module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_17(long long int var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_20(float * var_0, long long int var_1, float * var_2);
    __global__ void method_22(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5);
    __global__ void method_32(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4);
    __global__ void method_34(long long int var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_38(long long int var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_42(float * var_0, float * var_1);
    __global__ void method_44(float * var_0, float * var_1);
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, float * var_5, float * var_6, float * var_7, long long int var_8, long long int var_9, long long int var_10, long long int var_11);
    __device__ void method_21(float * var_0, long long int var_1, float * var_2, long long int var_3, long long int var_4);
    __device__ float method_23(float * var_0, float * var_1, long long int var_2, long long int var_3, float var_4, long long int var_5);
    __device__ float method_24(float var_0, float var_1);
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6, long long int var_7);
    __device__ void method_33(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4, long long int var_5, long long int var_6);
    __device__ void method_35(long long int var_0, long long int var_1, long long int var_2, long long int var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, long long int var_9, long long int var_10, long long int var_11, long long int var_12);
    __device__ void method_39(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9, long long int var_10, long long int var_11, long long int var_12, long long int var_13);
    __device__ void method_43(float * var_0, float * var_1, long long int var_2);
    __device__ void method_45(float * var_0, float * var_1, long long int var_2);
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, long long int var_3, float * var_4, long long int var_5, long long int var_6);
    __device__ float method_36(long long int var_0, float * var_1, float * var_2, float * var_3, long long int var_4, float * var_5, float var_6, long long int var_7);
    __device__ void method_37(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5);
    __device__ void method_40(float * var_0, long long int var_1, float * var_2, float * var_3, float * var_4, long long int var_5, float * var_6, long long int var_7, long long int var_8);
    
    __global__ void method_17(long long int var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = blockDim.y;
        long long int var_11 = (10 * var_7);
        long long int var_12 = (var_4 + var_11);
        method_18(var_10, var_7, var_8, var_9, var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_12);
    }
    __global__ void method_20(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = gridDim.x;
        long long int var_10 = (var_6 * 128);
        long long int var_11 = (var_10 + var_3);
        long long int var_12 = (var_9 * 128);
        method_21(var_0, var_1, var_2, var_12, var_11);
    }
    __global__ void method_22(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
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
        float var_16 = method_23(var_0, var_1, var_2, var_14, var_15, var_13);
        FunPointer0 var_19 = method_24;
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
            var_3[var_8] = var_20;
        } else {
        }
    }
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = gridDim.x;
        long long int var_13 = (var_9 * 128);
        long long int var_14 = (var_13 + var_6);
        long long int var_15 = (var_12 * 128);
        method_31(var_0, var_1, var_2, var_3, var_4, var_5, var_15, var_14);
    }
    __global__ void method_32(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4) {
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
        method_33(var_0, var_1, var_2, var_3, var_4, var_14, var_13);
    }
    __global__ void method_34(long long int var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = (10 * var_9);
        long long int var_13 = (var_6 + var_12);
        method_35(var_9, var_10, var_11, var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_13);
    }
    __global__ void method_38(long long int var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = blockDim.y;
        long long int var_13 = (10 * var_9);
        long long int var_14 = (var_6 + var_13);
        method_39(var_12, var_9, var_10, var_11, var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_14);
    }
    __global__ void method_42(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_43(var_0, var_1, var_9);
    }
    __global__ void method_44(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_45(var_0, var_1, var_9);
    }
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, float * var_5, float * var_6, float * var_7, long long int var_8, long long int var_9, long long int var_10, long long int var_11) {
        char var_12 = (var_11 < 10);
        if (var_12) {
            char var_13 = (var_11 >= 0);
            char var_14 = (var_13 == 0);
            if (var_14) {
                // unprinted assert;
            } else {
            }
            long long int var_15 = (var_0 * var_2);
            long long int var_16 = (var_9 + var_15);
            method_19(var_5, var_11, var_6, var_4, var_7, var_0, var_16);
            long long int var_17 = (var_11 + 10);
            method_18(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_17);
        } else {
        }
    }
    __device__ void method_21(float * var_0, long long int var_1, float * var_2, long long int var_3, long long int var_4) {
        char var_5 = (var_4 < var_1);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                // unprinted assert;
            } else {
            }
            if (var_7) {
                // unprinted assert;
            } else {
            }
            float var_8 = var_0[var_4];
            float var_9 = var_2[var_4];
            float var_10 = (-var_8);
            float var_11 = exp(var_10);
            float var_12 = (1 + var_11);
            float var_13 = (1 / var_12);
            var_2[var_4] = var_13;
            long long int var_14 = (var_4 + var_3);
            method_21(var_0, var_1, var_2, var_3, var_14);
        } else {
        }
    }
    __device__ float method_23(float * var_0, float * var_1, long long int var_2, long long int var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < var_2);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float var_9 = var_0[var_5];
            float var_10 = var_1[var_5];
            float var_11 = (var_10 - var_9);
            float var_12 = (var_11 * var_11);
            float var_13 = (var_4 + var_12);
            long long int var_14 = (var_5 + var_3);
            return method_23(var_0, var_1, var_2, var_3, var_13, var_14);
        } else {
            return var_4;
        }
    }
    __device__ float method_24(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6, long long int var_7) {
        char var_8 = (var_7 < var_4);
        if (var_8) {
            char var_9 = (var_7 >= 0);
            char var_10 = (var_9 == 0);
            if (var_10) {
                // unprinted assert;
            } else {
            }
            if (var_10) {
                // unprinted assert;
            } else {
            }
            float var_11 = var_2[var_7];
            float var_12 = var_3[var_7];
            float var_13 = var_5[var_7];
            float var_14 = (var_11 - var_12);
            float var_15 = (2 * var_14);
            float var_16 = (var_0 * var_15);
            float var_17 = (var_13 + var_16);
            var_5[var_7] = var_17;
            long long int var_18 = (var_7 + var_6);
            method_31(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_18);
        } else {
        }
    }
    __device__ void method_33(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4, long long int var_5, long long int var_6) {
        char var_7 = (var_6 < var_3);
        if (var_7) {
            char var_8 = (var_6 >= 0);
            char var_9 = (var_8 == 0);
            if (var_9) {
                // unprinted assert;
            } else {
            }
            if (var_9) {
                // unprinted assert;
            } else {
            }
            float var_10 = var_0[var_6];
            float var_11 = var_1[var_6];
            float var_12 = var_2[var_6];
            float var_13 = var_4[var_6];
            float var_14 = (1 - var_12);
            float var_15 = (var_12 * var_14);
            float var_16 = (var_11 * var_15);
            float var_17 = (var_13 + var_16);
            var_4[var_6] = var_17;
            long long int var_18 = (var_6 + var_5);
            method_33(var_0, var_1, var_2, var_3, var_4, var_5, var_18);
        } else {
        }
    }
    __device__ void method_35(long long int var_0, long long int var_1, long long int var_2, long long int var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, long long int var_9, long long int var_10, long long int var_11, long long int var_12) {
        char var_13 = (var_12 < 10);
        if (var_13) {
            char var_14 = (var_12 >= 0);
            char var_15 = (var_14 == 0);
            if (var_15) {
                // unprinted assert;
            } else {
            }
            if (var_15) {
                // unprinted assert;
            } else {
            }
            long long int var_16 = (8 * var_1);
            long long int var_17 = (var_10 + var_16);
            float var_18 = 0;
            float var_19 = method_36(var_12, var_4, var_5, var_6, var_3, var_7, var_18, var_17);
            __shared__ float var_20[70];
            char var_21 = (var_9 >= 0);
            char var_23;
            if (var_21) {
                var_23 = (var_9 < 10);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // unprinted assert;
            } else {
            }
            long long int var_25 = (var_9 * 7);
            char var_26 = (var_10 != 0);
            if (var_26) {
                char var_27 = (var_10 >= 1);
                char var_29;
                if (var_27) {
                    var_29 = (var_10 < 8);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // unprinted assert;
                } else {
                }
                long long int var_31 = (var_10 - 1);
                long long int var_32 = (var_25 + var_31);
                var_20[var_32] = var_19;
            } else {
            }
            __syncthreads();
            char var_33 = (var_10 == 0);
            if (var_33) {
                long long int var_34 = 1;
                method_37(var_20, var_25, var_8, var_12, var_19, var_34);
            } else {
            }
            long long int var_35 = (var_12 + 10);
            method_35(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_11, var_35);
        } else {
        }
    }
    __device__ void method_39(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9, long long int var_10, long long int var_11, long long int var_12, long long int var_13) {
        char var_14 = (var_13 < 10);
        if (var_14) {
            char var_15 = (var_13 >= 0);
            char var_16 = (var_15 == 0);
            if (var_16) {
                // unprinted assert;
            } else {
            }
            long long int var_17 = (var_0 * var_2);
            long long int var_18 = (var_11 + var_17);
            method_40(var_5, var_13, var_6, var_7, var_8, var_4, var_9, var_0, var_18);
            long long int var_19 = (var_13 + 10);
            method_39(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_11, var_12, var_19);
        } else {
        }
    }
    __device__ void method_43(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 7840);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 7936);
            method_43(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_45(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 10);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 128);
            method_45(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, long long int var_3, float * var_4, long long int var_5, long long int var_6) {
        char var_7 = (var_6 < var_3);
        if (var_7) {
            char var_8 = (var_6 >= 0);
            char var_9 = (var_8 == 0);
            if (var_9) {
                // unprinted assert;
            } else {
            }
            long long int var_10 = (var_6 * 10);
            char var_11 = (var_1 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_1 < 10);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // unprinted assert;
            } else {
            }
            long long int var_15 = (var_10 + var_1);
            if (var_9) {
                // unprinted assert;
            } else {
            }
            char var_17;
            if (var_11) {
                var_17 = (var_1 < 10);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // unprinted assert;
            } else {
            }
            float var_19 = var_0[var_1];
            float var_20 = var_2[var_15];
            float var_21 = var_4[var_15];
            float var_22 = (var_19 + var_20);
            var_4[var_15] = var_22;
            long long int var_23 = (var_6 + var_5);
            method_19(var_0, var_1, var_2, var_3, var_4, var_5, var_23);
        } else {
        }
    }
    __device__ float method_36(long long int var_0, float * var_1, float * var_2, float * var_3, long long int var_4, float * var_5, float var_6, long long int var_7) {
        char var_8 = (var_7 < var_4);
        if (var_8) {
            char var_9 = (var_7 >= 0);
            char var_10 = (var_9 == 0);
            if (var_10) {
                // unprinted assert;
            } else {
            }
            long long int var_11 = (var_7 * 10);
            char var_12 = (var_0 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_0 < 10);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // unprinted assert;
            } else {
            }
            long long int var_16 = (var_11 + var_0);
            float var_17 = var_1[var_16];
            float var_18 = var_2[var_16];
            float var_19 = var_3[var_16];
            float var_20 = var_5[var_0];
            float var_21 = (var_6 + var_18);
            long long int var_22 = (var_7 + 8);
            return method_36(var_0, var_1, var_2, var_3, var_4, var_5, var_21, var_22);
        } else {
            return var_6;
        }
    }
    __device__ void method_37(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 8);
        if (var_6) {
            char var_7 = (var_5 >= 1);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            long long int var_9 = (var_5 - 1);
            long long int var_10 = (var_1 + var_9);
            float var_11 = var_0[var_10];
            float var_12 = (var_4 + var_11);
            long long int var_13 = (var_5 + 1);
            method_37(var_0, var_1, var_2, var_3, var_12, var_13);
        } else {
            float var_14 = var_2[var_3];
            float var_15 = (var_4 + var_14);
            var_2[var_3] = var_15;
        }
    }
    __device__ void method_40(float * var_0, long long int var_1, float * var_2, float * var_3, float * var_4, long long int var_5, float * var_6, long long int var_7, long long int var_8) {
        char var_9 = (var_8 < var_5);
        if (var_9) {
            char var_10 = (var_8 >= 0);
            char var_11 = (var_10 == 0);
            if (var_11) {
                // unprinted assert;
            } else {
            }
            long long int var_12 = (var_8 * 10);
            char var_13 = (var_1 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_1 < 10);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // unprinted assert;
            } else {
            }
            long long int var_17 = (var_12 + var_1);
            if (var_11) {
                // unprinted assert;
            } else {
            }
            char var_19;
            if (var_13) {
                var_19 = (var_1 < 10);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // unprinted assert;
            } else {
            }
            float var_21 = var_0[var_1];
            float var_22 = var_2[var_17];
            float var_23 = var_3[var_17];
            float var_24 = var_4[var_17];
            float var_25 = var_6[var_17];
            float var_26 = (var_23 + var_25);
            var_6[var_17] = var_26;
            long long int var_27 = (var_8 + var_7);
            method_40(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_27);
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
and Union7 =
    | Union7Case0 of Tuple8
    | Union7Case1
and Tuple8 =
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
    let (var_14: bool) = (var_13 < 10L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: float) = method_15((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_15: float), (var_16: int64))
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_18: float) = (var_17 / 60000.000000)
        let (var_19: string) = System.String.Format("Average of batch costs is {0}.",var_18)
        let (var_20: string) = System.String.Format("{0}",var_19)
        System.Console.WriteLine(var_20)
        System.Console.WriteLine("-----")
        let (var_21: int64) = (var_13 + 1L)
        method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_21: int64))
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
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_18))))
    var_4.Push((Env2((Env6(var_19)), var_3)))
    (Env6(var_19))
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env6 =
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
    var_3.Push((Env2((Env6(var_9)), var_2)))
    (Env6(var_9))
and method_15((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: float), (var_14: int64)): float =
    let (var_15: bool) = (var_14 < 60000L)
    if var_15 then
        let (var_16: int64) = (var_14 + 128L)
        let (var_17: bool) = (60000L > var_16)
        let (var_18: int64) =
            if var_17 then
                var_16
            else
                60000L
        let (var_19: bool) = (var_14 < var_18)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_21: bool) = (var_14 >= 0L)
        let (var_22: bool) = (var_21 = false)
        if var_22 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_23: bool) = (var_18 > 0L)
        let (var_25: bool) =
            if var_23 then
                (var_18 <= 60000L)
            else
                false
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_27: int64) = (var_18 - var_14)
        let (var_28: int64) = (var_14 * 784L)
        if var_20 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_22 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_30: bool) =
            if var_23 then
                (var_18 <= 60000L)
            else
                false
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_32: int64) = (var_14 * 10L)
        let (var_33: bool) = (var_27 > 0L)
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_35: int64) = (var_27 * 10L)
        let (var_36: int64) = (var_35 * 4L)
        let (var_37: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_38: (Union0 ref)) = var_37.mem_0
        let (var_39: int32) = (int32 var_27)
        method_16((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: (Union0 ref)), (var_28: int64), (var_27: int64), (var_10: (Union0 ref)), (var_38: (Union0 ref)))
        let (var_40: bool) = (0L < var_27)
        let (var_41: bool) = (var_40 = false)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_42: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_43: (Union0 ref)) = var_42.mem_0
        let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_43: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_45: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_46: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
        var_0.ClearMemoryAsync(var_44, 0uy, var_46, var_45)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_48: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_49: (Union0 ref)) = var_48.mem_0
        let (var_50: bool) = (8L > var_27)
        let (var_51: int64) =
            if var_50 then
                var_27
            else
                8L
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_38: (Union0 ref)))
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_49: (Union0 ref)))
        // Cuda join point
        // method_17((var_27: int64), (var_52: ManagedCuda.BasicTypes.CUdeviceptr), (var_53: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_56: (System.Object [])) = [|var_27; var_52; var_53; var_54|]: (System.Object [])
        let (var_57: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_58: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_57.set_GridDimensions(var_58)
        let (var_59: uint32) = (uint32 var_51)
        let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_59, 1u)
        var_57.set_BlockDimensions(var_60)
        let (var_61: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_57.RunAsync(var_61, var_56)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_62: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_63: (Union0 ref)) = var_62.mem_0
        let (var_64: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_65: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
        var_0.ClearMemoryAsync(var_64, 0uy, var_66, var_65)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_71: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_72: (Union0 ref)) = var_71.mem_0
        let (var_73: bool) = (var_35 > 0L)
        let (var_74: bool) = (var_73 = false)
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_49: (Union0 ref)))
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_76: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_72: (Union0 ref)))
        let (var_77: int64) = (var_35 - 1L)
        let (var_78: int64) = (var_77 / 128L)
        let (var_79: int64) = (var_78 + 1L)
        let (var_80: bool) = (64L > var_79)
        let (var_81: int64) =
            if var_80 then
                var_79
            else
                64L
        // Cuda join point
        // method_20((var_75: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_76: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_83: (System.Object [])) = [|var_75; var_35; var_76|]: (System.Object [])
        let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_85: uint32) = (uint32 var_81)
        let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_85, 1u, 1u)
        var_84.set_GridDimensions(var_86)
        let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_84.set_BlockDimensions(var_87)
        let (var_88: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_84.RunAsync(var_88, var_83)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_89: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_36: int64))
        let (var_90: (Union0 ref)) = var_89.mem_0
        let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_90: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_92: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_93: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
        var_0.ClearMemoryAsync(var_91, 0uy, var_93, var_92)
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_72: (Union0 ref)))
        let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_96: int64) =
            if var_80 then
                var_79
            else
                64L
        let (var_99: bool) = (var_96 > 0L)
        let (var_100: bool) = (var_99 = false)
        if var_100 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_101: int64) = (var_96 * 4L)
        let (var_102: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_101: int64))
        let (var_103: (Union0 ref)) = var_102.mem_0
        let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_103: (Union0 ref)))
        // Cuda join point
        // method_22((var_94: ManagedCuda.BasicTypes.CUdeviceptr), (var_95: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_104: ManagedCuda.BasicTypes.CUdeviceptr), (var_96: int64))
        let (var_106: (System.Object [])) = [|var_94; var_95; var_35; var_104; var_96|]: (System.Object [])
        let (var_107: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_108: uint32) = (uint32 var_96)
        let (var_109: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_108, 1u, 1u)
        var_107.set_GridDimensions(var_109)
        let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_107.set_BlockDimensions(var_110)
        let (var_111: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_107.RunAsync(var_111, var_106)
        let (var_113: (Union7 ref)) = (ref Union7Case1)
        let (var_114: (float32 ref)) = (ref 0.000000f)
        let (var_116: (Union7 ref)) = (ref Union7Case1)
        let (var_117: (float32 ref)) = (ref 0.000000f)
        let (var_118: float32) = method_29((var_27: int64), (var_103: (Union0 ref)), (var_96: int64), (var_0: ManagedCuda.CudaContext), (var_113: (Union7 ref)), (var_116: (Union7 ref)))
        var_117 := 1.000000f
        let (var_119: float32) = method_29((var_27: int64), (var_103: (Union0 ref)), (var_96: int64), (var_0: ManagedCuda.CudaContext), (var_113: (Union7 ref)), (var_116: (Union7 ref)))
        let (var_120: float32) = (!var_117)
        let (var_121: float32) = method_28((var_103: (Union0 ref)), (var_96: int64), (var_0: ManagedCuda.CudaContext), (var_113: (Union7 ref)))
        let (var_122: float32) = (float32 var_27)
        let (var_123: float32) = (var_120 / var_122)
        let (var_124: float32) = (!var_114)
        let (var_125: float32) = (var_124 + var_123)
        var_114 := var_125
        let (var_126: float32) = method_28((var_103: (Union0 ref)), (var_96: int64), (var_0: ManagedCuda.CudaContext), (var_113: (Union7 ref)))
        let (var_127: float32) = (!var_114)
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_72: (Union0 ref)))
        let (var_129: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_90: (Union0 ref)))
        let (var_131: int64) =
            if var_80 then
                var_79
            else
                64L
        // Cuda join point
        // method_30((var_127: float32), (var_126: float32), (var_128: ManagedCuda.BasicTypes.CUdeviceptr), (var_129: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_130: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_133: (System.Object [])) = [|var_127; var_126; var_128; var_129; var_35; var_130|]: (System.Object [])
        let (var_134: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_1, var_0)
        let (var_135: uint32) = (uint32 var_131)
        let (var_136: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_135, 1u, 1u)
        var_134.set_GridDimensions(var_136)
        let (var_137: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_134.set_BlockDimensions(var_137)
        let (var_138: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_134.RunAsync(var_138, var_133)
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_139: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_49: (Union0 ref)))
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_90: (Union0 ref)))
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_72: (Union0 ref)))
        if var_74 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        let (var_143: int64) =
            if var_80 then
                var_79
            else
                64L
        // Cuda join point
        // method_32((var_139: ManagedCuda.BasicTypes.CUdeviceptr), (var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_141: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_142: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_145: (System.Object [])) = [|var_139; var_140; var_141; var_35; var_142|]: (System.Object [])
        let (var_146: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_147: uint32) = (uint32 var_143)
        let (var_148: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_147, 1u, 1u)
        var_146.set_GridDimensions(var_148)
        let (var_149: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_146.set_BlockDimensions(var_149)
        let (var_150: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_146.RunAsync(var_150, var_145)
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_38: (Union0 ref)))
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_49: (Union0 ref)))
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_155: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        // Cuda join point
        // method_34((var_27: int64), (var_151: ManagedCuda.BasicTypes.CUdeviceptr), (var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_153: ManagedCuda.BasicTypes.CUdeviceptr), (var_154: ManagedCuda.BasicTypes.CUdeviceptr), (var_155: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_157: (System.Object [])) = [|var_27; var_151; var_152; var_153; var_154; var_155|]: (System.Object [])
        let (var_158: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_1, var_0)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_158.set_GridDimensions(var_159)
        let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_158.set_BlockDimensions(var_160)
        let (var_161: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_158.RunAsync(var_161, var_157)
        let (var_162: int64) =
            if var_50 then
                var_27
            else
                8L
        let (var_163: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_38: (Union0 ref)))
        let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_49: (Union0 ref)))
        let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_43: (Union0 ref)))
        // Cuda join point
        // method_38((var_27: int64), (var_163: ManagedCuda.BasicTypes.CUdeviceptr), (var_164: ManagedCuda.BasicTypes.CUdeviceptr), (var_165: ManagedCuda.BasicTypes.CUdeviceptr), (var_166: ManagedCuda.BasicTypes.CUdeviceptr), (var_167: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_169: (System.Object [])) = [|var_27; var_163; var_164; var_165; var_166; var_167|]: (System.Object [])
        let (var_170: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_38", var_1, var_0)
        let (var_171: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_170.set_GridDimensions(var_171)
        let (var_172: uint32) = (uint32 var_162)
        let (var_173: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_172, 1u)
        var_170.set_BlockDimensions(var_173)
        let (var_174: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_170.RunAsync(var_174, var_169)
        method_41((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: (Union0 ref)), (var_28: int64), (var_27: int64), (var_43: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_176: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_10: (Union0 ref)))
        // Cuda join point
        // method_42((var_175: ManagedCuda.BasicTypes.CUdeviceptr), (var_176: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_178: (System.Object [])) = [|var_175; var_176|]: (System.Object [])
        let (var_179: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_42", var_1, var_0)
        let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_179.set_GridDimensions(var_180)
        let (var_181: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_179.set_BlockDimensions(var_181)
        let (var_182: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_179.RunAsync(var_182, var_178)
        let (var_183: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_184: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_185: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_183, 0uy, var_185, var_184)
        let (var_186: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_187: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        // Cuda join point
        // method_44((var_186: ManagedCuda.BasicTypes.CUdeviceptr), (var_187: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_189: (System.Object [])) = [|var_186; var_187|]: (System.Object [])
        let (var_190: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_1, var_0)
        let (var_191: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_190.set_GridDimensions(var_191)
        let (var_192: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_190.set_BlockDimensions(var_192)
        let (var_193: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_190.RunAsync(var_193, var_189)
        let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_195: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_196: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_194, 0uy, var_196, var_195)
        let (var_197: float) = (float var_118)
        let (var_198: float) = (float var_27)
        let (var_199: float) = (var_197 * var_198)
        let (var_200: float) = (var_13 + var_199)
        var_103 := Union0Case1
        var_90 := Union0Case1
        var_72 := Union0Case1
        var_63 := Union0Case1
        var_49 := Union0Case1
        var_43 := Union0Case1
        var_38 := Union0Case1
        method_15((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_200: float), (var_16: int64))
    else
        var_13
and method_16((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: (Union0 ref)), (var_3: int64), (var_4: int64), (var_5: (Union0 ref)), (var_6: (Union0 ref))): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: bool) = (0L < var_4)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_12: int64) = (var_4 * 784L)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_2: (Union0 ref)))
    let (var_14: ManagedCuda.BasicTypes.SizeT) = var_13.Pointer
    let (var_15: uint64) = uint64 var_14
    let (var_16: uint64) = (uint64 var_3)
    let (var_17: uint64) = (var_15 + var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_5: (Union0 ref)))
    let (var_21: (float32 ref)) = (ref 0.000000f)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_22: int64) = (var_4 * 10L)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
    let (var_24: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, var_1, 10, 784, var_9, var_19, var_1, var_20, 784, var_21, var_23, var_1)
    if var_24 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_24)
and method_29((var_0: int64), (var_1: (Union0 ref)), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union7 ref)), (var_5: (Union7 ref))): float32 =
    let (var_6: Union7) = (!var_5)
    match var_6 with
    | Union7Case0(var_7) ->
        var_7.mem_0
    | Union7Case1 ->
        let (var_9: float32) = method_27((var_0: int64), (var_1: (Union0 ref)), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union7 ref)))
        var_5 := (Union7Case0(Tuple8(var_9)))
        var_9
and method_28((var_0: (Union0 ref)), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: (Union7 ref))): float32 =
    let (var_4: Union7) = (!var_3)
    match var_4 with
    | Union7Case0(var_5) ->
        var_5.mem_0
    | Union7Case1 ->
        let (var_7: float32) = method_25((var_0: (Union0 ref)), (var_1: int64), (var_2: ManagedCuda.CudaContext))
        var_3 := (Union7Case0(Tuple8(var_7)))
        var_7
and method_41((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: (Union0 ref)), (var_3: int64), (var_4: int64), (var_5: (Union0 ref)), (var_6: (Union0 ref))): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: bool) = (0L < var_4)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_12: int64) = (var_4 * 784L)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_2: (Union0 ref)))
    let (var_14: ManagedCuda.BasicTypes.SizeT) = var_13.Pointer
    let (var_15: uint64) = uint64 var_14
    let (var_16: uint64) = (uint64 var_3)
    let (var_17: uint64) = (var_15 + var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_20: int64) = (var_4 * 10L)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_5: (Union0 ref)))
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
    let (var_24: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, 784, 10, var_1, var_9, var_19, var_1, var_21, var_1, var_22, var_23, 784)
    if var_24 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_24)
and method_27((var_0: int64), (var_1: (Union0 ref)), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union7 ref))): float32 =
    let (var_5: float32) = method_28((var_1: (Union0 ref)), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union7 ref)))
    let (var_6: float32) = (float32 var_0)
    (var_5 / var_6)
and method_25((var_0: (Union0 ref)), (var_1: int64), (var_2: ManagedCuda.CudaContext)): float32 =
    let (var_3: bool) = (0L < var_1)
    let (var_4: bool) = (var_3 = false)
    if var_4 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_5: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_0: (Union0 ref)))
    let (var_6: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_1))
    var_2.CopyToHost(var_6, var_5)
    var_2.Synchronize()
    let (var_7: float32) = 0.000000f
    let (var_8: int64) = 0L
    method_26((var_6: (float32 [])), (var_1: int64), (var_7: float32), (var_8: int64))
and method_26((var_0: (float32 [])), (var_1: int64), (var_2: float32), (var_3: int64)): float32 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: float32) = var_0.[int32 var_3]
        let (var_8: float32) = (var_2 + var_7)
        let (var_9: int64) = (var_3 + 1L)
        method_26((var_0: (float32 [])), (var_1: int64), (var_8: float32), (var_9: int64))
    else
        var_2
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
let (var_58: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_59: Tuple3) = method_2((var_58: string))
let (var_60: Tuple4) = var_59.mem_0
let (var_61: (uint8 [])) = var_59.mem_1
let (var_62: int64) = var_60.mem_0
let (var_63: int64) = var_60.mem_1
let (var_64: int64) = var_60.mem_2
let (var_65: bool) = (10000L = var_62)
let (var_69: bool) =
    if var_65 then
        let (var_66: bool) = (28L = var_63)
        if var_66 then
            (28L = var_64)
        else
            false
    else
        false
let (var_70: bool) = (var_69 = false)
if var_70 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_71: int64) = var_61.LongLength
let (var_72: bool) = (var_71 > 0L)
let (var_73: bool) = (var_72 = false)
if var_73 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_74: bool) = (7840000L = var_71)
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_79: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_80: int64) = 0L
method_3((var_61: (uint8 [])), (var_79: (float32 [])), (var_80: int64))
let (var_81: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_82: Tuple5) = method_5((var_81: string))
let (var_83: int64) = var_82.mem_0
let (var_84: (uint8 [])) = var_82.mem_1
let (var_85: bool) = (10000L = var_83)
let (var_86: bool) = (var_85 = false)
if var_86 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_90: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_91: int64) = 0L
method_6((var_84: (uint8 [])), (var_90: (float32 [])), (var_91: int64))
let (var_92: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_93: Tuple3) = method_2((var_92: string))
let (var_94: Tuple4) = var_93.mem_0
let (var_95: (uint8 [])) = var_93.mem_1
let (var_96: int64) = var_94.mem_0
let (var_97: int64) = var_94.mem_1
let (var_98: int64) = var_94.mem_2
let (var_99: bool) = (60000L = var_96)
let (var_103: bool) =
    if var_99 then
        let (var_100: bool) = (28L = var_97)
        if var_100 then
            (28L = var_98)
        else
            false
    else
        false
let (var_104: bool) = (var_103 = false)
if var_104 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_105: int64) = var_95.LongLength
let (var_106: bool) = (var_105 > 0L)
let (var_107: bool) = (var_106 = false)
if var_107 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_108: bool) = (47040000L = var_105)
let (var_109: bool) = (var_108 = false)
if var_109 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_113: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_114: int64) = 0L
method_8((var_95: (uint8 [])), (var_113: (float32 [])), (var_114: int64))
let (var_115: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_116: Tuple5) = method_5((var_115: string))
let (var_117: int64) = var_116.mem_0
let (var_118: (uint8 [])) = var_116.mem_1
let (var_119: bool) = (60000L = var_117)
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_124: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_125: int64) = 0L
method_9((var_118: (uint8 [])), (var_124: (float32 [])), (var_125: int64))
let (var_126: int64) = var_79.LongLength
let (var_127: int64) = (var_126 * 4L)
let (var_128: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_127: int64))
let (var_129: (Union0 ref)) = var_128.mem_0
let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_129: (Union0 ref)))
var_1.CopyToDevice(var_130, var_79)
let (var_131: int64) = var_90.LongLength
let (var_132: int64) = (var_131 * 4L)
let (var_133: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_132: int64))
let (var_134: (Union0 ref)) = var_133.mem_0
let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_134: (Union0 ref)))
var_1.CopyToDevice(var_135, var_90)
let (var_136: int64) = var_113.LongLength
let (var_137: int64) = (var_136 * 4L)
let (var_138: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_137: int64))
let (var_139: (Union0 ref)) = var_138.mem_0
let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_139: (Union0 ref)))
var_1.CopyToDevice(var_140, var_113)
let (var_141: int64) = var_124.LongLength
let (var_142: int64) = (var_141 * 4L)
let (var_143: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_142: int64))
let (var_144: (Union0 ref)) = var_143.mem_0
let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_144: (Union0 ref)))
var_1.CopyToDevice(var_145, var_124)
let (var_146: int64) = 31360L
let (var_147: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_146: int64))
let (var_148: (Union0 ref)) = var_147.mem_0
let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_148: (Union0 ref)))
let (var_150: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_51.GenerateNormal32(var_149, var_150, 0.000000f, 0.050189f)
let (var_151: int64) = 31360L
let (var_152: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_151: int64))
let (var_153: (Union0 ref)) = var_152.mem_0
let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_153: (Union0 ref)))
let (var_155: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_156: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_154, 0uy, var_156, var_155)
let (var_157: int64) = 40L
let (var_158: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_157: int64))
let (var_159: (Union0 ref)) = var_158.mem_0
let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_159: (Union0 ref)))
let (var_161: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_162: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_160, 0uy, var_162, var_161)
let (var_163: int64) = 40L
let (var_164: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_163: int64))
let (var_165: (Union0 ref)) = var_164.mem_0
let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_165: (Union0 ref)))
let (var_167: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_168: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_166, 0uy, var_168, var_167)
let (var_169: int64) = 0L
method_14((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_165: (Union0 ref)), (var_159: (Union0 ref)), (var_56: ManagedCuda.CudaBlas.CudaBlasHandle), (var_153: (Union0 ref)), (var_148: (Union0 ref)), (var_139: (Union0 ref)), (var_144: (Union0 ref)), (var_169: int64))
var_165 := Union0Case1
var_159 := Union0Case1
var_153 := Union0Case1
var_148 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_170)
var_43 := Union0Case1
var_1.Dispose()

