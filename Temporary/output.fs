module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
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
    typedef float(*FunPointer0)(float, float);
    struct Tuple3 {
        Tuple1 mem_0;
        Tuple1 mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(Tuple1 mem_0, Tuple1 mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple1(*FunPointer2)(Tuple1, Tuple1);
    __global__ void method_109(float * var_0, float * var_1);
    __global__ void method_112(float * var_0, float * var_1);
    __global__ void method_116(float * var_0, float * var_1);
    __global__ void method_119(float * var_0, float * var_1);
    __global__ void method_53(float * var_0, float * var_1, float * var_2);
    __global__ void method_77(float * var_0, float * var_1, float * var_2);
    __global__ void method_96(float * var_0, float * var_1, float * var_2);
    __global__ void method_132(long long int * var_0, long long int * var_1);
    __global__ void method_58(float * var_0, float * var_1);
    __global__ void method_63(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_90(float * var_0, float * var_1);
    __global__ void method_126(float * var_0, float * var_1, long long int * var_2);
    __global__ void method_68(float * var_0, float * var_1);
    __global__ void method_85(float * var_0, float * var_1);
    __global__ void method_102(float * var_0, float * var_1, float * var_2);
    __device__ char method_54(long long int * var_0);
    __device__ char method_113(long long int * var_0);
    __device__ char method_78(long long int * var_0);
    __device__ char method_103(long long int * var_0);
    __device__ char method_97(long long int * var_0, float * var_1);
    __device__ char method_133(long long int * var_0, long long int * var_1);
    __device__ char method_59(long long int * var_0);
    __device__ char method_91(long long int * var_0);
    __device__ float method_92(float var_0, float var_1);
    __device__ char method_127(long long int * var_0, float * var_1, float * var_2);
    __device__ Tuple1 method_128(Tuple1 var_0, Tuple1 var_1);
    __device__ char method_69(long long int * var_0, float * var_1);
    __device__ char method_70(long long int * var_0, float * var_1);
    __device__ char method_71(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_109(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_54(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 128);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 128);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_8];
            float var_17 = var_1[var_8];
            float var_18 = (var_16 - var_17);
            var_0[var_8] = var_18;
            var_1[var_8] = 0;
            long long int var_19 = (var_8 + 128);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_112(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_113(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 100352);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 100352);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_8];
            float var_17 = var_1[var_8];
            float var_18 = (var_16 - var_17);
            var_0[var_8] = var_18;
            var_1[var_8] = 0;
            long long int var_19 = (var_8 + 8192);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_116(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_78(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 10);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 10);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_8];
            float var_17 = var_1[var_8];
            float var_18 = (var_16 - var_17);
            var_0[var_8] = var_18;
            var_1[var_8] = 0;
            long long int var_19 = (var_8 + 128);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_119(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_103(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 1280);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 1280);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_8];
            float var_17 = var_1[var_8];
            float var_18 = (var_16 - var_17);
            var_0[var_8] = var_18;
            var_1[var_8] = 0;
            long long int var_19 = (var_8 + 1280);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_53(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_54(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 128);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_14 = threadIdx.y;
            long long int var_15 = blockIdx.y;
            long long int var_16 = (32 * var_15);
            long long int var_17 = (var_14 + var_16);
            long long int var_18[1];
            var_18[0] = var_17;
            while (method_54(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 128);
                } else {
                    var_23 = 0;
                }
                char var_24 = (var_23 == 0);
                if (var_24) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_25 = (var_20 * 128);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 128);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_25 + var_9);
                float var_30 = var_1[var_29];
                char var_32;
                if (var_21) {
                    var_32 = (var_20 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                char var_35;
                if (var_10) {
                    var_35 = (var_9 < 128);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                float var_37 = var_0[var_9];
                float var_38 = var_2[var_29];
                float var_39 = (var_37 + var_30);
                var_2[var_29] = var_39;
                long long int var_40 = (var_20 + 32);
                var_18[0] = var_40;
            }
            long long int var_41 = var_18[0];
            long long int var_42 = (var_9 + 128);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_77(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_78(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 10);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_14 = threadIdx.y;
            long long int var_15 = blockIdx.y;
            long long int var_16 = (32 * var_15);
            long long int var_17 = (var_14 + var_16);
            long long int var_18[1];
            var_18[0] = var_17;
            while (method_54(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 128);
                } else {
                    var_23 = 0;
                }
                char var_24 = (var_23 == 0);
                if (var_24) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_25 = (var_20 * 10);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 10);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_25 + var_9);
                float var_30 = var_1[var_29];
                char var_32;
                if (var_21) {
                    var_32 = (var_20 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                char var_35;
                if (var_10) {
                    var_35 = (var_9 < 10);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                float var_37 = var_0[var_9];
                float var_38 = var_2[var_29];
                float var_39 = (var_37 + var_30);
                var_2[var_29] = var_39;
                long long int var_40 = (var_20 + 32);
                var_18[0] = var_40;
            }
            long long int var_41 = var_18[0];
            long long int var_42 = (var_9 + 10);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_96(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_97(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 1280);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            float var_17 = var_0[var_11];
            float var_18 = var_1[var_11];
            float var_19 = (-var_18);
            float var_20 = log(var_17);
            float var_21 = (var_19 * var_20);
            float var_22 = (var_12 + var_21);
            long long int var_23 = (var_11 + 1024);
            var_8[0] = var_23;
            var_9[0] = var_22;
        }
        long long int var_24 = var_8[0];
        float var_25 = var_9[0];
        float var_26 = cub::BlockReduce<float,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_25);
        float var_27 = (var_26 / 128);
        long long int var_28 = threadIdx.x;
        char var_29 = (var_28 == 0);
        if (var_29) {
            long long int var_30 = blockIdx.x;
            char var_31 = (var_30 >= 0);
            char var_33;
            if (var_31) {
                var_33 = (var_30 < 1);
            } else {
                var_33 = 0;
            }
            char var_34 = (var_33 == 0);
            if (var_34) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_30] = var_27;
        } else {
        }
    }
    __global__ void method_132(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_133(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 128);
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
            long long int var_18 = (var_10 + 128);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = cub::BlockReduce<long long int,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_22 = threadIdx.x;
        char var_23 = (var_22 == 0);
        if (var_23) {
            long long int var_24 = blockIdx.x;
            char var_25 = (var_24 >= 0);
            char var_27;
            if (var_25) {
                var_27 = (var_24 < 1);
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
    __global__ void method_58(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_59(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 16384);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 16384);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_8];
            float var_17 = var_1[var_8];
            float var_18 = (-var_16);
            float var_19 = exp(var_18);
            float var_20 = (1 + var_19);
            float var_21 = (1 / var_20);
            var_1[var_8] = var_21;
            long long int var_22 = (var_8 + 8192);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_63(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_59(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 16384);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // "Argument out of bounds."
            } else {
            }
            char var_16;
            if (var_11) {
                var_16 = (var_10 < 16384);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_0[var_10];
            float var_19 = var_1[var_10];
            float var_20 = var_2[var_10];
            float var_21 = var_3[var_10];
            float var_22 = (1 - var_20);
            float var_23 = (var_20 * var_22);
            float var_24 = (var_19 * var_23);
            float var_25 = (var_21 + var_24);
            var_3[var_10] = var_25;
            long long int var_26 = (var_10 + 8192);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_90(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_54(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 128);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_12 = (var_7 * 10);
            char var_14;
            if (var_8) {
                var_14 = (var_7 < 128);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16[1];
            long long int var_17 = threadIdx.x;
            long long int var_18 = blockIdx.x;
            long long int var_19 = (10 * var_18);
            long long int var_20 = (var_17 + var_19);
            long long int var_21[1];
            var_21[0] = 0;
            while (method_91(var_21)) {
                long long int var_23 = var_21[0];
                long long int var_24 = (10 * var_23);
                long long int var_25 = (var_20 + var_24);
                long long int var_26 = (10 - var_24);
                char var_27 = (var_25 < 10);
                if (var_27) {
                    char var_28 = (var_23 >= 0);
                    char var_30;
                    if (var_28) {
                        var_30 = (var_23 < 1);
                    } else {
                        var_30 = 0;
                    }
                    char var_31 = (var_30 == 0);
                    if (var_31) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_32 = (var_25 >= 0);
                    char var_33 = (var_32 == 0);
                    if (var_33) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_34 = (var_12 + var_25);
                    float var_35 = var_0[var_34];
                    var_16[var_23] = var_35;
                } else {
                }
                long long int var_36 = (var_23 + 1);
                var_21[0] = var_36;
            }
            long long int var_37 = var_21[0];
            FunPointer0 var_40 = method_92;
            float var_41 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_16, var_40);
            __shared__ float var_42[1];
            long long int var_43 = threadIdx.x;
            char var_44 = (var_43 == 0);
            if (var_44) {
                var_42[0] = var_41;
            } else {
            }
            __syncthreads();
            float var_45 = var_42[0];
            float var_48[1];
            long long int var_49[1];
            var_49[0] = 0;
            while (method_91(var_49)) {
                long long int var_51 = var_49[0];
                long long int var_52 = (10 * var_51);
                long long int var_53 = (var_20 + var_52);
                long long int var_54 = (10 - var_52);
                char var_55 = (var_53 < 10);
                if (var_55) {
                    char var_56 = (var_53 >= 0);
                    char var_57 = (var_56 == 0);
                    if (var_57) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_58 = (var_12 + var_53);
                    char var_59 = (var_51 >= 0);
                    char var_61;
                    if (var_59) {
                        var_61 = (var_51 < 1);
                    } else {
                        var_61 = 0;
                    }
                    char var_62 = (var_61 == 0);
                    if (var_62) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_63 = var_16[var_51];
                    float var_64 = (var_63 - var_45);
                    float var_65 = exp(var_64);
                    char var_67;
                    if (var_59) {
                        var_67 = (var_51 < 1);
                    } else {
                        var_67 = 0;
                    }
                    char var_68 = (var_67 == 0);
                    if (var_68) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_48[var_51] = var_65;
                } else {
                }
                long long int var_69 = (var_51 + 1);
                var_49[0] = var_69;
            }
            long long int var_70 = var_49[0];
            float var_71 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_48);
            __shared__ float var_72[1];
            long long int var_73 = threadIdx.x;
            char var_74 = (var_73 == 0);
            if (var_74) {
                var_72[0] = var_71;
            } else {
            }
            __syncthreads();
            float var_75 = var_72[0];
            long long int var_76[1];
            var_76[0] = 0;
            while (method_91(var_76)) {
                long long int var_78 = var_76[0];
                long long int var_79 = (10 * var_78);
                long long int var_80 = (var_20 + var_79);
                long long int var_81 = (10 - var_79);
                char var_82 = (var_80 < 10);
                if (var_82) {
                    char var_83 = (var_80 >= 0);
                    char var_84 = (var_83 == 0);
                    if (var_84) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_85 = (var_12 + var_80);
                    char var_86 = (var_78 >= 0);
                    char var_88;
                    if (var_86) {
                        var_88 = (var_78 < 1);
                    } else {
                        var_88 = 0;
                    }
                    char var_89 = (var_88 == 0);
                    if (var_89) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_90 = var_48[var_78];
                    float var_91 = var_1[var_85];
                    float var_92 = (var_90 / var_75);
                    var_1[var_85] = var_92;
                } else {
                }
                long long int var_93 = (var_78 + 1);
                var_76[0] = var_93;
            }
            long long int var_94 = var_76[0];
            long long int var_95 = (var_7 + 64);
            var_5[0] = var_95;
        }
        long long int var_96 = var_5[0];
    }
    __global__ void method_126(float * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_54(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 128);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_13 = (var_8 * 10);
            char var_15;
            if (var_9) {
                var_15 = (var_8 < 128);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.x;
            long long int var_18 = blockIdx.x;
            long long int var_19 = (10 * var_18);
            long long int var_20 = (var_17 + var_19);
            float var_21 = __int_as_float(0xff800000);
            float var_22 = 0;
            long long int var_23[1];
            float var_24[1];
            float var_25[1];
            var_23[0] = var_20;
            var_24[0] = var_21;
            var_25[0] = var_22;
            while (method_127(var_23, var_24, var_25)) {
                long long int var_27 = var_23[0];
                float var_28 = var_24[0];
                float var_29 = var_25[0];
                char var_30 = (var_27 >= 0);
                char var_32;
                if (var_30) {
                    var_32 = (var_27 < 10);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_13 + var_27);
                float var_35 = var_0[var_34];
                float var_36 = var_1[var_34];
                char var_37 = (var_28 > var_35);
                Tuple1 var_38;
                if (var_37) {
                    var_38 = make_Tuple1(var_28, var_29);
                } else {
                    var_38 = make_Tuple1(var_35, var_36);
                }
                float var_39 = var_38.mem_0;
                float var_40 = var_38.mem_1;
                long long int var_41 = (var_27 + 10);
                var_23[0] = var_41;
                var_24[0] = var_39;
                var_25[0] = var_40;
            }
            long long int var_42 = var_23[0];
            float var_43 = var_24[0];
            float var_44 = var_25[0];
            FunPointer2 var_47 = method_128;
            Tuple1 var_48 = cub::BlockReduce<Tuple1,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple1(var_43, var_44), var_47);
            float var_49 = var_48.mem_0;
            float var_50 = var_48.mem_1;
            long long int var_51 = threadIdx.x;
            char var_52 = (var_51 == 0);
            if (var_52) {
                char var_54;
                if (var_9) {
                    var_54 = (var_8 < 128);
                } else {
                    var_54 = 0;
                }
                char var_55 = (var_54 == 0);
                if (var_55) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_56 = var_2[var_8];
                long long int var_57 = ((long long int) (var_50));
                var_2[var_8] = var_57;
            } else {
            }
            long long int var_58 = (var_8 + 64);
            var_6[0] = var_58;
        }
        long long int var_59 = var_6[0];
    }
    __global__ void method_68(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_54(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 128);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 128);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = threadIdx.y;
            long long int var_17 = blockIdx.y;
            long long int var_18 = (32 * var_17);
            long long int var_19 = (var_16 + var_18);
            float var_20 = 0;
            long long int var_21[1];
            float var_22[1];
            var_21[0] = var_19;
            var_22[0] = var_20;
            while (method_69(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 128);
                } else {
                    var_28 = 0;
                }
                char var_29 = (var_28 == 0);
                if (var_29) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_30 = (var_24 * 128);
                char var_32;
                if (var_9) {
                    var_32 = (var_8 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_30 + var_8);
                float var_35 = var_0[var_34];
                float var_36 = (var_25 + var_35);
                long long int var_37 = (var_24 + 32);
                var_21[0] = var_37;
                var_22[0] = var_36;
            }
            long long int var_38 = var_21[0];
            float var_39 = var_22[0];
            __shared__ float var_40[992];
            long long int var_41[1];
            float var_42[1];
            var_41[0] = 32;
            var_42[0] = var_39;
            while (method_70(var_41, var_42)) {
                long long int var_44 = var_41[0];
                float var_45 = var_42[0];
                long long int var_46 = (var_44 / 2);
                long long int var_47 = threadIdx.y;
                char var_48 = (var_47 < var_44);
                char var_51;
                if (var_48) {
                    long long int var_49 = threadIdx.y;
                    var_51 = (var_49 >= var_46);
                } else {
                    var_51 = 0;
                }
                if (var_51) {
                    long long int var_52 = threadIdx.y;
                    char var_53 = (var_52 >= 1);
                    char var_55;
                    if (var_53) {
                        var_55 = (var_52 < 32);
                    } else {
                        var_55 = 0;
                    }
                    char var_56 = (var_55 == 0);
                    if (var_56) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_57 = (var_52 - 1);
                    long long int var_58 = (var_57 * 32);
                    long long int var_59 = threadIdx.x;
                    char var_60 = (var_59 >= 0);
                    char var_62;
                    if (var_60) {
                        var_62 = (var_59 < 32);
                    } else {
                        var_62 = 0;
                    }
                    char var_63 = (var_62 == 0);
                    if (var_63) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_64 = (var_58 + var_59);
                    var_40[var_64] = var_45;
                } else {
                }
                __syncthreads();
                long long int var_65 = threadIdx.y;
                char var_66 = (var_65 < var_46);
                float var_91;
                if (var_66) {
                    long long int var_67 = threadIdx.y;
                    long long int var_68 = (var_67 + var_46);
                    long long int var_69[1];
                    float var_70[1];
                    var_69[0] = var_68;
                    var_70[0] = var_45;
                    while (method_71(var_44, var_69, var_70)) {
                        long long int var_72 = var_69[0];
                        float var_73 = var_70[0];
                        char var_74 = (var_72 >= 1);
                        char var_76;
                        if (var_74) {
                            var_76 = (var_72 < 32);
                        } else {
                            var_76 = 0;
                        }
                        char var_77 = (var_76 == 0);
                        if (var_77) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_78 = (var_72 - 1);
                        long long int var_79 = (var_78 * 32);
                        long long int var_80 = threadIdx.x;
                        char var_81 = (var_80 >= 0);
                        char var_83;
                        if (var_81) {
                            var_83 = (var_80 < 32);
                        } else {
                            var_83 = 0;
                        }
                        char var_84 = (var_83 == 0);
                        if (var_84) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_85 = (var_79 + var_80);
                        float var_86 = var_40[var_85];
                        float var_87 = (var_73 + var_86);
                        long long int var_88 = (var_72 + var_46);
                        var_69[0] = var_88;
                        var_70[0] = var_87;
                    }
                    long long int var_89 = var_69[0];
                    var_91 = var_70[0];
                } else {
                    var_91 = var_45;
                }
                var_41[0] = var_46;
                var_42[0] = var_91;
            }
            long long int var_92 = var_41[0];
            float var_93 = var_42[0];
            long long int var_94 = threadIdx.y;
            char var_95 = (var_94 == 0);
            if (var_95) {
                float var_96 = var_1[var_8];
                float var_97 = (var_93 + var_96);
                var_1[var_8] = var_97;
            } else {
            }
            long long int var_98 = (var_8 + 128);
            var_6[0] = var_98;
        }
        long long int var_99 = var_6[0];
    }
    __global__ void method_85(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_78(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 10);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            char var_14;
            if (var_9) {
                var_14 = (var_8 < 10);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = threadIdx.y;
            long long int var_17 = blockIdx.y;
            long long int var_18 = (32 * var_17);
            long long int var_19 = (var_16 + var_18);
            float var_20 = 0;
            long long int var_21[1];
            float var_22[1];
            var_21[0] = var_19;
            var_22[0] = var_20;
            while (method_69(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 128);
                } else {
                    var_28 = 0;
                }
                char var_29 = (var_28 == 0);
                if (var_29) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_30 = (var_24 * 10);
                char var_32;
                if (var_9) {
                    var_32 = (var_8 < 10);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_30 + var_8);
                float var_35 = var_0[var_34];
                float var_36 = (var_25 + var_35);
                long long int var_37 = (var_24 + 32);
                var_21[0] = var_37;
                var_22[0] = var_36;
            }
            long long int var_38 = var_21[0];
            float var_39 = var_22[0];
            __shared__ float var_40[310];
            long long int var_41[1];
            float var_42[1];
            var_41[0] = 32;
            var_42[0] = var_39;
            while (method_70(var_41, var_42)) {
                long long int var_44 = var_41[0];
                float var_45 = var_42[0];
                long long int var_46 = (var_44 / 2);
                long long int var_47 = threadIdx.y;
                char var_48 = (var_47 < var_44);
                char var_51;
                if (var_48) {
                    long long int var_49 = threadIdx.y;
                    var_51 = (var_49 >= var_46);
                } else {
                    var_51 = 0;
                }
                if (var_51) {
                    long long int var_52 = threadIdx.y;
                    char var_53 = (var_52 >= 1);
                    char var_55;
                    if (var_53) {
                        var_55 = (var_52 < 32);
                    } else {
                        var_55 = 0;
                    }
                    char var_56 = (var_55 == 0);
                    if (var_56) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_57 = (var_52 - 1);
                    long long int var_58 = (var_57 * 10);
                    long long int var_59 = threadIdx.x;
                    char var_60 = (var_59 >= 0);
                    char var_62;
                    if (var_60) {
                        var_62 = (var_59 < 10);
                    } else {
                        var_62 = 0;
                    }
                    char var_63 = (var_62 == 0);
                    if (var_63) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_64 = (var_58 + var_59);
                    var_40[var_64] = var_45;
                } else {
                }
                __syncthreads();
                long long int var_65 = threadIdx.y;
                char var_66 = (var_65 < var_46);
                float var_91;
                if (var_66) {
                    long long int var_67 = threadIdx.y;
                    long long int var_68 = (var_67 + var_46);
                    long long int var_69[1];
                    float var_70[1];
                    var_69[0] = var_68;
                    var_70[0] = var_45;
                    while (method_71(var_44, var_69, var_70)) {
                        long long int var_72 = var_69[0];
                        float var_73 = var_70[0];
                        char var_74 = (var_72 >= 1);
                        char var_76;
                        if (var_74) {
                            var_76 = (var_72 < 32);
                        } else {
                            var_76 = 0;
                        }
                        char var_77 = (var_76 == 0);
                        if (var_77) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_78 = (var_72 - 1);
                        long long int var_79 = (var_78 * 10);
                        long long int var_80 = threadIdx.x;
                        char var_81 = (var_80 >= 0);
                        char var_83;
                        if (var_81) {
                            var_83 = (var_80 < 10);
                        } else {
                            var_83 = 0;
                        }
                        char var_84 = (var_83 == 0);
                        if (var_84) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_85 = (var_79 + var_80);
                        float var_86 = var_40[var_85];
                        float var_87 = (var_73 + var_86);
                        long long int var_88 = (var_72 + var_46);
                        var_69[0] = var_88;
                        var_70[0] = var_87;
                    }
                    long long int var_89 = var_69[0];
                    var_91 = var_70[0];
                } else {
                    var_91 = var_45;
                }
                var_41[0] = var_46;
                var_42[0] = var_91;
            }
            long long int var_92 = var_41[0];
            float var_93 = var_42[0];
            long long int var_94 = threadIdx.y;
            char var_95 = (var_94 == 0);
            if (var_95) {
                float var_96 = var_1[var_8];
                float var_97 = (var_93 + var_96);
                var_1[var_8] = var_97;
            } else {
            }
            long long int var_98 = (var_8 + 10);
            var_6[0] = var_98;
        }
        long long int var_99 = var_6[0];
    }
    __global__ void method_102(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_103(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 1280);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 1280);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            float var_17 = var_0[var_9];
            float var_18 = var_1[var_9];
            float var_19 = var_2[var_9];
            float var_20 = (var_17 - var_18);
            float var_21 = (var_20 / 128);
            float var_22 = (var_19 + var_21);
            var_2[var_9] = var_22;
            long long int var_23 = (var_9 + 1280);
            var_7[0] = var_23;
        }
        long long int var_24 = var_7[0];
    }
    __device__ char method_54(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_113(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 100352);
    }
    __device__ char method_78(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_103(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1280);
    }
    __device__ char method_97(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1280);
    }
    __device__ char method_133(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_59(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
    }
    __device__ char method_91(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ float method_92(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_127(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 10);
    }
    __device__ Tuple1 method_128(Tuple1 var_0, Tuple1 var_1) {
        float var_2 = var_0.mem_0;
        float var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        float var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple1 var_7;
        if (var_6) {
            var_7 = make_Tuple1(var_2, var_3);
        } else {
            var_7 = make_Tuple1(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        float var_9 = var_7.mem_1;
        return make_Tuple1(var_8, var_9);
    }
    __device__ char method_69(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_70(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_71(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
}
"""

type Env0 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack1 =
    struct
    val mem_0: ResizeArray<Env0>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env2 =
    struct
    val mem_0: Env14
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack3 =
    struct
    val mem_0: ResizeArray<Env2>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env4 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack5 =
    struct
    val mem_0: ResizeArray<Env4>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env6 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env8
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack7 =
    struct
    val mem_0: ResizeArray<Env6>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env8 =
    struct
    val mem_0: (bool ref)
    val mem_1: ManagedCuda.CudaStream
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple9 =
    struct
    val mem_0: Tuple10
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple10 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple11 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env12 =
    struct
    val mem_0: Env4
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack13 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env14 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack15 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack16 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack17 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple18 =
    struct
    val mem_0: float
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvHeap19 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: EnvStack1
    mem_3: EnvStack3
    }
and EnvStack20 =
    struct
    val mem_0: EnvStack21
    val mem_1: (int64 ref)
    val mem_2: Env14
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack21 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack22 =
    struct
    val mem_0: EnvStack16
    val mem_1: (int64 ref)
    val mem_2: Env14
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack23 =
    struct
    val mem_0: Env24
    val mem_1: (unit -> unit)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env24 =
    struct
    val mem_0: Env25
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env25 =
    struct
    val mem_0: Env12
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack26 =
    struct
    val mem_0: Env27
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env27 =
    struct
    val mem_0: Env28
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env28 =
    struct
    val mem_0: Env29
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env29 =
    struct
    val mem_0: Env4
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env30 =
    struct
    val mem_0: Env24
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack31 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env14
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env32 =
    struct
    val mem_0: Env27
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3)): unit =
    let (var_4: ResizeArray<Env2>) = var_3.mem_0
    let (var_6: (Env2 -> bool)) = method_2
    let (var_7: int32) = var_4.RemoveAll <| System.Predicate(var_6)
    let (var_9: (Env2 -> (Env2 -> int32))) = method_3
    let (var_10: System.Comparison<Env2>) = System.Comparison<Env2>(var_9)
    var_4.Sort(var_10)
    let (var_11: ResizeArray<Env0>) = var_0.mem_0
    var_11.Clear()
    let (var_12: int32) = var_4.get_Count()
    let (var_13: uint64) = method_5((var_1: (uint64 ref)))
    let (var_14: int32) = 0
    let (var_15: uint64) = method_6((var_0: EnvStack1), (var_3: EnvStack3), (var_12: int32), (var_13: uint64), (var_14: int32))
    let (var_16: uint64) = method_5((var_1: (uint64 ref)))
    let (var_17: uint64) = (var_16 + var_2)
    let (var_18: uint64) = (var_17 - var_15)
    let (var_19: uint64) = (var_15 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: uint64) = (var_21 - var_15)
    let (var_23: bool) = (var_18 > var_22)
    if var_23 then
        let (var_24: uint64) = (var_18 - var_22)
        var_11.Add((Env0(var_21, var_24)))
    else
        ()
and method_7((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule)): Env6 =
    let (var_12: (int64 ref)) = (ref 0L)
    method_8((var_12: (int64 ref)), (var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_10: EnvStack7))
    (Env6(var_12, (Env8(var_0, var_1))))
and method_9((var_0: string)): Tuple9 =
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
    Tuple9(Tuple10(var_16, var_17, var_18), var_22)
and method_10((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_11((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_10((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_12((var_0: string)): Tuple11 =
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
    Tuple11(var_12, var_14)
and method_13((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_14((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_13((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_15((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_11((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_15((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_16((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_14((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_16((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64), (var_13: (float32 [])), (var_14: int64), (var_15: int64), (var_16: int64)): Env12 =
    let (var_17: int64) = (var_12 * var_15)
    let (var_18: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_19: int64) = var_18.AddrOfPinnedObject().ToInt64()
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: int64) = (var_14 * 4L)
    let (var_22: uint64) = (uint64 var_21)
    let (var_23: uint64) = (var_22 + var_20)
    let (var_24: Env4) = method_18((var_17: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: Env14) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: int64) = (var_17 * 4L)
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_35: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_31, var_33, var_34)
    if var_35 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_35)
    var_18.Free()
    (Env12((Env4(var_25, var_26))))
and method_24((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): EnvStack13 =
    let (var_12: Env4) = method_25((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env14) = var_12.mem_1
    method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (int64 ref)), (var_14: Env14), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    EnvStack13((var_13: (int64 ref)), (var_14: Env14))
and method_28((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): EnvStack13 =
    let (var_14: Env4) = method_25((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env14) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_29((var_15: (int64 ref)), (var_16: Env14), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack13((var_15: (int64 ref)), (var_16: Env14))
and method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): EnvStack15 =
    let (var_12: Env4) = method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env14) = var_12.mem_1
    let (var_15: (bool ref)) = var_11.mem_0
    let (var_16: ManagedCuda.CudaStream) = var_11.mem_1
    let (var_17: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: (bool ref)), (var_16: ManagedCuda.CudaStream))
    method_32((var_13: (int64 ref)), (var_14: Env14), (var_6: ManagedCuda.CudaContext), (var_17: ManagedCuda.BasicTypes.CUstream))
    EnvStack15((var_13: (int64 ref)), (var_14: Env14))
and method_33((var_0: EnvStack15), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8)): EnvStack15 =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env14) = var_0.mem_1
    let (var_15: Env4) = method_31((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env14) = var_15.mem_1
    let (var_18: (bool ref)) = var_12.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_12.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_27((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    method_32((var_16: (int64 ref)), (var_17: Env14), (var_7: ManagedCuda.CudaContext), (var_20: ManagedCuda.BasicTypes.CUstream))
    EnvStack15((var_16: (int64 ref)), (var_17: Env14))
and method_34((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): EnvStack16 =
    let (var_12: Env4) = method_35((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env14) = var_12.mem_1
    method_36((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (int64 ref)), (var_14: Env14), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    EnvStack16((var_13: (int64 ref)), (var_14: Env14))
and method_37((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): EnvStack16 =
    let (var_14: Env4) = method_35((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env14) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_38((var_15: (int64 ref)), (var_16: Env14), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack16((var_15: (int64 ref)), (var_16: Env14))
and method_39((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): EnvStack17 =
    let (var_12: Env4) = method_40((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env14) = var_12.mem_1
    let (var_15: (bool ref)) = var_11.mem_0
    let (var_16: ManagedCuda.CudaStream) = var_11.mem_1
    let (var_17: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: (bool ref)), (var_16: ManagedCuda.CudaStream))
    method_41((var_13: (int64 ref)), (var_14: Env14), (var_6: ManagedCuda.CudaContext), (var_17: ManagedCuda.BasicTypes.CUstream))
    EnvStack17((var_13: (int64 ref)), (var_14: Env14))
and method_42((var_0: EnvStack17), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8)): EnvStack17 =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env14) = var_0.mem_1
    let (var_15: Env4) = method_40((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env14) = var_15.mem_1
    let (var_18: (bool ref)) = var_12.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_12.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_27((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    method_41((var_16: (int64 ref)), (var_17: Env14), (var_7: ManagedCuda.CudaContext), (var_20: ManagedCuda.BasicTypes.CUstream))
    EnvStack17((var_16: (int64 ref)), (var_17: Env14))
and method_43((var_0: EnvStack15), (var_1: EnvStack15), (var_2: EnvStack13), (var_3: (int64 ref)), (var_4: Env14), (var_5: EnvStack17), (var_6: EnvStack17), (var_7: EnvStack16), (var_8: (int64 ref)), (var_9: Env14), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8), (var_22: Env4), (var_23: Env4), (var_24: Env4), (var_25: Env4), (var_26: int64)): unit =
    let (var_27: bool) = (var_26 < 30L)
    if var_27 then
        let (var_28: int64) = 0L
        let (var_29: float) = 0.000000
        let (var_30: int64) = 0L
        let (var_31: float) = method_44((var_24: Env4), (var_25: Env4), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8), (var_28: int64), (var_29: float), (var_0: EnvStack15), (var_1: EnvStack15), (var_2: EnvStack13), (var_3: (int64 ref)), (var_4: Env14), (var_5: EnvStack17), (var_6: EnvStack17), (var_7: EnvStack16), (var_8: (int64 ref)), (var_9: Env14), (var_30: int64))
        let (var_32: string) = System.String.Format("Training: {0}",var_31)
        let (var_33: string) = System.String.Format("{0}",var_32)
        System.Console.WriteLine(var_33)
        if (System.Double.IsNaN var_31) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_34: int64) = 0L
            let (var_35: float) = 0.000000
            let (var_36: int64) = 0L
            let (var_37: int64) = 0L
            let (var_38: int64) = 0L
            let (var_39: Tuple18) = method_120((var_22: Env4), (var_23: Env4), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8), (var_36: int64), (var_37: int64), (var_34: int64), (var_35: float), (var_0: EnvStack15), (var_1: EnvStack15), (var_2: EnvStack13), (var_3: (int64 ref)), (var_4: Env14), (var_5: EnvStack17), (var_6: EnvStack17), (var_7: EnvStack16), (var_8: (int64 ref)), (var_9: Env14), (var_38: int64))
            let (var_40: float) = var_39.mem_0
            let (var_41: int64) = var_39.mem_1
            let (var_42: int64) = var_39.mem_2
            let (var_43: string) = System.String.Format("Testing: {0}({1}/{2})",var_40,var_41,var_42)
            let (var_44: string) = System.String.Format("{0}",var_43)
            System.Console.WriteLine(var_44)
            let (var_45: int64) = (var_26 + 1L)
            method_43((var_0: EnvStack15), (var_1: EnvStack15), (var_2: EnvStack13), (var_3: (int64 ref)), (var_4: Env14), (var_5: EnvStack17), (var_6: EnvStack17), (var_7: EnvStack16), (var_8: (int64 ref)), (var_9: Env14), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8), (var_22: Env4), (var_23: Env4), (var_24: Env4), (var_25: Env4), (var_45: int64))
    else
        ()
and method_135((var_0: EnvStack7)): unit =
    let (var_1: ResizeArray<Env6>) = var_0.mem_0
    let (var_3: (Env6 -> unit)) = method_136
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_105((var_0: EnvStack5)): unit =
    let (var_1: ResizeArray<Env4>) = var_0.mem_0
    let (var_3: (Env4 -> unit)) = method_106
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2 ((var_0: Env2)): bool =
    let (var_1: Env14) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: Env14) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: EnvStack1), (var_1: EnvStack3), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env2>) = var_1.mem_0
        let (var_7: Env2) = var_6.[var_4]
        let (var_8: Env14) = var_7.mem_0
        let (var_9: uint64) = var_7.mem_1
        let (var_10: (uint64 ref)) = var_8.mem_0
        let (var_11: uint64) = method_5((var_10: (uint64 ref)))
        let (var_12: bool) = (var_11 >= var_3)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_14: uint64) = method_5((var_10: (uint64 ref)))
        let (var_15: uint64) = (var_14 - var_3)
        let (var_16: uint64) = (var_3 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_3)
        let (var_20: bool) = (var_15 > var_19)
        if var_20 then
            let (var_21: ResizeArray<Env0>) = var_0.mem_0
            let (var_22: uint64) = (var_15 - var_19)
            var_21.Add((Env0(var_18, var_22)))
        else
            ()
        let (var_23: uint64) = (var_14 + var_9)
        let (var_24: int32) = (var_4 + 1)
        method_6((var_0: EnvStack1), (var_1: EnvStack3), (var_2: int32), (var_23: uint64), (var_24: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: (bool ref)), (var_2: ManagedCuda.CudaStream), (var_3: EnvStack7)): unit =
    let (var_4: int64) = (!var_0)
    let (var_5: int64) = (var_4 + 1L)
    var_0 := var_5
    let (var_6: ResizeArray<Env6>) = var_3.mem_0
    var_6.Add((Env6(var_0, (Env8(var_1, var_2)))))
and method_11((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64)): unit =
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
        method_11((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_11: int64))
    else
        ()
and method_14((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_14((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_18((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8)): Env4 =
    let (var_13: int64) = (var_0 * 4L)
    let (var_14: EnvHeap19) = ({mem_0 = (var_3: (uint64 ref)); mem_1 = (var_4: uint64); mem_2 = (var_5: EnvStack1); mem_3 = (var_6: EnvStack3)} : EnvHeap19)
    method_19((var_14: EnvHeap19), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8), (var_13: int64))
and method_25((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 401408L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env14), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (uint64 ref)) = var_2.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100352L)
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_0.SetStream(var_19)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    var_0.GenerateNormal32(var_21, var_16, 0.000000f, 0.046829f)
and method_27((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_29((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(401408L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 512L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_32((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_35((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 5120L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_36((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env14), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (uint64 ref)) = var_2.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_0.SetStream(var_19)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    var_0.GenerateNormal32(var_21, var_16, 0.000000f, 0.120386f)
and method_38((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_40((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 40L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_41((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_44((var_0: Env4), (var_1: Env4), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_14: int64), (var_15: float), (var_16: EnvStack15), (var_17: EnvStack15), (var_18: EnvStack13), (var_19: (int64 ref)), (var_20: Env14), (var_21: EnvStack17), (var_22: EnvStack17), (var_23: EnvStack16), (var_24: (int64 ref)), (var_25: Env14), (var_26: int64)): float =
    let (var_27: bool) = (var_26 < 468L)
    if var_27 then
        let (var_28: bool) = (var_26 >= 0L)
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_30: int64) = (var_26 * 100352L)
        if var_29 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_31: int64) = (var_26 * 1280L)
        let (var_32: EnvHeap19) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: EnvStack1); mem_3 = (var_7: EnvStack3)} : EnvHeap19)
        let (var_33: (uint64 ref)) = var_32.mem_0
        let (var_34: uint64) = var_32.mem_1
        let (var_35: EnvStack1) = var_32.mem_2
        let (var_36: EnvStack3) = var_32.mem_3
        method_1((var_35: EnvStack1), (var_33: (uint64 ref)), (var_34: uint64), (var_36: EnvStack3))
        let (var_40: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_41: EnvStack5) = EnvStack5((var_40: ResizeArray<Env4>))
        // Executing the net...
        let (var_42: EnvStack20) = method_45((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_0: Env4), (var_30: int64), (var_16: EnvStack15), (var_17: EnvStack15), (var_18: EnvStack13), (var_19: (int64 ref)), (var_20: Env14))
        let (var_43: EnvStack21) = var_42.mem_0
        let (var_44: (int64 ref)) = var_42.mem_1
        let (var_45: Env14) = var_42.mem_2
        let (var_46: (unit -> unit)) = var_42.mem_3
        let (var_47: EnvStack22) = method_72((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_43: EnvStack21), (var_44: (int64 ref)), (var_45: Env14), (var_21: EnvStack17), (var_22: EnvStack17), (var_23: EnvStack16), (var_24: (int64 ref)), (var_25: Env14))
        let (var_48: EnvStack16) = var_47.mem_0
        let (var_49: (int64 ref)) = var_47.mem_1
        let (var_50: Env14) = var_47.mem_2
        let (var_51: (unit -> unit)) = var_47.mem_3
        let (var_52: EnvStack23) = method_86((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_48: EnvStack16), (var_49: (int64 ref)), (var_50: Env14), (var_1: Env4), (var_31: int64))
        let (var_53: Env24) = var_52.mem_0
        let (var_54: (unit -> unit)) = var_52.mem_1
        let (var_55: Env25) = var_53.mem_0
        let (var_56: Env12) = var_55.mem_0
        let (var_57: int64) = var_55.mem_1
        let (var_58: int64) = 1L
        let (var_59: Env4) = var_56.mem_0
        let (var_60: (float32 [])) = method_104((var_58: int64), (var_56: Env12), (var_57: int64))
        let (var_61: float32) = var_60.[int32 0L]
        let (var_62: float) = (float var_61)
        let (var_63: float) = (var_15 + var_62)
        let (var_64: int64) = (var_14 + 1L)
        if (System.Double.IsNaN var_63) then
            method_105((var_41: EnvStack5))
            // Done with the net...
            let (var_65: float) = (float var_64)
            (var_63 / var_65)
        else
            var_54()
            var_51()
            var_46()
            let (var_67: (int64 ref)) = var_17.mem_0
            let (var_68: Env14) = var_17.mem_1
            method_107((var_17: EnvStack15), (var_16: EnvStack15), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
            method_110((var_19: (int64 ref)), (var_20: Env14), (var_18: EnvStack13), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
            let (var_69: (int64 ref)) = var_22.mem_0
            let (var_70: Env14) = var_22.mem_1
            method_114((var_22: EnvStack17), (var_21: EnvStack17), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
            method_117((var_24: (int64 ref)), (var_25: Env14), (var_23: EnvStack16), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_41: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
            method_105((var_41: EnvStack5))
            // Executing the next loop...
            let (var_71: int64) = (var_26 + 1L)
            method_44((var_0: Env4), (var_1: Env4), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_64: int64), (var_63: float), (var_16: EnvStack15), (var_17: EnvStack15), (var_18: EnvStack13), (var_19: (int64 ref)), (var_20: Env14), (var_21: EnvStack17), (var_22: EnvStack17), (var_23: EnvStack16), (var_24: (int64 ref)), (var_25: Env14), (var_71: int64))
    else
        let (var_74: float) = (float var_14)
        (var_15 / var_74)
and method_120((var_0: Env4), (var_1: Env4), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: float), (var_18: EnvStack15), (var_19: EnvStack15), (var_20: EnvStack13), (var_21: (int64 ref)), (var_22: Env14), (var_23: EnvStack17), (var_24: EnvStack17), (var_25: EnvStack16), (var_26: (int64 ref)), (var_27: Env14), (var_28: int64)): Tuple18 =
    let (var_29: bool) = (var_28 < 78L)
    if var_29 then
        let (var_30: bool) = (var_28 >= 0L)
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_32: int64) = (var_28 * 100352L)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_33: int64) = (var_28 * 1280L)
        let (var_34: EnvHeap19) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: EnvStack1); mem_3 = (var_7: EnvStack3)} : EnvHeap19)
        let (var_35: (uint64 ref)) = var_34.mem_0
        let (var_36: uint64) = var_34.mem_1
        let (var_37: EnvStack1) = var_34.mem_2
        let (var_38: EnvStack3) = var_34.mem_3
        method_1((var_37: EnvStack1), (var_35: (uint64 ref)), (var_36: uint64), (var_38: EnvStack3))
        let (var_42: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_43: EnvStack5) = EnvStack5((var_42: ResizeArray<Env4>))
        // Executing the net...
        let (var_44: EnvStack20) = method_45((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_43: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_0: Env4), (var_32: int64), (var_18: EnvStack15), (var_19: EnvStack15), (var_20: EnvStack13), (var_21: (int64 ref)), (var_22: Env14))
        let (var_45: EnvStack21) = var_44.mem_0
        let (var_46: (int64 ref)) = var_44.mem_1
        let (var_47: Env14) = var_44.mem_2
        let (var_48: (unit -> unit)) = var_44.mem_3
        let (var_49: EnvStack22) = method_72((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_43: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_45: EnvStack21), (var_46: (int64 ref)), (var_47: Env14), (var_23: EnvStack17), (var_24: EnvStack17), (var_25: EnvStack16), (var_26: (int64 ref)), (var_27: Env14))
        let (var_50: EnvStack16) = var_49.mem_0
        let (var_51: (int64 ref)) = var_49.mem_1
        let (var_52: Env14) = var_49.mem_2
        let (var_53: (unit -> unit)) = var_49.mem_3
        let (var_54: EnvStack23) = method_86((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_43: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_50: EnvStack16), (var_51: (int64 ref)), (var_52: Env14), (var_1: Env4), (var_33: int64))
        let (var_55: Env24) = var_54.mem_0
        let (var_56: (unit -> unit)) = var_54.mem_1
        let (var_57: EnvStack26) = method_121((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_43: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_50: EnvStack16), (var_51: (int64 ref)), (var_52: Env14), (var_1: Env4), (var_33: int64))
        let (var_58: Env27) = var_57.mem_0
        let (var_59: Env25) = var_55.mem_0
        let (var_60: Env12) = var_59.mem_0
        let (var_61: int64) = var_59.mem_1
        let (var_62: int64) = 1L
        let (var_63: Env4) = var_60.mem_0
        let (var_64: (float32 [])) = method_104((var_62: int64), (var_60: Env12), (var_61: int64))
        let (var_65: float32) = var_64.[int32 0L]
        let (var_66: float) = (float var_65)
        let (var_67: float) = (var_17 + var_66)
        let (var_68: Env28) = var_58.mem_0
        let (var_69: Env29) = var_68.mem_0
        let (var_70: int64) = var_68.mem_1
        let (var_71: int64) = 1L
        let (var_72: Env4) = var_69.mem_0
        let (var_73: (int64 [])) = method_134((var_71: int64), (var_69: Env29), (var_70: int64))
        let (var_74: int64) = var_73.[int32 0L]
        let (var_75: int64) = (var_14 + var_74)
        let (var_76: int64) = (var_15 + 128L)
        let (var_77: int64) = (var_16 + 1L)
        if (System.Double.IsNaN var_67) then
            method_105((var_43: EnvStack5))
            // Done with the net...
            let (var_78: float) = (float var_77)
            let (var_79: float) = (var_67 / var_78)
            Tuple18(var_79, var_75, var_76)
        else
            method_105((var_43: EnvStack5))
            // Executing the next loop...
            let (var_80: int64) = (var_28 + 1L)
            method_120((var_0: Env4), (var_1: Env4), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8), (var_75: int64), (var_76: int64), (var_77: int64), (var_67: float), (var_18: EnvStack15), (var_19: EnvStack15), (var_20: EnvStack13), (var_21: (int64 ref)), (var_22: Env14), (var_23: EnvStack17), (var_24: EnvStack17), (var_25: EnvStack16), (var_26: (int64 ref)), (var_27: Env14), (var_80: int64))
    else
        let (var_83: float) = (float var_16)
        let (var_84: float) = (var_17 / var_83)
        Tuple18(var_84, var_14, var_15)
and method_136 ((var_0: Env6)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env8) = var_0.mem_1
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
and method_106 ((var_0: Env4)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env14) = var_0.mem_1
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
and method_4 ((var_1: (uint64 ref))) ((var_0: Env2)): int32 =
    let (var_2: Env14) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: (uint64 ref)) = var_2.mem_0
    let (var_5: uint64) = method_5((var_1: (uint64 ref)))
    let (var_6: uint64) = method_5((var_4: (uint64 ref)))
    let (var_7: bool) = (var_5 < var_6)
    if var_7 then
        -1
    else
        let (var_8: bool) = (var_5 = var_6)
        if var_8 then
            0
        else
            1
and method_19((var_0: EnvHeap19), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env8), (var_13: int64)): Env4 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: EnvStack1) = var_0.mem_2
    let (var_17: EnvStack3) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env14) = method_20((var_16: EnvStack1), (var_14: (uint64 ref)), (var_15: uint64), (var_17: EnvStack3), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_23((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: EnvStack5))
    (Env4(var_24, (Env14(var_23))))
and method_45((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: Env4), (var_13: int64), (var_14: EnvStack15), (var_15: EnvStack15), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env14)): EnvStack20 =
    let (var_19: EnvStack21) = method_46((var_12: Env4), (var_13: int64), (var_17: (int64 ref)), (var_18: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_20: (int64 ref)) = var_19.mem_0
    let (var_21: Env14) = var_19.mem_1
    let (var_22: EnvStack21) = method_49((var_20: (int64 ref)), (var_21: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    method_51((var_15: EnvStack15), (var_20: (int64 ref)), (var_21: Env14), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env8))
    let (var_23: EnvStack21) = method_55((var_20: (int64 ref)), (var_21: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env14) = var_23.mem_1
    let (var_26: EnvStack21) = method_49((var_24: (int64 ref)), (var_25: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_27: (unit -> unit)) = method_60((var_22: EnvStack21), (var_20: (int64 ref)), (var_21: Env14), (var_14: EnvStack15), (var_15: EnvStack15), (var_12: Env4), (var_13: int64), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_26: EnvStack21), (var_24: (int64 ref)), (var_25: Env14))
    EnvStack20((var_26: EnvStack21), (var_24: (int64 ref)), (var_25: Env14), (var_27: (unit -> unit)))
and method_72((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: EnvStack21), (var_13: (int64 ref)), (var_14: Env14), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack16), (var_18: (int64 ref)), (var_19: Env14)): EnvStack22 =
    let (var_20: EnvStack16) = method_73((var_13: (int64 ref)), (var_14: Env14), (var_18: (int64 ref)), (var_19: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_21: (int64 ref)) = var_20.mem_0
    let (var_22: Env14) = var_20.mem_1
    let (var_23: EnvStack16) = method_37((var_21: (int64 ref)), (var_22: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    method_75((var_16: EnvStack17), (var_21: (int64 ref)), (var_22: Env14), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env8))
    let (var_24: (unit -> unit)) = method_79((var_23: EnvStack16), (var_21: (int64 ref)), (var_22: Env14), (var_15: EnvStack17), (var_16: EnvStack17), (var_12: EnvStack21), (var_13: (int64 ref)), (var_14: Env14), (var_17: EnvStack16), (var_18: (int64 ref)), (var_19: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    EnvStack22((var_23: EnvStack16), (var_21: (int64 ref)), (var_22: Env14), (var_24: (unit -> unit)))
and method_86((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: EnvStack16), (var_13: (int64 ref)), (var_14: Env14), (var_15: Env4), (var_16: int64)): EnvStack23 =
    let (var_17: EnvStack16) = method_87((var_13: (int64 ref)), (var_14: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env14) = var_17.mem_1
    let (var_20: Env30) = method_93((var_18: (int64 ref)), (var_19: Env14), (var_15: Env4), (var_16: int64), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env8))
    let (var_21: Env24) = var_20.mem_0
    let (var_22: (unit -> unit)) = method_98((var_12: EnvStack16), (var_15: Env4), (var_16: int64), (var_18: (int64 ref)), (var_19: Env14), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    EnvStack23((var_21: Env24), (var_22: (unit -> unit)))
and method_104((var_0: int64), (var_1: Env12), (var_2: int64)): (float32 []) =
    let (var_3: Env4) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env14) = var_3.mem_1
    let (var_6: (uint64 ref)) = var_5.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_0))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_0 * 4L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_107((var_0: EnvStack15), (var_1: EnvStack15), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env14) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env14) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_108((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
and method_110((var_0: (int64 ref)), (var_1: Env14), (var_2: EnvStack13), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env8)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env14) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_111((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env8))
and method_114((var_0: EnvStack17), (var_1: EnvStack17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env14) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env14) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_115((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
and method_117((var_0: (int64 ref)), (var_1: Env14), (var_2: EnvStack16), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env8)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env14) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_118((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env8))
and method_121((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: EnvStack16), (var_13: (int64 ref)), (var_14: Env14), (var_15: Env4), (var_16: int64)): EnvStack26 =
    let (var_17: EnvStack31) = method_122((var_13: (int64 ref)), (var_14: Env14), (var_15: Env4), (var_16: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env14) = var_17.mem_1
    let (var_20: Env32) = method_129((var_18: (int64 ref)), (var_19: Env14), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env8))
    let (var_21: Env27) = var_20.mem_0
    EnvStack26((var_21: Env27))
and method_134((var_0: int64), (var_1: Env29), (var_2: int64)): (int64 []) =
    let (var_3: Env4) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env14) = var_3.mem_1
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
and method_20((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3), (var_4: uint64)): Env14 =
    let (var_5: ResizeArray<Env0>) = var_0.mem_0
    let (var_6: int32) = var_5.get_Count()
    let (var_7: bool) = (var_6 > 0)
    let (var_8: bool) = (var_7 = false)
    if var_8 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_9: Env0) = var_5.[0]
    let (var_10: uint64) = var_9.mem_0
    let (var_11: uint64) = var_9.mem_1
    let (var_12: bool) = (var_4 <= var_11)
    let (var_39: Env2) =
        if var_12 then
            let (var_13: uint64) = (var_10 + var_4)
            let (var_14: uint64) = (var_11 - var_4)
            var_5.[0] <- (Env0(var_13, var_14))
            let (var_15: (uint64 ref)) = (ref var_10)
            (Env2((Env14(var_15)), var_4))
        else
            let (var_17: (Env0 -> (Env0 -> int32))) = method_21
            let (var_18: System.Comparison<Env0>) = System.Comparison<Env0>(var_17)
            var_5.Sort(var_18)
            let (var_19: Env0) = var_5.[0]
            let (var_20: uint64) = var_19.mem_0
            let (var_21: uint64) = var_19.mem_1
            let (var_22: bool) = (var_4 <= var_21)
            if var_22 then
                let (var_23: uint64) = (var_20 + var_4)
                let (var_24: uint64) = (var_21 - var_4)
                var_5.[0] <- (Env0(var_23, var_24))
                let (var_25: (uint64 ref)) = (ref var_20)
                (Env2((Env14(var_25)), var_4))
            else
                method_1((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3))
                let (var_27: (Env0 -> (Env0 -> int32))) = method_21
                let (var_28: System.Comparison<Env0>) = System.Comparison<Env0>(var_27)
                var_5.Sort(var_28)
                let (var_29: Env0) = var_5.[0]
                let (var_30: uint64) = var_29.mem_0
                let (var_31: uint64) = var_29.mem_1
                let (var_32: bool) = (var_4 <= var_31)
                if var_32 then
                    let (var_33: uint64) = (var_30 + var_4)
                    let (var_34: uint64) = (var_31 - var_4)
                    var_5.[0] <- (Env0(var_33, var_34))
                    let (var_35: (uint64 ref)) = (ref var_30)
                    (Env2((Env14(var_35)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_40: Env14) = var_39.mem_0
    let (var_41: uint64) = var_39.mem_1
    let (var_42: ResizeArray<Env2>) = var_3.mem_0
    var_42.Add((Env2(var_40, var_41)))
    var_40
and method_23((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack5)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env4>) = var_2.mem_0
    var_5.Add((Env4(var_0, (Env14(var_1)))))
and method_46((var_0: Env4), (var_1: int64), (var_2: (int64 ref)), (var_3: Env14), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8)): EnvStack21 =
    let (var_16: Env4) = method_47((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env14) = var_16.mem_1
    method_48((var_0: Env4), (var_1: int64), (var_2: (int64 ref)), (var_3: Env14), (var_17: (int64 ref)), (var_18: Env14), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_14: (int64 ref)), (var_15: Env8))
    EnvStack21((var_17: (int64 ref)), (var_18: Env14))
and method_49((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): EnvStack21 =
    let (var_14: Env4) = method_47((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env14) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_50((var_15: (int64 ref)), (var_16: Env14), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack21((var_15: (int64 ref)), (var_16: Env14))
and method_51((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env14), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env8)): unit =
    let (var_15: (int64 ref)) = var_0.mem_0
    let (var_16: Env14) = var_0.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: uint64) = method_5((var_19: (uint64 ref)))
    method_52((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_21: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env8))
and method_55((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): EnvStack21 =
    let (var_18: Env4) = method_47((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: Env14) = var_18.mem_1
    method_56((var_0: (int64 ref)), (var_1: Env14), (var_19: (int64 ref)), (var_20: Env14), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
    EnvStack21((var_19: (int64 ref)), (var_20: Env14))
and method_60 ((var_0: EnvStack21), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack15), (var_4: EnvStack15), (var_5: Env4), (var_6: int64), (var_7: EnvStack13), (var_8: (int64 ref)), (var_9: Env14), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8), (var_22: EnvStack21), (var_23: (int64 ref)), (var_24: Env14)) (): unit =
    method_61((var_1: (int64 ref)), (var_2: Env14), (var_22: EnvStack21), (var_23: (int64 ref)), (var_24: Env14), (var_0: EnvStack21), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_20: (int64 ref)), (var_21: Env8))
    method_64((var_0: EnvStack21), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack15), (var_4: EnvStack15), (var_5: Env4), (var_6: int64), (var_7: EnvStack13), (var_8: (int64 ref)), (var_9: Env14), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8))
and method_73((var_0: (int64 ref)), (var_1: Env14), (var_2: (int64 ref)), (var_3: Env14), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8)): EnvStack16 =
    let (var_16: Env4) = method_35((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env14) = var_16.mem_1
    method_74((var_0: (int64 ref)), (var_1: Env14), (var_2: (int64 ref)), (var_3: Env14), (var_17: (int64 ref)), (var_18: Env14), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_14: (int64 ref)), (var_15: Env8))
    EnvStack16((var_17: (int64 ref)), (var_18: Env14))
and method_75((var_0: EnvStack17), (var_1: (int64 ref)), (var_2: Env14), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env8)): unit =
    let (var_15: (int64 ref)) = var_0.mem_0
    let (var_16: Env14) = var_0.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: uint64) = method_5((var_19: (uint64 ref)))
    method_76((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_21: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env8))
and method_79 ((var_0: EnvStack16), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: EnvStack21), (var_6: (int64 ref)), (var_7: Env14), (var_8: EnvStack16), (var_9: (int64 ref)), (var_10: Env14), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env8)) (): unit =
    method_80((var_0: EnvStack16), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: EnvStack21), (var_6: (int64 ref)), (var_7: Env14), (var_8: EnvStack16), (var_9: (int64 ref)), (var_10: Env14), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env8))
and method_87((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8)): EnvStack16 =
    let (var_17: Env4) = method_35((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env14) = var_17.mem_1
    method_88((var_0: (int64 ref)), (var_1: Env14), (var_18: (int64 ref)), (var_19: Env14), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env8))
    EnvStack16((var_18: (int64 ref)), (var_19: Env14))
and method_93((var_0: (int64 ref)), (var_1: Env14), (var_2: Env4), (var_3: int64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env8)): Env30 =
    let (var_16: (uint64 ref)) = var_1.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: (int64 ref)) = var_2.mem_0
    let (var_19: Env14) = var_2.mem_1
    let (var_20: (uint64 ref)) = var_19.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: int64) = (var_3 * 4L)
    let (var_23: uint64) = (uint64 var_22)
    let (var_24: uint64) = (var_21 + var_23)
    let (var_29: Env4) = method_94((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
    let (var_30: (int64 ref)) = var_29.mem_0
    let (var_31: Env14) = var_29.mem_1
    let (var_32: (uint64 ref)) = var_31.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    method_95((var_11: ManagedCuda.CudaContext), (var_17: uint64), (var_24: uint64), (var_33: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
    (Env30((Env24((Env25((Env12((Env4(var_30, var_31)))), 0L))))))
and method_98 ((var_0: EnvStack16), (var_1: Env4), (var_2: int64), (var_3: (int64 ref)), (var_4: Env14), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env8)) (): unit =
    method_99((var_0: EnvStack16), (var_1: Env4), (var_2: int64), (var_3: (int64 ref)), (var_4: Env14), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env8))
and method_108((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_109((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_109", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_111((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_112((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_112", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_115((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_116((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_116", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_118((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_119((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_119", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_122((var_0: (int64 ref)), (var_1: Env14), (var_2: Env4), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8)): EnvStack31 =
    let (var_16: Env4) = method_123((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env14) = var_16.mem_1
    method_124((var_0: (int64 ref)), (var_1: Env14), (var_2: Env4), (var_3: int64), (var_17: (int64 ref)), (var_18: Env14), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_14: (int64 ref)), (var_15: Env8))
    EnvStack31((var_17: (int64 ref)), (var_18: Env14))
and method_129((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env8)): Env32 =
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: Env4) = method_130((var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env14) = var_16.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_131((var_9: ManagedCuda.CudaContext), (var_15: uint64), (var_20: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
    (Env32((Env27((Env28((Env29((Env4(var_17, var_18)))), 0L))))))
and method_21 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_22((var_2: uint64))
and method_47((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 65536L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_48((var_0: Env4), (var_1: int64), (var_2: (int64 ref)), (var_3: Env14), (var_4: (int64 ref)), (var_5: Env14), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env8)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: (bool ref)) = var_8.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_8.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    var_6.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: (uint64 ref)) = var_3.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (int64 ref)) = var_0.mem_0
    let (var_21: Env14) = var_0.mem_1
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_1 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (float32 ref)) = (ref 0.000000f)
    let (var_30: (uint64 ref)) = var_5.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_31)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_13, var_14, 128, 128, 784, var_15, var_19, 128, var_28, 784, var_29, var_33, 128)
    if var_34 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_34)
and method_50((var_0: (int64 ref)), (var_1: Env14), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_52((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env8)): unit =
    // Cuda join point
    // method_53((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_53", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_56((var_0: (int64 ref)), (var_1: Env14), (var_2: (int64 ref)), (var_3: Env14), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env8)): unit =
    let (var_16: (uint64 ref)) = var_1.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: (uint64 ref)) = var_3.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    method_57((var_11: ManagedCuda.CudaContext), (var_17: uint64), (var_19: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
and method_61((var_0: (int64 ref)), (var_1: Env14), (var_2: EnvStack21), (var_3: (int64 ref)), (var_4: Env14), (var_5: EnvStack21), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: EnvStack1), (var_12: EnvStack3), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack5), (var_15: EnvStack7), (var_16: (int64 ref)), (var_17: Env8)): unit =
    let (var_18: (int64 ref)) = var_2.mem_0
    let (var_19: Env14) = var_2.mem_1
    let (var_20: (int64 ref)) = var_5.mem_0
    let (var_21: Env14) = var_5.mem_1
    let (var_22: (uint64 ref)) = var_1.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: (uint64 ref)) = var_19.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: (uint64 ref)) = var_4.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: (uint64 ref)) = var_21.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    method_62((var_13: ManagedCuda.CudaContext), (var_23: uint64), (var_25: uint64), (var_27: uint64), (var_29: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env8))
and method_64((var_0: EnvStack21), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack15), (var_4: EnvStack15), (var_5: Env4), (var_6: int64), (var_7: EnvStack13), (var_8: (int64 ref)), (var_9: Env14), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env8)): unit =
    method_65((var_5: Env4), (var_6: int64), (var_0: EnvStack21), (var_7: EnvStack13), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_20: (int64 ref)), (var_21: Env8))
    let (var_22: (int64 ref)) = var_3.mem_0
    let (var_23: Env14) = var_3.mem_1
    method_66((var_0: EnvStack21), (var_3: EnvStack15), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_20: (int64 ref)), (var_21: Env8))
and method_74((var_0: (int64 ref)), (var_1: Env14), (var_2: (int64 ref)), (var_3: Env14), (var_4: (int64 ref)), (var_5: Env14), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env8)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: (bool ref)) = var_8.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_8.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    var_6.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: (uint64 ref)) = var_3.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (uint64 ref)) = var_1.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: (float32 ref)) = (ref 0.000000f)
    let (var_25: (uint64 ref)) = var_5.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_13, var_14, 10, 128, 128, var_15, var_19, 10, var_23, 128, var_24, var_28, 10)
    if var_29 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_29)
and method_76((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env8)): unit =
    // Cuda join point
    // method_77((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_77", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_80((var_0: EnvStack16), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: EnvStack21), (var_6: (int64 ref)), (var_7: Env14), (var_8: EnvStack16), (var_9: (int64 ref)), (var_10: Env14), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env8)): unit =
    method_81((var_0: EnvStack16), (var_9: (int64 ref)), (var_10: Env14), (var_5: EnvStack21), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_21: (int64 ref)), (var_22: Env8))
    method_82((var_6: (int64 ref)), (var_7: Env14), (var_0: EnvStack16), (var_8: EnvStack16), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_21: (int64 ref)), (var_22: Env8))
    let (var_23: (int64 ref)) = var_3.mem_0
    let (var_24: Env14) = var_3.mem_1
    method_83((var_0: EnvStack16), (var_3: EnvStack17), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_21: (int64 ref)), (var_22: Env8))
and method_88((var_0: (int64 ref)), (var_1: Env14), (var_2: (int64 ref)), (var_3: Env14), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env8)): unit =
    let (var_16: (uint64 ref)) = var_1.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: (uint64 ref)) = var_3.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    method_89((var_11: ManagedCuda.CudaContext), (var_17: uint64), (var_19: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env8))
and method_94((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 4L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_95((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env8)): unit =
    // Cuda join point
    // method_96((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_96", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_99((var_0: EnvStack16), (var_1: Env4), (var_2: int64), (var_3: (int64 ref)), (var_4: Env14), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env8)): unit =
    method_100((var_3: (int64 ref)), (var_4: Env14), (var_1: Env4), (var_2: int64), (var_0: EnvStack16), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_15: (int64 ref)), (var_16: Env8))
and method_123((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 1024L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_124((var_0: (int64 ref)), (var_1: Env14), (var_2: Env4), (var_3: int64), (var_4: (int64 ref)), (var_5: Env14), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: EnvStack1), (var_12: EnvStack3), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack5), (var_15: EnvStack7), (var_16: (int64 ref)), (var_17: Env8)): unit =
    let (var_18: (uint64 ref)) = var_1.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (int64 ref)) = var_2.mem_0
    let (var_21: Env14) = var_2.mem_1
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_3 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: (uint64 ref)) = var_5.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_125((var_13: ManagedCuda.CudaContext), (var_19: uint64), (var_26: uint64), (var_28: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env8))
and method_130((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8)): Env4 =
    let (var_12: int64) = 8L
    let (var_13: EnvHeap19) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap19)
    method_19((var_13: EnvHeap19), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env8), (var_12: int64))
and method_131((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_132((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_132", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_22 ((var_1: uint64)) ((var_0: Env0)): int32 =
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
and method_57((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_58((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_58", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_62((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env8)): unit =
    // Cuda join point
    // method_63((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_63", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
and method_65((var_0: Env4), (var_1: int64), (var_2: EnvStack21), (var_3: EnvStack13), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env8)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env14) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env14) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: (bool ref)) = var_6.mem_0
    let (var_13: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: (bool ref)), (var_13: ManagedCuda.CudaStream))
    var_4.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_8.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (int64 ref)) = var_0.mem_0
    let (var_23: Env14) = var_0.mem_1
    let (var_24: (uint64 ref)) = var_23.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: int64) = (var_1 * 4L)
    let (var_27: uint64) = (uint64 var_26)
    let (var_28: uint64) = (var_25 + var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: (float32 ref)) = (ref 1.000000f)
    let (var_32: (uint64 ref)) = var_10.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_33)
    let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_34)
    let (var_36: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_15, var_16, 128, 784, 128, var_17, var_21, 128, var_30, 784, var_31, var_35, 128)
    if var_36 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_36)
and method_66((var_0: EnvStack21), (var_1: EnvStack15), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env14) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env14) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_67((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
and method_81((var_0: EnvStack16), (var_1: (int64 ref)), (var_2: Env14), (var_3: EnvStack21), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env8)): unit =
    let (var_7: (int64 ref)) = var_0.mem_0
    let (var_8: Env14) = var_0.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env14) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: (bool ref)) = var_6.mem_0
    let (var_13: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: (bool ref)), (var_13: ManagedCuda.CudaStream))
    var_4.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_2.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (uint64 ref)) = var_8.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: (float32 ref)) = (ref 1.000000f)
    let (var_27: (uint64 ref)) = var_10.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_15, var_16, 128, 128, 10, var_17, var_21, 10, var_25, 10, var_26, var_30, 128)
    if var_31 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_31)
and method_82((var_0: (int64 ref)), (var_1: Env14), (var_2: EnvStack16), (var_3: EnvStack16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env8)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env14) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env14) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: (bool ref)) = var_6.mem_0
    let (var_13: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: (bool ref)), (var_13: ManagedCuda.CudaStream))
    var_4.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_8.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (uint64 ref)) = var_1.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: (float32 ref)) = (ref 1.000000f)
    let (var_27: (uint64 ref)) = var_10.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_15, var_16, 10, 128, 128, var_17, var_21, 10, var_25, 128, var_26, var_30, 10)
    if var_31 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_31)
and method_83((var_0: EnvStack16), (var_1: EnvStack17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env8)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env14) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env14) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_84((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env8))
and method_89((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_90((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_90", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_100((var_0: (int64 ref)), (var_1: Env14), (var_2: Env4), (var_3: int64), (var_4: EnvStack16), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_15: (int64 ref)), (var_16: Env8)): unit =
    let (var_17: (int64 ref)) = var_4.mem_0
    let (var_18: Env14) = var_4.mem_1
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (int64 ref)) = var_2.mem_0
    let (var_22: Env14) = var_2.mem_1
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: int64) = (var_3 * 4L)
    let (var_26: uint64) = (uint64 var_25)
    let (var_27: uint64) = (var_24 + var_26)
    let (var_28: (uint64 ref)) = var_18.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    method_101((var_12: ManagedCuda.CudaContext), (var_20: uint64), (var_27: uint64), (var_29: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env8))
and method_125((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env8)): unit =
    // Cuda join point
    // method_126((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_126", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_67((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_68((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_68", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_84((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env8)): unit =
    // Cuda join point
    // method_85((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_85", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_101((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env8)): unit =
    // Cuda join point
    // method_102((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_102", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
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
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvarsall.bat")
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
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\" x64 -vcvars_ver=14.11"|]
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
let (var_35: uint64) = 1073741824UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: ResizeArray<Env0>) = ResizeArray<Env0>()
let (var_41: EnvStack1) = EnvStack1((var_40: ResizeArray<Env0>))
let (var_42: ResizeArray<Env2>) = ResizeArray<Env2>()
let (var_43: EnvStack3) = EnvStack3((var_42: ResizeArray<Env2>))
method_1((var_41: EnvStack1), (var_39: (uint64 ref)), (var_35: uint64), (var_43: EnvStack3))
let (var_44: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_45: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_44)
let (var_46: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_47: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_48: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_46, var_47)
let (var_57: ResizeArray<Env4>) = ResizeArray<Env4>()
let (var_58: EnvStack5) = EnvStack5((var_57: ResizeArray<Env4>))
let (var_67: ResizeArray<Env6>) = ResizeArray<Env6>()
let (var_68: EnvStack7) = EnvStack7((var_67: ResizeArray<Env6>))
let (var_69: (bool ref)) = (ref true)
let (var_70: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_71: Env6) = method_7((var_69: (bool ref)), (var_70: ManagedCuda.CudaStream), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_72: (int64 ref)) = var_71.mem_0
let (var_73: Env8) = var_71.mem_1
let (var_74: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_75: Tuple9) = method_9((var_74: string))
let (var_76: Tuple10) = var_75.mem_0
let (var_77: (uint8 [])) = var_75.mem_1
let (var_78: int64) = var_76.mem_0
let (var_79: int64) = var_76.mem_1
let (var_80: int64) = var_76.mem_2
let (var_81: bool) = (10000L = var_78)
let (var_85: bool) =
    if var_81 then
        let (var_82: bool) = (28L = var_79)
        if var_82 then
            (28L = var_80)
        else
            false
    else
        false
let (var_86: bool) = (var_85 = false)
if var_86 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_87: int64) = var_77.LongLength
let (var_88: bool) = (var_87 > 0L)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_90: bool) = (var_87 = 7840000L)
let (var_91: bool) = (var_90 = false)
if var_91 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_95: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_96: int64) = 0L
method_10((var_77: (uint8 [])), (var_95: (float32 [])), (var_96: int64))
let (var_97: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_98: Tuple11) = method_12((var_97: string))
let (var_99: int64) = var_98.mem_0
let (var_100: (uint8 [])) = var_98.mem_1
let (var_101: bool) = (10000L = var_99)
let (var_102: bool) = (var_101 = false)
if var_102 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_106: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_107: int64) = 0L
method_13((var_100: (uint8 [])), (var_106: (float32 [])), (var_107: int64))
let (var_108: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_109: Tuple9) = method_9((var_108: string))
let (var_110: Tuple10) = var_109.mem_0
let (var_111: (uint8 [])) = var_109.mem_1
let (var_112: int64) = var_110.mem_0
let (var_113: int64) = var_110.mem_1
let (var_114: int64) = var_110.mem_2
let (var_115: bool) = (60000L = var_112)
let (var_119: bool) =
    if var_115 then
        let (var_116: bool) = (28L = var_113)
        if var_116 then
            (28L = var_114)
        else
            false
    else
        false
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_121: int64) = var_111.LongLength
let (var_122: bool) = (var_121 > 0L)
let (var_123: bool) = (var_122 = false)
if var_123 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_124: bool) = (var_121 = 47040000L)
let (var_125: bool) = (var_124 = false)
if var_125 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_129: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_130: int64) = 0L
method_15((var_111: (uint8 [])), (var_129: (float32 [])), (var_130: int64))
let (var_131: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_132: Tuple11) = method_12((var_131: string))
let (var_133: int64) = var_132.mem_0
let (var_134: (uint8 [])) = var_132.mem_1
let (var_135: bool) = (60000L = var_133)
let (var_136: bool) = (var_135 = false)
if var_136 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_140: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_141: int64) = 0L
method_16((var_134: (uint8 [])), (var_140: (float32 [])), (var_141: int64))
let (var_142: int64) = 10000L
let (var_143: int64) = 0L
let (var_144: int64) = 784L
let (var_145: int64) = 1L
let (var_146: Env12) = method_17((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8), (var_142: int64), (var_95: (float32 [])), (var_143: int64), (var_144: int64), (var_145: int64))
let (var_147: Env4) = var_146.mem_0
let (var_148: int64) = 10000L
let (var_149: int64) = 0L
let (var_150: int64) = 10L
let (var_151: int64) = 1L
let (var_152: Env12) = method_17((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8), (var_148: int64), (var_106: (float32 [])), (var_149: int64), (var_150: int64), (var_151: int64))
let (var_153: Env4) = var_152.mem_0
let (var_154: int64) = 60000L
let (var_155: int64) = 0L
let (var_156: int64) = 784L
let (var_157: int64) = 1L
let (var_158: Env12) = method_17((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8), (var_154: int64), (var_129: (float32 [])), (var_155: int64), (var_156: int64), (var_157: int64))
let (var_159: Env4) = var_158.mem_0
let (var_160: int64) = 60000L
let (var_161: int64) = 0L
let (var_162: int64) = 10L
let (var_163: int64) = 1L
let (var_164: Env12) = method_17((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8), (var_160: int64), (var_140: (float32 [])), (var_161: int64), (var_162: int64), (var_163: int64))
let (var_165: Env4) = var_164.mem_0
let (var_166: EnvStack13) = method_24((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_167: (int64 ref)) = var_166.mem_0
let (var_168: Env14) = var_166.mem_1
let (var_169: EnvStack13) = method_28((var_167: (int64 ref)), (var_168: Env14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_170: EnvStack15) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_171: EnvStack15) = method_33((var_170: EnvStack15), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_172: EnvStack16) = method_34((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_173: (int64 ref)) = var_172.mem_0
let (var_174: Env14) = var_172.mem_1
let (var_175: EnvStack16) = method_37((var_173: (int64 ref)), (var_174: Env14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_176: EnvStack17) = method_39((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_177: EnvStack17) = method_42((var_176: EnvStack17), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8))
let (var_178: int64) = 0L
method_43((var_171: EnvStack15), (var_170: EnvStack15), (var_169: EnvStack13), (var_167: (int64 ref)), (var_168: Env14), (var_177: EnvStack17), (var_176: EnvStack17), (var_175: EnvStack16), (var_173: (int64 ref)), (var_174: Env14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_68: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: (int64 ref)), (var_73: Env8), (var_147: Env4), (var_153: Env4), (var_159: Env4), (var_165: Env4), (var_178: int64))
method_135((var_68: EnvStack7))
method_105((var_58: EnvStack5))
var_48.Dispose()
var_45.Dispose()
let (var_179: uint64) = method_5((var_39: (uint64 ref)))
let (var_180: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_179)
let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_180)
var_1.FreeMemory(var_181)
var_39 := 0UL
var_1.Dispose()

