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
    __global__ void method_62(float * var_0, float * var_1, float * var_2);
    __global__ void method_36(float * var_0, float * var_1);
    __global__ void method_41(float * var_0, float * var_1);
    __global__ void method_45(float * var_0, float * var_1, float * var_2);
    __global__ void method_48(float * var_0, float * var_1);
    __global__ void method_68(float * var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_63(long long int * var_0, float * var_1);
    __device__ char method_37(long long int * var_0);
    __device__ char method_69(long long int * var_0);
    
    __global__ void method_62(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_63(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 10);
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
            float var_19 = (var_18 - var_17);
            float var_20 = (var_19 * var_19);
            float var_21 = (var_12 + var_20);
            long long int var_22 = (var_11 + 10);
            var_8[0] = var_22;
            var_9[0] = var_21;
        }
        long long int var_23 = var_8[0];
        float var_24 = var_9[0];
        float var_25 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_24);
        long long int var_26 = threadIdx.x;
        char var_27 = (var_26 == 0);
        if (var_27) {
            long long int var_28 = blockIdx.x;
            char var_29 = (var_28 >= 0);
            char var_31;
            if (var_29) {
                var_31 = (var_28 < 1);
            } else {
                var_31 = 0;
            }
            char var_32 = (var_31 == 0);
            if (var_32) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_28] = var_25;
        } else {
        }
    }
    __global__ void method_36(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_37(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 1);
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
                var_14 = (var_7 < 1);
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
            while (method_37(var_21)) {
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
            float var_38 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_16);
            __shared__ float var_39[1];
            long long int var_40 = threadIdx.x;
            char var_41 = (var_40 == 0);
            if (var_41) {
                var_39[0] = var_38;
            } else {
            }
            __syncthreads();
            float var_42 = var_39[0];
            long long int var_43[1];
            var_43[0] = 0;
            while (method_37(var_43)) {
                long long int var_45 = var_43[0];
                long long int var_46 = (10 * var_45);
                long long int var_47 = (var_20 + var_46);
                long long int var_48 = (10 - var_46);
                char var_49 = (var_47 < 10);
                if (var_49) {
                    char var_50 = (var_47 >= 0);
                    char var_51 = (var_50 == 0);
                    if (var_51) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_52 = (var_12 + var_47);
                    char var_53 = (var_45 >= 0);
                    char var_55;
                    if (var_53) {
                        var_55 = (var_45 < 1);
                    } else {
                        var_55 = 0;
                    }
                    char var_56 = (var_55 == 0);
                    if (var_56) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_57 = var_16[var_45];
                    float var_58 = var_1[var_52];
                    float var_59 = (var_42 / 10);
                    float var_60 = (var_57 - var_59);
                    var_1[var_52] = var_60;
                } else {
                }
                long long int var_61 = (var_45 + 1);
                var_43[0] = var_61;
            }
            long long int var_62 = var_43[0];
            long long int var_63 = (var_7 + 1);
            var_5[0] = var_63;
        }
        long long int var_64 = var_5[0];
    }
    __global__ void method_41(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_37(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 1);
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
                var_14 = (var_7 < 1);
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
            while (method_37(var_21)) {
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
            float var_39[1];
            long long int var_40[1];
            var_40[0] = 0;
            while (method_37(var_40)) {
                long long int var_42 = var_40[0];
                long long int var_43 = (10 * var_42);
                long long int var_44 = (var_20 + var_43);
                long long int var_45 = (10 - var_43);
                char var_46 = (var_44 < 10);
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
                    float var_51 = var_16[var_42];
                    float var_52 = (var_51 * var_51);
                    char var_54;
                    if (var_47) {
                        var_54 = (var_42 < 1);
                    } else {
                        var_54 = 0;
                    }
                    char var_55 = (var_54 == 0);
                    if (var_55) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_39[var_42] = var_52;
                } else {
                }
                long long int var_56 = (var_42 + 1);
                var_40[0] = var_56;
            }
            long long int var_57 = var_40[0];
            float var_58 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_39);
            __shared__ float var_59[1];
            long long int var_60 = threadIdx.x;
            char var_61 = (var_60 == 0);
            if (var_61) {
                var_59[0] = var_58;
            } else {
            }
            __syncthreads();
            float var_62 = var_59[0];
            long long int var_63[1];
            var_63[0] = 0;
            while (method_37(var_63)) {
                long long int var_65 = var_63[0];
                long long int var_66 = (10 * var_65);
                long long int var_67 = (var_20 + var_66);
                long long int var_68 = (10 - var_66);
                char var_69 = (var_67 < 10);
                if (var_69) {
                    char var_70 = (var_67 >= 0);
                    char var_71 = (var_70 == 0);
                    if (var_71) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_72 = (var_12 + var_67);
                    char var_73 = (var_65 >= 0);
                    char var_75;
                    if (var_73) {
                        var_75 = (var_65 < 1);
                    } else {
                        var_75 = 0;
                    }
                    char var_76 = (var_75 == 0);
                    if (var_76) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_77 = var_16[var_65];
                    float var_78 = var_1[var_72];
                    float var_79 = (var_62 / 10);
                    float var_80 = sqrt(var_79);
                    float var_81 = (var_77 / var_80);
                    var_1[var_72] = var_81;
                } else {
                }
                long long int var_82 = (var_65 + 1);
                var_63[0] = var_82;
            }
            long long int var_83 = var_63[0];
            long long int var_84 = (var_7 + 1);
            var_5[0] = var_84;
        }
        long long int var_85 = var_5[0];
    }
    __global__ void method_45(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_37(var_6)) {
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
            long long int var_13 = (var_8 * 10);
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
            Tuple0 var_17[1];
            long long int var_18 = threadIdx.x;
            long long int var_19 = blockIdx.x;
            long long int var_20 = (10 * var_19);
            long long int var_21 = (var_18 + var_20);
            long long int var_22[1];
            var_22[0] = 0;
            while (method_37(var_22)) {
                long long int var_24 = var_22[0];
                long long int var_25 = (10 * var_24);
                long long int var_26 = (var_21 + var_25);
                long long int var_27 = (10 - var_25);
                char var_28 = (var_26 < 10);
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
                    float var_37 = var_1[var_35];
                    var_17[var_24] = make_Tuple0(var_36, var_37);
                } else {
                }
                long long int var_38 = (var_24 + 1);
                var_22[0] = var_38;
            }
            long long int var_39 = var_22[0];
            float var_41[1];
            long long int var_42[1];
            var_42[0] = 0;
            while (method_37(var_42)) {
                long long int var_44 = var_42[0];
                long long int var_45 = (10 * var_44);
                long long int var_46 = (var_21 + var_45);
                long long int var_47 = (10 - var_45);
                char var_48 = (var_46 < 10);
                if (var_48) {
                    char var_49 = (var_44 >= 0);
                    char var_51;
                    if (var_49) {
                        var_51 = (var_44 < 1);
                    } else {
                        var_51 = 0;
                    }
                    char var_52 = (var_51 == 0);
                    if (var_52) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple0 var_53 = var_17[var_44];
                    float var_54 = var_53.mem_0;
                    float var_55 = var_53.mem_1;
                    float var_56 = (var_55 * var_55);
                    char var_58;
                    if (var_49) {
                        var_58 = (var_44 < 1);
                    } else {
                        var_58 = 0;
                    }
                    char var_59 = (var_58 == 0);
                    if (var_59) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_41[var_44] = var_56;
                } else {
                }
                long long int var_60 = (var_44 + 1);
                var_42[0] = var_60;
            }
            long long int var_61 = var_42[0];
            float var_62 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_41);
            __shared__ float var_63[1];
            long long int var_64 = threadIdx.x;
            char var_65 = (var_64 == 0);
            if (var_65) {
                var_63[0] = var_62;
            } else {
            }
            __syncthreads();
            float var_66 = var_63[0];
            Tuple1 var_69[1];
            long long int var_70[1];
            var_70[0] = 0;
            while (method_37(var_70)) {
                long long int var_72 = var_70[0];
                long long int var_73 = (10 * var_72);
                long long int var_74 = (var_21 + var_73);
                long long int var_75 = (10 - var_73);
                char var_76 = (var_74 < 10);
                if (var_76) {
                    char var_77 = (var_74 >= 0);
                    char var_78 = (var_77 == 0);
                    if (var_78) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_79 = (var_13 + var_74);
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
                    Tuple0 var_84 = var_17[var_72];
                    float var_85 = var_84.mem_0;
                    float var_86 = var_84.mem_1;
                    float var_87 = (var_66 / 10);
                    float var_88 = sqrt(var_87);
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
                    var_69[var_72] = make_Tuple1(var_85, var_86, var_88);
                } else {
                }
                long long int var_92 = (var_72 + 1);
                var_70[0] = var_92;
            }
            long long int var_93 = var_70[0];
            float var_98[1];
            long long int var_99[1];
            var_99[0] = 0;
            while (method_37(var_99)) {
                long long int var_101 = var_99[0];
                long long int var_102 = (10 * var_101);
                long long int var_103 = (var_21 + var_102);
                long long int var_104 = (10 - var_102);
                char var_105 = (var_103 < 10);
                if (var_105) {
                    char var_106 = (var_101 >= 0);
                    char var_108;
                    if (var_106) {
                        var_108 = (var_101 < 1);
                    } else {
                        var_108 = 0;
                    }
                    char var_109 = (var_108 == 0);
                    if (var_109) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_110 = var_69[var_101];
                    float var_111 = var_110.mem_0;
                    float var_112 = var_110.mem_1;
                    float var_113 = var_110.mem_2;
                    float var_114 = (-var_111);
                    float var_115 = (var_114 * var_112);
                    float var_116 = (var_113 * var_113);
                    float var_117 = (var_115 / var_116);
                    char var_119;
                    if (var_106) {
                        var_119 = (var_101 < 1);
                    } else {
                        var_119 = 0;
                    }
                    char var_120 = (var_119 == 0);
                    if (var_120) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_98[var_101] = var_117;
                } else {
                }
                long long int var_121 = (var_101 + 1);
                var_99[0] = var_121;
            }
            long long int var_122 = var_99[0];
            float var_123 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_98);
            __shared__ float var_124[1];
            long long int var_125 = threadIdx.x;
            char var_126 = (var_125 == 0);
            if (var_126) {
                var_124[0] = var_123;
            } else {
            }
            __syncthreads();
            float var_127 = var_124[0];
            long long int var_128[1];
            var_128[0] = 0;
            while (method_37(var_128)) {
                long long int var_130 = var_128[0];
                long long int var_131 = (10 * var_130);
                long long int var_132 = (var_21 + var_131);
                long long int var_133 = (10 - var_131);
                char var_134 = (var_132 < 10);
                if (var_134) {
                    char var_135 = (var_132 >= 0);
                    char var_136 = (var_135 == 0);
                    if (var_136) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_137 = (var_13 + var_132);
                    char var_138 = (var_130 >= 0);
                    char var_140;
                    if (var_138) {
                        var_140 = (var_130 < 1);
                    } else {
                        var_140 = 0;
                    }
                    char var_141 = (var_140 == 0);
                    if (var_141) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Tuple1 var_142 = var_69[var_130];
                    float var_143 = var_142.mem_0;
                    float var_144 = var_142.mem_1;
                    float var_145 = var_142.mem_2;
                    float var_146 = var_2[var_137];
                    float var_147 = (var_143 / var_145);
                    float var_148 = (var_127 * var_144);
                    float var_149 = (var_145 * 10);
                    float var_150 = (var_148 / var_149);
                    float var_151 = (var_146 + var_147);
                    float var_152 = (var_151 + var_150);
                    var_2[var_137] = var_152;
                } else {
                }
                long long int var_153 = (var_130 + 1);
                var_128[0] = var_153;
            }
            long long int var_154 = var_128[0];
            long long int var_155 = (var_8 + 1);
            var_6[0] = var_155;
        }
        long long int var_156 = var_6[0];
    }
    __global__ void method_48(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_37(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 1);
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
                var_14 = (var_7 < 1);
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
            while (method_37(var_21)) {
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
            float var_38 = cub::BlockReduce<float,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_16);
            __shared__ float var_39[1];
            long long int var_40 = threadIdx.x;
            char var_41 = (var_40 == 0);
            if (var_41) {
                var_39[0] = var_38;
            } else {
            }
            __syncthreads();
            float var_42 = var_39[0];
            long long int var_43[1];
            var_43[0] = 0;
            while (method_37(var_43)) {
                long long int var_45 = var_43[0];
                long long int var_46 = (10 * var_45);
                long long int var_47 = (var_20 + var_46);
                long long int var_48 = (10 - var_46);
                char var_49 = (var_47 < 10);
                if (var_49) {
                    char var_50 = (var_47 >= 0);
                    char var_51 = (var_50 == 0);
                    if (var_51) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_52 = (var_12 + var_47);
                    char var_53 = (var_45 >= 0);
                    char var_55;
                    if (var_53) {
                        var_55 = (var_45 < 1);
                    } else {
                        var_55 = 0;
                    }
                    char var_56 = (var_55 == 0);
                    if (var_56) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_57 = var_16[var_45];
                    float var_58 = var_1[var_52];
                    float var_59 = (var_58 + var_57);
                    float var_60 = (var_42 / 10);
                    float var_61 = (var_59 - var_60);
                    var_1[var_52] = var_61;
                } else {
                }
                long long int var_62 = (var_45 + 1);
                var_43[0] = var_62;
            }
            long long int var_63 = var_43[0];
            long long int var_64 = (var_7 + 1);
            var_5[0] = var_64;
        }
        long long int var_65 = var_5[0];
    }
    __global__ void method_68(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_69(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 10);
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
                var_16 = (var_10 < 10);
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
            float var_23 = (2 * var_22);
            float var_24 = (var_20 + var_23);
            var_3[var_10] = var_24;
            long long int var_25 = (var_10 + 128);
            var_8[0] = var_25;
        }
        long long int var_26 = var_8[0];
    }
    __device__ char method_63(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 10);
    }
    __device__ char method_37(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_69(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
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
    val mem_0: EnvStack15
    val mem_1: (int64 ref)
    val mem_2: Env16
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack18 =
    struct
    val mem_0: Env19
    val mem_1: (unit -> unit)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env19 =
    struct
    val mem_0: Env20
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env20 =
    struct
    val mem_0: Env14
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env21 =
    struct
    val mem_0: Env19
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
and method_30((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10), (var_12: Env5), (var_13: Env5), (var_14: int64)): unit =
    let (var_15: bool) = (var_14 < 1L)
    if var_15 then
        let (var_16: int64) = 0L
        let (var_17: float) = method_31((var_12: Env5), (var_13: Env5), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10), (var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env16), (var_16: int64))
        let (var_18: string) = System.String.Format("Training: {0}",var_17)
        let (var_19: string) = System.String.Format("{0}",var_18)
        System.Console.WriteLine(var_19)
        let (var_20: int64) = (var_14 + 1L)
        method_30((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env10), (var_12: Env5), (var_13: Env5), (var_20: int64))
    else
        ()
and method_79((var_0: EnvStack8)): unit =
    let (var_1: ResizeArray<Env7>) = var_0.mem_0
    let (var_3: (Env7 -> unit)) = method_80
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_71((var_0: EnvStack6)): unit =
    let (var_1: ResizeArray<Env5>) = var_0.mem_0
    let (var_3: (Env5 -> unit)) = method_72
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
    let (var_9: int64) = 40L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env16), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (uint64 ref)) = var_2.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(10L)
    let (var_14: EnvHeap9) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_27((var_14: EnvHeap9))
    var_0.SetStream(var_15)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    var_0.GenerateNormal32(var_17, var_13, 0.000000f, 0.426401f)
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
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_31((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_11: EnvStack15), (var_12: (int64 ref)), (var_13: Env16), (var_14: int64)): float =
    let (var_15: bool) = (var_14 < 1L)
    if var_15 then
        let (var_16: bool) = (var_14 >= 0L)
        let (var_17: bool) = (var_16 = false)
        if var_17 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_18: int64) = (var_14 * 784L)
        if var_17 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_19: int64) = (var_14 * 10L)
        method_1((var_4: EnvHeap4))
        let (var_25: ResizeArray<Env5>) = ResizeArray<Env5>()
        let (var_26: EnvStack6) = EnvStack6((var_25: ResizeArray<Env5>))
        // Executing the net...
        let (var_27: int64) = 0L
        let (var_28: float) = 0.000000
        let (var_29: EnvStack17) = method_32((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_26: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_11: EnvStack15), (var_12: (int64 ref)), (var_13: Env16))
        let (var_30: EnvStack15) = var_29.mem_0
        let (var_31: (int64 ref)) = var_29.mem_1
        let (var_32: Env16) = var_29.mem_2
        let (var_33: (unit -> unit)) = var_29.mem_3
        let (var_34: EnvStack18) = method_58((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_26: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_30: EnvStack15), (var_31: (int64 ref)), (var_32: Env16), (var_1: Env5), (var_19: int64))
        let (var_35: Env19) = var_34.mem_0
        let (var_36: (unit -> unit)) = var_34.mem_1
        let (var_37: Env20) = var_35.mem_0
        let (var_38: Env14) = var_37.mem_0
        let (var_39: int64) = var_37.mem_1
        let (var_40: int64) = 1L
        let (var_41: Env5) = var_38.mem_0
        let (var_42: (float32 [])) = method_70((var_40: int64), (var_38: Env14), (var_39: int64))
        let (var_43: float32) = var_42.[int32 0L]
        let (var_44: float) = (float var_43)
        let (var_45: float) = (var_28 + var_44)
        let (var_46: int64) = (var_27 + 1L)
        if (System.Double.IsNaN var_45) then
            method_71((var_26: EnvStack6))
            // Done with the net...
            let (var_47: float) = (float var_46)
            (var_45 / var_47)
        else
            var_36()
            var_33()
            method_71((var_26: EnvStack6))
            let (var_49: int64) = 0L
            let (var_50: float) = 0.000000
            let (var_51: (int64 ref)) = var_11.mem_0
            let (var_52: Env16) = var_11.mem_1
            let (var_53: int64) = 0L
            method_73((var_11: EnvStack15), (var_49: int64), (var_50: float), (var_12: (int64 ref)), (var_13: Env16), (var_0: Env5), (var_18: int64), (var_1: Env5), (var_19: int64), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_26: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_53: int64))
            method_71((var_26: EnvStack6))
            // Executing the next loop...
            let (var_54: int64) = (var_14 + 1L)
            method_78((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_46: int64), (var_45: float), (var_11: EnvStack15), (var_12: (int64 ref)), (var_13: Env16), (var_54: int64))
    else
        0.000000
and method_80 ((var_0: Env7)): unit =
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
and method_72 ((var_0: Env5)): unit =
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
and method_32((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: EnvStack15), (var_10: (int64 ref)), (var_11: Env16)): EnvStack17 =
    let (var_12: EnvStack15) = method_33((var_10: (int64 ref)), (var_11: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env16) = var_12.mem_1
    let (var_15: EnvStack15) = method_28((var_13: (int64 ref)), (var_14: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_16: EnvStack15) = method_38((var_13: (int64 ref)), (var_14: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env16) = var_16.mem_1
    let (var_19: EnvStack15) = method_28((var_17: (int64 ref)), (var_18: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    let (var_20: (unit -> unit)) = method_42((var_9: EnvStack15), (var_10: (int64 ref)), (var_11: Env16), (var_15: EnvStack15), (var_13: (int64 ref)), (var_14: Env16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_19: EnvStack15), (var_17: (int64 ref)), (var_18: Env16))
    EnvStack17((var_19: EnvStack15), (var_17: (int64 ref)), (var_18: Env16), (var_20: (unit -> unit)))
and method_58((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: EnvStack15), (var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64)): EnvStack18 =
    let (var_14: Env21) = method_59((var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_7: (int64 ref)), (var_8: Env10))
    let (var_15: Env19) = var_14.mem_0
    let (var_16: (unit -> unit)) = method_64((var_9: EnvStack15), (var_15: Env19), (var_10: (int64 ref)), (var_11: Env16), (var_12: Env5), (var_13: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10))
    EnvStack18((var_15: Env19), (var_16: (unit -> unit)))
and method_70((var_0: int64), (var_1: Env14), (var_2: int64)): (float32 []) =
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
and method_73((var_0: EnvStack15), (var_1: int64), (var_2: float), (var_3: (int64 ref)), (var_4: Env16), (var_5: Env5), (var_6: int64), (var_7: Env5), (var_8: int64), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvHeap4), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack6), (var_14: EnvStack8), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env10), (var_18: int64)): unit =
    let (var_19: bool) = (var_18 < 1L)
    if var_19 then
        let (var_20: bool) = (var_18 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = (var_18 * 10L)
        let (var_23: (int64 ref)) = var_0.mem_0
        let (var_24: Env16) = var_0.mem_1
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = 0L
        method_74((var_23: (int64 ref)), (var_24: Env16), (var_22: int64), (var_1: int64), (var_2: float), (var_0: EnvStack15), (var_3: (int64 ref)), (var_4: Env16), (var_5: Env5), (var_6: int64), (var_7: Env5), (var_8: int64), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvHeap4), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack6), (var_14: EnvStack8), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env10), (var_25: int64))
        let (var_26: int64) = (var_18 + 1L)
        method_73((var_0: EnvStack15), (var_1: int64), (var_2: float), (var_3: (int64 ref)), (var_4: Env16), (var_5: Env5), (var_6: int64), (var_7: Env5), (var_8: int64), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvHeap4), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack6), (var_14: EnvStack8), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env10), (var_26: int64))
    else
        ()
and method_78((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_11: int64), (var_12: float), (var_13: EnvStack15), (var_14: (int64 ref)), (var_15: Env16), (var_16: int64)): float =
    let (var_17: bool) = (var_16 < 1L)
    if var_17 then
        let (var_18: bool) = (var_16 >= 0L)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_20: int64) = (var_16 * 784L)
        if var_19 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: int64) = (var_16 * 10L)
        method_1((var_4: EnvHeap4))
        let (var_27: ResizeArray<Env5>) = ResizeArray<Env5>()
        let (var_28: EnvStack6) = EnvStack6((var_27: ResizeArray<Env5>))
        // Executing the net...
        let (var_29: EnvStack17) = method_32((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_28: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_13: EnvStack15), (var_14: (int64 ref)), (var_15: Env16))
        let (var_30: EnvStack15) = var_29.mem_0
        let (var_31: (int64 ref)) = var_29.mem_1
        let (var_32: Env16) = var_29.mem_2
        let (var_33: (unit -> unit)) = var_29.mem_3
        let (var_34: EnvStack18) = method_58((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_28: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_30: EnvStack15), (var_31: (int64 ref)), (var_32: Env16), (var_1: Env5), (var_21: int64))
        let (var_35: Env19) = var_34.mem_0
        let (var_36: (unit -> unit)) = var_34.mem_1
        let (var_37: Env20) = var_35.mem_0
        let (var_38: Env14) = var_37.mem_0
        let (var_39: int64) = var_37.mem_1
        let (var_40: int64) = 1L
        let (var_41: Env5) = var_38.mem_0
        let (var_42: (float32 [])) = method_70((var_40: int64), (var_38: Env14), (var_39: int64))
        let (var_43: float32) = var_42.[int32 0L]
        let (var_44: float) = (float var_43)
        let (var_45: float) = (var_12 + var_44)
        let (var_46: int64) = (var_11 + 1L)
        if (System.Double.IsNaN var_45) then
            method_71((var_28: EnvStack6))
            // Done with the net...
            let (var_47: float) = (float var_46)
            (var_45 / var_47)
        else
            var_36()
            var_33()
            method_71((var_28: EnvStack6))
            // Executing the next loop...
            let (var_49: int64) = (var_16 + 1L)
            method_78((var_0: Env5), (var_1: Env5), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10), (var_46: int64), (var_45: float), (var_13: EnvStack15), (var_14: (int64 ref)), (var_15: Env16), (var_49: int64))
    else
        let (var_52: float) = (float var_11)
        (var_12 / var_52)
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
and method_33((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack15 =
    let (var_13: Env5) = method_25((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env16) = var_13.mem_1
    method_34((var_0: (int64 ref)), (var_1: Env16), (var_14: (int64 ref)), (var_15: Env16), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
    EnvStack15((var_14: (int64 ref)), (var_15: Env16))
and method_38((var_0: (int64 ref)), (var_1: Env16), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10)): EnvStack15 =
    let (var_15: Env5) = method_25((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env16) = var_15.mem_1
    method_39((var_0: (int64 ref)), (var_1: Env16), (var_16: (int64 ref)), (var_17: Env16), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvHeap4), (var_5: ManagedCuda.CudaContext), (var_6: EnvStack6), (var_7: EnvStack8), (var_9: (int64 ref)), (var_10: Env10))
    EnvStack15((var_16: (int64 ref)), (var_17: Env16))
and method_42 ((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack15), (var_4: (int64 ref)), (var_5: Env16), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16)) (): unit =
    method_43((var_15: EnvStack15), (var_4: (int64 ref)), (var_5: Env16), (var_3: EnvStack15), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_13: (int64 ref)), (var_14: Env10))
    method_46((var_3: EnvStack15), (var_0: EnvStack15), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_13: (int64 ref)), (var_14: Env10))
    let (var_18: (int64 ref)) = var_0.mem_0
    let (var_19: Env16) = var_0.mem_1
    let (var_20: int64) = 0L
    let (var_21: int64) = 10L
    let (var_22: int64) = 1L
    let (var_23: int64) = 0L
    let (var_24: int64) = 1L
    let (var_25: int64) = 0L
    let (var_26: int64) = 10L
    method_49((var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10), (var_18: (int64 ref)), (var_19: Env16), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_26: int64))
and method_59((var_0: (int64 ref)), (var_1: Env16), (var_2: Env5), (var_3: int64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): Env21 =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env16) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: int64) = (var_3 * 4L)
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: uint64) = (var_18 + var_20)
    let (var_24: Env5) = method_60((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: Env16) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_61((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_21: uint64), (var_28: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
    (Env21((Env19((Env20((Env14((Env5(var_25, var_26)))), 0L))))))
and method_64 ((var_0: EnvStack15), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10)) (): unit =
    method_65((var_0: EnvStack15), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_74((var_0: (int64 ref)), (var_1: Env16), (var_2: int64), (var_3: int64), (var_4: float), (var_5: EnvStack15), (var_6: (int64 ref)), (var_7: Env16), (var_8: Env5), (var_9: int64), (var_10: Env5), (var_11: int64), (var_12: ManagedCuda.CudaBlas.CudaBlas), (var_13: ManagedCuda.CudaRand.CudaRandDevice), (var_14: EnvHeap4), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack6), (var_17: EnvStack8), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env10), (var_21: int64)): unit =
    let (var_22: bool) = (var_21 < 10L)
    if var_22 then
        let (var_23: bool) = (var_21 >= 0L)
        let (var_24: bool) = (var_23 = false)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (var_2 + var_21)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_26: int64) = 1L
        let (var_27: (float32 [])) = method_75((var_26: int64), (var_6: (int64 ref)), (var_7: Env16), (var_25: int64))
        let (var_28: float32) = var_27.[int32 0L]
        let (var_29: float32) = (var_28 + 0.001000f)
        method_76((var_6: (int64 ref)), (var_7: Env16), (var_25: int64), (var_29: float32))
        let (var_30: int64) = 0L
        let (var_31: float) = method_77((var_8: Env5), (var_9: int64), (var_10: Env5), (var_11: int64), (var_12: ManagedCuda.CudaBlas.CudaBlas), (var_13: ManagedCuda.CudaRand.CudaRandDevice), (var_14: EnvHeap4), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack6), (var_17: EnvStack8), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env10), (var_3: int64), (var_4: float), (var_5: EnvStack15), (var_6: (int64 ref)), (var_7: Env16), (var_30: int64))
        let (var_32: float32) = (var_28 - 0.001000f)
        method_76((var_6: (int64 ref)), (var_7: Env16), (var_25: int64), (var_32: float32))
        let (var_33: int64) = 0L
        let (var_34: float) = method_77((var_8: Env5), (var_9: int64), (var_10: Env5), (var_11: int64), (var_12: ManagedCuda.CudaBlas.CudaBlas), (var_13: ManagedCuda.CudaRand.CudaRandDevice), (var_14: EnvHeap4), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack6), (var_17: EnvStack8), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env10), (var_3: int64), (var_4: float), (var_5: EnvStack15), (var_6: (int64 ref)), (var_7: Env16), (var_33: int64))
        method_76((var_6: (int64 ref)), (var_7: Env16), (var_25: int64), (var_28: float32))
        let (var_35: float) = (var_31 - var_34)
        let (var_36: float32) = (float32 var_35)
        let (var_37: float32) = (var_36 / 0.002000f)
        let (var_38: int64) = 1L
        let (var_39: (float32 [])) = method_75((var_38: int64), (var_0: (int64 ref)), (var_1: Env16), (var_25: int64))
        let (var_40: float32) = var_39.[int32 0L]
        let (var_41: float32) = (var_40 - var_37)
        let (var_42: float32) = (-var_41)
        let (var_43: bool) = (var_42 < var_41)
        let (var_44: float32) =
            if var_43 then
                var_41
            else
                var_42
        let (var_45: bool) = (var_44 >= 0.001000f)
        if var_45 then
            let (var_46: string) = System.String.Format("{0}",var_40)
            let (var_47: string) = System.String.Format("{0} = {1}","true_gradient",var_46)
            let (var_48: string) = System.String.Format("{0}",var_44)
            let (var_49: string) = System.String.Format("{0} = {1}","diff",var_48)
            let (var_50: string) = System.String.Format("{0}",var_37)
            let (var_51: string) = System.String.Format("{0} = {1}","approx_gradient",var_50)
            let (var_52: string) = String.concat "; " [|var_51; var_49; var_47|]
            let (var_53: string) = System.String.Format("{0}{1}{2}","{",var_52,"}")
            System.Console.WriteLine(var_53)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_54: int64) = (var_21 + 1L)
        method_74((var_0: (int64 ref)), (var_1: Env16), (var_2: int64), (var_3: int64), (var_4: float), (var_5: EnvStack15), (var_6: (int64 ref)), (var_7: Env16), (var_8: Env5), (var_9: int64), (var_10: Env5), (var_11: int64), (var_12: ManagedCuda.CudaBlas.CudaBlas), (var_13: ManagedCuda.CudaRand.CudaRandDevice), (var_14: EnvHeap4), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack6), (var_17: EnvStack8), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env10), (var_54: int64))
    else
        ()
and method_21 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_22((var_2: uint64))
and method_34((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): unit =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_35((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_16: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
and method_39((var_0: (int64 ref)), (var_1: Env16), (var_2: (int64 ref)), (var_3: Env16), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): unit =
    let (var_13: (uint64 ref)) = var_1.mem_0
    let (var_14: uint64) = method_5((var_13: (uint64 ref)))
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_40((var_8: ManagedCuda.CudaContext), (var_14: uint64), (var_16: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
and method_43((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env16), (var_3: EnvStack15), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: EnvHeap4), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack6), (var_10: EnvStack8), (var_11: (int64 ref)), (var_12: Env10)): unit =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env16) = var_0.mem_1
    let (var_15: (int64 ref)) = var_3.mem_0
    let (var_16: Env16) = var_3.mem_1
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_16.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    method_44((var_8: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_22: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10))
and method_46((var_0: EnvStack15), (var_1: EnvStack15), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvHeap4), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack6), (var_8: EnvStack8), (var_9: (int64 ref)), (var_10: Env10)): unit =
    let (var_11: (int64 ref)) = var_0.mem_0
    let (var_12: Env16) = var_0.mem_1
    let (var_13: (int64 ref)) = var_1.mem_0
    let (var_14: Env16) = var_1.mem_1
    let (var_15: (uint64 ref)) = var_12.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: (uint64 ref)) = var_14.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    method_47((var_6: ManagedCuda.CudaContext), (var_16: uint64), (var_18: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env10))
and method_49((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: (int64 ref)), (var_10: Env16), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64)): unit =
    let (var_18: int64) = (var_15 - var_14)
    let (var_19: int64) = (var_17 - var_16)
    let (var_20: int64) = (var_18 * var_19)
    let (var_21: bool) = (var_20 > 0L)
    let (var_22: bool) = (var_21 = false)
    if var_22 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_23: int64) = (var_19 * var_13)
    let (var_24: bool) = (var_12 = var_23)
    let (var_25: bool) = (var_24 = false)
    if var_25 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_26: int64) = (var_18 * var_12)
    let (var_27: (float32 [])) = method_50((var_18: int64), (var_9: (int64 ref)), (var_10: Env16), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_28: int64) = 0L
    method_51((var_27: (float32 [])), (var_28: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64))
and method_60((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvHeap4), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10)): Env5 =
    let (var_9: int64) = 4L
    method_19((var_2: EnvHeap4), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaContext), (var_4: EnvStack6), (var_5: EnvStack8), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env10), (var_9: int64))
and method_61((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_62((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_62", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_65((var_0: EnvStack15), (var_1: Env19), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10)): unit =
    let (var_15: Env20) = var_1.mem_0
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
    method_66((var_25: uint64), (var_2: (int64 ref)), (var_3: Env16), (var_4: Env5), (var_5: int64), (var_0: EnvStack15), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvHeap4), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack6), (var_11: EnvStack8), (var_13: (int64 ref)), (var_14: Env10))
and method_75((var_0: int64), (var_1: (int64 ref)), (var_2: Env16), (var_3: int64)): (float32 []) =
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
and method_76((var_0: (int64 ref)), (var_1: Env16), (var_2: int64), (var_3: float32)): unit =
    let (var_4: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_4.[int32 0L] <- var_3
    let (var_5: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_4,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_6: int64) = var_5.AddrOfPinnedObject().ToInt64()
    let (var_7: uint64) = (uint64 var_6)
    let (var_8: (uint64 ref)) = var_1.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: int64) = (var_2 * 4L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_14: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_13)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_7)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
    let (var_18: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_14, var_16, var_17)
    if var_18 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_18)
    var_5.Free()
and method_77((var_0: Env5), (var_1: int64), (var_2: Env5), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10), (var_13: int64), (var_14: float), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16), (var_18: int64)): float =
    let (var_19: bool) = (var_18 < 1L)
    if var_19 then
        let (var_20: bool) = (var_18 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = (var_18 * 784L)
        let (var_23: int64) = (var_1 + var_22)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_24: int64) = (var_18 * 10L)
        let (var_25: int64) = (var_3 + var_24)
        method_1((var_6: EnvHeap4))
        let (var_31: ResizeArray<Env5>) = ResizeArray<Env5>()
        let (var_32: EnvStack6) = EnvStack6((var_31: ResizeArray<Env5>))
        // Executing the net...
        let (var_33: EnvStack17) = method_32((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_32: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16))
        let (var_34: EnvStack15) = var_33.mem_0
        let (var_35: (int64 ref)) = var_33.mem_1
        let (var_36: Env16) = var_33.mem_2
        let (var_37: (unit -> unit)) = var_33.mem_3
        let (var_38: EnvStack18) = method_58((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_32: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10), (var_34: EnvStack15), (var_35: (int64 ref)), (var_36: Env16), (var_2: Env5), (var_25: int64))
        let (var_39: Env19) = var_38.mem_0
        let (var_40: (unit -> unit)) = var_38.mem_1
        let (var_41: Env20) = var_39.mem_0
        let (var_42: Env14) = var_41.mem_0
        let (var_43: int64) = var_41.mem_1
        let (var_44: int64) = 1L
        let (var_45: Env5) = var_42.mem_0
        let (var_46: (float32 [])) = method_70((var_44: int64), (var_42: Env14), (var_43: int64))
        let (var_47: float32) = var_46.[int32 0L]
        let (var_48: float) = (float var_47)
        let (var_49: float) = (var_14 + var_48)
        let (var_50: int64) = (var_13 + 1L)
        if (System.Double.IsNaN var_49) then
            method_71((var_32: EnvStack6))
            // Done with the net...
            let (var_51: float) = (float var_50)
            (var_49 / var_51)
        else
            method_71((var_32: EnvStack6))
            // Executing the next loop...
            let (var_53: int64) = (var_18 + 1L)
            method_77((var_0: Env5), (var_1: int64), (var_2: Env5), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvHeap4), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack6), (var_9: EnvStack8), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env10), (var_50: int64), (var_49: float), (var_15: EnvStack15), (var_16: (int64 ref)), (var_17: Env16), (var_53: int64))
    else
        let (var_56: float) = (float var_13)
        (var_14 / var_56)
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
and method_35((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_36((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_36", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_40((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_41((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_44((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env10)): unit =
    // Cuda join point
    // method_45((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap9) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: EnvHeap9))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_47((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env10)): unit =
    // Cuda join point
    // method_48((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_48", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap9) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: EnvHeap9))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_50((var_0: int64), (var_1: (int64 ref)), (var_2: Env16), (var_3: int64), (var_4: int64), (var_5: int64)): (float32 []) =
    let (var_6: int64) = (var_0 * var_4)
    let (var_7: (uint64 ref)) = var_2.mem_0
    let (var_8: uint64) = method_5((var_7: (uint64 ref)))
    let (var_9: int64) = (var_3 * 4L)
    let (var_10: uint64) = (uint64 var_9)
    let (var_11: uint64) = (var_8 + var_10)
    let (var_12: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_6))
    let (var_13: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_14: int64) = var_13.AddrOfPinnedObject().ToInt64()
    let (var_15: uint64) = (uint64 var_14)
    let (var_16: int64) = (var_6 * 4L)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_11)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_22: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_18, var_20, var_21)
    if var_22 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_22)
    var_13.Free()
    var_12
and method_51((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_52((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.AppendLine("[|")
    let (var_13: int64) = method_53((var_8: System.Text.StringBuilder), (var_9: string), (var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_10: int64))
    let (var_14: int64) = 0L
    method_52((var_8: System.Text.StringBuilder), (var_14: int64))
    let (var_15: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_16: string) = var_8.ToString()
    let (var_17: string) = System.String.Format("{0}",var_16)
    System.Console.WriteLine(var_17)
and method_66((var_0: uint64), (var_1: (int64 ref)), (var_2: Env16), (var_3: Env5), (var_4: int64), (var_5: EnvStack15), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvHeap4), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack6), (var_12: EnvStack8), (var_13: (int64 ref)), (var_14: Env10)): unit =
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
    method_67((var_10: ManagedCuda.CudaContext), (var_0: uint64), (var_18: uint64), (var_25: uint64), (var_27: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env10))
and method_52((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_52((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_53((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): int64 =
    let (var_11: bool) = (var_6 < var_7)
    if var_11 then
        let (var_12: bool) = (var_10 < 1000L)
        if var_12 then
            let (var_13: bool) = (var_6 >= var_6)
            let (var_14: bool) = (var_13 = false)
            if var_14 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_15: int64) = 0L
            method_54((var_0: System.Text.StringBuilder), (var_15: int64))
            let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_17: int64) = method_55((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_3: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_19: int64) = (var_6 + 1L)
            method_57((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_17: int64), (var_19: int64))
        else
            let (var_21: int64) = 0L
            method_52((var_0: System.Text.StringBuilder), (var_21: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_67((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env10)): unit =
    // Cuda join point
    // method_68((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_68", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: EnvHeap9) = var_7.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: EnvHeap9))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_12, var_14)
and method_54((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_54((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_55((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
    let (var_8: bool) = (var_4 < var_5)
    if var_8 then
        let (var_9: bool) = (var_7 < 1000L)
        if var_9 then
            let (var_10: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_11: bool) = (var_4 >= var_4)
            let (var_12: bool) = (var_11 = false)
            if var_12 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_13: float32) = var_1.[int32 var_2]
            let (var_14: string) = System.String.Format("{0}",var_13)
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
            let (var_16: string) = "; "
            let (var_17: int64) = (var_7 + 1L)
            let (var_18: int64) = (var_4 + 1L)
            method_56((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_57((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_7)
    if var_12 then
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: bool) = (var_11 >= var_6)
            let (var_15: bool) = (var_14 = false)
            if var_15 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_16: int64) = (var_11 - var_6)
            let (var_17: int64) = (var_16 * var_4)
            let (var_18: int64) = (var_3 + var_17)
            let (var_19: int64) = 0L
            method_54((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_55((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_11 + 1L)
            method_57((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_52((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_56((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
    let (var_9: bool) = (var_8 < var_5)
    if var_9 then
        let (var_10: bool) = (var_7 < 1000L)
        if var_10 then
            let (var_11: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_12: bool) = (var_8 >= var_4)
            let (var_13: bool) = (var_12 = false)
            if var_13 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_14: int64) = (var_8 - var_4)
            let (var_15: int64) = (var_14 * var_3)
            let (var_16: int64) = (var_2 + var_15)
            let (var_17: float32) = var_1.[int32 var_16]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
            let (var_20: string) = "; "
            let (var_21: int64) = (var_7 + 1L)
            let (var_22: int64) = (var_8 + 1L)
            method_56((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
        else
            let (var_24: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
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
let (var_173: int64) = 0L
method_30((var_172: EnvStack15), (var_170: (int64 ref)), (var_171: Env16), (var_49: ManagedCuda.CudaBlas.CudaBlas), (var_46: ManagedCuda.CudaRand.CudaRandDevice), (var_44: EnvHeap4), (var_1: ManagedCuda.CudaContext), (var_56: EnvStack6), (var_69: EnvStack8), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_75: (int64 ref)), (var_76: Env10), (var_162: Env5), (var_168: Env5), (var_173: int64))
method_79((var_69: EnvStack8))
method_71((var_56: EnvStack6))
var_49.Dispose()
var_46.Dispose()
let (var_174: uint64) = method_5((var_39: (uint64 ref)))
let (var_175: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_174)
let (var_176: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_175)
var_1.FreeMemory(var_176)
var_39 := 0UL
var_1.Dispose()

