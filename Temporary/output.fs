module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple4 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple4 make_Tuple4(float mem_0, float mem_1){
        Tuple4 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer0)(float, float);
    struct Tuple1 {
        float mem_0;
        long long int mem_1;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, long long int mem_1){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple6 {
        Tuple1 mem_0;
        Tuple1 mem_1;
    };
    __device__ __forceinline__ Tuple6 make_Tuple6(Tuple1 mem_0, Tuple1 mem_1){
        Tuple6 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple1(*FunPointer2)(Tuple1, Tuple1);
    struct Tuple3 {
        long long int mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(long long int mem_0, float mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple5 {
        float mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ Tuple5 make_Tuple5(float mem_0, float mem_1, float mem_2){
        Tuple5 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    __global__ void method_138(float * var_0, float * var_1);
    __global__ void method_141(float * var_0, float * var_1);
    __global__ void method_145(float * var_0, float * var_1);
    __global__ void method_149(float * var_0, float * var_1);
    __global__ void method_152(float * var_0, float * var_1);
    __global__ void method_64(float * var_0, float * var_1, float * var_2);
    __global__ void method_96(float * var_0, float * var_1, float * var_2);
    __global__ void method_109(float * var_0, float * var_1);
    __global__ void method_55(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, long long int var_5, float * var_6);
    __global__ void method_70(float * var_0, float * var_1);
    __global__ void method_117(float * var_0, float * var_1, long long int * var_2);
    __global__ void method_123(long long int * var_0, float * var_1, long long int var_2, float * var_3);
    __global__ void method_75(float * var_0, float * var_1, float * var_2);
    __global__ void method_80(float * var_0, float * var_1);
    __global__ void method_104(float * var_0, float * var_1);
    __device__ char method_65(long long int * var_0);
    __device__ char method_142(long long int * var_0);
    __device__ char method_146(long long int * var_0);
    __device__ char method_97(long long int * var_0);
    __device__ char method_153(long long int * var_0);
    __device__ char method_66(long long int * var_0);
    __device__ char method_110(long long int * var_0);
    __device__ float method_111(float var_0, float var_1);
    __device__ char method_56(long long int * var_0);
    __device__ char method_118(long long int * var_0, float * var_1, long long int * var_2);
    __device__ Tuple1 method_119(Tuple1 var_0, Tuple1 var_1);
    __device__ char method_81(long long int * var_0, float * var_1);
    
    __global__ void method_138(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_65(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 256);
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
                var_14 = (var_8 < 256);
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
            float var_18 = (0.003 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 256);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_141(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_142(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 39936);
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
                var_14 = (var_8 < 39936);
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
            float var_18 = (0.003 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_145(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_146(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 65536);
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
                var_14 = (var_8 < 65536);
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
            float var_18 = (0.003 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_149(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_97(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 192);
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
                var_14 = (var_8 < 192);
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
            float var_18 = (0.003 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 256);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
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
                var_11 = (var_8 < 49152);
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
                var_14 = (var_8 < 49152);
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
            float var_18 = (0.003 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_64(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_65(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 256);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            float var_14 = var_0[var_9];
            long long int var_15 = threadIdx.y;
            long long int var_16 = blockIdx.y;
            long long int var_17 = (var_15 + var_16);
            long long int var_18[1];
            var_18[0] = var_17;
            while (method_66(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 1);
                } else {
                    var_23 = 0;
                }
                char var_24 = (var_23 == 0);
                if (var_24) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_25 = (var_20 * 256);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 256);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_25 + var_9);
                char var_31;
                if (var_21) {
                    var_31 = (var_20 < 1);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                char var_34;
                if (var_10) {
                    var_34 = (var_9 < 256);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                float var_36 = var_1[var_29];
                float var_37 = var_2[var_29];
                float var_38 = (var_14 + var_36);
                var_2[var_29] = var_38;
                long long int var_39 = (var_20 + 1);
                var_18[0] = var_39;
            }
            long long int var_40 = var_18[0];
            long long int var_41 = (var_9 + 256);
            var_7[0] = var_41;
        }
        long long int var_42 = var_7[0];
    }
    __global__ void method_96(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_97(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 192);
            } else {
                var_12 = 0;
            }
            char var_13 = (var_12 == 0);
            if (var_13) {
                // "Argument out of bounds."
            } else {
            }
            float var_14 = var_0[var_9];
            long long int var_15 = threadIdx.y;
            long long int var_16 = blockIdx.y;
            long long int var_17 = (var_15 + var_16);
            long long int var_18[1];
            var_18[0] = var_17;
            while (method_66(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 1);
                } else {
                    var_23 = 0;
                }
                char var_24 = (var_23 == 0);
                if (var_24) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_25 = (var_20 * 192);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 192);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_25 + var_9);
                char var_31;
                if (var_21) {
                    var_31 = (var_20 < 1);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                char var_34;
                if (var_10) {
                    var_34 = (var_9 < 192);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                float var_36 = var_1[var_29];
                float var_37 = var_2[var_29];
                float var_38 = (var_14 + var_36);
                var_2[var_29] = var_38;
                long long int var_39 = (var_20 + 1);
                var_18[0] = var_39;
            }
            long long int var_40 = var_18[0];
            long long int var_41 = (var_9 + 192);
            var_7[0] = var_41;
        }
        long long int var_42 = var_7[0];
    }
    __global__ void method_109(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (64 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = (var_5 + -32);
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_7 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_66(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 1);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = (var_12 * 192);
            char var_19;
            if (var_13) {
                var_19 = (var_12 < 1);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_21 = (var_12 * 3);
            long long int var_22 = threadIdx.y;
            long long int var_23 = blockIdx.y;
            long long int var_24 = (var_22 + var_23);
            long long int var_25[1];
            var_25[0] = var_24;
            while (method_110(var_25)) {
                long long int var_27 = var_25[0];
                char var_28 = (var_27 >= 0);
                char var_30;
                if (var_28) {
                    var_30 = (var_27 < 3);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_32 = (var_27 * 64);
                long long int var_33 = (var_17 + var_32);
                float var_43[1];
                long long int var_44[1];
                var_44[0] = 0;
                while (method_66(var_44)) {
                    long long int var_46 = var_44[0];
                    long long int var_47 = (64 * var_46);
                    long long int var_48 = (var_6 + var_47);
                    long long int var_49 = (64 - var_47);
                    char var_50 = (var_48 < 32);
                    if (var_50) {
                        char var_51 = (var_46 >= 0);
                        char var_53;
                        if (var_51) {
                            var_53 = (var_46 < 1);
                        } else {
                            var_53 = 0;
                        }
                        char var_54 = (var_53 == 0);
                        if (var_54) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_55 = (var_48 >= -32);
                        char var_56 = (var_55 == 0);
                        if (var_56) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_57 = (var_48 - -32);
                        long long int var_58 = (var_33 + var_57);
                        float var_59 = var_0[var_58];
                        var_43[var_46] = var_59;
                    } else {
                    }
                    long long int var_60 = (var_46 + 1);
                    var_44[0] = var_60;
                }
                long long int var_61 = var_44[0];
                FunPointer0 var_64 = method_111;
                float var_65 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_43, var_64);
                __shared__ float var_66[1];
                long long int var_67 = threadIdx.x;
                char var_68 = (var_67 == 0);
                if (var_68) {
                    var_66[0] = var_65;
                } else {
                }
                __syncthreads();
                float var_69 = var_66[0];
                float var_79[1];
                long long int var_80[1];
                var_80[0] = 0;
                while (method_66(var_80)) {
                    long long int var_82 = var_80[0];
                    long long int var_83 = (64 * var_82);
                    long long int var_84 = (var_6 + var_83);
                    long long int var_85 = (64 - var_83);
                    char var_86 = (var_84 < 32);
                    if (var_86) {
                        char var_87 = (var_82 >= 0);
                        char var_89;
                        if (var_87) {
                            var_89 = (var_82 < 1);
                        } else {
                            var_89 = 0;
                        }
                        char var_90 = (var_89 == 0);
                        if (var_90) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_92;
                        if (var_87) {
                            var_92 = (var_82 < 1);
                        } else {
                            var_92 = 0;
                        }
                        char var_93 = (var_92 == 0);
                        if (var_93) {
                            // "Argument out of bounds."
                        } else {
                        }
                        float var_94 = var_43[var_82];
                        float var_95 = (var_94 - var_69);
                        float var_96 = exp(var_95);
                        var_79[var_82] = var_96;
                    } else {
                    }
                    long long int var_97 = (var_82 + 1);
                    var_80[0] = var_97;
                }
                long long int var_98 = var_80[0];
                float var_99 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_79);
                __shared__ float var_100[1];
                long long int var_101 = threadIdx.x;
                char var_102 = (var_101 == 0);
                if (var_102) {
                    var_100[0] = var_99;
                } else {
                }
                __syncthreads();
                float var_103 = var_100[0];
                float var_114[1];
                long long int var_115[1];
                var_115[0] = 0;
                while (method_66(var_115)) {
                    long long int var_117 = var_115[0];
                    long long int var_118 = (64 * var_117);
                    long long int var_119 = (var_6 + var_118);
                    long long int var_120 = (64 - var_118);
                    char var_121 = (var_119 < 32);
                    if (var_121) {
                        char var_122 = (var_117 >= 0);
                        char var_124;
                        if (var_122) {
                            var_124 = (var_117 < 1);
                        } else {
                            var_124 = 0;
                        }
                        char var_125 = (var_124 == 0);
                        if (var_125) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_127;
                        if (var_122) {
                            var_127 = (var_117 < 1);
                        } else {
                            var_127 = 0;
                        }
                        char var_128 = (var_127 == 0);
                        if (var_128) {
                            // "Argument out of bounds."
                        } else {
                        }
                        float var_129 = var_79[var_117];
                        float var_130 = (var_129 / var_103);
                        float var_131 = ((float) (var_119));
                        float var_132 = (var_130 * var_131);
                        var_114[var_117] = var_132;
                    } else {
                    }
                    long long int var_133 = (var_117 + 1);
                    var_115[0] = var_133;
                }
                long long int var_134 = var_115[0];
                float var_135 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_114);
                char var_137;
                if (var_28) {
                    var_137 = (var_27 < 3);
                } else {
                    var_137 = 0;
                }
                char var_138 = (var_137 == 0);
                if (var_138) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_139 = (var_21 + var_27);
                long long int var_140[1];
                var_140[0] = 0;
                while (method_66(var_140)) {
                    long long int var_142 = var_140[0];
                    long long int var_143 = (64 * var_142);
                    long long int var_144 = (var_6 + var_143);
                    long long int var_145 = (64 - var_143);
                    char var_146 = (var_144 < 32);
                    if (var_146) {
                        char var_147 = (var_142 >= 0);
                        char var_149;
                        if (var_147) {
                            var_149 = (var_142 < 1);
                        } else {
                            var_149 = 0;
                        }
                        char var_150 = (var_149 == 0);
                        if (var_150) {
                            // "Argument out of bounds."
                        } else {
                        }
                        float var_151 = var_114[var_142];
                        long long int var_152 = threadIdx.x;
                        char var_153 = (var_152 == 0);
                        if (var_153) {
                            var_1[var_139] = var_135;
                        } else {
                        }
                    } else {
                    }
                    long long int var_154 = (var_142 + 1);
                    var_140[0] = var_154;
                }
                long long int var_155 = var_140[0];
                long long int var_156 = (var_27 + 3);
                var_25[0] = var_156;
            }
            long long int var_157 = var_25[0];
            long long int var_158 = (var_12 + 1);
            var_10[0] = var_158;
        }
        long long int var_159 = var_10[0];
    }
    __global__ void method_55(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, long long int var_5, float * var_6) {
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (156 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11[1];
        var_11[0] = var_10;
        while (method_56(var_11)) {
            long long int var_13 = var_11[0];
            long long int var_14 = (var_13 % 156);
            long long int var_15 = (var_13 / 156);
            char var_16 = (var_14 == var_0);
            float var_17;
            if (var_16) {
                var_17 = 1;
            } else {
                var_17 = 0;
            }
            char var_18 = (var_14 == var_1);
            float var_19;
            if (var_18) {
                var_19 = 1;
            } else {
                var_19 = var_17;
            }
            char var_20 = (var_14 == var_2);
            float var_21;
            if (var_20) {
                var_21 = 1;
            } else {
                var_21 = var_19;
            }
            char var_22 = (var_14 == var_3);
            float var_23;
            if (var_22) {
                var_23 = 1;
            } else {
                var_23 = var_21;
            }
            char var_24 = (var_14 == var_4);
            float var_25;
            if (var_24) {
                var_25 = 1;
            } else {
                var_25 = var_23;
            }
            char var_26 = (var_14 == var_5);
            float var_27;
            if (var_26) {
                var_27 = 1;
            } else {
                var_27 = var_25;
            }
            char var_28 = (var_14 >= 0);
            char var_30;
            if (var_28) {
                var_30 = (var_14 < 156);
            } else {
                var_30 = 0;
            }
            char var_31 = (var_30 == 0);
            if (var_31) {
                // "Argument out of bounds."
            } else {
            }
            float var_32 = var_6[var_14];
            var_6[var_14] = var_27;
            long long int var_33 = (var_13 + 156);
            var_11[0] = var_33;
        }
        long long int var_34 = var_11[0];
    }
    __global__ void method_70(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = threadIdx.y;
        long long int var_7 = blockIdx.y;
        long long int var_8 = (var_6 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_66(var_9)) {
            long long int var_11 = var_9[0];
            float var_25[1];
            long long int var_26[1];
            var_26[0] = 0;
            while (method_66(var_26)) {
                long long int var_28 = var_26[0];
                long long int var_29 = (256 * var_28);
                long long int var_30 = (var_5 + var_29);
                long long int var_31 = (256 - var_29);
                char var_32 = (var_30 < 256);
                if (var_32) {
                    char var_33 = (var_28 >= 0);
                    char var_35;
                    if (var_33) {
                        var_35 = (var_28 < 1);
                    } else {
                        var_35 = 0;
                    }
                    char var_36 = (var_35 == 0);
                    if (var_36) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_37 = (var_11 >= 0);
                    char var_39;
                    if (var_37) {
                        var_39 = (var_11 < 1);
                    } else {
                        var_39 = 0;
                    }
                    char var_40 = (var_39 == 0);
                    if (var_40) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_41 = (var_11 * 256);
                    char var_42 = (var_30 >= 0);
                    char var_43 = (var_42 == 0);
                    if (var_43) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_44 = (var_41 + var_30);
                    float var_45 = var_0[var_44];
                    var_25[var_28] = var_45;
                } else {
                }
                long long int var_46 = (var_28 + 1);
                var_26[0] = var_46;
            }
            long long int var_47 = var_26[0];
            float var_48 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_25);
            __shared__ float var_49[1];
            long long int var_50 = threadIdx.x;
            char var_51 = (var_50 == 0);
            if (var_51) {
                var_49[0] = var_48;
            } else {
            }
            __syncthreads();
            float var_52 = var_49[0];
            float var_62[1];
            long long int var_63[1];
            var_63[0] = 0;
            while (method_66(var_63)) {
                long long int var_65 = var_63[0];
                long long int var_66 = (256 * var_65);
                long long int var_67 = (var_5 + var_66);
                long long int var_68 = (256 - var_66);
                char var_69 = (var_67 < 256);
                if (var_69) {
                    char var_70 = (var_65 >= 0);
                    char var_72;
                    if (var_70) {
                        var_72 = (var_65 < 1);
                    } else {
                        var_72 = 0;
                    }
                    char var_73 = (var_72 == 0);
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_75;
                    if (var_70) {
                        var_75 = (var_65 < 1);
                    } else {
                        var_75 = 0;
                    }
                    char var_76 = (var_75 == 0);
                    if (var_76) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_77 = var_25[var_65];
                    float var_78 = (var_52 / 256);
                    float var_79 = (var_77 - var_78);
                    var_62[var_65] = var_79;
                } else {
                }
                long long int var_80 = (var_65 + 1);
                var_63[0] = var_80;
            }
            long long int var_81 = var_63[0];
            float var_90[1];
            long long int var_91[1];
            var_91[0] = 0;
            while (method_66(var_91)) {
                long long int var_93 = var_91[0];
                long long int var_94 = (256 * var_93);
                long long int var_95 = (var_5 + var_94);
                long long int var_96 = (256 - var_94);
                char var_97 = (var_95 < 256);
                if (var_97) {
                    char var_98 = (var_93 >= 0);
                    char var_100;
                    if (var_98) {
                        var_100 = (var_93 < 1);
                    } else {
                        var_100 = 0;
                    }
                    char var_101 = (var_100 == 0);
                    if (var_101) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_103;
                    if (var_98) {
                        var_103 = (var_93 < 1);
                    } else {
                        var_103 = 0;
                    }
                    char var_104 = (var_103 == 0);
                    if (var_104) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_105 = var_62[var_93];
                    float var_106 = (var_105 * var_105);
                    var_90[var_93] = var_106;
                } else {
                }
                long long int var_107 = (var_93 + 1);
                var_91[0] = var_107;
            }
            long long int var_108 = var_91[0];
            float var_109 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_90);
            __shared__ float var_110[1];
            long long int var_111 = threadIdx.x;
            char var_112 = (var_111 == 0);
            if (var_112) {
                var_110[0] = var_109;
            } else {
            }
            __syncthreads();
            float var_113 = var_110[0];
            long long int var_114[1];
            var_114[0] = 0;
            while (method_66(var_114)) {
                long long int var_116 = var_114[0];
                long long int var_117 = (256 * var_116);
                long long int var_118 = (var_5 + var_117);
                long long int var_119 = (256 - var_117);
                char var_120 = (var_118 < 256);
                if (var_120) {
                    char var_121 = (var_116 >= 0);
                    char var_123;
                    if (var_121) {
                        var_123 = (var_116 < 1);
                    } else {
                        var_123 = 0;
                    }
                    char var_124 = (var_123 == 0);
                    if (var_124) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_125 = var_62[var_116];
                    char var_126 = (var_11 >= 0);
                    char var_128;
                    if (var_126) {
                        var_128 = (var_11 < 1);
                    } else {
                        var_128 = 0;
                    }
                    char var_129 = (var_128 == 0);
                    if (var_129) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_130 = (var_11 * 256);
                    char var_131 = (var_118 >= 0);
                    char var_132 = (var_131 == 0);
                    if (var_132) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_133 = (var_130 + var_118);
                    float var_134 = var_1[var_133];
                    float var_135 = (var_113 / 256);
                    float var_136 = sqrt(var_135);
                    float var_137 = (var_125 / var_136);
                    char var_138 = (var_137 > 0);
                    float var_139;
                    if (var_138) {
                        var_139 = var_137;
                    } else {
                        var_139 = 0;
                    }
                    var_1[var_133] = var_139;
                } else {
                }
                long long int var_140 = (var_116 + 1);
                var_114[0] = var_140;
            }
            long long int var_141 = var_114[0];
            long long int var_142 = (var_11 + 1);
            var_9[0] = var_142;
        }
        long long int var_143 = var_9[0];
    }
    __global__ void method_117(float * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_66(var_6)) {
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
            long long int var_13 = (var_8 * 3);
            char var_15;
            if (var_9) {
                var_15 = (var_8 < 1);
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
            long long int var_19 = (3 * var_18);
            long long int var_20 = (var_17 + var_19);
            float var_21 = __int_as_float(0xff800000);
            long long int var_22 = -1;
            long long int var_23[1];
            float var_24[1];
            long long int var_25[1];
            var_23[0] = var_20;
            var_24[0] = var_21;
            var_25[0] = var_22;
            while (method_118(var_23, var_24, var_25)) {
                long long int var_27 = var_23[0];
                float var_28 = var_24[0];
                long long int var_29 = var_25[0];
                char var_30 = (var_27 >= 0);
                char var_32;
                if (var_30) {
                    var_32 = (var_27 < 3);
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
                char var_36 = (var_28 > var_35);
                Tuple1 var_37;
                if (var_36) {
                    var_37 = make_Tuple1(var_28, var_29);
                } else {
                    var_37 = make_Tuple1(var_35, var_27);
                }
                float var_38 = var_37.mem_0;
                long long int var_39 = var_37.mem_1;
                long long int var_40 = (var_27 + 3);
                var_23[0] = var_40;
                var_24[0] = var_38;
                var_25[0] = var_39;
            }
            long long int var_41 = var_23[0];
            float var_42 = var_24[0];
            long long int var_43 = var_25[0];
            FunPointer2 var_46 = method_119;
            Tuple1 var_47 = cub::BlockReduce<Tuple1,3,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple1(var_42, var_43), var_46);
            float var_48 = var_47.mem_0;
            long long int var_49 = var_47.mem_1;
            long long int var_50 = threadIdx.x;
            char var_51 = (var_50 == 0);
            if (var_51) {
                char var_53;
                if (var_9) {
                    var_53 = (var_8 < 1);
                } else {
                    var_53 = 0;
                }
                char var_54 = (var_53 == 0);
                if (var_54) {
                    // "Argument out of bounds."
                } else {
                }
                float var_55 = var_1[var_8];
                long long int var_56 = var_2[var_8];
                var_1[var_8] = var_48;
                var_2[var_8] = var_49;
            } else {
            }
            long long int var_57 = (var_8 + 1);
            var_6[0] = var_57;
        }
        long long int var_58 = var_6[0];
    }
    __global__ void method_123(long long int * var_0, float * var_1, long long int var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (64 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8 = (var_7 + -32);
        long long int var_9 = threadIdx.y;
        long long int var_10 = blockIdx.y;
        long long int var_11 = (var_9 + var_10);
        long long int var_12[1];
        var_12[0] = var_11;
        while (method_66(var_12)) {
            long long int var_14 = var_12[0];
            char var_15 = (var_14 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_14 < 1);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = var_0[var_14];
            char var_21;
            if (var_15) {
                var_21 = (var_14 < 1);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = (var_14 * 192);
            char var_24 = (var_19 >= 0);
            char var_26;
            if (var_24) {
                var_26 = (var_19 < 3);
            } else {
                var_26 = 0;
            }
            char var_27 = (var_26 == 0);
            if (var_27) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_28 = (var_19 * 64);
            long long int var_29 = (var_23 + var_28);
            Tuple3 var_39[1];
            long long int var_40[1];
            var_40[0] = 0;
            while (method_66(var_40)) {
                long long int var_42 = var_40[0];
                long long int var_43 = (64 * var_42);
                long long int var_44 = (var_8 + var_43);
                long long int var_45 = (64 - var_43);
                char var_46 = (var_44 < 32);
                if (var_46) {
                    char var_47 = (var_42 >= 0);
                    char var_49;
                    if (var_47) {
                        var_49 = (var_42 < 1);
                    } else {
                        var_49 = 0;
                    }
                    char var_50 = (var_49 == 0);
                    if (var_50) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_51 = (var_44 >= -32);
                    char var_52 = (var_51 == 0);
                    if (var_52) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_53 = (var_44 - -32);
                    long long int var_54 = (var_29 + var_53);
                    float var_55 = var_1[var_54];
                    var_39[var_42] = make_Tuple3(var_19, var_55);
                } else {
                }
                long long int var_56 = (var_42 + 1);
                var_40[0] = var_56;
            }
            long long int var_57 = var_40[0];
            float var_67[1];
            long long int var_68[1];
            var_68[0] = 0;
            while (method_66(var_68)) {
                long long int var_70 = var_68[0];
                long long int var_71 = (64 * var_70);
                long long int var_72 = (var_8 + var_71);
                long long int var_73 = (64 - var_71);
                char var_74 = (var_72 < 32);
                if (var_74) {
                    char var_75 = (var_70 >= 0);
                    char var_77;
                    if (var_75) {
                        var_77 = (var_70 < 1);
                    } else {
                        var_77 = 0;
                    }
                    char var_78 = (var_77 == 0);
                    if (var_78) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_80;
                    if (var_75) {
                        var_80 = (var_70 < 1);
                    } else {
                        var_80 = 0;
                    }
                    char var_81 = (var_80 == 0);
                    if (var_81) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_82 = var_39[var_70];
                    long long int var_83 = var_82.mem_0;
                    float var_84 = var_82.mem_1;
                    var_67[var_70] = var_84;
                } else {
                }
                long long int var_85 = (var_70 + 1);
                var_68[0] = var_85;
            }
            long long int var_86 = var_68[0];
            FunPointer0 var_89 = method_111;
            float var_90 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_67, var_89);
            __shared__ float var_91[1];
            long long int var_92 = threadIdx.x;
            char var_93 = (var_92 == 0);
            if (var_93) {
                var_91[0] = var_90;
            } else {
            }
            __syncthreads();
            float var_94 = var_91[0];
            Tuple3 var_106[1];
            long long int var_107[1];
            var_107[0] = 0;
            while (method_66(var_107)) {
                long long int var_109 = var_107[0];
                long long int var_110 = (64 * var_109);
                long long int var_111 = (var_8 + var_110);
                long long int var_112 = (64 - var_110);
                char var_113 = (var_111 < 32);
                if (var_113) {
                    char var_114 = (var_109 >= 0);
                    char var_116;
                    if (var_114) {
                        var_116 = (var_109 < 1);
                    } else {
                        var_116 = 0;
                    }
                    char var_117 = (var_116 == 0);
                    if (var_117) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_119;
                    if (var_114) {
                        var_119 = (var_109 < 1);
                    } else {
                        var_119 = 0;
                    }
                    char var_120 = (var_119 == 0);
                    if (var_120) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_121 = var_39[var_109];
                    long long int var_122 = var_121.mem_0;
                    float var_123 = var_121.mem_1;
                    float var_124 = (var_123 - var_94);
                    float var_125 = exp(var_124);
                    var_106[var_109] = make_Tuple3(var_122, var_125);
                } else {
                }
                long long int var_126 = (var_109 + 1);
                var_107[0] = var_126;
            }
            long long int var_127 = var_107[0];
            float var_137[1];
            long long int var_138[1];
            var_138[0] = 0;
            while (method_66(var_138)) {
                long long int var_140 = var_138[0];
                long long int var_141 = (64 * var_140);
                long long int var_142 = (var_8 + var_141);
                long long int var_143 = (64 - var_141);
                char var_144 = (var_142 < 32);
                if (var_144) {
                    char var_145 = (var_140 >= 0);
                    char var_147;
                    if (var_145) {
                        var_147 = (var_140 < 1);
                    } else {
                        var_147 = 0;
                    }
                    char var_148 = (var_147 == 0);
                    if (var_148) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_150;
                    if (var_145) {
                        var_150 = (var_140 < 1);
                    } else {
                        var_150 = 0;
                    }
                    char var_151 = (var_150 == 0);
                    if (var_151) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_152 = var_106[var_140];
                    long long int var_153 = var_152.mem_0;
                    float var_154 = var_152.mem_1;
                    var_137[var_140] = var_154;
                } else {
                }
                long long int var_155 = (var_140 + 1);
                var_138[0] = var_155;
            }
            long long int var_156 = var_138[0];
            float var_157 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_137);
            __shared__ float var_158[1];
            long long int var_159 = threadIdx.x;
            char var_160 = (var_159 == 0);
            if (var_160) {
                var_158[0] = var_157;
            } else {
            }
            __syncthreads();
            float var_161 = var_158[0];
            char var_163;
            if (var_15) {
                var_163 = (var_14 < 1);
            } else {
                var_163 = 0;
            }
            char var_164 = (var_163 == 0);
            if (var_164) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_165[1];
            var_165[0] = 0;
            while (method_66(var_165)) {
                long long int var_167 = var_165[0];
                long long int var_168 = (64 * var_167);
                long long int var_169 = (var_8 + var_168);
                long long int var_170 = (64 - var_168);
                char var_171 = (var_169 < 32);
                if (var_171) {
                    char var_172 = (var_167 >= 0);
                    char var_174;
                    if (var_172) {
                        var_174 = (var_167 < 1);
                    } else {
                        var_174 = 0;
                    }
                    char var_175 = (var_174 == 0);
                    if (var_175) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_176 = var_106[var_167];
                    long long int var_177 = var_176.mem_0;
                    float var_178 = var_176.mem_1;
                    float var_179 = (var_178 / var_161);
                    char var_180 = (var_169 == var_2);
                    float var_181;
                    if (var_180) {
                        var_181 = 1;
                    } else {
                        var_181 = 0;
                    }
                    float var_182 = (var_179 - var_181);
                    char var_183 = (var_177 >= 0);
                    char var_185;
                    if (var_183) {
                        var_185 = (var_177 < 3);
                    } else {
                        var_185 = 0;
                    }
                    char var_186 = (var_185 == 0);
                    if (var_186) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_187 = (var_177 * 64);
                    long long int var_188 = (var_23 + var_187);
                    char var_189 = (var_169 >= -32);
                    char var_190 = (var_189 == 0);
                    if (var_190) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_191 = (var_169 - -32);
                    long long int var_192 = (var_188 + var_191);
                    float var_193 = var_3[var_192];
                    float var_194 = (var_193 + var_182);
                    var_3[var_192] = var_194;
                } else {
                }
                long long int var_195 = (var_167 + 1);
                var_165[0] = var_195;
            }
            long long int var_196 = var_165[0];
            long long int var_197 = (var_14 + 1);
            var_12[0] = var_197;
        }
        long long int var_198 = var_12[0];
    }
    __global__ void method_75(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7 = threadIdx.y;
        long long int var_8 = blockIdx.y;
        long long int var_9 = (var_7 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_66(var_10)) {
            long long int var_12 = var_10[0];
            Tuple4 var_27[1];
            long long int var_28[1];
            var_28[0] = 0;
            while (method_66(var_28)) {
                long long int var_30 = var_28[0];
                long long int var_31 = (256 * var_30);
                long long int var_32 = (var_6 + var_31);
                long long int var_33 = (256 - var_31);
                char var_34 = (var_32 < 256);
                if (var_34) {
                    char var_35 = (var_30 >= 0);
                    char var_37;
                    if (var_35) {
                        var_37 = (var_30 < 1);
                    } else {
                        var_37 = 0;
                    }
                    char var_38 = (var_37 == 0);
                    if (var_38) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_39 = (var_12 >= 0);
                    char var_41;
                    if (var_39) {
                        var_41 = (var_12 < 1);
                    } else {
                        var_41 = 0;
                    }
                    char var_42 = (var_41 == 0);
                    if (var_42) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_43 = (var_12 * 256);
                    char var_44 = (var_32 >= 0);
                    char var_45 = (var_44 == 0);
                    if (var_45) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_46 = (var_43 + var_32);
                    float var_47 = var_0[var_46];
                    float var_48 = var_1[var_46];
                    var_27[var_30] = make_Tuple4(var_47, var_48);
                } else {
                }
                long long int var_49 = (var_30 + 1);
                var_28[0] = var_49;
            }
            long long int var_50 = var_28[0];
            float var_60[1];
            long long int var_61[1];
            var_61[0] = 0;
            while (method_66(var_61)) {
                long long int var_63 = var_61[0];
                long long int var_64 = (256 * var_63);
                long long int var_65 = (var_6 + var_64);
                long long int var_66 = (256 - var_64);
                char var_67 = (var_65 < 256);
                if (var_67) {
                    char var_68 = (var_63 >= 0);
                    char var_70;
                    if (var_68) {
                        var_70 = (var_63 < 1);
                    } else {
                        var_70 = 0;
                    }
                    char var_71 = (var_70 == 0);
                    if (var_71) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_73;
                    if (var_68) {
                        var_73 = (var_63 < 1);
                    } else {
                        var_73 = 0;
                    }
                    char var_74 = (var_73 == 0);
                    if (var_74) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple4 var_75 = var_27[var_63];
                    float var_76 = var_75.mem_0;
                    float var_77 = var_75.mem_1;
                    var_60[var_63] = var_77;
                } else {
                }
                long long int var_78 = (var_63 + 1);
                var_61[0] = var_78;
            }
            long long int var_79 = var_61[0];
            float var_80 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_60);
            __shared__ float var_81[1];
            long long int var_82 = threadIdx.x;
            char var_83 = (var_82 == 0);
            if (var_83) {
                var_81[0] = var_80;
            } else {
            }
            __syncthreads();
            float var_84 = var_81[0];
            Tuple4 var_96[1];
            long long int var_97[1];
            var_97[0] = 0;
            while (method_66(var_97)) {
                long long int var_99 = var_97[0];
                long long int var_100 = (256 * var_99);
                long long int var_101 = (var_6 + var_100);
                long long int var_102 = (256 - var_100);
                char var_103 = (var_101 < 256);
                if (var_103) {
                    char var_104 = (var_99 >= 0);
                    char var_106;
                    if (var_104) {
                        var_106 = (var_99 < 1);
                    } else {
                        var_106 = 0;
                    }
                    char var_107 = (var_106 == 0);
                    if (var_107) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_109;
                    if (var_104) {
                        var_109 = (var_99 < 1);
                    } else {
                        var_109 = 0;
                    }
                    char var_110 = (var_109 == 0);
                    if (var_110) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple4 var_111 = var_27[var_99];
                    float var_112 = var_111.mem_0;
                    float var_113 = var_111.mem_1;
                    float var_114 = (var_84 / 256);
                    float var_115 = (var_113 - var_114);
                    var_96[var_99] = make_Tuple4(var_112, var_115);
                } else {
                }
                long long int var_116 = (var_99 + 1);
                var_97[0] = var_116;
            }
            long long int var_117 = var_97[0];
            float var_128[1];
            long long int var_129[1];
            var_129[0] = 0;
            while (method_66(var_129)) {
                long long int var_131 = var_129[0];
                long long int var_132 = (256 * var_131);
                long long int var_133 = (var_6 + var_132);
                long long int var_134 = (256 - var_132);
                char var_135 = (var_133 < 256);
                if (var_135) {
                    char var_136 = (var_131 >= 0);
                    char var_138;
                    if (var_136) {
                        var_138 = (var_131 < 1);
                    } else {
                        var_138 = 0;
                    }
                    char var_139 = (var_138 == 0);
                    if (var_139) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_141;
                    if (var_136) {
                        var_141 = (var_131 < 1);
                    } else {
                        var_141 = 0;
                    }
                    char var_142 = (var_141 == 0);
                    if (var_142) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple4 var_143 = var_96[var_131];
                    float var_144 = var_143.mem_0;
                    float var_145 = var_143.mem_1;
                    float var_146 = (var_145 * var_145);
                    var_128[var_131] = var_146;
                } else {
                }
                long long int var_147 = (var_131 + 1);
                var_129[0] = var_147;
            }
            long long int var_148 = var_129[0];
            float var_149 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_128);
            __shared__ float var_150[1];
            long long int var_151 = threadIdx.x;
            char var_152 = (var_151 == 0);
            if (var_152) {
                var_150[0] = var_149;
            } else {
            }
            __syncthreads();
            float var_153 = var_150[0];
            Tuple5 var_167[1];
            long long int var_168[1];
            var_168[0] = 0;
            while (method_66(var_168)) {
                long long int var_170 = var_168[0];
                long long int var_171 = (256 * var_170);
                long long int var_172 = (var_6 + var_171);
                long long int var_173 = (256 - var_171);
                char var_174 = (var_172 < 256);
                if (var_174) {
                    char var_175 = (var_170 >= 0);
                    char var_177;
                    if (var_175) {
                        var_177 = (var_170 < 1);
                    } else {
                        var_177 = 0;
                    }
                    char var_178 = (var_177 == 0);
                    if (var_178) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_180;
                    if (var_175) {
                        var_180 = (var_170 < 1);
                    } else {
                        var_180 = 0;
                    }
                    char var_181 = (var_180 == 0);
                    if (var_181) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple4 var_182 = var_96[var_170];
                    float var_183 = var_182.mem_0;
                    float var_184 = var_182.mem_1;
                    char var_185 = (var_184 > 0);
                    float var_186;
                    if (var_185) {
                        var_186 = var_183;
                    } else {
                        var_186 = 0;
                    }
                    float var_187 = (var_153 / 256);
                    float var_188 = sqrt(var_187);
                    var_167[var_170] = make_Tuple5(var_186, var_184, var_188);
                } else {
                }
                long long int var_189 = (var_170 + 1);
                var_168[0] = var_189;
            }
            long long int var_190 = var_168[0];
            float var_205[1];
            long long int var_206[1];
            var_206[0] = 0;
            while (method_66(var_206)) {
                long long int var_208 = var_206[0];
                long long int var_209 = (256 * var_208);
                long long int var_210 = (var_6 + var_209);
                long long int var_211 = (256 - var_209);
                char var_212 = (var_210 < 256);
                if (var_212) {
                    char var_213 = (var_208 >= 0);
                    char var_215;
                    if (var_213) {
                        var_215 = (var_208 < 1);
                    } else {
                        var_215 = 0;
                    }
                    char var_216 = (var_215 == 0);
                    if (var_216) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_218;
                    if (var_213) {
                        var_218 = (var_208 < 1);
                    } else {
                        var_218 = 0;
                    }
                    char var_219 = (var_218 == 0);
                    if (var_219) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_220 = var_167[var_208];
                    float var_221 = var_220.mem_0;
                    float var_222 = var_220.mem_1;
                    float var_223 = var_220.mem_2;
                    float var_224 = (-var_221);
                    float var_225 = (var_224 * var_222);
                    float var_226 = (var_223 * var_223);
                    float var_227 = (var_225 / var_226);
                    var_205[var_208] = var_227;
                } else {
                }
                long long int var_228 = (var_208 + 1);
                var_206[0] = var_228;
            }
            long long int var_229 = var_206[0];
            float var_230 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_205);
            __shared__ float var_231[1];
            long long int var_232 = threadIdx.x;
            char var_233 = (var_232 == 0);
            if (var_233) {
                var_231[0] = var_230;
            } else {
            }
            __syncthreads();
            float var_234 = var_231[0];
            float var_250[1];
            long long int var_251[1];
            var_251[0] = 0;
            while (method_66(var_251)) {
                long long int var_253 = var_251[0];
                long long int var_254 = (256 * var_253);
                long long int var_255 = (var_6 + var_254);
                long long int var_256 = (256 - var_254);
                char var_257 = (var_255 < 256);
                if (var_257) {
                    char var_258 = (var_253 >= 0);
                    char var_260;
                    if (var_258) {
                        var_260 = (var_253 < 1);
                    } else {
                        var_260 = 0;
                    }
                    char var_261 = (var_260 == 0);
                    if (var_261) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_263;
                    if (var_258) {
                        var_263 = (var_253 < 1);
                    } else {
                        var_263 = 0;
                    }
                    char var_264 = (var_263 == 0);
                    if (var_264) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_265 = var_167[var_253];
                    float var_266 = var_265.mem_0;
                    float var_267 = var_265.mem_1;
                    float var_268 = var_265.mem_2;
                    float var_269 = (var_266 / var_268);
                    float var_270 = (var_234 * var_267);
                    float var_271 = (var_268 * 256);
                    float var_272 = (var_270 / var_271);
                    float var_273 = (var_269 + var_272);
                    var_250[var_253] = var_273;
                } else {
                }
                long long int var_274 = (var_253 + 1);
                var_251[0] = var_274;
            }
            long long int var_275 = var_251[0];
            float var_276 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_250);
            __shared__ float var_277[1];
            long long int var_278 = threadIdx.x;
            char var_279 = (var_278 == 0);
            if (var_279) {
                var_277[0] = var_276;
            } else {
            }
            __syncthreads();
            float var_280 = var_277[0];
            long long int var_281[1];
            var_281[0] = 0;
            while (method_66(var_281)) {
                long long int var_283 = var_281[0];
                long long int var_284 = (256 * var_283);
                long long int var_285 = (var_6 + var_284);
                long long int var_286 = (256 - var_284);
                char var_287 = (var_285 < 256);
                if (var_287) {
                    char var_288 = (var_283 >= 0);
                    char var_290;
                    if (var_288) {
                        var_290 = (var_283 < 1);
                    } else {
                        var_290 = 0;
                    }
                    char var_291 = (var_290 == 0);
                    if (var_291) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_292 = var_250[var_283];
                    char var_293 = (var_12 >= 0);
                    char var_295;
                    if (var_293) {
                        var_295 = (var_12 < 1);
                    } else {
                        var_295 = 0;
                    }
                    char var_296 = (var_295 == 0);
                    if (var_296) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_297 = (var_12 * 256);
                    char var_298 = (var_285 >= 0);
                    char var_299 = (var_298 == 0);
                    if (var_299) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_300 = (var_297 + var_285);
                    float var_301 = var_2[var_300];
                    float var_302 = (var_301 + var_292);
                    float var_303 = (var_280 / 256);
                    float var_304 = (var_302 - var_303);
                    var_2[var_300] = var_304;
                } else {
                }
                long long int var_305 = (var_283 + 1);
                var_281[0] = var_305;
            }
            long long int var_306 = var_281[0];
            long long int var_307 = (var_12 + 1);
            var_10[0] = var_307;
        }
        long long int var_308 = var_10[0];
    }
    __global__ void method_80(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_65(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 256);
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
                var_14 = (var_8 < 256);
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
            long long int var_18 = (var_16 + var_17);
            float var_19 = 0;
            long long int var_20[1];
            float var_21[1];
            var_20[0] = var_18;
            var_21[0] = var_19;
            while (method_81(var_20, var_21)) {
                long long int var_23 = var_20[0];
                float var_24 = var_21[0];
                char var_25 = (var_23 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_23 < 1);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_23 * 256);
                char var_31;
                if (var_9) {
                    var_31 = (var_8 < 256);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_8);
                float var_34 = var_0[var_33];
                float var_35 = (var_24 + var_34);
                long long int var_36 = (var_23 + 1);
                var_20[0] = var_36;
                var_21[0] = var_35;
            }
            long long int var_37 = var_20[0];
            float var_38 = var_21[0];
            long long int var_39 = threadIdx.x;
            long long int var_40 = threadIdx.y;
            float var_41 = var_1[var_8];
            float var_42 = (var_38 + var_41);
            var_1[var_8] = var_42;
            long long int var_43 = (var_8 + 256);
            var_6[0] = var_43;
        }
        long long int var_44 = var_6[0];
    }
    __global__ void method_104(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_97(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 192);
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
                var_14 = (var_8 < 192);
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
            long long int var_18 = (var_16 + var_17);
            float var_19 = 0;
            long long int var_20[1];
            float var_21[1];
            var_20[0] = var_18;
            var_21[0] = var_19;
            while (method_81(var_20, var_21)) {
                long long int var_23 = var_20[0];
                float var_24 = var_21[0];
                char var_25 = (var_23 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_23 < 1);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_23 * 192);
                char var_31;
                if (var_9) {
                    var_31 = (var_8 < 192);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_8);
                float var_34 = var_0[var_33];
                float var_35 = (var_24 + var_34);
                long long int var_36 = (var_23 + 1);
                var_20[0] = var_36;
                var_21[0] = var_35;
            }
            long long int var_37 = var_20[0];
            float var_38 = var_21[0];
            long long int var_39 = threadIdx.x;
            long long int var_40 = threadIdx.y;
            float var_41 = var_1[var_8];
            float var_42 = (var_38 + var_41);
            var_1[var_8] = var_42;
            long long int var_43 = (var_8 + 192);
            var_6[0] = var_43;
        }
        long long int var_44 = var_6[0];
    }
    __device__ char method_65(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 256);
    }
    __device__ char method_142(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 39936);
    }
    __device__ char method_146(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 65536);
    }
    __device__ char method_97(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 192);
    }
    __device__ char method_153(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 49152);
    }
    __device__ char method_66(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_110(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 3);
    }
    __device__ float method_111(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_56(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 156);
    }
    __device__ char method_118(long long int * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        long long int var_5 = var_2[0];
        return (var_3 < 3);
    }
    __device__ Tuple1 method_119(Tuple1 var_0, Tuple1 var_1) {
        float var_2 = var_0.mem_0;
        long long int var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        long long int var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple1 var_7;
        if (var_6) {
            var_7 = make_Tuple1(var_2, var_3);
        } else {
            var_7 = make_Tuple1(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        long long int var_9 = var_7.mem_1;
        return make_Tuple1(var_8, var_9);
    }
    __device__ char method_81(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1);
    }
}
"""

type EnvStack0 =
    struct
    val mem_0: System.Random
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap1 =
    {
    mem_0: ManagedCuda.CudaContext
    }
and Env2 =
    struct
    val mem_0: uint64
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
    val mem_0: Env26
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack5 =
    struct
    val mem_0: ResizeArray<Env4>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap6 =
    {
    mem_0: EnvStack3
    mem_1: (uint64 ref)
    mem_2: uint64
    mem_3: EnvStack5
    }
and EnvHeap7 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: EnvHeap6
    }
and EnvHeap8 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaRand.CudaRandDevice
    mem_2: EnvHeap6
    }
and EnvHeap9 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvHeap6
    }
and Env10 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env26
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack11 =
    struct
    val mem_0: ResizeArray<Env10>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap12 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack11
    mem_4: EnvHeap6
    }
and Env13 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env17
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack14 =
    struct
    val mem_0: ResizeArray<Env13>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap15 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack11
    mem_4: EnvStack14
    mem_5: EnvHeap6
    }
and EnvHeap16 =
    {
    mem_0: ManagedCuda.CudaEvent
    mem_1: (bool ref)
    mem_2: ManagedCuda.CudaStream
    }
and Env17 =
    struct
    val mem_0: EnvHeap16
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap18 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack11
    mem_4: EnvStack14
    mem_5: EnvHeap6
    mem_6: (int64 ref)
    mem_7: EnvHeap16
    }
and EnvStack19 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack20 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap21 =
    {
    mem_0: (int64 ref)
    mem_1: (uint64 ref)
    mem_2: (int64 ref)
    mem_3: (uint64 ref)
    mem_4: (int64 ref)
    mem_5: (uint64 ref)
    mem_6: (int64 ref)
    mem_7: (uint64 ref)
    }
and EnvStack22 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap23 =
    {
    mem_0: (int64 ref)
    mem_1: (uint64 ref)
    mem_2: (int64 ref)
    mem_3: (uint64 ref)
    mem_4: (int64 ref)
    mem_5: (uint64 ref)
    mem_6: (int64 ref)
    mem_7: (uint64 ref)
    }
and EnvStack24 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack25 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env26 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env27 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap28 =
    {
    mem_0: EnvHeap21
    mem_1: EnvHeap23
    mem_2: (int64 ref)
    mem_3: (uint64 ref)
    mem_4: (int64 ref)
    mem_5: (uint64 ref)
    mem_6: (int64 ref)
    mem_7: (uint64 ref)
    mem_8: (int64 ref)
    mem_9: (uint64 ref)
    mem_10: EnvHeap18
    mem_11: ManagedCuda.BasicTypes.CUmodule
    }
and Tuple29 =
    struct
    val mem_0: Env30
    val mem_1: Env30
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env30 =
    struct
    val mem_0: int64
    val mem_1: string
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env31 =
    struct
    val mem_0: Union32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union32 =
    | Union32Case0
    | Union32Case1
    | Union32Case2
    | Union32Case3
    | Union32Case4
    | Union32Case5
    | Union32Case6
    | Union32Case7
    | Union32Case8
    | Union32Case9
    | Union32Case10
    | Union32Case11
    | Union32Case12
and Tuple33 =
    struct
    val mem_0: Env34
    val mem_1: Env36
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env34 =
    struct
    val mem_0: int64
    val mem_1: Union35
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Union35 =
    | Union35Case0 of Tuple44
    | Union35Case1
and Env36 =
    struct
    val mem_0: (Env31 [])
    val mem_1: Env37
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Env37 =
    struct
    val mem_0: (Env31 [])
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple38 =
    struct
    val mem_0: Env39
    val mem_1: Env40
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env39 =
    struct
    val mem_0: int64
    val mem_1: Union35
    val mem_2: string
    val mem_3: int64
    val mem_4: EnvHeap28
    val mem_5: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4, arg_mem_5) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4; mem_5 = arg_mem_5}
    end
and Env40 =
    struct
    val mem_0: int64
    val mem_1: Union35
    val mem_2: string
    val mem_3: int64
    val mem_4: Env41
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and Env41 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple42 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple43 =
    struct
    val mem_0: Union35
    val mem_1: Env36
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple44 =
    struct
    val mem_0: Env31
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union45 =
    | Union45Case0 of Tuple53
    | Union45Case1
and Tuple46 =
    struct
    val mem_0: Env47
    val mem_1: Env48
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env47 =
    struct
    val mem_0: int64
    val mem_1: Union35
    val mem_2: int64
    val mem_3: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Env48 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Union49 =
    | Union49Case0 of Tuple56
    | Union49Case1
and Tuple50 =
    struct
    val mem_0: Env34
    val mem_1: Env48
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple51 =
    struct
    val mem_0: Env34
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple52 =
    struct
    val mem_0: Env40
    val mem_1: Env39
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple53 =
    struct
    val mem_0: Tuple46
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack54 =
    struct
    val mem_0: Union55
    val mem_1: (unit -> unit)
    val mem_2: (unit -> unit)
    val mem_3: (unit -> unit)
    val mem_4: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and Union55 =
    | Union55Case0
    | Union55Case1
    | Union55Case2
and Tuple56 =
    struct
    val mem_0: Tuple50
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack57 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack58 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    val mem_4: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and EnvStack59 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    val mem_4: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and EnvStack60 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    val mem_4: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and EnvStack61 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack62 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack63 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    System.Console.WriteLine(var_1)
and method_1((var_0: EnvHeap7), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap6) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack3) = var_2.mem_0
    let (var_6: EnvStack5) = var_2.mem_3
    let (var_7: ResizeArray<Env4>) = var_6.mem_0
    let (var_9: (Env4 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env4 -> (Env4 -> int32))) = method_3
    let (var_13: System.Comparison<Env4>) = System.Comparison<Env4>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env2>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack3), (var_6: EnvStack5), (var_15: int32), (var_16: uint64), (var_17: int32))
    let (var_19: uint64) = method_5((var_3: (uint64 ref)))
    let (var_20: uint64) = (var_19 + var_4)
    let (var_21: uint64) = (var_20 - var_18)
    let (var_22: uint64) = (var_18 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_18)
    let (var_26: bool) = (var_21 > var_25)
    if var_26 then
        let (var_27: uint64) = (var_21 - var_25)
        var_14.Add((Env2(var_24, var_27)))
    else
        ()
and method_7((var_0: EnvHeap16), (var_1: EnvHeap15), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env13 =
    let (var_3: (int64 ref)) = (ref 0L)
    let (var_4: EnvStack14) = var_1.mem_4
    method_8((var_3: (int64 ref)), (var_0: EnvHeap16), (var_4: EnvStack14))
    (Env13(var_3, (Env17(var_0))))
and method_9((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack19 =
    let (var_2: Env10) = method_10((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env26) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_17((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack19((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_19((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack19 =
    let (var_4: Env10) = method_10((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_20((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack19((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_21((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack20 =
    let (var_2: Env10) = method_22((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env26) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    let (var_6: (int64 ref)) = var_0.mem_6
    let (var_7: EnvHeap16) = var_0.mem_7
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_18((var_7: EnvHeap16))
    let (var_9: ManagedCuda.CudaContext) = var_0.mem_0
    method_23((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_9: ManagedCuda.CudaContext), (var_8: ManagedCuda.BasicTypes.CUstream))
    EnvStack20((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_24((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack20 =
    let (var_4: Env10) = method_22((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_23((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack20((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_25((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_2: Env10) = method_26((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env26) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_27((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack22((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_28((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_4: Env10) = method_26((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_29((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack22((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_30((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack24 =
    let (var_2: Env10) = method_31((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env26) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_32((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack24((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_33((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack24 =
    let (var_4: Env10) = method_31((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_34((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack24((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_35((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_2: Env10) = method_36((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env26) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    let (var_6: (int64 ref)) = var_0.mem_6
    let (var_7: EnvHeap16) = var_0.mem_7
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_18((var_7: EnvHeap16))
    let (var_9: ManagedCuda.CudaContext) = var_0.mem_0
    method_37((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_9: ManagedCuda.CudaContext), (var_8: ManagedCuda.BasicTypes.CUstream))
    EnvStack25((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_38((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_4: Env10) = method_36((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_37((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack25((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_39 ((var_0: float)): unit =
    ()
and method_40((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (float -> unit)), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: int64)): unit =
    let (var_16: bool) = (var_15 < 10L)
    if var_16 then
        let (var_17: string) = System.String.Format("iteration {0}",var_15)
        let (var_18: string) = System.String.Format("Starting timing for: {0}",var_17)
        System.Console.WriteLine(var_18)
        let (var_19: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
        let (var_20: int64) = 0L
        let (var_21: int64) = 0L
        let (var_22: int64) = 0L
        let (var_23: Env27) = method_41((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (float -> unit)), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_20: int64), (var_21: int64), (var_22: int64))
        let (var_24: int64) = var_23.mem_0
        let (var_25: int64) = var_23.mem_1
        let (var_26: int64) = (var_24 + var_25)
        let (var_27: string) = System.String.Format("Winrate is {0} and {1} out of {2}.",var_24,var_25,var_26)
        System.Console.WriteLine(var_27)
        let (var_28: System.TimeSpan) = var_19.Elapsed
        let (var_29: string) = System.String.Format("The time was {0} for: {1}",var_28,var_17)
        System.Console.WriteLine(var_29)
        let (var_30: int64) = (var_15 + 1L)
        method_40((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (float -> unit)), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_30: int64))
    else
        ()
and method_156((var_0: EnvStack14)): unit =
    let (var_1: ResizeArray<Env13>) = var_0.mem_0
    let (var_3: (Env13 -> unit)) = method_157
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_154((var_0: EnvStack11)): unit =
    let (var_1: ResizeArray<Env10>) = var_0.mem_0
    let (var_3: (Env10 -> unit)) = method_155
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
and method_2 ((var_0: Env4)): bool =
    let (var_1: Env26) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: uint64) = (!var_2)
    (var_4 = 0UL)
and method_3 ((var_0: Env4)): (Env4 -> int32) =
    let (var_1: Env26) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    method_4((var_2: (uint64 ref)))
and method_6((var_0: EnvStack3), (var_1: EnvStack5), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env4>) = var_1.mem_0
        let (var_7: Env4) = var_6.[var_4]
        let (var_8: Env26) = var_7.mem_0
        let (var_9: (uint64 ref)) = var_8.mem_0
        let (var_10: uint64) = var_7.mem_1
        let (var_11: uint64) = method_5((var_9: (uint64 ref)))
        let (var_12: bool) = (var_11 >= var_3)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_14: uint64) = method_5((var_9: (uint64 ref)))
        let (var_15: uint64) = (var_14 - var_3)
        let (var_16: uint64) = (var_3 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_3)
        let (var_20: bool) = (var_15 > var_19)
        if var_20 then
            let (var_21: ResizeArray<Env2>) = var_0.mem_0
            let (var_22: uint64) = (var_15 - var_19)
            var_21.Add((Env2(var_18, var_22)))
        else
            ()
        let (var_23: uint64) = (var_14 + var_10)
        let (var_24: int32) = (var_4 + 1)
        method_6((var_0: EnvStack3), (var_1: EnvStack5), (var_2: int32), (var_23: uint64), (var_24: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: EnvHeap16), (var_2: EnvStack14)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env13>) = var_2.mem_0
    var_5.Add((Env13(var_0, (Env17(var_1)))))
and method_10((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 159744L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_17((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(39936L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.049266f)
and method_18((var_0: EnvHeap16)): ManagedCuda.BasicTypes.CUstream =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_4: ManagedCuda.CudaStream) = var_0.mem_2
    var_4.Stream
and method_20((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(159744L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_22((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 1024L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_23((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_26((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 262144L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_27((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.044194f)
and method_29((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(262144L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_31((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 196608L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_32((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(49152L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.066815f)
and method_34((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(196608L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_36((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 768L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_37((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(768L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_41((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (float -> unit)), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: int64), (var_16: int64), (var_17: int64)): Env27 =
    let (var_18: bool) = (var_17 < 1000L)
    if var_18 then
        method_15((var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        let (var_25: ResizeArray<Env10>) = ResizeArray<Env10>()
        let (var_26: EnvStack11) = EnvStack11((var_25: ResizeArray<Env10>))
        let (var_27: ManagedCuda.CudaContext) = var_13.mem_0
        let (var_28: ManagedCuda.CudaBlas.CudaBlas) = var_13.mem_1
        let (var_29: ManagedCuda.CudaRand.CudaRandDevice) = var_13.mem_2
        let (var_30: EnvStack11) = var_13.mem_3
        let (var_31: EnvStack14) = var_13.mem_4
        let (var_32: EnvHeap6) = var_13.mem_5
        let (var_33: (int64 ref)) = var_13.mem_6
        let (var_34: EnvHeap16) = var_13.mem_7
        let (var_35: EnvHeap18) = ({mem_0 = (var_27: ManagedCuda.CudaContext); mem_1 = (var_28: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_29: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_26: EnvStack11); mem_4 = (var_31: EnvStack14); mem_5 = (var_32: EnvHeap6); mem_6 = (var_33: (int64 ref)); mem_7 = (var_34: EnvHeap16)} : EnvHeap18)
        let (var_36: EnvHeap28) = ({mem_0 = (var_0: EnvHeap21); mem_1 = (var_1: EnvHeap23); mem_2 = (var_2: (int64 ref)); mem_3 = (var_3: (uint64 ref)); mem_4 = (var_4: (int64 ref)); mem_5 = (var_5: (uint64 ref)); mem_6 = (var_6: (int64 ref)); mem_7 = (var_7: (uint64 ref)); mem_8 = (var_8: (int64 ref)); mem_9 = (var_9: (uint64 ref)); mem_10 = (var_35: EnvHeap18); mem_11 = (var_14: ManagedCuda.BasicTypes.CUmodule)} : EnvHeap28)
        let (var_37: int64) = 10L
        let (var_38: string) = "One"
        let (var_39: int64) = 10L
        let (var_40: string) = "Two"
        let (var_41: Tuple29) = method_42((var_12: EnvStack0), (var_37: int64), (var_38: string), (var_36: EnvHeap28), (var_10: (float -> unit)), (var_39: int64), (var_40: string), (var_11: EnvStack0))
        let (var_42: Env30) = var_41.mem_0
        let (var_43: int64) = var_42.mem_0
        let (var_44: string) = var_42.mem_1
        let (var_45: Env30) = var_41.mem_1
        let (var_46: int64) = var_45.mem_0
        let (var_47: string) = var_45.mem_1
        let (var_48: (int64 ref)) = var_0.mem_0
        let (var_49: (uint64 ref)) = var_0.mem_1
        let (var_50: (int64 ref)) = var_0.mem_2
        let (var_51: (uint64 ref)) = var_0.mem_3
        let (var_52: (int64 ref)) = var_0.mem_4
        let (var_53: (uint64 ref)) = var_0.mem_5
        let (var_54: (int64 ref)) = var_0.mem_6
        let (var_55: (uint64 ref)) = var_0.mem_7
        method_136((var_50: (int64 ref)), (var_51: (uint64 ref)), (var_48: (int64 ref)), (var_49: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        method_139((var_54: (int64 ref)), (var_55: (uint64 ref)), (var_52: (int64 ref)), (var_53: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        let (var_56: (int64 ref)) = var_1.mem_0
        let (var_57: (uint64 ref)) = var_1.mem_1
        let (var_58: (int64 ref)) = var_1.mem_2
        let (var_59: (uint64 ref)) = var_1.mem_3
        let (var_60: (int64 ref)) = var_1.mem_4
        let (var_61: (uint64 ref)) = var_1.mem_5
        let (var_62: (int64 ref)) = var_1.mem_6
        let (var_63: (uint64 ref)) = var_1.mem_7
        method_136((var_58: (int64 ref)), (var_59: (uint64 ref)), (var_56: (int64 ref)), (var_57: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        method_143((var_62: (int64 ref)), (var_63: (uint64 ref)), (var_60: (int64 ref)), (var_61: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        method_147((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        method_150((var_8: (int64 ref)), (var_9: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_35: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule))
        let (var_64: bool) = (var_44 = "One")
        let (var_73: Env27) =
            if var_64 then
                let (var_65: bool) = (var_43 > 0L)
                if var_65 then
                    let (var_66: int64) = (var_15 + 1L)
                    (Env27(var_66, var_16))
                else
                    let (var_67: int64) = (var_16 + 1L)
                    (Env27(var_15, var_67))
            else
                let (var_69: bool) = (var_43 > 0L)
                if var_69 then
                    let (var_70: int64) = (var_16 + 1L)
                    (Env27(var_15, var_70))
                else
                    let (var_71: int64) = (var_15 + 1L)
                    (Env27(var_71, var_16))
        let (var_74: int64) = var_73.mem_0
        let (var_75: int64) = var_73.mem_1
        let (var_76: EnvStack11) = var_35.mem_3
        method_154((var_76: EnvStack11))
        let (var_77: int64) = (var_17 + 1L)
        method_41((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (float -> unit)), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: EnvHeap18), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_74: int64), (var_75: int64), (var_77: int64))
    else
        (Env27(var_15, var_16))
and method_157 ((var_0: Env13)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env17) = var_0.mem_1
    let (var_3: EnvHeap16) = var_2.mem_0
    let (var_4: int64) = (!var_1)
    let (var_5: int64) = (var_4 - 1L)
    var_1 := var_5
    let (var_6: int64) = (!var_1)
    let (var_7: bool) = (var_6 = 0L)
    if var_7 then
        let (var_8: ManagedCuda.CudaStream) = var_3.mem_2
        var_8.Dispose()
        let (var_9: ManagedCuda.CudaEvent) = var_3.mem_0
        var_9.Dispose()
        let (var_10: (bool ref)) = var_3.mem_1
        var_10 := false
    else
        ()
and method_155 ((var_0: Env10)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env26) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_2.mem_0
    let (var_4: int64) = (!var_1)
    let (var_5: int64) = (var_4 - 1L)
    var_1 := var_5
    let (var_6: int64) = (!var_1)
    let (var_7: bool) = (var_6 = 0L)
    if var_7 then
        var_3 := 0UL
    else
        ()
and method_4 ((var_1: (uint64 ref))) ((var_0: Env4)): int32 =
    let (var_2: Env26) = var_0.mem_0
    let (var_3: (uint64 ref)) = var_2.mem_0
    let (var_4: uint64) = var_0.mem_1
    let (var_5: uint64) = method_5((var_1: (uint64 ref)))
    let (var_6: uint64) = method_5((var_3: (uint64 ref)))
    let (var_7: bool) = (var_5 < var_6)
    if var_7 then
        -1
    else
        let (var_8: bool) = (var_5 = var_6)
        if var_8 then
            0
        else
            1
and method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64)): Env10 =
    let (var_3: uint64) = (uint64 var_2)
    let (var_4: uint64) = (var_3 + 256UL)
    let (var_5: uint64) = (var_4 - 1UL)
    let (var_6: uint64) = (var_5 &&& 18446744073709551360UL)
    let (var_7: Env26) = method_12((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_6: uint64))
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: (int64 ref)) = (ref 0L)
    let (var_10: EnvStack11) = var_0.mem_3
    method_16((var_9: (int64 ref)), (var_8: (uint64 ref)), (var_10: EnvStack11))
    (Env10(var_9, (Env26(var_8))))
and method_15((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap6) = var_0.mem_5
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack3) = var_2.mem_0
    let (var_6: EnvStack5) = var_2.mem_3
    let (var_7: ResizeArray<Env4>) = var_6.mem_0
    let (var_9: (Env4 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env4 -> (Env4 -> int32))) = method_3
    let (var_13: System.Comparison<Env4>) = System.Comparison<Env4>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env2>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack3), (var_6: EnvStack5), (var_15: int32), (var_16: uint64), (var_17: int32))
    let (var_19: uint64) = method_5((var_3: (uint64 ref)))
    let (var_20: uint64) = (var_19 + var_4)
    let (var_21: uint64) = (var_20 - var_18)
    let (var_22: uint64) = (var_18 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_18)
    let (var_26: bool) = (var_21 > var_25)
    if var_26 then
        let (var_27: uint64) = (var_21 - var_25)
        var_14.Add((Env2(var_24, var_27)))
    else
        ()
and method_42((var_0: EnvStack0), (var_1: int64), (var_2: string), (var_3: EnvHeap28), (var_4: (float -> unit)), (var_5: int64), (var_6: string), (var_7: EnvStack0)): Tuple29 =
    let (var_9: (Env31 [])) = [|(Env31(Union32Case12)); (Env31(Union32Case11)); (Env31(Union32Case3)); (Env31(Union32Case2)); (Env31(Union32Case9)); (Env31(Union32Case8)); (Env31(Union32Case1)); (Env31(Union32Case6)); (Env31(Union32Case10)); (Env31(Union32Case4)); (Env31(Union32Case7)); (Env31(Union32Case5)); (Env31(Union32Case0))|]
    let (var_10: int64) = var_9.LongLength
    let (var_11: bool) = (var_10 = 13L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_43((var_9: (Env31 [])), (var_0: EnvStack0))
    let (var_13: int64) = 13L
    let (var_14: Tuple33) = method_45((var_1: int64), (var_9: (Env31 [])), (var_13: int64), (var_2: string))
    let (var_15: Env34) = var_14.mem_0
    let (var_16: int64) = var_15.mem_0
    let (var_17: Union35) = var_15.mem_1
    let (var_18: int64) = var_15.mem_2
    let (var_19: Env36) = var_14.mem_1
    let (var_20: (Env31 [])) = var_19.mem_0
    let (var_21: Env37) = var_19.mem_1
    let (var_22: (Env31 [])) = var_21.mem_0
    let (var_23: int64) = var_19.mem_2
    let (var_24: Tuple33) = method_46((var_5: int64), (var_20: (Env31 [])), (var_22: (Env31 [])), (var_23: int64), (var_6: string))
    let (var_25: Env34) = var_24.mem_0
    let (var_26: int64) = var_25.mem_0
    let (var_27: Union35) = var_25.mem_1
    let (var_28: int64) = var_25.mem_2
    let (var_29: Env36) = var_24.mem_1
    let (var_30: (Env31 [])) = var_29.mem_0
    let (var_31: Env37) = var_29.mem_1
    let (var_32: (Env31 [])) = var_31.mem_0
    let (var_33: int64) = var_29.mem_2
    let (var_34: bool) = (var_16 > 0L)
    let (var_39: bool) =
        if var_34 then
            match var_17 with
            | Union35Case0(var_35) ->
                let (var_36: Env31) = var_35.mem_0
                let (var_37: Union32) = var_36.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_42: int64) =
        if var_39 then
            let (var_40: bool) = (0L > var_18)
            if var_40 then
                0L
            else
                var_18
        else
            0L
    let (var_43: bool) = (var_26 > 0L)
    let (var_48: bool) =
        if var_43 then
            match var_27 with
            | Union35Case0(var_44) ->
                let (var_45: Env31) = var_44.mem_0
                let (var_46: Union32) = var_45.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_51: int64) =
        if var_48 then
            let (var_49: bool) = (var_42 > var_28)
            if var_49 then
                var_42
            else
                var_28
        else
            var_42
    let (var_56: bool) =
        if var_34 then
            match var_17 with
            | Union35Case0(var_52) ->
                let (var_53: Env31) = var_52.mem_0
                let (var_54: Union32) = var_53.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_57: int64) =
        if var_56 then
            1L
        else
            0L
    let (var_62: bool) =
        if var_43 then
            match var_27 with
            | Union35Case0(var_58) ->
                let (var_59: Env31) = var_58.mem_0
                let (var_60: Union32) = var_59.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_64: int64) =
        if var_62 then
            (var_57 + 1L)
        else
            var_57
    let (var_65: int64) = 2L
    let (var_66: int64) = 0L
    let (var_67: Tuple38) = method_47((var_51: int64), (var_65: int64), (var_64: int64), (var_66: int64), (var_16: int64), (var_17: Union35), (var_2: string), (var_18: int64), (var_3: EnvHeap28), (var_4: (float -> unit)), (var_26: int64), (var_27: Union35), (var_6: string), (var_28: int64), (var_7: EnvStack0))
    let (var_68: Env39) = var_67.mem_0
    let (var_69: int64) = var_68.mem_0
    let (var_70: Union35) = var_68.mem_1
    let (var_71: string) = var_68.mem_2
    let (var_72: int64) = var_68.mem_3
    let (var_73: EnvHeap28) = var_68.mem_4
    let (var_74: (float -> unit)) = var_68.mem_5
    let (var_75: Env40) = var_67.mem_1
    let (var_76: int64) = var_75.mem_0
    let (var_77: Union35) = var_75.mem_1
    let (var_78: string) = var_75.mem_2
    let (var_79: int64) = var_75.mem_3
    let (var_80: Env41) = var_75.mem_4
    let (var_81: EnvStack0) = var_80.mem_0
    method_127((var_69: int64), (var_70: Union35), (var_71: string), (var_72: int64), (var_73: EnvHeap28), (var_74: (float -> unit)))
    method_129((var_76: int64), (var_77: Union35), (var_78: string), (var_79: int64), (var_81: EnvStack0))
    let (var_82: int64) = (var_69 + var_72)
    let (var_83: int64) = (var_76 + var_79)
    let (var_84: Tuple42) = method_130((var_69: int64), (var_70: Union35), (var_72: int64), (var_76: int64), (var_77: Union35), (var_79: int64))
    let (var_85: int64) = var_84.mem_0
    let (var_86: int64) = var_84.mem_1
    let (var_87: int64) = (var_85 - var_82)
    let (var_88: int64) = (var_86 - var_83)
    method_132((var_69: int64), (var_70: Union35), (var_71: string), (var_72: int64), (var_73: EnvHeap28), (var_74: (float -> unit)), (var_87: int64))
    method_133((var_76: int64), (var_77: Union35), (var_78: string), (var_79: int64), (var_81: EnvStack0), (var_88: int64))
    let (var_89: bool) = (var_85 > 0L)
    let (var_90: int64) =
        if var_89 then
            1L
        else
            0L
    let (var_91: bool) = (var_86 > 0L)
    let (var_93: int64) =
        if var_91 then
            (var_90 + 1L)
        else
            var_90
    let (var_94: bool) = (var_93 = 1L)
    if var_94 then
        Tuple29((Env30(var_85, var_2)), (Env30(var_86, var_6)))
    else
        method_134((var_0: EnvStack0), (var_86: int64), (var_6: string), (var_7: EnvStack0), (var_85: int64), (var_2: string), (var_3: EnvHeap28), (var_4: (float -> unit)))
and method_136((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_137((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_139((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_140((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_143((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_144((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_147((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_148((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_150((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_151((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_12((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: uint64)): Env26 =
    let (var_3: EnvHeap6) = var_0.mem_5
    let (var_4: (uint64 ref)) = var_3.mem_1
    let (var_5: uint64) = var_3.mem_2
    let (var_6: EnvStack5) = var_3.mem_3
    let (var_7: EnvStack3) = var_3.mem_0
    let (var_8: ResizeArray<Env2>) = var_7.mem_0
    let (var_9: int32) = var_8.get_Count()
    let (var_10: bool) = (var_9 > 0)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_12: Env2) = var_8.[0]
    let (var_13: uint64) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: bool) = (var_2 <= var_14)
    let (var_42: Env4) =
        if var_15 then
            let (var_16: uint64) = (var_13 + var_2)
            let (var_17: uint64) = (var_14 - var_2)
            var_8.[0] <- (Env2(var_16, var_17))
            let (var_18: (uint64 ref)) = (ref var_13)
            (Env4((Env26(var_18)), var_2))
        else
            let (var_20: (Env2 -> (Env2 -> int32))) = method_13
            let (var_21: System.Comparison<Env2>) = System.Comparison<Env2>(var_20)
            var_8.Sort(var_21)
            let (var_22: Env2) = var_8.[0]
            let (var_23: uint64) = var_22.mem_0
            let (var_24: uint64) = var_22.mem_1
            let (var_25: bool) = (var_2 <= var_24)
            if var_25 then
                let (var_26: uint64) = (var_23 + var_2)
                let (var_27: uint64) = (var_24 - var_2)
                var_8.[0] <- (Env2(var_26, var_27))
                let (var_28: (uint64 ref)) = (ref var_23)
                (Env4((Env26(var_28)), var_2))
            else
                method_15((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
                let (var_30: (Env2 -> (Env2 -> int32))) = method_13
                let (var_31: System.Comparison<Env2>) = System.Comparison<Env2>(var_30)
                var_8.Sort(var_31)
                let (var_32: Env2) = var_8.[0]
                let (var_33: uint64) = var_32.mem_0
                let (var_34: uint64) = var_32.mem_1
                let (var_35: bool) = (var_2 <= var_34)
                if var_35 then
                    let (var_36: uint64) = (var_33 + var_2)
                    let (var_37: uint64) = (var_34 - var_2)
                    var_8.[0] <- (Env2(var_36, var_37))
                    let (var_38: (uint64 ref)) = (ref var_33)
                    (Env4((Env26(var_38)), var_2))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_43: Env26) = var_42.mem_0
    let (var_44: (uint64 ref)) = var_43.mem_0
    let (var_45: uint64) = var_42.mem_1
    let (var_46: ResizeArray<Env4>) = var_6.mem_0
    var_46.Add((Env4((Env26(var_44)), var_45)))
    (Env26(var_44))
and method_16((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack11)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env10>) = var_2.mem_0
    var_5.Add((Env10(var_0, (Env26(var_1)))))
and method_43((var_0: (Env31 [])), (var_1: EnvStack0)): unit =
    //In Knuth shuffle
    let (var_2: int64) = 0L
    method_44((var_1: EnvStack0), (var_0: (Env31 [])), (var_2: int64))
and method_45((var_0: int64), (var_1: (Env31 [])), (var_2: int64), (var_3: string)): Tuple33 =
    //In dealing
    let (var_4: bool) = (var_0 > 1L)
    let (var_5: int64) =
        if var_4 then
            1L
        else
            var_0
    let (var_6: int64) = (var_0 - var_5)
    let (var_7: bool) = (var_5 > 0L)
    let (var_11: Tuple43) =
        if var_7 then
            let (var_8: int64) = (var_2 - 1L)
            let (var_9: Env31) = var_1.[int32 var_8]
            let (var_10: Union32) = var_9.mem_0
            Tuple43((Union35Case0(Tuple44((Env31(var_10))))), (Env36(var_1, (Env37(var_1)), var_8)))
        else
            Tuple43(Union35Case1, (Env36(var_1, (Env37(var_1)), var_2)))
    let (var_12: Union35) = var_11.mem_0
    let (var_13: Env36) = var_11.mem_1
    let (var_14: (Env31 [])) = var_13.mem_0
    let (var_15: Env37) = var_13.mem_1
    let (var_16: (Env31 [])) = var_15.mem_0
    let (var_17: int64) = var_13.mem_2
    Tuple33((Env34(var_6, var_12, var_5)), (Env36(var_14, (Env37(var_16)), var_17)))
and method_46((var_0: int64), (var_1: (Env31 [])), (var_2: (Env31 [])), (var_3: int64), (var_4: string)): Tuple33 =
    //In dealing
    let (var_5: bool) = (var_0 > 2L)
    let (var_6: int64) =
        if var_5 then
            2L
        else
            var_0
    let (var_7: int64) = (var_0 - var_6)
    let (var_8: bool) = (var_6 > 0L)
    let (var_12: Tuple43) =
        if var_8 then
            let (var_9: int64) = (var_3 - 1L)
            let (var_10: Env31) = var_1.[int32 var_9]
            let (var_11: Union32) = var_10.mem_0
            Tuple43((Union35Case0(Tuple44((Env31(var_11))))), (Env36(var_2, (Env37(var_2)), var_9)))
        else
            Tuple43(Union35Case1, (Env36(var_1, (Env37(var_2)), var_3)))
    let (var_13: Union35) = var_12.mem_0
    let (var_14: Env36) = var_12.mem_1
    let (var_15: (Env31 [])) = var_14.mem_0
    let (var_16: Env37) = var_14.mem_1
    let (var_17: (Env31 [])) = var_16.mem_0
    let (var_18: int64) = var_14.mem_2
    Tuple33((Env34(var_7, var_13, var_6)), (Env36(var_15, (Env37(var_17)), var_18)))
and method_47((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union35), (var_6: string), (var_7: int64), (var_8: EnvHeap28), (var_9: (float -> unit)), (var_10: int64), (var_11: Union35), (var_12: string), (var_13: int64), (var_14: EnvStack0)): Tuple38 =
    //In betting's loop.
    let (var_15: int64) = 0L
    let (var_16: bool) = (0L <> var_15)
    let (var_18: Env34) =
        if var_16 then
            let (var_17: Union35) = Union35Case1
            (Env34(var_4, var_17, var_7))
        else
            (Env34(var_4, var_5, var_7))
    let (var_19: int64) = var_18.mem_0
    let (var_20: Union35) = var_18.mem_1
    let (var_21: int64) = var_18.mem_2
    let (var_22: bool) = (1L <> var_15)
    let (var_24: Env34) =
        if var_22 then
            let (var_23: Union35) = Union35Case1
            (Env34(var_10, var_23, var_13))
        else
            (Env34(var_10, var_11, var_13))
    let (var_25: int64) = var_24.mem_0
    let (var_26: Union35) = var_24.mem_1
    let (var_27: int64) = var_24.mem_2
    let (var_28: Union45) = method_48((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_19: int64), (var_20: Union35), (var_21: int64), (var_25: int64), (var_26: Union35), (var_27: int64), (var_4: int64), (var_5: Union35), (var_6: string), (var_7: int64), (var_8: EnvHeap28), (var_9: (float -> unit)))
    match var_28 with
    | Union45Case0(var_29) ->
        let (var_30: Tuple46) = var_29.mem_0
        let (var_31: Env47) = var_30.mem_0
        let (var_32: int64) = var_31.mem_0
        let (var_33: Union35) = var_31.mem_1
        let (var_34: int64) = var_31.mem_2
        let (var_35: (float -> unit)) = var_31.mem_3
        let (var_36: Env48) = var_30.mem_1
        let (var_37: int64) = var_36.mem_0
        let (var_38: int64) = var_36.mem_1
        let (var_39: int64) = var_36.mem_2
        let (var_40: int64) = var_36.mem_3
        let (var_41: int64) = (var_15 + 1L)
        let (var_42: bool) = (0L <> var_41)
        let (var_44: Env34) =
            if var_42 then
                let (var_43: Union35) = Union35Case1
                (Env34(var_32, var_43, var_34))
            else
                (Env34(var_32, var_33, var_34))
        let (var_45: int64) = var_44.mem_0
        let (var_46: Union35) = var_44.mem_1
        let (var_47: int64) = var_44.mem_2
        let (var_48: bool) = (1L <> var_41)
        let (var_50: Env34) =
            if var_48 then
                let (var_49: Union35) = Union35Case1
                (Env34(var_10, var_49, var_13))
            else
                (Env34(var_10, var_11, var_13))
        let (var_51: int64) = var_50.mem_0
        let (var_52: Union35) = var_50.mem_1
        let (var_53: int64) = var_50.mem_2
        let (var_54: Union49) = method_126((var_37: int64), (var_38: int64), (var_39: int64), (var_40: int64), (var_45: int64), (var_46: Union35), (var_47: int64), (var_51: int64), (var_52: Union35), (var_53: int64), (var_10: int64), (var_11: Union35), (var_12: string), (var_13: int64), (var_14: EnvStack0))
        match var_54 with
        | Union49Case0(var_55) ->
            let (var_56: Tuple50) = var_55.mem_0
            let (var_57: Env34) = var_56.mem_0
            let (var_58: int64) = var_57.mem_0
            let (var_59: Union35) = var_57.mem_1
            let (var_60: int64) = var_57.mem_2
            let (var_61: Env48) = var_56.mem_1
            let (var_62: int64) = var_61.mem_0
            let (var_63: int64) = var_61.mem_1
            let (var_64: int64) = var_61.mem_2
            let (var_65: int64) = var_61.mem_3
            let (var_66: int64) = (var_41 + 1L)
            method_47((var_62: int64), (var_63: int64), (var_64: int64), (var_65: int64), (var_32: int64), (var_33: Union35), (var_6: string), (var_34: int64), (var_8: EnvHeap28), (var_35: (float -> unit)), (var_58: int64), (var_59: Union35), (var_12: string), (var_60: int64), (var_14: EnvStack0))
        | Union49Case1 ->
            Tuple38((Env39(var_32, var_33, var_6, var_34, var_8, var_35)), (Env40(var_10, var_11, var_12, var_13, (Env41(var_14)))))
    | Union45Case1 ->
        Tuple38((Env39(var_4, var_5, var_6, var_7, var_8, var_9)), (Env40(var_10, var_11, var_12, var_13, (Env41(var_14)))))
and method_127((var_0: int64), (var_1: Union35), (var_2: string), (var_3: int64), (var_4: EnvHeap28), (var_5: (float -> unit))): unit =
    //In showdown's card show.
    let (var_6: bool) = (var_3 > 0L)
    if var_6 then
        match var_1 with
        | Union35Case0(var_7) ->
            let (var_8: Env31) = var_7.mem_0
            let (var_9: Union32) = var_8.mem_0
            let (var_10: string) = method_128((var_9: Union32))
            ()
        | Union35Case1 ->
            ()
    else
        ()
and method_129((var_0: int64), (var_1: Union35), (var_2: string), (var_3: int64), (var_4: EnvStack0)): unit =
    //In showdown's card show.
    let (var_5: bool) = (var_3 > 0L)
    if var_5 then
        match var_1 with
        | Union35Case0(var_6) ->
            let (var_7: Env31) = var_6.mem_0
            let (var_8: Union32) = var_7.mem_0
            let (var_9: string) = method_128((var_8: Union32))
            ()
        | Union35Case1 ->
            ()
    else
        ()
and method_130((var_0: int64), (var_1: Union35), (var_2: int64), (var_3: int64), (var_4: Union35), (var_5: int64)): Tuple42 =
    //In showdown
    let (var_6: bool) = (var_2 > 0L)
    let (var_7: bool) = (var_5 > 0L)
    let (var_8: Union35) =
        if var_6 then
            var_1
        else
            Union35Case1
    let (var_25: Union35) =
        if var_7 then
            match var_8 with
            | Union35Case0(var_9) ->
                let (var_10: Env31) = var_9.mem_0
                let (var_11: Union32) = var_10.mem_0
                match var_4 with
                | Union35Case0(var_12) ->
                    let (var_13: Env31) = var_12.mem_0
                    let (var_14: Union32) = var_13.mem_0
                    let (var_15: int32) = method_131((var_11: Union32))
                    let (var_16: int32) = method_131((var_14: Union32))
                    let (var_17: bool) = (var_15 < var_16)
                    let (var_20: int32) =
                        if var_17 then
                            -1
                        else
                            let (var_18: bool) = (var_15 = var_16)
                            if var_18 then
                                0
                            else
                                1
                    let (var_21: bool) = (var_20 = 1)
                    if var_21 then
                        (Union35Case0(Tuple44((Env31(var_11)))))
                    else
                        (Union35Case0(Tuple44((Env31(var_14)))))
                | Union35Case1 ->
                    (Union35Case0(Tuple44((Env31(var_11)))))
            | Union35Case1 ->
                var_4
        else
            var_8
    match var_25 with
    | Union35Case0(var_26) ->
        let (var_27: Env31) = var_26.mem_0
        let (var_28: Union32) = var_27.mem_0
        let (var_29: int64) = System.Int64.MaxValue
        let (var_32: int64) =
            if var_6 then
                let (var_30: bool) = (var_29 > var_2)
                if var_30 then
                    var_2
                else
                    var_29
            else
                var_29
        let (var_35: int64) =
            if var_7 then
                let (var_33: bool) = (var_32 > var_5)
                if var_33 then
                    var_5
                else
                    var_32
            else
                var_32
        let (var_39: Tuple51) =
            if var_6 then
                let (var_36: bool) = (var_35 > var_2)
                let (var_37: int64) =
                    if var_36 then
                        var_2
                    else
                        var_35
                let (var_38: int64) = (var_2 - var_37)
                Tuple51((Env34(var_0, var_1, var_38)), var_37)
            else
                Tuple51((Env34(var_0, var_1, var_2)), 0L)
        let (var_40: Env34) = var_39.mem_0
        let (var_41: int64) = var_40.mem_0
        let (var_42: Union35) = var_40.mem_1
        let (var_43: int64) = var_40.mem_2
        let (var_44: int64) = var_39.mem_1
        let (var_49: Tuple51) =
            if var_7 then
                let (var_45: bool) = (var_35 > var_5)
                let (var_46: int64) =
                    if var_45 then
                        var_5
                    else
                        var_35
                let (var_47: int64) = (var_5 - var_46)
                let (var_48: int64) = (var_44 + var_46)
                Tuple51((Env34(var_3, var_4, var_47)), var_48)
            else
                Tuple51((Env34(var_3, var_4, var_5)), var_44)
        let (var_50: Env34) = var_49.mem_0
        let (var_51: int64) = var_50.mem_0
        let (var_52: Union35) = var_50.mem_1
        let (var_53: int64) = var_50.mem_2
        let (var_54: int64) = var_49.mem_1
        let (var_66: bool) =
            if var_6 then
                match var_42 with
                | Union35Case0(var_55) ->
                    let (var_56: Env31) = var_55.mem_0
                    let (var_57: Union32) = var_56.mem_0
                    let (var_58: int32) = method_131((var_28: Union32))
                    let (var_59: int32) = method_131((var_57: Union32))
                    let (var_60: bool) = (var_58 < var_59)
                    let (var_63: int32) =
                        if var_60 then
                            -1
                        else
                            let (var_61: bool) = (var_58 = var_59)
                            if var_61 then
                                0
                            else
                                1
                    (var_63 = 0)
                | Union35Case1 ->
                    false
            else
                false
        let (var_78: bool) =
            if var_7 then
                match var_52 with
                | Union35Case0(var_67) ->
                    let (var_68: Env31) = var_67.mem_0
                    let (var_69: Union32) = var_68.mem_0
                    let (var_70: int32) = method_131((var_28: Union32))
                    let (var_71: int32) = method_131((var_69: Union32))
                    let (var_72: bool) = (var_70 < var_71)
                    let (var_75: int32) =
                        if var_72 then
                            -1
                        else
                            let (var_73: bool) = (var_70 = var_71)
                            if var_73 then
                                0
                            else
                                1
                    (var_75 = 0)
                | Union35Case1 ->
                    false
            else
                false
        let (var_79: int64) =
            if var_66 then
                1L
            else
                0L
        let (var_81: int64) =
            if var_78 then
                (var_79 + 1L)
            else
                var_79
        let (var_82: int64) = (var_54 % var_81)
        let (var_83: bool) = (var_82 <> 0L)
        let (var_84: int64) = (var_54 / var_81)
        let (var_86: Tuple51) =
            if var_66 then
                let (var_85: int64) = (var_41 + var_84)
                Tuple51((Env34(var_85, var_42, var_43)), 1L)
            else
                Tuple51((Env34(var_41, var_42, var_43)), 0L)
        let (var_87: Env34) = var_86.mem_0
        let (var_88: int64) = var_87.mem_0
        let (var_89: Union35) = var_87.mem_1
        let (var_90: int64) = var_87.mem_2
        let (var_91: int64) = var_86.mem_1
        let (var_95: Tuple51) =
            if var_78 then
                let (var_92: int64) =
                    if var_83 then
                        var_91
                    else
                        0L
                let (var_93: int64) = (var_51 + var_84)
                let (var_94: int64) = (var_93 + var_92)
                Tuple51((Env34(var_94, var_52, var_53)), 1L)
            else
                Tuple51((Env34(var_51, var_52, var_53)), var_91)
        let (var_96: Env34) = var_95.mem_0
        let (var_97: int64) = var_96.mem_0
        let (var_98: Union35) = var_96.mem_1
        let (var_99: int64) = var_96.mem_2
        let (var_100: int64) = var_95.mem_1
        method_130((var_88: int64), (var_89: Union35), (var_90: int64), (var_97: int64), (var_98: Union35), (var_99: int64))
    | Union35Case1 ->
        let (var_102: int64) = (var_0 + var_2)
        let (var_103: int64) = (var_3 + var_5)
        Tuple42(var_102, var_103)
and method_132((var_0: int64), (var_1: Union35), (var_2: string), (var_3: int64), (var_4: EnvHeap28), (var_5: (float -> unit)), (var_6: int64)): unit =
    //In the reward part.
    let (var_7: float) = (float var_6)
    var_5(var_7)
    let (var_8: bool) = (var_6 = 1L)
    if var_8 then
        ()
    else
        let (var_9: bool) = (var_6 = -1L)
        if var_9 then
            let (var_10: int64) = (-var_6)
            ()
        else
            let (var_11: bool) = (var_6 > 0L)
            if var_11 then
                ()
            else
                let (var_12: bool) = (var_6 < 0L)
                if var_12 then
                    let (var_13: int64) = (-var_6)
                    ()
                else
                    ()
and method_133((var_0: int64), (var_1: Union35), (var_2: string), (var_3: int64), (var_4: EnvStack0), (var_5: int64)): unit =
    //In the reward part.
    let (var_6: bool) = (var_5 = 1L)
    if var_6 then
        ()
    else
        let (var_7: bool) = (var_5 = -1L)
        if var_7 then
            let (var_8: int64) = (-var_5)
            ()
        else
            let (var_9: bool) = (var_5 > 0L)
            if var_9 then
                ()
            else
                let (var_10: bool) = (var_5 < 0L)
                if var_10 then
                    let (var_11: int64) = (-var_5)
                    ()
                else
                    ()
and method_134((var_0: EnvStack0), (var_1: int64), (var_2: string), (var_3: EnvStack0), (var_4: int64), (var_5: string), (var_6: EnvHeap28), (var_7: (float -> unit))): Tuple29 =
    let (var_9: (Env31 [])) = [|(Env31(Union32Case12)); (Env31(Union32Case11)); (Env31(Union32Case3)); (Env31(Union32Case2)); (Env31(Union32Case9)); (Env31(Union32Case8)); (Env31(Union32Case1)); (Env31(Union32Case6)); (Env31(Union32Case10)); (Env31(Union32Case4)); (Env31(Union32Case7)); (Env31(Union32Case5)); (Env31(Union32Case0))|]
    let (var_10: int64) = var_9.LongLength
    let (var_11: bool) = (var_10 = 13L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_43((var_9: (Env31 [])), (var_0: EnvStack0))
    let (var_13: int64) = 13L
    let (var_14: Tuple33) = method_45((var_1: int64), (var_9: (Env31 [])), (var_13: int64), (var_2: string))
    let (var_15: Env34) = var_14.mem_0
    let (var_16: int64) = var_15.mem_0
    let (var_17: Union35) = var_15.mem_1
    let (var_18: int64) = var_15.mem_2
    let (var_19: Env36) = var_14.mem_1
    let (var_20: (Env31 [])) = var_19.mem_0
    let (var_21: Env37) = var_19.mem_1
    let (var_22: (Env31 [])) = var_21.mem_0
    let (var_23: int64) = var_19.mem_2
    let (var_24: Tuple33) = method_46((var_4: int64), (var_20: (Env31 [])), (var_22: (Env31 [])), (var_23: int64), (var_5: string))
    let (var_25: Env34) = var_24.mem_0
    let (var_26: int64) = var_25.mem_0
    let (var_27: Union35) = var_25.mem_1
    let (var_28: int64) = var_25.mem_2
    let (var_29: Env36) = var_24.mem_1
    let (var_30: (Env31 [])) = var_29.mem_0
    let (var_31: Env37) = var_29.mem_1
    let (var_32: (Env31 [])) = var_31.mem_0
    let (var_33: int64) = var_29.mem_2
    let (var_34: bool) = (var_16 > 0L)
    let (var_39: bool) =
        if var_34 then
            match var_17 with
            | Union35Case0(var_35) ->
                let (var_36: Env31) = var_35.mem_0
                let (var_37: Union32) = var_36.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_42: int64) =
        if var_39 then
            let (var_40: bool) = (0L > var_18)
            if var_40 then
                0L
            else
                var_18
        else
            0L
    let (var_43: bool) = (var_26 > 0L)
    let (var_48: bool) =
        if var_43 then
            match var_27 with
            | Union35Case0(var_44) ->
                let (var_45: Env31) = var_44.mem_0
                let (var_46: Union32) = var_45.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_51: int64) =
        if var_48 then
            let (var_49: bool) = (var_42 > var_28)
            if var_49 then
                var_42
            else
                var_28
        else
            var_42
    let (var_56: bool) =
        if var_34 then
            match var_17 with
            | Union35Case0(var_52) ->
                let (var_53: Env31) = var_52.mem_0
                let (var_54: Union32) = var_53.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_57: int64) =
        if var_56 then
            1L
        else
            0L
    let (var_62: bool) =
        if var_43 then
            match var_27 with
            | Union35Case0(var_58) ->
                let (var_59: Env31) = var_58.mem_0
                let (var_60: Union32) = var_59.mem_0
                true
            | Union35Case1 ->
                false
        else
            false
    let (var_64: int64) =
        if var_62 then
            (var_57 + 1L)
        else
            var_57
    let (var_65: int64) = 2L
    let (var_66: int64) = 0L
    let (var_67: Tuple52) = method_135((var_51: int64), (var_65: int64), (var_64: int64), (var_66: int64), (var_16: int64), (var_17: Union35), (var_2: string), (var_18: int64), (var_3: EnvStack0), (var_26: int64), (var_27: Union35), (var_5: string), (var_28: int64), (var_6: EnvHeap28), (var_7: (float -> unit)))
    let (var_68: Env40) = var_67.mem_0
    let (var_69: int64) = var_68.mem_0
    let (var_70: Union35) = var_68.mem_1
    let (var_71: string) = var_68.mem_2
    let (var_72: int64) = var_68.mem_3
    let (var_73: Env41) = var_68.mem_4
    let (var_74: EnvStack0) = var_73.mem_0
    let (var_75: Env39) = var_67.mem_1
    let (var_76: int64) = var_75.mem_0
    let (var_77: Union35) = var_75.mem_1
    let (var_78: string) = var_75.mem_2
    let (var_79: int64) = var_75.mem_3
    let (var_80: EnvHeap28) = var_75.mem_4
    let (var_81: (float -> unit)) = var_75.mem_5
    method_129((var_69: int64), (var_70: Union35), (var_71: string), (var_72: int64), (var_74: EnvStack0))
    method_127((var_76: int64), (var_77: Union35), (var_78: string), (var_79: int64), (var_80: EnvHeap28), (var_81: (float -> unit)))
    let (var_82: int64) = (var_69 + var_72)
    let (var_83: int64) = (var_76 + var_79)
    let (var_84: Tuple42) = method_130((var_69: int64), (var_70: Union35), (var_72: int64), (var_76: int64), (var_77: Union35), (var_79: int64))
    let (var_85: int64) = var_84.mem_0
    let (var_86: int64) = var_84.mem_1
    let (var_87: int64) = (var_85 - var_82)
    let (var_88: int64) = (var_86 - var_83)
    method_133((var_69: int64), (var_70: Union35), (var_71: string), (var_72: int64), (var_74: EnvStack0), (var_87: int64))
    method_132((var_76: int64), (var_77: Union35), (var_78: string), (var_79: int64), (var_80: EnvHeap28), (var_81: (float -> unit)), (var_88: int64))
    let (var_89: bool) = (var_85 > 0L)
    let (var_90: int64) =
        if var_89 then
            1L
        else
            0L
    let (var_91: bool) = (var_86 > 0L)
    let (var_93: int64) =
        if var_91 then
            (var_90 + 1L)
        else
            var_90
    let (var_94: bool) = (var_93 = 1L)
    if var_94 then
        Tuple29((Env30(var_85, var_2)), (Env30(var_86, var_5)))
    else
        method_42((var_0: EnvStack0), (var_86: int64), (var_5: string), (var_6: EnvHeap28), (var_7: (float -> unit)), (var_85: int64), (var_2: string), (var_3: EnvStack0))
and method_137((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_138((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_138", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_140((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_141((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_141", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_144((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_145((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_145", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_148((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_149((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_149", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_151((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_152((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_152", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_13 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_44((var_0: EnvStack0), (var_1: (Env31 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 12L)
    if var_3 then
        let (var_4: System.Random) = var_0.mem_0
        let (var_5: int32) = (int32 var_2)
        let (var_6: int32) = var_4.Next(var_5, 13)
        let (var_7: Env31) = var_1.[int32 var_2]
        let (var_8: Union32) = var_7.mem_0
        let (var_9: Env31) = var_1.[int32 var_6]
        var_1.[int32 var_2] <- var_9
        var_1.[int32 var_6] <- (Env31(var_8))
        let (var_10: int64) = (var_2 + 1L)
        method_44((var_0: EnvStack0), (var_1: (Env31 [])), (var_10: int64))
    else
        ()
and method_48((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union35), (var_6: int64), (var_7: int64), (var_8: Union35), (var_9: int64), (var_10: int64), (var_11: Union35), (var_12: string), (var_13: int64), (var_14: EnvHeap28), (var_15: (float -> unit))): Union45 =
    //In betting
    let (var_16: bool) = (var_3 < var_2)
    let (var_20: bool) =
        if var_16 then
            let (var_17: bool) = (var_2 <> 1L)
            if var_17 then
                true
            else
                (var_13 < var_0)
        else
            false
    if var_20 then
        let (var_21: bool) = (var_10 > 0L)
        let (var_26: bool) =
            if var_21 then
                match var_11 with
                | Union35Case0(var_22) ->
                    let (var_23: Env31) = var_22.mem_0
                    let (var_24: Union32) = var_23.mem_0
                    true
                | Union35Case1 ->
                    false
            else
                false
        if var_26 then
            let (var_27: EnvHeap21) = var_14.mem_0
            let (var_28: EnvHeap23) = var_14.mem_1
            let (var_29: (int64 ref)) = var_14.mem_2
            let (var_30: (uint64 ref)) = var_14.mem_3
            let (var_31: (int64 ref)) = var_14.mem_4
            let (var_32: (uint64 ref)) = var_14.mem_5
            let (var_33: (int64 ref)) = var_14.mem_6
            let (var_34: (uint64 ref)) = var_14.mem_7
            let (var_35: (int64 ref)) = var_14.mem_8
            let (var_36: (uint64 ref)) = var_14.mem_9
            let (var_37: EnvHeap18) = var_14.mem_10
            let (var_38: ManagedCuda.BasicTypes.CUmodule) = var_14.mem_11
            let (var_39: EnvStack54) = method_49((var_27: EnvHeap21), (var_28: EnvHeap23), (var_29: (int64 ref)), (var_30: (uint64 ref)), (var_31: (int64 ref)), (var_32: (uint64 ref)), (var_33: (int64 ref)), (var_34: (uint64 ref)), (var_35: (int64 ref)), (var_36: (uint64 ref)), (var_4: int64), (var_5: Union35), (var_6: int64), (var_7: int64), (var_8: Union35), (var_9: int64), (var_37: EnvHeap18), (var_38: ManagedCuda.BasicTypes.CUmodule))
            let (var_40: Union55) = var_39.mem_0
            let (var_41: (unit -> unit)) = var_39.mem_1
            let (var_42: (unit -> unit)) = var_39.mem_2
            let (var_43: (unit -> unit)) = var_39.mem_3
            let (var_44: (float -> unit)) = var_39.mem_4
            match var_40 with
            | Union55Case0 ->
                let (var_46: (float -> unit)) = method_125((var_41: (unit -> unit)), (var_42: (unit -> unit)), (var_43: (unit -> unit)), (var_44: (float -> unit)), (var_15: (float -> unit)))
                let (var_47: int64) = (var_0 + var_1)
                let (var_48: int64) = (var_47 - var_13)
                let (var_49: bool) = (var_10 > var_48)
                let (var_50: int64) =
                    if var_49 then
                        var_48
                    else
                        var_10
                let (var_51: int64) = (var_10 - var_50)
                let (var_52: int64) = (var_13 + var_50)
                let (var_53: bool) = (var_51 = 0L)
                if var_53 then
                    let (var_54: bool) = (var_52 > var_0)
                    if var_54 then
                        let (var_55: int64) = (var_52 - var_0)
                        let (var_56: bool) = (var_1 > var_55)
                        let (var_57: int64) =
                            if var_56 then
                                var_1
                            else
                                var_55
                        let (var_58: int64) = (var_2 - 1L)
                        (Union45Case0(Tuple53(Tuple46((Env47(var_51, var_11, var_52, var_46)), (Env48(var_52, var_57, var_58, 0L))))))
                    else
                        let (var_59: int64) = (var_2 - 1L)
                        (Union45Case0(Tuple53(Tuple46((Env47(var_51, var_11, var_52, var_46)), (Env48(var_0, var_1, var_59, var_3))))))
                else
                    let (var_61: bool) = (var_52 > var_0)
                    if var_61 then
                        let (var_62: int64) = (var_52 - var_0)
                        let (var_63: bool) = (var_1 > var_62)
                        let (var_64: int64) =
                            if var_63 then
                                var_1
                            else
                                var_62
                        (Union45Case0(Tuple53(Tuple46((Env47(var_51, var_11, var_52, var_46)), (Env48(var_52, var_64, var_2, 1L))))))
                    else
                        let (var_65: Env48) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                        let (var_66: int64) = var_65.mem_0
                        let (var_67: int64) = var_65.mem_1
                        let (var_68: int64) = var_65.mem_2
                        let (var_69: int64) = var_65.mem_3
                        (Union45Case0(Tuple53(Tuple46((Env47(var_51, var_11, var_52, var_46)), (Env48(var_66, var_67, var_68, var_69))))))
            | Union55Case1 ->
                let (var_73: (float -> unit)) = method_125((var_41: (unit -> unit)), (var_42: (unit -> unit)), (var_43: (unit -> unit)), (var_44: (float -> unit)), (var_15: (float -> unit)))
                let (var_74: int64) = (var_0 - var_13)
                let (var_75: bool) = (var_10 > var_74)
                let (var_76: int64) =
                    if var_75 then
                        var_74
                    else
                        var_10
                let (var_77: int64) = (var_10 - var_76)
                let (var_78: int64) = (var_13 + var_76)
                let (var_79: bool) = (var_77 = 0L)
                if var_79 then
                    let (var_80: int64) = (var_2 - 1L)
                    (Union45Case0(Tuple53(Tuple46((Env47(var_77, var_11, var_78, var_73)), (Env48(var_0, var_1, var_80, var_3))))))
                else
                    let (var_81: int64) = (var_3 + 1L)
                    (Union45Case0(Tuple53(Tuple46((Env47(var_77, var_11, var_78, var_73)), (Env48(var_0, var_1, var_2, var_81))))))
            | Union55Case2 ->
                let (var_84: (float -> unit)) = method_125((var_41: (unit -> unit)), (var_42: (unit -> unit)), (var_43: (unit -> unit)), (var_44: (float -> unit)), (var_15: (float -> unit)))
                let (var_85: int64) = (var_2 - 1L)
                (Union45Case0(Tuple53(Tuple46((Env47(var_10, Union35Case1, var_13, var_84)), (Env48(var_0, var_1, var_85, var_3))))))
        else
            (Union45Case0(Tuple53(Tuple46((Env47(var_10, var_11, var_13, var_15)), (Env48(var_0, var_1, var_2, var_3))))))
    else
        Union45Case1
and method_126((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union35), (var_6: int64), (var_7: int64), (var_8: Union35), (var_9: int64), (var_10: int64), (var_11: Union35), (var_12: string), (var_13: int64), (var_14: EnvStack0)): Union49 =
    //In betting
    let (var_15: bool) = (var_3 < var_2)
    let (var_19: bool) =
        if var_15 then
            let (var_16: bool) = (var_2 <> 1L)
            if var_16 then
                true
            else
                (var_13 < var_0)
        else
            false
    if var_19 then
        let (var_20: bool) = (var_10 > 0L)
        let (var_25: bool) =
            if var_20 then
                match var_11 with
                | Union35Case0(var_21) ->
                    let (var_22: Env31) = var_21.mem_0
                    let (var_23: Union32) = var_22.mem_0
                    true
                | Union35Case1 ->
                    false
            else
                false
        if var_25 then
            let (var_26: System.Random) = var_14.mem_0
            let (var_27: int32) = var_26.Next(0, 5)
            let (var_28: bool) = (var_27 = 0)
            if var_28 then
                let (var_29: int64) = (var_2 - 1L)
                (Union49Case0(Tuple56(Tuple50((Env34(var_10, Union35Case1, var_13)), (Env48(var_0, var_1, var_29, var_3))))))
            else
                let (var_30: bool) = (var_27 = 1)
                if var_30 then
                    let (var_31: int64) = (var_0 - var_13)
                    let (var_32: bool) = (var_10 > var_31)
                    let (var_33: int64) =
                        if var_32 then
                            var_31
                        else
                            var_10
                    let (var_34: int64) = (var_10 - var_33)
                    let (var_35: int64) = (var_13 + var_33)
                    let (var_36: bool) = (var_34 = 0L)
                    if var_36 then
                        let (var_37: int64) = (var_2 - 1L)
                        (Union49Case0(Tuple56(Tuple50((Env34(var_34, var_11, var_35)), (Env48(var_0, var_1, var_37, var_3))))))
                    else
                        let (var_38: int64) = (var_3 + 1L)
                        (Union49Case0(Tuple56(Tuple50((Env34(var_34, var_11, var_35)), (Env48(var_0, var_1, var_2, var_38))))))
                else
                    let (var_40: int64) = (var_0 + var_1)
                    let (var_41: int64) = (var_40 - var_13)
                    let (var_42: bool) = (var_10 > var_41)
                    let (var_43: int64) =
                        if var_42 then
                            var_41
                        else
                            var_10
                    let (var_44: int64) = (var_10 - var_43)
                    let (var_45: int64) = (var_13 + var_43)
                    let (var_46: bool) = (var_44 = 0L)
                    if var_46 then
                        let (var_47: bool) = (var_45 > var_0)
                        if var_47 then
                            let (var_48: int64) = (var_45 - var_0)
                            let (var_49: bool) = (var_1 > var_48)
                            let (var_50: int64) =
                                if var_49 then
                                    var_1
                                else
                                    var_48
                            let (var_51: int64) = (var_2 - 1L)
                            (Union49Case0(Tuple56(Tuple50((Env34(var_44, var_11, var_45)), (Env48(var_45, var_50, var_51, 0L))))))
                        else
                            let (var_52: int64) = (var_2 - 1L)
                            (Union49Case0(Tuple56(Tuple50((Env34(var_44, var_11, var_45)), (Env48(var_0, var_1, var_52, var_3))))))
                    else
                        let (var_54: bool) = (var_45 > var_0)
                        if var_54 then
                            let (var_55: int64) = (var_45 - var_0)
                            let (var_56: bool) = (var_1 > var_55)
                            let (var_57: int64) =
                                if var_56 then
                                    var_1
                                else
                                    var_55
                            (Union49Case0(Tuple56(Tuple50((Env34(var_44, var_11, var_45)), (Env48(var_45, var_57, var_2, 1L))))))
                        else
                            let (var_58: Env48) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_59: int64) = var_58.mem_0
                            let (var_60: int64) = var_58.mem_1
                            let (var_61: int64) = var_58.mem_2
                            let (var_62: int64) = var_58.mem_3
                            (Union49Case0(Tuple56(Tuple50((Env34(var_44, var_11, var_45)), (Env48(var_59, var_60, var_61, var_62))))))
        else
            (Union49Case0(Tuple56(Tuple50((Env34(var_10, var_11, var_13)), (Env48(var_0, var_1, var_2, var_3))))))
    else
        Union49Case1
and method_128((var_0: Union32)): string =
    //In show_card.
    match var_0 with
    | Union32Case0 ->
        "Ace-Spades"
    | Union32Case1 ->
        "Eight-Spades"
    | Union32Case2 ->
        "Five-Spades"
    | Union32Case3 ->
        "Four-Spades"
    | Union32Case4 ->
        "Jack-Spades"
    | Union32Case5 ->
        "King-Spades"
    | Union32Case6 ->
        "Nine-Spades"
    | Union32Case7 ->
        "Queen-Spades"
    | Union32Case8 ->
        "Seven-Spades"
    | Union32Case9 ->
        "Six-Spades"
    | Union32Case10 ->
        "Ten-Spades"
    | Union32Case11 ->
        "Three-Spades"
    | Union32Case12 ->
        "Two-Spades"
and method_131((var_0: Union32)): int32 =
    //In hand_rule
    match var_0 with
    | Union32Case0 ->
        12
    | Union32Case1 ->
        6
    | Union32Case2 ->
        3
    | Union32Case3 ->
        2
    | Union32Case4 ->
        9
    | Union32Case5 ->
        11
    | Union32Case6 ->
        7
    | Union32Case7 ->
        10
    | Union32Case8 ->
        5
    | Union32Case9 ->
        4
    | Union32Case10 ->
        8
    | Union32Case11 ->
        1
    | Union32Case12 ->
        0
and method_135((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union35), (var_6: string), (var_7: int64), (var_8: EnvStack0), (var_9: int64), (var_10: Union35), (var_11: string), (var_12: int64), (var_13: EnvHeap28), (var_14: (float -> unit))): Tuple52 =
    //In betting's loop.
    let (var_15: int64) = 0L
    let (var_16: bool) = (0L <> var_15)
    let (var_18: Env34) =
        if var_16 then
            let (var_17: Union35) = Union35Case1
            (Env34(var_4, var_17, var_7))
        else
            (Env34(var_4, var_5, var_7))
    let (var_19: int64) = var_18.mem_0
    let (var_20: Union35) = var_18.mem_1
    let (var_21: int64) = var_18.mem_2
    let (var_22: bool) = (1L <> var_15)
    let (var_24: Env34) =
        if var_22 then
            let (var_23: Union35) = Union35Case1
            (Env34(var_9, var_23, var_12))
        else
            (Env34(var_9, var_10, var_12))
    let (var_25: int64) = var_24.mem_0
    let (var_26: Union35) = var_24.mem_1
    let (var_27: int64) = var_24.mem_2
    let (var_28: Union49) = method_126((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_19: int64), (var_20: Union35), (var_21: int64), (var_25: int64), (var_26: Union35), (var_27: int64), (var_4: int64), (var_5: Union35), (var_6: string), (var_7: int64), (var_8: EnvStack0))
    match var_28 with
    | Union49Case0(var_29) ->
        let (var_30: Tuple50) = var_29.mem_0
        let (var_31: Env34) = var_30.mem_0
        let (var_32: int64) = var_31.mem_0
        let (var_33: Union35) = var_31.mem_1
        let (var_34: int64) = var_31.mem_2
        let (var_35: Env48) = var_30.mem_1
        let (var_36: int64) = var_35.mem_0
        let (var_37: int64) = var_35.mem_1
        let (var_38: int64) = var_35.mem_2
        let (var_39: int64) = var_35.mem_3
        let (var_40: int64) = (var_15 + 1L)
        let (var_41: bool) = (0L <> var_40)
        let (var_43: Env34) =
            if var_41 then
                let (var_42: Union35) = Union35Case1
                (Env34(var_32, var_42, var_34))
            else
                (Env34(var_32, var_33, var_34))
        let (var_44: int64) = var_43.mem_0
        let (var_45: Union35) = var_43.mem_1
        let (var_46: int64) = var_43.mem_2
        let (var_47: bool) = (1L <> var_40)
        let (var_49: Env34) =
            if var_47 then
                let (var_48: Union35) = Union35Case1
                (Env34(var_9, var_48, var_12))
            else
                (Env34(var_9, var_10, var_12))
        let (var_50: int64) = var_49.mem_0
        let (var_51: Union35) = var_49.mem_1
        let (var_52: int64) = var_49.mem_2
        let (var_53: Union45) = method_48((var_36: int64), (var_37: int64), (var_38: int64), (var_39: int64), (var_44: int64), (var_45: Union35), (var_46: int64), (var_50: int64), (var_51: Union35), (var_52: int64), (var_9: int64), (var_10: Union35), (var_11: string), (var_12: int64), (var_13: EnvHeap28), (var_14: (float -> unit)))
        match var_53 with
        | Union45Case0(var_54) ->
            let (var_55: Tuple46) = var_54.mem_0
            let (var_56: Env47) = var_55.mem_0
            let (var_57: int64) = var_56.mem_0
            let (var_58: Union35) = var_56.mem_1
            let (var_59: int64) = var_56.mem_2
            let (var_60: (float -> unit)) = var_56.mem_3
            let (var_61: Env48) = var_55.mem_1
            let (var_62: int64) = var_61.mem_0
            let (var_63: int64) = var_61.mem_1
            let (var_64: int64) = var_61.mem_2
            let (var_65: int64) = var_61.mem_3
            let (var_66: int64) = (var_40 + 1L)
            method_135((var_62: int64), (var_63: int64), (var_64: int64), (var_65: int64), (var_32: int64), (var_33: Union35), (var_6: string), (var_34: int64), (var_8: EnvStack0), (var_57: int64), (var_58: Union35), (var_11: string), (var_59: int64), (var_13: EnvHeap28), (var_60: (float -> unit)))
        | Union45Case1 ->
            Tuple52((Env40(var_32, var_33, var_6, var_34, (Env41(var_8)))), (Env39(var_9, var_10, var_11, var_12, var_13, var_14)))
    | Union49Case1 ->
        Tuple52((Env40(var_4, var_5, var_6, var_7, (Env41(var_8)))), (Env39(var_9, var_10, var_11, var_12, var_13, var_14)))
and method_14 ((var_1: uint64)) ((var_0: Env2)): int32 =
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
and method_49((var_0: EnvHeap21), (var_1: EnvHeap23), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: int64), (var_11: Union35), (var_12: int64), (var_13: int64), (var_14: Union35), (var_15: int64), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)): EnvStack54 =
    let (var_18: bool) = (var_10 >= 0L)
    let (var_19: bool) = (var_18 = false)
    if var_19 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_20: bool) = (var_10 < 32L)
    let (var_21: bool) = (var_20 = false)
    if var_21 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_22: Union35) = var_11
    let (var_28: int64) =
        match var_22 with
        | Union35Case0(var_23) ->
            let (var_24: Env31) = var_23.mem_0
            let (var_25: Union32) = var_24.mem_0
            let (var_26: Union32) = var_25
            match var_26 with
            | Union32Case0 ->
                0L
            | Union32Case1 ->
                1L
            | Union32Case2 ->
                2L
            | Union32Case3 ->
                3L
            | Union32Case4 ->
                4L
            | Union32Case5 ->
                5L
            | Union32Case6 ->
                6L
            | Union32Case7 ->
                7L
            | Union32Case8 ->
                8L
            | Union32Case9 ->
                9L
            | Union32Case10 ->
                10L
            | Union32Case11 ->
                11L
            | Union32Case12 ->
                12L
        | Union35Case1 ->
            13L
    let (var_29: int64) = (32L + var_28)
    let (var_30: bool) = (var_12 >= 0L)
    let (var_31: bool) = (var_30 = false)
    if var_31 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_32: bool) = (var_12 < 32L)
    let (var_33: bool) = (var_32 = false)
    if var_33 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_34: int64) = (46L + var_12)
    let (var_35: bool) = (var_13 >= 0L)
    let (var_36: bool) = (var_35 = false)
    if var_36 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_37: bool) = (var_13 < 32L)
    let (var_38: bool) = (var_37 = false)
    if var_38 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_39: int64) = (78L + var_13)
    let (var_40: Union35) = var_14
    let (var_46: int64) =
        match var_40 with
        | Union35Case0(var_41) ->
            let (var_42: Env31) = var_41.mem_0
            let (var_43: Union32) = var_42.mem_0
            let (var_44: Union32) = var_43
            match var_44 with
            | Union32Case0 ->
                0L
            | Union32Case1 ->
                1L
            | Union32Case2 ->
                2L
            | Union32Case3 ->
                3L
            | Union32Case4 ->
                4L
            | Union32Case5 ->
                5L
            | Union32Case6 ->
                6L
            | Union32Case7 ->
                7L
            | Union32Case8 ->
                8L
            | Union32Case9 ->
                9L
            | Union32Case10 ->
                10L
            | Union32Case11 ->
                11L
            | Union32Case12 ->
                12L
        | Union35Case1 ->
            13L
    let (var_47: int64) = (110L + var_46)
    let (var_48: bool) = (var_15 >= 0L)
    let (var_49: bool) = (var_48 = false)
    if var_49 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_50: bool) = (var_15 < 32L)
    let (var_51: bool) = (var_50 = false)
    if var_51 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_52: int64) = (124L + var_15)
    let (var_53: EnvStack57) = method_50((var_10: int64), (var_29: int64), (var_34: int64), (var_39: int64), (var_47: int64), (var_52: int64), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    let (var_54: (int64 ref)) = var_53.mem_0
    let (var_55: (uint64 ref)) = var_53.mem_1
    let (var_56: EnvStack58) = method_57((var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_54: (int64 ref)), (var_55: (uint64 ref)), (var_0: EnvHeap21))
    let (var_57: (int64 ref)) = var_56.mem_0
    let (var_58: (uint64 ref)) = var_56.mem_1
    let (var_59: (int64 ref)) = var_56.mem_2
    let (var_60: (uint64 ref)) = var_56.mem_3
    let (var_61: (unit -> unit)) = var_56.mem_4
    let (var_62: EnvStack58) = method_82((var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_57: (int64 ref)), (var_58: (uint64 ref)), (var_59: (int64 ref)), (var_60: (uint64 ref)), (var_1: EnvHeap23))
    let (var_63: (int64 ref)) = var_62.mem_0
    let (var_64: (uint64 ref)) = var_62.mem_1
    let (var_65: (int64 ref)) = var_62.mem_2
    let (var_66: (uint64 ref)) = var_62.mem_3
    let (var_67: (unit -> unit)) = var_62.mem_4
    let (var_68: EnvStack59) = method_89((var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_63: (int64 ref)), (var_64: (uint64 ref)), (var_65: (int64 ref)), (var_66: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)))
    let (var_69: (int64 ref)) = var_68.mem_0
    let (var_70: (uint64 ref)) = var_68.mem_1
    let (var_71: (int64 ref)) = var_68.mem_2
    let (var_72: (uint64 ref)) = var_68.mem_3
    let (var_73: (unit -> unit)) = var_68.mem_4
    let (var_74: EnvStack60) = method_105((var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_69: (int64 ref)), (var_70: (uint64 ref)), (var_71: (int64 ref)), (var_72: (uint64 ref)))
    let (var_75: (int64 ref)) = var_74.mem_0
    let (var_76: (uint64 ref)) = var_74.mem_1
    let (var_77: (int64 ref)) = var_74.mem_2
    let (var_78: (uint64 ref)) = var_74.mem_3
    let (var_79: (float -> unit)) = var_74.mem_4
    let (var_80: int64) = 1L
    let (var_81: int64) = 0L
    let (var_82: (int64 [])) = method_124((var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_80: int64), (var_77: (int64 ref)), (var_78: (uint64 ref)), (var_81: int64))
    let (var_83: int64) = var_82.[int32 0L]
    let (var_84: int64) = (var_83 - 1L)
    let (var_85: int64) = (var_84 - 1L)
    let (var_86: int64) = (var_85 - 1L)
    let (var_87: int64) = (var_83 % 3L)
    let (var_88: bool) = (var_87 < 1L)
    let (var_93: Union55) =
        if var_88 then
            Union55Case0
        else
            let (var_89: int64) = (var_87 - 1L)
            let (var_90: bool) = (var_89 < 1L)
            if var_90 then
                Union55Case1
            else
                let (var_91: int64) = (var_89 - 1L)
                Union55Case2
    EnvStack54((var_93: Union55), (var_61: (unit -> unit)), (var_67: (unit -> unit)), (var_73: (unit -> unit)), (var_79: (float -> unit)))
and method_125 ((var_1: (unit -> unit)), (var_2: (unit -> unit)), (var_3: (unit -> unit)), (var_4: (float -> unit)), (var_5: (float -> unit))) ((var_0: float)): unit =
    var_4(var_0)
    var_3()
    var_2()
    var_1()
    var_5(var_0)
and method_50((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): EnvStack57 =
    let (var_22: Env10) = method_51((var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: Env26) = var_22.mem_1
    let (var_25: (uint64 ref)) = var_24.mem_0
    method_52((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_23: (int64 ref)), (var_25: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
    EnvStack57((var_23: (int64 ref)), (var_25: (uint64 ref)))
and method_57((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap21)): EnvStack58 =
    let (var_5: (int64 ref)) = var_4.mem_4
    let (var_6: (uint64 ref)) = var_4.mem_5
    let (var_7: (int64 ref)) = var_4.mem_6
    let (var_8: (uint64 ref)) = var_4.mem_7
    let (var_9: (int64 ref)) = var_4.mem_0
    let (var_10: (uint64 ref)) = var_4.mem_1
    let (var_11: (int64 ref)) = var_4.mem_2
    let (var_12: (uint64 ref)) = var_4.mem_3
    let (var_13: EnvStack61) = method_58((var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: (uint64 ref)) = var_13.mem_1
    let (var_16: EnvStack61) = method_60((var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: (uint64 ref)) = var_16.mem_1
    method_62((var_11: (int64 ref)), (var_12: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_19: EnvStack61) = method_67((var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_20: (int64 ref)) = var_19.mem_0
    let (var_21: (uint64 ref)) = var_19.mem_1
    let (var_22: EnvStack61) = method_60((var_20: (int64 ref)), (var_21: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: (uint64 ref)) = var_22.mem_1
    let (var_25: (unit -> unit)) = method_71((var_17: (int64 ref)), (var_18: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_11: (int64 ref)), (var_12: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_5: (int64 ref)), (var_6: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: (uint64 ref)), (var_20: (int64 ref)), (var_21: (uint64 ref)))
    EnvStack58((var_23: (int64 ref)), (var_24: (uint64 ref)), (var_20: (int64 ref)), (var_21: (uint64 ref)), (var_25: (unit -> unit)))
and method_82((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap23)): EnvStack58 =
    let (var_7: (int64 ref)) = var_6.mem_4
    let (var_8: (uint64 ref)) = var_6.mem_5
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: (uint64 ref)) = var_6.mem_7
    let (var_11: (int64 ref)) = var_6.mem_0
    let (var_12: (uint64 ref)) = var_6.mem_1
    let (var_13: (int64 ref)) = var_6.mem_2
    let (var_14: (uint64 ref)) = var_6.mem_3
    let (var_15: EnvStack61) = method_83((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: (uint64 ref)) = var_15.mem_1
    let (var_18: EnvStack61) = method_60((var_16: (int64 ref)), (var_17: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: (uint64 ref)) = var_18.mem_1
    method_62((var_13: (int64 ref)), (var_14: (uint64 ref)), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_21: EnvStack61) = method_67((var_16: (int64 ref)), (var_17: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_22: (int64 ref)) = var_21.mem_0
    let (var_23: (uint64 ref)) = var_21.mem_1
    let (var_24: EnvStack61) = method_60((var_22: (int64 ref)), (var_23: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: (uint64 ref)) = var_24.mem_1
    let (var_27: (unit -> unit)) = method_85((var_19: (int64 ref)), (var_20: (uint64 ref)), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_11: (int64 ref)), (var_12: (uint64 ref)), (var_13: (int64 ref)), (var_14: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: (uint64 ref)), (var_22: (int64 ref)), (var_23: (uint64 ref)))
    EnvStack58((var_25: (int64 ref)), (var_26: (uint64 ref)), (var_22: (int64 ref)), (var_23: (uint64 ref)), (var_27: (unit -> unit)))
and method_89((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref))): EnvStack59 =
    let (var_14: EnvStack62) = method_90((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: (uint64 ref)) = var_14.mem_1
    let (var_17: EnvStack62) = method_92((var_15: (int64 ref)), (var_16: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: (uint64 ref)) = var_17.mem_1
    method_94((var_8: (int64 ref)), (var_9: (uint64 ref)), (var_15: (int64 ref)), (var_16: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_20: (unit -> unit)) = method_98((var_18: (int64 ref)), (var_19: (uint64 ref)), (var_15: (int64 ref)), (var_16: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack59((var_18: (int64 ref)), (var_19: (uint64 ref)), (var_15: (int64 ref)), (var_16: (uint64 ref)), (var_20: (unit -> unit)))
and method_105((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref))): EnvStack60 =
    let (var_6: Env10) = method_106((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env26) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    let (var_10: uint64) = method_5((var_5: (uint64 ref)))
    let (var_11: uint64) = method_5((var_9: (uint64 ref)))
    method_107((var_10: uint64), (var_11: uint64), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_12: EnvStack63) = method_112((var_7: (int64 ref)), (var_9: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: (uint64 ref)) = var_12.mem_1
    let (var_15: (int64 ref)) = var_12.mem_2
    let (var_16: (uint64 ref)) = var_12.mem_3
    let (var_18: (float -> unit)) = method_120((var_15: (int64 ref)), (var_16: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)))
    EnvStack60((var_13: (int64 ref)), (var_14: (uint64 ref)), (var_15: (int64 ref)), (var_16: (uint64 ref)), (var_18: (float -> unit)))
and method_124((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (int64 ref)), (var_4: (uint64 ref)), (var_5: int64)): (int64 []) =
    let (var_6: (int64 ref)) = var_0.mem_6
    let (var_7: EnvHeap16) = var_0.mem_7
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_18((var_7: EnvHeap16))
    let (var_9: uint64) = method_5((var_4: (uint64 ref)))
    let (var_10: int64) = (var_5 * 8L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_2))
    let (var_14: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_15: int64) = var_14.AddrOfPinnedObject().ToInt64()
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: int64) = (var_2 * 8L)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_23: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.AsynchronousMemcpy_v2.cuMemcpyAsync(var_19, var_21, var_22, var_8)
    if var_23 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_23)
    var_14.Free()
    var_13
and method_51((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 624L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_52((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_10: uint64) = method_5((var_7: (uint64 ref)))
    method_53((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_10: uint64), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule))
and method_58((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack61 =
    let (var_6: Env10) = method_22((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env26) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_59((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack61((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_60((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack61 =
    let (var_4: Env10) = method_22((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_61((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack61((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_62((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    let (var_8: uint64) = method_5((var_3: (uint64 ref)))
    method_63((var_6: uint64), (var_7: uint64), (var_8: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_67((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack61 =
    let (var_12: Env10) = method_22((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env26) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_14.mem_0
    let (var_16: uint64) = method_5((var_1: (uint64 ref)))
    let (var_17: uint64) = method_5((var_15: (uint64 ref)))
    method_68((var_16: uint64), (var_17: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack61((var_13: (int64 ref)), (var_15: (uint64 ref)))
and method_71 ((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_18: (int64 ref)), (var_19: (uint64 ref))) (): unit =
    method_72((var_16: (int64 ref)), (var_17: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
    method_76((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
and method_83((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack61 =
    let (var_6: Env10) = method_22((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env26) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_84((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack61((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_85 ((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: (uint64 ref)), (var_20: (int64 ref)), (var_21: (uint64 ref))) (): unit =
    method_72((var_18: (int64 ref)), (var_19: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_86((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_90((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack62 =
    let (var_6: Env10) = method_36((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env26) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_91((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack62((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_92((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack62 =
    let (var_4: Env10) = method_36((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env26) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_93((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack62((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_94((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    let (var_8: uint64) = method_5((var_3: (uint64 ref)))
    method_95((var_6: uint64), (var_7: uint64), (var_8: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_98 ((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)) (): unit =
    method_99((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_106((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 12L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_107((var_0: uint64), (var_1: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_108((var_0: uint64), (var_1: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap18))
and method_112((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack63 =
    let (var_4: int64) = 0L
    let (var_5: int64) = 0L
    let (var_6: Env10) = method_113((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env26) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    let (var_10: Env10) = method_114((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_11: (int64 ref)) = var_10.mem_0
    let (var_12: Env26) = var_10.mem_1
    let (var_13: (uint64 ref)) = var_12.mem_0
    method_115((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_11: (int64 ref)), (var_13: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack63((var_7: (int64 ref)), (var_9: (uint64 ref)), (var_11: (int64 ref)), (var_13: (uint64 ref)))
and method_120 ((var_1: (int64 ref)), (var_2: (uint64 ref)), (var_3: EnvHeap18), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref))) ((var_0: float)): unit =
    let (var_9: int64) = (int64 var_0)
    let (var_10: bool) = (-32L <= var_9)
    let (var_12: bool) =
        if var_10 then
            (var_9 < 32L)
        else
            false
    let (var_13: bool) = (var_12 = false)
    if var_13 then
        (failwith "The reward must be in range.")
    else
        ()
    let (var_14: uint64) = method_5((var_2: (uint64 ref)))
    let (var_15: uint64) = method_5((var_8: (uint64 ref)))
    let (var_16: uint64) = method_5((var_6: (uint64 ref)))
    method_121((var_14: uint64), (var_15: uint64), (var_9: int64), (var_16: uint64), (var_3: EnvHeap18), (var_4: ManagedCuda.BasicTypes.CUmodule))
and method_53((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_7: EnvHeap18), (var_8: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_54((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvHeap18))
and method_59((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 0.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 156, var_15, var_18, 256, var_21, 156, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_61((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_63((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_64((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_68((var_0: uint64), (var_1: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_69((var_0: uint64), (var_1: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap18))
and method_72((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: uint64) = method_5((var_1: (uint64 ref)))
    let (var_9: uint64) = method_5((var_3: (uint64 ref)))
    let (var_10: uint64) = method_5((var_5: (uint64 ref)))
    method_73((var_8: uint64), (var_9: uint64), (var_10: uint64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
and method_76((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_77((var_8: (int64 ref)), (var_9: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
    method_78((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
and method_84((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 0.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 256, var_15, var_18, 256, var_21, 256, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_86((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_87((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_88((var_10: (int64 ref)), (var_11: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_78((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_91((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 0.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 192, 1, 256, var_15, var_18, 192, var_21, 256, var_22, var_25, 192)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_93((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(768L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_95((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_96((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_96", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(6u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_99((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_100((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_101((var_10: (int64 ref)), (var_11: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_102((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_108((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_109((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_109", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 3u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_113((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 4L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_114((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 8L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_115((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: uint64) = method_5((var_1: (uint64 ref)))
    let (var_9: uint64) = method_5((var_3: (uint64 ref)))
    let (var_10: uint64) = method_5((var_5: (uint64 ref)))
    method_116((var_8: uint64), (var_9: uint64), (var_10: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap18))
and method_121((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: uint64), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_122((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_54((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvHeap18)): unit =
    // Cuda join point
    // method_55((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64))
    let (var_9: ManagedCuda.CudaContext) = var_8.mem_0
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_7, var_9)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(156u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (int64 ref)) = var_8.mem_6
    let (var_14: EnvHeap16) = var_8.mem_7
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_18((var_14: EnvHeap16))
    let (var_17: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_15, var_17)
and method_69((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_70((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_70", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_73((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: EnvHeap18), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_74((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18))
and method_77((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 156, 1, var_15, var_18, 256, var_21, 156, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_78((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_79((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_87((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 256, var_15, var_18, 256, var_21, 256, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_88((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 256, 1, var_15, var_18, 256, var_21, 256, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_100((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 192, var_15, var_18, 192, var_21, 192, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_101((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 192, 256, 1, var_15, var_18, 192, var_21, 256, var_22, var_25, 192)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_102((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_103((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_116((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_117((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_117", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_122((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: EnvHeap18)): unit =
    // Cuda join point
    // method_123((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: uint64))
    let (var_6: ManagedCuda.CudaContext) = var_5.mem_0
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_123", var_4, var_6)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (int64 ref)) = var_5.mem_6
    let (var_11: EnvHeap16) = var_5.mem_7
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_11: EnvHeap16))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_74((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_75((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_75", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_79((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_80((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_80", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_103((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_104((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_104", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(6u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
let (var_0: System.Random) = System.Random()
let (var_1: EnvStack0) = EnvStack0((var_0: System.Random))
let (var_2: string) = cuda_kernels
let (var_3: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_3.Synchronize()
let (var_4: string) = System.Environment.get_CurrentDirectory()
let (var_5: string) = System.IO.Path.Combine(var_4, "nvcc_router.bat")
let (var_6: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_6.set_RedirectStandardOutput(true)
var_6.set_RedirectStandardError(true)
var_6.set_UseShellExecute(false)
var_6.set_FileName(var_5)
let (var_7: System.Diagnostics.Process) = System.Diagnostics.Process()
var_7.set_StartInfo(var_6)
let (var_9: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_7.OutputDataReceived.Add(var_9)
var_7.ErrorDataReceived.Add(var_9)
let (var_10: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvarsall.bat")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_13: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_14: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_15: string) = System.IO.Path.Combine(var_4, "cuda_kernels.ptx")
let (var_16: string) = System.IO.Path.Combine(var_4, "cuda_kernels.cu")
let (var_17: bool) = System.IO.File.Exists(var_16)
if var_17 then
    System.IO.File.Delete(var_16)
else
    ()
System.IO.File.WriteAllText(var_16, var_2)
let (var_18: bool) = System.IO.File.Exists(var_5)
if var_18 then
    System.IO.File.Delete(var_5)
else
    ()
let (var_19: System.IO.FileStream) = System.IO.File.OpenWrite(var_5)
let (var_20: System.IO.StreamWriter) = System.IO.StreamWriter(var_19)
var_20.WriteLine("SETLOCAL")
let (var_21: string) = String.concat "" [|"CALL "; "\""; var_10; "\" x64 -vcvars_ver=14.11"|]
var_20.WriteLine(var_21)
let (var_22: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_11; "\""|]
var_20.WriteLine(var_22)
let (var_23: string) = String.concat "" [|"\""; var_14; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_12; "\" -I\"C:/cub-1.7.4\" -I\""; var_13; "\" --keep-dir \""; var_4; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_15; "\" \""; var_16; "\""|]
var_20.WriteLine(var_23)
var_20.Dispose()
var_19.Dispose()
let (var_24: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_25: bool) = var_7.Start()
let (var_26: bool) = (var_25 = false)
if var_26 then
    (failwith "NVCC failed to run.")
else
    ()
var_7.BeginOutputReadLine()
var_7.BeginErrorReadLine()
var_7.WaitForExit()
let (var_27: int32) = var_7.get_ExitCode()
let (var_28: bool) = (var_27 = 0)
let (var_29: bool) = (var_28 = false)
if var_29 then
    let (var_30: string) = System.String.Format("{0}",var_27)
    let (var_31: string) = String.concat ", " [|"NVCC failed compilation."; var_30|]
    let (var_32: string) = System.String.Format("[{0}]",var_31)
    (failwith var_32)
else
    ()
let (var_33: System.TimeSpan) = var_24.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_33
let (var_34: ManagedCuda.BasicTypes.CUmodule) = var_3.LoadModulePTX(var_15)
var_7.Dispose()
let (var_35: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_4|]
System.Console.WriteLine(var_35)
let (var_36: EnvHeap1) = ({mem_0 = (var_3: ManagedCuda.CudaContext)} : EnvHeap1)
let (var_37: uint64) = 1073741824UL
let (var_38: ManagedCuda.CudaContext) = var_36.mem_0
let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = var_38.AllocateMemory(var_39)
let (var_41: uint64) = uint64 var_40
let (var_42: (uint64 ref)) = (ref var_41)
let (var_43: ResizeArray<Env2>) = ResizeArray<Env2>()
let (var_44: EnvStack3) = EnvStack3((var_43: ResizeArray<Env2>))
let (var_45: ResizeArray<Env4>) = ResizeArray<Env4>()
let (var_46: EnvStack5) = EnvStack5((var_45: ResizeArray<Env4>))
let (var_47: EnvHeap6) = ({mem_0 = (var_44: EnvStack3); mem_1 = (var_42: (uint64 ref)); mem_2 = (var_37: uint64); mem_3 = (var_46: EnvStack5)} : EnvHeap6)
let (var_48: EnvHeap7) = ({mem_0 = (var_38: ManagedCuda.CudaContext); mem_1 = (var_47: EnvHeap6)} : EnvHeap7)
method_1((var_48: EnvHeap7), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_49: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_50: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_49)
let (var_51: ManagedCuda.CudaContext) = var_48.mem_0
let (var_52: EnvHeap6) = var_48.mem_1
let (var_53: EnvHeap8) = ({mem_0 = (var_51: ManagedCuda.CudaContext); mem_1 = (var_50: ManagedCuda.CudaRand.CudaRandDevice); mem_2 = (var_52: EnvHeap6)} : EnvHeap8)
let (var_54: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_55: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_56: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_54, var_55)
let (var_57: ManagedCuda.CudaContext) = var_53.mem_0
let (var_58: ManagedCuda.CudaRand.CudaRandDevice) = var_53.mem_1
let (var_59: EnvHeap6) = var_53.mem_2
let (var_60: EnvHeap9) = ({mem_0 = (var_57: ManagedCuda.CudaContext); mem_1 = (var_56: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_58: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_59: EnvHeap6)} : EnvHeap9)
let (var_67: ResizeArray<Env10>) = ResizeArray<Env10>()
let (var_68: EnvStack11) = EnvStack11((var_67: ResizeArray<Env10>))
let (var_69: ManagedCuda.CudaContext) = var_60.mem_0
let (var_70: ManagedCuda.CudaBlas.CudaBlas) = var_60.mem_1
let (var_71: ManagedCuda.CudaRand.CudaRandDevice) = var_60.mem_2
let (var_72: EnvHeap6) = var_60.mem_3
let (var_73: EnvHeap12) = ({mem_0 = (var_69: ManagedCuda.CudaContext); mem_1 = (var_70: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_71: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_68: EnvStack11); mem_4 = (var_72: EnvHeap6)} : EnvHeap12)
let (var_85: ResizeArray<Env13>) = ResizeArray<Env13>()
let (var_86: EnvStack14) = EnvStack14((var_85: ResizeArray<Env13>))
let (var_87: ManagedCuda.CudaContext) = var_73.mem_0
let (var_88: ManagedCuda.CudaBlas.CudaBlas) = var_73.mem_1
let (var_89: ManagedCuda.CudaRand.CudaRandDevice) = var_73.mem_2
let (var_90: EnvStack11) = var_73.mem_3
let (var_91: EnvHeap6) = var_73.mem_4
let (var_92: EnvHeap15) = ({mem_0 = (var_87: ManagedCuda.CudaContext); mem_1 = (var_88: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_89: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_90: EnvStack11); mem_4 = (var_86: EnvStack14); mem_5 = (var_91: EnvHeap6)} : EnvHeap15)
let (var_93: (bool ref)) = (ref true)
let (var_94: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_95: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_96: EnvHeap16) = ({mem_0 = (var_95: ManagedCuda.CudaEvent); mem_1 = (var_93: (bool ref)); mem_2 = (var_94: ManagedCuda.CudaStream)} : EnvHeap16)
let (var_97: Env13) = method_7((var_96: EnvHeap16), (var_92: EnvHeap15), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_98: (int64 ref)) = var_97.mem_0
let (var_99: Env17) = var_97.mem_1
let (var_100: EnvHeap16) = var_99.mem_0
let (var_101: ManagedCuda.CudaContext) = var_92.mem_0
let (var_102: ManagedCuda.CudaBlas.CudaBlas) = var_92.mem_1
let (var_103: ManagedCuda.CudaRand.CudaRandDevice) = var_92.mem_2
let (var_104: EnvStack11) = var_92.mem_3
let (var_105: EnvStack14) = var_92.mem_4
let (var_106: EnvHeap6) = var_92.mem_5
let (var_107: EnvHeap18) = ({mem_0 = (var_101: ManagedCuda.CudaContext); mem_1 = (var_102: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_103: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_104: EnvStack11); mem_4 = (var_105: EnvStack14); mem_5 = (var_106: EnvHeap6); mem_6 = (var_98: (int64 ref)); mem_7 = (var_100: EnvHeap16)} : EnvHeap18)
let (var_108: System.Random) = System.Random()
let (var_109: EnvStack0) = EnvStack0((var_108: System.Random))
let (var_142: EnvStack19) = method_9((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_143: (int64 ref)) = var_142.mem_0
let (var_144: (uint64 ref)) = var_142.mem_1
let (var_145: EnvStack19) = method_19((var_143: (int64 ref)), (var_144: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_146: (int64 ref)) = var_145.mem_0
let (var_147: (uint64 ref)) = var_145.mem_1
let (var_148: EnvStack20) = method_21((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_149: (int64 ref)) = var_148.mem_0
let (var_150: (uint64 ref)) = var_148.mem_1
let (var_151: EnvStack20) = method_24((var_149: (int64 ref)), (var_150: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_152: (int64 ref)) = var_151.mem_0
let (var_153: (uint64 ref)) = var_151.mem_1
let (var_154: EnvHeap21) = ({mem_0 = (var_152: (int64 ref)); mem_1 = (var_153: (uint64 ref)); mem_2 = (var_149: (int64 ref)); mem_3 = (var_150: (uint64 ref)); mem_4 = (var_146: (int64 ref)); mem_5 = (var_147: (uint64 ref)); mem_6 = (var_143: (int64 ref)); mem_7 = (var_144: (uint64 ref))} : EnvHeap21)
let (var_155: EnvStack22) = method_25((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_156: (int64 ref)) = var_155.mem_0
let (var_157: (uint64 ref)) = var_155.mem_1
let (var_158: EnvStack22) = method_28((var_156: (int64 ref)), (var_157: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_159: (int64 ref)) = var_158.mem_0
let (var_160: (uint64 ref)) = var_158.mem_1
let (var_161: EnvStack20) = method_21((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: (uint64 ref)) = var_161.mem_1
let (var_164: EnvStack20) = method_24((var_162: (int64 ref)), (var_163: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_165: (int64 ref)) = var_164.mem_0
let (var_166: (uint64 ref)) = var_164.mem_1
let (var_167: EnvHeap23) = ({mem_0 = (var_165: (int64 ref)); mem_1 = (var_166: (uint64 ref)); mem_2 = (var_162: (int64 ref)); mem_3 = (var_163: (uint64 ref)); mem_4 = (var_159: (int64 ref)); mem_5 = (var_160: (uint64 ref)); mem_6 = (var_156: (int64 ref)); mem_7 = (var_157: (uint64 ref))} : EnvHeap23)
let (var_168: EnvStack24) = method_30((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_169: (int64 ref)) = var_168.mem_0
let (var_170: (uint64 ref)) = var_168.mem_1
let (var_171: EnvStack24) = method_33((var_169: (int64 ref)), (var_170: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_172: (int64 ref)) = var_171.mem_0
let (var_173: (uint64 ref)) = var_171.mem_1
let (var_174: EnvStack25) = method_35((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_175: (int64 ref)) = var_174.mem_0
let (var_176: (uint64 ref)) = var_174.mem_1
let (var_177: EnvStack25) = method_38((var_175: (int64 ref)), (var_176: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_178: (int64 ref)) = var_177.mem_0
let (var_179: (uint64 ref)) = var_177.mem_1
let (var_181: (float -> unit)) = method_39
let (var_182: int64) = 0L
method_40((var_154: EnvHeap21), (var_167: EnvHeap23), (var_178: (int64 ref)), (var_179: (uint64 ref)), (var_175: (int64 ref)), (var_176: (uint64 ref)), (var_172: (int64 ref)), (var_173: (uint64 ref)), (var_169: (int64 ref)), (var_170: (uint64 ref)), (var_181: (float -> unit)), (var_109: EnvStack0), (var_1: EnvStack0), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule), (var_182: int64))
method_156((var_105: EnvStack14))
method_154((var_90: EnvStack11))
var_56.Dispose()
var_50.Dispose()
let (var_183: uint64) = method_5((var_42: (uint64 ref)))
let (var_184: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_183)
let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_184)
var_51.FreeMemory(var_185)
var_42 := 0UL
var_3.Dispose()

