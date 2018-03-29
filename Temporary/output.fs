module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct EnvStack1 {
        float mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ EnvStack1 make_EnvStack1(float mem_0, float mem_1, float mem_2){
        EnvStack1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    struct Tuple0 {
        EnvStack1 mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ Tuple0 make_Tuple0(EnvStack1 mem_0, float mem_1, float mem_2){
        Tuple0 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    struct Tuple2 {
        EnvStack1 mem_0;
        float mem_1;
        float mem_2;
        float mem_3;
    };
    __device__ __forceinline__ Tuple2 make_Tuple2(EnvStack1 mem_0, float mem_1, float mem_2, float mem_3){
        Tuple2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        tmp.mem_3 = mem_3;
        return tmp;
    }
    struct Tuple3 {
        EnvStack1 mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(EnvStack1 mem_0, float mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple9 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple9 make_Tuple9(float mem_0, float mem_1){
        Tuple9 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer4)(float, float);
    struct EnvStack6 {
        float mem_0;
        float mem_1;
        float mem_2;
        float mem_3;
        float mem_4;
        float mem_5;
    };
    __device__ __forceinline__ EnvStack6 make_EnvStack6(float mem_0, float mem_1, float mem_2, float mem_3, float mem_4, float mem_5){
        EnvStack6 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        tmp.mem_3 = mem_3;
        tmp.mem_4 = mem_4;
        tmp.mem_5 = mem_5;
        return tmp;
    }
    struct Tuple5 {
        EnvStack6 mem_0;
        float mem_1;
        float mem_2;
    };
    __device__ __forceinline__ Tuple5 make_Tuple5(EnvStack6 mem_0, float mem_1, float mem_2){
        Tuple5 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        return tmp;
    }
    struct Tuple7 {
        EnvStack6 mem_0;
        float mem_1;
        float mem_2;
        float mem_3;
    };
    __device__ __forceinline__ Tuple7 make_Tuple7(EnvStack6 mem_0, float mem_1, float mem_2, float mem_3){
        Tuple7 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        tmp.mem_3 = mem_3;
        return tmp;
    }
    struct Tuple8 {
        EnvStack6 mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple8 make_Tuple8(EnvStack6 mem_0, float mem_1){
        Tuple8 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __global__ void method_22(unsigned char * var_0, float * var_1);
    __global__ void method_35(float var_0, float * var_1);
    __global__ void method_70(float * var_0, float * var_1, float * var_2);
    __global__ void method_90(float * var_0, float * var_1, float * var_2);
    __global__ void method_56(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_62(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_85(float * var_0, float * var_1);
    __global__ void method_120(float * var_0, float * var_1);
    __global__ void method_124(float * var_0, float * var_1);
    __global__ void method_77(float * var_0, float * var_1);
    __global__ void method_96(float * var_0, float * var_1, float * var_2);
    __global__ void method_105(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6);
    __global__ void method_109(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8);
    __device__ char method_23(long long int * var_0);
    __device__ char method_24(long long int * var_0);
    __device__ char method_57(long long int * var_0);
    __device__ char method_91(long long int * var_0, float * var_1);
    __device__ char method_58(long long int * var_0);
    __device__ float method_86(float var_0, float var_1);
    __device__ char method_125(long long int * var_0);
    __device__ char method_78(long long int * var_0, float * var_1);
    __device__ char method_79(long long int * var_0, float * var_1);
    __device__ char method_80(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_97(long long int * var_0);
    
    __global__ void method_22(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_23(var_6)) {
            long long int var_8 = var_6[0];
            long long int var_9 = (var_8 % 32);
            long long int var_10 = (var_8 / 32);
            long long int var_11 = (var_10 % 64);
            long long int var_12 = (var_10 / 64);
            long long int var_13 = (var_12 % 17428);
            long long int var_14 = (var_12 / 17428);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 17428);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = (var_13 * 8192);
            char var_20 = (var_11 >= 0);
            char var_22;
            if (var_20) {
                var_22 = (var_11 < 64);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_24 = (var_11 * 17428);
            char var_26;
            if (var_15) {
                var_26 = (var_13 < 17428);
            } else {
                var_26 = 0;
            }
            char var_27 = (var_26 == 0);
            if (var_27) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_28 = (var_24 + var_13);
            unsigned char var_29 = var_0[var_28];
            char var_31;
            if (var_20) {
                var_31 = (var_11 < 64);
            } else {
                var_31 = 0;
            }
            char var_32 = (var_31 == 0);
            if (var_32) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_33 = (var_11 * 128);
            long long int var_34 = (var_19 + var_33);
            long long int var_35[1];
            var_35[0] = var_9;
            while (method_24(var_35)) {
                long long int var_37 = var_35[0];
                unsigned char var_38 = ((unsigned char) (var_37));
                char var_39 = (var_29 == var_38);
                float var_40;
                if (var_39) {
                    var_40 = 1;
                } else {
                    var_40 = 0;
                }
                char var_41 = (var_37 >= 0);
                char var_43;
                if (var_41) {
                    var_43 = (var_37 < 128);
                } else {
                    var_43 = 0;
                }
                char var_44 = (var_43 == 0);
                if (var_44) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_45 = (var_34 + var_37);
                var_1[var_45] = var_40;
                long long int var_46 = (var_37 + 32);
                var_35[0] = var_46;
            }
            long long int var_47 = var_35[0];
            long long int var_48 = (var_8 + 35692544);
            var_6[0] = var_48;
        }
        long long int var_49 = var_6[0];
    }
    __global__ void method_35(float var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_24(var_6)) {
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
            float var_16 = var_1[var_8];
            var_1[var_8] = var_0;
            long long int var_17 = (var_8 + 128);
            var_6[0] = var_17;
        }
        long long int var_18 = var_6[0];
    }
    __global__ void method_70(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_24(var_7)) {
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
            float var_14 = var_0[var_9];
            long long int var_15 = threadIdx.y;
            long long int var_16 = blockIdx.y;
            long long int var_17 = (32 * var_16);
            long long int var_18 = (var_15 + var_17);
            long long int var_19[1];
            var_19[0] = var_18;
            while (method_57(var_19)) {
                long long int var_21 = var_19[0];
                char var_22 = (var_21 >= 0);
                char var_24;
                if (var_22) {
                    var_24 = (var_21 < 64);
                } else {
                    var_24 = 0;
                }
                char var_25 = (var_24 == 0);
                if (var_25) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_26 = (var_21 * 128);
                char var_28;
                if (var_10) {
                    var_28 = (var_9 < 128);
                } else {
                    var_28 = 0;
                }
                char var_29 = (var_28 == 0);
                if (var_29) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_30 = (var_26 + var_9);
                char var_32;
                if (var_22) {
                    var_32 = (var_21 < 64);
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
                float var_37 = var_1[var_30];
                float var_38 = var_2[var_30];
                float var_39 = (var_14 + var_37);
                var_2[var_30] = var_39;
                long long int var_40 = (var_21 + 32);
                var_19[0] = var_40;
            }
            long long int var_41 = var_19[0];
            long long int var_42 = (var_9 + 128);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_90(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_91(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 8192);
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
        float var_27 = (var_26 / 64);
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
    __global__ void method_56(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.y;
        long long int var_5 = blockIdx.y;
        long long int var_6 = (var_4 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_57(var_7)) {
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
            long long int var_14 = (var_9 * 128);
            char var_16;
            if (var_10) {
                var_16 = (var_9 < 64);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_18 = threadIdx.x;
            long long int var_19 = blockIdx.x;
            long long int var_20 = (128 * var_19);
            long long int var_21 = (var_18 + var_20);
            float var_39[1];
            long long int var_40[1];
            var_40[0] = 0;
            while (method_58(var_40)) {
                long long int var_42 = var_40[0];
                long long int var_43 = (128 * var_42);
                long long int var_44 = (var_21 + var_43);
                long long int var_45 = (128 - var_43);
                char var_46 = (var_44 < 128);
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
                    char var_51 = (var_44 >= 0);
                    char var_52 = (var_51 == 0);
                    if (var_52) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_53 = (var_14 + var_44);
                    float var_54 = var_2[var_53];
                    if (var_52) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_55 = var_0[var_44];
                    if (var_52) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_56 = var_1[var_44];
                    float var_57 = (var_55 * var_54);
                    float var_58 = (var_57 + var_56);
                    var_39[var_42] = var_58;
                } else {
                }
                long long int var_59 = (var_42 + 1);
                var_40[0] = var_59;
            }
            long long int var_60 = var_40[0];
            float var_61 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_39);
            __shared__ float var_62[1];
            long long int var_63 = threadIdx.x;
            char var_64 = (var_63 == 0);
            if (var_64) {
                var_62[0] = var_61;
            } else {
            }
            __syncthreads();
            float var_65 = var_62[0];
            float var_68[1];
            long long int var_69[1];
            var_69[0] = 0;
            while (method_58(var_69)) {
                long long int var_71 = var_69[0];
                long long int var_72 = (128 * var_71);
                long long int var_73 = (var_21 + var_72);
                long long int var_74 = (128 - var_72);
                char var_75 = (var_73 < 128);
                if (var_75) {
                    char var_76 = (var_73 >= 0);
                    char var_77 = (var_76 == 0);
                    if (var_77) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_78 = (var_14 + var_73);
                    char var_79 = (var_71 >= 0);
                    char var_81;
                    if (var_79) {
                        var_81 = (var_71 < 1);
                    } else {
                        var_81 = 0;
                    }
                    char var_82 = (var_81 == 0);
                    if (var_82) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_83 = var_39[var_71];
                    float var_84 = (var_65 / 128);
                    float var_85 = (var_83 - var_84);
                    char var_87;
                    if (var_79) {
                        var_87 = (var_71 < 1);
                    } else {
                        var_87 = 0;
                    }
                    char var_88 = (var_87 == 0);
                    if (var_88) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_68[var_71] = var_85;
                } else {
                }
                long long int var_89 = (var_71 + 1);
                var_69[0] = var_89;
            }
            long long int var_90 = var_69[0];
            float var_92[1];
            long long int var_93[1];
            var_93[0] = 0;
            while (method_58(var_93)) {
                long long int var_95 = var_93[0];
                long long int var_96 = (128 * var_95);
                long long int var_97 = (var_21 + var_96);
                long long int var_98 = (128 - var_96);
                char var_99 = (var_97 < 128);
                if (var_99) {
                    char var_100 = (var_95 >= 0);
                    char var_102;
                    if (var_100) {
                        var_102 = (var_95 < 1);
                    } else {
                        var_102 = 0;
                    }
                    char var_103 = (var_102 == 0);
                    if (var_103) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_104 = var_68[var_95];
                    float var_105 = (var_104 * var_104);
                    char var_107;
                    if (var_100) {
                        var_107 = (var_95 < 1);
                    } else {
                        var_107 = 0;
                    }
                    char var_108 = (var_107 == 0);
                    if (var_108) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_92[var_95] = var_105;
                } else {
                }
                long long int var_109 = (var_95 + 1);
                var_93[0] = var_109;
            }
            long long int var_110 = var_93[0];
            float var_111 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_92);
            __shared__ float var_112[1];
            long long int var_113 = threadIdx.x;
            char var_114 = (var_113 == 0);
            if (var_114) {
                var_112[0] = var_111;
            } else {
            }
            __syncthreads();
            float var_115 = var_112[0];
            long long int var_116[1];
            var_116[0] = 0;
            while (method_58(var_116)) {
                long long int var_118 = var_116[0];
                long long int var_119 = (128 * var_118);
                long long int var_120 = (var_21 + var_119);
                long long int var_121 = (128 - var_119);
                char var_122 = (var_120 < 128);
                if (var_122) {
                    char var_123 = (var_120 >= 0);
                    char var_124 = (var_123 == 0);
                    if (var_124) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_125 = (var_14 + var_120);
                    char var_126 = (var_118 >= 0);
                    char var_128;
                    if (var_126) {
                        var_128 = (var_118 < 1);
                    } else {
                        var_128 = 0;
                    }
                    char var_129 = (var_128 == 0);
                    if (var_129) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_130 = var_68[var_118];
                    float var_131 = var_3[var_125];
                    float var_132 = (var_115 / 128);
                    float var_133 = (0.0025 + var_132);
                    float var_134 = sqrt(var_133);
                    float var_135 = (var_130 / var_134);
                    char var_136 = (var_135 > 0);
                    float var_137;
                    if (var_136) {
                        var_137 = var_135;
                    } else {
                        var_137 = 0;
                    }
                    var_3[var_125] = var_137;
                } else {
                }
                long long int var_138 = (var_118 + 1);
                var_116[0] = var_138;
            }
            long long int var_139 = var_116[0];
            long long int var_140 = (var_9 + 64);
            var_7[0] = var_140;
        }
        long long int var_141 = var_7[0];
    }
    __global__ void method_62(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.y;
        long long int var_6 = blockIdx.y;
        long long int var_7 = (var_5 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_57(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 64);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_15 = (var_10 * 128);
            char var_17;
            if (var_11) {
                var_17 = (var_10 < 64);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = threadIdx.x;
            long long int var_20 = blockIdx.x;
            long long int var_21 = (128 * var_20);
            long long int var_22 = (var_19 + var_21);
            Tuple0 var_42[1];
            long long int var_43[1];
            var_43[0] = 0;
            while (method_58(var_43)) {
                long long int var_45 = var_43[0];
                long long int var_46 = (128 * var_45);
                long long int var_47 = (var_22 + var_46);
                long long int var_48 = (128 - var_46);
                char var_49 = (var_47 < 128);
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
                    char var_54 = (var_47 >= 0);
                    char var_55 = (var_54 == 0);
                    if (var_55) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_56 = (var_15 + var_47);
                    float var_57 = var_2[var_56];
                    float var_58 = var_3[var_56];
                    if (var_55) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_59 = var_0[var_47];
                    if (var_55) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_60 = var_1[var_47];
                    EnvStack1 var_61 = make_EnvStack1(var_59, var_60, var_58);
                    float var_62 = (var_59 * var_58);
                    float var_63 = (var_62 + var_60);
                    var_42[var_45] = make_Tuple0(var_61, var_57, var_63);
                } else {
                }
                long long int var_64 = (var_45 + 1);
                var_43[0] = var_64;
            }
            long long int var_65 = var_43[0];
            float var_66[1];
            long long int var_67[1];
            var_67[0] = 0;
            while (method_58(var_67)) {
                long long int var_69 = var_67[0];
                long long int var_70 = (128 * var_69);
                long long int var_71 = (var_22 + var_70);
                long long int var_72 = (128 - var_70);
                char var_73 = (var_71 < 128);
                if (var_73) {
                    char var_74 = (var_69 >= 0);
                    char var_76;
                    if (var_74) {
                        var_76 = (var_69 < 1);
                    } else {
                        var_76 = 0;
                    }
                    char var_77 = (var_76 == 0);
                    if (var_77) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_78 = var_42[var_69];
                    EnvStack1 var_79 = var_78.mem_0;
                    float var_80 = var_78.mem_1;
                    float var_81 = var_78.mem_2;
                    char var_83;
                    if (var_74) {
                        var_83 = (var_69 < 1);
                    } else {
                        var_83 = 0;
                    }
                    char var_84 = (var_83 == 0);
                    if (var_84) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_66[var_69] = var_81;
                } else {
                }
                long long int var_85 = (var_69 + 1);
                var_67[0] = var_85;
            }
            long long int var_86 = var_67[0];
            float var_87 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_66);
            __shared__ float var_88[1];
            long long int var_89 = threadIdx.x;
            char var_90 = (var_89 == 0);
            if (var_90) {
                var_88[0] = var_87;
            } else {
            }
            __syncthreads();
            float var_91 = var_88[0];
            Tuple0 var_94[1];
            long long int var_95[1];
            var_95[0] = 0;
            while (method_58(var_95)) {
                long long int var_97 = var_95[0];
                long long int var_98 = (128 * var_97);
                long long int var_99 = (var_22 + var_98);
                long long int var_100 = (128 - var_98);
                char var_101 = (var_99 < 128);
                if (var_101) {
                    char var_102 = (var_99 >= 0);
                    char var_103 = (var_102 == 0);
                    if (var_103) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_104 = (var_15 + var_99);
                    char var_105 = (var_97 >= 0);
                    char var_107;
                    if (var_105) {
                        var_107 = (var_97 < 1);
                    } else {
                        var_107 = 0;
                    }
                    char var_108 = (var_107 == 0);
                    if (var_108) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_109 = var_42[var_97];
                    EnvStack1 var_110 = var_109.mem_0;
                    float var_111 = var_109.mem_1;
                    float var_112 = var_109.mem_2;
                    float var_113 = (var_91 / 128);
                    float var_114 = (var_112 - var_113);
                    char var_116;
                    if (var_105) {
                        var_116 = (var_97 < 1);
                    } else {
                        var_116 = 0;
                    }
                    char var_117 = (var_116 == 0);
                    if (var_117) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_94[var_97] = make_Tuple0(var_110, var_111, var_114);
                } else {
                }
                long long int var_118 = (var_97 + 1);
                var_95[0] = var_118;
            }
            long long int var_119 = var_95[0];
            float var_121[1];
            long long int var_122[1];
            var_122[0] = 0;
            while (method_58(var_122)) {
                long long int var_124 = var_122[0];
                long long int var_125 = (128 * var_124);
                long long int var_126 = (var_22 + var_125);
                long long int var_127 = (128 - var_125);
                char var_128 = (var_126 < 128);
                if (var_128) {
                    char var_129 = (var_124 >= 0);
                    char var_131;
                    if (var_129) {
                        var_131 = (var_124 < 1);
                    } else {
                        var_131 = 0;
                    }
                    char var_132 = (var_131 == 0);
                    if (var_132) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_133 = var_94[var_124];
                    EnvStack1 var_134 = var_133.mem_0;
                    float var_135 = var_133.mem_1;
                    float var_136 = var_133.mem_2;
                    float var_137 = (var_136 * var_136);
                    char var_139;
                    if (var_129) {
                        var_139 = (var_124 < 1);
                    } else {
                        var_139 = 0;
                    }
                    char var_140 = (var_139 == 0);
                    if (var_140) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_121[var_124] = var_137;
                } else {
                }
                long long int var_141 = (var_124 + 1);
                var_122[0] = var_141;
            }
            long long int var_142 = var_122[0];
            float var_143 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_121);
            __shared__ float var_144[1];
            long long int var_145 = threadIdx.x;
            char var_146 = (var_145 == 0);
            if (var_146) {
                var_144[0] = var_143;
            } else {
            }
            __syncthreads();
            float var_147 = var_144[0];
            Tuple2 var_153[1];
            long long int var_154[1];
            var_154[0] = 0;
            while (method_58(var_154)) {
                long long int var_156 = var_154[0];
                long long int var_157 = (128 * var_156);
                long long int var_158 = (var_22 + var_157);
                long long int var_159 = (128 - var_157);
                char var_160 = (var_158 < 128);
                if (var_160) {
                    char var_161 = (var_158 >= 0);
                    char var_162 = (var_161 == 0);
                    if (var_162) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_163 = (var_15 + var_158);
                    char var_164 = (var_156 >= 0);
                    char var_166;
                    if (var_164) {
                        var_166 = (var_156 < 1);
                    } else {
                        var_166 = 0;
                    }
                    char var_167 = (var_166 == 0);
                    if (var_167) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_168 = var_94[var_156];
                    EnvStack1 var_169 = var_168.mem_0;
                    float var_170 = var_168.mem_1;
                    float var_171 = var_168.mem_2;
                    char var_172 = (var_171 > 0);
                    float var_173;
                    if (var_172) {
                        var_173 = var_170;
                    } else {
                        var_173 = 0;
                    }
                    float var_174 = (var_147 / 128);
                    float var_175 = (0.0025 + var_174);
                    float var_176 = sqrt(var_175);
                    char var_178;
                    if (var_164) {
                        var_178 = (var_156 < 1);
                    } else {
                        var_178 = 0;
                    }
                    char var_179 = (var_178 == 0);
                    if (var_179) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_153[var_156] = make_Tuple2(var_169, var_173, var_171, var_176);
                } else {
                }
                long long int var_180 = (var_156 + 1);
                var_154[0] = var_180;
            }
            long long int var_181 = var_154[0];
            float var_186[1];
            long long int var_187[1];
            var_187[0] = 0;
            while (method_58(var_187)) {
                long long int var_189 = var_187[0];
                long long int var_190 = (128 * var_189);
                long long int var_191 = (var_22 + var_190);
                long long int var_192 = (128 - var_190);
                char var_193 = (var_191 < 128);
                if (var_193) {
                    char var_194 = (var_189 >= 0);
                    char var_196;
                    if (var_194) {
                        var_196 = (var_189 < 1);
                    } else {
                        var_196 = 0;
                    }
                    char var_197 = (var_196 == 0);
                    if (var_197) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple2 var_198 = var_153[var_189];
                    EnvStack1 var_199 = var_198.mem_0;
                    float var_200 = var_198.mem_1;
                    float var_201 = var_198.mem_2;
                    float var_202 = var_198.mem_3;
                    float var_203 = (-var_200);
                    float var_204 = (var_203 * var_201);
                    float var_205 = (var_202 * var_202);
                    float var_206 = (var_204 / var_205);
                    char var_208;
                    if (var_194) {
                        var_208 = (var_189 < 1);
                    } else {
                        var_208 = 0;
                    }
                    char var_209 = (var_208 == 0);
                    if (var_209) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_186[var_189] = var_206;
                } else {
                }
                long long int var_210 = (var_189 + 1);
                var_187[0] = var_210;
            }
            long long int var_211 = var_187[0];
            float var_212 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_186);
            __shared__ float var_213[1];
            long long int var_214 = threadIdx.x;
            char var_215 = (var_214 == 0);
            if (var_215) {
                var_213[0] = var_212;
            } else {
            }
            __syncthreads();
            float var_216 = var_213[0];
            Tuple3 var_222[1];
            long long int var_223[1];
            var_223[0] = 0;
            while (method_58(var_223)) {
                long long int var_225 = var_223[0];
                long long int var_226 = (128 * var_225);
                long long int var_227 = (var_22 + var_226);
                long long int var_228 = (128 - var_226);
                char var_229 = (var_227 < 128);
                if (var_229) {
                    char var_230 = (var_227 >= 0);
                    char var_231 = (var_230 == 0);
                    if (var_231) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_232 = (var_15 + var_227);
                    char var_233 = (var_225 >= 0);
                    char var_235;
                    if (var_233) {
                        var_235 = (var_225 < 1);
                    } else {
                        var_235 = 0;
                    }
                    char var_236 = (var_235 == 0);
                    if (var_236) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple2 var_237 = var_153[var_225];
                    EnvStack1 var_238 = var_237.mem_0;
                    float var_239 = var_237.mem_1;
                    float var_240 = var_237.mem_2;
                    float var_241 = var_237.mem_3;
                    float var_242 = (var_239 / var_241);
                    float var_243 = (var_216 * var_240);
                    float var_244 = (var_241 * 128);
                    float var_245 = (var_243 / var_244);
                    float var_246 = (var_242 + var_245);
                    char var_248;
                    if (var_233) {
                        var_248 = (var_225 < 1);
                    } else {
                        var_248 = 0;
                    }
                    char var_249 = (var_248 == 0);
                    if (var_249) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_222[var_225] = make_Tuple3(var_238, var_246);
                } else {
                }
                long long int var_250 = (var_225 + 1);
                var_223[0] = var_250;
            }
            long long int var_251 = var_223[0];
            float var_252[1];
            long long int var_253[1];
            var_253[0] = 0;
            while (method_58(var_253)) {
                long long int var_255 = var_253[0];
                long long int var_256 = (128 * var_255);
                long long int var_257 = (var_22 + var_256);
                long long int var_258 = (128 - var_256);
                char var_259 = (var_257 < 128);
                if (var_259) {
                    char var_260 = (var_255 >= 0);
                    char var_262;
                    if (var_260) {
                        var_262 = (var_255 < 1);
                    } else {
                        var_262 = 0;
                    }
                    char var_263 = (var_262 == 0);
                    if (var_263) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_264 = var_222[var_255];
                    EnvStack1 var_265 = var_264.mem_0;
                    float var_266 = var_264.mem_1;
                    char var_268;
                    if (var_260) {
                        var_268 = (var_255 < 1);
                    } else {
                        var_268 = 0;
                    }
                    char var_269 = (var_268 == 0);
                    if (var_269) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_252[var_255] = var_266;
                } else {
                }
                long long int var_270 = (var_255 + 1);
                var_253[0] = var_270;
            }
            long long int var_271 = var_253[0];
            float var_272 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_252);
            __shared__ float var_273[1];
            long long int var_274 = threadIdx.x;
            char var_275 = (var_274 == 0);
            if (var_275) {
                var_273[0] = var_272;
            } else {
            }
            __syncthreads();
            float var_276 = var_273[0];
            long long int var_277[1];
            var_277[0] = 0;
            while (method_58(var_277)) {
                long long int var_279 = var_277[0];
                long long int var_280 = (128 * var_279);
                long long int var_281 = (var_22 + var_280);
                long long int var_282 = (128 - var_280);
                char var_283 = (var_281 < 128);
                if (var_283) {
                    char var_284 = (var_281 >= 0);
                    char var_285 = (var_284 == 0);
                    if (var_285) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_286 = (var_15 + var_281);
                    char var_287 = (var_279 >= 0);
                    char var_289;
                    if (var_287) {
                        var_289 = (var_279 < 1);
                    } else {
                        var_289 = 0;
                    }
                    char var_290 = (var_289 == 0);
                    if (var_290) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple3 var_291 = var_222[var_279];
                    EnvStack1 var_292 = var_291.mem_0;
                    float var_293 = var_291.mem_1;
                    float var_294 = var_292.mem_0;
                    float var_295 = var_292.mem_1;
                    float var_296 = var_292.mem_2;
                    float var_297 = var_4[var_286];
                    float var_298 = (var_276 / 128);
                    float var_299 = (var_293 - var_298);
                    float var_300 = (var_299 * var_294);
                    float var_301 = (var_297 + var_300);
                    var_4[var_286] = var_301;
                } else {
                }
                long long int var_302 = (var_279 + 1);
                var_277[0] = var_302;
            }
            long long int var_303 = var_277[0];
            long long int var_304 = (var_10 + 64);
            var_8[0] = var_304;
        }
        long long int var_305 = var_8[0];
    }
    __global__ void method_85(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_57(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 64);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_12 = (var_7 * 128);
            char var_14;
            if (var_8) {
                var_14 = (var_7 < 64);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = threadIdx.x;
            long long int var_17 = blockIdx.x;
            long long int var_18 = (128 * var_17);
            long long int var_19 = (var_16 + var_18);
            float var_27[1];
            long long int var_28[1];
            var_28[0] = 0;
            while (method_58(var_28)) {
                long long int var_30 = var_28[0];
                long long int var_31 = (128 * var_30);
                long long int var_32 = (var_19 + var_31);
                long long int var_33 = (128 - var_31);
                char var_34 = (var_32 < 128);
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
                    char var_39 = (var_32 >= 0);
                    char var_40 = (var_39 == 0);
                    if (var_40) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_41 = (var_12 + var_32);
                    float var_42 = var_0[var_41];
                    var_27[var_30] = var_42;
                } else {
                }
                long long int var_43 = (var_30 + 1);
                var_28[0] = var_43;
            }
            long long int var_44 = var_28[0];
            FunPointer4 var_47 = method_86;
            float var_48 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_27, var_47);
            __shared__ float var_49[1];
            long long int var_50 = threadIdx.x;
            char var_51 = (var_50 == 0);
            if (var_51) {
                var_49[0] = var_48;
            } else {
            }
            __syncthreads();
            float var_52 = var_49[0];
            float var_55[1];
            long long int var_56[1];
            var_56[0] = 0;
            while (method_58(var_56)) {
                long long int var_58 = var_56[0];
                long long int var_59 = (128 * var_58);
                long long int var_60 = (var_19 + var_59);
                long long int var_61 = (128 - var_59);
                char var_62 = (var_60 < 128);
                if (var_62) {
                    char var_63 = (var_60 >= 0);
                    char var_64 = (var_63 == 0);
                    if (var_64) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_65 = (var_12 + var_60);
                    char var_66 = (var_58 >= 0);
                    char var_68;
                    if (var_66) {
                        var_68 = (var_58 < 1);
                    } else {
                        var_68 = 0;
                    }
                    char var_69 = (var_68 == 0);
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_70 = var_27[var_58];
                    float var_71 = (var_70 - var_52);
                    float var_72 = exp(var_71);
                    char var_74;
                    if (var_66) {
                        var_74 = (var_58 < 1);
                    } else {
                        var_74 = 0;
                    }
                    char var_75 = (var_74 == 0);
                    if (var_75) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_55[var_58] = var_72;
                } else {
                }
                long long int var_76 = (var_58 + 1);
                var_56[0] = var_76;
            }
            long long int var_77 = var_56[0];
            float var_78 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_55);
            __shared__ float var_79[1];
            long long int var_80 = threadIdx.x;
            char var_81 = (var_80 == 0);
            if (var_81) {
                var_79[0] = var_78;
            } else {
            }
            __syncthreads();
            float var_82 = var_79[0];
            long long int var_83[1];
            var_83[0] = 0;
            while (method_58(var_83)) {
                long long int var_85 = var_83[0];
                long long int var_86 = (128 * var_85);
                long long int var_87 = (var_19 + var_86);
                long long int var_88 = (128 - var_86);
                char var_89 = (var_87 < 128);
                if (var_89) {
                    char var_90 = (var_87 >= 0);
                    char var_91 = (var_90 == 0);
                    if (var_91) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_92 = (var_12 + var_87);
                    char var_93 = (var_85 >= 0);
                    char var_95;
                    if (var_93) {
                        var_95 = (var_85 < 1);
                    } else {
                        var_95 = 0;
                    }
                    char var_96 = (var_95 == 0);
                    if (var_96) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_97 = var_55[var_85];
                    float var_98 = var_1[var_92];
                    float var_99 = (var_97 / var_82);
                    var_1[var_92] = var_99;
                } else {
                }
                long long int var_100 = (var_85 + 1);
                var_83[0] = var_100;
            }
            long long int var_101 = var_83[0];
            long long int var_102 = (var_7 + 64);
            var_5[0] = var_102;
        }
        long long int var_103 = var_5[0];
    }
    __global__ void method_120(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_24(var_6)) {
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
            float var_18 = (0.01 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_124(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_125(var_6)) {
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
            float var_18 = (0.01 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_77(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_24(var_6)) {
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
            while (method_78(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 64);
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
            while (method_79(var_41, var_42)) {
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
                    while (method_80(var_44, var_69, var_70)) {
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
    __global__ void method_96(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_97(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 8192);
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
                var_15 = (var_9 < 8192);
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
            float var_21 = (var_20 / 64);
            float var_22 = (var_19 + var_21);
            var_2[var_9] = var_22;
            long long int var_23 = (var_9 + 8192);
            var_7[0] = var_23;
        }
        long long int var_24 = var_7[0];
    }
    __global__ void method_105(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6) {
        long long int var_7 = threadIdx.y;
        long long int var_8 = blockIdx.y;
        long long int var_9 = (var_7 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_57(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 64);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = (var_12 * 128);
            char var_19;
            if (var_13) {
                var_19 = (var_12 < 64);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_21 = threadIdx.x;
            long long int var_22 = blockIdx.x;
            long long int var_23 = (128 * var_22);
            long long int var_24 = (var_21 + var_23);
            float var_56[1];
            long long int var_57[1];
            var_57[0] = 0;
            while (method_58(var_57)) {
                long long int var_59 = var_57[0];
                long long int var_60 = (128 * var_59);
                long long int var_61 = (var_24 + var_60);
                long long int var_62 = (128 - var_60);
                char var_63 = (var_61 < 128);
                if (var_63) {
                    char var_64 = (var_59 >= 0);
                    char var_66;
                    if (var_64) {
                        var_66 = (var_59 < 1);
                    } else {
                        var_66 = 0;
                    }
                    char var_67 = (var_66 == 0);
                    if (var_67) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_68 = (var_61 >= 0);
                    char var_69 = (var_68 == 0);
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_70 = (var_17 + var_61);
                    float var_71 = var_4[var_70];
                    float var_72 = var_5[var_70];
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_73 = var_0[var_61];
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_74 = var_1[var_61];
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_75 = var_2[var_61];
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_76 = var_3[var_61];
                    float var_77 = (var_73 * var_71);
                    float var_78 = (var_77 * var_72);
                    float var_79 = (var_74 * var_72);
                    float var_80 = (var_78 + var_79);
                    float var_81 = (var_75 * var_71);
                    float var_82 = (var_80 + var_81);
                    float var_83 = (var_82 + var_76);
                    var_56[var_59] = var_83;
                } else {
                }
                long long int var_84 = (var_59 + 1);
                var_57[0] = var_84;
            }
            long long int var_85 = var_57[0];
            float var_86 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_56);
            __shared__ float var_87[1];
            long long int var_88 = threadIdx.x;
            char var_89 = (var_88 == 0);
            if (var_89) {
                var_87[0] = var_86;
            } else {
            }
            __syncthreads();
            float var_90 = var_87[0];
            float var_93[1];
            long long int var_94[1];
            var_94[0] = 0;
            while (method_58(var_94)) {
                long long int var_96 = var_94[0];
                long long int var_97 = (128 * var_96);
                long long int var_98 = (var_24 + var_97);
                long long int var_99 = (128 - var_97);
                char var_100 = (var_98 < 128);
                if (var_100) {
                    char var_101 = (var_98 >= 0);
                    char var_102 = (var_101 == 0);
                    if (var_102) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_103 = (var_17 + var_98);
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
                    float var_108 = var_56[var_96];
                    float var_109 = (var_90 / 128);
                    float var_110 = (var_108 - var_109);
                    char var_112;
                    if (var_104) {
                        var_112 = (var_96 < 1);
                    } else {
                        var_112 = 0;
                    }
                    char var_113 = (var_112 == 0);
                    if (var_113) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_93[var_96] = var_110;
                } else {
                }
                long long int var_114 = (var_96 + 1);
                var_94[0] = var_114;
            }
            long long int var_115 = var_94[0];
            float var_117[1];
            long long int var_118[1];
            var_118[0] = 0;
            while (method_58(var_118)) {
                long long int var_120 = var_118[0];
                long long int var_121 = (128 * var_120);
                long long int var_122 = (var_24 + var_121);
                long long int var_123 = (128 - var_121);
                char var_124 = (var_122 < 128);
                if (var_124) {
                    char var_125 = (var_120 >= 0);
                    char var_127;
                    if (var_125) {
                        var_127 = (var_120 < 1);
                    } else {
                        var_127 = 0;
                    }
                    char var_128 = (var_127 == 0);
                    if (var_128) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_129 = var_93[var_120];
                    float var_130 = (var_129 * var_129);
                    char var_132;
                    if (var_125) {
                        var_132 = (var_120 < 1);
                    } else {
                        var_132 = 0;
                    }
                    char var_133 = (var_132 == 0);
                    if (var_133) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_117[var_120] = var_130;
                } else {
                }
                long long int var_134 = (var_120 + 1);
                var_118[0] = var_134;
            }
            long long int var_135 = var_118[0];
            float var_136 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_117);
            __shared__ float var_137[1];
            long long int var_138 = threadIdx.x;
            char var_139 = (var_138 == 0);
            if (var_139) {
                var_137[0] = var_136;
            } else {
            }
            __syncthreads();
            float var_140 = var_137[0];
            long long int var_141[1];
            var_141[0] = 0;
            while (method_58(var_141)) {
                long long int var_143 = var_141[0];
                long long int var_144 = (128 * var_143);
                long long int var_145 = (var_24 + var_144);
                long long int var_146 = (128 - var_144);
                char var_147 = (var_145 < 128);
                if (var_147) {
                    char var_148 = (var_145 >= 0);
                    char var_149 = (var_148 == 0);
                    if (var_149) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_150 = (var_17 + var_145);
                    char var_151 = (var_143 >= 0);
                    char var_153;
                    if (var_151) {
                        var_153 = (var_143 < 1);
                    } else {
                        var_153 = 0;
                    }
                    char var_154 = (var_153 == 0);
                    if (var_154) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_155 = var_93[var_143];
                    float var_156 = var_6[var_150];
                    float var_157 = (var_140 / 128);
                    float var_158 = (0.0025 + var_157);
                    float var_159 = sqrt(var_158);
                    float var_160 = (var_155 / var_159);
                    char var_161 = (var_160 > 0);
                    float var_162;
                    if (var_161) {
                        var_162 = var_160;
                    } else {
                        var_162 = 0;
                    }
                    var_6[var_150] = var_162;
                } else {
                }
                long long int var_163 = (var_143 + 1);
                var_141[0] = var_163;
            }
            long long int var_164 = var_141[0];
            long long int var_165 = (var_12 + 64);
            var_10[0] = var_165;
        }
        long long int var_166 = var_10[0];
    }
    __global__ void method_109(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8) {
        long long int var_9 = threadIdx.y;
        long long int var_10 = blockIdx.y;
        long long int var_11 = (var_9 + var_10);
        long long int var_12[1];
        var_12[0] = var_11;
        while (method_57(var_12)) {
            long long int var_14 = var_12[0];
            char var_15 = (var_14 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_14 < 64);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = (var_14 * 128);
            char var_21;
            if (var_15) {
                var_21 = (var_14 < 64);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = threadIdx.x;
            long long int var_24 = blockIdx.x;
            long long int var_25 = (128 * var_24);
            long long int var_26 = (var_23 + var_25);
            Tuple5 var_60[1];
            long long int var_61[1];
            var_61[0] = 0;
            while (method_58(var_61)) {
                long long int var_63 = var_61[0];
                long long int var_64 = (128 * var_63);
                long long int var_65 = (var_26 + var_64);
                long long int var_66 = (128 - var_64);
                char var_67 = (var_65 < 128);
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
                    char var_72 = (var_65 >= 0);
                    char var_73 = (var_72 == 0);
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_74 = (var_19 + var_65);
                    float var_75 = var_4[var_74];
                    float var_76 = var_5[var_74];
                    float var_77 = var_6[var_74];
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_78 = var_0[var_65];
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_79 = var_1[var_65];
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_80 = var_2[var_65];
                    if (var_73) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_81 = var_3[var_65];
                    EnvStack6 var_82 = make_EnvStack6(var_78, var_79, var_80, var_81, var_76, var_77);
                    float var_83 = (var_78 * var_76);
                    float var_84 = (var_83 * var_77);
                    float var_85 = (var_79 * var_77);
                    float var_86 = (var_84 + var_85);
                    float var_87 = (var_80 * var_76);
                    float var_88 = (var_86 + var_87);
                    float var_89 = (var_88 + var_81);
                    var_60[var_63] = make_Tuple5(var_82, var_75, var_89);
                } else {
                }
                long long int var_90 = (var_63 + 1);
                var_61[0] = var_90;
            }
            long long int var_91 = var_61[0];
            float var_92[1];
            long long int var_93[1];
            var_93[0] = 0;
            while (method_58(var_93)) {
                long long int var_95 = var_93[0];
                long long int var_96 = (128 * var_95);
                long long int var_97 = (var_26 + var_96);
                long long int var_98 = (128 - var_96);
                char var_99 = (var_97 < 128);
                if (var_99) {
                    char var_100 = (var_95 >= 0);
                    char var_102;
                    if (var_100) {
                        var_102 = (var_95 < 1);
                    } else {
                        var_102 = 0;
                    }
                    char var_103 = (var_102 == 0);
                    if (var_103) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_104 = var_60[var_95];
                    EnvStack6 var_105 = var_104.mem_0;
                    float var_106 = var_104.mem_1;
                    float var_107 = var_104.mem_2;
                    char var_109;
                    if (var_100) {
                        var_109 = (var_95 < 1);
                    } else {
                        var_109 = 0;
                    }
                    char var_110 = (var_109 == 0);
                    if (var_110) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_92[var_95] = var_107;
                } else {
                }
                long long int var_111 = (var_95 + 1);
                var_93[0] = var_111;
            }
            long long int var_112 = var_93[0];
            float var_113 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_92);
            __shared__ float var_114[1];
            long long int var_115 = threadIdx.x;
            char var_116 = (var_115 == 0);
            if (var_116) {
                var_114[0] = var_113;
            } else {
            }
            __syncthreads();
            float var_117 = var_114[0];
            Tuple5 var_120[1];
            long long int var_121[1];
            var_121[0] = 0;
            while (method_58(var_121)) {
                long long int var_123 = var_121[0];
                long long int var_124 = (128 * var_123);
                long long int var_125 = (var_26 + var_124);
                long long int var_126 = (128 - var_124);
                char var_127 = (var_125 < 128);
                if (var_127) {
                    char var_128 = (var_125 >= 0);
                    char var_129 = (var_128 == 0);
                    if (var_129) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_130 = (var_19 + var_125);
                    char var_131 = (var_123 >= 0);
                    char var_133;
                    if (var_131) {
                        var_133 = (var_123 < 1);
                    } else {
                        var_133 = 0;
                    }
                    char var_134 = (var_133 == 0);
                    if (var_134) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_135 = var_60[var_123];
                    EnvStack6 var_136 = var_135.mem_0;
                    float var_137 = var_135.mem_1;
                    float var_138 = var_135.mem_2;
                    float var_139 = (var_117 / 128);
                    float var_140 = (var_138 - var_139);
                    char var_142;
                    if (var_131) {
                        var_142 = (var_123 < 1);
                    } else {
                        var_142 = 0;
                    }
                    char var_143 = (var_142 == 0);
                    if (var_143) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_120[var_123] = make_Tuple5(var_136, var_137, var_140);
                } else {
                }
                long long int var_144 = (var_123 + 1);
                var_121[0] = var_144;
            }
            long long int var_145 = var_121[0];
            float var_147[1];
            long long int var_148[1];
            var_148[0] = 0;
            while (method_58(var_148)) {
                long long int var_150 = var_148[0];
                long long int var_151 = (128 * var_150);
                long long int var_152 = (var_26 + var_151);
                long long int var_153 = (128 - var_151);
                char var_154 = (var_152 < 128);
                if (var_154) {
                    char var_155 = (var_150 >= 0);
                    char var_157;
                    if (var_155) {
                        var_157 = (var_150 < 1);
                    } else {
                        var_157 = 0;
                    }
                    char var_158 = (var_157 == 0);
                    if (var_158) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_159 = var_120[var_150];
                    EnvStack6 var_160 = var_159.mem_0;
                    float var_161 = var_159.mem_1;
                    float var_162 = var_159.mem_2;
                    float var_163 = (var_162 * var_162);
                    char var_165;
                    if (var_155) {
                        var_165 = (var_150 < 1);
                    } else {
                        var_165 = 0;
                    }
                    char var_166 = (var_165 == 0);
                    if (var_166) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_147[var_150] = var_163;
                } else {
                }
                long long int var_167 = (var_150 + 1);
                var_148[0] = var_167;
            }
            long long int var_168 = var_148[0];
            float var_169 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_147);
            __shared__ float var_170[1];
            long long int var_171 = threadIdx.x;
            char var_172 = (var_171 == 0);
            if (var_172) {
                var_170[0] = var_169;
            } else {
            }
            __syncthreads();
            float var_173 = var_170[0];
            Tuple7 var_179[1];
            long long int var_180[1];
            var_180[0] = 0;
            while (method_58(var_180)) {
                long long int var_182 = var_180[0];
                long long int var_183 = (128 * var_182);
                long long int var_184 = (var_26 + var_183);
                long long int var_185 = (128 - var_183);
                char var_186 = (var_184 < 128);
                if (var_186) {
                    char var_187 = (var_184 >= 0);
                    char var_188 = (var_187 == 0);
                    if (var_188) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_189 = (var_19 + var_184);
                    char var_190 = (var_182 >= 0);
                    char var_192;
                    if (var_190) {
                        var_192 = (var_182 < 1);
                    } else {
                        var_192 = 0;
                    }
                    char var_193 = (var_192 == 0);
                    if (var_193) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple5 var_194 = var_120[var_182];
                    EnvStack6 var_195 = var_194.mem_0;
                    float var_196 = var_194.mem_1;
                    float var_197 = var_194.mem_2;
                    char var_198 = (var_197 > 0);
                    float var_199;
                    if (var_198) {
                        var_199 = var_196;
                    } else {
                        var_199 = 0;
                    }
                    float var_200 = (var_173 / 128);
                    float var_201 = (0.0025 + var_200);
                    float var_202 = sqrt(var_201);
                    char var_204;
                    if (var_190) {
                        var_204 = (var_182 < 1);
                    } else {
                        var_204 = 0;
                    }
                    char var_205 = (var_204 == 0);
                    if (var_205) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_179[var_182] = make_Tuple7(var_195, var_199, var_197, var_202);
                } else {
                }
                long long int var_206 = (var_182 + 1);
                var_180[0] = var_206;
            }
            long long int var_207 = var_180[0];
            float var_212[1];
            long long int var_213[1];
            var_213[0] = 0;
            while (method_58(var_213)) {
                long long int var_215 = var_213[0];
                long long int var_216 = (128 * var_215);
                long long int var_217 = (var_26 + var_216);
                long long int var_218 = (128 - var_216);
                char var_219 = (var_217 < 128);
                if (var_219) {
                    char var_220 = (var_215 >= 0);
                    char var_222;
                    if (var_220) {
                        var_222 = (var_215 < 1);
                    } else {
                        var_222 = 0;
                    }
                    char var_223 = (var_222 == 0);
                    if (var_223) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple7 var_224 = var_179[var_215];
                    EnvStack6 var_225 = var_224.mem_0;
                    float var_226 = var_224.mem_1;
                    float var_227 = var_224.mem_2;
                    float var_228 = var_224.mem_3;
                    float var_229 = (-var_226);
                    float var_230 = (var_229 * var_227);
                    float var_231 = (var_228 * var_228);
                    float var_232 = (var_230 / var_231);
                    char var_234;
                    if (var_220) {
                        var_234 = (var_215 < 1);
                    } else {
                        var_234 = 0;
                    }
                    char var_235 = (var_234 == 0);
                    if (var_235) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_212[var_215] = var_232;
                } else {
                }
                long long int var_236 = (var_215 + 1);
                var_213[0] = var_236;
            }
            long long int var_237 = var_213[0];
            float var_238 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_212);
            __shared__ float var_239[1];
            long long int var_240 = threadIdx.x;
            char var_241 = (var_240 == 0);
            if (var_241) {
                var_239[0] = var_238;
            } else {
            }
            __syncthreads();
            float var_242 = var_239[0];
            Tuple8 var_248[1];
            long long int var_249[1];
            var_249[0] = 0;
            while (method_58(var_249)) {
                long long int var_251 = var_249[0];
                long long int var_252 = (128 * var_251);
                long long int var_253 = (var_26 + var_252);
                long long int var_254 = (128 - var_252);
                char var_255 = (var_253 < 128);
                if (var_255) {
                    char var_256 = (var_253 >= 0);
                    char var_257 = (var_256 == 0);
                    if (var_257) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_258 = (var_19 + var_253);
                    char var_259 = (var_251 >= 0);
                    char var_261;
                    if (var_259) {
                        var_261 = (var_251 < 1);
                    } else {
                        var_261 = 0;
                    }
                    char var_262 = (var_261 == 0);
                    if (var_262) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple7 var_263 = var_179[var_251];
                    EnvStack6 var_264 = var_263.mem_0;
                    float var_265 = var_263.mem_1;
                    float var_266 = var_263.mem_2;
                    float var_267 = var_263.mem_3;
                    float var_268 = (var_265 / var_267);
                    float var_269 = (var_242 * var_266);
                    float var_270 = (var_267 * 128);
                    float var_271 = (var_269 / var_270);
                    float var_272 = (var_268 + var_271);
                    char var_274;
                    if (var_259) {
                        var_274 = (var_251 < 1);
                    } else {
                        var_274 = 0;
                    }
                    char var_275 = (var_274 == 0);
                    if (var_275) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_248[var_251] = make_Tuple8(var_264, var_272);
                } else {
                }
                long long int var_276 = (var_251 + 1);
                var_249[0] = var_276;
            }
            long long int var_277 = var_249[0];
            float var_278[1];
            long long int var_279[1];
            var_279[0] = 0;
            while (method_58(var_279)) {
                long long int var_281 = var_279[0];
                long long int var_282 = (128 * var_281);
                long long int var_283 = (var_26 + var_282);
                long long int var_284 = (128 - var_282);
                char var_285 = (var_283 < 128);
                if (var_285) {
                    char var_286 = (var_281 >= 0);
                    char var_288;
                    if (var_286) {
                        var_288 = (var_281 < 1);
                    } else {
                        var_288 = 0;
                    }
                    char var_289 = (var_288 == 0);
                    if (var_289) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple8 var_290 = var_248[var_281];
                    EnvStack6 var_291 = var_290.mem_0;
                    float var_292 = var_290.mem_1;
                    char var_294;
                    if (var_286) {
                        var_294 = (var_281 < 1);
                    } else {
                        var_294 = 0;
                    }
                    char var_295 = (var_294 == 0);
                    if (var_295) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_278[var_281] = var_292;
                } else {
                }
                long long int var_296 = (var_281 + 1);
                var_279[0] = var_296;
            }
            long long int var_297 = var_279[0];
            float var_298 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_278);
            __shared__ float var_299[1];
            long long int var_300 = threadIdx.x;
            char var_301 = (var_300 == 0);
            if (var_301) {
                var_299[0] = var_298;
            } else {
            }
            __syncthreads();
            float var_302 = var_299[0];
            long long int var_303[1];
            var_303[0] = 0;
            while (method_58(var_303)) {
                long long int var_305 = var_303[0];
                long long int var_306 = (128 * var_305);
                long long int var_307 = (var_26 + var_306);
                long long int var_308 = (128 - var_306);
                char var_309 = (var_307 < 128);
                if (var_309) {
                    char var_310 = (var_307 >= 0);
                    char var_311 = (var_310 == 0);
                    if (var_311) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_312 = (var_19 + var_307);
                    char var_313 = (var_305 >= 0);
                    char var_315;
                    if (var_313) {
                        var_315 = (var_305 < 1);
                    } else {
                        var_315 = 0;
                    }
                    char var_316 = (var_315 == 0);
                    if (var_316) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple8 var_317 = var_248[var_305];
                    EnvStack6 var_318 = var_317.mem_0;
                    float var_319 = var_317.mem_1;
                    float var_320 = var_318.mem_0;
                    float var_321 = var_318.mem_1;
                    float var_322 = var_318.mem_2;
                    float var_323 = var_318.mem_3;
                    float var_324 = var_318.mem_4;
                    float var_325 = var_318.mem_5;
                    float var_326 = var_7[var_312];
                    float var_327 = var_8[var_312];
                    float var_328 = (var_302 / 128);
                    float var_329 = (var_319 - var_328);
                    float var_330 = (var_320 * var_325);
                    float var_331 = (var_330 + var_322);
                    float var_332 = (var_320 * var_324);
                    float var_333 = (var_332 + var_321);
                    float var_334 = (var_329 * var_331);
                    float var_335 = (var_329 * var_333);
                    float var_336 = (var_326 + var_334);
                    float var_337 = (var_327 + var_335);
                    var_7[var_312] = var_336;
                    var_8[var_312] = var_337;
                } else {
                }
                long long int var_338 = (var_305 + 1);
                var_303[0] = var_338;
            }
            long long int var_339 = var_303[0];
            long long int var_340 = (var_14 + 64);
            var_12[0] = var_340;
        }
        long long int var_341 = var_12[0];
    }
    __device__ char method_23(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 35692544);
    }
    __device__ char method_24(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_57(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_91(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8192);
    }
    __device__ char method_58(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ float method_86(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_125(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
    }
    __device__ char method_78(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 64);
    }
    __device__ char method_79(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_80(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_97(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8192);
    }
}
"""

type EnvHeap0 =
    {
    mem_0: ManagedCuda.CudaContext
    }
and Env1 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: ResizeArray<Env1>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: Env19
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack4 =
    struct
    val mem_0: ResizeArray<Env3>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap5 =
    {
    mem_0: EnvStack2
    mem_1: (uint64 ref)
    mem_2: uint64
    mem_3: EnvStack4
    }
and EnvHeap6 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: EnvHeap5
    }
and EnvHeap7 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaRand.CudaRandDevice
    mem_2: EnvHeap5
    }
and EnvHeap8 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvHeap5
    }
and Env9 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack10 =
    struct
    val mem_0: ResizeArray<Env9>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap11 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvHeap5
    }
and Env12 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack13 =
    struct
    val mem_0: ResizeArray<Env12>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap14 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvStack13
    mem_5: EnvHeap5
    }
and EnvHeap15 =
    {
    mem_0: ManagedCuda.CudaEvent
    mem_1: (bool ref)
    mem_2: ManagedCuda.CudaStream
    }
and Env16 =
    struct
    val mem_0: EnvHeap15
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap17 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvStack13
    mem_5: EnvHeap5
    mem_6: (int64 ref)
    mem_7: Env16
    }
and Env18 =
    struct
    val mem_0: Env9
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env19 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack20 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack21 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack22 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap23 =
    {
    mem_0: EnvStack22
    mem_1: (int64 ref)
    mem_2: Env19
    mem_3: EnvStack22
    mem_4: (int64 ref)
    mem_5: Env19
    mem_6: EnvStack22
    mem_7: (int64 ref)
    mem_8: Env19
    mem_9: EnvStack22
    mem_10: EnvStack22
    mem_11: EnvStack21
    mem_12: (int64 ref)
    mem_13: Env19
    mem_14: EnvStack21
    mem_15: (int64 ref)
    mem_16: Env19
    }
and Env24 =
    struct
    val mem_0: EnvHeap15
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack25 =
    struct
    val mem_0: EnvStack26
    val mem_1: (int64 ref)
    val mem_2: Env19
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack26 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack27 =
    struct
    val mem_0: EnvStack26
    val mem_1: (int64 ref)
    val mem_2: Env19
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack28 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    val mem_2: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvStack29 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env19
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: EnvHeap6), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap5) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack2) = var_2.mem_0
    let (var_6: EnvStack4) = var_2.mem_3
    let (var_7: ResizeArray<Env3>) = var_6.mem_0
    let (var_9: (Env3 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env3 -> (Env3 -> int32))) = method_3
    let (var_13: System.Comparison<Env3>) = System.Comparison<Env3>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env1>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack2), (var_6: EnvStack4), (var_15: int32), (var_16: uint64), (var_17: int32))
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
        var_14.Add((Env1(var_24, var_27)))
    else
        ()
and method_7((var_0: EnvHeap15), (var_1: EnvHeap14), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env12 =
    let (var_3: (int64 ref)) = (ref 0L)
    let (var_4: EnvStack13) = var_1.mem_4
    method_8((var_3: (int64 ref)), (var_0: EnvHeap15), (var_4: EnvStack13))
    (Env12(var_3, (Env16(var_0))))
and method_9((var_0: (uint8 [])), (var_1: (char [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < var_2)
    if var_4 then
        let (var_5: char) = var_1.[int32 var_3]
        let (var_6: int64) = (int64 var_5)
        let (var_7: bool) = (var_6 < 128L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "The inputs need to be in the [0,127] range.")
        else
            ()
        var_0.[int32 var_3] <- (uint8 var_6)
        let (var_9: int64) = (var_3 + 1L)
        method_9((var_0: (uint8 [])), (var_1: (char [])), (var_2: int64), (var_9: int64))
    else
        ()
and method_10((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (uint8 [])), (var_4: int64), (var_5: int64)): Env18 =
    let (var_6: int64) = (var_2 * var_5)
    let (var_7: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_3,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_8: int64) = var_7.AddrOfPinnedObject().ToInt64()
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (uint64 var_4)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: Env9) = method_11((var_6: int64), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env19) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_14.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_11)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_6)
    let (var_22: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_18, var_20, var_21)
    if var_22 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_22)
    var_7.Free()
    (Env18((Env9(var_13, var_14))))
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_18((var_0: uint64), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): EnvStack20 =
    let (var_20: Env9) = method_19((var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule))
    let (var_21: (int64 ref)) = var_20.mem_0
    let (var_22: Env19) = var_20.mem_1
    method_20((var_0: uint64), (var_21: (int64 ref)), (var_22: Env19), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule))
    EnvStack20((var_21: (int64 ref)), (var_22: Env19))
and method_26((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack21 =
    let (var_2: Env9) = method_27((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env19) = var_2.mem_1
    method_28((var_3: (int64 ref)), (var_4: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack21((var_3: (int64 ref)), (var_4: Env19))
and method_29((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack21 =
    let (var_4: Env9) = method_27((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env19) = var_4.mem_1
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: Env16) = var_2.mem_7
    let (var_9: EnvHeap15) = var_8.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_25((var_9: EnvHeap15))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_30((var_5: (int64 ref)), (var_6: Env19), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack21((var_5: (int64 ref)), (var_6: Env19))
and method_31((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 512L
    method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_32((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: Env19)): unit =
    let (var_4: float32) = 1.000000f
    method_33((var_4: float32), (var_2: (int64 ref)), (var_3: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
and method_36((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_4: Env9) = method_31((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env19) = var_4.mem_1
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: Env16) = var_2.mem_7
    let (var_9: EnvHeap15) = var_8.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_25((var_9: EnvHeap15))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_37((var_5: (int64 ref)), (var_6: Env19), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack22((var_5: (int64 ref)), (var_6: Env19))
and method_38((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: Env19)): unit =
    let (var_4: float32) = 0.500000f
    method_33((var_4: float32), (var_2: (int64 ref)), (var_3: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
and method_39((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_2: Env9) = method_31((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env19) = var_2.mem_1
    let (var_5: (int64 ref)) = var_0.mem_6
    let (var_6: Env16) = var_0.mem_7
    let (var_7: EnvHeap15) = var_6.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_25((var_7: EnvHeap15))
    let (var_9: ManagedCuda.CudaContext) = var_0.mem_0
    method_37((var_3: (int64 ref)), (var_4: Env19), (var_9: ManagedCuda.CudaContext), (var_8: ManagedCuda.BasicTypes.CUstream))
    EnvStack22((var_3: (int64 ref)), (var_4: Env19))
and method_40((var_0: EnvStack22), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): EnvStack22 =
    let (var_3: (int64 ref)) = var_0.mem_0
    let (var_4: Env19) = var_0.mem_1
    let (var_5: Env9) = method_31((var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule))
    let (var_6: (int64 ref)) = var_5.mem_0
    let (var_7: Env19) = var_5.mem_1
    let (var_8: (int64 ref)) = var_1.mem_6
    let (var_9: Env16) = var_1.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_12: ManagedCuda.CudaContext) = var_1.mem_0
    method_37((var_6: (int64 ref)), (var_7: Env19), (var_12: ManagedCuda.CudaContext), (var_11: ManagedCuda.BasicTypes.CUstream))
    EnvStack22((var_6: (int64 ref)), (var_7: Env19))
and method_41((var_0: EnvHeap15), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env12 =
    let (var_3: (int64 ref)) = (ref 0L)
    let (var_4: EnvStack13) = var_1.mem_4
    method_8((var_3: (int64 ref)), (var_0: EnvHeap15), (var_4: EnvStack13))
    (Env12(var_3, (Env16(var_0))))
and method_42((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack21 =
    let (var_2: Env9) = method_27((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env19) = var_2.mem_1
    method_43((var_3: (int64 ref)), (var_4: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack21((var_3: (int64 ref)), (var_4: Env19))
and method_44((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvHeap23), (var_9: EnvStack22), (var_10: EnvStack22), (var_11: EnvStack21), (var_12: (int64 ref)), (var_13: Env19), (var_14: EnvHeap17), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: int64)): unit =
    let (var_17: bool) = (var_16 < 5L)
    if var_17 then
        let (var_18: string) = System.String.Format("iteration {0}",var_16)
        let (var_19: string) = System.String.Format("Starting timing for: {0}",var_18)
        let (var_20: string) = System.String.Format("{0}",var_19)
        System.Console.WriteLine(var_20)
        let (var_21: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
        let (var_22: int64) = 0L
        let (var_23: float) = 0.000000
        let (var_24: int64) = 0L
        let (var_25: float) = method_45((var_0: (int64 ref)), (var_1: Env19), (var_14: EnvHeap17), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_22: int64), (var_23: float), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvHeap23), (var_9: EnvStack22), (var_10: EnvStack22), (var_11: EnvStack21), (var_12: (int64 ref)), (var_13: Env19), (var_24: int64))
        let (var_26: System.TimeSpan) = var_21.Elapsed
        let (var_27: string) = System.String.Format("The time was {0} for: {1}",var_26,var_18)
        let (var_28: string) = System.String.Format("{0}",var_27)
        System.Console.WriteLine(var_28)
        let (var_29: string) = System.String.Format("Training: {0}",var_25)
        let (var_30: string) = System.String.Format("{0}",var_29)
        System.Console.WriteLine(var_30)
        if (System.Double.IsNaN var_25) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_31: int64) = (var_16 + 1L)
            method_44((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: EnvHeap23), (var_9: EnvStack22), (var_10: EnvStack22), (var_11: EnvStack21), (var_12: (int64 ref)), (var_13: Env19), (var_14: EnvHeap17), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_31: int64))
    else
        ()
and method_131((var_0: EnvStack13)): unit =
    let (var_1: ResizeArray<Env12>) = var_0.mem_0
    let (var_3: (Env12 -> unit)) = method_132
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_115((var_0: EnvStack10)): unit =
    let (var_1: ResizeArray<Env9>) = var_0.mem_0
    let (var_3: (Env9 -> unit)) = method_116
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_2 ((var_0: Env3)): bool =
    let (var_1: Env19) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env3)): (Env3 -> int32) =
    let (var_1: Env19) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: EnvStack2), (var_1: EnvStack4), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env3>) = var_1.mem_0
        let (var_7: Env3) = var_6.[var_4]
        let (var_8: Env19) = var_7.mem_0
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
            let (var_21: ResizeArray<Env1>) = var_0.mem_0
            let (var_22: uint64) = (var_15 - var_19)
            var_21.Add((Env1(var_18, var_22)))
        else
            ()
        let (var_23: uint64) = (var_14 + var_9)
        let (var_24: int32) = (var_4 + 1)
        method_6((var_0: EnvStack2), (var_1: EnvStack4), (var_2: int32), (var_23: uint64), (var_24: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: EnvHeap15), (var_2: EnvStack13)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env12>) = var_2.mem_0
    var_5.Add((Env12(var_0, (Env16(var_1)))))
and method_11((var_0: int64), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    method_12((var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_0: int64))
and method_19((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 571080704L
    method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_20((var_0: uint64), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_5: (uint64 ref)) = var_2.mem_0
    let (var_6: uint64) = method_5((var_5: (uint64 ref)))
    method_21((var_0: uint64), (var_6: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_27((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 65536L
    method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_28((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    let (var_7: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: Env16) = var_2.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    var_7.SetStream(var_11)
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    var_7.GenerateNormal32(var_13, var_6, 0.000000f, 0.062500f)
and method_25((var_0: EnvHeap15)): ManagedCuda.BasicTypes.CUstream =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_4: ManagedCuda.CudaStream) = var_0.mem_2
    var_4.Stream
and method_30((var_0: (int64 ref)), (var_1: Env19), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64)): Env9 =
    let (var_3: uint64) = (uint64 var_2)
    let (var_4: uint64) = (var_3 + 256UL)
    let (var_5: uint64) = (var_4 - 1UL)
    let (var_6: uint64) = (var_5 &&& 18446744073709551360UL)
    let (var_7: Env19) = method_13((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_6: uint64))
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: (int64 ref)) = (ref 0L)
    let (var_10: EnvStack10) = var_0.mem_3
    method_17((var_9: (int64 ref)), (var_8: (uint64 ref)), (var_10: EnvStack10))
    (Env9(var_9, (Env19(var_8))))
and method_33((var_0: float32), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_5: (uint64 ref)) = var_2.mem_0
    let (var_6: uint64) = method_5((var_5: (uint64 ref)))
    method_34((var_0: float32), (var_6: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_37((var_0: (int64 ref)), (var_1: Env19), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_43((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    let (var_7: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_8: (int64 ref)) = var_2.mem_6
    let (var_9: Env16) = var_2.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    var_7.SetStream(var_11)
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    var_7.GenerateNormal32(var_13, var_6, 0.000000f, 0.088388f)
and method_45((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: int64), (var_5: float), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvHeap23), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19), (var_18: int64)): float =
    let (var_19: bool) = (var_18 < 272L)
    if var_19 then
        let (var_20: bool) = (var_18 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = (var_18 * 524288L)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_23: int64) = (8192L + var_22)
        method_16((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
        let (var_30: ResizeArray<Env9>) = ResizeArray<Env9>()
        let (var_31: EnvStack10) = EnvStack10((var_30: ResizeArray<Env9>))
        let (var_32: ManagedCuda.CudaContext) = var_2.mem_0
        let (var_33: ManagedCuda.CudaBlas.CudaBlas) = var_2.mem_1
        let (var_34: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
        let (var_35: EnvStack10) = var_2.mem_3
        let (var_36: EnvStack13) = var_2.mem_4
        let (var_37: EnvHeap5) = var_2.mem_5
        let (var_38: (int64 ref)) = var_2.mem_6
        let (var_39: Env16) = var_2.mem_7
        let (var_40: EnvHeap17) = ({mem_0 = (var_32: ManagedCuda.CudaContext); mem_1 = (var_33: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_34: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_31: EnvStack10); mem_4 = (var_36: EnvStack13); mem_5 = (var_37: EnvHeap5); mem_6 = (var_38: (int64 ref)); mem_7 = (var_39: Env16)} : EnvHeap17)
        // Executing the net...
        let (var_92: (int64 ref)) = var_40.mem_6
        let (var_93: Env16) = var_40.mem_7
        let (var_94: ManagedCuda.CudaContext) = var_40.mem_0
        let (var_95: ManagedCuda.CudaBlas.CudaBlas) = var_40.mem_1
        let (var_96: ManagedCuda.CudaRand.CudaRandDevice) = var_40.mem_2
        let (var_97: EnvStack10) = var_40.mem_3
        let (var_98: EnvStack13) = var_40.mem_4
        let (var_99: EnvHeap5) = var_40.mem_5
        let (var_100: EnvHeap17) = ({mem_0 = (var_94: ManagedCuda.CudaContext); mem_1 = (var_95: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_96: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_97: EnvStack10); mem_4 = (var_98: EnvStack13); mem_5 = (var_99: EnvHeap5); mem_6 = (var_10: (int64 ref)); mem_7 = (var_11: Env16)} : EnvHeap17)
        let (var_101: EnvHeap15) = var_11.mem_0
        let (var_102: Env24) = method_46((var_101: EnvHeap15))
        let (var_103: EnvHeap15) = var_102.mem_0
        let (var_104: ManagedCuda.CudaEvent) = var_103.mem_0
        let (var_105: EnvHeap15) = var_93.mem_0
        let (var_106: ManagedCuda.BasicTypes.CUstream) = method_25((var_105: EnvHeap15))
        var_104.Record(var_106)
        let (var_107: ManagedCuda.CudaStream) = var_103.mem_2
        var_107.WaitEvent var_104.Event
        let (var_108: EnvStack25) = method_47((var_100: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_0: (int64 ref)), (var_1: Env19), (var_22: int64), (var_10: (int64 ref)), (var_11: Env16), (var_92: (int64 ref)), (var_93: Env16), (var_12: EnvHeap23))
        let (var_109: EnvStack26) = var_108.mem_0
        let (var_110: (int64 ref)) = var_108.mem_1
        let (var_111: Env19) = var_108.mem_2
        let (var_112: (unit -> unit)) = var_108.mem_3
        let (var_113: EnvHeap17) = ({mem_0 = (var_94: ManagedCuda.CudaContext); mem_1 = (var_95: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_96: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_97: EnvStack10); mem_4 = (var_98: EnvStack13); mem_5 = (var_99: EnvHeap5); mem_6 = (var_8: (int64 ref)); mem_7 = (var_9: Env16)} : EnvHeap17)
        let (var_114: EnvHeap15) = var_9.mem_0
        let (var_115: Env24) = method_46((var_114: EnvHeap15))
        let (var_116: EnvHeap15) = var_115.mem_0
        let (var_117: ManagedCuda.CudaEvent) = var_116.mem_0
        let (var_118: ManagedCuda.BasicTypes.CUstream) = method_25((var_101: EnvHeap15))
        var_117.Record(var_118)
        let (var_119: ManagedCuda.CudaStream) = var_116.mem_2
        var_119.WaitEvent var_117.Event
        let (var_120: EnvStack27) = method_65((var_113: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_109: EnvStack26), (var_110: (int64 ref)), (var_111: Env19), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19))
        let (var_121: EnvStack26) = var_120.mem_0
        let (var_122: (int64 ref)) = var_120.mem_1
        let (var_123: Env19) = var_120.mem_2
        let (var_124: (unit -> unit)) = var_120.mem_3
        let (var_125: EnvHeap17) = ({mem_0 = (var_94: ManagedCuda.CudaContext); mem_1 = (var_95: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_96: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_97: EnvStack10); mem_4 = (var_98: EnvStack13); mem_5 = (var_99: EnvHeap5); mem_6 = (var_6: (int64 ref)); mem_7 = (var_7: Env16)} : EnvHeap17)
        let (var_126: EnvHeap15) = var_7.mem_0
        let (var_127: Env24) = method_46((var_126: EnvHeap15))
        let (var_128: EnvHeap15) = var_127.mem_0
        let (var_129: ManagedCuda.CudaEvent) = var_128.mem_0
        let (var_130: ManagedCuda.BasicTypes.CUstream) = method_25((var_114: EnvHeap15))
        var_129.Record(var_130)
        let (var_131: ManagedCuda.CudaStream) = var_128.mem_2
        var_131.WaitEvent var_129.Event
        let (var_132: Env24) = method_46((var_126: EnvHeap15))
        let (var_133: EnvHeap15) = var_132.mem_0
        let (var_134: ManagedCuda.CudaEvent) = var_133.mem_0
        let (var_135: ManagedCuda.BasicTypes.CUstream) = method_25((var_105: EnvHeap15))
        var_134.Record(var_135)
        let (var_136: ManagedCuda.CudaStream) = var_133.mem_2
        var_136.WaitEvent var_134.Event
        let (var_137: EnvStack28) = method_81((var_125: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_121: EnvStack26), (var_122: (int64 ref)), (var_123: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_23: int64), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_92: (int64 ref)), (var_93: Env16))
        let (var_138: (int64 ref)) = var_137.mem_0
        let (var_139: Env19) = var_137.mem_1
        let (var_140: (unit -> unit)) = var_137.mem_2
        let (var_141: (unit -> unit)) = method_98((var_112: (unit -> unit)), (var_124: (unit -> unit)), (var_140: (unit -> unit)))
        let (var_142: (unit -> float32)) = method_99((var_138: (int64 ref)), (var_139: Env19))
        let (var_181: int64) = 1L
        method_113((var_0: (int64 ref)), (var_1: Env19), (var_22: int64), (var_23: int64), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvHeap23), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19), (var_40: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: int64), (var_5: float), (var_18: int64), (var_2: EnvHeap17), (var_142: (unit -> float32)), (var_141: (unit -> unit)), (var_109: EnvStack26), (var_110: (int64 ref)), (var_111: Env19), (var_181: int64))
    else
        let (var_183: float) = (float var_4)
        (var_5 / var_183)
and method_132 ((var_0: Env12)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env16) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: EnvHeap15) = var_2.mem_0
        let (var_8: ManagedCuda.CudaStream) = var_7.mem_2
        var_8.Dispose()
        let (var_9: ManagedCuda.CudaEvent) = var_7.mem_0
        var_9.Dispose()
        let (var_10: (bool ref)) = var_7.mem_1
        var_10 := false
    else
        ()
and method_116 ((var_0: Env9)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env19) = var_0.mem_1
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
and method_4 ((var_1: (uint64 ref))) ((var_0: Env3)): int32 =
    let (var_2: Env19) = var_0.mem_0
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
and method_21((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_22((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_13((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: uint64)): Env19 =
    let (var_3: EnvHeap5) = var_0.mem_5
    let (var_4: (uint64 ref)) = var_3.mem_1
    let (var_5: uint64) = var_3.mem_2
    let (var_6: EnvStack4) = var_3.mem_3
    let (var_7: EnvStack2) = var_3.mem_0
    let (var_8: ResizeArray<Env1>) = var_7.mem_0
    let (var_9: int32) = var_8.get_Count()
    let (var_10: bool) = (var_9 > 0)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_12: Env1) = var_8.[0]
    let (var_13: uint64) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: bool) = (var_2 <= var_14)
    let (var_42: Env3) =
        if var_15 then
            let (var_16: uint64) = (var_13 + var_2)
            let (var_17: uint64) = (var_14 - var_2)
            var_8.[0] <- (Env1(var_16, var_17))
            let (var_18: (uint64 ref)) = (ref var_13)
            (Env3((Env19(var_18)), var_2))
        else
            let (var_20: (Env1 -> (Env1 -> int32))) = method_14
            let (var_21: System.Comparison<Env1>) = System.Comparison<Env1>(var_20)
            var_8.Sort(var_21)
            let (var_22: Env1) = var_8.[0]
            let (var_23: uint64) = var_22.mem_0
            let (var_24: uint64) = var_22.mem_1
            let (var_25: bool) = (var_2 <= var_24)
            if var_25 then
                let (var_26: uint64) = (var_23 + var_2)
                let (var_27: uint64) = (var_24 - var_2)
                var_8.[0] <- (Env1(var_26, var_27))
                let (var_28: (uint64 ref)) = (ref var_23)
                (Env3((Env19(var_28)), var_2))
            else
                method_16((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
                let (var_30: (Env1 -> (Env1 -> int32))) = method_14
                let (var_31: System.Comparison<Env1>) = System.Comparison<Env1>(var_30)
                var_8.Sort(var_31)
                let (var_32: Env1) = var_8.[0]
                let (var_33: uint64) = var_32.mem_0
                let (var_34: uint64) = var_32.mem_1
                let (var_35: bool) = (var_2 <= var_34)
                if var_35 then
                    let (var_36: uint64) = (var_33 + var_2)
                    let (var_37: uint64) = (var_34 - var_2)
                    var_8.[0] <- (Env1(var_36, var_37))
                    let (var_38: (uint64 ref)) = (ref var_33)
                    (Env3((Env19(var_38)), var_2))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_43: Env19) = var_42.mem_0
    let (var_44: uint64) = var_42.mem_1
    let (var_45: ResizeArray<Env3>) = var_6.mem_0
    var_45.Add((Env3(var_43, var_44)))
    var_43
and method_17((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack10)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env9>) = var_2.mem_0
    var_5.Add((Env9(var_0, (Env19(var_1)))))
and method_34((var_0: float32), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_35((var_0: float32), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_16((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap5) = var_0.mem_5
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack2) = var_2.mem_0
    let (var_6: EnvStack4) = var_2.mem_3
    let (var_7: ResizeArray<Env3>) = var_6.mem_0
    let (var_9: (Env3 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env3 -> (Env3 -> int32))) = method_3
    let (var_13: System.Comparison<Env3>) = System.Comparison<Env3>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env1>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack2), (var_6: EnvStack4), (var_15: int32), (var_16: uint64), (var_17: int32))
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
        var_14.Add((Env1(var_24, var_27)))
    else
        ()
and method_46((var_0: EnvHeap15)): Env24 =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    (Env24(var_0))
and method_47((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: Env19), (var_4: int64), (var_5: (int64 ref)), (var_6: Env16), (var_7: (int64 ref)), (var_8: Env16), (var_9: EnvHeap23)): EnvStack25 =
    let (var_10: EnvStack22) = var_9.mem_0
    let (var_11: (int64 ref)) = var_9.mem_1
    let (var_12: Env19) = var_9.mem_2
    let (var_13: EnvStack22) = var_9.mem_3
    let (var_14: (int64 ref)) = var_9.mem_4
    let (var_15: Env19) = var_9.mem_5
    let (var_16: EnvStack22) = var_9.mem_6
    let (var_17: (int64 ref)) = var_9.mem_7
    let (var_18: Env19) = var_9.mem_8
    let (var_19: EnvStack22) = var_9.mem_9
    let (var_20: EnvStack22) = var_9.mem_10
    let (var_21: EnvStack21) = var_9.mem_11
    let (var_22: (int64 ref)) = var_9.mem_12
    let (var_23: Env19) = var_9.mem_13
    let (var_24: EnvStack21) = var_9.mem_14
    let (var_25: (int64 ref)) = var_9.mem_15
    let (var_26: Env19) = var_9.mem_16
    let (var_27: EnvStack26) = method_48((var_2: (int64 ref)), (var_3: Env19), (var_4: int64), (var_22: (int64 ref)), (var_23: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_28: (int64 ref)) = var_27.mem_0
    let (var_29: Env19) = var_27.mem_1
    let (var_30: EnvStack26) = method_51((var_28: (int64 ref)), (var_29: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: Env19) = var_30.mem_1
    let (var_33: (int64 ref)) = var_16.mem_0
    let (var_34: Env19) = var_16.mem_1
    let (var_35: (int64 ref)) = var_20.mem_0
    let (var_36: Env19) = var_20.mem_1
    let (var_37: (int64 ref)) = var_19.mem_0
    let (var_38: Env19) = var_19.mem_1
    let (var_39: (uint64 ref)) = var_18.mem_0
    let (var_40: uint64) = method_5((var_39: (uint64 ref)))
    let (var_41: (uint64 ref)) = var_36.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: EnvStack26) = method_53((var_40: uint64), (var_42: uint64), (var_28: (int64 ref)), (var_29: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_44: (int64 ref)) = var_43.mem_0
    let (var_45: Env19) = var_43.mem_1
    let (var_46: EnvStack26) = method_51((var_44: (int64 ref)), (var_45: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_47: (unit -> unit)) = method_59((var_30: EnvStack26), (var_28: (int64 ref)), (var_29: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: int64), (var_21: EnvStack21), (var_22: (int64 ref)), (var_23: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvStack22), (var_17: (int64 ref)), (var_18: Env19), (var_19: EnvStack22), (var_20: EnvStack22), (var_46: EnvStack26), (var_44: (int64 ref)), (var_45: Env19), (var_5: (int64 ref)), (var_6: Env16), (var_7: (int64 ref)), (var_8: Env16))
    EnvStack25((var_46: EnvStack26), (var_44: (int64 ref)), (var_45: Env19), (var_47: (unit -> unit)))
and method_65((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_5: (int64 ref)), (var_6: Env16), (var_7: (int64 ref)), (var_8: Env16), (var_9: EnvStack22), (var_10: EnvStack22), (var_11: EnvStack21), (var_12: (int64 ref)), (var_13: Env19)): EnvStack27 =
    let (var_14: EnvStack26) = method_66((var_3: (int64 ref)), (var_4: Env19), (var_12: (int64 ref)), (var_13: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env19) = var_14.mem_1
    let (var_17: EnvStack26) = method_51((var_15: (int64 ref)), (var_16: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    method_68((var_10: EnvStack22), (var_15: (int64 ref)), (var_16: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_18: (unit -> unit)) = method_71((var_17: EnvStack26), (var_15: (int64 ref)), (var_16: Env19), (var_9: EnvStack22), (var_10: EnvStack22), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_11: EnvStack21), (var_12: (int64 ref)), (var_13: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env16), (var_7: (int64 ref)), (var_8: Env16))
    EnvStack27((var_17: EnvStack26), (var_15: (int64 ref)), (var_16: Env19), (var_18: (unit -> unit)))
and method_81((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: (int64 ref)), (var_13: Env16)): EnvStack28 =
    let (var_14: EnvStack26) = method_82((var_3: (int64 ref)), (var_4: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env19) = var_14.mem_1
    let (var_17: EnvStack29) = method_87((var_15: (int64 ref)), (var_16: Env19), (var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env19) = var_17.mem_1
    let (var_20: (unit -> unit)) = method_92((var_2: EnvStack26), (var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_15: (int64 ref)), (var_16: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: (int64 ref)), (var_13: Env16))
    EnvStack28((var_18: (int64 ref)), (var_19: Env19), (var_20: (unit -> unit)))
and method_98 ((var_0: (unit -> unit)), (var_1: (unit -> unit)), (var_2: (unit -> unit))) (): unit =
    var_2()
    var_1()
    var_0()
and method_99 ((var_0: (int64 ref)), (var_1: Env19)) (): float32 =
    let (var_2: int64) = 1L
    let (var_3: int64) = 0L
    let (var_4: (float32 [])) = method_100((var_2: int64), (var_0: (int64 ref)), (var_1: Env19), (var_3: int64))
    var_4.[int32 0L]
and method_113((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: int64), (var_19: float), (var_20: int64), (var_21: EnvHeap17), (var_22: (unit -> float32)), (var_23: (unit -> unit)), (var_24: EnvStack26), (var_25: (int64 ref)), (var_26: Env19), (var_27: int64)): float =
    let (var_28: bool) = (var_27 < 64L)
    if var_28 then
        let (var_29: bool) = (var_27 >= 0L)
        let (var_30: bool) = (var_29 = false)
        if var_30 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_31: int64) = (var_27 * 8192L)
        let (var_32: int64) = (var_2 + var_31)
        if var_30 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_33: int64) = (var_3 + var_31)
        let (var_34: (int64 ref)) = var_16.mem_6
        let (var_35: Env16) = var_16.mem_7
        let (var_36: ManagedCuda.CudaContext) = var_16.mem_0
        let (var_37: ManagedCuda.CudaBlas.CudaBlas) = var_16.mem_1
        let (var_38: ManagedCuda.CudaRand.CudaRandDevice) = var_16.mem_2
        let (var_39: EnvStack10) = var_16.mem_3
        let (var_40: EnvStack13) = var_16.mem_4
        let (var_41: EnvHeap5) = var_16.mem_5
        let (var_42: EnvHeap17) = ({mem_0 = (var_36: ManagedCuda.CudaContext); mem_1 = (var_37: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_38: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_39: EnvStack10); mem_4 = (var_40: EnvStack13); mem_5 = (var_41: EnvHeap5); mem_6 = (var_8: (int64 ref)); mem_7 = (var_9: Env16)} : EnvHeap17)
        let (var_43: EnvHeap15) = var_9.mem_0
        let (var_44: Env24) = method_46((var_43: EnvHeap15))
        let (var_45: EnvHeap15) = var_44.mem_0
        let (var_46: ManagedCuda.CudaEvent) = var_45.mem_0
        let (var_47: EnvHeap15) = var_35.mem_0
        let (var_48: ManagedCuda.BasicTypes.CUstream) = method_25((var_47: EnvHeap15))
        var_46.Record(var_48)
        let (var_49: ManagedCuda.CudaStream) = var_45.mem_2
        var_49.WaitEvent var_46.Event
        let (var_50: EnvStack25) = method_101((var_42: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_24: EnvStack26), (var_25: (int64 ref)), (var_26: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_32: int64), (var_8: (int64 ref)), (var_9: Env16), (var_34: (int64 ref)), (var_35: Env16), (var_10: EnvHeap23))
        let (var_51: EnvStack26) = var_50.mem_0
        let (var_52: (int64 ref)) = var_50.mem_1
        let (var_53: Env19) = var_50.mem_2
        let (var_54: (unit -> unit)) = var_50.mem_3
        let (var_55: EnvHeap17) = ({mem_0 = (var_36: ManagedCuda.CudaContext); mem_1 = (var_37: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_38: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_39: EnvStack10); mem_4 = (var_40: EnvStack13); mem_5 = (var_41: EnvHeap5); mem_6 = (var_6: (int64 ref)); mem_7 = (var_7: Env16)} : EnvHeap17)
        let (var_56: EnvHeap15) = var_7.mem_0
        let (var_57: Env24) = method_46((var_56: EnvHeap15))
        let (var_58: EnvHeap15) = var_57.mem_0
        let (var_59: ManagedCuda.CudaEvent) = var_58.mem_0
        let (var_60: ManagedCuda.BasicTypes.CUstream) = method_25((var_43: EnvHeap15))
        var_59.Record(var_60)
        let (var_61: ManagedCuda.CudaStream) = var_58.mem_2
        var_61.WaitEvent var_59.Event
        let (var_62: EnvStack27) = method_65((var_55: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_51: EnvStack26), (var_52: (int64 ref)), (var_53: Env19), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19))
        let (var_63: EnvStack26) = var_62.mem_0
        let (var_64: (int64 ref)) = var_62.mem_1
        let (var_65: Env19) = var_62.mem_2
        let (var_66: (unit -> unit)) = var_62.mem_3
        let (var_67: EnvHeap17) = ({mem_0 = (var_36: ManagedCuda.CudaContext); mem_1 = (var_37: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_38: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_39: EnvStack10); mem_4 = (var_40: EnvStack13); mem_5 = (var_41: EnvHeap5); mem_6 = (var_4: (int64 ref)); mem_7 = (var_5: Env16)} : EnvHeap17)
        let (var_68: EnvHeap15) = var_5.mem_0
        let (var_69: Env24) = method_46((var_68: EnvHeap15))
        let (var_70: EnvHeap15) = var_69.mem_0
        let (var_71: ManagedCuda.CudaEvent) = var_70.mem_0
        let (var_72: ManagedCuda.BasicTypes.CUstream) = method_25((var_56: EnvHeap15))
        var_71.Record(var_72)
        let (var_73: ManagedCuda.CudaStream) = var_70.mem_2
        var_73.WaitEvent var_71.Event
        let (var_74: Env24) = method_46((var_68: EnvHeap15))
        let (var_75: EnvHeap15) = var_74.mem_0
        let (var_76: ManagedCuda.CudaEvent) = var_75.mem_0
        let (var_77: ManagedCuda.BasicTypes.CUstream) = method_25((var_47: EnvHeap15))
        var_76.Record(var_77)
        let (var_78: ManagedCuda.CudaStream) = var_75.mem_2
        var_78.WaitEvent var_76.Event
        let (var_79: EnvStack28) = method_81((var_67: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_63: EnvStack26), (var_64: (int64 ref)), (var_65: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_33: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_34: (int64 ref)), (var_35: Env16))
        let (var_80: (int64 ref)) = var_79.mem_0
        let (var_81: Env19) = var_79.mem_1
        let (var_82: (unit -> unit)) = var_79.mem_2
        let (var_83: (unit -> unit)) = method_111((var_23: (unit -> unit)), (var_54: (unit -> unit)), (var_66: (unit -> unit)), (var_82: (unit -> unit)))
        let (var_84: (unit -> float32)) = method_112((var_80: (int64 ref)), (var_81: Env19), (var_22: (unit -> float32)))
        let (var_85: int64) = (var_27 + 1L)
        method_113((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: int64), (var_19: float), (var_20: int64), (var_21: EnvHeap17), (var_84: (unit -> float32)), (var_83: (unit -> unit)), (var_51: EnvStack26), (var_52: (int64 ref)), (var_53: Env19), (var_85: int64))
    else
        let (var_87: float32) = var_22()
        let (var_88: float) = (float var_87)
        let (var_89: float) = (var_19 + var_88)
        let (var_90: int64) = (var_18 + 1L)
        let (var_97: ResizeArray<Env9>) = ResizeArray<Env9>()
        let (var_98: EnvStack10) = EnvStack10((var_97: ResizeArray<Env9>))
        let (var_99: ManagedCuda.CudaContext) = var_16.mem_0
        let (var_100: ManagedCuda.CudaBlas.CudaBlas) = var_16.mem_1
        let (var_101: ManagedCuda.CudaRand.CudaRandDevice) = var_16.mem_2
        let (var_102: EnvStack10) = var_16.mem_3
        let (var_103: EnvStack13) = var_16.mem_4
        let (var_104: EnvHeap5) = var_16.mem_5
        let (var_105: (int64 ref)) = var_16.mem_6
        let (var_106: Env16) = var_16.mem_7
        let (var_107: EnvHeap17) = ({mem_0 = (var_99: ManagedCuda.CudaContext); mem_1 = (var_100: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_101: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_98: EnvStack10); mem_4 = (var_103: EnvStack13); mem_5 = (var_104: EnvHeap5); mem_6 = (var_105: (int64 ref)); mem_7 = (var_106: Env16)} : EnvHeap17)
        let (var_108: EnvStack10) = var_107.mem_3
        method_114((var_25: (int64 ref)), (var_26: Env19), (var_108: EnvStack10))
        if (System.Double.IsNaN var_89) then
            method_115((var_102: EnvStack10))
            // Done with the net...
            method_115((var_108: EnvStack10))
            let (var_109: float) = (float var_90)
            (var_89 / var_109)
        else
            var_23()
            method_117((var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule))
            method_115((var_102: EnvStack10))
            // Executing the next loop...
            let (var_111: int64) = (var_20 + 1L)
            method_126((var_0: (int64 ref)), (var_1: Env19), (var_21: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_90: int64), (var_89: float), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_107: EnvHeap17), (var_25: (int64 ref)), (var_26: Env19), (var_111: int64))
and method_14 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_15((var_2: uint64))
and method_48((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: (int64 ref)), (var_4: Env19), (var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_7: Env9) = method_49((var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule))
    let (var_8: (int64 ref)) = var_7.mem_0
    let (var_9: Env19) = var_7.mem_1
    method_50((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: (int64 ref)), (var_4: Env19), (var_8: (int64 ref)), (var_9: Env19), (var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule))
    EnvStack26((var_8: (int64 ref)), (var_9: Env19))
and method_51((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_4: Env9) = method_49((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env19) = var_4.mem_1
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: Env16) = var_2.mem_7
    let (var_9: EnvHeap15) = var_8.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_25((var_9: EnvHeap15))
    let (var_11: ManagedCuda.CudaContext) = var_2.mem_0
    method_52((var_5: (int64 ref)), (var_6: Env19), (var_11: ManagedCuda.CudaContext), (var_10: ManagedCuda.BasicTypes.CUstream))
    EnvStack26((var_5: (int64 ref)), (var_6: Env19))
and method_53((var_0: uint64), (var_1: uint64), (var_2: (int64 ref)), (var_3: Env19), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_28: Env9) = method_49((var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_29: (int64 ref)) = var_28.mem_0
    let (var_30: Env19) = var_28.mem_1
    method_54((var_0: uint64), (var_1: uint64), (var_2: (int64 ref)), (var_3: Env19), (var_29: (int64 ref)), (var_30: Env19), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack26((var_29: (int64 ref)), (var_30: Env19))
and method_59 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvStack22), (var_12: (int64 ref)), (var_13: Env19), (var_14: EnvStack22), (var_15: EnvStack22), (var_16: EnvStack26), (var_17: (int64 ref)), (var_18: Env19), (var_19: (int64 ref)), (var_20: Env16), (var_21: (int64 ref)), (var_22: Env16)) (): unit =
    let (var_23: (int64 ref)) = var_0.mem_0
    let (var_24: Env19) = var_0.mem_1
    let (var_25: (int64 ref)) = var_11.mem_0
    let (var_26: Env19) = var_11.mem_1
    let (var_27: (int64 ref)) = var_15.mem_0
    let (var_28: Env19) = var_15.mem_1
    let (var_29: (int64 ref)) = var_14.mem_0
    let (var_30: Env19) = var_14.mem_1
    let (var_31: (uint64 ref)) = var_13.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    let (var_33: (uint64 ref)) = var_28.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    let (var_35: (uint64 ref)) = var_26.mem_0
    let (var_36: uint64) = method_5((var_35: (uint64 ref)))
    let (var_37: (uint64 ref)) = var_30.mem_0
    let (var_38: uint64) = method_5((var_37: (uint64 ref)))
    method_60((var_32: uint64), (var_34: uint64), (var_16: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_0: EnvStack26), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_63((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    let (var_39: EnvHeap15) = var_22.mem_0
    let (var_40: Env24) = method_46((var_39: EnvHeap15))
    let (var_41: EnvHeap15) = var_40.mem_0
    let (var_42: ManagedCuda.CudaEvent) = var_41.mem_0
    let (var_43: EnvHeap15) = var_20.mem_0
    let (var_44: ManagedCuda.BasicTypes.CUstream) = method_25((var_43: EnvHeap15))
    var_42.Record(var_44)
    let (var_45: ManagedCuda.CudaStream) = var_41.mem_2
    var_45.WaitEvent var_42.Event
and method_66((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_6: Env9) = method_49((var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env19) = var_6.mem_1
    method_67((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_7: (int64 ref)), (var_8: Env19), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack26((var_7: (int64 ref)), (var_8: Env19))
and method_68((var_0: EnvStack22), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_5: (int64 ref)) = var_0.mem_0
    let (var_6: Env19) = var_0.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: uint64) = method_5((var_7: (uint64 ref)))
    let (var_9: (uint64 ref)) = var_2.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    let (var_11: uint64) = method_5((var_9: (uint64 ref)))
    method_69((var_8: uint64), (var_10: uint64), (var_11: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_71 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvStack22), (var_4: EnvStack22), (var_5: EnvStack26), (var_6: (int64 ref)), (var_7: Env19), (var_8: EnvStack21), (var_9: (int64 ref)), (var_10: Env19), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env16), (var_15: (int64 ref)), (var_16: Env16)) (): unit =
    method_72((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvStack22), (var_4: EnvStack22), (var_5: EnvStack26), (var_6: (int64 ref)), (var_7: Env19), (var_8: EnvStack21), (var_9: (int64 ref)), (var_10: Env19), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule))
    let (var_17: EnvHeap15) = var_16.mem_0
    let (var_18: Env24) = method_46((var_17: EnvHeap15))
    let (var_19: EnvHeap15) = var_18.mem_0
    let (var_20: ManagedCuda.CudaEvent) = var_19.mem_0
    let (var_21: EnvHeap15) = var_14.mem_0
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_25((var_21: EnvHeap15))
    var_20.Record(var_22)
    let (var_23: ManagedCuda.CudaStream) = var_19.mem_2
    var_23.WaitEvent var_20.Event
and method_82((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_7: Env9) = method_49((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_8: (int64 ref)) = var_7.mem_0
    let (var_9: Env19) = var_7.mem_1
    method_83((var_0: (int64 ref)), (var_1: Env19), (var_8: (int64 ref)), (var_9: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack26((var_8: (int64 ref)), (var_9: Env19))
and method_87((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: int64), (var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule)): EnvStack29 =
    let (var_7: (uint64 ref)) = var_1.mem_0
    let (var_8: uint64) = method_5((var_7: (uint64 ref)))
    let (var_9: (uint64 ref)) = var_3.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    let (var_11: int64) = (var_4 * 4L)
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: uint64) = (var_10 + var_12)
    let (var_18: Env9) = method_88((var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule))
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: Env19) = var_18.mem_1
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    method_89((var_8: uint64), (var_13: uint64), (var_22: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_5: EnvHeap17))
    EnvStack29((var_19: (int64 ref)), (var_20: Env19))
and method_92 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: int64), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: (int64 ref)), (var_13: Env16)) (): unit =
    method_93((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: int64), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule))
    let (var_14: EnvHeap15) = var_11.mem_0
    let (var_15: Env24) = method_46((var_14: EnvHeap15))
    let (var_16: EnvHeap15) = var_15.mem_0
    let (var_17: ManagedCuda.CudaEvent) = var_16.mem_0
    let (var_18: EnvHeap15) = var_9.mem_0
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_25((var_18: EnvHeap15))
    var_17.Record(var_19)
    let (var_20: ManagedCuda.CudaStream) = var_16.mem_2
    var_20.WaitEvent var_17.Event
    let (var_21: EnvHeap15) = var_13.mem_0
    let (var_22: Env24) = method_46((var_21: EnvHeap15))
    let (var_23: EnvHeap15) = var_22.mem_0
    let (var_24: ManagedCuda.CudaEvent) = var_23.mem_0
    let (var_25: ManagedCuda.BasicTypes.CUstream) = method_25((var_18: EnvHeap15))
    var_24.Record(var_25)
    let (var_26: ManagedCuda.CudaStream) = var_23.mem_2
    var_26.WaitEvent var_24.Event
and method_100((var_0: int64), (var_1: (int64 ref)), (var_2: Env19), (var_3: int64)): (float32 []) =
    let (var_4: (uint64 ref)) = var_2.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: int64) = (var_3 * 4L)
    let (var_7: uint64) = (uint64 var_6)
    let (var_8: uint64) = (var_5 + var_7)
    let (var_9: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_0))
    let (var_10: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_9,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_11: int64) = var_10.AddrOfPinnedObject().ToInt64()
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: int64) = (var_0 * 4L)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_8)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_19: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_15, var_17, var_18)
    if var_19 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_19)
    var_10.Free()
    var_9
and method_101((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvHeap23)): EnvStack25 =
    let (var_13: EnvStack22) = var_12.mem_0
    let (var_14: (int64 ref)) = var_12.mem_1
    let (var_15: Env19) = var_12.mem_2
    let (var_16: EnvStack22) = var_12.mem_3
    let (var_17: (int64 ref)) = var_12.mem_4
    let (var_18: Env19) = var_12.mem_5
    let (var_19: EnvStack22) = var_12.mem_6
    let (var_20: (int64 ref)) = var_12.mem_7
    let (var_21: Env19) = var_12.mem_8
    let (var_22: EnvStack22) = var_12.mem_9
    let (var_23: EnvStack22) = var_12.mem_10
    let (var_24: EnvStack21) = var_12.mem_11
    let (var_25: (int64 ref)) = var_12.mem_12
    let (var_26: Env19) = var_12.mem_13
    let (var_27: EnvStack21) = var_12.mem_14
    let (var_28: (int64 ref)) = var_12.mem_15
    let (var_29: Env19) = var_12.mem_16
    let (var_30: EnvStack26) = method_48((var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_25: (int64 ref)), (var_26: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: Env19) = var_30.mem_1
    let (var_33: EnvStack26) = method_51((var_31: (int64 ref)), (var_32: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_34: EnvStack26) = method_66((var_3: (int64 ref)), (var_4: Env19), (var_28: (int64 ref)), (var_29: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_35: (int64 ref)) = var_34.mem_0
    let (var_36: Env19) = var_34.mem_1
    let (var_37: EnvStack26) = method_51((var_35: (int64 ref)), (var_36: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_38: (int64 ref)) = var_33.mem_0
    let (var_39: Env19) = var_33.mem_1
    let (var_40: (int64 ref)) = var_37.mem_0
    let (var_41: Env19) = var_37.mem_1
    let (var_42: (int64 ref)) = var_13.mem_0
    let (var_43: Env19) = var_13.mem_1
    let (var_44: (int64 ref)) = var_16.mem_0
    let (var_45: Env19) = var_16.mem_1
    let (var_46: (int64 ref)) = var_19.mem_0
    let (var_47: Env19) = var_19.mem_1
    let (var_48: (int64 ref)) = var_23.mem_0
    let (var_49: Env19) = var_23.mem_1
    let (var_50: (int64 ref)) = var_22.mem_0
    let (var_51: Env19) = var_22.mem_1
    let (var_52: (uint64 ref)) = var_15.mem_0
    let (var_53: uint64) = method_5((var_52: (uint64 ref)))
    let (var_54: (uint64 ref)) = var_18.mem_0
    let (var_55: uint64) = method_5((var_54: (uint64 ref)))
    let (var_56: (uint64 ref)) = var_21.mem_0
    let (var_57: uint64) = method_5((var_56: (uint64 ref)))
    let (var_58: (uint64 ref)) = var_49.mem_0
    let (var_59: uint64) = method_5((var_58: (uint64 ref)))
    let (var_60: EnvStack26) = method_102((var_53: uint64), (var_55: uint64), (var_57: uint64), (var_59: uint64), (var_31: (int64 ref)), (var_32: Env19), (var_35: (int64 ref)), (var_36: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_61: (int64 ref)) = var_60.mem_0
    let (var_62: Env19) = var_60.mem_1
    let (var_63: EnvStack26) = method_51((var_61: (int64 ref)), (var_62: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_64: (unit -> unit)) = method_106((var_33: EnvStack26), (var_31: (int64 ref)), (var_32: Env19), (var_5: (int64 ref)), (var_6: Env19), (var_7: int64), (var_24: EnvStack21), (var_25: (int64 ref)), (var_26: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_37: EnvStack26), (var_35: (int64 ref)), (var_36: Env19), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_27: EnvStack21), (var_28: (int64 ref)), (var_29: Env19), (var_13: EnvStack22), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvStack22), (var_17: (int64 ref)), (var_18: Env19), (var_19: EnvStack22), (var_20: (int64 ref)), (var_21: Env19), (var_22: EnvStack22), (var_23: EnvStack22), (var_63: EnvStack26), (var_61: (int64 ref)), (var_62: Env19), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16))
    EnvStack25((var_63: EnvStack26), (var_61: (int64 ref)), (var_62: Env19), (var_64: (unit -> unit)))
and method_111 ((var_0: (unit -> unit)), (var_1: (unit -> unit)), (var_2: (unit -> unit)), (var_3: (unit -> unit))) (): unit =
    var_3()
    var_2()
    var_1()
    var_0()
and method_112 ((var_0: (int64 ref)), (var_1: Env19), (var_2: (unit -> float32))) (): float32 =
    let (var_3: float32) = var_2()
    let (var_4: int64) = 1L
    let (var_5: int64) = 0L
    let (var_6: (float32 [])) = method_100((var_4: int64), (var_0: (int64 ref)), (var_1: Env19), (var_5: int64))
    let (var_7: float32) = var_6.[int32 0L]
    (var_3 + var_7)
and method_114((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvStack10)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env9>) = var_2.mem_0
    var_5.Add((Env9(var_0, var_1)))
and method_117((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: (int64 ref)), (var_5: Env16), (var_6: EnvHeap23), (var_7: EnvStack22), (var_8: EnvStack22), (var_9: EnvStack21), (var_10: (int64 ref)), (var_11: Env19), (var_12: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_14: ManagedCuda.CudaContext) = var_12.mem_0
    let (var_15: ManagedCuda.CudaBlas.CudaBlas) = var_12.mem_1
    let (var_16: ManagedCuda.CudaRand.CudaRandDevice) = var_12.mem_2
    let (var_17: EnvStack10) = var_12.mem_3
    let (var_18: EnvStack13) = var_12.mem_4
    let (var_19: EnvHeap5) = var_12.mem_5
    let (var_20: (int64 ref)) = var_12.mem_6
    let (var_21: Env16) = var_12.mem_7
    let (var_22: EnvHeap17) = ({mem_0 = (var_14: ManagedCuda.CudaContext); mem_1 = (var_15: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_16: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_17: EnvStack10); mem_4 = (var_18: EnvStack13); mem_5 = (var_19: EnvHeap5); mem_6 = (var_4: (int64 ref)); mem_7 = (var_5: Env16)} : EnvHeap17)
    let (var_23: EnvStack22) = var_6.mem_0
    let (var_24: (int64 ref)) = var_6.mem_1
    let (var_25: Env19) = var_6.mem_2
    let (var_26: EnvStack22) = var_6.mem_3
    let (var_27: (int64 ref)) = var_6.mem_4
    let (var_28: Env19) = var_6.mem_5
    let (var_29: EnvStack22) = var_6.mem_6
    let (var_30: (int64 ref)) = var_6.mem_7
    let (var_31: Env19) = var_6.mem_8
    let (var_32: EnvStack22) = var_6.mem_9
    let (var_33: EnvStack22) = var_6.mem_10
    let (var_34: EnvStack21) = var_6.mem_11
    let (var_35: (int64 ref)) = var_6.mem_12
    let (var_36: Env19) = var_6.mem_13
    let (var_37: EnvStack21) = var_6.mem_14
    let (var_38: (int64 ref)) = var_6.mem_15
    let (var_39: Env19) = var_6.mem_16
    method_118((var_24: (int64 ref)), (var_25: Env19), (var_23: EnvStack22), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    method_118((var_27: (int64 ref)), (var_28: Env19), (var_26: EnvStack22), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    method_118((var_30: (int64 ref)), (var_31: Env19), (var_29: EnvStack22), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    let (var_40: (int64 ref)) = var_33.mem_0
    let (var_41: Env19) = var_33.mem_1
    method_121((var_33: EnvStack22), (var_32: EnvStack22), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    method_122((var_35: (int64 ref)), (var_36: Env19), (var_34: EnvStack21), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    method_122((var_38: (int64 ref)), (var_39: Env19), (var_37: EnvStack21), (var_22: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    let (var_42: EnvHeap17) = ({mem_0 = (var_14: ManagedCuda.CudaContext); mem_1 = (var_15: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_16: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_17: EnvStack10); mem_4 = (var_18: EnvStack13); mem_5 = (var_19: EnvHeap5); mem_6 = (var_2: (int64 ref)); mem_7 = (var_3: Env16)} : EnvHeap17)
    let (var_43: (int64 ref)) = var_8.mem_0
    let (var_44: Env19) = var_8.mem_1
    method_121((var_8: EnvStack22), (var_7: EnvStack22), (var_42: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
    method_122((var_10: (int64 ref)), (var_11: Env19), (var_9: EnvStack21), (var_42: EnvHeap17), (var_13: ManagedCuda.BasicTypes.CUmodule))
and method_126((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: int64), (var_5: float), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvHeap23), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19), (var_18: EnvHeap17), (var_19: (int64 ref)), (var_20: Env19), (var_21: int64)): float =
    let (var_22: bool) = (var_21 < 272L)
    if var_22 then
        let (var_23: bool) = (var_21 >= 0L)
        let (var_24: bool) = (var_23 = false)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (var_21 * 524288L)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_26: int64) = (8192L + var_25)
        method_16((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
        let (var_33: ResizeArray<Env9>) = ResizeArray<Env9>()
        let (var_34: EnvStack10) = EnvStack10((var_33: ResizeArray<Env9>))
        let (var_35: ManagedCuda.CudaContext) = var_2.mem_0
        let (var_36: ManagedCuda.CudaBlas.CudaBlas) = var_2.mem_1
        let (var_37: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
        let (var_38: EnvStack10) = var_2.mem_3
        let (var_39: EnvStack13) = var_2.mem_4
        let (var_40: EnvHeap5) = var_2.mem_5
        let (var_41: (int64 ref)) = var_2.mem_6
        let (var_42: Env16) = var_2.mem_7
        let (var_43: EnvHeap17) = ({mem_0 = (var_35: ManagedCuda.CudaContext); mem_1 = (var_36: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_37: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_34: EnvStack10); mem_4 = (var_39: EnvStack13); mem_5 = (var_40: EnvHeap5); mem_6 = (var_41: (int64 ref)); mem_7 = (var_42: Env16)} : EnvHeap17)
        // Executing the net...
        let (var_95: (int64 ref)) = var_43.mem_6
        let (var_96: Env16) = var_43.mem_7
        let (var_97: ManagedCuda.CudaContext) = var_43.mem_0
        let (var_98: ManagedCuda.CudaBlas.CudaBlas) = var_43.mem_1
        let (var_99: ManagedCuda.CudaRand.CudaRandDevice) = var_43.mem_2
        let (var_100: EnvStack10) = var_43.mem_3
        let (var_101: EnvStack13) = var_43.mem_4
        let (var_102: EnvHeap5) = var_43.mem_5
        let (var_103: EnvHeap17) = ({mem_0 = (var_97: ManagedCuda.CudaContext); mem_1 = (var_98: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_99: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_100: EnvStack10); mem_4 = (var_101: EnvStack13); mem_5 = (var_102: EnvHeap5); mem_6 = (var_10: (int64 ref)); mem_7 = (var_11: Env16)} : EnvHeap17)
        let (var_104: EnvHeap15) = var_11.mem_0
        let (var_105: Env24) = method_46((var_104: EnvHeap15))
        let (var_106: EnvHeap15) = var_105.mem_0
        let (var_107: ManagedCuda.CudaEvent) = var_106.mem_0
        let (var_108: EnvHeap15) = var_96.mem_0
        let (var_109: ManagedCuda.BasicTypes.CUstream) = method_25((var_108: EnvHeap15))
        var_107.Record(var_109)
        let (var_110: ManagedCuda.CudaStream) = var_106.mem_2
        var_110.WaitEvent var_107.Event
        let (var_111: EnvStack25) = method_127((var_103: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_25: int64), (var_10: (int64 ref)), (var_11: Env16), (var_95: (int64 ref)), (var_96: Env16), (var_12: EnvHeap23))
        let (var_112: EnvStack26) = var_111.mem_0
        let (var_113: (int64 ref)) = var_111.mem_1
        let (var_114: Env19) = var_111.mem_2
        let (var_115: (unit -> unit)) = var_111.mem_3
        let (var_116: EnvHeap17) = ({mem_0 = (var_97: ManagedCuda.CudaContext); mem_1 = (var_98: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_99: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_100: EnvStack10); mem_4 = (var_101: EnvStack13); mem_5 = (var_102: EnvHeap5); mem_6 = (var_8: (int64 ref)); mem_7 = (var_9: Env16)} : EnvHeap17)
        let (var_117: EnvHeap15) = var_9.mem_0
        let (var_118: Env24) = method_46((var_117: EnvHeap15))
        let (var_119: EnvHeap15) = var_118.mem_0
        let (var_120: ManagedCuda.CudaEvent) = var_119.mem_0
        let (var_121: ManagedCuda.BasicTypes.CUstream) = method_25((var_104: EnvHeap15))
        var_120.Record(var_121)
        let (var_122: ManagedCuda.CudaStream) = var_119.mem_2
        var_122.WaitEvent var_120.Event
        let (var_123: EnvStack27) = method_65((var_116: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_112: EnvStack26), (var_113: (int64 ref)), (var_114: Env19), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19))
        let (var_124: EnvStack26) = var_123.mem_0
        let (var_125: (int64 ref)) = var_123.mem_1
        let (var_126: Env19) = var_123.mem_2
        let (var_127: (unit -> unit)) = var_123.mem_3
        let (var_128: EnvHeap17) = ({mem_0 = (var_97: ManagedCuda.CudaContext); mem_1 = (var_98: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_99: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_100: EnvStack10); mem_4 = (var_101: EnvStack13); mem_5 = (var_102: EnvHeap5); mem_6 = (var_6: (int64 ref)); mem_7 = (var_7: Env16)} : EnvHeap17)
        let (var_129: EnvHeap15) = var_7.mem_0
        let (var_130: Env24) = method_46((var_129: EnvHeap15))
        let (var_131: EnvHeap15) = var_130.mem_0
        let (var_132: ManagedCuda.CudaEvent) = var_131.mem_0
        let (var_133: ManagedCuda.BasicTypes.CUstream) = method_25((var_117: EnvHeap15))
        var_132.Record(var_133)
        let (var_134: ManagedCuda.CudaStream) = var_131.mem_2
        var_134.WaitEvent var_132.Event
        let (var_135: Env24) = method_46((var_129: EnvHeap15))
        let (var_136: EnvHeap15) = var_135.mem_0
        let (var_137: ManagedCuda.CudaEvent) = var_136.mem_0
        let (var_138: ManagedCuda.BasicTypes.CUstream) = method_25((var_108: EnvHeap15))
        var_137.Record(var_138)
        let (var_139: ManagedCuda.CudaStream) = var_136.mem_2
        var_139.WaitEvent var_137.Event
        let (var_140: EnvStack28) = method_81((var_128: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_124: EnvStack26), (var_125: (int64 ref)), (var_126: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_26: int64), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_95: (int64 ref)), (var_96: Env16))
        let (var_141: (int64 ref)) = var_140.mem_0
        let (var_142: Env19) = var_140.mem_1
        let (var_143: (unit -> unit)) = var_140.mem_2
        let (var_144: (unit -> unit)) = method_98((var_115: (unit -> unit)), (var_127: (unit -> unit)), (var_143: (unit -> unit)))
        let (var_145: (unit -> float32)) = method_99((var_141: (int64 ref)), (var_142: Env19))
        let (var_184: int64) = 1L
        method_130((var_0: (int64 ref)), (var_1: Env19), (var_25: int64), (var_26: int64), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: (int64 ref)), (var_11: Env16), (var_12: EnvHeap23), (var_13: EnvStack22), (var_14: EnvStack22), (var_15: EnvStack21), (var_16: (int64 ref)), (var_17: Env19), (var_43: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: int64), (var_5: float), (var_21: int64), (var_2: EnvHeap17), (var_18: EnvHeap17), (var_145: (unit -> float32)), (var_144: (unit -> unit)), (var_112: EnvStack26), (var_113: (int64 ref)), (var_114: Env19), (var_184: int64))
    else
        let (var_186: EnvStack10) = var_18.mem_3
        method_115((var_186: EnvStack10))
        let (var_187: float) = (float var_4)
        (var_5 / var_187)
and method_15 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
and method_49((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 32768L
    method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_50((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: (int64 ref)), (var_4: Env19), (var_5: (int64 ref)), (var_6: Env19), (var_7: EnvHeap17), (var_8: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlas) = var_7.mem_1
    let (var_10: (int64 ref)) = var_7.mem_6
    let (var_11: Env16) = var_7.mem_7
    let (var_12: ManagedCuda.CudaBlas.CudaBlasHandle) = var_9.get_CublasHandle()
    let (var_13: EnvHeap15) = var_11.mem_0
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_25((var_13: EnvHeap15))
    var_9.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_4.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (uint64 ref)) = var_1.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_2 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (float32 ref)) = (ref 0.000000f)
    let (var_30: (uint64 ref)) = var_6.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_31)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_12, var_15, var_16, 128, 64, 128, var_17, var_21, 128, var_28, 128, var_29, var_33, 128)
    if var_34 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_34)
and method_52((var_0: (int64 ref)), (var_1: Env19), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_54((var_0: uint64), (var_1: uint64), (var_2: (int64 ref)), (var_3: Env19), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: (uint64 ref)) = var_3.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: (uint64 ref)) = var_5.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    method_55((var_0: uint64), (var_1: uint64), (var_9: uint64), (var_11: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap17))
and method_60((var_0: uint64), (var_1: uint64), (var_2: EnvStack26), (var_3: (int64 ref)), (var_4: Env19), (var_5: EnvStack26), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: (int64 ref)) = var_2.mem_0
    let (var_9: Env19) = var_2.mem_1
    let (var_10: (int64 ref)) = var_5.mem_0
    let (var_11: Env19) = var_5.mem_1
    let (var_12: (uint64 ref)) = var_9.mem_0
    let (var_13: uint64) = method_5((var_12: (uint64 ref)))
    let (var_14: (uint64 ref)) = var_4.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_11.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_61((var_0: uint64), (var_1: uint64), (var_13: uint64), (var_15: uint64), (var_17: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap17))
and method_63((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_64((var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_0: EnvStack26), (var_6: EnvStack21), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
and method_67((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: Env16) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: EnvHeap15) = var_10.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_25((var_12: EnvHeap15))
    var_8.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_3.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_1.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 0.000000f)
    let (var_26: (uint64 ref)) = var_5.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 128, 64, 128, var_16, var_20, 128, var_24, 128, var_25, var_29, 128)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_69((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17)): unit =
    // Cuda join point
    // method_70((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_70", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: Env16) = var_4.mem_7
    let (var_11: EnvHeap15) = var_10.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_25((var_11: EnvHeap15))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_12, var_14)
and method_72((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvStack22), (var_4: EnvStack22), (var_5: EnvStack26), (var_6: (int64 ref)), (var_7: Env19), (var_8: EnvStack21), (var_9: (int64 ref)), (var_10: Env19), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_73((var_0: EnvStack26), (var_9: (int64 ref)), (var_10: Env19), (var_5: EnvStack26), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule))
    method_74((var_6: (int64 ref)), (var_7: Env19), (var_0: EnvStack26), (var_8: EnvStack21), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule))
    let (var_13: (int64 ref)) = var_3.mem_0
    let (var_14: Env19) = var_3.mem_1
    method_75((var_0: EnvStack26), (var_3: EnvStack22), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule))
and method_83((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: (uint64 ref)) = var_1.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: (uint64 ref)) = var_3.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    method_84((var_7: uint64), (var_9: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17))
and method_88((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 4L
    method_12((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_89((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17)): unit =
    // Cuda join point
    // method_90((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_90", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: Env16) = var_4.mem_7
    let (var_11: EnvHeap15) = var_10.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_25((var_11: EnvHeap15))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_12, var_14)
and method_93((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: int64), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_94((var_4: (int64 ref)), (var_5: Env19), (var_1: (int64 ref)), (var_2: Env19), (var_3: int64), (var_0: EnvStack26), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule))
and method_102((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: (int64 ref)), (var_5: Env19), (var_6: (int64 ref)), (var_7: Env19), (var_8: EnvHeap17), (var_9: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_45: Env9) = method_49((var_8: EnvHeap17), (var_9: ManagedCuda.BasicTypes.CUmodule))
    let (var_46: (int64 ref)) = var_45.mem_0
    let (var_47: Env19) = var_45.mem_1
    method_103((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: (int64 ref)), (var_5: Env19), (var_6: (int64 ref)), (var_7: Env19), (var_46: (int64 ref)), (var_47: Env19), (var_8: EnvHeap17), (var_9: ManagedCuda.BasicTypes.CUmodule))
    EnvStack26((var_46: (int64 ref)), (var_47: Env19))
and method_106 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvStack26), (var_12: (int64 ref)), (var_13: Env19), (var_14: EnvStack26), (var_15: (int64 ref)), (var_16: Env19), (var_17: EnvStack21), (var_18: (int64 ref)), (var_19: Env19), (var_20: EnvStack22), (var_21: (int64 ref)), (var_22: Env19), (var_23: EnvStack22), (var_24: (int64 ref)), (var_25: Env19), (var_26: EnvStack22), (var_27: (int64 ref)), (var_28: Env19), (var_29: EnvStack22), (var_30: EnvStack22), (var_31: EnvStack26), (var_32: (int64 ref)), (var_33: Env19), (var_34: (int64 ref)), (var_35: Env16), (var_36: (int64 ref)), (var_37: Env16)) (): unit =
    let (var_38: (int64 ref)) = var_0.mem_0
    let (var_39: Env19) = var_0.mem_1
    let (var_40: (int64 ref)) = var_11.mem_0
    let (var_41: Env19) = var_11.mem_1
    let (var_42: (int64 ref)) = var_20.mem_0
    let (var_43: Env19) = var_20.mem_1
    let (var_44: (int64 ref)) = var_23.mem_0
    let (var_45: Env19) = var_23.mem_1
    let (var_46: (int64 ref)) = var_26.mem_0
    let (var_47: Env19) = var_26.mem_1
    let (var_48: (int64 ref)) = var_30.mem_0
    let (var_49: Env19) = var_30.mem_1
    let (var_50: (int64 ref)) = var_29.mem_0
    let (var_51: Env19) = var_29.mem_1
    let (var_52: (uint64 ref)) = var_22.mem_0
    let (var_53: uint64) = method_5((var_52: (uint64 ref)))
    let (var_54: (uint64 ref)) = var_25.mem_0
    let (var_55: uint64) = method_5((var_54: (uint64 ref)))
    let (var_56: (uint64 ref)) = var_28.mem_0
    let (var_57: uint64) = method_5((var_56: (uint64 ref)))
    let (var_58: (uint64 ref)) = var_49.mem_0
    let (var_59: uint64) = method_5((var_58: (uint64 ref)))
    let (var_60: (uint64 ref)) = var_43.mem_0
    let (var_61: uint64) = method_5((var_60: (uint64 ref)))
    let (var_62: (uint64 ref)) = var_45.mem_0
    let (var_63: uint64) = method_5((var_62: (uint64 ref)))
    let (var_64: (uint64 ref)) = var_47.mem_0
    let (var_65: uint64) = method_5((var_64: (uint64 ref)))
    let (var_66: (uint64 ref)) = var_51.mem_0
    let (var_67: uint64) = method_5((var_66: (uint64 ref)))
    method_107((var_53: uint64), (var_55: uint64), (var_57: uint64), (var_59: uint64), (var_31: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_12: (int64 ref)), (var_13: Env19), (var_0: EnvStack26), (var_11: EnvStack26), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_110((var_11: EnvStack26), (var_12: (int64 ref)), (var_13: Env19), (var_14: EnvStack26), (var_15: (int64 ref)), (var_16: Env19), (var_17: EnvStack21), (var_18: (int64 ref)), (var_19: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_63((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    let (var_68: EnvHeap15) = var_37.mem_0
    let (var_69: Env24) = method_46((var_68: EnvHeap15))
    let (var_70: EnvHeap15) = var_69.mem_0
    let (var_71: ManagedCuda.CudaEvent) = var_70.mem_0
    let (var_72: EnvHeap15) = var_35.mem_0
    let (var_73: ManagedCuda.BasicTypes.CUstream) = method_25((var_72: EnvHeap15))
    var_71.Record(var_73)
    let (var_74: ManagedCuda.CudaStream) = var_70.mem_2
    var_74.WaitEvent var_71.Event
and method_118((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvStack22), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_5: (int64 ref)) = var_2.mem_0
    let (var_6: Env19) = var_2.mem_1
    let (var_7: (uint64 ref)) = var_1.mem_0
    let (var_8: uint64) = method_5((var_7: (uint64 ref)))
    let (var_9: (uint64 ref)) = var_6.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    method_119((var_8: uint64), (var_10: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_121((var_0: EnvStack22), (var_1: EnvStack22), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: (int64 ref)) = var_0.mem_0
    let (var_5: Env19) = var_0.mem_1
    let (var_6: (int64 ref)) = var_1.mem_0
    let (var_7: Env19) = var_1.mem_1
    let (var_8: (uint64 ref)) = var_5.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: (uint64 ref)) = var_7.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    method_119((var_9: uint64), (var_11: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap17))
and method_122((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvStack21), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_5: (int64 ref)) = var_2.mem_0
    let (var_6: Env19) = var_2.mem_1
    let (var_7: (uint64 ref)) = var_1.mem_0
    let (var_8: uint64) = method_5((var_7: (uint64 ref)))
    let (var_9: (uint64 ref)) = var_6.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    method_123((var_8: uint64), (var_10: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_127((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: Env19), (var_4: (int64 ref)), (var_5: Env19), (var_6: int64), (var_7: (int64 ref)), (var_8: Env16), (var_9: (int64 ref)), (var_10: Env16), (var_11: EnvHeap23)): EnvStack25 =
    let (var_12: EnvStack22) = var_11.mem_0
    let (var_13: (int64 ref)) = var_11.mem_1
    let (var_14: Env19) = var_11.mem_2
    let (var_15: EnvStack22) = var_11.mem_3
    let (var_16: (int64 ref)) = var_11.mem_4
    let (var_17: Env19) = var_11.mem_5
    let (var_18: EnvStack22) = var_11.mem_6
    let (var_19: (int64 ref)) = var_11.mem_7
    let (var_20: Env19) = var_11.mem_8
    let (var_21: EnvStack22) = var_11.mem_9
    let (var_22: EnvStack22) = var_11.mem_10
    let (var_23: EnvStack21) = var_11.mem_11
    let (var_24: (int64 ref)) = var_11.mem_12
    let (var_25: Env19) = var_11.mem_13
    let (var_26: EnvStack21) = var_11.mem_14
    let (var_27: (int64 ref)) = var_11.mem_15
    let (var_28: Env19) = var_11.mem_16
    let (var_29: EnvStack26) = method_48((var_4: (int64 ref)), (var_5: Env19), (var_6: int64), (var_24: (int64 ref)), (var_25: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_30: (int64 ref)) = var_29.mem_0
    let (var_31: Env19) = var_29.mem_1
    let (var_32: EnvStack26) = method_51((var_30: (int64 ref)), (var_31: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_33: EnvStack26) = method_66((var_2: (int64 ref)), (var_3: Env19), (var_27: (int64 ref)), (var_28: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_34: (int64 ref)) = var_33.mem_0
    let (var_35: Env19) = var_33.mem_1
    let (var_36: EnvStack26) = method_51((var_34: (int64 ref)), (var_35: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_37: (int64 ref)) = var_32.mem_0
    let (var_38: Env19) = var_32.mem_1
    let (var_39: (int64 ref)) = var_36.mem_0
    let (var_40: Env19) = var_36.mem_1
    let (var_41: (int64 ref)) = var_12.mem_0
    let (var_42: Env19) = var_12.mem_1
    let (var_43: (int64 ref)) = var_15.mem_0
    let (var_44: Env19) = var_15.mem_1
    let (var_45: (int64 ref)) = var_18.mem_0
    let (var_46: Env19) = var_18.mem_1
    let (var_47: (int64 ref)) = var_22.mem_0
    let (var_48: Env19) = var_22.mem_1
    let (var_49: (int64 ref)) = var_21.mem_0
    let (var_50: Env19) = var_21.mem_1
    let (var_51: (uint64 ref)) = var_14.mem_0
    let (var_52: uint64) = method_5((var_51: (uint64 ref)))
    let (var_53: (uint64 ref)) = var_17.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: (uint64 ref)) = var_20.mem_0
    let (var_56: uint64) = method_5((var_55: (uint64 ref)))
    let (var_57: (uint64 ref)) = var_48.mem_0
    let (var_58: uint64) = method_5((var_57: (uint64 ref)))
    let (var_59: EnvStack26) = method_102((var_52: uint64), (var_54: uint64), (var_56: uint64), (var_58: uint64), (var_30: (int64 ref)), (var_31: Env19), (var_34: (int64 ref)), (var_35: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_60: (int64 ref)) = var_59.mem_0
    let (var_61: Env19) = var_59.mem_1
    let (var_62: EnvStack26) = method_51((var_60: (int64 ref)), (var_61: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_63: (unit -> unit)) = method_128((var_32: EnvStack26), (var_30: (int64 ref)), (var_31: Env19), (var_4: (int64 ref)), (var_5: Env19), (var_6: int64), (var_23: EnvStack21), (var_24: (int64 ref)), (var_25: Env19), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_36: EnvStack26), (var_34: (int64 ref)), (var_35: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_26: EnvStack21), (var_27: (int64 ref)), (var_28: Env19), (var_12: EnvStack22), (var_13: (int64 ref)), (var_14: Env19), (var_15: EnvStack22), (var_16: (int64 ref)), (var_17: Env19), (var_18: EnvStack22), (var_19: (int64 ref)), (var_20: Env19), (var_21: EnvStack22), (var_22: EnvStack22), (var_62: EnvStack26), (var_60: (int64 ref)), (var_61: Env19), (var_7: (int64 ref)), (var_8: Env16), (var_9: (int64 ref)), (var_10: Env16))
    EnvStack25((var_62: EnvStack26), (var_60: (int64 ref)), (var_61: Env19), (var_63: (unit -> unit)))
and method_130((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: int64), (var_19: float), (var_20: int64), (var_21: EnvHeap17), (var_22: EnvHeap17), (var_23: (unit -> float32)), (var_24: (unit -> unit)), (var_25: EnvStack26), (var_26: (int64 ref)), (var_27: Env19), (var_28: int64)): float =
    let (var_29: bool) = (var_28 < 64L)
    if var_29 then
        let (var_30: bool) = (var_28 >= 0L)
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_32: int64) = (var_28 * 8192L)
        let (var_33: int64) = (var_2 + var_32)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_34: int64) = (var_3 + var_32)
        let (var_35: (int64 ref)) = var_16.mem_6
        let (var_36: Env16) = var_16.mem_7
        let (var_37: ManagedCuda.CudaContext) = var_16.mem_0
        let (var_38: ManagedCuda.CudaBlas.CudaBlas) = var_16.mem_1
        let (var_39: ManagedCuda.CudaRand.CudaRandDevice) = var_16.mem_2
        let (var_40: EnvStack10) = var_16.mem_3
        let (var_41: EnvStack13) = var_16.mem_4
        let (var_42: EnvHeap5) = var_16.mem_5
        let (var_43: EnvHeap17) = ({mem_0 = (var_37: ManagedCuda.CudaContext); mem_1 = (var_38: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_39: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_40: EnvStack10); mem_4 = (var_41: EnvStack13); mem_5 = (var_42: EnvHeap5); mem_6 = (var_8: (int64 ref)); mem_7 = (var_9: Env16)} : EnvHeap17)
        let (var_44: EnvHeap15) = var_9.mem_0
        let (var_45: Env24) = method_46((var_44: EnvHeap15))
        let (var_46: EnvHeap15) = var_45.mem_0
        let (var_47: ManagedCuda.CudaEvent) = var_46.mem_0
        let (var_48: EnvHeap15) = var_36.mem_0
        let (var_49: ManagedCuda.BasicTypes.CUstream) = method_25((var_48: EnvHeap15))
        var_47.Record(var_49)
        let (var_50: ManagedCuda.CudaStream) = var_46.mem_2
        var_50.WaitEvent var_47.Event
        let (var_51: EnvStack25) = method_101((var_43: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_25: EnvStack26), (var_26: (int64 ref)), (var_27: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_33: int64), (var_8: (int64 ref)), (var_9: Env16), (var_35: (int64 ref)), (var_36: Env16), (var_10: EnvHeap23))
        let (var_52: EnvStack26) = var_51.mem_0
        let (var_53: (int64 ref)) = var_51.mem_1
        let (var_54: Env19) = var_51.mem_2
        let (var_55: (unit -> unit)) = var_51.mem_3
        let (var_56: EnvHeap17) = ({mem_0 = (var_37: ManagedCuda.CudaContext); mem_1 = (var_38: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_39: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_40: EnvStack10); mem_4 = (var_41: EnvStack13); mem_5 = (var_42: EnvHeap5); mem_6 = (var_6: (int64 ref)); mem_7 = (var_7: Env16)} : EnvHeap17)
        let (var_57: EnvHeap15) = var_7.mem_0
        let (var_58: Env24) = method_46((var_57: EnvHeap15))
        let (var_59: EnvHeap15) = var_58.mem_0
        let (var_60: ManagedCuda.CudaEvent) = var_59.mem_0
        let (var_61: ManagedCuda.BasicTypes.CUstream) = method_25((var_44: EnvHeap15))
        var_60.Record(var_61)
        let (var_62: ManagedCuda.CudaStream) = var_59.mem_2
        var_62.WaitEvent var_60.Event
        let (var_63: EnvStack27) = method_65((var_56: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_52: EnvStack26), (var_53: (int64 ref)), (var_54: Env19), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19))
        let (var_64: EnvStack26) = var_63.mem_0
        let (var_65: (int64 ref)) = var_63.mem_1
        let (var_66: Env19) = var_63.mem_2
        let (var_67: (unit -> unit)) = var_63.mem_3
        let (var_68: EnvHeap17) = ({mem_0 = (var_37: ManagedCuda.CudaContext); mem_1 = (var_38: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_39: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_40: EnvStack10); mem_4 = (var_41: EnvStack13); mem_5 = (var_42: EnvHeap5); mem_6 = (var_4: (int64 ref)); mem_7 = (var_5: Env16)} : EnvHeap17)
        let (var_69: EnvHeap15) = var_5.mem_0
        let (var_70: Env24) = method_46((var_69: EnvHeap15))
        let (var_71: EnvHeap15) = var_70.mem_0
        let (var_72: ManagedCuda.CudaEvent) = var_71.mem_0
        let (var_73: ManagedCuda.BasicTypes.CUstream) = method_25((var_57: EnvHeap15))
        var_72.Record(var_73)
        let (var_74: ManagedCuda.CudaStream) = var_71.mem_2
        var_74.WaitEvent var_72.Event
        let (var_75: Env24) = method_46((var_69: EnvHeap15))
        let (var_76: EnvHeap15) = var_75.mem_0
        let (var_77: ManagedCuda.CudaEvent) = var_76.mem_0
        let (var_78: ManagedCuda.BasicTypes.CUstream) = method_25((var_48: EnvHeap15))
        var_77.Record(var_78)
        let (var_79: ManagedCuda.CudaStream) = var_76.mem_2
        var_79.WaitEvent var_77.Event
        let (var_80: EnvStack28) = method_81((var_68: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_64: EnvStack26), (var_65: (int64 ref)), (var_66: Env19), (var_0: (int64 ref)), (var_1: Env19), (var_34: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_35: (int64 ref)), (var_36: Env16))
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: Env19) = var_80.mem_1
        let (var_83: (unit -> unit)) = var_80.mem_2
        let (var_84: (unit -> unit)) = method_111((var_24: (unit -> unit)), (var_55: (unit -> unit)), (var_67: (unit -> unit)), (var_83: (unit -> unit)))
        let (var_85: (unit -> float32)) = method_112((var_81: (int64 ref)), (var_82: Env19), (var_23: (unit -> float32)))
        let (var_86: int64) = (var_28 + 1L)
        method_130((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: int64), (var_19: float), (var_20: int64), (var_21: EnvHeap17), (var_22: EnvHeap17), (var_85: (unit -> float32)), (var_84: (unit -> unit)), (var_52: EnvStack26), (var_53: (int64 ref)), (var_54: Env19), (var_86: int64))
    else
        let (var_88: float32) = var_23()
        let (var_89: float) = (float var_88)
        let (var_90: float) = (var_19 + var_89)
        let (var_91: int64) = (var_18 + 1L)
        let (var_98: ResizeArray<Env9>) = ResizeArray<Env9>()
        let (var_99: EnvStack10) = EnvStack10((var_98: ResizeArray<Env9>))
        let (var_100: ManagedCuda.CudaContext) = var_16.mem_0
        let (var_101: ManagedCuda.CudaBlas.CudaBlas) = var_16.mem_1
        let (var_102: ManagedCuda.CudaRand.CudaRandDevice) = var_16.mem_2
        let (var_103: EnvStack10) = var_16.mem_3
        let (var_104: EnvStack13) = var_16.mem_4
        let (var_105: EnvHeap5) = var_16.mem_5
        let (var_106: (int64 ref)) = var_16.mem_6
        let (var_107: Env16) = var_16.mem_7
        let (var_108: EnvHeap17) = ({mem_0 = (var_100: ManagedCuda.CudaContext); mem_1 = (var_101: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_102: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_99: EnvStack10); mem_4 = (var_104: EnvStack13); mem_5 = (var_105: EnvHeap5); mem_6 = (var_106: (int64 ref)); mem_7 = (var_107: Env16)} : EnvHeap17)
        let (var_109: EnvStack10) = var_108.mem_3
        method_114((var_26: (int64 ref)), (var_27: Env19), (var_109: EnvStack10))
        if (System.Double.IsNaN var_90) then
            let (var_110: EnvStack10) = var_22.mem_3
            method_115((var_110: EnvStack10))
            method_115((var_103: EnvStack10))
            // Done with the net...
            method_115((var_109: EnvStack10))
            let (var_111: float) = (float var_91)
            (var_90 / var_111)
        else
            var_24()
            method_117((var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule))
            let (var_113: EnvStack10) = var_22.mem_3
            method_115((var_113: EnvStack10))
            method_115((var_103: EnvStack10))
            // Executing the next loop...
            let (var_114: int64) = (var_20 + 1L)
            method_126((var_0: (int64 ref)), (var_1: Env19), (var_21: EnvHeap17), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_91: int64), (var_90: float), (var_4: (int64 ref)), (var_5: Env16), (var_6: (int64 ref)), (var_7: Env16), (var_8: (int64 ref)), (var_9: Env16), (var_10: EnvHeap23), (var_11: EnvStack22), (var_12: EnvStack22), (var_13: EnvStack21), (var_14: (int64 ref)), (var_15: Env19), (var_108: EnvHeap17), (var_26: (int64 ref)), (var_27: Env19), (var_114: int64))
and method_55((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: EnvHeap17)): unit =
    // Cuda join point
    // method_56((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_6: ManagedCuda.CudaContext) = var_5.mem_0
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_4, var_6)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (int64 ref)) = var_5.mem_6
    let (var_11: Env16) = var_5.mem_7
    let (var_12: EnvHeap15) = var_11.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_25((var_12: EnvHeap15))
    let (var_15: (System.Object [])) = [|var_0; var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_13, var_15)
and method_61((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap17)): unit =
    // Cuda join point
    // method_62((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_7: ManagedCuda.CudaContext) = var_6.mem_0
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_62", var_5, var_7)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (int64 ref)) = var_6.mem_6
    let (var_12: Env16) = var_6.mem_7
    let (var_13: EnvHeap15) = var_12.mem_0
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_25((var_13: EnvHeap15))
    let (var_16: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_14, var_16)
and method_64((var_0: (int64 ref)), (var_1: Env19), (var_2: int64), (var_3: EnvStack26), (var_4: EnvStack21), (var_5: EnvHeap17), (var_6: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_7: (int64 ref)) = var_3.mem_0
    let (var_8: Env19) = var_3.mem_1
    let (var_9: (int64 ref)) = var_4.mem_0
    let (var_10: Env19) = var_4.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlas) = var_5.mem_1
    let (var_12: (int64 ref)) = var_5.mem_6
    let (var_13: Env16) = var_5.mem_7
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_11.get_CublasHandle()
    let (var_15: EnvHeap15) = var_13.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_25((var_15: EnvHeap15))
    var_11.set_Stream(var_16)
    let (var_17: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_18: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_19: (float32 ref)) = (ref 1.000000f)
    let (var_20: (uint64 ref)) = var_8.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: (uint64 ref)) = var_1.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: int64) = (var_2 * 4L)
    let (var_27: uint64) = (uint64 var_26)
    let (var_28: uint64) = (var_25 + var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: (float32 ref)) = (ref 1.000000f)
    let (var_32: (uint64 ref)) = var_10.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_33)
    let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_34)
    let (var_36: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_17, var_18, 128, 128, 64, var_19, var_23, 128, var_30, 128, var_31, var_35, 128)
    if var_36 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_36)
and method_73((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvStack26), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: (int64 ref)) = var_0.mem_0
    let (var_7: Env19) = var_0.mem_1
    let (var_8: (int64 ref)) = var_3.mem_0
    let (var_9: Env19) = var_3.mem_1
    let (var_10: ManagedCuda.CudaBlas.CudaBlas) = var_4.mem_1
    let (var_11: (int64 ref)) = var_4.mem_6
    let (var_12: Env16) = var_4.mem_7
    let (var_13: ManagedCuda.CudaBlas.CudaBlasHandle) = var_10.get_CublasHandle()
    let (var_14: EnvHeap15) = var_12.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_25((var_14: EnvHeap15))
    var_10.set_Stream(var_15)
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_17: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_18: (float32 ref)) = (ref 1.000000f)
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: (uint64 ref)) = var_7.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: (float32 ref)) = (ref 1.000000f)
    let (var_28: (uint64 ref)) = var_9.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_13, var_16, var_17, 128, 64, 128, var_18, var_22, 128, var_26, 128, var_27, var_31, 128)
    if var_32 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_32)
and method_74((var_0: (int64 ref)), (var_1: Env19), (var_2: EnvStack26), (var_3: EnvStack21), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: (int64 ref)) = var_2.mem_0
    let (var_7: Env19) = var_2.mem_1
    let (var_8: (int64 ref)) = var_3.mem_0
    let (var_9: Env19) = var_3.mem_1
    let (var_10: ManagedCuda.CudaBlas.CudaBlas) = var_4.mem_1
    let (var_11: (int64 ref)) = var_4.mem_6
    let (var_12: Env16) = var_4.mem_7
    let (var_13: ManagedCuda.CudaBlas.CudaBlasHandle) = var_10.get_CublasHandle()
    let (var_14: EnvHeap15) = var_12.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_25((var_14: EnvHeap15))
    var_10.set_Stream(var_15)
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_17: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_18: (float32 ref)) = (ref 1.000000f)
    let (var_19: (uint64 ref)) = var_7.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: (uint64 ref)) = var_1.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: (float32 ref)) = (ref 1.000000f)
    let (var_28: (uint64 ref)) = var_9.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_13, var_16, var_17, 128, 128, 64, var_18, var_22, 128, var_26, 128, var_27, var_31, 128)
    if var_32 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_32)
and method_75((var_0: EnvStack26), (var_1: EnvStack22), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: (int64 ref)) = var_0.mem_0
    let (var_5: Env19) = var_0.mem_1
    let (var_6: (int64 ref)) = var_1.mem_0
    let (var_7: Env19) = var_1.mem_1
    let (var_8: (uint64 ref)) = var_5.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: (uint64 ref)) = var_7.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    method_76((var_9: uint64), (var_11: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap17))
and method_84((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_85((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_85", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_94((var_0: (int64 ref)), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env19), (var_4: int64), (var_5: EnvStack26), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: (int64 ref)) = var_5.mem_0
    let (var_9: Env19) = var_5.mem_1
    let (var_10: (uint64 ref)) = var_1.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    let (var_12: (uint64 ref)) = var_3.mem_0
    let (var_13: uint64) = method_5((var_12: (uint64 ref)))
    let (var_14: int64) = (var_4 * 4L)
    let (var_15: uint64) = (uint64 var_14)
    let (var_16: uint64) = (var_13 + var_15)
    let (var_17: (uint64 ref)) = var_9.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_95((var_11: uint64), (var_16: uint64), (var_18: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvHeap17))
and method_103((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: (int64 ref)), (var_5: Env19), (var_6: (int64 ref)), (var_7: Env19), (var_8: (int64 ref)), (var_9: Env19), (var_10: EnvHeap17), (var_11: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_12: (uint64 ref)) = var_5.mem_0
    let (var_13: uint64) = method_5((var_12: (uint64 ref)))
    let (var_14: (uint64 ref)) = var_7.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: (uint64 ref)) = var_9.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    method_104((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_13: uint64), (var_15: uint64), (var_17: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap17))
and method_107((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: EnvStack26), (var_5: (int64 ref)), (var_6: Env19), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvStack26), (var_10: EnvStack26), (var_11: EnvHeap17), (var_12: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_13: (int64 ref)) = var_4.mem_0
    let (var_14: Env19) = var_4.mem_1
    let (var_15: (int64 ref)) = var_9.mem_0
    let (var_16: Env19) = var_9.mem_1
    let (var_17: (int64 ref)) = var_10.mem_0
    let (var_18: Env19) = var_10.mem_1
    let (var_19: (uint64 ref)) = var_14.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_6.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_8.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: (uint64 ref)) = var_16.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: (uint64 ref)) = var_18.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_108((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_20: uint64), (var_22: uint64), (var_24: uint64), (var_26: uint64), (var_28: uint64), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap17))
and method_110((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: EnvStack26), (var_4: (int64 ref)), (var_5: Env19), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_73((var_0: EnvStack26), (var_7: (int64 ref)), (var_8: Env19), (var_3: EnvStack26), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_74((var_4: (int64 ref)), (var_5: Env19), (var_0: EnvStack26), (var_6: EnvStack21), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
and method_119((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_120((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_120", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_123((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_124((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_124", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_128 ((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvStack26), (var_12: (int64 ref)), (var_13: Env19), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvStack21), (var_17: (int64 ref)), (var_18: Env19), (var_19: EnvStack22), (var_20: (int64 ref)), (var_21: Env19), (var_22: EnvStack22), (var_23: (int64 ref)), (var_24: Env19), (var_25: EnvStack22), (var_26: (int64 ref)), (var_27: Env19), (var_28: EnvStack22), (var_29: EnvStack22), (var_30: EnvStack26), (var_31: (int64 ref)), (var_32: Env19), (var_33: (int64 ref)), (var_34: Env16), (var_35: (int64 ref)), (var_36: Env16)) (): unit =
    let (var_37: (int64 ref)) = var_0.mem_0
    let (var_38: Env19) = var_0.mem_1
    let (var_39: (int64 ref)) = var_11.mem_0
    let (var_40: Env19) = var_11.mem_1
    let (var_41: (int64 ref)) = var_19.mem_0
    let (var_42: Env19) = var_19.mem_1
    let (var_43: (int64 ref)) = var_22.mem_0
    let (var_44: Env19) = var_22.mem_1
    let (var_45: (int64 ref)) = var_25.mem_0
    let (var_46: Env19) = var_25.mem_1
    let (var_47: (int64 ref)) = var_29.mem_0
    let (var_48: Env19) = var_29.mem_1
    let (var_49: (int64 ref)) = var_28.mem_0
    let (var_50: Env19) = var_28.mem_1
    let (var_51: (uint64 ref)) = var_21.mem_0
    let (var_52: uint64) = method_5((var_51: (uint64 ref)))
    let (var_53: (uint64 ref)) = var_24.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: (uint64 ref)) = var_27.mem_0
    let (var_56: uint64) = method_5((var_55: (uint64 ref)))
    let (var_57: (uint64 ref)) = var_48.mem_0
    let (var_58: uint64) = method_5((var_57: (uint64 ref)))
    let (var_59: (uint64 ref)) = var_42.mem_0
    let (var_60: uint64) = method_5((var_59: (uint64 ref)))
    let (var_61: (uint64 ref)) = var_44.mem_0
    let (var_62: uint64) = method_5((var_61: (uint64 ref)))
    let (var_63: (uint64 ref)) = var_46.mem_0
    let (var_64: uint64) = method_5((var_63: (uint64 ref)))
    let (var_65: (uint64 ref)) = var_50.mem_0
    let (var_66: uint64) = method_5((var_65: (uint64 ref)))
    method_107((var_52: uint64), (var_54: uint64), (var_56: uint64), (var_58: uint64), (var_30: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_12: (int64 ref)), (var_13: Env19), (var_0: EnvStack26), (var_11: EnvStack26), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_129((var_11: EnvStack26), (var_12: (int64 ref)), (var_13: Env19), (var_14: (int64 ref)), (var_15: Env19), (var_16: EnvStack21), (var_17: (int64 ref)), (var_18: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    method_63((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: int64), (var_6: EnvStack21), (var_7: (int64 ref)), (var_8: Env19), (var_9: EnvHeap17), (var_10: ManagedCuda.BasicTypes.CUmodule))
    let (var_67: EnvHeap15) = var_36.mem_0
    let (var_68: Env24) = method_46((var_67: EnvHeap15))
    let (var_69: EnvHeap15) = var_68.mem_0
    let (var_70: ManagedCuda.CudaEvent) = var_69.mem_0
    let (var_71: EnvHeap15) = var_34.mem_0
    let (var_72: ManagedCuda.BasicTypes.CUstream) = method_25((var_71: EnvHeap15))
    var_70.Record(var_72)
    let (var_73: ManagedCuda.CudaStream) = var_69.mem_2
    var_73.WaitEvent var_70.Event
and method_76((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_77((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_77", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: Env16) = var_3.mem_7
    let (var_10: EnvHeap15) = var_9.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_25((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_11, var_13)
and method_95((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17)): unit =
    // Cuda join point
    // method_96((var_0: uint64), (var_1: uint64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_96", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: Env16) = var_4.mem_7
    let (var_11: EnvHeap15) = var_10.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_25((var_11: EnvHeap15))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_12, var_14)
and method_104((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvHeap17)): unit =
    // Cuda join point
    // method_105((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64))
    let (var_9: ManagedCuda.CudaContext) = var_8.mem_0
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_105", var_7, var_9)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (int64 ref)) = var_8.mem_6
    let (var_14: Env16) = var_8.mem_7
    let (var_15: EnvHeap15) = var_14.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_25((var_15: EnvHeap15))
    let (var_18: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_16, var_18)
and method_108((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap17)): unit =
    // Cuda join point
    // method_109((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64))
    let (var_11: ManagedCuda.CudaContext) = var_10.mem_0
    let (var_12: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_109", var_9, var_11)
    let (var_13: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_12.set_GridDimensions(var_13)
    let (var_14: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_12.set_BlockDimensions(var_14)
    let (var_15: (int64 ref)) = var_10.mem_6
    let (var_16: Env16) = var_10.mem_7
    let (var_17: EnvHeap15) = var_16.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_25((var_17: EnvHeap15))
    let (var_20: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4; var_5; var_6; var_7; var_8|]: (System.Object [])
    var_12.RunAsync(var_18, var_20)
and method_129((var_0: EnvStack26), (var_1: (int64 ref)), (var_2: Env19), (var_3: (int64 ref)), (var_4: Env19), (var_5: EnvStack21), (var_6: (int64 ref)), (var_7: Env19), (var_8: EnvHeap17), (var_9: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_74((var_3: (int64 ref)), (var_4: Env19), (var_0: EnvStack26), (var_5: EnvStack21), (var_8: EnvHeap17), (var_9: ManagedCuda.BasicTypes.CUmodule))
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
let (var_35: EnvHeap0) = ({mem_0 = (var_1: ManagedCuda.CudaContext)} : EnvHeap0)
let (var_36: uint64) = 1073741824UL
let (var_37: ManagedCuda.CudaContext) = var_35.mem_0
let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = var_37.AllocateMemory(var_38)
let (var_40: uint64) = uint64 var_39
let (var_41: (uint64 ref)) = (ref var_40)
let (var_42: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_43: EnvStack2) = EnvStack2((var_42: ResizeArray<Env1>))
let (var_44: ResizeArray<Env3>) = ResizeArray<Env3>()
let (var_45: EnvStack4) = EnvStack4((var_44: ResizeArray<Env3>))
let (var_46: EnvHeap5) = ({mem_0 = (var_43: EnvStack2); mem_1 = (var_41: (uint64 ref)); mem_2 = (var_36: uint64); mem_3 = (var_45: EnvStack4)} : EnvHeap5)
let (var_47: EnvHeap6) = ({mem_0 = (var_37: ManagedCuda.CudaContext); mem_1 = (var_46: EnvHeap5)} : EnvHeap6)
method_1((var_47: EnvHeap6), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_48: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_49: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_48)
let (var_50: ManagedCuda.CudaContext) = var_47.mem_0
let (var_51: EnvHeap5) = var_47.mem_1
let (var_52: EnvHeap7) = ({mem_0 = (var_50: ManagedCuda.CudaContext); mem_1 = (var_49: ManagedCuda.CudaRand.CudaRandDevice); mem_2 = (var_51: EnvHeap5)} : EnvHeap7)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaContext) = var_52.mem_0
let (var_57: ManagedCuda.CudaRand.CudaRandDevice) = var_52.mem_1
let (var_58: EnvHeap5) = var_52.mem_2
let (var_59: EnvHeap8) = ({mem_0 = (var_56: ManagedCuda.CudaContext); mem_1 = (var_55: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_57: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_58: EnvHeap5)} : EnvHeap8)
let (var_66: ResizeArray<Env9>) = ResizeArray<Env9>()
let (var_67: EnvStack10) = EnvStack10((var_66: ResizeArray<Env9>))
let (var_68: ManagedCuda.CudaContext) = var_59.mem_0
let (var_69: ManagedCuda.CudaBlas.CudaBlas) = var_59.mem_1
let (var_70: ManagedCuda.CudaRand.CudaRandDevice) = var_59.mem_2
let (var_71: EnvHeap5) = var_59.mem_3
let (var_72: EnvHeap11) = ({mem_0 = (var_68: ManagedCuda.CudaContext); mem_1 = (var_69: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_70: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_67: EnvStack10); mem_4 = (var_71: EnvHeap5)} : EnvHeap11)
let (var_84: ResizeArray<Env12>) = ResizeArray<Env12>()
let (var_85: EnvStack13) = EnvStack13((var_84: ResizeArray<Env12>))
let (var_86: ManagedCuda.CudaContext) = var_72.mem_0
let (var_87: ManagedCuda.CudaBlas.CudaBlas) = var_72.mem_1
let (var_88: ManagedCuda.CudaRand.CudaRandDevice) = var_72.mem_2
let (var_89: EnvStack10) = var_72.mem_3
let (var_90: EnvHeap5) = var_72.mem_4
let (var_91: EnvHeap14) = ({mem_0 = (var_86: ManagedCuda.CudaContext); mem_1 = (var_87: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_88: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_89: EnvStack10); mem_4 = (var_85: EnvStack13); mem_5 = (var_90: EnvHeap5)} : EnvHeap14)
let (var_92: (bool ref)) = (ref true)
let (var_93: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_94: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_95: EnvHeap15) = ({mem_0 = (var_94: ManagedCuda.CudaEvent); mem_1 = (var_92: (bool ref)); mem_2 = (var_93: ManagedCuda.CudaStream)} : EnvHeap15)
let (var_96: Env12) = method_7((var_95: EnvHeap15), (var_91: EnvHeap14), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_97: (int64 ref)) = var_96.mem_0
let (var_98: Env16) = var_96.mem_1
let (var_99: ManagedCuda.CudaContext) = var_91.mem_0
let (var_100: ManagedCuda.CudaBlas.CudaBlas) = var_91.mem_1
let (var_101: ManagedCuda.CudaRand.CudaRandDevice) = var_91.mem_2
let (var_102: EnvStack10) = var_91.mem_3
let (var_103: EnvStack13) = var_91.mem_4
let (var_104: EnvHeap5) = var_91.mem_5
let (var_105: EnvHeap17) = ({mem_0 = (var_99: ManagedCuda.CudaContext); mem_1 = (var_100: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_101: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_102: EnvStack10); mem_4 = (var_103: EnvStack13); mem_5 = (var_104: EnvHeap5); mem_6 = (var_97: (int64 ref)); mem_7 = (var_98: Env16)} : EnvHeap17)
let (var_107: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_108: int64) = var_107.LongLength
let (var_109: bool) = (var_108 >= 0L)
let (var_110: bool) = (var_109 = false)
if var_110 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_115: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_108))
let (var_116: int64) = 0L
method_9((var_115: (uint8 [])), (var_107: (char [])), (var_108: int64), (var_116: int64))
let (var_117: int64) = var_115.LongLength
let (var_118: bool) = (var_117 > 0L)
let (var_119: bool) = (var_118 = false)
if var_119 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_120: bool) = (var_117 = 1115394L)
let (var_121: bool) = (var_120 = false)
if var_121 then
    (failwith "The dimensions must match.")
else
    ()
let (var_122: int64) = 1115394L
let (var_123: int64) = 0L
let (var_124: int64) = 1L
let (var_125: Env18) = method_10((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_122: int64), (var_115: (uint8 [])), (var_123: int64), (var_124: int64))
let (var_126: Env9) = var_125.mem_0
let (var_127: (int64 ref)) = var_126.mem_0
let (var_128: Env19) = var_126.mem_1
let (var_129: (uint64 ref)) = var_128.mem_0
let (var_130: uint64) = method_5((var_129: (uint64 ref)))
let (var_131: EnvStack20) = method_18((var_130: uint64), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_132: (int64 ref)) = var_131.mem_0
let (var_133: Env19) = var_131.mem_1
let (var_134: EnvStack21) = method_26((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_135: (int64 ref)) = var_134.mem_0
let (var_136: Env19) = var_134.mem_1
let (var_137: EnvStack21) = method_29((var_135: (int64 ref)), (var_136: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_138: EnvStack21) = method_26((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_139: (int64 ref)) = var_138.mem_0
let (var_140: Env19) = var_138.mem_1
let (var_141: EnvStack21) = method_29((var_139: (int64 ref)), (var_140: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_142: Env9) = method_31((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_143: (int64 ref)) = var_142.mem_0
let (var_144: Env19) = var_142.mem_1
method_32((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_143: (int64 ref)), (var_144: Env19))
let (var_145: EnvStack22) = method_36((var_143: (int64 ref)), (var_144: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_146: Env9) = method_31((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_147: (int64 ref)) = var_146.mem_0
let (var_148: Env19) = var_146.mem_1
method_38((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_147: (int64 ref)), (var_148: Env19))
let (var_149: EnvStack22) = method_36((var_147: (int64 ref)), (var_148: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_150: Env9) = method_31((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_151: (int64 ref)) = var_150.mem_0
let (var_152: Env19) = var_150.mem_1
method_38((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_151: (int64 ref)), (var_152: Env19))
let (var_153: EnvStack22) = method_36((var_151: (int64 ref)), (var_152: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_154: EnvStack22) = method_39((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_155: EnvStack22) = method_40((var_154: EnvStack22), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_156: EnvHeap23) = ({mem_0 = (var_145: EnvStack22); mem_1 = (var_143: (int64 ref)); mem_2 = (var_144: Env19); mem_3 = (var_149: EnvStack22); mem_4 = (var_147: (int64 ref)); mem_5 = (var_148: Env19); mem_6 = (var_153: EnvStack22); mem_7 = (var_151: (int64 ref)); mem_8 = (var_152: Env19); mem_9 = (var_155: EnvStack22); mem_10 = (var_154: EnvStack22); mem_11 = (var_137: EnvStack21); mem_12 = (var_135: (int64 ref)); mem_13 = (var_136: Env19); mem_14 = (var_141: EnvStack21); mem_15 = (var_139: (int64 ref)); mem_16 = (var_140: Env19)} : EnvHeap23)
let (var_157: (bool ref)) = (ref true)
let (var_158: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_159: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_160: EnvHeap15) = ({mem_0 = (var_159: ManagedCuda.CudaEvent); mem_1 = (var_157: (bool ref)); mem_2 = (var_158: ManagedCuda.CudaStream)} : EnvHeap15)
let (var_161: Env12) = method_41((var_160: EnvHeap15), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: Env16) = var_161.mem_1
let (var_164: ManagedCuda.CudaContext) = var_105.mem_0
let (var_165: ManagedCuda.CudaBlas.CudaBlas) = var_105.mem_1
let (var_166: ManagedCuda.CudaRand.CudaRandDevice) = var_105.mem_2
let (var_167: EnvStack10) = var_105.mem_3
let (var_168: EnvStack13) = var_105.mem_4
let (var_169: EnvHeap5) = var_105.mem_5
let (var_170: (int64 ref)) = var_105.mem_6
let (var_171: Env16) = var_105.mem_7
let (var_172: EnvHeap17) = ({mem_0 = (var_164: ManagedCuda.CudaContext); mem_1 = (var_165: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_166: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_167: EnvStack10); mem_4 = (var_168: EnvStack13); mem_5 = (var_169: EnvHeap5); mem_6 = (var_162: (int64 ref)); mem_7 = (var_163: Env16)} : EnvHeap17)
let (var_173: (int64 ref)) = var_172.mem_6
let (var_174: Env16) = var_172.mem_7
let (var_175: EnvStack21) = method_42((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_176: (int64 ref)) = var_175.mem_0
let (var_177: Env19) = var_175.mem_1
let (var_178: EnvStack21) = method_29((var_176: (int64 ref)), (var_177: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_179: EnvStack22) = method_39((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_180: EnvStack22) = method_40((var_179: EnvStack22), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_181: (bool ref)) = (ref true)
let (var_182: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_183: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_184: EnvHeap15) = ({mem_0 = (var_183: ManagedCuda.CudaEvent); mem_1 = (var_181: (bool ref)); mem_2 = (var_182: ManagedCuda.CudaStream)} : EnvHeap15)
let (var_185: Env12) = method_41((var_184: EnvHeap15), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_186: (int64 ref)) = var_185.mem_0
let (var_187: Env16) = var_185.mem_1
let (var_188: EnvHeap17) = ({mem_0 = (var_164: ManagedCuda.CudaContext); mem_1 = (var_165: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_166: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_167: EnvStack10); mem_4 = (var_168: EnvStack13); mem_5 = (var_169: EnvHeap5); mem_6 = (var_186: (int64 ref)); mem_7 = (var_187: Env16)} : EnvHeap17)
let (var_189: (int64 ref)) = var_188.mem_6
let (var_190: Env16) = var_188.mem_7
let (var_191: (bool ref)) = (ref true)
let (var_192: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_193: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_194: EnvHeap15) = ({mem_0 = (var_193: ManagedCuda.CudaEvent); mem_1 = (var_191: (bool ref)); mem_2 = (var_192: ManagedCuda.CudaStream)} : EnvHeap15)
let (var_195: Env12) = method_41((var_194: EnvHeap15), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_196: (int64 ref)) = var_195.mem_0
let (var_197: Env16) = var_195.mem_1
let (var_198: EnvHeap17) = ({mem_0 = (var_164: ManagedCuda.CudaContext); mem_1 = (var_165: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_166: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_167: EnvStack10); mem_4 = (var_168: EnvStack13); mem_5 = (var_169: EnvHeap5); mem_6 = (var_196: (int64 ref)); mem_7 = (var_197: Env16)} : EnvHeap17)
let (var_199: (int64 ref)) = var_198.mem_6
let (var_200: Env16) = var_198.mem_7
let (var_201: int64) = 0L
method_44((var_132: (int64 ref)), (var_133: Env19), (var_199: (int64 ref)), (var_200: Env16), (var_189: (int64 ref)), (var_190: Env16), (var_173: (int64 ref)), (var_174: Env16), (var_156: EnvHeap23), (var_180: EnvStack22), (var_179: EnvStack22), (var_178: EnvStack21), (var_176: (int64 ref)), (var_177: Env19), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_201: int64))
method_131((var_103: EnvStack13))
method_115((var_89: EnvStack10))
var_55.Dispose()
var_49.Dispose()
let (var_202: uint64) = method_5((var_41: (uint64 ref)))
let (var_203: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_202)
let (var_204: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_203)
var_50.FreeMemory(var_204)
var_41 := 0UL
var_1.Dispose()

