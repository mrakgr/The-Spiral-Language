module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
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
    typedef float(*FunPointer0)(float, float);
    struct Tuple2 {
        float mem_0;
        long long int mem_1;
    };
    __device__ __forceinline__ Tuple2 make_Tuple2(float mem_0, long long int mem_1){
        Tuple2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple5 {
        Tuple2 mem_0;
        Tuple2 mem_1;
    };
    __device__ __forceinline__ Tuple5 make_Tuple5(Tuple2 mem_0, Tuple2 mem_1){
        Tuple5 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple2(*FunPointer1)(Tuple2, Tuple2);
    struct Tuple4 {
        float mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ Tuple4 make_Tuple4(float mem_0, float mem_1, float mem_2){
        Tuple4 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    __global__ void method_122(float * var_0, float * var_1);
    __global__ void method_125(float * var_0, float * var_1);
    __global__ void method_129(float * var_0, float * var_1);
    __global__ void method_132(float * var_0, float * var_1);
    __global__ void method_52(float * var_0, float * var_1, float * var_2);
    __global__ void method_77(float * var_0, float * var_1, float * var_2);
    __global__ void method_43(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, long long int var_5, float * var_6);
    __global__ void method_58(float * var_0, float * var_1);
    __global__ void method_90(float * var_0, float * var_1);
    __global__ void method_99(float * var_0, float * var_1, long long int * var_2);
    __global__ void method_105(long long int * var_0, float * var_1, float var_2, float * var_3);
    __global__ void method_63(float * var_0, float * var_1, float * var_2);
    __global__ void method_68(float * var_0, float * var_1);
    __global__ void method_85(float * var_0, float * var_1);
    __device__ char method_53(long long int * var_0);
    __device__ char method_126(long long int * var_0);
    __device__ char method_78(long long int * var_0);
    __device__ char method_133(long long int * var_0);
    __device__ char method_54(long long int * var_0);
    __device__ char method_44(long long int * var_0);
    __device__ float method_91(float var_0, float var_1);
    __device__ char method_100(long long int * var_0, float * var_1, float * var_2, long long int * var_3);
    __device__ Tuple2 method_101(Tuple2 var_0, Tuple2 var_1);
    __device__ char method_69(long long int * var_0, float * var_1);
    
    __global__ void method_122(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_53(var_6)) {
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
    __global__ void method_125(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_126(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 28672);
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
                var_14 = (var_8 < 28672);
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
    __global__ void method_129(float * var_0, float * var_1) {
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
                var_11 = (var_8 < 3);
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
                var_14 = (var_8 < 3);
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
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_132(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_133(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 768);
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
                var_14 = (var_8 < 768);
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
            long long int var_20 = (var_8 + 768);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_52(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_53(var_7)) {
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
            while (method_54(var_18)) {
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
    __global__ void method_77(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (3 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_78(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 3);
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
            while (method_54(var_18)) {
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
                long long int var_25 = (var_20 * 3);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 3);
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
                    var_34 = (var_9 < 3);
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
            long long int var_41 = (var_9 + 3);
            var_7[0] = var_41;
        }
        long long int var_42 = var_7[0];
    }
    __global__ void method_43(long long int var_0, long long int var_1, long long int var_2, long long int var_3, long long int var_4, long long int var_5, float * var_6) {
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (112 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11[1];
        var_11[0] = var_10;
        while (method_44(var_11)) {
            long long int var_13 = var_11[0];
            long long int var_14 = (var_13 % 112);
            long long int var_15 = (var_13 / 112);
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
                var_30 = (var_14 < 112);
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
            long long int var_33 = (var_13 + 112);
            var_11[0] = var_33;
        }
        long long int var_34 = var_11[0];
    }
    __global__ void method_58(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = threadIdx.y;
        long long int var_7 = blockIdx.y;
        long long int var_8 = (var_6 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_54(var_9)) {
            long long int var_11 = var_9[0];
            float var_25[1];
            long long int var_26[1];
            var_26[0] = 0;
            while (method_54(var_26)) {
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
            while (method_54(var_63)) {
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
            while (method_54(var_91)) {
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
            while (method_54(var_114)) {
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
    __global__ void method_90(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (3 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = threadIdx.y;
        long long int var_7 = blockIdx.y;
        long long int var_8 = (var_6 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_54(var_9)) {
            long long int var_11 = var_9[0];
            float var_25[1];
            long long int var_26[1];
            var_26[0] = 0;
            while (method_54(var_26)) {
                long long int var_28 = var_26[0];
                long long int var_29 = (3 * var_28);
                long long int var_30 = (var_5 + var_29);
                long long int var_31 = (3 - var_29);
                char var_32 = (var_30 < 3);
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
                    long long int var_41 = (var_11 * 3);
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
            FunPointer0 var_50 = method_91;
            float var_51 = cub::BlockReduce<float,3,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_25, var_50);
            __shared__ float var_52[1];
            long long int var_53 = threadIdx.x;
            char var_54 = (var_53 == 0);
            if (var_54) {
                var_52[0] = var_51;
            } else {
            }
            __syncthreads();
            float var_55 = var_52[0];
            float var_65[1];
            long long int var_66[1];
            var_66[0] = 0;
            while (method_54(var_66)) {
                long long int var_68 = var_66[0];
                long long int var_69 = (3 * var_68);
                long long int var_70 = (var_5 + var_69);
                long long int var_71 = (3 - var_69);
                char var_72 = (var_70 < 3);
                if (var_72) {
                    char var_73 = (var_68 >= 0);
                    char var_75;
                    if (var_73) {
                        var_75 = (var_68 < 1);
                    } else {
                        var_75 = 0;
                    }
                    char var_76 = (var_75 == 0);
                    if (var_76) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_78;
                    if (var_73) {
                        var_78 = (var_68 < 1);
                    } else {
                        var_78 = 0;
                    }
                    char var_79 = (var_78 == 0);
                    if (var_79) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_80 = var_25[var_68];
                    float var_81 = (var_80 - var_55);
                    float var_82 = exp(var_81);
                    var_65[var_68] = var_82;
                } else {
                }
                long long int var_83 = (var_68 + 1);
                var_66[0] = var_83;
            }
            long long int var_84 = var_66[0];
            float var_85 = cub::BlockReduce<float,3,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_65);
            __shared__ float var_86[1];
            long long int var_87 = threadIdx.x;
            char var_88 = (var_87 == 0);
            if (var_88) {
                var_86[0] = var_85;
            } else {
            }
            __syncthreads();
            float var_89 = var_86[0];
            long long int var_90[1];
            var_90[0] = 0;
            while (method_54(var_90)) {
                long long int var_92 = var_90[0];
                long long int var_93 = (3 * var_92);
                long long int var_94 = (var_5 + var_93);
                long long int var_95 = (3 - var_93);
                char var_96 = (var_94 < 3);
                if (var_96) {
                    char var_97 = (var_92 >= 0);
                    char var_99;
                    if (var_97) {
                        var_99 = (var_92 < 1);
                    } else {
                        var_99 = 0;
                    }
                    char var_100 = (var_99 == 0);
                    if (var_100) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_101 = var_65[var_92];
                    char var_102 = (var_11 >= 0);
                    char var_104;
                    if (var_102) {
                        var_104 = (var_11 < 1);
                    } else {
                        var_104 = 0;
                    }
                    char var_105 = (var_104 == 0);
                    if (var_105) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_106 = (var_11 * 3);
                    char var_107 = (var_94 >= 0);
                    char var_108 = (var_107 == 0);
                    if (var_108) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_109 = (var_106 + var_94);
                    float var_110 = var_1[var_109];
                    float var_111 = (var_101 / var_89);
                    var_1[var_109] = var_111;
                } else {
                }
                long long int var_112 = (var_92 + 1);
                var_90[0] = var_112;
            }
            long long int var_113 = var_90[0];
            long long int var_114 = (var_11 + 1);
            var_9[0] = var_114;
        }
        long long int var_115 = var_9[0];
    }
    __global__ void method_99(float * var_0, float * var_1, long long int * var_2) {
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
            float var_17 = var_1[var_8];
            long long int var_18 = threadIdx.x;
            long long int var_19 = blockIdx.x;
            long long int var_20 = (3 * var_19);
            long long int var_21 = (var_18 + var_20);
            float var_22 = 0;
            float var_23 = __int_as_float(0x7f800000);
            long long int var_24 = 0;
            long long int var_25[1];
            float var_26[1];
            float var_27[1];
            long long int var_28[1];
            var_25[0] = var_21;
            var_26[0] = var_22;
            var_27[0] = var_23;
            var_28[0] = var_24;
            while (method_100(var_25, var_26, var_27, var_28)) {
                long long int var_30 = var_25[0];
                float var_31 = var_26[0];
                float var_32 = var_27[0];
                long long int var_33 = var_28[0];
                char var_34 = (var_30 >= 0);
                char var_36;
                if (var_34) {
                    var_36 = (var_30 < 3);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_38 = (var_13 + var_30);
                float var_39 = var_0[var_38];
                float var_40[1];
                float var_41 = var_40[0];
                float var_42[1];
                float var_43 = var_42[0];
                cub::BlockScan<float,3,cub::BLOCK_SCAN_RAKING_MEMOIZE,1,1>().InclusiveSum(var_39, var_41, var_43);
                float var_44 = (var_31 + var_41);
                float var_45 = (var_31 + var_43);
                float var_46 = (var_44 - var_17);
                char var_47 = (var_46 < 0);
                float var_48;
                if (var_47) {
                    var_48 = __int_as_float(0x7f800000);
                } else {
                    var_48 = var_46;
                }
                FunPointer1 var_51 = method_101;
                Tuple2 var_52 = cub::BlockReduce<Tuple2,3,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple2(var_48, var_30), var_51);
                float var_53 = var_52.mem_0;
                long long int var_54 = var_52.mem_1;
                char var_55 = (var_32 <= var_53);
                Tuple2 var_56;
                if (var_55) {
                    var_56 = make_Tuple2(var_32, var_33);
                } else {
                    var_56 = make_Tuple2(var_53, var_54);
                }
                float var_57 = var_56.mem_0;
                long long int var_58 = var_56.mem_1;
                long long int var_59 = (var_30 + 3);
                var_25[0] = var_59;
                var_26[0] = var_45;
                var_27[0] = var_57;
                var_28[0] = var_58;
            }
            long long int var_60 = var_25[0];
            float var_61 = var_26[0];
            float var_62 = var_27[0];
            long long int var_63 = var_28[0];
            long long int var_64 = threadIdx.x;
            char var_65 = (var_64 == 0);
            if (var_65) {
                char var_67;
                if (var_9) {
                    var_67 = (var_8 < 1);
                } else {
                    var_67 = 0;
                }
                char var_68 = (var_67 == 0);
                if (var_68) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_69 = var_2[var_8];
                var_2[var_8] = var_63;
            } else {
            }
            long long int var_70 = (var_8 + 1);
            var_6[0] = var_70;
        }
        long long int var_71 = var_6[0];
    }
    __global__ void method_105(long long int * var_0, float * var_1, float var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (3 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_78(var_8)) {
            long long int var_10 = var_8[0];
            long long int var_11 = (var_10 % 3);
            long long int var_12 = (var_10 / 3);
            long long int var_13 = var_0[0];
            char var_14 = (var_11 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_11 < 3);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_1[var_11];
            char var_20;
            if (var_14) {
                var_20 = (var_11 < 3);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            char var_22 = (var_13 == var_11);
            float var_23;
            if (var_22) {
                var_23 = 1;
            } else {
                var_23 = 0;
            }
            float var_24 = var_3[var_11];
            float var_25 = (var_18 - var_23);
            float var_26 = (var_25 * var_2);
            float var_27 = (var_24 + var_26);
            var_3[var_11] = var_27;
            long long int var_28 = (var_10 + 3);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __global__ void method_63(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7 = threadIdx.y;
        long long int var_8 = blockIdx.y;
        long long int var_9 = (var_7 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_54(var_10)) {
            long long int var_12 = var_10[0];
            Tuple3 var_27[1];
            long long int var_28[1];
            var_28[0] = 0;
            while (method_54(var_28)) {
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
                    var_27[var_30] = make_Tuple3(var_47, var_48);
                } else {
                }
                long long int var_49 = (var_30 + 1);
                var_28[0] = var_49;
            }
            long long int var_50 = var_28[0];
            float var_60[1];
            long long int var_61[1];
            var_61[0] = 0;
            while (method_54(var_61)) {
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
                    Tuple3 var_75 = var_27[var_63];
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
            Tuple3 var_96[1];
            long long int var_97[1];
            var_97[0] = 0;
            while (method_54(var_97)) {
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
                    Tuple3 var_111 = var_27[var_99];
                    float var_112 = var_111.mem_0;
                    float var_113 = var_111.mem_1;
                    float var_114 = (var_84 / 256);
                    float var_115 = (var_113 - var_114);
                    var_96[var_99] = make_Tuple3(var_112, var_115);
                } else {
                }
                long long int var_116 = (var_99 + 1);
                var_97[0] = var_116;
            }
            long long int var_117 = var_97[0];
            float var_128[1];
            long long int var_129[1];
            var_129[0] = 0;
            while (method_54(var_129)) {
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
                    Tuple3 var_143 = var_96[var_131];
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
            Tuple4 var_167[1];
            long long int var_168[1];
            var_168[0] = 0;
            while (method_54(var_168)) {
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
                    Tuple3 var_182 = var_96[var_170];
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
                    var_167[var_170] = make_Tuple4(var_186, var_184, var_188);
                } else {
                }
                long long int var_189 = (var_170 + 1);
                var_168[0] = var_189;
            }
            long long int var_190 = var_168[0];
            float var_205[1];
            long long int var_206[1];
            var_206[0] = 0;
            while (method_54(var_206)) {
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
                    Tuple4 var_220 = var_167[var_208];
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
            while (method_54(var_251)) {
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
                    Tuple4 var_265 = var_167[var_253];
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
            while (method_54(var_281)) {
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
    __global__ void method_68(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_53(var_6)) {
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
            while (method_69(var_20, var_21)) {
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
    __global__ void method_85(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (3 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_78(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 3);
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
                var_14 = (var_8 < 3);
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
            while (method_69(var_20, var_21)) {
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
                long long int var_29 = (var_23 * 3);
                char var_31;
                if (var_9) {
                    var_31 = (var_8 < 3);
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
            long long int var_43 = (var_8 + 3);
            var_6[0] = var_43;
        }
        long long int var_44 = var_6[0];
    }
    __device__ char method_53(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 256);
    }
    __device__ char method_126(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 28672);
    }
    __device__ char method_78(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 3);
    }
    __device__ char method_133(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 768);
    }
    __device__ char method_54(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_44(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 112);
    }
    __device__ float method_91(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_100(long long int * var_0, float * var_1, float * var_2, long long int * var_3) {
        long long int var_4 = var_0[0];
        float var_5 = var_1[0];
        float var_6 = var_2[0];
        long long int var_7 = var_3[0];
        return (var_4 < 3);
    }
    __device__ Tuple2 method_101(Tuple2 var_0, Tuple2 var_1) {
        float var_2 = var_0.mem_0;
        long long int var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        long long int var_5 = var_1.mem_1;
        char var_6 = (var_2 <= var_4);
        Tuple2 var_7;
        if (var_6) {
            var_7 = make_Tuple2(var_2, var_3);
        } else {
            var_7 = make_Tuple2(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        long long int var_9 = var_7.mem_1;
        return make_Tuple2(var_8, var_9);
    }
    __device__ char method_69(long long int * var_0, float * var_1) {
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
    val mem_0: Env31
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
    val mem_1: Env31
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
and EnvStack23 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap24 =
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
and EnvHeap25 =
    {
    mem_0: EnvHeap21
    mem_1: EnvHeap24
    }
and Union26 =
    | Union26Case0 of Tuple32
    | Union26Case1 of Tuple33
and EnvStack27 =
    struct
    val mem_0: ResizeArray<Union26>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack28 =
    struct
    val mem_0: EnvStack27
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap29 =
    {
    mem_0: EnvHeap25
    mem_1: (int64 ref)
    }
and EnvHeap30 =
    {
    mem_0: (int64 ref)
    }
and Env31 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple32 =
    struct
    val mem_0: Tuple34
    val mem_1: Union35
    val mem_2: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple33 =
    struct
    val mem_0: float
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple34 =
    struct
    val mem_0: Env37
    val mem_1: Env37
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union35 =
    | Union35Case0
    | Union35Case1
    | Union35Case2
and EnvHeap36 =
    {
    mem_0: EnvHeap18
    mem_1: ManagedCuda.BasicTypes.CUmodule
    mem_2: EnvHeap25
    mem_3: (int64 ref)
    }
and Env37 =
    struct
    val mem_0: int64
    val mem_1: Union40
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvHeap38 =
    {
    mem_0: EnvHeap18
    mem_1: ManagedCuda.BasicTypes.CUmodule
    mem_2: (int64 ref)
    mem_3: EnvHeap25
    mem_4: (int64 ref)
    }
and EnvHeap39 =
    {
    mem_0: (int64 ref)
    mem_1: (int64 ref)
    }
and Union40 =
    | Union40Case0 of Tuple44
    | Union40Case1
and Env41 =
    struct
    val mem_0: Union42
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union42 =
    | Union42Case0
    | Union42Case1
    | Union42Case2
    | Union42Case3
    | Union42Case4
    | Union42Case5
    | Union42Case6
    | Union42Case7
    | Union42Case8
    | Union42Case9
    | Union42Case10
    | Union42Case11
    | Union42Case12
and EnvHeapMutable43 =
    {
    mutable mem_0: (Env41 [])
    mutable mem_1: int64
    }
and Tuple44 =
    struct
    val mem_0: Env41
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeapMutable45 =
    {
    mutable mem_0: Union40
    mutable mem_1: int64
    }
and EnvHeap46 =
    {
    mem_0: EnvHeap18
    mem_1: ManagedCuda.BasicTypes.CUmodule
    mem_2: (int64 ref)
    mem_3: EnvHeap25
    mem_4: EnvHeapMutable45
    mem_5: (int64 ref)
    }
and EnvHeap47 =
    {
    mem_0: (int64 ref)
    mem_1: EnvHeapMutable45
    mem_2: (int64 ref)
    }
and Union48 =
    | Union48Case0 of Tuple50
    | Union48Case1
and Env49 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Tuple50 =
    struct
    val mem_0: Env49
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack51 =
    struct
    val mem_0: Union35
    val mem_1: (unit -> unit)
    val mem_2: (unit -> unit)
    val mem_3: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack52 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack53 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    val mem_4: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and EnvStack54 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (int64 ref)
    val mem_3: (uint64 ref)
    val mem_4: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and EnvStack55 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvStack56 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
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
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack59 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
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
    let (var_4: Env31) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_17((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack19((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_19((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack19 =
    let (var_4: Env10) = method_10((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env31) = var_4.mem_1
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
    let (var_4: Env31) = var_2.mem_1
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
    let (var_6: Env31) = var_4.mem_1
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
    let (var_4: Env31) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_27((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack22((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_28((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_4: Env10) = method_26((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env31) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_29((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack22((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_30((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack23 =
    let (var_2: Env10) = method_31((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env31) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    let (var_6: (int64 ref)) = var_0.mem_6
    let (var_7: EnvHeap16) = var_0.mem_7
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_18((var_7: EnvHeap16))
    let (var_9: ManagedCuda.CudaContext) = var_0.mem_0
    method_32((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_9: ManagedCuda.CudaContext), (var_8: ManagedCuda.BasicTypes.CUstream))
    EnvStack23((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_33((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack23 =
    let (var_4: Env10) = method_31((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env31) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_32((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack23((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_34((var_0: EnvHeap29), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_5: int64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: int64) = 0L
    method_35((var_0: EnvHeap29), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_5: int64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_4: int64), (var_8: int64))
and method_138((var_0: EnvStack14)): unit =
    let (var_1: ResizeArray<Env13>) = var_0.mem_0
    let (var_3: (Env13 -> unit)) = method_139
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_136((var_0: EnvStack11)): unit =
    let (var_1: ResizeArray<Env10>) = var_0.mem_0
    let (var_3: (Env10 -> unit)) = method_137
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
    let (var_1: Env31) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: uint64) = (!var_2)
    (var_4 = 0UL)
and method_3 ((var_0: Env4)): (Env4 -> int32) =
    let (var_1: Env31) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    method_4((var_2: (uint64 ref)))
and method_6((var_0: EnvStack3), (var_1: EnvStack5), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env4>) = var_1.mem_0
        let (var_7: Env4) = var_6.[var_4]
        let (var_8: Env31) = var_7.mem_0
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
    let (var_2: int64) = 114688L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_17((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(28672L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.052129f)
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
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(114688L)
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
    let (var_2: int64) = 3072L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_27((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(768L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.087875f)
and method_29((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(3072L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_31((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 12L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_32((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(12L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_35((var_0: EnvHeap29), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_5: EnvHeap18), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: int64), (var_8: int64)): unit =
    let (var_9: bool) = (var_8 < var_7)
    if var_9 then
        let (var_10: string) = System.String.Format("iteration {0}",var_8)
        let (var_11: string) = System.String.Format("Starting timing for: {0}",var_10)
        System.Console.WriteLine(var_11)
        let (var_12: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
        method_15((var_5: EnvHeap18), (var_6: ManagedCuda.BasicTypes.CUmodule))
        let (var_19: ResizeArray<Env10>) = ResizeArray<Env10>()
        let (var_20: EnvStack11) = EnvStack11((var_19: ResizeArray<Env10>))
        let (var_21: ManagedCuda.CudaContext) = var_5.mem_0
        let (var_22: ManagedCuda.CudaBlas.CudaBlas) = var_5.mem_1
        let (var_23: ManagedCuda.CudaRand.CudaRandDevice) = var_5.mem_2
        let (var_24: EnvStack11) = var_5.mem_3
        let (var_25: EnvStack14) = var_5.mem_4
        let (var_26: EnvHeap6) = var_5.mem_5
        let (var_27: (int64 ref)) = var_5.mem_6
        let (var_28: EnvHeap16) = var_5.mem_7
        let (var_29: EnvHeap18) = ({mem_0 = (var_21: ManagedCuda.CudaContext); mem_1 = (var_22: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_23: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_20: EnvStack11); mem_4 = (var_25: EnvStack14); mem_5 = (var_26: EnvHeap6); mem_6 = (var_27: (int64 ref)); mem_7 = (var_28: EnvHeap16)} : EnvHeap18)
        let (var_30: (int64 ref)) = (ref 0L)
        let (var_31: EnvHeap25) = var_0.mem_0
        let (var_32: (int64 ref)) = var_0.mem_1
        let (var_33: EnvHeap36) = ({mem_0 = (var_29: EnvHeap18); mem_1 = (var_6: ManagedCuda.BasicTypes.CUmodule); mem_2 = (var_31: EnvHeap25); mem_3 = (var_30: (int64 ref))} : EnvHeap36)
        let (var_34: (int64 ref)) = (ref 0L)
        let (var_35: (int64 ref)) = var_2.mem_0
        let (var_36: EnvHeap30) = ({mem_0 = (var_34: (int64 ref))} : EnvHeap30)
        let (var_37: int64) = 0L
        method_107((var_33: EnvHeap36), (var_1: EnvStack28), (var_36: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_37: int64))
        let (var_38: (int64 ref)) = var_33.mem_3
        let (var_39: int64) = (!var_38)
        let (var_40: (int64 ref)) = var_36.mem_0
        let (var_41: int64) = (!var_40)
        let (var_42: int64) = (var_39 + var_41)
        let (var_43: string) = System.String.Format("Winrate is {0} and {1} out of {2}.",var_39,var_41,var_42)
        System.Console.WriteLine(var_43)
        let (var_44: EnvStack11) = var_29.mem_3
        method_136((var_44: EnvStack11))
        let (var_45: System.TimeSpan) = var_12.Elapsed
        let (var_46: string) = System.String.Format("The time was {0} for: {1}",var_45,var_10)
        System.Console.WriteLine(var_46)
        let (var_47: int64) = (var_8 + 1L)
        method_35((var_0: EnvHeap29), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_5: EnvHeap18), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: int64), (var_47: int64))
    else
        ()
and method_139 ((var_0: Env13)): unit =
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
and method_137 ((var_0: Env10)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env31) = var_0.mem_1
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
    let (var_2: Env31) = var_0.mem_0
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
    let (var_7: Env31) = method_12((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_6: uint64))
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: (int64 ref)) = (ref 0L)
    let (var_10: EnvStack11) = var_0.mem_3
    method_16((var_9: (int64 ref)), (var_8: (uint64 ref)), (var_10: EnvStack11))
    (Env10(var_9, (Env31(var_8))))
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
and method_107((var_0: EnvHeap36), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < var_4)
    if var_6 then
        let (var_7: (int64 ref)) = (ref 10L)
        let (var_8: EnvHeap18) = var_0.mem_0
        let (var_9: ManagedCuda.BasicTypes.CUmodule) = var_0.mem_1
        let (var_10: EnvHeap25) = var_0.mem_2
        let (var_11: (int64 ref)) = var_0.mem_3
        let (var_12: EnvHeap38) = ({mem_0 = (var_8: EnvHeap18); mem_1 = (var_9: ManagedCuda.BasicTypes.CUmodule); mem_2 = (var_7: (int64 ref)); mem_3 = (var_10: EnvHeap25); mem_4 = (var_11: (int64 ref))} : EnvHeap38)
        let (var_13: (int64 ref)) = (ref 10L)
        let (var_14: (int64 ref)) = var_2.mem_0
        let (var_15: EnvHeap39) = ({mem_0 = (var_13: (int64 ref)); mem_1 = (var_14: (int64 ref))} : EnvHeap39)
        method_108((var_3: EnvStack0), (var_12: EnvHeap38), (var_1: EnvStack28), (var_15: EnvHeap39))
        let (var_16: int64) = (var_5 + 1L)
        method_107((var_0: EnvHeap36), (var_1: EnvStack28), (var_2: EnvHeap30), (var_3: EnvStack0), (var_4: int64), (var_16: int64))
    else
        ()
and method_12((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: uint64)): Env31 =
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
            (Env4((Env31(var_18)), var_2))
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
                (Env4((Env31(var_28)), var_2))
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
                    (Env4((Env31(var_38)), var_2))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_43: Env31) = var_42.mem_0
    let (var_44: (uint64 ref)) = var_43.mem_0
    let (var_45: uint64) = var_42.mem_1
    let (var_46: ResizeArray<Env4>) = var_6.mem_0
    var_46.Add((Env4((Env31(var_44)), var_45)))
    (Env31(var_44))
and method_16((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack11)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env10>) = var_2.mem_0
    var_5.Add((Env10(var_0, (Env31(var_1)))))
and method_108((var_0: EnvStack0), (var_1: EnvHeap38), (var_2: EnvStack28), (var_3: EnvHeap39)): unit =
    let (var_4: (int64 ref)) = var_1.mem_2
    let (var_5: int64) = (!var_4)
    let (var_6: (int64 ref)) = var_3.mem_0
    let (var_7: int64) = (!var_6)
    let (var_9: (Env41 [])) = [|(Env41(Union42Case12)); (Env41(Union42Case11)); (Env41(Union42Case3)); (Env41(Union42Case2)); (Env41(Union42Case9)); (Env41(Union42Case8)); (Env41(Union42Case1)); (Env41(Union42Case6)); (Env41(Union42Case10)); (Env41(Union42Case4)); (Env41(Union42Case7)); (Env41(Union42Case5)); (Env41(Union42Case0))|]
    let (var_10: int64) = var_9.LongLength
    let (var_11: bool) = (var_10 = 13L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_109((var_9: (Env41 [])), (var_0: EnvStack0))
    let (var_13: int64) = 13L
    let (var_14: EnvHeapMutable43) = ({mem_0 = (var_9: (Env41 [])); mem_1 = (var_13: int64)} : EnvHeapMutable43)
    // In dealing.
    let (var_15: int64) = var_14.mem_1
    let (var_16: int64) = (var_15 - 1L)
    var_14.mem_1 <- var_16
    let (var_17: (Env41 [])) = var_14.mem_0
    let (var_18: Env41) = var_17.[int32 var_16]
    let (var_19: Union42) = var_18.mem_0
    let (var_20: Union40) = (Union40Case0(Tuple44((Env41(var_19)))))
    let (var_21: int64) = 0L
    let (var_22: EnvHeapMutable45) = ({mem_0 = (var_20: Union40); mem_1 = (var_21: int64)} : EnvHeapMutable45)
    let (var_23: EnvHeap18) = var_1.mem_0
    let (var_24: ManagedCuda.BasicTypes.CUmodule) = var_1.mem_1
    let (var_25: EnvHeap25) = var_1.mem_3
    let (var_26: (int64 ref)) = var_1.mem_4
    let (var_27: EnvHeap46) = ({mem_0 = (var_23: EnvHeap18); mem_1 = (var_24: ManagedCuda.BasicTypes.CUmodule); mem_2 = (var_4: (int64 ref)); mem_3 = (var_25: EnvHeap25); mem_4 = (var_22: EnvHeapMutable45); mem_5 = (var_26: (int64 ref))} : EnvHeap46)
    let (var_28: (int64 ref)) = var_27.mem_2
    let (var_29: int64) = (!var_28)
    let (var_30: EnvHeapMutable45) = var_27.mem_4
    let (var_31: int64) = var_30.mem_1
    let (var_32: int64) = (1L - var_31)
    let (var_33: bool) = (var_29 > var_32)
    let (var_34: int64) =
        if var_33 then
            var_32
        else
            var_29
    let (var_35: int64) = (-var_34)
    let (var_36: int64) = (!var_28)
    let (var_37: int64) = (var_36 + var_35)
    var_28 := var_37
    let (var_38: int64) = var_30.mem_1
    let (var_39: int64) = (var_38 + var_34)
    var_30.mem_1 <- var_39
    let (var_40: int64) = var_30.mem_1
    let (var_41: bool) = (var_40 > 0L)
    let (var_42: int64) = var_14.mem_1
    let (var_43: int64) = (var_42 - 1L)
    var_14.mem_1 <- var_43
    let (var_44: (Env41 [])) = var_14.mem_0
    let (var_45: Env41) = var_44.[int32 var_43]
    let (var_46: Union42) = var_45.mem_0
    let (var_47: Union40) = (Union40Case0(Tuple44((Env41(var_46)))))
    let (var_48: int64) = 0L
    let (var_49: EnvHeapMutable45) = ({mem_0 = (var_47: Union40); mem_1 = (var_48: int64)} : EnvHeapMutable45)
    let (var_50: (int64 ref)) = var_3.mem_1
    let (var_51: EnvHeap47) = ({mem_0 = (var_6: (int64 ref)); mem_1 = (var_49: EnvHeapMutable45); mem_2 = (var_50: (int64 ref))} : EnvHeap47)
    let (var_52: (int64 ref)) = var_51.mem_0
    let (var_53: int64) = (!var_52)
    let (var_54: EnvHeapMutable45) = var_51.mem_1
    let (var_55: int64) = var_54.mem_1
    let (var_56: int64) = (2L - var_55)
    let (var_57: bool) = (var_53 > var_56)
    let (var_58: int64) =
        if var_57 then
            var_56
        else
            var_53
    let (var_59: int64) = (-var_58)
    let (var_60: int64) = (!var_52)
    let (var_61: int64) = (var_60 + var_59)
    var_52 := var_61
    let (var_62: int64) = var_54.mem_1
    let (var_63: int64) = (var_62 + var_58)
    var_54.mem_1 <- var_63
    let (var_64: int64) = var_54.mem_1
    let (var_65: bool) = (var_64 > 0L)
    let (var_66: int64) = (!var_28)
    let (var_67: bool) = (var_66 > 0L)
    let (var_73: bool) =
        if var_67 then
            let (var_68: Union40) = var_30.mem_0
            match var_68 with
            | Union40Case0(var_69) ->
                let (var_70: Env41) = var_69.mem_0
                let (var_71: Union42) = var_70.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_77: int64) =
        if var_73 then
            let (var_74: int64) = var_30.mem_1
            let (var_75: bool) = (0L > var_74)
            if var_75 then
                0L
            else
                var_74
        else
            0L
    let (var_78: int64) = (!var_52)
    let (var_79: bool) = (var_78 > 0L)
    let (var_85: bool) =
        if var_79 then
            let (var_80: Union40) = var_54.mem_0
            match var_80 with
            | Union40Case0(var_81) ->
                let (var_82: Env41) = var_81.mem_0
                let (var_83: Union42) = var_82.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_89: int64) =
        if var_85 then
            let (var_86: int64) = var_54.mem_1
            let (var_87: bool) = (var_77 > var_86)
            if var_87 then
                var_77
            else
                var_86
        else
            var_77
    let (var_90: int64) = (!var_28)
    let (var_91: bool) = (var_90 > 0L)
    let (var_97: bool) =
        if var_91 then
            let (var_92: Union40) = var_30.mem_0
            match var_92 with
            | Union40Case0(var_93) ->
                let (var_94: Env41) = var_93.mem_0
                let (var_95: Union42) = var_94.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_98: int64) =
        if var_97 then
            1L
        else
            0L
    let (var_99: int64) = (!var_52)
    let (var_100: bool) = (var_99 > 0L)
    let (var_106: bool) =
        if var_100 then
            let (var_101: Union40) = var_54.mem_0
            match var_101 with
            | Union40Case0(var_102) ->
                let (var_103: Env41) = var_102.mem_0
                let (var_104: Union42) = var_103.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_108: int64) =
        if var_106 then
            (var_98 + 1L)
        else
            var_98
    let (var_109: int64) = 2L
    let (var_110: int64) = 0L
    method_111((var_89: int64), (var_109: int64), (var_108: int64), (var_110: int64), (var_27: EnvHeap46), (var_2: EnvStack28), (var_51: EnvHeap47))
    let (var_111: int64) = (!var_28)
    let (var_112: int64) = var_30.mem_1
    let (var_113: int64) = (var_111 + var_112)
    let (var_114: int64) = (!var_52)
    let (var_115: int64) = var_54.mem_1
    let (var_116: int64) = (var_114 + var_115)
    let (var_117: Union40) = var_30.mem_0
    match var_117 with
    | Union40Case0(var_118) ->
        let (var_119: Env41) = var_118.mem_0
        let (var_120: Union42) = var_119.mem_0
        let (var_121: Union40) = var_54.mem_0
        match var_121 with
        | Union40Case0(var_122) ->
            let (var_123: Env41) = var_122.mem_0
            let (var_124: Union42) = var_123.mem_0
            let (var_125: int32) = method_115((var_120: Union42))
            let (var_126: int32) = method_115((var_124: Union42))
            let (var_127: bool) = (var_125 < var_126)
            let (var_130: int32) =
                if var_127 then
                    -1
                else
                    let (var_128: bool) = (var_125 = var_126)
                    if var_128 then
                        0
                    else
                        1
            let (var_131: bool) = (var_130 = 1)
            if var_131 then
                method_116((var_27: EnvHeap46), (var_2: EnvStack28), (var_51: EnvHeap47))
            else
                let (var_132: bool) = (var_130 = 0)
                if var_132 then
                    let (var_133: int64) = var_30.mem_1
                    let (var_134: int64) = var_30.mem_1
                    let (var_135: int64) = (var_134 - var_133)
                    let (var_136: bool) = (0L > var_135)
                    let (var_137: int64) =
                        if var_136 then
                            0L
                        else
                            var_135
                    var_30.mem_1 <- var_137
                    let (var_138: int64) = (var_134 - var_137)
                    let (var_139: int64) = (!var_28)
                    let (var_140: int64) = (var_139 + var_138)
                    var_28 := var_140
                    let (var_141: int64) = var_54.mem_1
                    let (var_142: int64) = var_54.mem_1
                    let (var_143: int64) = (var_142 - var_141)
                    let (var_144: bool) = (0L > var_143)
                    let (var_145: int64) =
                        if var_144 then
                            0L
                        else
                            var_143
                    var_54.mem_1 <- var_145
                    let (var_146: int64) = (var_142 - var_145)
                    let (var_147: int64) = (!var_52)
                    let (var_148: int64) = (var_147 + var_146)
                    var_52 := var_148
                else
                    method_117((var_51: EnvHeap47), (var_27: EnvHeap46), (var_2: EnvStack28))
        | Union40Case1 ->
            method_116((var_27: EnvHeap46), (var_2: EnvStack28), (var_51: EnvHeap47))
    | Union40Case1 ->
        method_117((var_51: EnvHeap47), (var_27: EnvHeap46), (var_2: EnvStack28))
    let (var_149: int64) = (!var_28)
    let (var_150: int64) = (var_149 - var_113)
    let (var_151: Union40) = var_30.mem_0
    match var_151 with
    | Union40Case0(var_152) ->
        let (var_153: Env41) = var_152.mem_0
        let (var_154: Union42) = var_153.mem_0
        let (var_155: string) = method_118((var_154: Union42))
        ()
    | Union40Case1 ->
        ()
    let (var_156: EnvStack27) = var_2.mem_0
    let (var_157: float) = (float var_150)
    let (var_158: ResizeArray<Union26>) = var_156.mem_0
    var_158.Add((Union26Case1(Tuple33(var_157))))
    let (var_159: float) = 0.000000
    let (var_160: int32) = var_158.get_Count()
    let (var_161: int32) = (var_160 - 1)
    let (var_162: float) = method_119((var_158: ResizeArray<Union26>), (var_159: float), (var_161: int32))
    var_158.Clear()
    let (var_163: EnvHeap25) = var_27.mem_3
    let (var_164: EnvHeap21) = var_163.mem_0
    let (var_165: EnvHeap24) = var_163.mem_1
    let (var_166: EnvHeap18) = var_27.mem_0
    let (var_167: ManagedCuda.BasicTypes.CUmodule) = var_27.mem_1
    let (var_168: (int64 ref)) = var_164.mem_0
    let (var_169: (uint64 ref)) = var_164.mem_1
    let (var_170: (int64 ref)) = var_164.mem_2
    let (var_171: (uint64 ref)) = var_164.mem_3
    let (var_172: (int64 ref)) = var_164.mem_4
    let (var_173: (uint64 ref)) = var_164.mem_5
    let (var_174: (int64 ref)) = var_164.mem_6
    let (var_175: (uint64 ref)) = var_164.mem_7
    method_120((var_170: (int64 ref)), (var_171: (uint64 ref)), (var_168: (int64 ref)), (var_169: (uint64 ref)), (var_166: EnvHeap18), (var_167: ManagedCuda.BasicTypes.CUmodule))
    method_123((var_174: (int64 ref)), (var_175: (uint64 ref)), (var_172: (int64 ref)), (var_173: (uint64 ref)), (var_166: EnvHeap18), (var_167: ManagedCuda.BasicTypes.CUmodule))
    let (var_176: (int64 ref)) = var_165.mem_0
    let (var_177: (uint64 ref)) = var_165.mem_1
    let (var_178: (int64 ref)) = var_165.mem_2
    let (var_179: (uint64 ref)) = var_165.mem_3
    let (var_180: (int64 ref)) = var_165.mem_4
    let (var_181: (uint64 ref)) = var_165.mem_5
    let (var_182: (int64 ref)) = var_165.mem_6
    let (var_183: (uint64 ref)) = var_165.mem_7
    method_127((var_178: (int64 ref)), (var_179: (uint64 ref)), (var_176: (int64 ref)), (var_177: (uint64 ref)), (var_166: EnvHeap18), (var_167: ManagedCuda.BasicTypes.CUmodule))
    method_130((var_182: (int64 ref)), (var_183: (uint64 ref)), (var_180: (int64 ref)), (var_181: (uint64 ref)), (var_166: EnvHeap18), (var_167: ManagedCuda.BasicTypes.CUmodule))
    let (var_184: bool) = (var_150 = 1L)
    if var_184 then
        ()
    else
        let (var_185: bool) = (var_150 = -1L)
        if var_185 then
            let (var_186: int64) = (-var_150)
            ()
        else
            let (var_187: bool) = (var_150 > 0L)
            if var_187 then
                ()
            else
                let (var_188: bool) = (var_150 < 0L)
                if var_188 then
                    let (var_189: int64) = (-var_150)
                    ()
                else
                    ()
    let (var_190: int64) = (!var_52)
    let (var_191: int64) = (var_190 - var_116)
    let (var_192: Union40) = var_54.mem_0
    match var_192 with
    | Union40Case0(var_193) ->
        let (var_194: Env41) = var_193.mem_0
        let (var_195: Union42) = var_194.mem_0
        let (var_196: string) = method_118((var_195: Union42))
        ()
    | Union40Case1 ->
        ()
    let (var_197: bool) = (var_191 = 1L)
    if var_197 then
        ()
    else
        let (var_198: bool) = (var_191 = -1L)
        if var_198 then
            let (var_199: int64) = (-var_191)
            ()
        else
            let (var_200: bool) = (var_191 > 0L)
            if var_200 then
                ()
            else
                let (var_201: bool) = (var_191 < 0L)
                if var_201 then
                    let (var_202: int64) = (-var_191)
                    ()
                else
                    ()
    let (var_203: int64) = (!var_4)
    let (var_204: bool) = (var_203 > 0L)
    let (var_205: int64) =
        if var_204 then
            1L
        else
            0L
    let (var_206: int64) = (!var_6)
    let (var_207: bool) = (var_206 > 0L)
    let (var_209: int64) =
        if var_207 then
            (var_205 + 1L)
        else
            var_205
    let (var_210: bool) = (var_209 <= 1L)
    if var_210 then
        let (var_211: int64) = (!var_4)
        let (var_212: bool) = (var_211 > 0L)
        if var_212 then
            let (var_213: int64) = (!var_26)
            let (var_214: int64) = (var_213 + 1L)
            var_26 := var_214
        else
            ()
        let (var_215: int64) = (!var_6)
        let (var_216: bool) = (var_215 > 0L)
        if var_216 then
            let (var_217: int64) = (!var_50)
            let (var_218: int64) = (var_217 + 1L)
            var_50 := var_218
        else
            ()
    else
        method_134((var_0: EnvStack0), (var_3: EnvHeap39), (var_1: EnvHeap38), (var_2: EnvStack28))
and method_13 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_109((var_0: (Env41 [])), (var_1: EnvStack0)): unit =
    //In Knuth shuffle
    let (var_2: int64) = 0L
    method_110((var_1: EnvStack0), (var_0: (Env41 [])), (var_2: int64))
and method_111((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeap46), (var_5: EnvStack28), (var_6: EnvHeap47)): unit =
    // In betting's loop.
    let (var_7: int64) = 0L
    let (var_8: bool) = (0L <> var_7)
    let (var_19: Env37) =
        if var_8 then
            let (var_9: (int64 ref)) = var_4.mem_2
            let (var_10: int64) = (!var_9)
            let (var_11: EnvHeapMutable45) = var_4.mem_4
            let (var_12: int64) = var_11.mem_1
            let (var_13: Union40) = Union40Case1
            (Env37(var_10, var_13, var_12))
        else
            let (var_14: (int64 ref)) = var_4.mem_2
            let (var_15: int64) = (!var_14)
            let (var_16: EnvHeapMutable45) = var_4.mem_4
            let (var_17: int64) = var_16.mem_1
            let (var_18: Union40) = var_16.mem_0
            (Env37(var_15, var_18, var_17))
    let (var_20: int64) = var_19.mem_0
    let (var_21: Union40) = var_19.mem_1
    let (var_22: int64) = var_19.mem_2
    let (var_23: bool) = (1L <> var_7)
    let (var_34: Env37) =
        if var_23 then
            let (var_24: (int64 ref)) = var_6.mem_0
            let (var_25: int64) = (!var_24)
            let (var_26: EnvHeapMutable45) = var_6.mem_1
            let (var_27: int64) = var_26.mem_1
            let (var_28: Union40) = Union40Case1
            (Env37(var_25, var_28, var_27))
        else
            let (var_29: (int64 ref)) = var_6.mem_0
            let (var_30: int64) = (!var_29)
            let (var_31: EnvHeapMutable45) = var_6.mem_1
            let (var_32: int64) = var_31.mem_1
            let (var_33: Union40) = var_31.mem_0
            (Env37(var_30, var_33, var_32))
    let (var_35: int64) = var_34.mem_0
    let (var_36: Union40) = var_34.mem_1
    let (var_37: int64) = var_34.mem_2
    let (var_38: Union48) = method_112((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_20: int64), (var_21: Union40), (var_22: int64), (var_35: int64), (var_36: Union40), (var_37: int64), (var_4: EnvHeap46), (var_5: EnvStack28))
    match var_38 with
    | Union48Case0(var_39) ->
        let (var_40: Env49) = var_39.mem_0
        let (var_41: int64) = var_40.mem_0
        let (var_42: int64) = var_40.mem_1
        let (var_43: int64) = var_40.mem_2
        let (var_44: int64) = var_40.mem_3
        let (var_45: int64) = (var_7 + 1L)
        let (var_46: bool) = (0L <> var_45)
        let (var_57: Env37) =
            if var_46 then
                let (var_47: (int64 ref)) = var_4.mem_2
                let (var_48: int64) = (!var_47)
                let (var_49: EnvHeapMutable45) = var_4.mem_4
                let (var_50: int64) = var_49.mem_1
                let (var_51: Union40) = Union40Case1
                (Env37(var_48, var_51, var_50))
            else
                let (var_52: (int64 ref)) = var_4.mem_2
                let (var_53: int64) = (!var_52)
                let (var_54: EnvHeapMutable45) = var_4.mem_4
                let (var_55: int64) = var_54.mem_1
                let (var_56: Union40) = var_54.mem_0
                (Env37(var_53, var_56, var_55))
        let (var_58: int64) = var_57.mem_0
        let (var_59: Union40) = var_57.mem_1
        let (var_60: int64) = var_57.mem_2
        let (var_61: bool) = (1L <> var_45)
        let (var_72: Env37) =
            if var_61 then
                let (var_62: (int64 ref)) = var_6.mem_0
                let (var_63: int64) = (!var_62)
                let (var_64: EnvHeapMutable45) = var_6.mem_1
                let (var_65: int64) = var_64.mem_1
                let (var_66: Union40) = Union40Case1
                (Env37(var_63, var_66, var_65))
            else
                let (var_67: (int64 ref)) = var_6.mem_0
                let (var_68: int64) = (!var_67)
                let (var_69: EnvHeapMutable45) = var_6.mem_1
                let (var_70: int64) = var_69.mem_1
                let (var_71: Union40) = var_69.mem_0
                (Env37(var_68, var_71, var_70))
        let (var_73: int64) = var_72.mem_0
        let (var_74: Union40) = var_72.mem_1
        let (var_75: int64) = var_72.mem_2
        let (var_76: Union48) = method_114((var_41: int64), (var_42: int64), (var_43: int64), (var_44: int64), (var_58: int64), (var_59: Union40), (var_60: int64), (var_73: int64), (var_74: Union40), (var_75: int64), (var_6: EnvHeap47))
        match var_76 with
        | Union48Case0(var_77) ->
            let (var_78: Env49) = var_77.mem_0
            let (var_79: int64) = var_78.mem_0
            let (var_80: int64) = var_78.mem_1
            let (var_81: int64) = var_78.mem_2
            let (var_82: int64) = var_78.mem_3
            let (var_83: int64) = (var_45 + 1L)
            method_111((var_79: int64), (var_80: int64), (var_81: int64), (var_82: int64), (var_4: EnvHeap46), (var_5: EnvStack28), (var_6: EnvHeap47))
        | Union48Case1 ->
            ()
    | Union48Case1 ->
        ()
and method_115((var_0: Union42)): int32 =
    // In hand_rule.
    match var_0 with
    | Union42Case0 ->
        12
    | Union42Case1 ->
        6
    | Union42Case2 ->
        3
    | Union42Case3 ->
        2
    | Union42Case4 ->
        9
    | Union42Case5 ->
        11
    | Union42Case6 ->
        7
    | Union42Case7 ->
        10
    | Union42Case8 ->
        5
    | Union42Case9 ->
        4
    | Union42Case10 ->
        8
    | Union42Case11 ->
        1
    | Union42Case12 ->
        0
and method_116((var_0: EnvHeap46), (var_1: EnvStack28), (var_2: EnvHeap47)): unit =
    let (var_3: EnvHeapMutable45) = var_0.mem_4
    let (var_4: int64) = var_3.mem_1
    let (var_5: EnvHeapMutable45) = var_2.mem_1
    let (var_6: int64) = var_5.mem_1
    let (var_7: bool) = (var_4 > var_6)
    let (var_8: int64) =
        if var_7 then
            var_6
        else
            var_4
    let (var_9: int64) = var_3.mem_1
    let (var_10: int64) = (var_9 - var_8)
    let (var_11: bool) = (0L > var_10)
    let (var_12: int64) =
        if var_11 then
            0L
        else
            var_10
    var_3.mem_1 <- var_12
    let (var_13: int64) = (var_9 - var_12)
    let (var_14: int64) = var_5.mem_1
    let (var_15: int64) = (var_14 - var_8)
    let (var_16: bool) = (0L > var_15)
    let (var_17: int64) =
        if var_16 then
            0L
        else
            var_15
    var_5.mem_1 <- var_17
    let (var_18: int64) = (var_14 - var_17)
    let (var_19: int64) = (var_13 + var_18)
    let (var_20: int64) = var_3.mem_1
    let (var_21: int64) = var_3.mem_1
    let (var_22: int64) = (var_21 - var_20)
    let (var_23: bool) = (0L > var_22)
    let (var_24: int64) =
        if var_23 then
            0L
        else
            var_22
    var_3.mem_1 <- var_24
    let (var_25: int64) = (var_21 - var_24)
    let (var_26: int64) = (var_19 + var_25)
    let (var_27: (int64 ref)) = var_0.mem_2
    let (var_28: int64) = (!var_27)
    let (var_29: int64) = (var_28 + var_26)
    var_27 := var_29
    let (var_30: int64) = var_5.mem_1
    let (var_31: int64) = var_5.mem_1
    let (var_32: int64) = (var_31 - var_30)
    let (var_33: bool) = (0L > var_32)
    let (var_34: int64) =
        if var_33 then
            0L
        else
            var_32
    var_5.mem_1 <- var_34
    let (var_35: int64) = (var_31 - var_34)
    let (var_36: (int64 ref)) = var_2.mem_0
    let (var_37: int64) = (!var_36)
    let (var_38: int64) = (var_37 + var_35)
    var_36 := var_38
and method_117((var_0: EnvHeap47), (var_1: EnvHeap46), (var_2: EnvStack28)): unit =
    let (var_3: EnvHeapMutable45) = var_0.mem_1
    let (var_4: int64) = var_3.mem_1
    let (var_5: EnvHeapMutable45) = var_1.mem_4
    let (var_6: int64) = var_5.mem_1
    let (var_7: bool) = (var_4 > var_6)
    let (var_8: int64) =
        if var_7 then
            var_6
        else
            var_4
    let (var_9: int64) = var_3.mem_1
    let (var_10: int64) = (var_9 - var_8)
    let (var_11: bool) = (0L > var_10)
    let (var_12: int64) =
        if var_11 then
            0L
        else
            var_10
    var_3.mem_1 <- var_12
    let (var_13: int64) = (var_9 - var_12)
    let (var_14: int64) = var_5.mem_1
    let (var_15: int64) = (var_14 - var_8)
    let (var_16: bool) = (0L > var_15)
    let (var_17: int64) =
        if var_16 then
            0L
        else
            var_15
    var_5.mem_1 <- var_17
    let (var_18: int64) = (var_14 - var_17)
    let (var_19: int64) = (var_13 + var_18)
    let (var_20: int64) = var_3.mem_1
    let (var_21: int64) = var_3.mem_1
    let (var_22: int64) = (var_21 - var_20)
    let (var_23: bool) = (0L > var_22)
    let (var_24: int64) =
        if var_23 then
            0L
        else
            var_22
    var_3.mem_1 <- var_24
    let (var_25: int64) = (var_21 - var_24)
    let (var_26: int64) = (var_19 + var_25)
    let (var_27: (int64 ref)) = var_0.mem_0
    let (var_28: int64) = (!var_27)
    let (var_29: int64) = (var_28 + var_26)
    var_27 := var_29
    let (var_30: int64) = var_5.mem_1
    let (var_31: int64) = var_5.mem_1
    let (var_32: int64) = (var_31 - var_30)
    let (var_33: bool) = (0L > var_32)
    let (var_34: int64) =
        if var_33 then
            0L
        else
            var_32
    var_5.mem_1 <- var_34
    let (var_35: int64) = (var_31 - var_34)
    let (var_36: (int64 ref)) = var_1.mem_2
    let (var_37: int64) = (!var_36)
    let (var_38: int64) = (var_37 + var_35)
    var_36 := var_38
and method_118((var_0: Union42)): string =
    //In show_card.
    match var_0 with
    | Union42Case0 ->
        "Ace-Spades"
    | Union42Case1 ->
        "Eight-Spades"
    | Union42Case2 ->
        "Five-Spades"
    | Union42Case3 ->
        "Four-Spades"
    | Union42Case4 ->
        "Jack-Spades"
    | Union42Case5 ->
        "King-Spades"
    | Union42Case6 ->
        "Nine-Spades"
    | Union42Case7 ->
        "Queen-Spades"
    | Union42Case8 ->
        "Seven-Spades"
    | Union42Case9 ->
        "Six-Spades"
    | Union42Case10 ->
        "Ten-Spades"
    | Union42Case11 ->
        "Three-Spades"
    | Union42Case12 ->
        "Two-Spades"
and method_119((var_0: ResizeArray<Union26>), (var_1: float), (var_2: int32)): float =
    let (var_3: bool) = (var_2 >= 0)
    if var_3 then
        let (var_4: Union26) = var_0.[var_2]
        let (var_20: float) =
            match var_4 with
            | Union26Case0(var_5) ->
                let (var_7: Tuple34) = var_5.mem_0
                let (var_8: Env37) = var_7.mem_0
                let (var_9: int64) = var_8.mem_0
                let (var_10: Union40) = var_8.mem_1
                let (var_11: int64) = var_8.mem_2
                let (var_12: Env37) = var_7.mem_1
                let (var_13: int64) = var_12.mem_0
                let (var_14: Union40) = var_12.mem_1
                let (var_15: int64) = var_12.mem_2
                let (var_16: Union35) = var_5.mem_1
                let (var_17: (float -> unit)) = var_5.mem_2
                var_17(var_1)
                var_1
            | Union26Case1(var_6) ->
                let (var_18: float) = var_6.mem_0
                (var_1 + var_18)
        let (var_21: int32) = (var_2 + -1)
        method_119((var_0: ResizeArray<Union26>), (var_20: float), (var_21: int32))
    else
        var_1
and method_120((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_121((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_123((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_124((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_127((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_128((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_130((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_131((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_134((var_0: EnvStack0), (var_1: EnvHeap39), (var_2: EnvHeap38), (var_3: EnvStack28)): unit =
    let (var_4: (int64 ref)) = var_1.mem_0
    let (var_5: int64) = (!var_4)
    let (var_6: (int64 ref)) = var_2.mem_2
    let (var_7: int64) = (!var_6)
    let (var_9: (Env41 [])) = [|(Env41(Union42Case12)); (Env41(Union42Case11)); (Env41(Union42Case3)); (Env41(Union42Case2)); (Env41(Union42Case9)); (Env41(Union42Case8)); (Env41(Union42Case1)); (Env41(Union42Case6)); (Env41(Union42Case10)); (Env41(Union42Case4)); (Env41(Union42Case7)); (Env41(Union42Case5)); (Env41(Union42Case0))|]
    let (var_10: int64) = var_9.LongLength
    let (var_11: bool) = (var_10 = 13L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_109((var_9: (Env41 [])), (var_0: EnvStack0))
    let (var_13: int64) = 13L
    let (var_14: EnvHeapMutable43) = ({mem_0 = (var_9: (Env41 [])); mem_1 = (var_13: int64)} : EnvHeapMutable43)
    // In dealing.
    let (var_15: int64) = var_14.mem_1
    let (var_16: int64) = (var_15 - 1L)
    var_14.mem_1 <- var_16
    let (var_17: (Env41 [])) = var_14.mem_0
    let (var_18: Env41) = var_17.[int32 var_16]
    let (var_19: Union42) = var_18.mem_0
    let (var_20: Union40) = (Union40Case0(Tuple44((Env41(var_19)))))
    let (var_21: int64) = 0L
    let (var_22: EnvHeapMutable45) = ({mem_0 = (var_20: Union40); mem_1 = (var_21: int64)} : EnvHeapMutable45)
    let (var_23: (int64 ref)) = var_1.mem_1
    let (var_24: EnvHeap47) = ({mem_0 = (var_4: (int64 ref)); mem_1 = (var_22: EnvHeapMutable45); mem_2 = (var_23: (int64 ref))} : EnvHeap47)
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: int64) = (!var_25)
    let (var_27: EnvHeapMutable45) = var_24.mem_1
    let (var_28: int64) = var_27.mem_1
    let (var_29: int64) = (1L - var_28)
    let (var_30: bool) = (var_26 > var_29)
    let (var_31: int64) =
        if var_30 then
            var_29
        else
            var_26
    let (var_32: int64) = (-var_31)
    let (var_33: int64) = (!var_25)
    let (var_34: int64) = (var_33 + var_32)
    var_25 := var_34
    let (var_35: int64) = var_27.mem_1
    let (var_36: int64) = (var_35 + var_31)
    var_27.mem_1 <- var_36
    let (var_37: int64) = var_27.mem_1
    let (var_38: bool) = (var_37 > 0L)
    let (var_39: int64) = var_14.mem_1
    let (var_40: int64) = (var_39 - 1L)
    var_14.mem_1 <- var_40
    let (var_41: (Env41 [])) = var_14.mem_0
    let (var_42: Env41) = var_41.[int32 var_40]
    let (var_43: Union42) = var_42.mem_0
    let (var_44: Union40) = (Union40Case0(Tuple44((Env41(var_43)))))
    let (var_45: int64) = 0L
    let (var_46: EnvHeapMutable45) = ({mem_0 = (var_44: Union40); mem_1 = (var_45: int64)} : EnvHeapMutable45)
    let (var_47: EnvHeap18) = var_2.mem_0
    let (var_48: ManagedCuda.BasicTypes.CUmodule) = var_2.mem_1
    let (var_49: EnvHeap25) = var_2.mem_3
    let (var_50: (int64 ref)) = var_2.mem_4
    let (var_51: EnvHeap46) = ({mem_0 = (var_47: EnvHeap18); mem_1 = (var_48: ManagedCuda.BasicTypes.CUmodule); mem_2 = (var_6: (int64 ref)); mem_3 = (var_49: EnvHeap25); mem_4 = (var_46: EnvHeapMutable45); mem_5 = (var_50: (int64 ref))} : EnvHeap46)
    let (var_52: (int64 ref)) = var_51.mem_2
    let (var_53: int64) = (!var_52)
    let (var_54: EnvHeapMutable45) = var_51.mem_4
    let (var_55: int64) = var_54.mem_1
    let (var_56: int64) = (2L - var_55)
    let (var_57: bool) = (var_53 > var_56)
    let (var_58: int64) =
        if var_57 then
            var_56
        else
            var_53
    let (var_59: int64) = (-var_58)
    let (var_60: int64) = (!var_52)
    let (var_61: int64) = (var_60 + var_59)
    var_52 := var_61
    let (var_62: int64) = var_54.mem_1
    let (var_63: int64) = (var_62 + var_58)
    var_54.mem_1 <- var_63
    let (var_64: int64) = var_54.mem_1
    let (var_65: bool) = (var_64 > 0L)
    let (var_66: int64) = (!var_25)
    let (var_67: bool) = (var_66 > 0L)
    let (var_73: bool) =
        if var_67 then
            let (var_68: Union40) = var_27.mem_0
            match var_68 with
            | Union40Case0(var_69) ->
                let (var_70: Env41) = var_69.mem_0
                let (var_71: Union42) = var_70.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_77: int64) =
        if var_73 then
            let (var_74: int64) = var_27.mem_1
            let (var_75: bool) = (0L > var_74)
            if var_75 then
                0L
            else
                var_74
        else
            0L
    let (var_78: int64) = (!var_52)
    let (var_79: bool) = (var_78 > 0L)
    let (var_85: bool) =
        if var_79 then
            let (var_80: Union40) = var_54.mem_0
            match var_80 with
            | Union40Case0(var_81) ->
                let (var_82: Env41) = var_81.mem_0
                let (var_83: Union42) = var_82.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_89: int64) =
        if var_85 then
            let (var_86: int64) = var_54.mem_1
            let (var_87: bool) = (var_77 > var_86)
            if var_87 then
                var_77
            else
                var_86
        else
            var_77
    let (var_90: int64) = (!var_25)
    let (var_91: bool) = (var_90 > 0L)
    let (var_97: bool) =
        if var_91 then
            let (var_92: Union40) = var_27.mem_0
            match var_92 with
            | Union40Case0(var_93) ->
                let (var_94: Env41) = var_93.mem_0
                let (var_95: Union42) = var_94.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_98: int64) =
        if var_97 then
            1L
        else
            0L
    let (var_99: int64) = (!var_52)
    let (var_100: bool) = (var_99 > 0L)
    let (var_106: bool) =
        if var_100 then
            let (var_101: Union40) = var_54.mem_0
            match var_101 with
            | Union40Case0(var_102) ->
                let (var_103: Env41) = var_102.mem_0
                let (var_104: Union42) = var_103.mem_0
                true
            | Union40Case1 ->
                false
        else
            false
    let (var_108: int64) =
        if var_106 then
            (var_98 + 1L)
        else
            var_98
    let (var_109: int64) = 2L
    let (var_110: int64) = 0L
    method_135((var_89: int64), (var_109: int64), (var_108: int64), (var_110: int64), (var_24: EnvHeap47), (var_51: EnvHeap46), (var_3: EnvStack28))
    let (var_111: int64) = (!var_25)
    let (var_112: int64) = var_27.mem_1
    let (var_113: int64) = (var_111 + var_112)
    let (var_114: int64) = (!var_52)
    let (var_115: int64) = var_54.mem_1
    let (var_116: int64) = (var_114 + var_115)
    let (var_117: Union40) = var_27.mem_0
    match var_117 with
    | Union40Case0(var_118) ->
        let (var_119: Env41) = var_118.mem_0
        let (var_120: Union42) = var_119.mem_0
        let (var_121: Union40) = var_54.mem_0
        match var_121 with
        | Union40Case0(var_122) ->
            let (var_123: Env41) = var_122.mem_0
            let (var_124: Union42) = var_123.mem_0
            let (var_125: int32) = method_115((var_120: Union42))
            let (var_126: int32) = method_115((var_124: Union42))
            let (var_127: bool) = (var_125 < var_126)
            let (var_130: int32) =
                if var_127 then
                    -1
                else
                    let (var_128: bool) = (var_125 = var_126)
                    if var_128 then
                        0
                    else
                        1
            let (var_131: bool) = (var_130 = 1)
            if var_131 then
                method_117((var_24: EnvHeap47), (var_51: EnvHeap46), (var_3: EnvStack28))
            else
                let (var_132: bool) = (var_130 = 0)
                if var_132 then
                    let (var_133: int64) = var_27.mem_1
                    let (var_134: int64) = var_27.mem_1
                    let (var_135: int64) = (var_134 - var_133)
                    let (var_136: bool) = (0L > var_135)
                    let (var_137: int64) =
                        if var_136 then
                            0L
                        else
                            var_135
                    var_27.mem_1 <- var_137
                    let (var_138: int64) = (var_134 - var_137)
                    let (var_139: int64) = (!var_25)
                    let (var_140: int64) = (var_139 + var_138)
                    var_25 := var_140
                    let (var_141: int64) = var_54.mem_1
                    let (var_142: int64) = var_54.mem_1
                    let (var_143: int64) = (var_142 - var_141)
                    let (var_144: bool) = (0L > var_143)
                    let (var_145: int64) =
                        if var_144 then
                            0L
                        else
                            var_143
                    var_54.mem_1 <- var_145
                    let (var_146: int64) = (var_142 - var_145)
                    let (var_147: int64) = (!var_52)
                    let (var_148: int64) = (var_147 + var_146)
                    var_52 := var_148
                else
                    method_116((var_51: EnvHeap46), (var_3: EnvStack28), (var_24: EnvHeap47))
        | Union40Case1 ->
            method_117((var_24: EnvHeap47), (var_51: EnvHeap46), (var_3: EnvStack28))
    | Union40Case1 ->
        method_116((var_51: EnvHeap46), (var_3: EnvStack28), (var_24: EnvHeap47))
    let (var_149: int64) = (!var_25)
    let (var_150: int64) = (var_149 - var_113)
    let (var_151: Union40) = var_27.mem_0
    match var_151 with
    | Union40Case0(var_152) ->
        let (var_153: Env41) = var_152.mem_0
        let (var_154: Union42) = var_153.mem_0
        let (var_155: string) = method_118((var_154: Union42))
        ()
    | Union40Case1 ->
        ()
    let (var_156: bool) = (var_150 = 1L)
    if var_156 then
        ()
    else
        let (var_157: bool) = (var_150 = -1L)
        if var_157 then
            let (var_158: int64) = (-var_150)
            ()
        else
            let (var_159: bool) = (var_150 > 0L)
            if var_159 then
                ()
            else
                let (var_160: bool) = (var_150 < 0L)
                if var_160 then
                    let (var_161: int64) = (-var_150)
                    ()
                else
                    ()
    let (var_162: int64) = (!var_52)
    let (var_163: int64) = (var_162 - var_116)
    let (var_164: Union40) = var_54.mem_0
    match var_164 with
    | Union40Case0(var_165) ->
        let (var_166: Env41) = var_165.mem_0
        let (var_167: Union42) = var_166.mem_0
        let (var_168: string) = method_118((var_167: Union42))
        ()
    | Union40Case1 ->
        ()
    let (var_169: EnvStack27) = var_3.mem_0
    let (var_170: float) = (float var_163)
    let (var_171: ResizeArray<Union26>) = var_169.mem_0
    var_171.Add((Union26Case1(Tuple33(var_170))))
    let (var_172: float) = 0.000000
    let (var_173: int32) = var_171.get_Count()
    let (var_174: int32) = (var_173 - 1)
    let (var_175: float) = method_119((var_171: ResizeArray<Union26>), (var_172: float), (var_174: int32))
    var_171.Clear()
    let (var_176: EnvHeap25) = var_51.mem_3
    let (var_177: EnvHeap21) = var_176.mem_0
    let (var_178: EnvHeap24) = var_176.mem_1
    let (var_179: EnvHeap18) = var_51.mem_0
    let (var_180: ManagedCuda.BasicTypes.CUmodule) = var_51.mem_1
    let (var_181: (int64 ref)) = var_177.mem_0
    let (var_182: (uint64 ref)) = var_177.mem_1
    let (var_183: (int64 ref)) = var_177.mem_2
    let (var_184: (uint64 ref)) = var_177.mem_3
    let (var_185: (int64 ref)) = var_177.mem_4
    let (var_186: (uint64 ref)) = var_177.mem_5
    let (var_187: (int64 ref)) = var_177.mem_6
    let (var_188: (uint64 ref)) = var_177.mem_7
    method_120((var_183: (int64 ref)), (var_184: (uint64 ref)), (var_181: (int64 ref)), (var_182: (uint64 ref)), (var_179: EnvHeap18), (var_180: ManagedCuda.BasicTypes.CUmodule))
    method_123((var_187: (int64 ref)), (var_188: (uint64 ref)), (var_185: (int64 ref)), (var_186: (uint64 ref)), (var_179: EnvHeap18), (var_180: ManagedCuda.BasicTypes.CUmodule))
    let (var_189: (int64 ref)) = var_178.mem_0
    let (var_190: (uint64 ref)) = var_178.mem_1
    let (var_191: (int64 ref)) = var_178.mem_2
    let (var_192: (uint64 ref)) = var_178.mem_3
    let (var_193: (int64 ref)) = var_178.mem_4
    let (var_194: (uint64 ref)) = var_178.mem_5
    let (var_195: (int64 ref)) = var_178.mem_6
    let (var_196: (uint64 ref)) = var_178.mem_7
    method_127((var_191: (int64 ref)), (var_192: (uint64 ref)), (var_189: (int64 ref)), (var_190: (uint64 ref)), (var_179: EnvHeap18), (var_180: ManagedCuda.BasicTypes.CUmodule))
    method_130((var_195: (int64 ref)), (var_196: (uint64 ref)), (var_193: (int64 ref)), (var_194: (uint64 ref)), (var_179: EnvHeap18), (var_180: ManagedCuda.BasicTypes.CUmodule))
    let (var_197: bool) = (var_163 = 1L)
    if var_197 then
        ()
    else
        let (var_198: bool) = (var_163 = -1L)
        if var_198 then
            let (var_199: int64) = (-var_163)
            ()
        else
            let (var_200: bool) = (var_163 > 0L)
            if var_200 then
                ()
            else
                let (var_201: bool) = (var_163 < 0L)
                if var_201 then
                    let (var_202: int64) = (-var_163)
                    ()
                else
                    ()
    let (var_203: int64) = (!var_4)
    let (var_204: bool) = (var_203 > 0L)
    let (var_205: int64) =
        if var_204 then
            1L
        else
            0L
    let (var_206: int64) = (!var_6)
    let (var_207: bool) = (var_206 > 0L)
    let (var_209: int64) =
        if var_207 then
            (var_205 + 1L)
        else
            var_205
    let (var_210: bool) = (var_209 <= 1L)
    if var_210 then
        let (var_211: int64) = (!var_4)
        let (var_212: bool) = (var_211 > 0L)
        if var_212 then
            let (var_213: int64) = (!var_23)
            let (var_214: int64) = (var_213 + 1L)
            var_23 := var_214
        else
            ()
        let (var_215: int64) = (!var_6)
        let (var_216: bool) = (var_215 > 0L)
        if var_216 then
            let (var_217: int64) = (!var_50)
            let (var_218: int64) = (var_217 + 1L)
            var_50 := var_218
        else
            ()
    else
        method_108((var_0: EnvStack0), (var_2: EnvHeap38), (var_3: EnvStack28), (var_1: EnvHeap39))
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
and method_110((var_0: EnvStack0), (var_1: (Env41 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 12L)
    if var_3 then
        let (var_4: System.Random) = var_0.mem_0
        let (var_5: int32) = (int32 var_2)
        let (var_6: int32) = var_4.Next(var_5, 13)
        let (var_7: Env41) = var_1.[int32 var_2]
        let (var_8: Union42) = var_7.mem_0
        let (var_9: Env41) = var_1.[int32 var_6]
        var_1.[int32 var_2] <- var_9
        var_1.[int32 var_6] <- (Env41(var_8))
        let (var_10: int64) = (var_2 + 1L)
        method_110((var_0: EnvStack0), (var_1: (Env41 [])), (var_10: int64))
    else
        ()
and method_112((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union40), (var_6: int64), (var_7: int64), (var_8: Union40), (var_9: int64), (var_10: EnvHeap46), (var_11: EnvStack28)): Union48 =
    //In betting
    let (var_12: bool) = (var_3 < var_2)
    let (var_18: bool) =
        if var_12 then
            let (var_13: bool) = (var_2 <> 1L)
            if var_13 then
                true
            else
                let (var_14: EnvHeapMutable45) = var_10.mem_4
                let (var_15: int64) = var_14.mem_1
                (var_15 < var_0)
        else
            false
    if var_18 then
        let (var_19: (int64 ref)) = var_10.mem_2
        let (var_20: int64) = (!var_19)
        let (var_21: bool) = (var_20 > 0L)
        let (var_28: bool) =
            if var_21 then
                let (var_22: EnvHeapMutable45) = var_10.mem_4
                let (var_23: Union40) = var_22.mem_0
                match var_23 with
                | Union40Case0(var_24) ->
                    let (var_25: Env41) = var_24.mem_0
                    let (var_26: Union42) = var_25.mem_0
                    true
                | Union40Case1 ->
                    false
            else
                false
        if var_28 then
            let (var_29: EnvHeap25) = var_10.mem_3
            let (var_30: EnvHeap21) = var_29.mem_0
            let (var_31: EnvHeap24) = var_29.mem_1
            let (var_32: EnvHeap18) = var_10.mem_0
            let (var_33: ManagedCuda.BasicTypes.CUmodule) = var_10.mem_1
            let (var_34: EnvStack51) = method_37((var_4: int64), (var_5: Union40), (var_6: int64), (var_7: int64), (var_8: Union40), (var_9: int64), (var_30: EnvHeap21), (var_31: EnvHeap24), (var_32: EnvHeap18), (var_33: ManagedCuda.BasicTypes.CUmodule))
            let (var_35: Union35) = var_34.mem_0
            let (var_36: (unit -> unit)) = var_34.mem_1
            let (var_37: (unit -> unit)) = var_34.mem_2
            let (var_38: (float -> unit)) = var_34.mem_3
            let (var_39: EnvStack27) = var_11.mem_0
            let (var_41: (float -> unit)) = method_113((var_36: (unit -> unit)), (var_37: (unit -> unit)), (var_38: (float -> unit)))
            let (var_42: ResizeArray<Union26>) = var_39.mem_0
            var_42.Add((Union26Case0(Tuple32(Tuple34((Env37(var_4, var_5, var_6)), (Env37(var_7, var_8, var_9))), var_35, var_41))))
            match var_35 with
            | Union35Case0 ->
                let (var_43: int64) = (var_0 + var_1)
                let (var_44: int64) = (!var_19)
                let (var_45: EnvHeapMutable45) = var_10.mem_4
                let (var_46: int64) = var_45.mem_1
                let (var_47: int64) = (var_43 - var_46)
                let (var_48: bool) = (var_44 > var_47)
                let (var_49: int64) =
                    if var_48 then
                        var_47
                    else
                        var_44
                let (var_50: int64) = (-var_49)
                let (var_51: int64) = (!var_19)
                let (var_52: int64) = (var_51 + var_50)
                var_19 := var_52
                let (var_53: int64) = var_45.mem_1
                let (var_54: int64) = (var_53 + var_49)
                var_45.mem_1 <- var_54
                let (var_55: int64) = var_45.mem_1
                let (var_56: int64) = (!var_19)
                let (var_57: bool) = (var_56 = 0L)
                if var_57 then
                    let (var_58: bool) = (var_55 > var_0)
                    if var_58 then
                        let (var_59: int64) = (var_55 - var_0)
                        let (var_60: bool) = (var_1 > var_59)
                        let (var_61: int64) =
                            if var_60 then
                                var_1
                            else
                                var_59
                        let (var_62: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_55, var_61, var_62, 0L)))))
                    else
                        let (var_63: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_63, var_3)))))
                else
                    let (var_65: bool) = (var_55 > var_0)
                    if var_65 then
                        let (var_66: int64) = (var_55 - var_0)
                        let (var_67: bool) = (var_1 > var_66)
                        let (var_68: int64) =
                            if var_67 then
                                var_1
                            else
                                var_66
                        (Union48Case0(Tuple50((Env49(var_55, var_68, var_2, 1L)))))
                    else
                        let (var_69: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                        let (var_70: int64) = var_69.mem_0
                        let (var_71: int64) = var_69.mem_1
                        let (var_72: int64) = var_69.mem_2
                        let (var_73: int64) = var_69.mem_3
                        (Union48Case0(Tuple50((Env49(var_70, var_71, var_72, var_73)))))
            | Union35Case1 ->
                let (var_76: int64) = (!var_19)
                let (var_77: EnvHeapMutable45) = var_10.mem_4
                let (var_78: int64) = var_77.mem_1
                let (var_79: int64) = (var_0 - var_78)
                let (var_80: bool) = (var_76 > var_79)
                let (var_81: int64) =
                    if var_80 then
                        var_79
                    else
                        var_76
                let (var_82: int64) = (-var_81)
                let (var_83: int64) = (!var_19)
                let (var_84: int64) = (var_83 + var_82)
                var_19 := var_84
                let (var_85: int64) = var_77.mem_1
                let (var_86: int64) = (var_85 + var_81)
                var_77.mem_1 <- var_86
                let (var_87: int64) = (!var_19)
                let (var_88: bool) = (var_87 = 0L)
                if var_88 then
                    let (var_89: int64) = (var_2 - 1L)
                    (Union48Case0(Tuple50((Env49(var_0, var_1, var_89, var_3)))))
                else
                    let (var_90: int64) = (var_3 + 1L)
                    (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_90)))))
            | Union35Case2 ->
                let (var_92: EnvHeapMutable45) = var_10.mem_4
                let (var_93: Union40) = Union40Case1
                var_92.mem_0 <- var_93
                let (var_94: int64) = (var_2 - 1L)
                (Union48Case0(Tuple50((Env49(var_0, var_1, var_94, var_3)))))
        else
            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_3)))))
    else
        Union48Case1
and method_114((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union40), (var_6: int64), (var_7: int64), (var_8: Union40), (var_9: int64), (var_10: EnvHeap47)): Union48 =
    //In betting
    let (var_11: bool) = (var_3 < var_2)
    let (var_17: bool) =
        if var_11 then
            let (var_12: bool) = (var_2 <> 1L)
            if var_12 then
                true
            else
                let (var_13: EnvHeapMutable45) = var_10.mem_1
                let (var_14: int64) = var_13.mem_1
                (var_14 < var_0)
        else
            false
    if var_17 then
        let (var_18: (int64 ref)) = var_10.mem_0
        let (var_19: int64) = (!var_18)
        let (var_20: bool) = (var_19 > 0L)
        let (var_27: bool) =
            if var_20 then
                let (var_21: EnvHeapMutable45) = var_10.mem_1
                let (var_22: Union40) = var_21.mem_0
                match var_22 with
                | Union40Case0(var_23) ->
                    let (var_24: Env41) = var_23.mem_0
                    let (var_25: Union42) = var_24.mem_0
                    true
                | Union40Case1 ->
                    false
            else
                false
        if var_27 then
            let (var_28: bool) = (0L > var_6)
            let (var_29: int64) =
                if var_28 then
                    0L
                else
                    var_6
            let (var_30: bool) = (var_29 > var_9)
            let (var_31: int64) =
                if var_30 then
                    var_29
                else
                    var_9
            let (var_35: bool) =
                match var_5 with
                | Union40Case0(var_32) ->
                    let (var_33: Env41) = var_32.mem_0
                    let (var_34: Union42) = var_33.mem_0
                    true
                | Union40Case1 ->
                    false
            let (var_42: Env37) =
                if var_35 then
                    (Env37(var_4, var_5, var_6))
                else
                    let (var_39: bool) =
                        match var_8 with
                        | Union40Case0(var_36) ->
                            let (var_37: Env41) = var_36.mem_0
                            let (var_38: Union42) = var_37.mem_0
                            true
                        | Union40Case1 ->
                            false
                    if var_39 then
                        (Env37(var_7, var_8, var_9))
                    else
                        (failwith "Key cannot be found.")
            let (var_43: int64) = var_42.mem_0
            let (var_44: Union40) = var_42.mem_1
            let (var_45: int64) = var_42.mem_2
            match var_44 with
            | Union40Case0(var_46) ->
                let (var_47: Env41) = var_46.mem_0
                let (var_48: Union42) = var_47.mem_0
                match var_48 with
                | Union42Case0 ->
                    let (var_49: int64) = (var_0 + var_1)
                    let (var_50: int64) = (!var_18)
                    let (var_51: EnvHeapMutable45) = var_10.mem_1
                    let (var_52: int64) = var_51.mem_1
                    let (var_53: int64) = (var_49 - var_52)
                    let (var_54: bool) = (var_50 > var_53)
                    let (var_55: int64) =
                        if var_54 then
                            var_53
                        else
                            var_50
                    let (var_56: int64) = (-var_55)
                    let (var_57: int64) = (!var_18)
                    let (var_58: int64) = (var_57 + var_56)
                    var_18 := var_58
                    let (var_59: int64) = var_51.mem_1
                    let (var_60: int64) = (var_59 + var_55)
                    var_51.mem_1 <- var_60
                    let (var_61: int64) = var_51.mem_1
                    let (var_62: int64) = (!var_18)
                    let (var_63: bool) = (var_62 = 0L)
                    if var_63 then
                        let (var_64: bool) = (var_61 > var_0)
                        if var_64 then
                            let (var_65: int64) = (var_61 - var_0)
                            let (var_66: bool) = (var_1 > var_65)
                            let (var_67: int64) =
                                if var_66 then
                                    var_1
                                else
                                    var_65
                            let (var_68: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_61, var_67, var_68, 0L)))))
                        else
                            let (var_69: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_69, var_3)))))
                    else
                        let (var_71: bool) = (var_61 > var_0)
                        if var_71 then
                            let (var_72: int64) = (var_61 - var_0)
                            let (var_73: bool) = (var_1 > var_72)
                            let (var_74: int64) =
                                if var_73 then
                                    var_1
                                else
                                    var_72
                            (Union48Case0(Tuple50((Env49(var_61, var_74, var_2, 1L)))))
                        else
                            let (var_75: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_76: int64) = var_75.mem_0
                            let (var_77: int64) = var_75.mem_1
                            let (var_78: int64) = var_75.mem_2
                            let (var_79: int64) = var_75.mem_3
                            (Union48Case0(Tuple50((Env49(var_76, var_77, var_78, var_79)))))
                | Union42Case1 ->
                    let (var_82: bool) = (var_45 >= var_31)
                    let (var_84: bool) =
                        if var_82 then
                            true
                        else
                            (var_43 = 0L)
                    if var_84 then
                        let (var_85: int64) = (!var_18)
                        let (var_86: EnvHeapMutable45) = var_10.mem_1
                        let (var_87: int64) = var_86.mem_1
                        let (var_88: int64) = (var_0 - var_87)
                        let (var_89: bool) = (var_85 > var_88)
                        let (var_90: int64) =
                            if var_89 then
                                var_88
                            else
                                var_85
                        let (var_91: int64) = (-var_90)
                        let (var_92: int64) = (!var_18)
                        let (var_93: int64) = (var_92 + var_91)
                        var_18 := var_93
                        let (var_94: int64) = var_86.mem_1
                        let (var_95: int64) = (var_94 + var_90)
                        var_86.mem_1 <- var_95
                        let (var_96: int64) = (!var_18)
                        let (var_97: bool) = (var_96 = 0L)
                        if var_97 then
                            let (var_98: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_98, var_3)))))
                        else
                            let (var_99: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_99)))))
                    else
                        let (var_101: EnvHeapMutable45) = var_10.mem_1
                        let (var_102: Union40) = Union40Case1
                        var_101.mem_0 <- var_102
                        let (var_103: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_103, var_3)))))
                | Union42Case2 ->
                    let (var_105: bool) = (var_45 >= var_31)
                    let (var_107: bool) =
                        if var_105 then
                            true
                        else
                            (var_43 = 0L)
                    if var_107 then
                        let (var_108: int64) = (!var_18)
                        let (var_109: EnvHeapMutable45) = var_10.mem_1
                        let (var_110: int64) = var_109.mem_1
                        let (var_111: int64) = (var_0 - var_110)
                        let (var_112: bool) = (var_108 > var_111)
                        let (var_113: int64) =
                            if var_112 then
                                var_111
                            else
                                var_108
                        let (var_114: int64) = (-var_113)
                        let (var_115: int64) = (!var_18)
                        let (var_116: int64) = (var_115 + var_114)
                        var_18 := var_116
                        let (var_117: int64) = var_109.mem_1
                        let (var_118: int64) = (var_117 + var_113)
                        var_109.mem_1 <- var_118
                        let (var_119: int64) = (!var_18)
                        let (var_120: bool) = (var_119 = 0L)
                        if var_120 then
                            let (var_121: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_121, var_3)))))
                        else
                            let (var_122: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_122)))))
                    else
                        let (var_124: EnvHeapMutable45) = var_10.mem_1
                        let (var_125: Union40) = Union40Case1
                        var_124.mem_0 <- var_125
                        let (var_126: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_126, var_3)))))
                | Union42Case3 ->
                    let (var_128: bool) = (var_45 >= var_31)
                    let (var_130: bool) =
                        if var_128 then
                            true
                        else
                            (var_43 = 0L)
                    if var_130 then
                        let (var_131: int64) = (!var_18)
                        let (var_132: EnvHeapMutable45) = var_10.mem_1
                        let (var_133: int64) = var_132.mem_1
                        let (var_134: int64) = (var_0 - var_133)
                        let (var_135: bool) = (var_131 > var_134)
                        let (var_136: int64) =
                            if var_135 then
                                var_134
                            else
                                var_131
                        let (var_137: int64) = (-var_136)
                        let (var_138: int64) = (!var_18)
                        let (var_139: int64) = (var_138 + var_137)
                        var_18 := var_139
                        let (var_140: int64) = var_132.mem_1
                        let (var_141: int64) = (var_140 + var_136)
                        var_132.mem_1 <- var_141
                        let (var_142: int64) = (!var_18)
                        let (var_143: bool) = (var_142 = 0L)
                        if var_143 then
                            let (var_144: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_144, var_3)))))
                        else
                            let (var_145: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_145)))))
                    else
                        let (var_147: EnvHeapMutable45) = var_10.mem_1
                        let (var_148: Union40) = Union40Case1
                        var_147.mem_0 <- var_148
                        let (var_149: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_149, var_3)))))
                | Union42Case4 ->
                    let (var_151: int64) = (var_0 + var_1)
                    let (var_152: int64) = (!var_18)
                    let (var_153: EnvHeapMutable45) = var_10.mem_1
                    let (var_154: int64) = var_153.mem_1
                    let (var_155: int64) = (var_151 - var_154)
                    let (var_156: bool) = (var_152 > var_155)
                    let (var_157: int64) =
                        if var_156 then
                            var_155
                        else
                            var_152
                    let (var_158: int64) = (-var_157)
                    let (var_159: int64) = (!var_18)
                    let (var_160: int64) = (var_159 + var_158)
                    var_18 := var_160
                    let (var_161: int64) = var_153.mem_1
                    let (var_162: int64) = (var_161 + var_157)
                    var_153.mem_1 <- var_162
                    let (var_163: int64) = var_153.mem_1
                    let (var_164: int64) = (!var_18)
                    let (var_165: bool) = (var_164 = 0L)
                    if var_165 then
                        let (var_166: bool) = (var_163 > var_0)
                        if var_166 then
                            let (var_167: int64) = (var_163 - var_0)
                            let (var_168: bool) = (var_1 > var_167)
                            let (var_169: int64) =
                                if var_168 then
                                    var_1
                                else
                                    var_167
                            let (var_170: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_163, var_169, var_170, 0L)))))
                        else
                            let (var_171: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_171, var_3)))))
                    else
                        let (var_173: bool) = (var_163 > var_0)
                        if var_173 then
                            let (var_174: int64) = (var_163 - var_0)
                            let (var_175: bool) = (var_1 > var_174)
                            let (var_176: int64) =
                                if var_175 then
                                    var_1
                                else
                                    var_174
                            (Union48Case0(Tuple50((Env49(var_163, var_176, var_2, 1L)))))
                        else
                            let (var_177: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_178: int64) = var_177.mem_0
                            let (var_179: int64) = var_177.mem_1
                            let (var_180: int64) = var_177.mem_2
                            let (var_181: int64) = var_177.mem_3
                            (Union48Case0(Tuple50((Env49(var_178, var_179, var_180, var_181)))))
                | Union42Case5 ->
                    let (var_184: int64) = (var_0 + var_1)
                    let (var_185: int64) = (!var_18)
                    let (var_186: EnvHeapMutable45) = var_10.mem_1
                    let (var_187: int64) = var_186.mem_1
                    let (var_188: int64) = (var_184 - var_187)
                    let (var_189: bool) = (var_185 > var_188)
                    let (var_190: int64) =
                        if var_189 then
                            var_188
                        else
                            var_185
                    let (var_191: int64) = (-var_190)
                    let (var_192: int64) = (!var_18)
                    let (var_193: int64) = (var_192 + var_191)
                    var_18 := var_193
                    let (var_194: int64) = var_186.mem_1
                    let (var_195: int64) = (var_194 + var_190)
                    var_186.mem_1 <- var_195
                    let (var_196: int64) = var_186.mem_1
                    let (var_197: int64) = (!var_18)
                    let (var_198: bool) = (var_197 = 0L)
                    if var_198 then
                        let (var_199: bool) = (var_196 > var_0)
                        if var_199 then
                            let (var_200: int64) = (var_196 - var_0)
                            let (var_201: bool) = (var_1 > var_200)
                            let (var_202: int64) =
                                if var_201 then
                                    var_1
                                else
                                    var_200
                            let (var_203: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_196, var_202, var_203, 0L)))))
                        else
                            let (var_204: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_204, var_3)))))
                    else
                        let (var_206: bool) = (var_196 > var_0)
                        if var_206 then
                            let (var_207: int64) = (var_196 - var_0)
                            let (var_208: bool) = (var_1 > var_207)
                            let (var_209: int64) =
                                if var_208 then
                                    var_1
                                else
                                    var_207
                            (Union48Case0(Tuple50((Env49(var_196, var_209, var_2, 1L)))))
                        else
                            let (var_210: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_211: int64) = var_210.mem_0
                            let (var_212: int64) = var_210.mem_1
                            let (var_213: int64) = var_210.mem_2
                            let (var_214: int64) = var_210.mem_3
                            (Union48Case0(Tuple50((Env49(var_211, var_212, var_213, var_214)))))
                | Union42Case6 ->
                    let (var_217: bool) = (var_45 >= var_31)
                    let (var_219: bool) =
                        if var_217 then
                            true
                        else
                            (var_43 = 0L)
                    if var_219 then
                        let (var_220: int64) = (!var_18)
                        let (var_221: EnvHeapMutable45) = var_10.mem_1
                        let (var_222: int64) = var_221.mem_1
                        let (var_223: int64) = (var_0 - var_222)
                        let (var_224: bool) = (var_220 > var_223)
                        let (var_225: int64) =
                            if var_224 then
                                var_223
                            else
                                var_220
                        let (var_226: int64) = (-var_225)
                        let (var_227: int64) = (!var_18)
                        let (var_228: int64) = (var_227 + var_226)
                        var_18 := var_228
                        let (var_229: int64) = var_221.mem_1
                        let (var_230: int64) = (var_229 + var_225)
                        var_221.mem_1 <- var_230
                        let (var_231: int64) = (!var_18)
                        let (var_232: bool) = (var_231 = 0L)
                        if var_232 then
                            let (var_233: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_233, var_3)))))
                        else
                            let (var_234: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_234)))))
                    else
                        let (var_236: EnvHeapMutable45) = var_10.mem_1
                        let (var_237: Union40) = Union40Case1
                        var_236.mem_0 <- var_237
                        let (var_238: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_238, var_3)))))
                | Union42Case7 ->
                    let (var_240: int64) = (var_0 + var_1)
                    let (var_241: int64) = (!var_18)
                    let (var_242: EnvHeapMutable45) = var_10.mem_1
                    let (var_243: int64) = var_242.mem_1
                    let (var_244: int64) = (var_240 - var_243)
                    let (var_245: bool) = (var_241 > var_244)
                    let (var_246: int64) =
                        if var_245 then
                            var_244
                        else
                            var_241
                    let (var_247: int64) = (-var_246)
                    let (var_248: int64) = (!var_18)
                    let (var_249: int64) = (var_248 + var_247)
                    var_18 := var_249
                    let (var_250: int64) = var_242.mem_1
                    let (var_251: int64) = (var_250 + var_246)
                    var_242.mem_1 <- var_251
                    let (var_252: int64) = var_242.mem_1
                    let (var_253: int64) = (!var_18)
                    let (var_254: bool) = (var_253 = 0L)
                    if var_254 then
                        let (var_255: bool) = (var_252 > var_0)
                        if var_255 then
                            let (var_256: int64) = (var_252 - var_0)
                            let (var_257: bool) = (var_1 > var_256)
                            let (var_258: int64) =
                                if var_257 then
                                    var_1
                                else
                                    var_256
                            let (var_259: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_252, var_258, var_259, 0L)))))
                        else
                            let (var_260: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_260, var_3)))))
                    else
                        let (var_262: bool) = (var_252 > var_0)
                        if var_262 then
                            let (var_263: int64) = (var_252 - var_0)
                            let (var_264: bool) = (var_1 > var_263)
                            let (var_265: int64) =
                                if var_264 then
                                    var_1
                                else
                                    var_263
                            (Union48Case0(Tuple50((Env49(var_252, var_265, var_2, 1L)))))
                        else
                            let (var_266: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_267: int64) = var_266.mem_0
                            let (var_268: int64) = var_266.mem_1
                            let (var_269: int64) = var_266.mem_2
                            let (var_270: int64) = var_266.mem_3
                            (Union48Case0(Tuple50((Env49(var_267, var_268, var_269, var_270)))))
                | Union42Case8 ->
                    let (var_273: bool) = (var_45 >= var_31)
                    let (var_275: bool) =
                        if var_273 then
                            true
                        else
                            (var_43 = 0L)
                    if var_275 then
                        let (var_276: int64) = (!var_18)
                        let (var_277: EnvHeapMutable45) = var_10.mem_1
                        let (var_278: int64) = var_277.mem_1
                        let (var_279: int64) = (var_0 - var_278)
                        let (var_280: bool) = (var_276 > var_279)
                        let (var_281: int64) =
                            if var_280 then
                                var_279
                            else
                                var_276
                        let (var_282: int64) = (-var_281)
                        let (var_283: int64) = (!var_18)
                        let (var_284: int64) = (var_283 + var_282)
                        var_18 := var_284
                        let (var_285: int64) = var_277.mem_1
                        let (var_286: int64) = (var_285 + var_281)
                        var_277.mem_1 <- var_286
                        let (var_287: int64) = (!var_18)
                        let (var_288: bool) = (var_287 = 0L)
                        if var_288 then
                            let (var_289: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_289, var_3)))))
                        else
                            let (var_290: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_290)))))
                    else
                        let (var_292: EnvHeapMutable45) = var_10.mem_1
                        let (var_293: Union40) = Union40Case1
                        var_292.mem_0 <- var_293
                        let (var_294: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_294, var_3)))))
                | Union42Case9 ->
                    let (var_296: bool) = (var_45 >= var_31)
                    let (var_298: bool) =
                        if var_296 then
                            true
                        else
                            (var_43 = 0L)
                    if var_298 then
                        let (var_299: int64) = (!var_18)
                        let (var_300: EnvHeapMutable45) = var_10.mem_1
                        let (var_301: int64) = var_300.mem_1
                        let (var_302: int64) = (var_0 - var_301)
                        let (var_303: bool) = (var_299 > var_302)
                        let (var_304: int64) =
                            if var_303 then
                                var_302
                            else
                                var_299
                        let (var_305: int64) = (-var_304)
                        let (var_306: int64) = (!var_18)
                        let (var_307: int64) = (var_306 + var_305)
                        var_18 := var_307
                        let (var_308: int64) = var_300.mem_1
                        let (var_309: int64) = (var_308 + var_304)
                        var_300.mem_1 <- var_309
                        let (var_310: int64) = (!var_18)
                        let (var_311: bool) = (var_310 = 0L)
                        if var_311 then
                            let (var_312: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_312, var_3)))))
                        else
                            let (var_313: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_313)))))
                    else
                        let (var_315: EnvHeapMutable45) = var_10.mem_1
                        let (var_316: Union40) = Union40Case1
                        var_315.mem_0 <- var_316
                        let (var_317: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_317, var_3)))))
                | Union42Case10 ->
                    let (var_319: int64) = (var_0 + var_1)
                    let (var_320: int64) = (!var_18)
                    let (var_321: EnvHeapMutable45) = var_10.mem_1
                    let (var_322: int64) = var_321.mem_1
                    let (var_323: int64) = (var_319 - var_322)
                    let (var_324: bool) = (var_320 > var_323)
                    let (var_325: int64) =
                        if var_324 then
                            var_323
                        else
                            var_320
                    let (var_326: int64) = (-var_325)
                    let (var_327: int64) = (!var_18)
                    let (var_328: int64) = (var_327 + var_326)
                    var_18 := var_328
                    let (var_329: int64) = var_321.mem_1
                    let (var_330: int64) = (var_329 + var_325)
                    var_321.mem_1 <- var_330
                    let (var_331: int64) = var_321.mem_1
                    let (var_332: int64) = (!var_18)
                    let (var_333: bool) = (var_332 = 0L)
                    if var_333 then
                        let (var_334: bool) = (var_331 > var_0)
                        if var_334 then
                            let (var_335: int64) = (var_331 - var_0)
                            let (var_336: bool) = (var_1 > var_335)
                            let (var_337: int64) =
                                if var_336 then
                                    var_1
                                else
                                    var_335
                            let (var_338: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_331, var_337, var_338, 0L)))))
                        else
                            let (var_339: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_339, var_3)))))
                    else
                        let (var_341: bool) = (var_331 > var_0)
                        if var_341 then
                            let (var_342: int64) = (var_331 - var_0)
                            let (var_343: bool) = (var_1 > var_342)
                            let (var_344: int64) =
                                if var_343 then
                                    var_1
                                else
                                    var_342
                            (Union48Case0(Tuple50((Env49(var_331, var_344, var_2, 1L)))))
                        else
                            let (var_345: Env49) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_346: int64) = var_345.mem_0
                            let (var_347: int64) = var_345.mem_1
                            let (var_348: int64) = var_345.mem_2
                            let (var_349: int64) = var_345.mem_3
                            (Union48Case0(Tuple50((Env49(var_346, var_347, var_348, var_349)))))
                | Union42Case11 ->
                    let (var_352: bool) = (var_45 >= var_31)
                    let (var_354: bool) =
                        if var_352 then
                            true
                        else
                            (var_43 = 0L)
                    if var_354 then
                        let (var_355: int64) = (!var_18)
                        let (var_356: EnvHeapMutable45) = var_10.mem_1
                        let (var_357: int64) = var_356.mem_1
                        let (var_358: int64) = (var_0 - var_357)
                        let (var_359: bool) = (var_355 > var_358)
                        let (var_360: int64) =
                            if var_359 then
                                var_358
                            else
                                var_355
                        let (var_361: int64) = (-var_360)
                        let (var_362: int64) = (!var_18)
                        let (var_363: int64) = (var_362 + var_361)
                        var_18 := var_363
                        let (var_364: int64) = var_356.mem_1
                        let (var_365: int64) = (var_364 + var_360)
                        var_356.mem_1 <- var_365
                        let (var_366: int64) = (!var_18)
                        let (var_367: bool) = (var_366 = 0L)
                        if var_367 then
                            let (var_368: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_368, var_3)))))
                        else
                            let (var_369: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_369)))))
                    else
                        let (var_371: EnvHeapMutable45) = var_10.mem_1
                        let (var_372: Union40) = Union40Case1
                        var_371.mem_0 <- var_372
                        let (var_373: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_373, var_3)))))
                | Union42Case12 ->
                    let (var_375: bool) = (var_45 >= var_31)
                    let (var_377: bool) =
                        if var_375 then
                            true
                        else
                            (var_43 = 0L)
                    if var_377 then
                        let (var_378: int64) = (!var_18)
                        let (var_379: EnvHeapMutable45) = var_10.mem_1
                        let (var_380: int64) = var_379.mem_1
                        let (var_381: int64) = (var_0 - var_380)
                        let (var_382: bool) = (var_378 > var_381)
                        let (var_383: int64) =
                            if var_382 then
                                var_381
                            else
                                var_378
                        let (var_384: int64) = (-var_383)
                        let (var_385: int64) = (!var_18)
                        let (var_386: int64) = (var_385 + var_384)
                        var_18 := var_386
                        let (var_387: int64) = var_379.mem_1
                        let (var_388: int64) = (var_387 + var_383)
                        var_379.mem_1 <- var_388
                        let (var_389: int64) = (!var_18)
                        let (var_390: bool) = (var_389 = 0L)
                        if var_390 then
                            let (var_391: int64) = (var_2 - 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_391, var_3)))))
                        else
                            let (var_392: int64) = (var_3 + 1L)
                            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_392)))))
                    else
                        let (var_394: EnvHeapMutable45) = var_10.mem_1
                        let (var_395: Union40) = Union40Case1
                        var_394.mem_0 <- var_395
                        let (var_396: int64) = (var_2 - 1L)
                        (Union48Case0(Tuple50((Env49(var_0, var_1, var_396, var_3)))))
            | Union40Case1 ->
                (failwith "No self in the internal representation.")
        else
            (Union48Case0(Tuple50((Env49(var_0, var_1, var_2, var_3)))))
    else
        Union48Case1
and method_121((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_122((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_122", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_124((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_125((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_125", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_128((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_129((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_129", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_131((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_132((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_132", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(6u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_135((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeap47), (var_5: EnvHeap46), (var_6: EnvStack28)): unit =
    // In betting's loop.
    let (var_7: int64) = 0L
    let (var_8: bool) = (0L <> var_7)
    let (var_19: Env37) =
        if var_8 then
            let (var_9: (int64 ref)) = var_4.mem_0
            let (var_10: int64) = (!var_9)
            let (var_11: EnvHeapMutable45) = var_4.mem_1
            let (var_12: int64) = var_11.mem_1
            let (var_13: Union40) = Union40Case1
            (Env37(var_10, var_13, var_12))
        else
            let (var_14: (int64 ref)) = var_4.mem_0
            let (var_15: int64) = (!var_14)
            let (var_16: EnvHeapMutable45) = var_4.mem_1
            let (var_17: int64) = var_16.mem_1
            let (var_18: Union40) = var_16.mem_0
            (Env37(var_15, var_18, var_17))
    let (var_20: int64) = var_19.mem_0
    let (var_21: Union40) = var_19.mem_1
    let (var_22: int64) = var_19.mem_2
    let (var_23: bool) = (1L <> var_7)
    let (var_34: Env37) =
        if var_23 then
            let (var_24: (int64 ref)) = var_5.mem_2
            let (var_25: int64) = (!var_24)
            let (var_26: EnvHeapMutable45) = var_5.mem_4
            let (var_27: int64) = var_26.mem_1
            let (var_28: Union40) = Union40Case1
            (Env37(var_25, var_28, var_27))
        else
            let (var_29: (int64 ref)) = var_5.mem_2
            let (var_30: int64) = (!var_29)
            let (var_31: EnvHeapMutable45) = var_5.mem_4
            let (var_32: int64) = var_31.mem_1
            let (var_33: Union40) = var_31.mem_0
            (Env37(var_30, var_33, var_32))
    let (var_35: int64) = var_34.mem_0
    let (var_36: Union40) = var_34.mem_1
    let (var_37: int64) = var_34.mem_2
    let (var_38: Union48) = method_114((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_20: int64), (var_21: Union40), (var_22: int64), (var_35: int64), (var_36: Union40), (var_37: int64), (var_4: EnvHeap47))
    match var_38 with
    | Union48Case0(var_39) ->
        let (var_40: Env49) = var_39.mem_0
        let (var_41: int64) = var_40.mem_0
        let (var_42: int64) = var_40.mem_1
        let (var_43: int64) = var_40.mem_2
        let (var_44: int64) = var_40.mem_3
        let (var_45: int64) = (var_7 + 1L)
        let (var_46: bool) = (0L <> var_45)
        let (var_57: Env37) =
            if var_46 then
                let (var_47: (int64 ref)) = var_4.mem_0
                let (var_48: int64) = (!var_47)
                let (var_49: EnvHeapMutable45) = var_4.mem_1
                let (var_50: int64) = var_49.mem_1
                let (var_51: Union40) = Union40Case1
                (Env37(var_48, var_51, var_50))
            else
                let (var_52: (int64 ref)) = var_4.mem_0
                let (var_53: int64) = (!var_52)
                let (var_54: EnvHeapMutable45) = var_4.mem_1
                let (var_55: int64) = var_54.mem_1
                let (var_56: Union40) = var_54.mem_0
                (Env37(var_53, var_56, var_55))
        let (var_58: int64) = var_57.mem_0
        let (var_59: Union40) = var_57.mem_1
        let (var_60: int64) = var_57.mem_2
        let (var_61: bool) = (1L <> var_45)
        let (var_72: Env37) =
            if var_61 then
                let (var_62: (int64 ref)) = var_5.mem_2
                let (var_63: int64) = (!var_62)
                let (var_64: EnvHeapMutable45) = var_5.mem_4
                let (var_65: int64) = var_64.mem_1
                let (var_66: Union40) = Union40Case1
                (Env37(var_63, var_66, var_65))
            else
                let (var_67: (int64 ref)) = var_5.mem_2
                let (var_68: int64) = (!var_67)
                let (var_69: EnvHeapMutable45) = var_5.mem_4
                let (var_70: int64) = var_69.mem_1
                let (var_71: Union40) = var_69.mem_0
                (Env37(var_68, var_71, var_70))
        let (var_73: int64) = var_72.mem_0
        let (var_74: Union40) = var_72.mem_1
        let (var_75: int64) = var_72.mem_2
        let (var_76: Union48) = method_112((var_41: int64), (var_42: int64), (var_43: int64), (var_44: int64), (var_58: int64), (var_59: Union40), (var_60: int64), (var_73: int64), (var_74: Union40), (var_75: int64), (var_5: EnvHeap46), (var_6: EnvStack28))
        match var_76 with
        | Union48Case0(var_77) ->
            let (var_78: Env49) = var_77.mem_0
            let (var_79: int64) = var_78.mem_0
            let (var_80: int64) = var_78.mem_1
            let (var_81: int64) = var_78.mem_2
            let (var_82: int64) = var_78.mem_3
            let (var_83: int64) = (var_45 + 1L)
            method_135((var_79: int64), (var_80: int64), (var_81: int64), (var_82: int64), (var_4: EnvHeap47), (var_5: EnvHeap46), (var_6: EnvStack28))
        | Union48Case1 ->
            ()
    | Union48Case1 ->
        ()
and method_37((var_0: int64), (var_1: Union40), (var_2: int64), (var_3: int64), (var_4: Union40), (var_5: int64), (var_6: EnvHeap21), (var_7: EnvHeap24), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule)): EnvStack51 =
    let (var_10: bool) = (var_0 >= 0L)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_12: bool) = (var_0 < 21L)
    let (var_13: bool) = (var_12 = false)
    if var_13 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_14: Union40) = var_1
    let (var_20: int64) =
        match var_14 with
        | Union40Case0(var_15) ->
            let (var_16: Env41) = var_15.mem_0
            let (var_17: Union42) = var_16.mem_0
            let (var_18: Union42) = var_17
            match var_18 with
            | Union42Case0 ->
                0L
            | Union42Case1 ->
                1L
            | Union42Case2 ->
                2L
            | Union42Case3 ->
                3L
            | Union42Case4 ->
                4L
            | Union42Case5 ->
                5L
            | Union42Case6 ->
                6L
            | Union42Case7 ->
                7L
            | Union42Case8 ->
                8L
            | Union42Case9 ->
                9L
            | Union42Case10 ->
                10L
            | Union42Case11 ->
                11L
            | Union42Case12 ->
                12L
        | Union40Case1 ->
            13L
    let (var_21: int64) = (21L + var_20)
    let (var_22: bool) = (var_2 >= 0L)
    let (var_23: bool) = (var_22 = false)
    if var_23 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_24: bool) = (var_2 < 21L)
    let (var_25: bool) = (var_24 = false)
    if var_25 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_26: int64) = (35L + var_2)
    let (var_27: bool) = (var_3 >= 0L)
    let (var_28: bool) = (var_27 = false)
    if var_28 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_29: bool) = (var_3 < 21L)
    let (var_30: bool) = (var_29 = false)
    if var_30 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_31: int64) = (56L + var_3)
    let (var_32: Union40) = var_4
    let (var_38: int64) =
        match var_32 with
        | Union40Case0(var_33) ->
            let (var_34: Env41) = var_33.mem_0
            let (var_35: Union42) = var_34.mem_0
            let (var_36: Union42) = var_35
            match var_36 with
            | Union42Case0 ->
                0L
            | Union42Case1 ->
                1L
            | Union42Case2 ->
                2L
            | Union42Case3 ->
                3L
            | Union42Case4 ->
                4L
            | Union42Case5 ->
                5L
            | Union42Case6 ->
                6L
            | Union42Case7 ->
                7L
            | Union42Case8 ->
                8L
            | Union42Case9 ->
                9L
            | Union42Case10 ->
                10L
            | Union42Case11 ->
                11L
            | Union42Case12 ->
                12L
        | Union40Case1 ->
            13L
    let (var_39: int64) = (77L + var_38)
    let (var_40: bool) = (var_5 >= 0L)
    let (var_41: bool) = (var_40 = false)
    if var_41 then
        (failwith "x must be greater or equal to its lower bound.")
    else
        ()
    let (var_42: bool) = (var_5 < 21L)
    let (var_43: bool) = (var_42 = false)
    if var_43 then
        (failwith "x must be lesser than its upper bound.")
    else
        ()
    let (var_44: int64) = (91L + var_5)
    let (var_45: EnvStack52) = method_38((var_0: int64), (var_21: int64), (var_26: int64), (var_31: int64), (var_39: int64), (var_44: int64), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule))
    let (var_46: (int64 ref)) = var_45.mem_0
    let (var_47: (uint64 ref)) = var_45.mem_1
    let (var_48: EnvStack53) = method_45((var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_46: (int64 ref)), (var_47: (uint64 ref)), (var_6: EnvHeap21))
    let (var_49: (int64 ref)) = var_48.mem_0
    let (var_50: (uint64 ref)) = var_48.mem_1
    let (var_51: (int64 ref)) = var_48.mem_2
    let (var_52: (uint64 ref)) = var_48.mem_3
    let (var_53: (unit -> unit)) = var_48.mem_4
    let (var_54: EnvStack54) = method_70((var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_49: (int64 ref)), (var_50: (uint64 ref)), (var_51: (int64 ref)), (var_52: (uint64 ref)), (var_7: EnvHeap24))
    let (var_55: (int64 ref)) = var_54.mem_0
    let (var_56: (uint64 ref)) = var_54.mem_1
    let (var_57: (int64 ref)) = var_54.mem_2
    let (var_58: (uint64 ref)) = var_54.mem_3
    let (var_59: (unit -> unit)) = var_54.mem_4
    let (var_60: EnvStack55) = method_86((var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_55: (int64 ref)), (var_56: (uint64 ref)), (var_57: (int64 ref)), (var_58: (uint64 ref)))
    let (var_61: (int64 ref)) = var_60.mem_0
    let (var_62: (uint64 ref)) = var_60.mem_1
    let (var_63: (float -> unit)) = var_60.mem_2
    let (var_64: int64) = 1L
    let (var_65: int64) = 0L
    let (var_66: (int64 [])) = method_106((var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_64: int64), (var_61: (int64 ref)), (var_62: (uint64 ref)), (var_65: int64))
    let (var_67: int64) = var_66.[int32 0L]
    let (var_68: int64) = (var_67 - 1L)
    let (var_69: int64) = (var_68 - 1L)
    let (var_70: int64) = (var_69 - 1L)
    let (var_71: int64) = (var_67 % 3L)
    let (var_72: bool) = (var_71 < 1L)
    let (var_77: Union35) =
        if var_72 then
            Union35Case0
        else
            let (var_73: int64) = (var_71 - 1L)
            let (var_74: bool) = (var_73 < 1L)
            if var_74 then
                Union35Case1
            else
                let (var_75: int64) = (var_73 - 1L)
                Union35Case2
    EnvStack51((var_77: Union35), (var_53: (unit -> unit)), (var_59: (unit -> unit)), (var_63: (float -> unit)))
and method_113 ((var_1: (unit -> unit)), (var_2: (unit -> unit)), (var_3: (float -> unit))) ((var_0: float)): unit =
    let (var_4: float) = (var_0 / 10.000000)
    var_3(var_4)
    var_2()
    var_1()
and method_38((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): EnvStack52 =
    let (var_22: Env10) = method_39((var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: Env31) = var_22.mem_1
    let (var_25: (uint64 ref)) = var_24.mem_0
    method_40((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_23: (int64 ref)), (var_25: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
    EnvStack52((var_23: (int64 ref)), (var_25: (uint64 ref)))
and method_45((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap21)): EnvStack53 =
    let (var_5: (int64 ref)) = var_4.mem_4
    let (var_6: (uint64 ref)) = var_4.mem_5
    let (var_7: (int64 ref)) = var_4.mem_6
    let (var_8: (uint64 ref)) = var_4.mem_7
    let (var_9: (int64 ref)) = var_4.mem_0
    let (var_10: (uint64 ref)) = var_4.mem_1
    let (var_11: (int64 ref)) = var_4.mem_2
    let (var_12: (uint64 ref)) = var_4.mem_3
    let (var_13: EnvStack56) = method_46((var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: (uint64 ref)) = var_13.mem_1
    let (var_16: EnvStack56) = method_48((var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: (uint64 ref)) = var_16.mem_1
    method_50((var_11: (int64 ref)), (var_12: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_19: EnvStack56) = method_55((var_14: (int64 ref)), (var_15: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_20: (int64 ref)) = var_19.mem_0
    let (var_21: (uint64 ref)) = var_19.mem_1
    let (var_22: EnvStack56) = method_48((var_20: (int64 ref)), (var_21: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: (uint64 ref)) = var_22.mem_1
    let (var_25: (unit -> unit)) = method_59((var_17: (int64 ref)), (var_18: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_11: (int64 ref)), (var_12: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_5: (int64 ref)), (var_6: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: (uint64 ref)), (var_20: (int64 ref)), (var_21: (uint64 ref)))
    EnvStack53((var_23: (int64 ref)), (var_24: (uint64 ref)), (var_20: (int64 ref)), (var_21: (uint64 ref)), (var_25: (unit -> unit)))
and method_70((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap24)): EnvStack54 =
    let (var_7: (int64 ref)) = var_6.mem_4
    let (var_8: (uint64 ref)) = var_6.mem_5
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: (uint64 ref)) = var_6.mem_7
    let (var_11: (int64 ref)) = var_6.mem_0
    let (var_12: (uint64 ref)) = var_6.mem_1
    let (var_13: (int64 ref)) = var_6.mem_2
    let (var_14: (uint64 ref)) = var_6.mem_3
    let (var_15: EnvStack57) = method_71((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: (uint64 ref)) = var_15.mem_1
    let (var_18: EnvStack57) = method_73((var_16: (int64 ref)), (var_17: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: (uint64 ref)) = var_18.mem_1
    method_75((var_13: (int64 ref)), (var_14: (uint64 ref)), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_21: (unit -> unit)) = method_79((var_19: (int64 ref)), (var_20: (uint64 ref)), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_11: (int64 ref)), (var_12: (uint64 ref)), (var_13: (int64 ref)), (var_14: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack54((var_19: (int64 ref)), (var_20: (uint64 ref)), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_21: (unit -> unit)))
and method_86((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref))): EnvStack55 =
    let (var_6: EnvStack57) = method_87((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: (uint64 ref)) = var_6.mem_1
    let (var_9: EnvStack58) = method_92((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_10: (int64 ref)) = var_9.mem_0
    let (var_11: (uint64 ref)) = var_9.mem_1
    let (var_12: EnvStack59) = method_95((var_7: (int64 ref)), (var_8: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: (uint64 ref)) = var_12.mem_1
    let (var_16: (float -> unit)) = method_102((var_13: (int64 ref)), (var_14: (uint64 ref)), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)))
    EnvStack55((var_13: (int64 ref)), (var_14: (uint64 ref)), (var_16: (float -> unit)))
and method_106((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (int64 ref)), (var_4: (uint64 ref)), (var_5: int64)): (int64 []) =
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
and method_39((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 448L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_40((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_10: uint64) = method_5((var_7: (uint64 ref)))
    method_41((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_10: uint64), (var_8: EnvHeap18), (var_9: ManagedCuda.BasicTypes.CUmodule))
and method_46((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack56 =
    let (var_6: Env10) = method_22((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env31) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_47((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack56((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_48((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack56 =
    let (var_4: Env10) = method_22((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env31) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_49((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack56((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_50((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    let (var_8: uint64) = method_5((var_3: (uint64 ref)))
    method_51((var_6: uint64), (var_7: uint64), (var_8: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_55((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack56 =
    let (var_12: Env10) = method_22((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env31) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_14.mem_0
    let (var_16: uint64) = method_5((var_1: (uint64 ref)))
    let (var_17: uint64) = method_5((var_15: (uint64 ref)))
    method_56((var_16: uint64), (var_17: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack56((var_13: (int64 ref)), (var_15: (uint64 ref)))
and method_59 ((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: (uint64 ref)), (var_18: (int64 ref)), (var_19: (uint64 ref))) (): unit =
    method_60((var_16: (int64 ref)), (var_17: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
    method_64((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
and method_71((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack57 =
    let (var_6: Env10) = method_31((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env31) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_72((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack57((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_73((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack57 =
    let (var_4: Env10) = method_31((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env31) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: EnvHeap16) = var_2.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_74((var_5: (int64 ref)), (var_7: (uint64 ref)), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack57((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_75((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    let (var_8: uint64) = method_5((var_3: (uint64 ref)))
    method_76((var_6: uint64), (var_7: uint64), (var_8: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_79 ((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)) (): unit =
    method_80((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_87((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack57 =
    let (var_7: Env10) = method_31((var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_8: (int64 ref)) = var_7.mem_0
    let (var_9: Env31) = var_7.mem_1
    let (var_10: (uint64 ref)) = var_9.mem_0
    let (var_11: uint64) = method_5((var_1: (uint64 ref)))
    let (var_12: uint64) = method_5((var_10: (uint64 ref)))
    method_88((var_11: uint64), (var_12: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack57((var_8: (int64 ref)), (var_10: (uint64 ref)))
and method_92((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack58 =
    let (var_2: Env10) = method_93((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env31) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_94((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack58((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_95((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack59 =
    let (var_11: Env10) = method_96((var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_12: (int64 ref)) = var_11.mem_0
    let (var_13: Env31) = var_11.mem_1
    let (var_14: (uint64 ref)) = var_13.mem_0
    method_97((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_12: (int64 ref)), (var_14: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack59((var_12: (int64 ref)), (var_14: (uint64 ref)))
and method_102 ((var_1: (int64 ref)), (var_2: (uint64 ref)), (var_3: (int64 ref)), (var_4: (uint64 ref)), (var_5: EnvHeap18), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: (uint64 ref)), (var_9: (int64 ref)), (var_10: (uint64 ref))) ((var_0: float)): unit =
    let (var_11: float32) = (float32 var_0)
    let (var_12: uint64) = method_5((var_8: (uint64 ref)))
    let (var_13: uint64) = method_5((var_4: (uint64 ref)))
    let (var_14: uint64) = method_5((var_2: (uint64 ref)))
    method_103((var_14: uint64), (var_13: uint64), (var_11: float32), (var_12: uint64), (var_5: EnvHeap18), (var_6: ManagedCuda.BasicTypes.CUmodule))
and method_41((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_7: EnvHeap18), (var_8: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_42((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvHeap18))
and method_47((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
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
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 112, var_15, var_18, 256, var_21, 112, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_49((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_51((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_52((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_56((var_0: uint64), (var_1: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_57((var_0: uint64), (var_1: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap18))
and method_60((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: uint64) = method_5((var_1: (uint64 ref)))
    let (var_9: uint64) = method_5((var_3: (uint64 ref)))
    let (var_10: uint64) = method_5((var_5: (uint64 ref)))
    method_61((var_8: uint64), (var_9: uint64), (var_10: uint64), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule))
and method_64((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_65((var_8: (int64 ref)), (var_9: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
    method_66((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_14: EnvHeap18), (var_15: ManagedCuda.BasicTypes.CUmodule))
and method_72((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
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
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 3, 1, 256, var_15, var_18, 3, var_21, 256, var_22, var_25, 3)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_74((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_5)
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(12L)
    var_2.ClearMemoryAsync(var_6, 0uy, var_7, var_3)
and method_76((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_77((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_77", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_80((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_10: (int64 ref)), (var_11: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_81((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_14: (int64 ref)), (var_15: (uint64 ref)), (var_8: (int64 ref)), (var_9: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_82((var_10: (int64 ref)), (var_11: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
    method_83((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_16: EnvHeap18), (var_17: ManagedCuda.BasicTypes.CUmodule))
and method_88((var_0: uint64), (var_1: uint64), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_89((var_0: uint64), (var_1: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap18))
and method_93((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 4L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_94((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap18), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap16) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap16))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateUniform32(var_11, var_5)
and method_96((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env10 =
    let (var_2: int64) = 8L
    method_11((var_0: EnvHeap18), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_97((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: uint64) = method_5((var_1: (uint64 ref)))
    let (var_9: uint64) = method_5((var_3: (uint64 ref)))
    let (var_10: uint64) = method_5((var_5: (uint64 ref)))
    method_98((var_8: uint64), (var_9: uint64), (var_10: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap18))
and method_103((var_0: uint64), (var_1: uint64), (var_2: float32), (var_3: uint64), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_104((var_0: uint64), (var_1: uint64), (var_2: float32), (var_3: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_42((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvHeap18)): unit =
    // Cuda join point
    // method_43((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: uint64))
    let (var_9: ManagedCuda.CudaContext) = var_8.mem_0
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_7, var_9)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(112u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (int64 ref)) = var_8.mem_6
    let (var_14: EnvHeap16) = var_8.mem_7
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_18((var_14: EnvHeap16))
    let (var_17: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_15, var_17)
and method_57((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_58((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_58", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_61((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: EnvHeap18), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_62((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18))
and method_65((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
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
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 112, 1, var_15, var_18, 256, var_21, 112, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_66((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_67((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_81((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
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
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 256, 1, 3, var_15, var_18, 3, var_21, 3, var_22, var_25, 256)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_82((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap18), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
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
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 3, 256, 1, var_15, var_18, 3, var_21, 256, var_22, var_25, 3)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_83((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap18), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: uint64) = method_5((var_1: (uint64 ref)))
    let (var_7: uint64) = method_5((var_3: (uint64 ref)))
    method_84((var_6: uint64), (var_7: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18))
and method_89((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_90((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_90", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_98((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_99((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_99", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_104((var_0: uint64), (var_1: uint64), (var_2: float32), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: EnvHeap18)): unit =
    // Cuda join point
    // method_105((var_0: uint64), (var_1: uint64), (var_2: float32), (var_3: uint64))
    let (var_6: ManagedCuda.CudaContext) = var_5.mem_0
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_105", var_4, var_6)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (int64 ref)) = var_5.mem_6
    let (var_11: EnvHeap16) = var_5.mem_7
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_11: EnvHeap16))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_62((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap18)): unit =
    // Cuda join point
    // method_63((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_63", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap16) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap16))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_67((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_68((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_68", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap16) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap16))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_84((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap18)): unit =
    // Cuda join point
    // method_85((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_85", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
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
let (var_161: EnvStack23) = method_30((var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: (uint64 ref)) = var_161.mem_1
let (var_164: EnvStack23) = method_33((var_162: (int64 ref)), (var_163: (uint64 ref)), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
let (var_165: (int64 ref)) = var_164.mem_0
let (var_166: (uint64 ref)) = var_164.mem_1
let (var_167: EnvHeap24) = ({mem_0 = (var_165: (int64 ref)); mem_1 = (var_166: (uint64 ref)); mem_2 = (var_162: (int64 ref)); mem_3 = (var_163: (uint64 ref)); mem_4 = (var_159: (int64 ref)); mem_5 = (var_160: (uint64 ref)); mem_6 = (var_156: (int64 ref)); mem_7 = (var_157: (uint64 ref))} : EnvHeap24)
let (var_168: EnvHeap25) = ({mem_0 = (var_154: EnvHeap21); mem_1 = (var_167: EnvHeap24)} : EnvHeap25)
let (var_169: ResizeArray<Union26>) = ResizeArray<Union26>()
let (var_170: EnvStack27) = EnvStack27((var_169: ResizeArray<Union26>))
let (var_171: EnvStack28) = EnvStack28((var_170: EnvStack27))
let (var_172: (int64 ref)) = (ref 0L)
let (var_173: EnvHeap29) = ({mem_0 = (var_168: EnvHeap25); mem_1 = (var_172: (int64 ref))} : EnvHeap29)
let (var_174: (int64 ref)) = (ref 0L)
let (var_175: EnvHeap30) = ({mem_0 = (var_174: (int64 ref))} : EnvHeap30)
let (var_176: int64) = 40L
let (var_177: int64) = 1000L
method_34((var_173: EnvHeap29), (var_171: EnvStack28), (var_175: EnvHeap30), (var_1: EnvStack0), (var_176: int64), (var_177: int64), (var_107: EnvHeap18), (var_34: ManagedCuda.BasicTypes.CUmodule))
method_138((var_105: EnvStack14))
method_136((var_90: EnvStack11))
var_56.Dispose()
var_50.Dispose()
let (var_178: uint64) = method_5((var_42: (uint64 ref)))
let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_178)
let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_179)
var_51.FreeMemory(var_180)
var_42 := 0UL
var_3.Dispose()

