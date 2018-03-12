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
    __global__ void method_55(float * var_0, float * var_1);
    __global__ void method_56(float * var_0, float * var_1);
    __global__ void method_49(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_60(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_24(long long int * var_0);
    __device__ char method_26(long long int * var_0);
    __device__ char method_31(long long int * var_0, float * var_1);
    __device__ char method_38(long long int * var_0, float * var_1);
    __device__ char method_39(long long int * var_0, float * var_1);
    __device__ char method_40(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_57(long long int * var_0);
    
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
    __global__ void method_55(float * var_0, float * var_1) {
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
    __global__ void method_56(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_57(var_6)) {
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
    __global__ void method_60(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
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
    __device__ char method_57(long long int * var_0) {
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
    val mem_0: Env7
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env7
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
and EnvStack5 =
    struct
    val mem_0: ManagedCuda.CudaBlas.CudaBlas
    val mem_1: ManagedCuda.CudaRand.CudaRandDevice
    val mem_2: (uint64 ref)
    val mem_3: uint64
    val mem_4: ResizeArray<Env0>
    val mem_5: ResizeArray<Env1>
    val mem_6: ManagedCuda.CudaContext
    val mem_7: ResizeArray<Env2>
    val mem_8: ResizeArray<Env3>
    val mem_9: ManagedCuda.BasicTypes.CUmodule
    val mem_10: (int64 ref)
    val mem_11: EnvHeap4
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4, arg_mem_5, arg_mem_6, arg_mem_7, arg_mem_8, arg_mem_9, arg_mem_10, arg_mem_11) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4; mem_5 = arg_mem_5; mem_6 = arg_mem_6; mem_7 = arg_mem_7; mem_8 = arg_mem_8; mem_9 = arg_mem_9; mem_10 = arg_mem_10; mem_11 = arg_mem_11}
    end
and Env6 =
    struct
    val mem_0: Env2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env7 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap8 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: ResizeArray<Env0>
    mem_3: ResizeArray<Env1>
    }
and EnvHeap9 =
    {
    mem_0: (int64 ref)
    mem_1: Env7
    mem_2: (int64 ref)
    mem_3: Env7
    mem_4: (int64 ref)
    mem_5: Env7
    mem_6: (int64 ref)
    mem_7: Env7
    mem_8: (int64 ref)
    mem_9: Env7
    mem_10: (int64 ref)
    mem_11: Env7
    mem_12: (int64 ref)
    mem_13: Env7
    mem_14: (int64 ref)
    mem_15: Env7
    mem_16: (int64 ref)
    mem_17: Env7
    mem_18: (int64 ref)
    mem_19: Env7
    mem_20: (int64 ref)
    mem_21: Env7
    mem_22: (int64 ref)
    mem_23: Env7
    mem_24: (int64 ref)
    mem_25: Env7
    mem_26: (int64 ref)
    mem_27: Env7
    mem_28: (int64 ref)
    mem_29: Env7
    mem_30: (int64 ref)
    mem_31: Env7
    mem_32: (int64 ref)
    mem_33: Env7
    mem_34: (int64 ref)
    mem_35: Env7
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: int64), (var_13: (uint8 [])), (var_14: int64), (var_15: int64)): Env6 =
    let (var_16: int64) = (var_12 * var_15)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: uint64) = (uint64 var_14)
    let (var_21: uint64) = (var_20 + var_19)
    let (var_22: EnvHeap8) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap8)
    let (var_23: Env2) = method_11((var_22: EnvHeap8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_16: int64))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env7) = var_23.mem_1
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
    (Env6((Env2(var_24, var_25))))
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_11((var_0: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: EnvHeap4), (var_13: int64)): Env2 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: ResizeArray<Env0>) = var_0.mem_2
    let (var_17: ResizeArray<Env1>) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env7) = method_12((var_16: ResizeArray<Env0>), (var_14: (uint64 ref)), (var_15: uint64), (var_17: ResizeArray<Env1>), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_15((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: ResizeArray<Env2>))
    (Env2(var_24, (Env7(var_23))))
and method_19((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: (int64 ref)), (var_13: Env7), (var_14: EnvHeap9), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: int64)): unit =
    let (var_24: bool) = (var_23 < 5L)
    if var_24 then
        let (var_25: int64) = 0L
        let (var_26: float) = 0.000000
        let (var_27: int64) = 0L
        let (var_28: float) = method_21((var_12: (int64 ref)), (var_13: Env7), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_25: int64), (var_26: float), (var_14: EnvHeap9), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_27: int64))
        let (var_29: string) = System.String.Format("Training: {0}",var_28)
        let (var_30: string) = System.String.Format("{0}",var_29)
        System.Console.WriteLine(var_30)
        if (System.Double.IsNaN var_28) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_31: int64) = (var_23 + 1L)
            method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: (int64 ref)), (var_13: Env7), (var_14: EnvHeap9), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_31: int64))
    else
        ()
and method_62((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_63
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_53((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_54
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env1)): bool =
    let (var_1: Env7) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: Env7) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env1) = var_1.[var_4]
        let (var_7: Env7) = var_6.mem_0
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
and method_12((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): Env7 =
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
            (Env1((Env7(var_14)), var_4))
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
                (Env1((Env7(var_24)), var_4))
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
                    (Env1((Env7(var_34)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_39: Env7) = var_38.mem_0
    let (var_40: uint64) = var_38.mem_1
    var_3.Add((Env1(var_39, var_40)))
    var_39
and method_15((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, (Env7(var_1)))))
and method_21((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: EnvHeap9), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_25: int64)): float =
    let (var_26: bool) = (var_25 < 271L)
    if var_26 then
        let (var_27: bool) = (var_25 >= 0L)
        let (var_28: bool) = (var_27 = false)
        if var_28 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_29: int64) = (var_25 * 524288L)
        if var_28 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_30: int64) = (524288L + var_29)
        let (var_31: EnvHeap8) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap8)
        let (var_32: (uint64 ref)) = var_31.mem_0
        let (var_33: uint64) = var_31.mem_1
        let (var_34: ResizeArray<Env0>) = var_31.mem_2
        let (var_35: ResizeArray<Env1>) = var_31.mem_3
        method_1((var_34: ResizeArray<Env0>), (var_32: (uint64 ref)), (var_33: uint64), (var_35: ResizeArray<Env1>))
        let (var_39: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_279: (int64 ref)) = var_16.mem_12
        let (var_280: Env7) = var_16.mem_13
        let (var_281: (int64 ref)) = var_16.mem_14
        let (var_282: Env7) = var_16.mem_15
        let (var_283: (int64 ref)) = var_16.mem_16
        let (var_284: Env7) = var_16.mem_17
        let (var_285: (int64 ref)) = var_16.mem_18
        let (var_286: Env7) = var_16.mem_19
        let (var_287: (int64 ref)) = var_16.mem_20
        let (var_288: Env7) = var_16.mem_21
        let (var_289: (int64 ref)) = var_16.mem_22
        let (var_290: Env7) = var_16.mem_23
        let (var_291: (int64 ref)) = var_16.mem_24
        let (var_292: Env7) = var_16.mem_25
        let (var_293: (int64 ref)) = var_16.mem_26
        let (var_294: Env7) = var_16.mem_27
        let (var_295: (int64 ref)) = var_16.mem_28
        let (var_296: Env7) = var_16.mem_29
        let (var_297: (int64 ref)) = var_16.mem_30
        let (var_298: Env7) = var_16.mem_31
        let (var_299: (int64 ref)) = var_16.mem_32
        let (var_300: Env7) = var_16.mem_33
        let (var_301: (int64 ref)) = var_16.mem_34
        let (var_302: Env7) = var_16.mem_35
        let (var_303: (int64 ref)) = var_16.mem_0
        let (var_304: Env7) = var_16.mem_1
        let (var_305: (int64 ref)) = var_16.mem_2
        let (var_306: Env7) = var_16.mem_3
        let (var_307: (int64 ref)) = var_16.mem_4
        let (var_308: Env7) = var_16.mem_5
        let (var_309: (int64 ref)) = var_16.mem_6
        let (var_310: Env7) = var_16.mem_7
        let (var_311: (int64 ref)) = var_16.mem_8
        let (var_312: Env7) = var_16.mem_9
        let (var_313: (int64 ref)) = var_16.mem_10
        let (var_314: Env7) = var_16.mem_11
        let (var_315: int64) = 32768L
        let (var_316: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_315: int64))
        let (var_317: (int64 ref)) = var_316.mem_0
        let (var_318: Env7) = var_316.mem_1
        method_22((var_285: (int64 ref)), (var_286: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_29: int64), (var_317: (int64 ref)), (var_318: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_319: int64) = 32768L
        let (var_320: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_319: int64))
        let (var_321: (int64 ref)) = var_320.mem_0
        let (var_322: Env7) = var_320.mem_1
        let (var_323: (bool ref)) = var_13.mem_0
        let (var_324: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_325: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_326: (uint64 ref)) = var_322.mem_0
        let (var_327: uint64) = method_5((var_326: (uint64 ref)))
        let (var_328: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_327)
        let (var_329: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_328)
        let (var_330: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_329, 0uy, var_330, var_325)
        let (var_331: (uint64 ref)) = var_310.mem_0
        let (var_332: uint64) = method_5((var_331: (uint64 ref)))
        let (var_333: (uint64 ref)) = var_318.mem_0
        let (var_334: uint64) = method_5((var_333: (uint64 ref)))
        let (var_335: uint64) = method_5((var_333: (uint64 ref)))
        // Cuda join point
        // method_23((var_332: uint64), (var_334: uint64), (var_335: uint64))
        let (var_336: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_337: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_336.set_GridDimensions(var_337)
        let (var_338: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_336.set_BlockDimensions(var_338)
        let (var_339: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_341: (System.Object [])) = [|var_332; var_334; var_335|]: (System.Object [])
        var_336.RunAsync(var_339, var_341)
        let (var_343: int64) = 32768L
        let (var_344: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_343: int64))
        let (var_345: (int64 ref)) = var_344.mem_0
        let (var_346: Env7) = var_344.mem_1
        let (var_347: uint64) = method_5((var_333: (uint64 ref)))
        let (var_348: (uint64 ref)) = var_346.mem_0
        let (var_349: uint64) = method_5((var_348: (uint64 ref)))
        // Cuda join point
        // method_25((var_347: uint64), (var_349: uint64))
        let (var_350: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_351: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_350.set_GridDimensions(var_351)
        let (var_352: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_350.set_BlockDimensions(var_352)
        let (var_353: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_355: (System.Object [])) = [|var_347; var_349|]: (System.Object [])
        var_350.RunAsync(var_353, var_355)
        let (var_356: int64) = 32768L
        let (var_357: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_356: int64))
        let (var_358: (int64 ref)) = var_357.mem_0
        let (var_359: Env7) = var_357.mem_1
        let (var_360: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_361: (uint64 ref)) = var_359.mem_0
        let (var_362: uint64) = method_5((var_361: (uint64 ref)))
        let (var_363: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_362)
        let (var_364: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_363)
        let (var_365: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_364, 0uy, var_365, var_360)
        let (var_366: int64) = 32768L
        let (var_367: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_366: int64))
        let (var_368: (int64 ref)) = var_367.mem_0
        let (var_369: Env7) = var_367.mem_1
        method_22((var_289: (int64 ref)), (var_290: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_29: int64), (var_368: (int64 ref)), (var_369: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_370: int64) = 32768L
        let (var_371: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_370: int64))
        let (var_372: (int64 ref)) = var_371.mem_0
        let (var_373: Env7) = var_371.mem_1
        let (var_374: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_375: (uint64 ref)) = var_373.mem_0
        let (var_376: uint64) = method_5((var_375: (uint64 ref)))
        let (var_377: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_376)
        let (var_378: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_377)
        let (var_379: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_378, 0uy, var_379, var_374)
        let (var_380: (uint64 ref)) = var_314.mem_0
        let (var_381: uint64) = method_5((var_380: (uint64 ref)))
        let (var_382: (uint64 ref)) = var_369.mem_0
        let (var_383: uint64) = method_5((var_382: (uint64 ref)))
        let (var_384: uint64) = method_5((var_382: (uint64 ref)))
        // Cuda join point
        // method_23((var_381: uint64), (var_383: uint64), (var_384: uint64))
        let (var_385: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_386: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_385.set_GridDimensions(var_386)
        let (var_387: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_385.set_BlockDimensions(var_387)
        let (var_388: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_390: (System.Object [])) = [|var_381; var_383; var_384|]: (System.Object [])
        var_385.RunAsync(var_388, var_390)
        let (var_395: int64) = 32768L
        let (var_396: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_395: int64))
        let (var_397: (int64 ref)) = var_396.mem_0
        let (var_398: Env7) = var_396.mem_1
        let (var_399: uint64) = method_5((var_382: (uint64 ref)))
        let (var_400: (uint64 ref)) = var_398.mem_0
        let (var_401: uint64) = method_5((var_400: (uint64 ref)))
        // Cuda join point
        // method_27((var_399: uint64), (var_401: uint64))
        let (var_402: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_403: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_402.set_GridDimensions(var_403)
        let (var_404: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_402.set_BlockDimensions(var_404)
        let (var_405: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_407: (System.Object [])) = [|var_399; var_401|]: (System.Object [])
        var_402.RunAsync(var_405, var_407)
        let (var_408: int64) = 32768L
        let (var_409: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_408: int64))
        let (var_410: (int64 ref)) = var_409.mem_0
        let (var_411: Env7) = var_409.mem_1
        let (var_412: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_413: (uint64 ref)) = var_411.mem_0
        let (var_414: uint64) = method_5((var_413: (uint64 ref)))
        let (var_415: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_414)
        let (var_416: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_415)
        let (var_417: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_416, 0uy, var_417, var_412)
        let (var_419: int64) = 32768L
        let (var_420: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_419: int64))
        let (var_421: (int64 ref)) = var_420.mem_0
        let (var_422: Env7) = var_420.mem_1
        let (var_423: uint64) = method_5((var_348: (uint64 ref)))
        let (var_424: uint64) = method_5((var_400: (uint64 ref)))
        let (var_425: (uint64 ref)) = var_422.mem_0
        let (var_426: uint64) = method_5((var_425: (uint64 ref)))
        // Cuda join point
        // method_28((var_423: uint64), (var_424: uint64), (var_426: uint64))
        let (var_427: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_428: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_427.set_GridDimensions(var_428)
        let (var_429: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_427.set_BlockDimensions(var_429)
        let (var_430: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_432: (System.Object [])) = [|var_423; var_424; var_426|]: (System.Object [])
        var_427.RunAsync(var_430, var_432)
        let (var_433: int64) = 32768L
        let (var_434: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_433: int64))
        let (var_435: (int64 ref)) = var_434.mem_0
        let (var_436: Env7) = var_434.mem_1
        let (var_437: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_438: (uint64 ref)) = var_436.mem_0
        let (var_439: uint64) = method_5((var_438: (uint64 ref)))
        let (var_440: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_439)
        let (var_441: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_440)
        let (var_442: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_441, 0uy, var_442, var_437)
        let (var_443: int64) = 32768L
        let (var_444: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_443: int64))
        let (var_445: (int64 ref)) = var_444.mem_0
        let (var_446: Env7) = var_444.mem_1
        method_29((var_23: (int64 ref)), (var_24: Env7), (var_421: (int64 ref)), (var_422: Env7), (var_445: (int64 ref)), (var_446: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_447: int64) = 32768L
        let (var_448: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_447: int64))
        let (var_449: (int64 ref)) = var_448.mem_0
        let (var_450: Env7) = var_448.mem_1
        let (var_451: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_452: (uint64 ref)) = var_450.mem_0
        let (var_453: uint64) = method_5((var_452: (uint64 ref)))
        let (var_454: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_453)
        let (var_455: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_454)
        let (var_456: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_455, 0uy, var_456, var_451)
        let (var_457: (uint64 ref)) = var_20.mem_0
        let (var_458: uint64) = method_5((var_457: (uint64 ref)))
        let (var_459: (uint64 ref)) = var_446.mem_0
        let (var_460: uint64) = method_5((var_459: (uint64 ref)))
        let (var_461: uint64) = method_5((var_459: (uint64 ref)))
        // Cuda join point
        // method_23((var_458: uint64), (var_460: uint64), (var_461: uint64))
        let (var_462: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_463: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_462.set_GridDimensions(var_463)
        let (var_464: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_462.set_BlockDimensions(var_464)
        let (var_465: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_467: (System.Object [])) = [|var_458; var_460; var_461|]: (System.Object [])
        var_462.RunAsync(var_465, var_467)
        let (var_472: int64) = 32768L
        let (var_473: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_472: int64))
        let (var_474: (int64 ref)) = var_473.mem_0
        let (var_475: Env7) = var_473.mem_1
        let (var_476: uint64) = method_5((var_459: (uint64 ref)))
        let (var_477: (uint64 ref)) = var_475.mem_0
        let (var_478: uint64) = method_5((var_477: (uint64 ref)))
        // Cuda join point
        // method_27((var_476: uint64), (var_478: uint64))
        let (var_479: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_480: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_479.set_GridDimensions(var_480)
        let (var_481: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_479.set_BlockDimensions(var_481)
        let (var_482: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_484: (System.Object [])) = [|var_476; var_478|]: (System.Object [])
        var_479.RunAsync(var_482, var_484)
        let (var_485: int64) = 32768L
        let (var_486: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_485: int64))
        let (var_487: (int64 ref)) = var_486.mem_0
        let (var_488: Env7) = var_486.mem_1
        let (var_489: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_490: (uint64 ref)) = var_488.mem_0
        let (var_491: uint64) = method_5((var_490: (uint64 ref)))
        let (var_492: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_491)
        let (var_493: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_492)
        let (var_494: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_493, 0uy, var_494, var_489)
        let (var_495: uint64) = method_5((var_477: (uint64 ref)))
        let (var_496: (uint64 ref)) = var_1.mem_0
        let (var_497: uint64) = method_5((var_496: (uint64 ref)))
        let (var_498: int64) = (var_30 * 4L)
        let (var_499: uint64) = (uint64 var_498)
        let (var_500: uint64) = (var_497 + var_499)
        let (var_504: int64) = 4L
        let (var_505: Env2) = method_11((var_31: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_504: int64))
        let (var_506: (int64 ref)) = var_505.mem_0
        let (var_507: Env7) = var_505.mem_1
        let (var_508: (uint64 ref)) = var_507.mem_0
        let (var_509: uint64) = method_5((var_508: (uint64 ref)))
        // Cuda join point
        // method_30((var_495: uint64), (var_500: uint64), (var_509: uint64))
        let (var_510: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_11, var_8)
        let (var_511: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_510.set_GridDimensions(var_511)
        let (var_512: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_510.set_BlockDimensions(var_512)
        let (var_513: ManagedCuda.BasicTypes.CUstream) = method_19((var_323: (bool ref)), (var_324: ManagedCuda.CudaStream))
        let (var_515: (System.Object [])) = [|var_495; var_500; var_509|]: (System.Object [])
        var_510.RunAsync(var_513, var_515)
        let (var_516: (unit -> unit)) = method_32((var_321: (int64 ref)), (var_322: Env7), (var_317: (int64 ref)), (var_318: Env7), (var_307: (int64 ref)), (var_308: Env7), (var_309: (int64 ref)), (var_310: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_29: int64), (var_283: (int64 ref)), (var_284: Env7), (var_285: (int64 ref)), (var_286: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_358: (int64 ref)), (var_359: Env7), (var_345: (int64 ref)), (var_346: Env7), (var_372: (int64 ref)), (var_373: Env7), (var_368: (int64 ref)), (var_369: Env7), (var_311: (int64 ref)), (var_312: Env7), (var_313: (int64 ref)), (var_314: Env7), (var_287: (int64 ref)), (var_288: Env7), (var_289: (int64 ref)), (var_290: Env7), (var_410: (int64 ref)), (var_411: Env7), (var_397: (int64 ref)), (var_398: Env7), (var_435: (int64 ref)), (var_436: Env7), (var_421: (int64 ref)), (var_422: Env7), (var_449: (int64 ref)), (var_450: Env7), (var_445: (int64 ref)), (var_446: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_487: (int64 ref)), (var_488: Env7), (var_474: (int64 ref)), (var_475: Env7), (var_506: (int64 ref)), (var_507: Env7), (var_30: int64))
        let (var_517: (unit -> float32)) = method_44((var_506: (int64 ref)), (var_507: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_819: int64) = 1L
        method_51((var_0: (int64 ref)), (var_1: Env7), (var_29: int64), (var_30: int64), (var_16: EnvHeap9), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_39: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_25: int64), (var_9: ResizeArray<Env2>), (var_517: (unit -> float32)), (var_516: (unit -> unit)), (var_435: (int64 ref)), (var_436: Env7), (var_421: (int64 ref)), (var_422: Env7), (var_819: int64))
    else
        let (var_821: float) = (float var_14)
        (var_15 / var_821)
and method_63 ((var_0: Env3)): unit =
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
    let (var_2: Env7) = var_0.mem_1
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
    let (var_2: Env7) = var_0.mem_0
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
and method_22((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: int64), (var_5: (int64 ref)), (var_6: Env7), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: EnvHeap4)): unit =
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
and method_29((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_32 ((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_13: (int64 ref)), (var_14: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4), (var_27: (int64 ref)), (var_28: Env7), (var_29: (int64 ref)), (var_30: Env7), (var_31: (int64 ref)), (var_32: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_35: (int64 ref)), (var_36: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_39: (int64 ref)), (var_40: Env7), (var_41: (int64 ref)), (var_42: Env7), (var_43: (int64 ref)), (var_44: Env7), (var_45: (int64 ref)), (var_46: Env7), (var_47: (int64 ref)), (var_48: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_51: (int64 ref)), (var_52: Env7), (var_53: (int64 ref)), (var_54: Env7), (var_55: (int64 ref)), (var_56: Env7), (var_57: (int64 ref)), (var_58: Env7), (var_59: (int64 ref)), (var_60: Env7), (var_61: (int64 ref)), (var_62: Env7), (var_63: (int64 ref)), (var_64: Env7), (var_65: (int64 ref)), (var_66: Env7), (var_67: (int64 ref)), (var_68: Env7), (var_69: int64)) (): unit =
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
    method_35((var_61: (int64 ref)), (var_62: Env7), (var_51: (int64 ref)), (var_52: Env7), (var_47: (int64 ref)), (var_48: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    method_36((var_51: (int64 ref)), (var_52: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_59: (int64 ref)), (var_60: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
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
    method_42((var_31: (int64 ref)), (var_32: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_39: (int64 ref)), (var_40: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
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
    method_42((var_0: (int64 ref)), (var_1: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
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
and method_44 ((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4)) (): float32 =
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_45((var_14: int64), (var_0: (int64 ref)), (var_1: Env7), (var_15: int64))
    var_16.[int32 0L]
and method_51((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_25: int64), (var_26: float), (var_27: int64), (var_28: ResizeArray<Env2>), (var_29: (unit -> float32)), (var_30: (unit -> unit)), (var_31: (int64 ref)), (var_32: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_35: int64)): float =
    let (var_36: bool) = (var_35 < 64L)
    if var_36 then
        let (var_37: bool) = (var_35 >= 0L)
        let (var_38: bool) = (var_37 = false)
        if var_38 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_39: int64) = (var_35 * 8192L)
        let (var_40: int64) = (var_2 + var_39)
        if var_38 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_41: int64) = (var_3 + var_39)
        let (var_42: (int64 ref)) = var_4.mem_12
        let (var_43: Env7) = var_4.mem_13
        let (var_44: (int64 ref)) = var_4.mem_14
        let (var_45: Env7) = var_4.mem_15
        let (var_46: (int64 ref)) = var_4.mem_16
        let (var_47: Env7) = var_4.mem_17
        let (var_48: (int64 ref)) = var_4.mem_18
        let (var_49: Env7) = var_4.mem_19
        let (var_50: (int64 ref)) = var_4.mem_20
        let (var_51: Env7) = var_4.mem_21
        let (var_52: (int64 ref)) = var_4.mem_22
        let (var_53: Env7) = var_4.mem_23
        let (var_54: (int64 ref)) = var_4.mem_24
        let (var_55: Env7) = var_4.mem_25
        let (var_56: (int64 ref)) = var_4.mem_26
        let (var_57: Env7) = var_4.mem_27
        let (var_58: (int64 ref)) = var_4.mem_28
        let (var_59: Env7) = var_4.mem_29
        let (var_60: (int64 ref)) = var_4.mem_30
        let (var_61: Env7) = var_4.mem_31
        let (var_62: (int64 ref)) = var_4.mem_32
        let (var_63: Env7) = var_4.mem_33
        let (var_64: (int64 ref)) = var_4.mem_34
        let (var_65: Env7) = var_4.mem_35
        let (var_66: (int64 ref)) = var_4.mem_0
        let (var_67: Env7) = var_4.mem_1
        let (var_68: (int64 ref)) = var_4.mem_2
        let (var_69: Env7) = var_4.mem_3
        let (var_70: (int64 ref)) = var_4.mem_4
        let (var_71: Env7) = var_4.mem_5
        let (var_72: (int64 ref)) = var_4.mem_6
        let (var_73: Env7) = var_4.mem_7
        let (var_74: (int64 ref)) = var_4.mem_8
        let (var_75: Env7) = var_4.mem_9
        let (var_76: (int64 ref)) = var_4.mem_10
        let (var_77: Env7) = var_4.mem_11
        let (var_78: int64) = 32768L
        let (var_79: EnvHeap8) = ({mem_0 = (var_15: (uint64 ref)); mem_1 = (var_16: uint64); mem_2 = (var_17: ResizeArray<Env0>); mem_3 = (var_18: ResizeArray<Env1>)} : EnvHeap8)
        let (var_80: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_78: int64))
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: Env7) = var_80.mem_1
        method_22((var_48: (int64 ref)), (var_49: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_40: int64), (var_81: (int64 ref)), (var_82: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_83: int64) = 32768L
        let (var_84: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_83: int64))
        let (var_85: (int64 ref)) = var_84.mem_0
        let (var_86: Env7) = var_84.mem_1
        let (var_87: (bool ref)) = var_24.mem_0
        let (var_88: ManagedCuda.CudaStream) = var_24.mem_1
        let (var_89: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_90: (uint64 ref)) = var_86.mem_0
        let (var_91: uint64) = method_5((var_90: (uint64 ref)))
        let (var_92: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_91)
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_92)
        let (var_94: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_93, 0uy, var_94, var_89)
        method_46((var_60: (int64 ref)), (var_61: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_81: (int64 ref)), (var_82: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_95: (uint64 ref)) = var_73.mem_0
        let (var_96: uint64) = method_5((var_95: (uint64 ref)))
        let (var_97: (uint64 ref)) = var_82.mem_0
        let (var_98: uint64) = method_5((var_97: (uint64 ref)))
        let (var_99: uint64) = method_5((var_97: (uint64 ref)))
        // Cuda join point
        // method_23((var_96: uint64), (var_98: uint64), (var_99: uint64))
        let (var_100: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_100.set_GridDimensions(var_101)
        let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_100.set_BlockDimensions(var_102)
        let (var_103: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_105: (System.Object [])) = [|var_96; var_98; var_99|]: (System.Object [])
        var_100.RunAsync(var_103, var_105)
        let (var_107: int64) = 32768L
        let (var_108: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_107: int64))
        let (var_109: (int64 ref)) = var_108.mem_0
        let (var_110: Env7) = var_108.mem_1
        let (var_111: uint64) = method_5((var_97: (uint64 ref)))
        let (var_112: (uint64 ref)) = var_110.mem_0
        let (var_113: uint64) = method_5((var_112: (uint64 ref)))
        // Cuda join point
        // method_25((var_111: uint64), (var_113: uint64))
        let (var_114: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_22, var_19)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_114.set_GridDimensions(var_115)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_114.set_BlockDimensions(var_116)
        let (var_117: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_119: (System.Object [])) = [|var_111; var_113|]: (System.Object [])
        var_114.RunAsync(var_117, var_119)
        let (var_120: int64) = 32768L
        let (var_121: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_120: int64))
        let (var_122: (int64 ref)) = var_121.mem_0
        let (var_123: Env7) = var_121.mem_1
        let (var_124: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_125: (uint64 ref)) = var_123.mem_0
        let (var_126: uint64) = method_5((var_125: (uint64 ref)))
        let (var_127: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_126)
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_127)
        let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_128, 0uy, var_129, var_124)
        let (var_130: int64) = 32768L
        let (var_131: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_130: int64))
        let (var_132: (int64 ref)) = var_131.mem_0
        let (var_133: Env7) = var_131.mem_1
        method_22((var_52: (int64 ref)), (var_53: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_40: int64), (var_132: (int64 ref)), (var_133: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_134: int64) = 32768L
        let (var_135: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_134: int64))
        let (var_136: (int64 ref)) = var_135.mem_0
        let (var_137: Env7) = var_135.mem_1
        let (var_138: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_139: (uint64 ref)) = var_137.mem_0
        let (var_140: uint64) = method_5((var_139: (uint64 ref)))
        let (var_141: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_140)
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_141)
        let (var_143: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_142, 0uy, var_143, var_138)
        method_46((var_64: (int64 ref)), (var_65: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_132: (int64 ref)), (var_133: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_144: (uint64 ref)) = var_77.mem_0
        let (var_145: uint64) = method_5((var_144: (uint64 ref)))
        let (var_146: (uint64 ref)) = var_133.mem_0
        let (var_147: uint64) = method_5((var_146: (uint64 ref)))
        let (var_148: uint64) = method_5((var_146: (uint64 ref)))
        // Cuda join point
        // method_23((var_145: uint64), (var_147: uint64), (var_148: uint64))
        let (var_149: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_149.set_GridDimensions(var_150)
        let (var_151: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_149.set_BlockDimensions(var_151)
        let (var_152: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_154: (System.Object [])) = [|var_145; var_147; var_148|]: (System.Object [])
        var_149.RunAsync(var_152, var_154)
        let (var_159: int64) = 32768L
        let (var_160: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_159: int64))
        let (var_161: (int64 ref)) = var_160.mem_0
        let (var_162: Env7) = var_160.mem_1
        let (var_163: uint64) = method_5((var_146: (uint64 ref)))
        let (var_164: (uint64 ref)) = var_162.mem_0
        let (var_165: uint64) = method_5((var_164: (uint64 ref)))
        // Cuda join point
        // method_27((var_163: uint64), (var_165: uint64))
        let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_166.set_GridDimensions(var_167)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_166.set_BlockDimensions(var_168)
        let (var_169: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_171: (System.Object [])) = [|var_163; var_165|]: (System.Object [])
        var_166.RunAsync(var_169, var_171)
        let (var_172: int64) = 32768L
        let (var_173: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_172: int64))
        let (var_174: (int64 ref)) = var_173.mem_0
        let (var_175: Env7) = var_173.mem_1
        let (var_176: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_177: (uint64 ref)) = var_175.mem_0
        let (var_178: uint64) = method_5((var_177: (uint64 ref)))
        let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_178)
        let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_179)
        let (var_181: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_180, 0uy, var_181, var_176)
        let (var_182: int64) = 32768L
        let (var_183: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_182: int64))
        let (var_184: (int64 ref)) = var_183.mem_0
        let (var_185: Env7) = var_183.mem_1
        method_22((var_44: (int64 ref)), (var_45: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_40: int64), (var_184: (int64 ref)), (var_185: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_186: int64) = 32768L
        let (var_187: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_186: int64))
        let (var_188: (int64 ref)) = var_187.mem_0
        let (var_189: Env7) = var_187.mem_1
        let (var_190: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_191: (uint64 ref)) = var_189.mem_0
        let (var_192: uint64) = method_5((var_191: (uint64 ref)))
        let (var_193: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_192)
        let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_193)
        let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_194, 0uy, var_195, var_190)
        method_46((var_56: (int64 ref)), (var_57: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_184: (int64 ref)), (var_185: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_196: (uint64 ref)) = var_69.mem_0
        let (var_197: uint64) = method_5((var_196: (uint64 ref)))
        let (var_198: (uint64 ref)) = var_185.mem_0
        let (var_199: uint64) = method_5((var_198: (uint64 ref)))
        let (var_200: uint64) = method_5((var_198: (uint64 ref)))
        // Cuda join point
        // method_23((var_197: uint64), (var_199: uint64), (var_200: uint64))
        let (var_201: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_201.set_GridDimensions(var_202)
        let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_201.set_BlockDimensions(var_203)
        let (var_204: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_206: (System.Object [])) = [|var_197; var_199; var_200|]: (System.Object [])
        var_201.RunAsync(var_204, var_206)
        let (var_211: int64) = 32768L
        let (var_212: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_211: int64))
        let (var_213: (int64 ref)) = var_212.mem_0
        let (var_214: Env7) = var_212.mem_1
        let (var_215: uint64) = method_5((var_198: (uint64 ref)))
        let (var_216: (uint64 ref)) = var_214.mem_0
        let (var_217: uint64) = method_5((var_216: (uint64 ref)))
        // Cuda join point
        // method_27((var_215: uint64), (var_217: uint64))
        let (var_218: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_219: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_218.set_GridDimensions(var_219)
        let (var_220: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_218.set_BlockDimensions(var_220)
        let (var_221: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_223: (System.Object [])) = [|var_215; var_217|]: (System.Object [])
        var_218.RunAsync(var_221, var_223)
        let (var_224: int64) = 32768L
        let (var_225: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_224: int64))
        let (var_226: (int64 ref)) = var_225.mem_0
        let (var_227: Env7) = var_225.mem_1
        let (var_228: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_229: (uint64 ref)) = var_227.mem_0
        let (var_230: uint64) = method_5((var_229: (uint64 ref)))
        let (var_231: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_230)
        let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_231)
        let (var_233: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_232, 0uy, var_233, var_228)
        let (var_235: int64) = 32768L
        let (var_236: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_235: int64))
        let (var_237: (int64 ref)) = var_236.mem_0
        let (var_238: Env7) = var_236.mem_1
        let (var_239: uint64) = method_5((var_112: (uint64 ref)))
        let (var_240: uint64) = method_5((var_164: (uint64 ref)))
        let (var_241: (uint64 ref)) = var_238.mem_0
        let (var_242: uint64) = method_5((var_241: (uint64 ref)))
        // Cuda join point
        // method_28((var_239: uint64), (var_240: uint64), (var_242: uint64))
        let (var_243: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_22, var_19)
        let (var_244: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_243.set_GridDimensions(var_244)
        let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_243.set_BlockDimensions(var_245)
        let (var_246: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_248: (System.Object [])) = [|var_239; var_240; var_242|]: (System.Object [])
        var_243.RunAsync(var_246, var_248)
        let (var_249: int64) = 32768L
        let (var_250: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_249: int64))
        let (var_251: (int64 ref)) = var_250.mem_0
        let (var_252: Env7) = var_250.mem_1
        let (var_253: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_254: (uint64 ref)) = var_252.mem_0
        let (var_255: uint64) = method_5((var_254: (uint64 ref)))
        let (var_256: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_255)
        let (var_257: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_256)
        let (var_258: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_257, 0uy, var_258, var_253)
        let (var_260: int64) = 32768L
        let (var_261: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_260: int64))
        let (var_262: (int64 ref)) = var_261.mem_0
        let (var_263: Env7) = var_261.mem_1
        let (var_264: (uint64 ref)) = var_34.mem_0
        let (var_265: uint64) = method_5((var_264: (uint64 ref)))
        let (var_266: uint64) = method_5((var_216: (uint64 ref)))
        let (var_267: (uint64 ref)) = var_263.mem_0
        let (var_268: uint64) = method_5((var_267: (uint64 ref)))
        // Cuda join point
        // method_28((var_265: uint64), (var_266: uint64), (var_268: uint64))
        let (var_269: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_22, var_19)
        let (var_270: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_269.set_GridDimensions(var_270)
        let (var_271: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_269.set_BlockDimensions(var_271)
        let (var_272: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_274: (System.Object [])) = [|var_265; var_266; var_268|]: (System.Object [])
        var_269.RunAsync(var_272, var_274)
        let (var_275: int64) = 32768L
        let (var_276: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_275: int64))
        let (var_277: (int64 ref)) = var_276.mem_0
        let (var_278: Env7) = var_276.mem_1
        let (var_279: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_280: (uint64 ref)) = var_278.mem_0
        let (var_281: uint64) = method_5((var_280: (uint64 ref)))
        let (var_282: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_281)
        let (var_283: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_282)
        let (var_284: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_283, 0uy, var_284, var_279)
        let (var_286: int64) = 32768L
        let (var_287: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_286: int64))
        let (var_288: (int64 ref)) = var_287.mem_0
        let (var_289: Env7) = var_287.mem_1
        let (var_290: uint64) = method_5((var_241: (uint64 ref)))
        let (var_291: uint64) = method_5((var_267: (uint64 ref)))
        let (var_292: (uint64 ref)) = var_289.mem_0
        let (var_293: uint64) = method_5((var_292: (uint64 ref)))
        // Cuda join point
        // method_47((var_290: uint64), (var_291: uint64), (var_293: uint64))
        let (var_294: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_22, var_19)
        let (var_295: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_294.set_GridDimensions(var_295)
        let (var_296: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_294.set_BlockDimensions(var_296)
        let (var_297: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_299: (System.Object [])) = [|var_290; var_291; var_293|]: (System.Object [])
        var_294.RunAsync(var_297, var_299)
        let (var_300: int64) = 32768L
        let (var_301: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_300: int64))
        let (var_302: (int64 ref)) = var_301.mem_0
        let (var_303: Env7) = var_301.mem_1
        let (var_304: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_305: (uint64 ref)) = var_303.mem_0
        let (var_306: uint64) = method_5((var_305: (uint64 ref)))
        let (var_307: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_306)
        let (var_308: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_307)
        let (var_309: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_308, 0uy, var_309, var_304)
        let (var_310: int64) = 32768L
        let (var_311: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_310: int64))
        let (var_312: (int64 ref)) = var_311.mem_0
        let (var_313: Env7) = var_311.mem_1
        method_29((var_11: (int64 ref)), (var_12: Env7), (var_288: (int64 ref)), (var_289: Env7), (var_312: (int64 ref)), (var_313: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_314: int64) = 32768L
        let (var_315: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_314: int64))
        let (var_316: (int64 ref)) = var_315.mem_0
        let (var_317: Env7) = var_315.mem_1
        let (var_318: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_319: (uint64 ref)) = var_317.mem_0
        let (var_320: uint64) = method_5((var_319: (uint64 ref)))
        let (var_321: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_320)
        let (var_322: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_321)
        let (var_323: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_322, 0uy, var_323, var_318)
        let (var_324: (uint64 ref)) = var_8.mem_0
        let (var_325: uint64) = method_5((var_324: (uint64 ref)))
        let (var_326: (uint64 ref)) = var_313.mem_0
        let (var_327: uint64) = method_5((var_326: (uint64 ref)))
        let (var_328: uint64) = method_5((var_326: (uint64 ref)))
        // Cuda join point
        // method_23((var_325: uint64), (var_327: uint64), (var_328: uint64))
        let (var_329: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_330: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_329.set_GridDimensions(var_330)
        let (var_331: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_329.set_BlockDimensions(var_331)
        let (var_332: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_334: (System.Object [])) = [|var_325; var_327; var_328|]: (System.Object [])
        var_329.RunAsync(var_332, var_334)
        let (var_339: int64) = 32768L
        let (var_340: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_339: int64))
        let (var_341: (int64 ref)) = var_340.mem_0
        let (var_342: Env7) = var_340.mem_1
        let (var_343: uint64) = method_5((var_326: (uint64 ref)))
        let (var_344: (uint64 ref)) = var_342.mem_0
        let (var_345: uint64) = method_5((var_344: (uint64 ref)))
        // Cuda join point
        // method_27((var_343: uint64), (var_345: uint64))
        let (var_346: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_347: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_346.set_GridDimensions(var_347)
        let (var_348: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_346.set_BlockDimensions(var_348)
        let (var_349: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_351: (System.Object [])) = [|var_343; var_345|]: (System.Object [])
        var_346.RunAsync(var_349, var_351)
        let (var_352: int64) = 32768L
        let (var_353: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_352: int64))
        let (var_354: (int64 ref)) = var_353.mem_0
        let (var_355: Env7) = var_353.mem_1
        let (var_356: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_357: (uint64 ref)) = var_355.mem_0
        let (var_358: uint64) = method_5((var_357: (uint64 ref)))
        let (var_359: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_358)
        let (var_360: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_359)
        let (var_361: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_360, 0uy, var_361, var_356)
        let (var_362: uint64) = method_5((var_344: (uint64 ref)))
        let (var_363: (uint64 ref)) = var_1.mem_0
        let (var_364: uint64) = method_5((var_363: (uint64 ref)))
        let (var_365: int64) = (var_41 * 4L)
        let (var_366: uint64) = (uint64 var_365)
        let (var_367: uint64) = (var_364 + var_366)
        let (var_371: int64) = 4L
        let (var_372: Env2) = method_11((var_79: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_371: int64))
        let (var_373: (int64 ref)) = var_372.mem_0
        let (var_374: Env7) = var_372.mem_1
        let (var_375: (uint64 ref)) = var_374.mem_0
        let (var_376: uint64) = method_5((var_375: (uint64 ref)))
        // Cuda join point
        // method_30((var_362: uint64), (var_367: uint64), (var_376: uint64))
        let (var_377: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_22, var_19)
        let (var_378: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_377.set_GridDimensions(var_378)
        let (var_379: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_377.set_BlockDimensions(var_379)
        let (var_380: ManagedCuda.BasicTypes.CUstream) = method_19((var_87: (bool ref)), (var_88: ManagedCuda.CudaStream))
        let (var_382: (System.Object [])) = [|var_362; var_367; var_376|]: (System.Object [])
        var_377.RunAsync(var_380, var_382)
        let (var_383: (unit -> unit)) = method_48((var_30: (unit -> unit)), (var_85: (int64 ref)), (var_86: Env7), (var_81: (int64 ref)), (var_82: Env7), (var_70: (int64 ref)), (var_71: Env7), (var_72: (int64 ref)), (var_73: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_40: int64), (var_46: (int64 ref)), (var_47: Env7), (var_48: (int64 ref)), (var_49: Env7), (var_31: (int64 ref)), (var_32: Env7), (var_33: (int64 ref)), (var_34: Env7), (var_58: (int64 ref)), (var_59: Env7), (var_60: (int64 ref)), (var_61: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_122: (int64 ref)), (var_123: Env7), (var_109: (int64 ref)), (var_110: Env7), (var_136: (int64 ref)), (var_137: Env7), (var_132: (int64 ref)), (var_133: Env7), (var_74: (int64 ref)), (var_75: Env7), (var_76: (int64 ref)), (var_77: Env7), (var_50: (int64 ref)), (var_51: Env7), (var_52: (int64 ref)), (var_53: Env7), (var_62: (int64 ref)), (var_63: Env7), (var_64: (int64 ref)), (var_65: Env7), (var_174: (int64 ref)), (var_175: Env7), (var_161: (int64 ref)), (var_162: Env7), (var_188: (int64 ref)), (var_189: Env7), (var_184: (int64 ref)), (var_185: Env7), (var_66: (int64 ref)), (var_67: Env7), (var_68: (int64 ref)), (var_69: Env7), (var_42: (int64 ref)), (var_43: Env7), (var_44: (int64 ref)), (var_45: Env7), (var_54: (int64 ref)), (var_55: Env7), (var_56: (int64 ref)), (var_57: Env7), (var_226: (int64 ref)), (var_227: Env7), (var_213: (int64 ref)), (var_214: Env7), (var_251: (int64 ref)), (var_252: Env7), (var_237: (int64 ref)), (var_238: Env7), (var_277: (int64 ref)), (var_278: Env7), (var_262: (int64 ref)), (var_263: Env7), (var_302: (int64 ref)), (var_303: Env7), (var_288: (int64 ref)), (var_289: Env7), (var_316: (int64 ref)), (var_317: Env7), (var_312: (int64 ref)), (var_313: Env7), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_354: (int64 ref)), (var_355: Env7), (var_341: (int64 ref)), (var_342: Env7), (var_373: (int64 ref)), (var_374: Env7), (var_41: int64))
        let (var_384: (unit -> float32)) = method_50((var_373: (int64 ref)), (var_374: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_29: (unit -> float32)))
        let (var_385: int64) = (var_35 + 1L)
        method_51((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_25: int64), (var_26: float), (var_27: int64), (var_28: ResizeArray<Env2>), (var_384: (unit -> float32)), (var_383: (unit -> unit)), (var_302: (int64 ref)), (var_303: Env7), (var_288: (int64 ref)), (var_289: Env7), (var_385: int64))
    else
        let (var_387: float32) = var_29()
        let (var_388: float) = (float var_387)
        let (var_389: float) = (var_26 + var_388)
        let (var_398: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_52((var_33: (int64 ref)), (var_34: Env7), (var_398: ResizeArray<Env2>))
        let (var_399: int64) = (var_25 + 1L)
        if (System.Double.IsNaN var_389) then
            method_53((var_20: ResizeArray<Env2>))
            // Done with the net...
            method_53((var_20: ResizeArray<Env2>))
            let (var_400: float) = (float var_399)
            (var_389 / var_400)
        else
            var_30()
            let (var_402: (int64 ref)) = var_4.mem_0
            let (var_403: Env7) = var_4.mem_1
            let (var_404: (int64 ref)) = var_4.mem_2
            let (var_405: Env7) = var_4.mem_3
            let (var_406: (int64 ref)) = var_4.mem_4
            let (var_407: Env7) = var_4.mem_5
            let (var_408: (int64 ref)) = var_4.mem_6
            let (var_409: Env7) = var_4.mem_7
            let (var_410: (int64 ref)) = var_4.mem_8
            let (var_411: Env7) = var_4.mem_9
            let (var_412: (int64 ref)) = var_4.mem_10
            let (var_413: Env7) = var_4.mem_11
            let (var_414: (int64 ref)) = var_4.mem_12
            let (var_415: Env7) = var_4.mem_13
            let (var_416: (int64 ref)) = var_4.mem_14
            let (var_417: Env7) = var_4.mem_15
            let (var_418: (int64 ref)) = var_4.mem_16
            let (var_419: Env7) = var_4.mem_17
            let (var_420: (int64 ref)) = var_4.mem_18
            let (var_421: Env7) = var_4.mem_19
            let (var_422: (int64 ref)) = var_4.mem_20
            let (var_423: Env7) = var_4.mem_21
            let (var_424: (int64 ref)) = var_4.mem_22
            let (var_425: Env7) = var_4.mem_23
            let (var_426: (int64 ref)) = var_4.mem_24
            let (var_427: Env7) = var_4.mem_25
            let (var_428: (int64 ref)) = var_4.mem_26
            let (var_429: Env7) = var_4.mem_27
            let (var_430: (int64 ref)) = var_4.mem_28
            let (var_431: Env7) = var_4.mem_29
            let (var_432: (int64 ref)) = var_4.mem_30
            let (var_433: Env7) = var_4.mem_31
            let (var_434: (int64 ref)) = var_4.mem_32
            let (var_435: Env7) = var_4.mem_33
            let (var_436: (int64 ref)) = var_4.mem_34
            let (var_437: Env7) = var_4.mem_35
            let (var_438: (uint64 ref)) = var_405.mem_0
            let (var_439: uint64) = method_5((var_438: (uint64 ref)))
            let (var_440: (uint64 ref)) = var_403.mem_0
            let (var_441: uint64) = method_5((var_440: (uint64 ref)))
            // Cuda join point
            // method_55((var_439: uint64), (var_441: uint64))
            let (var_442: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_443: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_442.set_GridDimensions(var_443)
            let (var_444: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_442.set_BlockDimensions(var_444)
            let (var_445: (bool ref)) = var_24.mem_0
            let (var_446: ManagedCuda.CudaStream) = var_24.mem_1
            let (var_447: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_449: (System.Object [])) = [|var_439; var_441|]: (System.Object [])
            var_442.RunAsync(var_447, var_449)
            let (var_450: (uint64 ref)) = var_409.mem_0
            let (var_451: uint64) = method_5((var_450: (uint64 ref)))
            let (var_452: (uint64 ref)) = var_407.mem_0
            let (var_453: uint64) = method_5((var_452: (uint64 ref)))
            // Cuda join point
            // method_55((var_451: uint64), (var_453: uint64))
            let (var_454: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_455: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_454.set_GridDimensions(var_455)
            let (var_456: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_454.set_BlockDimensions(var_456)
            let (var_457: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_459: (System.Object [])) = [|var_451; var_453|]: (System.Object [])
            var_454.RunAsync(var_457, var_459)
            let (var_460: (uint64 ref)) = var_413.mem_0
            let (var_461: uint64) = method_5((var_460: (uint64 ref)))
            let (var_462: (uint64 ref)) = var_411.mem_0
            let (var_463: uint64) = method_5((var_462: (uint64 ref)))
            // Cuda join point
            // method_55((var_461: uint64), (var_463: uint64))
            let (var_464: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_465: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_464.set_GridDimensions(var_465)
            let (var_466: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_464.set_BlockDimensions(var_466)
            let (var_467: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_469: (System.Object [])) = [|var_461; var_463|]: (System.Object [])
            var_464.RunAsync(var_467, var_469)
            let (var_470: (uint64 ref)) = var_417.mem_0
            let (var_471: uint64) = method_5((var_470: (uint64 ref)))
            let (var_472: (uint64 ref)) = var_415.mem_0
            let (var_473: uint64) = method_5((var_472: (uint64 ref)))
            // Cuda join point
            // method_56((var_471: uint64), (var_473: uint64))
            let (var_474: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_475: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_474.set_GridDimensions(var_475)
            let (var_476: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_474.set_BlockDimensions(var_476)
            let (var_477: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_479: (System.Object [])) = [|var_471; var_473|]: (System.Object [])
            var_474.RunAsync(var_477, var_479)
            let (var_480: (uint64 ref)) = var_421.mem_0
            let (var_481: uint64) = method_5((var_480: (uint64 ref)))
            let (var_482: (uint64 ref)) = var_419.mem_0
            let (var_483: uint64) = method_5((var_482: (uint64 ref)))
            // Cuda join point
            // method_56((var_481: uint64), (var_483: uint64))
            let (var_484: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_485: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_484.set_GridDimensions(var_485)
            let (var_486: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_484.set_BlockDimensions(var_486)
            let (var_487: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_489: (System.Object [])) = [|var_481; var_483|]: (System.Object [])
            var_484.RunAsync(var_487, var_489)
            let (var_490: (uint64 ref)) = var_425.mem_0
            let (var_491: uint64) = method_5((var_490: (uint64 ref)))
            let (var_492: (uint64 ref)) = var_423.mem_0
            let (var_493: uint64) = method_5((var_492: (uint64 ref)))
            // Cuda join point
            // method_56((var_491: uint64), (var_493: uint64))
            let (var_494: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_495: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_494.set_GridDimensions(var_495)
            let (var_496: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_494.set_BlockDimensions(var_496)
            let (var_497: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_499: (System.Object [])) = [|var_491; var_493|]: (System.Object [])
            var_494.RunAsync(var_497, var_499)
            let (var_500: (uint64 ref)) = var_429.mem_0
            let (var_501: uint64) = method_5((var_500: (uint64 ref)))
            let (var_502: (uint64 ref)) = var_427.mem_0
            let (var_503: uint64) = method_5((var_502: (uint64 ref)))
            // Cuda join point
            // method_56((var_501: uint64), (var_503: uint64))
            let (var_504: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_505: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_504.set_GridDimensions(var_505)
            let (var_506: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_504.set_BlockDimensions(var_506)
            let (var_507: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_509: (System.Object [])) = [|var_501; var_503|]: (System.Object [])
            var_504.RunAsync(var_507, var_509)
            let (var_510: (uint64 ref)) = var_433.mem_0
            let (var_511: uint64) = method_5((var_510: (uint64 ref)))
            let (var_512: (uint64 ref)) = var_431.mem_0
            let (var_513: uint64) = method_5((var_512: (uint64 ref)))
            // Cuda join point
            // method_56((var_511: uint64), (var_513: uint64))
            let (var_514: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_515: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_514.set_GridDimensions(var_515)
            let (var_516: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_514.set_BlockDimensions(var_516)
            let (var_517: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_519: (System.Object [])) = [|var_511; var_513|]: (System.Object [])
            var_514.RunAsync(var_517, var_519)
            let (var_520: (uint64 ref)) = var_437.mem_0
            let (var_521: uint64) = method_5((var_520: (uint64 ref)))
            let (var_522: (uint64 ref)) = var_435.mem_0
            let (var_523: uint64) = method_5((var_522: (uint64 ref)))
            // Cuda join point
            // method_56((var_521: uint64), (var_523: uint64))
            let (var_524: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_525: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_524.set_GridDimensions(var_525)
            let (var_526: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_524.set_BlockDimensions(var_526)
            let (var_527: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_529: (System.Object [])) = [|var_521; var_523|]: (System.Object [])
            var_524.RunAsync(var_527, var_529)
            let (var_530: (uint64 ref)) = var_8.mem_0
            let (var_531: uint64) = method_5((var_530: (uint64 ref)))
            let (var_532: (uint64 ref)) = var_6.mem_0
            let (var_533: uint64) = method_5((var_532: (uint64 ref)))
            // Cuda join point
            // method_55((var_531: uint64), (var_533: uint64))
            let (var_534: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_535: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_534.set_GridDimensions(var_535)
            let (var_536: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_534.set_BlockDimensions(var_536)
            let (var_537: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_539: (System.Object [])) = [|var_531; var_533|]: (System.Object [])
            var_534.RunAsync(var_537, var_539)
            let (var_540: (uint64 ref)) = var_12.mem_0
            let (var_541: uint64) = method_5((var_540: (uint64 ref)))
            let (var_542: (uint64 ref)) = var_10.mem_0
            let (var_543: uint64) = method_5((var_542: (uint64 ref)))
            // Cuda join point
            // method_56((var_541: uint64), (var_543: uint64))
            let (var_544: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_545: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_544.set_GridDimensions(var_545)
            let (var_546: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_544.set_BlockDimensions(var_546)
            let (var_547: ManagedCuda.BasicTypes.CUstream) = method_19((var_445: (bool ref)), (var_446: ManagedCuda.CudaStream))
            let (var_549: (System.Object [])) = [|var_541; var_543|]: (System.Object [])
            var_544.RunAsync(var_547, var_549)
            method_53((var_20: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_550: int64) = (var_27 + 1L)
            method_58((var_0: (int64 ref)), (var_1: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_399: int64), (var_389: float), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_20: ResizeArray<Env2>), (var_33: (int64 ref)), (var_34: Env7), (var_550: int64))
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
and method_35((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_36((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_42((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: int64), (var_5: (int64 ref)), (var_6: Env7), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: EnvHeap4)): unit =
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
and method_45((var_0: int64), (var_1: (int64 ref)), (var_2: Env7), (var_3: int64)): (float32 []) =
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
and method_46((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_48 ((var_0: (unit -> unit)), (var_1: (int64 ref)), (var_2: Env7), (var_3: (int64 ref)), (var_4: Env7), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4), (var_36: (int64 ref)), (var_37: Env7), (var_38: (int64 ref)), (var_39: Env7), (var_40: (int64 ref)), (var_41: Env7), (var_42: (int64 ref)), (var_43: Env7), (var_44: (int64 ref)), (var_45: Env7), (var_46: (int64 ref)), (var_47: Env7), (var_48: (int64 ref)), (var_49: Env7), (var_50: (int64 ref)), (var_51: Env7), (var_52: (int64 ref)), (var_53: Env7), (var_54: (int64 ref)), (var_55: Env7), (var_56: (int64 ref)), (var_57: Env7), (var_58: (int64 ref)), (var_59: Env7), (var_60: (int64 ref)), (var_61: Env7), (var_62: (int64 ref)), (var_63: Env7), (var_64: (int64 ref)), (var_65: Env7), (var_66: (int64 ref)), (var_67: Env7), (var_68: (int64 ref)), (var_69: Env7), (var_70: (int64 ref)), (var_71: Env7), (var_72: (int64 ref)), (var_73: Env7), (var_74: (int64 ref)), (var_75: Env7), (var_76: (int64 ref)), (var_77: Env7), (var_78: (int64 ref)), (var_79: Env7), (var_80: (int64 ref)), (var_81: Env7), (var_82: (int64 ref)), (var_83: Env7), (var_84: (int64 ref)), (var_85: Env7), (var_86: (int64 ref)), (var_87: Env7), (var_88: (int64 ref)), (var_89: Env7), (var_90: (int64 ref)), (var_91: Env7), (var_92: (int64 ref)), (var_93: Env7), (var_94: (int64 ref)), (var_95: Env7), (var_96: (int64 ref)), (var_97: Env7), (var_98: (int64 ref)), (var_99: Env7), (var_100: (int64 ref)), (var_101: Env7), (var_102: (int64 ref)), (var_103: Env7), (var_104: (int64 ref)), (var_105: Env7), (var_106: (int64 ref)), (var_107: Env7), (var_108: (int64 ref)), (var_109: Env7), (var_110: int64)) (): unit =
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
    method_35((var_102: (int64 ref)), (var_103: Env7), (var_92: (int64 ref)), (var_93: Env7), (var_88: (int64 ref)), (var_89: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_92: (int64 ref)), (var_93: Env7), (var_90: (int64 ref)), (var_91: Env7), (var_100: (int64 ref)), (var_101: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
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
    method_42((var_60: (int64 ref)), (var_61: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_68: (int64 ref)), (var_69: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_74: (int64 ref)), (var_75: Env7), (var_60: (int64 ref)), (var_61: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_60: (int64 ref)), (var_61: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_72: (int64 ref)), (var_73: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
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
    method_42((var_40: (int64 ref)), (var_41: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_48: (int64 ref)), (var_49: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_54: (int64 ref)), (var_55: Env7), (var_40: (int64 ref)), (var_41: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_40: (int64 ref)), (var_41: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_52: (int64 ref)), (var_53: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
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
    method_42((var_1: (int64 ref)), (var_2: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_12: (int64 ref)), (var_13: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_35((var_22: (int64 ref)), (var_23: Env7), (var_1: (int64 ref)), (var_2: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_36((var_1: (int64 ref)), (var_2: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
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
and method_50 ((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: (unit -> float32))) (): float32 =
    let (var_15: float32) = var_14()
    let (var_16: int64) = 1L
    let (var_17: int64) = 0L
    let (var_18: (float32 [])) = method_45((var_16: int64), (var_0: (int64 ref)), (var_1: Env7), (var_17: int64))
    let (var_19: float32) = var_18.[int32 0L]
    (var_15 + var_19)
and method_52((var_0: (int64 ref)), (var_1: Env7), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, var_1)))
and method_58((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: EnvHeap9), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_25: ResizeArray<Env2>), (var_26: (int64 ref)), (var_27: Env7), (var_28: int64)): float =
    let (var_29: bool) = (var_28 < 271L)
    if var_29 then
        let (var_30: bool) = (var_28 >= 0L)
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_32: int64) = (var_28 * 524288L)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_33: int64) = (524288L + var_32)
        let (var_34: EnvHeap8) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap8)
        let (var_35: (uint64 ref)) = var_34.mem_0
        let (var_36: uint64) = var_34.mem_1
        let (var_37: ResizeArray<Env0>) = var_34.mem_2
        let (var_38: ResizeArray<Env1>) = var_34.mem_3
        method_1((var_37: ResizeArray<Env0>), (var_35: (uint64 ref)), (var_36: uint64), (var_38: ResizeArray<Env1>))
        let (var_42: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_385: (int64 ref)) = var_16.mem_12
        let (var_386: Env7) = var_16.mem_13
        let (var_387: (int64 ref)) = var_16.mem_14
        let (var_388: Env7) = var_16.mem_15
        let (var_389: (int64 ref)) = var_16.mem_16
        let (var_390: Env7) = var_16.mem_17
        let (var_391: (int64 ref)) = var_16.mem_18
        let (var_392: Env7) = var_16.mem_19
        let (var_393: (int64 ref)) = var_16.mem_20
        let (var_394: Env7) = var_16.mem_21
        let (var_395: (int64 ref)) = var_16.mem_22
        let (var_396: Env7) = var_16.mem_23
        let (var_397: (int64 ref)) = var_16.mem_24
        let (var_398: Env7) = var_16.mem_25
        let (var_399: (int64 ref)) = var_16.mem_26
        let (var_400: Env7) = var_16.mem_27
        let (var_401: (int64 ref)) = var_16.mem_28
        let (var_402: Env7) = var_16.mem_29
        let (var_403: (int64 ref)) = var_16.mem_30
        let (var_404: Env7) = var_16.mem_31
        let (var_405: (int64 ref)) = var_16.mem_32
        let (var_406: Env7) = var_16.mem_33
        let (var_407: (int64 ref)) = var_16.mem_34
        let (var_408: Env7) = var_16.mem_35
        let (var_409: (int64 ref)) = var_16.mem_0
        let (var_410: Env7) = var_16.mem_1
        let (var_411: (int64 ref)) = var_16.mem_2
        let (var_412: Env7) = var_16.mem_3
        let (var_413: (int64 ref)) = var_16.mem_4
        let (var_414: Env7) = var_16.mem_5
        let (var_415: (int64 ref)) = var_16.mem_6
        let (var_416: Env7) = var_16.mem_7
        let (var_417: (int64 ref)) = var_16.mem_8
        let (var_418: Env7) = var_16.mem_9
        let (var_419: (int64 ref)) = var_16.mem_10
        let (var_420: Env7) = var_16.mem_11
        let (var_421: int64) = 32768L
        let (var_422: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_421: int64))
        let (var_423: (int64 ref)) = var_422.mem_0
        let (var_424: Env7) = var_422.mem_1
        method_22((var_391: (int64 ref)), (var_392: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_423: (int64 ref)), (var_424: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_425: int64) = 32768L
        let (var_426: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_425: int64))
        let (var_427: (int64 ref)) = var_426.mem_0
        let (var_428: Env7) = var_426.mem_1
        let (var_429: (bool ref)) = var_13.mem_0
        let (var_430: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_431: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_432: (uint64 ref)) = var_428.mem_0
        let (var_433: uint64) = method_5((var_432: (uint64 ref)))
        let (var_434: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_433)
        let (var_435: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_434)
        let (var_436: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_435, 0uy, var_436, var_431)
        method_46((var_403: (int64 ref)), (var_404: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_423: (int64 ref)), (var_424: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_437: (uint64 ref)) = var_416.mem_0
        let (var_438: uint64) = method_5((var_437: (uint64 ref)))
        let (var_439: (uint64 ref)) = var_424.mem_0
        let (var_440: uint64) = method_5((var_439: (uint64 ref)))
        let (var_441: uint64) = method_5((var_439: (uint64 ref)))
        // Cuda join point
        // method_23((var_438: uint64), (var_440: uint64), (var_441: uint64))
        let (var_442: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_443: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_442.set_GridDimensions(var_443)
        let (var_444: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_442.set_BlockDimensions(var_444)
        let (var_445: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_447: (System.Object [])) = [|var_438; var_440; var_441|]: (System.Object [])
        var_442.RunAsync(var_445, var_447)
        let (var_449: int64) = 32768L
        let (var_450: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_449: int64))
        let (var_451: (int64 ref)) = var_450.mem_0
        let (var_452: Env7) = var_450.mem_1
        let (var_453: uint64) = method_5((var_439: (uint64 ref)))
        let (var_454: (uint64 ref)) = var_452.mem_0
        let (var_455: uint64) = method_5((var_454: (uint64 ref)))
        // Cuda join point
        // method_25((var_453: uint64), (var_455: uint64))
        let (var_456: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_457: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_456.set_GridDimensions(var_457)
        let (var_458: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_456.set_BlockDimensions(var_458)
        let (var_459: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_461: (System.Object [])) = [|var_453; var_455|]: (System.Object [])
        var_456.RunAsync(var_459, var_461)
        let (var_462: int64) = 32768L
        let (var_463: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_462: int64))
        let (var_464: (int64 ref)) = var_463.mem_0
        let (var_465: Env7) = var_463.mem_1
        let (var_466: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_467: (uint64 ref)) = var_465.mem_0
        let (var_468: uint64) = method_5((var_467: (uint64 ref)))
        let (var_469: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_468)
        let (var_470: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_469)
        let (var_471: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_470, 0uy, var_471, var_466)
        let (var_472: int64) = 32768L
        let (var_473: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_472: int64))
        let (var_474: (int64 ref)) = var_473.mem_0
        let (var_475: Env7) = var_473.mem_1
        method_22((var_395: (int64 ref)), (var_396: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_474: (int64 ref)), (var_475: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_476: int64) = 32768L
        let (var_477: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_476: int64))
        let (var_478: (int64 ref)) = var_477.mem_0
        let (var_479: Env7) = var_477.mem_1
        let (var_480: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_481: (uint64 ref)) = var_479.mem_0
        let (var_482: uint64) = method_5((var_481: (uint64 ref)))
        let (var_483: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_482)
        let (var_484: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_483)
        let (var_485: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_484, 0uy, var_485, var_480)
        method_46((var_407: (int64 ref)), (var_408: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_474: (int64 ref)), (var_475: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_486: (uint64 ref)) = var_420.mem_0
        let (var_487: uint64) = method_5((var_486: (uint64 ref)))
        let (var_488: (uint64 ref)) = var_475.mem_0
        let (var_489: uint64) = method_5((var_488: (uint64 ref)))
        let (var_490: uint64) = method_5((var_488: (uint64 ref)))
        // Cuda join point
        // method_23((var_487: uint64), (var_489: uint64), (var_490: uint64))
        let (var_491: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_492: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_491.set_GridDimensions(var_492)
        let (var_493: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_491.set_BlockDimensions(var_493)
        let (var_494: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_496: (System.Object [])) = [|var_487; var_489; var_490|]: (System.Object [])
        var_491.RunAsync(var_494, var_496)
        let (var_501: int64) = 32768L
        let (var_502: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_501: int64))
        let (var_503: (int64 ref)) = var_502.mem_0
        let (var_504: Env7) = var_502.mem_1
        let (var_505: uint64) = method_5((var_488: (uint64 ref)))
        let (var_506: (uint64 ref)) = var_504.mem_0
        let (var_507: uint64) = method_5((var_506: (uint64 ref)))
        // Cuda join point
        // method_27((var_505: uint64), (var_507: uint64))
        let (var_508: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_509: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_508.set_GridDimensions(var_509)
        let (var_510: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_508.set_BlockDimensions(var_510)
        let (var_511: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_513: (System.Object [])) = [|var_505; var_507|]: (System.Object [])
        var_508.RunAsync(var_511, var_513)
        let (var_514: int64) = 32768L
        let (var_515: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_514: int64))
        let (var_516: (int64 ref)) = var_515.mem_0
        let (var_517: Env7) = var_515.mem_1
        let (var_518: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_519: (uint64 ref)) = var_517.mem_0
        let (var_520: uint64) = method_5((var_519: (uint64 ref)))
        let (var_521: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_520)
        let (var_522: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_521)
        let (var_523: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_522, 0uy, var_523, var_518)
        let (var_524: int64) = 32768L
        let (var_525: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_524: int64))
        let (var_526: (int64 ref)) = var_525.mem_0
        let (var_527: Env7) = var_525.mem_1
        method_22((var_387: (int64 ref)), (var_388: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_526: (int64 ref)), (var_527: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_528: int64) = 32768L
        let (var_529: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_528: int64))
        let (var_530: (int64 ref)) = var_529.mem_0
        let (var_531: Env7) = var_529.mem_1
        let (var_532: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_533: (uint64 ref)) = var_531.mem_0
        let (var_534: uint64) = method_5((var_533: (uint64 ref)))
        let (var_535: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_534)
        let (var_536: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_535)
        let (var_537: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_536, 0uy, var_537, var_532)
        method_46((var_399: (int64 ref)), (var_400: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_526: (int64 ref)), (var_527: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_538: (uint64 ref)) = var_412.mem_0
        let (var_539: uint64) = method_5((var_538: (uint64 ref)))
        let (var_540: (uint64 ref)) = var_527.mem_0
        let (var_541: uint64) = method_5((var_540: (uint64 ref)))
        let (var_542: uint64) = method_5((var_540: (uint64 ref)))
        // Cuda join point
        // method_23((var_539: uint64), (var_541: uint64), (var_542: uint64))
        let (var_543: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_544: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_543.set_GridDimensions(var_544)
        let (var_545: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_543.set_BlockDimensions(var_545)
        let (var_546: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_548: (System.Object [])) = [|var_539; var_541; var_542|]: (System.Object [])
        var_543.RunAsync(var_546, var_548)
        let (var_553: int64) = 32768L
        let (var_554: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_553: int64))
        let (var_555: (int64 ref)) = var_554.mem_0
        let (var_556: Env7) = var_554.mem_1
        let (var_557: uint64) = method_5((var_540: (uint64 ref)))
        let (var_558: (uint64 ref)) = var_556.mem_0
        let (var_559: uint64) = method_5((var_558: (uint64 ref)))
        // Cuda join point
        // method_27((var_557: uint64), (var_559: uint64))
        let (var_560: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_561: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_560.set_GridDimensions(var_561)
        let (var_562: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_560.set_BlockDimensions(var_562)
        let (var_563: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_565: (System.Object [])) = [|var_557; var_559|]: (System.Object [])
        var_560.RunAsync(var_563, var_565)
        let (var_566: int64) = 32768L
        let (var_567: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_566: int64))
        let (var_568: (int64 ref)) = var_567.mem_0
        let (var_569: Env7) = var_567.mem_1
        let (var_570: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_571: (uint64 ref)) = var_569.mem_0
        let (var_572: uint64) = method_5((var_571: (uint64 ref)))
        let (var_573: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_572)
        let (var_574: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_573)
        let (var_575: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_574, 0uy, var_575, var_570)
        let (var_577: int64) = 32768L
        let (var_578: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_577: int64))
        let (var_579: (int64 ref)) = var_578.mem_0
        let (var_580: Env7) = var_578.mem_1
        let (var_581: uint64) = method_5((var_454: (uint64 ref)))
        let (var_582: uint64) = method_5((var_506: (uint64 ref)))
        let (var_583: (uint64 ref)) = var_580.mem_0
        let (var_584: uint64) = method_5((var_583: (uint64 ref)))
        // Cuda join point
        // method_28((var_581: uint64), (var_582: uint64), (var_584: uint64))
        let (var_585: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_586: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_585.set_GridDimensions(var_586)
        let (var_587: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_585.set_BlockDimensions(var_587)
        let (var_588: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_590: (System.Object [])) = [|var_581; var_582; var_584|]: (System.Object [])
        var_585.RunAsync(var_588, var_590)
        let (var_591: int64) = 32768L
        let (var_592: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_591: int64))
        let (var_593: (int64 ref)) = var_592.mem_0
        let (var_594: Env7) = var_592.mem_1
        let (var_595: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_596: (uint64 ref)) = var_594.mem_0
        let (var_597: uint64) = method_5((var_596: (uint64 ref)))
        let (var_598: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_597)
        let (var_599: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_598)
        let (var_600: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_599, 0uy, var_600, var_595)
        let (var_602: int64) = 32768L
        let (var_603: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_602: int64))
        let (var_604: (int64 ref)) = var_603.mem_0
        let (var_605: Env7) = var_603.mem_1
        let (var_606: (uint64 ref)) = var_27.mem_0
        let (var_607: uint64) = method_5((var_606: (uint64 ref)))
        let (var_608: uint64) = method_5((var_558: (uint64 ref)))
        let (var_609: (uint64 ref)) = var_605.mem_0
        let (var_610: uint64) = method_5((var_609: (uint64 ref)))
        // Cuda join point
        // method_28((var_607: uint64), (var_608: uint64), (var_610: uint64))
        let (var_611: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_11, var_8)
        let (var_612: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_611.set_GridDimensions(var_612)
        let (var_613: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_611.set_BlockDimensions(var_613)
        let (var_614: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_616: (System.Object [])) = [|var_607; var_608; var_610|]: (System.Object [])
        var_611.RunAsync(var_614, var_616)
        let (var_617: int64) = 32768L
        let (var_618: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_617: int64))
        let (var_619: (int64 ref)) = var_618.mem_0
        let (var_620: Env7) = var_618.mem_1
        let (var_621: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_622: (uint64 ref)) = var_620.mem_0
        let (var_623: uint64) = method_5((var_622: (uint64 ref)))
        let (var_624: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_623)
        let (var_625: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_624)
        let (var_626: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_625, 0uy, var_626, var_621)
        let (var_628: int64) = 32768L
        let (var_629: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_628: int64))
        let (var_630: (int64 ref)) = var_629.mem_0
        let (var_631: Env7) = var_629.mem_1
        let (var_632: uint64) = method_5((var_583: (uint64 ref)))
        let (var_633: uint64) = method_5((var_609: (uint64 ref)))
        let (var_634: (uint64 ref)) = var_631.mem_0
        let (var_635: uint64) = method_5((var_634: (uint64 ref)))
        // Cuda join point
        // method_47((var_632: uint64), (var_633: uint64), (var_635: uint64))
        let (var_636: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_11, var_8)
        let (var_637: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_636.set_GridDimensions(var_637)
        let (var_638: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_636.set_BlockDimensions(var_638)
        let (var_639: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_641: (System.Object [])) = [|var_632; var_633; var_635|]: (System.Object [])
        var_636.RunAsync(var_639, var_641)
        let (var_642: int64) = 32768L
        let (var_643: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_642: int64))
        let (var_644: (int64 ref)) = var_643.mem_0
        let (var_645: Env7) = var_643.mem_1
        let (var_646: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_647: (uint64 ref)) = var_645.mem_0
        let (var_648: uint64) = method_5((var_647: (uint64 ref)))
        let (var_649: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_648)
        let (var_650: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_649)
        let (var_651: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_650, 0uy, var_651, var_646)
        let (var_652: int64) = 32768L
        let (var_653: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_652: int64))
        let (var_654: (int64 ref)) = var_653.mem_0
        let (var_655: Env7) = var_653.mem_1
        method_29((var_23: (int64 ref)), (var_24: Env7), (var_630: (int64 ref)), (var_631: Env7), (var_654: (int64 ref)), (var_655: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_656: int64) = 32768L
        let (var_657: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_656: int64))
        let (var_658: (int64 ref)) = var_657.mem_0
        let (var_659: Env7) = var_657.mem_1
        let (var_660: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_661: (uint64 ref)) = var_659.mem_0
        let (var_662: uint64) = method_5((var_661: (uint64 ref)))
        let (var_663: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_662)
        let (var_664: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_663)
        let (var_665: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_664, 0uy, var_665, var_660)
        let (var_666: (uint64 ref)) = var_20.mem_0
        let (var_667: uint64) = method_5((var_666: (uint64 ref)))
        let (var_668: (uint64 ref)) = var_655.mem_0
        let (var_669: uint64) = method_5((var_668: (uint64 ref)))
        let (var_670: uint64) = method_5((var_668: (uint64 ref)))
        // Cuda join point
        // method_23((var_667: uint64), (var_669: uint64), (var_670: uint64))
        let (var_671: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_672: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_671.set_GridDimensions(var_672)
        let (var_673: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_671.set_BlockDimensions(var_673)
        let (var_674: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_676: (System.Object [])) = [|var_667; var_669; var_670|]: (System.Object [])
        var_671.RunAsync(var_674, var_676)
        let (var_681: int64) = 32768L
        let (var_682: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_681: int64))
        let (var_683: (int64 ref)) = var_682.mem_0
        let (var_684: Env7) = var_682.mem_1
        let (var_685: uint64) = method_5((var_668: (uint64 ref)))
        let (var_686: (uint64 ref)) = var_684.mem_0
        let (var_687: uint64) = method_5((var_686: (uint64 ref)))
        // Cuda join point
        // method_27((var_685: uint64), (var_687: uint64))
        let (var_688: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_689: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_688.set_GridDimensions(var_689)
        let (var_690: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_688.set_BlockDimensions(var_690)
        let (var_691: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_693: (System.Object [])) = [|var_685; var_687|]: (System.Object [])
        var_688.RunAsync(var_691, var_693)
        let (var_694: int64) = 32768L
        let (var_695: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_694: int64))
        let (var_696: (int64 ref)) = var_695.mem_0
        let (var_697: Env7) = var_695.mem_1
        let (var_698: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_699: (uint64 ref)) = var_697.mem_0
        let (var_700: uint64) = method_5((var_699: (uint64 ref)))
        let (var_701: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_700)
        let (var_702: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_701)
        let (var_703: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_702, 0uy, var_703, var_698)
        let (var_704: uint64) = method_5((var_686: (uint64 ref)))
        let (var_705: (uint64 ref)) = var_1.mem_0
        let (var_706: uint64) = method_5((var_705: (uint64 ref)))
        let (var_707: int64) = (var_33 * 4L)
        let (var_708: uint64) = (uint64 var_707)
        let (var_709: uint64) = (var_706 + var_708)
        let (var_713: int64) = 4L
        let (var_714: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_713: int64))
        let (var_715: (int64 ref)) = var_714.mem_0
        let (var_716: Env7) = var_714.mem_1
        let (var_717: (uint64 ref)) = var_716.mem_0
        let (var_718: uint64) = method_5((var_717: (uint64 ref)))
        // Cuda join point
        // method_30((var_704: uint64), (var_709: uint64), (var_718: uint64))
        let (var_719: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_11, var_8)
        let (var_720: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_719.set_GridDimensions(var_720)
        let (var_721: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_719.set_BlockDimensions(var_721)
        let (var_722: ManagedCuda.BasicTypes.CUstream) = method_19((var_429: (bool ref)), (var_430: ManagedCuda.CudaStream))
        let (var_724: (System.Object [])) = [|var_704; var_709; var_718|]: (System.Object [])
        var_719.RunAsync(var_722, var_724)
        let (var_725: (unit -> unit)) = method_59((var_427: (int64 ref)), (var_428: Env7), (var_423: (int64 ref)), (var_424: Env7), (var_413: (int64 ref)), (var_414: Env7), (var_415: (int64 ref)), (var_416: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_389: (int64 ref)), (var_390: Env7), (var_391: (int64 ref)), (var_392: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_401: (int64 ref)), (var_402: Env7), (var_403: (int64 ref)), (var_404: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_464: (int64 ref)), (var_465: Env7), (var_451: (int64 ref)), (var_452: Env7), (var_478: (int64 ref)), (var_479: Env7), (var_474: (int64 ref)), (var_475: Env7), (var_417: (int64 ref)), (var_418: Env7), (var_419: (int64 ref)), (var_420: Env7), (var_393: (int64 ref)), (var_394: Env7), (var_395: (int64 ref)), (var_396: Env7), (var_405: (int64 ref)), (var_406: Env7), (var_407: (int64 ref)), (var_408: Env7), (var_516: (int64 ref)), (var_517: Env7), (var_503: (int64 ref)), (var_504: Env7), (var_530: (int64 ref)), (var_531: Env7), (var_526: (int64 ref)), (var_527: Env7), (var_409: (int64 ref)), (var_410: Env7), (var_411: (int64 ref)), (var_412: Env7), (var_385: (int64 ref)), (var_386: Env7), (var_387: (int64 ref)), (var_388: Env7), (var_397: (int64 ref)), (var_398: Env7), (var_399: (int64 ref)), (var_400: Env7), (var_568: (int64 ref)), (var_569: Env7), (var_555: (int64 ref)), (var_556: Env7), (var_593: (int64 ref)), (var_594: Env7), (var_579: (int64 ref)), (var_580: Env7), (var_619: (int64 ref)), (var_620: Env7), (var_604: (int64 ref)), (var_605: Env7), (var_644: (int64 ref)), (var_645: Env7), (var_630: (int64 ref)), (var_631: Env7), (var_658: (int64 ref)), (var_659: Env7), (var_654: (int64 ref)), (var_655: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_696: (int64 ref)), (var_697: Env7), (var_683: (int64 ref)), (var_684: Env7), (var_715: (int64 ref)), (var_716: Env7), (var_33: int64))
        let (var_726: (unit -> float32)) = method_44((var_715: (int64 ref)), (var_716: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_1027: int64) = 1L
        method_61((var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_33: int64), (var_16: EnvHeap9), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: (int64 ref)), (var_22: Env7), (var_23: (int64 ref)), (var_24: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_28: int64), (var_9: ResizeArray<Env2>), (var_25: ResizeArray<Env2>), (var_726: (unit -> float32)), (var_725: (unit -> unit)), (var_644: (int64 ref)), (var_645: Env7), (var_630: (int64 ref)), (var_631: Env7), (var_1027: int64))
    else
        method_53((var_25: ResizeArray<Env2>))
        let (var_1029: float) = (float var_14)
        (var_15 / var_1029)
and method_59 ((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_13: (int64 ref)), (var_14: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4), (var_33: (int64 ref)), (var_34: Env7), (var_35: (int64 ref)), (var_36: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_39: (int64 ref)), (var_40: Env7), (var_41: (int64 ref)), (var_42: Env7), (var_43: (int64 ref)), (var_44: Env7), (var_45: (int64 ref)), (var_46: Env7), (var_47: (int64 ref)), (var_48: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_51: (int64 ref)), (var_52: Env7), (var_53: (int64 ref)), (var_54: Env7), (var_55: (int64 ref)), (var_56: Env7), (var_57: (int64 ref)), (var_58: Env7), (var_59: (int64 ref)), (var_60: Env7), (var_61: (int64 ref)), (var_62: Env7), (var_63: (int64 ref)), (var_64: Env7), (var_65: (int64 ref)), (var_66: Env7), (var_67: (int64 ref)), (var_68: Env7), (var_69: (int64 ref)), (var_70: Env7), (var_71: (int64 ref)), (var_72: Env7), (var_73: (int64 ref)), (var_74: Env7), (var_75: (int64 ref)), (var_76: Env7), (var_77: (int64 ref)), (var_78: Env7), (var_79: (int64 ref)), (var_80: Env7), (var_81: (int64 ref)), (var_82: Env7), (var_83: (int64 ref)), (var_84: Env7), (var_85: (int64 ref)), (var_86: Env7), (var_87: (int64 ref)), (var_88: Env7), (var_89: (int64 ref)), (var_90: Env7), (var_91: (int64 ref)), (var_92: Env7), (var_93: (int64 ref)), (var_94: Env7), (var_95: (int64 ref)), (var_96: Env7), (var_97: (int64 ref)), (var_98: Env7), (var_99: (int64 ref)), (var_100: Env7), (var_101: (int64 ref)), (var_102: Env7), (var_103: (int64 ref)), (var_104: Env7), (var_105: (int64 ref)), (var_106: Env7), (var_107: int64)) (): unit =
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
    method_35((var_99: (int64 ref)), (var_100: Env7), (var_89: (int64 ref)), (var_90: Env7), (var_85: (int64 ref)), (var_86: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_89: (int64 ref)), (var_90: Env7), (var_87: (int64 ref)), (var_88: Env7), (var_97: (int64 ref)), (var_98: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
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
    // method_60((var_167: uint64), (var_169: uint64), (var_170: uint64), (var_171: uint64), (var_173: uint64))
    let (var_174: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_60", var_30, var_27)
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
    method_42((var_57: (int64 ref)), (var_58: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_65: (int64 ref)), (var_66: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_57: (int64 ref)), (var_58: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_69: (int64 ref)), (var_70: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
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
    method_42((var_37: (int64 ref)), (var_38: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_45: (int64 ref)), (var_46: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_37: (int64 ref)), (var_38: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
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
    method_42((var_0: (int64 ref)), (var_1: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_36((var_0: (int64 ref)), (var_1: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
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
and method_61((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_25: int64), (var_26: float), (var_27: int64), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env2>), (var_30: (unit -> float32)), (var_31: (unit -> unit)), (var_32: (int64 ref)), (var_33: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_36: int64)): float =
    let (var_37: bool) = (var_36 < 64L)
    if var_37 then
        let (var_38: bool) = (var_36 >= 0L)
        let (var_39: bool) = (var_38 = false)
        if var_39 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_40: int64) = (var_36 * 8192L)
        let (var_41: int64) = (var_2 + var_40)
        if var_39 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_42: int64) = (var_3 + var_40)
        let (var_43: (int64 ref)) = var_4.mem_12
        let (var_44: Env7) = var_4.mem_13
        let (var_45: (int64 ref)) = var_4.mem_14
        let (var_46: Env7) = var_4.mem_15
        let (var_47: (int64 ref)) = var_4.mem_16
        let (var_48: Env7) = var_4.mem_17
        let (var_49: (int64 ref)) = var_4.mem_18
        let (var_50: Env7) = var_4.mem_19
        let (var_51: (int64 ref)) = var_4.mem_20
        let (var_52: Env7) = var_4.mem_21
        let (var_53: (int64 ref)) = var_4.mem_22
        let (var_54: Env7) = var_4.mem_23
        let (var_55: (int64 ref)) = var_4.mem_24
        let (var_56: Env7) = var_4.mem_25
        let (var_57: (int64 ref)) = var_4.mem_26
        let (var_58: Env7) = var_4.mem_27
        let (var_59: (int64 ref)) = var_4.mem_28
        let (var_60: Env7) = var_4.mem_29
        let (var_61: (int64 ref)) = var_4.mem_30
        let (var_62: Env7) = var_4.mem_31
        let (var_63: (int64 ref)) = var_4.mem_32
        let (var_64: Env7) = var_4.mem_33
        let (var_65: (int64 ref)) = var_4.mem_34
        let (var_66: Env7) = var_4.mem_35
        let (var_67: (int64 ref)) = var_4.mem_0
        let (var_68: Env7) = var_4.mem_1
        let (var_69: (int64 ref)) = var_4.mem_2
        let (var_70: Env7) = var_4.mem_3
        let (var_71: (int64 ref)) = var_4.mem_4
        let (var_72: Env7) = var_4.mem_5
        let (var_73: (int64 ref)) = var_4.mem_6
        let (var_74: Env7) = var_4.mem_7
        let (var_75: (int64 ref)) = var_4.mem_8
        let (var_76: Env7) = var_4.mem_9
        let (var_77: (int64 ref)) = var_4.mem_10
        let (var_78: Env7) = var_4.mem_11
        let (var_79: int64) = 32768L
        let (var_80: EnvHeap8) = ({mem_0 = (var_15: (uint64 ref)); mem_1 = (var_16: uint64); mem_2 = (var_17: ResizeArray<Env0>); mem_3 = (var_18: ResizeArray<Env1>)} : EnvHeap8)
        let (var_81: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_79: int64))
        let (var_82: (int64 ref)) = var_81.mem_0
        let (var_83: Env7) = var_81.mem_1
        method_22((var_49: (int64 ref)), (var_50: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_41: int64), (var_82: (int64 ref)), (var_83: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_84: int64) = 32768L
        let (var_85: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_84: int64))
        let (var_86: (int64 ref)) = var_85.mem_0
        let (var_87: Env7) = var_85.mem_1
        let (var_88: (bool ref)) = var_24.mem_0
        let (var_89: ManagedCuda.CudaStream) = var_24.mem_1
        let (var_90: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_91: (uint64 ref)) = var_87.mem_0
        let (var_92: uint64) = method_5((var_91: (uint64 ref)))
        let (var_93: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_92)
        let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_93)
        let (var_95: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_94, 0uy, var_95, var_90)
        method_46((var_61: (int64 ref)), (var_62: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_82: (int64 ref)), (var_83: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_96: (uint64 ref)) = var_74.mem_0
        let (var_97: uint64) = method_5((var_96: (uint64 ref)))
        let (var_98: (uint64 ref)) = var_83.mem_0
        let (var_99: uint64) = method_5((var_98: (uint64 ref)))
        let (var_100: uint64) = method_5((var_98: (uint64 ref)))
        // Cuda join point
        // method_23((var_97: uint64), (var_99: uint64), (var_100: uint64))
        let (var_101: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_101.set_GridDimensions(var_102)
        let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_101.set_BlockDimensions(var_103)
        let (var_104: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_106: (System.Object [])) = [|var_97; var_99; var_100|]: (System.Object [])
        var_101.RunAsync(var_104, var_106)
        let (var_108: int64) = 32768L
        let (var_109: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_108: int64))
        let (var_110: (int64 ref)) = var_109.mem_0
        let (var_111: Env7) = var_109.mem_1
        let (var_112: uint64) = method_5((var_98: (uint64 ref)))
        let (var_113: (uint64 ref)) = var_111.mem_0
        let (var_114: uint64) = method_5((var_113: (uint64 ref)))
        // Cuda join point
        // method_25((var_112: uint64), (var_114: uint64))
        let (var_115: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_22, var_19)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_115.set_GridDimensions(var_116)
        let (var_117: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_115.set_BlockDimensions(var_117)
        let (var_118: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_120: (System.Object [])) = [|var_112; var_114|]: (System.Object [])
        var_115.RunAsync(var_118, var_120)
        let (var_121: int64) = 32768L
        let (var_122: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_121: int64))
        let (var_123: (int64 ref)) = var_122.mem_0
        let (var_124: Env7) = var_122.mem_1
        let (var_125: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_126: (uint64 ref)) = var_124.mem_0
        let (var_127: uint64) = method_5((var_126: (uint64 ref)))
        let (var_128: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_127)
        let (var_129: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_128)
        let (var_130: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_129, 0uy, var_130, var_125)
        let (var_131: int64) = 32768L
        let (var_132: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_131: int64))
        let (var_133: (int64 ref)) = var_132.mem_0
        let (var_134: Env7) = var_132.mem_1
        method_22((var_53: (int64 ref)), (var_54: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_41: int64), (var_133: (int64 ref)), (var_134: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_135: int64) = 32768L
        let (var_136: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_135: int64))
        let (var_137: (int64 ref)) = var_136.mem_0
        let (var_138: Env7) = var_136.mem_1
        let (var_139: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_140: (uint64 ref)) = var_138.mem_0
        let (var_141: uint64) = method_5((var_140: (uint64 ref)))
        let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_141)
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_142)
        let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_143, 0uy, var_144, var_139)
        method_46((var_65: (int64 ref)), (var_66: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_133: (int64 ref)), (var_134: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_145: (uint64 ref)) = var_78.mem_0
        let (var_146: uint64) = method_5((var_145: (uint64 ref)))
        let (var_147: (uint64 ref)) = var_134.mem_0
        let (var_148: uint64) = method_5((var_147: (uint64 ref)))
        let (var_149: uint64) = method_5((var_147: (uint64 ref)))
        // Cuda join point
        // method_23((var_146: uint64), (var_148: uint64), (var_149: uint64))
        let (var_150: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_151: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_150.set_GridDimensions(var_151)
        let (var_152: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_150.set_BlockDimensions(var_152)
        let (var_153: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_155: (System.Object [])) = [|var_146; var_148; var_149|]: (System.Object [])
        var_150.RunAsync(var_153, var_155)
        let (var_160: int64) = 32768L
        let (var_161: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_160: int64))
        let (var_162: (int64 ref)) = var_161.mem_0
        let (var_163: Env7) = var_161.mem_1
        let (var_164: uint64) = method_5((var_147: (uint64 ref)))
        let (var_165: (uint64 ref)) = var_163.mem_0
        let (var_166: uint64) = method_5((var_165: (uint64 ref)))
        // Cuda join point
        // method_27((var_164: uint64), (var_166: uint64))
        let (var_167: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_167.set_GridDimensions(var_168)
        let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_167.set_BlockDimensions(var_169)
        let (var_170: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_172: (System.Object [])) = [|var_164; var_166|]: (System.Object [])
        var_167.RunAsync(var_170, var_172)
        let (var_173: int64) = 32768L
        let (var_174: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_173: int64))
        let (var_175: (int64 ref)) = var_174.mem_0
        let (var_176: Env7) = var_174.mem_1
        let (var_177: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_178: (uint64 ref)) = var_176.mem_0
        let (var_179: uint64) = method_5((var_178: (uint64 ref)))
        let (var_180: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_179)
        let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_180)
        let (var_182: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_181, 0uy, var_182, var_177)
        let (var_183: int64) = 32768L
        let (var_184: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_183: int64))
        let (var_185: (int64 ref)) = var_184.mem_0
        let (var_186: Env7) = var_184.mem_1
        method_22((var_45: (int64 ref)), (var_46: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_41: int64), (var_185: (int64 ref)), (var_186: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_187: int64) = 32768L
        let (var_188: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_187: int64))
        let (var_189: (int64 ref)) = var_188.mem_0
        let (var_190: Env7) = var_188.mem_1
        let (var_191: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_192: (uint64 ref)) = var_190.mem_0
        let (var_193: uint64) = method_5((var_192: (uint64 ref)))
        let (var_194: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_193)
        let (var_195: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_194)
        let (var_196: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_195, 0uy, var_196, var_191)
        method_46((var_57: (int64 ref)), (var_58: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_185: (int64 ref)), (var_186: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_197: (uint64 ref)) = var_70.mem_0
        let (var_198: uint64) = method_5((var_197: (uint64 ref)))
        let (var_199: (uint64 ref)) = var_186.mem_0
        let (var_200: uint64) = method_5((var_199: (uint64 ref)))
        let (var_201: uint64) = method_5((var_199: (uint64 ref)))
        // Cuda join point
        // method_23((var_198: uint64), (var_200: uint64), (var_201: uint64))
        let (var_202: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_202.set_GridDimensions(var_203)
        let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_202.set_BlockDimensions(var_204)
        let (var_205: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_207: (System.Object [])) = [|var_198; var_200; var_201|]: (System.Object [])
        var_202.RunAsync(var_205, var_207)
        let (var_212: int64) = 32768L
        let (var_213: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_212: int64))
        let (var_214: (int64 ref)) = var_213.mem_0
        let (var_215: Env7) = var_213.mem_1
        let (var_216: uint64) = method_5((var_199: (uint64 ref)))
        let (var_217: (uint64 ref)) = var_215.mem_0
        let (var_218: uint64) = method_5((var_217: (uint64 ref)))
        // Cuda join point
        // method_27((var_216: uint64), (var_218: uint64))
        let (var_219: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_220: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_219.set_GridDimensions(var_220)
        let (var_221: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_219.set_BlockDimensions(var_221)
        let (var_222: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_224: (System.Object [])) = [|var_216; var_218|]: (System.Object [])
        var_219.RunAsync(var_222, var_224)
        let (var_225: int64) = 32768L
        let (var_226: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_225: int64))
        let (var_227: (int64 ref)) = var_226.mem_0
        let (var_228: Env7) = var_226.mem_1
        let (var_229: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_230: (uint64 ref)) = var_228.mem_0
        let (var_231: uint64) = method_5((var_230: (uint64 ref)))
        let (var_232: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_231)
        let (var_233: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_232)
        let (var_234: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_233, 0uy, var_234, var_229)
        let (var_236: int64) = 32768L
        let (var_237: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_236: int64))
        let (var_238: (int64 ref)) = var_237.mem_0
        let (var_239: Env7) = var_237.mem_1
        let (var_240: uint64) = method_5((var_113: (uint64 ref)))
        let (var_241: uint64) = method_5((var_165: (uint64 ref)))
        let (var_242: (uint64 ref)) = var_239.mem_0
        let (var_243: uint64) = method_5((var_242: (uint64 ref)))
        // Cuda join point
        // method_28((var_240: uint64), (var_241: uint64), (var_243: uint64))
        let (var_244: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_22, var_19)
        let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_244.set_GridDimensions(var_245)
        let (var_246: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_244.set_BlockDimensions(var_246)
        let (var_247: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_249: (System.Object [])) = [|var_240; var_241; var_243|]: (System.Object [])
        var_244.RunAsync(var_247, var_249)
        let (var_250: int64) = 32768L
        let (var_251: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_250: int64))
        let (var_252: (int64 ref)) = var_251.mem_0
        let (var_253: Env7) = var_251.mem_1
        let (var_254: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_255: (uint64 ref)) = var_253.mem_0
        let (var_256: uint64) = method_5((var_255: (uint64 ref)))
        let (var_257: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_256)
        let (var_258: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_257)
        let (var_259: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_258, 0uy, var_259, var_254)
        let (var_261: int64) = 32768L
        let (var_262: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_261: int64))
        let (var_263: (int64 ref)) = var_262.mem_0
        let (var_264: Env7) = var_262.mem_1
        let (var_265: (uint64 ref)) = var_35.mem_0
        let (var_266: uint64) = method_5((var_265: (uint64 ref)))
        let (var_267: uint64) = method_5((var_217: (uint64 ref)))
        let (var_268: (uint64 ref)) = var_264.mem_0
        let (var_269: uint64) = method_5((var_268: (uint64 ref)))
        // Cuda join point
        // method_28((var_266: uint64), (var_267: uint64), (var_269: uint64))
        let (var_270: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_22, var_19)
        let (var_271: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_270.set_GridDimensions(var_271)
        let (var_272: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_270.set_BlockDimensions(var_272)
        let (var_273: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_275: (System.Object [])) = [|var_266; var_267; var_269|]: (System.Object [])
        var_270.RunAsync(var_273, var_275)
        let (var_276: int64) = 32768L
        let (var_277: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_276: int64))
        let (var_278: (int64 ref)) = var_277.mem_0
        let (var_279: Env7) = var_277.mem_1
        let (var_280: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_281: (uint64 ref)) = var_279.mem_0
        let (var_282: uint64) = method_5((var_281: (uint64 ref)))
        let (var_283: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_282)
        let (var_284: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_283)
        let (var_285: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_284, 0uy, var_285, var_280)
        let (var_287: int64) = 32768L
        let (var_288: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_287: int64))
        let (var_289: (int64 ref)) = var_288.mem_0
        let (var_290: Env7) = var_288.mem_1
        let (var_291: uint64) = method_5((var_242: (uint64 ref)))
        let (var_292: uint64) = method_5((var_268: (uint64 ref)))
        let (var_293: (uint64 ref)) = var_290.mem_0
        let (var_294: uint64) = method_5((var_293: (uint64 ref)))
        // Cuda join point
        // method_47((var_291: uint64), (var_292: uint64), (var_294: uint64))
        let (var_295: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_22, var_19)
        let (var_296: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_295.set_GridDimensions(var_296)
        let (var_297: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_295.set_BlockDimensions(var_297)
        let (var_298: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_300: (System.Object [])) = [|var_291; var_292; var_294|]: (System.Object [])
        var_295.RunAsync(var_298, var_300)
        let (var_301: int64) = 32768L
        let (var_302: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_301: int64))
        let (var_303: (int64 ref)) = var_302.mem_0
        let (var_304: Env7) = var_302.mem_1
        let (var_305: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_306: (uint64 ref)) = var_304.mem_0
        let (var_307: uint64) = method_5((var_306: (uint64 ref)))
        let (var_308: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_307)
        let (var_309: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_308)
        let (var_310: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_309, 0uy, var_310, var_305)
        let (var_311: int64) = 32768L
        let (var_312: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_311: int64))
        let (var_313: (int64 ref)) = var_312.mem_0
        let (var_314: Env7) = var_312.mem_1
        method_29((var_11: (int64 ref)), (var_12: Env7), (var_289: (int64 ref)), (var_290: Env7), (var_313: (int64 ref)), (var_314: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4))
        let (var_315: int64) = 32768L
        let (var_316: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_315: int64))
        let (var_317: (int64 ref)) = var_316.mem_0
        let (var_318: Env7) = var_316.mem_1
        let (var_319: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_320: (uint64 ref)) = var_318.mem_0
        let (var_321: uint64) = method_5((var_320: (uint64 ref)))
        let (var_322: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_321)
        let (var_323: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_322)
        let (var_324: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_323, 0uy, var_324, var_319)
        let (var_325: (uint64 ref)) = var_8.mem_0
        let (var_326: uint64) = method_5((var_325: (uint64 ref)))
        let (var_327: (uint64 ref)) = var_314.mem_0
        let (var_328: uint64) = method_5((var_327: (uint64 ref)))
        let (var_329: uint64) = method_5((var_327: (uint64 ref)))
        // Cuda join point
        // method_23((var_326: uint64), (var_328: uint64), (var_329: uint64))
        let (var_330: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_22, var_19)
        let (var_331: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_330.set_GridDimensions(var_331)
        let (var_332: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_330.set_BlockDimensions(var_332)
        let (var_333: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_335: (System.Object [])) = [|var_326; var_328; var_329|]: (System.Object [])
        var_330.RunAsync(var_333, var_335)
        let (var_340: int64) = 32768L
        let (var_341: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_340: int64))
        let (var_342: (int64 ref)) = var_341.mem_0
        let (var_343: Env7) = var_341.mem_1
        let (var_344: uint64) = method_5((var_327: (uint64 ref)))
        let (var_345: (uint64 ref)) = var_343.mem_0
        let (var_346: uint64) = method_5((var_345: (uint64 ref)))
        // Cuda join point
        // method_27((var_344: uint64), (var_346: uint64))
        let (var_347: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_22, var_19)
        let (var_348: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_347.set_GridDimensions(var_348)
        let (var_349: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_347.set_BlockDimensions(var_349)
        let (var_350: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_352: (System.Object [])) = [|var_344; var_346|]: (System.Object [])
        var_347.RunAsync(var_350, var_352)
        let (var_353: int64) = 32768L
        let (var_354: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_353: int64))
        let (var_355: (int64 ref)) = var_354.mem_0
        let (var_356: Env7) = var_354.mem_1
        let (var_357: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_358: (uint64 ref)) = var_356.mem_0
        let (var_359: uint64) = method_5((var_358: (uint64 ref)))
        let (var_360: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_359)
        let (var_361: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_360)
        let (var_362: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_19.ClearMemoryAsync(var_361, 0uy, var_362, var_357)
        let (var_363: uint64) = method_5((var_345: (uint64 ref)))
        let (var_364: (uint64 ref)) = var_1.mem_0
        let (var_365: uint64) = method_5((var_364: (uint64 ref)))
        let (var_366: int64) = (var_42 * 4L)
        let (var_367: uint64) = (uint64 var_366)
        let (var_368: uint64) = (var_365 + var_367)
        let (var_372: int64) = 4L
        let (var_373: Env2) = method_11((var_80: EnvHeap8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_372: int64))
        let (var_374: (int64 ref)) = var_373.mem_0
        let (var_375: Env7) = var_373.mem_1
        let (var_376: (uint64 ref)) = var_375.mem_0
        let (var_377: uint64) = method_5((var_376: (uint64 ref)))
        // Cuda join point
        // method_30((var_363: uint64), (var_368: uint64), (var_377: uint64))
        let (var_378: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_22, var_19)
        let (var_379: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_378.set_GridDimensions(var_379)
        let (var_380: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_378.set_BlockDimensions(var_380)
        let (var_381: ManagedCuda.BasicTypes.CUstream) = method_19((var_88: (bool ref)), (var_89: ManagedCuda.CudaStream))
        let (var_383: (System.Object [])) = [|var_363; var_368; var_377|]: (System.Object [])
        var_378.RunAsync(var_381, var_383)
        let (var_384: (unit -> unit)) = method_48((var_31: (unit -> unit)), (var_86: (int64 ref)), (var_87: Env7), (var_82: (int64 ref)), (var_83: Env7), (var_71: (int64 ref)), (var_72: Env7), (var_73: (int64 ref)), (var_74: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_41: int64), (var_47: (int64 ref)), (var_48: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_32: (int64 ref)), (var_33: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_59: (int64 ref)), (var_60: Env7), (var_61: (int64 ref)), (var_62: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_123: (int64 ref)), (var_124: Env7), (var_110: (int64 ref)), (var_111: Env7), (var_137: (int64 ref)), (var_138: Env7), (var_133: (int64 ref)), (var_134: Env7), (var_75: (int64 ref)), (var_76: Env7), (var_77: (int64 ref)), (var_78: Env7), (var_51: (int64 ref)), (var_52: Env7), (var_53: (int64 ref)), (var_54: Env7), (var_63: (int64 ref)), (var_64: Env7), (var_65: (int64 ref)), (var_66: Env7), (var_175: (int64 ref)), (var_176: Env7), (var_162: (int64 ref)), (var_163: Env7), (var_189: (int64 ref)), (var_190: Env7), (var_185: (int64 ref)), (var_186: Env7), (var_67: (int64 ref)), (var_68: Env7), (var_69: (int64 ref)), (var_70: Env7), (var_43: (int64 ref)), (var_44: Env7), (var_45: (int64 ref)), (var_46: Env7), (var_55: (int64 ref)), (var_56: Env7), (var_57: (int64 ref)), (var_58: Env7), (var_227: (int64 ref)), (var_228: Env7), (var_214: (int64 ref)), (var_215: Env7), (var_252: (int64 ref)), (var_253: Env7), (var_238: (int64 ref)), (var_239: Env7), (var_278: (int64 ref)), (var_279: Env7), (var_263: (int64 ref)), (var_264: Env7), (var_303: (int64 ref)), (var_304: Env7), (var_289: (int64 ref)), (var_290: Env7), (var_317: (int64 ref)), (var_318: Env7), (var_313: (int64 ref)), (var_314: Env7), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_355: (int64 ref)), (var_356: Env7), (var_342: (int64 ref)), (var_343: Env7), (var_374: (int64 ref)), (var_375: Env7), (var_42: int64))
        let (var_385: (unit -> float32)) = method_50((var_374: (int64 ref)), (var_375: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_30: (unit -> float32)))
        let (var_386: int64) = (var_36 + 1L)
        method_61((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_25: int64), (var_26: float), (var_27: int64), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env2>), (var_385: (unit -> float32)), (var_384: (unit -> unit)), (var_303: (int64 ref)), (var_304: Env7), (var_289: (int64 ref)), (var_290: Env7), (var_386: int64))
    else
        let (var_388: float32) = var_30()
        let (var_389: float) = (float var_388)
        let (var_390: float) = (var_26 + var_389)
        method_53((var_29: ResizeArray<Env2>))
        let (var_399: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_52((var_34: (int64 ref)), (var_35: Env7), (var_399: ResizeArray<Env2>))
        let (var_400: int64) = (var_25 + 1L)
        if (System.Double.IsNaN var_390) then
            method_53((var_20: ResizeArray<Env2>))
            // Done with the net...
            method_53((var_20: ResizeArray<Env2>))
            let (var_401: float) = (float var_400)
            (var_390 / var_401)
        else
            var_31()
            let (var_403: (int64 ref)) = var_4.mem_0
            let (var_404: Env7) = var_4.mem_1
            let (var_405: (int64 ref)) = var_4.mem_2
            let (var_406: Env7) = var_4.mem_3
            let (var_407: (int64 ref)) = var_4.mem_4
            let (var_408: Env7) = var_4.mem_5
            let (var_409: (int64 ref)) = var_4.mem_6
            let (var_410: Env7) = var_4.mem_7
            let (var_411: (int64 ref)) = var_4.mem_8
            let (var_412: Env7) = var_4.mem_9
            let (var_413: (int64 ref)) = var_4.mem_10
            let (var_414: Env7) = var_4.mem_11
            let (var_415: (int64 ref)) = var_4.mem_12
            let (var_416: Env7) = var_4.mem_13
            let (var_417: (int64 ref)) = var_4.mem_14
            let (var_418: Env7) = var_4.mem_15
            let (var_419: (int64 ref)) = var_4.mem_16
            let (var_420: Env7) = var_4.mem_17
            let (var_421: (int64 ref)) = var_4.mem_18
            let (var_422: Env7) = var_4.mem_19
            let (var_423: (int64 ref)) = var_4.mem_20
            let (var_424: Env7) = var_4.mem_21
            let (var_425: (int64 ref)) = var_4.mem_22
            let (var_426: Env7) = var_4.mem_23
            let (var_427: (int64 ref)) = var_4.mem_24
            let (var_428: Env7) = var_4.mem_25
            let (var_429: (int64 ref)) = var_4.mem_26
            let (var_430: Env7) = var_4.mem_27
            let (var_431: (int64 ref)) = var_4.mem_28
            let (var_432: Env7) = var_4.mem_29
            let (var_433: (int64 ref)) = var_4.mem_30
            let (var_434: Env7) = var_4.mem_31
            let (var_435: (int64 ref)) = var_4.mem_32
            let (var_436: Env7) = var_4.mem_33
            let (var_437: (int64 ref)) = var_4.mem_34
            let (var_438: Env7) = var_4.mem_35
            let (var_439: (uint64 ref)) = var_406.mem_0
            let (var_440: uint64) = method_5((var_439: (uint64 ref)))
            let (var_441: (uint64 ref)) = var_404.mem_0
            let (var_442: uint64) = method_5((var_441: (uint64 ref)))
            // Cuda join point
            // method_55((var_440: uint64), (var_442: uint64))
            let (var_443: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_444: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_443.set_GridDimensions(var_444)
            let (var_445: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_443.set_BlockDimensions(var_445)
            let (var_446: (bool ref)) = var_24.mem_0
            let (var_447: ManagedCuda.CudaStream) = var_24.mem_1
            let (var_448: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_450: (System.Object [])) = [|var_440; var_442|]: (System.Object [])
            var_443.RunAsync(var_448, var_450)
            let (var_451: (uint64 ref)) = var_410.mem_0
            let (var_452: uint64) = method_5((var_451: (uint64 ref)))
            let (var_453: (uint64 ref)) = var_408.mem_0
            let (var_454: uint64) = method_5((var_453: (uint64 ref)))
            // Cuda join point
            // method_55((var_452: uint64), (var_454: uint64))
            let (var_455: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_456: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_455.set_GridDimensions(var_456)
            let (var_457: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_455.set_BlockDimensions(var_457)
            let (var_458: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_460: (System.Object [])) = [|var_452; var_454|]: (System.Object [])
            var_455.RunAsync(var_458, var_460)
            let (var_461: (uint64 ref)) = var_414.mem_0
            let (var_462: uint64) = method_5((var_461: (uint64 ref)))
            let (var_463: (uint64 ref)) = var_412.mem_0
            let (var_464: uint64) = method_5((var_463: (uint64 ref)))
            // Cuda join point
            // method_55((var_462: uint64), (var_464: uint64))
            let (var_465: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_466: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_465.set_GridDimensions(var_466)
            let (var_467: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_465.set_BlockDimensions(var_467)
            let (var_468: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_470: (System.Object [])) = [|var_462; var_464|]: (System.Object [])
            var_465.RunAsync(var_468, var_470)
            let (var_471: (uint64 ref)) = var_418.mem_0
            let (var_472: uint64) = method_5((var_471: (uint64 ref)))
            let (var_473: (uint64 ref)) = var_416.mem_0
            let (var_474: uint64) = method_5((var_473: (uint64 ref)))
            // Cuda join point
            // method_56((var_472: uint64), (var_474: uint64))
            let (var_475: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_476: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_475.set_GridDimensions(var_476)
            let (var_477: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_475.set_BlockDimensions(var_477)
            let (var_478: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_480: (System.Object [])) = [|var_472; var_474|]: (System.Object [])
            var_475.RunAsync(var_478, var_480)
            let (var_481: (uint64 ref)) = var_422.mem_0
            let (var_482: uint64) = method_5((var_481: (uint64 ref)))
            let (var_483: (uint64 ref)) = var_420.mem_0
            let (var_484: uint64) = method_5((var_483: (uint64 ref)))
            // Cuda join point
            // method_56((var_482: uint64), (var_484: uint64))
            let (var_485: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_486: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_485.set_GridDimensions(var_486)
            let (var_487: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_485.set_BlockDimensions(var_487)
            let (var_488: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_490: (System.Object [])) = [|var_482; var_484|]: (System.Object [])
            var_485.RunAsync(var_488, var_490)
            let (var_491: (uint64 ref)) = var_426.mem_0
            let (var_492: uint64) = method_5((var_491: (uint64 ref)))
            let (var_493: (uint64 ref)) = var_424.mem_0
            let (var_494: uint64) = method_5((var_493: (uint64 ref)))
            // Cuda join point
            // method_56((var_492: uint64), (var_494: uint64))
            let (var_495: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_496: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_495.set_GridDimensions(var_496)
            let (var_497: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_495.set_BlockDimensions(var_497)
            let (var_498: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_500: (System.Object [])) = [|var_492; var_494|]: (System.Object [])
            var_495.RunAsync(var_498, var_500)
            let (var_501: (uint64 ref)) = var_430.mem_0
            let (var_502: uint64) = method_5((var_501: (uint64 ref)))
            let (var_503: (uint64 ref)) = var_428.mem_0
            let (var_504: uint64) = method_5((var_503: (uint64 ref)))
            // Cuda join point
            // method_56((var_502: uint64), (var_504: uint64))
            let (var_505: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_506: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_505.set_GridDimensions(var_506)
            let (var_507: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_505.set_BlockDimensions(var_507)
            let (var_508: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_510: (System.Object [])) = [|var_502; var_504|]: (System.Object [])
            var_505.RunAsync(var_508, var_510)
            let (var_511: (uint64 ref)) = var_434.mem_0
            let (var_512: uint64) = method_5((var_511: (uint64 ref)))
            let (var_513: (uint64 ref)) = var_432.mem_0
            let (var_514: uint64) = method_5((var_513: (uint64 ref)))
            // Cuda join point
            // method_56((var_512: uint64), (var_514: uint64))
            let (var_515: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_516: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_515.set_GridDimensions(var_516)
            let (var_517: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_515.set_BlockDimensions(var_517)
            let (var_518: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_520: (System.Object [])) = [|var_512; var_514|]: (System.Object [])
            var_515.RunAsync(var_518, var_520)
            let (var_521: (uint64 ref)) = var_438.mem_0
            let (var_522: uint64) = method_5((var_521: (uint64 ref)))
            let (var_523: (uint64 ref)) = var_436.mem_0
            let (var_524: uint64) = method_5((var_523: (uint64 ref)))
            // Cuda join point
            // method_56((var_522: uint64), (var_524: uint64))
            let (var_525: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_526: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_525.set_GridDimensions(var_526)
            let (var_527: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_525.set_BlockDimensions(var_527)
            let (var_528: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_530: (System.Object [])) = [|var_522; var_524|]: (System.Object [])
            var_525.RunAsync(var_528, var_530)
            let (var_531: (uint64 ref)) = var_8.mem_0
            let (var_532: uint64) = method_5((var_531: (uint64 ref)))
            let (var_533: (uint64 ref)) = var_6.mem_0
            let (var_534: uint64) = method_5((var_533: (uint64 ref)))
            // Cuda join point
            // method_55((var_532: uint64), (var_534: uint64))
            let (var_535: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_22, var_19)
            let (var_536: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_535.set_GridDimensions(var_536)
            let (var_537: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_535.set_BlockDimensions(var_537)
            let (var_538: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_540: (System.Object [])) = [|var_532; var_534|]: (System.Object [])
            var_535.RunAsync(var_538, var_540)
            let (var_541: (uint64 ref)) = var_12.mem_0
            let (var_542: uint64) = method_5((var_541: (uint64 ref)))
            let (var_543: (uint64 ref)) = var_10.mem_0
            let (var_544: uint64) = method_5((var_543: (uint64 ref)))
            // Cuda join point
            // method_56((var_542: uint64), (var_544: uint64))
            let (var_545: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_22, var_19)
            let (var_546: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_545.set_GridDimensions(var_546)
            let (var_547: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_545.set_BlockDimensions(var_547)
            let (var_548: ManagedCuda.BasicTypes.CUstream) = method_19((var_446: (bool ref)), (var_447: ManagedCuda.CudaStream))
            let (var_550: (System.Object [])) = [|var_542; var_544|]: (System.Object [])
            var_545.RunAsync(var_548, var_550)
            method_53((var_20: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_551: int64) = (var_27 + 1L)
            method_58((var_0: (int64 ref)), (var_1: Env7), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: (uint64 ref)), (var_16: uint64), (var_17: ResizeArray<Env0>), (var_18: ResizeArray<Env1>), (var_19: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_21: ResizeArray<Env3>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: (int64 ref)), (var_24: EnvHeap4), (var_400: int64), (var_390: float), (var_4: EnvHeap9), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: (int64 ref)), (var_12: Env7), (var_20: ResizeArray<Env2>), (var_34: (int64 ref)), (var_35: Env7), (var_551: int64))
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
let (var_73: EnvStack5) = EnvStack5((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4))
let (var_75: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_76: int64) = var_75.LongLength
let (var_77: bool) = (var_76 >= 0L)
let (var_78: bool) = (var_77 = false)
if var_78 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_83: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_76))
let (var_84: int64) = 0L
method_9((var_83: (uint8 [])), (var_75: (char [])), (var_76: int64), (var_84: int64))
let (var_85: int64) = var_83.LongLength
let (var_86: bool) = (var_85 > 0L)
let (var_87: bool) = (var_86 = false)
if var_87 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_88: bool) = (var_85 = 1115394L)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "The dimensions must match.")
else
    ()
let (var_90: int64) = 1115394L
let (var_91: int64) = 0L
let (var_92: int64) = 1L
let (var_93: Env6) = method_10((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_90: int64), (var_83: (uint8 [])), (var_91: int64), (var_92: int64))
let (var_94: Env2) = var_93.mem_0
let (var_95: (int64 ref)) = var_94.mem_0
let (var_96: Env7) = var_94.mem_1
let (var_97: (uint64 ref)) = var_96.mem_0
let (var_98: uint64) = method_5((var_97: (uint64 ref)))
let (var_102: int64) = 571080704L
let (var_103: EnvHeap8) = ({mem_0 = (var_39: (uint64 ref)); mem_1 = (var_35: uint64); mem_2 = (var_40: ResizeArray<Env0>); mem_3 = (var_41: ResizeArray<Env1>)} : EnvHeap8)
let (var_104: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_102: int64))
let (var_105: (int64 ref)) = var_104.mem_0
let (var_106: Env7) = var_104.mem_1
let (var_107: (uint64 ref)) = var_106.mem_0
let (var_108: uint64) = method_5((var_107: (uint64 ref)))
// Cuda join point
// method_16((var_98: uint64), (var_108: uint64))
let (var_109: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
var_109.set_GridDimensions(var_110)
let (var_111: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_109.set_BlockDimensions(var_111)
let (var_112: (bool ref)) = var_72.mem_0
let (var_113: ManagedCuda.CudaStream) = var_72.mem_1
let (var_114: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_116: (System.Object [])) = [|var_98; var_108|]: (System.Object [])
var_109.RunAsync(var_114, var_116)
let (var_117: int64) = 65536L
let (var_118: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_117: int64))
let (var_119: (int64 ref)) = var_118.mem_0
let (var_120: Env7) = var_118.mem_1
let (var_121: (uint64 ref)) = var_120.mem_0
let (var_122: uint64) = method_5((var_121: (uint64 ref)))
let (var_123: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_124: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_124)
let (var_125: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_122)
let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_125)
var_43.GenerateNormal32(var_126, var_123, 0.000000f, 0.108253f)
let (var_127: int64) = 65536L
let (var_128: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_127: int64))
let (var_129: (int64 ref)) = var_128.mem_0
let (var_130: Env7) = var_128.mem_1
let (var_131: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_132: (uint64 ref)) = var_130.mem_0
let (var_133: uint64) = method_5((var_132: (uint64 ref)))
let (var_134: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_133)
let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_134)
let (var_136: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_135, 0uy, var_136, var_131)
let (var_137: int64) = 65536L
let (var_138: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_137: int64))
let (var_139: (int64 ref)) = var_138.mem_0
let (var_140: Env7) = var_138.mem_1
let (var_141: (uint64 ref)) = var_140.mem_0
let (var_142: uint64) = method_5((var_141: (uint64 ref)))
let (var_143: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_144: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_144)
let (var_145: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_142)
let (var_146: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_145)
var_43.GenerateNormal32(var_146, var_143, 0.000000f, 0.088388f)
let (var_147: int64) = 65536L
let (var_148: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_147: int64))
let (var_149: (int64 ref)) = var_148.mem_0
let (var_150: Env7) = var_148.mem_1
let (var_151: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_152: (uint64 ref)) = var_150.mem_0
let (var_153: uint64) = method_5((var_152: (uint64 ref)))
let (var_154: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_153)
let (var_155: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_154)
let (var_156: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_155, 0uy, var_156, var_151)
let (var_157: int64) = 65536L
let (var_158: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_157: int64))
let (var_159: (int64 ref)) = var_158.mem_0
let (var_160: Env7) = var_158.mem_1
let (var_161: (uint64 ref)) = var_160.mem_0
let (var_162: uint64) = method_5((var_161: (uint64 ref)))
let (var_163: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_164: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_164)
let (var_165: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_162)
let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_165)
var_43.GenerateNormal32(var_166, var_163, 0.000000f, 0.088388f)
let (var_167: int64) = 65536L
let (var_168: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_167: int64))
let (var_169: (int64 ref)) = var_168.mem_0
let (var_170: Env7) = var_168.mem_1
let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_172: (uint64 ref)) = var_170.mem_0
let (var_173: uint64) = method_5((var_172: (uint64 ref)))
let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_173)
let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_174)
let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_175, 0uy, var_176, var_171)
let (var_177: int64) = 65536L
let (var_178: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_177: int64))
let (var_179: (int64 ref)) = var_178.mem_0
let (var_180: Env7) = var_178.mem_1
let (var_181: (uint64 ref)) = var_180.mem_0
let (var_182: uint64) = method_5((var_181: (uint64 ref)))
let (var_183: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_184: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_184)
let (var_185: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_182)
let (var_186: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_185)
var_43.GenerateNormal32(var_186, var_183, 0.000000f, 0.108253f)
let (var_187: int64) = 65536L
let (var_188: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_187: int64))
let (var_189: (int64 ref)) = var_188.mem_0
let (var_190: Env7) = var_188.mem_1
let (var_191: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_192: (uint64 ref)) = var_190.mem_0
let (var_193: uint64) = method_5((var_192: (uint64 ref)))
let (var_194: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_193)
let (var_195: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_194)
let (var_196: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_195, 0uy, var_196, var_191)
let (var_197: int64) = 65536L
let (var_198: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_197: int64))
let (var_199: (int64 ref)) = var_198.mem_0
let (var_200: Env7) = var_198.mem_1
let (var_201: (uint64 ref)) = var_200.mem_0
let (var_202: uint64) = method_5((var_201: (uint64 ref)))
let (var_203: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_204: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_204)
let (var_205: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_202)
let (var_206: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_205)
var_43.GenerateNormal32(var_206, var_203, 0.000000f, 0.088388f)
let (var_207: int64) = 65536L
let (var_208: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_207: int64))
let (var_209: (int64 ref)) = var_208.mem_0
let (var_210: Env7) = var_208.mem_1
let (var_211: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_212: (uint64 ref)) = var_210.mem_0
let (var_213: uint64) = method_5((var_212: (uint64 ref)))
let (var_214: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_213)
let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_214)
let (var_216: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_215, 0uy, var_216, var_211)
let (var_217: int64) = 65536L
let (var_218: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_217: int64))
let (var_219: (int64 ref)) = var_218.mem_0
let (var_220: Env7) = var_218.mem_1
let (var_221: (uint64 ref)) = var_220.mem_0
let (var_222: uint64) = method_5((var_221: (uint64 ref)))
let (var_223: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_224: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_224)
let (var_225: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_222)
let (var_226: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_225)
var_43.GenerateNormal32(var_226, var_223, 0.000000f, 0.088388f)
let (var_227: int64) = 65536L
let (var_228: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_227: int64))
let (var_229: (int64 ref)) = var_228.mem_0
let (var_230: Env7) = var_228.mem_1
let (var_231: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_232: (uint64 ref)) = var_230.mem_0
let (var_233: uint64) = method_5((var_232: (uint64 ref)))
let (var_234: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_233)
let (var_235: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_234)
let (var_236: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_235, 0uy, var_236, var_231)
let (var_237: int64) = 512L
let (var_238: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_237: int64))
let (var_239: (int64 ref)) = var_238.mem_0
let (var_240: Env7) = var_238.mem_1
let (var_241: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_242: (uint64 ref)) = var_240.mem_0
let (var_243: uint64) = method_5((var_242: (uint64 ref)))
let (var_244: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_243)
let (var_245: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_244)
let (var_246: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_245, 0uy, var_246, var_241)
let (var_247: int64) = 512L
let (var_248: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_247: int64))
let (var_249: (int64 ref)) = var_248.mem_0
let (var_250: Env7) = var_248.mem_1
let (var_251: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_252: (uint64 ref)) = var_250.mem_0
let (var_253: uint64) = method_5((var_252: (uint64 ref)))
let (var_254: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_253)
let (var_255: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_254)
let (var_256: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_255, 0uy, var_256, var_251)
let (var_257: int64) = 512L
let (var_258: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_257: int64))
let (var_259: (int64 ref)) = var_258.mem_0
let (var_260: Env7) = var_258.mem_1
let (var_261: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_262: (uint64 ref)) = var_260.mem_0
let (var_263: uint64) = method_5((var_262: (uint64 ref)))
let (var_264: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_263)
let (var_265: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_264)
let (var_266: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_265, 0uy, var_266, var_261)
let (var_267: int64) = 512L
let (var_268: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_267: int64))
let (var_269: (int64 ref)) = var_268.mem_0
let (var_270: Env7) = var_268.mem_1
let (var_271: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_272: (uint64 ref)) = var_270.mem_0
let (var_273: uint64) = method_5((var_272: (uint64 ref)))
let (var_274: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_273)
let (var_275: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_274)
let (var_276: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_275, 0uy, var_276, var_271)
let (var_277: int64) = 512L
let (var_278: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_277: int64))
let (var_279: (int64 ref)) = var_278.mem_0
let (var_280: Env7) = var_278.mem_1
let (var_281: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_282: (uint64 ref)) = var_280.mem_0
let (var_283: uint64) = method_5((var_282: (uint64 ref)))
let (var_284: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_283)
let (var_285: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_284)
let (var_286: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_285, 0uy, var_286, var_281)
let (var_287: int64) = 512L
let (var_288: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_287: int64))
let (var_289: (int64 ref)) = var_288.mem_0
let (var_290: Env7) = var_288.mem_1
let (var_291: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_292: (uint64 ref)) = var_290.mem_0
let (var_293: uint64) = method_5((var_292: (uint64 ref)))
let (var_294: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_293)
let (var_295: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_294)
let (var_296: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_295, 0uy, var_296, var_291)
let (var_297: EnvHeap9) = ({mem_0 = (var_289: (int64 ref)); mem_1 = (var_290: Env7); mem_2 = (var_279: (int64 ref)); mem_3 = (var_280: Env7); mem_4 = (var_249: (int64 ref)); mem_5 = (var_250: Env7); mem_6 = (var_239: (int64 ref)); mem_7 = (var_240: Env7); mem_8 = (var_269: (int64 ref)); mem_9 = (var_270: Env7); mem_10 = (var_259: (int64 ref)); mem_11 = (var_260: Env7); mem_12 = (var_169: (int64 ref)); mem_13 = (var_170: Env7); mem_14 = (var_159: (int64 ref)); mem_15 = (var_160: Env7); mem_16 = (var_129: (int64 ref)); mem_17 = (var_130: Env7); mem_18 = (var_119: (int64 ref)); mem_19 = (var_120: Env7); mem_20 = (var_149: (int64 ref)); mem_21 = (var_150: Env7); mem_22 = (var_139: (int64 ref)); mem_23 = (var_140: Env7); mem_24 = (var_229: (int64 ref)); mem_25 = (var_230: Env7); mem_26 = (var_219: (int64 ref)); mem_27 = (var_220: Env7); mem_28 = (var_189: (int64 ref)); mem_29 = (var_190: Env7); mem_30 = (var_179: (int64 ref)); mem_31 = (var_180: Env7); mem_32 = (var_209: (int64 ref)); mem_33 = (var_210: Env7); mem_34 = (var_199: (int64 ref)); mem_35 = (var_200: Env7)} : EnvHeap9)
let (var_298: int64) = 65536L
let (var_299: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_298: int64))
let (var_300: (int64 ref)) = var_299.mem_0
let (var_301: Env7) = var_299.mem_1
let (var_302: (uint64 ref)) = var_301.mem_0
let (var_303: uint64) = method_5((var_302: (uint64 ref)))
let (var_304: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_305: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
var_43.SetStream(var_305)
let (var_306: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_303)
let (var_307: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_306)
var_43.GenerateNormal32(var_307, var_304, 0.000000f, 0.088388f)
let (var_308: int64) = 65536L
let (var_309: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_308: int64))
let (var_310: (int64 ref)) = var_309.mem_0
let (var_311: Env7) = var_309.mem_1
let (var_312: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_313: (uint64 ref)) = var_311.mem_0
let (var_314: uint64) = method_5((var_313: (uint64 ref)))
let (var_315: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_314)
let (var_316: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_315)
let (var_317: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_316, 0uy, var_317, var_312)
let (var_318: int64) = 512L
let (var_319: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_318: int64))
let (var_320: (int64 ref)) = var_319.mem_0
let (var_321: Env7) = var_319.mem_1
let (var_322: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_323: (uint64 ref)) = var_321.mem_0
let (var_324: uint64) = method_5((var_323: (uint64 ref)))
let (var_325: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_324)
let (var_326: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_325)
let (var_327: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_326, 0uy, var_327, var_322)
let (var_328: int64) = 512L
let (var_329: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_328: int64))
let (var_330: (int64 ref)) = var_329.mem_0
let (var_331: Env7) = var_329.mem_1
let (var_332: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_333: (uint64 ref)) = var_331.mem_0
let (var_334: uint64) = method_5((var_333: (uint64 ref)))
let (var_335: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_334)
let (var_336: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_335)
let (var_337: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_336, 0uy, var_337, var_332)
let (var_338: int64) = 0L
method_20((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_105: (int64 ref)), (var_106: Env7), (var_297: EnvHeap9), (var_330: (int64 ref)), (var_331: Env7), (var_320: (int64 ref)), (var_321: Env7), (var_310: (int64 ref)), (var_311: Env7), (var_300: (int64 ref)), (var_301: Env7), (var_338: int64))
method_62((var_66: ResizeArray<Env3>))
method_53((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_339: uint64) = method_5((var_39: (uint64 ref)))
let (var_340: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_339)
let (var_341: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_340)
var_1.FreeMemory(var_341)
var_39 := 0UL
var_1.Dispose()

