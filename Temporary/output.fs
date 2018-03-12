module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_23(float * var_0, float * var_1, float * var_2);
    __global__ void method_25(float * var_0, float * var_1);
    __global__ void method_27(float * var_0, float * var_1, float * var_2);
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_31(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_33(float * var_0, float * var_1);
    __global__ void method_48(float * var_0, float * var_1);
    __global__ void method_49(float * var_0, float * var_1);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_24(long long int * var_0);
    __device__ char method_26(long long int * var_0);
    __device__ char method_28(long long int * var_0, float * var_1);
    __device__ char method_34(long long int * var_0, float * var_1);
    __device__ char method_35(long long int * var_0, float * var_1);
    __device__ char method_36(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_50(long long int * var_0);
    
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
    __global__ void method_27(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_28(var_8, var_9)) {
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
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3) {
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
    __global__ void method_31(float * var_0, float * var_1, float * var_2, float * var_3) {
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
    __global__ void method_33(float * var_0, float * var_1) {
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
            while (method_34(var_21, var_22)) {
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
            while (method_35(var_41, var_42)) {
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
                    while (method_36(var_44, var_69, var_70)) {
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
    __global__ void method_48(float * var_0, float * var_1) {
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
    __global__ void method_49(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_50(var_6)) {
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
    __device__ char method_28(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8192);
    }
    __device__ char method_34(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 64);
    }
    __device__ char method_35(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_36(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_50(long long int * var_0) {
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
and method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: int64)): unit =
    let (var_27: bool) = (var_26 < 5L)
    if var_27 then
        let (var_28: int64) = 0L
        let (var_29: float) = 0.000000
        let (var_30: int64) = 0L
        let (var_31: float) = method_21((var_12: (int64 ref)), (var_13: Env7), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_28: int64), (var_29: float), (var_14: (int64 ref)), (var_15: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_30: int64))
        let (var_32: string) = System.String.Format("Training: {0}",var_31)
        let (var_33: string) = System.String.Format("{0}",var_32)
        System.Console.WriteLine(var_33)
        if (System.Double.IsNaN var_31) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_34: int64) = (var_26 + 1L)
            method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: EnvHeap4), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_34: int64))
    else
        ()
and method_54((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_55
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_46((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_47
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
and method_21((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_28: int64)): float =
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
        let (var_120: int64) = 32768L
        let (var_121: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_120: int64))
        let (var_122: (int64 ref)) = var_121.mem_0
        let (var_123: Env7) = var_121.mem_1
        method_22((var_22: (int64 ref)), (var_23: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_122: (int64 ref)), (var_123: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_124: int64) = 32768L
        let (var_125: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_124: int64))
        let (var_126: (int64 ref)) = var_125.mem_0
        let (var_127: Env7) = var_125.mem_1
        let (var_128: (bool ref)) = var_13.mem_0
        let (var_129: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_130: ManagedCuda.BasicTypes.CUstream) = method_19((var_128: (bool ref)), (var_129: ManagedCuda.CudaStream))
        let (var_131: (uint64 ref)) = var_127.mem_0
        let (var_132: uint64) = method_5((var_131: (uint64 ref)))
        let (var_133: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_132)
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_133)
        let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_134, 0uy, var_135, var_130)
        let (var_136: (uint64 ref)) = var_19.mem_0
        let (var_137: uint64) = method_5((var_136: (uint64 ref)))
        let (var_138: (uint64 ref)) = var_123.mem_0
        let (var_139: uint64) = method_5((var_138: (uint64 ref)))
        let (var_140: uint64) = method_5((var_138: (uint64 ref)))
        // Cuda join point
        // method_23((var_137: uint64), (var_139: uint64), (var_140: uint64))
        let (var_141: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_142: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_141.set_GridDimensions(var_142)
        let (var_143: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_141.set_BlockDimensions(var_143)
        let (var_144: ManagedCuda.BasicTypes.CUstream) = method_19((var_128: (bool ref)), (var_129: ManagedCuda.CudaStream))
        let (var_146: (System.Object [])) = [|var_137; var_139; var_140|]: (System.Object [])
        var_141.RunAsync(var_144, var_146)
        let (var_151: int64) = 32768L
        let (var_152: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_151: int64))
        let (var_153: (int64 ref)) = var_152.mem_0
        let (var_154: Env7) = var_152.mem_1
        let (var_155: uint64) = method_5((var_138: (uint64 ref)))
        let (var_156: (uint64 ref)) = var_154.mem_0
        let (var_157: uint64) = method_5((var_156: (uint64 ref)))
        // Cuda join point
        // method_25((var_155: uint64), (var_157: uint64))
        let (var_158: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_158.set_GridDimensions(var_159)
        let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_158.set_BlockDimensions(var_160)
        let (var_161: ManagedCuda.BasicTypes.CUstream) = method_19((var_128: (bool ref)), (var_129: ManagedCuda.CudaStream))
        let (var_163: (System.Object [])) = [|var_155; var_157|]: (System.Object [])
        var_158.RunAsync(var_161, var_163)
        let (var_164: int64) = 32768L
        let (var_165: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_164: int64))
        let (var_166: (int64 ref)) = var_165.mem_0
        let (var_167: Env7) = var_165.mem_1
        let (var_168: ManagedCuda.BasicTypes.CUstream) = method_19((var_128: (bool ref)), (var_129: ManagedCuda.CudaStream))
        let (var_169: (uint64 ref)) = var_167.mem_0
        let (var_170: uint64) = method_5((var_169: (uint64 ref)))
        let (var_171: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_170)
        let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_171)
        let (var_173: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_172, 0uy, var_173, var_168)
        let (var_174: uint64) = method_5((var_156: (uint64 ref)))
        let (var_175: (uint64 ref)) = var_1.mem_0
        let (var_176: uint64) = method_5((var_175: (uint64 ref)))
        let (var_177: int64) = (var_33 * 4L)
        let (var_178: uint64) = (uint64 var_177)
        let (var_179: uint64) = (var_176 + var_178)
        let (var_183: int64) = 4L
        let (var_184: Env2) = method_11((var_34: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_183: int64))
        let (var_185: (int64 ref)) = var_184.mem_0
        let (var_186: Env7) = var_184.mem_1
        let (var_187: (uint64 ref)) = var_186.mem_0
        let (var_188: uint64) = method_5((var_187: (uint64 ref)))
        // Cuda join point
        // method_27((var_174: uint64), (var_179: uint64), (var_188: uint64))
        let (var_189: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_190: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_189.set_GridDimensions(var_190)
        let (var_191: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_189.set_BlockDimensions(var_191)
        let (var_192: ManagedCuda.BasicTypes.CUstream) = method_19((var_128: (bool ref)), (var_129: ManagedCuda.CudaStream))
        let (var_194: (System.Object [])) = [|var_174; var_179; var_188|]: (System.Object [])
        var_189.RunAsync(var_192, var_194)
        let (var_195: (unit -> unit)) = method_29((var_126: (int64 ref)), (var_127: Env7), (var_122: (int64 ref)), (var_123: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_166: (int64 ref)), (var_167: Env7), (var_153: (int64 ref)), (var_154: Env7), (var_185: (int64 ref)), (var_186: Env7), (var_33: int64))
        let (var_196: (unit -> float32)) = method_37((var_185: (int64 ref)), (var_186: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_272: int64) = 1L
        method_44((var_0: (int64 ref)), (var_1: Env7), (var_32: int64), (var_33: int64), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_28: int64), (var_9: ResizeArray<Env2>), (var_196: (unit -> float32)), (var_195: (unit -> unit)), (var_166: (int64 ref)), (var_167: Env7), (var_153: (int64 ref)), (var_154: Env7), (var_272: int64))
    else
        let (var_274: float) = (float var_14)
        (var_15 / var_274)
and method_55 ((var_0: Env3)): unit =
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
and method_47 ((var_0: Env2)): unit =
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
and method_29 ((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_13: (int64 ref)), (var_14: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4), (var_27: (int64 ref)), (var_28: Env7), (var_29: (int64 ref)), (var_30: Env7), (var_31: (int64 ref)), (var_32: Env7), (var_33: int64)) (): unit =
    let (var_34: (uint64 ref)) = var_32.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: (uint64 ref)) = var_30.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: (uint64 ref)) = var_9.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: int64) = (var_33 * 4L)
    let (var_41: uint64) = (uint64 var_40)
    let (var_42: uint64) = (var_39 + var_41)
    let (var_43: (uint64 ref)) = var_28.mem_0
    let (var_44: uint64) = method_5((var_43: (uint64 ref)))
    // Cuda join point
    // method_30((var_35: uint64), (var_37: uint64), (var_42: uint64), (var_44: uint64))
    let (var_45: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_24, var_21)
    let (var_46: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_45.set_GridDimensions(var_46)
    let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_45.set_BlockDimensions(var_47)
    let (var_48: (bool ref)) = var_26.mem_0
    let (var_49: ManagedCuda.CudaStream) = var_26.mem_1
    let (var_50: ManagedCuda.BasicTypes.CUstream) = method_19((var_48: (bool ref)), (var_49: ManagedCuda.CudaStream))
    let (var_52: (System.Object [])) = [|var_35; var_37; var_42; var_44|]: (System.Object [])
    var_45.RunAsync(var_50, var_52)
    let (var_53: (uint64 ref)) = var_3.mem_0
    let (var_54: uint64) = method_5((var_53: (uint64 ref)))
    let (var_55: uint64) = method_5((var_43: (uint64 ref)))
    let (var_56: uint64) = method_5((var_36: (uint64 ref)))
    let (var_57: (uint64 ref)) = var_1.mem_0
    let (var_58: uint64) = method_5((var_57: (uint64 ref)))
    // Cuda join point
    // method_31((var_54: uint64), (var_55: uint64), (var_56: uint64), (var_58: uint64))
    let (var_59: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_24, var_21)
    let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_59.set_GridDimensions(var_60)
    let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_59.set_BlockDimensions(var_61)
    let (var_62: ManagedCuda.BasicTypes.CUstream) = method_19((var_48: (bool ref)), (var_49: ManagedCuda.CudaStream))
    let (var_64: (System.Object [])) = [|var_54; var_55; var_56; var_58|]: (System.Object [])
    var_59.RunAsync(var_62, var_64)
    method_32((var_0: (int64 ref)), (var_1: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: ResizeArray<Env0>), (var_20: ResizeArray<Env1>), (var_21: ManagedCuda.CudaContext), (var_22: ResizeArray<Env2>), (var_23: ResizeArray<Env3>), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: EnvHeap4))
    let (var_65: uint64) = method_5((var_57: (uint64 ref)))
    let (var_66: (uint64 ref)) = var_5.mem_0
    let (var_67: uint64) = method_5((var_66: (uint64 ref)))
    // Cuda join point
    // method_33((var_65: uint64), (var_67: uint64))
    let (var_68: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_24, var_21)
    let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_68.set_GridDimensions(var_69)
    let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_68.set_BlockDimensions(var_70)
    let (var_71: ManagedCuda.BasicTypes.CUstream) = method_19((var_48: (bool ref)), (var_49: ManagedCuda.CudaStream))
    let (var_73: (System.Object [])) = [|var_65; var_67|]: (System.Object [])
    var_68.RunAsync(var_71, var_73)
and method_37 ((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4)) (): float32 =
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_38((var_14: int64), (var_0: (int64 ref)), (var_1: Env7), (var_15: int64))
    var_16.[int32 0L]
and method_44((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_28: int64), (var_29: float), (var_30: int64), (var_31: ResizeArray<Env2>), (var_32: (unit -> float32)), (var_33: (unit -> unit)), (var_34: (int64 ref)), (var_35: Env7), (var_36: (int64 ref)), (var_37: Env7), (var_38: int64)): float =
    let (var_39: bool) = (var_38 < 64L)
    if var_39 then
        let (var_40: bool) = (var_38 >= 0L)
        let (var_41: bool) = (var_40 = false)
        if var_41 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_42: int64) = (var_38 * 8192L)
        let (var_43: int64) = (var_2 + var_42)
        if var_41 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_44: int64) = (var_3 + var_42)
        let (var_45: int64) = 32768L
        let (var_46: EnvHeap8) = ({mem_0 = (var_18: (uint64 ref)); mem_1 = (var_19: uint64); mem_2 = (var_20: ResizeArray<Env0>); mem_3 = (var_21: ResizeArray<Env1>)} : EnvHeap8)
        let (var_47: Env2) = method_11((var_46: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_45: int64))
        let (var_48: (int64 ref)) = var_47.mem_0
        let (var_49: Env7) = var_47.mem_1
        method_22((var_10: (int64 ref)), (var_11: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_43: int64), (var_48: (int64 ref)), (var_49: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4))
        let (var_50: int64) = 32768L
        let (var_51: Env2) = method_11((var_46: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_50: int64))
        let (var_52: (int64 ref)) = var_51.mem_0
        let (var_53: Env7) = var_51.mem_1
        let (var_54: (bool ref)) = var_27.mem_0
        let (var_55: ManagedCuda.CudaStream) = var_27.mem_1
        let (var_56: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
        let (var_57: (uint64 ref)) = var_53.mem_0
        let (var_58: uint64) = method_5((var_57: (uint64 ref)))
        let (var_59: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_58)
        let (var_60: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_59)
        let (var_61: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_22.ClearMemoryAsync(var_60, 0uy, var_61, var_56)
        method_39((var_14: (int64 ref)), (var_15: Env7), (var_36: (int64 ref)), (var_37: Env7), (var_48: (int64 ref)), (var_49: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4))
        let (var_62: (uint64 ref)) = var_7.mem_0
        let (var_63: uint64) = method_5((var_62: (uint64 ref)))
        let (var_64: (uint64 ref)) = var_49.mem_0
        let (var_65: uint64) = method_5((var_64: (uint64 ref)))
        let (var_66: uint64) = method_5((var_64: (uint64 ref)))
        // Cuda join point
        // method_23((var_63: uint64), (var_65: uint64), (var_66: uint64))
        let (var_67: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_25, var_22)
        let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_67.set_GridDimensions(var_68)
        let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_67.set_BlockDimensions(var_69)
        let (var_70: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
        let (var_72: (System.Object [])) = [|var_63; var_65; var_66|]: (System.Object [])
        var_67.RunAsync(var_70, var_72)
        let (var_77: int64) = 32768L
        let (var_78: Env2) = method_11((var_46: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_77: int64))
        let (var_79: (int64 ref)) = var_78.mem_0
        let (var_80: Env7) = var_78.mem_1
        let (var_81: uint64) = method_5((var_64: (uint64 ref)))
        let (var_82: (uint64 ref)) = var_80.mem_0
        let (var_83: uint64) = method_5((var_82: (uint64 ref)))
        // Cuda join point
        // method_25((var_81: uint64), (var_83: uint64))
        let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_25, var_22)
        let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_84.set_GridDimensions(var_85)
        let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_84.set_BlockDimensions(var_86)
        let (var_87: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
        let (var_89: (System.Object [])) = [|var_81; var_83|]: (System.Object [])
        var_84.RunAsync(var_87, var_89)
        let (var_90: int64) = 32768L
        let (var_91: Env2) = method_11((var_46: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_90: int64))
        let (var_92: (int64 ref)) = var_91.mem_0
        let (var_93: Env7) = var_91.mem_1
        let (var_94: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
        let (var_95: (uint64 ref)) = var_93.mem_0
        let (var_96: uint64) = method_5((var_95: (uint64 ref)))
        let (var_97: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_96)
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_97)
        let (var_99: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_22.ClearMemoryAsync(var_98, 0uy, var_99, var_94)
        let (var_100: uint64) = method_5((var_82: (uint64 ref)))
        let (var_101: (uint64 ref)) = var_1.mem_0
        let (var_102: uint64) = method_5((var_101: (uint64 ref)))
        let (var_103: int64) = (var_44 * 4L)
        let (var_104: uint64) = (uint64 var_103)
        let (var_105: uint64) = (var_102 + var_104)
        let (var_109: int64) = 4L
        let (var_110: Env2) = method_11((var_46: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_109: int64))
        let (var_111: (int64 ref)) = var_110.mem_0
        let (var_112: Env7) = var_110.mem_1
        let (var_113: (uint64 ref)) = var_112.mem_0
        let (var_114: uint64) = method_5((var_113: (uint64 ref)))
        // Cuda join point
        // method_27((var_100: uint64), (var_105: uint64), (var_114: uint64))
        let (var_115: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_25, var_22)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_115.set_GridDimensions(var_116)
        let (var_117: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_115.set_BlockDimensions(var_117)
        let (var_118: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
        let (var_120: (System.Object [])) = [|var_100; var_105; var_114|]: (System.Object [])
        var_115.RunAsync(var_118, var_120)
        let (var_121: (unit -> unit)) = method_40((var_33: (unit -> unit)), (var_52: (int64 ref)), (var_53: Env7), (var_48: (int64 ref)), (var_49: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_43: int64), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_34: (int64 ref)), (var_35: Env7), (var_36: (int64 ref)), (var_37: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_92: (int64 ref)), (var_93: Env7), (var_79: (int64 ref)), (var_80: Env7), (var_111: (int64 ref)), (var_112: Env7), (var_44: int64))
        let (var_122: (unit -> float32)) = method_43((var_111: (int64 ref)), (var_112: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_32: (unit -> float32)))
        let (var_123: int64) = (var_38 + 1L)
        method_44((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_28: int64), (var_29: float), (var_30: int64), (var_31: ResizeArray<Env2>), (var_122: (unit -> float32)), (var_121: (unit -> unit)), (var_92: (int64 ref)), (var_93: Env7), (var_79: (int64 ref)), (var_80: Env7), (var_123: int64))
    else
        let (var_125: float32) = var_32()
        let (var_126: float) = (float var_125)
        let (var_127: float) = (var_29 + var_126)
        let (var_136: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_45((var_36: (int64 ref)), (var_37: Env7), (var_136: ResizeArray<Env2>))
        let (var_137: int64) = (var_28 + 1L)
        if (System.Double.IsNaN var_127) then
            method_46((var_23: ResizeArray<Env2>))
            // Done with the net...
            method_46((var_136: ResizeArray<Env2>))
            let (var_138: float) = (float var_137)
            (var_127 / var_138)
        else
            var_33()
            let (var_140: (uint64 ref)) = var_7.mem_0
            let (var_141: uint64) = method_5((var_140: (uint64 ref)))
            let (var_142: (uint64 ref)) = var_5.mem_0
            let (var_143: uint64) = method_5((var_142: (uint64 ref)))
            // Cuda join point
            // method_48((var_141: uint64), (var_143: uint64))
            let (var_144: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_48", var_25, var_22)
            let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_144.set_GridDimensions(var_145)
            let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_144.set_BlockDimensions(var_146)
            let (var_147: (bool ref)) = var_27.mem_0
            let (var_148: ManagedCuda.CudaStream) = var_27.mem_1
            let (var_149: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
            let (var_151: (System.Object [])) = [|var_141; var_143|]: (System.Object [])
            var_144.RunAsync(var_149, var_151)
            let (var_152: (uint64 ref)) = var_11.mem_0
            let (var_153: uint64) = method_5((var_152: (uint64 ref)))
            let (var_154: (uint64 ref)) = var_9.mem_0
            let (var_155: uint64) = method_5((var_154: (uint64 ref)))
            // Cuda join point
            // method_49((var_153: uint64), (var_155: uint64))
            let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_25, var_22)
            let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_156.set_GridDimensions(var_157)
            let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_156.set_BlockDimensions(var_158)
            let (var_159: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
            let (var_161: (System.Object [])) = [|var_153; var_155|]: (System.Object [])
            var_156.RunAsync(var_159, var_161)
            let (var_162: (uint64 ref)) = var_15.mem_0
            let (var_163: uint64) = method_5((var_162: (uint64 ref)))
            let (var_164: (uint64 ref)) = var_13.mem_0
            let (var_165: uint64) = method_5((var_164: (uint64 ref)))
            // Cuda join point
            // method_49((var_163: uint64), (var_165: uint64))
            let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_25, var_22)
            let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_166.set_GridDimensions(var_167)
            let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_166.set_BlockDimensions(var_168)
            let (var_169: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
            let (var_171: (System.Object [])) = [|var_163; var_165|]: (System.Object [])
            var_166.RunAsync(var_169, var_171)
            method_46((var_23: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_172: int64) = (var_30 + 1L)
            method_51((var_0: (int64 ref)), (var_1: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_137: int64), (var_127: float), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_136: ResizeArray<Env2>), (var_36: (int64 ref)), (var_37: Env7), (var_172: int64))
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
and method_32((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: int64), (var_5: (int64 ref)), (var_6: Env7), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: EnvHeap4)): unit =
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
and method_38((var_0: int64), (var_1: (int64 ref)), (var_2: Env7), (var_3: int64)): (float32 []) =
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
and method_39((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_40 ((var_0: (unit -> unit)), (var_1: (int64 ref)), (var_2: Env7), (var_3: (int64 ref)), (var_4: Env7), (var_5: (int64 ref)), (var_6: Env7), (var_7: (int64 ref)), (var_8: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4), (var_36: (int64 ref)), (var_37: Env7), (var_38: (int64 ref)), (var_39: Env7), (var_40: (int64 ref)), (var_41: Env7), (var_42: int64)) (): unit =
    let (var_43: (uint64 ref)) = var_41.mem_0
    let (var_44: uint64) = method_5((var_43: (uint64 ref)))
    let (var_45: (uint64 ref)) = var_39.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: (uint64 ref)) = var_10.mem_0
    let (var_48: uint64) = method_5((var_47: (uint64 ref)))
    let (var_49: int64) = (var_42 * 4L)
    let (var_50: uint64) = (uint64 var_49)
    let (var_51: uint64) = (var_48 + var_50)
    let (var_52: (uint64 ref)) = var_37.mem_0
    let (var_53: uint64) = method_5((var_52: (uint64 ref)))
    // Cuda join point
    // method_30((var_44: uint64), (var_46: uint64), (var_51: uint64), (var_53: uint64))
    let (var_54: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_33, var_30)
    let (var_55: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_54.set_GridDimensions(var_55)
    let (var_56: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_54.set_BlockDimensions(var_56)
    let (var_57: (bool ref)) = var_35.mem_0
    let (var_58: ManagedCuda.CudaStream) = var_35.mem_1
    let (var_59: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
    let (var_61: (System.Object [])) = [|var_44; var_46; var_51; var_53|]: (System.Object [])
    var_54.RunAsync(var_59, var_61)
    let (var_62: (uint64 ref)) = var_4.mem_0
    let (var_63: uint64) = method_5((var_62: (uint64 ref)))
    let (var_64: uint64) = method_5((var_52: (uint64 ref)))
    let (var_65: uint64) = method_5((var_45: (uint64 ref)))
    let (var_66: (uint64 ref)) = var_2.mem_0
    let (var_67: uint64) = method_5((var_66: (uint64 ref)))
    // Cuda join point
    // method_31((var_63: uint64), (var_64: uint64), (var_65: uint64), (var_67: uint64))
    let (var_68: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_33, var_30)
    let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_68.set_GridDimensions(var_69)
    let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_68.set_BlockDimensions(var_70)
    let (var_71: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
    let (var_73: (System.Object [])) = [|var_63; var_64; var_65; var_67|]: (System.Object [])
    var_68.RunAsync(var_71, var_73)
    method_32((var_1: (int64 ref)), (var_2: Env7), (var_9: (int64 ref)), (var_10: Env7), (var_11: int64), (var_12: (int64 ref)), (var_13: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_41((var_22: (int64 ref)), (var_23: Env7), (var_1: (int64 ref)), (var_2: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    method_42((var_1: (int64 ref)), (var_2: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_24: ManagedCuda.CudaBlas.CudaBlas), (var_25: ManagedCuda.CudaRand.CudaRandDevice), (var_26: (uint64 ref)), (var_27: uint64), (var_28: ResizeArray<Env0>), (var_29: ResizeArray<Env1>), (var_30: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env3>), (var_33: ManagedCuda.BasicTypes.CUmodule), (var_34: (int64 ref)), (var_35: EnvHeap4))
    let (var_74: uint64) = method_5((var_66: (uint64 ref)))
    let (var_75: (uint64 ref)) = var_6.mem_0
    let (var_76: uint64) = method_5((var_75: (uint64 ref)))
    // Cuda join point
    // method_33((var_74: uint64), (var_76: uint64))
    let (var_77: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_33, var_30)
    let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_77.set_GridDimensions(var_78)
    let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_77.set_BlockDimensions(var_79)
    let (var_80: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
    let (var_82: (System.Object [])) = [|var_74; var_76|]: (System.Object [])
    var_77.RunAsync(var_80, var_82)
    var_0()
and method_43 ((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: (unit -> float32))) (): float32 =
    let (var_15: float32) = var_14()
    let (var_16: int64) = 1L
    let (var_17: int64) = 0L
    let (var_18: (float32 [])) = method_38((var_16: int64), (var_0: (int64 ref)), (var_1: Env7), (var_17: int64))
    let (var_19: float32) = var_18.[int32 0L]
    (var_15 + var_19)
and method_45((var_0: (int64 ref)), (var_1: Env7), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, var_1)))
and method_51((var_0: (int64 ref)), (var_1: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_28: ResizeArray<Env2>), (var_29: (int64 ref)), (var_30: Env7), (var_31: int64)): float =
    let (var_32: bool) = (var_31 < 271L)
    if var_32 then
        let (var_33: bool) = (var_31 >= 0L)
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_35: int64) = (var_31 * 524288L)
        if var_34 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = (524288L + var_35)
        let (var_37: EnvHeap8) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap8)
        let (var_38: (uint64 ref)) = var_37.mem_0
        let (var_39: uint64) = var_37.mem_1
        let (var_40: ResizeArray<Env0>) = var_37.mem_2
        let (var_41: ResizeArray<Env1>) = var_37.mem_3
        method_1((var_40: ResizeArray<Env0>), (var_38: (uint64 ref)), (var_39: uint64), (var_41: ResizeArray<Env1>))
        let (var_45: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_123: int64) = 32768L
        let (var_124: Env2) = method_11((var_37: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_123: int64))
        let (var_125: (int64 ref)) = var_124.mem_0
        let (var_126: Env7) = var_124.mem_1
        method_22((var_22: (int64 ref)), (var_23: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_35: int64), (var_125: (int64 ref)), (var_126: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_127: int64) = 32768L
        let (var_128: Env2) = method_11((var_37: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_127: int64))
        let (var_129: (int64 ref)) = var_128.mem_0
        let (var_130: Env7) = var_128.mem_1
        let (var_131: (bool ref)) = var_13.mem_0
        let (var_132: ManagedCuda.CudaStream) = var_13.mem_1
        let (var_133: ManagedCuda.BasicTypes.CUstream) = method_19((var_131: (bool ref)), (var_132: ManagedCuda.CudaStream))
        let (var_134: (uint64 ref)) = var_130.mem_0
        let (var_135: uint64) = method_5((var_134: (uint64 ref)))
        let (var_136: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_135)
        let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_136)
        let (var_138: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_137, 0uy, var_138, var_133)
        method_39((var_26: (int64 ref)), (var_27: Env7), (var_29: (int64 ref)), (var_30: Env7), (var_125: (int64 ref)), (var_126: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_139: (uint64 ref)) = var_19.mem_0
        let (var_140: uint64) = method_5((var_139: (uint64 ref)))
        let (var_141: (uint64 ref)) = var_126.mem_0
        let (var_142: uint64) = method_5((var_141: (uint64 ref)))
        let (var_143: uint64) = method_5((var_141: (uint64 ref)))
        // Cuda join point
        // method_23((var_140: uint64), (var_142: uint64), (var_143: uint64))
        let (var_144: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_11, var_8)
        let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_144.set_GridDimensions(var_145)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_144.set_BlockDimensions(var_146)
        let (var_147: ManagedCuda.BasicTypes.CUstream) = method_19((var_131: (bool ref)), (var_132: ManagedCuda.CudaStream))
        let (var_149: (System.Object [])) = [|var_140; var_142; var_143|]: (System.Object [])
        var_144.RunAsync(var_147, var_149)
        let (var_154: int64) = 32768L
        let (var_155: Env2) = method_11((var_37: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_154: int64))
        let (var_156: (int64 ref)) = var_155.mem_0
        let (var_157: Env7) = var_155.mem_1
        let (var_158: uint64) = method_5((var_141: (uint64 ref)))
        let (var_159: (uint64 ref)) = var_157.mem_0
        let (var_160: uint64) = method_5((var_159: (uint64 ref)))
        // Cuda join point
        // method_25((var_158: uint64), (var_160: uint64))
        let (var_161: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_11, var_8)
        let (var_162: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_161.set_GridDimensions(var_162)
        let (var_163: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_161.set_BlockDimensions(var_163)
        let (var_164: ManagedCuda.BasicTypes.CUstream) = method_19((var_131: (bool ref)), (var_132: ManagedCuda.CudaStream))
        let (var_166: (System.Object [])) = [|var_158; var_160|]: (System.Object [])
        var_161.RunAsync(var_164, var_166)
        let (var_167: int64) = 32768L
        let (var_168: Env2) = method_11((var_37: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_167: int64))
        let (var_169: (int64 ref)) = var_168.mem_0
        let (var_170: Env7) = var_168.mem_1
        let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_131: (bool ref)), (var_132: ManagedCuda.CudaStream))
        let (var_172: (uint64 ref)) = var_170.mem_0
        let (var_173: uint64) = method_5((var_172: (uint64 ref)))
        let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_173)
        let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_174)
        let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_8.ClearMemoryAsync(var_175, 0uy, var_176, var_171)
        let (var_177: uint64) = method_5((var_159: (uint64 ref)))
        let (var_178: (uint64 ref)) = var_1.mem_0
        let (var_179: uint64) = method_5((var_178: (uint64 ref)))
        let (var_180: int64) = (var_36 * 4L)
        let (var_181: uint64) = (uint64 var_180)
        let (var_182: uint64) = (var_179 + var_181)
        let (var_186: int64) = 4L
        let (var_187: Env2) = method_11((var_37: EnvHeap8), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_186: int64))
        let (var_188: (int64 ref)) = var_187.mem_0
        let (var_189: Env7) = var_187.mem_1
        let (var_190: (uint64 ref)) = var_189.mem_0
        let (var_191: uint64) = method_5((var_190: (uint64 ref)))
        // Cuda join point
        // method_27((var_177: uint64), (var_182: uint64), (var_191: uint64))
        let (var_192: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_11, var_8)
        let (var_193: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_192.set_GridDimensions(var_193)
        let (var_194: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_192.set_BlockDimensions(var_194)
        let (var_195: ManagedCuda.BasicTypes.CUstream) = method_19((var_131: (bool ref)), (var_132: ManagedCuda.CudaStream))
        let (var_197: (System.Object [])) = [|var_177; var_182; var_191|]: (System.Object [])
        var_192.RunAsync(var_195, var_197)
        let (var_198: (unit -> unit)) = method_52((var_129: (int64 ref)), (var_130: Env7), (var_125: (int64 ref)), (var_126: Env7), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_35: int64), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_29: (int64 ref)), (var_30: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_169: (int64 ref)), (var_170: Env7), (var_156: (int64 ref)), (var_157: Env7), (var_188: (int64 ref)), (var_189: Env7), (var_36: int64))
        let (var_199: (unit -> float32)) = method_37((var_188: (int64 ref)), (var_189: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4))
        let (var_275: int64) = 1L
        method_53((var_0: (int64 ref)), (var_1: Env7), (var_35: int64), (var_36: int64), (var_16: (int64 ref)), (var_17: Env7), (var_18: (int64 ref)), (var_19: Env7), (var_20: (int64 ref)), (var_21: Env7), (var_22: (int64 ref)), (var_23: Env7), (var_24: (int64 ref)), (var_25: Env7), (var_26: (int64 ref)), (var_27: Env7), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_45: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: EnvHeap4), (var_14: int64), (var_15: float), (var_31: int64), (var_9: ResizeArray<Env2>), (var_28: ResizeArray<Env2>), (var_199: (unit -> float32)), (var_198: (unit -> unit)), (var_169: (int64 ref)), (var_170: Env7), (var_156: (int64 ref)), (var_157: Env7), (var_275: int64))
    else
        method_46((var_28: ResizeArray<Env2>))
        let (var_277: float) = (float var_14)
        (var_15 / var_277)
and method_41((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_42((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: EnvHeap4)): unit =
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
and method_52 ((var_0: (int64 ref)), (var_1: Env7), (var_2: (int64 ref)), (var_3: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_13: (int64 ref)), (var_14: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_19: (int64 ref)), (var_20: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4), (var_33: (int64 ref)), (var_34: Env7), (var_35: (int64 ref)), (var_36: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_39: int64)) (): unit =
    let (var_40: (uint64 ref)) = var_38.mem_0
    let (var_41: uint64) = method_5((var_40: (uint64 ref)))
    let (var_42: (uint64 ref)) = var_36.mem_0
    let (var_43: uint64) = method_5((var_42: (uint64 ref)))
    let (var_44: (uint64 ref)) = var_9.mem_0
    let (var_45: uint64) = method_5((var_44: (uint64 ref)))
    let (var_46: int64) = (var_39 * 4L)
    let (var_47: uint64) = (uint64 var_46)
    let (var_48: uint64) = (var_45 + var_47)
    let (var_49: (uint64 ref)) = var_34.mem_0
    let (var_50: uint64) = method_5((var_49: (uint64 ref)))
    // Cuda join point
    // method_30((var_41: uint64), (var_43: uint64), (var_48: uint64), (var_50: uint64))
    let (var_51: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_30, var_27)
    let (var_52: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_51.set_GridDimensions(var_52)
    let (var_53: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_51.set_BlockDimensions(var_53)
    let (var_54: (bool ref)) = var_32.mem_0
    let (var_55: ManagedCuda.CudaStream) = var_32.mem_1
    let (var_56: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_58: (System.Object [])) = [|var_41; var_43; var_48; var_50|]: (System.Object [])
    var_51.RunAsync(var_56, var_58)
    let (var_59: (uint64 ref)) = var_3.mem_0
    let (var_60: uint64) = method_5((var_59: (uint64 ref)))
    let (var_61: uint64) = method_5((var_49: (uint64 ref)))
    let (var_62: uint64) = method_5((var_42: (uint64 ref)))
    let (var_63: (uint64 ref)) = var_1.mem_0
    let (var_64: uint64) = method_5((var_63: (uint64 ref)))
    // Cuda join point
    // method_31((var_60: uint64), (var_61: uint64), (var_62: uint64), (var_64: uint64))
    let (var_65: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_30, var_27)
    let (var_66: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_65.set_GridDimensions(var_66)
    let (var_67: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_65.set_BlockDimensions(var_67)
    let (var_68: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_70: (System.Object [])) = [|var_60; var_61; var_62; var_64|]: (System.Object [])
    var_65.RunAsync(var_68, var_70)
    method_32((var_0: (int64 ref)), (var_1: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: int64), (var_11: (int64 ref)), (var_12: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    method_42((var_0: (int64 ref)), (var_1: Env7), (var_15: (int64 ref)), (var_16: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: (uint64 ref)), (var_24: uint64), (var_25: ResizeArray<Env0>), (var_26: ResizeArray<Env1>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<Env2>), (var_29: ResizeArray<Env3>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: (int64 ref)), (var_32: EnvHeap4))
    let (var_71: uint64) = method_5((var_63: (uint64 ref)))
    let (var_72: (uint64 ref)) = var_5.mem_0
    let (var_73: uint64) = method_5((var_72: (uint64 ref)))
    // Cuda join point
    // method_33((var_71: uint64), (var_73: uint64))
    let (var_74: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_30, var_27)
    let (var_75: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_74.set_GridDimensions(var_75)
    let (var_76: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_74.set_BlockDimensions(var_76)
    let (var_77: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_79: (System.Object [])) = [|var_71; var_73|]: (System.Object [])
    var_74.RunAsync(var_77, var_79)
and method_53((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_28: int64), (var_29: float), (var_30: int64), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env2>), (var_33: (unit -> float32)), (var_34: (unit -> unit)), (var_35: (int64 ref)), (var_36: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_39: int64)): float =
    let (var_40: bool) = (var_39 < 64L)
    if var_40 then
        let (var_41: bool) = (var_39 >= 0L)
        let (var_42: bool) = (var_41 = false)
        if var_42 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_43: int64) = (var_39 * 8192L)
        let (var_44: int64) = (var_2 + var_43)
        if var_42 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_45: int64) = (var_3 + var_43)
        let (var_46: int64) = 32768L
        let (var_47: EnvHeap8) = ({mem_0 = (var_18: (uint64 ref)); mem_1 = (var_19: uint64); mem_2 = (var_20: ResizeArray<Env0>); mem_3 = (var_21: ResizeArray<Env1>)} : EnvHeap8)
        let (var_48: Env2) = method_11((var_47: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_46: int64))
        let (var_49: (int64 ref)) = var_48.mem_0
        let (var_50: Env7) = var_48.mem_1
        method_22((var_10: (int64 ref)), (var_11: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_44: int64), (var_49: (int64 ref)), (var_50: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4))
        let (var_51: int64) = 32768L
        let (var_52: Env2) = method_11((var_47: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_51: int64))
        let (var_53: (int64 ref)) = var_52.mem_0
        let (var_54: Env7) = var_52.mem_1
        let (var_55: (bool ref)) = var_27.mem_0
        let (var_56: ManagedCuda.CudaStream) = var_27.mem_1
        let (var_57: ManagedCuda.BasicTypes.CUstream) = method_19((var_55: (bool ref)), (var_56: ManagedCuda.CudaStream))
        let (var_58: (uint64 ref)) = var_54.mem_0
        let (var_59: uint64) = method_5((var_58: (uint64 ref)))
        let (var_60: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_59)
        let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_60)
        let (var_62: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_22.ClearMemoryAsync(var_61, 0uy, var_62, var_57)
        method_39((var_14: (int64 ref)), (var_15: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4))
        let (var_63: (uint64 ref)) = var_7.mem_0
        let (var_64: uint64) = method_5((var_63: (uint64 ref)))
        let (var_65: (uint64 ref)) = var_50.mem_0
        let (var_66: uint64) = method_5((var_65: (uint64 ref)))
        let (var_67: uint64) = method_5((var_65: (uint64 ref)))
        // Cuda join point
        // method_23((var_64: uint64), (var_66: uint64), (var_67: uint64))
        let (var_68: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_25, var_22)
        let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_68.set_GridDimensions(var_69)
        let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_68.set_BlockDimensions(var_70)
        let (var_71: ManagedCuda.BasicTypes.CUstream) = method_19((var_55: (bool ref)), (var_56: ManagedCuda.CudaStream))
        let (var_73: (System.Object [])) = [|var_64; var_66; var_67|]: (System.Object [])
        var_68.RunAsync(var_71, var_73)
        let (var_78: int64) = 32768L
        let (var_79: Env2) = method_11((var_47: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_78: int64))
        let (var_80: (int64 ref)) = var_79.mem_0
        let (var_81: Env7) = var_79.mem_1
        let (var_82: uint64) = method_5((var_65: (uint64 ref)))
        let (var_83: (uint64 ref)) = var_81.mem_0
        let (var_84: uint64) = method_5((var_83: (uint64 ref)))
        // Cuda join point
        // method_25((var_82: uint64), (var_84: uint64))
        let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_25, var_22)
        let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_85.set_GridDimensions(var_86)
        let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_85.set_BlockDimensions(var_87)
        let (var_88: ManagedCuda.BasicTypes.CUstream) = method_19((var_55: (bool ref)), (var_56: ManagedCuda.CudaStream))
        let (var_90: (System.Object [])) = [|var_82; var_84|]: (System.Object [])
        var_85.RunAsync(var_88, var_90)
        let (var_91: int64) = 32768L
        let (var_92: Env2) = method_11((var_47: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_91: int64))
        let (var_93: (int64 ref)) = var_92.mem_0
        let (var_94: Env7) = var_92.mem_1
        let (var_95: ManagedCuda.BasicTypes.CUstream) = method_19((var_55: (bool ref)), (var_56: ManagedCuda.CudaStream))
        let (var_96: (uint64 ref)) = var_94.mem_0
        let (var_97: uint64) = method_5((var_96: (uint64 ref)))
        let (var_98: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_97)
        let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_98)
        let (var_100: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
        var_22.ClearMemoryAsync(var_99, 0uy, var_100, var_95)
        let (var_101: uint64) = method_5((var_83: (uint64 ref)))
        let (var_102: (uint64 ref)) = var_1.mem_0
        let (var_103: uint64) = method_5((var_102: (uint64 ref)))
        let (var_104: int64) = (var_45 * 4L)
        let (var_105: uint64) = (uint64 var_104)
        let (var_106: uint64) = (var_103 + var_105)
        let (var_110: int64) = 4L
        let (var_111: Env2) = method_11((var_47: EnvHeap8), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_110: int64))
        let (var_112: (int64 ref)) = var_111.mem_0
        let (var_113: Env7) = var_111.mem_1
        let (var_114: (uint64 ref)) = var_113.mem_0
        let (var_115: uint64) = method_5((var_114: (uint64 ref)))
        // Cuda join point
        // method_27((var_101: uint64), (var_106: uint64), (var_115: uint64))
        let (var_116: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_25, var_22)
        let (var_117: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_116.set_GridDimensions(var_117)
        let (var_118: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_116.set_BlockDimensions(var_118)
        let (var_119: ManagedCuda.BasicTypes.CUstream) = method_19((var_55: (bool ref)), (var_56: ManagedCuda.CudaStream))
        let (var_121: (System.Object [])) = [|var_101; var_106; var_115|]: (System.Object [])
        var_116.RunAsync(var_119, var_121)
        let (var_122: (unit -> unit)) = method_40((var_34: (unit -> unit)), (var_53: (int64 ref)), (var_54: Env7), (var_49: (int64 ref)), (var_50: Env7), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_0: (int64 ref)), (var_1: Env7), (var_44: int64), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_35: (int64 ref)), (var_36: Env7), (var_37: (int64 ref)), (var_38: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_93: (int64 ref)), (var_94: Env7), (var_80: (int64 ref)), (var_81: Env7), (var_112: (int64 ref)), (var_113: Env7), (var_45: int64))
        let (var_123: (unit -> float32)) = method_43((var_112: (int64 ref)), (var_113: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_33: (unit -> float32)))
        let (var_124: int64) = (var_39 + 1L)
        method_53((var_0: (int64 ref)), (var_1: Env7), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_23: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_28: int64), (var_29: float), (var_30: int64), (var_31: ResizeArray<Env2>), (var_32: ResizeArray<Env2>), (var_123: (unit -> float32)), (var_122: (unit -> unit)), (var_93: (int64 ref)), (var_94: Env7), (var_80: (int64 ref)), (var_81: Env7), (var_124: int64))
    else
        let (var_126: float32) = var_33()
        let (var_127: float) = (float var_126)
        let (var_128: float) = (var_29 + var_127)
        let (var_137: ResizeArray<Env2>) = ResizeArray<Env2>()
        method_45((var_37: (int64 ref)), (var_38: Env7), (var_137: ResizeArray<Env2>))
        let (var_138: int64) = (var_28 + 1L)
        if (System.Double.IsNaN var_128) then
            method_46((var_32: ResizeArray<Env2>))
            method_46((var_23: ResizeArray<Env2>))
            // Done with the net...
            method_46((var_137: ResizeArray<Env2>))
            let (var_139: float) = (float var_138)
            (var_128 / var_139)
        else
            var_34()
            let (var_141: (uint64 ref)) = var_7.mem_0
            let (var_142: uint64) = method_5((var_141: (uint64 ref)))
            let (var_143: (uint64 ref)) = var_5.mem_0
            let (var_144: uint64) = method_5((var_143: (uint64 ref)))
            // Cuda join point
            // method_48((var_142: uint64), (var_144: uint64))
            let (var_145: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_48", var_25, var_22)
            let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_145.set_GridDimensions(var_146)
            let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_145.set_BlockDimensions(var_147)
            let (var_148: (bool ref)) = var_27.mem_0
            let (var_149: ManagedCuda.CudaStream) = var_27.mem_1
            let (var_150: ManagedCuda.BasicTypes.CUstream) = method_19((var_148: (bool ref)), (var_149: ManagedCuda.CudaStream))
            let (var_152: (System.Object [])) = [|var_142; var_144|]: (System.Object [])
            var_145.RunAsync(var_150, var_152)
            let (var_153: (uint64 ref)) = var_11.mem_0
            let (var_154: uint64) = method_5((var_153: (uint64 ref)))
            let (var_155: (uint64 ref)) = var_9.mem_0
            let (var_156: uint64) = method_5((var_155: (uint64 ref)))
            // Cuda join point
            // method_49((var_154: uint64), (var_156: uint64))
            let (var_157: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_25, var_22)
            let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_157.set_GridDimensions(var_158)
            let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_157.set_BlockDimensions(var_159)
            let (var_160: ManagedCuda.BasicTypes.CUstream) = method_19((var_148: (bool ref)), (var_149: ManagedCuda.CudaStream))
            let (var_162: (System.Object [])) = [|var_154; var_156|]: (System.Object [])
            var_157.RunAsync(var_160, var_162)
            let (var_163: (uint64 ref)) = var_15.mem_0
            let (var_164: uint64) = method_5((var_163: (uint64 ref)))
            let (var_165: (uint64 ref)) = var_13.mem_0
            let (var_166: uint64) = method_5((var_165: (uint64 ref)))
            // Cuda join point
            // method_49((var_164: uint64), (var_166: uint64))
            let (var_167: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_25, var_22)
            let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_167.set_GridDimensions(var_168)
            let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_167.set_BlockDimensions(var_169)
            let (var_170: ManagedCuda.BasicTypes.CUstream) = method_19((var_148: (bool ref)), (var_149: ManagedCuda.CudaStream))
            let (var_172: (System.Object [])) = [|var_164; var_166|]: (System.Object [])
            var_167.RunAsync(var_170, var_172)
            method_46((var_32: ResizeArray<Env2>))
            method_46((var_23: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_173: int64) = (var_30 + 1L)
            method_51((var_0: (int64 ref)), (var_1: Env7), (var_16: ManagedCuda.CudaBlas.CudaBlas), (var_17: ManagedCuda.CudaRand.CudaRandDevice), (var_18: (uint64 ref)), (var_19: uint64), (var_20: ResizeArray<Env0>), (var_21: ResizeArray<Env1>), (var_22: ManagedCuda.CudaContext), (var_31: ResizeArray<Env2>), (var_24: ResizeArray<Env3>), (var_25: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: EnvHeap4), (var_138: int64), (var_128: float), (var_4: (int64 ref)), (var_5: Env7), (var_6: (int64 ref)), (var_7: Env7), (var_8: (int64 ref)), (var_9: Env7), (var_10: (int64 ref)), (var_11: Env7), (var_12: (int64 ref)), (var_13: Env7), (var_14: (int64 ref)), (var_15: Env7), (var_137: ResizeArray<Env2>), (var_37: (int64 ref)), (var_38: Env7), (var_173: int64))
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
var_43.GenerateNormal32(var_126, var_123, 0.000000f, 0.088388f)
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
let (var_157: int64) = 512L
let (var_158: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_157: int64))
let (var_159: (int64 ref)) = var_158.mem_0
let (var_160: Env7) = var_158.mem_1
let (var_161: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_162: (uint64 ref)) = var_160.mem_0
let (var_163: uint64) = method_5((var_162: (uint64 ref)))
let (var_164: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_163)
let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_164)
let (var_166: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_165, 0uy, var_166, var_161)
let (var_167: int64) = 512L
let (var_168: Env2) = method_11((var_103: EnvHeap8), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_167: int64))
let (var_169: (int64 ref)) = var_168.mem_0
let (var_170: Env7) = var_168.mem_1
let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_112: (bool ref)), (var_113: ManagedCuda.CudaStream))
let (var_172: (uint64 ref)) = var_170.mem_0
let (var_173: uint64) = method_5((var_172: (uint64 ref)))
let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_173)
let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_174)
let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_175, 0uy, var_176, var_171)
let (var_177: int64) = 0L
method_20((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_66: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_71: (int64 ref)), (var_72: EnvHeap4), (var_105: (int64 ref)), (var_106: Env7), (var_169: (int64 ref)), (var_170: Env7), (var_159: (int64 ref)), (var_160: Env7), (var_129: (int64 ref)), (var_130: Env7), (var_119: (int64 ref)), (var_120: Env7), (var_149: (int64 ref)), (var_150: Env7), (var_139: (int64 ref)), (var_140: Env7), (var_177: int64))
method_54((var_66: ResizeArray<Env3>))
method_46((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_178: uint64) = method_5((var_39: (uint64 ref)))
let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_178)
let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_179)
var_1.FreeMemory(var_180)
var_39 := 0UL
var_1.Dispose()

