module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_9(float * var_0, float * var_1, float * var_2);
    __global__ void method_12(float * var_0, float * var_1);
    __global__ void method_14(float * var_0, float * var_1, float * var_2);
    __global__ void method_22(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_24(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_27(float * var_0, float * var_1);
    __global__ void method_30(float * var_0, float * var_1);
    __global__ void method_32(float * var_0, float * var_1);
    __global__ void method_34(float * var_0, float * var_1);
    __global__ void method_40(float * var_0, float * var_1, float * var_2);
    __device__ void method_10(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    __device__ void method_13(float * var_0, float * var_1, long long int var_2);
    __device__ float method_15(float * var_0, float * var_1, float var_2, long long int var_3);
    typedef float(*FunPointer0)(float, float);
    __device__ float method_16(float var_0, float var_1);
    __device__ void method_23(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5);
    __device__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4);
    __device__ void method_28(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8);
    __device__ void method_31(float * var_0, float * var_1, long long int var_2);
    __device__ void method_33(float * var_0, float * var_1, long long int var_2);
    __device__ void method_35(float * var_0, float * var_1, long long int var_2);
    __device__ void method_41(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    __device__ void method_11(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4);
    __device__ float method_29(long long int var_0, float * var_1, float var_2, long long int var_3);
    struct Tuple1 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, float mem_1){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __device__ Tuple1 method_42(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5);
    
    __global__ void method_9(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (32 * var_6);
        long long int var_10 = (var_3 + var_9);
        method_10(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_10);
    }
    __global__ void method_12(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_13(var_0, var_1, var_9);
    }
    __global__ void method_14(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        float var_12 = method_15(var_0, var_1, var_11, var_10);
        FunPointer0 var_15 = method_16;
        float var_16 = cub::BlockReduce<float,128>().Reduce(var_12, var_15);
        char var_17 = (var_3 == 0);
        if (var_17) {
            char var_18 = (var_6 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_6 < 1);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                printf("Argument out of bounds.");
            } else {
            }
            var_2[var_6] = var_16;
        } else {
        }
    }
    __global__ void method_22(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_23(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __global__ void method_24(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 * 128);
        long long int var_11 = (var_10 + var_4);
        method_25(var_0, var_1, var_2, var_3, var_11);
    }
    __global__ void method_27(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (32 * var_5);
        long long int var_9 = (var_2 + var_8);
        method_28(var_5, var_6, var_7, var_0, var_1, var_2, var_3, var_4, var_9);
    }
    __global__ void method_30(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_31(var_0, var_1, var_9);
    }
    __global__ void method_32(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_33(var_0, var_1, var_9);
    }
    __global__ void method_34(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_35(var_0, var_1, var_9);
    }
    __global__ void method_40(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        method_41(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_9);
    }
    __device__ void method_10(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 32);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_13 = (var_7 + var_1);
            method_11(var_3, var_9, var_4, var_5, var_13);
            long long int var_14 = (var_9 + 32);
            method_10(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_14);
        } else {
        }
    }
    __device__ void method_13(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 32);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (-var_6);
            float var_9 = exp(var_8);
            float var_10 = (1 + var_9);
            float var_11 = (1 / var_10);
            var_1[var_2] = var_11;
            long long int var_12 = (var_2 + 128);
            method_13(var_0, var_1, var_12);
        } else {
        }
    }
    __device__ float method_15(float * var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 32);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_7 = var_0[var_3];
            float var_8 = var_1[var_3];
            float var_9 = (var_8 - var_7);
            float var_10 = (var_9 * var_9);
            float var_11 = (var_2 + var_10);
            long long int var_12 = (var_3 + 128);
            return method_15(var_0, var_1, var_11, var_12);
        } else {
            return var_2;
        }
    }
    __device__ float method_16(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_23(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < 32);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_8) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_9 = var_2[var_5];
            float var_10 = var_3[var_5];
            float var_11 = var_4[var_5];
            float var_12 = (var_9 - var_10);
            float var_13 = (2 * var_12);
            float var_14 = (var_0 * var_13);
            float var_15 = (var_11 + var_14);
            var_4[var_5] = var_15;
            long long int var_16 = (var_5 + 128);
            method_23(var_0, var_1, var_2, var_3, var_4, var_16);
        } else {
        }
    }
    __device__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 32);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_7) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_8 = var_0[var_4];
            float var_9 = var_1[var_4];
            float var_10 = var_2[var_4];
            float var_11 = var_3[var_4];
            float var_12 = (1 - var_10);
            float var_13 = (var_10 * var_12);
            float var_14 = (var_9 * var_13);
            float var_15 = (var_11 + var_14);
            var_3[var_4] = var_15;
            long long int var_16 = (var_4 + 128);
            method_25(var_0, var_1, var_2, var_3, var_16);
        } else {
        }
    }
    __device__ void method_28(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8) {
        char var_9 = (var_8 < 32);
        if (var_9) {
            char var_10 = (var_8 >= 0);
            char var_11 = (var_10 == 0);
            if (var_11) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_11) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_12 = (var_6 + var_1);
            float var_13 = 0;
            float var_14 = method_29(var_8, var_3, var_13, var_12);
            float var_15 = var_4[var_8];
            float var_16 = (var_14 + var_15);
            var_4[var_8] = var_16;
            long long int var_17 = (var_8 + 32);
            method_28(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_17);
        } else {
        }
    }
    __device__ void method_31(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 25088);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 8192);
            method_31(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_33(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 32);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 128);
            method_33(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_35(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 32);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            if (var_5) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            var_1[var_2] = var_6;
            long long int var_8 = (var_2 + 128);
            method_35(var_0, var_1, var_8);
        } else {
        }
    }
    __device__ void method_41(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 1);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_13 = (var_9 * 32);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_14 = (var_6 + var_0);
            float var_15 = __int_as_float(0xff800000);
            float var_16 = 0;
            Tuple1 var_17 = method_42(var_3, var_13, var_4, var_15, var_16, var_14);
            float var_18 = var_17.mem_0;
            float var_19 = var_17.mem_1;
            char var_20 = (var_6 == 0);
            if (var_20) {
                if (var_12) {
                    printf("Argument out of bounds.");
                } else {
                }
            } else {
            }
            long long int var_21 = (var_9 + 1);
            method_41(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_21);
        } else {
        }
    }
    __device__ void method_11(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 1);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_8 = (var_4 * 32);
            char var_9 = (var_1 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_1 < 32);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_13 = (var_8 + var_1);
            if (var_7) {
                printf("Argument out of bounds.");
            } else {
            }
            char var_15;
            if (var_9) {
                var_15 = (var_1 < 32);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                printf("Argument out of bounds.");
            } else {
            }
            float var_17 = var_0[var_1];
            float var_18 = var_2[var_13];
            float var_19 = var_3[var_13];
            float var_20 = (var_17 + var_18);
            var_3[var_13] = var_20;
            long long int var_21 = (var_4 + 1);
            method_11(var_0, var_1, var_2, var_3, var_21);
        } else {
        }
    }
    __device__ float method_29(long long int var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 1);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_7 = (var_3 * 32);
            char var_8 = (var_0 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_0 < 32);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_12 = (var_7 + var_0);
            float var_13 = var_1[var_12];
            float var_14 = (var_2 + var_13);
            long long int var_15 = (var_3 + 1);
            return method_29(var_0, var_1, var_14, var_15);
        } else {
            return var_2;
        }
    }
    __device__ Tuple1 method_42(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 32);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_9 = (var_1 + var_5);
            float var_10 = var_0[var_9];
            float var_11 = var_2[var_9];
            char var_12 = (var_3 > var_10);
            Tuple1 var_13;
            if (var_12) {
                var_13 = make_Tuple1(var_3, var_4);
            } else {
                var_13 = make_Tuple1(var_10, var_11);
            }
            float var_14 = var_13.mem_0;
            float var_15 = var_13.mem_1;
            long long int var_16 = (var_5 + 1);
            return method_42(var_0, var_1, var_2, var_14, var_15, var_16);
        } else {
            return make_Tuple1(var_3, var_4);
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
and Env4 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union5 =
    | Union5Case0 of Tuple6
    | Union5Case1
and Tuple6 =
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env3 =
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
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env3), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_5((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 3L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: int64) = 0L
        let (var_18: Env4) = method_7((var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_16: int64), (var_15: float), (var_17: int64))
        let (var_19: int64) = var_18.mem_0
        let (var_20: float) = var_18.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: string) = System.String.Format("Average of batch costs is {0}.",var_20)
        let (var_22: string) = System.String.Format("{0}",var_21)
        System.Console.WriteLine(var_22)
        let (var_23: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_19,1L)
        let (var_24: string) = System.String.Format("{0}",var_23)
        System.Console.WriteLine(var_24)
        System.Console.WriteLine("-----")
        let (var_25: int64) = (var_13 + 1L)
        method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_25: int64))
    else
        ()
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env3), (var_6: int64)): Env3 =
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
    var_4.Push((Env2((Env3(var_21)), var_3)))
    (Env3(var_21))
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env3 =
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
    var_3.Push((Env2((Env3(var_11)), var_2)))
    (Env3(var_11))
and method_7((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_15: int64)): Env4 =
    let (var_16: bool) = (var_15 < 1L)
    if var_16 then
        let (var_17: int64) = (var_15 + 1L)
        let (var_18: bool) = (var_15 >= 0L)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_20: bool) = (var_17 > 0L)
        let (var_22: bool) =
            if var_20 then
                (var_17 <= 1L)
            else
                false
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_24: int64) = (var_15 * 784L)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_26: bool) =
            if var_20 then
                (var_17 <= 1L)
            else
                false
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_28: int64) = (var_15 * 32L)
        let (var_29: int64) = 128L
        let (var_30: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_29: int64))
        let (var_31: (Union0 ref)) = var_30.mem_0
        method_8((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_24: int64), (var_10: (Union0 ref)), (var_31: (Union0 ref)))
        let (var_32: int64) = 128L
        let (var_33: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_32: int64))
        let (var_34: (Union0 ref)) = var_33.mem_0
        let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_34: (Union0 ref)))
        let (var_36: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_37: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_35, 0uy, var_37, var_36)
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_7: (Union0 ref)))
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_31: (Union0 ref)))
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_31: (Union0 ref)))
        // Cuda join point
        // method_9((var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_39: ManagedCuda.BasicTypes.CUdeviceptr), (var_40: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_42: (System.Object [])) = [|var_38; var_39; var_40|]: (System.Object [])
        let (var_43: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_9", var_4, var_3)
        let (var_44: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_43.set_GridDimensions(var_44)
        let (var_45: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_43.set_BlockDimensions(var_45)
        let (var_46: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_43.RunAsync(var_46, var_42)
        let (var_51: int64) = 128L
        let (var_52: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_51: int64))
        let (var_53: (Union0 ref)) = var_52.mem_0
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_31: (Union0 ref)))
        let (var_55: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        // Cuda join point
        // method_12((var_54: ManagedCuda.BasicTypes.CUdeviceptr), (var_55: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_57: (System.Object [])) = [|var_54; var_55|]: (System.Object [])
        let (var_58: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_12", var_4, var_3)
        let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_58.set_GridDimensions(var_59)
        let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_58.set_BlockDimensions(var_60)
        let (var_61: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_58.RunAsync(var_61, var_57)
        let (var_62: int64) = 128L
        let (var_63: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_62: int64))
        let (var_64: (Union0 ref)) = var_63.mem_0
        let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_64: (Union0 ref)))
        let (var_66: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_67: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_65, 0uy, var_67, var_66)
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_72: int64) = 4L
        let (var_73: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_72: int64))
        let (var_74: (Union0 ref)) = var_73.mem_0
        let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_74: (Union0 ref)))
        // Cuda join point
        // method_14((var_68: ManagedCuda.BasicTypes.CUdeviceptr), (var_69: ManagedCuda.BasicTypes.CUdeviceptr), (var_75: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_77: (System.Object [])) = [|var_68; var_69; var_75|]: (System.Object [])
        let (var_78: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_4, var_3)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_78.set_GridDimensions(var_79)
        let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_78.set_BlockDimensions(var_80)
        let (var_81: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_78.RunAsync(var_81, var_77)
        let (var_83: (Union5 ref)) = (ref Union5Case1)
        let (var_84: (float32 ref)) = (ref 0.000000f)
        let (var_86: (Union5 ref)) = (ref Union5Case1)
        let (var_87: (float32 ref)) = (ref 0.000000f)
        let (var_88: float32) = method_21((var_74: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_83: (Union5 ref)), (var_86: (Union5 ref)))
        var_87 := 1.000000f
        let (var_89: float32) = method_21((var_74: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_83: (Union5 ref)), (var_86: (Union5 ref)))
        let (var_90: float32) = (!var_87)
        let (var_91: float32) = method_20((var_74: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_83: (Union5 ref)))
        let (var_92: float32) = (!var_84)
        let (var_93: float32) = (var_92 + var_90)
        var_84 := var_93
        let (var_94: float32) = method_20((var_74: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_83: (Union5 ref)))
        let (var_95: float32) = (!var_84)
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_64: (Union0 ref)))
        // Cuda join point
        // method_22((var_95: float32), (var_94: float32), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_100: (System.Object [])) = [|var_95; var_94; var_96; var_97; var_98|]: (System.Object [])
        let (var_101: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_4, var_3)
        let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_101.set_GridDimensions(var_102)
        let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_101.set_BlockDimensions(var_103)
        let (var_104: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_101.RunAsync(var_104, var_100)
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_31: (Union0 ref)))
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_64: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_34: (Union0 ref)))
        // Cuda join point
        // method_24((var_105: ManagedCuda.BasicTypes.CUdeviceptr), (var_106: ManagedCuda.BasicTypes.CUdeviceptr), (var_107: ManagedCuda.BasicTypes.CUdeviceptr), (var_108: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_110: (System.Object [])) = [|var_105; var_106; var_107; var_108|]: (System.Object [])
        let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_111.set_GridDimensions(var_112)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_111.set_BlockDimensions(var_113)
        let (var_114: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_111.RunAsync(var_114, var_110)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_24: int64), (var_34: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_34: (Union0 ref)))
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        // Cuda join point
        // method_27((var_115: ManagedCuda.BasicTypes.CUdeviceptr), (var_116: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_118: (System.Object [])) = [|var_115; var_116|]: (System.Object [])
        let (var_119: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_4, var_3)
        let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_119.set_GridDimensions(var_120)
        let (var_121: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_119.set_BlockDimensions(var_121)
        let (var_122: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_119.RunAsync(var_122, var_118)
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_9: (Union0 ref)))
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_10: (Union0 ref)))
        // Cuda join point
        // method_30((var_123: ManagedCuda.BasicTypes.CUdeviceptr), (var_124: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_126: (System.Object [])) = [|var_123; var_124|]: (System.Object [])
        let (var_127: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_4, var_3)
        let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_127.set_GridDimensions(var_128)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_127.set_BlockDimensions(var_129)
        let (var_130: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_127.RunAsync(var_130, var_126)
        let (var_131: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_9: (Union0 ref)))
        let (var_132: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_133: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100352L)
        var_3.ClearMemoryAsync(var_131, 0uy, var_133, var_132)
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_7: (Union0 ref)))
        // Cuda join point
        // method_32((var_134: ManagedCuda.BasicTypes.CUdeviceptr), (var_135: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_137: (System.Object [])) = [|var_134; var_135|]: (System.Object [])
        let (var_138: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_4, var_3)
        let (var_139: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_138.set_GridDimensions(var_139)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_138.set_BlockDimensions(var_140)
        let (var_141: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_138.RunAsync(var_141, var_137)
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        let (var_143: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_142, 0uy, var_144, var_143)
        let (var_145: float) = (float var_88)
        let (var_146: float) = (var_14 + var_145)
        let (var_147: int64) = 128L
        let (var_148: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_147: int64))
        let (var_149: (Union0 ref)) = var_148.mem_0
        let (var_150: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_149: (Union0 ref)))
        // Cuda join point
        // method_34((var_150: ManagedCuda.BasicTypes.CUdeviceptr), (var_151: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_153: (System.Object [])) = [|var_150; var_151|]: (System.Object [])
        let (var_154: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_155: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_154.set_GridDimensions(var_155)
        let (var_156: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_154.set_BlockDimensions(var_156)
        let (var_157: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_154.RunAsync(var_157, var_153)
        let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_149: (Union0 ref)))
        let (var_159: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
        var_3.CopyToHost(var_159, var_158)
        var_3.Synchronize()
        let (var_160: int64) = 128L
        let (var_161: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_160: int64))
        let (var_162: (Union0 ref)) = var_161.mem_0
        let (var_163: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_162: (Union0 ref)))
        // Cuda join point
        // method_34((var_163: ManagedCuda.BasicTypes.CUdeviceptr), (var_164: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_166: (System.Object [])) = [|var_163; var_164|]: (System.Object [])
        let (var_167: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_167.set_GridDimensions(var_168)
        let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_167.set_BlockDimensions(var_169)
        let (var_170: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_167.RunAsync(var_170, var_166)
        let (var_171: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_162: (Union0 ref)))
        let (var_172: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
        var_3.CopyToHost(var_172, var_171)
        var_3.Synchronize()
        let (var_173: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_174: string) = ""
        let (var_175: int64) = 0L
        method_36((var_173: System.Text.StringBuilder), (var_175: int64))
        let (var_176: System.Text.StringBuilder) = var_173.AppendLine("[|")
        let (var_177: int64) = 0L
        method_37((var_173: System.Text.StringBuilder), (var_174: string), (var_159: (float32 [])), (var_177: int64))
        let (var_178: int64) = 0L
        method_36((var_173: System.Text.StringBuilder), (var_178: int64))
        let (var_179: System.Text.StringBuilder) = var_173.AppendLine("|]")
        let (var_180: string) = var_173.ToString()
        let (var_181: string) = System.String.Format("{0}",var_180)
        System.Console.WriteLine(var_181)
        let (var_182: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_183: string) = ""
        let (var_184: int64) = 0L
        method_36((var_182: System.Text.StringBuilder), (var_184: int64))
        let (var_185: System.Text.StringBuilder) = var_182.AppendLine("[|")
        let (var_186: int64) = 0L
        method_37((var_182: System.Text.StringBuilder), (var_183: string), (var_172: (float32 [])), (var_186: int64))
        let (var_187: int64) = 0L
        method_36((var_182: System.Text.StringBuilder), (var_187: int64))
        let (var_188: System.Text.StringBuilder) = var_182.AppendLine("|]")
        let (var_189: string) = var_182.ToString()
        let (var_190: string) = System.String.Format("{0}",var_189)
        System.Console.WriteLine(var_190)
        let (var_191: int64) = 4L
        let (var_192: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_191: int64))
        let (var_193: (Union0 ref)) = var_192.mem_0
        let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_53: (Union0 ref)))
        let (var_195: int64) = (var_28 * 4L)
        let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_197: ManagedCuda.BasicTypes.SizeT) = var_196.Pointer
        let (var_198: uint64) = uint64 var_197
        let (var_199: uint64) = (uint64 var_195)
        let (var_200: uint64) = (var_198 + var_199)
        let (var_201: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_200)
        let (var_202: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_201)
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_193: (Union0 ref)))
        // Cuda join point
        // method_40((var_194: ManagedCuda.BasicTypes.CUdeviceptr), (var_202: ManagedCuda.BasicTypes.CUdeviceptr), (var_203: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_205: (System.Object [])) = [|var_194; var_202; var_203|]: (System.Object [])
        let (var_206: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_4, var_3)
        let (var_207: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_206.set_GridDimensions(var_207)
        let (var_208: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_206.set_BlockDimensions(var_208)
        let (var_209: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_206.RunAsync(var_209, var_205)
        let (var_210: float32) = 0.000000f
        let (var_211: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_193: (Union0 ref)))
        let (var_212: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
        var_3.CopyToHost(var_212, var_211)
        var_3.Synchronize()
        let (var_213: int64) = var_212.LongLength
        let (var_214: int64) = 0L
        let (var_215: float32) = method_43((var_212: (float32 [])), (var_213: int64), (var_210: float32), (var_214: int64))
        let (var_216: int64) = (int64 var_215)
        var_193 := Union0Case1
        var_162 := Union0Case1
        var_149 := Union0Case1
        let (var_217: int64) = (var_13 + var_216)
        var_74 := Union0Case1
        var_64 := Union0Case1
        var_53 := Union0Case1
        var_34 := Union0Case1
        var_31 := Union0Case1
        method_44((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_217: int64), (var_146: float), (var_17: int64))
    else
        (Env4(var_13, var_14))
and method_8((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_1: (Union0 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = var_9.Pointer
    let (var_11: uint64) = uint64 var_10
    let (var_12: uint64) = (uint64 var_8)
    let (var_13: uint64) = (var_11 + var_12)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_3: (Union0 ref)))
    let (var_17: (float32 ref)) = (ref 0.000000f)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_4: (Union0 ref)))
    let (var_19: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 1, 32, 784, var_7, var_15, 1, var_16, 784, var_17, var_18, 1)
    if var_19 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_19)
and method_21((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union5 ref)), (var_3: (Union5 ref))): float32 =
    let (var_4: Union5) = (!var_3)
    match var_4 with
    | Union5Case0(var_5) ->
        var_5.mem_0
    | Union5Case1 ->
        let (var_7: float32) = method_19((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union5 ref)))
        var_3 := (Union5Case0(Tuple6(var_7)))
        var_7
and method_20((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union5 ref))): float32 =
    let (var_3: Union5) = (!var_2)
    match var_3 with
    | Union5Case0(var_4) ->
        var_4.mem_0
    | Union5Case1 ->
        let (var_6: float32) = method_17((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext))
        var_2 := (Union5Case0(Tuple6(var_6)))
        var_6
and method_26((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_1: (Union0 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = var_9.Pointer
    let (var_11: uint64) = uint64 var_10
    let (var_12: uint64) = (uint64 var_8)
    let (var_13: uint64) = (var_11 + var_12)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_3: (Union0 ref)))
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_4: (Union0 ref)))
    let (var_19: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 784, 32, 1, var_7, var_15, 1, var_16, 1, var_17, var_18, 784)
    if var_19 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_19)
and method_36((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_36((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_37((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 1L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_3 * 32L)
        let (var_8: int64) = 0L
        method_38((var_0: System.Text.StringBuilder), (var_8: int64))
        let (var_9: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_10: int64) = 0L
        let (var_11: string) = method_39((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_7: int64), (var_1: string), (var_10: int64))
        let (var_12: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_13: int64) = (var_3 + 1L)
        method_37((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_13: int64))
    else
        ()
and method_43((var_0: (float32 [])), (var_1: int64), (var_2: float32), (var_3: int64)): float32 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: float32) = var_0.[int32 var_3]
        let (var_6: float32) = (var_2 + var_5)
        let (var_7: int64) = (var_3 + 1L)
        method_43((var_0: (float32 [])), (var_1: int64), (var_6: float32), (var_7: int64))
    else
        var_2
and method_44((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_15: int64), (var_16: float), (var_17: int64)): Env4 =
    let (var_18: bool) = (var_17 < 1L)
    if var_18 then
        let (var_19: int64) = (var_17 + 1L)
        let (var_20: bool) = (var_17 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_22: bool) = (var_19 > 0L)
        let (var_24: bool) =
            if var_22 then
                (var_19 <= 1L)
            else
                false
        let (var_25: bool) = (var_24 = false)
        if var_25 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_26: int64) = (var_17 * 784L)
        if var_21 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_28: bool) =
            if var_22 then
                (var_19 <= 1L)
            else
                false
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_30: int64) = (var_17 * 32L)
        let (var_31: int64) = 128L
        let (var_32: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_31: int64))
        let (var_33: (Union0 ref)) = var_32.mem_0
        method_8((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_26: int64), (var_10: (Union0 ref)), (var_33: (Union0 ref)))
        let (var_34: int64) = 128L
        let (var_35: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_34: int64))
        let (var_36: (Union0 ref)) = var_35.mem_0
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_36: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_37, 0uy, var_39, var_38)
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_7: (Union0 ref)))
        let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_33: (Union0 ref)))
        let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_33: (Union0 ref)))
        // Cuda join point
        // method_9((var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_41: ManagedCuda.BasicTypes.CUdeviceptr), (var_42: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_44: (System.Object [])) = [|var_40; var_41; var_42|]: (System.Object [])
        let (var_45: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_9", var_4, var_3)
        let (var_46: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_45.set_GridDimensions(var_46)
        let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_45.set_BlockDimensions(var_47)
        let (var_48: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_45.RunAsync(var_48, var_44)
        let (var_53: int64) = 128L
        let (var_54: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_53: int64))
        let (var_55: (Union0 ref)) = var_54.mem_0
        let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_33: (Union0 ref)))
        let (var_57: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        // Cuda join point
        // method_12((var_56: ManagedCuda.BasicTypes.CUdeviceptr), (var_57: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_59: (System.Object [])) = [|var_56; var_57|]: (System.Object [])
        let (var_60: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_12", var_4, var_3)
        let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_60.set_GridDimensions(var_61)
        let (var_62: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_60.set_BlockDimensions(var_62)
        let (var_63: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_60.RunAsync(var_63, var_59)
        let (var_64: int64) = 128L
        let (var_65: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_64: int64))
        let (var_66: (Union0 ref)) = var_65.mem_0
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
        let (var_68: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_67, 0uy, var_69, var_68)
        let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_74: int64) = 4L
        let (var_75: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_74: int64))
        let (var_76: (Union0 ref)) = var_75.mem_0
        let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_76: (Union0 ref)))
        // Cuda join point
        // method_14((var_70: ManagedCuda.BasicTypes.CUdeviceptr), (var_71: ManagedCuda.BasicTypes.CUdeviceptr), (var_77: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_79: (System.Object [])) = [|var_70; var_71; var_77|]: (System.Object [])
        let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_4, var_3)
        let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_80.set_GridDimensions(var_81)
        let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_80.set_BlockDimensions(var_82)
        let (var_83: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_80.RunAsync(var_83, var_79)
        let (var_85: (Union5 ref)) = (ref Union5Case1)
        let (var_86: (float32 ref)) = (ref 0.000000f)
        let (var_88: (Union5 ref)) = (ref Union5Case1)
        let (var_89: (float32 ref)) = (ref 0.000000f)
        let (var_90: float32) = method_21((var_76: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_85: (Union5 ref)), (var_88: (Union5 ref)))
        var_89 := 1.000000f
        let (var_91: float32) = method_21((var_76: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_85: (Union5 ref)), (var_88: (Union5 ref)))
        let (var_92: float32) = (!var_89)
        let (var_93: float32) = method_20((var_76: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_85: (Union5 ref)))
        let (var_94: float32) = (!var_86)
        let (var_95: float32) = (var_94 + var_92)
        var_86 := var_95
        let (var_96: float32) = method_20((var_76: (Union0 ref)), (var_3: ManagedCuda.CudaContext), (var_85: (Union5 ref)))
        let (var_97: float32) = (!var_86)
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_100: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
        // Cuda join point
        // method_22((var_97: float32), (var_96: float32), (var_98: ManagedCuda.BasicTypes.CUdeviceptr), (var_99: ManagedCuda.BasicTypes.CUdeviceptr), (var_100: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_102: (System.Object [])) = [|var_97; var_96; var_98; var_99; var_100|]: (System.Object [])
        let (var_103: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_4, var_3)
        let (var_104: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_103.set_GridDimensions(var_104)
        let (var_105: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_103.set_BlockDimensions(var_105)
        let (var_106: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_103.RunAsync(var_106, var_102)
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_33: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
        let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_36: (Union0 ref)))
        // Cuda join point
        // method_24((var_107: ManagedCuda.BasicTypes.CUdeviceptr), (var_108: ManagedCuda.BasicTypes.CUdeviceptr), (var_109: ManagedCuda.BasicTypes.CUdeviceptr), (var_110: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_112: (System.Object [])) = [|var_107; var_108; var_109; var_110|]: (System.Object [])
        let (var_113: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_113.set_GridDimensions(var_114)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_113.set_BlockDimensions(var_115)
        let (var_116: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_113.RunAsync(var_116, var_112)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_26: int64), (var_36: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_117: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_36: (Union0 ref)))
        let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        // Cuda join point
        // method_27((var_117: ManagedCuda.BasicTypes.CUdeviceptr), (var_118: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_120: (System.Object [])) = [|var_117; var_118|]: (System.Object [])
        let (var_121: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_4, var_3)
        let (var_122: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_121.set_GridDimensions(var_122)
        let (var_123: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_121.set_BlockDimensions(var_123)
        let (var_124: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_121.RunAsync(var_124, var_120)
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_9: (Union0 ref)))
        let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_10: (Union0 ref)))
        // Cuda join point
        // method_30((var_125: ManagedCuda.BasicTypes.CUdeviceptr), (var_126: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_128: (System.Object [])) = [|var_125; var_126|]: (System.Object [])
        let (var_129: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_4, var_3)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_129.set_GridDimensions(var_130)
        let (var_131: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_129.set_BlockDimensions(var_131)
        let (var_132: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_129.RunAsync(var_132, var_128)
        let (var_133: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_9: (Union0 ref)))
        let (var_134: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100352L)
        var_3.ClearMemoryAsync(var_133, 0uy, var_135, var_134)
        let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_7: (Union0 ref)))
        // Cuda join point
        // method_32((var_136: ManagedCuda.BasicTypes.CUdeviceptr), (var_137: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_139: (System.Object [])) = [|var_136; var_137|]: (System.Object [])
        let (var_140: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_4, var_3)
        let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_140.set_GridDimensions(var_141)
        let (var_142: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_140.set_BlockDimensions(var_142)
        let (var_143: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_140.RunAsync(var_143, var_139)
        let (var_144: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_6: (Union0 ref)))
        let (var_145: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_146: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
        var_3.ClearMemoryAsync(var_144, 0uy, var_146, var_145)
        let (var_147: float) = (float var_90)
        let (var_148: float) = (var_16 + var_147)
        let (var_149: int64) = 128L
        let (var_150: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_149: int64))
        let (var_151: (Union0 ref)) = var_150.mem_0
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_151: (Union0 ref)))
        // Cuda join point
        // method_34((var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_153: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_155: (System.Object [])) = [|var_152; var_153|]: (System.Object [])
        let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_156.set_GridDimensions(var_157)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_156.set_BlockDimensions(var_158)
        let (var_159: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_156.RunAsync(var_159, var_155)
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_151: (Union0 ref)))
        let (var_161: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
        var_3.CopyToHost(var_161, var_160)
        var_3.Synchronize()
        let (var_162: int64) = 128L
        let (var_163: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_162: int64))
        let (var_164: (Union0 ref)) = var_163.mem_0
        let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_164: (Union0 ref)))
        // Cuda join point
        // method_34((var_165: ManagedCuda.BasicTypes.CUdeviceptr), (var_166: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_168: (System.Object [])) = [|var_165; var_166|]: (System.Object [])
        let (var_169: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_169.set_GridDimensions(var_170)
        let (var_171: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_169.set_BlockDimensions(var_171)
        let (var_172: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_169.RunAsync(var_172, var_168)
        let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_164: (Union0 ref)))
        let (var_174: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
        var_3.CopyToHost(var_174, var_173)
        var_3.Synchronize()
        let (var_175: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_176: string) = ""
        let (var_177: int64) = 0L
        method_36((var_175: System.Text.StringBuilder), (var_177: int64))
        let (var_178: System.Text.StringBuilder) = var_175.AppendLine("[|")
        let (var_179: int64) = 0L
        method_37((var_175: System.Text.StringBuilder), (var_176: string), (var_161: (float32 [])), (var_179: int64))
        let (var_180: int64) = 0L
        method_36((var_175: System.Text.StringBuilder), (var_180: int64))
        let (var_181: System.Text.StringBuilder) = var_175.AppendLine("|]")
        let (var_182: string) = var_175.ToString()
        let (var_183: string) = System.String.Format("{0}",var_182)
        System.Console.WriteLine(var_183)
        let (var_184: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_185: string) = ""
        let (var_186: int64) = 0L
        method_36((var_184: System.Text.StringBuilder), (var_186: int64))
        let (var_187: System.Text.StringBuilder) = var_184.AppendLine("[|")
        let (var_188: int64) = 0L
        method_37((var_184: System.Text.StringBuilder), (var_185: string), (var_174: (float32 [])), (var_188: int64))
        let (var_189: int64) = 0L
        method_36((var_184: System.Text.StringBuilder), (var_189: int64))
        let (var_190: System.Text.StringBuilder) = var_184.AppendLine("|]")
        let (var_191: string) = var_184.ToString()
        let (var_192: string) = System.String.Format("{0}",var_191)
        System.Console.WriteLine(var_192)
        let (var_193: int64) = 4L
        let (var_194: Env3) = method_2((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_1: uint64), (var_193: int64))
        let (var_195: (Union0 ref)) = var_194.mem_0
        let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_55: (Union0 ref)))
        let (var_197: int64) = (var_30 * 4L)
        let (var_198: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_12: (Union0 ref)))
        let (var_199: ManagedCuda.BasicTypes.SizeT) = var_198.Pointer
        let (var_200: uint64) = uint64 var_199
        let (var_201: uint64) = (uint64 var_197)
        let (var_202: uint64) = (var_200 + var_201)
        let (var_203: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_202)
        let (var_204: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_203)
        let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_195: (Union0 ref)))
        // Cuda join point
        // method_40((var_196: ManagedCuda.BasicTypes.CUdeviceptr), (var_204: ManagedCuda.BasicTypes.CUdeviceptr), (var_205: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_207: (System.Object [])) = [|var_196; var_204; var_205|]: (System.Object [])
        let (var_208: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_4, var_3)
        let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_208.set_GridDimensions(var_209)
        let (var_210: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_208.set_BlockDimensions(var_210)
        let (var_211: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_208.RunAsync(var_211, var_207)
        let (var_212: float32) = 0.000000f
        let (var_213: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_195: (Union0 ref)))
        let (var_214: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
        var_3.CopyToHost(var_214, var_213)
        var_3.Synchronize()
        let (var_215: int64) = var_214.LongLength
        let (var_216: int64) = 0L
        let (var_217: float32) = method_43((var_214: (float32 [])), (var_215: int64), (var_212: float32), (var_216: int64))
        let (var_218: int64) = (int64 var_217)
        var_195 := Union0Case1
        var_164 := Union0Case1
        var_151 := Union0Case1
        let (var_219: int64) = (var_15 + var_218)
        var_76 := Union0Case1
        var_66 := Union0Case1
        var_55 := Union0Case1
        var_36 := Union0Case1
        var_33 := Union0Case1
        method_44((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env2>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_219: int64), (var_148: float), (var_19: int64))
    else
        (Env4(var_15, var_16))
and method_19((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union5 ref))): float32 =
    method_20((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union5 ref)))
and method_17((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext)): float32 =
    let (var_2: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_0: (Union0 ref)))
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_1.CopyToHost(var_3, var_2)
    var_1.Synchronize()
    let (var_4: float32) = 0.000000f
    let (var_5: int64) = 0L
    method_18((var_3: (float32 [])), (var_4: float32), (var_5: int64))
and method_38((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_38((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_39((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: string), (var_4: int64)): string =
    let (var_5: bool) = (var_4 < 32L)
    if var_5 then
        let (var_6: System.Text.StringBuilder) = var_0.Append(var_3)
        let (var_7: bool) = (var_4 >= 0L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: int64) = (var_2 + var_4)
        let (var_10: float32) = var_1.[int32 var_9]
        let (var_11: string) = System.String.Format("{0}",var_10)
        let (var_12: System.Text.StringBuilder) = var_0.Append(var_11)
        let (var_13: string) = "; "
        let (var_14: int64) = (var_4 + 1L)
        method_39((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_13: string), (var_14: int64))
    else
        var_3
and method_18((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 1L)
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
        method_18((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
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
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_51: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_50)
let (var_52: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_51.SetStream(var_52)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaBlas.CudaBlasHandle) = var_55.get_CublasHandle()
let (var_57: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_55.set_Stream(var_57)
let (var_58: int64) = 100352L
let (var_59: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_62: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(25088L)
var_51.GenerateNormal32(var_61, var_62, 0.000000f, 0.049507f)
let (var_63: int64) = 100352L
let (var_64: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_63: int64))
let (var_65: (Union0 ref)) = var_64.mem_0
let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_65: (Union0 ref)))
let (var_67: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_68: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100352L)
var_1.ClearMemoryAsync(var_66, 0uy, var_68, var_67)
let (var_69: int64) = 128L
let (var_70: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_69: int64))
let (var_71: (Union0 ref)) = var_70.mem_0
let (var_72: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_71: (Union0 ref)))
let (var_73: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_74: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
var_1.ClearMemoryAsync(var_72, 0uy, var_74, var_73)
let (var_75: int64) = 128L
let (var_76: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_75: int64))
let (var_77: (Union0 ref)) = var_76.mem_0
let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_77: (Union0 ref)))
let (var_79: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_80: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(128L)
var_1.ClearMemoryAsync(var_78, 0uy, var_80, var_79)
let (var_81: int64) = 3136L
let (var_82: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_81: int64))
let (var_83: (Union0 ref)) = var_82.mem_0
let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_83: (Union0 ref)))
let (var_85: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(784L)
var_51.GenerateUniform32(var_84, var_85)
let (var_86: int64) = 128L
let (var_87: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_86: int64))
let (var_88: (Union0 ref)) = var_87.mem_0
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_88: (Union0 ref)))
let (var_90: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32L)
var_51.GenerateUniform32(var_89, var_90)
let (var_91: int64) = 0L
method_6((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (Union0 ref)), (var_71: (Union0 ref)), (var_56: ManagedCuda.CudaBlas.CudaBlasHandle), (var_65: (Union0 ref)), (var_60: (Union0 ref)), (var_83: (Union0 ref)), (var_88: (Union0 ref)), (var_91: int64))
var_88 := Union0Case1
var_83 := Union0Case1
var_77 := Union0Case1
var_71 := Union0Case1
var_65 := Union0Case1
var_60 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_92)
var_43 := Union0Case1
var_1.Dispose()

