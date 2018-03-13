module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_19(unsigned char * var_0, float * var_1);
    __global__ void method_39(float * var_0, float * var_1, float * var_2);
    __global__ void method_42(float * var_0, float * var_1);
    __global__ void method_45(float * var_0, float * var_1);
    __global__ void method_47(float * var_0, float * var_1, float * var_2);
    __global__ void method_51(float * var_0, float * var_1, float * var_2);
    __global__ void method_55(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_57(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_61(float * var_0, float * var_1);
    __global__ void method_66(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_69(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_74(float * var_0, float * var_1, float * var_2);
    __global__ void method_77(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_85(float * var_0, float * var_1);
    __global__ void method_87(float * var_0, float * var_1);
    __global__ void method_92(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_20(long long int * var_0);
    __device__ char method_21(long long int * var_0);
    __device__ char method_40(long long int * var_0);
    __device__ char method_43(long long int * var_0);
    __device__ char method_52(long long int * var_0, float * var_1);
    __device__ char method_62(long long int * var_0, float * var_1);
    __device__ char method_63(long long int * var_0, float * var_1);
    __device__ char method_64(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_88(long long int * var_0);
    
    __global__ void method_19(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_20(var_6)) {
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
            while (method_21(var_35)) {
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
    __global__ void method_39(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_21(var_7)) {
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
            while (method_40(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 64);
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
                char var_31;
                if (var_21) {
                    var_31 = (var_20 < 64);
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
                    var_34 = (var_9 < 128);
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
            long long int var_42 = (var_9 + 128);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_42(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_43(var_6)) {
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
            float var_18 = tanh(var_16);
            var_1[var_8] = var_18;
            long long int var_19 = (var_8 + 8192);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_45(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_43(var_6)) {
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
    __global__ void method_47(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_43(var_7)) {
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
            float var_20 = (var_17 * var_18);
            var_2[var_9] = var_20;
            long long int var_21 = (var_9 + 8192);
            var_7[0] = var_21;
        }
        long long int var_22 = var_7[0];
    }
    __global__ void method_51(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_52(var_8, var_9)) {
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
            float var_19 = (var_18 - var_17);
            float var_20 = (var_19 * var_19);
            float var_21 = (var_12 + var_20);
            long long int var_22 = (var_11 + 1024);
            var_8[0] = var_22;
            var_9[0] = var_21;
        }
        long long int var_23 = var_8[0];
        float var_24 = var_9[0];
        float var_25 = cub::BlockReduce<float,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_24);
        float var_26 = (var_25 / 64);
        long long int var_27 = threadIdx.x;
        char var_28 = (var_27 == 0);
        if (var_28) {
            long long int var_29 = blockIdx.x;
            char var_30 = (var_29 >= 0);
            char var_32;
            if (var_30) {
                var_32 = (var_29 < 1);
            } else {
                var_32 = 0;
            }
            char var_33 = (var_32 == 0);
            if (var_33) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_29] = var_26;
        } else {
        }
    }
    __global__ void method_55(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_43(var_8)) {
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
            float var_18 = var_1[var_10];
            float var_19 = var_2[var_10];
            float var_20 = var_3[var_10];
            float var_21 = var_0[0];
            float var_22 = (var_18 - var_19);
            float var_23 = (2 * var_22);
            float var_24 = (var_23 / 64);
            float var_25 = (var_20 + var_24);
            var_3[var_10] = var_25;
            long long int var_26 = (var_10 + 8192);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_57(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_43(var_8)) {
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
    __global__ void method_61(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_21(var_6)) {
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
            while (method_62(var_21, var_22)) {
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
            while (method_63(var_41, var_42)) {
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
                    while (method_64(var_44, var_69, var_70)) {
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
    __global__ void method_66(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_43(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 8192);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            char var_18;
            if (var_13) {
                var_18 = (var_12 < 8192);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            float var_20 = var_0[var_12];
            float var_21 = var_1[var_12];
            float var_22 = var_2[var_12];
            float var_23 = var_3[var_12];
            float var_24 = var_4[var_12];
            float var_25 = var_5[var_12];
            float var_26 = (var_22 * var_21);
            float var_27 = (var_22 * var_20);
            float var_28 = (var_24 + var_26);
            float var_29 = (var_25 + var_27);
            var_4[var_12] = var_28;
            var_5[var_12] = var_29;
            long long int var_30 = (var_12 + 8192);
            var_10[0] = var_30;
        }
        long long int var_31 = var_10[0];
    }
    __global__ void method_69(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_43(var_8)) {
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
            float var_22 = (var_20 * var_20);
            float var_23 = (1 - var_22);
            float var_24 = (var_19 * var_23);
            float var_25 = (var_21 + var_24);
            var_3[var_10] = var_25;
            long long int var_26 = (var_10 + 8192);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_74(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_43(var_7)) {
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
            float var_20 = (var_17 + var_18);
            var_2[var_9] = var_20;
            long long int var_21 = (var_9 + 8192);
            var_7[0] = var_21;
        }
        long long int var_22 = var_7[0];
    }
    __global__ void method_77(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_43(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 8192);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            char var_18;
            if (var_13) {
                var_18 = (var_12 < 8192);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            float var_20 = var_0[var_12];
            float var_21 = var_1[var_12];
            float var_22 = var_2[var_12];
            float var_23 = var_3[var_12];
            float var_24 = var_4[var_12];
            float var_25 = var_5[var_12];
            float var_26 = (var_24 + var_22);
            float var_27 = (var_25 + var_22);
            var_4[var_12] = var_26;
            var_5[var_12] = var_27;
            long long int var_28 = (var_12 + 8192);
            var_10[0] = var_28;
        }
        long long int var_29 = var_10[0];
    }
    __global__ void method_85(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_21(var_6)) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_87(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_88(var_6)) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_92(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (128 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_43(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 8192);
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
                var_17 = (var_11 < 8192);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            float var_19 = var_0[var_11];
            float var_20 = var_1[var_11];
            float var_21 = var_2[var_11];
            float var_22 = var_3[var_11];
            float var_23 = var_4[var_11];
            float var_24 = (var_21 * var_19);
            float var_25 = (var_23 + var_24);
            var_4[var_11] = var_25;
            long long int var_26 = (var_11 + 8192);
            var_9[0] = var_26;
        }
        long long int var_27 = var_9[0];
    }
    __device__ char method_20(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 35692544);
    }
    __device__ char method_21(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_40(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_43(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8192);
    }
    __device__ char method_52(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8192);
    }
    __device__ char method_62(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 64);
    }
    __device__ char method_63(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_64(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_88(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
    }
}
"""

type Env0 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env1 =
    struct
    val mem_0: Env6
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env6
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env4
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env4 =
    struct
    val mem_0: (bool ref)
    val mem_1: ManagedCuda.CudaStream
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env5 =
    struct
    val mem_0: Env2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env6 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack7 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env6
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack8 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env6
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap9 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: ResizeArray<Env0>
    mem_3: ResizeArray<Env1>
    }
and EnvStack10 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env6
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>)): unit =
    let (var_5: (Env1 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env1 -> (Env1 -> int32))) = method_3
    let (var_9: System.Comparison<Env1>) = System.Comparison<Env1>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: uint64) = method_5((var_1: (uint64 ref)))
    let (var_12: int32) = 0
    let (var_13: uint64) = method_6((var_0: ResizeArray<Env0>), (var_3: ResizeArray<Env1>), (var_10: int32), (var_11: uint64), (var_12: int32))
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: uint64) = (var_14 + var_2)
    let (var_16: uint64) = (var_15 - var_13)
    let (var_17: uint64) = (var_13 + 256UL)
    let (var_18: uint64) = (var_17 - 1UL)
    let (var_19: uint64) = (var_18 &&& 18446744073709551360UL)
    let (var_20: uint64) = (var_19 - var_13)
    let (var_21: bool) = (var_16 > var_20)
    if var_21 then
        let (var_22: uint64) = (var_16 - var_20)
        var_0.Add((Env0(var_19, var_22)))
    else
        ()
and method_7((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule)): Env3 =
    let (var_12: (int64 ref)) = (ref 0L)
    method_8((var_12: (int64 ref)), (var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_10: ResizeArray<Env3>))
    (Env3(var_12, (Env4(var_0, var_1))))
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64), (var_13: (uint8 [])), (var_14: int64), (var_15: int64)): Env5 =
    let (var_16: int64) = (var_12 * var_15)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: uint64) = (uint64 var_14)
    let (var_21: uint64) = (var_20 + var_19)
    let (var_22: Env2) = method_11((var_16: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: Env6) = var_22.mem_1
    let (var_25: (uint64 ref)) = var_24.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_32: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_28, var_30, var_31)
    if var_32 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_32)
    var_17.Free()
    (Env5((Env2(var_23, var_24))))
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 571080704L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_18((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_19((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_23((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 65536L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_24((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): unit =
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_2.SetStream(var_19)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    var_2.GenerateNormal32(var_21, var_16, 0.000000f, 0.108253f)
and method_25((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack7 =
    let (var_14: Env2) = method_23((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env6) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_26((var_15: (int64 ref)), (var_16: Env6), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack7((var_15: (int64 ref)), (var_16: Env6))
and method_27((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): unit =
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_2.SetStream(var_19)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    var_2.GenerateNormal32(var_21, var_16, 0.000000f, 0.088388f)
and method_28((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): EnvStack8 =
    let (var_12: Env2) = method_29((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env6) = var_12.mem_1
    let (var_15: (bool ref)) = var_11.mem_0
    let (var_16: ManagedCuda.CudaStream) = var_11.mem_1
    let (var_17: ManagedCuda.BasicTypes.CUstream) = method_22((var_15: (bool ref)), (var_16: ManagedCuda.CudaStream))
    method_30((var_13: (int64 ref)), (var_14: Env6), (var_6: ManagedCuda.CudaContext), (var_17: ManagedCuda.BasicTypes.CUstream))
    EnvStack8((var_13: (int64 ref)), (var_14: Env6))
and method_31((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): EnvStack8 =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env6) = var_0.mem_1
    let (var_15: Env2) = method_29((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env6) = var_15.mem_1
    let (var_18: (bool ref)) = var_12.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_12.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_22((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    method_30((var_16: (int64 ref)), (var_17: Env6), (var_7: ManagedCuda.CudaContext), (var_20: ManagedCuda.BasicTypes.CUstream))
    EnvStack8((var_16: (int64 ref)), (var_17: Env6))
and method_32((var_0: (int64 ref)), (var_1: Env6), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack7), (var_9: (int64 ref)), (var_10: Env6), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env6), (var_14: EnvStack7), (var_15: (int64 ref)), (var_16: Env6), (var_17: EnvStack7), (var_18: (int64 ref)), (var_19: Env6), (var_20: EnvStack7), (var_21: (int64 ref)), (var_22: Env6), (var_23: EnvStack7), (var_24: (int64 ref)), (var_25: Env6), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: ManagedCuda.CudaBlas.CudaBlas), (var_32: ManagedCuda.CudaRand.CudaRandDevice), (var_33: (uint64 ref)), (var_34: uint64), (var_35: ResizeArray<Env0>), (var_36: ResizeArray<Env1>), (var_37: ManagedCuda.CudaContext), (var_38: ResizeArray<Env2>), (var_39: ResizeArray<Env3>), (var_40: ManagedCuda.BasicTypes.CUmodule), (var_41: (int64 ref)), (var_42: Env4), (var_43: int64)): unit =
    let (var_44: bool) = (var_43 < 5L)
    if var_44 then
        let (var_45: int64) = 0L
        let (var_46: float) = 0.000000
        let (var_47: int64) = 0L
        let (var_48: float) = method_33((var_0: (int64 ref)), (var_1: Env6), (var_31: ManagedCuda.CudaBlas.CudaBlas), (var_32: ManagedCuda.CudaRand.CudaRandDevice), (var_33: (uint64 ref)), (var_34: uint64), (var_35: ResizeArray<Env0>), (var_36: ResizeArray<Env1>), (var_37: ManagedCuda.CudaContext), (var_38: ResizeArray<Env2>), (var_39: ResizeArray<Env3>), (var_40: ManagedCuda.BasicTypes.CUmodule), (var_41: (int64 ref)), (var_42: Env4), (var_45: int64), (var_46: float), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack7), (var_9: (int64 ref)), (var_10: Env6), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env6), (var_14: EnvStack7), (var_15: (int64 ref)), (var_16: Env6), (var_17: EnvStack7), (var_18: (int64 ref)), (var_19: Env6), (var_20: EnvStack7), (var_21: (int64 ref)), (var_22: Env6), (var_23: EnvStack7), (var_24: (int64 ref)), (var_25: Env6), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_47: int64))
        let (var_49: string) = System.String.Format("Training: {0}",var_48)
        let (var_50: string) = System.String.Format("{0}",var_49)
        System.Console.WriteLine(var_50)
        if (System.Double.IsNaN var_48) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_51: int64) = (var_43 + 1L)
            method_32((var_0: (int64 ref)), (var_1: Env6), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack7), (var_9: (int64 ref)), (var_10: Env6), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env6), (var_14: EnvStack7), (var_15: (int64 ref)), (var_16: Env6), (var_17: EnvStack7), (var_18: (int64 ref)), (var_19: Env6), (var_20: EnvStack7), (var_21: (int64 ref)), (var_22: Env6), (var_23: EnvStack7), (var_24: (int64 ref)), (var_25: Env6), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: ManagedCuda.CudaBlas.CudaBlas), (var_32: ManagedCuda.CudaRand.CudaRandDevice), (var_33: (uint64 ref)), (var_34: uint64), (var_35: ResizeArray<Env0>), (var_36: ResizeArray<Env1>), (var_37: ManagedCuda.CudaContext), (var_38: ResizeArray<Env2>), (var_39: ResizeArray<Env3>), (var_40: ManagedCuda.BasicTypes.CUmodule), (var_41: (int64 ref)), (var_42: Env4), (var_51: int64))
    else
        ()
and method_94((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_95
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_81((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_82
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env1)): bool =
    let (var_1: Env6) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: Env6) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env1) = var_1.[var_4]
        let (var_7: Env6) = var_6.mem_0
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
            let (var_20: uint64) = (var_14 - var_18)
            var_0.Add((Env0(var_17, var_20)))
        else
            ()
        let (var_21: uint64) = (var_13 + var_8)
        let (var_22: int32) = (var_4 + 1)
        method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_21: uint64), (var_22: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: (bool ref)), (var_2: ManagedCuda.CudaStream), (var_3: ResizeArray<Env3>)): unit =
    let (var_4: int64) = (!var_0)
    let (var_5: int64) = (var_4 + 1L)
    var_0 := var_5
    var_3.Add((Env3(var_0, (Env4(var_1, var_2)))))
and method_11((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): Env2 =
    let (var_13: EnvHeap9) = ({mem_0 = (var_3: (uint64 ref)); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env0>); mem_3 = (var_6: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_0: int64))
and method_12((var_0: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_13: int64)): Env2 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: ResizeArray<Env0>) = var_0.mem_2
    let (var_17: ResizeArray<Env1>) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env6) = method_13((var_16: ResizeArray<Env0>), (var_14: (uint64 ref)), (var_15: uint64), (var_17: ResizeArray<Env1>), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_16((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: ResizeArray<Env2>))
    (Env2(var_24, (Env6(var_23))))
and method_22((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_26((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_29((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 512L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_30((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_33((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: float), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack7), (var_35: (int64 ref)), (var_36: Env6), (var_37: EnvStack7), (var_38: (int64 ref)), (var_39: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_45: int64)): float =
    let (var_46: bool) = (var_45 < 271L)
    if var_46 then
        let (var_47: bool) = (var_45 >= 0L)
        let (var_48: bool) = (var_47 = false)
        if var_48 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_49: int64) = (var_45 * 524288L)
        if var_48 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_50: int64) = (524288L + var_49)
        let (var_51: EnvHeap9) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap9)
        let (var_52: (uint64 ref)) = var_51.mem_0
        let (var_53: uint64) = var_51.mem_1
        let (var_54: ResizeArray<Env0>) = var_51.mem_2
        let (var_55: ResizeArray<Env1>) = var_51.mem_3
        method_1((var_54: ResizeArray<Env0>), (var_52: (uint64 ref)), (var_53: uint64), (var_55: ResizeArray<Env1>))
        let (var_59: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_148: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_149: (int64 ref)) = var_148.mem_0
        let (var_150: Env6) = var_148.mem_1
        method_35((var_26: (int64 ref)), (var_27: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_49: int64), (var_149: (int64 ref)), (var_150: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_151: EnvStack10) = method_36((var_149: (int64 ref)), (var_150: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_152: (int64 ref)) = var_19.mem_0
        let (var_153: Env6) = var_19.mem_1
        let (var_154: (uint64 ref)) = var_153.mem_0
        let (var_155: uint64) = method_5((var_154: (uint64 ref)))
        let (var_156: (uint64 ref)) = var_150.mem_0
        let (var_157: uint64) = method_5((var_156: (uint64 ref)))
        let (var_158: uint64) = method_5((var_156: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_155: uint64), (var_157: uint64), (var_158: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_160: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_161: (int64 ref)) = var_160.mem_0
        let (var_162: Env6) = var_160.mem_1
        let (var_163: uint64) = method_5((var_156: (uint64 ref)))
        let (var_164: (uint64 ref)) = var_162.mem_0
        let (var_165: uint64) = method_5((var_164: (uint64 ref)))
        method_41((var_8: ManagedCuda.CudaContext), (var_163: uint64), (var_165: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_166: EnvStack10) = method_36((var_161: (int64 ref)), (var_162: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_167: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_168: (int64 ref)) = var_167.mem_0
        let (var_169: Env6) = var_167.mem_1
        method_35((var_29: (int64 ref)), (var_30: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_49: int64), (var_168: (int64 ref)), (var_169: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_170: EnvStack10) = method_36((var_168: (int64 ref)), (var_169: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_171: (int64 ref)) = var_21.mem_0
        let (var_172: Env6) = var_21.mem_1
        let (var_173: (uint64 ref)) = var_172.mem_0
        let (var_174: uint64) = method_5((var_173: (uint64 ref)))
        let (var_175: (uint64 ref)) = var_169.mem_0
        let (var_176: uint64) = method_5((var_175: (uint64 ref)))
        let (var_177: uint64) = method_5((var_175: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_174: uint64), (var_176: uint64), (var_177: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_182: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_183: (int64 ref)) = var_182.mem_0
        let (var_184: Env6) = var_182.mem_1
        let (var_185: uint64) = method_5((var_175: (uint64 ref)))
        let (var_186: (uint64 ref)) = var_184.mem_0
        let (var_187: uint64) = method_5((var_186: (uint64 ref)))
        method_44((var_8: ManagedCuda.CudaContext), (var_185: uint64), (var_187: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_188: EnvStack10) = method_36((var_183: (int64 ref)), (var_184: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_190: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_191: (int64 ref)) = var_190.mem_0
        let (var_192: Env6) = var_190.mem_1
        let (var_193: uint64) = method_5((var_164: (uint64 ref)))
        let (var_194: uint64) = method_5((var_186: (uint64 ref)))
        let (var_195: (uint64 ref)) = var_192.mem_0
        let (var_196: uint64) = method_5((var_195: (uint64 ref)))
        method_46((var_8: ManagedCuda.CudaContext), (var_193: uint64), (var_194: uint64), (var_196: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_197: EnvStack10) = method_36((var_191: (int64 ref)), (var_192: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_198: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_199: (int64 ref)) = var_198.mem_0
        let (var_200: Env6) = var_198.mem_1
        method_48((var_43: (int64 ref)), (var_44: Env6), (var_191: (int64 ref)), (var_192: Env6), (var_199: (int64 ref)), (var_200: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_201: EnvStack10) = method_36((var_199: (int64 ref)), (var_200: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_202: (int64 ref)) = var_41.mem_0
        let (var_203: Env6) = var_41.mem_1
        let (var_204: (uint64 ref)) = var_203.mem_0
        let (var_205: uint64) = method_5((var_204: (uint64 ref)))
        let (var_206: (uint64 ref)) = var_200.mem_0
        let (var_207: uint64) = method_5((var_206: (uint64 ref)))
        let (var_208: uint64) = method_5((var_206: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_205: uint64), (var_207: uint64), (var_208: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_213: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_214: (int64 ref)) = var_213.mem_0
        let (var_215: Env6) = var_213.mem_1
        let (var_216: uint64) = method_5((var_206: (uint64 ref)))
        let (var_217: (uint64 ref)) = var_215.mem_0
        let (var_218: uint64) = method_5((var_217: (uint64 ref)))
        method_44((var_8: ManagedCuda.CudaContext), (var_216: uint64), (var_218: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_219: EnvStack10) = method_36((var_214: (int64 ref)), (var_215: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_220: uint64) = method_5((var_217: (uint64 ref)))
        let (var_221: (uint64 ref)) = var_1.mem_0
        let (var_222: uint64) = method_5((var_221: (uint64 ref)))
        let (var_223: int64) = (var_50 * 4L)
        let (var_224: uint64) = (uint64 var_223)
        let (var_225: uint64) = (var_222 + var_224)
        let (var_229: Env2) = method_49((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_230: (int64 ref)) = var_229.mem_0
        let (var_231: Env6) = var_229.mem_1
        let (var_232: (uint64 ref)) = var_231.mem_0
        let (var_233: uint64) = method_5((var_232: (uint64 ref)))
        method_50((var_8: ManagedCuda.CudaContext), (var_220: uint64), (var_225: uint64), (var_233: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_234: (unit -> unit)) = method_53((var_151: EnvStack10), (var_149: (int64 ref)), (var_150: Env6), (var_18: EnvStack8), (var_19: EnvStack8), (var_0: (int64 ref)), (var_1: Env6), (var_49: int64), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_166: EnvStack10), (var_161: (int64 ref)), (var_162: Env6), (var_170: EnvStack10), (var_168: (int64 ref)), (var_169: Env6), (var_20: EnvStack8), (var_21: EnvStack8), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_188: EnvStack10), (var_183: (int64 ref)), (var_184: Env6), (var_197: EnvStack10), (var_191: (int64 ref)), (var_192: Env6), (var_201: EnvStack10), (var_199: (int64 ref)), (var_200: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_219: EnvStack10), (var_214: (int64 ref)), (var_215: Env6), (var_230: (int64 ref)), (var_231: Env6), (var_50: int64))
        let (var_235: (unit -> float32)) = method_70((var_230: (int64 ref)), (var_231: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_356: int64) = 1L
        method_79((var_0: (int64 ref)), (var_1: Env6), (var_49: int64), (var_50: int64), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack7), (var_35: (int64 ref)), (var_36: Env6), (var_37: EnvStack7), (var_38: (int64 ref)), (var_39: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_59: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: float), (var_45: int64), (var_9: ResizeArray<Env2>), (var_235: (unit -> float32)), (var_234: (unit -> unit)), (var_197: EnvStack10), (var_191: (int64 ref)), (var_192: Env6), (var_356: int64))
    else
        let (var_358: float) = (float var_14)
        (var_15 / var_358)
and method_95 ((var_0: Env3)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env4) = var_0.mem_1
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
and method_82 ((var_0: Env2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env6) = var_0.mem_1
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
and method_4 ((var_1: (uint64 ref))) ((var_0: Env1)): int32 =
    let (var_2: Env6) = var_0.mem_0
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
and method_13((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): Env6 =
    let (var_5: int32) = var_0.get_Count()
    let (var_6: bool) = (var_5 > 0)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_8: Env0) = var_0.[0]
    let (var_9: uint64) = var_8.mem_0
    let (var_10: uint64) = var_8.mem_1
    let (var_11: bool) = (var_4 <= var_10)
    let (var_38: Env1) =
        if var_11 then
            let (var_12: uint64) = (var_9 + var_4)
            let (var_13: uint64) = (var_10 - var_4)
            var_0.[0] <- (Env0(var_12, var_13))
            let (var_14: (uint64 ref)) = (ref var_9)
            (Env1((Env6(var_14)), var_4))
        else
            let (var_16: (Env0 -> (Env0 -> int32))) = method_14
            let (var_17: System.Comparison<Env0>) = System.Comparison<Env0>(var_16)
            var_0.Sort(var_17)
            let (var_18: Env0) = var_0.[0]
            let (var_19: uint64) = var_18.mem_0
            let (var_20: uint64) = var_18.mem_1
            let (var_21: bool) = (var_4 <= var_20)
            if var_21 then
                let (var_22: uint64) = (var_19 + var_4)
                let (var_23: uint64) = (var_20 - var_4)
                var_0.[0] <- (Env0(var_22, var_23))
                let (var_24: (uint64 ref)) = (ref var_19)
                (Env1((Env6(var_24)), var_4))
            else
                method_1((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_26: (Env0 -> (Env0 -> int32))) = method_14
                let (var_27: System.Comparison<Env0>) = System.Comparison<Env0>(var_26)
                var_0.Sort(var_27)
                let (var_28: Env0) = var_0.[0]
                let (var_29: uint64) = var_28.mem_0
                let (var_30: uint64) = var_28.mem_1
                let (var_31: bool) = (var_4 <= var_30)
                if var_31 then
                    let (var_32: uint64) = (var_29 + var_4)
                    let (var_33: uint64) = (var_30 - var_4)
                    var_0.[0] <- (Env0(var_32, var_33))
                    let (var_34: (uint64 ref)) = (ref var_29)
                    (Env1((Env6(var_34)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_39: Env6) = var_38.mem_0
    let (var_40: uint64) = var_38.mem_1
    var_3.Add((Env1(var_39, var_40)))
    var_39
and method_16((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, (Env6(var_1)))))
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 32768L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_35((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: int64), (var_5: (int64 ref)), (var_6: Env6), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env4)): unit =
    let (var_19: ManagedCuda.CudaBlas.CudaBlasHandle) = var_7.get_CublasHandle()
    let (var_20: (bool ref)) = var_18.mem_0
    let (var_21: ManagedCuda.CudaStream) = var_18.mem_1
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_22((var_20: (bool ref)), (var_21: ManagedCuda.CudaStream))
    var_7.set_Stream(var_22)
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_1.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (uint64 ref)) = var_3.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: int64) = (var_4 * 4L)
    let (var_33: uint64) = (uint64 var_32)
    let (var_34: uint64) = (var_31 + var_33)
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_34)
    let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_35)
    let (var_37: (float32 ref)) = (ref 0.000000f)
    let (var_38: (uint64 ref)) = var_6.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
    let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_40)
    let (var_42: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_19, var_23, var_24, 128, 64, 128, var_25, var_29, 128, var_36, 128, var_37, var_41, 128)
    if var_42 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_42)
and method_36((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack10 =
    let (var_14: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env6) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_37((var_15: (int64 ref)), (var_16: Env6), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack10((var_15: (int64 ref)), (var_16: Env6))
and method_38((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_39((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_22((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_41((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_42((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_42", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_44((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_45((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_46((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_47((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_22((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_48((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_22((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
    var_6.set_Stream(var_21)
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: (float32 ref)) = (ref 1.000000f)
    let (var_25: (uint64 ref)) = var_1.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (uint64 ref)) = var_3.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: (float32 ref)) = (ref 0.000000f)
    let (var_34: (uint64 ref)) = var_5.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_18, var_22, var_23, 128, 64, 128, var_24, var_28, 128, var_32, 128, var_33, var_37, 128)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_49((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 4L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_12((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_50((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_51((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_22((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_53 ((var_0: EnvStack10), (var_1: (int64 ref)), (var_2: Env6), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_8: EnvStack7), (var_9: (int64 ref)), (var_10: Env6), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: ResizeArray<Env0>), (var_16: ResizeArray<Env1>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<Env2>), (var_19: ResizeArray<Env3>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4), (var_23: EnvStack10), (var_24: (int64 ref)), (var_25: Env6), (var_26: EnvStack10), (var_27: (int64 ref)), (var_28: Env6), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack10), (var_35: (int64 ref)), (var_36: Env6), (var_37: EnvStack10), (var_38: (int64 ref)), (var_39: Env6), (var_40: EnvStack10), (var_41: (int64 ref)), (var_42: Env6), (var_43: EnvStack8), (var_44: EnvStack8), (var_45: EnvStack7), (var_46: (int64 ref)), (var_47: Env6), (var_48: EnvStack10), (var_49: (int64 ref)), (var_50: Env6), (var_51: (int64 ref)), (var_52: Env6), (var_53: int64)) (): unit =
    let (var_54: (uint64 ref)) = var_52.mem_0
    let (var_55: uint64) = method_5((var_54: (uint64 ref)))
    let (var_56: (int64 ref)) = var_48.mem_0
    let (var_57: Env6) = var_48.mem_1
    let (var_58: (uint64 ref)) = var_50.mem_0
    let (var_59: uint64) = method_5((var_58: (uint64 ref)))
    let (var_60: (uint64 ref)) = var_6.mem_0
    let (var_61: uint64) = method_5((var_60: (uint64 ref)))
    let (var_62: int64) = (var_53 * 4L)
    let (var_63: uint64) = (uint64 var_62)
    let (var_64: uint64) = (var_61 + var_63)
    let (var_65: (uint64 ref)) = var_57.mem_0
    let (var_66: uint64) = method_5((var_65: (uint64 ref)))
    method_54((var_17: ManagedCuda.CudaContext), (var_55: uint64), (var_59: uint64), (var_64: uint64), (var_66: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_67: (int64 ref)) = var_40.mem_0
    let (var_68: Env6) = var_40.mem_1
    let (var_69: (uint64 ref)) = var_42.mem_0
    let (var_70: uint64) = method_5((var_69: (uint64 ref)))
    let (var_71: uint64) = method_5((var_65: (uint64 ref)))
    let (var_72: uint64) = method_5((var_58: (uint64 ref)))
    let (var_73: (uint64 ref)) = var_68.mem_0
    let (var_74: uint64) = method_5((var_73: (uint64 ref)))
    method_56((var_17: ManagedCuda.CudaContext), (var_70: uint64), (var_71: uint64), (var_72: uint64), (var_74: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_75: (int64 ref)) = var_37.mem_0
    let (var_76: Env6) = var_37.mem_1
    method_58((var_46: (int64 ref)), (var_47: Env6), (var_40: EnvStack10), (var_37: EnvStack10), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: ResizeArray<Env0>), (var_16: ResizeArray<Env1>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<Env2>), (var_19: ResizeArray<Env3>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_77: (int64 ref)) = var_45.mem_0
    let (var_78: Env6) = var_45.mem_1
    method_59((var_40: EnvStack10), (var_38: (int64 ref)), (var_39: Env6), (var_45: EnvStack7), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: ResizeArray<Env0>), (var_16: ResizeArray<Env1>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<Env2>), (var_19: ResizeArray<Env3>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_79: (int64 ref)) = var_43.mem_0
    let (var_80: Env6) = var_43.mem_1
    let (var_81: uint64) = method_5((var_73: (uint64 ref)))
    let (var_82: (uint64 ref)) = var_80.mem_0
    let (var_83: uint64) = method_5((var_82: (uint64 ref)))
    method_60((var_17: ManagedCuda.CudaContext), (var_81: uint64), (var_83: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_84: (int64 ref)) = var_23.mem_0
    let (var_85: Env6) = var_23.mem_1
    let (var_86: (int64 ref)) = var_34.mem_0
    let (var_87: Env6) = var_34.mem_1
    let (var_88: (uint64 ref)) = var_25.mem_0
    let (var_89: uint64) = method_5((var_88: (uint64 ref)))
    let (var_90: (uint64 ref)) = var_36.mem_0
    let (var_91: uint64) = method_5((var_90: (uint64 ref)))
    let (var_92: (uint64 ref)) = var_76.mem_0
    let (var_93: uint64) = method_5((var_92: (uint64 ref)))
    let (var_94: (uint64 ref)) = var_39.mem_0
    let (var_95: uint64) = method_5((var_94: (uint64 ref)))
    let (var_96: (uint64 ref)) = var_85.mem_0
    let (var_97: uint64) = method_5((var_96: (uint64 ref)))
    let (var_98: (uint64 ref)) = var_87.mem_0
    let (var_99: uint64) = method_5((var_98: (uint64 ref)))
    method_65((var_17: ManagedCuda.CudaContext), (var_89: uint64), (var_91: uint64), (var_93: uint64), (var_95: uint64), (var_97: uint64), (var_99: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_100: (int64 ref)) = var_26.mem_0
    let (var_101: Env6) = var_26.mem_1
    let (var_102: (uint64 ref)) = var_28.mem_0
    let (var_103: uint64) = method_5((var_102: (uint64 ref)))
    let (var_104: uint64) = method_5((var_98: (uint64 ref)))
    let (var_105: uint64) = method_5((var_90: (uint64 ref)))
    let (var_106: (uint64 ref)) = var_101.mem_0
    let (var_107: uint64) = method_5((var_106: (uint64 ref)))
    method_56((var_17: ManagedCuda.CudaContext), (var_103: uint64), (var_104: uint64), (var_105: uint64), (var_107: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_108: (int64 ref)) = var_31.mem_0
    let (var_109: Env6) = var_31.mem_1
    method_67((var_26: EnvStack10), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_31: EnvStack7), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: ResizeArray<Env0>), (var_16: ResizeArray<Env1>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<Env2>), (var_19: ResizeArray<Env3>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_110: (int64 ref)) = var_29.mem_0
    let (var_111: Env6) = var_29.mem_1
    let (var_112: uint64) = method_5((var_106: (uint64 ref)))
    let (var_113: (uint64 ref)) = var_111.mem_0
    let (var_114: uint64) = method_5((var_113: (uint64 ref)))
    method_60((var_17: ManagedCuda.CudaContext), (var_112: uint64), (var_114: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_115: (int64 ref)) = var_0.mem_0
    let (var_116: Env6) = var_0.mem_1
    let (var_117: (uint64 ref)) = var_2.mem_0
    let (var_118: uint64) = method_5((var_117: (uint64 ref)))
    let (var_119: uint64) = method_5((var_96: (uint64 ref)))
    let (var_120: uint64) = method_5((var_88: (uint64 ref)))
    let (var_121: (uint64 ref)) = var_116.mem_0
    let (var_122: uint64) = method_5((var_121: (uint64 ref)))
    method_68((var_17: ManagedCuda.CudaContext), (var_118: uint64), (var_119: uint64), (var_120: uint64), (var_122: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_123: (int64 ref)) = var_8.mem_0
    let (var_124: Env6) = var_8.mem_1
    method_67((var_0: EnvStack10), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_8: EnvStack7), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: ResizeArray<Env0>), (var_16: ResizeArray<Env1>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<Env2>), (var_19: ResizeArray<Env3>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
    let (var_125: (int64 ref)) = var_3.mem_0
    let (var_126: Env6) = var_3.mem_1
    let (var_127: uint64) = method_5((var_121: (uint64 ref)))
    let (var_128: (uint64 ref)) = var_126.mem_0
    let (var_129: uint64) = method_5((var_128: (uint64 ref)))
    method_60((var_17: ManagedCuda.CudaContext), (var_127: uint64), (var_129: uint64), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env4))
and method_70 ((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)) (): float32 =
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_71((var_14: int64), (var_0: (int64 ref)), (var_1: Env6), (var_15: int64))
    var_16.[int32 0L]
and method_79((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_45: int64), (var_46: float), (var_47: int64), (var_48: ResizeArray<Env2>), (var_49: (unit -> float32)), (var_50: (unit -> unit)), (var_51: EnvStack10), (var_52: (int64 ref)), (var_53: Env6), (var_54: int64)): float =
    let (var_55: bool) = (var_54 < 64L)
    if var_55 then
        let (var_56: bool) = (var_54 >= 0L)
        let (var_57: bool) = (var_56 = false)
        if var_57 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_58: int64) = (var_54 * 8192L)
        let (var_59: int64) = (var_2 + var_58)
        if var_57 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_60: int64) = (var_3 + var_58)
        let (var_61: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_62: (int64 ref)) = var_61.mem_0
        let (var_63: Env6) = var_61.mem_1
        method_35((var_14: (int64 ref)), (var_15: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_59: int64), (var_62: (int64 ref)), (var_63: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_64: EnvStack10) = method_36((var_62: (int64 ref)), (var_63: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_23: (int64 ref)), (var_24: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_62: (int64 ref)), (var_63: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_65: (int64 ref)) = var_7.mem_0
        let (var_66: Env6) = var_7.mem_1
        let (var_67: (uint64 ref)) = var_66.mem_0
        let (var_68: uint64) = method_5((var_67: (uint64 ref)))
        let (var_69: (uint64 ref)) = var_63.mem_0
        let (var_70: uint64) = method_5((var_69: (uint64 ref)))
        let (var_71: uint64) = method_5((var_69: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_68: uint64), (var_70: uint64), (var_71: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_73: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_74: (int64 ref)) = var_73.mem_0
        let (var_75: Env6) = var_73.mem_1
        let (var_76: uint64) = method_5((var_69: (uint64 ref)))
        let (var_77: (uint64 ref)) = var_75.mem_0
        let (var_78: uint64) = method_5((var_77: (uint64 ref)))
        method_41((var_39: ManagedCuda.CudaContext), (var_76: uint64), (var_78: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_79: EnvStack10) = method_36((var_74: (int64 ref)), (var_75: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_80: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: Env6) = var_80.mem_1
        method_35((var_17: (int64 ref)), (var_18: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_59: int64), (var_81: (int64 ref)), (var_82: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_83: EnvStack10) = method_36((var_81: (int64 ref)), (var_82: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_26: (int64 ref)), (var_27: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_81: (int64 ref)), (var_82: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_84: (int64 ref)) = var_9.mem_0
        let (var_85: Env6) = var_9.mem_1
        let (var_86: (uint64 ref)) = var_85.mem_0
        let (var_87: uint64) = method_5((var_86: (uint64 ref)))
        let (var_88: (uint64 ref)) = var_82.mem_0
        let (var_89: uint64) = method_5((var_88: (uint64 ref)))
        let (var_90: uint64) = method_5((var_88: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_87: uint64), (var_89: uint64), (var_90: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_95: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_96: (int64 ref)) = var_95.mem_0
        let (var_97: Env6) = var_95.mem_1
        let (var_98: uint64) = method_5((var_88: (uint64 ref)))
        let (var_99: (uint64 ref)) = var_97.mem_0
        let (var_100: uint64) = method_5((var_99: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_98: uint64), (var_100: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_101: EnvStack10) = method_36((var_96: (int64 ref)), (var_97: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_102: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_103: (int64 ref)) = var_102.mem_0
        let (var_104: Env6) = var_102.mem_1
        method_35((var_11: (int64 ref)), (var_12: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_59: int64), (var_103: (int64 ref)), (var_104: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_105: EnvStack10) = method_36((var_103: (int64 ref)), (var_104: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_20: (int64 ref)), (var_21: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_103: (int64 ref)), (var_104: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_106: (int64 ref)) = var_5.mem_0
        let (var_107: Env6) = var_5.mem_1
        let (var_108: (uint64 ref)) = var_107.mem_0
        let (var_109: uint64) = method_5((var_108: (uint64 ref)))
        let (var_110: (uint64 ref)) = var_104.mem_0
        let (var_111: uint64) = method_5((var_110: (uint64 ref)))
        let (var_112: uint64) = method_5((var_110: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_109: uint64), (var_111: uint64), (var_112: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_117: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_118: (int64 ref)) = var_117.mem_0
        let (var_119: Env6) = var_117.mem_1
        let (var_120: uint64) = method_5((var_110: (uint64 ref)))
        let (var_121: (uint64 ref)) = var_119.mem_0
        let (var_122: uint64) = method_5((var_121: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_120: uint64), (var_122: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_123: EnvStack10) = method_36((var_118: (int64 ref)), (var_119: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_125: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_126: (int64 ref)) = var_125.mem_0
        let (var_127: Env6) = var_125.mem_1
        let (var_128: uint64) = method_5((var_77: (uint64 ref)))
        let (var_129: uint64) = method_5((var_99: (uint64 ref)))
        let (var_130: (uint64 ref)) = var_127.mem_0
        let (var_131: uint64) = method_5((var_130: (uint64 ref)))
        method_46((var_39: ManagedCuda.CudaContext), (var_128: uint64), (var_129: uint64), (var_131: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_132: EnvStack10) = method_36((var_126: (int64 ref)), (var_127: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_134: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_135: (int64 ref)) = var_134.mem_0
        let (var_136: Env6) = var_134.mem_1
        let (var_137: (uint64 ref)) = var_53.mem_0
        let (var_138: uint64) = method_5((var_137: (uint64 ref)))
        let (var_139: uint64) = method_5((var_121: (uint64 ref)))
        let (var_140: (uint64 ref)) = var_136.mem_0
        let (var_141: uint64) = method_5((var_140: (uint64 ref)))
        method_46((var_39: ManagedCuda.CudaContext), (var_138: uint64), (var_139: uint64), (var_141: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_142: EnvStack10) = method_36((var_135: (int64 ref)), (var_136: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_144: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_145: (int64 ref)) = var_144.mem_0
        let (var_146: Env6) = var_144.mem_1
        let (var_147: uint64) = method_5((var_130: (uint64 ref)))
        let (var_148: uint64) = method_5((var_140: (uint64 ref)))
        let (var_149: (uint64 ref)) = var_146.mem_0
        let (var_150: uint64) = method_5((var_149: (uint64 ref)))
        method_73((var_39: ManagedCuda.CudaContext), (var_147: uint64), (var_148: uint64), (var_150: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_151: EnvStack10) = method_36((var_145: (int64 ref)), (var_146: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_152: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_153: (int64 ref)) = var_152.mem_0
        let (var_154: Env6) = var_152.mem_1
        method_48((var_31: (int64 ref)), (var_32: Env6), (var_145: (int64 ref)), (var_146: Env6), (var_153: (int64 ref)), (var_154: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_155: EnvStack10) = method_36((var_153: (int64 ref)), (var_154: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_156: (int64 ref)) = var_29.mem_0
        let (var_157: Env6) = var_29.mem_1
        let (var_158: (uint64 ref)) = var_157.mem_0
        let (var_159: uint64) = method_5((var_158: (uint64 ref)))
        let (var_160: (uint64 ref)) = var_154.mem_0
        let (var_161: uint64) = method_5((var_160: (uint64 ref)))
        let (var_162: uint64) = method_5((var_160: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_159: uint64), (var_161: uint64), (var_162: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_167: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_168: (int64 ref)) = var_167.mem_0
        let (var_169: Env6) = var_167.mem_1
        let (var_170: uint64) = method_5((var_160: (uint64 ref)))
        let (var_171: (uint64 ref)) = var_169.mem_0
        let (var_172: uint64) = method_5((var_171: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_170: uint64), (var_172: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_173: EnvStack10) = method_36((var_168: (int64 ref)), (var_169: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_174: uint64) = method_5((var_171: (uint64 ref)))
        let (var_175: (uint64 ref)) = var_1.mem_0
        let (var_176: uint64) = method_5((var_175: (uint64 ref)))
        let (var_177: int64) = (var_60 * 4L)
        let (var_178: uint64) = (uint64 var_177)
        let (var_179: uint64) = (var_176 + var_178)
        let (var_183: Env2) = method_49((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_184: (int64 ref)) = var_183.mem_0
        let (var_185: Env6) = var_183.mem_1
        let (var_186: (uint64 ref)) = var_185.mem_0
        let (var_187: uint64) = method_5((var_186: (uint64 ref)))
        method_50((var_39: ManagedCuda.CudaContext), (var_174: uint64), (var_179: uint64), (var_187: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_188: (unit -> unit)) = method_75((var_50: (unit -> unit)), (var_64: EnvStack10), (var_62: (int64 ref)), (var_63: Env6), (var_6: EnvStack8), (var_7: EnvStack8), (var_0: (int64 ref)), (var_1: Env6), (var_59: int64), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_51: EnvStack10), (var_52: (int64 ref)), (var_53: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_79: EnvStack10), (var_74: (int64 ref)), (var_75: Env6), (var_83: EnvStack10), (var_81: (int64 ref)), (var_82: Env6), (var_8: EnvStack8), (var_9: EnvStack8), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_101: EnvStack10), (var_96: (int64 ref)), (var_97: Env6), (var_105: EnvStack10), (var_103: (int64 ref)), (var_104: Env6), (var_4: EnvStack8), (var_5: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_123: EnvStack10), (var_118: (int64 ref)), (var_119: Env6), (var_132: EnvStack10), (var_126: (int64 ref)), (var_127: Env6), (var_142: EnvStack10), (var_135: (int64 ref)), (var_136: Env6), (var_151: EnvStack10), (var_145: (int64 ref)), (var_146: Env6), (var_155: EnvStack10), (var_153: (int64 ref)), (var_154: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_173: EnvStack10), (var_168: (int64 ref)), (var_169: Env6), (var_184: (int64 ref)), (var_185: Env6), (var_60: int64))
        let (var_189: (unit -> float32)) = method_78((var_184: (int64 ref)), (var_185: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_49: (unit -> float32)))
        let (var_190: int64) = (var_54 + 1L)
        method_79((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_45: int64), (var_46: float), (var_47: int64), (var_48: ResizeArray<Env2>), (var_189: (unit -> float32)), (var_188: (unit -> unit)), (var_151: EnvStack10), (var_145: (int64 ref)), (var_146: Env6), (var_190: int64))
    else
        // Done with foru...
        let (var_192: float32) = var_49()
        let (var_193: float) = (float var_192)
        let (var_194: float) = (var_46 + var_193)
        let (var_203: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_80((var_52: (int64 ref)), (var_53: Env6), (var_203: ResizeArray<Env2>))
        let (var_204: int64) = (var_45 + 1L)
        if (System.Double.IsNaN var_194) then
            // Is nan...
            method_81((var_40: ResizeArray<Env2>))
            // Done with the net...
            method_81((var_203: ResizeArray<Env2>))
            let (var_205: float) = (float var_204)
            (var_194 / var_205)
        else
            var_50()
            method_83((var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
            // Done with body...
            method_81((var_40: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_207: int64) = (var_47 + 1L)
            method_89((var_0: (int64 ref)), (var_1: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_48: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_204: int64), (var_194: float), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_203: ResizeArray<Env2>), (var_52: (int64 ref)), (var_53: Env6), (var_207: int64))
and method_14 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_15((var_2: uint64))
and method_37((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_54((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env4)): unit =
    // Cuda join point
    // method_55((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_22((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
and method_56((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env4)): unit =
    // Cuda join point
    // method_57((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_22((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
and method_58((var_0: (int64 ref)), (var_1: Env6), (var_2: EnvStack10), (var_3: EnvStack10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4)): unit =
    let (var_16: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_17: (bool ref)) = var_15.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_15.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_4.set_Stream(var_19)
    let (var_20: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: (uint64 ref)) = var_1.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: (int64 ref)) = var_2.mem_0
    let (var_28: Env6) = var_2.mem_1
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: (float32 ref)) = (ref 1.000000f)
    let (var_34: (int64 ref)) = var_3.mem_0
    let (var_35: Env6) = var_3.mem_1
    let (var_36: (uint64 ref)) = var_35.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
    let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_38)
    let (var_40: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_16, var_20, var_21, 128, 64, 128, var_22, var_26, 128, var_32, 128, var_33, var_39, 128)
    if var_40 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_40)
and method_59((var_0: EnvStack10), (var_1: (int64 ref)), (var_2: Env6), (var_3: EnvStack7), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4)): unit =
    let (var_16: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_17: (bool ref)) = var_15.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_15.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_22((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_4.set_Stream(var_19)
    let (var_20: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: (int64 ref)) = var_0.mem_0
    let (var_24: Env6) = var_0.mem_1
    let (var_25: (uint64 ref)) = var_24.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (uint64 ref)) = var_2.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: (float32 ref)) = (ref 1.000000f)
    let (var_34: (int64 ref)) = var_3.mem_0
    let (var_35: Env6) = var_3.mem_1
    let (var_36: (uint64 ref)) = var_35.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
    let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_38)
    let (var_40: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_16, var_20, var_21, 128, 128, 64, var_22, var_28, 128, var_32, 128, var_33, var_39, 128)
    if var_40 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_40)
and method_60((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_61((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_61", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_65((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env4)): unit =
    // Cuda join point
    // method_66((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64))
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_66", var_7, var_0)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (bool ref)) = var_9.mem_0
    let (var_14: ManagedCuda.CudaStream) = var_9.mem_1
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_22((var_13: (bool ref)), (var_14: ManagedCuda.CudaStream))
    let (var_17: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_15, var_17)
and method_67((var_0: EnvStack10), (var_1: (int64 ref)), (var_2: Env6), (var_3: int64), (var_4: EnvStack7), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4)): unit =
    let (var_17: ManagedCuda.CudaBlas.CudaBlasHandle) = var_5.get_CublasHandle()
    let (var_18: (bool ref)) = var_16.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_22((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    var_5.set_Stream(var_20)
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_23: (float32 ref)) = (ref 1.000000f)
    let (var_24: (int64 ref)) = var_0.mem_0
    let (var_25: Env6) = var_0.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (uint64 ref)) = var_2.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: int64) = (var_3 * 4L)
    let (var_33: uint64) = (uint64 var_32)
    let (var_34: uint64) = (var_31 + var_33)
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_34)
    let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_35)
    let (var_37: (float32 ref)) = (ref 1.000000f)
    let (var_38: (int64 ref)) = var_4.mem_0
    let (var_39: Env6) = var_4.mem_1
    let (var_40: (uint64 ref)) = var_39.mem_0
    let (var_41: uint64) = method_5((var_40: (uint64 ref)))
    let (var_42: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_41)
    let (var_43: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_42)
    let (var_44: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_17, var_21, var_22, 128, 128, 64, var_23, var_29, 128, var_36, 128, var_37, var_43, 128)
    if var_44 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_44)
and method_68((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env4)): unit =
    // Cuda join point
    // method_69((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_69", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_22((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
and method_71((var_0: int64), (var_1: (int64 ref)), (var_2: Env6), (var_3: int64)): (float32 []) =
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
and method_72((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_22((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
    var_6.set_Stream(var_21)
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: (float32 ref)) = (ref 1.000000f)
    let (var_25: (uint64 ref)) = var_1.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (uint64 ref)) = var_3.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: (float32 ref)) = (ref 1.000000f)
    let (var_34: (uint64 ref)) = var_5.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_18, var_22, var_23, 128, 64, 128, var_24, var_28, 128, var_32, 128, var_33, var_37, 128)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_73((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_74((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_74", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_22((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_75 ((var_0: (unit -> unit)), (var_1: EnvStack10), (var_2: (int64 ref)), (var_3: Env6), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: (int64 ref)), (var_7: Env6), (var_8: int64), (var_9: EnvStack7), (var_10: (int64 ref)), (var_11: Env6), (var_12: EnvStack10), (var_13: (int64 ref)), (var_14: Env6), (var_15: EnvStack7), (var_16: (int64 ref)), (var_17: Env6), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4), (var_30: EnvStack10), (var_31: (int64 ref)), (var_32: Env6), (var_33: EnvStack10), (var_34: (int64 ref)), (var_35: Env6), (var_36: EnvStack8), (var_37: EnvStack8), (var_38: EnvStack7), (var_39: (int64 ref)), (var_40: Env6), (var_41: EnvStack7), (var_42: (int64 ref)), (var_43: Env6), (var_44: EnvStack10), (var_45: (int64 ref)), (var_46: Env6), (var_47: EnvStack10), (var_48: (int64 ref)), (var_49: Env6), (var_50: EnvStack8), (var_51: EnvStack8), (var_52: EnvStack7), (var_53: (int64 ref)), (var_54: Env6), (var_55: EnvStack7), (var_56: (int64 ref)), (var_57: Env6), (var_58: EnvStack10), (var_59: (int64 ref)), (var_60: Env6), (var_61: EnvStack10), (var_62: (int64 ref)), (var_63: Env6), (var_64: EnvStack10), (var_65: (int64 ref)), (var_66: Env6), (var_67: EnvStack10), (var_68: (int64 ref)), (var_69: Env6), (var_70: EnvStack10), (var_71: (int64 ref)), (var_72: Env6), (var_73: EnvStack8), (var_74: EnvStack8), (var_75: EnvStack7), (var_76: (int64 ref)), (var_77: Env6), (var_78: EnvStack10), (var_79: (int64 ref)), (var_80: Env6), (var_81: (int64 ref)), (var_82: Env6), (var_83: int64)) (): unit =
    let (var_84: (uint64 ref)) = var_82.mem_0
    let (var_85: uint64) = method_5((var_84: (uint64 ref)))
    let (var_86: (int64 ref)) = var_78.mem_0
    let (var_87: Env6) = var_78.mem_1
    let (var_88: (uint64 ref)) = var_80.mem_0
    let (var_89: uint64) = method_5((var_88: (uint64 ref)))
    let (var_90: (uint64 ref)) = var_7.mem_0
    let (var_91: uint64) = method_5((var_90: (uint64 ref)))
    let (var_92: int64) = (var_83 * 4L)
    let (var_93: uint64) = (uint64 var_92)
    let (var_94: uint64) = (var_91 + var_93)
    let (var_95: (uint64 ref)) = var_87.mem_0
    let (var_96: uint64) = method_5((var_95: (uint64 ref)))
    method_54((var_24: ManagedCuda.CudaContext), (var_85: uint64), (var_89: uint64), (var_94: uint64), (var_96: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_97: (int64 ref)) = var_70.mem_0
    let (var_98: Env6) = var_70.mem_1
    let (var_99: (uint64 ref)) = var_72.mem_0
    let (var_100: uint64) = method_5((var_99: (uint64 ref)))
    let (var_101: uint64) = method_5((var_95: (uint64 ref)))
    let (var_102: uint64) = method_5((var_88: (uint64 ref)))
    let (var_103: (uint64 ref)) = var_98.mem_0
    let (var_104: uint64) = method_5((var_103: (uint64 ref)))
    method_56((var_24: ManagedCuda.CudaContext), (var_100: uint64), (var_101: uint64), (var_102: uint64), (var_104: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_105: (int64 ref)) = var_67.mem_0
    let (var_106: Env6) = var_67.mem_1
    method_58((var_76: (int64 ref)), (var_77: Env6), (var_70: EnvStack10), (var_67: EnvStack10), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_107: (int64 ref)) = var_75.mem_0
    let (var_108: Env6) = var_75.mem_1
    method_59((var_70: EnvStack10), (var_68: (int64 ref)), (var_69: Env6), (var_75: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_109: (int64 ref)) = var_73.mem_0
    let (var_110: Env6) = var_73.mem_1
    let (var_111: uint64) = method_5((var_103: (uint64 ref)))
    let (var_112: (uint64 ref)) = var_110.mem_0
    let (var_113: uint64) = method_5((var_112: (uint64 ref)))
    method_60((var_24: ManagedCuda.CudaContext), (var_111: uint64), (var_113: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_114: (int64 ref)) = var_61.mem_0
    let (var_115: Env6) = var_61.mem_1
    let (var_116: (int64 ref)) = var_64.mem_0
    let (var_117: Env6) = var_64.mem_1
    let (var_118: (uint64 ref)) = var_63.mem_0
    let (var_119: uint64) = method_5((var_118: (uint64 ref)))
    let (var_120: (uint64 ref)) = var_66.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    let (var_122: (uint64 ref)) = var_106.mem_0
    let (var_123: uint64) = method_5((var_122: (uint64 ref)))
    let (var_124: (uint64 ref)) = var_69.mem_0
    let (var_125: uint64) = method_5((var_124: (uint64 ref)))
    let (var_126: (uint64 ref)) = var_115.mem_0
    let (var_127: uint64) = method_5((var_126: (uint64 ref)))
    let (var_128: (uint64 ref)) = var_117.mem_0
    let (var_129: uint64) = method_5((var_128: (uint64 ref)))
    method_76((var_24: ManagedCuda.CudaContext), (var_119: uint64), (var_121: uint64), (var_123: uint64), (var_125: uint64), (var_127: uint64), (var_129: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_130: (int64 ref)) = var_12.mem_0
    let (var_131: Env6) = var_12.mem_1
    let (var_132: (int64 ref)) = var_58.mem_0
    let (var_133: Env6) = var_58.mem_1
    let (var_134: (uint64 ref)) = var_14.mem_0
    let (var_135: uint64) = method_5((var_134: (uint64 ref)))
    let (var_136: (uint64 ref)) = var_60.mem_0
    let (var_137: uint64) = method_5((var_136: (uint64 ref)))
    let (var_138: uint64) = method_5((var_128: (uint64 ref)))
    let (var_139: uint64) = method_5((var_120: (uint64 ref)))
    let (var_140: (uint64 ref)) = var_131.mem_0
    let (var_141: uint64) = method_5((var_140: (uint64 ref)))
    let (var_142: (uint64 ref)) = var_133.mem_0
    let (var_143: uint64) = method_5((var_142: (uint64 ref)))
    method_65((var_24: ManagedCuda.CudaContext), (var_135: uint64), (var_137: uint64), (var_138: uint64), (var_139: uint64), (var_141: uint64), (var_143: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_144: (int64 ref)) = var_30.mem_0
    let (var_145: Env6) = var_30.mem_1
    let (var_146: (int64 ref)) = var_44.mem_0
    let (var_147: Env6) = var_44.mem_1
    let (var_148: (uint64 ref)) = var_32.mem_0
    let (var_149: uint64) = method_5((var_148: (uint64 ref)))
    let (var_150: (uint64 ref)) = var_46.mem_0
    let (var_151: uint64) = method_5((var_150: (uint64 ref)))
    let (var_152: uint64) = method_5((var_126: (uint64 ref)))
    let (var_153: uint64) = method_5((var_118: (uint64 ref)))
    let (var_154: (uint64 ref)) = var_145.mem_0
    let (var_155: uint64) = method_5((var_154: (uint64 ref)))
    let (var_156: (uint64 ref)) = var_147.mem_0
    let (var_157: uint64) = method_5((var_156: (uint64 ref)))
    method_65((var_24: ManagedCuda.CudaContext), (var_149: uint64), (var_151: uint64), (var_152: uint64), (var_153: uint64), (var_155: uint64), (var_157: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_158: (int64 ref)) = var_47.mem_0
    let (var_159: Env6) = var_47.mem_1
    let (var_160: (uint64 ref)) = var_49.mem_0
    let (var_161: uint64) = method_5((var_160: (uint64 ref)))
    let (var_162: uint64) = method_5((var_142: (uint64 ref)))
    let (var_163: uint64) = method_5((var_136: (uint64 ref)))
    let (var_164: (uint64 ref)) = var_159.mem_0
    let (var_165: uint64) = method_5((var_164: (uint64 ref)))
    method_56((var_24: ManagedCuda.CudaContext), (var_161: uint64), (var_162: uint64), (var_163: uint64), (var_165: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_166: (int64 ref)) = var_52.mem_0
    let (var_167: Env6) = var_52.mem_1
    method_67((var_47: EnvStack10), (var_6: (int64 ref)), (var_7: Env6), (var_8: int64), (var_52: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    method_58((var_56: (int64 ref)), (var_57: Env6), (var_47: EnvStack10), (var_12: EnvStack10), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_168: (int64 ref)) = var_55.mem_0
    let (var_169: Env6) = var_55.mem_1
    method_59((var_47: EnvStack10), (var_13: (int64 ref)), (var_14: Env6), (var_55: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_170: (int64 ref)) = var_50.mem_0
    let (var_171: Env6) = var_50.mem_1
    let (var_172: uint64) = method_5((var_164: (uint64 ref)))
    let (var_173: (uint64 ref)) = var_171.mem_0
    let (var_174: uint64) = method_5((var_173: (uint64 ref)))
    method_60((var_24: ManagedCuda.CudaContext), (var_172: uint64), (var_174: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_175: (int64 ref)) = var_33.mem_0
    let (var_176: Env6) = var_33.mem_1
    let (var_177: (uint64 ref)) = var_35.mem_0
    let (var_178: uint64) = method_5((var_177: (uint64 ref)))
    let (var_179: uint64) = method_5((var_156: (uint64 ref)))
    let (var_180: uint64) = method_5((var_150: (uint64 ref)))
    let (var_181: (uint64 ref)) = var_176.mem_0
    let (var_182: uint64) = method_5((var_181: (uint64 ref)))
    method_56((var_24: ManagedCuda.CudaContext), (var_178: uint64), (var_179: uint64), (var_180: uint64), (var_182: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_183: (int64 ref)) = var_38.mem_0
    let (var_184: Env6) = var_38.mem_1
    method_67((var_33: EnvStack10), (var_6: (int64 ref)), (var_7: Env6), (var_8: int64), (var_38: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    method_58((var_42: (int64 ref)), (var_43: Env6), (var_33: EnvStack10), (var_12: EnvStack10), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_185: (int64 ref)) = var_41.mem_0
    let (var_186: Env6) = var_41.mem_1
    method_59((var_33: EnvStack10), (var_13: (int64 ref)), (var_14: Env6), (var_41: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_187: (int64 ref)) = var_36.mem_0
    let (var_188: Env6) = var_36.mem_1
    let (var_189: uint64) = method_5((var_181: (uint64 ref)))
    let (var_190: (uint64 ref)) = var_188.mem_0
    let (var_191: uint64) = method_5((var_190: (uint64 ref)))
    method_60((var_24: ManagedCuda.CudaContext), (var_189: uint64), (var_191: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_192: (int64 ref)) = var_1.mem_0
    let (var_193: Env6) = var_1.mem_1
    let (var_194: (uint64 ref)) = var_3.mem_0
    let (var_195: uint64) = method_5((var_194: (uint64 ref)))
    let (var_196: uint64) = method_5((var_154: (uint64 ref)))
    let (var_197: uint64) = method_5((var_148: (uint64 ref)))
    let (var_198: (uint64 ref)) = var_193.mem_0
    let (var_199: uint64) = method_5((var_198: (uint64 ref)))
    method_68((var_24: ManagedCuda.CudaContext), (var_195: uint64), (var_196: uint64), (var_197: uint64), (var_199: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_200: (int64 ref)) = var_9.mem_0
    let (var_201: Env6) = var_9.mem_1
    method_67((var_1: EnvStack10), (var_6: (int64 ref)), (var_7: Env6), (var_8: int64), (var_9: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    method_58((var_16: (int64 ref)), (var_17: Env6), (var_1: EnvStack10), (var_12: EnvStack10), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_202: (int64 ref)) = var_15.mem_0
    let (var_203: Env6) = var_15.mem_1
    method_59((var_1: EnvStack10), (var_13: (int64 ref)), (var_14: Env6), (var_15: EnvStack7), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: (uint64 ref)), (var_21: uint64), (var_22: ResizeArray<Env0>), (var_23: ResizeArray<Env1>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<Env2>), (var_26: ResizeArray<Env3>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    let (var_204: (int64 ref)) = var_4.mem_0
    let (var_205: Env6) = var_4.mem_1
    let (var_206: uint64) = method_5((var_198: (uint64 ref)))
    let (var_207: (uint64 ref)) = var_205.mem_0
    let (var_208: uint64) = method_5((var_207: (uint64 ref)))
    method_60((var_24: ManagedCuda.CudaContext), (var_206: uint64), (var_208: uint64), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env4))
    var_0()
and method_78 ((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: (unit -> float32))) (): float32 =
    let (var_15: float32) = var_14()
    let (var_16: int64) = 1L
    let (var_17: int64) = 0L
    let (var_18: (float32 [])) = method_71((var_16: int64), (var_0: (int64 ref)), (var_1: Env6), (var_17: int64))
    let (var_19: float32) = var_18.[int32 0L]
    (var_15 + var_19)
and method_80((var_0: (int64 ref)), (var_1: Env6), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, var_1)))
and method_83((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack7), (var_7: (int64 ref)), (var_8: Env6), (var_9: EnvStack7), (var_10: (int64 ref)), (var_11: Env6), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env6), (var_15: EnvStack7), (var_16: (int64 ref)), (var_17: Env6), (var_18: EnvStack7), (var_19: (int64 ref)), (var_20: Env6), (var_21: EnvStack7), (var_22: (int64 ref)), (var_23: Env6), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack7), (var_27: (int64 ref)), (var_28: Env6), (var_29: ManagedCuda.CudaBlas.CudaBlas), (var_30: ManagedCuda.CudaRand.CudaRandDevice), (var_31: (uint64 ref)), (var_32: uint64), (var_33: ResizeArray<Env0>), (var_34: ResizeArray<Env1>), (var_35: ManagedCuda.CudaContext), (var_36: ResizeArray<Env2>), (var_37: ResizeArray<Env3>), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4)): unit =
    let (var_41: (int64 ref)) = var_1.mem_0
    let (var_42: Env6) = var_1.mem_1
    let (var_43: (int64 ref)) = var_0.mem_0
    let (var_44: Env6) = var_0.mem_1
    let (var_45: (uint64 ref)) = var_42.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: (uint64 ref)) = var_44.mem_0
    let (var_48: uint64) = method_5((var_47: (uint64 ref)))
    method_84((var_35: ManagedCuda.CudaContext), (var_46: uint64), (var_48: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_49: (int64 ref)) = var_3.mem_0
    let (var_50: Env6) = var_3.mem_1
    let (var_51: (int64 ref)) = var_2.mem_0
    let (var_52: Env6) = var_2.mem_1
    let (var_53: (uint64 ref)) = var_50.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: (uint64 ref)) = var_52.mem_0
    let (var_56: uint64) = method_5((var_55: (uint64 ref)))
    method_84((var_35: ManagedCuda.CudaContext), (var_54: uint64), (var_56: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_57: (int64 ref)) = var_5.mem_0
    let (var_58: Env6) = var_5.mem_1
    let (var_59: (int64 ref)) = var_4.mem_0
    let (var_60: Env6) = var_4.mem_1
    let (var_61: (uint64 ref)) = var_58.mem_0
    let (var_62: uint64) = method_5((var_61: (uint64 ref)))
    let (var_63: (uint64 ref)) = var_60.mem_0
    let (var_64: uint64) = method_5((var_63: (uint64 ref)))
    method_84((var_35: ManagedCuda.CudaContext), (var_62: uint64), (var_64: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_65: (int64 ref)) = var_6.mem_0
    let (var_66: Env6) = var_6.mem_1
    let (var_67: (uint64 ref)) = var_8.mem_0
    let (var_68: uint64) = method_5((var_67: (uint64 ref)))
    let (var_69: (uint64 ref)) = var_66.mem_0
    let (var_70: uint64) = method_5((var_69: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_68: uint64), (var_70: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_71: (int64 ref)) = var_9.mem_0
    let (var_72: Env6) = var_9.mem_1
    let (var_73: (uint64 ref)) = var_11.mem_0
    let (var_74: uint64) = method_5((var_73: (uint64 ref)))
    let (var_75: (uint64 ref)) = var_72.mem_0
    let (var_76: uint64) = method_5((var_75: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_74: uint64), (var_76: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_77: (int64 ref)) = var_12.mem_0
    let (var_78: Env6) = var_12.mem_1
    let (var_79: (uint64 ref)) = var_14.mem_0
    let (var_80: uint64) = method_5((var_79: (uint64 ref)))
    let (var_81: (uint64 ref)) = var_78.mem_0
    let (var_82: uint64) = method_5((var_81: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_80: uint64), (var_82: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_83: (int64 ref)) = var_15.mem_0
    let (var_84: Env6) = var_15.mem_1
    let (var_85: (uint64 ref)) = var_17.mem_0
    let (var_86: uint64) = method_5((var_85: (uint64 ref)))
    let (var_87: (uint64 ref)) = var_84.mem_0
    let (var_88: uint64) = method_5((var_87: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_86: uint64), (var_88: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_89: (int64 ref)) = var_18.mem_0
    let (var_90: Env6) = var_18.mem_1
    let (var_91: (uint64 ref)) = var_20.mem_0
    let (var_92: uint64) = method_5((var_91: (uint64 ref)))
    let (var_93: (uint64 ref)) = var_90.mem_0
    let (var_94: uint64) = method_5((var_93: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_92: uint64), (var_94: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_95: (int64 ref)) = var_21.mem_0
    let (var_96: Env6) = var_21.mem_1
    let (var_97: (uint64 ref)) = var_23.mem_0
    let (var_98: uint64) = method_5((var_97: (uint64 ref)))
    let (var_99: (uint64 ref)) = var_96.mem_0
    let (var_100: uint64) = method_5((var_99: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_98: uint64), (var_100: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_101: (int64 ref)) = var_25.mem_0
    let (var_102: Env6) = var_25.mem_1
    let (var_103: (int64 ref)) = var_24.mem_0
    let (var_104: Env6) = var_24.mem_1
    let (var_105: (uint64 ref)) = var_102.mem_0
    let (var_106: uint64) = method_5((var_105: (uint64 ref)))
    let (var_107: (uint64 ref)) = var_104.mem_0
    let (var_108: uint64) = method_5((var_107: (uint64 ref)))
    method_84((var_35: ManagedCuda.CudaContext), (var_106: uint64), (var_108: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
    let (var_109: (int64 ref)) = var_26.mem_0
    let (var_110: Env6) = var_26.mem_1
    let (var_111: (uint64 ref)) = var_28.mem_0
    let (var_112: uint64) = method_5((var_111: (uint64 ref)))
    let (var_113: (uint64 ref)) = var_110.mem_0
    let (var_114: uint64) = method_5((var_113: (uint64 ref)))
    method_86((var_35: ManagedCuda.CudaContext), (var_112: uint64), (var_114: uint64), (var_38: ManagedCuda.BasicTypes.CUmodule), (var_39: (int64 ref)), (var_40: Env4))
and method_89((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: float), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack7), (var_35: (int64 ref)), (var_36: Env6), (var_37: EnvStack7), (var_38: (int64 ref)), (var_39: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_45: ResizeArray<Env2>), (var_46: (int64 ref)), (var_47: Env6), (var_48: int64)): float =
    let (var_49: bool) = (var_48 < 271L)
    if var_49 then
        let (var_50: bool) = (var_48 >= 0L)
        let (var_51: bool) = (var_50 = false)
        if var_51 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_52: int64) = (var_48 * 524288L)
        if var_51 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_53: int64) = (524288L + var_52)
        let (var_54: EnvHeap9) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap9)
        let (var_55: (uint64 ref)) = var_54.mem_0
        let (var_56: uint64) = var_54.mem_1
        let (var_57: ResizeArray<Env0>) = var_54.mem_2
        let (var_58: ResizeArray<Env1>) = var_54.mem_3
        method_1((var_57: ResizeArray<Env0>), (var_55: (uint64 ref)), (var_56: uint64), (var_58: ResizeArray<Env1>))
        let (var_62: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_192: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_193: (int64 ref)) = var_192.mem_0
        let (var_194: Env6) = var_192.mem_1
        method_35((var_26: (int64 ref)), (var_27: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_52: int64), (var_193: (int64 ref)), (var_194: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_195: EnvStack10) = method_36((var_193: (int64 ref)), (var_194: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        method_72((var_35: (int64 ref)), (var_36: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_193: (int64 ref)), (var_194: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_196: (int64 ref)) = var_19.mem_0
        let (var_197: Env6) = var_19.mem_1
        let (var_198: (uint64 ref)) = var_197.mem_0
        let (var_199: uint64) = method_5((var_198: (uint64 ref)))
        let (var_200: (uint64 ref)) = var_194.mem_0
        let (var_201: uint64) = method_5((var_200: (uint64 ref)))
        let (var_202: uint64) = method_5((var_200: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_199: uint64), (var_201: uint64), (var_202: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_204: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_205: (int64 ref)) = var_204.mem_0
        let (var_206: Env6) = var_204.mem_1
        let (var_207: uint64) = method_5((var_200: (uint64 ref)))
        let (var_208: (uint64 ref)) = var_206.mem_0
        let (var_209: uint64) = method_5((var_208: (uint64 ref)))
        method_41((var_8: ManagedCuda.CudaContext), (var_207: uint64), (var_209: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_210: EnvStack10) = method_36((var_205: (int64 ref)), (var_206: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_211: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_212: (int64 ref)) = var_211.mem_0
        let (var_213: Env6) = var_211.mem_1
        method_35((var_29: (int64 ref)), (var_30: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_52: int64), (var_212: (int64 ref)), (var_213: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_214: EnvStack10) = method_36((var_212: (int64 ref)), (var_213: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        method_72((var_38: (int64 ref)), (var_39: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_212: (int64 ref)), (var_213: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_215: (int64 ref)) = var_21.mem_0
        let (var_216: Env6) = var_21.mem_1
        let (var_217: (uint64 ref)) = var_216.mem_0
        let (var_218: uint64) = method_5((var_217: (uint64 ref)))
        let (var_219: (uint64 ref)) = var_213.mem_0
        let (var_220: uint64) = method_5((var_219: (uint64 ref)))
        let (var_221: uint64) = method_5((var_219: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_218: uint64), (var_220: uint64), (var_221: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_226: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_227: (int64 ref)) = var_226.mem_0
        let (var_228: Env6) = var_226.mem_1
        let (var_229: uint64) = method_5((var_219: (uint64 ref)))
        let (var_230: (uint64 ref)) = var_228.mem_0
        let (var_231: uint64) = method_5((var_230: (uint64 ref)))
        method_44((var_8: ManagedCuda.CudaContext), (var_229: uint64), (var_231: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_232: EnvStack10) = method_36((var_227: (int64 ref)), (var_228: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_233: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_234: (int64 ref)) = var_233.mem_0
        let (var_235: Env6) = var_233.mem_1
        method_35((var_23: (int64 ref)), (var_24: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_52: int64), (var_234: (int64 ref)), (var_235: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_236: EnvStack10) = method_36((var_234: (int64 ref)), (var_235: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        method_72((var_32: (int64 ref)), (var_33: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_234: (int64 ref)), (var_235: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_237: (int64 ref)) = var_17.mem_0
        let (var_238: Env6) = var_17.mem_1
        let (var_239: (uint64 ref)) = var_238.mem_0
        let (var_240: uint64) = method_5((var_239: (uint64 ref)))
        let (var_241: (uint64 ref)) = var_235.mem_0
        let (var_242: uint64) = method_5((var_241: (uint64 ref)))
        let (var_243: uint64) = method_5((var_241: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_240: uint64), (var_242: uint64), (var_243: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_248: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_249: (int64 ref)) = var_248.mem_0
        let (var_250: Env6) = var_248.mem_1
        let (var_251: uint64) = method_5((var_241: (uint64 ref)))
        let (var_252: (uint64 ref)) = var_250.mem_0
        let (var_253: uint64) = method_5((var_252: (uint64 ref)))
        method_44((var_8: ManagedCuda.CudaContext), (var_251: uint64), (var_253: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_254: EnvStack10) = method_36((var_249: (int64 ref)), (var_250: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_256: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_257: (int64 ref)) = var_256.mem_0
        let (var_258: Env6) = var_256.mem_1
        let (var_259: uint64) = method_5((var_208: (uint64 ref)))
        let (var_260: uint64) = method_5((var_230: (uint64 ref)))
        let (var_261: (uint64 ref)) = var_258.mem_0
        let (var_262: uint64) = method_5((var_261: (uint64 ref)))
        method_46((var_8: ManagedCuda.CudaContext), (var_259: uint64), (var_260: uint64), (var_262: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_263: EnvStack10) = method_36((var_257: (int64 ref)), (var_258: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_265: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_266: (int64 ref)) = var_265.mem_0
        let (var_267: Env6) = var_265.mem_1
        let (var_268: (uint64 ref)) = var_47.mem_0
        let (var_269: uint64) = method_5((var_268: (uint64 ref)))
        let (var_270: uint64) = method_5((var_252: (uint64 ref)))
        let (var_271: (uint64 ref)) = var_267.mem_0
        let (var_272: uint64) = method_5((var_271: (uint64 ref)))
        method_46((var_8: ManagedCuda.CudaContext), (var_269: uint64), (var_270: uint64), (var_272: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_273: EnvStack10) = method_36((var_266: (int64 ref)), (var_267: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_275: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_276: (int64 ref)) = var_275.mem_0
        let (var_277: Env6) = var_275.mem_1
        let (var_278: uint64) = method_5((var_261: (uint64 ref)))
        let (var_279: uint64) = method_5((var_271: (uint64 ref)))
        let (var_280: (uint64 ref)) = var_277.mem_0
        let (var_281: uint64) = method_5((var_280: (uint64 ref)))
        method_73((var_8: ManagedCuda.CudaContext), (var_278: uint64), (var_279: uint64), (var_281: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_282: EnvStack10) = method_36((var_276: (int64 ref)), (var_277: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_283: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_284: (int64 ref)) = var_283.mem_0
        let (var_285: Env6) = var_283.mem_1
        method_48((var_43: (int64 ref)), (var_44: Env6), (var_276: (int64 ref)), (var_277: Env6), (var_284: (int64 ref)), (var_285: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_286: EnvStack10) = method_36((var_284: (int64 ref)), (var_285: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_287: (int64 ref)) = var_41.mem_0
        let (var_288: Env6) = var_41.mem_1
        let (var_289: (uint64 ref)) = var_288.mem_0
        let (var_290: uint64) = method_5((var_289: (uint64 ref)))
        let (var_291: (uint64 ref)) = var_285.mem_0
        let (var_292: uint64) = method_5((var_291: (uint64 ref)))
        let (var_293: uint64) = method_5((var_291: (uint64 ref)))
        method_38((var_8: ManagedCuda.CudaContext), (var_290: uint64), (var_292: uint64), (var_293: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_298: Env2) = method_34((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_299: (int64 ref)) = var_298.mem_0
        let (var_300: Env6) = var_298.mem_1
        let (var_301: uint64) = method_5((var_291: (uint64 ref)))
        let (var_302: (uint64 ref)) = var_300.mem_0
        let (var_303: uint64) = method_5((var_302: (uint64 ref)))
        method_44((var_8: ManagedCuda.CudaContext), (var_301: uint64), (var_303: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_304: EnvStack10) = method_36((var_299: (int64 ref)), (var_300: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_305: uint64) = method_5((var_302: (uint64 ref)))
        let (var_306: (uint64 ref)) = var_1.mem_0
        let (var_307: uint64) = method_5((var_306: (uint64 ref)))
        let (var_308: int64) = (var_53 * 4L)
        let (var_309: uint64) = (uint64 var_308)
        let (var_310: uint64) = (var_307 + var_309)
        let (var_314: Env2) = method_49((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_315: (int64 ref)) = var_314.mem_0
        let (var_316: Env6) = var_314.mem_1
        let (var_317: (uint64 ref)) = var_316.mem_0
        let (var_318: uint64) = method_5((var_317: (uint64 ref)))
        method_50((var_8: ManagedCuda.CudaContext), (var_305: uint64), (var_310: uint64), (var_318: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_319: (unit -> unit)) = method_90((var_195: EnvStack10), (var_193: (int64 ref)), (var_194: Env6), (var_18: EnvStack8), (var_19: EnvStack8), (var_0: (int64 ref)), (var_1: Env6), (var_52: int64), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_34: EnvStack7), (var_35: (int64 ref)), (var_36: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_210: EnvStack10), (var_205: (int64 ref)), (var_206: Env6), (var_214: EnvStack10), (var_212: (int64 ref)), (var_213: Env6), (var_20: EnvStack8), (var_21: EnvStack8), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_37: EnvStack7), (var_38: (int64 ref)), (var_39: Env6), (var_232: EnvStack10), (var_227: (int64 ref)), (var_228: Env6), (var_236: EnvStack10), (var_234: (int64 ref)), (var_235: Env6), (var_16: EnvStack8), (var_17: EnvStack8), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_254: EnvStack10), (var_249: (int64 ref)), (var_250: Env6), (var_263: EnvStack10), (var_257: (int64 ref)), (var_258: Env6), (var_273: EnvStack10), (var_266: (int64 ref)), (var_267: Env6), (var_282: EnvStack10), (var_276: (int64 ref)), (var_277: Env6), (var_286: EnvStack10), (var_284: (int64 ref)), (var_285: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_304: EnvStack10), (var_299: (int64 ref)), (var_300: Env6), (var_315: (int64 ref)), (var_316: Env6), (var_53: int64))
        let (var_320: (unit -> float32)) = method_70((var_315: (int64 ref)), (var_316: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
        let (var_438: int64) = 1L
        method_93((var_0: (int64 ref)), (var_1: Env6), (var_52: int64), (var_53: int64), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack7), (var_29: (int64 ref)), (var_30: Env6), (var_31: EnvStack7), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack7), (var_35: (int64 ref)), (var_36: Env6), (var_37: EnvStack7), (var_38: (int64 ref)), (var_39: Env6), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack7), (var_43: (int64 ref)), (var_44: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_62: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: float), (var_48: int64), (var_9: ResizeArray<Env2>), (var_45: ResizeArray<Env2>), (var_320: (unit -> float32)), (var_319: (unit -> unit)), (var_282: EnvStack10), (var_276: (int64 ref)), (var_277: Env6), (var_438: int64))
    else
        method_81((var_45: ResizeArray<Env2>))
        let (var_440: float) = (float var_14)
        (var_15 / var_440)
and method_15 ((var_1: uint64)) ((var_0: Env0)): int32 =
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
and method_76((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env4)): unit =
    // Cuda join point
    // method_77((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64))
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_77", var_7, var_0)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (bool ref)) = var_9.mem_0
    let (var_14: ManagedCuda.CudaStream) = var_9.mem_1
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_22((var_13: (bool ref)), (var_14: ManagedCuda.CudaStream))
    let (var_17: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_15, var_17)
and method_84((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_85((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_85", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_86((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_87((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_87", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_22((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_90 ((var_0: EnvStack10), (var_1: (int64 ref)), (var_2: Env6), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_8: EnvStack7), (var_9: (int64 ref)), (var_10: Env6), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4), (var_28: EnvStack10), (var_29: (int64 ref)), (var_30: Env6), (var_31: EnvStack10), (var_32: (int64 ref)), (var_33: Env6), (var_34: EnvStack8), (var_35: EnvStack8), (var_36: EnvStack7), (var_37: (int64 ref)), (var_38: Env6), (var_39: EnvStack7), (var_40: (int64 ref)), (var_41: Env6), (var_42: EnvStack10), (var_43: (int64 ref)), (var_44: Env6), (var_45: EnvStack10), (var_46: (int64 ref)), (var_47: Env6), (var_48: EnvStack8), (var_49: EnvStack8), (var_50: EnvStack7), (var_51: (int64 ref)), (var_52: Env6), (var_53: EnvStack7), (var_54: (int64 ref)), (var_55: Env6), (var_56: EnvStack10), (var_57: (int64 ref)), (var_58: Env6), (var_59: EnvStack10), (var_60: (int64 ref)), (var_61: Env6), (var_62: EnvStack10), (var_63: (int64 ref)), (var_64: Env6), (var_65: EnvStack10), (var_66: (int64 ref)), (var_67: Env6), (var_68: EnvStack10), (var_69: (int64 ref)), (var_70: Env6), (var_71: EnvStack8), (var_72: EnvStack8), (var_73: EnvStack7), (var_74: (int64 ref)), (var_75: Env6), (var_76: EnvStack10), (var_77: (int64 ref)), (var_78: Env6), (var_79: (int64 ref)), (var_80: Env6), (var_81: int64)) (): unit =
    let (var_82: (uint64 ref)) = var_80.mem_0
    let (var_83: uint64) = method_5((var_82: (uint64 ref)))
    let (var_84: (int64 ref)) = var_76.mem_0
    let (var_85: Env6) = var_76.mem_1
    let (var_86: (uint64 ref)) = var_78.mem_0
    let (var_87: uint64) = method_5((var_86: (uint64 ref)))
    let (var_88: (uint64 ref)) = var_6.mem_0
    let (var_89: uint64) = method_5((var_88: (uint64 ref)))
    let (var_90: int64) = (var_81 * 4L)
    let (var_91: uint64) = (uint64 var_90)
    let (var_92: uint64) = (var_89 + var_91)
    let (var_93: (uint64 ref)) = var_85.mem_0
    let (var_94: uint64) = method_5((var_93: (uint64 ref)))
    method_54((var_22: ManagedCuda.CudaContext), (var_83: uint64), (var_87: uint64), (var_92: uint64), (var_94: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_95: (int64 ref)) = var_68.mem_0
    let (var_96: Env6) = var_68.mem_1
    let (var_97: (uint64 ref)) = var_70.mem_0
    let (var_98: uint64) = method_5((var_97: (uint64 ref)))
    let (var_99: uint64) = method_5((var_93: (uint64 ref)))
    let (var_100: uint64) = method_5((var_86: (uint64 ref)))
    let (var_101: (uint64 ref)) = var_96.mem_0
    let (var_102: uint64) = method_5((var_101: (uint64 ref)))
    method_56((var_22: ManagedCuda.CudaContext), (var_98: uint64), (var_99: uint64), (var_100: uint64), (var_102: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_103: (int64 ref)) = var_65.mem_0
    let (var_104: Env6) = var_65.mem_1
    method_58((var_74: (int64 ref)), (var_75: Env6), (var_68: EnvStack10), (var_65: EnvStack10), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_105: (int64 ref)) = var_73.mem_0
    let (var_106: Env6) = var_73.mem_1
    method_59((var_68: EnvStack10), (var_66: (int64 ref)), (var_67: Env6), (var_73: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_107: (int64 ref)) = var_71.mem_0
    let (var_108: Env6) = var_71.mem_1
    let (var_109: uint64) = method_5((var_101: (uint64 ref)))
    let (var_110: (uint64 ref)) = var_108.mem_0
    let (var_111: uint64) = method_5((var_110: (uint64 ref)))
    method_60((var_22: ManagedCuda.CudaContext), (var_109: uint64), (var_111: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_112: (int64 ref)) = var_59.mem_0
    let (var_113: Env6) = var_59.mem_1
    let (var_114: (int64 ref)) = var_62.mem_0
    let (var_115: Env6) = var_62.mem_1
    let (var_116: (uint64 ref)) = var_61.mem_0
    let (var_117: uint64) = method_5((var_116: (uint64 ref)))
    let (var_118: (uint64 ref)) = var_64.mem_0
    let (var_119: uint64) = method_5((var_118: (uint64 ref)))
    let (var_120: (uint64 ref)) = var_104.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    let (var_122: (uint64 ref)) = var_67.mem_0
    let (var_123: uint64) = method_5((var_122: (uint64 ref)))
    let (var_124: (uint64 ref)) = var_113.mem_0
    let (var_125: uint64) = method_5((var_124: (uint64 ref)))
    let (var_126: (uint64 ref)) = var_115.mem_0
    let (var_127: uint64) = method_5((var_126: (uint64 ref)))
    method_76((var_22: ManagedCuda.CudaContext), (var_117: uint64), (var_119: uint64), (var_121: uint64), (var_123: uint64), (var_125: uint64), (var_127: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_128: (int64 ref)) = var_56.mem_0
    let (var_129: Env6) = var_56.mem_1
    let (var_130: (uint64 ref)) = var_12.mem_0
    let (var_131: uint64) = method_5((var_130: (uint64 ref)))
    let (var_132: (uint64 ref)) = var_58.mem_0
    let (var_133: uint64) = method_5((var_132: (uint64 ref)))
    let (var_134: uint64) = method_5((var_126: (uint64 ref)))
    let (var_135: uint64) = method_5((var_118: (uint64 ref)))
    let (var_136: (uint64 ref)) = var_129.mem_0
    let (var_137: uint64) = method_5((var_136: (uint64 ref)))
    method_91((var_22: ManagedCuda.CudaContext), (var_131: uint64), (var_133: uint64), (var_134: uint64), (var_135: uint64), (var_137: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_138: (int64 ref)) = var_28.mem_0
    let (var_139: Env6) = var_28.mem_1
    let (var_140: (int64 ref)) = var_42.mem_0
    let (var_141: Env6) = var_42.mem_1
    let (var_142: (uint64 ref)) = var_30.mem_0
    let (var_143: uint64) = method_5((var_142: (uint64 ref)))
    let (var_144: (uint64 ref)) = var_44.mem_0
    let (var_145: uint64) = method_5((var_144: (uint64 ref)))
    let (var_146: uint64) = method_5((var_124: (uint64 ref)))
    let (var_147: uint64) = method_5((var_116: (uint64 ref)))
    let (var_148: (uint64 ref)) = var_139.mem_0
    let (var_149: uint64) = method_5((var_148: (uint64 ref)))
    let (var_150: (uint64 ref)) = var_141.mem_0
    let (var_151: uint64) = method_5((var_150: (uint64 ref)))
    method_65((var_22: ManagedCuda.CudaContext), (var_143: uint64), (var_145: uint64), (var_146: uint64), (var_147: uint64), (var_149: uint64), (var_151: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_152: (int64 ref)) = var_45.mem_0
    let (var_153: Env6) = var_45.mem_1
    let (var_154: (uint64 ref)) = var_47.mem_0
    let (var_155: uint64) = method_5((var_154: (uint64 ref)))
    let (var_156: uint64) = method_5((var_136: (uint64 ref)))
    let (var_157: uint64) = method_5((var_132: (uint64 ref)))
    let (var_158: (uint64 ref)) = var_153.mem_0
    let (var_159: uint64) = method_5((var_158: (uint64 ref)))
    method_56((var_22: ManagedCuda.CudaContext), (var_155: uint64), (var_156: uint64), (var_157: uint64), (var_159: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_160: (int64 ref)) = var_50.mem_0
    let (var_161: Env6) = var_50.mem_1
    method_67((var_45: EnvStack10), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_50: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_162: (int64 ref)) = var_53.mem_0
    let (var_163: Env6) = var_53.mem_1
    method_59((var_45: EnvStack10), (var_11: (int64 ref)), (var_12: Env6), (var_53: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_164: (int64 ref)) = var_48.mem_0
    let (var_165: Env6) = var_48.mem_1
    let (var_166: uint64) = method_5((var_158: (uint64 ref)))
    let (var_167: (uint64 ref)) = var_165.mem_0
    let (var_168: uint64) = method_5((var_167: (uint64 ref)))
    method_60((var_22: ManagedCuda.CudaContext), (var_166: uint64), (var_168: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_169: (int64 ref)) = var_31.mem_0
    let (var_170: Env6) = var_31.mem_1
    let (var_171: (uint64 ref)) = var_33.mem_0
    let (var_172: uint64) = method_5((var_171: (uint64 ref)))
    let (var_173: uint64) = method_5((var_150: (uint64 ref)))
    let (var_174: uint64) = method_5((var_144: (uint64 ref)))
    let (var_175: (uint64 ref)) = var_170.mem_0
    let (var_176: uint64) = method_5((var_175: (uint64 ref)))
    method_56((var_22: ManagedCuda.CudaContext), (var_172: uint64), (var_173: uint64), (var_174: uint64), (var_176: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_177: (int64 ref)) = var_36.mem_0
    let (var_178: Env6) = var_36.mem_1
    method_67((var_31: EnvStack10), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_36: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_179: (int64 ref)) = var_39.mem_0
    let (var_180: Env6) = var_39.mem_1
    method_59((var_31: EnvStack10), (var_11: (int64 ref)), (var_12: Env6), (var_39: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_181: (int64 ref)) = var_34.mem_0
    let (var_182: Env6) = var_34.mem_1
    let (var_183: uint64) = method_5((var_175: (uint64 ref)))
    let (var_184: (uint64 ref)) = var_182.mem_0
    let (var_185: uint64) = method_5((var_184: (uint64 ref)))
    method_60((var_22: ManagedCuda.CudaContext), (var_183: uint64), (var_185: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_186: (int64 ref)) = var_0.mem_0
    let (var_187: Env6) = var_0.mem_1
    let (var_188: (uint64 ref)) = var_2.mem_0
    let (var_189: uint64) = method_5((var_188: (uint64 ref)))
    let (var_190: uint64) = method_5((var_148: (uint64 ref)))
    let (var_191: uint64) = method_5((var_142: (uint64 ref)))
    let (var_192: (uint64 ref)) = var_187.mem_0
    let (var_193: uint64) = method_5((var_192: (uint64 ref)))
    method_68((var_22: ManagedCuda.CudaContext), (var_189: uint64), (var_190: uint64), (var_191: uint64), (var_193: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_194: (int64 ref)) = var_8.mem_0
    let (var_195: Env6) = var_8.mem_1
    method_67((var_0: EnvStack10), (var_5: (int64 ref)), (var_6: Env6), (var_7: int64), (var_8: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_196: (int64 ref)) = var_13.mem_0
    let (var_197: Env6) = var_13.mem_1
    method_59((var_0: EnvStack10), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
    let (var_198: (int64 ref)) = var_3.mem_0
    let (var_199: Env6) = var_3.mem_1
    let (var_200: uint64) = method_5((var_192: (uint64 ref)))
    let (var_201: (uint64 ref)) = var_199.mem_0
    let (var_202: uint64) = method_5((var_201: (uint64 ref)))
    method_60((var_22: ManagedCuda.CudaContext), (var_200: uint64), (var_202: uint64), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env4))
and method_93((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_45: int64), (var_46: float), (var_47: int64), (var_48: ResizeArray<Env2>), (var_49: ResizeArray<Env2>), (var_50: (unit -> float32)), (var_51: (unit -> unit)), (var_52: EnvStack10), (var_53: (int64 ref)), (var_54: Env6), (var_55: int64)): float =
    let (var_56: bool) = (var_55 < 64L)
    if var_56 then
        let (var_57: bool) = (var_55 >= 0L)
        let (var_58: bool) = (var_57 = false)
        if var_58 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_59: int64) = (var_55 * 8192L)
        let (var_60: int64) = (var_2 + var_59)
        if var_58 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_61: int64) = (var_3 + var_59)
        let (var_62: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_63: (int64 ref)) = var_62.mem_0
        let (var_64: Env6) = var_62.mem_1
        method_35((var_14: (int64 ref)), (var_15: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_60: int64), (var_63: (int64 ref)), (var_64: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_65: EnvStack10) = method_36((var_63: (int64 ref)), (var_64: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_23: (int64 ref)), (var_24: Env6), (var_53: (int64 ref)), (var_54: Env6), (var_63: (int64 ref)), (var_64: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_66: (int64 ref)) = var_7.mem_0
        let (var_67: Env6) = var_7.mem_1
        let (var_68: (uint64 ref)) = var_67.mem_0
        let (var_69: uint64) = method_5((var_68: (uint64 ref)))
        let (var_70: (uint64 ref)) = var_64.mem_0
        let (var_71: uint64) = method_5((var_70: (uint64 ref)))
        let (var_72: uint64) = method_5((var_70: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_69: uint64), (var_71: uint64), (var_72: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_74: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_75: (int64 ref)) = var_74.mem_0
        let (var_76: Env6) = var_74.mem_1
        let (var_77: uint64) = method_5((var_70: (uint64 ref)))
        let (var_78: (uint64 ref)) = var_76.mem_0
        let (var_79: uint64) = method_5((var_78: (uint64 ref)))
        method_41((var_39: ManagedCuda.CudaContext), (var_77: uint64), (var_79: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_80: EnvStack10) = method_36((var_75: (int64 ref)), (var_76: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_81: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_82: (int64 ref)) = var_81.mem_0
        let (var_83: Env6) = var_81.mem_1
        method_35((var_17: (int64 ref)), (var_18: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_60: int64), (var_82: (int64 ref)), (var_83: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_84: EnvStack10) = method_36((var_82: (int64 ref)), (var_83: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_26: (int64 ref)), (var_27: Env6), (var_53: (int64 ref)), (var_54: Env6), (var_82: (int64 ref)), (var_83: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_85: (int64 ref)) = var_9.mem_0
        let (var_86: Env6) = var_9.mem_1
        let (var_87: (uint64 ref)) = var_86.mem_0
        let (var_88: uint64) = method_5((var_87: (uint64 ref)))
        let (var_89: (uint64 ref)) = var_83.mem_0
        let (var_90: uint64) = method_5((var_89: (uint64 ref)))
        let (var_91: uint64) = method_5((var_89: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_88: uint64), (var_90: uint64), (var_91: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_96: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_97: (int64 ref)) = var_96.mem_0
        let (var_98: Env6) = var_96.mem_1
        let (var_99: uint64) = method_5((var_89: (uint64 ref)))
        let (var_100: (uint64 ref)) = var_98.mem_0
        let (var_101: uint64) = method_5((var_100: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_99: uint64), (var_101: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_102: EnvStack10) = method_36((var_97: (int64 ref)), (var_98: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_103: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_104: (int64 ref)) = var_103.mem_0
        let (var_105: Env6) = var_103.mem_1
        method_35((var_11: (int64 ref)), (var_12: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_60: int64), (var_104: (int64 ref)), (var_105: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_106: EnvStack10) = method_36((var_104: (int64 ref)), (var_105: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        method_72((var_20: (int64 ref)), (var_21: Env6), (var_53: (int64 ref)), (var_54: Env6), (var_104: (int64 ref)), (var_105: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_107: (int64 ref)) = var_5.mem_0
        let (var_108: Env6) = var_5.mem_1
        let (var_109: (uint64 ref)) = var_108.mem_0
        let (var_110: uint64) = method_5((var_109: (uint64 ref)))
        let (var_111: (uint64 ref)) = var_105.mem_0
        let (var_112: uint64) = method_5((var_111: (uint64 ref)))
        let (var_113: uint64) = method_5((var_111: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_110: uint64), (var_112: uint64), (var_113: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_118: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_119: (int64 ref)) = var_118.mem_0
        let (var_120: Env6) = var_118.mem_1
        let (var_121: uint64) = method_5((var_111: (uint64 ref)))
        let (var_122: (uint64 ref)) = var_120.mem_0
        let (var_123: uint64) = method_5((var_122: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_121: uint64), (var_123: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_124: EnvStack10) = method_36((var_119: (int64 ref)), (var_120: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_126: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_127: (int64 ref)) = var_126.mem_0
        let (var_128: Env6) = var_126.mem_1
        let (var_129: uint64) = method_5((var_78: (uint64 ref)))
        let (var_130: uint64) = method_5((var_100: (uint64 ref)))
        let (var_131: (uint64 ref)) = var_128.mem_0
        let (var_132: uint64) = method_5((var_131: (uint64 ref)))
        method_46((var_39: ManagedCuda.CudaContext), (var_129: uint64), (var_130: uint64), (var_132: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_133: EnvStack10) = method_36((var_127: (int64 ref)), (var_128: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_135: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_136: (int64 ref)) = var_135.mem_0
        let (var_137: Env6) = var_135.mem_1
        let (var_138: (uint64 ref)) = var_54.mem_0
        let (var_139: uint64) = method_5((var_138: (uint64 ref)))
        let (var_140: uint64) = method_5((var_122: (uint64 ref)))
        let (var_141: (uint64 ref)) = var_137.mem_0
        let (var_142: uint64) = method_5((var_141: (uint64 ref)))
        method_46((var_39: ManagedCuda.CudaContext), (var_139: uint64), (var_140: uint64), (var_142: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_143: EnvStack10) = method_36((var_136: (int64 ref)), (var_137: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_145: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_146: (int64 ref)) = var_145.mem_0
        let (var_147: Env6) = var_145.mem_1
        let (var_148: uint64) = method_5((var_131: (uint64 ref)))
        let (var_149: uint64) = method_5((var_141: (uint64 ref)))
        let (var_150: (uint64 ref)) = var_147.mem_0
        let (var_151: uint64) = method_5((var_150: (uint64 ref)))
        method_73((var_39: ManagedCuda.CudaContext), (var_148: uint64), (var_149: uint64), (var_151: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_152: EnvStack10) = method_36((var_146: (int64 ref)), (var_147: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_153: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_154: (int64 ref)) = var_153.mem_0
        let (var_155: Env6) = var_153.mem_1
        method_48((var_31: (int64 ref)), (var_32: Env6), (var_146: (int64 ref)), (var_147: Env6), (var_154: (int64 ref)), (var_155: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_156: EnvStack10) = method_36((var_154: (int64 ref)), (var_155: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_157: (int64 ref)) = var_29.mem_0
        let (var_158: Env6) = var_29.mem_1
        let (var_159: (uint64 ref)) = var_158.mem_0
        let (var_160: uint64) = method_5((var_159: (uint64 ref)))
        let (var_161: (uint64 ref)) = var_155.mem_0
        let (var_162: uint64) = method_5((var_161: (uint64 ref)))
        let (var_163: uint64) = method_5((var_161: (uint64 ref)))
        method_38((var_39: ManagedCuda.CudaContext), (var_160: uint64), (var_162: uint64), (var_163: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_168: Env2) = method_34((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_169: (int64 ref)) = var_168.mem_0
        let (var_170: Env6) = var_168.mem_1
        let (var_171: uint64) = method_5((var_161: (uint64 ref)))
        let (var_172: (uint64 ref)) = var_170.mem_0
        let (var_173: uint64) = method_5((var_172: (uint64 ref)))
        method_44((var_39: ManagedCuda.CudaContext), (var_171: uint64), (var_173: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_174: EnvStack10) = method_36((var_169: (int64 ref)), (var_170: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_175: uint64) = method_5((var_172: (uint64 ref)))
        let (var_176: (uint64 ref)) = var_1.mem_0
        let (var_177: uint64) = method_5((var_176: (uint64 ref)))
        let (var_178: int64) = (var_61 * 4L)
        let (var_179: uint64) = (uint64 var_178)
        let (var_180: uint64) = (var_177 + var_179)
        let (var_184: Env2) = method_49((var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_185: (int64 ref)) = var_184.mem_0
        let (var_186: Env6) = var_184.mem_1
        let (var_187: (uint64 ref)) = var_186.mem_0
        let (var_188: uint64) = method_5((var_187: (uint64 ref)))
        method_50((var_39: ManagedCuda.CudaContext), (var_175: uint64), (var_180: uint64), (var_188: uint64), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
        let (var_189: (unit -> unit)) = method_75((var_51: (unit -> unit)), (var_65: EnvStack10), (var_63: (int64 ref)), (var_64: Env6), (var_6: EnvStack8), (var_7: EnvStack8), (var_0: (int64 ref)), (var_1: Env6), (var_60: int64), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_52: EnvStack10), (var_53: (int64 ref)), (var_54: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_80: EnvStack10), (var_75: (int64 ref)), (var_76: Env6), (var_84: EnvStack10), (var_82: (int64 ref)), (var_83: Env6), (var_8: EnvStack8), (var_9: EnvStack8), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_102: EnvStack10), (var_97: (int64 ref)), (var_98: Env6), (var_106: EnvStack10), (var_104: (int64 ref)), (var_105: Env6), (var_4: EnvStack8), (var_5: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_124: EnvStack10), (var_119: (int64 ref)), (var_120: Env6), (var_133: EnvStack10), (var_127: (int64 ref)), (var_128: Env6), (var_143: EnvStack10), (var_136: (int64 ref)), (var_137: Env6), (var_152: EnvStack10), (var_146: (int64 ref)), (var_147: Env6), (var_156: EnvStack10), (var_154: (int64 ref)), (var_155: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_174: EnvStack10), (var_169: (int64 ref)), (var_170: Env6), (var_185: (int64 ref)), (var_186: Env6), (var_61: int64))
        let (var_190: (unit -> float32)) = method_78((var_185: (int64 ref)), (var_186: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_50: (unit -> float32)))
        let (var_191: int64) = (var_55 + 1L)
        method_93((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_45: int64), (var_46: float), (var_47: int64), (var_48: ResizeArray<Env2>), (var_49: ResizeArray<Env2>), (var_190: (unit -> float32)), (var_189: (unit -> unit)), (var_152: EnvStack10), (var_146: (int64 ref)), (var_147: Env6), (var_191: int64))
    else
        // Done with foru...
        let (var_193: float32) = var_50()
        let (var_194: float) = (float var_193)
        let (var_195: float) = (var_46 + var_194)
        let (var_204: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_80((var_53: (int64 ref)), (var_54: Env6), (var_204: ResizeArray<Env2>))
        let (var_205: int64) = (var_45 + 1L)
        if (System.Double.IsNaN var_195) then
            method_81((var_49: ResizeArray<Env2>))
            // Is nan...
            method_81((var_40: ResizeArray<Env2>))
            // Done with the net...
            method_81((var_204: ResizeArray<Env2>))
            let (var_206: float) = (float var_205)
            (var_195 / var_206)
        else
            var_51()
            method_83((var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_40: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4))
            method_81((var_49: ResizeArray<Env2>))
            // Done with body...
            method_81((var_40: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_208: int64) = (var_47 + 1L)
            method_89((var_0: (int64 ref)), (var_1: Env6), (var_33: ManagedCuda.CudaBlas.CudaBlas), (var_34: ManagedCuda.CudaRand.CudaRandDevice), (var_35: (uint64 ref)), (var_36: uint64), (var_37: ResizeArray<Env0>), (var_38: ResizeArray<Env1>), (var_39: ManagedCuda.CudaContext), (var_48: ResizeArray<Env2>), (var_41: ResizeArray<Env3>), (var_42: ManagedCuda.BasicTypes.CUmodule), (var_43: (int64 ref)), (var_44: Env4), (var_205: int64), (var_195: float), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack7), (var_11: (int64 ref)), (var_12: Env6), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env6), (var_16: EnvStack7), (var_17: (int64 ref)), (var_18: Env6), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env6), (var_22: EnvStack7), (var_23: (int64 ref)), (var_24: Env6), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env6), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack7), (var_31: (int64 ref)), (var_32: Env6), (var_204: ResizeArray<Env2>), (var_53: (int64 ref)), (var_54: Env6), (var_208: int64))
and method_91((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: (int64 ref)), (var_8: Env4)): unit =
    // Cuda join point
    // method_92((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64))
    let (var_9: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_92", var_6, var_0)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_9.set_GridDimensions(var_10)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_9.set_BlockDimensions(var_11)
    let (var_12: (bool ref)) = var_8.mem_0
    let (var_13: ManagedCuda.CudaStream) = var_8.mem_1
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_22((var_12: (bool ref)), (var_13: ManagedCuda.CudaStream))
    let (var_16: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5|]: (System.Object [])
    var_9.RunAsync(var_14, var_16)
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
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_40: ResizeArray<Env0>), (var_39: (uint64 ref)), (var_35: uint64), (var_41: ResizeArray<Env1>))
let (var_42: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_43: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_42)
let (var_44: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_45: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_46: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_44, var_45)
let (var_55: ResizeArray<Env2>) = ResizeArray<Env2>()
let (var_64: ResizeArray<Env3>) = ResizeArray<Env3>()
let (var_65: (bool ref)) = (ref true)
let (var_66: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_67: Env3) = method_7((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_68: (int64 ref)) = var_67.mem_0
let (var_69: Env4) = var_67.mem_1
let (var_71: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_72: int64) = var_71.LongLength
let (var_73: bool) = (var_72 >= 0L)
let (var_74: bool) = (var_73 = false)
if var_74 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_79: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_72))
let (var_80: int64) = 0L
method_9((var_79: (uint8 [])), (var_71: (char [])), (var_72: int64), (var_80: int64))
let (var_81: int64) = var_79.LongLength
let (var_82: bool) = (var_81 > 0L)
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_84: bool) = (var_81 = 1115394L)
let (var_85: bool) = (var_84 = false)
if var_85 then
    (failwith "The dimensions must match.")
else
    ()
let (var_86: int64) = 1115394L
let (var_87: int64) = 0L
let (var_88: int64) = 1L
let (var_89: Env5) = method_10((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_86: int64), (var_79: (uint8 [])), (var_87: int64), (var_88: int64))
let (var_90: Env2) = var_89.mem_0
let (var_91: (int64 ref)) = var_90.mem_0
let (var_92: Env6) = var_90.mem_1
let (var_93: (uint64 ref)) = var_92.mem_0
let (var_94: uint64) = method_5((var_93: (uint64 ref)))
let (var_98: Env2) = method_17((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_99: (int64 ref)) = var_98.mem_0
let (var_100: Env6) = var_98.mem_1
let (var_101: (uint64 ref)) = var_100.mem_0
let (var_102: uint64) = method_5((var_101: (uint64 ref)))
method_18((var_1: ManagedCuda.CudaContext), (var_94: uint64), (var_102: uint64), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_103: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_104: (int64 ref)) = var_103.mem_0
let (var_105: Env6) = var_103.mem_1
method_24((var_104: (int64 ref)), (var_105: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_106: EnvStack7) = method_25((var_104: (int64 ref)), (var_105: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_107: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_108: (int64 ref)) = var_107.mem_0
let (var_109: Env6) = var_107.mem_1
method_27((var_108: (int64 ref)), (var_109: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_110: EnvStack7) = method_25((var_108: (int64 ref)), (var_109: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_111: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_112: (int64 ref)) = var_111.mem_0
let (var_113: Env6) = var_111.mem_1
method_27((var_112: (int64 ref)), (var_113: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_114: EnvStack7) = method_25((var_112: (int64 ref)), (var_113: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_115: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_116: (int64 ref)) = var_115.mem_0
let (var_117: Env6) = var_115.mem_1
method_24((var_116: (int64 ref)), (var_117: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_118: EnvStack7) = method_25((var_116: (int64 ref)), (var_117: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_119: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_120: (int64 ref)) = var_119.mem_0
let (var_121: Env6) = var_119.mem_1
method_27((var_120: (int64 ref)), (var_121: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_122: EnvStack7) = method_25((var_120: (int64 ref)), (var_121: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_123: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_124: (int64 ref)) = var_123.mem_0
let (var_125: Env6) = var_123.mem_1
method_27((var_124: (int64 ref)), (var_125: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_126: EnvStack7) = method_25((var_124: (int64 ref)), (var_125: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_127: EnvStack8) = method_28((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_128: EnvStack8) = method_31((var_127: EnvStack8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_129: EnvStack8) = method_28((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_130: EnvStack8) = method_31((var_129: EnvStack8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_131: EnvStack8) = method_28((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_132: EnvStack8) = method_31((var_131: EnvStack8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_133: Env2) = method_23((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_134: (int64 ref)) = var_133.mem_0
let (var_135: Env6) = var_133.mem_1
method_27((var_134: (int64 ref)), (var_135: Env6), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_136: EnvStack7) = method_25((var_134: (int64 ref)), (var_135: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_137: EnvStack8) = method_28((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_138: EnvStack8) = method_31((var_137: EnvStack8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_139: int64) = 0L
method_32((var_99: (int64 ref)), (var_100: Env6), (var_132: EnvStack8), (var_131: EnvStack8), (var_128: EnvStack8), (var_127: EnvStack8), (var_130: EnvStack8), (var_129: EnvStack8), (var_114: EnvStack7), (var_112: (int64 ref)), (var_113: Env6), (var_106: EnvStack7), (var_104: (int64 ref)), (var_105: Env6), (var_110: EnvStack7), (var_108: (int64 ref)), (var_109: Env6), (var_126: EnvStack7), (var_124: (int64 ref)), (var_125: Env6), (var_118: EnvStack7), (var_116: (int64 ref)), (var_117: Env6), (var_122: EnvStack7), (var_120: (int64 ref)), (var_121: Env6), (var_138: EnvStack8), (var_137: EnvStack8), (var_136: EnvStack7), (var_134: (int64 ref)), (var_135: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_139: int64))
method_94((var_64: ResizeArray<Env3>))
method_81((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_140: uint64) = method_5((var_39: (uint64 ref)))
let (var_141: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_140)
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_141)
var_1.FreeMemory(var_142)
var_39 := 0UL
var_1.Dispose()

