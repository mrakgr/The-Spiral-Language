module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_23(float * var_0, float * var_1, float * var_2);
    __global__ void method_25(float * var_0, float * var_1);
    __global__ void method_27(float * var_0, float * var_1);
    __global__ void method_28(float * var_0, float * var_1, float * var_2);
    __global__ void method_30(float * var_0, float * var_1, float * var_2);
    __global__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_34(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_37(float * var_0, float * var_1);
    __global__ void method_41(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_43(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_47(float * var_0, float * var_1, float * var_2);
    __global__ void method_49(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_56(float * var_0, float * var_1);
    __global__ void method_57(float * var_0, float * var_1);
    __global__ void method_61(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_24(long long int * var_0);
    __device__ char method_26(long long int * var_0);
    __device__ char method_31(long long int * var_0, float * var_1);
    __device__ char method_38(long long int * var_0, float * var_1);
    __device__ char method_39(long long int * var_0, float * var_1);
    __device__ char method_40(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_58(long long int * var_0);
    
    __global__ void method_16(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_17(var_6)) {
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
            while (method_18(var_35)) {
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
    __global__ void method_23(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_18(var_7)) {
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
            while (method_24(var_18)) {
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
    __global__ void method_25(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_26(var_6)) {
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
    __global__ void method_27(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_26(var_6)) {
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
    __global__ void method_28(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_26(var_7)) {
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
    __global__ void method_30(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_31(var_8, var_9)) {
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
    __global__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_26(var_8)) {
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
    __global__ void method_34(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_26(var_8)) {
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
    __global__ void method_37(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_18(var_6)) {
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
            while (method_38(var_21, var_22)) {
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
            while (method_39(var_41, var_42)) {
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
                    while (method_40(var_44, var_69, var_70)) {
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
    __global__ void method_41(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_26(var_10)) {
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
    __global__ void method_43(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_26(var_8)) {
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
    __global__ void method_47(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_26(var_7)) {
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
    __global__ void method_49(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_26(var_10)) {
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
    __global__ void method_56(float * var_0, float * var_1) {
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
    __global__ void method_57(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_58(var_6)) {
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
    __global__ void method_61(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (128 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_26(var_9)) {
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
    __device__ char method_17(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 35692544);
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_24(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_26(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8192);
    }
    __device__ char method_31(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8192);
    }
    __device__ char method_38(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 64);
    }
    __device__ char method_39(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_40(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_58(long long int * var_0) {
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
    val mem_1: EnvHeap4
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap4 =
    {
    mem_0: (bool ref)
    mem_1: ManagedCuda.CudaStream
    }
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
and EnvHeap7 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: ResizeArray<Env0>
    mem_3: ResizeArray<Env1>
    }
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
and method_7((var_0: EnvHeap4), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule)): Env3 =
    let (var_11: (int64 ref)) = (ref 0L)
    method_8((var_11: (int64 ref)), (var_0: EnvHeap4), (var_9: ResizeArray<Env3>))
    (Env3(var_11, var_0))
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: int64), (var_13: (uint8 [])), (var_14: int64), (var_15: int64)): Env5 =
    let (var_16: int64) = (var_12 * var_15)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: uint64) = (uint64 var_14)
    let (var_21: uint64) = (var_20 + var_19)
    let (var_22: EnvHeap7) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap7)
    let (var_23: Env2) = method_11((var_22: EnvHeap7), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_16: int64))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env6) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_33: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_29, var_31, var_32)
    if var_33 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_33)
    var_17.Free()
    (Env5((Env2(var_24, var_25))))
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_11((var_0: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: EnvHeap4), (var_13: int64)): Env2 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: ResizeArray<Env0>) = var_0.mem_2
    let (var_17: ResizeArray<Env1>) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env6) = method_12((var_16: ResizeArray<Env0>), (var_14: (uint64 ref)), (var_15: uint64), (var_17: ResizeArray<Env1>), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_15((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: ResizeArray<Env2>))
    (Env2(var_24, (Env6(var_23))))
and method_19((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_20((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_47: ManagedCuda.CudaRand.CudaRandDevice), (var_48: (uint64 ref)), (var_49: uint64), (var_50: ResizeArray<Env0>), (var_51: ResizeArray<Env1>), (var_52: ManagedCuda.CudaContext), (var_53: ResizeArray<Env2>), (var_54: ResizeArray<Env3>), (var_55: ManagedCuda.BasicTypes.CUmodule), (var_56: (int64 ref)), (var_57: EnvHeap4), (var_58: int64)): unit =
    let (var_59: bool) = (var_58 < 5L)
    if var_59 then
        let (var_60: int64) = 0L
        let (var_61: float) = 0.000000
        let (var_62: int64) = 0L
        let (var_63: float) = method_21((var_0: (int64 ref)), (var_1: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_47: ManagedCuda.CudaRand.CudaRandDevice), (var_48: (uint64 ref)), (var_49: uint64), (var_50: ResizeArray<Env0>), (var_51: ResizeArray<Env1>), (var_52: ManagedCuda.CudaContext), (var_53: ResizeArray<Env2>), (var_54: ResizeArray<Env3>), (var_55: ManagedCuda.BasicTypes.CUmodule), (var_56: (int64 ref)), (var_57: EnvHeap4), (var_60: int64), (var_61: float), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_62: int64))
        let (var_64: string) = System.String.Format("Training: {0}",var_63)
        let (var_65: string) = System.String.Format("{0}",var_64)
        System.Console.WriteLine(var_65)
        if (System.Double.IsNaN var_63) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_66: int64) = (var_58 + 1L)
            method_20((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_47: ManagedCuda.CudaRand.CudaRandDevice), (var_48: (uint64 ref)), (var_49: uint64), (var_50: ResizeArray<Env0>), (var_51: ResizeArray<Env1>), (var_52: ManagedCuda.CudaContext), (var_53: ResizeArray<Env2>), (var_54: ResizeArray<Env3>), (var_55: ManagedCuda.BasicTypes.CUmodule), (var_56: (int64 ref)), (var_57: EnvHeap4), (var_66: int64))
    else
        ()
and method_63((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_64
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_53((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_54
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
and method_8((var_0: (int64 ref)), (var_1: EnvHeap4), (var_2: ResizeArray<Env3>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env3(var_0, var_1)))
and method_12((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): Env6 =
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
            let (var_16: (Env0 -> (Env0 -> int32))) = method_13
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
                let (var_26: (Env0 -> (Env0 -> int32))) = method_13
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
and method_15((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, (Env6(var_1)))))
and method_21((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_60: int64)): float =
    let (var_61: bool) = (var_60 < 271L)
    if var_61 then
        let (var_62: bool) = (var_60 >= 0L)
        let (var_63: bool) = (var_62 = false)
        if var_63 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_64: int64) = (var_60 * 524288L)
        if var_63 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_65: int64) = (524288L + var_64)
        let (var_66: EnvHeap7) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap7)
        let (var_67: (uint64 ref)) = var_66.mem_0
        let (var_68: uint64) = var_66.mem_1
        let (var_69: ResizeArray<Env0>) = var_66.mem_2
        let (var_70: ResizeArray<Env1>) = var_66.mem_3
        method_1((var_69: ResizeArray<Env0>), (var_67: (uint64 ref)), (var_68: uint64), (var_70: ResizeArray<Env1>))
        let (var_74: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_278: int64) = 32768L
        let (var_279: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_278: int64))
        let (var_280: (int64 ref)) = var_279.mem_0
        let (var_281: Env6) = var_279.mem_1
        method_22((var_34: (int64 ref)), (var_35: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_64: int64), (var_280: (int64 ref)), (var_281: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_282: int64) = 32768L
        let (var_283: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_282: int64))
        let (var_284: (int64 ref)) = var_283.mem_0
        let (var_285: Env6) = var_283.mem_1
        let (var_286: (bool ref)) = var_13.mem_0
        let (var_287: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_288: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_289: (uint64 ref)) = var_285.mem_0
        let (var_290: uint64) = method_5((var_289: (uint64 ref)))
        let (var_291: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_290)
        let (var_292: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_291)
        let (var_293: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_292, 0uy, var_293, var_288)
        let (var_294: (uint64 ref)) = var_23.mem_0
        let (var_295: uint64) = method_5((var_294: (uint64 ref)))
        let (var_296: (uint64 ref)) = var_281.mem_0
        let (var_297: uint64) = method_5((var_296: (uint64 ref)))
        let (var_298: uint64) = method_5((var_296: (uint64 ref)))
        // Cuda join point
        // method_23((var_295: uint64), (var_297: uint64), (var_298: uint64))
        let (var_299: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_300: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_299.set_GridDimensions(var_300)
        let (var_301: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_299.set_BlockDimensions(var_301)
        let (var_302: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_304: (System.Object [])) = [|var_295; var_297; var_298|]: (System.Object [])
        var_299.RunAsync(var_302, var_304)
        let (var_306: int64) = 32768L
        let (var_307: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_306: int64))
        let (var_308: (int64 ref)) = var_307.mem_0
        let (var_309: Env6) = var_307.mem_1
        let (var_310: uint64) = method_5((var_296: (uint64 ref)))
        let (var_311: (uint64 ref)) = var_309.mem_0
        let (var_312: uint64) = method_5((var_311: (uint64 ref)))
        // Cuda join point
        // method_25((var_310: uint64), (var_312: uint64))
        let (var_313: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_314: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_313.set_GridDimensions(var_314)
        let (var_315: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_313.set_BlockDimensions(var_315)
        let (var_316: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_318: (System.Object [])) = [|var_310; var_312|]: (System.Object [])
        var_313.RunAsync(var_316, var_318)
        let (var_319: int64) = 32768L
        let (var_320: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_319: int64))
        let (var_321: (int64 ref)) = var_320.mem_0
        let (var_322: Env6) = var_320.mem_1
        let (var_323: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_324: (uint64 ref)) = var_322.mem_0
        let (var_325: uint64) = method_5((var_324: (uint64 ref)))
        let (var_326: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_325)
        let (var_327: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_326)
        let (var_328: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_327, 0uy, var_328, var_323)
        let (var_329: int64) = 32768L
        let (var_330: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_329: int64))
        let (var_331: (int64 ref)) = var_330.mem_0
        let (var_332: Env6) = var_330.mem_1
        method_22((var_38: (int64 ref)), (var_39: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_64: int64), (var_331: (int64 ref)), (var_332: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_333: int64) = 32768L
        let (var_334: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_333: int64))
        let (var_335: (int64 ref)) = var_334.mem_0
        let (var_336: Env6) = var_334.mem_1
        let (var_337: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_338: (uint64 ref)) = var_336.mem_0
        let (var_339: uint64) = method_5((var_338: (uint64 ref)))
        let (var_340: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_339)
        let (var_341: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_340)
        let (var_342: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_341, 0uy, var_342, var_337)
        let (var_343: (uint64 ref)) = var_27.mem_0
        let (var_344: uint64) = method_5((var_343: (uint64 ref)))
        let (var_345: (uint64 ref)) = var_332.mem_0
        let (var_346: uint64) = method_5((var_345: (uint64 ref)))
        let (var_347: uint64) = method_5((var_345: (uint64 ref)))
        // Cuda join point
        // method_23((var_344: uint64), (var_346: uint64), (var_347: uint64))
        let (var_348: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_349: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_348.set_GridDimensions(var_349)
        let (var_350: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_348.set_BlockDimensions(var_350)
        let (var_351: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_353: (System.Object [])) = [|var_344; var_346; var_347|]: (System.Object [])
        var_348.RunAsync(var_351, var_353)
        let (var_358: int64) = 32768L
        let (var_359: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_358: int64))
        let (var_360: (int64 ref)) = var_359.mem_0
        let (var_361: Env6) = var_359.mem_1
        let (var_362: uint64) = method_5((var_345: (uint64 ref)))
        let (var_363: (uint64 ref)) = var_361.mem_0
        let (var_364: uint64) = method_5((var_363: (uint64 ref)))
        // Cuda join point
        // method_27((var_362: uint64), (var_364: uint64))
        let (var_365: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_366: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_365.set_GridDimensions(var_366)
        let (var_367: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_365.set_BlockDimensions(var_367)
        let (var_368: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_370: (System.Object [])) = [|var_362; var_364|]: (System.Object [])
        var_365.RunAsync(var_368, var_370)
        let (var_371: int64) = 32768L
        let (var_372: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_371: int64))
        let (var_373: (int64 ref)) = var_372.mem_0
        let (var_374: Env6) = var_372.mem_1
        let (var_375: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_376: (uint64 ref)) = var_374.mem_0
        let (var_377: uint64) = method_5((var_376: (uint64 ref)))
        let (var_378: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_377)
        let (var_379: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_378)
        let (var_380: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_379, 0uy, var_380, var_375)
        let (var_382: int64) = 32768L
        let (var_383: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_382: int64))
        let (var_384: (int64 ref)) = var_383.mem_0
        let (var_385: Env6) = var_383.mem_1
        let (var_386: uint64) = method_5((var_311: (uint64 ref)))
        let (var_387: uint64) = method_5((var_363: (uint64 ref)))
        let (var_388: (uint64 ref)) = var_385.mem_0
        let (var_389: uint64) = method_5((var_388: (uint64 ref)))
        // Cuda join point
        // method_28((var_386: uint64), (var_387: uint64), (var_389: uint64))
        let (var_390: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_391: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_390.set_GridDimensions(var_391)
        let (var_392: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_390.set_BlockDimensions(var_392)
        let (var_393: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_395: (System.Object [])) = [|var_386; var_387; var_389|]: (System.Object [])
        var_390.RunAsync(var_393, var_395)
        let (var_396: int64) = 32768L
        let (var_397: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_396: int64))
        let (var_398: (int64 ref)) = var_397.mem_0
        let (var_399: Env6) = var_397.mem_1
        let (var_400: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_401: (uint64 ref)) = var_399.mem_0
        let (var_402: uint64) = method_5((var_401: (uint64 ref)))
        let (var_403: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_402)
        let (var_404: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_403)
        let (var_405: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_404, 0uy, var_405, var_400)
        let (var_406: int64) = 32768L
        let (var_407: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_406: int64))
        let (var_408: (int64 ref)) = var_407.mem_0
        let (var_409: Env6) = var_407.mem_1
        method_29((var_58: (int64 ref)), (var_59: Env6), (var_384: (int64 ref)), (var_385: Env6), (var_408: (int64 ref)), (var_409: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_410: int64) = 32768L
        let (var_411: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_410: int64))
        let (var_412: (int64 ref)) = var_411.mem_0
        let (var_413: Env6) = var_411.mem_1
        let (var_414: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_415: (uint64 ref)) = var_413.mem_0
        let (var_416: uint64) = method_5((var_415: (uint64 ref)))
        let (var_417: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_416)
        let (var_418: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_417)
        let (var_419: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_418, 0uy, var_419, var_414)
        let (var_420: (uint64 ref)) = var_55.mem_0
        let (var_421: uint64) = method_5((var_420: (uint64 ref)))
        let (var_422: (uint64 ref)) = var_409.mem_0
        let (var_423: uint64) = method_5((var_422: (uint64 ref)))
        let (var_424: uint64) = method_5((var_422: (uint64 ref)))
        // Cuda join point
        // method_23((var_421: uint64), (var_423: uint64), (var_424: uint64))
        let (var_425: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_426: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_425.set_GridDimensions(var_426)
        let (var_427: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_425.set_BlockDimensions(var_427)
        let (var_428: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_430: (System.Object [])) = [|var_421; var_423; var_424|]: (System.Object [])
        var_425.RunAsync(var_428, var_430)
        let (var_435: int64) = 32768L
        let (var_436: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_435: int64))
        let (var_437: (int64 ref)) = var_436.mem_0
        let (var_438: Env6) = var_436.mem_1
        let (var_439: uint64) = method_5((var_422: (uint64 ref)))
        let (var_440: (uint64 ref)) = var_438.mem_0
        let (var_441: uint64) = method_5((var_440: (uint64 ref)))
        // Cuda join point
        // method_27((var_439: uint64), (var_441: uint64))
        let (var_442: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_443: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_442.set_GridDimensions(var_443)
        let (var_444: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_442.set_BlockDimensions(var_444)
        let (var_445: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_447: (System.Object [])) = [|var_439; var_441|]: (System.Object [])
        var_442.RunAsync(var_445, var_447)
        let (var_448: int64) = 32768L
        let (var_449: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_448: int64))
        let (var_450: (int64 ref)) = var_449.mem_0
        let (var_451: Env6) = var_449.mem_1
        let (var_452: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_453: (uint64 ref)) = var_451.mem_0
        let (var_454: uint64) = method_5((var_453: (uint64 ref)))
        let (var_455: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_454)
        let (var_456: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_455)
        let (var_457: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_456, 0uy, var_457, var_452)
        let (var_458: uint64) = method_5((var_440: (uint64 ref)))
        let (var_459: (uint64 ref)) = var_1.mem_0
        let (var_460: uint64) = method_5((var_459: (uint64 ref)))
        let (var_461: int64) = (var_65 * 4L)
        let (var_462: uint64) = (uint64 var_461)
        let (var_463: uint64) = (var_460 + var_462)
        let (var_467: int64) = 4L
        let (var_468: Env2) = method_11((var_66: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_467: int64))
        let (var_469: (int64 ref)) = var_468.mem_0
        let (var_470: Env6) = var_468.mem_1
        let (var_471: (uint64 ref)) = var_470.mem_0
        let (var_472: uint64) = method_5((var_471: (uint64 ref)))
        // Cuda join point
        // method_30((var_458: uint64), (var_463: uint64), (var_472: uint64))
        let (var_473: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_11, var_8)
        let (var_474: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_473.set_GridDimensions(var_474)
        let (var_475: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_473.set_BlockDimensions(var_475)
        let (var_476: ManagedCuda.BasicTypes.CUstream) = method_19((var_286: (bool ref)), (var_287: ManagedCuda.CudaStream))
        let (var_478: (System.Object [])) = [|var_458; var_463; var_472|]: (System.Object [])
        var_473.RunAsync(var_476, var_478)
        let (var_479: (unit -> unit)) = method_32((var_284: (int64 ref)), (var_285: Env6), (var_280: (int64 ref)), (var_281: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_64: int64), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_321: (int64 ref)), (var_322: Env6), (var_308: (int64 ref)), (var_309: Env6), (var_335: (int64 ref)), (var_336: Env6), (var_331: (int64 ref)), (var_332: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_373: (int64 ref)), (var_374: Env6), (var_360: (int64 ref)), (var_361: Env6), (var_398: (int64 ref)), (var_399: Env6), (var_384: (int64 ref)), (var_385: Env6), (var_412: (int64 ref)), (var_413: Env6), (var_408: (int64 ref)), (var_409: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_450: (int64 ref)), (var_451: Env6), (var_437: (int64 ref)), (var_438: Env6), (var_469: (int64 ref)), (var_470: Env6), (var_65: int64))
        let (var_480: (unit -> float32)) = method_44((var_469: (int64 ref)), (var_470: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_782: int64) = 1L
        method_51((var_0: (int64 ref)), (var_1: Env6), (var_64: int64), (var_65: int64), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_74: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_60: int64), (var_9: ResizeArray<Env2>), (var_480: (unit -> float32)), (var_479: (unit -> unit)), (var_398: (int64 ref)), (var_399: Env6), (var_384: (int64 ref)), (var_385: Env6), (var_782: int64))
    else
        let (var_784: float) = (float var_14)
        (var_15 / var_784)
and method_64 ((var_0: Env3)): unit =
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
and method_54 ((var_0: Env2)): unit =
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
and method_13 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_22((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: int64), (var_5: (int64 ref)), (var_6: Env6), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: EnvHeap4)): unit =
    let (var_19: ManagedCuda.CudaBlas.CudaBlasHandle) = var_7.get_CublasHandle()
    let (var_20: (bool ref)) = var_18.mem_0
    let (var_21: ManagedCuda.CudaStream) = var_18.mem_1
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_19((var_20: (bool ref)), (var_21: ManagedCuda.CudaStream))
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
and method_29((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_19((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
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
and method_32 ((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_11: (int64 ref)), (var_12: Env6), (var_13: (int64 ref)), (var_14: Env6), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4), (var_27: (int64 ref)), (var_28: Env6), (var_29: (int64 ref)), (var_30: Env6), (var_31: (int64 ref)), (var_32: Env6), (var_33: (int64 ref)), (var_34: Env6), (var_35: (int64 ref)), (var_36: Env6), (var_37: (int64 ref)), (var_38: Env6), (var_39: (int64 ref)), (var_40: Env6), (var_41: (int64 ref)), (var_42: Env6), (var_43: (int64 ref)), (var_44: Env6), (var_45: (int64 ref)), (var_46: Env6), (var_47: (int64 ref)), (var_48: Env6), (var_49: (int64 ref)), (var_50: Env6), (var_51: (int64 ref)), (var_52: Env6), (var_53: (int64 ref)), (var_54: Env6), (var_55: (int64 ref)), (var_56: Env6), (var_57: (int64 ref)), (var_58: Env6), (var_59: (int64 ref)), (var_60: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_63: (int64 ref)), (var_64: Env6), (var_65: (int64 ref)), (var_66: Env6), (var_67: (int64 ref)), (var_68: Env6), (var_69: int64)) (): unit =
    let (var_70: (uint64 ref)) = var_68.mem_0
    let (var_71: uint64) = method_5((var_70: (uint64 ref)))
    let (var_72: (uint64 ref)) = var_66.mem_0
    let (var_73: uint64) = method_5((var_72: (uint64 ref)))
    let (var_74: (uint64 ref)) = var_9.mem_0
    let (var_75: uint64) = method_5((var_74: (uint64 ref)))
    let (var_76: int64) = (var_69 * 4L)
    let (var_77: uint64) = (uint64 var_76)
    let (var_78: uint64) = (var_75 + var_77)
    let (var_79: (uint64 ref)) = var_64.mem_0
    let (var_80: uint64) = method_5((var_79: (uint64 ref)))
    // Cuda join point
    // method_33((var_71: uint64), (var_73: uint64), (var_78: uint64), (var_80: uint64))
    let (var_81: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_24, var_21)
    let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_81.set_GridDimensions(var_82)
    let (var_83: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_81.set_BlockDimensions(var_83)
    let (var_84: (bool ref)) = var_26.mem_0
    let (var_85: ManagedCuda.CudaStream) = var_26.mem_1
    let (var_86: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_88: (System.Object [])) = [|var_71; var_73; var_78; var_80|]: (System.Object [])
    var_81.RunAsync(var_86, var_88)
    let (var_89: (uint64 ref)) = var_54.mem_0
    let (var_90: uint64) = method_5((var_89: (uint64 ref)))
    let (var_91: uint64) = method_5((var_79: (uint64 ref)))
    let (var_92: uint64) = method_5((var_72: (uint64 ref)))
    let (var_93: (uint64 ref)) = var_52.mem_0
    let (var_94: uint64) = method_5((var_93: (uint64 ref)))
    // Cuda join point
    // method_34((var_90: uint64), (var_91: uint64), (var_92: uint64), (var_94: uint64))
    let (var_95: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_24, var_21)
    let (var_96: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_95.set_GridDimensions(var_96)
    let (var_97: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_95.set_BlockDimensions(var_97)
    let (var_98: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_100: (System.Object [])) = [|var_90; var_91; var_92; var_94|]: (System.Object [])
    var_95.RunAsync(var_98, var_100)
    method_35((var_61: (int64 ref)), (var_62: Env6), (var_51: (int64 ref)), (var_52: Env6), (var_47: (int64 ref)), (var_48: Env6), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    method_36((var_51: (int64 ref)), (var_52: Env6), (var_49: (int64 ref)), (var_50: Env6), (var_59: (int64 ref)), (var_60: Env6), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    let (var_101: uint64) = method_5((var_93: (uint64 ref)))
    let (var_102: (uint64 ref)) = var_56.mem_0
    let (var_103: uint64) = method_5((var_102: (uint64 ref)))
    // Cuda join point
    // method_37((var_101: uint64), (var_103: uint64))
    let (var_104: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_24, var_21)
    let (var_105: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_104.set_GridDimensions(var_105)
    let (var_106: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_104.set_BlockDimensions(var_106)
    let (var_107: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_109: (System.Object [])) = [|var_101; var_103|]: (System.Object [])
    var_104.RunAsync(var_107, var_109)
    let (var_110: (uint64 ref)) = var_30.mem_0
    let (var_111: uint64) = method_5((var_110: (uint64 ref)))
    let (var_112: (uint64 ref)) = var_46.mem_0
    let (var_113: uint64) = method_5((var_112: (uint64 ref)))
    let (var_114: (uint64 ref)) = var_48.mem_0
    let (var_115: uint64) = method_5((var_114: (uint64 ref)))
    let (var_116: (uint64 ref)) = var_50.mem_0
    let (var_117: uint64) = method_5((var_116: (uint64 ref)))
    let (var_118: (uint64 ref)) = var_28.mem_0
    let (var_119: uint64) = method_5((var_118: (uint64 ref)))
    let (var_120: (uint64 ref)) = var_44.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    // Cuda join point
    // method_41((var_111: uint64), (var_113: uint64), (var_115: uint64), (var_117: uint64), (var_119: uint64), (var_121: uint64))
    let (var_122: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_24, var_21)
    let (var_123: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_122.set_GridDimensions(var_123)
    let (var_124: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_122.set_BlockDimensions(var_124)
    let (var_125: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_127: (System.Object [])) = [|var_111; var_113; var_115; var_117; var_119; var_121|]: (System.Object [])
    var_122.RunAsync(var_125, var_127)
    let (var_128: (uint64 ref)) = var_34.mem_0
    let (var_129: uint64) = method_5((var_128: (uint64 ref)))
    let (var_130: uint64) = method_5((var_120: (uint64 ref)))
    let (var_131: uint64) = method_5((var_112: (uint64 ref)))
    let (var_132: (uint64 ref)) = var_32.mem_0
    let (var_133: uint64) = method_5((var_132: (uint64 ref)))
    // Cuda join point
    // method_34((var_129: uint64), (var_130: uint64), (var_131: uint64), (var_133: uint64))
    let (var_134: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_24, var_21)
    let (var_135: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_134.set_GridDimensions(var_135)
    let (var_136: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_134.set_BlockDimensions(var_136)
    let (var_137: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_139: (System.Object [])) = [|var_129; var_130; var_131; var_133|]: (System.Object [])
    var_134.RunAsync(var_137, var_139)
    method_42((var_31: (int64 ref)), (var_32: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_39: (int64 ref)), (var_40: Env6), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    let (var_140: uint64) = method_5((var_132: (uint64 ref)))
    let (var_141: (uint64 ref)) = var_36.mem_0
    let (var_142: uint64) = method_5((var_141: (uint64 ref)))
    // Cuda join point
    // method_37((var_140: uint64), (var_142: uint64))
    let (var_143: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_24, var_21)
    let (var_144: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_143.set_GridDimensions(var_144)
    let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_143.set_BlockDimensions(var_145)
    let (var_146: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_148: (System.Object [])) = [|var_140; var_142|]: (System.Object [])
    var_143.RunAsync(var_146, var_148)
    let (var_149: (uint64 ref)) = var_3.mem_0
    let (var_150: uint64) = method_5((var_149: (uint64 ref)))
    let (var_151: uint64) = method_5((var_118: (uint64 ref)))
    let (var_152: uint64) = method_5((var_110: (uint64 ref)))
    let (var_153: (uint64 ref)) = var_1.mem_0
    let (var_154: uint64) = method_5((var_153: (uint64 ref)))
    // Cuda join point
    // method_43((var_150: uint64), (var_151: uint64), (var_152: uint64), (var_154: uint64))
    let (var_155: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_24, var_21)
    let (var_156: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_155.set_GridDimensions(var_156)
    let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_155.set_BlockDimensions(var_157)
    let (var_158: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_160: (System.Object [])) = [|var_150; var_151; var_152; var_154|]: (System.Object [])
    var_155.RunAsync(var_158, var_160)
    method_42((var_0: (int64 ref)), (var_1: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_11: (int64 ref)), (var_12: Env6), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    let (var_161: uint64) = method_5((var_153: (uint64 ref)))
    let (var_162: (uint64 ref)) = var_5.mem_0
    let (var_163: uint64) = method_5((var_162: (uint64 ref)))
    // Cuda join point
    // method_37((var_161: uint64), (var_163: uint64))
    let (var_164: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_24, var_21)
    let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_164.set_GridDimensions(var_165)
    let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_164.set_BlockDimensions(var_166)
    let (var_167: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_169: (System.Object [])) = [|var_161; var_163|]: (System.Object [])
    var_164.RunAsync(var_167, var_169)
and method_44 ((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4)) (): float32 =
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_45((var_14: int64), (var_0: (int64 ref)), (var_1: Env6), (var_15: int64))
    var_16.[int32 0L]
and method_51((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_60: int64), (var_61: float), (var_62: int64), (var_63: ResizeArray<Env2>), (var_64: (unit -> float32)), (var_65: (unit -> unit)), (var_66: (int64 ref)), (var_67: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_70: int64)): float =
    let (var_71: bool) = (var_70 < 64L)
    if var_71 then
        let (var_72: bool) = (var_70 >= 0L)
        let (var_73: bool) = (var_72 = false)
        if var_73 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_74: int64) = (var_70 * 8192L)
        let (var_75: int64) = (var_2 + var_74)
        if var_73 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_76: int64) = (var_3 + var_74)
        let (var_77: int64) = 32768L
        let (var_78: EnvHeap7) = ({mem_0 = (var_50: (uint64 ref)); mem_1 = (var_51: uint64); mem_2 = (var_52: ResizeArray<Env0>); mem_3 = (var_53: ResizeArray<Env1>)} : EnvHeap7)
        let (var_79: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_77: int64))
        let (var_80: (int64 ref)) = var_79.mem_0
        let (var_81: Env6) = var_79.mem_1
        method_22((var_22: (int64 ref)), (var_23: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_75: int64), (var_80: (int64 ref)), (var_81: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_82: int64) = 32768L
        let (var_83: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_82: int64))
        let (var_84: (int64 ref)) = var_83.mem_0
        let (var_85: Env6) = var_83.mem_1
        let (var_86: (bool ref)) = var_59.mem_0
        let (var_87: ManagedCuda.CudaStream) = var_59.mem_1
        let (var_88: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_89: (uint64 ref)) = var_85.mem_0
        let (var_90: uint64) = method_5((var_89: (uint64 ref)))
        let (var_91: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_90)
        let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_91)
        let (var_93: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_92, 0uy, var_93, var_88)
        method_46((var_34: (int64 ref)), (var_35: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_80: (int64 ref)), (var_81: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_94: (uint64 ref)) = var_11.mem_0
        let (var_95: uint64) = method_5((var_94: (uint64 ref)))
        let (var_96: (uint64 ref)) = var_81.mem_0
        let (var_97: uint64) = method_5((var_96: (uint64 ref)))
        let (var_98: uint64) = method_5((var_96: (uint64 ref)))
        // Cuda join point
        // method_23((var_95: uint64), (var_97: uint64), (var_98: uint64))
        let (var_99: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_100: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_99.set_GridDimensions(var_100)
        let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_99.set_BlockDimensions(var_101)
        let (var_102: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_104: (System.Object [])) = [|var_95; var_97; var_98|]: (System.Object [])
        var_99.RunAsync(var_102, var_104)
        let (var_106: int64) = 32768L
        let (var_107: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_106: int64))
        let (var_108: (int64 ref)) = var_107.mem_0
        let (var_109: Env6) = var_107.mem_1
        let (var_110: uint64) = method_5((var_96: (uint64 ref)))
        let (var_111: (uint64 ref)) = var_109.mem_0
        let (var_112: uint64) = method_5((var_111: (uint64 ref)))
        // Cuda join point
        // method_25((var_110: uint64), (var_112: uint64))
        let (var_113: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_57, var_54)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_113.set_GridDimensions(var_114)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_113.set_BlockDimensions(var_115)
        let (var_116: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_118: (System.Object [])) = [|var_110; var_112|]: (System.Object [])
        var_113.RunAsync(var_116, var_118)
        let (var_119: int64) = 32768L
        let (var_120: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_119: int64))
        let (var_121: (int64 ref)) = var_120.mem_0
        let (var_122: Env6) = var_120.mem_1
        let (var_123: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_124: (uint64 ref)) = var_122.mem_0
        let (var_125: uint64) = method_5((var_124: (uint64 ref)))
        let (var_126: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_125)
        let (var_127: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_126)
        let (var_128: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_127, 0uy, var_128, var_123)
        let (var_129: int64) = 32768L
        let (var_130: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_129: int64))
        let (var_131: (int64 ref)) = var_130.mem_0
        let (var_132: Env6) = var_130.mem_1
        method_22((var_26: (int64 ref)), (var_27: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_75: int64), (var_131: (int64 ref)), (var_132: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_133: int64) = 32768L
        let (var_134: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_133: int64))
        let (var_135: (int64 ref)) = var_134.mem_0
        let (var_136: Env6) = var_134.mem_1
        let (var_137: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_138: (uint64 ref)) = var_136.mem_0
        let (var_139: uint64) = method_5((var_138: (uint64 ref)))
        let (var_140: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_139)
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_140)
        let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_141, 0uy, var_142, var_137)
        method_46((var_38: (int64 ref)), (var_39: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_131: (int64 ref)), (var_132: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_143: (uint64 ref)) = var_15.mem_0
        let (var_144: uint64) = method_5((var_143: (uint64 ref)))
        let (var_145: (uint64 ref)) = var_132.mem_0
        let (var_146: uint64) = method_5((var_145: (uint64 ref)))
        let (var_147: uint64) = method_5((var_145: (uint64 ref)))
        // Cuda join point
        // method_23((var_144: uint64), (var_146: uint64), (var_147: uint64))
        let (var_148: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_149: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_148.set_GridDimensions(var_149)
        let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_148.set_BlockDimensions(var_150)
        let (var_151: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_153: (System.Object [])) = [|var_144; var_146; var_147|]: (System.Object [])
        var_148.RunAsync(var_151, var_153)
        let (var_158: int64) = 32768L
        let (var_159: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_158: int64))
        let (var_160: (int64 ref)) = var_159.mem_0
        let (var_161: Env6) = var_159.mem_1
        let (var_162: uint64) = method_5((var_145: (uint64 ref)))
        let (var_163: (uint64 ref)) = var_161.mem_0
        let (var_164: uint64) = method_5((var_163: (uint64 ref)))
        // Cuda join point
        // method_27((var_162: uint64), (var_164: uint64))
        let (var_165: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_165.set_GridDimensions(var_166)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_165.set_BlockDimensions(var_167)
        let (var_168: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_170: (System.Object [])) = [|var_162; var_164|]: (System.Object [])
        var_165.RunAsync(var_168, var_170)
        let (var_171: int64) = 32768L
        let (var_172: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_171: int64))
        let (var_173: (int64 ref)) = var_172.mem_0
        let (var_174: Env6) = var_172.mem_1
        let (var_175: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_176: (uint64 ref)) = var_174.mem_0
        let (var_177: uint64) = method_5((var_176: (uint64 ref)))
        let (var_178: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_177)
        let (var_179: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_178)
        let (var_180: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_179, 0uy, var_180, var_175)
        let (var_181: int64) = 32768L
        let (var_182: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_181: int64))
        let (var_183: (int64 ref)) = var_182.mem_0
        let (var_184: Env6) = var_182.mem_1
        method_22((var_18: (int64 ref)), (var_19: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_75: int64), (var_183: (int64 ref)), (var_184: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_185: int64) = 32768L
        let (var_186: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_185: int64))
        let (var_187: (int64 ref)) = var_186.mem_0
        let (var_188: Env6) = var_186.mem_1
        let (var_189: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_190: (uint64 ref)) = var_188.mem_0
        let (var_191: uint64) = method_5((var_190: (uint64 ref)))
        let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_191)
        let (var_193: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_192)
        let (var_194: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_193, 0uy, var_194, var_189)
        method_46((var_30: (int64 ref)), (var_31: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_183: (int64 ref)), (var_184: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_195: (uint64 ref)) = var_7.mem_0
        let (var_196: uint64) = method_5((var_195: (uint64 ref)))
        let (var_197: (uint64 ref)) = var_184.mem_0
        let (var_198: uint64) = method_5((var_197: (uint64 ref)))
        let (var_199: uint64) = method_5((var_197: (uint64 ref)))
        // Cuda join point
        // method_23((var_196: uint64), (var_198: uint64), (var_199: uint64))
        let (var_200: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_201: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_200.set_GridDimensions(var_201)
        let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_200.set_BlockDimensions(var_202)
        let (var_203: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_205: (System.Object [])) = [|var_196; var_198; var_199|]: (System.Object [])
        var_200.RunAsync(var_203, var_205)
        let (var_210: int64) = 32768L
        let (var_211: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_210: int64))
        let (var_212: (int64 ref)) = var_211.mem_0
        let (var_213: Env6) = var_211.mem_1
        let (var_214: uint64) = method_5((var_197: (uint64 ref)))
        let (var_215: (uint64 ref)) = var_213.mem_0
        let (var_216: uint64) = method_5((var_215: (uint64 ref)))
        // Cuda join point
        // method_27((var_214: uint64), (var_216: uint64))
        let (var_217: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_218: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_217.set_GridDimensions(var_218)
        let (var_219: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_217.set_BlockDimensions(var_219)
        let (var_220: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_222: (System.Object [])) = [|var_214; var_216|]: (System.Object [])
        var_217.RunAsync(var_220, var_222)
        let (var_223: int64) = 32768L
        let (var_224: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_223: int64))
        let (var_225: (int64 ref)) = var_224.mem_0
        let (var_226: Env6) = var_224.mem_1
        let (var_227: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_228: (uint64 ref)) = var_226.mem_0
        let (var_229: uint64) = method_5((var_228: (uint64 ref)))
        let (var_230: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_229)
        let (var_231: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_230)
        let (var_232: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_231, 0uy, var_232, var_227)
        let (var_234: int64) = 32768L
        let (var_235: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_234: int64))
        let (var_236: (int64 ref)) = var_235.mem_0
        let (var_237: Env6) = var_235.mem_1
        let (var_238: uint64) = method_5((var_111: (uint64 ref)))
        let (var_239: uint64) = method_5((var_163: (uint64 ref)))
        let (var_240: (uint64 ref)) = var_237.mem_0
        let (var_241: uint64) = method_5((var_240: (uint64 ref)))
        // Cuda join point
        // method_28((var_238: uint64), (var_239: uint64), (var_241: uint64))
        let (var_242: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_57, var_54)
        let (var_243: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_242.set_GridDimensions(var_243)
        let (var_244: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_242.set_BlockDimensions(var_244)
        let (var_245: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_247: (System.Object [])) = [|var_238; var_239; var_241|]: (System.Object [])
        var_242.RunAsync(var_245, var_247)
        let (var_248: int64) = 32768L
        let (var_249: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_248: int64))
        let (var_250: (int64 ref)) = var_249.mem_0
        let (var_251: Env6) = var_249.mem_1
        let (var_252: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_253: (uint64 ref)) = var_251.mem_0
        let (var_254: uint64) = method_5((var_253: (uint64 ref)))
        let (var_255: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_254)
        let (var_256: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_255)
        let (var_257: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_256, 0uy, var_257, var_252)
        let (var_259: int64) = 32768L
        let (var_260: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_259: int64))
        let (var_261: (int64 ref)) = var_260.mem_0
        let (var_262: Env6) = var_260.mem_1
        let (var_263: (uint64 ref)) = var_69.mem_0
        let (var_264: uint64) = method_5((var_263: (uint64 ref)))
        let (var_265: uint64) = method_5((var_215: (uint64 ref)))
        let (var_266: (uint64 ref)) = var_262.mem_0
        let (var_267: uint64) = method_5((var_266: (uint64 ref)))
        // Cuda join point
        // method_28((var_264: uint64), (var_265: uint64), (var_267: uint64))
        let (var_268: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_57, var_54)
        let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_268.set_GridDimensions(var_269)
        let (var_270: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_268.set_BlockDimensions(var_270)
        let (var_271: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_273: (System.Object [])) = [|var_264; var_265; var_267|]: (System.Object [])
        var_268.RunAsync(var_271, var_273)
        let (var_274: int64) = 32768L
        let (var_275: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_274: int64))
        let (var_276: (int64 ref)) = var_275.mem_0
        let (var_277: Env6) = var_275.mem_1
        let (var_278: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_279: (uint64 ref)) = var_277.mem_0
        let (var_280: uint64) = method_5((var_279: (uint64 ref)))
        let (var_281: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_280)
        let (var_282: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_281)
        let (var_283: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_282, 0uy, var_283, var_278)
        let (var_285: int64) = 32768L
        let (var_286: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_285: int64))
        let (var_287: (int64 ref)) = var_286.mem_0
        let (var_288: Env6) = var_286.mem_1
        let (var_289: uint64) = method_5((var_240: (uint64 ref)))
        let (var_290: uint64) = method_5((var_266: (uint64 ref)))
        let (var_291: (uint64 ref)) = var_288.mem_0
        let (var_292: uint64) = method_5((var_291: (uint64 ref)))
        // Cuda join point
        // method_47((var_289: uint64), (var_290: uint64), (var_292: uint64))
        let (var_293: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_57, var_54)
        let (var_294: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_293.set_GridDimensions(var_294)
        let (var_295: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_293.set_BlockDimensions(var_295)
        let (var_296: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_298: (System.Object [])) = [|var_289; var_290; var_292|]: (System.Object [])
        var_293.RunAsync(var_296, var_298)
        let (var_299: int64) = 32768L
        let (var_300: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_299: int64))
        let (var_301: (int64 ref)) = var_300.mem_0
        let (var_302: Env6) = var_300.mem_1
        let (var_303: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_304: (uint64 ref)) = var_302.mem_0
        let (var_305: uint64) = method_5((var_304: (uint64 ref)))
        let (var_306: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_305)
        let (var_307: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_306)
        let (var_308: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_307, 0uy, var_308, var_303)
        let (var_309: int64) = 32768L
        let (var_310: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_309: int64))
        let (var_311: (int64 ref)) = var_310.mem_0
        let (var_312: Env6) = var_310.mem_1
        method_29((var_46: (int64 ref)), (var_47: Env6), (var_287: (int64 ref)), (var_288: Env6), (var_311: (int64 ref)), (var_312: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_313: int64) = 32768L
        let (var_314: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_313: int64))
        let (var_315: (int64 ref)) = var_314.mem_0
        let (var_316: Env6) = var_314.mem_1
        let (var_317: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_318: (uint64 ref)) = var_316.mem_0
        let (var_319: uint64) = method_5((var_318: (uint64 ref)))
        let (var_320: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_319)
        let (var_321: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_320)
        let (var_322: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_321, 0uy, var_322, var_317)
        let (var_323: (uint64 ref)) = var_43.mem_0
        let (var_324: uint64) = method_5((var_323: (uint64 ref)))
        let (var_325: (uint64 ref)) = var_312.mem_0
        let (var_326: uint64) = method_5((var_325: (uint64 ref)))
        let (var_327: uint64) = method_5((var_325: (uint64 ref)))
        // Cuda join point
        // method_23((var_324: uint64), (var_326: uint64), (var_327: uint64))
        let (var_328: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_329: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_328.set_GridDimensions(var_329)
        let (var_330: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_328.set_BlockDimensions(var_330)
        let (var_331: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_333: (System.Object [])) = [|var_324; var_326; var_327|]: (System.Object [])
        var_328.RunAsync(var_331, var_333)
        let (var_338: int64) = 32768L
        let (var_339: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_338: int64))
        let (var_340: (int64 ref)) = var_339.mem_0
        let (var_341: Env6) = var_339.mem_1
        let (var_342: uint64) = method_5((var_325: (uint64 ref)))
        let (var_343: (uint64 ref)) = var_341.mem_0
        let (var_344: uint64) = method_5((var_343: (uint64 ref)))
        // Cuda join point
        // method_27((var_342: uint64), (var_344: uint64))
        let (var_345: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_346: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_345.set_GridDimensions(var_346)
        let (var_347: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_345.set_BlockDimensions(var_347)
        let (var_348: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_350: (System.Object [])) = [|var_342; var_344|]: (System.Object [])
        var_345.RunAsync(var_348, var_350)
        let (var_351: int64) = 32768L
        let (var_352: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_351: int64))
        let (var_353: (int64 ref)) = var_352.mem_0
        let (var_354: Env6) = var_352.mem_1
        let (var_355: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_356: (uint64 ref)) = var_354.mem_0
        let (var_357: uint64) = method_5((var_356: (uint64 ref)))
        let (var_358: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_357)
        let (var_359: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_358)
        let (var_360: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_359, 0uy, var_360, var_355)
        let (var_361: uint64) = method_5((var_343: (uint64 ref)))
        let (var_362: (uint64 ref)) = var_1.mem_0
        let (var_363: uint64) = method_5((var_362: (uint64 ref)))
        let (var_364: int64) = (var_76 * 4L)
        let (var_365: uint64) = (uint64 var_364)
        let (var_366: uint64) = (var_363 + var_365)
        let (var_370: int64) = 4L
        let (var_371: Env2) = method_11((var_78: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_370: int64))
        let (var_372: (int64 ref)) = var_371.mem_0
        let (var_373: Env6) = var_371.mem_1
        let (var_374: (uint64 ref)) = var_373.mem_0
        let (var_375: uint64) = method_5((var_374: (uint64 ref)))
        // Cuda join point
        // method_30((var_361: uint64), (var_366: uint64), (var_375: uint64))
        let (var_376: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_57, var_54)
        let (var_377: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_376.set_GridDimensions(var_377)
        let (var_378: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_376.set_BlockDimensions(var_378)
        let (var_379: ManagedCuda.BasicTypes.CUstream) = method_19((var_86: (bool ref)), (var_87: ManagedCuda.CudaStream))
        let (var_381: (System.Object [])) = [|var_361; var_366; var_375|]: (System.Object [])
        var_376.RunAsync(var_379, var_381)
        let (var_382: (unit -> unit)) = method_48((var_65: (unit -> unit)), (var_84: (int64 ref)), (var_85: Env6), (var_80: (int64 ref)), (var_81: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_75: int64), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_66: (int64 ref)), (var_67: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_121: (int64 ref)), (var_122: Env6), (var_108: (int64 ref)), (var_109: Env6), (var_135: (int64 ref)), (var_136: Env6), (var_131: (int64 ref)), (var_132: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_173: (int64 ref)), (var_174: Env6), (var_160: (int64 ref)), (var_161: Env6), (var_187: (int64 ref)), (var_188: Env6), (var_183: (int64 ref)), (var_184: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_225: (int64 ref)), (var_226: Env6), (var_212: (int64 ref)), (var_213: Env6), (var_250: (int64 ref)), (var_251: Env6), (var_236: (int64 ref)), (var_237: Env6), (var_276: (int64 ref)), (var_277: Env6), (var_261: (int64 ref)), (var_262: Env6), (var_301: (int64 ref)), (var_302: Env6), (var_287: (int64 ref)), (var_288: Env6), (var_315: (int64 ref)), (var_316: Env6), (var_311: (int64 ref)), (var_312: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_353: (int64 ref)), (var_354: Env6), (var_340: (int64 ref)), (var_341: Env6), (var_372: (int64 ref)), (var_373: Env6), (var_76: int64))
        let (var_383: (unit -> float32)) = method_50((var_372: (int64 ref)), (var_373: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_64: (unit -> float32)))
        let (var_384: int64) = (var_70 + 1L)
        method_51((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_60: int64), (var_61: float), (var_62: int64), (var_63: ResizeArray<Env2>), (var_383: (unit -> float32)), (var_382: (unit -> unit)), (var_301: (int64 ref)), (var_302: Env6), (var_287: (int64 ref)), (var_288: Env6), (var_384: int64))
    else
        // Done with foru...
        let (var_386: float32) = var_64()
        let (var_387: float) = (float var_386)
        let (var_388: float) = (var_61 + var_387)
        let (var_397: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_52((var_68: (int64 ref)), (var_69: Env6), (var_397: ResizeArray<Env2>))
        let (var_398: int64) = (var_60 + 1L)
        if (System.Double.IsNaN var_388) then
            // Is nan...
            method_53((var_55: ResizeArray<Env2>))
            // Done with the net...
            method_53((var_397: ResizeArray<Env2>))
            let (var_399: float) = (float var_398)
            (var_388 / var_399)
        else
            var_65()
            method_55((var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
            // Done with body...
            method_53((var_55: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_401: int64) = (var_62 + 1L)
            method_59((var_0: (int64 ref)), (var_1: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_63: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_398: int64), (var_388: float), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_397: ResizeArray<Env2>), (var_68: (int64 ref)), (var_69: Env6), (var_401: int64))
and method_14 ((var_1: uint64)) ((var_0: Env0)): int32 =
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
and method_35((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_19((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
    var_6.set_Stream(var_21)
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
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
and method_36((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_19((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
    var_6.set_Stream(var_21)
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
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
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_18, var_22, var_23, 128, 128, 64, var_24, var_28, 128, var_32, 128, var_33, var_37, 128)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_42((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: int64), (var_5: (int64 ref)), (var_6: Env6), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: EnvHeap4)): unit =
    let (var_19: ManagedCuda.CudaBlas.CudaBlasHandle) = var_7.get_CublasHandle()
    let (var_20: (bool ref)) = var_18.mem_0
    let (var_21: ManagedCuda.CudaStream) = var_18.mem_1
    let (var_22: ManagedCuda.BasicTypes.CUstream) = method_19((var_20: (bool ref)), (var_21: ManagedCuda.CudaStream))
    var_7.set_Stream(var_22)
    let (var_23: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_24: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
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
    let (var_37: (float32 ref)) = (ref 1.000000f)
    let (var_38: (uint64 ref)) = var_6.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
    let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_40)
    let (var_42: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_19, var_23, var_24, 128, 128, 64, var_25, var_29, 128, var_36, 128, var_37, var_41, 128)
    if var_42 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_42)
and method_45((var_0: int64), (var_1: (int64 ref)), (var_2: Env6), (var_3: int64)): (float32 []) =
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
and method_46((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
    let (var_18: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_19: (bool ref)) = var_17.mem_0
    let (var_20: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_21: ManagedCuda.BasicTypes.CUstream) = method_19((var_19: (bool ref)), (var_20: ManagedCuda.CudaStream))
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
and method_48 ((var_0: (unit -> unit)), (var_1: (int64 ref)), (var_2: Env6), (var_3: (int64 ref)), (var_4: Env6), (var_5: (int64 ref)), (var_6: Env6), (var_7: (int64 ref)), (var_8: Env6), (var_9: (int64 ref)), (var_10: Env6), (var_11: int64), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_60: (int64 ref)), (var_61: Env6), (var_62: (int64 ref)), (var_63: Env6), (var_64: (int64 ref)), (var_65: Env6), (var_66: (int64 ref)), (var_67: Env6), (var_68: (int64 ref)), (var_69: Env6), (var_70: (int64 ref)), (var_71: Env6), (var_72: (int64 ref)), (var_73: Env6), (var_74: (int64 ref)), (var_75: Env6), (var_76: (int64 ref)), (var_77: Env6), (var_78: (int64 ref)), (var_79: Env6), (var_80: (int64 ref)), (var_81: Env6), (var_82: (int64 ref)), (var_83: Env6), (var_84: (int64 ref)), (var_85: Env6), (var_86: (int64 ref)), (var_87: Env6), (var_88: (int64 ref)), (var_89: Env6), (var_90: (int64 ref)), (var_91: Env6), (var_92: (int64 ref)), (var_93: Env6), (var_94: (int64 ref)), (var_95: Env6), (var_96: (int64 ref)), (var_97: Env6), (var_98: (int64 ref)), (var_99: Env6), (var_100: (int64 ref)), (var_101: Env6), (var_102: (int64 ref)), (var_103: Env6), (var_104: (int64 ref)), (var_105: Env6), (var_106: (int64 ref)), (var_107: Env6), (var_108: (int64 ref)), (var_109: Env6), (var_110: int64)) (): unit =
    let (var_111: (uint64 ref)) = var_109.mem_0
    let (var_112: uint64) = method_5((var_111: (uint64 ref)))
    let (var_113: (uint64 ref)) = var_107.mem_0
    let (var_114: uint64) = method_5((var_113: (uint64 ref)))
    let (var_115: (uint64 ref)) = var_10.mem_0
    let (var_116: uint64) = method_5((var_115: (uint64 ref)))
    let (var_117: int64) = (var_110 * 4L)
    let (var_118: uint64) = (uint64 var_117)
    let (var_119: uint64) = (var_116 + var_118)
    let (var_120: (uint64 ref)) = var_105.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    // Cuda join point
    // method_33((var_112: uint64), (var_114: uint64), (var_119: uint64), (var_121: uint64))
    let (var_122: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_33, var_30)
    let (var_123: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_122.set_GridDimensions(var_123)
    let (var_124: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_122.set_BlockDimensions(var_124)
    let (var_125: (bool ref)) = var_35.mem_0
    let (var_126: ManagedCuda.CudaStream) = var_35.mem_1
    let (var_127: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_129: (System.Object [])) = [|var_112; var_114; var_119; var_121|]: (System.Object [])
    var_122.RunAsync(var_127, var_129)
    let (var_130: (uint64 ref)) = var_95.mem_0
    let (var_131: uint64) = method_5((var_130: (uint64 ref)))
    let (var_132: uint64) = method_5((var_120: (uint64 ref)))
    let (var_133: uint64) = method_5((var_113: (uint64 ref)))
    let (var_134: (uint64 ref)) = var_93.mem_0
    let (var_135: uint64) = method_5((var_134: (uint64 ref)))
    // Cuda join point
    // method_34((var_131: uint64), (var_132: uint64), (var_133: uint64), (var_135: uint64))
    let (var_136: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_33, var_30)
    let (var_137: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_136.set_GridDimensions(var_137)
    let (var_138: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_136.set_BlockDimensions(var_138)
    let (var_139: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_141: (System.Object [])) = [|var_131; var_132; var_133; var_135|]: (System.Object [])
    var_136.RunAsync(var_139, var_141)
    method_35((var_102: (int64 ref)), (var_103: Env6), (var_92: (int64 ref)), (var_93: Env6), (var_88: (int64 ref)), (var_89: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_92: (int64 ref)), (var_93: Env6), (var_90: (int64 ref)), (var_91: Env6), (var_100: (int64 ref)), (var_101: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    let (var_142: uint64) = method_5((var_134: (uint64 ref)))
    let (var_143: (uint64 ref)) = var_97.mem_0
    let (var_144: uint64) = method_5((var_143: (uint64 ref)))
    // Cuda join point
    // method_37((var_142: uint64), (var_144: uint64))
    let (var_145: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_33, var_30)
    let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_145.set_GridDimensions(var_146)
    let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_145.set_BlockDimensions(var_147)
    let (var_148: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_150: (System.Object [])) = [|var_142; var_144|]: (System.Object [])
    var_145.RunAsync(var_148, var_150)
    let (var_151: (uint64 ref)) = var_83.mem_0
    let (var_152: uint64) = method_5((var_151: (uint64 ref)))
    let (var_153: (uint64 ref)) = var_87.mem_0
    let (var_154: uint64) = method_5((var_153: (uint64 ref)))
    let (var_155: (uint64 ref)) = var_89.mem_0
    let (var_156: uint64) = method_5((var_155: (uint64 ref)))
    let (var_157: (uint64 ref)) = var_91.mem_0
    let (var_158: uint64) = method_5((var_157: (uint64 ref)))
    let (var_159: (uint64 ref)) = var_81.mem_0
    let (var_160: uint64) = method_5((var_159: (uint64 ref)))
    let (var_161: (uint64 ref)) = var_85.mem_0
    let (var_162: uint64) = method_5((var_161: (uint64 ref)))
    // Cuda join point
    // method_49((var_152: uint64), (var_154: uint64), (var_156: uint64), (var_158: uint64), (var_160: uint64), (var_162: uint64))
    let (var_163: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_33, var_30)
    let (var_164: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_163.set_GridDimensions(var_164)
    let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_163.set_BlockDimensions(var_165)
    let (var_166: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_168: (System.Object [])) = [|var_152; var_154; var_156; var_158; var_160; var_162|]: (System.Object [])
    var_163.RunAsync(var_166, var_168)
    let (var_169: (uint64 ref)) = var_19.mem_0
    let (var_170: uint64) = method_5((var_169: (uint64 ref)))
    let (var_171: (uint64 ref)) = var_79.mem_0
    let (var_172: uint64) = method_5((var_171: (uint64 ref)))
    let (var_173: uint64) = method_5((var_161: (uint64 ref)))
    let (var_174: uint64) = method_5((var_153: (uint64 ref)))
    let (var_175: (uint64 ref)) = var_17.mem_0
    let (var_176: uint64) = method_5((var_175: (uint64 ref)))
    let (var_177: (uint64 ref)) = var_77.mem_0
    let (var_178: uint64) = method_5((var_177: (uint64 ref)))
    // Cuda join point
    // method_41((var_170: uint64), (var_172: uint64), (var_173: uint64), (var_174: uint64), (var_176: uint64), (var_178: uint64))
    let (var_179: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_33, var_30)
    let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_179.set_GridDimensions(var_180)
    let (var_181: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_179.set_BlockDimensions(var_181)
    let (var_182: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_184: (System.Object [])) = [|var_170; var_172; var_173; var_174; var_176; var_178|]: (System.Object [])
    var_179.RunAsync(var_182, var_184)
    let (var_185: (uint64 ref)) = var_39.mem_0
    let (var_186: uint64) = method_5((var_185: (uint64 ref)))
    let (var_187: (uint64 ref)) = var_59.mem_0
    let (var_188: uint64) = method_5((var_187: (uint64 ref)))
    let (var_189: uint64) = method_5((var_159: (uint64 ref)))
    let (var_190: uint64) = method_5((var_151: (uint64 ref)))
    let (var_191: (uint64 ref)) = var_37.mem_0
    let (var_192: uint64) = method_5((var_191: (uint64 ref)))
    let (var_193: (uint64 ref)) = var_57.mem_0
    let (var_194: uint64) = method_5((var_193: (uint64 ref)))
    // Cuda join point
    // method_41((var_186: uint64), (var_188: uint64), (var_189: uint64), (var_190: uint64), (var_192: uint64), (var_194: uint64))
    let (var_195: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_33, var_30)
    let (var_196: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_195.set_GridDimensions(var_196)
    let (var_197: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_195.set_BlockDimensions(var_197)
    let (var_198: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_200: (System.Object [])) = [|var_186; var_188; var_189; var_190; var_192; var_194|]: (System.Object [])
    var_195.RunAsync(var_198, var_200)
    let (var_201: (uint64 ref)) = var_63.mem_0
    let (var_202: uint64) = method_5((var_201: (uint64 ref)))
    let (var_203: uint64) = method_5((var_177: (uint64 ref)))
    let (var_204: uint64) = method_5((var_171: (uint64 ref)))
    let (var_205: (uint64 ref)) = var_61.mem_0
    let (var_206: uint64) = method_5((var_205: (uint64 ref)))
    // Cuda join point
    // method_34((var_202: uint64), (var_203: uint64), (var_204: uint64), (var_206: uint64))
    let (var_207: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_33, var_30)
    let (var_208: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_207.set_GridDimensions(var_208)
    let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_207.set_BlockDimensions(var_209)
    let (var_210: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_212: (System.Object [])) = [|var_202; var_203; var_204; var_206|]: (System.Object [])
    var_207.RunAsync(var_210, var_212)
    method_42((var_60: (int64 ref)), (var_61: Env6), (var_9: (int64 ref)), (var_10: Env6), (var_11: int64), (var_68: (int64 ref)), (var_69: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_74: (int64 ref)), (var_75: Env6), (var_60: (int64 ref)), (var_61: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_60: (int64 ref)), (var_61: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_72: (int64 ref)), (var_73: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    let (var_213: uint64) = method_5((var_205: (uint64 ref)))
    let (var_214: (uint64 ref)) = var_65.mem_0
    let (var_215: uint64) = method_5((var_214: (uint64 ref)))
    // Cuda join point
    // method_37((var_213: uint64), (var_215: uint64))
    let (var_216: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_33, var_30)
    let (var_217: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_216.set_GridDimensions(var_217)
    let (var_218: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_216.set_BlockDimensions(var_218)
    let (var_219: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_221: (System.Object [])) = [|var_213; var_215|]: (System.Object [])
    var_216.RunAsync(var_219, var_221)
    let (var_222: (uint64 ref)) = var_43.mem_0
    let (var_223: uint64) = method_5((var_222: (uint64 ref)))
    let (var_224: uint64) = method_5((var_193: (uint64 ref)))
    let (var_225: uint64) = method_5((var_187: (uint64 ref)))
    let (var_226: (uint64 ref)) = var_41.mem_0
    let (var_227: uint64) = method_5((var_226: (uint64 ref)))
    // Cuda join point
    // method_34((var_223: uint64), (var_224: uint64), (var_225: uint64), (var_227: uint64))
    let (var_228: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_33, var_30)
    let (var_229: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_228.set_GridDimensions(var_229)
    let (var_230: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_228.set_BlockDimensions(var_230)
    let (var_231: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_233: (System.Object [])) = [|var_223; var_224; var_225; var_227|]: (System.Object [])
    var_228.RunAsync(var_231, var_233)
    method_42((var_40: (int64 ref)), (var_41: Env6), (var_9: (int64 ref)), (var_10: Env6), (var_11: int64), (var_48: (int64 ref)), (var_49: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_54: (int64 ref)), (var_55: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_40: (int64 ref)), (var_41: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    let (var_234: uint64) = method_5((var_226: (uint64 ref)))
    let (var_235: (uint64 ref)) = var_45.mem_0
    let (var_236: uint64) = method_5((var_235: (uint64 ref)))
    // Cuda join point
    // method_37((var_234: uint64), (var_236: uint64))
    let (var_237: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_33, var_30)
    let (var_238: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_237.set_GridDimensions(var_238)
    let (var_239: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_237.set_BlockDimensions(var_239)
    let (var_240: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_242: (System.Object [])) = [|var_234; var_236|]: (System.Object [])
    var_237.RunAsync(var_240, var_242)
    let (var_243: (uint64 ref)) = var_4.mem_0
    let (var_244: uint64) = method_5((var_243: (uint64 ref)))
    let (var_245: uint64) = method_5((var_191: (uint64 ref)))
    let (var_246: uint64) = method_5((var_185: (uint64 ref)))
    let (var_247: (uint64 ref)) = var_2.mem_0
    let (var_248: uint64) = method_5((var_247: (uint64 ref)))
    // Cuda join point
    // method_43((var_244: uint64), (var_245: uint64), (var_246: uint64), (var_248: uint64))
    let (var_249: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_33, var_30)
    let (var_250: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_249.set_GridDimensions(var_250)
    let (var_251: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_249.set_BlockDimensions(var_251)
    let (var_252: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_254: (System.Object [])) = [|var_244; var_245; var_246; var_248|]: (System.Object [])
    var_249.RunAsync(var_252, var_254)
    method_42((var_1: (int64 ref)), (var_2: Env6), (var_9: (int64 ref)), (var_10: Env6), (var_11: int64), (var_12: (int64 ref)), (var_13: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_22: (int64 ref)), (var_23: Env6), (var_1: (int64 ref)), (var_2: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_1: (int64 ref)), (var_2: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    let (var_255: uint64) = method_5((var_247: (uint64 ref)))
    let (var_256: (uint64 ref)) = var_6.mem_0
    let (var_257: uint64) = method_5((var_256: (uint64 ref)))
    // Cuda join point
    // method_37((var_255: uint64), (var_257: uint64))
    let (var_258: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_33, var_30)
    let (var_259: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_258.set_GridDimensions(var_259)
    let (var_260: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_258.set_BlockDimensions(var_260)
    let (var_261: ManagedCuda.BasicTypes.CUstream) = method_19((var_125: (bool ref)), (var_126: ManagedCuda.CudaStream))
    let (var_263: (System.Object [])) = [|var_255; var_257|]: (System.Object [])
    var_258.RunAsync(var_261, var_263)
    var_0()
and method_50 ((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: (unit -> float32))) (): float32 =
    let (var_15: float32) = var_14()
    let (var_16: int64) = 1L
    let (var_17: int64) = 0L
    let (var_18: (float32 [])) = method_45((var_16: int64), (var_0: (int64 ref)), (var_1: Env6), (var_17: int64))
    let (var_19: float32) = var_18.[int32 0L]
    (var_15 + var_19)
and method_52((var_0: (int64 ref)), (var_1: Env6), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, var_1)))
and method_55((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_46: (uint64 ref)), (var_47: uint64), (var_48: ResizeArray<Env0>), (var_49: ResizeArray<Env1>), (var_50: ManagedCuda.CudaContext), (var_51: ResizeArray<Env2>), (var_52: ResizeArray<Env3>), (var_53: ManagedCuda.BasicTypes.CUmodule), (var_54: (int64 ref)), (var_55: EnvHeap4)): unit =
    let (var_56: (uint64 ref)) = var_3.mem_0
    let (var_57: uint64) = method_5((var_56: (uint64 ref)))
    let (var_58: (uint64 ref)) = var_1.mem_0
    let (var_59: uint64) = method_5((var_58: (uint64 ref)))
    // Cuda join point
    // method_56((var_57: uint64), (var_59: uint64))
    let (var_60: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_53, var_50)
    let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_60.set_GridDimensions(var_61)
    let (var_62: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_60.set_BlockDimensions(var_62)
    let (var_63: (bool ref)) = var_55.mem_0
    let (var_64: ManagedCuda.CudaStream) = var_55.mem_1
    let (var_65: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_67: (System.Object [])) = [|var_57; var_59|]: (System.Object [])
    var_60.RunAsync(var_65, var_67)
    let (var_68: (uint64 ref)) = var_7.mem_0
    let (var_69: uint64) = method_5((var_68: (uint64 ref)))
    let (var_70: (uint64 ref)) = var_5.mem_0
    let (var_71: uint64) = method_5((var_70: (uint64 ref)))
    // Cuda join point
    // method_56((var_69: uint64), (var_71: uint64))
    let (var_72: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_53, var_50)
    let (var_73: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_72.set_GridDimensions(var_73)
    let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_72.set_BlockDimensions(var_74)
    let (var_75: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_77: (System.Object [])) = [|var_69; var_71|]: (System.Object [])
    var_72.RunAsync(var_75, var_77)
    let (var_78: (uint64 ref)) = var_11.mem_0
    let (var_79: uint64) = method_5((var_78: (uint64 ref)))
    let (var_80: (uint64 ref)) = var_9.mem_0
    let (var_81: uint64) = method_5((var_80: (uint64 ref)))
    // Cuda join point
    // method_56((var_79: uint64), (var_81: uint64))
    let (var_82: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_53, var_50)
    let (var_83: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_82.set_GridDimensions(var_83)
    let (var_84: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_82.set_BlockDimensions(var_84)
    let (var_85: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_87: (System.Object [])) = [|var_79; var_81|]: (System.Object [])
    var_82.RunAsync(var_85, var_87)
    let (var_88: (uint64 ref)) = var_15.mem_0
    let (var_89: uint64) = method_5((var_88: (uint64 ref)))
    let (var_90: (uint64 ref)) = var_13.mem_0
    let (var_91: uint64) = method_5((var_90: (uint64 ref)))
    // Cuda join point
    // method_57((var_89: uint64), (var_91: uint64))
    let (var_92: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_93: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_92.set_GridDimensions(var_93)
    let (var_94: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_92.set_BlockDimensions(var_94)
    let (var_95: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_97: (System.Object [])) = [|var_89; var_91|]: (System.Object [])
    var_92.RunAsync(var_95, var_97)
    let (var_98: (uint64 ref)) = var_19.mem_0
    let (var_99: uint64) = method_5((var_98: (uint64 ref)))
    let (var_100: (uint64 ref)) = var_17.mem_0
    let (var_101: uint64) = method_5((var_100: (uint64 ref)))
    // Cuda join point
    // method_57((var_99: uint64), (var_101: uint64))
    let (var_102: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_102.set_GridDimensions(var_103)
    let (var_104: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_102.set_BlockDimensions(var_104)
    let (var_105: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_107: (System.Object [])) = [|var_99; var_101|]: (System.Object [])
    var_102.RunAsync(var_105, var_107)
    let (var_108: (uint64 ref)) = var_23.mem_0
    let (var_109: uint64) = method_5((var_108: (uint64 ref)))
    let (var_110: (uint64 ref)) = var_21.mem_0
    let (var_111: uint64) = method_5((var_110: (uint64 ref)))
    // Cuda join point
    // method_57((var_109: uint64), (var_111: uint64))
    let (var_112: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_112.set_GridDimensions(var_113)
    let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_112.set_BlockDimensions(var_114)
    let (var_115: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_117: (System.Object [])) = [|var_109; var_111|]: (System.Object [])
    var_112.RunAsync(var_115, var_117)
    let (var_118: (uint64 ref)) = var_27.mem_0
    let (var_119: uint64) = method_5((var_118: (uint64 ref)))
    let (var_120: (uint64 ref)) = var_25.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    // Cuda join point
    // method_57((var_119: uint64), (var_121: uint64))
    let (var_122: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_123: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_122.set_GridDimensions(var_123)
    let (var_124: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_122.set_BlockDimensions(var_124)
    let (var_125: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_127: (System.Object [])) = [|var_119; var_121|]: (System.Object [])
    var_122.RunAsync(var_125, var_127)
    let (var_128: (uint64 ref)) = var_31.mem_0
    let (var_129: uint64) = method_5((var_128: (uint64 ref)))
    let (var_130: (uint64 ref)) = var_29.mem_0
    let (var_131: uint64) = method_5((var_130: (uint64 ref)))
    // Cuda join point
    // method_57((var_129: uint64), (var_131: uint64))
    let (var_132: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_133: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_132.set_GridDimensions(var_133)
    let (var_134: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_132.set_BlockDimensions(var_134)
    let (var_135: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_137: (System.Object [])) = [|var_129; var_131|]: (System.Object [])
    var_132.RunAsync(var_135, var_137)
    let (var_138: (uint64 ref)) = var_35.mem_0
    let (var_139: uint64) = method_5((var_138: (uint64 ref)))
    let (var_140: (uint64 ref)) = var_33.mem_0
    let (var_141: uint64) = method_5((var_140: (uint64 ref)))
    // Cuda join point
    // method_57((var_139: uint64), (var_141: uint64))
    let (var_142: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_143: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_142.set_GridDimensions(var_143)
    let (var_144: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_142.set_BlockDimensions(var_144)
    let (var_145: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_147: (System.Object [])) = [|var_139; var_141|]: (System.Object [])
    var_142.RunAsync(var_145, var_147)
    let (var_148: (uint64 ref)) = var_39.mem_0
    let (var_149: uint64) = method_5((var_148: (uint64 ref)))
    let (var_150: (uint64 ref)) = var_37.mem_0
    let (var_151: uint64) = method_5((var_150: (uint64 ref)))
    // Cuda join point
    // method_56((var_149: uint64), (var_151: uint64))
    let (var_152: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_53, var_50)
    let (var_153: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_152.set_GridDimensions(var_153)
    let (var_154: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_152.set_BlockDimensions(var_154)
    let (var_155: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_157: (System.Object [])) = [|var_149; var_151|]: (System.Object [])
    var_152.RunAsync(var_155, var_157)
    let (var_158: (uint64 ref)) = var_43.mem_0
    let (var_159: uint64) = method_5((var_158: (uint64 ref)))
    let (var_160: (uint64 ref)) = var_41.mem_0
    let (var_161: uint64) = method_5((var_160: (uint64 ref)))
    // Cuda join point
    // method_57((var_159: uint64), (var_161: uint64))
    let (var_162: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_53, var_50)
    let (var_163: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_162.set_GridDimensions(var_163)
    let (var_164: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_162.set_BlockDimensions(var_164)
    let (var_165: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_167: (System.Object [])) = [|var_159; var_161|]: (System.Object [])
    var_162.RunAsync(var_165, var_167)
and method_59((var_0: (int64 ref)), (var_1: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_60: ResizeArray<Env2>), (var_61: (int64 ref)), (var_62: Env6), (var_63: int64)): float =
    let (var_64: bool) = (var_63 < 271L)
    if var_64 then
        let (var_65: bool) = (var_63 >= 0L)
        let (var_66: bool) = (var_65 = false)
        if var_66 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_67: int64) = (var_63 * 524288L)
        if var_66 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_68: int64) = (524288L + var_67)
        let (var_69: EnvHeap7) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap7)
        let (var_70: (uint64 ref)) = var_69.mem_0
        let (var_71: uint64) = var_69.mem_1
        let (var_72: ResizeArray<Env0>) = var_69.mem_2
        let (var_73: ResizeArray<Env1>) = var_69.mem_3
        method_1((var_72: ResizeArray<Env0>), (var_70: (uint64 ref)), (var_71: uint64), (var_73: ResizeArray<Env1>))
        let (var_77: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_384: int64) = 32768L
        let (var_385: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_384: int64))
        let (var_386: (int64 ref)) = var_385.mem_0
        let (var_387: Env6) = var_385.mem_1
        method_22((var_34: (int64 ref)), (var_35: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_67: int64), (var_386: (int64 ref)), (var_387: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_388: int64) = 32768L
        let (var_389: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_388: int64))
        let (var_390: (int64 ref)) = var_389.mem_0
        let (var_391: Env6) = var_389.mem_1
        let (var_392: (bool ref)) = var_13.mem_0
        let (var_393: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_394: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_395: (uint64 ref)) = var_391.mem_0
        let (var_396: uint64) = method_5((var_395: (uint64 ref)))
        let (var_397: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_396)
        let (var_398: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_397)
        let (var_399: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_398, 0uy, var_399, var_394)
        method_46((var_46: (int64 ref)), (var_47: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_386: (int64 ref)), (var_387: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_400: (uint64 ref)) = var_23.mem_0
        let (var_401: uint64) = method_5((var_400: (uint64 ref)))
        let (var_402: (uint64 ref)) = var_387.mem_0
        let (var_403: uint64) = method_5((var_402: (uint64 ref)))
        let (var_404: uint64) = method_5((var_402: (uint64 ref)))
        // Cuda join point
        // method_23((var_401: uint64), (var_403: uint64), (var_404: uint64))
        let (var_405: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_406: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_405.set_GridDimensions(var_406)
        let (var_407: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_405.set_BlockDimensions(var_407)
        let (var_408: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_410: (System.Object [])) = [|var_401; var_403; var_404|]: (System.Object [])
        var_405.RunAsync(var_408, var_410)
        let (var_412: int64) = 32768L
        let (var_413: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_412: int64))
        let (var_414: (int64 ref)) = var_413.mem_0
        let (var_415: Env6) = var_413.mem_1
        let (var_416: uint64) = method_5((var_402: (uint64 ref)))
        let (var_417: (uint64 ref)) = var_415.mem_0
        let (var_418: uint64) = method_5((var_417: (uint64 ref)))
        // Cuda join point
        // method_25((var_416: uint64), (var_418: uint64))
        let (var_419: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_420: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_419.set_GridDimensions(var_420)
        let (var_421: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_419.set_BlockDimensions(var_421)
        let (var_422: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_424: (System.Object [])) = [|var_416; var_418|]: (System.Object [])
        var_419.RunAsync(var_422, var_424)
        let (var_425: int64) = 32768L
        let (var_426: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_425: int64))
        let (var_427: (int64 ref)) = var_426.mem_0
        let (var_428: Env6) = var_426.mem_1
        let (var_429: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_430: (uint64 ref)) = var_428.mem_0
        let (var_431: uint64) = method_5((var_430: (uint64 ref)))
        let (var_432: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_431)
        let (var_433: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_432)
        let (var_434: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_433, 0uy, var_434, var_429)
        let (var_435: int64) = 32768L
        let (var_436: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_435: int64))
        let (var_437: (int64 ref)) = var_436.mem_0
        let (var_438: Env6) = var_436.mem_1
        method_22((var_38: (int64 ref)), (var_39: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_67: int64), (var_437: (int64 ref)), (var_438: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_439: int64) = 32768L
        let (var_440: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_439: int64))
        let (var_441: (int64 ref)) = var_440.mem_0
        let (var_442: Env6) = var_440.mem_1
        let (var_443: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_444: (uint64 ref)) = var_442.mem_0
        let (var_445: uint64) = method_5((var_444: (uint64 ref)))
        let (var_446: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_445)
        let (var_447: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_446)
        let (var_448: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_447, 0uy, var_448, var_443)
        method_46((var_50: (int64 ref)), (var_51: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_437: (int64 ref)), (var_438: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_449: (uint64 ref)) = var_27.mem_0
        let (var_450: uint64) = method_5((var_449: (uint64 ref)))
        let (var_451: (uint64 ref)) = var_438.mem_0
        let (var_452: uint64) = method_5((var_451: (uint64 ref)))
        let (var_453: uint64) = method_5((var_451: (uint64 ref)))
        // Cuda join point
        // method_23((var_450: uint64), (var_452: uint64), (var_453: uint64))
        let (var_454: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_455: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_454.set_GridDimensions(var_455)
        let (var_456: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_454.set_BlockDimensions(var_456)
        let (var_457: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_459: (System.Object [])) = [|var_450; var_452; var_453|]: (System.Object [])
        var_454.RunAsync(var_457, var_459)
        let (var_464: int64) = 32768L
        let (var_465: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_464: int64))
        let (var_466: (int64 ref)) = var_465.mem_0
        let (var_467: Env6) = var_465.mem_1
        let (var_468: uint64) = method_5((var_451: (uint64 ref)))
        let (var_469: (uint64 ref)) = var_467.mem_0
        let (var_470: uint64) = method_5((var_469: (uint64 ref)))
        // Cuda join point
        // method_27((var_468: uint64), (var_470: uint64))
        let (var_471: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_472: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_471.set_GridDimensions(var_472)
        let (var_473: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_471.set_BlockDimensions(var_473)
        let (var_474: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_476: (System.Object [])) = [|var_468; var_470|]: (System.Object [])
        var_471.RunAsync(var_474, var_476)
        let (var_477: int64) = 32768L
        let (var_478: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_477: int64))
        let (var_479: (int64 ref)) = var_478.mem_0
        let (var_480: Env6) = var_478.mem_1
        let (var_481: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_482: (uint64 ref)) = var_480.mem_0
        let (var_483: uint64) = method_5((var_482: (uint64 ref)))
        let (var_484: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_483)
        let (var_485: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_484)
        let (var_486: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_485, 0uy, var_486, var_481)
        let (var_487: int64) = 32768L
        let (var_488: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_487: int64))
        let (var_489: (int64 ref)) = var_488.mem_0
        let (var_490: Env6) = var_488.mem_1
        method_22((var_30: (int64 ref)), (var_31: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_67: int64), (var_489: (int64 ref)), (var_490: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_491: int64) = 32768L
        let (var_492: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_491: int64))
        let (var_493: (int64 ref)) = var_492.mem_0
        let (var_494: Env6) = var_492.mem_1
        let (var_495: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_496: (uint64 ref)) = var_494.mem_0
        let (var_497: uint64) = method_5((var_496: (uint64 ref)))
        let (var_498: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_497)
        let (var_499: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_498)
        let (var_500: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_499, 0uy, var_500, var_495)
        method_46((var_42: (int64 ref)), (var_43: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_489: (int64 ref)), (var_490: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_501: (uint64 ref)) = var_19.mem_0
        let (var_502: uint64) = method_5((var_501: (uint64 ref)))
        let (var_503: (uint64 ref)) = var_490.mem_0
        let (var_504: uint64) = method_5((var_503: (uint64 ref)))
        let (var_505: uint64) = method_5((var_503: (uint64 ref)))
        // Cuda join point
        // method_23((var_502: uint64), (var_504: uint64), (var_505: uint64))
        let (var_506: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_507: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_506.set_GridDimensions(var_507)
        let (var_508: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_506.set_BlockDimensions(var_508)
        let (var_509: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_511: (System.Object [])) = [|var_502; var_504; var_505|]: (System.Object [])
        var_506.RunAsync(var_509, var_511)
        let (var_516: int64) = 32768L
        let (var_517: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_516: int64))
        let (var_518: (int64 ref)) = var_517.mem_0
        let (var_519: Env6) = var_517.mem_1
        let (var_520: uint64) = method_5((var_503: (uint64 ref)))
        let (var_521: (uint64 ref)) = var_519.mem_0
        let (var_522: uint64) = method_5((var_521: (uint64 ref)))
        // Cuda join point
        // method_27((var_520: uint64), (var_522: uint64))
        let (var_523: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_524: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_523.set_GridDimensions(var_524)
        let (var_525: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_523.set_BlockDimensions(var_525)
        let (var_526: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_528: (System.Object [])) = [|var_520; var_522|]: (System.Object [])
        var_523.RunAsync(var_526, var_528)
        let (var_529: int64) = 32768L
        let (var_530: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_529: int64))
        let (var_531: (int64 ref)) = var_530.mem_0
        let (var_532: Env6) = var_530.mem_1
        let (var_533: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_534: (uint64 ref)) = var_532.mem_0
        let (var_535: uint64) = method_5((var_534: (uint64 ref)))
        let (var_536: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_535)
        let (var_537: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_536)
        let (var_538: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_537, 0uy, var_538, var_533)
        let (var_540: int64) = 32768L
        let (var_541: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_540: int64))
        let (var_542: (int64 ref)) = var_541.mem_0
        let (var_543: Env6) = var_541.mem_1
        let (var_544: uint64) = method_5((var_417: (uint64 ref)))
        let (var_545: uint64) = method_5((var_469: (uint64 ref)))
        let (var_546: (uint64 ref)) = var_543.mem_0
        let (var_547: uint64) = method_5((var_546: (uint64 ref)))
        // Cuda join point
        // method_28((var_544: uint64), (var_545: uint64), (var_547: uint64))
        let (var_548: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_549: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_548.set_GridDimensions(var_549)
        let (var_550: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_548.set_BlockDimensions(var_550)
        let (var_551: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_553: (System.Object [])) = [|var_544; var_545; var_547|]: (System.Object [])
        var_548.RunAsync(var_551, var_553)
        let (var_554: int64) = 32768L
        let (var_555: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_554: int64))
        let (var_556: (int64 ref)) = var_555.mem_0
        let (var_557: Env6) = var_555.mem_1
        let (var_558: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_559: (uint64 ref)) = var_557.mem_0
        let (var_560: uint64) = method_5((var_559: (uint64 ref)))
        let (var_561: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_560)
        let (var_562: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_561)
        let (var_563: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_562, 0uy, var_563, var_558)
        let (var_565: int64) = 32768L
        let (var_566: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_565: int64))
        let (var_567: (int64 ref)) = var_566.mem_0
        let (var_568: Env6) = var_566.mem_1
        let (var_569: (uint64 ref)) = var_62.mem_0
        let (var_570: uint64) = method_5((var_569: (uint64 ref)))
        let (var_571: uint64) = method_5((var_521: (uint64 ref)))
        let (var_572: (uint64 ref)) = var_568.mem_0
        let (var_573: uint64) = method_5((var_572: (uint64 ref)))
        // Cuda join point
        // method_28((var_570: uint64), (var_571: uint64), (var_573: uint64))
        let (var_574: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_575: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_574.set_GridDimensions(var_575)
        let (var_576: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_574.set_BlockDimensions(var_576)
        let (var_577: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_579: (System.Object [])) = [|var_570; var_571; var_573|]: (System.Object [])
        var_574.RunAsync(var_577, var_579)
        let (var_580: int64) = 32768L
        let (var_581: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_580: int64))
        let (var_582: (int64 ref)) = var_581.mem_0
        let (var_583: Env6) = var_581.mem_1
        let (var_584: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_585: (uint64 ref)) = var_583.mem_0
        let (var_586: uint64) = method_5((var_585: (uint64 ref)))
        let (var_587: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_586)
        let (var_588: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_587)
        let (var_589: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_588, 0uy, var_589, var_584)
        let (var_591: int64) = 32768L
        let (var_592: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_591: int64))
        let (var_593: (int64 ref)) = var_592.mem_0
        let (var_594: Env6) = var_592.mem_1
        let (var_595: uint64) = method_5((var_546: (uint64 ref)))
        let (var_596: uint64) = method_5((var_572: (uint64 ref)))
        let (var_597: (uint64 ref)) = var_594.mem_0
        let (var_598: uint64) = method_5((var_597: (uint64 ref)))
        // Cuda join point
        // method_47((var_595: uint64), (var_596: uint64), (var_598: uint64))
        let (var_599: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_11, var_8)
        let (var_600: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_599.set_GridDimensions(var_600)
        let (var_601: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_599.set_BlockDimensions(var_601)
        let (var_602: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_604: (System.Object [])) = [|var_595; var_596; var_598|]: (System.Object [])
        var_599.RunAsync(var_602, var_604)
        let (var_605: int64) = 32768L
        let (var_606: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_605: int64))
        let (var_607: (int64 ref)) = var_606.mem_0
        let (var_608: Env6) = var_606.mem_1
        let (var_609: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_610: (uint64 ref)) = var_608.mem_0
        let (var_611: uint64) = method_5((var_610: (uint64 ref)))
        let (var_612: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_611)
        let (var_613: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_612)
        let (var_614: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_613, 0uy, var_614, var_609)
        let (var_615: int64) = 32768L
        let (var_616: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_615: int64))
        let (var_617: (int64 ref)) = var_616.mem_0
        let (var_618: Env6) = var_616.mem_1
        method_29((var_58: (int64 ref)), (var_59: Env6), (var_593: (int64 ref)), (var_594: Env6), (var_617: (int64 ref)), (var_618: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_619: int64) = 32768L
        let (var_620: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_619: int64))
        let (var_621: (int64 ref)) = var_620.mem_0
        let (var_622: Env6) = var_620.mem_1
        let (var_623: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_624: (uint64 ref)) = var_622.mem_0
        let (var_625: uint64) = method_5((var_624: (uint64 ref)))
        let (var_626: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_625)
        let (var_627: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_626)
        let (var_628: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_627, 0uy, var_628, var_623)
        let (var_629: (uint64 ref)) = var_55.mem_0
        let (var_630: uint64) = method_5((var_629: (uint64 ref)))
        let (var_631: (uint64 ref)) = var_618.mem_0
        let (var_632: uint64) = method_5((var_631: (uint64 ref)))
        let (var_633: uint64) = method_5((var_631: (uint64 ref)))
        // Cuda join point
        // method_23((var_630: uint64), (var_632: uint64), (var_633: uint64))
        let (var_634: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_635: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_634.set_GridDimensions(var_635)
        let (var_636: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_634.set_BlockDimensions(var_636)
        let (var_637: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_639: (System.Object [])) = [|var_630; var_632; var_633|]: (System.Object [])
        var_634.RunAsync(var_637, var_639)
        let (var_644: int64) = 32768L
        let (var_645: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_644: int64))
        let (var_646: (int64 ref)) = var_645.mem_0
        let (var_647: Env6) = var_645.mem_1
        let (var_648: uint64) = method_5((var_631: (uint64 ref)))
        let (var_649: (uint64 ref)) = var_647.mem_0
        let (var_650: uint64) = method_5((var_649: (uint64 ref)))
        // Cuda join point
        // method_27((var_648: uint64), (var_650: uint64))
        let (var_651: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_652: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_651.set_GridDimensions(var_652)
        let (var_653: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_651.set_BlockDimensions(var_653)
        let (var_654: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_656: (System.Object [])) = [|var_648; var_650|]: (System.Object [])
        var_651.RunAsync(var_654, var_656)
        let (var_657: int64) = 32768L
        let (var_658: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_657: int64))
        let (var_659: (int64 ref)) = var_658.mem_0
        let (var_660: Env6) = var_658.mem_1
        let (var_661: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_662: (uint64 ref)) = var_660.mem_0
        let (var_663: uint64) = method_5((var_662: (uint64 ref)))
        let (var_664: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_663)
        let (var_665: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_664)
        let (var_666: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_665, 0uy, var_666, var_661)
        let (var_667: uint64) = method_5((var_649: (uint64 ref)))
        let (var_668: (uint64 ref)) = var_1.mem_0
        let (var_669: uint64) = method_5((var_668: (uint64 ref)))
        let (var_670: int64) = (var_68 * 4L)
        let (var_671: uint64) = (uint64 var_670)
        let (var_672: uint64) = (var_669 + var_671)
        let (var_676: int64) = 4L
        let (var_677: Env2) = method_11((var_69: EnvHeap7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_676: int64))
        let (var_678: (int64 ref)) = var_677.mem_0
        let (var_679: Env6) = var_677.mem_1
        let (var_680: (uint64 ref)) = var_679.mem_0
        let (var_681: uint64) = method_5((var_680: (uint64 ref)))
        // Cuda join point
        // method_30((var_667: uint64), (var_672: uint64), (var_681: uint64))
        let (var_682: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_11, var_8)
        let (var_683: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_682.set_GridDimensions(var_683)
        let (var_684: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_682.set_BlockDimensions(var_684)
        let (var_685: ManagedCuda.BasicTypes.CUstream) = method_19((var_392: (bool ref)), (var_393: ManagedCuda.CudaStream))
        let (var_687: (System.Object [])) = [|var_667; var_672; var_681|]: (System.Object [])
        var_682.RunAsync(var_685, var_687)
        let (var_688: (unit -> unit)) = method_60((var_390: (int64 ref)), (var_391: Env6), (var_386: (int64 ref)), (var_387: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_67: int64), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_427: (int64 ref)), (var_428: Env6), (var_414: (int64 ref)), (var_415: Env6), (var_441: (int64 ref)), (var_442: Env6), (var_437: (int64 ref)), (var_438: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_479: (int64 ref)), (var_480: Env6), (var_466: (int64 ref)), (var_467: Env6), (var_493: (int64 ref)), (var_494: Env6), (var_489: (int64 ref)), (var_490: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_531: (int64 ref)), (var_532: Env6), (var_518: (int64 ref)), (var_519: Env6), (var_556: (int64 ref)), (var_557: Env6), (var_542: (int64 ref)), (var_543: Env6), (var_582: (int64 ref)), (var_583: Env6), (var_567: (int64 ref)), (var_568: Env6), (var_607: (int64 ref)), (var_608: Env6), (var_593: (int64 ref)), (var_594: Env6), (var_621: (int64 ref)), (var_622: Env6), (var_617: (int64 ref)), (var_618: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_659: (int64 ref)), (var_660: Env6), (var_646: (int64 ref)), (var_647: Env6), (var_678: (int64 ref)), (var_679: Env6), (var_68: int64))
        let (var_689: (unit -> float32)) = method_44((var_678: (int64 ref)), (var_679: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_990: int64) = 1L
        method_62((var_0: (int64 ref)), (var_1: Env6), (var_67: int64), (var_68: int64), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: (int64 ref)), (var_49: Env6), (var_50: (int64 ref)), (var_51: Env6), (var_52: (int64 ref)), (var_53: Env6), (var_54: (int64 ref)), (var_55: Env6), (var_56: (int64 ref)), (var_57: Env6), (var_58: (int64 ref)), (var_59: Env6), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_77: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_63: int64), (var_9: ResizeArray<Env2>), (var_60: ResizeArray<Env2>), (var_689: (unit -> float32)), (var_688: (unit -> unit)), (var_607: (int64 ref)), (var_608: Env6), (var_593: (int64 ref)), (var_594: Env6), (var_990: int64))
    else
        method_53((var_60: ResizeArray<Env2>))
        let (var_992: float) = (float var_14)
        (var_15 / var_992)
and method_60 ((var_0: (int64 ref)), (var_1: Env6), (var_2: (int64 ref)), (var_3: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_11: (int64 ref)), (var_12: Env6), (var_13: (int64 ref)), (var_14: Env6), (var_15: (int64 ref)), (var_16: Env6), (var_17: (int64 ref)), (var_18: Env6), (var_19: (int64 ref)), (var_20: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4), (var_33: (int64 ref)), (var_34: Env6), (var_35: (int64 ref)), (var_36: Env6), (var_37: (int64 ref)), (var_38: Env6), (var_39: (int64 ref)), (var_40: Env6), (var_41: (int64 ref)), (var_42: Env6), (var_43: (int64 ref)), (var_44: Env6), (var_45: (int64 ref)), (var_46: Env6), (var_47: (int64 ref)), (var_48: Env6), (var_49: (int64 ref)), (var_50: Env6), (var_51: (int64 ref)), (var_52: Env6), (var_53: (int64 ref)), (var_54: Env6), (var_55: (int64 ref)), (var_56: Env6), (var_57: (int64 ref)), (var_58: Env6), (var_59: (int64 ref)), (var_60: Env6), (var_61: (int64 ref)), (var_62: Env6), (var_63: (int64 ref)), (var_64: Env6), (var_65: (int64 ref)), (var_66: Env6), (var_67: (int64 ref)), (var_68: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_71: (int64 ref)), (var_72: Env6), (var_73: (int64 ref)), (var_74: Env6), (var_75: (int64 ref)), (var_76: Env6), (var_77: (int64 ref)), (var_78: Env6), (var_79: (int64 ref)), (var_80: Env6), (var_81: (int64 ref)), (var_82: Env6), (var_83: (int64 ref)), (var_84: Env6), (var_85: (int64 ref)), (var_86: Env6), (var_87: (int64 ref)), (var_88: Env6), (var_89: (int64 ref)), (var_90: Env6), (var_91: (int64 ref)), (var_92: Env6), (var_93: (int64 ref)), (var_94: Env6), (var_95: (int64 ref)), (var_96: Env6), (var_97: (int64 ref)), (var_98: Env6), (var_99: (int64 ref)), (var_100: Env6), (var_101: (int64 ref)), (var_102: Env6), (var_103: (int64 ref)), (var_104: Env6), (var_105: (int64 ref)), (var_106: Env6), (var_107: int64)) (): unit =
    let (var_108: (uint64 ref)) = var_106.mem_0
    let (var_109: uint64) = method_5((var_108: (uint64 ref)))
    let (var_110: (uint64 ref)) = var_104.mem_0
    let (var_111: uint64) = method_5((var_110: (uint64 ref)))
    let (var_112: (uint64 ref)) = var_9.mem_0
    let (var_113: uint64) = method_5((var_112: (uint64 ref)))
    let (var_114: int64) = (var_107 * 4L)
    let (var_115: uint64) = (uint64 var_114)
    let (var_116: uint64) = (var_113 + var_115)
    let (var_117: (uint64 ref)) = var_102.mem_0
    let (var_118: uint64) = method_5((var_117: (uint64 ref)))
    // Cuda join point
    // method_33((var_109: uint64), (var_111: uint64), (var_116: uint64), (var_118: uint64))
    let (var_119: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_30, var_27)
    let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_119.set_GridDimensions(var_120)
    let (var_121: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_119.set_BlockDimensions(var_121)
    let (var_122: (bool ref)) = var_32.mem_0
    let (var_123: ManagedCuda.CudaStream) = var_32.mem_1
    let (var_124: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_126: (System.Object [])) = [|var_109; var_111; var_116; var_118|]: (System.Object [])
    var_119.RunAsync(var_124, var_126)
    let (var_127: (uint64 ref)) = var_92.mem_0
    let (var_128: uint64) = method_5((var_127: (uint64 ref)))
    let (var_129: uint64) = method_5((var_117: (uint64 ref)))
    let (var_130: uint64) = method_5((var_110: (uint64 ref)))
    let (var_131: (uint64 ref)) = var_90.mem_0
    let (var_132: uint64) = method_5((var_131: (uint64 ref)))
    // Cuda join point
    // method_34((var_128: uint64), (var_129: uint64), (var_130: uint64), (var_132: uint64))
    let (var_133: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_30, var_27)
    let (var_134: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_133.set_GridDimensions(var_134)
    let (var_135: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_133.set_BlockDimensions(var_135)
    let (var_136: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_138: (System.Object [])) = [|var_128; var_129; var_130; var_132|]: (System.Object [])
    var_133.RunAsync(var_136, var_138)
    method_35((var_99: (int64 ref)), (var_100: Env6), (var_89: (int64 ref)), (var_90: Env6), (var_85: (int64 ref)), (var_86: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_89: (int64 ref)), (var_90: Env6), (var_87: (int64 ref)), (var_88: Env6), (var_97: (int64 ref)), (var_98: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    let (var_139: uint64) = method_5((var_131: (uint64 ref)))
    let (var_140: (uint64 ref)) = var_94.mem_0
    let (var_141: uint64) = method_5((var_140: (uint64 ref)))
    // Cuda join point
    // method_37((var_139: uint64), (var_141: uint64))
    let (var_142: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_30, var_27)
    let (var_143: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_142.set_GridDimensions(var_143)
    let (var_144: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_142.set_BlockDimensions(var_144)
    let (var_145: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_147: (System.Object [])) = [|var_139; var_141|]: (System.Object [])
    var_142.RunAsync(var_145, var_147)
    let (var_148: (uint64 ref)) = var_80.mem_0
    let (var_149: uint64) = method_5((var_148: (uint64 ref)))
    let (var_150: (uint64 ref)) = var_84.mem_0
    let (var_151: uint64) = method_5((var_150: (uint64 ref)))
    let (var_152: (uint64 ref)) = var_86.mem_0
    let (var_153: uint64) = method_5((var_152: (uint64 ref)))
    let (var_154: (uint64 ref)) = var_88.mem_0
    let (var_155: uint64) = method_5((var_154: (uint64 ref)))
    let (var_156: (uint64 ref)) = var_78.mem_0
    let (var_157: uint64) = method_5((var_156: (uint64 ref)))
    let (var_158: (uint64 ref)) = var_82.mem_0
    let (var_159: uint64) = method_5((var_158: (uint64 ref)))
    // Cuda join point
    // method_49((var_149: uint64), (var_151: uint64), (var_153: uint64), (var_155: uint64), (var_157: uint64), (var_159: uint64))
    let (var_160: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_30, var_27)
    let (var_161: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_160.set_GridDimensions(var_161)
    let (var_162: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_160.set_BlockDimensions(var_162)
    let (var_163: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_165: (System.Object [])) = [|var_149; var_151; var_153; var_155; var_157; var_159|]: (System.Object [])
    var_160.RunAsync(var_163, var_165)
    let (var_166: (uint64 ref)) = var_16.mem_0
    let (var_167: uint64) = method_5((var_166: (uint64 ref)))
    let (var_168: (uint64 ref)) = var_76.mem_0
    let (var_169: uint64) = method_5((var_168: (uint64 ref)))
    let (var_170: uint64) = method_5((var_158: (uint64 ref)))
    let (var_171: uint64) = method_5((var_150: (uint64 ref)))
    let (var_172: (uint64 ref)) = var_74.mem_0
    let (var_173: uint64) = method_5((var_172: (uint64 ref)))
    // Cuda join point
    // method_61((var_167: uint64), (var_169: uint64), (var_170: uint64), (var_171: uint64), (var_173: uint64))
    let (var_174: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_61", var_30, var_27)
    let (var_175: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_174.set_GridDimensions(var_175)
    let (var_176: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_174.set_BlockDimensions(var_176)
    let (var_177: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_179: (System.Object [])) = [|var_167; var_169; var_170; var_171; var_173|]: (System.Object [])
    var_174.RunAsync(var_177, var_179)
    let (var_180: (uint64 ref)) = var_36.mem_0
    let (var_181: uint64) = method_5((var_180: (uint64 ref)))
    let (var_182: (uint64 ref)) = var_56.mem_0
    let (var_183: uint64) = method_5((var_182: (uint64 ref)))
    let (var_184: uint64) = method_5((var_156: (uint64 ref)))
    let (var_185: uint64) = method_5((var_148: (uint64 ref)))
    let (var_186: (uint64 ref)) = var_34.mem_0
    let (var_187: uint64) = method_5((var_186: (uint64 ref)))
    let (var_188: (uint64 ref)) = var_54.mem_0
    let (var_189: uint64) = method_5((var_188: (uint64 ref)))
    // Cuda join point
    // method_41((var_181: uint64), (var_183: uint64), (var_184: uint64), (var_185: uint64), (var_187: uint64), (var_189: uint64))
    let (var_190: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_30, var_27)
    let (var_191: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_190.set_GridDimensions(var_191)
    let (var_192: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_190.set_BlockDimensions(var_192)
    let (var_193: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_195: (System.Object [])) = [|var_181; var_183; var_184; var_185; var_187; var_189|]: (System.Object [])
    var_190.RunAsync(var_193, var_195)
    let (var_196: (uint64 ref)) = var_60.mem_0
    let (var_197: uint64) = method_5((var_196: (uint64 ref)))
    let (var_198: uint64) = method_5((var_172: (uint64 ref)))
    let (var_199: uint64) = method_5((var_168: (uint64 ref)))
    let (var_200: (uint64 ref)) = var_58.mem_0
    let (var_201: uint64) = method_5((var_200: (uint64 ref)))
    // Cuda join point
    // method_34((var_197: uint64), (var_198: uint64), (var_199: uint64), (var_201: uint64))
    let (var_202: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_30, var_27)
    let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_202.set_GridDimensions(var_203)
    let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_202.set_BlockDimensions(var_204)
    let (var_205: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_207: (System.Object [])) = [|var_197; var_198; var_199; var_201|]: (System.Object [])
    var_202.RunAsync(var_205, var_207)
    method_42((var_57: (int64 ref)), (var_58: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_65: (int64 ref)), (var_66: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_57: (int64 ref)), (var_58: Env6), (var_15: (int64 ref)), (var_16: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    let (var_208: uint64) = method_5((var_200: (uint64 ref)))
    let (var_209: (uint64 ref)) = var_62.mem_0
    let (var_210: uint64) = method_5((var_209: (uint64 ref)))
    // Cuda join point
    // method_37((var_208: uint64), (var_210: uint64))
    let (var_211: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_30, var_27)
    let (var_212: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_211.set_GridDimensions(var_212)
    let (var_213: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_211.set_BlockDimensions(var_213)
    let (var_214: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_216: (System.Object [])) = [|var_208; var_210|]: (System.Object [])
    var_211.RunAsync(var_214, var_216)
    let (var_217: (uint64 ref)) = var_40.mem_0
    let (var_218: uint64) = method_5((var_217: (uint64 ref)))
    let (var_219: uint64) = method_5((var_188: (uint64 ref)))
    let (var_220: uint64) = method_5((var_182: (uint64 ref)))
    let (var_221: (uint64 ref)) = var_38.mem_0
    let (var_222: uint64) = method_5((var_221: (uint64 ref)))
    // Cuda join point
    // method_34((var_218: uint64), (var_219: uint64), (var_220: uint64), (var_222: uint64))
    let (var_223: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_30, var_27)
    let (var_224: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_223.set_GridDimensions(var_224)
    let (var_225: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_223.set_BlockDimensions(var_225)
    let (var_226: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_228: (System.Object [])) = [|var_218; var_219; var_220; var_222|]: (System.Object [])
    var_223.RunAsync(var_226, var_228)
    method_42((var_37: (int64 ref)), (var_38: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_45: (int64 ref)), (var_46: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_37: (int64 ref)), (var_38: Env6), (var_15: (int64 ref)), (var_16: Env6), (var_49: (int64 ref)), (var_50: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    let (var_229: uint64) = method_5((var_221: (uint64 ref)))
    let (var_230: (uint64 ref)) = var_42.mem_0
    let (var_231: uint64) = method_5((var_230: (uint64 ref)))
    // Cuda join point
    // method_37((var_229: uint64), (var_231: uint64))
    let (var_232: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_30, var_27)
    let (var_233: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_232.set_GridDimensions(var_233)
    let (var_234: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_232.set_BlockDimensions(var_234)
    let (var_235: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_237: (System.Object [])) = [|var_229; var_231|]: (System.Object [])
    var_232.RunAsync(var_235, var_237)
    let (var_238: (uint64 ref)) = var_3.mem_0
    let (var_239: uint64) = method_5((var_238: (uint64 ref)))
    let (var_240: uint64) = method_5((var_186: (uint64 ref)))
    let (var_241: uint64) = method_5((var_180: (uint64 ref)))
    let (var_242: (uint64 ref)) = var_1.mem_0
    let (var_243: uint64) = method_5((var_242: (uint64 ref)))
    // Cuda join point
    // method_43((var_239: uint64), (var_240: uint64), (var_241: uint64), (var_243: uint64))
    let (var_244: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_30, var_27)
    let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_244.set_GridDimensions(var_245)
    let (var_246: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_244.set_BlockDimensions(var_246)
    let (var_247: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_249: (System.Object [])) = [|var_239; var_240; var_241; var_243|]: (System.Object [])
    var_244.RunAsync(var_247, var_249)
    method_42((var_0: (int64 ref)), (var_1: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: int64), (var_11: (int64 ref)), (var_12: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_0: (int64 ref)), (var_1: Env6), (var_15: (int64 ref)), (var_16: Env6), (var_17: (int64 ref)), (var_18: Env6), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    let (var_250: uint64) = method_5((var_242: (uint64 ref)))
    let (var_251: (uint64 ref)) = var_5.mem_0
    let (var_252: uint64) = method_5((var_251: (uint64 ref)))
    // Cuda join point
    // method_37((var_250: uint64), (var_252: uint64))
    let (var_253: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_30, var_27)
    let (var_254: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_253.set_GridDimensions(var_254)
    let (var_255: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_253.set_BlockDimensions(var_255)
    let (var_256: ManagedCuda.BasicTypes.CUstream) = method_19((var_122: (bool ref)), (var_123: ManagedCuda.CudaStream))
    let (var_258: (System.Object [])) = [|var_250; var_252|]: (System.Object [])
    var_253.RunAsync(var_256, var_258)
and method_62((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_60: int64), (var_61: float), (var_62: int64), (var_63: ResizeArray<Env2>), (var_64: ResizeArray<Env2>), (var_65: (unit -> float32)), (var_66: (unit -> unit)), (var_67: (int64 ref)), (var_68: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_71: int64)): float =
    let (var_72: bool) = (var_71 < 64L)
    if var_72 then
        let (var_73: bool) = (var_71 >= 0L)
        let (var_74: bool) = (var_73 = false)
        if var_74 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_75: int64) = (var_71 * 8192L)
        let (var_76: int64) = (var_2 + var_75)
        if var_74 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_77: int64) = (var_3 + var_75)
        let (var_78: int64) = 32768L
        let (var_79: EnvHeap7) = ({mem_0 = (var_50: (uint64 ref)); mem_1 = (var_51: uint64); mem_2 = (var_52: ResizeArray<Env0>); mem_3 = (var_53: ResizeArray<Env1>)} : EnvHeap7)
        let (var_80: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_78: int64))
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: Env6) = var_80.mem_1
        method_22((var_22: (int64 ref)), (var_23: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_76: int64), (var_81: (int64 ref)), (var_82: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_83: int64) = 32768L
        let (var_84: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_83: int64))
        let (var_85: (int64 ref)) = var_84.mem_0
        let (var_86: Env6) = var_84.mem_1
        let (var_87: (bool ref)) = var_59.mem_0
        let (var_88: ManagedCuda.CudaStream) = var_59.mem_1
        let (var_89: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_90: (uint64 ref)) = var_86.mem_0
        let (var_91: uint64) = method_5((var_90: (uint64 ref)))
        let (var_92: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_91)
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_92)
        let (var_94: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_93, 0uy, var_94, var_89)
        method_46((var_34: (int64 ref)), (var_35: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_81: (int64 ref)), (var_82: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_95: (uint64 ref)) = var_11.mem_0
        let (var_96: uint64) = method_5((var_95: (uint64 ref)))
        let (var_97: (uint64 ref)) = var_82.mem_0
        let (var_98: uint64) = method_5((var_97: (uint64 ref)))
        let (var_99: uint64) = method_5((var_97: (uint64 ref)))
        // Cuda join point
        // method_23((var_96: uint64), (var_98: uint64), (var_99: uint64))
        let (var_100: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_100.set_GridDimensions(var_101)
        let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_100.set_BlockDimensions(var_102)
        let (var_103: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_105: (System.Object [])) = [|var_96; var_98; var_99|]: (System.Object [])
        var_100.RunAsync(var_103, var_105)
        let (var_107: int64) = 32768L
        let (var_108: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_107: int64))
        let (var_109: (int64 ref)) = var_108.mem_0
        let (var_110: Env6) = var_108.mem_1
        let (var_111: uint64) = method_5((var_97: (uint64 ref)))
        let (var_112: (uint64 ref)) = var_110.mem_0
        let (var_113: uint64) = method_5((var_112: (uint64 ref)))
        // Cuda join point
        // method_25((var_111: uint64), (var_113: uint64))
        let (var_114: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_57, var_54)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_114.set_GridDimensions(var_115)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_114.set_BlockDimensions(var_116)
        let (var_117: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_119: (System.Object [])) = [|var_111; var_113|]: (System.Object [])
        var_114.RunAsync(var_117, var_119)
        let (var_120: int64) = 32768L
        let (var_121: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_120: int64))
        let (var_122: (int64 ref)) = var_121.mem_0
        let (var_123: Env6) = var_121.mem_1
        let (var_124: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_125: (uint64 ref)) = var_123.mem_0
        let (var_126: uint64) = method_5((var_125: (uint64 ref)))
        let (var_127: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_126)
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_127)
        let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_128, 0uy, var_129, var_124)
        let (var_130: int64) = 32768L
        let (var_131: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_130: int64))
        let (var_132: (int64 ref)) = var_131.mem_0
        let (var_133: Env6) = var_131.mem_1
        method_22((var_26: (int64 ref)), (var_27: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_76: int64), (var_132: (int64 ref)), (var_133: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_134: int64) = 32768L
        let (var_135: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_134: int64))
        let (var_136: (int64 ref)) = var_135.mem_0
        let (var_137: Env6) = var_135.mem_1
        let (var_138: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_139: (uint64 ref)) = var_137.mem_0
        let (var_140: uint64) = method_5((var_139: (uint64 ref)))
        let (var_141: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_140)
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_141)
        let (var_143: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_142, 0uy, var_143, var_138)
        method_46((var_38: (int64 ref)), (var_39: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_132: (int64 ref)), (var_133: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_144: (uint64 ref)) = var_15.mem_0
        let (var_145: uint64) = method_5((var_144: (uint64 ref)))
        let (var_146: (uint64 ref)) = var_133.mem_0
        let (var_147: uint64) = method_5((var_146: (uint64 ref)))
        let (var_148: uint64) = method_5((var_146: (uint64 ref)))
        // Cuda join point
        // method_23((var_145: uint64), (var_147: uint64), (var_148: uint64))
        let (var_149: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_149.set_GridDimensions(var_150)
        let (var_151: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_149.set_BlockDimensions(var_151)
        let (var_152: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_154: (System.Object [])) = [|var_145; var_147; var_148|]: (System.Object [])
        var_149.RunAsync(var_152, var_154)
        let (var_159: int64) = 32768L
        let (var_160: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_159: int64))
        let (var_161: (int64 ref)) = var_160.mem_0
        let (var_162: Env6) = var_160.mem_1
        let (var_163: uint64) = method_5((var_146: (uint64 ref)))
        let (var_164: (uint64 ref)) = var_162.mem_0
        let (var_165: uint64) = method_5((var_164: (uint64 ref)))
        // Cuda join point
        // method_27((var_163: uint64), (var_165: uint64))
        let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_166.set_GridDimensions(var_167)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_166.set_BlockDimensions(var_168)
        let (var_169: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_171: (System.Object [])) = [|var_163; var_165|]: (System.Object [])
        var_166.RunAsync(var_169, var_171)
        let (var_172: int64) = 32768L
        let (var_173: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_172: int64))
        let (var_174: (int64 ref)) = var_173.mem_0
        let (var_175: Env6) = var_173.mem_1
        let (var_176: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_177: (uint64 ref)) = var_175.mem_0
        let (var_178: uint64) = method_5((var_177: (uint64 ref)))
        let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_178)
        let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_179)
        let (var_181: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_180, 0uy, var_181, var_176)
        let (var_182: int64) = 32768L
        let (var_183: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_182: int64))
        let (var_184: (int64 ref)) = var_183.mem_0
        let (var_185: Env6) = var_183.mem_1
        method_22((var_18: (int64 ref)), (var_19: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_76: int64), (var_184: (int64 ref)), (var_185: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_186: int64) = 32768L
        let (var_187: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_186: int64))
        let (var_188: (int64 ref)) = var_187.mem_0
        let (var_189: Env6) = var_187.mem_1
        let (var_190: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_191: (uint64 ref)) = var_189.mem_0
        let (var_192: uint64) = method_5((var_191: (uint64 ref)))
        let (var_193: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_192)
        let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_193)
        let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_194, 0uy, var_195, var_190)
        method_46((var_30: (int64 ref)), (var_31: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_184: (int64 ref)), (var_185: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_196: (uint64 ref)) = var_7.mem_0
        let (var_197: uint64) = method_5((var_196: (uint64 ref)))
        let (var_198: (uint64 ref)) = var_185.mem_0
        let (var_199: uint64) = method_5((var_198: (uint64 ref)))
        let (var_200: uint64) = method_5((var_198: (uint64 ref)))
        // Cuda join point
        // method_23((var_197: uint64), (var_199: uint64), (var_200: uint64))
        let (var_201: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_201.set_GridDimensions(var_202)
        let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_201.set_BlockDimensions(var_203)
        let (var_204: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_206: (System.Object [])) = [|var_197; var_199; var_200|]: (System.Object [])
        var_201.RunAsync(var_204, var_206)
        let (var_211: int64) = 32768L
        let (var_212: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_211: int64))
        let (var_213: (int64 ref)) = var_212.mem_0
        let (var_214: Env6) = var_212.mem_1
        let (var_215: uint64) = method_5((var_198: (uint64 ref)))
        let (var_216: (uint64 ref)) = var_214.mem_0
        let (var_217: uint64) = method_5((var_216: (uint64 ref)))
        // Cuda join point
        // method_27((var_215: uint64), (var_217: uint64))
        let (var_218: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_219: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_218.set_GridDimensions(var_219)
        let (var_220: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_218.set_BlockDimensions(var_220)
        let (var_221: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_223: (System.Object [])) = [|var_215; var_217|]: (System.Object [])
        var_218.RunAsync(var_221, var_223)
        let (var_224: int64) = 32768L
        let (var_225: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_224: int64))
        let (var_226: (int64 ref)) = var_225.mem_0
        let (var_227: Env6) = var_225.mem_1
        let (var_228: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_229: (uint64 ref)) = var_227.mem_0
        let (var_230: uint64) = method_5((var_229: (uint64 ref)))
        let (var_231: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_230)
        let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_231)
        let (var_233: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_232, 0uy, var_233, var_228)
        let (var_235: int64) = 32768L
        let (var_236: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_235: int64))
        let (var_237: (int64 ref)) = var_236.mem_0
        let (var_238: Env6) = var_236.mem_1
        let (var_239: uint64) = method_5((var_112: (uint64 ref)))
        let (var_240: uint64) = method_5((var_164: (uint64 ref)))
        let (var_241: (uint64 ref)) = var_238.mem_0
        let (var_242: uint64) = method_5((var_241: (uint64 ref)))
        // Cuda join point
        // method_28((var_239: uint64), (var_240: uint64), (var_242: uint64))
        let (var_243: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_57, var_54)
        let (var_244: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_243.set_GridDimensions(var_244)
        let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_243.set_BlockDimensions(var_245)
        let (var_246: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_248: (System.Object [])) = [|var_239; var_240; var_242|]: (System.Object [])
        var_243.RunAsync(var_246, var_248)
        let (var_249: int64) = 32768L
        let (var_250: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_249: int64))
        let (var_251: (int64 ref)) = var_250.mem_0
        let (var_252: Env6) = var_250.mem_1
        let (var_253: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_254: (uint64 ref)) = var_252.mem_0
        let (var_255: uint64) = method_5((var_254: (uint64 ref)))
        let (var_256: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_255)
        let (var_257: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_256)
        let (var_258: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_257, 0uy, var_258, var_253)
        let (var_260: int64) = 32768L
        let (var_261: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_260: int64))
        let (var_262: (int64 ref)) = var_261.mem_0
        let (var_263: Env6) = var_261.mem_1
        let (var_264: (uint64 ref)) = var_70.mem_0
        let (var_265: uint64) = method_5((var_264: (uint64 ref)))
        let (var_266: uint64) = method_5((var_216: (uint64 ref)))
        let (var_267: (uint64 ref)) = var_263.mem_0
        let (var_268: uint64) = method_5((var_267: (uint64 ref)))
        // Cuda join point
        // method_28((var_265: uint64), (var_266: uint64), (var_268: uint64))
        let (var_269: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_57, var_54)
        let (var_270: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_269.set_GridDimensions(var_270)
        let (var_271: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_269.set_BlockDimensions(var_271)
        let (var_272: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_274: (System.Object [])) = [|var_265; var_266; var_268|]: (System.Object [])
        var_269.RunAsync(var_272, var_274)
        let (var_275: int64) = 32768L
        let (var_276: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_275: int64))
        let (var_277: (int64 ref)) = var_276.mem_0
        let (var_278: Env6) = var_276.mem_1
        let (var_279: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_280: (uint64 ref)) = var_278.mem_0
        let (var_281: uint64) = method_5((var_280: (uint64 ref)))
        let (var_282: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_281)
        let (var_283: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_282)
        let (var_284: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_283, 0uy, var_284, var_279)
        let (var_286: int64) = 32768L
        let (var_287: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_286: int64))
        let (var_288: (int64 ref)) = var_287.mem_0
        let (var_289: Env6) = var_287.mem_1
        let (var_290: uint64) = method_5((var_241: (uint64 ref)))
        let (var_291: uint64) = method_5((var_267: (uint64 ref)))
        let (var_292: (uint64 ref)) = var_289.mem_0
        let (var_293: uint64) = method_5((var_292: (uint64 ref)))
        // Cuda join point
        // method_47((var_290: uint64), (var_291: uint64), (var_293: uint64))
        let (var_294: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_57, var_54)
        let (var_295: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_294.set_GridDimensions(var_295)
        let (var_296: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_294.set_BlockDimensions(var_296)
        let (var_297: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_299: (System.Object [])) = [|var_290; var_291; var_293|]: (System.Object [])
        var_294.RunAsync(var_297, var_299)
        let (var_300: int64) = 32768L
        let (var_301: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_300: int64))
        let (var_302: (int64 ref)) = var_301.mem_0
        let (var_303: Env6) = var_301.mem_1
        let (var_304: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_305: (uint64 ref)) = var_303.mem_0
        let (var_306: uint64) = method_5((var_305: (uint64 ref)))
        let (var_307: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_306)
        let (var_308: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_307)
        let (var_309: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_308, 0uy, var_309, var_304)
        let (var_310: int64) = 32768L
        let (var_311: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_310: int64))
        let (var_312: (int64 ref)) = var_311.mem_0
        let (var_313: Env6) = var_311.mem_1
        method_29((var_46: (int64 ref)), (var_47: Env6), (var_288: (int64 ref)), (var_289: Env6), (var_312: (int64 ref)), (var_313: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
        let (var_314: int64) = 32768L
        let (var_315: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_314: int64))
        let (var_316: (int64 ref)) = var_315.mem_0
        let (var_317: Env6) = var_315.mem_1
        let (var_318: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_319: (uint64 ref)) = var_317.mem_0
        let (var_320: uint64) = method_5((var_319: (uint64 ref)))
        let (var_321: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_320)
        let (var_322: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_321)
        let (var_323: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_322, 0uy, var_323, var_318)
        let (var_324: (uint64 ref)) = var_43.mem_0
        let (var_325: uint64) = method_5((var_324: (uint64 ref)))
        let (var_326: (uint64 ref)) = var_313.mem_0
        let (var_327: uint64) = method_5((var_326: (uint64 ref)))
        let (var_328: uint64) = method_5((var_326: (uint64 ref)))
        // Cuda join point
        // method_23((var_325: uint64), (var_327: uint64), (var_328: uint64))
        let (var_329: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_57, var_54)
        let (var_330: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_329.set_GridDimensions(var_330)
        let (var_331: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_329.set_BlockDimensions(var_331)
        let (var_332: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_334: (System.Object [])) = [|var_325; var_327; var_328|]: (System.Object [])
        var_329.RunAsync(var_332, var_334)
        let (var_339: int64) = 32768L
        let (var_340: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_339: int64))
        let (var_341: (int64 ref)) = var_340.mem_0
        let (var_342: Env6) = var_340.mem_1
        let (var_343: uint64) = method_5((var_326: (uint64 ref)))
        let (var_344: (uint64 ref)) = var_342.mem_0
        let (var_345: uint64) = method_5((var_344: (uint64 ref)))
        // Cuda join point
        // method_27((var_343: uint64), (var_345: uint64))
        let (var_346: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_57, var_54)
        let (var_347: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_346.set_GridDimensions(var_347)
        let (var_348: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_346.set_BlockDimensions(var_348)
        let (var_349: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_351: (System.Object [])) = [|var_343; var_345|]: (System.Object [])
        var_346.RunAsync(var_349, var_351)
        let (var_352: int64) = 32768L
        let (var_353: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_352: int64))
        let (var_354: (int64 ref)) = var_353.mem_0
        let (var_355: Env6) = var_353.mem_1
        let (var_356: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_357: (uint64 ref)) = var_355.mem_0
        let (var_358: uint64) = method_5((var_357: (uint64 ref)))
        let (var_359: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_358)
        let (var_360: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_359)
        let (var_361: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_54.ClearMemoryAsync(var_360, 0uy, var_361, var_356)
        let (var_362: uint64) = method_5((var_344: (uint64 ref)))
        let (var_363: (uint64 ref)) = var_1.mem_0
        let (var_364: uint64) = method_5((var_363: (uint64 ref)))
        let (var_365: int64) = (var_77 * 4L)
        let (var_366: uint64) = (uint64 var_365)
        let (var_367: uint64) = (var_364 + var_366)
        let (var_371: int64) = 4L
        let (var_372: Env2) = method_11((var_79: EnvHeap7), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_371: int64))
        let (var_373: (int64 ref)) = var_372.mem_0
        let (var_374: Env6) = var_372.mem_1
        let (var_375: (uint64 ref)) = var_374.mem_0
        let (var_376: uint64) = method_5((var_375: (uint64 ref)))
        // Cuda join point
        // method_30((var_362: uint64), (var_367: uint64), (var_376: uint64))
        let (var_377: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_57, var_54)
        let (var_378: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_377.set_GridDimensions(var_378)
        let (var_379: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_377.set_BlockDimensions(var_379)
        let (var_380: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_382: (System.Object [])) = [|var_362; var_367; var_376|]: (System.Object [])
        var_377.RunAsync(var_380, var_382)
        let (var_383: (unit -> unit)) = method_48((var_66: (unit -> unit)), (var_85: (int64 ref)), (var_86: Env6), (var_81: (int64 ref)), (var_82: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_0: (int64 ref)), (var_1: Env6), (var_76: int64), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_67: (int64 ref)), (var_68: Env6), (var_69: (int64 ref)), (var_70: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_122: (int64 ref)), (var_123: Env6), (var_109: (int64 ref)), (var_110: Env6), (var_136: (int64 ref)), (var_137: Env6), (var_132: (int64 ref)), (var_133: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_174: (int64 ref)), (var_175: Env6), (var_161: (int64 ref)), (var_162: Env6), (var_188: (int64 ref)), (var_189: Env6), (var_184: (int64 ref)), (var_185: Env6), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_226: (int64 ref)), (var_227: Env6), (var_213: (int64 ref)), (var_214: Env6), (var_251: (int64 ref)), (var_252: Env6), (var_237: (int64 ref)), (var_238: Env6), (var_277: (int64 ref)), (var_278: Env6), (var_262: (int64 ref)), (var_263: Env6), (var_302: (int64 ref)), (var_303: Env6), (var_288: (int64 ref)), (var_289: Env6), (var_316: (int64 ref)), (var_317: Env6), (var_312: (int64 ref)), (var_313: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_354: (int64 ref)), (var_355: Env6), (var_341: (int64 ref)), (var_342: Env6), (var_373: (int64 ref)), (var_374: Env6), (var_77: int64))
        let (var_384: (unit -> float32)) = method_50((var_373: (int64 ref)), (var_374: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_65: (unit -> float32)))
        let (var_385: int64) = (var_71 + 1L)
        method_62((var_0: (int64 ref)), (var_1: Env6), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_60: int64), (var_61: float), (var_62: int64), (var_63: ResizeArray<Env2>), (var_64: ResizeArray<Env2>), (var_384: (unit -> float32)), (var_383: (unit -> unit)), (var_302: (int64 ref)), (var_303: Env6), (var_288: (int64 ref)), (var_289: Env6), (var_385: int64))
    else
        // Done with foru...
        let (var_387: float32) = var_65()
        let (var_388: float) = (float var_387)
        let (var_389: float) = (var_61 + var_388)
        let (var_398: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_52((var_69: (int64 ref)), (var_70: Env6), (var_398: ResizeArray<Env2>))
        let (var_399: int64) = (var_60 + 1L)
        if (System.Double.IsNaN var_389) then
            method_53((var_64: ResizeArray<Env2>))
            // Is nan...
            method_53((var_55: ResizeArray<Env2>))
            // Done with the net...
            method_53((var_398: ResizeArray<Env2>))
            let (var_400: float) = (float var_399)
            (var_389 / var_400)
        else
            var_66()
            method_55((var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4))
            method_53((var_64: ResizeArray<Env2>))
            // Done with body...
            method_53((var_55: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_402: int64) = (var_62 + 1L)
            method_59((var_0: (int64 ref)), (var_1: Env6), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_49: ManagedCuda.CudaRand.CudaRandDevice), (var_50: (uint64 ref)), (var_51: uint64), (var_52: ResizeArray<Env0>), (var_53: ResizeArray<Env1>), (var_54: ManagedCuda.CudaContext), (var_63: ResizeArray<Env2>), (var_56: ResizeArray<Env3>), (var_57: ManagedCuda.BasicTypes.CUmodule), (var_58: (int64 ref)), (var_59: EnvHeap4), (var_399: int64), (var_389: float), (var_4: (int64 ref)), (var_5: Env6), (var_6: (int64 ref)), (var_7: Env6), (var_8: (int64 ref)), (var_9: Env6), (var_10: (int64 ref)), (var_11: Env6), (var_12: (int64 ref)), (var_13: Env6), (var_14: (int64 ref)), (var_15: Env6), (var_16: (int64 ref)), (var_17: Env6), (var_18: (int64 ref)), (var_19: Env6), (var_20: (int64 ref)), (var_21: Env6), (var_22: (int64 ref)), (var_23: Env6), (var_24: (int64 ref)), (var_25: Env6), (var_26: (int64 ref)), (var_27: Env6), (var_28: (int64 ref)), (var_29: Env6), (var_30: (int64 ref)), (var_31: Env6), (var_32: (int64 ref)), (var_33: Env6), (var_34: (int64 ref)), (var_35: Env6), (var_36: (int64 ref)), (var_37: Env6), (var_38: (int64 ref)), (var_39: Env6), (var_40: (int64 ref)), (var_41: Env6), (var_42: (int64 ref)), (var_43: Env6), (var_44: (int64 ref)), (var_45: Env6), (var_46: (int64 ref)), (var_47: Env6), (var_398: ResizeArray<Env2>), (var_69: (int64 ref)), (var_70: Env6), (var_402: int64))
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
let (var_66: ResizeArray<Env3>) = ResizeArray<Env3>()
let (var_67: (bool ref)) = (ref true)
let (var_68: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_69: EnvHeap4) = ({mem_0 = (var_67: (bool ref)); mem_1 = (var_68: ManagedCuda.CudaStream)} : EnvHeap4)
let (var_70: Env3) = method_7((var_69: EnvHeap4), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_71: (int64 ref)) = var_70.mem_0
let (var_72: EnvHeap4) = var_70.mem_1
let (var_74: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_75: int64) = var_74.LongLength
let (var_76: bool) = (var_75 >= 0L)
let (var_77: bool) = (var_76 = false)
if var_77 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_82: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_75))
let (var_83: int64) = 0L
method_9((var_82: (uint8 [])), (var_74: (char [])), (var_75: int64), (var_83: int64))
let (var_84: int64) = var_82.LongLength
let (var_85: bool) = (var_84 > 0L)
let (var_86: bool) = (var_85 = false)
if var_86 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_87: bool) = (var_84 = 1115394L)
let (var_88: bool) = (var_87 = false)
if var_88 then
    (failwith "The dimensions must match.")
else
    ()
let (var_89: int64) = 1115394L
let (var_90: int64) = 0L
let (var_91: int64) = 1L
let (var_92: Env5) = method_10((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_89: int64), (var_82: (uint8 [])), (var_90: int64), (var_91: int64))
let (var_93: Env2) = var_92.mem_0
let (var_94: (int64 ref)) = var_93.mem_0
let (var_95: Env6) = var_93.mem_1
let (var_96: (uint64 ref)) = var_95.mem_0
let (var_97: uint64) = method_5((var_96: (uint64 ref)))
let (var_101: int64) = 571080704L
let (var_102: EnvHeap7) = ({mem_0 = (var_39: (uint64 ref)); mem_1 = (var_35: uint64); mem_2 = (var_40: ResizeArray<Env0>); mem_3 = (var_41: ResizeArray<Env1>)} : EnvHeap7)
let (var_103: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_101: int64))
let (var_104: (int64 ref)) = var_103.mem_0
let (var_105: Env6) = var_103.mem_1
let (var_106: (uint64 ref)) = var_105.mem_0
let (var_107: uint64) = method_5((var_106: (uint64 ref)))
// Cuda join point
// method_16((var_97: uint64), (var_107: uint64))
let (var_108: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_109: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
var_108.set_GridDimensions(var_109)
let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_108.set_BlockDimensions(var_110)
let (var_111: (bool ref)) = var_72.mem_0
let (var_112: ManagedCuda.CudaStream) = var_72.mem_1
let (var_113: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_115: (System.Object [])) = [|var_97; var_107|]: (System.Object [])
var_108.RunAsync(var_113, var_115)
let (var_116: int64) = 65536L
let (var_117: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_116: int64))
let (var_118: (int64 ref)) = var_117.mem_0
let (var_119: Env6) = var_117.mem_1
let (var_120: (uint64 ref)) = var_119.mem_0
let (var_121: uint64) = method_5((var_120: (uint64 ref)))
let (var_122: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_123: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_123)
let (var_124: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_121)
let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_124)
var_43.GenerateNormal32(var_125, var_122, 0.000000f, 0.108253f)
let (var_126: int64) = 65536L
let (var_127: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_126: int64))
let (var_128: (int64 ref)) = var_127.mem_0
let (var_129: Env6) = var_127.mem_1
let (var_130: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_131: (uint64 ref)) = var_129.mem_0
let (var_132: uint64) = method_5((var_131: (uint64 ref)))
let (var_133: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_132)
let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_133)
let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_134, 0uy, var_135, var_130)
let (var_136: int64) = 65536L
let (var_137: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_136: int64))
let (var_138: (int64 ref)) = var_137.mem_0
let (var_139: Env6) = var_137.mem_1
let (var_140: (uint64 ref)) = var_139.mem_0
let (var_141: uint64) = method_5((var_140: (uint64 ref)))
let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_143: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_143)
let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_141)
let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_144)
var_43.GenerateNormal32(var_145, var_142, 0.000000f, 0.088388f)
let (var_146: int64) = 65536L
let (var_147: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_146: int64))
let (var_148: (int64 ref)) = var_147.mem_0
let (var_149: Env6) = var_147.mem_1
let (var_150: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_151: (uint64 ref)) = var_149.mem_0
let (var_152: uint64) = method_5((var_151: (uint64 ref)))
let (var_153: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_152)
let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_153)
let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_154, 0uy, var_155, var_150)
let (var_156: int64) = 65536L
let (var_157: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_156: int64))
let (var_158: (int64 ref)) = var_157.mem_0
let (var_159: Env6) = var_157.mem_1
let (var_160: (uint64 ref)) = var_159.mem_0
let (var_161: uint64) = method_5((var_160: (uint64 ref)))
let (var_162: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_163: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_163)
let (var_164: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_161)
let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_164)
var_43.GenerateNormal32(var_165, var_162, 0.000000f, 0.088388f)
let (var_166: int64) = 65536L
let (var_167: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_166: int64))
let (var_168: (int64 ref)) = var_167.mem_0
let (var_169: Env6) = var_167.mem_1
let (var_170: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_171: (uint64 ref)) = var_169.mem_0
let (var_172: uint64) = method_5((var_171: (uint64 ref)))
let (var_173: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_172)
let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_173)
let (var_175: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_174, 0uy, var_175, var_170)
let (var_176: int64) = 65536L
let (var_177: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_176: int64))
let (var_178: (int64 ref)) = var_177.mem_0
let (var_179: Env6) = var_177.mem_1
let (var_180: (uint64 ref)) = var_179.mem_0
let (var_181: uint64) = method_5((var_180: (uint64 ref)))
let (var_182: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_183: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_183)
let (var_184: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_181)
let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_184)
var_43.GenerateNormal32(var_185, var_182, 0.000000f, 0.108253f)
let (var_186: int64) = 65536L
let (var_187: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_186: int64))
let (var_188: (int64 ref)) = var_187.mem_0
let (var_189: Env6) = var_187.mem_1
let (var_190: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_191: (uint64 ref)) = var_189.mem_0
let (var_192: uint64) = method_5((var_191: (uint64 ref)))
let (var_193: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_192)
let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_193)
let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_194, 0uy, var_195, var_190)
let (var_196: int64) = 65536L
let (var_197: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_196: int64))
let (var_198: (int64 ref)) = var_197.mem_0
let (var_199: Env6) = var_197.mem_1
let (var_200: (uint64 ref)) = var_199.mem_0
let (var_201: uint64) = method_5((var_200: (uint64 ref)))
let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_203: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_203)
let (var_204: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_201)
let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_204)
var_43.GenerateNormal32(var_205, var_202, 0.000000f, 0.088388f)
let (var_206: int64) = 65536L
let (var_207: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_206: int64))
let (var_208: (int64 ref)) = var_207.mem_0
let (var_209: Env6) = var_207.mem_1
let (var_210: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_211: (uint64 ref)) = var_209.mem_0
let (var_212: uint64) = method_5((var_211: (uint64 ref)))
let (var_213: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_212)
let (var_214: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_213)
let (var_215: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_214, 0uy, var_215, var_210)
let (var_216: int64) = 65536L
let (var_217: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_216: int64))
let (var_218: (int64 ref)) = var_217.mem_0
let (var_219: Env6) = var_217.mem_1
let (var_220: (uint64 ref)) = var_219.mem_0
let (var_221: uint64) = method_5((var_220: (uint64 ref)))
let (var_222: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_223: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_223)
let (var_224: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_221)
let (var_225: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_224)
var_43.GenerateNormal32(var_225, var_222, 0.000000f, 0.088388f)
let (var_226: int64) = 65536L
let (var_227: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_226: int64))
let (var_228: (int64 ref)) = var_227.mem_0
let (var_229: Env6) = var_227.mem_1
let (var_230: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_231: (uint64 ref)) = var_229.mem_0
let (var_232: uint64) = method_5((var_231: (uint64 ref)))
let (var_233: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_232)
let (var_234: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_233)
let (var_235: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_234, 0uy, var_235, var_230)
let (var_236: int64) = 512L
let (var_237: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_236: int64))
let (var_238: (int64 ref)) = var_237.mem_0
let (var_239: Env6) = var_237.mem_1
let (var_240: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_241: (uint64 ref)) = var_239.mem_0
let (var_242: uint64) = method_5((var_241: (uint64 ref)))
let (var_243: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_242)
let (var_244: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_243)
let (var_245: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_244, 0uy, var_245, var_240)
let (var_246: int64) = 512L
let (var_247: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_246: int64))
let (var_248: (int64 ref)) = var_247.mem_0
let (var_249: Env6) = var_247.mem_1
let (var_250: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_251: (uint64 ref)) = var_249.mem_0
let (var_252: uint64) = method_5((var_251: (uint64 ref)))
let (var_253: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_252)
let (var_254: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_253)
let (var_255: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_254, 0uy, var_255, var_250)
let (var_256: int64) = 512L
let (var_257: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_256: int64))
let (var_258: (int64 ref)) = var_257.mem_0
let (var_259: Env6) = var_257.mem_1
let (var_260: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_261: (uint64 ref)) = var_259.mem_0
let (var_262: uint64) = method_5((var_261: (uint64 ref)))
let (var_263: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_262)
let (var_264: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_263)
let (var_265: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_264, 0uy, var_265, var_260)
let (var_266: int64) = 512L
let (var_267: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_266: int64))
let (var_268: (int64 ref)) = var_267.mem_0
let (var_269: Env6) = var_267.mem_1
let (var_270: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_271: (uint64 ref)) = var_269.mem_0
let (var_272: uint64) = method_5((var_271: (uint64 ref)))
let (var_273: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_272)
let (var_274: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_273)
let (var_275: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_274, 0uy, var_275, var_270)
let (var_276: int64) = 512L
let (var_277: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_276: int64))
let (var_278: (int64 ref)) = var_277.mem_0
let (var_279: Env6) = var_277.mem_1
let (var_280: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_281: (uint64 ref)) = var_279.mem_0
let (var_282: uint64) = method_5((var_281: (uint64 ref)))
let (var_283: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_282)
let (var_284: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_283)
let (var_285: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_284, 0uy, var_285, var_280)
let (var_286: int64) = 512L
let (var_287: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_286: int64))
let (var_288: (int64 ref)) = var_287.mem_0
let (var_289: Env6) = var_287.mem_1
let (var_290: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_291: (uint64 ref)) = var_289.mem_0
let (var_292: uint64) = method_5((var_291: (uint64 ref)))
let (var_293: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_292)
let (var_294: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_293)
let (var_295: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_294, 0uy, var_295, var_290)
let (var_296: int64) = 65536L
let (var_297: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_296: int64))
let (var_298: (int64 ref)) = var_297.mem_0
let (var_299: Env6) = var_297.mem_1
let (var_300: (uint64 ref)) = var_299.mem_0
let (var_301: uint64) = method_5((var_300: (uint64 ref)))
let (var_302: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_303: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
var_43.SetStream(var_303)
let (var_304: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_301)
let (var_305: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_304)
var_43.GenerateNormal32(var_305, var_302, 0.000000f, 0.088388f)
let (var_306: int64) = 65536L
let (var_307: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_306: int64))
let (var_308: (int64 ref)) = var_307.mem_0
let (var_309: Env6) = var_307.mem_1
let (var_310: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_311: (uint64 ref)) = var_309.mem_0
let (var_312: uint64) = method_5((var_311: (uint64 ref)))
let (var_313: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_312)
let (var_314: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_313)
let (var_315: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_314, 0uy, var_315, var_310)
let (var_316: int64) = 512L
let (var_317: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_316: int64))
let (var_318: (int64 ref)) = var_317.mem_0
let (var_319: Env6) = var_317.mem_1
let (var_320: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_321: (uint64 ref)) = var_319.mem_0
let (var_322: uint64) = method_5((var_321: (uint64 ref)))
let (var_323: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_322)
let (var_324: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_323)
let (var_325: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_324, 0uy, var_325, var_320)
let (var_326: int64) = 512L
let (var_327: Env2) = method_11((var_102: EnvHeap7), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_326: int64))
let (var_328: (int64 ref)) = var_327.mem_0
let (var_329: Env6) = var_327.mem_1
let (var_330: ManagedCuda.BasicTypes.CUstream) = method_19((var_111: (bool ref)), (var_112: ManagedCuda.CudaStream))
let (var_331: (uint64 ref)) = var_329.mem_0
let (var_332: uint64) = method_5((var_331: (uint64 ref)))
let (var_333: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_332)
let (var_334: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_333)
let (var_335: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_334, 0uy, var_335, var_330)
let (var_336: int64) = 0L
method_20((var_104: (int64 ref)), (var_105: Env6), (var_288: (int64 ref)), (var_289: Env6), (var_278: (int64 ref)), (var_279: Env6), (var_248: (int64 ref)), (var_249: Env6), (var_238: (int64 ref)), (var_239: Env6), (var_268: (int64 ref)), (var_269: Env6), (var_258: (int64 ref)), (var_259: Env6), (var_168: (int64 ref)), (var_169: Env6), (var_158: (int64 ref)), (var_159: Env6), (var_128: (int64 ref)), (var_129: Env6), (var_118: (int64 ref)), (var_119: Env6), (var_148: (int64 ref)), (var_149: Env6), (var_138: (int64 ref)), (var_139: Env6), (var_228: (int64 ref)), (var_229: Env6), (var_218: (int64 ref)), (var_219: Env6), (var_188: (int64 ref)), (var_189: Env6), (var_178: (int64 ref)), (var_179: Env6), (var_208: (int64 ref)), (var_209: Env6), (var_198: (int64 ref)), (var_199: Env6), (var_328: (int64 ref)), (var_329: Env6), (var_318: (int64 ref)), (var_319: Env6), (var_308: (int64 ref)), (var_309: Env6), (var_298: (int64 ref)), (var_299: Env6), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_336: int64))
method_63((var_66: ResizeArray<Env3>))
method_53((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_337: uint64) = method_5((var_39: (uint64 ref)))
let (var_338: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_337)
let (var_339: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_338)
var_1.FreeMemory(var_339)
var_39 := 0UL
var_1.Dispose()

