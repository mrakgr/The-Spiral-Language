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
    struct Tuple2 {
        Tuple0 mem_0;
        Tuple0 mem_1;
    };
    __device__ __forceinline__ Tuple2 make_Tuple2(Tuple0 mem_0, Tuple0 mem_1){
        Tuple2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple0(*FunPointer1)(Tuple0, Tuple0);
    __global__ void method_17(long long int var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_20(float * var_0, long long int var_1, float * var_2);
    __global__ void method_21(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __global__ void method_25(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5);
    __global__ void method_26(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4);
    __global__ void method_28(long long int var_0, float * var_1, float * var_2);
    __global__ void method_30(float * var_0, float * var_1);
    __global__ void method_32(float * var_0, float * var_1);
    __global__ void method_35(float * var_0, float * var_1, float * var_2);
    __global__ void method_37(float * var_0, float * var_1);
    __global__ void method_39(float * var_0, float * var_1, float * var_2);
    __global__ void method_42(float * var_0, float * var_1, float * var_2);
    __device__ char method_18(long long int * var_0);
    __device__ char method_19(long long int var_0, long long int * var_1);
    __device__ char method_22(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_29(long long int * var_0, float * var_1);
    __device__ char method_31(long long int * var_0);
    __device__ char method_36(long long int * var_0);
    __device__ char method_38(long long int * var_0);
    __device__ char method_40(long long int * var_0, float * var_1);
    __device__ char method_43(long long int * var_0, float * var_1, float * var_2);
    __device__ Tuple0 method_44(Tuple0 var_0, Tuple0 var_1);
    
    __global__ void method_17(long long int var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = blockDim.y;
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (10 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_18(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 10);
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
            long long int var_18 = (var_4 * var_17);
            long long int var_19 = (var_16 + var_18);
            long long int var_20[1];
            var_20[0] = var_19;
            while (method_19(var_0, var_20)) {
                long long int var_22 = var_20[0];
                char var_23 = (var_22 >= 0);
                char var_25;
                if (var_23) {
                    var_25 = (var_22 < var_0);
                } else {
                    var_25 = 0;
                }
                char var_26 = (var_25 == 0);
                if (var_26) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_27 = (var_22 * 10);
                char var_29;
                if (var_12) {
                    var_29 = (var_11 < 10);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_27 + var_11);
                char var_33;
                if (var_23) {
                    var_33 = (var_22 < var_0);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                char var_36;
                if (var_12) {
                    var_36 = (var_11 < 10);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                float var_38 = var_1[var_11];
                float var_39 = var_2[var_31];
                float var_40 = var_3[var_31];
                float var_41 = (var_38 + var_39);
                var_3[var_31] = var_41;
                long long int var_42 = (var_22 + var_4);
                var_20[0] = var_42;
            }
            long long int var_43 = var_20[0];
            long long int var_44 = (var_11 + 10);
            var_9[0] = var_44;
        }
        long long int var_45 = var_9[0];
    }
    __global__ void method_20(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = gridDim.x;
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8 = (var_3 * 128);
        long long int var_9[1];
        var_9[0] = var_7;
        while (method_19(var_1, var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < var_1);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            char var_17;
            if (var_12) {
                var_17 = (var_11 < var_1);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            float var_19 = var_0[var_11];
            float var_20 = var_2[var_11];
            float var_21 = (-var_19);
            float var_22 = exp(var_21);
            float var_23 = (1 + var_22);
            float var_24 = (1 / var_23);
            var_2[var_11] = var_24;
            long long int var_25 = (var_11 + var_8);
            var_9[0] = var_25;
        }
        long long int var_26 = var_9[0];
    }
    __global__ void method_21(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
        long long int var_5 = gridDim.x;
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (256 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10 = (var_5 * 256);
        float var_11 = 0;
        long long int var_12[1];
        float var_13[1];
        var_12[0] = var_9;
        var_13[0] = var_11;
        while (method_22(var_2, var_12, var_13)) {
            long long int var_15 = var_12[0];
            float var_16 = var_13[0];
            char var_17 = (var_15 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_15 < var_2);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_15];
            float var_22 = var_1[var_15];
            float var_23 = log(var_21);
            float var_24 = (var_22 * var_23);
            float var_25 = (1 - var_22);
            float var_26 = (1 - var_21);
            float var_27 = log(var_26);
            float var_28 = (var_25 * var_27);
            float var_29 = (var_24 + var_28);
            float var_30 = (-var_29);
            float var_31 = (var_16 + var_30);
            long long int var_32 = (var_15 + var_10);
            var_12[0] = var_32;
            var_13[0] = var_31;
        }
        long long int var_33 = var_12[0];
        float var_34 = var_13[0];
        float var_35 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_34);
        long long int var_36 = threadIdx.x;
        char var_37 = (var_36 == 0);
        if (var_37) {
            long long int var_38 = blockIdx.x;
            char var_39 = (var_38 >= 0);
            char var_41;
            if (var_39) {
                var_41 = (var_38 < var_4);
            } else {
                var_41 = 0;
            }
            char var_42 = (var_41 == 0);
            if (var_42) {
                // "Argument out of bounds."
            } else {
            }
            var_3[var_38] = var_35;
        } else {
        }
    }
    __global__ void method_25(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5) {
        long long int var_6 = gridDim.x;
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (128 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11 = (var_6 * 128);
        long long int var_12[1];
        var_12[0] = var_10;
        while (method_19(var_4, var_12)) {
            long long int var_14 = var_12[0];
            char var_15 = (var_14 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_14 < var_4);
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
                var_20 = (var_14 < var_4);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_2[var_14];
            float var_23 = var_3[var_14];
            float var_24 = var_5[var_14];
            float var_25 = (var_22 - var_23);
            float var_26 = (1 - var_22);
            float var_27 = (var_22 * var_26);
            float var_28 = (var_25 / var_27);
            float var_29 = (var_0 * var_28);
            float var_30 = (var_24 + var_29);
            var_5[var_14] = var_30;
            long long int var_31 = (var_14 + var_11);
            var_12[0] = var_31;
        }
        long long int var_32 = var_12[0];
    }
    __global__ void method_26(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4) {
        long long int var_5 = gridDim.x;
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10 = (var_5 * 128);
        long long int var_11[1];
        var_11[0] = var_9;
        while (method_19(var_3, var_11)) {
            long long int var_13 = var_11[0];
            char var_14 = (var_13 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_13 < var_3);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_13 < var_3);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_13];
            float var_22 = var_1[var_13];
            float var_23 = var_2[var_13];
            float var_24 = var_4[var_13];
            float var_25 = (1 - var_23);
            float var_26 = (var_23 * var_25);
            float var_27 = (var_22 * var_26);
            float var_28 = (var_24 + var_27);
            var_4[var_13] = var_28;
            long long int var_29 = (var_13 + var_10);
            var_11[0] = var_29;
        }
        long long int var_30 = var_11[0];
    }
    __global__ void method_28(long long int var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_18(var_7)) {
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 10);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.y;
            long long int var_18 = blockIdx.y;
            long long int var_19 = (32 * var_18);
            long long int var_20 = (var_17 + var_19);
            float var_21 = 0;
            long long int var_22[1];
            float var_23[1];
            var_22[0] = var_20;
            var_23[0] = var_21;
            while (method_22(var_0, var_22, var_23)) {
                long long int var_25 = var_22[0];
                float var_26 = var_23[0];
                char var_27 = (var_25 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_25 < var_0);
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
                if (var_10) {
                    var_33 = (var_9 < 10);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_31 + var_9);
                float var_36 = var_1[var_35];
                float var_37 = (var_26 + var_36);
                long long int var_38 = (var_25 + 32);
                var_22[0] = var_38;
                var_23[0] = var_37;
            }
            long long int var_39 = var_22[0];
            float var_40 = var_23[0];
            __shared__ float var_41[310];
            long long int var_42[1];
            float var_43[1];
            var_42[0] = 32;
            var_43[0] = var_40;
            while (method_29(var_42, var_43)) {
                long long int var_45 = var_42[0];
                float var_46 = var_43[0];
                long long int var_47 = (var_45 / 2);
                long long int var_48 = threadIdx.y;
                char var_49 = (var_48 < var_45);
                char var_52;
                if (var_49) {
                    long long int var_50 = threadIdx.y;
                    var_52 = (var_50 >= var_47);
                } else {
                    var_52 = 0;
                }
                if (var_52) {
                    long long int var_53 = threadIdx.y;
                    char var_54 = (var_53 >= 1);
                    char var_56;
                    if (var_54) {
                        var_56 = (var_53 < 32);
                    } else {
                        var_56 = 0;
                    }
                    char var_57 = (var_56 == 0);
                    if (var_57) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_58 = (var_53 - 1);
                    long long int var_59 = (var_58 * 10);
                    long long int var_60 = threadIdx.x;
                    char var_61 = (var_60 >= 0);
                    char var_63;
                    if (var_61) {
                        var_63 = (var_60 < 10);
                    } else {
                        var_63 = 0;
                    }
                    char var_64 = (var_63 == 0);
                    if (var_64) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_65 = (var_59 + var_60);
                    var_41[var_65] = var_46;
                } else {
                }
                __syncthreads();
                long long int var_66 = threadIdx.y;
                char var_67 = (var_66 < var_47);
                float var_92;
                if (var_67) {
                    long long int var_68 = threadIdx.y;
                    long long int var_69 = (var_68 + var_47);
                    long long int var_70[1];
                    float var_71[1];
                    var_70[0] = var_69;
                    var_71[0] = var_46;
                    while (method_22(var_45, var_70, var_71)) {
                        long long int var_73 = var_70[0];
                        float var_74 = var_71[0];
                        char var_75 = (var_73 >= 1);
                        char var_77;
                        if (var_75) {
                            var_77 = (var_73 < 32);
                        } else {
                            var_77 = 0;
                        }
                        char var_78 = (var_77 == 0);
                        if (var_78) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_79 = (var_73 - 1);
                        long long int var_80 = (var_79 * 10);
                        long long int var_81 = threadIdx.x;
                        char var_82 = (var_81 >= 0);
                        char var_84;
                        if (var_82) {
                            var_84 = (var_81 < 10);
                        } else {
                            var_84 = 0;
                        }
                        char var_85 = (var_84 == 0);
                        if (var_85) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_86 = (var_80 + var_81);
                        float var_87 = var_41[var_86];
                        float var_88 = (var_74 + var_87);
                        long long int var_89 = (var_73 + var_47);
                        var_70[0] = var_89;
                        var_71[0] = var_88;
                    }
                    long long int var_90 = var_70[0];
                    var_92 = var_71[0];
                } else {
                    var_92 = var_46;
                }
                var_42[0] = var_47;
                var_43[0] = var_92;
            }
            long long int var_93 = var_42[0];
            float var_94 = var_43[0];
            long long int var_95 = threadIdx.y;
            char var_96 = (var_95 == 0);
            if (var_96) {
                float var_97 = var_2[var_9];
                float var_98 = (var_94 + var_97);
                var_2[var_9] = var_98;
            } else {
            }
            long long int var_99 = (var_9 + 10);
            var_7[0] = var_99;
        }
        long long int var_100 = var_7[0];
    }
    __global__ void method_30(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_31(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 7840);
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
                var_14 = (var_8 < 7840);
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
            float var_18 = (0.25 * var_16);
            float var_19 = (var_17 - var_18);
            var_1[var_8] = var_19;
            long long int var_20 = (var_8 + 7936);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_32(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_18(var_6)) {
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
            float var_18 = (0.25 * var_16);
            float var_19 = (var_17 - var_18);
            var_1[var_8] = var_19;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_35(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_18(var_7)) {
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
            while (method_36(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 10000);
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
                char var_31;
                if (var_21) {
                    var_31 = (var_20 < 10000);
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
                    var_34 = (var_9 < 10);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                float var_36 = var_0[var_9];
                float var_37 = var_1[var_29];
                float var_38 = var_2[var_29];
                float var_39 = (var_36 + var_37);
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
    __global__ void method_37(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_38(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 100000);
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
                var_14 = (var_8 < 100000);
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
    __global__ void method_39(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_40(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 100000);
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
            long long int var_28 = (var_11 + 16384);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        long long int var_32 = threadIdx.x;
        char var_33 = (var_32 == 0);
        if (var_33) {
            long long int var_34 = blockIdx.x;
            char var_35 = (var_34 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_34 < 64);
            } else {
                var_37 = 0;
            }
            char var_38 = (var_37 == 0);
            if (var_38) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_34] = var_31;
        } else {
        }
    }
    __global__ void method_42(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_36(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 10000);
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
                var_15 = (var_8 < 10000);
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
            while (method_43(var_23, var_24, var_25)) {
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
            FunPointer1 var_47 = method_44;
            Tuple0 var_48 = cub::BlockReduce<Tuple0,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple0(var_43, var_44), var_47);
            float var_49 = var_48.mem_0;
            float var_50 = var_48.mem_1;
            long long int var_51 = threadIdx.x;
            char var_52 = (var_51 == 0);
            if (var_52) {
                char var_54;
                if (var_9) {
                    var_54 = (var_8 < 10000);
                } else {
                    var_54 = 0;
                }
                char var_55 = (var_54 == 0);
                if (var_55) {
                    // "Argument out of bounds."
                } else {
                }
                float var_56 = var_2[var_8];
                var_2[var_8] = var_50;
            } else {
            }
            long long int var_57 = (var_8 + 64);
            var_6[0] = var_57;
        }
        long long int var_58 = var_6[0];
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_19(long long int var_0, long long int * var_1) {
        long long int var_2 = var_1[0];
        return (var_2 < var_0);
    }
    __device__ char method_22(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_29(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_31(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 7840);
    }
    __device__ char method_36(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10000);
    }
    __device__ char method_38(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 100000);
    }
    __device__ char method_40(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 100000);
    }
    __device__ char method_43(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 10);
    }
    __device__ Tuple0 method_44(Tuple0 var_0, Tuple0 var_1) {
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
}
"""

type EnvStack0 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env1 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple2 =
    struct
    val mem_0: Tuple3
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple4 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack5 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env6 =
    struct
    val mem_0: float
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env7 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2((var_0: string)): Tuple2 =
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
    Tuple2(Tuple3(var_16, var_17, var_18), var_22)
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
and method_5((var_0: string)): Tuple4 =
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
    Tuple4(var_12, var_14)
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
and method_10((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64)): EnvStack5 =
    let (var_8: int64) = (var_3 * var_6)
    let (var_9: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_4,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_10: int64) = var_9.AddrOfPinnedObject().ToInt64()
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: int64) = (var_5 * 4L)
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: uint64) = (var_13 + var_11)
    let (var_15: int64) = (var_8 * 4L)
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: uint64) = (var_16 % 256UL)
    let (var_18: uint64) = (var_16 - var_17)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: EnvStack0) = method_11((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_1: uint64), (var_19: uint64))
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_1((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_28: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_24, var_26, var_27)
    if var_28 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_28)
    var_9.Free()
    EnvStack5((var_20: EnvStack0))
and method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64)): EnvStack0 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env1) = var_1.Peek()
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = (!var_9)
        let (var_11: bool) = (var_10 = 0UL)
        if var_11 then
            let (var_12: Env1) = var_1.Pop()
            let (var_13: EnvStack0) = var_12.mem_0
            let (var_14: uint64) = var_12.mem_1
            method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64))
        else
            method_12((var_10: uint64), (var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_8: uint64))
    else
        method_13((var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>))
and method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack0), (var_7: EnvStack0), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack0), (var_10: EnvStack0), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5), (var_14: EnvStack5), (var_15: int64)): unit =
    let (var_16: bool) = (var_15 < 10L)
    if var_16 then
        System.Console.WriteLine("Training:")
        let (var_17: float) = 0.000000
        let (var_18: int64) = 0L
        let (var_19: Env6) = method_15((var_13: EnvStack5), (var_14: EnvStack5), (var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_6: EnvStack0), (var_7: EnvStack0), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack0), (var_10: EnvStack0), (var_17: float), (var_18: int64))
        let (var_20: float) = var_19.mem_0
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: float) = (var_20 / 60000.000000)
        let (var_22: string) = System.String.Format("Average of batch costs is {0}.",var_21)
        let (var_23: string) = System.String.Format("{0}",var_22)
        System.Console.WriteLine(var_23)
        System.Console.WriteLine("-----")
        let (var_24: bool) = System.Double.IsNaN(var_21)
        if var_24 then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            System.Console.WriteLine("Test:")
            let (var_25: int64) = 0L
            let (var_26: float) = 0.000000
            let (var_27: int64) = 0L
            let (var_28: Env7) = method_33((var_11: EnvStack5), (var_12: EnvStack5), (var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_6: EnvStack0), (var_7: EnvStack0), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack0), (var_10: EnvStack0), (var_25: int64), (var_26: float), (var_27: int64))
            let (var_29: int64) = var_28.mem_0
            let (var_30: float) = var_28.mem_1
            System.Console.WriteLine("-----")
            System.Console.WriteLine("Batch done.")
            let (var_31: float) = (var_30 / 10000.000000)
            let (var_32: string) = System.String.Format("Average of batch costs is {0}.",var_31)
            let (var_33: string) = System.String.Format("{0}",var_32)
            System.Console.WriteLine(var_33)
            let (var_34: float) = (float var_29)
            let (var_35: float) = (var_34 / 10000.000000)
            let (var_36: float) = (var_35 * 100.000000)
            let (var_37: string) = System.String.Format("The accuracy of the batch is {0}/{1}({2}%). ",var_29,10000L,var_36)
            let (var_38: string) = System.String.Format("{0}",var_37)
            System.Console.WriteLine(var_38)
            System.Console.WriteLine("-----")
            let (var_39: int64) = (var_15 + 1L)
            method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack0), (var_7: EnvStack0), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack0), (var_10: EnvStack0), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5), (var_14: EnvStack5), (var_39: int64))
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
and method_12((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_5: uint64)): EnvStack0 =
    let (var_6: uint64) = (var_0 + var_5)
    let (var_7: uint64) = (var_1 + var_2)
    let (var_8: uint64) = (var_7 - var_6)
    let (var_9: bool) = (var_3 <= var_8)
    let (var_10: bool) = (var_9 = false)
    if var_10 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_11: (uint64 ref)) = (ref var_6)
    let (var_12: EnvStack0) = EnvStack0((var_11: (uint64 ref)))
    var_4.Push((Env1(var_12, var_3)))
    var_12
and method_13((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env1>)): EnvStack0 =
    let (var_4: uint64) = (var_0 + var_1)
    let (var_5: uint64) = (var_4 - var_0)
    let (var_6: bool) = (var_2 <= var_5)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_8: (uint64 ref)) = (ref var_0)
    let (var_9: EnvStack0) = EnvStack0((var_8: (uint64 ref)))
    var_3.Push((Env1(var_9, var_2)))
    var_9
and method_15((var_0: EnvStack5), (var_1: EnvStack5), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack0), (var_9: EnvStack0), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: float), (var_14: int64)): Env6 =
    let (var_15: bool) = (var_14 < 60000L)
    if var_15 then
        let (var_16: bool) = System.Double.IsNaN(var_13)
        if var_16 then
            (Env6(var_13))
        else
            let (var_17: int64) = (var_14 + 128L)
            let (var_18: bool) = (60000L > var_17)
            let (var_19: int64) =
                if var_18 then
                    var_17
                else
                    60000L
            let (var_20: bool) = (var_14 < var_19)
            let (var_21: bool) = (var_20 = false)
            if var_21 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_22: bool) = (var_14 >= 0L)
            let (var_23: bool) = (var_22 = false)
            if var_23 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_24: bool) = (var_19 > 0L)
            let (var_26: bool) =
                if var_24 then
                    (var_19 <= 60000L)
                else
                    false
            let (var_27: bool) = (var_26 = false)
            if var_27 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_28: int64) = (var_19 - var_14)
            let (var_29: int64) = (784L * var_14)
            if var_21 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            if var_23 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_31: bool) =
                if var_24 then
                    (var_19 <= 60000L)
                else
                    false
            let (var_32: bool) = (var_31 = false)
            if var_32 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_33: int64) = (10L * var_14)
            let (var_34: EnvStack0) = var_0.mem_0
            let (var_35: bool) = (var_28 > 0L)
            let (var_36: bool) = (var_35 = false)
            if var_36 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_37: int64) = (var_28 * 10L)
            let (var_38: int64) = (var_37 * 4L)
            let (var_39: uint64) = (uint64 var_38)
            let (var_40: uint64) = (var_39 % 256UL)
            let (var_41: uint64) = (var_39 - var_40)
            let (var_42: uint64) = (var_41 + 256UL)
            let (var_43: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_42: uint64))
            let (var_44: int32) = (int32 var_28)
            method_16((var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_44: int32), (var_12: EnvStack0), (var_0: EnvStack5), (var_29: int64), (var_28: int64), (var_43: EnvStack0))
            let (var_45: bool) = (0L < var_28)
            let (var_46: bool) = (var_45 = false)
            if var_46 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_47: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_42: uint64))
            let (var_48: bool) = (var_37 > 0L)
            let (var_49: bool) = (var_48 = false)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_50: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_51: (uint64 ref)) = var_47.mem_0
            let (var_52: uint64) = method_1((var_51: (uint64 ref)))
            let (var_53: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_52)
            let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_53)
            let (var_55: int64) = (10L * var_28)
            let (var_56: int64) = (var_55 * 4L)
            let (var_57: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_56)
            var_2.ClearMemoryAsync(var_54, 0uy, var_57, var_50)
            let (var_58: bool) = (32L > var_28)
            let (var_59: int64) =
                if var_58 then
                    var_28
                else
                    32L
            let (var_60: (uint64 ref)) = var_9.mem_0
            let (var_61: uint64) = method_1((var_60: (uint64 ref)))
            let (var_62: (uint64 ref)) = var_43.mem_0
            let (var_63: uint64) = method_1((var_62: (uint64 ref)))
            let (var_64: uint64) = method_1((var_62: (uint64 ref)))
            // Cuda join point
            // method_17((var_28: int64), (var_61: uint64), (var_63: uint64), (var_64: uint64))
            let (var_65: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_3, var_2)
            let (var_66: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_65.set_GridDimensions(var_66)
            let (var_67: uint32) = (uint32 var_59)
            let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_67, 1u)
            var_65.set_BlockDimensions(var_68)
            let (var_69: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_71: (System.Object [])) = [|var_28; var_61; var_63; var_64|]: (System.Object [])
            var_65.RunAsync(var_69, var_71)
            if var_46 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_76: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_42: uint64))
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_77: uint64) = method_1((var_62: (uint64 ref)))
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_78: (uint64 ref)) = var_76.mem_0
            let (var_79: uint64) = method_1((var_78: (uint64 ref)))
            let (var_80: int64) = (var_37 - 1L)
            let (var_81: int64) = (var_80 / 128L)
            let (var_82: int64) = (var_81 + 1L)
            let (var_83: bool) = (64L > var_82)
            let (var_84: int64) =
                if var_83 then
                    var_82
                else
                    64L
            // Cuda join point
            // method_20((var_77: uint64), (var_37: int64), (var_79: uint64))
            let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_3, var_2)
            let (var_86: uint32) = (uint32 var_84)
            let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_86, 1u, 1u)
            var_85.set_GridDimensions(var_87)
            let (var_88: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_85.set_BlockDimensions(var_88)
            let (var_89: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_91: (System.Object [])) = [|var_77; var_37; var_79|]: (System.Object [])
            var_85.RunAsync(var_89, var_91)
            if var_46 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_92: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_42: uint64))
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_93: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_94: (uint64 ref)) = var_92.mem_0
            let (var_95: uint64) = method_1((var_94: (uint64 ref)))
            let (var_96: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_95)
            let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_96)
            let (var_98: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_56)
            var_2.ClearMemoryAsync(var_97, 0uy, var_98, var_93)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_99: uint64) = method_1((var_78: (uint64 ref)))
            let (var_100: EnvStack0) = var_1.mem_0
            let (var_101: (uint64 ref)) = var_100.mem_0
            let (var_102: uint64) = method_1((var_101: (uint64 ref)))
            let (var_103: int64) = (var_33 * 4L)
            let (var_104: uint64) = (uint64 var_103)
            let (var_105: uint64) = (var_102 + var_104)
            let (var_106: int64) = (var_80 / 256L)
            let (var_107: int64) = (var_106 + 1L)
            let (var_108: bool) = (64L > var_107)
            let (var_109: int64) =
                if var_108 then
                    var_107
                else
                    64L
            let (var_117: bool) = (var_109 > 0L)
            let (var_118: bool) = (var_117 = false)
            if var_118 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_119: int64) = (var_109 * 4L)
            let (var_120: uint64) = (uint64 var_119)
            let (var_121: uint64) = (var_120 % 256UL)
            let (var_122: uint64) = (var_120 - var_121)
            let (var_123: uint64) = (var_122 + 256UL)
            let (var_124: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_123: uint64))
            let (var_125: (uint64 ref)) = var_124.mem_0
            let (var_126: uint64) = method_1((var_125: (uint64 ref)))
            // Cuda join point
            // method_21((var_99: uint64), (var_105: uint64), (var_37: int64), (var_126: uint64), (var_109: int64))
            let (var_127: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_3, var_2)
            let (var_128: uint32) = (uint32 var_109)
            let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_128, 1u, 1u)
            var_127.set_GridDimensions(var_129)
            let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
            var_127.set_BlockDimensions(var_130)
            let (var_131: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_133: (System.Object [])) = [|var_99; var_105; var_37; var_126; var_109|]: (System.Object [])
            var_127.RunAsync(var_131, var_133)
            if var_118 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_134: int64) = 0L
            let (var_135: int64) = 1L
            let (var_136: (float32 [])) = method_23((var_109: int64), (var_124: EnvStack0), (var_134: int64), (var_135: int64))
            let (var_137: bool) = (0L < var_109)
            let (var_138: bool) = (var_137 = false)
            if var_138 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_139: float32) = var_136.[int32 0L]
            let (var_140: int64) = 1L
            let (var_141: float32) = method_24((var_136: (float32 [])), (var_109: int64), (var_139: float32), (var_140: int64))
            var_125 := 0UL
            let (var_142: (float32 ref)) = (ref 0.000000f)
            let (var_143: float32) = (float32 var_28)
            let (var_144: float32) = (var_141 / var_143)
            let (var_145: (float32 ref)) = (ref 0.000000f)
            var_145 := 1.000000f
            let (var_146: float32) = (!var_145)
            let (var_147: float32) = (var_146 / var_143)
            let (var_148: float32) = (!var_142)
            let (var_149: float32) = (var_148 + var_147)
            var_142 := var_149
            let (var_150: float32) = (!var_142)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_151: uint64) = method_1((var_78: (uint64 ref)))
            let (var_152: uint64) = method_1((var_101: (uint64 ref)))
            let (var_153: uint64) = (var_152 + var_104)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_154: uint64) = method_1((var_94: (uint64 ref)))
            let (var_155: int64) =
                if var_83 then
                    var_82
                else
                    64L
            // Cuda join point
            // method_25((var_150: float32), (var_141: float32), (var_151: uint64), (var_153: uint64), (var_37: int64), (var_154: uint64))
            let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_3, var_2)
            let (var_157: uint32) = (uint32 var_155)
            let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_157, 1u, 1u)
            var_156.set_GridDimensions(var_158)
            let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_156.set_BlockDimensions(var_159)
            let (var_160: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_162: (System.Object [])) = [|var_150; var_141; var_151; var_153; var_37; var_154|]: (System.Object [])
            var_156.RunAsync(var_160, var_162)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_163: uint64) = method_1((var_62: (uint64 ref)))
            let (var_164: uint64) = method_1((var_94: (uint64 ref)))
            let (var_165: uint64) = method_1((var_78: (uint64 ref)))
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_166: uint64) = method_1((var_51: (uint64 ref)))
            let (var_167: int64) =
                if var_83 then
                    var_82
                else
                    64L
            // Cuda join point
            // method_26((var_163: uint64), (var_164: uint64), (var_165: uint64), (var_37: int64), (var_166: uint64))
            let (var_168: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_3, var_2)
            let (var_169: uint32) = (uint32 var_167)
            let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_169, 1u, 1u)
            var_168.set_GridDimensions(var_170)
            let (var_171: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_168.set_BlockDimensions(var_171)
            let (var_172: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_174: (System.Object [])) = [|var_163; var_164; var_165; var_37; var_166|]: (System.Object [])
            var_168.RunAsync(var_172, var_174)
            method_27((var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_44: int32), (var_47: EnvStack0), (var_28: int64), (var_0: EnvStack5), (var_29: int64), (var_11: EnvStack0))
            let (var_175: uint64) = method_1((var_51: (uint64 ref)))
            let (var_176: (uint64 ref)) = var_8.mem_0
            let (var_177: uint64) = method_1((var_176: (uint64 ref)))
            // Cuda join point
            // method_28((var_28: int64), (var_175: uint64), (var_177: uint64))
            let (var_178: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_3, var_2)
            let (var_179: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_178.set_GridDimensions(var_179)
            let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_178.set_BlockDimensions(var_180)
            let (var_181: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_183: (System.Object [])) = [|var_28; var_175; var_177|]: (System.Object [])
            var_178.RunAsync(var_181, var_183)
            let (var_184: (uint64 ref)) = var_11.mem_0
            let (var_185: uint64) = method_1((var_184: (uint64 ref)))
            let (var_186: (uint64 ref)) = var_12.mem_0
            let (var_187: uint64) = method_1((var_186: (uint64 ref)))
            // Cuda join point
            // method_30((var_185: uint64), (var_187: uint64))
            let (var_188: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_3, var_2)
            let (var_189: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
            var_188.set_GridDimensions(var_189)
            let (var_190: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_188.set_BlockDimensions(var_190)
            let (var_191: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_193: (System.Object [])) = [|var_185; var_187|]: (System.Object [])
            var_188.RunAsync(var_191, var_193)
            let (var_194: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_195: uint64) = method_1((var_184: (uint64 ref)))
            let (var_196: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_195)
            let (var_197: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_196)
            let (var_198: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
            var_2.ClearMemoryAsync(var_197, 0uy, var_198, var_194)
            let (var_199: uint64) = method_1((var_176: (uint64 ref)))
            let (var_200: uint64) = method_1((var_60: (uint64 ref)))
            // Cuda join point
            // method_32((var_199: uint64), (var_200: uint64))
            let (var_201: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_3, var_2)
            let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_201.set_GridDimensions(var_202)
            let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_201.set_BlockDimensions(var_203)
            let (var_204: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_206: (System.Object [])) = [|var_199; var_200|]: (System.Object [])
            var_201.RunAsync(var_204, var_206)
            let (var_207: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_208: uint64) = method_1((var_176: (uint64 ref)))
            let (var_209: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_208)
            let (var_210: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_209)
            let (var_211: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
            var_2.ClearMemoryAsync(var_210, 0uy, var_211, var_207)
            let (var_212: float) = (float var_144)
            let (var_213: float) = (float var_28)
            let (var_214: float) = (var_212 * var_213)
            let (var_215: float) = (var_13 + var_214)
            var_94 := 0UL
            var_78 := 0UL
            var_51 := 0UL
            var_62 := 0UL
            method_15((var_0: EnvStack5), (var_1: EnvStack5), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack0), (var_9: EnvStack0), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack0), (var_12: EnvStack0), (var_215: float), (var_17: int64))
    else
        (Env6(var_13))
and method_33((var_0: EnvStack5), (var_1: EnvStack5), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack0), (var_9: EnvStack0), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack0), (var_12: EnvStack0), (var_13: int64), (var_14: float), (var_15: int64)): Env7 =
    let (var_16: bool) = (var_15 < 10000L)
    if var_16 then
        let (var_17: bool) = System.Double.IsNaN(var_14)
        if var_17 then
            (Env7(var_13, var_14))
        else
            let (var_18: int64) = (var_15 + 10000L)
            let (var_19: bool) = (var_15 >= 0L)
            let (var_20: bool) = (var_19 = false)
            if var_20 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_21: bool) = (var_18 > 0L)
            let (var_23: bool) =
                if var_21 then
                    (var_18 <= 10000L)
                else
                    false
            let (var_24: bool) = (var_23 = false)
            if var_24 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_25: int64) = (784L * var_15)
            if var_20 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_27: bool) =
                if var_21 then
                    (var_18 <= 10000L)
                else
                    false
            let (var_28: bool) = (var_27 = false)
            if var_28 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_29: int64) = (10L * var_15)
            let (var_30: EnvStack0) = var_0.mem_0
            let (var_31: uint64) = 400128UL
            let (var_32: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_31: uint64))
            method_34((var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_12: EnvStack0), (var_0: EnvStack5), (var_25: int64), (var_32: EnvStack0))
            let (var_33: uint64) = 400128UL
            let (var_34: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_33: uint64))
            let (var_35: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_36: (uint64 ref)) = var_34.mem_0
            let (var_37: uint64) = method_1((var_36: (uint64 ref)))
            let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
            let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_38)
            let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(400000L)
            var_2.ClearMemoryAsync(var_39, 0uy, var_40, var_35)
            let (var_41: (uint64 ref)) = var_9.mem_0
            let (var_42: uint64) = method_1((var_41: (uint64 ref)))
            let (var_43: (uint64 ref)) = var_32.mem_0
            let (var_44: uint64) = method_1((var_43: (uint64 ref)))
            let (var_45: uint64) = method_1((var_43: (uint64 ref)))
            // Cuda join point
            // method_35((var_42: uint64), (var_44: uint64), (var_45: uint64))
            let (var_46: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_3, var_2)
            let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_46.set_GridDimensions(var_47)
            let (var_48: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_46.set_BlockDimensions(var_48)
            let (var_49: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_51: (System.Object [])) = [|var_42; var_44; var_45|]: (System.Object [])
            var_46.RunAsync(var_49, var_51)
            let (var_56: uint64) = 400128UL
            let (var_57: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_56: uint64))
            let (var_58: uint64) = method_1((var_43: (uint64 ref)))
            let (var_59: (uint64 ref)) = var_57.mem_0
            let (var_60: uint64) = method_1((var_59: (uint64 ref)))
            // Cuda join point
            // method_37((var_58: uint64), (var_60: uint64))
            let (var_61: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_3, var_2)
            let (var_62: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_61.set_GridDimensions(var_62)
            let (var_63: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_61.set_BlockDimensions(var_63)
            let (var_64: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_66: (System.Object [])) = [|var_58; var_60|]: (System.Object [])
            var_61.RunAsync(var_64, var_66)
            let (var_67: uint64) = 400128UL
            let (var_68: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_67: uint64))
            let (var_69: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_70: (uint64 ref)) = var_68.mem_0
            let (var_71: uint64) = method_1((var_70: (uint64 ref)))
            let (var_72: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_71)
            let (var_73: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_72)
            let (var_74: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(400000L)
            var_2.ClearMemoryAsync(var_73, 0uy, var_74, var_69)
            let (var_75: uint64) = method_1((var_59: (uint64 ref)))
            let (var_76: EnvStack0) = var_1.mem_0
            let (var_77: (uint64 ref)) = var_76.mem_0
            let (var_78: uint64) = method_1((var_77: (uint64 ref)))
            let (var_79: int64) = (var_29 * 4L)
            let (var_80: uint64) = (uint64 var_79)
            let (var_81: uint64) = (var_78 + var_80)
            let (var_89: uint64) = 512UL
            let (var_90: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_89: uint64))
            let (var_91: (uint64 ref)) = var_90.mem_0
            let (var_92: uint64) = method_1((var_91: (uint64 ref)))
            // Cuda join point
            // method_39((var_75: uint64), (var_81: uint64), (var_92: uint64))
            let (var_93: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_3, var_2)
            let (var_94: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_93.set_GridDimensions(var_94)
            let (var_95: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
            var_93.set_BlockDimensions(var_95)
            let (var_96: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_98: (System.Object [])) = [|var_75; var_81; var_92|]: (System.Object [])
            var_93.RunAsync(var_96, var_98)
            let (var_99: int64) = 64L
            let (var_100: int64) = 0L
            let (var_101: int64) = 1L
            let (var_102: (float32 [])) = method_23((var_99: int64), (var_90: EnvStack0), (var_100: int64), (var_101: int64))
            let (var_103: float32) = var_102.[int32 0L]
            let (var_104: int64) = 1L
            let (var_105: float32) = method_41((var_102: (float32 [])), (var_103: float32), (var_104: int64))
            var_91 := 0UL
            let (var_106: (float32 ref)) = (ref 0.000000f)
            let (var_107: float32) = (var_105 / 10000.000000f)
            let (var_108: (float32 ref)) = (ref 0.000000f)
            let (var_109: float) = (float var_107)
            let (var_110: float) = (var_109 * 10000.000000)
            let (var_111: float) = (var_14 + var_110)
            let (var_112: uint64) = 40192UL
            let (var_113: EnvStack0) = method_11((var_5: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_6: uint64), (var_112: uint64))
            let (var_114: uint64) = method_1((var_59: (uint64 ref)))
            let (var_115: uint64) = method_1((var_77: (uint64 ref)))
            let (var_116: uint64) = (var_115 + var_80)
            let (var_117: (uint64 ref)) = var_113.mem_0
            let (var_118: uint64) = method_1((var_117: (uint64 ref)))
            // Cuda join point
            // method_42((var_114: uint64), (var_116: uint64), (var_118: uint64))
            let (var_119: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_42", var_3, var_2)
            let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
            var_119.set_GridDimensions(var_120)
            let (var_121: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_119.set_BlockDimensions(var_121)
            let (var_122: ManagedCuda.BasicTypes.CUstream) = var_4.get_Stream()
            let (var_124: (System.Object [])) = [|var_114; var_116; var_118|]: (System.Object [])
            var_119.RunAsync(var_122, var_124)
            let (var_125: int64) = 0L
            let (var_126: int64) = 10000L
            let (var_127: int64) = 0L
            let (var_128: int64) = 1L
            let (var_129: (float32 [])) = method_23((var_126: int64), (var_113: EnvStack0), (var_127: int64), (var_128: int64))
            let (var_130: int64) = var_129.LongLength
            let (var_131: int64) = 0L
            let (var_132: int64) = method_45((var_129: (float32 [])), (var_130: int64), (var_125: int64), (var_131: int64))
            var_117 := 0UL
            let (var_133: int64) = (var_13 + var_132)
            var_70 := 0UL
            var_59 := 0UL
            var_36 := 0UL
            var_43 := 0UL
            method_33((var_0: EnvStack5), (var_1: EnvStack5), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack0), (var_9: EnvStack0), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack0), (var_12: EnvStack0), (var_133: int64), (var_111: float), (var_18: int64))
    else
        (Env7(var_13, var_14))
and method_16((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: EnvStack0), (var_3: EnvStack5), (var_4: int64), (var_5: int64), (var_6: EnvStack0)): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: (uint64 ref)) = var_2.mem_0
    let (var_11: uint64) = method_1((var_10: (uint64 ref)))
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_11)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: int64) = (var_5 * 784L)
    let (var_15: bool) = (var_14 > 0L)
    let (var_16: bool) = (var_15 = false)
    if var_16 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_17: EnvStack0) = var_3.mem_0
    let (var_18: (uint64 ref)) = var_17.mem_0
    let (var_19: uint64) = method_1((var_18: (uint64 ref)))
    let (var_20: int64) = (var_4 * 4L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_19 + var_21)
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 0.000000f)
    let (var_26: int64) = (var_5 * 10L)
    let (var_27: bool) = (var_26 > 0L)
    let (var_28: bool) = (var_27 = false)
    if var_28 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_29: (uint64 ref)) = var_6.mem_0
    let (var_30: uint64) = method_1((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, 10, var_1, 784, var_9, var_13, 10, var_24, 784, var_25, var_32, 10)
    if var_33 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_33)
and method_23((var_0: int64), (var_1: EnvStack0), (var_2: int64), (var_3: int64)): (float32 []) =
    let (var_4: int64) = (var_0 * var_3)
    let (var_5: (uint64 ref)) = var_1.mem_0
    let (var_6: uint64) = method_1((var_5: (uint64 ref)))
    let (var_7: int64) = (var_2 * 4L)
    let (var_8: uint64) = (uint64 var_7)
    let (var_9: uint64) = (var_6 + var_8)
    let (var_10: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_4))
    let (var_11: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_10,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_12: int64) = var_11.AddrOfPinnedObject().ToInt64()
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: int64) = (var_4 * 4L)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_9)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_20: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_16, var_18, var_19)
    if var_20 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_20)
    var_11.Free()
    var_10
and method_24((var_0: (float32 [])), (var_1: int64), (var_2: float32), (var_3: int64)): float32 =
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
        method_24((var_0: (float32 [])), (var_1: int64), (var_8: float32), (var_9: int64))
    else
        var_2
and method_27((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: EnvStack0), (var_3: int64), (var_4: EnvStack5), (var_5: int64), (var_6: EnvStack0)): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: int64) = (var_3 * 10L)
    let (var_11: bool) = (var_10 > 0L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_13: (uint64 ref)) = var_2.mem_0
    let (var_14: uint64) = method_1((var_13: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: int64) = (var_3 * 784L)
    let (var_18: bool) = (var_17 > 0L)
    let (var_19: bool) = (var_18 = false)
    if var_19 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_20: EnvStack0) = var_4.mem_0
    let (var_21: (uint64 ref)) = var_20.mem_0
    let (var_22: uint64) = method_1((var_21: (uint64 ref)))
    let (var_23: int64) = (var_5 * 4L)
    let (var_24: uint64) = (uint64 var_23)
    let (var_25: uint64) = (var_22 + var_24)
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: (float32 ref)) = (ref 1.000000f)
    let (var_29: (uint64 ref)) = var_6.mem_0
    let (var_30: uint64) = method_1((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, 10, 784, var_1, var_9, var_16, 10, var_27, 784, var_28, var_32, 10)
    if var_33 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_33)
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack0), (var_2: EnvStack5), (var_3: int64), (var_4: EnvStack0)): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: (uint64 ref)) = var_1.mem_0
    let (var_9: uint64) = method_1((var_8: (uint64 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_9)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    let (var_12: EnvStack0) = var_2.mem_0
    let (var_13: (uint64 ref)) = var_12.mem_0
    let (var_14: uint64) = method_1((var_13: (uint64 ref)))
    let (var_15: int64) = (var_3 * 4L)
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: uint64) = (var_14 + var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (float32 ref)) = (ref 0.000000f)
    let (var_21: (uint64 ref)) = var_4.mem_0
    let (var_22: uint64) = method_1((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 10, 10000, 784, var_7, var_11, 10, var_19, 784, var_20, var_24, 10)
    if var_25 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_25)
and method_41((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
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
        method_41((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_45((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: float32) = var_0.[int32 var_3]
        let (var_6: bool) = (var_5 = 1.000000f)
        let (var_8: int64) =
            if var_6 then
                (var_2 + 1L)
            else
                var_2
        let (var_9: int64) = (var_3 + 1L)
        method_45((var_0: (float32 [])), (var_1: int64), (var_8: int64), (var_9: int64))
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
let (var_35: ManagedCuda.BasicTypes.SizeT) = var_1.GetFreeDeviceMemorySize()
let (var_36: int64) = int64 var_35
let (var_37: float) = float var_36
let (var_38: float) = (0.700000 * var_37)
let (var_39: uint64) = uint64 var_38
let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_40)
let (var_42: uint64) = uint64 var_41
let (var_43: (uint64 ref)) = (ref var_42)
let (var_44: EnvStack0) = EnvStack0((var_43: (uint64 ref)))
let (var_45: System.Collections.Generic.Stack<Env1>) = System.Collections.Generic.Stack<Env1>()
let (var_46: (uint64 ref)) = var_44.mem_0
let (var_47: uint64) = method_1((var_46: (uint64 ref)))
let (var_48: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_49: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_50: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_49)
let (var_51: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
var_50.SetStream(var_51)
let (var_52: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_53: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_54: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_52, var_53)
let (var_55: ManagedCuda.CudaBlas.CudaBlasHandle) = var_54.get_CublasHandle()
let (var_56: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
var_54.set_Stream(var_56)
let (var_57: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_58: Tuple2) = method_2((var_57: string))
let (var_59: Tuple3) = var_58.mem_0
let (var_60: (uint8 [])) = var_58.mem_1
let (var_61: int64) = var_59.mem_0
let (var_62: int64) = var_59.mem_1
let (var_63: int64) = var_59.mem_2
let (var_64: bool) = (10000L = var_61)
let (var_68: bool) =
    if var_64 then
        let (var_65: bool) = (28L = var_62)
        if var_65 then
            (28L = var_63)
        else
            false
    else
        false
let (var_69: bool) = (var_68 = false)
if var_69 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_70: int64) = var_60.LongLength
let (var_71: bool) = (var_70 > 0L)
let (var_72: bool) = (var_71 = false)
if var_72 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_76: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_77: int64) = 0L
method_3((var_60: (uint8 [])), (var_76: (float32 [])), (var_77: int64))
let (var_78: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_79: Tuple4) = method_5((var_78: string))
let (var_80: int64) = var_79.mem_0
let (var_81: (uint8 [])) = var_79.mem_1
let (var_82: bool) = (10000L = var_80)
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_87: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_88: int64) = 0L
method_6((var_81: (uint8 [])), (var_87: (float32 [])), (var_88: int64))
let (var_89: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_90: Tuple2) = method_2((var_89: string))
let (var_91: Tuple3) = var_90.mem_0
let (var_92: (uint8 [])) = var_90.mem_1
let (var_93: int64) = var_91.mem_0
let (var_94: int64) = var_91.mem_1
let (var_95: int64) = var_91.mem_2
let (var_96: bool) = (60000L = var_93)
let (var_100: bool) =
    if var_96 then
        let (var_97: bool) = (28L = var_94)
        if var_97 then
            (28L = var_95)
        else
            false
    else
        false
let (var_101: bool) = (var_100 = false)
if var_101 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_102: int64) = var_92.LongLength
let (var_103: bool) = (var_102 > 0L)
let (var_104: bool) = (var_103 = false)
if var_104 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_108: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_109: int64) = 0L
method_8((var_92: (uint8 [])), (var_108: (float32 [])), (var_109: int64))
let (var_110: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_111: Tuple4) = method_5((var_110: string))
let (var_112: int64) = var_111.mem_0
let (var_113: (uint8 [])) = var_111.mem_1
let (var_114: bool) = (60000L = var_112)
let (var_115: bool) = (var_114 = false)
if var_115 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_119: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_120: int64) = 0L
method_9((var_113: (uint8 [])), (var_119: (float32 [])), (var_120: int64))
let (var_121: int64) = 10000L
let (var_122: int64) = 0L
let (var_123: int64) = 784L
let (var_124: int64) = 1L
let (var_125: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_121: int64), (var_76: (float32 [])), (var_122: int64), (var_123: int64), (var_124: int64))
let (var_126: int64) = 10000L
let (var_127: int64) = 0L
let (var_128: int64) = 10L
let (var_129: int64) = 1L
let (var_130: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_126: int64), (var_87: (float32 [])), (var_127: int64), (var_128: int64), (var_129: int64))
let (var_131: int64) = 60000L
let (var_132: int64) = 0L
let (var_133: int64) = 784L
let (var_134: int64) = 1L
let (var_135: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_131: int64), (var_108: (float32 [])), (var_132: int64), (var_133: int64), (var_134: int64))
let (var_136: int64) = 60000L
let (var_137: int64) = 0L
let (var_138: int64) = 10L
let (var_139: int64) = 1L
let (var_140: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_136: int64), (var_119: (float32 [])), (var_137: int64), (var_138: int64), (var_139: int64))
let (var_141: uint64) = 31488UL
let (var_142: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_141: uint64))
let (var_143: (uint64 ref)) = var_142.mem_0
let (var_144: uint64) = method_1((var_143: (uint64 ref)))
let (var_145: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
let (var_146: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_144)
let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_146)
var_50.GenerateNormal32(var_147, var_145, 0.000000f, 0.050189f)
let (var_148: uint64) = 31488UL
let (var_149: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_148: uint64))
let (var_150: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_151: (uint64 ref)) = var_149.mem_0
let (var_152: uint64) = method_1((var_151: (uint64 ref)))
let (var_153: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_152)
let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_153)
let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_154, 0uy, var_155, var_150)
let (var_156: uint64) = 256UL
let (var_157: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_156: uint64))
let (var_158: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_159: (uint64 ref)) = var_157.mem_0
let (var_160: uint64) = method_1((var_159: (uint64 ref)))
let (var_161: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_160)
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_161)
let (var_163: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_162, 0uy, var_163, var_158)
let (var_164: uint64) = 256UL
let (var_165: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_164: uint64))
let (var_166: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_167: (uint64 ref)) = var_165.mem_0
let (var_168: uint64) = method_1((var_167: (uint64 ref)))
let (var_169: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_168)
let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_169)
let (var_171: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_170, 0uy, var_171, var_166)
let (var_172: int64) = 0L
method_14((var_1: ManagedCuda.CudaContext), (var_48: ManagedCuda.CudaStream), (var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_165: EnvStack0), (var_157: EnvStack0), (var_55: ManagedCuda.CudaBlas.CudaBlasHandle), (var_149: EnvStack0), (var_142: EnvStack0), (var_125: EnvStack5), (var_130: EnvStack5), (var_135: EnvStack5), (var_140: EnvStack5), (var_172: int64))
var_167 := 0UL
var_159 := 0UL
var_151 := 0UL
var_143 := 0UL
var_54.Dispose()
var_50.Dispose()
var_48.Dispose()
let (var_173: uint64) = method_1((var_46: (uint64 ref)))
let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_173)
let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_174)
var_1.FreeMemory(var_175)
var_46 := 0UL
var_1.Dispose()

