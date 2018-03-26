module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple0 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple0 make_Tuple0(float mem_0, float mem_1){
        Tuple0 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple1 {
        float mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, float mem_1, float mem_2){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    struct Tuple3 {
        Tuple0 mem_0;
        Tuple0 mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(Tuple0 mem_0, Tuple0 mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple0(*FunPointer2)(Tuple0, Tuple0);
    __global__ void method_135(float * var_0, float * var_1);
    __global__ void method_138(float * var_0, float * var_1);
    __global__ void method_142(float * var_0, float * var_1);
    __global__ void method_146(float * var_0, float * var_1);
    __global__ void method_149(float * var_0, float * var_1);
    __global__ void method_152(float * var_0, float * var_1);
    __global__ void method_62(float * var_0, float * var_1, float * var_2);
    __global__ void method_103(float * var_0, float * var_1, float * var_2);
    __global__ void method_123(float * var_0, float * var_1, float * var_2);
    __global__ void method_166(long long int * var_0, long long int * var_1);
    __global__ void method_68(float * var_0, float * var_1, float * var_2);
    __global__ void method_75(float * var_0, float * var_1);
    __global__ void method_80(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_92(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_108(float * var_0, float * var_1);
    __global__ void method_113(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_160(float * var_0, float * var_1, long long int * var_2);
    __global__ void method_86(float * var_0, float * var_1);
    __global__ void method_119(float * var_0, float * var_1);
    __global__ void method_129(float * var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_63(long long int * var_0);
    __device__ char method_139(long long int * var_0);
    __device__ char method_143(long long int * var_0);
    __device__ char method_69(long long int * var_0);
    __device__ char method_104(long long int * var_0);
    __device__ char method_153(long long int * var_0);
    __device__ char method_64(long long int * var_0);
    __device__ char method_124(long long int * var_0, float * var_1);
    __device__ char method_167(long long int * var_0, long long int * var_1);
    __device__ char method_76(long long int * var_0);
    __device__ char method_109(long long int * var_0);
    __device__ char method_161(long long int * var_0, float * var_1, float * var_2);
    __device__ Tuple0 method_162(Tuple0 var_0, Tuple0 var_1);
    __device__ char method_87(long long int * var_0, float * var_1);
    __device__ char method_88(long long int * var_0, float * var_1);
    __device__ char method_89(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_135(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_63(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 64);
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
                var_14 = (var_8 < 64);
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
    __global__ void method_138(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_139(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 50176);
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
                var_14 = (var_8 < 50176);
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
    __global__ void method_142(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_143(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 4096);
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
                var_14 = (var_8 < 4096);
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
            long long int var_19 = (var_8 + 4096);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_146(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_69(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 1);
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
                var_14 = (var_8 < 1);
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
    __global__ void method_149(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_104(var_6)) {
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
    __global__ void method_152(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_153(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 640);
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
                var_14 = (var_8 < 640);
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
            long long int var_19 = (var_8 + 640);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_62(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_63(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 64);
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
            while (method_64(var_18)) {
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
                long long int var_25 = (var_20 * 64);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 64);
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
                    var_35 = (var_9 < 64);
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
            long long int var_42 = (var_9 + 64);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_103(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_104(var_7)) {
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
            while (method_64(var_18)) {
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
    __global__ void method_123(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_124(var_8, var_9)) {
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
            float var_19 = log(var_17);
            float var_20 = (var_18 * var_19);
            float var_21 = (1 - var_18);
            float var_22 = (1 - var_17);
            float var_23 = log(var_22);
            float var_24 = (var_21 * var_23);
            float var_25 = (var_20 + var_24);
            float var_26 = (-var_25);
            float var_27 = (var_12 + var_26);
            long long int var_28 = (var_11 + 1024);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        float var_32 = (var_31 / 128);
        long long int var_33 = threadIdx.x;
        char var_34 = (var_33 == 0);
        if (var_34) {
            long long int var_35 = blockIdx.x;
            char var_36 = (var_35 >= 0);
            char var_38;
            if (var_36) {
                var_38 = (var_35 < 1);
            } else {
                var_38 = 0;
            }
            char var_39 = (var_38 == 0);
            if (var_39) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_35] = var_32;
        } else {
        }
    }
    __global__ void method_166(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_167(var_7, var_8)) {
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
    __global__ void method_68(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_64(var_6)) {
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
            long long int var_13 = (var_8 * 64);
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
            float var_17[1];
            long long int var_18 = threadIdx.x;
            long long int var_19 = blockIdx.x;
            long long int var_20 = (64 * var_19);
            long long int var_21 = (var_18 + var_20);
            long long int var_22[1];
            var_22[0] = 0;
            while (method_69(var_22)) {
                long long int var_24 = var_22[0];
                long long int var_25 = (64 * var_24);
                long long int var_26 = (var_21 + var_25);
                long long int var_27 = (64 - var_25);
                char var_28 = (var_26 < 64);
                if (var_28) {
                    char var_29 = (var_24 >= 0);
                    char var_31;
                    if (var_29) {
                        var_31 = (var_24 < 1);
                    } else {
                        var_31 = 0;
                    }
                    char var_32 = (var_31 == 0);
                    if (var_32) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_33 = (var_26 >= 0);
                    char var_34 = (var_33 == 0);
                    if (var_34) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_35 = (var_13 + var_26);
                    float var_36 = var_0[var_35];
                    var_17[var_24] = var_36;
                } else {
                }
                long long int var_37 = (var_24 + 1);
                var_22[0] = var_37;
            }
            long long int var_38 = var_22[0];
            float var_39 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_17);
            __shared__ float var_40[1];
            long long int var_41 = threadIdx.x;
            char var_42 = (var_41 == 0);
            if (var_42) {
                var_40[0] = var_39;
            } else {
            }
            __syncthreads();
            float var_43 = var_40[0];
            float var_46[1];
            long long int var_47[1];
            var_47[0] = 0;
            while (method_69(var_47)) {
                long long int var_49 = var_47[0];
                long long int var_50 = (64 * var_49);
                long long int var_51 = (var_21 + var_50);
                long long int var_52 = (64 - var_50);
                char var_53 = (var_51 < 64);
                if (var_53) {
                    char var_54 = (var_51 >= 0);
                    char var_55 = (var_54 == 0);
                    if (var_55) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_56 = (var_13 + var_51);
                    char var_57 = (var_49 >= 0);
                    char var_59;
                    if (var_57) {
                        var_59 = (var_49 < 1);
                    } else {
                        var_59 = 0;
                    }
                    char var_60 = (var_59 == 0);
                    if (var_60) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_61 = var_17[var_49];
                    float var_62 = (var_43 / 64);
                    float var_63 = (var_61 - var_62);
                    char var_65;
                    if (var_57) {
                        var_65 = (var_49 < 1);
                    } else {
                        var_65 = 0;
                    }
                    char var_66 = (var_65 == 0);
                    if (var_66) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_46[var_49] = var_63;
                } else {
                }
                long long int var_67 = (var_49 + 1);
                var_47[0] = var_67;
            }
            long long int var_68 = var_47[0];
            float var_70[1];
            long long int var_71[1];
            var_71[0] = 0;
            while (method_69(var_71)) {
                long long int var_73 = var_71[0];
                long long int var_74 = (64 * var_73);
                long long int var_75 = (var_21 + var_74);
                long long int var_76 = (64 - var_74);
                char var_77 = (var_75 < 64);
                if (var_77) {
                    char var_78 = (var_73 >= 0);
                    char var_80;
                    if (var_78) {
                        var_80 = (var_73 < 1);
                    } else {
                        var_80 = 0;
                    }
                    char var_81 = (var_80 == 0);
                    if (var_81) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_82 = var_46[var_73];
                    float var_83 = (var_82 * var_82);
                    char var_85;
                    if (var_78) {
                        var_85 = (var_73 < 1);
                    } else {
                        var_85 = 0;
                    }
                    char var_86 = (var_85 == 0);
                    if (var_86) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_70[var_73] = var_83;
                } else {
                }
                long long int var_87 = (var_73 + 1);
                var_71[0] = var_87;
            }
            long long int var_88 = var_71[0];
            float var_89 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_70);
            __shared__ float var_90[1];
            long long int var_91 = threadIdx.x;
            char var_92 = (var_91 == 0);
            if (var_92) {
                var_90[0] = var_89;
            } else {
            }
            __syncthreads();
            float var_93 = var_90[0];
            long long int var_94[1];
            var_94[0] = 0;
            while (method_69(var_94)) {
                long long int var_96 = var_94[0];
                long long int var_97 = (64 * var_96);
                long long int var_98 = (var_21 + var_97);
                long long int var_99 = (64 - var_97);
                char var_100 = (var_98 < 64);
                if (var_100) {
                    char var_101 = (var_98 >= 0);
                    char var_102 = (var_101 == 0);
                    if (var_102) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_103 = (var_13 + var_98);
                    char var_104 = (var_96 >= 0);
                    char var_106;
                    if (var_104) {
                        var_106 = (var_96 < 1);
                    } else {
                        var_106 = 0;
                    }
                    char var_107 = (var_106 == 0);
                    if (var_107) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_108 = var_46[var_96];
                    float var_109 = var_1[var_103];
                    float var_110 = var_2[0];
                    float var_111 = (var_110 * var_110);
                    float var_112 = (var_93 / 64);
                    float var_113 = (var_111 + var_112);
                    float var_114 = sqrt(var_113);
                    float var_115 = (var_108 / var_114);
                    var_1[var_103] = var_115;
                } else {
                }
                long long int var_116 = (var_96 + 1);
                var_94[0] = var_116;
            }
            long long int var_117 = var_94[0];
            long long int var_118 = (var_8 + 64);
            var_6[0] = var_118;
        }
        long long int var_119 = var_6[0];
    }
    __global__ void method_75(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_76(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 8192);
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
                var_14 = (var_8 < 8192);
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
    __global__ void method_80(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_76(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 8192);
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
                var_16 = (var_10 < 8192);
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
    __global__ void method_92(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.y;
        long long int var_6 = blockIdx.y;
        long long int var_7 = (var_5 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_64(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 128);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_15 = (var_10 * 64);
            char var_17;
            if (var_11) {
                var_17 = (var_10 < 128);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            Tuple0 var_19[1];
            long long int var_20 = threadIdx.x;
            long long int var_21 = blockIdx.x;
            long long int var_22 = (64 * var_21);
            long long int var_23 = (var_20 + var_22);
            long long int var_24[1];
            var_24[0] = 0;
            while (method_69(var_24)) {
                long long int var_26 = var_24[0];
                long long int var_27 = (64 * var_26);
                long long int var_28 = (var_23 + var_27);
                long long int var_29 = (64 - var_27);
                char var_30 = (var_28 < 64);
                if (var_30) {
                    char var_31 = (var_26 >= 0);
                    char var_33;
                    if (var_31) {
                        var_33 = (var_26 < 1);
                    } else {
                        var_33 = 0;
                    }
                    char var_34 = (var_33 == 0);
                    if (var_34) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_35 = (var_28 >= 0);
                    char var_36 = (var_35 == 0);
                    if (var_36) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_37 = (var_15 + var_28);
                    float var_38 = var_0[var_37];
                    float var_39 = var_1[var_37];
                    var_19[var_26] = make_Tuple0(var_38, var_39);
                } else {
                }
                long long int var_40 = (var_26 + 1);
                var_24[0] = var_40;
            }
            long long int var_41 = var_24[0];
            float var_42[1];
            long long int var_43[1];
            var_43[0] = 0;
            while (method_69(var_43)) {
                long long int var_45 = var_43[0];
                long long int var_46 = (64 * var_45);
                long long int var_47 = (var_23 + var_46);
                long long int var_48 = (64 - var_46);
                char var_49 = (var_47 < 64);
                if (var_49) {
                    char var_50 = (var_45 >= 0);
                    char var_52;
                    if (var_50) {
                        var_52 = (var_45 < 1);
                    } else {
                        var_52 = 0;
                    }
                    char var_53 = (var_52 == 0);
                    if (var_53) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_54 = var_19[var_45];
                    float var_55 = var_54.mem_0;
                    float var_56 = var_54.mem_1;
                    char var_58;
                    if (var_50) {
                        var_58 = (var_45 < 1);
                    } else {
                        var_58 = 0;
                    }
                    char var_59 = (var_58 == 0);
                    if (var_59) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_42[var_45] = var_56;
                } else {
                }
                long long int var_60 = (var_45 + 1);
                var_43[0] = var_60;
            }
            long long int var_61 = var_43[0];
            float var_62 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_42);
            __shared__ float var_63[1];
            long long int var_64 = threadIdx.x;
            char var_65 = (var_64 == 0);
            if (var_65) {
                var_63[0] = var_62;
            } else {
            }
            __syncthreads();
            float var_66 = var_63[0];
            Tuple0 var_69[1];
            long long int var_70[1];
            var_70[0] = 0;
            while (method_69(var_70)) {
                long long int var_72 = var_70[0];
                long long int var_73 = (64 * var_72);
                long long int var_74 = (var_23 + var_73);
                long long int var_75 = (64 - var_73);
                char var_76 = (var_74 < 64);
                if (var_76) {
                    char var_77 = (var_74 >= 0);
                    char var_78 = (var_77 == 0);
                    if (var_78) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_79 = (var_15 + var_74);
                    char var_80 = (var_72 >= 0);
                    char var_82;
                    if (var_80) {
                        var_82 = (var_72 < 1);
                    } else {
                        var_82 = 0;
                    }
                    char var_83 = (var_82 == 0);
                    if (var_83) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_84 = var_19[var_72];
                    float var_85 = var_84.mem_0;
                    float var_86 = var_84.mem_1;
                    float var_87 = (var_66 / 64);
                    float var_88 = (var_86 - var_87);
                    char var_90;
                    if (var_80) {
                        var_90 = (var_72 < 1);
                    } else {
                        var_90 = 0;
                    }
                    char var_91 = (var_90 == 0);
                    if (var_91) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_69[var_72] = make_Tuple0(var_85, var_88);
                } else {
                }
                long long int var_92 = (var_72 + 1);
                var_70[0] = var_92;
            }
            long long int var_93 = var_70[0];
            float var_95[1];
            long long int var_96[1];
            var_96[0] = 0;
            while (method_69(var_96)) {
                long long int var_98 = var_96[0];
                long long int var_99 = (64 * var_98);
                long long int var_100 = (var_23 + var_99);
                long long int var_101 = (64 - var_99);
                char var_102 = (var_100 < 64);
                if (var_102) {
                    char var_103 = (var_98 >= 0);
                    char var_105;
                    if (var_103) {
                        var_105 = (var_98 < 1);
                    } else {
                        var_105 = 0;
                    }
                    char var_106 = (var_105 == 0);
                    if (var_106) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_107 = var_69[var_98];
                    float var_108 = var_107.mem_0;
                    float var_109 = var_107.mem_1;
                    float var_110 = (var_109 * var_109);
                    char var_112;
                    if (var_103) {
                        var_112 = (var_98 < 1);
                    } else {
                        var_112 = 0;
                    }
                    char var_113 = (var_112 == 0);
                    if (var_113) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_95[var_98] = var_110;
                } else {
                }
                long long int var_114 = (var_98 + 1);
                var_96[0] = var_114;
            }
            long long int var_115 = var_96[0];
            float var_116 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_95);
            __shared__ float var_117[1];
            long long int var_118 = threadIdx.x;
            char var_119 = (var_118 == 0);
            if (var_119) {
                var_117[0] = var_116;
            } else {
            }
            __syncthreads();
            float var_120 = var_117[0];
            Tuple1 var_126[1];
            long long int var_127[1];
            var_127[0] = 0;
            while (method_69(var_127)) {
                long long int var_129 = var_127[0];
                long long int var_130 = (64 * var_129);
                long long int var_131 = (var_23 + var_130);
                long long int var_132 = (64 - var_130);
                char var_133 = (var_131 < 64);
                if (var_133) {
                    char var_134 = (var_131 >= 0);
                    char var_135 = (var_134 == 0);
                    if (var_135) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_136 = (var_15 + var_131);
                    char var_137 = (var_129 >= 0);
                    char var_139;
                    if (var_137) {
                        var_139 = (var_129 < 1);
                    } else {
                        var_139 = 0;
                    }
                    char var_140 = (var_139 == 0);
                    if (var_140) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_141 = var_69[var_129];
                    float var_142 = var_141.mem_0;
                    float var_143 = var_141.mem_1;
                    float var_144 = var_4[0];
                    float var_145 = (var_144 * var_144);
                    float var_146 = (var_120 / 64);
                    float var_147 = (var_145 + var_146);
                    float var_148 = sqrt(var_147);
                    char var_150;
                    if (var_137) {
                        var_150 = (var_129 < 1);
                    } else {
                        var_150 = 0;
                    }
                    char var_151 = (var_150 == 0);
                    if (var_151) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_126[var_129] = make_Tuple1(var_142, var_143, var_148);
                } else {
                }
                long long int var_152 = (var_129 + 1);
                var_127[0] = var_152;
            }
            long long int var_153 = var_127[0];
            float var_158[1];
            long long int var_159[1];
            var_159[0] = 0;
            while (method_69(var_159)) {
                long long int var_161 = var_159[0];
                long long int var_162 = (64 * var_161);
                long long int var_163 = (var_23 + var_162);
                long long int var_164 = (64 - var_162);
                char var_165 = (var_163 < 64);
                if (var_165) {
                    char var_166 = (var_161 >= 0);
                    char var_168;
                    if (var_166) {
                        var_168 = (var_161 < 1);
                    } else {
                        var_168 = 0;
                    }
                    char var_169 = (var_168 == 0);
                    if (var_169) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_170 = var_126[var_161];
                    float var_171 = var_170.mem_0;
                    float var_172 = var_170.mem_1;
                    float var_173 = var_170.mem_2;
                    float var_174 = (-var_171);
                    float var_175 = (var_174 * var_172);
                    float var_176 = (var_173 * var_173);
                    float var_177 = (var_175 / var_176);
                    char var_179;
                    if (var_166) {
                        var_179 = (var_161 < 1);
                    } else {
                        var_179 = 0;
                    }
                    char var_180 = (var_179 == 0);
                    if (var_180) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_158[var_161] = var_177;
                } else {
                }
                long long int var_181 = (var_161 + 1);
                var_159[0] = var_181;
            }
            long long int var_182 = var_159[0];
            float var_183 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_158);
            __shared__ float var_184[1];
            long long int var_185 = threadIdx.x;
            char var_186 = (var_185 == 0);
            if (var_186) {
                var_184[0] = var_183;
            } else {
            }
            __syncthreads();
            float var_187 = var_184[0];
            Tuple1 var_191[1];
            long long int var_192[1];
            var_192[0] = 0;
            while (method_69(var_192)) {
                long long int var_194 = var_192[0];
                long long int var_195 = (64 * var_194);
                long long int var_196 = (var_23 + var_195);
                long long int var_197 = (64 - var_195);
                char var_198 = (var_196 < 64);
                if (var_198) {
                    char var_199 = (var_196 >= 0);
                    char var_200 = (var_199 == 0);
                    if (var_200) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_201 = (var_15 + var_196);
                    char var_202 = (var_194 >= 0);
                    char var_204;
                    if (var_202) {
                        var_204 = (var_194 < 1);
                    } else {
                        var_204 = 0;
                    }
                    char var_205 = (var_204 == 0);
                    if (var_205) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_206 = var_126[var_194];
                    float var_207 = var_206.mem_0;
                    float var_208 = var_206.mem_1;
                    float var_209 = var_206.mem_2;
                    float var_210 = (var_207 / var_209);
                    float var_211 = (2 * var_209);
                    float var_212 = (var_187 / var_211);
                    char var_214;
                    if (var_202) {
                        var_214 = (var_194 < 1);
                    } else {
                        var_214 = 0;
                    }
                    char var_215 = (var_214 == 0);
                    if (var_215) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_191[var_194] = make_Tuple1(var_210, var_208, var_212);
                } else {
                }
                long long int var_216 = (var_194 + 1);
                var_192[0] = var_216;
            }
            long long int var_217 = var_192[0];
            float var_218[1];
            long long int var_219[1];
            var_219[0] = 0;
            while (method_69(var_219)) {
                long long int var_221 = var_219[0];
                long long int var_222 = (64 * var_221);
                long long int var_223 = (var_23 + var_222);
                long long int var_224 = (64 - var_222);
                char var_225 = (var_223 < 64);
                if (var_225) {
                    char var_226 = (var_221 >= 0);
                    char var_228;
                    if (var_226) {
                        var_228 = (var_221 < 1);
                    } else {
                        var_228 = 0;
                    }
                    char var_229 = (var_228 == 0);
                    if (var_229) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_230 = var_191[var_221];
                    float var_231 = var_230.mem_0;
                    float var_232 = var_230.mem_1;
                    float var_233 = var_230.mem_2;
                    char var_235;
                    if (var_226) {
                        var_235 = (var_221 < 1);
                    } else {
                        var_235 = 0;
                    }
                    char var_236 = (var_235 == 0);
                    if (var_236) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_218[var_221] = var_233;
                } else {
                }
                long long int var_237 = (var_221 + 1);
                var_219[0] = var_237;
            }
            long long int var_238 = var_219[0];
            float var_239 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_218);
            float var_249[1];
            long long int var_250[1];
            var_250[0] = 0;
            while (method_69(var_250)) {
                long long int var_252 = var_250[0];
                long long int var_253 = (64 * var_252);
                long long int var_254 = (var_23 + var_253);
                long long int var_255 = (64 - var_253);
                char var_256 = (var_254 < 64);
                if (var_256) {
                    char var_257 = (var_254 >= 0);
                    char var_258 = (var_257 == 0);
                    if (var_258) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_259 = (var_15 + var_254);
                    char var_260 = (var_252 >= 0);
                    char var_262;
                    if (var_260) {
                        var_262 = (var_252 < 1);
                    } else {
                        var_262 = 0;
                    }
                    char var_263 = (var_262 == 0);
                    if (var_263) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_264 = var_191[var_252];
                    float var_265 = var_264.mem_0;
                    float var_266 = var_264.mem_1;
                    float var_267 = var_264.mem_2;
                    long long int var_268 = threadIdx.x;
                    char var_269 = (var_268 == 0);
                    if (var_269) {
                        float var_270 = var_4[0];
                        float var_271 = (2 * var_270);
                        float var_272 = (var_271 * var_239);
                        float * var_273 = var_3 + 0;
                        atomicAdd(var_273, var_272);
                    } else {
                    }
                    float var_274 = (var_267 * 0.03125);
                    float var_275 = (var_274 * var_266);
                    float var_276 = (var_265 + var_275);
                    char var_278;
                    if (var_260) {
                        var_278 = (var_252 < 1);
                    } else {
                        var_278 = 0;
                    }
                    char var_279 = (var_278 == 0);
                    if (var_279) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_249[var_252] = var_276;
                } else {
                }
                long long int var_280 = (var_252 + 1);
                var_250[0] = var_280;
            }
            long long int var_281 = var_250[0];
            float var_282 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_249);
            __shared__ float var_283[1];
            long long int var_284 = threadIdx.x;
            char var_285 = (var_284 == 0);
            if (var_285) {
                var_283[0] = var_282;
            } else {
            }
            __syncthreads();
            float var_286 = var_283[0];
            long long int var_287[1];
            var_287[0] = 0;
            while (method_69(var_287)) {
                long long int var_289 = var_287[0];
                long long int var_290 = (64 * var_289);
                long long int var_291 = (var_23 + var_290);
                long long int var_292 = (64 - var_290);
                char var_293 = (var_291 < 64);
                if (var_293) {
                    char var_294 = (var_291 >= 0);
                    char var_295 = (var_294 == 0);
                    if (var_295) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_296 = (var_15 + var_291);
                    char var_297 = (var_289 >= 0);
                    char var_299;
                    if (var_297) {
                        var_299 = (var_289 < 1);
                    } else {
                        var_299 = 0;
                    }
                    char var_300 = (var_299 == 0);
                    if (var_300) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_301 = var_249[var_289];
                    float var_302 = var_2[var_296];
                    float var_303 = (var_302 + var_301);
                    float var_304 = (var_286 / 64);
                    float var_305 = (var_303 - var_304);
                    var_2[var_296] = var_305;
                } else {
                }
                long long int var_306 = (var_289 + 1);
                var_287[0] = var_306;
            }
            long long int var_307 = var_287[0];
            long long int var_308 = (var_10 + 64);
            var_8[0] = var_308;
        }
        long long int var_309 = var_8[0];
    }
    __global__ void method_108(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_109(var_6)) {
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
            float var_18 = (-var_16);
            float var_19 = exp(var_18);
            float var_20 = (1 + var_19);
            float var_21 = (1 / var_20);
            var_1[var_8] = var_21;
            long long int var_22 = (var_8 + 1280);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_113(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_109(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 1280);
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
                var_16 = (var_10 < 1280);
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
            long long int var_26 = (var_10 + 1280);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_160(float * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_64(var_6)) {
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
            while (method_161(var_23, var_24, var_25)) {
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
                Tuple0 var_38;
                if (var_37) {
                    var_38 = make_Tuple0(var_28, var_29);
                } else {
                    var_38 = make_Tuple0(var_35, var_36);
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
            FunPointer2 var_47 = method_162;
            Tuple0 var_48 = cub::BlockReduce<Tuple0,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple0(var_43, var_44), var_47);
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
    __global__ void method_86(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_63(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 64);
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
                var_14 = (var_8 < 64);
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
            while (method_87(var_21, var_22)) {
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
                long long int var_30 = (var_24 * 64);
                char var_32;
                if (var_9) {
                    var_32 = (var_8 < 64);
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
            while (method_88(var_41, var_42)) {
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
                    while (method_89(var_44, var_69, var_70)) {
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
            long long int var_98 = (var_8 + 64);
            var_6[0] = var_98;
        }
        long long int var_99 = var_6[0];
    }
    __global__ void method_119(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_104(var_6)) {
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
            while (method_87(var_21, var_22)) {
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
            while (method_88(var_41, var_42)) {
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
                    while (method_89(var_44, var_69, var_70)) {
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
    __global__ void method_129(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_109(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 1280);
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
                var_16 = (var_10 < 1280);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_1[var_10];
            float var_19 = var_2[var_10];
            float var_20 = var_3[var_10];
            float var_21 = var_0[0];
            float var_22 = (var_18 - var_19);
            float var_23 = (1 - var_18);
            float var_24 = (var_18 * var_23);
            float var_25 = (var_22 / var_24);
            float var_26 = (var_25 / 128);
            float var_27 = (var_20 + var_26);
            var_3[var_10] = var_27;
            long long int var_28 = (var_10 + 1280);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __device__ char method_63(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_139(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 50176);
    }
    __device__ char method_143(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 4096);
    }
    __device__ char method_69(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_104(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_153(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 640);
    }
    __device__ char method_64(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_124(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1280);
    }
    __device__ char method_167(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_76(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8192);
    }
    __device__ char method_109(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1280);
    }
    __device__ char method_161(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 10);
    }
    __device__ Tuple0 method_162(Tuple0 var_0, Tuple0 var_1) {
        float var_2 = var_0.mem_0;
        float var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        float var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple0 var_7;
        if (var_6) {
            var_7 = make_Tuple0(var_2, var_3);
        } else {
            var_7 = make_Tuple0(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        float var_9 = var_7.mem_1;
        return make_Tuple0(var_8, var_9);
    }
    __device__ char method_87(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_88(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_89(long long int var_0, long long int * var_1, float * var_2) {
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
    val mem_0: Env16
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack3 =
    struct
    val mem_0: ResizeArray<Env2>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap4 =
    {
    mem_0: EnvStack1
    mem_1: (uint64 ref)
    mem_2: uint64
    mem_3: EnvStack3
    }
and Env5 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack6 =
    struct
    val mem_0: ResizeArray<Env5>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env7 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack8 =
    struct
    val mem_0: ResizeArray<Env7>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap9 =
    {
    mem_0: ManagedCuda.CudaEvent
    mem_1: (bool ref)
    mem_2: ManagedCuda.CudaStream
    }
and Env10 =
    struct
    val mem_0: EnvHeap9
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple11 =
    struct
    val mem_0: Tuple12
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple12 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple13 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env14 =
    struct
    val mem_0: Env5
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack15 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env16 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack17 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack18 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack19 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack20 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack21 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple22 =
    struct
    val mem_0: float
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvStack23 =
    struct
    val mem_0: EnvStack24
    val mem_1: (int64 ref)
    val mem_2: Env16
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack24 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack25 =
    struct
    val mem_0: EnvStack26
    val mem_1: (int64 ref)
    val mem_2: Env16
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack26 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack27 =
    struct
    val mem_0: Env28
    val mem_1: (unit -> unit)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env28 =
    struct
    val mem_0: Env29
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env29 =
    struct
    val mem_0: Env14
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack30 =
    struct
    val mem_0: Env31
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env31 =
    struct
    val mem_0: Env32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env32 =
    struct
    val mem_0: Env33
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env33 =
    struct
    val mem_0: Env5
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env34 =
    struct
    val mem_0: Env28
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack35 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env36 =
    struct
    val mem_0: Env31
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: EnvHeap4)): unit =
    let (var_1: (uint64 ref)) = var_0.mem_1
    let (var_2: uint64) = var_0.mem_2
    let (var_3: EnvStack1) = var_0.mem_0
    let (var_4: EnvStack3) = var_0.mem_3
    let (var_5: ResizeArray<Env2>) = var_4.mem_0
    let (var_7: (Env2 -> bool)) = method_2
    let (var_8: int32) = var_5.RemoveAll <| System.Predicate(var_7)
    let (var_10: (Env2 -> (Env2 -> int32))) = method_3
    let (var_11: System.Comparison<Env2>) = System.Comparison<Env2>(var_10)
    var_5.Sort(var_11)
    let (var_12: ResizeArray<Env0>) = var_3.mem_0
    var_12.Clear()
    let (var_13: int32) = var_5.get_Count()
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: int32) = 0
    let (var_16: uint64) = method_6((var_3: EnvStack1), (var_4: EnvStack3), (var_13: int32), (var_14: uint64), (var_15: int32))
    let (var_17: uint64) = method_5((var_1: (uint64 ref)))
    let (var_18: uint64) = (var_17 + var_2)
    let (var_19: uint64) = (var_18 - var_16)
    let (var_20: uint64) = (var_16 + 256UL)
    let (var_21: uint64) = (var_20 - 1UL)
    let (var_22: uint64) = (var_21 &&& 18446744073709551360UL)
    let (var_23: uint64) = (var_22 - var_16)
    let (var_24: bool) = (var_19 > var_23)
    if var_24 then
        let (var_25: uint64) = (var_19 - var_23)
        var_12.Add((Env0(var_22, var_25)))
    else
        ()
and method_7((var_0: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule)): Env7 =
    let (var_8: (int64 ref)) = (ref 0L)
    method_8((var_8: (int64 ref)), (var_0: EnvHeap9), (var_6: EnvStack8))
    (Env7(var_8, (Env10(var_0))))
and method_9((var_0: string)): Tuple11 =
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
    Tuple11(Tuple12(var_16, var_17, var_18), var_22)
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
and method_12((var_0: string)): Tuple13 =
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
    Tuple13(var_12, var_14)
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
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64), (var_10: (float32 [])), (var_11: int64), (var_12: int64), (var_13: int64)): Env14 =
    let (var_14: int64) = (var_9 * var_12)
    let (var_15: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_10,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_16: int64) = var_15.AddrOfPinnedObject().ToInt64()
    let (var_17: uint64) = (uint64 var_16)
    let (var_18: int64) = (var_11 * 4L)
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: uint64) = (var_19 + var_17)
    let (var_21: Env5) = method_18((var_14: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_22: (int64 ref)) = var_21.mem_0
    let (var_23: Env16) = var_21.mem_1
    let (var_24: (uint64 ref)) = var_23.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: int64) = (var_14 * 4L)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_32: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_28, var_30, var_31)
    if var_32 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_32)
    var_15.Free()
    (Env14((Env5(var_22, var_23))))
and method_24((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack15 =
    let (var_9: Env5) = method_25((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_10: (int64 ref)), (var_11: Env16), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    EnvStack15((var_10: (int64 ref)), (var_11: Env16))
and method_28((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack15 =
    let (var_11: Env5) = method_25((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env16) = var_11.mem_1
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    method_29((var_12: (int64 ref)), (var_13: Env16), (var_5: ManagedCuda.CudaContext), (var_15: ManagedCuda.BasicTypes.CUstream))
    EnvStack15((var_12: (int64 ref)), (var_13: Env16))
and method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack17 =
    let (var_9: Env5) = method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    let (var_12: EnvHeap9) = var_8.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    method_32((var_10: (int64 ref)), (var_11: Env16), (var_3: ManagedCuda.CudaContext), (var_13: ManagedCuda.BasicTypes.CUstream))
    EnvStack17((var_10: (int64 ref)), (var_11: Env16))
and method_33((var_0: EnvStack17), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10)): EnvStack17 =
    let (var_10: (int64 ref)) = var_0.mem_0
    let (var_11: Env16) = var_0.mem_1
    let (var_12: Env5) = method_31((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env16) = var_12.mem_1
    let (var_15: EnvHeap9) = var_9.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: EnvHeap9))
    method_32((var_13: (int64 ref)), (var_14: Env16), (var_4: ManagedCuda.CudaContext), (var_16: ManagedCuda.BasicTypes.CUstream))
    EnvStack17((var_13: (int64 ref)), (var_14: Env16))
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack18 =
    let (var_9: Env5) = method_35((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    let (var_12: EnvHeap9) = var_8.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    method_36((var_10: (int64 ref)), (var_11: Env16), (var_3: ManagedCuda.CudaContext), (var_13: ManagedCuda.BasicTypes.CUstream))
    EnvStack18((var_10: (int64 ref)), (var_11: Env16))
and method_37((var_0: EnvStack18), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10)): EnvStack18 =
    let (var_10: (int64 ref)) = var_0.mem_0
    let (var_11: Env16) = var_0.mem_1
    let (var_12: Env5) = method_35((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env16) = var_12.mem_1
    let (var_15: EnvHeap9) = var_9.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: EnvHeap9))
    method_36((var_13: (int64 ref)), (var_14: Env16), (var_4: ManagedCuda.CudaContext), (var_16: ManagedCuda.BasicTypes.CUstream))
    EnvStack18((var_13: (int64 ref)), (var_14: Env16))
and method_38((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack19 =
    let (var_9: Env5) = method_39((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    method_40((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_10: (int64 ref)), (var_11: Env16), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    EnvStack19((var_10: (int64 ref)), (var_11: Env16))
and method_41((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack19 =
    let (var_11: Env5) = method_39((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env16) = var_11.mem_1
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    method_42((var_12: (int64 ref)), (var_13: Env16), (var_5: ManagedCuda.CudaContext), (var_15: ManagedCuda.BasicTypes.CUstream))
    EnvStack19((var_12: (int64 ref)), (var_13: Env16))
and method_43((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack20 =
    let (var_9: Env5) = method_44((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    method_45((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_10: (int64 ref)), (var_11: Env16), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    EnvStack20((var_10: (int64 ref)), (var_11: Env16))
and method_46((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack20 =
    let (var_11: Env5) = method_44((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env16) = var_11.mem_1
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    method_47((var_12: (int64 ref)), (var_13: Env16), (var_5: ManagedCuda.CudaContext), (var_15: ManagedCuda.BasicTypes.CUstream))
    EnvStack20((var_12: (int64 ref)), (var_13: Env16))
and method_48((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): EnvStack21 =
    let (var_9: Env5) = method_49((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: Env16) = var_9.mem_1
    let (var_12: EnvHeap9) = var_8.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    method_50((var_10: (int64 ref)), (var_11: Env16), (var_3: ManagedCuda.CudaContext), (var_13: ManagedCuda.BasicTypes.CUstream))
    EnvStack21((var_10: (int64 ref)), (var_11: Env16))
and method_51((var_0: EnvStack21), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10)): EnvStack21 =
    let (var_10: (int64 ref)) = var_0.mem_0
    let (var_11: Env16) = var_0.mem_1
    let (var_12: Env5) = method_49((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env16) = var_12.mem_1
    let (var_15: EnvHeap9) = var_9.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: EnvHeap9))
    method_50((var_13: (int64 ref)), (var_14: Env16), (var_4: ManagedCuda.CudaContext), (var_16: ManagedCuda.BasicTypes.CUstream))
    EnvStack21((var_13: (int64 ref)), (var_14: Env16))
and method_52((var_0: EnvStack17), (var_1: EnvStack17), (var_2: EnvStack17), (var_3: EnvStack17), (var_4: EnvStack15), (var_5: (int64 ref)), (var_6: Env16), (var_7: EnvStack19), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvStack18), (var_11: EnvStack18), (var_12: EnvStack21), (var_13: EnvStack21), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvHeap4), (var_20: ManagedCuda.CudaContext), (var_21: EnvStack6), (var_22: EnvStack8), (var_23: ManagedCuda.BasicTypes.CUmodule), (var_24: (int64 ref)), (var_25: Env10), (var_26: Env5), (var_27: Env5), (var_28: Env5), (var_29: Env5), (var_30: int64)): unit =
    let (var_31: bool) = (var_30 < 5L)
    if var_31 then
        let (var_32: int64) = 0L
        let (var_33: float) = 0.000000
        let (var_34: int64) = 0L
        let (var_35: float) = method_53((var_28: Env5), (var_29: Env5), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvHeap4), (var_20: ManagedCuda.CudaContext), (var_21: EnvStack6), (var_22: EnvStack8), (var_23: ManagedCuda.BasicTypes.CUmodule), (var_24: (int64 ref)), (var_25: Env10), (var_32: int64), (var_33: float), (var_0: EnvStack17), (var_1: EnvStack17), (var_2: EnvStack17), (var_3: EnvStack17), (var_4: EnvStack15), (var_5: (int64 ref)), (var_6: Env16), (var_7: EnvStack19), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvStack18), (var_11: EnvStack18), (var_12: EnvStack21), (var_13: EnvStack21), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16), (var_34: int64))
        let (var_36: string) = System.String.Format("Training: {0}",var_35)
        let (var_37: string) = System.String.Format("{0}",var_36)
        System.Console.WriteLine(var_37)
        if (System.Double.IsNaN var_35) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_38: int64) = 0L
            let (var_39: float) = 0.000000
            let (var_40: int64) = 0L
            let (var_41: int64) = 0L
            let (var_42: int64) = 0L
            let (var_43: Tuple22) = method_154((var_26: Env5), (var_27: Env5), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvHeap4), (var_20: ManagedCuda.CudaContext), (var_21: EnvStack6), (var_22: EnvStack8), (var_23: ManagedCuda.BasicTypes.CUmodule), (var_24: (int64 ref)), (var_25: Env10), (var_40: int64), (var_41: int64), (var_38: int64), (var_39: float), (var_0: EnvStack17), (var_1: EnvStack17), (var_2: EnvStack17), (var_3: EnvStack17), (var_4: EnvStack15), (var_5: (int64 ref)), (var_6: Env16), (var_7: EnvStack19), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvStack18), (var_11: EnvStack18), (var_12: EnvStack21), (var_13: EnvStack21), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16), (var_42: int64))
            let (var_44: float) = var_43.mem_0
            let (var_45: int64) = var_43.mem_1
            let (var_46: int64) = var_43.mem_2
            let (var_47: string) = System.String.Format("Testing: {0}({1}/{2})",var_44,var_45,var_46)
            let (var_48: string) = System.String.Format("{0}",var_47)
            System.Console.WriteLine(var_48)
            let (var_49: int64) = (var_30 + 1L)
            method_52((var_0: EnvStack17), (var_1: EnvStack17), (var_2: EnvStack17), (var_3: EnvStack17), (var_4: EnvStack15), (var_5: (int64 ref)), (var_6: Env16), (var_7: EnvStack19), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvStack18), (var_11: EnvStack18), (var_12: EnvStack21), (var_13: EnvStack21), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvHeap4), (var_20: ManagedCuda.CudaContext), (var_21: EnvStack6), (var_22: EnvStack8), (var_23: ManagedCuda.BasicTypes.CUmodule), (var_24: (int64 ref)), (var_25: Env10), (var_26: Env5), (var_27: Env5), (var_28: Env5), (var_29: Env5), (var_49: int64))
    else
        ()
and method_169((var_0: EnvStack8)): unit =
    let (var_1: ResizeArray<Env7>) = var_0.mem_0
    let (var_3: (Env7 -> unit)) = method_170
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_131((var_0: EnvStack6)): unit =
    let (var_1: ResizeArray<Env5>) = var_0.mem_0
    let (var_3: (Env5 -> unit)) = method_132
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
    let (var_1: Env16) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: Env16) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: EnvStack1), (var_1: EnvStack3), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env2>) = var_1.mem_0
        let (var_7: Env2) = var_6.[var_4]
        let (var_8: Env16) = var_7.mem_0
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
and method_8((var_0: (int64 ref)), (var_1: EnvHeap9), (var_2: EnvStack8)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env7>) = var_2.mem_0
    var_5.Add((Env7(var_0, (Env10(var_1)))))
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
and method_18((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvHeap4), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10)): Env5 =
    let (var_10: int64) = (var_0 * 4L)
    method_19((var_3: EnvHeap4), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack6), (var_6: EnvStack8), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env10), (var_10: int64))
and method_25((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 200704L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (uint64 ref)) = var_2.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(50176L)
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    var_0.SetStream(var_15)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    var_0.GenerateNormal32(var_17, var_13, 0.000000f, 0.048564f)
and method_27((var_0: EnvHeap9)): ManagedCuda.BasicTypes.CUstream =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_4: ManagedCuda.CudaStream) = var_0.mem_2
    var_4.Stream
and method_29((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(200704L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 256L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_32((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(256L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_35((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 4L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_36((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_39((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 16384L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_40((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (uint64 ref)) = var_2.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4096L)
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    var_0.SetStream(var_15)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    var_0.GenerateNormal32(var_17, var_13, 0.000000f, 0.125000f)
and method_42((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_44((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 2560L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_45((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (uint64 ref)) = var_2.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(640L)
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    var_0.SetStream(var_15)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    var_0.GenerateNormal32(var_17, var_13, 0.000000f, 0.164399f)
and method_47((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2560L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_49((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 40L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_50((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_53((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_11: int64), (var_12: float), (var_13: EnvStack17), (var_14: EnvStack17), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack15), (var_18: (int64 ref)), (var_19: Env16), (var_20: EnvStack19), (var_21: (int64 ref)), (var_22: Env16), (var_23: EnvStack18), (var_24: EnvStack18), (var_25: EnvStack21), (var_26: EnvStack21), (var_27: EnvStack20), (var_28: (int64 ref)), (var_29: Env16), (var_30: int64)): float =
    let (var_31: bool) = (var_30 < 468L)
    if var_31 then
        let (var_32: bool) = (var_30 >= 0L)
        let (var_33: bool) = (var_32 = false)
        if var_33 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_34: int64) = (var_30 * 100352L)
        if var_33 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_35: int64) = (var_30 * 1280L)
        method_1((var_4: EnvHeap4))
        let (var_41: ResizeArray<Env5>) = ResizeArray<Env5>()
        let (var_42: EnvStack6) = EnvStack6((var_41: ResizeArray<Env5>))
        // Executing the net...
        let (var_43: EnvStack23) = method_54((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_0: Env5), (var_34: int64), (var_13: EnvStack17), (var_14: EnvStack17), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack15), (var_18: (int64 ref)), (var_19: Env16), (var_20: EnvStack19), (var_21: (int64 ref)), (var_22: Env16), (var_23: EnvStack18), (var_24: EnvStack18))
        let (var_44: EnvStack24) = var_43.mem_0
        let (var_45: (int64 ref)) = var_43.mem_1
        let (var_46: Env16) = var_43.mem_2
        let (var_47: (unit -> unit)) = var_43.mem_3
        let (var_48: EnvStack25) = method_95((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_44: EnvStack24), (var_45: (int64 ref)), (var_46: Env16), (var_25: EnvStack21), (var_26: EnvStack21), (var_27: EnvStack20), (var_28: (int64 ref)), (var_29: Env16))
        let (var_49: EnvStack26) = var_48.mem_0
        let (var_50: (int64 ref)) = var_48.mem_1
        let (var_51: Env16) = var_48.mem_2
        let (var_52: (unit -> unit)) = var_48.mem_3
        let (var_53: EnvStack27) = method_120((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_49: EnvStack26), (var_50: (int64 ref)), (var_51: Env16), (var_1: Env5), (var_35: int64))
        let (var_54: Env28) = var_53.mem_0
        let (var_55: (unit -> unit)) = var_53.mem_1
        let (var_56: Env29) = var_54.mem_0
        let (var_57: Env14) = var_56.mem_0
        let (var_58: int64) = var_56.mem_1
        let (var_59: int64) = 1L
        let (var_60: Env5) = var_57.mem_0
        let (var_61: (float32 [])) = method_130((var_59: int64), (var_57: Env14), (var_58: int64))
        let (var_62: float32) = var_61.[int32 0L]
        let (var_63: float) = (float var_62)
        let (var_64: float) = (var_12 + var_63)
        let (var_65: int64) = (var_11 + 1L)
        if (System.Double.IsNaN var_64) then
            method_131((var_42: EnvStack6))
            // Done with the net...
            let (var_66: float) = (float var_65)
            (var_64 / var_66)
        else
            var_55()
            var_52()
            var_47()
            let (var_68: (int64 ref)) = var_14.mem_0
            let (var_69: Env16) = var_14.mem_1
            method_133((var_14: EnvStack17), (var_13: EnvStack17), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            let (var_70: (int64 ref)) = var_16.mem_0
            let (var_71: Env16) = var_16.mem_1
            method_133((var_16: EnvStack17), (var_15: EnvStack17), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            method_136((var_18: (int64 ref)), (var_19: Env16), (var_17: EnvStack15), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            method_140((var_21: (int64 ref)), (var_22: Env16), (var_20: EnvStack19), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            let (var_72: (int64 ref)) = var_24.mem_0
            let (var_73: Env16) = var_24.mem_1
            method_144((var_24: EnvStack18), (var_23: EnvStack18), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            let (var_74: (int64 ref)) = var_26.mem_0
            let (var_75: Env16) = var_26.mem_1
            method_147((var_26: EnvStack21), (var_25: EnvStack21), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            method_150((var_28: (int64 ref)), (var_29: Env16), (var_27: EnvStack20), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_42: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
            method_131((var_42: EnvStack6))
            // Executing the next loop...
            let (var_76: int64) = (var_30 + 1L)
            method_53((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_65: int64), (var_64: float), (var_13: EnvStack17), (var_14: EnvStack17), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack15), (var_18: (int64 ref)), (var_19: Env16), (var_20: EnvStack19), (var_21: (int64 ref)), (var_22: Env16), (var_23: EnvStack18), (var_24: EnvStack18), (var_25: EnvStack21), (var_26: EnvStack21), (var_27: EnvStack20), (var_28: (int64 ref)), (var_29: Env16), (var_76: int64))
    else
        let (var_79: float) = (float var_11)
        (var_12 / var_79)
and method_154((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: float), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack17), (var_18: EnvStack17), (var_19: EnvStack15), (var_20: (int64 ref)), (var_21: Env16), (var_22: EnvStack19), (var_23: (int64 ref)), (var_24: Env16), (var_25: EnvStack18), (var_26: EnvStack18), (var_27: EnvStack21), (var_28: EnvStack21), (var_29: EnvStack20), (var_30: (int64 ref)), (var_31: Env16), (var_32: int64)): Tuple22 =
    let (var_33: bool) = (var_32 < 78L)
    if var_33 then
        let (var_34: bool) = (var_32 >= 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = (var_32 * 100352L)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_37: int64) = (var_32 * 1280L)
        method_1((var_4: EnvHeap4))
        let (var_43: ResizeArray<Env5>) = ResizeArray<Env5>()
        let (var_44: EnvStack6) = EnvStack6((var_43: ResizeArray<Env5>))
        // Executing the net...
        let (var_45: EnvStack23) = method_54((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_44: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_0: Env5), (var_36: int64), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack17), (var_18: EnvStack17), (var_19: EnvStack15), (var_20: (int64 ref)), (var_21: Env16), (var_22: EnvStack19), (var_23: (int64 ref)), (var_24: Env16), (var_25: EnvStack18), (var_26: EnvStack18))
        let (var_46: EnvStack24) = var_45.mem_0
        let (var_47: (int64 ref)) = var_45.mem_1
        let (var_48: Env16) = var_45.mem_2
        let (var_49: (unit -> unit)) = var_45.mem_3
        let (var_50: EnvStack25) = method_95((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_44: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_46: EnvStack24), (var_47: (int64 ref)), (var_48: Env16), (var_27: EnvStack21), (var_28: EnvStack21), (var_29: EnvStack20), (var_30: (int64 ref)), (var_31: Env16))
        let (var_51: EnvStack26) = var_50.mem_0
        let (var_52: (int64 ref)) = var_50.mem_1
        let (var_53: Env16) = var_50.mem_2
        let (var_54: (unit -> unit)) = var_50.mem_3
        let (var_55: EnvStack27) = method_120((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_44: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_51: EnvStack26), (var_52: (int64 ref)), (var_53: Env16), (var_1: Env5), (var_37: int64))
        let (var_56: Env28) = var_55.mem_0
        let (var_57: (unit -> unit)) = var_55.mem_1
        let (var_58: EnvStack30) = method_155((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_44: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_51: EnvStack26), (var_52: (int64 ref)), (var_53: Env16), (var_1: Env5), (var_37: int64))
        let (var_59: Env31) = var_58.mem_0
        let (var_60: Env29) = var_56.mem_0
        let (var_61: Env14) = var_60.mem_0
        let (var_62: int64) = var_60.mem_1
        let (var_63: int64) = 1L
        let (var_64: Env5) = var_61.mem_0
        let (var_65: (float32 [])) = method_130((var_63: int64), (var_61: Env14), (var_62: int64))
        let (var_66: float32) = var_65.[int32 0L]
        let (var_67: float) = (float var_66)
        let (var_68: float) = (var_14 + var_67)
        let (var_69: Env32) = var_59.mem_0
        let (var_70: Env33) = var_69.mem_0
        let (var_71: int64) = var_69.mem_1
        let (var_72: int64) = 1L
        let (var_73: Env5) = var_70.mem_0
        let (var_74: (int64 [])) = method_168((var_72: int64), (var_70: Env33), (var_71: int64))
        let (var_75: int64) = var_74.[int32 0L]
        let (var_76: int64) = (var_11 + var_75)
        let (var_77: int64) = (var_12 + 128L)
        let (var_78: int64) = (var_13 + 1L)
        if (System.Double.IsNaN var_68) then
            method_131((var_44: EnvStack6))
            // Done with the net...
            let (var_79: float) = (float var_78)
            let (var_80: float) = (var_68 / var_79)
            Tuple22(var_80, var_76, var_77)
        else
            method_131((var_44: EnvStack6))
            // Executing the next loop...
            let (var_81: int64) = (var_32 + 1L)
            method_154((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_76: int64), (var_77: int64), (var_78: int64), (var_68: float), (var_15: EnvStack17), (var_16: EnvStack17), (var_17: EnvStack17), (var_18: EnvStack17), (var_19: EnvStack15), (var_20: (int64 ref)), (var_21: Env16), (var_22: EnvStack19), (var_23: (int64 ref)), (var_24: Env16), (var_25: EnvStack18), (var_26: EnvStack18), (var_27: EnvStack21), (var_28: EnvStack21), (var_29: EnvStack20), (var_30: (int64 ref)), (var_31: Env16), (var_81: int64))
    else
        let (var_84: float) = (float var_13)
        let (var_85: float) = (var_14 / var_84)
        Tuple22(var_85, var_11, var_12)
and method_170 ((var_0: Env7)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env10) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: EnvHeap9) = var_2.mem_0
        let (var_8: ManagedCuda.CudaStream) = var_7.mem_2
        var_8.Dispose()
        let (var_9: ManagedCuda.CudaEvent) = var_7.mem_0
        var_9.Dispose()
        let (var_10: (bool ref)) = var_7.mem_1
        var_10 := false
    else
        ()
and method_132 ((var_0: Env5)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env16) = var_0.mem_1
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
    let (var_2: Env16) = var_0.mem_0
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
and method_19((var_0: EnvHeap4), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64)): Env5 =
    let (var_10: uint64) = (uint64 var_9)
    let (var_11: uint64) = (var_10 + 256UL)
    let (var_12: uint64) = (var_11 - 1UL)
    let (var_13: uint64) = (var_12 &&& 18446744073709551360UL)
    let (var_14: Env16) = method_20((var_0: EnvHeap4), (var_13: uint64))
    let (var_15: (uint64 ref)) = var_14.mem_0
    let (var_16: (int64 ref)) = (ref 0L)
    method_23((var_16: (int64 ref)), (var_15: (uint64 ref)), (var_4: EnvStack6))
    (Env5(var_16, (Env16(var_15))))
and method_54((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: Env5), (var_10: int64), (var_11: EnvStack17), (var_12: EnvStack17), (var_13: EnvStack17), (var_14: EnvStack17), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16), (var_18: EnvStack19), (var_19: (int64 ref)), (var_20: Env16), (var_21: EnvStack18), (var_22: EnvStack18)): EnvStack23 =
    let (var_23: EnvStack24) = method_55((var_9: Env5), (var_10: int64), (var_16: (int64 ref)), (var_17: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env16) = var_23.mem_1
    let (var_26: EnvStack24) = method_58((var_24: (int64 ref)), (var_25: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    method_60((var_12: EnvStack17), (var_24: (int64 ref)), (var_25: Env16), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_27: (int64 ref)) = var_22.mem_0
    let (var_28: Env16) = var_22.mem_1
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: EnvStack24) = method_65((var_30: uint64), (var_24: (int64 ref)), (var_25: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: Env16) = var_31.mem_1
    let (var_34: EnvStack24) = method_58((var_32: (int64 ref)), (var_33: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_35: EnvStack24) = method_70((var_32: (int64 ref)), (var_33: Env16), (var_19: (int64 ref)), (var_20: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_36: (int64 ref)) = var_35.mem_0
    let (var_37: Env16) = var_35.mem_1
    let (var_38: EnvStack24) = method_58((var_36: (int64 ref)), (var_37: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    method_60((var_14: EnvStack17), (var_36: (int64 ref)), (var_37: Env16), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_39: EnvStack24) = method_72((var_36: (int64 ref)), (var_37: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_40: (int64 ref)) = var_39.mem_0
    let (var_41: Env16) = var_39.mem_1
    let (var_42: EnvStack24) = method_58((var_40: (int64 ref)), (var_41: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_43: (unit -> unit)) = method_77((var_26: EnvStack24), (var_24: (int64 ref)), (var_25: Env16), (var_11: EnvStack17), (var_12: EnvStack17), (var_9: Env5), (var_10: int64), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_21: EnvStack18), (var_22: EnvStack18), (var_34: EnvStack24), (var_32: (int64 ref)), (var_33: Env16), (var_38: EnvStack24), (var_36: (int64 ref)), (var_37: Env16), (var_13: EnvStack17), (var_14: EnvStack17), (var_18: EnvStack19), (var_19: (int64 ref)), (var_20: Env16), (var_42: EnvStack24), (var_40: (int64 ref)), (var_41: Env16))
    EnvStack23((var_42: EnvStack24), (var_40: (int64 ref)), (var_41: Env16), (var_43: (unit -> unit)))
and method_95((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: EnvStack24), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvStack21), (var_13: EnvStack21), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16)): EnvStack25 =
    let (var_17: EnvStack26) = method_96((var_10: (int64 ref)), (var_11: Env16), (var_15: (int64 ref)), (var_16: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env16) = var_17.mem_1
    let (var_20: EnvStack26) = method_99((var_18: (int64 ref)), (var_19: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    method_101((var_13: EnvStack21), (var_18: (int64 ref)), (var_19: Env16), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_21: EnvStack26) = method_105((var_18: (int64 ref)), (var_19: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_22: (int64 ref)) = var_21.mem_0
    let (var_23: Env16) = var_21.mem_1
    let (var_24: EnvStack26) = method_99((var_22: (int64 ref)), (var_23: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_25: (unit -> unit)) = method_110((var_20: EnvStack26), (var_18: (int64 ref)), (var_19: Env16), (var_12: EnvStack21), (var_13: EnvStack21), (var_9: EnvStack24), (var_10: (int64 ref)), (var_11: Env16), (var_14: EnvStack20), (var_15: (int64 ref)), (var_16: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_24: EnvStack26), (var_22: (int64 ref)), (var_23: Env16))
    EnvStack25((var_24: EnvStack26), (var_22: (int64 ref)), (var_23: Env16), (var_25: (unit -> unit)))
and method_120((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: EnvStack26), (var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64)): EnvStack27 =
    let (var_14: Env34) = method_121((var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_15: Env28) = var_14.mem_0
    let (var_16: (unit -> unit)) = method_125((var_9: EnvStack26), (var_15: Env28), (var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    EnvStack27((var_15: Env28), (var_16: (unit -> unit)))
and method_130((var_0: int64), (var_1: Env14), (var_2: int64)): (float32 []) =
    let (var_3: Env5) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env16) = var_3.mem_1
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
and method_133((var_0: EnvStack17), (var_1: EnvStack17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_134((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_136((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack15), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: (int64 ref)), (var_11: Env10)): unit =
    let (var_12: (int64 ref)) = var_2.mem_0
    let (var_13: Env16) = var_2.mem_1
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_13.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_137((var_7: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
and method_140((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack19), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: (int64 ref)), (var_11: Env10)): unit =
    let (var_12: (int64 ref)) = var_2.mem_0
    let (var_13: Env16) = var_2.mem_1
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_13.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_141((var_7: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
and method_144((var_0: EnvStack18), (var_1: EnvStack18), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_145((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_147((var_0: EnvStack21), (var_1: EnvStack21), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_148((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_150((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack20), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: (int64 ref)), (var_11: Env10)): unit =
    let (var_12: (int64 ref)) = var_2.mem_0
    let (var_13: Env16) = var_2.mem_1
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_13.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_151((var_7: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
and method_155((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: EnvStack26), (var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64)): EnvStack30 =
    let (var_14: EnvStack35) = method_156((var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env16) = var_14.mem_1
    let (var_17: Env36) = method_163((var_15: (int64 ref)), (var_16: Env16), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_18: Env31) = var_17.mem_0
    EnvStack30((var_18: Env31))
and method_168((var_0: int64), (var_1: Env33), (var_2: int64)): (int64 []) =
    let (var_3: Env5) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env16) = var_3.mem_1
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
and method_20((var_0: EnvHeap4), (var_1: uint64)): Env16 =
    let (var_2: (uint64 ref)) = var_0.mem_1
    let (var_3: uint64) = var_0.mem_2
    let (var_4: EnvStack3) = var_0.mem_3
    let (var_5: EnvStack1) = var_0.mem_0
    let (var_6: ResizeArray<Env0>) = var_5.mem_0
    let (var_7: int32) = var_6.get_Count()
    let (var_8: bool) = (var_7 > 0)
    let (var_9: bool) = (var_8 = false)
    if var_9 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_10: Env0) = var_6.[0]
    let (var_11: uint64) = var_10.mem_0
    let (var_12: uint64) = var_10.mem_1
    let (var_13: bool) = (var_1 <= var_12)
    let (var_40: Env2) =
        if var_13 then
            let (var_14: uint64) = (var_11 + var_1)
            let (var_15: uint64) = (var_12 - var_1)
            var_6.[0] <- (Env0(var_14, var_15))
            let (var_16: (uint64 ref)) = (ref var_11)
            (Env2((Env16(var_16)), var_1))
        else
            let (var_18: (Env0 -> (Env0 -> int32))) = method_21
            let (var_19: System.Comparison<Env0>) = System.Comparison<Env0>(var_18)
            var_6.Sort(var_19)
            let (var_20: Env0) = var_6.[0]
            let (var_21: uint64) = var_20.mem_0
            let (var_22: uint64) = var_20.mem_1
            let (var_23: bool) = (var_1 <= var_22)
            if var_23 then
                let (var_24: uint64) = (var_21 + var_1)
                let (var_25: uint64) = (var_22 - var_1)
                var_6.[0] <- (Env0(var_24, var_25))
                let (var_26: (uint64 ref)) = (ref var_21)
                (Env2((Env16(var_26)), var_1))
            else
                method_1((var_0: EnvHeap4))
                let (var_28: (Env0 -> (Env0 -> int32))) = method_21
                let (var_29: System.Comparison<Env0>) = System.Comparison<Env0>(var_28)
                var_6.Sort(var_29)
                let (var_30: Env0) = var_6.[0]
                let (var_31: uint64) = var_30.mem_0
                let (var_32: uint64) = var_30.mem_1
                let (var_33: bool) = (var_1 <= var_32)
                if var_33 then
                    let (var_34: uint64) = (var_31 + var_1)
                    let (var_35: uint64) = (var_32 - var_1)
                    var_6.[0] <- (Env0(var_34, var_35))
                    let (var_36: (uint64 ref)) = (ref var_31)
                    (Env2((Env16(var_36)), var_1))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_41: Env16) = var_40.mem_0
    let (var_42: uint64) = var_40.mem_1
    let (var_43: ResizeArray<Env2>) = var_4.mem_0
    var_43.Add((Env2(var_41, var_42)))
    var_41
and method_23((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack6)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env5>) = var_2.mem_0
    var_5.Add((Env5(var_0, (Env16(var_1)))))
and method_55((var_0: Env5), (var_1: int64), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10)): EnvStack24 =
    let (var_13: Env5) = method_56((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    method_57((var_0: Env5), (var_1: int64), (var_2: (int64 ref)), (var_3: Env16), (var_14: (int64 ref)), (var_15: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_11: (int64 ref)), (var_12: Env10))
    EnvStack24((var_14: (int64 ref)), (var_15: Env16))
and method_58((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack24 =
    let (var_11: Env5) = method_56((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env16) = var_11.mem_1
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    method_59((var_12: (int64 ref)), (var_13: Env16), (var_5: ManagedCuda.CudaContext), (var_15: ManagedCuda.BasicTypes.CUstream))
    EnvStack24((var_12: (int64 ref)), (var_13: Env16))
and method_60((var_0: EnvStack17), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: (int64 ref)), (var_11: Env10)): unit =
    let (var_12: (int64 ref)) = var_0.mem_0
    let (var_13: Env16) = var_0.mem_1
    let (var_14: (uint64 ref)) = var_13.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_2.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: uint64) = method_5((var_16: (uint64 ref)))
    method_61((var_7: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_18: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
and method_65((var_0: uint64), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10)): EnvStack24 =
    let (var_21: Env5) = method_56((var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
    let (var_22: (int64 ref)) = var_21.mem_0
    let (var_23: Env16) = var_21.mem_1
    method_66((var_0: uint64), (var_1: (int64 ref)), (var_2: Env16), (var_22: (int64 ref)), (var_23: Env16), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_10: (int64 ref)), (var_11: Env10))
    EnvStack24((var_22: (int64 ref)), (var_23: Env16))
and method_70((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10)): EnvStack24 =
    let (var_13: Env5) = method_56((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    method_71((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_14: (int64 ref)), (var_15: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_11: (int64 ref)), (var_12: Env10))
    EnvStack24((var_14: (int64 ref)), (var_15: Env16))
and method_72((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack24 =
    let (var_15: Env5) = method_56((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env16) = var_15.mem_1
    method_73((var_0: (int64 ref)), (var_1: Env16), (var_16: (int64 ref)), (var_17: Env16), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
    EnvStack24((var_16: (int64 ref)), (var_17: Env16))
and method_77 ((var_0: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: Env5), (var_6: int64), (var_7: EnvStack15), (var_8: (int64 ref)), (var_9: Env16), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env10), (var_19: EnvStack18), (var_20: EnvStack18), (var_21: EnvStack24), (var_22: (int64 ref)), (var_23: Env16), (var_24: EnvStack24), (var_25: (int64 ref)), (var_26: Env16), (var_27: EnvStack17), (var_28: EnvStack17), (var_29: EnvStack19), (var_30: (int64 ref)), (var_31: Env16), (var_32: EnvStack24), (var_33: (int64 ref)), (var_34: Env16)) (): unit =
    method_78((var_25: (int64 ref)), (var_26: Env16), (var_32: EnvStack24), (var_33: (int64 ref)), (var_34: Env16), (var_24: EnvStack24), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_17: (int64 ref)), (var_18: Env10))
    method_81((var_24: EnvStack24), (var_25: (int64 ref)), (var_26: Env16), (var_27: EnvStack17), (var_28: EnvStack17), (var_21: EnvStack24), (var_22: (int64 ref)), (var_23: Env16), (var_29: EnvStack19), (var_30: (int64 ref)), (var_31: Env16), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env10))
    let (var_35: (int64 ref)) = var_19.mem_0
    let (var_36: Env16) = var_19.mem_1
    let (var_37: (uint64 ref)) = var_36.mem_0
    let (var_38: uint64) = method_5((var_37: (uint64 ref)))
    let (var_39: (int64 ref)) = var_20.mem_0
    let (var_40: Env16) = var_20.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    method_90((var_38: uint64), (var_42: uint64), (var_21: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_0: EnvStack24), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_17: (int64 ref)), (var_18: Env10))
    method_93((var_0: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: Env5), (var_6: int64), (var_7: EnvStack15), (var_8: (int64 ref)), (var_9: Env16), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env10))
and method_96((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10)): EnvStack26 =
    let (var_13: Env5) = method_97((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    method_98((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_14: (int64 ref)), (var_15: Env16), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_11: (int64 ref)), (var_12: Env10))
    EnvStack26((var_14: (int64 ref)), (var_15: Env16))
and method_99((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack26 =
    let (var_11: Env5) = method_97((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env16) = var_11.mem_1
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    method_100((var_12: (int64 ref)), (var_13: Env16), (var_5: ManagedCuda.CudaContext), (var_15: ManagedCuda.BasicTypes.CUstream))
    EnvStack26((var_12: (int64 ref)), (var_13: Env16))
and method_101((var_0: EnvStack21), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: (int64 ref)), (var_11: Env10)): unit =
    let (var_12: (int64 ref)) = var_0.mem_0
    let (var_13: Env16) = var_0.mem_1
    let (var_14: (uint64 ref)) = var_13.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_2.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: uint64) = method_5((var_16: (uint64 ref)))
    method_102((var_7: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_18: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10))
and method_105((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack26 =
    let (var_15: Env5) = method_97((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env16) = var_15.mem_1
    method_106((var_0: (int64 ref)), (var_1: Env16), (var_16: (int64 ref)), (var_17: Env16), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
    EnvStack26((var_16: (int64 ref)), (var_17: Env16))
and method_110 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack21), (var_4: EnvStack21), (var_5: EnvStack24), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvStack20), (var_9: (int64 ref)), (var_10: Env16), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env10), (var_20: EnvStack26), (var_21: (int64 ref)), (var_22: Env16)) (): unit =
    method_111((var_1: (int64 ref)), (var_2: Env16), (var_20: EnvStack26), (var_21: (int64 ref)), (var_22: Env16), (var_0: EnvStack26), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_18: (int64 ref)), (var_19: Env10))
    method_114((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack21), (var_4: EnvStack21), (var_5: EnvStack24), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvStack20), (var_9: (int64 ref)), (var_10: Env16), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env10))
and method_121((var_0: (int64 ref)), (var_1: Env16), (var_2: Env5), (var_3: int64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): Env34 =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env16) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: int64) = (var_3 * 4L)
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: uint64) = (var_18 + var_20)
    let (var_30: Env5) = method_35((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: Env16) = var_30.mem_1
    let (var_33: (uint64 ref)) = var_32.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    method_122((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_21: uint64), (var_34: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    (Env34((Env28((Env29((Env14((Env5(var_31, var_32)))), 0L))))))
and method_125 ((var_0: EnvStack26), (var_1: Env28), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10)) (): unit =
    method_126((var_0: EnvStack26), (var_1: Env28), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_134((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_135((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_135", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_137((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_138((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_138", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_141((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_142((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_142", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_145((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_146((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_146", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_148((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_149((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_149", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_151((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_152((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_152", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_156((var_0: (int64 ref)), (var_1: Env16), (var_2: Env5), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10)): EnvStack35 =
    let (var_13: Env5) = method_157((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    method_158((var_0: (int64 ref)), (var_1: Env16), (var_2: Env5), (var_3: int64), (var_14: (int64 ref)), (var_15: Env16), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_11: (int64 ref)), (var_12: Env10))
    EnvStack35((var_14: (int64 ref)), (var_15: Env16))
and method_163((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): Env36 =
    let (var_11: (uint64 ref)) = var_1.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: Env5) = method_164((var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    let (var_16: (uint64 ref)) = var_15.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_165((var_6: ManagedCuda.CudaContext), (var_12: uint64), (var_17: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    (Env36((Env31((Env32((Env33((Env5(var_14, var_15)))), 0L))))))
and method_21 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_22((var_2: uint64))
and method_56((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 32768L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_57((var_0: Env5), (var_1: int64), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env10)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: EnvHeap9) = var_8.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    var_6.set_Stream(var_11)
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: (float32 ref)) = (ref 1.000000f)
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (int64 ref)) = var_0.mem_0
    let (var_20: Env16) = var_0.mem_1
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: int64) = (var_1 * 4L)
    let (var_24: uint64) = (uint64 var_23)
    let (var_25: uint64) = (var_22 + var_24)
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: (float32 ref)) = (ref 0.000000f)
    let (var_29: (uint64 ref)) = var_5.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_12, var_13, 64, 128, 784, var_14, var_18, 64, var_27, 784, var_28, var_32, 64)
    if var_33 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_33)
and method_59((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_61((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_62((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_62", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_66((var_0: uint64), (var_1: (int64 ref)), (var_2: Env16), (var_3: (int64 ref)), (var_4: Env16), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: (int64 ref)), (var_13: Env10)): unit =
    let (var_14: (uint64 ref)) = var_2.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_4.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_67((var_9: ManagedCuda.CudaContext), (var_15: uint64), (var_17: uint64), (var_0: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env10))
and method_71((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env10)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: EnvHeap9) = var_8.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    var_6.set_Stream(var_11)
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: (float32 ref)) = (ref 1.000000f)
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: (float32 ref)) = (ref 0.000000f)
    let (var_24: (uint64 ref)) = var_5.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_12, var_13, 64, 128, 64, var_14, var_18, 64, var_22, 64, var_23, var_27, 64)
    if var_28 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_28)
and method_73((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): unit =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_74((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_16: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
and method_78((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack24), (var_3: (int64 ref)), (var_4: Env16), (var_5: EnvStack24), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env16) = var_2.mem_1
    let (var_17: (int64 ref)) = var_5.mem_0
    let (var_18: Env16) = var_5.mem_1
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_16.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_4.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: (uint64 ref)) = var_18.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    method_79((var_10: ManagedCuda.CudaContext), (var_20: uint64), (var_22: uint64), (var_24: uint64), (var_26: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_81((var_0: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: EnvStack24), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvStack19), (var_9: (int64 ref)), (var_10: Env16), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env10)): unit =
    method_82((var_0: EnvStack24), (var_9: (int64 ref)), (var_10: Env16), (var_5: EnvStack24), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_18: (int64 ref)), (var_19: Env10))
    method_83((var_6: (int64 ref)), (var_7: Env16), (var_0: EnvStack24), (var_8: EnvStack19), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_18: (int64 ref)), (var_19: Env10))
    let (var_20: (int64 ref)) = var_3.mem_0
    let (var_21: Env16) = var_3.mem_1
    method_84((var_0: EnvStack24), (var_3: EnvStack17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_18: (int64 ref)), (var_19: Env10))
and method_90((var_0: uint64), (var_1: uint64), (var_2: EnvStack24), (var_3: (int64 ref)), (var_4: Env16), (var_5: EnvStack24), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env16) = var_2.mem_1
    let (var_17: (int64 ref)) = var_5.mem_0
    let (var_18: Env16) = var_5.mem_1
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_4.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_18.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    method_91((var_10: ManagedCuda.CudaContext), (var_20: uint64), (var_22: uint64), (var_24: uint64), (var_0: uint64), (var_1: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_93((var_0: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack17), (var_4: EnvStack17), (var_5: Env5), (var_6: int64), (var_7: EnvStack15), (var_8: (int64 ref)), (var_9: Env16), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env10)): unit =
    method_94((var_5: Env5), (var_6: int64), (var_0: EnvStack24), (var_7: EnvStack15), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_17: (int64 ref)), (var_18: Env10))
    let (var_19: (int64 ref)) = var_3.mem_0
    let (var_20: Env16) = var_3.mem_1
    method_84((var_0: EnvStack24), (var_3: EnvStack17), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvHeap4), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack6), (var_15: EnvStack8), (var_17: (int64 ref)), (var_18: Env10))
and method_97((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 5120L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_98((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env10)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: EnvHeap9) = var_8.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    var_6.set_Stream(var_11)
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: (float32 ref)) = (ref 1.000000f)
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: (float32 ref)) = (ref 0.000000f)
    let (var_24: (uint64 ref)) = var_5.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_12, var_13, 10, 128, 64, var_14, var_18, 10, var_22, 64, var_23, var_27, 10)
    if var_28 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_28)
and method_100((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_102((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_103((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_103", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_106((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): unit =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_107((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_16: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
and method_111((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env16), (var_5: EnvStack26), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env16) = var_2.mem_1
    let (var_17: (int64 ref)) = var_5.mem_0
    let (var_18: Env16) = var_5.mem_1
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_16.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_4.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: (uint64 ref)) = var_18.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    method_112((var_10: ManagedCuda.CudaContext), (var_20: uint64), (var_22: uint64), (var_24: uint64), (var_26: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_114((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack21), (var_4: EnvStack21), (var_5: EnvStack24), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvStack20), (var_9: (int64 ref)), (var_10: Env16), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env10)): unit =
    method_115((var_0: EnvStack26), (var_9: (int64 ref)), (var_10: Env16), (var_5: EnvStack24), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_18: (int64 ref)), (var_19: Env10))
    method_116((var_6: (int64 ref)), (var_7: Env16), (var_0: EnvStack26), (var_8: EnvStack20), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_18: (int64 ref)), (var_19: Env10))
    let (var_20: (int64 ref)) = var_3.mem_0
    let (var_21: Env16) = var_3.mem_1
    method_117((var_0: EnvStack26), (var_3: EnvStack21), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvHeap4), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack6), (var_16: EnvStack8), (var_18: (int64 ref)), (var_19: Env10))
and method_122((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_123((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_123", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_126((var_0: EnvStack26), (var_1: Env28), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: Env29) = var_1.mem_0
    let (var_16: Env14) = var_15.mem_0
    let (var_17: int64) = var_15.mem_1
    let (var_18: Env5) = var_16.mem_0
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: Env16) = var_18.mem_1
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: int64) = (var_17 * 4L)
    let (var_24: uint64) = (uint64 var_23)
    let (var_25: uint64) = (var_22 + var_24)
    method_127((var_25: uint64), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_0: EnvStack26), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_13: (int64 ref)), (var_14: Env10))
and method_157((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 1024L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_158((var_0: (int64 ref)), (var_1: Env16), (var_2: Env5), (var_3: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: (uint64 ref)) = var_1.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (int64 ref)) = var_2.mem_0
    let (var_18: Env16) = var_2.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: int64) = (var_3 * 4L)
    let (var_22: uint64) = (uint64 var_21)
    let (var_23: uint64) = (var_20 + var_22)
    let (var_24: (uint64 ref)) = var_5.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    method_159((var_10: ManagedCuda.CudaContext), (var_16: uint64), (var_23: uint64), (var_25: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_164((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 8L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_165((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_166((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_166", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
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
and method_67((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_68((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_68", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_74((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_75((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_75", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_79((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env10)): unit =
    // Cuda join point
    // method_80((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_80", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: EnvHeap9) = var_7.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: EnvHeap9))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_12, var_14)
and method_82((var_0: EnvStack24), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack24), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env10)): unit =
    let (var_7: (int64 ref)) = var_0.mem_0
    let (var_8: Env16) = var_0.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env16) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap9) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_2.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_8.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 64, 128, 64, var_16, var_20, 64, var_24, 64, var_25, var_29, 64)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_83((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack24), (var_3: EnvStack19), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env10)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env16) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env16) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap9) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_8.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_1.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 64, 64, 128, var_16, var_20, 64, var_24, 64, var_25, var_29, 64)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_84((var_0: EnvStack24), (var_1: EnvStack17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_85((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_91((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): unit =
    // Cuda join point
    // method_92((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64))
    let (var_9: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_92", var_6, var_0)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_9.set_GridDimensions(var_10)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_9.set_BlockDimensions(var_11)
    let (var_12: EnvHeap9) = var_8.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5|]: (System.Object [])
    var_9.RunAsync(var_13, var_15)
and method_94((var_0: Env5), (var_1: int64), (var_2: EnvStack24), (var_3: EnvStack15), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env10)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env16) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env16) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap9) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_8.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (int64 ref)) = var_0.mem_0
    let (var_22: Env16) = var_0.mem_1
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: int64) = (var_1 * 4L)
    let (var_26: uint64) = (uint64 var_25)
    let (var_27: uint64) = (var_24 + var_26)
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (float32 ref)) = (ref 1.000000f)
    let (var_31: (uint64 ref)) = var_10.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_32)
    let (var_34: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_33)
    let (var_35: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 64, 784, 128, var_16, var_20, 64, var_29, 784, var_30, var_34, 64)
    if var_35 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_35)
and method_107((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_108((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_108", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_112((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env10)): unit =
    // Cuda join point
    // method_113((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_113", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: EnvHeap9) = var_7.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: EnvHeap9))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_12, var_14)
and method_115((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack24), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env10)): unit =
    let (var_7: (int64 ref)) = var_0.mem_0
    let (var_8: Env16) = var_0.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env16) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap9) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_2.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_8.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 64, 128, 10, var_16, var_20, 10, var_24, 10, var_25, var_29, 64)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_116((var_0: (int64 ref)), (var_1: Env16), (var_2: EnvStack26), (var_3: EnvStack20), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env10)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env16) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env16) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap9) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: EnvHeap9))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_8.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_1.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 10, 64, 128, var_16, var_20, 10, var_24, 64, var_25, var_29, 10)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_117((var_0: EnvStack26), (var_1: EnvStack21), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_118((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_127((var_0: uint64), (var_1: (int64 ref)), (var_2: Env16), (var_3: Env5), (var_4: int64), (var_5: EnvStack26), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: (int64 ref)) = var_5.mem_0
    let (var_16: Env16) = var_5.mem_1
    let (var_17: (uint64 ref)) = var_2.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (int64 ref)) = var_3.mem_0
    let (var_20: Env16) = var_3.mem_1
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: int64) = (var_4 * 4L)
    let (var_24: uint64) = (uint64 var_23)
    let (var_25: uint64) = (var_22 + var_24)
    let (var_26: (uint64 ref)) = var_16.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    method_128((var_10: ManagedCuda.CudaContext), (var_0: uint64), (var_18: uint64), (var_25: uint64), (var_27: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_159((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_160((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_160", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_85((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_86((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_86", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_118((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_119((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_119", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_128((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env10)): unit =
    // Cuda join point
    // method_129((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_129", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: EnvHeap9) = var_7.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: EnvHeap9))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_12, var_14)
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
let (var_44: EnvHeap4) = ({mem_0 = (var_41: EnvStack1); mem_1 = (var_39: (uint64 ref)); mem_2 = (var_35: uint64); mem_3 = (var_43: EnvStack3)} : EnvHeap4)
method_1((var_44: EnvHeap4))
let (var_45: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_46: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_45)
let (var_47: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_48: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_49: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_47, var_48)
let (var_55: ResizeArray<Env5>) = ResizeArray<Env5>()
let (var_56: EnvStack6) = EnvStack6((var_55: ResizeArray<Env5>))
let (var_68: ResizeArray<Env7>) = ResizeArray<Env7>()
let (var_69: EnvStack8) = EnvStack8((var_68: ResizeArray<Env7>))
let (var_70: (bool ref)) = (ref true)
let (var_71: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_72: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_73: EnvHeap9) = ({mem_0 = (var_72: ManagedCuda.CudaEvent); mem_1 = (var_70: (bool ref)); mem_2 = (var_71: ManagedCuda.CudaStream)} : EnvHeap9)
let (var_74: Env7) = method_7((var_73: EnvHeap9), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_75: (int64 ref)) = var_74.mem_0
let (var_76: Env10) = var_74.mem_1
let (var_77: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_78: Tuple11) = method_9((var_77: string))
let (var_79: Tuple12) = var_78.mem_0
let (var_80: (uint8 [])) = var_78.mem_1
let (var_81: int64) = var_79.mem_0
let (var_82: int64) = var_79.mem_1
let (var_83: int64) = var_79.mem_2
let (var_84: bool) = (10000L = var_81)
let (var_88: bool) =
    if var_84 then
        let (var_85: bool) = (28L = var_82)
        if var_85 then
            (28L = var_83)
        else
            false
    else
        false
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_90: int64) = var_80.LongLength
let (var_91: bool) = (var_90 > 0L)
let (var_92: bool) = (var_91 = false)
if var_92 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_93: bool) = (var_90 = 7840000L)
let (var_94: bool) = (var_93 = false)
if var_94 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_98: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_99: int64) = 0L
method_10((var_80: (uint8 [])), (var_98: (float32 [])), (var_99: int64))
let (var_100: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_101: Tuple13) = method_12((var_100: string))
let (var_102: int64) = var_101.mem_0
let (var_103: (uint8 [])) = var_101.mem_1
let (var_104: bool) = (10000L = var_102)
let (var_105: bool) = (var_104 = false)
if var_105 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_109: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_110: int64) = 0L
method_13((var_103: (uint8 [])), (var_109: (float32 [])), (var_110: int64))
let (var_111: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_112: Tuple11) = method_9((var_111: string))
let (var_113: Tuple12) = var_112.mem_0
let (var_114: (uint8 [])) = var_112.mem_1
let (var_115: int64) = var_113.mem_0
let (var_116: int64) = var_113.mem_1
let (var_117: int64) = var_113.mem_2
let (var_118: bool) = (60000L = var_115)
let (var_122: bool) =
    if var_118 then
        let (var_119: bool) = (28L = var_116)
        if var_119 then
            (28L = var_117)
        else
            false
    else
        false
let (var_123: bool) = (var_122 = false)
if var_123 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_124: int64) = var_114.LongLength
let (var_125: bool) = (var_124 > 0L)
let (var_126: bool) = (var_125 = false)
if var_126 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_127: bool) = (var_124 = 47040000L)
let (var_128: bool) = (var_127 = false)
if var_128 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_132: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_133: int64) = 0L
method_15((var_114: (uint8 [])), (var_132: (float32 [])), (var_133: int64))
let (var_134: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_135: Tuple13) = method_12((var_134: string))
let (var_136: int64) = var_135.mem_0
let (var_137: (uint8 [])) = var_135.mem_1
let (var_138: bool) = (60000L = var_136)
let (var_139: bool) = (var_138 = false)
if var_139 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_143: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_144: int64) = 0L
method_16((var_137: (uint8 [])), (var_143: (float32 [])), (var_144: int64))
let (var_145: int64) = 10000L
let (var_146: int64) = 0L
let (var_147: int64) = 784L
let (var_148: int64) = 1L
let (var_149: Env14) = method_17((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_145: int64), (var_98: (float32 [])), (var_146: int64), (var_147: int64), (var_148: int64))
let (var_150: Env5) = var_149.mem_0
let (var_151: int64) = 10000L
let (var_152: int64) = 0L
let (var_153: int64) = 10L
let (var_154: int64) = 1L
let (var_155: Env14) = method_17((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_151: int64), (var_109: (float32 [])), (var_152: int64), (var_153: int64), (var_154: int64))
let (var_156: Env5) = var_155.mem_0
let (var_157: int64) = 60000L
let (var_158: int64) = 0L
let (var_159: int64) = 784L
let (var_160: int64) = 1L
let (var_161: Env14) = method_17((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_157: int64), (var_132: (float32 [])), (var_158: int64), (var_159: int64), (var_160: int64))
let (var_162: Env5) = var_161.mem_0
let (var_163: int64) = 60000L
let (var_164: int64) = 0L
let (var_165: int64) = 10L
let (var_166: int64) = 1L
let (var_167: Env14) = method_17((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_163: int64), (var_143: (float32 [])), (var_164: int64), (var_165: int64), (var_166: int64))
let (var_168: Env5) = var_167.mem_0
let (var_169: EnvStack15) = method_24((var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_170: (int64 ref)) = var_169.mem_0
let (var_171: Env16) = var_169.mem_1
let (var_172: EnvStack15) = method_28((var_170: (int64 ref)), (var_171: Env16), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_173: EnvStack17) = method_30((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_174: EnvStack17) = method_33((var_173: EnvStack17), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_175: EnvStack18) = method_34((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_176: EnvStack18) = method_37((var_175: EnvStack18), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_177: EnvStack19) = method_38((var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_178: (int64 ref)) = var_177.mem_0
let (var_179: Env16) = var_177.mem_1
let (var_180: EnvStack19) = method_41((var_178: (int64 ref)), (var_179: Env16), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_181: EnvStack17) = method_30((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_182: EnvStack17) = method_33((var_181: EnvStack17), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_183: EnvStack20) = method_43((var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_184: (int64 ref)) = var_183.mem_0
let (var_185: Env16) = var_183.mem_1
let (var_186: EnvStack20) = method_46((var_184: (int64 ref)), (var_185: Env16), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_187: EnvStack21) = method_48((var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_188: EnvStack21) = method_51((var_187: EnvStack21), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10))
let (var_189: int64) = 0L
method_52((var_174: EnvStack17), (var_173: EnvStack17), (var_182: EnvStack17), (var_181: EnvStack17), (var_172: EnvStack15), (var_170: (int64 ref)), (var_171: Env16), (var_180: EnvStack19), (var_178: (int64 ref)), (var_179: Env16), (var_176: EnvStack18), (var_175: EnvStack18), (var_188: EnvStack21), (var_187: EnvStack21), (var_186: EnvStack20), (var_184: (int64 ref)), (var_185: Env16), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_150: Env5), (var_156: Env5), (var_162: Env5), (var_168: Env5), (var_189: int64))
method_169((var_69: EnvStack8))
method_131((var_56: EnvStack6))
var_49.Dispose()
var_46.Dispose()
let (var_190: uint64) = method_5((var_39: (uint64 ref)))
let (var_191: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_190)
let (var_192: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_191)
var_1.FreeMemory(var_192)
var_39 := 0UL
var_1.Dispose()

