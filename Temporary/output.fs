module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_23(float * var_0, float * var_1, float * var_2);
    __global__ void method_24(float * var_0, float * var_1);
    __global__ void method_26(float * var_0, float * var_1, float * var_2);
    __global__ void method_29(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_32(float * var_0, float * var_1);
    __global__ void method_46(float * var_0, float * var_1);
    __global__ void method_47(float * var_0, float * var_1);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_25(long long int * var_0);
    __device__ char method_27(long long int * var_0, float * var_1);
    __device__ char method_33(long long int * var_0, float * var_1);
    __device__ char method_34(long long int * var_0, float * var_1);
    __device__ char method_35(long long int var_0, long long int * var_1, float * var_2);
    
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
            long long int var_11 = (var_10 % 128);
            long long int var_12 = (var_10 / 128);
            long long int var_13 = (var_12 % 8714);
            long long int var_14 = (var_12 / 8714);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 8714);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = (var_13 * 16384);
            char var_20 = (var_11 >= 0);
            char var_22;
            if (var_20) {
                var_22 = (var_11 < 128);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_24 = (var_11 * 8714);
            char var_26;
            if (var_15) {
                var_26 = (var_13 < 8714);
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
                var_31 = (var_11 < 128);
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
            while (method_18(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 128);
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
                    var_31 = (var_20 < 128);
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
    __global__ void method_24(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_25(var_6)) {
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
    __global__ void method_26(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_27(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 16384);
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
            long long int var_28 = (var_11 + 1024);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        float var_32 = (var_31 / 128);
        long long int var_33 = threadIdx.x;
        char var_34 = (var_33 == 0);
        if (var_34) {
            long long int var_35 = blockIdx.x;
            char var_36 = (var_35 >= 0);
            char var_38;
            if (var_36) {
                var_38 = (var_35 < 1);
            } else {
                var_38 = 0;
            }
            char var_39 = (var_38 == 0);
            if (var_39) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_35] = var_32;
        } else {
        }
    }
    __global__ void method_29(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_25(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 16384);
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
                var_16 = (var_10 < 16384);
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
            float var_23 = (1 - var_18);
            float var_24 = (var_18 * var_23);
            float var_25 = (var_22 / var_24);
            float var_26 = (var_25 / 128);
            float var_27 = (var_20 + var_26);
            var_3[var_10] = var_27;
            long long int var_28 = (var_10 + 8192);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_25(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 16384);
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
                var_16 = (var_10 < 16384);
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
    __global__ void method_32(float * var_0, float * var_1) {
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
            while (method_33(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 128);
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
            while (method_34(var_41, var_42)) {
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
                    while (method_35(var_44, var_69, var_70)) {
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
    __global__ void method_46(float * var_0, float * var_1) {
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
            float var_18 = (0.5 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_47(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_25(var_6)) {
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
            float var_18 = (0.5 * var_17);
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
    __device__ char method_25(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
    }
    __device__ char method_27(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 16384);
    }
    __device__ char method_33(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_34(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_35(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
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
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap3 =
    {
    mem_0: (int64 ref)
    mem_1: EnvStack0
    }
and EnvHeap4 =
    {
    mem_0: (int64 ref)
    mem_1: EnvHeap5
    }
and EnvHeap5 =
    {
    mem_0: (bool ref)
    mem_1: ManagedCuda.CudaStream
    }
and EnvStack6 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap7 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
and EnvStack8 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>)): unit =
    let (var_5: (Env2 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env2 -> (Env2 -> int32))) = method_3
    let (var_9: System.Comparison<Env2>) = System.Comparison<Env2>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: (uint64 ref)) = var_1.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: int32) = 0
    let (var_14: uint64) = method_6((var_0: ResizeArray<Env1>), (var_3: ResizeArray<Env2>), (var_10: int32), (var_12: uint64), (var_13: int32))
    let (var_15: uint64) = method_5((var_11: (uint64 ref)))
    let (var_16: uint64) = (var_15 + var_2)
    let (var_17: uint64) = (var_16 - var_14)
    let (var_18: uint64) = (var_14 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: uint64) = (var_20 - var_14)
    let (var_22: bool) = (var_17 > var_21)
    if var_22 then
        let (var_23: uint64) = (var_17 - var_21)
        var_0.Add((Env1(var_20, var_23)))
    else
        ()
and method_7((var_0: EnvHeap5), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule)): EnvHeap4 =
    let (var_11: (int64 ref)) = (ref 0L)
    let (var_12: EnvHeap4) = ({mem_0 = (var_11: (int64 ref)); mem_1 = (var_0: EnvHeap5)} : EnvHeap4)
    method_8((var_12: EnvHeap4), (var_9: ResizeArray<EnvHeap4>))
    var_12
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: int64), (var_12: (uint8 [])), (var_13: int64), (var_14: int64)): EnvStack6 =
    let (var_15: int64) = (var_11 * var_14)
    let (var_16: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_17: int64) = var_16.AddrOfPinnedObject().ToInt64()
    let (var_18: uint64) = (uint64 var_17)
    let (var_19: uint64) = (uint64 var_13)
    let (var_20: uint64) = (var_19 + var_18)
    let (var_21: EnvHeap7) = ({mem_0 = (var_2: EnvStack0); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env1>); mem_3 = (var_5: ResizeArray<Env2>)} : EnvHeap7)
    let (var_22: EnvHeap3) = method_11((var_21: EnvHeap7), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_15: int64))
    let (var_23: EnvStack6) = EnvStack6((var_22: EnvHeap3))
    let (var_24: EnvHeap3) = var_23.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_34: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_30, var_32, var_33)
    if var_34 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_34)
    var_16.Free()
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
and method_11((var_0: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
    let (var_13: EnvStack0) = var_0.mem_0
    let (var_14: uint64) = var_0.mem_1
    let (var_15: ResizeArray<Env1>) = var_0.mem_2
    let (var_16: ResizeArray<Env2>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_12((var_15: ResizeArray<Env1>), (var_13: EnvStack0), (var_14: uint64), (var_16: ResizeArray<Env2>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap3) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap3)
    method_15((var_23: EnvHeap3), (var_8: ResizeArray<EnvHeap3>))
    var_23
and method_19((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_20((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvStack0), (var_9: uint64), (var_10: ResizeArray<Env1>), (var_11: ResizeArray<Env2>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap3>), (var_14: ResizeArray<EnvHeap4>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap4), (var_17: EnvStack8), (var_18: int64)): unit =
    let (var_19: bool) = (var_18 < 100L)
    if var_19 then
        let (var_20: int64) = 0L
        let (var_21: float) = 0.000000
        let (var_22: int64) = 0L
        let (var_23: float) = method_21((var_17: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvStack0), (var_9: uint64), (var_10: ResizeArray<Env1>), (var_11: ResizeArray<Env2>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap3>), (var_14: ResizeArray<EnvHeap4>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap4), (var_20: int64), (var_21: float), (var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_22: int64))
        let (var_24: string) = System.String.Format("Training: {0}",var_23)
        let (var_25: string) = System.String.Format("{0}",var_24)
        System.Console.WriteLine(var_25)
        if (System.Double.IsNaN var_23) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_26: int64) = (var_18 + 1L)
            method_20((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: EnvStack0), (var_9: uint64), (var_10: ResizeArray<Env1>), (var_11: ResizeArray<Env2>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap3>), (var_14: ResizeArray<EnvHeap4>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap4), (var_17: EnvStack8), (var_26: int64))
    else
        ()
and method_51((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_52
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_44((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_45
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env2)): bool =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_4((var_1: EnvStack0))
and method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env2>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env2) = var_1.[var_4]
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
            let (var_20: uint64) = (var_14 - var_18)
            var_0.Add((Env1(var_17, var_20)))
        else
            ()
        let (var_21: uint64) = (var_13 + var_8)
        let (var_22: int32) = (var_4 + 1)
        method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env2>), (var_2: int32), (var_21: uint64), (var_22: int32))
    else
        var_3
and method_8((var_0: EnvHeap4), (var_1: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvHeap5) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_12((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>), (var_4: uint64)): EnvStack0 =
    let (var_5: int32) = var_0.get_Count()
    let (var_6: bool) = (var_5 > 0)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_8: Env1) = var_0.[0]
    let (var_9: uint64) = var_8.mem_0
    let (var_10: uint64) = var_8.mem_1
    let (var_11: bool) = (var_4 <= var_10)
    let (var_41: Env2) =
        if var_11 then
            let (var_12: uint64) = (var_9 + var_4)
            let (var_13: uint64) = (var_10 - var_4)
            var_0.[0] <- (Env1(var_12, var_13))
            let (var_14: (uint64 ref)) = (ref var_9)
            let (var_15: EnvStack0) = EnvStack0((var_14: (uint64 ref)))
            (Env2(var_15, var_4))
        else
            let (var_17: (Env1 -> (Env1 -> int32))) = method_13
            let (var_18: System.Comparison<Env1>) = System.Comparison<Env1>(var_17)
            var_0.Sort(var_18)
            let (var_19: Env1) = var_0.[0]
            let (var_20: uint64) = var_19.mem_0
            let (var_21: uint64) = var_19.mem_1
            let (var_22: bool) = (var_4 <= var_21)
            if var_22 then
                let (var_23: uint64) = (var_20 + var_4)
                let (var_24: uint64) = (var_21 - var_4)
                var_0.[0] <- (Env1(var_23, var_24))
                let (var_25: (uint64 ref)) = (ref var_20)
                let (var_26: EnvStack0) = EnvStack0((var_25: (uint64 ref)))
                (Env2(var_26, var_4))
            else
                method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>))
                let (var_28: (Env1 -> (Env1 -> int32))) = method_13
                let (var_29: System.Comparison<Env1>) = System.Comparison<Env1>(var_28)
                var_0.Sort(var_29)
                let (var_30: Env1) = var_0.[0]
                let (var_31: uint64) = var_30.mem_0
                let (var_32: uint64) = var_30.mem_1
                let (var_33: bool) = (var_4 <= var_32)
                if var_33 then
                    let (var_34: uint64) = (var_31 + var_4)
                    let (var_35: uint64) = (var_32 - var_4)
                    var_0.[0] <- (Env1(var_34, var_35))
                    let (var_36: (uint64 ref)) = (ref var_31)
                    let (var_37: EnvStack0) = EnvStack0((var_36: (uint64 ref)))
                    (Env2(var_37, var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_42: EnvStack0) = var_41.mem_0
    let (var_43: uint64) = var_41.mem_1
    var_3.Add((Env2(var_42, var_43)))
    var_42
and method_15((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_21((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: int64)): float =
    let (var_21: bool) = (var_20 < 1L)
    if var_21 then
        let (var_22: bool) = (var_20 >= 0L)
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_24: int64) = (var_20 * 1048576L)
        if var_23 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (1048576L + var_24)
        let (var_26: EnvHeap7) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap7)
        let (var_27: EnvStack0) = var_26.mem_0
        let (var_28: uint64) = var_26.mem_1
        let (var_29: ResizeArray<Env1>) = var_26.mem_2
        let (var_30: ResizeArray<Env2>) = var_26.mem_3
        method_1((var_29: ResizeArray<Env1>), (var_27: EnvStack0), (var_28: uint64), (var_30: ResizeArray<Env2>))
        let (var_34: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_135: EnvHeap3) = var_0.mem_0
        let (var_136: int64) = 65536L
        let (var_137: EnvHeap3) = method_11((var_26: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_136: int64))
        let (var_138: EnvStack8) = EnvStack8((var_137: EnvHeap3))
        method_22((var_17: EnvStack8), (var_0: EnvStack8), (var_24: int64), (var_138: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_139: EnvHeap3) = var_138.mem_0
        let (var_140: int64) = 65536L
        let (var_141: EnvHeap3) = method_11((var_26: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_140: int64))
        let (var_142: EnvStack8) = EnvStack8((var_141: EnvHeap3))
        let (var_143: (int64 ref)) = var_11.mem_0
        let (var_144: EnvHeap5) = var_11.mem_1
        let (var_145: (bool ref)) = var_144.mem_0
        let (var_146: ManagedCuda.CudaStream) = var_144.mem_1
        let (var_147: ManagedCuda.BasicTypes.CUstream) = method_19((var_145: (bool ref)), (var_146: ManagedCuda.CudaStream))
        let (var_148: EnvHeap3) = var_142.mem_0
        let (var_149: (int64 ref)) = var_148.mem_0
        let (var_150: EnvStack0) = var_148.mem_1
        let (var_151: (uint64 ref)) = var_150.mem_0
        let (var_152: uint64) = method_5((var_151: (uint64 ref)))
        let (var_153: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_152)
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_153)
        let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_7.ClearMemoryAsync(var_154, 0uy, var_155, var_147)
        let (var_156: EnvHeap3) = var_15.mem_0
        let (var_157: (int64 ref)) = var_156.mem_0
        let (var_158: EnvStack0) = var_156.mem_1
        let (var_159: (uint64 ref)) = var_158.mem_0
        let (var_160: uint64) = method_5((var_159: (uint64 ref)))
        let (var_161: (int64 ref)) = var_139.mem_0
        let (var_162: EnvStack0) = var_139.mem_1
        let (var_163: (uint64 ref)) = var_162.mem_0
        let (var_164: uint64) = method_5((var_163: (uint64 ref)))
        let (var_165: uint64) = method_5((var_163: (uint64 ref)))
        // Cuda join point
        // method_23((var_160: uint64), (var_164: uint64), (var_165: uint64))
        let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_10, var_7)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_166.set_GridDimensions(var_167)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_166.set_BlockDimensions(var_168)
        let (var_169: ManagedCuda.BasicTypes.CUstream) = method_19((var_145: (bool ref)), (var_146: ManagedCuda.CudaStream))
        let (var_171: (System.Object [])) = [|var_160; var_164; var_165|]: (System.Object [])
        var_166.RunAsync(var_169, var_171)
        let (var_176: int64) = 65536L
        let (var_177: EnvHeap3) = method_11((var_26: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_176: int64))
        let (var_178: EnvStack8) = EnvStack8((var_177: EnvHeap3))
        let (var_179: uint64) = method_5((var_163: (uint64 ref)))
        let (var_180: EnvHeap3) = var_178.mem_0
        let (var_181: (int64 ref)) = var_180.mem_0
        let (var_182: EnvStack0) = var_180.mem_1
        let (var_183: (uint64 ref)) = var_182.mem_0
        let (var_184: uint64) = method_5((var_183: (uint64 ref)))
        // Cuda join point
        // method_24((var_179: uint64), (var_184: uint64))
        let (var_185: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_10, var_7)
        let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_185.set_GridDimensions(var_186)
        let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_185.set_BlockDimensions(var_187)
        let (var_188: ManagedCuda.BasicTypes.CUstream) = method_19((var_145: (bool ref)), (var_146: ManagedCuda.CudaStream))
        let (var_190: (System.Object [])) = [|var_179; var_184|]: (System.Object [])
        var_185.RunAsync(var_188, var_190)
        let (var_191: int64) = 65536L
        let (var_192: EnvHeap3) = method_11((var_26: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_191: int64))
        let (var_193: EnvStack8) = EnvStack8((var_192: EnvHeap3))
        let (var_194: ManagedCuda.BasicTypes.CUstream) = method_19((var_145: (bool ref)), (var_146: ManagedCuda.CudaStream))
        let (var_195: EnvHeap3) = var_193.mem_0
        let (var_196: (int64 ref)) = var_195.mem_0
        let (var_197: EnvStack0) = var_195.mem_1
        let (var_198: (uint64 ref)) = var_197.mem_0
        let (var_199: uint64) = method_5((var_198: (uint64 ref)))
        let (var_200: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_199)
        let (var_201: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_200)
        let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_7.ClearMemoryAsync(var_201, 0uy, var_202, var_194)
        let (var_203: uint64) = method_5((var_183: (uint64 ref)))
        let (var_204: (int64 ref)) = var_135.mem_0
        let (var_205: EnvStack0) = var_135.mem_1
        let (var_206: (uint64 ref)) = var_205.mem_0
        let (var_207: uint64) = method_5((var_206: (uint64 ref)))
        let (var_208: int64) = (var_25 * 4L)
        let (var_209: uint64) = (uint64 var_208)
        let (var_210: uint64) = (var_207 + var_209)
        let (var_219: int64) = 4L
        let (var_220: EnvHeap3) = method_11((var_26: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_219: int64))
        let (var_221: EnvStack8) = EnvStack8((var_220: EnvHeap3))
        let (var_222: EnvHeap3) = var_221.mem_0
        let (var_223: (int64 ref)) = var_222.mem_0
        let (var_224: EnvStack0) = var_222.mem_1
        let (var_225: (uint64 ref)) = var_224.mem_0
        let (var_226: uint64) = method_5((var_225: (uint64 ref)))
        // Cuda join point
        // method_26((var_203: uint64), (var_210: uint64), (var_226: uint64))
        let (var_227: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_10, var_7)
        let (var_228: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_227.set_GridDimensions(var_228)
        let (var_229: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_227.set_BlockDimensions(var_229)
        let (var_230: ManagedCuda.BasicTypes.CUstream) = method_19((var_145: (bool ref)), (var_146: ManagedCuda.CudaStream))
        let (var_232: (System.Object [])) = [|var_203; var_210; var_226|]: (System.Object [])
        var_227.RunAsync(var_230, var_232)
        let (var_233: (unit -> unit)) = method_28((var_142: EnvStack8), (var_138: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_0: EnvStack8), (var_24: int64), (var_16: EnvStack8), (var_17: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_193: EnvStack8), (var_178: EnvStack8), (var_221: EnvStack8), (var_25: int64))
        let (var_234: (unit -> float32)) = method_36((var_221: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_325: int64) = 1L
        method_43((var_0: EnvStack8), (var_24: int64), (var_25: int64), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_20: int64), (var_8: ResizeArray<EnvHeap3>), (var_234: (unit -> float32)), (var_233: (unit -> unit)), (var_193: EnvStack8), (var_178: EnvStack8), (var_325: int64))
    else
        let (var_327: float) = (float var_12)
        (var_13 / var_327)
and method_52 ((var_0: EnvHeap4)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvHeap5) = var_0.mem_1
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
and method_45 ((var_0: EnvHeap3)): unit =
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
and method_4 ((var_1: EnvStack0)) ((var_0: Env2)): int32 =
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
and method_13 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_22((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_19((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    var_4.set_Stream(var_20)
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_23: (float32 ref)) = (ref 1.000000f)
    let (var_24: EnvHeap3) = var_0.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: EnvHeap3) = var_1.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: int64) = (var_2 * 4L)
    let (var_37: uint64) = (uint64 var_36)
    let (var_38: uint64) = (var_35 + var_37)
    let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_38)
    let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_39)
    let (var_41: (float32 ref)) = (ref 0.000000f)
    let (var_42: EnvHeap3) = var_3.mem_0
    let (var_43: (int64 ref)) = var_42.mem_0
    let (var_44: EnvStack0) = var_42.mem_1
    let (var_45: (uint64 ref)) = var_44.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
    let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 128, 128, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_28 ((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: EnvStack0), (var_11: uint64), (var_12: ResizeArray<Env1>), (var_13: ResizeArray<Env2>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<EnvHeap3>), (var_16: ResizeArray<EnvHeap4>), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: EnvHeap4), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: int64)) (): unit =
    let (var_23: EnvHeap3) = var_21.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: EnvHeap3) = var_20.mem_0
    let (var_29: (int64 ref)) = var_28.mem_0
    let (var_30: EnvStack0) = var_28.mem_1
    let (var_31: (uint64 ref)) = var_30.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    let (var_33: EnvHeap3) = var_4.mem_0
    let (var_34: (int64 ref)) = var_33.mem_0
    let (var_35: EnvStack0) = var_33.mem_1
    let (var_36: (uint64 ref)) = var_35.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: int64) = (var_22 * 4L)
    let (var_39: uint64) = (uint64 var_38)
    let (var_40: uint64) = (var_37 + var_39)
    let (var_41: EnvHeap3) = var_19.mem_0
    let (var_42: (int64 ref)) = var_41.mem_0
    let (var_43: EnvStack0) = var_41.mem_1
    let (var_44: (uint64 ref)) = var_43.mem_0
    let (var_45: uint64) = method_5((var_44: (uint64 ref)))
    // Cuda join point
    // method_29((var_27: uint64), (var_32: uint64), (var_40: uint64), (var_45: uint64))
    let (var_46: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_17, var_14)
    let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_46.set_GridDimensions(var_47)
    let (var_48: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_46.set_BlockDimensions(var_48)
    let (var_49: (int64 ref)) = var_18.mem_0
    let (var_50: EnvHeap5) = var_18.mem_1
    let (var_51: (bool ref)) = var_50.mem_0
    let (var_52: ManagedCuda.CudaStream) = var_50.mem_1
    let (var_53: ManagedCuda.BasicTypes.CUstream) = method_19((var_51: (bool ref)), (var_52: ManagedCuda.CudaStream))
    let (var_55: (System.Object [])) = [|var_27; var_32; var_40; var_45|]: (System.Object [])
    var_46.RunAsync(var_53, var_55)
    let (var_56: EnvHeap3) = var_1.mem_0
    let (var_57: (int64 ref)) = var_56.mem_0
    let (var_58: EnvStack0) = var_56.mem_1
    let (var_59: (uint64 ref)) = var_58.mem_0
    let (var_60: uint64) = method_5((var_59: (uint64 ref)))
    let (var_61: uint64) = method_5((var_44: (uint64 ref)))
    let (var_62: uint64) = method_5((var_31: (uint64 ref)))
    let (var_63: EnvHeap3) = var_0.mem_0
    let (var_64: (int64 ref)) = var_63.mem_0
    let (var_65: EnvStack0) = var_63.mem_1
    let (var_66: (uint64 ref)) = var_65.mem_0
    let (var_67: uint64) = method_5((var_66: (uint64 ref)))
    // Cuda join point
    // method_30((var_60: uint64), (var_61: uint64), (var_62: uint64), (var_67: uint64))
    let (var_68: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_17, var_14)
    let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_68.set_GridDimensions(var_69)
    let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_68.set_BlockDimensions(var_70)
    let (var_71: ManagedCuda.BasicTypes.CUstream) = method_19((var_51: (bool ref)), (var_52: ManagedCuda.CudaStream))
    let (var_73: (System.Object [])) = [|var_60; var_61; var_62; var_67|]: (System.Object [])
    var_68.RunAsync(var_71, var_73)
    method_31((var_0: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: EnvStack0), (var_11: uint64), (var_12: ResizeArray<Env1>), (var_13: ResizeArray<Env2>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<EnvHeap3>), (var_16: ResizeArray<EnvHeap4>), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: EnvHeap4))
    let (var_74: uint64) = method_5((var_66: (uint64 ref)))
    let (var_75: EnvHeap3) = var_2.mem_0
    let (var_76: (int64 ref)) = var_75.mem_0
    let (var_77: EnvStack0) = var_75.mem_1
    let (var_78: (uint64 ref)) = var_77.mem_0
    let (var_79: uint64) = method_5((var_78: (uint64 ref)))
    // Cuda join point
    // method_32((var_74: uint64), (var_79: uint64))
    let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_17, var_14)
    let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_80.set_GridDimensions(var_81)
    let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_80.set_BlockDimensions(var_82)
    let (var_83: ManagedCuda.BasicTypes.CUstream) = method_19((var_51: (bool ref)), (var_52: ManagedCuda.CudaStream))
    let (var_85: (System.Object [])) = [|var_74; var_79|]: (System.Object [])
    var_80.RunAsync(var_83, var_85)
and method_36 ((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4)) (): float32 =
    let (var_12: int64) = 1L
    let (var_13: int64) = 0L
    let (var_14: (float32 [])) = method_37((var_12: int64), (var_0: EnvStack8), (var_13: int64))
    var_14.[int32 0L]
and method_43((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_20: int64), (var_21: float), (var_22: int64), (var_23: ResizeArray<EnvHeap3>), (var_24: (unit -> float32)), (var_25: (unit -> unit)), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: int64)): float =
    let (var_29: bool) = (var_28 < 64L)
    if var_29 then
        let (var_30: bool) = (var_28 >= 0L)
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_32: int64) = (var_28 * 16384L)
        let (var_33: int64) = (var_1 + var_32)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_34: int64) = (var_2 + var_32)
        let (var_35: EnvHeap3) = var_0.mem_0
        let (var_36: int64) = 65536L
        let (var_37: EnvHeap7) = ({mem_0 = (var_11: EnvStack0); mem_1 = (var_12: uint64); mem_2 = (var_13: ResizeArray<Env1>); mem_3 = (var_14: ResizeArray<Env2>)} : EnvHeap7)
        let (var_38: EnvHeap3) = method_11((var_37: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_36: int64))
        let (var_39: EnvStack8) = EnvStack8((var_38: EnvHeap3))
        method_22((var_6: EnvStack8), (var_0: EnvStack8), (var_33: int64), (var_39: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4))
        let (var_40: EnvHeap3) = var_39.mem_0
        let (var_41: int64) = 65536L
        let (var_42: EnvHeap3) = method_11((var_37: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_41: int64))
        let (var_43: EnvStack8) = EnvStack8((var_42: EnvHeap3))
        let (var_44: (int64 ref)) = var_19.mem_0
        let (var_45: EnvHeap5) = var_19.mem_1
        let (var_46: (bool ref)) = var_45.mem_0
        let (var_47: ManagedCuda.CudaStream) = var_45.mem_1
        let (var_48: ManagedCuda.BasicTypes.CUstream) = method_19((var_46: (bool ref)), (var_47: ManagedCuda.CudaStream))
        let (var_49: EnvHeap3) = var_43.mem_0
        let (var_50: (int64 ref)) = var_49.mem_0
        let (var_51: EnvStack0) = var_49.mem_1
        let (var_52: (uint64 ref)) = var_51.mem_0
        let (var_53: uint64) = method_5((var_52: (uint64 ref)))
        let (var_54: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_53)
        let (var_55: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_54)
        let (var_56: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_15.ClearMemoryAsync(var_55, 0uy, var_56, var_48)
        method_38((var_8: EnvStack8), (var_27: EnvStack8), (var_39: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4))
        let (var_57: EnvHeap3) = var_4.mem_0
        let (var_58: (int64 ref)) = var_57.mem_0
        let (var_59: EnvStack0) = var_57.mem_1
        let (var_60: (uint64 ref)) = var_59.mem_0
        let (var_61: uint64) = method_5((var_60: (uint64 ref)))
        let (var_62: (int64 ref)) = var_40.mem_0
        let (var_63: EnvStack0) = var_40.mem_1
        let (var_64: (uint64 ref)) = var_63.mem_0
        let (var_65: uint64) = method_5((var_64: (uint64 ref)))
        let (var_66: uint64) = method_5((var_64: (uint64 ref)))
        // Cuda join point
        // method_23((var_61: uint64), (var_65: uint64), (var_66: uint64))
        let (var_67: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_18, var_15)
        let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_67.set_GridDimensions(var_68)
        let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_67.set_BlockDimensions(var_69)
        let (var_70: ManagedCuda.BasicTypes.CUstream) = method_19((var_46: (bool ref)), (var_47: ManagedCuda.CudaStream))
        let (var_72: (System.Object [])) = [|var_61; var_65; var_66|]: (System.Object [])
        var_67.RunAsync(var_70, var_72)
        let (var_77: int64) = 65536L
        let (var_78: EnvHeap3) = method_11((var_37: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_77: int64))
        let (var_79: EnvStack8) = EnvStack8((var_78: EnvHeap3))
        let (var_80: uint64) = method_5((var_64: (uint64 ref)))
        let (var_81: EnvHeap3) = var_79.mem_0
        let (var_82: (int64 ref)) = var_81.mem_0
        let (var_83: EnvStack0) = var_81.mem_1
        let (var_84: (uint64 ref)) = var_83.mem_0
        let (var_85: uint64) = method_5((var_84: (uint64 ref)))
        // Cuda join point
        // method_24((var_80: uint64), (var_85: uint64))
        let (var_86: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_18, var_15)
        let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_86.set_GridDimensions(var_87)
        let (var_88: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_86.set_BlockDimensions(var_88)
        let (var_89: ManagedCuda.BasicTypes.CUstream) = method_19((var_46: (bool ref)), (var_47: ManagedCuda.CudaStream))
        let (var_91: (System.Object [])) = [|var_80; var_85|]: (System.Object [])
        var_86.RunAsync(var_89, var_91)
        let (var_92: int64) = 65536L
        let (var_93: EnvHeap3) = method_11((var_37: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_92: int64))
        let (var_94: EnvStack8) = EnvStack8((var_93: EnvHeap3))
        let (var_95: ManagedCuda.BasicTypes.CUstream) = method_19((var_46: (bool ref)), (var_47: ManagedCuda.CudaStream))
        let (var_96: EnvHeap3) = var_94.mem_0
        let (var_97: (int64 ref)) = var_96.mem_0
        let (var_98: EnvStack0) = var_96.mem_1
        let (var_99: (uint64 ref)) = var_98.mem_0
        let (var_100: uint64) = method_5((var_99: (uint64 ref)))
        let (var_101: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_100)
        let (var_102: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_101)
        let (var_103: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_15.ClearMemoryAsync(var_102, 0uy, var_103, var_95)
        let (var_104: uint64) = method_5((var_84: (uint64 ref)))
        let (var_105: (int64 ref)) = var_35.mem_0
        let (var_106: EnvStack0) = var_35.mem_1
        let (var_107: (uint64 ref)) = var_106.mem_0
        let (var_108: uint64) = method_5((var_107: (uint64 ref)))
        let (var_109: int64) = (var_34 * 4L)
        let (var_110: uint64) = (uint64 var_109)
        let (var_111: uint64) = (var_108 + var_110)
        let (var_120: int64) = 4L
        let (var_121: EnvHeap3) = method_11((var_37: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_120: int64))
        let (var_122: EnvStack8) = EnvStack8((var_121: EnvHeap3))
        let (var_123: EnvHeap3) = var_122.mem_0
        let (var_124: (int64 ref)) = var_123.mem_0
        let (var_125: EnvStack0) = var_123.mem_1
        let (var_126: (uint64 ref)) = var_125.mem_0
        let (var_127: uint64) = method_5((var_126: (uint64 ref)))
        // Cuda join point
        // method_26((var_104: uint64), (var_111: uint64), (var_127: uint64))
        let (var_128: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_18, var_15)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_128.set_GridDimensions(var_129)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_128.set_BlockDimensions(var_130)
        let (var_131: ManagedCuda.BasicTypes.CUstream) = method_19((var_46: (bool ref)), (var_47: ManagedCuda.CudaStream))
        let (var_133: (System.Object [])) = [|var_104; var_111; var_127|]: (System.Object [])
        var_128.RunAsync(var_131, var_133)
        let (var_134: (unit -> unit)) = method_39((var_25: (unit -> unit)), (var_43: EnvStack8), (var_39: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_0: EnvStack8), (var_33: int64), (var_5: EnvStack8), (var_6: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_94: EnvStack8), (var_79: EnvStack8), (var_122: EnvStack8), (var_34: int64))
        let (var_135: (unit -> float32)) = method_42((var_122: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_24: (unit -> float32)))
        let (var_136: int64) = (var_28 + 1L)
        method_43((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_20: int64), (var_21: float), (var_22: int64), (var_23: ResizeArray<EnvHeap3>), (var_135: (unit -> float32)), (var_134: (unit -> unit)), (var_94: EnvStack8), (var_79: EnvStack8), (var_136: int64))
    else
        let (var_138: float32) = var_24()
        let (var_139: float) = (float var_138)
        let (var_140: float) = (var_21 + var_139)
        let (var_149: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_150: EnvHeap3) = var_27.mem_0
        method_15((var_150: EnvHeap3), (var_149: ResizeArray<EnvHeap3>))
        let (var_151: int64) = (var_20 + 1L)
        if (System.Double.IsNaN var_140) then
            method_44((var_16: ResizeArray<EnvHeap3>))
            method_44((var_149: ResizeArray<EnvHeap3>))
            let (var_152: float) = (float var_151)
            (var_140 / var_152)
        else
            var_25()
            let (var_154: EnvHeap3) = var_4.mem_0
            let (var_155: (int64 ref)) = var_154.mem_0
            let (var_156: EnvStack0) = var_154.mem_1
            let (var_157: (uint64 ref)) = var_156.mem_0
            let (var_158: uint64) = method_5((var_157: (uint64 ref)))
            let (var_159: EnvHeap3) = var_3.mem_0
            let (var_160: (int64 ref)) = var_159.mem_0
            let (var_161: EnvStack0) = var_159.mem_1
            let (var_162: (uint64 ref)) = var_161.mem_0
            let (var_163: uint64) = method_5((var_162: (uint64 ref)))
            // Cuda join point
            // method_46((var_158: uint64), (var_163: uint64))
            let (var_164: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_46", var_18, var_15)
            let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_164.set_GridDimensions(var_165)
            let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_164.set_BlockDimensions(var_166)
            let (var_167: (int64 ref)) = var_19.mem_0
            let (var_168: EnvHeap5) = var_19.mem_1
            let (var_169: (bool ref)) = var_168.mem_0
            let (var_170: ManagedCuda.CudaStream) = var_168.mem_1
            let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
            let (var_173: (System.Object [])) = [|var_158; var_163|]: (System.Object [])
            var_164.RunAsync(var_171, var_173)
            let (var_174: EnvHeap3) = var_6.mem_0
            let (var_175: (int64 ref)) = var_174.mem_0
            let (var_176: EnvStack0) = var_174.mem_1
            let (var_177: (uint64 ref)) = var_176.mem_0
            let (var_178: uint64) = method_5((var_177: (uint64 ref)))
            let (var_179: EnvHeap3) = var_5.mem_0
            let (var_180: (int64 ref)) = var_179.mem_0
            let (var_181: EnvStack0) = var_179.mem_1
            let (var_182: (uint64 ref)) = var_181.mem_0
            let (var_183: uint64) = method_5((var_182: (uint64 ref)))
            // Cuda join point
            // method_47((var_178: uint64), (var_183: uint64))
            let (var_184: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_18, var_15)
            let (var_185: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_184.set_GridDimensions(var_185)
            let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_184.set_BlockDimensions(var_186)
            let (var_187: ManagedCuda.BasicTypes.CUstream) = method_19((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
            let (var_189: (System.Object [])) = [|var_178; var_183|]: (System.Object [])
            var_184.RunAsync(var_187, var_189)
            let (var_190: EnvHeap3) = var_8.mem_0
            let (var_191: (int64 ref)) = var_190.mem_0
            let (var_192: EnvStack0) = var_190.mem_1
            let (var_193: (uint64 ref)) = var_192.mem_0
            let (var_194: uint64) = method_5((var_193: (uint64 ref)))
            let (var_195: EnvHeap3) = var_7.mem_0
            let (var_196: (int64 ref)) = var_195.mem_0
            let (var_197: EnvStack0) = var_195.mem_1
            let (var_198: (uint64 ref)) = var_197.mem_0
            let (var_199: uint64) = method_5((var_198: (uint64 ref)))
            // Cuda join point
            // method_47((var_194: uint64), (var_199: uint64))
            let (var_200: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_18, var_15)
            let (var_201: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_200.set_GridDimensions(var_201)
            let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_200.set_BlockDimensions(var_202)
            let (var_203: ManagedCuda.BasicTypes.CUstream) = method_19((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
            let (var_205: (System.Object [])) = [|var_194; var_199|]: (System.Object [])
            var_200.RunAsync(var_203, var_205)
            method_44((var_16: ResizeArray<EnvHeap3>))
            let (var_206: int64) = (var_22 + 1L)
            method_48((var_0: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_23: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_151: int64), (var_140: float), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_149: ResizeArray<EnvHeap3>), (var_27: EnvStack8), (var_206: int64))
and method_14 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
and method_31((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_19((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    var_4.set_Stream(var_20)
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_23: (float32 ref)) = (ref 1.000000f)
    let (var_24: EnvHeap3) = var_0.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: EnvHeap3) = var_1.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: int64) = (var_2 * 4L)
    let (var_37: uint64) = (uint64 var_36)
    let (var_38: uint64) = (var_35 + var_37)
    let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_38)
    let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_39)
    let (var_41: (float32 ref)) = (ref 1.000000f)
    let (var_42: EnvHeap3) = var_3.mem_0
    let (var_43: (int64 ref)) = var_42.mem_0
    let (var_44: EnvStack0) = var_42.mem_1
    let (var_45: (uint64 ref)) = var_44.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
    let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 128, 128, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_37((var_0: int64), (var_1: EnvStack8), (var_2: int64)): (float32 []) =
    let (var_3: EnvHeap3) = var_1.mem_0
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
and method_38((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_3.get_CublasHandle()
    let (var_15: (int64 ref)) = var_13.mem_0
    let (var_16: EnvHeap5) = var_13.mem_1
    let (var_17: (bool ref)) = var_16.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_19((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_3.set_Stream(var_19)
    let (var_20: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: EnvHeap3) = var_0.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: EnvHeap3) = var_1.mem_0
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: EnvStack0) = var_30.mem_1
    let (var_33: (uint64 ref)) = var_32.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_34)
    let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_35)
    let (var_37: (float32 ref)) = (ref 1.000000f)
    let (var_38: EnvHeap3) = var_2.mem_0
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: EnvStack0) = var_38.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_42)
    let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_43)
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 128, 128, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_39 ((var_0: (unit -> unit)), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: int64)) (): unit =
    let (var_28: EnvHeap3) = var_26.mem_0
    let (var_29: (int64 ref)) = var_28.mem_0
    let (var_30: EnvStack0) = var_28.mem_1
    let (var_31: (uint64 ref)) = var_30.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    let (var_33: EnvHeap3) = var_25.mem_0
    let (var_34: (int64 ref)) = var_33.mem_0
    let (var_35: EnvStack0) = var_33.mem_1
    let (var_36: (uint64 ref)) = var_35.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: EnvHeap3) = var_5.mem_0
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: EnvStack0) = var_38.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: int64) = (var_27 * 4L)
    let (var_44: uint64) = (uint64 var_43)
    let (var_45: uint64) = (var_42 + var_44)
    let (var_46: EnvHeap3) = var_24.mem_0
    let (var_47: (int64 ref)) = var_46.mem_0
    let (var_48: EnvStack0) = var_46.mem_1
    let (var_49: (uint64 ref)) = var_48.mem_0
    let (var_50: uint64) = method_5((var_49: (uint64 ref)))
    // Cuda join point
    // method_29((var_32: uint64), (var_37: uint64), (var_45: uint64), (var_50: uint64))
    let (var_51: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_22, var_19)
    let (var_52: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_51.set_GridDimensions(var_52)
    let (var_53: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_51.set_BlockDimensions(var_53)
    let (var_54: (int64 ref)) = var_23.mem_0
    let (var_55: EnvHeap5) = var_23.mem_1
    let (var_56: (bool ref)) = var_55.mem_0
    let (var_57: ManagedCuda.CudaStream) = var_55.mem_1
    let (var_58: ManagedCuda.BasicTypes.CUstream) = method_19((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
    let (var_60: (System.Object [])) = [|var_32; var_37; var_45; var_50|]: (System.Object [])
    var_51.RunAsync(var_58, var_60)
    let (var_61: EnvHeap3) = var_2.mem_0
    let (var_62: (int64 ref)) = var_61.mem_0
    let (var_63: EnvStack0) = var_61.mem_1
    let (var_64: (uint64 ref)) = var_63.mem_0
    let (var_65: uint64) = method_5((var_64: (uint64 ref)))
    let (var_66: uint64) = method_5((var_49: (uint64 ref)))
    let (var_67: uint64) = method_5((var_36: (uint64 ref)))
    let (var_68: EnvHeap3) = var_1.mem_0
    let (var_69: (int64 ref)) = var_68.mem_0
    let (var_70: EnvStack0) = var_68.mem_1
    let (var_71: (uint64 ref)) = var_70.mem_0
    let (var_72: uint64) = method_5((var_71: (uint64 ref)))
    // Cuda join point
    // method_30((var_65: uint64), (var_66: uint64), (var_67: uint64), (var_72: uint64))
    let (var_73: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_22, var_19)
    let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_73.set_GridDimensions(var_74)
    let (var_75: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_73.set_BlockDimensions(var_75)
    let (var_76: ManagedCuda.BasicTypes.CUstream) = method_19((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
    let (var_78: (System.Object [])) = [|var_65; var_66; var_67; var_72|]: (System.Object [])
    var_73.RunAsync(var_76, var_78)
    method_31((var_1: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_7: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_40((var_12: EnvStack8), (var_1: EnvStack8), (var_9: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_41((var_1: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    let (var_79: uint64) = method_5((var_71: (uint64 ref)))
    let (var_80: EnvHeap3) = var_3.mem_0
    let (var_81: (int64 ref)) = var_80.mem_0
    let (var_82: EnvStack0) = var_80.mem_1
    let (var_83: (uint64 ref)) = var_82.mem_0
    let (var_84: uint64) = method_5((var_83: (uint64 ref)))
    // Cuda join point
    // method_32((var_79: uint64), (var_84: uint64))
    let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_22, var_19)
    let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_85.set_GridDimensions(var_86)
    let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_85.set_BlockDimensions(var_87)
    let (var_88: ManagedCuda.BasicTypes.CUstream) = method_19((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
    let (var_90: (System.Object [])) = [|var_79; var_84|]: (System.Object [])
    var_85.RunAsync(var_88, var_90)
    var_0()
and method_42 ((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: (unit -> float32))) (): float32 =
    let (var_13: float32) = var_12()
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_37((var_14: int64), (var_0: EnvStack8), (var_15: int64))
    let (var_17: float32) = var_16.[int32 0L]
    (var_13 + var_17)
and method_48((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: ResizeArray<EnvHeap3>), (var_21: EnvStack8), (var_22: int64)): float =
    let (var_23: bool) = (var_22 < 1L)
    if var_23 then
        let (var_24: bool) = (var_22 >= 0L)
        let (var_25: bool) = (var_24 = false)
        if var_25 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_26: int64) = (var_22 * 1048576L)
        if var_25 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_27: int64) = (1048576L + var_26)
        let (var_28: EnvHeap7) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap7)
        let (var_29: EnvStack0) = var_28.mem_0
        let (var_30: uint64) = var_28.mem_1
        let (var_31: ResizeArray<Env1>) = var_28.mem_2
        let (var_32: ResizeArray<Env2>) = var_28.mem_3
        method_1((var_31: ResizeArray<Env1>), (var_29: EnvStack0), (var_30: uint64), (var_32: ResizeArray<Env2>))
        let (var_36: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_137: EnvHeap3) = var_0.mem_0
        let (var_138: int64) = 65536L
        let (var_139: EnvHeap3) = method_11((var_28: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_138: int64))
        let (var_140: EnvStack8) = EnvStack8((var_139: EnvHeap3))
        method_22((var_17: EnvStack8), (var_0: EnvStack8), (var_26: int64), (var_140: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_141: EnvHeap3) = var_140.mem_0
        let (var_142: int64) = 65536L
        let (var_143: EnvHeap3) = method_11((var_28: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_142: int64))
        let (var_144: EnvStack8) = EnvStack8((var_143: EnvHeap3))
        let (var_145: (int64 ref)) = var_11.mem_0
        let (var_146: EnvHeap5) = var_11.mem_1
        let (var_147: (bool ref)) = var_146.mem_0
        let (var_148: ManagedCuda.CudaStream) = var_146.mem_1
        let (var_149: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
        let (var_150: EnvHeap3) = var_144.mem_0
        let (var_151: (int64 ref)) = var_150.mem_0
        let (var_152: EnvStack0) = var_150.mem_1
        let (var_153: (uint64 ref)) = var_152.mem_0
        let (var_154: uint64) = method_5((var_153: (uint64 ref)))
        let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_154)
        let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_155)
        let (var_157: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_7.ClearMemoryAsync(var_156, 0uy, var_157, var_149)
        method_38((var_19: EnvStack8), (var_21: EnvStack8), (var_140: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_158: EnvHeap3) = var_15.mem_0
        let (var_159: (int64 ref)) = var_158.mem_0
        let (var_160: EnvStack0) = var_158.mem_1
        let (var_161: (uint64 ref)) = var_160.mem_0
        let (var_162: uint64) = method_5((var_161: (uint64 ref)))
        let (var_163: (int64 ref)) = var_141.mem_0
        let (var_164: EnvStack0) = var_141.mem_1
        let (var_165: (uint64 ref)) = var_164.mem_0
        let (var_166: uint64) = method_5((var_165: (uint64 ref)))
        let (var_167: uint64) = method_5((var_165: (uint64 ref)))
        // Cuda join point
        // method_23((var_162: uint64), (var_166: uint64), (var_167: uint64))
        let (var_168: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_10, var_7)
        let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_168.set_GridDimensions(var_169)
        let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_168.set_BlockDimensions(var_170)
        let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
        let (var_173: (System.Object [])) = [|var_162; var_166; var_167|]: (System.Object [])
        var_168.RunAsync(var_171, var_173)
        let (var_178: int64) = 65536L
        let (var_179: EnvHeap3) = method_11((var_28: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_178: int64))
        let (var_180: EnvStack8) = EnvStack8((var_179: EnvHeap3))
        let (var_181: uint64) = method_5((var_165: (uint64 ref)))
        let (var_182: EnvHeap3) = var_180.mem_0
        let (var_183: (int64 ref)) = var_182.mem_0
        let (var_184: EnvStack0) = var_182.mem_1
        let (var_185: (uint64 ref)) = var_184.mem_0
        let (var_186: uint64) = method_5((var_185: (uint64 ref)))
        // Cuda join point
        // method_24((var_181: uint64), (var_186: uint64))
        let (var_187: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_10, var_7)
        let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_187.set_GridDimensions(var_188)
        let (var_189: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_187.set_BlockDimensions(var_189)
        let (var_190: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
        let (var_192: (System.Object [])) = [|var_181; var_186|]: (System.Object [])
        var_187.RunAsync(var_190, var_192)
        let (var_193: int64) = 65536L
        let (var_194: EnvHeap3) = method_11((var_28: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_193: int64))
        let (var_195: EnvStack8) = EnvStack8((var_194: EnvHeap3))
        let (var_196: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
        let (var_197: EnvHeap3) = var_195.mem_0
        let (var_198: (int64 ref)) = var_197.mem_0
        let (var_199: EnvStack0) = var_197.mem_1
        let (var_200: (uint64 ref)) = var_199.mem_0
        let (var_201: uint64) = method_5((var_200: (uint64 ref)))
        let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_201)
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_202)
        let (var_204: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_7.ClearMemoryAsync(var_203, 0uy, var_204, var_196)
        let (var_205: uint64) = method_5((var_185: (uint64 ref)))
        let (var_206: (int64 ref)) = var_137.mem_0
        let (var_207: EnvStack0) = var_137.mem_1
        let (var_208: (uint64 ref)) = var_207.mem_0
        let (var_209: uint64) = method_5((var_208: (uint64 ref)))
        let (var_210: int64) = (var_27 * 4L)
        let (var_211: uint64) = (uint64 var_210)
        let (var_212: uint64) = (var_209 + var_211)
        let (var_221: int64) = 4L
        let (var_222: EnvHeap3) = method_11((var_28: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_221: int64))
        let (var_223: EnvStack8) = EnvStack8((var_222: EnvHeap3))
        let (var_224: EnvHeap3) = var_223.mem_0
        let (var_225: (int64 ref)) = var_224.mem_0
        let (var_226: EnvStack0) = var_224.mem_1
        let (var_227: (uint64 ref)) = var_226.mem_0
        let (var_228: uint64) = method_5((var_227: (uint64 ref)))
        // Cuda join point
        // method_26((var_205: uint64), (var_212: uint64), (var_228: uint64))
        let (var_229: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_10, var_7)
        let (var_230: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_229.set_GridDimensions(var_230)
        let (var_231: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_229.set_BlockDimensions(var_231)
        let (var_232: ManagedCuda.BasicTypes.CUstream) = method_19((var_147: (bool ref)), (var_148: ManagedCuda.CudaStream))
        let (var_234: (System.Object [])) = [|var_205; var_212; var_228|]: (System.Object [])
        var_229.RunAsync(var_232, var_234)
        let (var_235: (unit -> unit)) = method_49((var_144: EnvStack8), (var_140: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_0: EnvStack8), (var_26: int64), (var_16: EnvStack8), (var_17: EnvStack8), (var_21: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_195: EnvStack8), (var_180: EnvStack8), (var_223: EnvStack8), (var_27: int64))
        let (var_236: (unit -> float32)) = method_36((var_223: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_327: int64) = 1L
        method_50((var_0: EnvStack8), (var_26: int64), (var_27: int64), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_36: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_22: int64), (var_8: ResizeArray<EnvHeap3>), (var_20: ResizeArray<EnvHeap3>), (var_236: (unit -> float32)), (var_235: (unit -> unit)), (var_195: EnvStack8), (var_180: EnvStack8), (var_327: int64))
    else
        method_44((var_20: ResizeArray<EnvHeap3>))
        let (var_329: float) = (float var_12)
        (var_13 / var_329)
and method_40((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_3.get_CublasHandle()
    let (var_15: (int64 ref)) = var_13.mem_0
    let (var_16: EnvHeap5) = var_13.mem_1
    let (var_17: (bool ref)) = var_16.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_19((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_3.set_Stream(var_19)
    let (var_20: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: EnvHeap3) = var_0.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: EnvHeap3) = var_1.mem_0
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: EnvStack0) = var_30.mem_1
    let (var_33: (uint64 ref)) = var_32.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_34)
    let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_35)
    let (var_37: (float32 ref)) = (ref 1.000000f)
    let (var_38: EnvHeap3) = var_2.mem_0
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: EnvStack0) = var_38.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_42)
    let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_43)
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 128, 128, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_41((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_3.get_CublasHandle()
    let (var_15: (int64 ref)) = var_13.mem_0
    let (var_16: EnvHeap5) = var_13.mem_1
    let (var_17: (bool ref)) = var_16.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_19((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_3.set_Stream(var_19)
    let (var_20: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_22: (float32 ref)) = (ref 1.000000f)
    let (var_23: EnvHeap3) = var_0.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: EnvHeap3) = var_1.mem_0
    let (var_31: (int64 ref)) = var_30.mem_0
    let (var_32: EnvStack0) = var_30.mem_1
    let (var_33: (uint64 ref)) = var_32.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_34)
    let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_35)
    let (var_37: (float32 ref)) = (ref 1.000000f)
    let (var_38: EnvHeap3) = var_2.mem_0
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: EnvStack0) = var_38.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_42)
    let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_43)
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 128, 128, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_49 ((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: int64)) (): unit =
    let (var_26: EnvHeap3) = var_24.mem_0
    let (var_27: (int64 ref)) = var_26.mem_0
    let (var_28: EnvStack0) = var_26.mem_1
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: EnvHeap3) = var_23.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: EnvHeap3) = var_4.mem_0
    let (var_37: (int64 ref)) = var_36.mem_0
    let (var_38: EnvStack0) = var_36.mem_1
    let (var_39: (uint64 ref)) = var_38.mem_0
    let (var_40: uint64) = method_5((var_39: (uint64 ref)))
    let (var_41: int64) = (var_25 * 4L)
    let (var_42: uint64) = (uint64 var_41)
    let (var_43: uint64) = (var_40 + var_42)
    let (var_44: EnvHeap3) = var_22.mem_0
    let (var_45: (int64 ref)) = var_44.mem_0
    let (var_46: EnvStack0) = var_44.mem_1
    let (var_47: (uint64 ref)) = var_46.mem_0
    let (var_48: uint64) = method_5((var_47: (uint64 ref)))
    // Cuda join point
    // method_29((var_30: uint64), (var_35: uint64), (var_43: uint64), (var_48: uint64))
    let (var_49: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_20, var_17)
    let (var_50: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_49.set_GridDimensions(var_50)
    let (var_51: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_49.set_BlockDimensions(var_51)
    let (var_52: (int64 ref)) = var_21.mem_0
    let (var_53: EnvHeap5) = var_21.mem_1
    let (var_54: (bool ref)) = var_53.mem_0
    let (var_55: ManagedCuda.CudaStream) = var_53.mem_1
    let (var_56: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_58: (System.Object [])) = [|var_30; var_35; var_43; var_48|]: (System.Object [])
    var_49.RunAsync(var_56, var_58)
    let (var_59: EnvHeap3) = var_1.mem_0
    let (var_60: (int64 ref)) = var_59.mem_0
    let (var_61: EnvStack0) = var_59.mem_1
    let (var_62: (uint64 ref)) = var_61.mem_0
    let (var_63: uint64) = method_5((var_62: (uint64 ref)))
    let (var_64: uint64) = method_5((var_47: (uint64 ref)))
    let (var_65: uint64) = method_5((var_34: (uint64 ref)))
    let (var_66: EnvHeap3) = var_0.mem_0
    let (var_67: (int64 ref)) = var_66.mem_0
    let (var_68: EnvStack0) = var_66.mem_1
    let (var_69: (uint64 ref)) = var_68.mem_0
    let (var_70: uint64) = method_5((var_69: (uint64 ref)))
    // Cuda join point
    // method_30((var_63: uint64), (var_64: uint64), (var_65: uint64), (var_70: uint64))
    let (var_71: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_20, var_17)
    let (var_72: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_71.set_GridDimensions(var_72)
    let (var_73: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_71.set_BlockDimensions(var_73)
    let (var_74: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_76: (System.Object [])) = [|var_63; var_64; var_65; var_70|]: (System.Object [])
    var_71.RunAsync(var_74, var_76)
    method_31((var_0: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    method_41((var_0: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    let (var_77: uint64) = method_5((var_69: (uint64 ref)))
    let (var_78: EnvHeap3) = var_2.mem_0
    let (var_79: (int64 ref)) = var_78.mem_0
    let (var_80: EnvStack0) = var_78.mem_1
    let (var_81: (uint64 ref)) = var_80.mem_0
    let (var_82: uint64) = method_5((var_81: (uint64 ref)))
    // Cuda join point
    // method_32((var_77: uint64), (var_82: uint64))
    let (var_83: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_20, var_17)
    let (var_84: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_83.set_GridDimensions(var_84)
    let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_83.set_BlockDimensions(var_85)
    let (var_86: ManagedCuda.BasicTypes.CUstream) = method_19((var_54: (bool ref)), (var_55: ManagedCuda.CudaStream))
    let (var_88: (System.Object [])) = [|var_77; var_82|]: (System.Object [])
    var_83.RunAsync(var_86, var_88)
and method_50((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_20: int64), (var_21: float), (var_22: int64), (var_23: ResizeArray<EnvHeap3>), (var_24: ResizeArray<EnvHeap3>), (var_25: (unit -> float32)), (var_26: (unit -> unit)), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: int64)): float =
    let (var_30: bool) = (var_29 < 64L)
    if var_30 then
        let (var_31: bool) = (var_29 >= 0L)
        let (var_32: bool) = (var_31 = false)
        if var_32 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_33: int64) = (var_29 * 16384L)
        let (var_34: int64) = (var_1 + var_33)
        if var_32 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_35: int64) = (var_2 + var_33)
        let (var_36: EnvHeap3) = var_0.mem_0
        let (var_37: int64) = 65536L
        let (var_38: EnvHeap7) = ({mem_0 = (var_11: EnvStack0); mem_1 = (var_12: uint64); mem_2 = (var_13: ResizeArray<Env1>); mem_3 = (var_14: ResizeArray<Env2>)} : EnvHeap7)
        let (var_39: EnvHeap3) = method_11((var_38: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_37: int64))
        let (var_40: EnvStack8) = EnvStack8((var_39: EnvHeap3))
        method_22((var_6: EnvStack8), (var_0: EnvStack8), (var_34: int64), (var_40: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4))
        let (var_41: EnvHeap3) = var_40.mem_0
        let (var_42: int64) = 65536L
        let (var_43: EnvHeap3) = method_11((var_38: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_42: int64))
        let (var_44: EnvStack8) = EnvStack8((var_43: EnvHeap3))
        let (var_45: (int64 ref)) = var_19.mem_0
        let (var_46: EnvHeap5) = var_19.mem_1
        let (var_47: (bool ref)) = var_46.mem_0
        let (var_48: ManagedCuda.CudaStream) = var_46.mem_1
        let (var_49: ManagedCuda.BasicTypes.CUstream) = method_19((var_47: (bool ref)), (var_48: ManagedCuda.CudaStream))
        let (var_50: EnvHeap3) = var_44.mem_0
        let (var_51: (int64 ref)) = var_50.mem_0
        let (var_52: EnvStack0) = var_50.mem_1
        let (var_53: (uint64 ref)) = var_52.mem_0
        let (var_54: uint64) = method_5((var_53: (uint64 ref)))
        let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_54)
        let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_55)
        let (var_57: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_15.ClearMemoryAsync(var_56, 0uy, var_57, var_49)
        method_38((var_8: EnvStack8), (var_28: EnvStack8), (var_40: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4))
        let (var_58: EnvHeap3) = var_4.mem_0
        let (var_59: (int64 ref)) = var_58.mem_0
        let (var_60: EnvStack0) = var_58.mem_1
        let (var_61: (uint64 ref)) = var_60.mem_0
        let (var_62: uint64) = method_5((var_61: (uint64 ref)))
        let (var_63: (int64 ref)) = var_41.mem_0
        let (var_64: EnvStack0) = var_41.mem_1
        let (var_65: (uint64 ref)) = var_64.mem_0
        let (var_66: uint64) = method_5((var_65: (uint64 ref)))
        let (var_67: uint64) = method_5((var_65: (uint64 ref)))
        // Cuda join point
        // method_23((var_62: uint64), (var_66: uint64), (var_67: uint64))
        let (var_68: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_18, var_15)
        let (var_69: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_68.set_GridDimensions(var_69)
        let (var_70: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
        var_68.set_BlockDimensions(var_70)
        let (var_71: ManagedCuda.BasicTypes.CUstream) = method_19((var_47: (bool ref)), (var_48: ManagedCuda.CudaStream))
        let (var_73: (System.Object [])) = [|var_62; var_66; var_67|]: (System.Object [])
        var_68.RunAsync(var_71, var_73)
        let (var_78: int64) = 65536L
        let (var_79: EnvHeap3) = method_11((var_38: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_78: int64))
        let (var_80: EnvStack8) = EnvStack8((var_79: EnvHeap3))
        let (var_81: uint64) = method_5((var_65: (uint64 ref)))
        let (var_82: EnvHeap3) = var_80.mem_0
        let (var_83: (int64 ref)) = var_82.mem_0
        let (var_84: EnvStack0) = var_82.mem_1
        let (var_85: (uint64 ref)) = var_84.mem_0
        let (var_86: uint64) = method_5((var_85: (uint64 ref)))
        // Cuda join point
        // method_24((var_81: uint64), (var_86: uint64))
        let (var_87: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_18, var_15)
        let (var_88: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_87.set_GridDimensions(var_88)
        let (var_89: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_87.set_BlockDimensions(var_89)
        let (var_90: ManagedCuda.BasicTypes.CUstream) = method_19((var_47: (bool ref)), (var_48: ManagedCuda.CudaStream))
        let (var_92: (System.Object [])) = [|var_81; var_86|]: (System.Object [])
        var_87.RunAsync(var_90, var_92)
        let (var_93: int64) = 65536L
        let (var_94: EnvHeap3) = method_11((var_38: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_93: int64))
        let (var_95: EnvStack8) = EnvStack8((var_94: EnvHeap3))
        let (var_96: ManagedCuda.BasicTypes.CUstream) = method_19((var_47: (bool ref)), (var_48: ManagedCuda.CudaStream))
        let (var_97: EnvHeap3) = var_95.mem_0
        let (var_98: (int64 ref)) = var_97.mem_0
        let (var_99: EnvStack0) = var_97.mem_1
        let (var_100: (uint64 ref)) = var_99.mem_0
        let (var_101: uint64) = method_5((var_100: (uint64 ref)))
        let (var_102: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_101)
        let (var_103: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_102)
        let (var_104: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
        var_15.ClearMemoryAsync(var_103, 0uy, var_104, var_96)
        let (var_105: uint64) = method_5((var_85: (uint64 ref)))
        let (var_106: (int64 ref)) = var_36.mem_0
        let (var_107: EnvStack0) = var_36.mem_1
        let (var_108: (uint64 ref)) = var_107.mem_0
        let (var_109: uint64) = method_5((var_108: (uint64 ref)))
        let (var_110: int64) = (var_35 * 4L)
        let (var_111: uint64) = (uint64 var_110)
        let (var_112: uint64) = (var_109 + var_111)
        let (var_121: int64) = 4L
        let (var_122: EnvHeap3) = method_11((var_38: EnvHeap7), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_121: int64))
        let (var_123: EnvStack8) = EnvStack8((var_122: EnvHeap3))
        let (var_124: EnvHeap3) = var_123.mem_0
        let (var_125: (int64 ref)) = var_124.mem_0
        let (var_126: EnvStack0) = var_124.mem_1
        let (var_127: (uint64 ref)) = var_126.mem_0
        let (var_128: uint64) = method_5((var_127: (uint64 ref)))
        // Cuda join point
        // method_26((var_105: uint64), (var_112: uint64), (var_128: uint64))
        let (var_129: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_18, var_15)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_129.set_GridDimensions(var_130)
        let (var_131: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_129.set_BlockDimensions(var_131)
        let (var_132: ManagedCuda.BasicTypes.CUstream) = method_19((var_47: (bool ref)), (var_48: ManagedCuda.CudaStream))
        let (var_134: (System.Object [])) = [|var_105; var_112; var_128|]: (System.Object [])
        var_129.RunAsync(var_132, var_134)
        let (var_135: (unit -> unit)) = method_39((var_26: (unit -> unit)), (var_44: EnvStack8), (var_40: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_0: EnvStack8), (var_34: int64), (var_5: EnvStack8), (var_6: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_95: EnvStack8), (var_80: EnvStack8), (var_123: EnvStack8), (var_35: int64))
        let (var_136: (unit -> float32)) = method_42((var_123: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_25: (unit -> float32)))
        let (var_137: int64) = (var_29 + 1L)
        method_50((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_16: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_20: int64), (var_21: float), (var_22: int64), (var_23: ResizeArray<EnvHeap3>), (var_24: ResizeArray<EnvHeap3>), (var_136: (unit -> float32)), (var_135: (unit -> unit)), (var_95: EnvStack8), (var_80: EnvStack8), (var_137: int64))
    else
        let (var_139: float32) = var_25()
        let (var_140: float) = (float var_139)
        let (var_141: float) = (var_21 + var_140)
        method_44((var_24: ResizeArray<EnvHeap3>))
        let (var_150: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_151: EnvHeap3) = var_28.mem_0
        method_15((var_151: EnvHeap3), (var_150: ResizeArray<EnvHeap3>))
        let (var_152: int64) = (var_20 + 1L)
        if (System.Double.IsNaN var_141) then
            method_44((var_16: ResizeArray<EnvHeap3>))
            method_44((var_150: ResizeArray<EnvHeap3>))
            let (var_153: float) = (float var_152)
            (var_141 / var_153)
        else
            var_26()
            let (var_155: EnvHeap3) = var_4.mem_0
            let (var_156: (int64 ref)) = var_155.mem_0
            let (var_157: EnvStack0) = var_155.mem_1
            let (var_158: (uint64 ref)) = var_157.mem_0
            let (var_159: uint64) = method_5((var_158: (uint64 ref)))
            let (var_160: EnvHeap3) = var_3.mem_0
            let (var_161: (int64 ref)) = var_160.mem_0
            let (var_162: EnvStack0) = var_160.mem_1
            let (var_163: (uint64 ref)) = var_162.mem_0
            let (var_164: uint64) = method_5((var_163: (uint64 ref)))
            // Cuda join point
            // method_46((var_159: uint64), (var_164: uint64))
            let (var_165: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_46", var_18, var_15)
            let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_165.set_GridDimensions(var_166)
            let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_165.set_BlockDimensions(var_167)
            let (var_168: (int64 ref)) = var_19.mem_0
            let (var_169: EnvHeap5) = var_19.mem_1
            let (var_170: (bool ref)) = var_169.mem_0
            let (var_171: ManagedCuda.CudaStream) = var_169.mem_1
            let (var_172: ManagedCuda.BasicTypes.CUstream) = method_19((var_170: (bool ref)), (var_171: ManagedCuda.CudaStream))
            let (var_174: (System.Object [])) = [|var_159; var_164|]: (System.Object [])
            var_165.RunAsync(var_172, var_174)
            let (var_175: EnvHeap3) = var_6.mem_0
            let (var_176: (int64 ref)) = var_175.mem_0
            let (var_177: EnvStack0) = var_175.mem_1
            let (var_178: (uint64 ref)) = var_177.mem_0
            let (var_179: uint64) = method_5((var_178: (uint64 ref)))
            let (var_180: EnvHeap3) = var_5.mem_0
            let (var_181: (int64 ref)) = var_180.mem_0
            let (var_182: EnvStack0) = var_180.mem_1
            let (var_183: (uint64 ref)) = var_182.mem_0
            let (var_184: uint64) = method_5((var_183: (uint64 ref)))
            // Cuda join point
            // method_47((var_179: uint64), (var_184: uint64))
            let (var_185: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_18, var_15)
            let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_185.set_GridDimensions(var_186)
            let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_185.set_BlockDimensions(var_187)
            let (var_188: ManagedCuda.BasicTypes.CUstream) = method_19((var_170: (bool ref)), (var_171: ManagedCuda.CudaStream))
            let (var_190: (System.Object [])) = [|var_179; var_184|]: (System.Object [])
            var_185.RunAsync(var_188, var_190)
            let (var_191: EnvHeap3) = var_8.mem_0
            let (var_192: (int64 ref)) = var_191.mem_0
            let (var_193: EnvStack0) = var_191.mem_1
            let (var_194: (uint64 ref)) = var_193.mem_0
            let (var_195: uint64) = method_5((var_194: (uint64 ref)))
            let (var_196: EnvHeap3) = var_7.mem_0
            let (var_197: (int64 ref)) = var_196.mem_0
            let (var_198: EnvStack0) = var_196.mem_1
            let (var_199: (uint64 ref)) = var_198.mem_0
            let (var_200: uint64) = method_5((var_199: (uint64 ref)))
            // Cuda join point
            // method_47((var_195: uint64), (var_200: uint64))
            let (var_201: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_18, var_15)
            let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_201.set_GridDimensions(var_202)
            let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_201.set_BlockDimensions(var_203)
            let (var_204: ManagedCuda.BasicTypes.CUstream) = method_19((var_170: (bool ref)), (var_171: ManagedCuda.CudaStream))
            let (var_206: (System.Object [])) = [|var_195; var_200|]: (System.Object [])
            var_201.RunAsync(var_204, var_206)
            method_44((var_16: ResizeArray<EnvHeap3>))
            let (var_207: int64) = (var_22 + 1L)
            method_48((var_0: EnvStack8), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: EnvStack0), (var_12: uint64), (var_13: ResizeArray<Env1>), (var_14: ResizeArray<Env2>), (var_15: ManagedCuda.CudaContext), (var_23: ResizeArray<EnvHeap3>), (var_17: ResizeArray<EnvHeap4>), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: EnvHeap4), (var_152: int64), (var_141: float), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_150: ResizeArray<EnvHeap3>), (var_28: EnvStack8), (var_207: int64))
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
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env2>) = ResizeArray<Env2>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env2>))
let (var_43: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_44: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_43)
let (var_45: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_46: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_47: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_45, var_46)
let (var_56: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_68: ResizeArray<EnvHeap4>) = ResizeArray<EnvHeap4>()
let (var_69: (bool ref)) = (ref true)
let (var_70: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_71: EnvHeap5) = ({mem_0 = (var_69: (bool ref)); mem_1 = (var_70: ManagedCuda.CudaStream)} : EnvHeap5)
let (var_72: EnvHeap4) = method_7((var_71: EnvHeap5), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule))
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
let (var_92: EnvStack6) = method_10((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_89: int64), (var_82: (uint8 [])), (var_90: int64), (var_91: int64))
let (var_93: EnvHeap3) = var_92.mem_0
let (var_94: (int64 ref)) = var_93.mem_0
let (var_95: EnvStack0) = var_93.mem_1
let (var_96: (uint64 ref)) = var_95.mem_0
let (var_97: uint64) = method_5((var_96: (uint64 ref)))
let (var_101: int64) = 571080704L
let (var_102: EnvHeap7) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap7)
let (var_103: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_101: int64))
let (var_104: EnvStack8) = EnvStack8((var_103: EnvHeap3))
let (var_105: EnvHeap3) = var_104.mem_0
let (var_106: (int64 ref)) = var_105.mem_0
let (var_107: EnvStack0) = var_105.mem_1
let (var_108: (uint64 ref)) = var_107.mem_0
let (var_109: uint64) = method_5((var_108: (uint64 ref)))
// Cuda join point
// method_16((var_97: uint64), (var_109: uint64))
let (var_110: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_111: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
var_110.set_GridDimensions(var_111)
let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_110.set_BlockDimensions(var_112)
let (var_113: (int64 ref)) = var_72.mem_0
let (var_114: EnvHeap5) = var_72.mem_1
let (var_115: (bool ref)) = var_114.mem_0
let (var_116: ManagedCuda.CudaStream) = var_114.mem_1
let (var_117: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_119: (System.Object [])) = [|var_97; var_109|]: (System.Object [])
var_110.RunAsync(var_117, var_119)
let (var_120: int64) = 65536L
let (var_121: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_120: int64))
let (var_122: EnvStack8) = EnvStack8((var_121: EnvHeap3))
let (var_123: EnvHeap3) = var_122.mem_0
let (var_124: (int64 ref)) = var_123.mem_0
let (var_125: EnvStack0) = var_123.mem_1
let (var_126: (uint64 ref)) = var_125.mem_0
let (var_127: uint64) = method_5((var_126: (uint64 ref)))
let (var_128: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_129: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_129)
let (var_130: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_127)
let (var_131: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_130)
var_44.GenerateNormal32(var_131, var_128, 0.000000f, 0.088388f)
let (var_132: int64) = 65536L
let (var_133: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_132: int64))
let (var_134: EnvStack8) = EnvStack8((var_133: EnvHeap3))
let (var_135: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_136: EnvHeap3) = var_134.mem_0
let (var_137: (int64 ref)) = var_136.mem_0
let (var_138: EnvStack0) = var_136.mem_1
let (var_139: (uint64 ref)) = var_138.mem_0
let (var_140: uint64) = method_5((var_139: (uint64 ref)))
let (var_141: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_140)
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_141)
let (var_143: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_142, 0uy, var_143, var_135)
let (var_144: int64) = 65536L
let (var_145: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_144: int64))
let (var_146: EnvStack8) = EnvStack8((var_145: EnvHeap3))
let (var_147: EnvHeap3) = var_146.mem_0
let (var_148: (int64 ref)) = var_147.mem_0
let (var_149: EnvStack0) = var_147.mem_1
let (var_150: (uint64 ref)) = var_149.mem_0
let (var_151: uint64) = method_5((var_150: (uint64 ref)))
let (var_152: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_153: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_153)
let (var_154: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_151)
let (var_155: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_154)
var_44.GenerateNormal32(var_155, var_152, 0.000000f, 0.088388f)
let (var_156: int64) = 65536L
let (var_157: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_156: int64))
let (var_158: EnvStack8) = EnvStack8((var_157: EnvHeap3))
let (var_159: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_160: EnvHeap3) = var_158.mem_0
let (var_161: (int64 ref)) = var_160.mem_0
let (var_162: EnvStack0) = var_160.mem_1
let (var_163: (uint64 ref)) = var_162.mem_0
let (var_164: uint64) = method_5((var_163: (uint64 ref)))
let (var_165: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_164)
let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_165)
let (var_167: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_166, 0uy, var_167, var_159)
let (var_168: int64) = 512L
let (var_169: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_168: int64))
let (var_170: EnvStack8) = EnvStack8((var_169: EnvHeap3))
let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_172: EnvHeap3) = var_170.mem_0
let (var_173: (int64 ref)) = var_172.mem_0
let (var_174: EnvStack0) = var_172.mem_1
let (var_175: (uint64 ref)) = var_174.mem_0
let (var_176: uint64) = method_5((var_175: (uint64 ref)))
let (var_177: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_176)
let (var_178: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_177)
let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_178, 0uy, var_179, var_171)
let (var_180: int64) = 512L
let (var_181: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_180: int64))
let (var_182: EnvStack8) = EnvStack8((var_181: EnvHeap3))
let (var_183: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_184: EnvHeap3) = var_182.mem_0
let (var_185: (int64 ref)) = var_184.mem_0
let (var_186: EnvStack0) = var_184.mem_1
let (var_187: (uint64 ref)) = var_186.mem_0
let (var_188: uint64) = method_5((var_187: (uint64 ref)))
let (var_189: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_188)
let (var_190: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_189)
let (var_191: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_190, 0uy, var_191, var_183)
let (var_192: int64) = 0L
method_20((var_182: EnvStack8), (var_170: EnvStack8), (var_134: EnvStack8), (var_122: EnvStack8), (var_158: EnvStack8), (var_146: EnvStack8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_104: EnvStack8), (var_192: int64))
method_51((var_68: ResizeArray<EnvHeap4>))
method_44((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_193: (uint64 ref)) = var_40.mem_0
let (var_194: uint64) = method_5((var_193: (uint64 ref)))
let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_194)
let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_195)
var_1.FreeMemory(var_196)
var_193 := 0UL
var_1.Dispose()

