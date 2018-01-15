module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_17(float * var_0, float * var_1, float * var_2);
    __global__ void method_20(float * var_0, float * var_1);
    __global__ void method_22(float * var_0, float * var_1, float * var_2);
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_35(float * var_0, float * var_1);
    __global__ void method_39(float * var_0, float * var_1);
    __global__ void method_41(float * var_0, float * var_1);
    __global__ void method_43(float * var_0, float * var_1, float * var_2);
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    __device__ void method_21(float * var_0, float * var_1, long long int var_2);
    __device__ float method_23(float * var_0, float * var_1, float var_2, long long int var_3);
    typedef float(*FunPointer0)(float, float);
    __device__ float method_24(float var_0, float var_1);
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5);
    __device__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4);
    __device__ void method_36(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8);
    __device__ void method_40(float * var_0, float * var_1, long long int var_2);
    __device__ void method_42(float * var_0, float * var_1, long long int var_2);
    __device__ void method_44(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4);
    __device__ float method_37(long long int var_0, float * var_1, float var_2, long long int var_3);
    __device__ void method_38(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5);
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
    __device__ Tuple1 method_45(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5);
    
    __global__ void method_17(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (10 * var_6);
        long long int var_10 = (var_3 + var_9);
        method_18(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_10);
    }
    __global__ void method_20(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_21(var_0, var_1, var_9);
    }
    __global__ void method_22(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        float var_12 = method_23(var_0, var_1, var_11, var_10);
        FunPointer0 var_15 = method_24;
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
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_31(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 * 128);
        long long int var_11 = (var_10 + var_4);
        method_33(var_0, var_1, var_2, var_3, var_11);
    }
    __global__ void method_35(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (10 * var_5);
        long long int var_9 = (var_2 + var_8);
        method_36(var_5, var_6, var_7, var_0, var_1, var_2, var_3, var_4, var_9);
    }
    __global__ void method_39(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_40(var_0, var_1, var_9);
    }
    __global__ void method_41(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_42(var_0, var_1, var_9);
    }
    __global__ void method_43(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        method_44(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_9);
    }
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 10);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_13 = (2 * var_1);
            long long int var_14 = (var_7 + var_13);
            method_19(var_3, var_9, var_4, var_5, var_14);
            long long int var_15 = (var_9 + 10);
            method_18(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_15);
        } else {
        }
    }
    __device__ void method_21(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 20);
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
            method_21(var_0, var_1, var_12);
        } else {
        }
    }
    __device__ float method_23(float * var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 20);
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
            return method_23(var_0, var_1, var_11, var_12);
        } else {
            return var_2;
        }
    }
    __device__ float method_24(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < 20);
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
            method_31(var_0, var_1, var_2, var_3, var_4, var_16);
        } else {
        }
    }
    __device__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 20);
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
            method_33(var_0, var_1, var_2, var_3, var_16);
        } else {
        }
    }
    __device__ void method_36(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8) {
        char var_9 = (var_8 < 10);
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
            long long int var_12 = (2 * var_1);
            long long int var_13 = (var_6 + var_12);
            float var_14 = 0;
            float var_15 = method_37(var_8, var_3, var_14, var_13);
            __shared__ float var_16[10];
            char var_17 = (var_5 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_5 < 10);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                printf("Argument out of bounds.");
            } else {
            }
            char var_21 = (var_6 != 0);
            if (var_21) {
                char var_22 = (var_6 >= 1);
                char var_24;
                if (var_22) {
                    var_24 = (var_6 < 2);
                } else {
                    var_24 = 0;
                }
                char var_25 = (var_24 == 0);
                if (var_25) {
                    printf("Argument out of bounds.");
                } else {
                }
                long long int var_26 = (var_6 - 1);
                long long int var_27 = (var_5 + var_26);
                var_16[var_27] = var_15;
            } else {
            }
            __syncthreads();
            char var_28 = (var_6 == 0);
            if (var_28) {
                long long int var_29 = 1;
                method_38(var_16, var_5, var_4, var_8, var_15, var_29);
            } else {
            }
            long long int var_30 = (var_8 + 10);
            method_36(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_30);
        } else {
        }
    }
    __device__ void method_40(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 7840);
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
            long long int var_10 = (var_2 + 7936);
            method_40(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_42(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 10);
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
            method_42(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_44(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 2);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_13 = (var_9 * 10);
            if (var_12) {
                printf("Argument out of bounds.");
            } else {
            }
            printf("outer i = %d\n", var_9);
            long long int var_14 = (var_6 + var_0);
            float var_15 = __int_as_float(0xff800000);
            float var_16 = 0;
            Tuple1 var_17 = method_45(var_3, var_13, var_4, var_15, var_16, var_14);
            float var_18 = var_17.mem_0;
            float var_19 = var_17.mem_1;
            char var_20 = (var_6 == 0);
            if (var_20) {
                if (var_12) {
                    printf("Argument out of bounds.");
                } else {
                }
                float var_21 = var_5[var_9];
                var_5[var_9] = var_19;
            } else {
            }
            long long int var_22 = (var_9 + 1);
            method_44(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_22);
        } else {
        }
    }
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 2);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_8 = (var_4 * 10);
            char var_9 = (var_1 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_1 < 10);
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
                var_15 = (var_1 < 10);
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
            long long int var_21 = (var_4 + 2);
            method_19(var_0, var_1, var_2, var_3, var_21);
        } else {
        }
    }
    __device__ float method_37(long long int var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 2);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_7 = (var_3 * 10);
            char var_8 = (var_0 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_0 < 10);
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
            long long int var_15 = (var_3 + 2);
            return method_37(var_0, var_1, var_14, var_15);
        } else {
            return var_2;
        }
    }
    __device__ void method_38(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 2);
        if (var_6) {
            char var_7 = (var_5 >= 1);
            char var_8 = (var_7 == 0);
            if (var_8) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_9 = (var_5 - 1);
            long long int var_10 = (var_1 + var_9);
            float var_11 = var_0[var_10];
            float var_12 = (var_4 + var_11);
            long long int var_13 = (var_5 + 1);
            method_38(var_0, var_1, var_2, var_3, var_12, var_13);
        } else {
            float var_14 = var_2[var_3];
            float var_15 = (var_4 + var_14);
            var_2[var_3] = var_15;
        }
    }
    __device__ Tuple1 method_45(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 10);
        if (var_6) {
            printf("inner i = %d\n", var_5);
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                printf("Argument out of bounds.");
            } else {
            }
            long long int var_9 = (var_1 + var_5);
            float var_10 = var_0[var_9];
            float var_11 = var_2[var_9];
            printf("in: %f, in': %f\n", var_10, var_11);
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
            return method_45(var_0, var_1, var_2, var_14, var_15, var_16);
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
    val mem_0: Env6
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: Tuple4
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple4 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple5 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env6 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env7 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union8 =
    | Union8Case0 of Tuple9
    | Union8Case1
and Tuple9 =
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
and method_2((var_0: string)): Tuple3 =
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
    Tuple3(Tuple4(var_16, var_17, var_18), var_22)
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
and method_5((var_0: string)): Tuple5 =
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
    Tuple5(var_12, var_14)
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
and method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env6 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env6) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_11((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env6), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env6) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_12((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_13((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 3L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: int64) = 0L
        let (var_18: Env7) = method_15((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_16: int64), (var_15: float), (var_17: int64))
        let (var_19: int64) = var_18.mem_0
        let (var_20: float) = var_18.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: float) = (var_20 / 32.000000)
        let (var_22: string) = System.String.Format("Average of batch costs is {0}.",var_21)
        let (var_23: string) = System.String.Format("{0}",var_22)
        System.Console.WriteLine(var_23)
        let (var_24: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_19,32L)
        let (var_25: string) = System.String.Format("{0}",var_24)
        System.Console.WriteLine(var_25)
        System.Console.WriteLine("-----")
        let (var_26: int64) = (var_13 + 1L)
        method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_26: int64))
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
and method_11((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env6), (var_6: int64)): Env6 =
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
    var_4.Push((Env2((Env6(var_21)), var_3)))
    (Env6(var_21))
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env6 =
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
    var_3.Push((Env2((Env6(var_11)), var_2)))
    (Env6(var_11))
and method_15((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_15: int64)): Env7 =
    let (var_16: bool) = (var_15 < 32L)
    if var_16 then
        let (var_17: int64) = (var_15 + 2L)
        let (var_18: bool) = (var_15 >= 0L)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_20: bool) = (var_17 > 0L)
        let (var_22: bool) =
            if var_20 then
                (var_17 <= 32L)
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
                (var_17 <= 32L)
            else
                false
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_28: int64) = (var_15 * 10L)
        let (var_29: int64) = 80L
        let (var_30: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_29: int64))
        let (var_31: (Union0 ref)) = var_30.mem_0
        method_16((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_24: int64), (var_10: (Union0 ref)), (var_31: (Union0 ref)))
        let (var_32: int64) = 80L
        let (var_33: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_32: int64))
        let (var_34: (Union0 ref)) = var_33.mem_0
        let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_34: (Union0 ref)))
        let (var_36: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_37: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(80L)
        var_0.ClearMemoryAsync(var_35, 0uy, var_37, var_36)
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_31: (Union0 ref)))
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_31: (Union0 ref)))
        // Cuda join point
        // method_17((var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_39: ManagedCuda.BasicTypes.CUdeviceptr), (var_40: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_42: (System.Object [])) = [|var_38; var_39; var_40|]: (System.Object [])
        let (var_43: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_44: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_43.set_GridDimensions(var_44)
        let (var_45: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 2u, 1u)
        var_43.set_BlockDimensions(var_45)
        let (var_46: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_43.RunAsync(var_46, var_42)
        let (var_51: int64) = 80L
        let (var_52: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_51: int64))
        let (var_53: (Union0 ref)) = var_52.mem_0
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_31: (Union0 ref)))
        let (var_55: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_53: (Union0 ref)))
        // Cuda join point
        // method_20((var_54: ManagedCuda.BasicTypes.CUdeviceptr), (var_55: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_57: (System.Object [])) = [|var_54; var_55|]: (System.Object [])
        let (var_58: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_58.set_GridDimensions(var_59)
        let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_58.set_BlockDimensions(var_60)
        let (var_61: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_58.RunAsync(var_61, var_57)
        let (var_62: int64) = 80L
        let (var_63: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_62: int64))
        let (var_64: (Union0 ref)) = var_63.mem_0
        let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_64: (Union0 ref)))
        let (var_66: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_67: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(80L)
        var_0.ClearMemoryAsync(var_65, 0uy, var_67, var_66)
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_53: (Union0 ref)))
        let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_72: int64) = 4L
        let (var_73: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_72: int64))
        let (var_74: (Union0 ref)) = var_73.mem_0
        let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_74: (Union0 ref)))
        // Cuda join point
        // method_22((var_68: ManagedCuda.BasicTypes.CUdeviceptr), (var_69: ManagedCuda.BasicTypes.CUdeviceptr), (var_75: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_77: (System.Object [])) = [|var_68; var_69; var_75|]: (System.Object [])
        let (var_78: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_78.set_GridDimensions(var_79)
        let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_78.set_BlockDimensions(var_80)
        let (var_81: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_78.RunAsync(var_81, var_77)
        let (var_83: (Union8 ref)) = (ref Union8Case1)
        let (var_84: (float32 ref)) = (ref 0.000000f)
        let (var_86: (Union8 ref)) = (ref Union8Case1)
        let (var_87: (float32 ref)) = (ref 0.000000f)
        let (var_88: float32) = method_29((var_74: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_83: (Union8 ref)), (var_86: (Union8 ref)))
        var_87 := 1.000000f
        let (var_89: float32) = method_29((var_74: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_83: (Union8 ref)), (var_86: (Union8 ref)))
        let (var_90: float32) = (!var_87)
        let (var_91: float32) = method_28((var_74: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_83: (Union8 ref)))
        let (var_92: float32) = (var_90 / 2.000000f)
        let (var_93: float32) = (!var_84)
        let (var_94: float32) = (var_93 + var_92)
        var_84 := var_94
        let (var_95: float32) = method_28((var_74: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_83: (Union8 ref)))
        let (var_96: float32) = (!var_84)
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_53: (Union0 ref)))
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_64: (Union0 ref)))
        // Cuda join point
        // method_30((var_96: float32), (var_95: float32), (var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: ManagedCuda.BasicTypes.CUdeviceptr), (var_99: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_101: (System.Object [])) = [|var_96; var_95; var_97; var_98; var_99|]: (System.Object [])
        let (var_102: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_1, var_0)
        let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_102.set_GridDimensions(var_103)
        let (var_104: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_102.set_BlockDimensions(var_104)
        let (var_105: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_102.RunAsync(var_105, var_101)
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_31: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_64: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_53: (Union0 ref)))
        let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_34: (Union0 ref)))
        // Cuda join point
        // method_32((var_106: ManagedCuda.BasicTypes.CUdeviceptr), (var_107: ManagedCuda.BasicTypes.CUdeviceptr), (var_108: ManagedCuda.BasicTypes.CUdeviceptr), (var_109: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_111: (System.Object [])) = [|var_106; var_107; var_108; var_109|]: (System.Object [])
        let (var_112: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_112.set_GridDimensions(var_113)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_112.set_BlockDimensions(var_114)
        let (var_115: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_112.RunAsync(var_115, var_111)
        method_34((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_24: int64), (var_34: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_34: (Union0 ref)))
        let (var_117: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        // Cuda join point
        // method_35((var_116: ManagedCuda.BasicTypes.CUdeviceptr), (var_117: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_119: (System.Object [])) = [|var_116; var_117|]: (System.Object [])
        let (var_120: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_1, var_0)
        let (var_121: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_120.set_GridDimensions(var_121)
        let (var_122: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 2u, 1u)
        var_120.set_BlockDimensions(var_122)
        let (var_123: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_120.RunAsync(var_123, var_119)
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_10: (Union0 ref)))
        // Cuda join point
        // method_39((var_124: ManagedCuda.BasicTypes.CUdeviceptr), (var_125: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_127: (System.Object [])) = [|var_124; var_125|]: (System.Object [])
        let (var_128: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_1, var_0)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_128.set_GridDimensions(var_129)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_128.set_BlockDimensions(var_130)
        let (var_131: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_128.RunAsync(var_131, var_127)
        let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_133: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_134: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_132, 0uy, var_134, var_133)
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        // Cuda join point
        // method_41((var_135: ManagedCuda.BasicTypes.CUdeviceptr), (var_136: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_138: (System.Object [])) = [|var_135; var_136|]: (System.Object [])
        let (var_139: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_1, var_0)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_139.set_GridDimensions(var_140)
        let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_139.set_BlockDimensions(var_141)
        let (var_142: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_139.RunAsync(var_142, var_138)
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_144: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_145: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_143, 0uy, var_145, var_144)
        let (var_146: float) = (float var_88)
        let (var_147: float) = (var_146 * 2.000000)
        let (var_148: float) = (var_14 + var_147)
        let (var_149: int64) = 8L
        let (var_150: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_149: int64))
        let (var_151: (Union0 ref)) = var_150.mem_0
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_53: (Union0 ref)))
        let (var_153: int64) = (var_28 * 4L)
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_155: ManagedCuda.BasicTypes.SizeT) = var_154.Pointer
        let (var_156: uint64) = uint64 var_155
        let (var_157: uint64) = (uint64 var_153)
        let (var_158: uint64) = (var_156 + var_157)
        let (var_159: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_158)
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_159)
        let (var_161: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_151: (Union0 ref)))
        // Cuda join point
        // method_43((var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_160: ManagedCuda.BasicTypes.CUdeviceptr), (var_161: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_163: (System.Object [])) = [|var_152; var_160; var_161|]: (System.Object [])
        let (var_164: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_1, var_0)
        let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_164.set_GridDimensions(var_165)
        let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_164.set_BlockDimensions(var_166)
        let (var_167: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_164.RunAsync(var_167, var_163)
        let (var_168: float32) = 0.000000f
        let (var_169: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_151: (Union0 ref)))
        let (var_170: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
        var_0.CopyToHost(var_170, var_169)
        var_0.Synchronize()
        let (var_171: int64) = var_170.LongLength
        let (var_172: int64) = 0L
        let (var_173: float32) = method_46((var_170: (float32 [])), (var_171: int64), (var_168: float32), (var_172: int64))
        let (var_174: int64) = (int64 var_173)
        var_151 := Union0Case1
        let (var_175: int64) = (var_13 + var_174)
        var_74 := Union0Case1
        var_64 := Union0Case1
        var_53 := Union0Case1
        var_34 := Union0Case1
        var_31 := Union0Case1
        method_47((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_175: int64), (var_148: float), (var_17: int64))
    else
        (Env7(var_13, var_14))
and method_16((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_1: (Union0 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = var_9.Pointer
    let (var_11: uint64) = uint64 var_10
    let (var_12: uint64) = (uint64 var_8)
    let (var_13: uint64) = (var_11 + var_12)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_3: (Union0 ref)))
    let (var_17: (float32 ref)) = (ref 0.000000f)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_4: (Union0 ref)))
    let (var_19: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 2, 10, 784, var_7, var_15, 2, var_16, 784, var_17, var_18, 2)
    if var_19 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_19)
and method_29((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union8 ref)), (var_3: (Union8 ref))): float32 =
    let (var_4: Union8) = (!var_3)
    match var_4 with
    | Union8Case0(var_5) ->
        var_5.mem_0
    | Union8Case1 ->
        let (var_7: float32) = method_27((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union8 ref)))
        var_3 := (Union8Case0(Tuple9(var_7)))
        var_7
and method_28((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union8 ref))): float32 =
    let (var_3: Union8) = (!var_2)
    match var_3 with
    | Union8Case0(var_4) ->
        var_4.mem_0
    | Union8Case1 ->
        let (var_6: float32) = method_25((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext))
        var_2 := (Union8Case0(Tuple9(var_6)))
        var_6
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_1: (Union0 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = var_9.Pointer
    let (var_11: uint64) = uint64 var_10
    let (var_12: uint64) = (uint64 var_8)
    let (var_13: uint64) = (var_11 + var_12)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_3: (Union0 ref)))
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_4: (Union0 ref)))
    let (var_19: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 784, 10, 2, var_7, var_15, 2, var_16, 2, var_17, var_18, 784)
    if var_19 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_19)
and method_46((var_0: (float32 [])), (var_1: int64), (var_2: float32), (var_3: int64)): float32 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: float32) = var_0.[int32 var_3]
        let (var_6: float32) = (var_2 + var_5)
        let (var_7: int64) = (var_3 + 1L)
        method_46((var_0: (float32 [])), (var_1: int64), (var_6: float32), (var_7: int64))
    else
        var_2
and method_47((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_15: int64), (var_16: float), (var_17: int64)): Env7 =
    let (var_18: bool) = (var_17 < 32L)
    if var_18 then
        let (var_19: int64) = (var_17 + 2L)
        let (var_20: bool) = (var_17 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_22: bool) = (var_19 > 0L)
        let (var_24: bool) =
            if var_22 then
                (var_19 <= 32L)
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
                (var_19 <= 32L)
            else
                false
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_30: int64) = (var_17 * 10L)
        let (var_31: int64) = 80L
        let (var_32: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_31: int64))
        let (var_33: (Union0 ref)) = var_32.mem_0
        method_16((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_26: int64), (var_10: (Union0 ref)), (var_33: (Union0 ref)))
        let (var_34: int64) = 80L
        let (var_35: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_34: int64))
        let (var_36: (Union0 ref)) = var_35.mem_0
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_36: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(80L)
        var_0.ClearMemoryAsync(var_37, 0uy, var_39, var_38)
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        // Cuda join point
        // method_17((var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_41: ManagedCuda.BasicTypes.CUdeviceptr), (var_42: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_44: (System.Object [])) = [|var_40; var_41; var_42|]: (System.Object [])
        let (var_45: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_46: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_45.set_GridDimensions(var_46)
        let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 2u, 1u)
        var_45.set_BlockDimensions(var_47)
        let (var_48: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_45.RunAsync(var_48, var_44)
        let (var_53: int64) = 80L
        let (var_54: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_53: int64))
        let (var_55: (Union0 ref)) = var_54.mem_0
        let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        let (var_57: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_55: (Union0 ref)))
        // Cuda join point
        // method_20((var_56: ManagedCuda.BasicTypes.CUdeviceptr), (var_57: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_59: (System.Object [])) = [|var_56; var_57|]: (System.Object [])
        let (var_60: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_60.set_GridDimensions(var_61)
        let (var_62: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_60.set_BlockDimensions(var_62)
        let (var_63: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_60.RunAsync(var_63, var_59)
        let (var_64: int64) = 80L
        let (var_65: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_64: int64))
        let (var_66: (Union0 ref)) = var_65.mem_0
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_66: (Union0 ref)))
        let (var_68: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(80L)
        var_0.ClearMemoryAsync(var_67, 0uy, var_69, var_68)
        let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_55: (Union0 ref)))
        let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_74: int64) = 4L
        let (var_75: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_74: int64))
        let (var_76: (Union0 ref)) = var_75.mem_0
        let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_76: (Union0 ref)))
        // Cuda join point
        // method_22((var_70: ManagedCuda.BasicTypes.CUdeviceptr), (var_71: ManagedCuda.BasicTypes.CUdeviceptr), (var_77: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_79: (System.Object [])) = [|var_70; var_71; var_77|]: (System.Object [])
        let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_80.set_GridDimensions(var_81)
        let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_80.set_BlockDimensions(var_82)
        let (var_83: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_80.RunAsync(var_83, var_79)
        let (var_85: (Union8 ref)) = (ref Union8Case1)
        let (var_86: (float32 ref)) = (ref 0.000000f)
        let (var_88: (Union8 ref)) = (ref Union8Case1)
        let (var_89: (float32 ref)) = (ref 0.000000f)
        let (var_90: float32) = method_29((var_76: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_85: (Union8 ref)), (var_88: (Union8 ref)))
        var_89 := 1.000000f
        let (var_91: float32) = method_29((var_76: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_85: (Union8 ref)), (var_88: (Union8 ref)))
        let (var_92: float32) = (!var_89)
        let (var_93: float32) = method_28((var_76: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_85: (Union8 ref)))
        let (var_94: float32) = (var_92 / 2.000000f)
        let (var_95: float32) = (!var_86)
        let (var_96: float32) = (var_95 + var_94)
        var_86 := var_96
        let (var_97: float32) = method_28((var_76: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_85: (Union8 ref)))
        let (var_98: float32) = (!var_86)
        let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_55: (Union0 ref)))
        let (var_100: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_66: (Union0 ref)))
        // Cuda join point
        // method_30((var_98: float32), (var_97: float32), (var_99: ManagedCuda.BasicTypes.CUdeviceptr), (var_100: ManagedCuda.BasicTypes.CUdeviceptr), (var_101: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_103: (System.Object [])) = [|var_98; var_97; var_99; var_100; var_101|]: (System.Object [])
        let (var_104: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_1, var_0)
        let (var_105: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_104.set_GridDimensions(var_105)
        let (var_106: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_104.set_BlockDimensions(var_106)
        let (var_107: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_104.RunAsync(var_107, var_103)
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_66: (Union0 ref)))
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_55: (Union0 ref)))
        let (var_111: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_36: (Union0 ref)))
        // Cuda join point
        // method_32((var_108: ManagedCuda.BasicTypes.CUdeviceptr), (var_109: ManagedCuda.BasicTypes.CUdeviceptr), (var_110: ManagedCuda.BasicTypes.CUdeviceptr), (var_111: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_113: (System.Object [])) = [|var_108; var_109; var_110; var_111|]: (System.Object [])
        let (var_114: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_114.set_GridDimensions(var_115)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_114.set_BlockDimensions(var_116)
        let (var_117: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_114.RunAsync(var_117, var_113)
        method_34((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_26: int64), (var_36: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_36: (Union0 ref)))
        let (var_119: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        // Cuda join point
        // method_35((var_118: ManagedCuda.BasicTypes.CUdeviceptr), (var_119: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_121: (System.Object [])) = [|var_118; var_119|]: (System.Object [])
        let (var_122: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_1, var_0)
        let (var_123: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_122.set_GridDimensions(var_123)
        let (var_124: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 2u, 1u)
        var_122.set_BlockDimensions(var_124)
        let (var_125: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_122.RunAsync(var_125, var_121)
        let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_127: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_10: (Union0 ref)))
        // Cuda join point
        // method_39((var_126: ManagedCuda.BasicTypes.CUdeviceptr), (var_127: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_129: (System.Object [])) = [|var_126; var_127|]: (System.Object [])
        let (var_130: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_1, var_0)
        let (var_131: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_130.set_GridDimensions(var_131)
        let (var_132: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_130.set_BlockDimensions(var_132)
        let (var_133: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_130.RunAsync(var_133, var_129)
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_135: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_136: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_134, 0uy, var_136, var_135)
        let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        // Cuda join point
        // method_41((var_137: ManagedCuda.BasicTypes.CUdeviceptr), (var_138: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_140: (System.Object [])) = [|var_137; var_138|]: (System.Object [])
        let (var_141: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_1, var_0)
        let (var_142: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_141.set_GridDimensions(var_142)
        let (var_143: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_141.set_BlockDimensions(var_143)
        let (var_144: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_141.RunAsync(var_144, var_140)
        let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_146: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_147: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_145, 0uy, var_147, var_146)
        let (var_148: float) = (float var_90)
        let (var_149: float) = (var_148 * 2.000000)
        let (var_150: float) = (var_16 + var_149)
        let (var_151: int64) = 8L
        let (var_152: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_151: int64))
        let (var_153: (Union0 ref)) = var_152.mem_0
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_55: (Union0 ref)))
        let (var_155: int64) = (var_30 * 4L)
        let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_157: ManagedCuda.BasicTypes.SizeT) = var_156.Pointer
        let (var_158: uint64) = uint64 var_157
        let (var_159: uint64) = (uint64 var_155)
        let (var_160: uint64) = (var_158 + var_159)
        let (var_161: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_160)
        let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_161)
        let (var_163: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_153: (Union0 ref)))
        // Cuda join point
        // method_43((var_154: ManagedCuda.BasicTypes.CUdeviceptr), (var_162: ManagedCuda.BasicTypes.CUdeviceptr), (var_163: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_165: (System.Object [])) = [|var_154; var_162; var_163|]: (System.Object [])
        let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_1, var_0)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_166.set_GridDimensions(var_167)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_166.set_BlockDimensions(var_168)
        let (var_169: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_166.RunAsync(var_169, var_165)
        let (var_170: float32) = 0.000000f
        let (var_171: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_153: (Union0 ref)))
        let (var_172: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
        var_0.CopyToHost(var_172, var_171)
        var_0.Synchronize()
        let (var_173: int64) = var_172.LongLength
        let (var_174: int64) = 0L
        let (var_175: float32) = method_46((var_172: (float32 [])), (var_173: int64), (var_170: float32), (var_174: int64))
        let (var_176: int64) = (int64 var_175)
        var_153 := Union0Case1
        let (var_177: int64) = (var_15 + var_176)
        var_76 := Union0Case1
        var_66 := Union0Case1
        var_55 := Union0Case1
        var_36 := Union0Case1
        var_33 := Union0Case1
        method_47((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64), (var_14: float), (var_177: int64), (var_150: float), (var_19: int64))
    else
        (Env7(var_15, var_16))
and method_27((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union8 ref))): float32 =
    let (var_3: float32) = method_28((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union8 ref)))
    (var_3 / 2.000000f)
and method_25((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext)): float32 =
    let (var_2: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_0: (Union0 ref)))
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_1.CopyToHost(var_3, var_2)
    var_1.Synchronize()
    let (var_4: float32) = 0.000000f
    let (var_5: int64) = 0L
    method_26((var_3: (float32 [])), (var_4: float32), (var_5: int64))
and method_26((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
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
        method_26((var_0: (float32 [])), (var_7: float32), (var_8: int64))
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
let (var_9: string) = System.String.Format("{0}{1}{2}",'"',var_8,'"')
let (var_10: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_11: string) = System.String.Format("{0}{1}{2}",'"',var_10,'"')
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_13: string) = System.String.Format("{0}{1}{2}",'"',var_12,'"')
let (var_14: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_15: string) = System.String.Format("{0}{1}{2}",'"',var_14,'"')
let (var_16: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_17: string) = System.String.Format("{0}{1}{2}",'"',var_16,'"')
let (var_18: string) = System.String.Format("{0}{1}{2}",'"',var_2,'"')
let (var_19: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_20: string) = System.String.Format("{0}{1}{2}",'"',var_19,'"')
let (var_21: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_22: string) = System.String.Format("{0}{1}{2}",'"',var_21,'"')
let (var_23: bool) = System.IO.File.Exists(var_21)
if var_23 then
    System.IO.File.Delete(var_21)
else
    ()
System.IO.File.WriteAllText(var_21, var_0)
let (var_24: bool) = System.IO.File.Exists(var_3)
if var_24 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_25: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_26: System.IO.StreamWriter) = System.IO.StreamWriter(var_25)
var_26.WriteLine("SETLOCAL")
let (var_27: string) = String.concat "" [|"CALL "; var_9|]
var_26.WriteLine(var_27)
let (var_28: string) = String.concat "" [|"SET PATH=%PATH%;"; var_11|]
var_26.WriteLine(var_28)
let (var_29: string) = String.concat "" [|var_17; " -gencode=arch=compute_30,code=\"sm_30,compute_30\" --use-local-env --cl-version 2017 -I"; var_13; " -I"C:/cub-1.7.4" -I"; var_15; " --keep-dir "; var_18; " -maxrregcount=0  --machine 64 -ptx -cudart static  -o "; var_20; " "; var_22|]
var_26.WriteLine(var_29)
var_26.Dispose()
var_25.Dispose()
let (var_30: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_31: bool) = var_5.Start()
let (var_32: bool) = (var_31 = false)
if var_32 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_33: int32) = var_5.get_ExitCode()
let (var_34: bool) = (var_33 = 0)
let (var_35: bool) = (var_34 = false)
if var_35 then
    let (var_36: string) = System.String.Format("{0}",var_33)
    let (var_37: string) = String.concat ", " [|"NVCC failed compilation."; var_36|]
    let (var_38: string) = System.String.Format("[{0}]",var_37)
    (failwith var_38)
else
    ()
let (var_39: System.TimeSpan) = var_30.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_39
let (var_40: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_19)
var_5.Dispose()
let (var_41: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_42: string) = System.String.Format("{0}",var_41)
System.Console.WriteLine(var_42)
let (var_43: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_44: ManagedCuda.BasicTypes.SizeT) = var_43.get_TotalGlobalMemory()
let (var_45: int64) = int64 var_44
let (var_46: float) = float var_45
let (var_47: float) = (0.700000 * var_46)
let (var_48: int64) = int64 var_47
let (var_49: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_48)
let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_49)
let (var_51: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_50))))
let (var_52: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
let (var_54: ManagedCuda.BasicTypes.SizeT) = var_53.Pointer
let (var_55: uint64) = uint64 var_54
let (var_56: uint64) = uint64 var_48
let (var_57: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_58: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_59: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_58)
let (var_60: ManagedCuda.BasicTypes.CUstream) = var_57.get_Stream()
var_59.SetStream(var_60)
let (var_61: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_62: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_63: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_61, var_62)
let (var_64: ManagedCuda.CudaBlas.CudaBlasHandle) = var_63.get_CublasHandle()
let (var_65: ManagedCuda.BasicTypes.CUstream) = var_57.get_Stream()
var_63.set_Stream(var_65)
let (var_66: string) = System.IO.Path.Combine("C:\ML Datasets\Mnist", "t10k-images.idx3-ubyte")
let (var_67: Tuple3) = method_2((var_66: string))
let (var_68: Tuple4) = var_67.mem_0
let (var_69: (uint8 [])) = var_67.mem_1
let (var_70: int64) = var_68.mem_0
let (var_71: int64) = var_68.mem_1
let (var_72: int64) = var_68.mem_2
let (var_73: bool) = (10000L = var_70)
let (var_77: bool) =
    if var_73 then
        let (var_74: bool) = (28L = var_71)
        if var_74 then
            (28L = var_72)
        else
            false
    else
        false
let (var_78: bool) = (var_77 = false)
if var_78 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_79: int64) = var_69.LongLength
let (var_80: bool) = (var_79 > 0L)
let (var_81: bool) = (var_80 = false)
if var_81 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_82: bool) = (7840000L = var_79)
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_87: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_88: int64) = 0L
method_3((var_69: (uint8 [])), (var_87: (float32 [])), (var_88: int64))
let (var_89: string) = System.IO.Path.Combine("C:\ML Datasets\Mnist", "t10k-labels.idx1-ubyte")
let (var_90: Tuple5) = method_5((var_89: string))
let (var_91: int64) = var_90.mem_0
let (var_92: (uint8 [])) = var_90.mem_1
let (var_93: bool) = (10000L = var_91)
let (var_94: bool) = (var_93 = false)
if var_94 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_98: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_99: int64) = 0L
method_6((var_92: (uint8 [])), (var_98: (float32 [])), (var_99: int64))
let (var_100: string) = System.IO.Path.Combine("C:\ML Datasets\Mnist", "train-images.idx3-ubyte")
let (var_101: Tuple3) = method_2((var_100: string))
let (var_102: Tuple4) = var_101.mem_0
let (var_103: (uint8 [])) = var_101.mem_1
let (var_104: int64) = var_102.mem_0
let (var_105: int64) = var_102.mem_1
let (var_106: int64) = var_102.mem_2
let (var_107: bool) = (60000L = var_104)
let (var_111: bool) =
    if var_107 then
        let (var_108: bool) = (28L = var_105)
        if var_108 then
            (28L = var_106)
        else
            false
    else
        false
let (var_112: bool) = (var_111 = false)
if var_112 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_113: int64) = var_103.LongLength
let (var_114: bool) = (var_113 > 0L)
let (var_115: bool) = (var_114 = false)
if var_115 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_116: bool) = (47040000L = var_113)
let (var_117: bool) = (var_116 = false)
if var_117 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_121: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_122: int64) = 0L
method_8((var_103: (uint8 [])), (var_121: (float32 [])), (var_122: int64))
let (var_123: string) = System.IO.Path.Combine("C:\ML Datasets\Mnist", "train-labels.idx1-ubyte")
let (var_124: Tuple5) = method_5((var_123: string))
let (var_125: int64) = var_124.mem_0
let (var_126: (uint8 [])) = var_124.mem_1
let (var_127: bool) = (60000L = var_125)
let (var_128: bool) = (var_127 = false)
if var_128 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_132: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_133: int64) = 0L
method_9((var_126: (uint8 [])), (var_132: (float32 [])), (var_133: int64))
let (var_134: int64) = var_87.LongLength
let (var_135: int64) = (var_134 * 4L)
let (var_136: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_135: int64))
let (var_137: (Union0 ref)) = var_136.mem_0
let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_137: (Union0 ref)))
var_1.CopyToDevice(var_138, var_87)
let (var_139: int64) = var_98.LongLength
let (var_140: int64) = (var_139 * 4L)
let (var_141: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_140: int64))
let (var_142: (Union0 ref)) = var_141.mem_0
let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_142: (Union0 ref)))
var_1.CopyToDevice(var_143, var_98)
let (var_144: int64) = var_121.LongLength
let (var_145: int64) = (var_144 * 4L)
let (var_146: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_145: int64))
let (var_147: (Union0 ref)) = var_146.mem_0
let (var_148: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_147: (Union0 ref)))
var_1.CopyToDevice(var_148, var_121)
let (var_149: int64) = var_132.LongLength
let (var_150: int64) = (var_149 * 4L)
let (var_151: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_150: int64))
let (var_152: (Union0 ref)) = var_151.mem_0
let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_152: (Union0 ref)))
var_1.CopyToDevice(var_153, var_132)
let (var_154: int64) = 31360L
let (var_155: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_154: int64))
let (var_156: (Union0 ref)) = var_155.mem_0
let (var_157: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_156: (Union0 ref)))
let (var_158: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_59.GenerateNormal32(var_157, var_158, 0.000000f, 0.050189f)
let (var_159: int64) = 31360L
let (var_160: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_159: int64))
let (var_161: (Union0 ref)) = var_160.mem_0
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_161: (Union0 ref)))
let (var_163: ManagedCuda.BasicTypes.CUstream) = var_57.get_Stream()
let (var_164: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_162, 0uy, var_164, var_163)
let (var_165: int64) = 40L
let (var_166: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_165: int64))
let (var_167: (Union0 ref)) = var_166.mem_0
let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_167: (Union0 ref)))
let (var_169: ManagedCuda.BasicTypes.CUstream) = var_57.get_Stream()
let (var_170: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_168, 0uy, var_170, var_169)
let (var_171: int64) = 40L
let (var_172: Env6) = method_10((var_55: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_56: uint64), (var_171: int64))
let (var_173: (Union0 ref)) = var_172.mem_0
let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_173: (Union0 ref)))
let (var_175: ManagedCuda.BasicTypes.CUstream) = var_57.get_Stream()
let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_174, 0uy, var_176, var_175)
let (var_177: int64) = 0L
method_14((var_1: ManagedCuda.CudaContext), (var_57: ManagedCuda.CudaStream), (var_55: uint64), (var_56: uint64), (var_52: System.Collections.Generic.Stack<Env2>), (var_40: ManagedCuda.BasicTypes.CUmodule), (var_173: (Union0 ref)), (var_167: (Union0 ref)), (var_64: ManagedCuda.CudaBlas.CudaBlasHandle), (var_161: (Union0 ref)), (var_156: (Union0 ref)), (var_147: (Union0 ref)), (var_152: (Union0 ref)), (var_177: int64))
var_173 := Union0Case1
var_167 := Union0Case1
var_161 := Union0Case1
var_156 := Union0Case1
var_63.Dispose()
var_59.Dispose()
var_57.Dispose()
let (var_178: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
var_1.FreeMemory(var_178)
var_51 := Union0Case1
var_1.Dispose()

