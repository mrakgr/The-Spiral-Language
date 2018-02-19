module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_27(long long int var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_30(float * var_0, long long int var_1, float * var_2);
    __global__ void method_31(float * var_0, float * var_1, long long int var_2, float * var_3);
    __global__ void method_33(float * var_0, long long int var_1, float var_2, float * var_3);
    __global__ void method_35(float var_0, float * var_1, float * var_2, float * var_3, float * var_4, long long int var_5, float * var_6);
    __global__ void method_36(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4);
    __global__ void method_38(long long int var_0, float * var_1, float * var_2);
    __global__ void method_40(float * var_0, float * var_1);
    __global__ void method_42(float * var_0, float * var_1);
    __device__ char method_28(long long int * var_0);
    __device__ char method_29(long long int var_0, long long int * var_1);
    __device__ char method_32(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_39(long long int * var_0, float * var_1);
    __device__ char method_41(long long int * var_0);
    
    __global__ void method_27(long long int var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = blockDim.y;
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (10 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_28(var_9)) {
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
            while (method_29(var_0, var_20)) {
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
    __global__ void method_30(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = gridDim.x;
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8 = (var_3 * 128);
        long long int var_9[1];
        var_9[0] = var_7;
        while (method_29(var_1, var_9)) {
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
    __global__ void method_31(float * var_0, float * var_1, long long int var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (256 * var_5);
        long long int var_7 = (var_4 + var_6);
        float var_8 = 0;
        long long int var_9[1];
        float var_10[1];
        var_9[0] = var_7;
        var_10[0] = var_8;
        while (method_32(var_2, var_9, var_10)) {
            long long int var_12 = var_9[0];
            float var_13 = var_10[0];
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < var_2);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_0[var_12];
            float var_19 = var_1[var_12];
            float var_20 = log(var_18);
            float var_21 = (var_19 * var_20);
            float var_22 = (1 - var_19);
            float var_23 = (1 - var_18);
            float var_24 = log(var_23);
            float var_25 = (var_22 * var_24);
            float var_26 = (var_21 + var_25);
            float var_27 = (-var_26);
            float var_28 = (var_13 + var_27);
            long long int var_29 = (var_12 + 16384);
            var_9[0] = var_29;
            var_10[0] = var_28;
        }
        long long int var_30 = var_9[0];
        float var_31 = var_10[0];
        float var_32 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_31);
        long long int var_33 = threadIdx.x;
        char var_34 = (var_33 == 0);
        if (var_34) {
            long long int var_35 = blockIdx.x;
            char var_36 = (var_35 >= 0);
            char var_38;
            if (var_36) {
                var_38 = (var_35 < 64);
            } else {
                var_38 = 0;
            }
            char var_39 = (var_38 == 0);
            if (var_39) {
                // "Argument out of bounds."
            } else {
            }
            var_3[var_35] = var_32;
        } else {
        }
    }
    __global__ void method_33(float * var_0, long long int var_1, float var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (64 * var_5);
        long long int var_7 = (var_4 + var_6);
        float var_8 = 0;
        long long int var_9[1];
        float var_10[1];
        var_9[0] = var_7;
        var_10[0] = var_8;
        while (method_32(var_1, var_9, var_10)) {
            long long int var_12 = var_9[0];
            float var_13 = var_10[0];
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 64);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_0[var_12];
            float var_19 = (var_13 + var_18);
            long long int var_20 = (var_12 + 64);
            var_9[0] = var_20;
            var_10[0] = var_19;
        }
        long long int var_21 = var_9[0];
        float var_22 = var_10[0];
        float var_23 = cub::BlockReduce<float,64,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_22);
        float var_24 = (var_23 / var_2);
        long long int var_25 = threadIdx.x;
        char var_26 = (var_25 == 0);
        if (var_26) {
            long long int var_27 = blockIdx.x;
            char var_28 = (var_27 >= 0);
            char var_30;
            if (var_28) {
                var_30 = (var_27 < 1);
            } else {
                var_30 = 0;
            }
            char var_31 = (var_30 == 0);
            if (var_31) {
                // "Argument out of bounds."
            } else {
            }
            var_3[var_27] = var_24;
        } else {
        }
    }
    __global__ void method_35(float var_0, float * var_1, float * var_2, float * var_3, float * var_4, long long int var_5, float * var_6) {
        long long int var_7 = gridDim.x;
        long long int var_8 = threadIdx.x;
        long long int var_9 = blockIdx.x;
        long long int var_10 = (128 * var_9);
        long long int var_11 = (var_8 + var_10);
        long long int var_12 = (var_7 * 128);
        long long int var_13[1];
        var_13[0] = var_11;
        while (method_29(var_5, var_13)) {
            long long int var_15 = var_13[0];
            char var_16 = (var_15 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_15 < var_5);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            char var_21;
            if (var_16) {
                var_21 = (var_15 < var_5);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            float var_23 = var_3[var_15];
            float var_24 = var_4[var_15];
            float var_25 = var_6[var_15];
            float var_26 = var_1[0];
            float var_27 = var_2[0];
            float var_28 = (var_23 - var_24);
            float var_29 = (1 - var_23);
            float var_30 = (var_23 * var_29);
            float var_31 = (var_28 / var_30);
            float var_32 = (var_26 * var_31);
            float var_33 = (var_32 / var_0);
            float var_34 = (var_25 + var_33);
            var_6[var_15] = var_34;
            long long int var_35 = (var_15 + var_12);
            var_13[0] = var_35;
        }
        long long int var_36 = var_13[0];
    }
    __global__ void method_36(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4) {
        long long int var_5 = gridDim.x;
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10 = (var_5 * 128);
        long long int var_11[1];
        var_11[0] = var_9;
        while (method_29(var_3, var_11)) {
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
    __global__ void method_38(long long int var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_28(var_7)) {
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
            while (method_32(var_0, var_22, var_23)) {
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
            while (method_39(var_42, var_43)) {
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
                    while (method_32(var_45, var_70, var_71)) {
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
    __global__ void method_40(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_41(var_6)) {
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
    __global__ void method_42(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_28(var_6)) {
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
    __device__ char method_28(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_29(long long int var_0, long long int * var_1) {
        long long int var_2 = var_1[0];
        return (var_2 < var_0);
    }
    __device__ char method_32(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_39(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_41(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 7840);
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
and EnvHeap2 =
    {
    mem_0: (int64 ref)
    mem_1: EnvStack0
    }
and EnvHeap3 =
    {
    mem_0: (int64 ref)
    mem_1: EnvHeap4
    }
and EnvHeap4 =
    {
    mem_0: (bool ref)
    mem_1: ManagedCuda.CudaStream
    }
and Tuple5 =
    struct
    val mem_0: Tuple6
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple6 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple7 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack8 =
    struct
    val mem_0: EnvHeap2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap9 =
    {
    mem_0: ResizeArray<Env1>
    mem_1: EnvStack0
    mem_2: uint64
    mem_3: ResizeArray<Env1>
    }
and Env10 =
    struct
    val mem_0: float
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>)): unit =
    let (var_5: (Env1 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env1 -> (Env1 -> int32))) = method_3
    let (var_9: System.Comparison<Env1>) = System.Comparison<Env1>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: (uint64 ref)) = var_1.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: int32) = 0
    let (var_14: uint64) = method_6((var_0: ResizeArray<Env1>), (var_3: ResizeArray<Env1>), (var_10: int32), (var_12: uint64), (var_13: int32))
    let (var_15: uint64) = method_5((var_11: (uint64 ref)))
    let (var_16: uint64) = (var_15 + var_2)
    let (var_17: uint64) = (var_16 - var_14)
    let (var_18: uint64) = (var_14 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: uint64) = (var_20 - var_14)
    let (var_22: bool) = (var_17 > var_21)
    if var_22 then
        let (var_23: (uint64 ref)) = (ref var_20)
        let (var_24: EnvStack0) = EnvStack0((var_23: (uint64 ref)))
        let (var_25: uint64) = (var_17 - var_21)
        var_0.Add((Env1(var_24, var_25)))
    else
        ()
and method_7((var_0: EnvHeap4), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ResizeArray<Env1>), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap2>), (var_9: ResizeArray<EnvHeap3>), (var_10: ManagedCuda.BasicTypes.CUmodule)): EnvHeap3 =
    let (var_11: (int64 ref)) = (ref 0L)
    let (var_12: EnvHeap3) = ({mem_0 = (var_11: (int64 ref)); mem_1 = (var_0: EnvHeap4)} : EnvHeap3)
    method_8((var_12: EnvHeap3), (var_9: ResizeArray<EnvHeap3>))
    var_12
and method_9((var_0: string)): Tuple5 =
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
    Tuple5(Tuple6(var_16, var_17, var_18), var_22)
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
and method_12((var_0: string)): Tuple7 =
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
    Tuple7(var_12, var_14)
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
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_11: int64), (var_12: (float32 [])), (var_13: int64), (var_14: int64), (var_15: int64)): EnvStack8 =
    let (var_16: int64) = (var_11 * var_14)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: int64) = (var_13 * 4L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_21 + var_19)
    let (var_23: int64) = (var_16 * 4L)
    let (var_24: EnvHeap9) = ({mem_0 = (var_2: ResizeArray<Env1>); mem_1 = (var_3: EnvStack0); mem_2 = (var_4: uint64); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    let (var_25: EnvHeap2) = method_18((var_24: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_23: int64))
    let (var_26: EnvStack8) = EnvStack8((var_25: EnvHeap2))
    let (var_27: EnvHeap2) = var_26.mem_0
    let (var_28: (int64 ref)) = var_27.mem_0
    let (var_29: EnvStack0) = var_27.mem_1
    let (var_30: (uint64 ref)) = var_29.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_31)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_34)
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_37: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_33, var_35, var_36)
    if var_37 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_37)
    var_17.Free()
    var_26
and method_18((var_0: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ResizeArray<Env1>), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap2>), (var_9: ResizeArray<EnvHeap3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap3), (var_12: int64)): EnvHeap2 =
    let (var_13: ResizeArray<Env1>) = var_0.mem_0
    let (var_14: EnvStack0) = var_0.mem_1
    let (var_15: uint64) = var_0.mem_2
    let (var_16: ResizeArray<Env1>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_19((var_13: ResizeArray<Env1>), (var_14: EnvStack0), (var_15: uint64), (var_16: ResizeArray<Env1>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap2) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap2)
    method_22((var_23: EnvHeap2), (var_8: ResizeArray<EnvHeap2>))
    var_23
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_23((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_24((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: int64)): unit =
    let (var_18: bool) = (var_17 < 1L)
    if var_18 then
        System.Console.WriteLine("Training:")
        let (var_19: float) = 0.000000
        let (var_20: int64) = 0L
        let (var_21: Env10) = method_25((var_15: EnvStack8), (var_16: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_19: float), (var_20: int64))
        let (var_22: float) = var_21.mem_0
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_23: float) = (var_22 / 60000.000000)
        let (var_24: string) = System.String.Format("Average of batch costs is {0}.",var_23)
        let (var_25: string) = System.String.Format("{0}",var_24)
        System.Console.WriteLine(var_25)
        System.Console.WriteLine("-----")
    else
        ()
and method_46((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_47
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_44((var_0: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (EnvHeap2 -> unit)) = method_45
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env1)): bool =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_4((var_1: EnvStack0))
and method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env1) = var_1.[var_4]
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: bool) = (var_10 >= var_3)
        let (var_12: bool) = (var_11 = false)
        if var_12 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_13: uint64) = method_5((var_9: (uint64 ref)))
        let (var_14: uint64) = (var_13 - var_3)
        let (var_15: uint64) = (var_3 + 256UL)
        let (var_16: uint64) = (var_15 - 1UL)
        let (var_17: uint64) = (var_16 &&& 18446744073709551360UL)
        let (var_18: uint64) = (var_17 - var_3)
        let (var_19: bool) = (var_14 > var_18)
        if var_19 then
            let (var_20: (uint64 ref)) = (ref var_17)
            let (var_21: EnvStack0) = EnvStack0((var_20: (uint64 ref)))
            let (var_22: uint64) = (var_14 - var_18)
            var_0.Add((Env1(var_21, var_22)))
        else
            ()
        let (var_23: uint64) = method_5((var_9: (uint64 ref)))
        let (var_24: uint64) = (var_23 + var_8)
        let (var_25: int32) = (var_4 + 1)
        method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_24: uint64), (var_25: int32))
    else
        var_3
and method_8((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvHeap4) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
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
and method_19((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): EnvStack0 =
    let (var_5: int32) = var_0.get_Count()
    let (var_6: bool) = (var_5 > 0)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_8: Env1) = var_0.[0]
    let (var_9: EnvStack0) = var_8.mem_0
    let (var_10: uint64) = var_8.mem_1
    let (var_11: bool) = (var_4 <= var_10)
    let (var_47: Env1) =
        if var_11 then
            let (var_12: (uint64 ref)) = var_9.mem_0
            let (var_13: uint64) = (!var_12)
            let (var_14: uint64) = (var_13 + var_4)
            let (var_15: (uint64 ref)) = (ref var_14)
            let (var_16: EnvStack0) = EnvStack0((var_15: (uint64 ref)))
            let (var_17: uint64) = (var_10 - var_4)
            var_0.[0] <- (Env1(var_16, var_17))
            (Env1(var_9, var_4))
        else
            let (var_19: (Env1 -> (Env1 -> int32))) = method_20
            let (var_20: System.Comparison<Env1>) = System.Comparison<Env1>(var_19)
            var_0.Sort(var_20)
            let (var_21: Env1) = var_0.[0]
            let (var_22: EnvStack0) = var_21.mem_0
            let (var_23: uint64) = var_21.mem_1
            let (var_24: bool) = (var_4 <= var_23)
            if var_24 then
                let (var_25: (uint64 ref)) = var_22.mem_0
                let (var_26: uint64) = (!var_25)
                let (var_27: uint64) = (var_26 + var_4)
                let (var_28: (uint64 ref)) = (ref var_27)
                let (var_29: EnvStack0) = EnvStack0((var_28: (uint64 ref)))
                let (var_30: uint64) = (var_23 - var_4)
                var_0.[0] <- (Env1(var_29, var_30))
                (Env1(var_22, var_4))
            else
                method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_32: (Env1 -> (Env1 -> int32))) = method_20
                let (var_33: System.Comparison<Env1>) = System.Comparison<Env1>(var_32)
                var_0.Sort(var_33)
                let (var_34: Env1) = var_0.[0]
                let (var_35: EnvStack0) = var_34.mem_0
                let (var_36: uint64) = var_34.mem_1
                let (var_37: bool) = (var_4 <= var_36)
                if var_37 then
                    let (var_38: (uint64 ref)) = var_35.mem_0
                    let (var_39: uint64) = (!var_38)
                    let (var_40: uint64) = (var_39 + var_4)
                    let (var_41: (uint64 ref)) = (ref var_40)
                    let (var_42: EnvStack0) = EnvStack0((var_41: (uint64 ref)))
                    let (var_43: uint64) = (var_36 - var_4)
                    var_0.[0] <- (Env1(var_42, var_43))
                    (Env1(var_35, var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_48: EnvStack0) = var_47.mem_0
    let (var_49: uint64) = var_47.mem_1
    var_3.Add((Env1(var_48, var_49)))
    var_48
and method_22((var_0: EnvHeap2), (var_1: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_25((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_17: float), (var_18: int64)): Env10 =
    let (var_19: bool) = (var_18 < 60000L)
    if var_19 then
        let (var_20: bool) = System.Double.IsNaN(var_17)
        if var_20 then
            (Env10(var_17))
        else
            let (var_21: int64) = (var_18 + 128L)
            let (var_22: bool) = (60000L > var_21)
            let (var_23: int64) =
                if var_22 then
                    var_21
                else
                    60000L
            let (var_24: bool) = (var_18 < var_23)
            let (var_25: bool) = (var_24 = false)
            if var_25 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_26: bool) = (var_18 >= 0L)
            let (var_27: bool) = (var_26 = false)
            if var_27 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_28: bool) = (var_23 > 0L)
            let (var_30: bool) =
                if var_28 then
                    (var_23 <= 60000L)
                else
                    false
            let (var_31: bool) = (var_30 = false)
            if var_31 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_32: int64) = (var_23 - var_18)
            let (var_33: int64) = (784L * var_18)
            if var_25 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            if var_27 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_35: bool) =
                if var_28 then
                    (var_23 <= 60000L)
                else
                    false
            let (var_36: bool) = (var_35 = false)
            if var_36 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_37: int64) = (10L * var_18)
            let (var_46: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
            let (var_47: EnvHeap2) = var_0.mem_0
            let (var_48: bool) = (var_32 > 0L)
            let (var_49: bool) = (var_48 = false)
            if var_49 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_50: int64) = (var_32 * 10L)
            let (var_51: int64) = (var_50 * 4L)
            let (var_52: EnvHeap9) = ({mem_0 = (var_8: ResizeArray<Env1>); mem_1 = (var_9: EnvStack0); mem_2 = (var_10: uint64); mem_3 = (var_11: ResizeArray<Env1>)} : EnvHeap9)
            let (var_53: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_51: int64))
            let (var_54: EnvStack8) = EnvStack8((var_53: EnvHeap2))
            let (var_55: int32) = (int32 var_32)
            method_26((var_55: int32), (var_5: EnvStack8), (var_0: EnvStack8), (var_33: int64), (var_32: int64), (var_54: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3))
            let (var_56: EnvHeap2) = var_54.mem_0
            let (var_57: bool) = (0L < var_32)
            let (var_58: bool) = (var_57 = false)
            if var_58 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_59: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_51: int64))
            let (var_60: EnvStack8) = EnvStack8((var_59: EnvHeap2))
            let (var_61: bool) = (var_50 > 0L)
            let (var_62: bool) = (var_61 = false)
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_63: (int64 ref)) = var_16.mem_0
            let (var_64: EnvHeap4) = var_16.mem_1
            let (var_65: (bool ref)) = var_64.mem_0
            let (var_66: ManagedCuda.CudaStream) = var_64.mem_1
            let (var_67: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_68: EnvHeap2) = var_60.mem_0
            let (var_69: (int64 ref)) = var_68.mem_0
            let (var_70: EnvStack0) = var_68.mem_1
            let (var_71: (uint64 ref)) = var_70.mem_0
            let (var_72: uint64) = method_5((var_71: (uint64 ref)))
            let (var_73: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_72)
            let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_73)
            let (var_75: int64) = (10L * var_32)
            let (var_76: int64) = (var_75 * 4L)
            let (var_77: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_76)
            var_12.ClearMemoryAsync(var_74, 0uy, var_77, var_67)
            let (var_78: bool) = (32L > var_32)
            let (var_79: int64) =
                if var_78 then
                    var_32
                else
                    32L
            let (var_80: EnvHeap2) = var_3.mem_0
            let (var_81: (int64 ref)) = var_80.mem_0
            let (var_82: EnvStack0) = var_80.mem_1
            let (var_83: (uint64 ref)) = var_82.mem_0
            let (var_84: uint64) = method_5((var_83: (uint64 ref)))
            let (var_85: (int64 ref)) = var_56.mem_0
            let (var_86: EnvStack0) = var_56.mem_1
            let (var_87: (uint64 ref)) = var_86.mem_0
            let (var_88: uint64) = method_5((var_87: (uint64 ref)))
            let (var_89: uint64) = method_5((var_87: (uint64 ref)))
            // Cuda join point
            // method_27((var_32: int64), (var_84: uint64), (var_88: uint64), (var_89: uint64))
            let (var_90: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_15, var_12)
            let (var_91: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_90.set_GridDimensions(var_91)
            let (var_92: uint32) = (uint32 var_79)
            let (var_93: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_92, 1u)
            var_90.set_BlockDimensions(var_93)
            let (var_94: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_96: (System.Object [])) = [|var_32; var_84; var_88; var_89|]: (System.Object [])
            var_90.RunAsync(var_94, var_96)
            if var_58 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_101: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_51: int64))
            let (var_102: EnvStack8) = EnvStack8((var_101: EnvHeap2))
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_103: uint64) = method_5((var_87: (uint64 ref)))
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_104: EnvHeap2) = var_102.mem_0
            let (var_105: (int64 ref)) = var_104.mem_0
            let (var_106: EnvStack0) = var_104.mem_1
            let (var_107: (uint64 ref)) = var_106.mem_0
            let (var_108: uint64) = method_5((var_107: (uint64 ref)))
            let (var_109: int64) = (var_50 - 1L)
            let (var_110: int64) = (var_109 / 128L)
            let (var_111: int64) = (var_110 + 1L)
            let (var_112: bool) = (64L > var_111)
            let (var_113: int64) =
                if var_112 then
                    var_111
                else
                    64L
            // Cuda join point
            // method_30((var_103: uint64), (var_50: int64), (var_108: uint64))
            let (var_114: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_15, var_12)
            let (var_115: uint32) = (uint32 var_113)
            let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_115, 1u, 1u)
            var_114.set_GridDimensions(var_116)
            let (var_117: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_114.set_BlockDimensions(var_117)
            let (var_118: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_120: (System.Object [])) = [|var_103; var_50; var_108|]: (System.Object [])
            var_114.RunAsync(var_118, var_120)
            if var_58 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_121: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_51: int64))
            let (var_122: EnvStack8) = EnvStack8((var_121: EnvHeap2))
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_123: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_124: EnvHeap2) = var_122.mem_0
            let (var_125: (int64 ref)) = var_124.mem_0
            let (var_126: EnvStack0) = var_124.mem_1
            let (var_127: (uint64 ref)) = var_126.mem_0
            let (var_128: uint64) = method_5((var_127: (uint64 ref)))
            let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_128)
            let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_129)
            let (var_131: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_76)
            var_12.ClearMemoryAsync(var_130, 0uy, var_131, var_123)
            let (var_132: float32) = (float32 var_32)
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_133: int64) = (var_109 / 256L)
            let (var_134: int64) = (var_133 + 1L)
            let (var_143: uint64) = method_5((var_107: (uint64 ref)))
            let (var_144: EnvHeap2) = var_1.mem_0
            let (var_145: (int64 ref)) = var_144.mem_0
            let (var_146: EnvStack0) = var_144.mem_1
            let (var_147: (uint64 ref)) = var_146.mem_0
            let (var_148: uint64) = method_5((var_147: (uint64 ref)))
            let (var_149: int64) = (var_37 * 4L)
            let (var_150: uint64) = (uint64 var_149)
            let (var_151: uint64) = (var_148 + var_150)
            let (var_159: int64) = 256L
            let (var_160: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_159: int64))
            let (var_161: EnvStack8) = EnvStack8((var_160: EnvHeap2))
            let (var_162: EnvHeap2) = var_161.mem_0
            let (var_163: (int64 ref)) = var_162.mem_0
            let (var_164: EnvStack0) = var_162.mem_1
            let (var_165: (uint64 ref)) = var_164.mem_0
            let (var_166: uint64) = method_5((var_165: (uint64 ref)))
            // Cuda join point
            // method_31((var_143: uint64), (var_151: uint64), (var_50: int64), (var_166: uint64))
            let (var_167: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_15, var_12)
            let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_167.set_GridDimensions(var_168)
            let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
            var_167.set_BlockDimensions(var_169)
            let (var_170: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_172: (System.Object [])) = [|var_143; var_151; var_50; var_166|]: (System.Object [])
            var_167.RunAsync(var_170, var_172)
            let (var_173: uint64) = method_5((var_165: (uint64 ref)))
            let (var_175: int64) = 4L
            let (var_176: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_175: int64))
            let (var_177: EnvStack8) = EnvStack8((var_176: EnvHeap2))
            let (var_178: EnvHeap2) = var_177.mem_0
            let (var_179: (int64 ref)) = var_178.mem_0
            let (var_180: EnvStack0) = var_178.mem_1
            let (var_181: (uint64 ref)) = var_180.mem_0
            let (var_182: uint64) = method_5((var_181: (uint64 ref)))
            // Cuda join point
            // method_33((var_173: uint64), (var_50: int64), (var_132: float32), (var_182: uint64))
            let (var_183: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_15, var_12)
            let (var_184: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_183.set_GridDimensions(var_184)
            let (var_185: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_183.set_BlockDimensions(var_185)
            let (var_186: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_188: (System.Object [])) = [|var_173; var_50; var_132; var_182|]: (System.Object [])
            var_183.RunAsync(var_186, var_188)
            let (var_189: int64) = 4L
            let (var_190: EnvHeap2) = method_18((var_52: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_189: int64))
            let (var_191: EnvStack8) = EnvStack8((var_190: EnvHeap2))
            let (var_192: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_193: EnvHeap2) = var_191.mem_0
            let (var_194: (int64 ref)) = var_193.mem_0
            let (var_195: EnvStack0) = var_193.mem_1
            let (var_196: (uint64 ref)) = var_195.mem_0
            let (var_197: uint64) = method_5((var_196: (uint64 ref)))
            let (var_198: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_197)
            let (var_199: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_198)
            let (var_200: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
            var_12.ClearMemoryAsync(var_199, 0uy, var_200, var_192)
            let (var_201: int64) = 0L
            let (var_202: float32) = 1.000000f
            method_34((var_191: EnvStack8), (var_201: int64), (var_202: float32))
            let (var_203: uint64) = method_5((var_196: (uint64 ref)))
            let (var_204: uint64) = method_5((var_181: (uint64 ref)))
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_205: uint64) = method_5((var_107: (uint64 ref)))
            let (var_206: uint64) = method_5((var_147: (uint64 ref)))
            let (var_207: uint64) = (var_206 + var_150)
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_208: uint64) = method_5((var_127: (uint64 ref)))
            let (var_209: int64) =
                if var_112 then
                    var_111
                else
                    64L
            // Cuda join point
            // method_35((var_132: float32), (var_203: uint64), (var_204: uint64), (var_205: uint64), (var_207: uint64), (var_50: int64), (var_208: uint64))
            let (var_210: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_15, var_12)
            let (var_211: uint32) = (uint32 var_209)
            let (var_212: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_211, 1u, 1u)
            var_210.set_GridDimensions(var_212)
            let (var_213: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_210.set_BlockDimensions(var_213)
            let (var_214: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_216: (System.Object [])) = [|var_132; var_203; var_204; var_205; var_207; var_50; var_208|]: (System.Object [])
            var_210.RunAsync(var_214, var_216)
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_217: uint64) = method_5((var_87: (uint64 ref)))
            let (var_218: uint64) = method_5((var_127: (uint64 ref)))
            let (var_219: uint64) = method_5((var_107: (uint64 ref)))
            if var_62 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_220: uint64) = method_5((var_71: (uint64 ref)))
            let (var_221: int64) =
                if var_112 then
                    var_111
                else
                    64L
            // Cuda join point
            // method_36((var_217: uint64), (var_218: uint64), (var_219: uint64), (var_50: int64), (var_220: uint64))
            let (var_222: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_36", var_15, var_12)
            let (var_223: uint32) = (uint32 var_221)
            let (var_224: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_223, 1u, 1u)
            var_222.set_GridDimensions(var_224)
            let (var_225: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_222.set_BlockDimensions(var_225)
            let (var_226: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_228: (System.Object [])) = [|var_217; var_218; var_219; var_50; var_220|]: (System.Object [])
            var_222.RunAsync(var_226, var_228)
            method_37((var_55: int32), (var_60: EnvStack8), (var_32: int64), (var_0: EnvStack8), (var_33: int64), (var_4: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3))
            let (var_229: uint64) = method_5((var_71: (uint64 ref)))
            let (var_230: EnvHeap2) = var_2.mem_0
            let (var_231: (int64 ref)) = var_230.mem_0
            let (var_232: EnvStack0) = var_230.mem_1
            let (var_233: (uint64 ref)) = var_232.mem_0
            let (var_234: uint64) = method_5((var_233: (uint64 ref)))
            // Cuda join point
            // method_38((var_32: int64), (var_229: uint64), (var_234: uint64))
            let (var_235: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_38", var_15, var_12)
            let (var_236: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_235.set_GridDimensions(var_236)
            let (var_237: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_235.set_BlockDimensions(var_237)
            let (var_238: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_240: (System.Object [])) = [|var_32; var_229; var_234|]: (System.Object [])
            var_235.RunAsync(var_238, var_240)
            let (var_241: EnvHeap2) = var_4.mem_0
            let (var_242: (int64 ref)) = var_241.mem_0
            let (var_243: EnvStack0) = var_241.mem_1
            let (var_244: (uint64 ref)) = var_243.mem_0
            let (var_245: uint64) = method_5((var_244: (uint64 ref)))
            let (var_246: EnvHeap2) = var_5.mem_0
            let (var_247: (int64 ref)) = var_246.mem_0
            let (var_248: EnvStack0) = var_246.mem_1
            let (var_249: (uint64 ref)) = var_248.mem_0
            let (var_250: uint64) = method_5((var_249: (uint64 ref)))
            // Cuda join point
            // method_40((var_245: uint64), (var_250: uint64))
            let (var_251: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_15, var_12)
            let (var_252: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
            var_251.set_GridDimensions(var_252)
            let (var_253: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_251.set_BlockDimensions(var_253)
            let (var_254: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_256: (System.Object [])) = [|var_245; var_250|]: (System.Object [])
            var_251.RunAsync(var_254, var_256)
            let (var_257: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_258: uint64) = method_5((var_244: (uint64 ref)))
            let (var_259: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_258)
            let (var_260: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_259)
            let (var_261: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
            var_12.ClearMemoryAsync(var_260, 0uy, var_261, var_257)
            let (var_262: uint64) = method_5((var_233: (uint64 ref)))
            let (var_263: uint64) = method_5((var_83: (uint64 ref)))
            // Cuda join point
            // method_42((var_262: uint64), (var_263: uint64))
            let (var_264: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_42", var_15, var_12)
            let (var_265: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_264.set_GridDimensions(var_265)
            let (var_266: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_264.set_BlockDimensions(var_266)
            let (var_267: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_269: (System.Object [])) = [|var_262; var_263|]: (System.Object [])
            var_264.RunAsync(var_267, var_269)
            let (var_270: ManagedCuda.BasicTypes.CUstream) = method_23((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream))
            let (var_271: uint64) = method_5((var_233: (uint64 ref)))
            let (var_272: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_271)
            let (var_273: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_272)
            let (var_274: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
            var_12.ClearMemoryAsync(var_273, 0uy, var_274, var_270)
            let (var_275: int64) = 1L
            let (var_276: int64) = 0L
            let (var_277: (float32 [])) = method_43((var_275: int64), (var_177: EnvStack8), (var_276: int64))
            let (var_278: float32) = var_277.[int32 0L]
            let (var_279: string) = System.String.Format("{0}",var_278)
            let (var_280: string) = System.String.Format("{0} = {1}","c",var_279)
            let (var_281: string) = String.concat "; " [|var_280|]
            let (var_282: string) = System.String.Format("{0}{1}{2}","{",var_281,"}")
            System.Console.WriteLine(var_282)
            let (var_283: float) = (float var_278)
            let (var_284: float) = (float var_32)
            let (var_285: float) = (var_283 * var_284)
            let (var_286: float) = (var_17 + var_285)
            method_44((var_46: ResizeArray<EnvHeap2>))
            method_25((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_286: float), (var_21: int64))
    else
        (Env10(var_17))
and method_47 ((var_0: EnvHeap3)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvHeap4) = var_0.mem_1
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
and method_45 ((var_0: EnvHeap2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvStack0) = var_0.mem_1
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
and method_4 ((var_1: EnvStack0)) ((var_0: Env1)): int32 =
    let (var_2: EnvStack0) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: (uint64 ref)) = var_2.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: bool) = (var_5 < var_7)
    if var_8 then
        -1
    else
        let (var_9: bool) = (var_5 = var_7)
        if var_9 then
            0
        else
            1
and method_20 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_21((var_2: uint64))
and method_26((var_0: int32), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: int64), (var_4: int64), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3)): unit =
    let (var_17: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_18: (int64 ref)) = var_16.mem_0
    let (var_19: EnvHeap4) = var_16.mem_1
    let (var_20: (bool ref)) = var_19.mem_0
    let (var_21: ManagedCuda.CudaStream) = var_19.mem_1
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_23((var_20: (bool ref)), (var_21: ManagedCuda.CudaStream))
    var_6.set_Stream(var_22)
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: EnvHeap2) = var_1.mem_0
    let (var_27: (int64 ref)) = var_26.mem_0
    let (var_28: EnvStack0) = var_26.mem_1
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: int64) = (var_4 * 784L)
    let (var_34: bool) = (var_33 > 0L)
    let (var_35: bool) = (var_34 = false)
    if var_35 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_36: EnvHeap2) = var_2.mem_0
    let (var_37: (int64 ref)) = var_36.mem_0
    let (var_38: EnvStack0) = var_36.mem_1
    let (var_39: (uint64 ref)) = var_38.mem_0
    let (var_40: uint64) = method_5((var_39: (uint64 ref)))
    let (var_41: int64) = (var_3 * 4L)
    let (var_42: uint64) = (uint64 var_41)
    let (var_43: uint64) = (var_40 + var_42)
    let (var_44: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_43)
    let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_44)
    let (var_46: (float32 ref)) = (ref 0.000000f)
    let (var_47: int64) = (var_4 * 10L)
    let (var_48: bool) = (var_47 > 0L)
    let (var_49: bool) = (var_48 = false)
    if var_49 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_50: EnvHeap2) = var_5.mem_0
    let (var_51: (int64 ref)) = var_50.mem_0
    let (var_52: EnvStack0) = var_50.mem_1
    let (var_53: (uint64 ref)) = var_52.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_54)
    let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_55)
    let (var_57: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_17, var_23, var_24, 10, var_0, 784, var_25, var_32, 10, var_45, 784, var_46, var_56, 10)
    if var_57 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_57)
and method_34((var_0: EnvStack8), (var_1: int64), (var_2: float32)): unit =
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_3.[int32 0L] <- var_2
    let (var_4: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_3,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_5: int64) = var_4.AddrOfPinnedObject().ToInt64()
    let (var_6: uint64) = (uint64 var_5)
    let (var_7: EnvHeap2) = var_0.mem_0
    let (var_8: (int64 ref)) = var_7.mem_0
    let (var_9: EnvStack0) = var_7.mem_1
    let (var_10: (uint64 ref)) = var_9.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    let (var_12: int64) = (var_1 * 4L)
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: uint64) = (var_11 + var_13)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_6)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
    let (var_20: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_16, var_18, var_19)
    if var_20 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_20)
    var_4.Free()
and method_37((var_0: int32), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: int64), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3)): unit =
    let (var_17: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_18: (int64 ref)) = var_16.mem_0
    let (var_19: EnvHeap4) = var_16.mem_1
    let (var_20: (bool ref)) = var_19.mem_0
    let (var_21: ManagedCuda.CudaStream) = var_19.mem_1
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_23((var_20: (bool ref)), (var_21: ManagedCuda.CudaStream))
    var_6.set_Stream(var_22)
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: int64) = (var_2 * 10L)
    let (var_27: bool) = (var_26 > 0L)
    let (var_28: bool) = (var_27 = false)
    if var_28 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_29: EnvHeap2) = var_1.mem_0
    let (var_30: (int64 ref)) = var_29.mem_0
    let (var_31: EnvStack0) = var_29.mem_1
    let (var_32: (uint64 ref)) = var_31.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_33)
    let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_34)
    let (var_36: int64) = (var_2 * 784L)
    let (var_37: bool) = (var_36 > 0L)
    let (var_38: bool) = (var_37 = false)
    if var_38 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_39: EnvHeap2) = var_3.mem_0
    let (var_40: (int64 ref)) = var_39.mem_0
    let (var_41: EnvStack0) = var_39.mem_1
    let (var_42: (uint64 ref)) = var_41.mem_0
    let (var_43: uint64) = method_5((var_42: (uint64 ref)))
    let (var_44: int64) = (var_4 * 4L)
    let (var_45: uint64) = (uint64 var_44)
    let (var_46: uint64) = (var_43 + var_45)
    let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
    let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
    let (var_49: (float32 ref)) = (ref 1.000000f)
    let (var_50: EnvHeap2) = var_5.mem_0
    let (var_51: (int64 ref)) = var_50.mem_0
    let (var_52: EnvStack0) = var_50.mem_1
    let (var_53: (uint64 ref)) = var_52.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_54)
    let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_55)
    let (var_57: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_17, var_23, var_24, 10, 784, var_0, var_25, var_35, 10, var_48, 784, var_49, var_56, 10)
    if var_57 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_57)
and method_43((var_0: int64), (var_1: EnvStack8), (var_2: int64)): (float32 []) =
    let (var_3: EnvHeap2) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: EnvStack0) = var_3.mem_1
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
and method_21 ((var_1: uint64)) ((var_0: Env1)): int32 =
    let (var_2: EnvStack0) = var_0.mem_0
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
let (var_35: uint64) = 1073741824UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>))
let (var_43: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_44: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_43)
let (var_45: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_46: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_47: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_45, var_46)
let (var_56: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
let (var_68: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_69: (bool ref)) = (ref true)
let (var_70: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_71: EnvHeap4) = ({mem_0 = (var_69: (bool ref)); mem_1 = (var_70: ManagedCuda.CudaStream)} : EnvHeap4)
let (var_72: EnvHeap3) = method_7((var_71: EnvHeap4), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_73: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_74: Tuple5) = method_9((var_73: string))
let (var_75: Tuple6) = var_74.mem_0
let (var_76: (uint8 [])) = var_74.mem_1
let (var_77: int64) = var_75.mem_0
let (var_78: int64) = var_75.mem_1
let (var_79: int64) = var_75.mem_2
let (var_80: bool) = (10000L = var_77)
let (var_84: bool) =
    if var_80 then
        let (var_81: bool) = (28L = var_78)
        if var_81 then
            (28L = var_79)
        else
            false
    else
        false
let (var_85: bool) = (var_84 = false)
if var_85 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_86: int64) = var_76.LongLength
let (var_87: bool) = (var_86 > 0L)
let (var_88: bool) = (var_87 = false)
if var_88 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_92: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_93: int64) = 0L
method_10((var_76: (uint8 [])), (var_92: (float32 [])), (var_93: int64))
let (var_94: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_95: Tuple7) = method_12((var_94: string))
let (var_96: int64) = var_95.mem_0
let (var_97: (uint8 [])) = var_95.mem_1
let (var_98: bool) = (10000L = var_96)
let (var_99: bool) = (var_98 = false)
if var_99 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_103: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_104: int64) = 0L
method_13((var_97: (uint8 [])), (var_103: (float32 [])), (var_104: int64))
let (var_105: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_106: Tuple5) = method_9((var_105: string))
let (var_107: Tuple6) = var_106.mem_0
let (var_108: (uint8 [])) = var_106.mem_1
let (var_109: int64) = var_107.mem_0
let (var_110: int64) = var_107.mem_1
let (var_111: int64) = var_107.mem_2
let (var_112: bool) = (60000L = var_109)
let (var_116: bool) =
    if var_112 then
        let (var_113: bool) = (28L = var_110)
        if var_113 then
            (28L = var_111)
        else
            false
    else
        false
let (var_117: bool) = (var_116 = false)
if var_117 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_118: int64) = var_108.LongLength
let (var_119: bool) = (var_118 > 0L)
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_124: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_125: int64) = 0L
method_15((var_108: (uint8 [])), (var_124: (float32 [])), (var_125: int64))
let (var_126: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_127: Tuple7) = method_12((var_126: string))
let (var_128: int64) = var_127.mem_0
let (var_129: (uint8 [])) = var_127.mem_1
let (var_130: bool) = (60000L = var_128)
let (var_131: bool) = (var_130 = false)
if var_131 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_135: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_136: int64) = 0L
method_16((var_129: (uint8 [])), (var_135: (float32 [])), (var_136: int64))
let (var_137: int64) = 10000L
let (var_138: int64) = 0L
let (var_139: int64) = 784L
let (var_140: int64) = 1L
let (var_141: EnvStack8) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_137: int64), (var_92: (float32 [])), (var_138: int64), (var_139: int64), (var_140: int64))
let (var_142: int64) = 10000L
let (var_143: int64) = 0L
let (var_144: int64) = 10L
let (var_145: int64) = 1L
let (var_146: EnvStack8) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_142: int64), (var_103: (float32 [])), (var_143: int64), (var_144: int64), (var_145: int64))
let (var_147: int64) = 60000L
let (var_148: int64) = 0L
let (var_149: int64) = 784L
let (var_150: int64) = 1L
let (var_151: EnvStack8) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_147: int64), (var_124: (float32 [])), (var_148: int64), (var_149: int64), (var_150: int64))
let (var_152: int64) = 60000L
let (var_153: int64) = 0L
let (var_154: int64) = 10L
let (var_155: int64) = 1L
let (var_156: EnvStack8) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_152: int64), (var_135: (float32 [])), (var_153: int64), (var_154: int64), (var_155: int64))
let (var_157: int64) = 31360L
let (var_158: EnvHeap9) = ({mem_0 = (var_41: ResizeArray<Env1>); mem_1 = (var_40: EnvStack0); mem_2 = (var_35: uint64); mem_3 = (var_42: ResizeArray<Env1>)} : EnvHeap9)
let (var_159: EnvHeap2) = method_18((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_157: int64))
let (var_160: EnvStack8) = EnvStack8((var_159: EnvHeap2))
let (var_161: EnvHeap2) = var_160.mem_0
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: EnvStack0) = var_161.mem_1
let (var_164: (uint64 ref)) = var_163.mem_0
let (var_165: uint64) = method_5((var_164: (uint64 ref)))
let (var_166: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
let (var_167: (int64 ref)) = var_72.mem_0
let (var_168: EnvHeap4) = var_72.mem_1
let (var_169: (bool ref)) = var_168.mem_0
let (var_170: ManagedCuda.CudaStream) = var_168.mem_1
let (var_171: ManagedCuda.BasicTypes.CUstream) = method_23((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
var_44.SetStream(var_171)
let (var_172: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_165)
let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_172)
var_44.GenerateNormal32(var_173, var_166, 0.000000f, 0.050189f)
let (var_174: int64) = 31360L
let (var_175: EnvHeap2) = method_18((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_174: int64))
let (var_176: EnvStack8) = EnvStack8((var_175: EnvHeap2))
let (var_177: ManagedCuda.BasicTypes.CUstream) = method_23((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
let (var_178: EnvHeap2) = var_176.mem_0
let (var_179: (int64 ref)) = var_178.mem_0
let (var_180: EnvStack0) = var_178.mem_1
let (var_181: (uint64 ref)) = var_180.mem_0
let (var_182: uint64) = method_5((var_181: (uint64 ref)))
let (var_183: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_182)
let (var_184: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_183)
let (var_185: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_184, 0uy, var_185, var_177)
let (var_186: int64) = 40L
let (var_187: EnvHeap2) = method_18((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_186: int64))
let (var_188: EnvStack8) = EnvStack8((var_187: EnvHeap2))
let (var_189: ManagedCuda.BasicTypes.CUstream) = method_23((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
let (var_190: EnvHeap2) = var_188.mem_0
let (var_191: (int64 ref)) = var_190.mem_0
let (var_192: EnvStack0) = var_190.mem_1
let (var_193: (uint64 ref)) = var_192.mem_0
let (var_194: uint64) = method_5((var_193: (uint64 ref)))
let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_194)
let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_195)
let (var_197: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_196, 0uy, var_197, var_189)
let (var_198: int64) = 40L
let (var_199: EnvHeap2) = method_18((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_198: int64))
let (var_200: EnvStack8) = EnvStack8((var_199: EnvHeap2))
let (var_201: ManagedCuda.BasicTypes.CUstream) = method_23((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
let (var_202: EnvHeap2) = var_200.mem_0
let (var_203: (int64 ref)) = var_202.mem_0
let (var_204: EnvStack0) = var_202.mem_1
let (var_205: (uint64 ref)) = var_204.mem_0
let (var_206: uint64) = method_5((var_205: (uint64 ref)))
let (var_207: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_206)
let (var_208: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_207)
let (var_209: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_208, 0uy, var_209, var_201)
let (var_210: ResizeArray<Env1>) = var_158.mem_0
let (var_211: EnvStack0) = var_158.mem_1
let (var_212: uint64) = var_158.mem_2
let (var_213: ResizeArray<Env1>) = var_158.mem_3
method_1((var_210: ResizeArray<Env1>), (var_211: EnvStack0), (var_212: uint64), (var_213: ResizeArray<Env1>))
System.Console.WriteLine("---")
let (var_214: int64) = 0L
method_24((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_200: EnvStack8), (var_188: EnvStack8), (var_176: EnvStack8), (var_160: EnvStack8), (var_151: EnvStack8), (var_156: EnvStack8), (var_214: int64))
method_46((var_68: ResizeArray<EnvHeap3>))
method_44((var_56: ResizeArray<EnvHeap2>))
var_47.Dispose()
var_44.Dispose()
let (var_215: (uint64 ref)) = var_40.mem_0
let (var_216: uint64) = method_5((var_215: (uint64 ref)))
let (var_217: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_216)
let (var_218: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_217)
var_1.FreeMemory(var_218)
var_215 := 0UL
var_1.Dispose()

