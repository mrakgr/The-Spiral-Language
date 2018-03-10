module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_21(float * var_0);
    __global__ void method_25(float * var_0, float * var_1, float * var_2);
    __global__ void method_27(float * var_0, float * var_1);
    __global__ void method_29(float * var_0, float * var_1);
    __global__ void method_30(float * var_0, float * var_1, float * var_2);
    __global__ void method_40(float * var_0, float * var_1, float * var_2);
    __global__ void method_43(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_44(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_45(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_47(float * var_0, float * var_1);
    __global__ void method_51(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_55(float * var_0, float * var_1, float * var_2);
    __global__ void method_64(float * var_0, float * var_1);
    __global__ void method_65(float * var_0, float * var_1);
    __global__ void method_57(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_69(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_26(long long int * var_0);
    __device__ char method_28(long long int * var_0);
    __device__ char method_41(long long int * var_0, float * var_1);
    __device__ char method_48(long long int * var_0, float * var_1);
    __device__ char method_49(long long int * var_0, float * var_1);
    __device__ char method_50(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_66(long long int * var_0);
    
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
            long long int var_11 = (var_10 % 2);
            long long int var_12 = (var_10 / 2);
            long long int var_13 = (var_12 % 557697);
            long long int var_14 = (var_12 / 557697);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 557697);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = (var_13 * 256);
            char var_20 = (var_11 >= 0);
            char var_22;
            if (var_20) {
                var_22 = (var_11 < 2);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_24 = (var_11 * 557697);
            char var_26;
            if (var_15) {
                var_26 = (var_13 < 557697);
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
                var_31 = (var_11 < 2);
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
            long long int var_48 = (var_8 + 35692800);
            var_6[0] = var_48;
        }
        long long int var_49 = var_6[0];
    }
    __global__ void method_21(float * var_0) {
        long long int var_1 = threadIdx.x;
        long long int var_2 = blockIdx.x;
        long long int var_3 = (128 * var_2);
        long long int var_4 = (var_1 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_18(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 128);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                // "Argument out of bounds."
            } else {
            }
            char var_13;
            if (var_8) {
                var_13 = (var_7 < 128);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // "Argument out of bounds."
            } else {
            }
            float var_15 = var_0[var_7];
            var_0[var_7] = 1;
            long long int var_16 = (var_7 + 128);
            var_5[0] = var_16;
        }
        long long int var_17 = var_5[0];
    }
    __global__ void method_25(float * var_0, float * var_1, float * var_2) {
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
            long long int var_16 = (2 * var_15);
            long long int var_17 = (var_14 + var_16);
            long long int var_18[1];
            var_18[0] = var_17;
            while (method_26(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 2);
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
                    var_31 = (var_20 < 2);
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
                long long int var_40 = (var_20 + 2);
                var_18[0] = var_40;
            }
            long long int var_41 = var_18[0];
            long long int var_42 = (var_9 + 128);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_27(float * var_0, float * var_1) {
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
            float var_18 = tanh(var_16);
            var_1[var_8] = var_18;
            long long int var_19 = (var_8 + 256);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_29(float * var_0, float * var_1) {
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
            float var_18 = (-var_16);
            float var_19 = exp(var_18);
            float var_20 = (1 + var_19);
            float var_21 = (1 / var_20);
            var_1[var_8] = var_21;
            long long int var_22 = (var_8 + 256);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_30(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_28(var_7)) {
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 256);
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
            long long int var_21 = (var_9 + 256);
            var_7[0] = var_21;
        }
        long long int var_22 = var_7[0];
    }
    __global__ void method_40(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_41(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 256);
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
            long long int var_28 = (var_11 + 256);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        float var_32 = (var_31 / 2);
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
    __global__ void method_43(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_28(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 256);
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
                var_16 = (var_10 < 256);
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
            float var_26 = (var_25 / 2);
            float var_27 = (var_20 + var_26);
            var_3[var_10] = var_27;
            long long int var_28 = (var_10 + 256);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __global__ void method_44(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_28(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 256);
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
                var_16 = (var_10 < 256);
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
            long long int var_26 = (var_10 + 256);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_45(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_28(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 256);
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
                var_18 = (var_12 < 256);
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
            long long int var_30 = (var_12 + 256);
            var_10[0] = var_30;
        }
        long long int var_31 = var_10[0];
    }
    __global__ void method_47(float * var_0, float * var_1) {
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
            long long int var_18 = (2 * var_17);
            long long int var_19 = (var_16 + var_18);
            float var_20 = 0;
            long long int var_21[1];
            float var_22[1];
            var_21[0] = var_19;
            var_22[0] = var_20;
            while (method_48(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 2);
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
                long long int var_37 = (var_24 + 2);
                var_21[0] = var_37;
                var_22[0] = var_36;
            }
            long long int var_38 = var_21[0];
            float var_39 = var_22[0];
            __shared__ float var_40[32];
            long long int var_41[1];
            float var_42[1];
            var_41[0] = 2;
            var_42[0] = var_39;
            while (method_49(var_41, var_42)) {
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
                        var_55 = (var_52 < 2);
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
                    while (method_50(var_44, var_69, var_70)) {
                        long long int var_72 = var_69[0];
                        float var_73 = var_70[0];
                        char var_74 = (var_72 >= 1);
                        char var_76;
                        if (var_74) {
                            var_76 = (var_72 < 2);
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
    __global__ void method_51(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_28(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 256);
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
                var_16 = (var_10 < 256);
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
            long long int var_26 = (var_10 + 256);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_55(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_28(var_7)) {
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 256);
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
            long long int var_21 = (var_9 + 256);
            var_7[0] = var_21;
        }
        long long int var_22 = var_7[0];
    }
    __global__ void method_64(float * var_0, float * var_1) {
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
            float var_18 = (0.1 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_65(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_66(var_6)) {
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
            float var_18 = (0.1 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_57(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_28(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 256);
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
                var_18 = (var_12 < 256);
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
            long long int var_28 = (var_12 + 256);
            var_10[0] = var_28;
        }
        long long int var_29 = var_10[0];
    }
    __global__ void method_69(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (128 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_28(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 256);
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
                var_17 = (var_11 < 256);
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
            long long int var_26 = (var_11 + 256);
            var_9[0] = var_26;
        }
        long long int var_27 = var_9[0];
    }
    __device__ char method_17(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 35692608);
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_26(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 2);
    }
    __device__ char method_28(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 256);
    }
    __device__ char method_41(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 256);
    }
    __device__ char method_48(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 2);
    }
    __device__ char method_49(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_50(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_66(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
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
and method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack8)): unit =
    let (var_12: EnvHeap3) = var_11.mem_0
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: EnvStack0) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_14.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    // Cuda join point
    // method_21((var_16: uint64))
    let (var_17: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_9, var_6)
    let (var_18: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_17.set_GridDimensions(var_18)
    let (var_19: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_17.set_BlockDimensions(var_19)
    let (var_20: (int64 ref)) = var_10.mem_0
    let (var_21: EnvHeap5) = var_10.mem_1
    let (var_22: (bool ref)) = var_21.mem_0
    let (var_23: ManagedCuda.CudaStream) = var_21.mem_1
    let (var_24: ManagedCuda.BasicTypes.CUstream) = method_19((var_22: (bool ref)), (var_23: ManagedCuda.CudaStream))
    let (var_26: (System.Object [])) = [|var_16|]: (System.Object [])
    var_17.RunAsync(var_24, var_26)
and method_22((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: EnvStack0), (var_21: uint64), (var_22: ResizeArray<Env1>), (var_23: ResizeArray<Env2>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<EnvHeap3>), (var_26: ResizeArray<EnvHeap4>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: EnvHeap4), (var_29: EnvStack8), (var_30: int64)): unit =
    let (var_31: bool) = (var_30 < 100L)
    if var_31 then
        let (var_32: int64) = 0L
        let (var_33: float) = 0.000000
        let (var_34: int64) = 0L
        let (var_35: float) = method_23((var_29: EnvStack8), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: EnvStack0), (var_21: uint64), (var_22: ResizeArray<Env1>), (var_23: ResizeArray<Env2>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<EnvHeap3>), (var_26: ResizeArray<EnvHeap4>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: EnvHeap4), (var_32: int64), (var_33: float), (var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_34: int64))
        let (var_36: string) = System.String.Format("Training: {0}",var_35)
        let (var_37: string) = System.String.Format("{0}",var_36)
        System.Console.WriteLine(var_37)
        if (System.Double.IsNaN var_35) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_38: int64) = (var_30 + 1L)
            method_22((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: ManagedCuda.CudaBlas.CudaBlas), (var_19: ManagedCuda.CudaRand.CudaRandDevice), (var_20: EnvStack0), (var_21: uint64), (var_22: ResizeArray<Env1>), (var_23: ResizeArray<Env2>), (var_24: ManagedCuda.CudaContext), (var_25: ResizeArray<EnvHeap3>), (var_26: ResizeArray<EnvHeap4>), (var_27: ManagedCuda.BasicTypes.CUmodule), (var_28: EnvHeap4), (var_29: EnvStack8), (var_38: int64))
    else
        ()
and method_71((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_72
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_62((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_63
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
and method_23((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_32: int64)): float =
    let (var_33: bool) = (var_32 < 1L)
    if var_33 then
        let (var_34: bool) = (var_32 >= 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = (var_32 * 1024L)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_37: int64) = (1024L + var_36)
        let (var_38: EnvHeap7) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap7)
        let (var_39: EnvStack0) = var_38.mem_0
        let (var_40: uint64) = var_38.mem_1
        let (var_41: ResizeArray<Env1>) = var_38.mem_2
        let (var_42: ResizeArray<Env2>) = var_38.mem_3
        method_1((var_41: ResizeArray<Env1>), (var_39: EnvStack0), (var_40: uint64), (var_42: ResizeArray<Env2>))
        let (var_46: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_273: EnvHeap3) = var_0.mem_0
        let (var_274: int64) = 1024L
        let (var_275: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_274: int64))
        let (var_276: EnvStack8) = EnvStack8((var_275: EnvHeap3))
        method_24((var_23: EnvStack8), (var_0: EnvStack8), (var_36: int64), (var_276: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_277: EnvHeap3) = var_276.mem_0
        let (var_278: int64) = 1024L
        let (var_279: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_278: int64))
        let (var_280: EnvStack8) = EnvStack8((var_279: EnvHeap3))
        let (var_281: (int64 ref)) = var_11.mem_0
        let (var_282: EnvHeap5) = var_11.mem_1
        let (var_283: (bool ref)) = var_282.mem_0
        let (var_284: ManagedCuda.CudaStream) = var_282.mem_1
        let (var_285: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_286: EnvHeap3) = var_280.mem_0
        let (var_287: (int64 ref)) = var_286.mem_0
        let (var_288: EnvStack0) = var_286.mem_1
        let (var_289: (uint64 ref)) = var_288.mem_0
        let (var_290: uint64) = method_5((var_289: (uint64 ref)))
        let (var_291: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_290)
        let (var_292: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_291)
        let (var_293: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_292, 0uy, var_293, var_285)
        let (var_294: EnvHeap3) = var_17.mem_0
        let (var_295: (int64 ref)) = var_294.mem_0
        let (var_296: EnvStack0) = var_294.mem_1
        let (var_297: (uint64 ref)) = var_296.mem_0
        let (var_298: uint64) = method_5((var_297: (uint64 ref)))
        let (var_299: (int64 ref)) = var_277.mem_0
        let (var_300: EnvStack0) = var_277.mem_1
        let (var_301: (uint64 ref)) = var_300.mem_0
        let (var_302: uint64) = method_5((var_301: (uint64 ref)))
        let (var_303: uint64) = method_5((var_301: (uint64 ref)))
        // Cuda join point
        // method_25((var_298: uint64), (var_302: uint64), (var_303: uint64))
        let (var_304: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_305: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_304.set_GridDimensions(var_305)
        let (var_306: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_304.set_BlockDimensions(var_306)
        let (var_307: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_309: (System.Object [])) = [|var_298; var_302; var_303|]: (System.Object [])
        var_304.RunAsync(var_307, var_309)
        let (var_311: int64) = 1024L
        let (var_312: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_311: int64))
        let (var_313: EnvStack8) = EnvStack8((var_312: EnvHeap3))
        let (var_314: uint64) = method_5((var_301: (uint64 ref)))
        let (var_315: EnvHeap3) = var_313.mem_0
        let (var_316: (int64 ref)) = var_315.mem_0
        let (var_317: EnvStack0) = var_315.mem_1
        let (var_318: (uint64 ref)) = var_317.mem_0
        let (var_319: uint64) = method_5((var_318: (uint64 ref)))
        // Cuda join point
        // method_27((var_314: uint64), (var_319: uint64))
        let (var_320: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_10, var_7)
        let (var_321: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_320.set_GridDimensions(var_321)
        let (var_322: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_320.set_BlockDimensions(var_322)
        let (var_323: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_325: (System.Object [])) = [|var_314; var_319|]: (System.Object [])
        var_320.RunAsync(var_323, var_325)
        let (var_326: int64) = 1024L
        let (var_327: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_326: int64))
        let (var_328: EnvStack8) = EnvStack8((var_327: EnvHeap3))
        let (var_329: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_330: EnvHeap3) = var_328.mem_0
        let (var_331: (int64 ref)) = var_330.mem_0
        let (var_332: EnvStack0) = var_330.mem_1
        let (var_333: (uint64 ref)) = var_332.mem_0
        let (var_334: uint64) = method_5((var_333: (uint64 ref)))
        let (var_335: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_334)
        let (var_336: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_335)
        let (var_337: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_336, 0uy, var_337, var_329)
        let (var_338: int64) = 1024L
        let (var_339: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_338: int64))
        let (var_340: EnvStack8) = EnvStack8((var_339: EnvHeap3))
        method_24((var_25: EnvStack8), (var_0: EnvStack8), (var_36: int64), (var_340: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_341: EnvHeap3) = var_340.mem_0
        let (var_342: int64) = 1024L
        let (var_343: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_342: int64))
        let (var_344: EnvStack8) = EnvStack8((var_343: EnvHeap3))
        let (var_345: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_346: EnvHeap3) = var_344.mem_0
        let (var_347: (int64 ref)) = var_346.mem_0
        let (var_348: EnvStack0) = var_346.mem_1
        let (var_349: (uint64 ref)) = var_348.mem_0
        let (var_350: uint64) = method_5((var_349: (uint64 ref)))
        let (var_351: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_350)
        let (var_352: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_351)
        let (var_353: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_352, 0uy, var_353, var_345)
        let (var_354: EnvHeap3) = var_19.mem_0
        let (var_355: (int64 ref)) = var_354.mem_0
        let (var_356: EnvStack0) = var_354.mem_1
        let (var_357: (uint64 ref)) = var_356.mem_0
        let (var_358: uint64) = method_5((var_357: (uint64 ref)))
        let (var_359: (int64 ref)) = var_341.mem_0
        let (var_360: EnvStack0) = var_341.mem_1
        let (var_361: (uint64 ref)) = var_360.mem_0
        let (var_362: uint64) = method_5((var_361: (uint64 ref)))
        let (var_363: uint64) = method_5((var_361: (uint64 ref)))
        // Cuda join point
        // method_25((var_358: uint64), (var_362: uint64), (var_363: uint64))
        let (var_364: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_365: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_364.set_GridDimensions(var_365)
        let (var_366: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_364.set_BlockDimensions(var_366)
        let (var_367: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_369: (System.Object [])) = [|var_358; var_362; var_363|]: (System.Object [])
        var_364.RunAsync(var_367, var_369)
        let (var_374: int64) = 1024L
        let (var_375: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_374: int64))
        let (var_376: EnvStack8) = EnvStack8((var_375: EnvHeap3))
        let (var_377: uint64) = method_5((var_361: (uint64 ref)))
        let (var_378: EnvHeap3) = var_376.mem_0
        let (var_379: (int64 ref)) = var_378.mem_0
        let (var_380: EnvStack0) = var_378.mem_1
        let (var_381: (uint64 ref)) = var_380.mem_0
        let (var_382: uint64) = method_5((var_381: (uint64 ref)))
        // Cuda join point
        // method_29((var_377: uint64), (var_382: uint64))
        let (var_383: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_384: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_383.set_GridDimensions(var_384)
        let (var_385: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_383.set_BlockDimensions(var_385)
        let (var_386: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_388: (System.Object [])) = [|var_377; var_382|]: (System.Object [])
        var_383.RunAsync(var_386, var_388)
        let (var_389: int64) = 1024L
        let (var_390: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_389: int64))
        let (var_391: EnvStack8) = EnvStack8((var_390: EnvHeap3))
        let (var_392: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_393: EnvHeap3) = var_391.mem_0
        let (var_394: (int64 ref)) = var_393.mem_0
        let (var_395: EnvStack0) = var_393.mem_1
        let (var_396: (uint64 ref)) = var_395.mem_0
        let (var_397: uint64) = method_5((var_396: (uint64 ref)))
        let (var_398: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_397)
        let (var_399: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_398)
        let (var_400: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_399, 0uy, var_400, var_392)
        let (var_402: int64) = 1024L
        let (var_403: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_402: int64))
        let (var_404: EnvStack8) = EnvStack8((var_403: EnvHeap3))
        let (var_405: uint64) = method_5((var_318: (uint64 ref)))
        let (var_406: uint64) = method_5((var_381: (uint64 ref)))
        let (var_407: EnvHeap3) = var_404.mem_0
        let (var_408: (int64 ref)) = var_407.mem_0
        let (var_409: EnvStack0) = var_407.mem_1
        let (var_410: (uint64 ref)) = var_409.mem_0
        let (var_411: uint64) = method_5((var_410: (uint64 ref)))
        // Cuda join point
        // method_30((var_405: uint64), (var_406: uint64), (var_411: uint64))
        let (var_412: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_10, var_7)
        let (var_413: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_412.set_GridDimensions(var_413)
        let (var_414: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_412.set_BlockDimensions(var_414)
        let (var_415: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_417: (System.Object [])) = [|var_405; var_406; var_411|]: (System.Object [])
        var_412.RunAsync(var_415, var_417)
        let (var_418: int64) = 1024L
        let (var_419: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_418: int64))
        let (var_420: EnvStack8) = EnvStack8((var_419: EnvHeap3))
        let (var_421: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_422: EnvHeap3) = var_420.mem_0
        let (var_423: (int64 ref)) = var_422.mem_0
        let (var_424: EnvStack0) = var_422.mem_1
        let (var_425: (uint64 ref)) = var_424.mem_0
        let (var_426: uint64) = method_5((var_425: (uint64 ref)))
        let (var_427: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_426)
        let (var_428: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_427)
        let (var_429: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_428, 0uy, var_429, var_421)
        let (var_434: int64) = 1024L
        let (var_435: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_434: int64))
        let (var_436: EnvStack8) = EnvStack8((var_435: EnvHeap3))
        let (var_437: uint64) = method_5((var_410: (uint64 ref)))
        let (var_438: EnvHeap3) = var_436.mem_0
        let (var_439: (int64 ref)) = var_438.mem_0
        let (var_440: EnvStack0) = var_438.mem_1
        let (var_441: (uint64 ref)) = var_440.mem_0
        let (var_442: uint64) = method_5((var_441: (uint64 ref)))
        // Cuda join point
        // method_29((var_437: uint64), (var_442: uint64))
        let (var_443: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_444: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_443.set_GridDimensions(var_444)
        let (var_445: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_443.set_BlockDimensions(var_445)
        let (var_446: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_448: (System.Object [])) = [|var_437; var_442|]: (System.Object [])
        var_443.RunAsync(var_446, var_448)
        let (var_449: int64) = 1024L
        let (var_450: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_449: int64))
        let (var_451: EnvStack8) = EnvStack8((var_450: EnvHeap3))
        let (var_452: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_453: EnvHeap3) = var_451.mem_0
        let (var_454: (int64 ref)) = var_453.mem_0
        let (var_455: EnvStack0) = var_453.mem_1
        let (var_456: (uint64 ref)) = var_455.mem_0
        let (var_457: uint64) = method_5((var_456: (uint64 ref)))
        let (var_458: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_457)
        let (var_459: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_458)
        let (var_460: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_459, 0uy, var_460, var_452)
        let (var_461: int64) = 128L
        let (var_462: int64) = 1L
        let (var_463: int64) = 0L
        let (var_464: int64) = 2L
        let (var_465: int64) = 0L
        let (var_466: int64) = 128L
        method_31((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_0: EnvStack8), (var_37: int64), (var_461: int64), (var_462: int64), (var_463: int64), (var_464: int64), (var_465: int64), (var_466: int64))
        let (var_467: uint64) = method_5((var_441: (uint64 ref)))
        let (var_468: (int64 ref)) = var_273.mem_0
        let (var_469: EnvStack0) = var_273.mem_1
        let (var_470: (uint64 ref)) = var_469.mem_0
        let (var_471: uint64) = method_5((var_470: (uint64 ref)))
        let (var_472: int64) = (var_37 * 4L)
        let (var_473: uint64) = (uint64 var_472)
        let (var_474: uint64) = (var_471 + var_473)
        let (var_483: int64) = 4L
        let (var_484: EnvHeap3) = method_11((var_38: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_483: int64))
        let (var_485: EnvStack8) = EnvStack8((var_484: EnvHeap3))
        let (var_486: EnvHeap3) = var_485.mem_0
        let (var_487: (int64 ref)) = var_486.mem_0
        let (var_488: EnvStack0) = var_486.mem_1
        let (var_489: (uint64 ref)) = var_488.mem_0
        let (var_490: uint64) = method_5((var_489: (uint64 ref)))
        // Cuda join point
        // method_40((var_467: uint64), (var_474: uint64), (var_490: uint64))
        let (var_491: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_10, var_7)
        let (var_492: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_491.set_GridDimensions(var_492)
        let (var_493: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
        var_491.set_BlockDimensions(var_493)
        let (var_494: ManagedCuda.BasicTypes.CUstream) = method_19((var_283: (bool ref)), (var_284: ManagedCuda.CudaStream))
        let (var_496: (System.Object [])) = [|var_467; var_474; var_490|]: (System.Object [])
        var_491.RunAsync(var_494, var_496)
        let (var_497: (unit -> unit)) = method_42((var_280: EnvStack8), (var_276: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_0: EnvStack8), (var_36: int64), (var_22: EnvStack8), (var_23: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_328: EnvStack8), (var_313: EnvStack8), (var_344: EnvStack8), (var_340: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_391: EnvStack8), (var_376: EnvStack8), (var_420: EnvStack8), (var_404: EnvStack8), (var_451: EnvStack8), (var_436: EnvStack8), (var_485: EnvStack8), (var_37: int64))
        let (var_498: (unit -> float32)) = method_52((var_485: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_832: int64) = 1L
        method_61((var_0: EnvStack8), (var_36: int64), (var_37: int64), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_32: int64), (var_8: ResizeArray<EnvHeap3>), (var_498: (unit -> float32)), (var_497: (unit -> unit)), (var_451: EnvStack8), (var_436: EnvStack8), (var_832: int64))
    else
        let (var_834: float) = (float var_12)
        (var_13 / var_834)
and method_72 ((var_0: EnvHeap4)): unit =
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
and method_63 ((var_0: EnvHeap3)): unit =
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
and method_24((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 2, 128, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack8), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64)): unit =
    let (var_19: int64) = (var_16 - var_15)
    let (var_20: int64) = (var_18 - var_17)
    let (var_21: int64) = (var_19 * var_20)
    let (var_22: bool) = (var_21 > 0L)
    let (var_23: bool) = (var_22 = false)
    if var_23 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_24: int64) = (var_20 * var_14)
    let (var_25: bool) = (var_13 = var_24)
    let (var_26: bool) = (var_25 = false)
    if var_26 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_27: int64) = (var_19 * var_13)
    let (var_28: (float32 [])) = method_32((var_19: int64), (var_11: EnvStack8), (var_12: int64), (var_13: int64), (var_14: int64))
    method_33((var_28: (float32 [])), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64))
and method_42 ((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: EnvStack0), (var_11: uint64), (var_12: ResizeArray<Env1>), (var_13: ResizeArray<Env2>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<EnvHeap3>), (var_16: ResizeArray<EnvHeap4>), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: EnvHeap4), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_32: EnvStack8), (var_33: EnvStack8), (var_34: int64)) (): unit =
    let (var_35: EnvHeap3) = var_33.mem_0
    let (var_36: (int64 ref)) = var_35.mem_0
    let (var_37: EnvStack0) = var_35.mem_1
    let (var_38: (uint64 ref)) = var_37.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: EnvHeap3) = var_32.mem_0
    let (var_41: (int64 ref)) = var_40.mem_0
    let (var_42: EnvStack0) = var_40.mem_1
    let (var_43: (uint64 ref)) = var_42.mem_0
    let (var_44: uint64) = method_5((var_43: (uint64 ref)))
    let (var_45: EnvHeap3) = var_4.mem_0
    let (var_46: (int64 ref)) = var_45.mem_0
    let (var_47: EnvStack0) = var_45.mem_1
    let (var_48: (uint64 ref)) = var_47.mem_0
    let (var_49: uint64) = method_5((var_48: (uint64 ref)))
    let (var_50: int64) = (var_34 * 4L)
    let (var_51: uint64) = (uint64 var_50)
    let (var_52: uint64) = (var_49 + var_51)
    let (var_53: EnvHeap3) = var_31.mem_0
    let (var_54: (int64 ref)) = var_53.mem_0
    let (var_55: EnvStack0) = var_53.mem_1
    let (var_56: (uint64 ref)) = var_55.mem_0
    let (var_57: uint64) = method_5((var_56: (uint64 ref)))
    // Cuda join point
    // method_43((var_39: uint64), (var_44: uint64), (var_52: uint64), (var_57: uint64))
    let (var_58: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_17, var_14)
    let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_58.set_GridDimensions(var_59)
    let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_58.set_BlockDimensions(var_60)
    let (var_61: (int64 ref)) = var_18.mem_0
    let (var_62: EnvHeap5) = var_18.mem_1
    let (var_63: (bool ref)) = var_62.mem_0
    let (var_64: ManagedCuda.CudaStream) = var_62.mem_1
    let (var_65: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_67: (System.Object [])) = [|var_39; var_44; var_52; var_57|]: (System.Object [])
    var_58.RunAsync(var_65, var_67)
    let (var_68: EnvHeap3) = var_30.mem_0
    let (var_69: (int64 ref)) = var_68.mem_0
    let (var_70: EnvStack0) = var_68.mem_1
    let (var_71: (uint64 ref)) = var_70.mem_0
    let (var_72: uint64) = method_5((var_71: (uint64 ref)))
    let (var_73: uint64) = method_5((var_56: (uint64 ref)))
    let (var_74: uint64) = method_5((var_43: (uint64 ref)))
    let (var_75: EnvHeap3) = var_29.mem_0
    let (var_76: (int64 ref)) = var_75.mem_0
    let (var_77: EnvStack0) = var_75.mem_1
    let (var_78: (uint64 ref)) = var_77.mem_0
    let (var_79: uint64) = method_5((var_78: (uint64 ref)))
    // Cuda join point
    // method_44((var_72: uint64), (var_73: uint64), (var_74: uint64), (var_79: uint64))
    let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_17, var_14)
    let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_80.set_GridDimensions(var_81)
    let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_80.set_BlockDimensions(var_82)
    let (var_83: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_85: (System.Object [])) = [|var_72; var_73; var_74; var_79|]: (System.Object [])
    var_80.RunAsync(var_83, var_85)
    let (var_86: EnvHeap3) = var_20.mem_0
    let (var_87: (int64 ref)) = var_86.mem_0
    let (var_88: EnvStack0) = var_86.mem_1
    let (var_89: (uint64 ref)) = var_88.mem_0
    let (var_90: uint64) = method_5((var_89: (uint64 ref)))
    let (var_91: EnvHeap3) = var_28.mem_0
    let (var_92: (int64 ref)) = var_91.mem_0
    let (var_93: EnvStack0) = var_91.mem_1
    let (var_94: (uint64 ref)) = var_93.mem_0
    let (var_95: uint64) = method_5((var_94: (uint64 ref)))
    let (var_96: uint64) = method_5((var_78: (uint64 ref)))
    let (var_97: uint64) = method_5((var_71: (uint64 ref)))
    let (var_98: EnvHeap3) = var_19.mem_0
    let (var_99: (int64 ref)) = var_98.mem_0
    let (var_100: EnvStack0) = var_98.mem_1
    let (var_101: (uint64 ref)) = var_100.mem_0
    let (var_102: uint64) = method_5((var_101: (uint64 ref)))
    let (var_103: EnvHeap3) = var_27.mem_0
    let (var_104: (int64 ref)) = var_103.mem_0
    let (var_105: EnvStack0) = var_103.mem_1
    let (var_106: (uint64 ref)) = var_105.mem_0
    let (var_107: uint64) = method_5((var_106: (uint64 ref)))
    // Cuda join point
    // method_45((var_90: uint64), (var_95: uint64), (var_96: uint64), (var_97: uint64), (var_102: uint64), (var_107: uint64))
    let (var_108: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_17, var_14)
    let (var_109: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_108.set_GridDimensions(var_109)
    let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_108.set_BlockDimensions(var_110)
    let (var_111: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_113: (System.Object [])) = [|var_90; var_95; var_96; var_97; var_102; var_107|]: (System.Object [])
    var_108.RunAsync(var_111, var_113)
    let (var_114: EnvHeap3) = var_22.mem_0
    let (var_115: (int64 ref)) = var_114.mem_0
    let (var_116: EnvStack0) = var_114.mem_1
    let (var_117: (uint64 ref)) = var_116.mem_0
    let (var_118: uint64) = method_5((var_117: (uint64 ref)))
    let (var_119: uint64) = method_5((var_106: (uint64 ref)))
    let (var_120: uint64) = method_5((var_94: (uint64 ref)))
    let (var_121: EnvHeap3) = var_21.mem_0
    let (var_122: (int64 ref)) = var_121.mem_0
    let (var_123: EnvStack0) = var_121.mem_1
    let (var_124: (uint64 ref)) = var_123.mem_0
    let (var_125: uint64) = method_5((var_124: (uint64 ref)))
    // Cuda join point
    // method_44((var_118: uint64), (var_119: uint64), (var_120: uint64), (var_125: uint64))
    let (var_126: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_17, var_14)
    let (var_127: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_126.set_GridDimensions(var_127)
    let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_126.set_BlockDimensions(var_128)
    let (var_129: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_131: (System.Object [])) = [|var_118; var_119; var_120; var_125|]: (System.Object [])
    var_126.RunAsync(var_129, var_131)
    method_46((var_21: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_25: EnvStack8), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: EnvStack0), (var_11: uint64), (var_12: ResizeArray<Env1>), (var_13: ResizeArray<Env2>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<EnvHeap3>), (var_16: ResizeArray<EnvHeap4>), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: EnvHeap4))
    let (var_132: uint64) = method_5((var_124: (uint64 ref)))
    let (var_133: EnvHeap3) = var_23.mem_0
    let (var_134: (int64 ref)) = var_133.mem_0
    let (var_135: EnvStack0) = var_133.mem_1
    let (var_136: (uint64 ref)) = var_135.mem_0
    let (var_137: uint64) = method_5((var_136: (uint64 ref)))
    // Cuda join point
    // method_47((var_132: uint64), (var_137: uint64))
    let (var_138: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_17, var_14)
    let (var_139: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_138.set_GridDimensions(var_139)
    let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_138.set_BlockDimensions(var_140)
    let (var_141: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_143: (System.Object [])) = [|var_132; var_137|]: (System.Object [])
    var_138.RunAsync(var_141, var_143)
    let (var_144: EnvHeap3) = var_1.mem_0
    let (var_145: (int64 ref)) = var_144.mem_0
    let (var_146: EnvStack0) = var_144.mem_1
    let (var_147: (uint64 ref)) = var_146.mem_0
    let (var_148: uint64) = method_5((var_147: (uint64 ref)))
    let (var_149: uint64) = method_5((var_101: (uint64 ref)))
    let (var_150: uint64) = method_5((var_89: (uint64 ref)))
    let (var_151: EnvHeap3) = var_0.mem_0
    let (var_152: (int64 ref)) = var_151.mem_0
    let (var_153: EnvStack0) = var_151.mem_1
    let (var_154: (uint64 ref)) = var_153.mem_0
    let (var_155: uint64) = method_5((var_154: (uint64 ref)))
    // Cuda join point
    // method_51((var_148: uint64), (var_149: uint64), (var_150: uint64), (var_155: uint64))
    let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_17, var_14)
    let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_156.set_GridDimensions(var_157)
    let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_156.set_BlockDimensions(var_158)
    let (var_159: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_161: (System.Object [])) = [|var_148; var_149; var_150; var_155|]: (System.Object [])
    var_156.RunAsync(var_159, var_161)
    method_46((var_0: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: EnvStack0), (var_11: uint64), (var_12: ResizeArray<Env1>), (var_13: ResizeArray<Env2>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<EnvHeap3>), (var_16: ResizeArray<EnvHeap4>), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: EnvHeap4))
    let (var_162: uint64) = method_5((var_154: (uint64 ref)))
    let (var_163: EnvHeap3) = var_2.mem_0
    let (var_164: (int64 ref)) = var_163.mem_0
    let (var_165: EnvStack0) = var_163.mem_1
    let (var_166: (uint64 ref)) = var_165.mem_0
    let (var_167: uint64) = method_5((var_166: (uint64 ref)))
    // Cuda join point
    // method_47((var_162: uint64), (var_167: uint64))
    let (var_168: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_17, var_14)
    let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_168.set_GridDimensions(var_169)
    let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_168.set_BlockDimensions(var_170)
    let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_63: (bool ref)), (var_64: ManagedCuda.CudaStream))
    let (var_173: (System.Object [])) = [|var_162; var_167|]: (System.Object [])
    var_168.RunAsync(var_171, var_173)
and method_52 ((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4)) (): float32 =
    let (var_12: int64) = 1L
    let (var_13: int64) = 0L
    let (var_14: (float32 [])) = method_53((var_12: int64), (var_0: EnvStack8), (var_13: int64))
    var_14.[int32 0L]
and method_61((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64), (var_33: float), (var_34: int64), (var_35: ResizeArray<EnvHeap3>), (var_36: (unit -> float32)), (var_37: (unit -> unit)), (var_38: EnvStack8), (var_39: EnvStack8), (var_40: int64)): float =
    let (var_41: bool) = (var_40 < 4L)
    if var_41 then
        let (var_42: bool) = (var_40 >= 0L)
        let (var_43: bool) = (var_42 = false)
        if var_43 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_44: int64) = (var_40 * 256L)
        let (var_45: int64) = (var_1 + var_44)
        if var_43 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_46: int64) = (var_2 + var_44)
        let (var_47: EnvHeap3) = var_0.mem_0
        let (var_48: int64) = 1024L
        let (var_49: EnvHeap7) = ({mem_0 = (var_23: EnvStack0); mem_1 = (var_24: uint64); mem_2 = (var_25: ResizeArray<Env1>); mem_3 = (var_26: ResizeArray<Env2>)} : EnvHeap7)
        let (var_50: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_48: int64))
        let (var_51: EnvStack8) = EnvStack8((var_50: EnvHeap3))
        method_24((var_12: EnvStack8), (var_0: EnvStack8), (var_45: int64), (var_51: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_52: EnvHeap3) = var_51.mem_0
        let (var_53: int64) = 1024L
        let (var_54: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_53: int64))
        let (var_55: EnvStack8) = EnvStack8((var_54: EnvHeap3))
        let (var_56: (int64 ref)) = var_31.mem_0
        let (var_57: EnvHeap5) = var_31.mem_1
        let (var_58: (bool ref)) = var_57.mem_0
        let (var_59: ManagedCuda.CudaStream) = var_57.mem_1
        let (var_60: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_61: EnvHeap3) = var_55.mem_0
        let (var_62: (int64 ref)) = var_61.mem_0
        let (var_63: EnvStack0) = var_61.mem_1
        let (var_64: (uint64 ref)) = var_63.mem_0
        let (var_65: uint64) = method_5((var_64: (uint64 ref)))
        let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_65)
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_66)
        let (var_68: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_67, 0uy, var_68, var_60)
        method_54((var_18: EnvStack8), (var_39: EnvStack8), (var_51: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_69: EnvHeap3) = var_6.mem_0
        let (var_70: (int64 ref)) = var_69.mem_0
        let (var_71: EnvStack0) = var_69.mem_1
        let (var_72: (uint64 ref)) = var_71.mem_0
        let (var_73: uint64) = method_5((var_72: (uint64 ref)))
        let (var_74: (int64 ref)) = var_52.mem_0
        let (var_75: EnvStack0) = var_52.mem_1
        let (var_76: (uint64 ref)) = var_75.mem_0
        let (var_77: uint64) = method_5((var_76: (uint64 ref)))
        let (var_78: uint64) = method_5((var_76: (uint64 ref)))
        // Cuda join point
        // method_25((var_73: uint64), (var_77: uint64), (var_78: uint64))
        let (var_79: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_79.set_GridDimensions(var_80)
        let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_79.set_BlockDimensions(var_81)
        let (var_82: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_84: (System.Object [])) = [|var_73; var_77; var_78|]: (System.Object [])
        var_79.RunAsync(var_82, var_84)
        let (var_86: int64) = 1024L
        let (var_87: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_86: int64))
        let (var_88: EnvStack8) = EnvStack8((var_87: EnvHeap3))
        let (var_89: uint64) = method_5((var_76: (uint64 ref)))
        let (var_90: EnvHeap3) = var_88.mem_0
        let (var_91: (int64 ref)) = var_90.mem_0
        let (var_92: EnvStack0) = var_90.mem_1
        let (var_93: (uint64 ref)) = var_92.mem_0
        let (var_94: uint64) = method_5((var_93: (uint64 ref)))
        // Cuda join point
        // method_27((var_89: uint64), (var_94: uint64))
        let (var_95: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_30, var_27)
        let (var_96: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_95.set_GridDimensions(var_96)
        let (var_97: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_95.set_BlockDimensions(var_97)
        let (var_98: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_100: (System.Object [])) = [|var_89; var_94|]: (System.Object [])
        var_95.RunAsync(var_98, var_100)
        let (var_101: int64) = 1024L
        let (var_102: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_101: int64))
        let (var_103: EnvStack8) = EnvStack8((var_102: EnvHeap3))
        let (var_104: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_105: EnvHeap3) = var_103.mem_0
        let (var_106: (int64 ref)) = var_105.mem_0
        let (var_107: EnvStack0) = var_105.mem_1
        let (var_108: (uint64 ref)) = var_107.mem_0
        let (var_109: uint64) = method_5((var_108: (uint64 ref)))
        let (var_110: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_109)
        let (var_111: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_110)
        let (var_112: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_111, 0uy, var_112, var_104)
        let (var_113: int64) = 1024L
        let (var_114: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_113: int64))
        let (var_115: EnvStack8) = EnvStack8((var_114: EnvHeap3))
        method_24((var_14: EnvStack8), (var_0: EnvStack8), (var_45: int64), (var_115: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_116: EnvHeap3) = var_115.mem_0
        let (var_117: int64) = 1024L
        let (var_118: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_117: int64))
        let (var_119: EnvStack8) = EnvStack8((var_118: EnvHeap3))
        let (var_120: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_121: EnvHeap3) = var_119.mem_0
        let (var_122: (int64 ref)) = var_121.mem_0
        let (var_123: EnvStack0) = var_121.mem_1
        let (var_124: (uint64 ref)) = var_123.mem_0
        let (var_125: uint64) = method_5((var_124: (uint64 ref)))
        let (var_126: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_125)
        let (var_127: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_126)
        let (var_128: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_127, 0uy, var_128, var_120)
        method_54((var_20: EnvStack8), (var_39: EnvStack8), (var_115: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_129: EnvHeap3) = var_8.mem_0
        let (var_130: (int64 ref)) = var_129.mem_0
        let (var_131: EnvStack0) = var_129.mem_1
        let (var_132: (uint64 ref)) = var_131.mem_0
        let (var_133: uint64) = method_5((var_132: (uint64 ref)))
        let (var_134: (int64 ref)) = var_116.mem_0
        let (var_135: EnvStack0) = var_116.mem_1
        let (var_136: (uint64 ref)) = var_135.mem_0
        let (var_137: uint64) = method_5((var_136: (uint64 ref)))
        let (var_138: uint64) = method_5((var_136: (uint64 ref)))
        // Cuda join point
        // method_25((var_133: uint64), (var_137: uint64), (var_138: uint64))
        let (var_139: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_139.set_GridDimensions(var_140)
        let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_139.set_BlockDimensions(var_141)
        let (var_142: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_144: (System.Object [])) = [|var_133; var_137; var_138|]: (System.Object [])
        var_139.RunAsync(var_142, var_144)
        let (var_149: int64) = 1024L
        let (var_150: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_149: int64))
        let (var_151: EnvStack8) = EnvStack8((var_150: EnvHeap3))
        let (var_152: uint64) = method_5((var_136: (uint64 ref)))
        let (var_153: EnvHeap3) = var_151.mem_0
        let (var_154: (int64 ref)) = var_153.mem_0
        let (var_155: EnvStack0) = var_153.mem_1
        let (var_156: (uint64 ref)) = var_155.mem_0
        let (var_157: uint64) = method_5((var_156: (uint64 ref)))
        // Cuda join point
        // method_29((var_152: uint64), (var_157: uint64))
        let (var_158: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_158.set_GridDimensions(var_159)
        let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_158.set_BlockDimensions(var_160)
        let (var_161: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_163: (System.Object [])) = [|var_152; var_157|]: (System.Object [])
        var_158.RunAsync(var_161, var_163)
        let (var_164: int64) = 1024L
        let (var_165: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_164: int64))
        let (var_166: EnvStack8) = EnvStack8((var_165: EnvHeap3))
        let (var_167: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_168: EnvHeap3) = var_166.mem_0
        let (var_169: (int64 ref)) = var_168.mem_0
        let (var_170: EnvStack0) = var_168.mem_1
        let (var_171: (uint64 ref)) = var_170.mem_0
        let (var_172: uint64) = method_5((var_171: (uint64 ref)))
        let (var_173: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_172)
        let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_173)
        let (var_175: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_174, 0uy, var_175, var_167)
        let (var_176: int64) = 1024L
        let (var_177: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_176: int64))
        let (var_178: EnvStack8) = EnvStack8((var_177: EnvHeap3))
        method_24((var_10: EnvStack8), (var_0: EnvStack8), (var_45: int64), (var_178: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_179: EnvHeap3) = var_178.mem_0
        let (var_180: int64) = 1024L
        let (var_181: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_180: int64))
        let (var_182: EnvStack8) = EnvStack8((var_181: EnvHeap3))
        let (var_183: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_184: EnvHeap3) = var_182.mem_0
        let (var_185: (int64 ref)) = var_184.mem_0
        let (var_186: EnvStack0) = var_184.mem_1
        let (var_187: (uint64 ref)) = var_186.mem_0
        let (var_188: uint64) = method_5((var_187: (uint64 ref)))
        let (var_189: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_188)
        let (var_190: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_189)
        let (var_191: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_190, 0uy, var_191, var_183)
        method_54((var_16: EnvStack8), (var_39: EnvStack8), (var_178: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_192: EnvHeap3) = var_4.mem_0
        let (var_193: (int64 ref)) = var_192.mem_0
        let (var_194: EnvStack0) = var_192.mem_1
        let (var_195: (uint64 ref)) = var_194.mem_0
        let (var_196: uint64) = method_5((var_195: (uint64 ref)))
        let (var_197: (int64 ref)) = var_179.mem_0
        let (var_198: EnvStack0) = var_179.mem_1
        let (var_199: (uint64 ref)) = var_198.mem_0
        let (var_200: uint64) = method_5((var_199: (uint64 ref)))
        let (var_201: uint64) = method_5((var_199: (uint64 ref)))
        // Cuda join point
        // method_25((var_196: uint64), (var_200: uint64), (var_201: uint64))
        let (var_202: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_202.set_GridDimensions(var_203)
        let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_202.set_BlockDimensions(var_204)
        let (var_205: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_207: (System.Object [])) = [|var_196; var_200; var_201|]: (System.Object [])
        var_202.RunAsync(var_205, var_207)
        let (var_212: int64) = 1024L
        let (var_213: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_212: int64))
        let (var_214: EnvStack8) = EnvStack8((var_213: EnvHeap3))
        let (var_215: uint64) = method_5((var_199: (uint64 ref)))
        let (var_216: EnvHeap3) = var_214.mem_0
        let (var_217: (int64 ref)) = var_216.mem_0
        let (var_218: EnvStack0) = var_216.mem_1
        let (var_219: (uint64 ref)) = var_218.mem_0
        let (var_220: uint64) = method_5((var_219: (uint64 ref)))
        // Cuda join point
        // method_29((var_215: uint64), (var_220: uint64))
        let (var_221: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_222: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_221.set_GridDimensions(var_222)
        let (var_223: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_221.set_BlockDimensions(var_223)
        let (var_224: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_226: (System.Object [])) = [|var_215; var_220|]: (System.Object [])
        var_221.RunAsync(var_224, var_226)
        let (var_227: int64) = 1024L
        let (var_228: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_227: int64))
        let (var_229: EnvStack8) = EnvStack8((var_228: EnvHeap3))
        let (var_230: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_231: EnvHeap3) = var_229.mem_0
        let (var_232: (int64 ref)) = var_231.mem_0
        let (var_233: EnvStack0) = var_231.mem_1
        let (var_234: (uint64 ref)) = var_233.mem_0
        let (var_235: uint64) = method_5((var_234: (uint64 ref)))
        let (var_236: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_235)
        let (var_237: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_236)
        let (var_238: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_237, 0uy, var_238, var_230)
        let (var_240: int64) = 1024L
        let (var_241: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_240: int64))
        let (var_242: EnvStack8) = EnvStack8((var_241: EnvHeap3))
        let (var_243: uint64) = method_5((var_93: (uint64 ref)))
        let (var_244: uint64) = method_5((var_156: (uint64 ref)))
        let (var_245: EnvHeap3) = var_242.mem_0
        let (var_246: (int64 ref)) = var_245.mem_0
        let (var_247: EnvStack0) = var_245.mem_1
        let (var_248: (uint64 ref)) = var_247.mem_0
        let (var_249: uint64) = method_5((var_248: (uint64 ref)))
        // Cuda join point
        // method_30((var_243: uint64), (var_244: uint64), (var_249: uint64))
        let (var_250: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_30, var_27)
        let (var_251: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_250.set_GridDimensions(var_251)
        let (var_252: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_250.set_BlockDimensions(var_252)
        let (var_253: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_255: (System.Object [])) = [|var_243; var_244; var_249|]: (System.Object [])
        var_250.RunAsync(var_253, var_255)
        let (var_256: int64) = 1024L
        let (var_257: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_256: int64))
        let (var_258: EnvStack8) = EnvStack8((var_257: EnvHeap3))
        let (var_259: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_260: EnvHeap3) = var_258.mem_0
        let (var_261: (int64 ref)) = var_260.mem_0
        let (var_262: EnvStack0) = var_260.mem_1
        let (var_263: (uint64 ref)) = var_262.mem_0
        let (var_264: uint64) = method_5((var_263: (uint64 ref)))
        let (var_265: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_264)
        let (var_266: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_265)
        let (var_267: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_266, 0uy, var_267, var_259)
        let (var_270: int64) = 1024L
        let (var_271: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_270: int64))
        let (var_272: EnvStack8) = EnvStack8((var_271: EnvHeap3))
        let (var_273: EnvHeap3) = var_39.mem_0
        let (var_274: (int64 ref)) = var_273.mem_0
        let (var_275: EnvStack0) = var_273.mem_1
        let (var_276: (uint64 ref)) = var_275.mem_0
        let (var_277: uint64) = method_5((var_276: (uint64 ref)))
        let (var_278: uint64) = method_5((var_219: (uint64 ref)))
        let (var_279: EnvHeap3) = var_272.mem_0
        let (var_280: (int64 ref)) = var_279.mem_0
        let (var_281: EnvStack0) = var_279.mem_1
        let (var_282: (uint64 ref)) = var_281.mem_0
        let (var_283: uint64) = method_5((var_282: (uint64 ref)))
        // Cuda join point
        // method_30((var_277: uint64), (var_278: uint64), (var_283: uint64))
        let (var_284: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_30, var_27)
        let (var_285: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_284.set_GridDimensions(var_285)
        let (var_286: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_284.set_BlockDimensions(var_286)
        let (var_287: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_289: (System.Object [])) = [|var_277; var_278; var_283|]: (System.Object [])
        var_284.RunAsync(var_287, var_289)
        let (var_290: int64) = 1024L
        let (var_291: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_290: int64))
        let (var_292: EnvStack8) = EnvStack8((var_291: EnvHeap3))
        let (var_293: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_294: EnvHeap3) = var_292.mem_0
        let (var_295: (int64 ref)) = var_294.mem_0
        let (var_296: EnvStack0) = var_294.mem_1
        let (var_297: (uint64 ref)) = var_296.mem_0
        let (var_298: uint64) = method_5((var_297: (uint64 ref)))
        let (var_299: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_298)
        let (var_300: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_299)
        let (var_301: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_300, 0uy, var_301, var_293)
        let (var_303: int64) = 1024L
        let (var_304: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_303: int64))
        let (var_305: EnvStack8) = EnvStack8((var_304: EnvHeap3))
        let (var_306: uint64) = method_5((var_248: (uint64 ref)))
        let (var_307: uint64) = method_5((var_282: (uint64 ref)))
        let (var_308: EnvHeap3) = var_305.mem_0
        let (var_309: (int64 ref)) = var_308.mem_0
        let (var_310: EnvStack0) = var_308.mem_1
        let (var_311: (uint64 ref)) = var_310.mem_0
        let (var_312: uint64) = method_5((var_311: (uint64 ref)))
        // Cuda join point
        // method_55((var_306: uint64), (var_307: uint64), (var_312: uint64))
        let (var_313: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_30, var_27)
        let (var_314: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_313.set_GridDimensions(var_314)
        let (var_315: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_313.set_BlockDimensions(var_315)
        let (var_316: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_318: (System.Object [])) = [|var_306; var_307; var_312|]: (System.Object [])
        var_313.RunAsync(var_316, var_318)
        let (var_319: int64) = 1024L
        let (var_320: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_319: int64))
        let (var_321: EnvStack8) = EnvStack8((var_320: EnvHeap3))
        let (var_322: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_323: EnvHeap3) = var_321.mem_0
        let (var_324: (int64 ref)) = var_323.mem_0
        let (var_325: EnvStack0) = var_323.mem_1
        let (var_326: (uint64 ref)) = var_325.mem_0
        let (var_327: uint64) = method_5((var_326: (uint64 ref)))
        let (var_328: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_327)
        let (var_329: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_328)
        let (var_330: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_329, 0uy, var_330, var_322)
        let (var_335: int64) = 1024L
        let (var_336: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_335: int64))
        let (var_337: EnvStack8) = EnvStack8((var_336: EnvHeap3))
        let (var_338: uint64) = method_5((var_311: (uint64 ref)))
        let (var_339: EnvHeap3) = var_337.mem_0
        let (var_340: (int64 ref)) = var_339.mem_0
        let (var_341: EnvStack0) = var_339.mem_1
        let (var_342: (uint64 ref)) = var_341.mem_0
        let (var_343: uint64) = method_5((var_342: (uint64 ref)))
        // Cuda join point
        // method_29((var_338: uint64), (var_343: uint64))
        let (var_344: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_345: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_344.set_GridDimensions(var_345)
        let (var_346: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_344.set_BlockDimensions(var_346)
        let (var_347: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_349: (System.Object [])) = [|var_338; var_343|]: (System.Object [])
        var_344.RunAsync(var_347, var_349)
        let (var_350: int64) = 1024L
        let (var_351: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_350: int64))
        let (var_352: EnvStack8) = EnvStack8((var_351: EnvHeap3))
        let (var_353: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_354: EnvHeap3) = var_352.mem_0
        let (var_355: (int64 ref)) = var_354.mem_0
        let (var_356: EnvStack0) = var_354.mem_1
        let (var_357: (uint64 ref)) = var_356.mem_0
        let (var_358: uint64) = method_5((var_357: (uint64 ref)))
        let (var_359: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_358)
        let (var_360: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_359)
        let (var_361: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_360, 0uy, var_361, var_353)
        let (var_362: int64) = 128L
        let (var_363: int64) = 1L
        let (var_364: int64) = 0L
        let (var_365: int64) = 2L
        let (var_366: int64) = 0L
        let (var_367: int64) = 128L
        method_31((var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_0: EnvStack8), (var_46: int64), (var_362: int64), (var_363: int64), (var_364: int64), (var_365: int64), (var_366: int64), (var_367: int64))
        let (var_368: uint64) = method_5((var_342: (uint64 ref)))
        let (var_369: (int64 ref)) = var_47.mem_0
        let (var_370: EnvStack0) = var_47.mem_1
        let (var_371: (uint64 ref)) = var_370.mem_0
        let (var_372: uint64) = method_5((var_371: (uint64 ref)))
        let (var_373: int64) = (var_46 * 4L)
        let (var_374: uint64) = (uint64 var_373)
        let (var_375: uint64) = (var_372 + var_374)
        let (var_384: int64) = 4L
        let (var_385: EnvHeap3) = method_11((var_49: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_384: int64))
        let (var_386: EnvStack8) = EnvStack8((var_385: EnvHeap3))
        let (var_387: EnvHeap3) = var_386.mem_0
        let (var_388: (int64 ref)) = var_387.mem_0
        let (var_389: EnvStack0) = var_387.mem_1
        let (var_390: (uint64 ref)) = var_389.mem_0
        let (var_391: uint64) = method_5((var_390: (uint64 ref)))
        // Cuda join point
        // method_40((var_368: uint64), (var_375: uint64), (var_391: uint64))
        let (var_392: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_30, var_27)
        let (var_393: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_392.set_GridDimensions(var_393)
        let (var_394: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
        var_392.set_BlockDimensions(var_394)
        let (var_395: ManagedCuda.BasicTypes.CUstream) = method_19((var_58: (bool ref)), (var_59: ManagedCuda.CudaStream))
        let (var_397: (System.Object [])) = [|var_368; var_375; var_391|]: (System.Object [])
        var_392.RunAsync(var_395, var_397)
        let (var_398: (unit -> unit)) = method_56((var_37: (unit -> unit)), (var_55: EnvStack8), (var_51: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_0: EnvStack8), (var_45: int64), (var_11: EnvStack8), (var_12: EnvStack8), (var_38: EnvStack8), (var_39: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_103: EnvStack8), (var_88: EnvStack8), (var_119: EnvStack8), (var_115: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_166: EnvStack8), (var_151: EnvStack8), (var_182: EnvStack8), (var_178: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_229: EnvStack8), (var_214: EnvStack8), (var_258: EnvStack8), (var_242: EnvStack8), (var_292: EnvStack8), (var_272: EnvStack8), (var_321: EnvStack8), (var_305: EnvStack8), (var_352: EnvStack8), (var_337: EnvStack8), (var_386: EnvStack8), (var_46: int64))
        let (var_399: (unit -> float32)) = method_60((var_386: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_36: (unit -> float32)))
        let (var_400: int64) = (var_40 + 1L)
        method_61((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64), (var_33: float), (var_34: int64), (var_35: ResizeArray<EnvHeap3>), (var_399: (unit -> float32)), (var_398: (unit -> unit)), (var_352: EnvStack8), (var_337: EnvStack8), (var_400: int64))
    else
        let (var_402: float32) = var_36()
        let (var_403: float) = (float var_402)
        let (var_404: float) = (var_33 + var_403)
        let (var_413: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_414: EnvHeap3) = var_39.mem_0
        method_15((var_414: EnvHeap3), (var_413: ResizeArray<EnvHeap3>))
        let (var_415: int64) = (var_32 + 1L)
        if (System.Double.IsNaN var_404) then
            method_62((var_28: ResizeArray<EnvHeap3>))
            method_62((var_413: ResizeArray<EnvHeap3>))
            let (var_416: float) = (float var_415)
            (var_404 / var_416)
        else
            var_37()
            let (var_418: EnvHeap3) = var_4.mem_0
            let (var_419: (int64 ref)) = var_418.mem_0
            let (var_420: EnvStack0) = var_418.mem_1
            let (var_421: (uint64 ref)) = var_420.mem_0
            let (var_422: uint64) = method_5((var_421: (uint64 ref)))
            let (var_423: EnvHeap3) = var_3.mem_0
            let (var_424: (int64 ref)) = var_423.mem_0
            let (var_425: EnvStack0) = var_423.mem_1
            let (var_426: (uint64 ref)) = var_425.mem_0
            let (var_427: uint64) = method_5((var_426: (uint64 ref)))
            // Cuda join point
            // method_64((var_422: uint64), (var_427: uint64))
            let (var_428: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_429: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_428.set_GridDimensions(var_429)
            let (var_430: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_428.set_BlockDimensions(var_430)
            let (var_431: (int64 ref)) = var_31.mem_0
            let (var_432: EnvHeap5) = var_31.mem_1
            let (var_433: (bool ref)) = var_432.mem_0
            let (var_434: ManagedCuda.CudaStream) = var_432.mem_1
            let (var_435: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_437: (System.Object [])) = [|var_422; var_427|]: (System.Object [])
            var_428.RunAsync(var_435, var_437)
            let (var_438: EnvHeap3) = var_6.mem_0
            let (var_439: (int64 ref)) = var_438.mem_0
            let (var_440: EnvStack0) = var_438.mem_1
            let (var_441: (uint64 ref)) = var_440.mem_0
            let (var_442: uint64) = method_5((var_441: (uint64 ref)))
            let (var_443: EnvHeap3) = var_5.mem_0
            let (var_444: (int64 ref)) = var_443.mem_0
            let (var_445: EnvStack0) = var_443.mem_1
            let (var_446: (uint64 ref)) = var_445.mem_0
            let (var_447: uint64) = method_5((var_446: (uint64 ref)))
            // Cuda join point
            // method_64((var_442: uint64), (var_447: uint64))
            let (var_448: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_449: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_448.set_GridDimensions(var_449)
            let (var_450: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_448.set_BlockDimensions(var_450)
            let (var_451: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_453: (System.Object [])) = [|var_442; var_447|]: (System.Object [])
            var_448.RunAsync(var_451, var_453)
            let (var_454: EnvHeap3) = var_8.mem_0
            let (var_455: (int64 ref)) = var_454.mem_0
            let (var_456: EnvStack0) = var_454.mem_1
            let (var_457: (uint64 ref)) = var_456.mem_0
            let (var_458: uint64) = method_5((var_457: (uint64 ref)))
            let (var_459: EnvHeap3) = var_7.mem_0
            let (var_460: (int64 ref)) = var_459.mem_0
            let (var_461: EnvStack0) = var_459.mem_1
            let (var_462: (uint64 ref)) = var_461.mem_0
            let (var_463: uint64) = method_5((var_462: (uint64 ref)))
            // Cuda join point
            // method_64((var_458: uint64), (var_463: uint64))
            let (var_464: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_465: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_464.set_GridDimensions(var_465)
            let (var_466: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_464.set_BlockDimensions(var_466)
            let (var_467: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_469: (System.Object [])) = [|var_458; var_463|]: (System.Object [])
            var_464.RunAsync(var_467, var_469)
            let (var_470: EnvHeap3) = var_10.mem_0
            let (var_471: (int64 ref)) = var_470.mem_0
            let (var_472: EnvStack0) = var_470.mem_1
            let (var_473: (uint64 ref)) = var_472.mem_0
            let (var_474: uint64) = method_5((var_473: (uint64 ref)))
            let (var_475: EnvHeap3) = var_9.mem_0
            let (var_476: (int64 ref)) = var_475.mem_0
            let (var_477: EnvStack0) = var_475.mem_1
            let (var_478: (uint64 ref)) = var_477.mem_0
            let (var_479: uint64) = method_5((var_478: (uint64 ref)))
            // Cuda join point
            // method_65((var_474: uint64), (var_479: uint64))
            let (var_480: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_481: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_480.set_GridDimensions(var_481)
            let (var_482: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_480.set_BlockDimensions(var_482)
            let (var_483: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_485: (System.Object [])) = [|var_474; var_479|]: (System.Object [])
            var_480.RunAsync(var_483, var_485)
            let (var_486: EnvHeap3) = var_12.mem_0
            let (var_487: (int64 ref)) = var_486.mem_0
            let (var_488: EnvStack0) = var_486.mem_1
            let (var_489: (uint64 ref)) = var_488.mem_0
            let (var_490: uint64) = method_5((var_489: (uint64 ref)))
            let (var_491: EnvHeap3) = var_11.mem_0
            let (var_492: (int64 ref)) = var_491.mem_0
            let (var_493: EnvStack0) = var_491.mem_1
            let (var_494: (uint64 ref)) = var_493.mem_0
            let (var_495: uint64) = method_5((var_494: (uint64 ref)))
            // Cuda join point
            // method_65((var_490: uint64), (var_495: uint64))
            let (var_496: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_497: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_496.set_GridDimensions(var_497)
            let (var_498: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_496.set_BlockDimensions(var_498)
            let (var_499: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_501: (System.Object [])) = [|var_490; var_495|]: (System.Object [])
            var_496.RunAsync(var_499, var_501)
            let (var_502: EnvHeap3) = var_14.mem_0
            let (var_503: (int64 ref)) = var_502.mem_0
            let (var_504: EnvStack0) = var_502.mem_1
            let (var_505: (uint64 ref)) = var_504.mem_0
            let (var_506: uint64) = method_5((var_505: (uint64 ref)))
            let (var_507: EnvHeap3) = var_13.mem_0
            let (var_508: (int64 ref)) = var_507.mem_0
            let (var_509: EnvStack0) = var_507.mem_1
            let (var_510: (uint64 ref)) = var_509.mem_0
            let (var_511: uint64) = method_5((var_510: (uint64 ref)))
            // Cuda join point
            // method_65((var_506: uint64), (var_511: uint64))
            let (var_512: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_513: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_512.set_GridDimensions(var_513)
            let (var_514: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_512.set_BlockDimensions(var_514)
            let (var_515: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_517: (System.Object [])) = [|var_506; var_511|]: (System.Object [])
            var_512.RunAsync(var_515, var_517)
            let (var_518: EnvHeap3) = var_16.mem_0
            let (var_519: (int64 ref)) = var_518.mem_0
            let (var_520: EnvStack0) = var_518.mem_1
            let (var_521: (uint64 ref)) = var_520.mem_0
            let (var_522: uint64) = method_5((var_521: (uint64 ref)))
            let (var_523: EnvHeap3) = var_15.mem_0
            let (var_524: (int64 ref)) = var_523.mem_0
            let (var_525: EnvStack0) = var_523.mem_1
            let (var_526: (uint64 ref)) = var_525.mem_0
            let (var_527: uint64) = method_5((var_526: (uint64 ref)))
            // Cuda join point
            // method_65((var_522: uint64), (var_527: uint64))
            let (var_528: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_529: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_528.set_GridDimensions(var_529)
            let (var_530: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_528.set_BlockDimensions(var_530)
            let (var_531: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_533: (System.Object [])) = [|var_522; var_527|]: (System.Object [])
            var_528.RunAsync(var_531, var_533)
            let (var_534: EnvHeap3) = var_18.mem_0
            let (var_535: (int64 ref)) = var_534.mem_0
            let (var_536: EnvStack0) = var_534.mem_1
            let (var_537: (uint64 ref)) = var_536.mem_0
            let (var_538: uint64) = method_5((var_537: (uint64 ref)))
            let (var_539: EnvHeap3) = var_17.mem_0
            let (var_540: (int64 ref)) = var_539.mem_0
            let (var_541: EnvStack0) = var_539.mem_1
            let (var_542: (uint64 ref)) = var_541.mem_0
            let (var_543: uint64) = method_5((var_542: (uint64 ref)))
            // Cuda join point
            // method_65((var_538: uint64), (var_543: uint64))
            let (var_544: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_545: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_544.set_GridDimensions(var_545)
            let (var_546: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_544.set_BlockDimensions(var_546)
            let (var_547: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_549: (System.Object [])) = [|var_538; var_543|]: (System.Object [])
            var_544.RunAsync(var_547, var_549)
            let (var_550: EnvHeap3) = var_20.mem_0
            let (var_551: (int64 ref)) = var_550.mem_0
            let (var_552: EnvStack0) = var_550.mem_1
            let (var_553: (uint64 ref)) = var_552.mem_0
            let (var_554: uint64) = method_5((var_553: (uint64 ref)))
            let (var_555: EnvHeap3) = var_19.mem_0
            let (var_556: (int64 ref)) = var_555.mem_0
            let (var_557: EnvStack0) = var_555.mem_1
            let (var_558: (uint64 ref)) = var_557.mem_0
            let (var_559: uint64) = method_5((var_558: (uint64 ref)))
            // Cuda join point
            // method_65((var_554: uint64), (var_559: uint64))
            let (var_560: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_561: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_560.set_GridDimensions(var_561)
            let (var_562: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_560.set_BlockDimensions(var_562)
            let (var_563: ManagedCuda.BasicTypes.CUstream) = method_19((var_433: (bool ref)), (var_434: ManagedCuda.CudaStream))
            let (var_565: (System.Object [])) = [|var_554; var_559|]: (System.Object [])
            var_560.RunAsync(var_563, var_565)
            method_62((var_28: ResizeArray<EnvHeap3>))
            let (var_566: int64) = (var_34 + 1L)
            method_67((var_0: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_35: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_415: int64), (var_404: float), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_413: ResizeArray<EnvHeap3>), (var_39: EnvStack8), (var_566: int64))
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
and method_32((var_0: int64), (var_1: EnvStack8), (var_2: int64), (var_3: int64), (var_4: int64)): (float32 []) =
    let (var_5: EnvHeap3) = var_1.mem_0
    let (var_6: int64) = (var_0 * var_3)
    let (var_7: (int64 ref)) = var_5.mem_0
    let (var_8: EnvStack0) = var_5.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    let (var_11: int64) = (var_2 * 4L)
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: uint64) = (var_10 + var_12)
    let (var_14: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_6))
    let (var_15: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_14,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_16: int64) = var_15.AddrOfPinnedObject().ToInt64()
    let (var_17: uint64) = (uint64 var_16)
    let (var_18: int64) = (var_6 * 4L)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_24: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_20, var_22, var_23)
    if var_24 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_24)
    var_15.Free()
    var_14
and method_33((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_34((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.AppendLine("[|")
    let (var_13: int64) = method_35((var_8: System.Text.StringBuilder), (var_9: string), (var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_10: int64))
    let (var_14: int64) = 0L
    method_34((var_8: System.Text.StringBuilder), (var_14: int64))
    let (var_15: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_16: string) = var_8.ToString()
    let (var_17: string) = System.String.Format("{0}",var_16)
    System.Console.WriteLine(var_17)
and method_46((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 128, 2, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_53((var_0: int64), (var_1: EnvStack8), (var_2: int64)): (float32 []) =
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
and method_54((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
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
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 2, 128, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_56 ((var_0: (unit -> unit)), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_32: EnvStack8), (var_33: EnvStack8), (var_34: EnvStack8), (var_35: EnvStack8), (var_36: EnvStack8), (var_37: EnvStack8), (var_38: EnvStack8), (var_39: EnvStack8), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack8), (var_43: EnvStack8), (var_44: EnvStack8), (var_45: EnvStack8), (var_46: EnvStack8), (var_47: EnvStack8), (var_48: EnvStack8), (var_49: EnvStack8), (var_50: EnvStack8), (var_51: EnvStack8), (var_52: EnvStack8), (var_53: EnvStack8), (var_54: EnvStack8), (var_55: int64)) (): unit =
    let (var_56: EnvHeap3) = var_54.mem_0
    let (var_57: (int64 ref)) = var_56.mem_0
    let (var_58: EnvStack0) = var_56.mem_1
    let (var_59: (uint64 ref)) = var_58.mem_0
    let (var_60: uint64) = method_5((var_59: (uint64 ref)))
    let (var_61: EnvHeap3) = var_53.mem_0
    let (var_62: (int64 ref)) = var_61.mem_0
    let (var_63: EnvStack0) = var_61.mem_1
    let (var_64: (uint64 ref)) = var_63.mem_0
    let (var_65: uint64) = method_5((var_64: (uint64 ref)))
    let (var_66: EnvHeap3) = var_5.mem_0
    let (var_67: (int64 ref)) = var_66.mem_0
    let (var_68: EnvStack0) = var_66.mem_1
    let (var_69: (uint64 ref)) = var_68.mem_0
    let (var_70: uint64) = method_5((var_69: (uint64 ref)))
    let (var_71: int64) = (var_55 * 4L)
    let (var_72: uint64) = (uint64 var_71)
    let (var_73: uint64) = (var_70 + var_72)
    let (var_74: EnvHeap3) = var_52.mem_0
    let (var_75: (int64 ref)) = var_74.mem_0
    let (var_76: EnvStack0) = var_74.mem_1
    let (var_77: (uint64 ref)) = var_76.mem_0
    let (var_78: uint64) = method_5((var_77: (uint64 ref)))
    // Cuda join point
    // method_43((var_60: uint64), (var_65: uint64), (var_73: uint64), (var_78: uint64))
    let (var_79: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_22, var_19)
    let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_79.set_GridDimensions(var_80)
    let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_79.set_BlockDimensions(var_81)
    let (var_82: (int64 ref)) = var_23.mem_0
    let (var_83: EnvHeap5) = var_23.mem_1
    let (var_84: (bool ref)) = var_83.mem_0
    let (var_85: ManagedCuda.CudaStream) = var_83.mem_1
    let (var_86: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_88: (System.Object [])) = [|var_60; var_65; var_73; var_78|]: (System.Object [])
    var_79.RunAsync(var_86, var_88)
    let (var_89: EnvHeap3) = var_51.mem_0
    let (var_90: (int64 ref)) = var_89.mem_0
    let (var_91: EnvStack0) = var_89.mem_1
    let (var_92: (uint64 ref)) = var_91.mem_0
    let (var_93: uint64) = method_5((var_92: (uint64 ref)))
    let (var_94: uint64) = method_5((var_77: (uint64 ref)))
    let (var_95: uint64) = method_5((var_64: (uint64 ref)))
    let (var_96: EnvHeap3) = var_50.mem_0
    let (var_97: (int64 ref)) = var_96.mem_0
    let (var_98: EnvStack0) = var_96.mem_1
    let (var_99: (uint64 ref)) = var_98.mem_0
    let (var_100: uint64) = method_5((var_99: (uint64 ref)))
    // Cuda join point
    // method_44((var_93: uint64), (var_94: uint64), (var_95: uint64), (var_100: uint64))
    let (var_101: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_22, var_19)
    let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_101.set_GridDimensions(var_102)
    let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_101.set_BlockDimensions(var_103)
    let (var_104: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_106: (System.Object [])) = [|var_93; var_94; var_95; var_100|]: (System.Object [])
    var_101.RunAsync(var_104, var_106)
    let (var_107: EnvHeap3) = var_47.mem_0
    let (var_108: (int64 ref)) = var_107.mem_0
    let (var_109: EnvStack0) = var_107.mem_1
    let (var_110: (uint64 ref)) = var_109.mem_0
    let (var_111: uint64) = method_5((var_110: (uint64 ref)))
    let (var_112: EnvHeap3) = var_49.mem_0
    let (var_113: (int64 ref)) = var_112.mem_0
    let (var_114: EnvStack0) = var_112.mem_1
    let (var_115: (uint64 ref)) = var_114.mem_0
    let (var_116: uint64) = method_5((var_115: (uint64 ref)))
    let (var_117: uint64) = method_5((var_99: (uint64 ref)))
    let (var_118: uint64) = method_5((var_92: (uint64 ref)))
    let (var_119: EnvHeap3) = var_46.mem_0
    let (var_120: (int64 ref)) = var_119.mem_0
    let (var_121: EnvStack0) = var_119.mem_1
    let (var_122: (uint64 ref)) = var_121.mem_0
    let (var_123: uint64) = method_5((var_122: (uint64 ref)))
    let (var_124: EnvHeap3) = var_48.mem_0
    let (var_125: (int64 ref)) = var_124.mem_0
    let (var_126: EnvStack0) = var_124.mem_1
    let (var_127: (uint64 ref)) = var_126.mem_0
    let (var_128: uint64) = method_5((var_127: (uint64 ref)))
    // Cuda join point
    // method_57((var_111: uint64), (var_116: uint64), (var_117: uint64), (var_118: uint64), (var_123: uint64), (var_128: uint64))
    let (var_129: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_22, var_19)
    let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_129.set_GridDimensions(var_130)
    let (var_131: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_129.set_BlockDimensions(var_131)
    let (var_132: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_134: (System.Object [])) = [|var_111; var_116; var_117; var_118; var_123; var_128|]: (System.Object [])
    var_129.RunAsync(var_132, var_134)
    let (var_135: EnvHeap3) = var_10.mem_0
    let (var_136: (int64 ref)) = var_135.mem_0
    let (var_137: EnvStack0) = var_135.mem_1
    let (var_138: (uint64 ref)) = var_137.mem_0
    let (var_139: uint64) = method_5((var_138: (uint64 ref)))
    let (var_140: EnvHeap3) = var_45.mem_0
    let (var_141: (int64 ref)) = var_140.mem_0
    let (var_142: EnvStack0) = var_140.mem_1
    let (var_143: (uint64 ref)) = var_142.mem_0
    let (var_144: uint64) = method_5((var_143: (uint64 ref)))
    let (var_145: uint64) = method_5((var_127: (uint64 ref)))
    let (var_146: uint64) = method_5((var_115: (uint64 ref)))
    let (var_147: EnvHeap3) = var_9.mem_0
    let (var_148: (int64 ref)) = var_147.mem_0
    let (var_149: EnvStack0) = var_147.mem_1
    let (var_150: (uint64 ref)) = var_149.mem_0
    let (var_151: uint64) = method_5((var_150: (uint64 ref)))
    let (var_152: EnvHeap3) = var_44.mem_0
    let (var_153: (int64 ref)) = var_152.mem_0
    let (var_154: EnvStack0) = var_152.mem_1
    let (var_155: (uint64 ref)) = var_154.mem_0
    let (var_156: uint64) = method_5((var_155: (uint64 ref)))
    // Cuda join point
    // method_45((var_139: uint64), (var_144: uint64), (var_145: uint64), (var_146: uint64), (var_151: uint64), (var_156: uint64))
    let (var_157: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_22, var_19)
    let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_157.set_GridDimensions(var_158)
    let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_157.set_BlockDimensions(var_159)
    let (var_160: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_162: (System.Object [])) = [|var_139; var_144; var_145; var_146; var_151; var_156|]: (System.Object [])
    var_157.RunAsync(var_160, var_162)
    let (var_163: EnvHeap3) = var_25.mem_0
    let (var_164: (int64 ref)) = var_163.mem_0
    let (var_165: EnvStack0) = var_163.mem_1
    let (var_166: (uint64 ref)) = var_165.mem_0
    let (var_167: uint64) = method_5((var_166: (uint64 ref)))
    let (var_168: EnvHeap3) = var_35.mem_0
    let (var_169: (int64 ref)) = var_168.mem_0
    let (var_170: EnvStack0) = var_168.mem_1
    let (var_171: (uint64 ref)) = var_170.mem_0
    let (var_172: uint64) = method_5((var_171: (uint64 ref)))
    let (var_173: uint64) = method_5((var_122: (uint64 ref)))
    let (var_174: uint64) = method_5((var_110: (uint64 ref)))
    let (var_175: EnvHeap3) = var_24.mem_0
    let (var_176: (int64 ref)) = var_175.mem_0
    let (var_177: EnvStack0) = var_175.mem_1
    let (var_178: (uint64 ref)) = var_177.mem_0
    let (var_179: uint64) = method_5((var_178: (uint64 ref)))
    let (var_180: EnvHeap3) = var_34.mem_0
    let (var_181: (int64 ref)) = var_180.mem_0
    let (var_182: EnvStack0) = var_180.mem_1
    let (var_183: (uint64 ref)) = var_182.mem_0
    let (var_184: uint64) = method_5((var_183: (uint64 ref)))
    // Cuda join point
    // method_45((var_167: uint64), (var_172: uint64), (var_173: uint64), (var_174: uint64), (var_179: uint64), (var_184: uint64))
    let (var_185: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_22, var_19)
    let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_185.set_GridDimensions(var_186)
    let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_185.set_BlockDimensions(var_187)
    let (var_188: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_190: (System.Object [])) = [|var_167; var_172; var_173; var_174; var_179; var_184|]: (System.Object [])
    var_185.RunAsync(var_188, var_190)
    let (var_191: EnvHeap3) = var_37.mem_0
    let (var_192: (int64 ref)) = var_191.mem_0
    let (var_193: EnvStack0) = var_191.mem_1
    let (var_194: (uint64 ref)) = var_193.mem_0
    let (var_195: uint64) = method_5((var_194: (uint64 ref)))
    let (var_196: uint64) = method_5((var_155: (uint64 ref)))
    let (var_197: uint64) = method_5((var_143: (uint64 ref)))
    let (var_198: EnvHeap3) = var_36.mem_0
    let (var_199: (int64 ref)) = var_198.mem_0
    let (var_200: EnvStack0) = var_198.mem_1
    let (var_201: (uint64 ref)) = var_200.mem_0
    let (var_202: uint64) = method_5((var_201: (uint64 ref)))
    // Cuda join point
    // method_44((var_195: uint64), (var_196: uint64), (var_197: uint64), (var_202: uint64))
    let (var_203: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_22, var_19)
    let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_203.set_GridDimensions(var_204)
    let (var_205: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_203.set_BlockDimensions(var_205)
    let (var_206: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_208: (System.Object [])) = [|var_195; var_196; var_197; var_202|]: (System.Object [])
    var_203.RunAsync(var_206, var_208)
    method_46((var_36: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_40: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_58((var_43: EnvStack8), (var_36: EnvStack8), (var_9: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_59((var_36: EnvStack8), (var_10: EnvStack8), (var_42: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    let (var_209: uint64) = method_5((var_201: (uint64 ref)))
    let (var_210: EnvHeap3) = var_38.mem_0
    let (var_211: (int64 ref)) = var_210.mem_0
    let (var_212: EnvStack0) = var_210.mem_1
    let (var_213: (uint64 ref)) = var_212.mem_0
    let (var_214: uint64) = method_5((var_213: (uint64 ref)))
    // Cuda join point
    // method_47((var_209: uint64), (var_214: uint64))
    let (var_215: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_22, var_19)
    let (var_216: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_215.set_GridDimensions(var_216)
    let (var_217: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_215.set_BlockDimensions(var_217)
    let (var_218: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_220: (System.Object [])) = [|var_209; var_214|]: (System.Object [])
    var_215.RunAsync(var_218, var_220)
    let (var_221: EnvHeap3) = var_27.mem_0
    let (var_222: (int64 ref)) = var_221.mem_0
    let (var_223: EnvStack0) = var_221.mem_1
    let (var_224: (uint64 ref)) = var_223.mem_0
    let (var_225: uint64) = method_5((var_224: (uint64 ref)))
    let (var_226: uint64) = method_5((var_183: (uint64 ref)))
    let (var_227: uint64) = method_5((var_171: (uint64 ref)))
    let (var_228: EnvHeap3) = var_26.mem_0
    let (var_229: (int64 ref)) = var_228.mem_0
    let (var_230: EnvStack0) = var_228.mem_1
    let (var_231: (uint64 ref)) = var_230.mem_0
    let (var_232: uint64) = method_5((var_231: (uint64 ref)))
    // Cuda join point
    // method_44((var_225: uint64), (var_226: uint64), (var_227: uint64), (var_232: uint64))
    let (var_233: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_22, var_19)
    let (var_234: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_233.set_GridDimensions(var_234)
    let (var_235: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_233.set_BlockDimensions(var_235)
    let (var_236: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_238: (System.Object [])) = [|var_225; var_226; var_227; var_232|]: (System.Object [])
    var_233.RunAsync(var_236, var_238)
    method_46((var_26: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_30: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_58((var_33: EnvStack8), (var_26: EnvStack8), (var_9: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_59((var_26: EnvStack8), (var_10: EnvStack8), (var_32: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    let (var_239: uint64) = method_5((var_231: (uint64 ref)))
    let (var_240: EnvHeap3) = var_28.mem_0
    let (var_241: (int64 ref)) = var_240.mem_0
    let (var_242: EnvStack0) = var_240.mem_1
    let (var_243: (uint64 ref)) = var_242.mem_0
    let (var_244: uint64) = method_5((var_243: (uint64 ref)))
    // Cuda join point
    // method_47((var_239: uint64), (var_244: uint64))
    let (var_245: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_22, var_19)
    let (var_246: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_245.set_GridDimensions(var_246)
    let (var_247: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_245.set_BlockDimensions(var_247)
    let (var_248: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_250: (System.Object [])) = [|var_239; var_244|]: (System.Object [])
    var_245.RunAsync(var_248, var_250)
    let (var_251: EnvHeap3) = var_2.mem_0
    let (var_252: (int64 ref)) = var_251.mem_0
    let (var_253: EnvStack0) = var_251.mem_1
    let (var_254: (uint64 ref)) = var_253.mem_0
    let (var_255: uint64) = method_5((var_254: (uint64 ref)))
    let (var_256: uint64) = method_5((var_178: (uint64 ref)))
    let (var_257: uint64) = method_5((var_166: (uint64 ref)))
    let (var_258: EnvHeap3) = var_1.mem_0
    let (var_259: (int64 ref)) = var_258.mem_0
    let (var_260: EnvStack0) = var_258.mem_1
    let (var_261: (uint64 ref)) = var_260.mem_0
    let (var_262: uint64) = method_5((var_261: (uint64 ref)))
    // Cuda join point
    // method_51((var_255: uint64), (var_256: uint64), (var_257: uint64), (var_262: uint64))
    let (var_263: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_22, var_19)
    let (var_264: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_263.set_GridDimensions(var_264)
    let (var_265: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_263.set_BlockDimensions(var_265)
    let (var_266: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_268: (System.Object [])) = [|var_255; var_256; var_257; var_262|]: (System.Object [])
    var_263.RunAsync(var_266, var_268)
    method_46((var_1: EnvStack8), (var_5: EnvStack8), (var_6: int64), (var_7: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_58((var_12: EnvStack8), (var_1: EnvStack8), (var_9: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    method_59((var_1: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_13: ManagedCuda.CudaBlas.CudaBlas), (var_14: ManagedCuda.CudaRand.CudaRandDevice), (var_15: EnvStack0), (var_16: uint64), (var_17: ResizeArray<Env1>), (var_18: ResizeArray<Env2>), (var_19: ManagedCuda.CudaContext), (var_20: ResizeArray<EnvHeap3>), (var_21: ResizeArray<EnvHeap4>), (var_22: ManagedCuda.BasicTypes.CUmodule), (var_23: EnvHeap4))
    let (var_269: uint64) = method_5((var_261: (uint64 ref)))
    let (var_270: EnvHeap3) = var_3.mem_0
    let (var_271: (int64 ref)) = var_270.mem_0
    let (var_272: EnvStack0) = var_270.mem_1
    let (var_273: (uint64 ref)) = var_272.mem_0
    let (var_274: uint64) = method_5((var_273: (uint64 ref)))
    // Cuda join point
    // method_47((var_269: uint64), (var_274: uint64))
    let (var_275: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_22, var_19)
    let (var_276: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_275.set_GridDimensions(var_276)
    let (var_277: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_275.set_BlockDimensions(var_277)
    let (var_278: ManagedCuda.BasicTypes.CUstream) = method_19((var_84: (bool ref)), (var_85: ManagedCuda.CudaStream))
    let (var_280: (System.Object [])) = [|var_269; var_274|]: (System.Object [])
    var_275.RunAsync(var_278, var_280)
    var_0()
and method_60 ((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: (unit -> float32))) (): float32 =
    let (var_13: float32) = var_12()
    let (var_14: int64) = 1L
    let (var_15: int64) = 0L
    let (var_16: (float32 [])) = method_53((var_14: int64), (var_0: EnvStack8), (var_15: int64))
    let (var_17: float32) = var_16.[int32 0L]
    (var_13 + var_17)
and method_67((var_0: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_32: ResizeArray<EnvHeap3>), (var_33: EnvStack8), (var_34: int64)): float =
    let (var_35: bool) = (var_34 < 1L)
    if var_35 then
        let (var_36: bool) = (var_34 >= 0L)
        let (var_37: bool) = (var_36 = false)
        if var_37 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_38: int64) = (var_34 * 1024L)
        if var_37 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_39: int64) = (1024L + var_38)
        let (var_40: EnvHeap7) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap7)
        let (var_41: EnvStack0) = var_40.mem_0
        let (var_42: uint64) = var_40.mem_1
        let (var_43: ResizeArray<Env1>) = var_40.mem_2
        let (var_44: ResizeArray<Env2>) = var_40.mem_3
        method_1((var_43: ResizeArray<Env1>), (var_41: EnvStack0), (var_42: uint64), (var_44: ResizeArray<Env2>))
        let (var_48: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_401: EnvHeap3) = var_0.mem_0
        let (var_402: int64) = 1024L
        let (var_403: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_402: int64))
        let (var_404: EnvStack8) = EnvStack8((var_403: EnvHeap3))
        method_24((var_23: EnvStack8), (var_0: EnvStack8), (var_38: int64), (var_404: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_405: EnvHeap3) = var_404.mem_0
        let (var_406: int64) = 1024L
        let (var_407: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_406: int64))
        let (var_408: EnvStack8) = EnvStack8((var_407: EnvHeap3))
        let (var_409: (int64 ref)) = var_11.mem_0
        let (var_410: EnvHeap5) = var_11.mem_1
        let (var_411: (bool ref)) = var_410.mem_0
        let (var_412: ManagedCuda.CudaStream) = var_410.mem_1
        let (var_413: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_414: EnvHeap3) = var_408.mem_0
        let (var_415: (int64 ref)) = var_414.mem_0
        let (var_416: EnvStack0) = var_414.mem_1
        let (var_417: (uint64 ref)) = var_416.mem_0
        let (var_418: uint64) = method_5((var_417: (uint64 ref)))
        let (var_419: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_418)
        let (var_420: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_419)
        let (var_421: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_420, 0uy, var_421, var_413)
        method_54((var_29: EnvStack8), (var_33: EnvStack8), (var_404: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_422: EnvHeap3) = var_17.mem_0
        let (var_423: (int64 ref)) = var_422.mem_0
        let (var_424: EnvStack0) = var_422.mem_1
        let (var_425: (uint64 ref)) = var_424.mem_0
        let (var_426: uint64) = method_5((var_425: (uint64 ref)))
        let (var_427: (int64 ref)) = var_405.mem_0
        let (var_428: EnvStack0) = var_405.mem_1
        let (var_429: (uint64 ref)) = var_428.mem_0
        let (var_430: uint64) = method_5((var_429: (uint64 ref)))
        let (var_431: uint64) = method_5((var_429: (uint64 ref)))
        // Cuda join point
        // method_25((var_426: uint64), (var_430: uint64), (var_431: uint64))
        let (var_432: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_433: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_432.set_GridDimensions(var_433)
        let (var_434: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_432.set_BlockDimensions(var_434)
        let (var_435: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_437: (System.Object [])) = [|var_426; var_430; var_431|]: (System.Object [])
        var_432.RunAsync(var_435, var_437)
        let (var_439: int64) = 1024L
        let (var_440: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_439: int64))
        let (var_441: EnvStack8) = EnvStack8((var_440: EnvHeap3))
        let (var_442: uint64) = method_5((var_429: (uint64 ref)))
        let (var_443: EnvHeap3) = var_441.mem_0
        let (var_444: (int64 ref)) = var_443.mem_0
        let (var_445: EnvStack0) = var_443.mem_1
        let (var_446: (uint64 ref)) = var_445.mem_0
        let (var_447: uint64) = method_5((var_446: (uint64 ref)))
        // Cuda join point
        // method_27((var_442: uint64), (var_447: uint64))
        let (var_448: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_10, var_7)
        let (var_449: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_448.set_GridDimensions(var_449)
        let (var_450: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_448.set_BlockDimensions(var_450)
        let (var_451: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_453: (System.Object [])) = [|var_442; var_447|]: (System.Object [])
        var_448.RunAsync(var_451, var_453)
        let (var_454: int64) = 1024L
        let (var_455: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_454: int64))
        let (var_456: EnvStack8) = EnvStack8((var_455: EnvHeap3))
        let (var_457: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_458: EnvHeap3) = var_456.mem_0
        let (var_459: (int64 ref)) = var_458.mem_0
        let (var_460: EnvStack0) = var_458.mem_1
        let (var_461: (uint64 ref)) = var_460.mem_0
        let (var_462: uint64) = method_5((var_461: (uint64 ref)))
        let (var_463: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_462)
        let (var_464: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_463)
        let (var_465: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_464, 0uy, var_465, var_457)
        let (var_466: int64) = 1024L
        let (var_467: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_466: int64))
        let (var_468: EnvStack8) = EnvStack8((var_467: EnvHeap3))
        method_24((var_25: EnvStack8), (var_0: EnvStack8), (var_38: int64), (var_468: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_469: EnvHeap3) = var_468.mem_0
        let (var_470: int64) = 1024L
        let (var_471: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_470: int64))
        let (var_472: EnvStack8) = EnvStack8((var_471: EnvHeap3))
        let (var_473: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_474: EnvHeap3) = var_472.mem_0
        let (var_475: (int64 ref)) = var_474.mem_0
        let (var_476: EnvStack0) = var_474.mem_1
        let (var_477: (uint64 ref)) = var_476.mem_0
        let (var_478: uint64) = method_5((var_477: (uint64 ref)))
        let (var_479: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_478)
        let (var_480: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_479)
        let (var_481: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_480, 0uy, var_481, var_473)
        method_54((var_31: EnvStack8), (var_33: EnvStack8), (var_468: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_482: EnvHeap3) = var_19.mem_0
        let (var_483: (int64 ref)) = var_482.mem_0
        let (var_484: EnvStack0) = var_482.mem_1
        let (var_485: (uint64 ref)) = var_484.mem_0
        let (var_486: uint64) = method_5((var_485: (uint64 ref)))
        let (var_487: (int64 ref)) = var_469.mem_0
        let (var_488: EnvStack0) = var_469.mem_1
        let (var_489: (uint64 ref)) = var_488.mem_0
        let (var_490: uint64) = method_5((var_489: (uint64 ref)))
        let (var_491: uint64) = method_5((var_489: (uint64 ref)))
        // Cuda join point
        // method_25((var_486: uint64), (var_490: uint64), (var_491: uint64))
        let (var_492: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_493: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_492.set_GridDimensions(var_493)
        let (var_494: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_492.set_BlockDimensions(var_494)
        let (var_495: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_497: (System.Object [])) = [|var_486; var_490; var_491|]: (System.Object [])
        var_492.RunAsync(var_495, var_497)
        let (var_502: int64) = 1024L
        let (var_503: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_502: int64))
        let (var_504: EnvStack8) = EnvStack8((var_503: EnvHeap3))
        let (var_505: uint64) = method_5((var_489: (uint64 ref)))
        let (var_506: EnvHeap3) = var_504.mem_0
        let (var_507: (int64 ref)) = var_506.mem_0
        let (var_508: EnvStack0) = var_506.mem_1
        let (var_509: (uint64 ref)) = var_508.mem_0
        let (var_510: uint64) = method_5((var_509: (uint64 ref)))
        // Cuda join point
        // method_29((var_505: uint64), (var_510: uint64))
        let (var_511: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_512: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_511.set_GridDimensions(var_512)
        let (var_513: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_511.set_BlockDimensions(var_513)
        let (var_514: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_516: (System.Object [])) = [|var_505; var_510|]: (System.Object [])
        var_511.RunAsync(var_514, var_516)
        let (var_517: int64) = 1024L
        let (var_518: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_517: int64))
        let (var_519: EnvStack8) = EnvStack8((var_518: EnvHeap3))
        let (var_520: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_521: EnvHeap3) = var_519.mem_0
        let (var_522: (int64 ref)) = var_521.mem_0
        let (var_523: EnvStack0) = var_521.mem_1
        let (var_524: (uint64 ref)) = var_523.mem_0
        let (var_525: uint64) = method_5((var_524: (uint64 ref)))
        let (var_526: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_525)
        let (var_527: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_526)
        let (var_528: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_527, 0uy, var_528, var_520)
        let (var_529: int64) = 1024L
        let (var_530: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_529: int64))
        let (var_531: EnvStack8) = EnvStack8((var_530: EnvHeap3))
        method_24((var_21: EnvStack8), (var_0: EnvStack8), (var_38: int64), (var_531: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_532: EnvHeap3) = var_531.mem_0
        let (var_533: int64) = 1024L
        let (var_534: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_533: int64))
        let (var_535: EnvStack8) = EnvStack8((var_534: EnvHeap3))
        let (var_536: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_537: EnvHeap3) = var_535.mem_0
        let (var_538: (int64 ref)) = var_537.mem_0
        let (var_539: EnvStack0) = var_537.mem_1
        let (var_540: (uint64 ref)) = var_539.mem_0
        let (var_541: uint64) = method_5((var_540: (uint64 ref)))
        let (var_542: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_541)
        let (var_543: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_542)
        let (var_544: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_543, 0uy, var_544, var_536)
        method_54((var_27: EnvStack8), (var_33: EnvStack8), (var_531: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_545: EnvHeap3) = var_15.mem_0
        let (var_546: (int64 ref)) = var_545.mem_0
        let (var_547: EnvStack0) = var_545.mem_1
        let (var_548: (uint64 ref)) = var_547.mem_0
        let (var_549: uint64) = method_5((var_548: (uint64 ref)))
        let (var_550: (int64 ref)) = var_532.mem_0
        let (var_551: EnvStack0) = var_532.mem_1
        let (var_552: (uint64 ref)) = var_551.mem_0
        let (var_553: uint64) = method_5((var_552: (uint64 ref)))
        let (var_554: uint64) = method_5((var_552: (uint64 ref)))
        // Cuda join point
        // method_25((var_549: uint64), (var_553: uint64), (var_554: uint64))
        let (var_555: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_556: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_555.set_GridDimensions(var_556)
        let (var_557: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_555.set_BlockDimensions(var_557)
        let (var_558: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_560: (System.Object [])) = [|var_549; var_553; var_554|]: (System.Object [])
        var_555.RunAsync(var_558, var_560)
        let (var_565: int64) = 1024L
        let (var_566: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_565: int64))
        let (var_567: EnvStack8) = EnvStack8((var_566: EnvHeap3))
        let (var_568: uint64) = method_5((var_552: (uint64 ref)))
        let (var_569: EnvHeap3) = var_567.mem_0
        let (var_570: (int64 ref)) = var_569.mem_0
        let (var_571: EnvStack0) = var_569.mem_1
        let (var_572: (uint64 ref)) = var_571.mem_0
        let (var_573: uint64) = method_5((var_572: (uint64 ref)))
        // Cuda join point
        // method_29((var_568: uint64), (var_573: uint64))
        let (var_574: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_575: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_574.set_GridDimensions(var_575)
        let (var_576: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_574.set_BlockDimensions(var_576)
        let (var_577: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_579: (System.Object [])) = [|var_568; var_573|]: (System.Object [])
        var_574.RunAsync(var_577, var_579)
        let (var_580: int64) = 1024L
        let (var_581: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_580: int64))
        let (var_582: EnvStack8) = EnvStack8((var_581: EnvHeap3))
        let (var_583: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_584: EnvHeap3) = var_582.mem_0
        let (var_585: (int64 ref)) = var_584.mem_0
        let (var_586: EnvStack0) = var_584.mem_1
        let (var_587: (uint64 ref)) = var_586.mem_0
        let (var_588: uint64) = method_5((var_587: (uint64 ref)))
        let (var_589: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_588)
        let (var_590: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_589)
        let (var_591: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_590, 0uy, var_591, var_583)
        let (var_593: int64) = 1024L
        let (var_594: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_593: int64))
        let (var_595: EnvStack8) = EnvStack8((var_594: EnvHeap3))
        let (var_596: uint64) = method_5((var_446: (uint64 ref)))
        let (var_597: uint64) = method_5((var_509: (uint64 ref)))
        let (var_598: EnvHeap3) = var_595.mem_0
        let (var_599: (int64 ref)) = var_598.mem_0
        let (var_600: EnvStack0) = var_598.mem_1
        let (var_601: (uint64 ref)) = var_600.mem_0
        let (var_602: uint64) = method_5((var_601: (uint64 ref)))
        // Cuda join point
        // method_30((var_596: uint64), (var_597: uint64), (var_602: uint64))
        let (var_603: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_10, var_7)
        let (var_604: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_603.set_GridDimensions(var_604)
        let (var_605: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_603.set_BlockDimensions(var_605)
        let (var_606: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_608: (System.Object [])) = [|var_596; var_597; var_602|]: (System.Object [])
        var_603.RunAsync(var_606, var_608)
        let (var_609: int64) = 1024L
        let (var_610: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_609: int64))
        let (var_611: EnvStack8) = EnvStack8((var_610: EnvHeap3))
        let (var_612: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_613: EnvHeap3) = var_611.mem_0
        let (var_614: (int64 ref)) = var_613.mem_0
        let (var_615: EnvStack0) = var_613.mem_1
        let (var_616: (uint64 ref)) = var_615.mem_0
        let (var_617: uint64) = method_5((var_616: (uint64 ref)))
        let (var_618: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_617)
        let (var_619: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_618)
        let (var_620: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_619, 0uy, var_620, var_612)
        let (var_623: int64) = 1024L
        let (var_624: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_623: int64))
        let (var_625: EnvStack8) = EnvStack8((var_624: EnvHeap3))
        let (var_626: EnvHeap3) = var_33.mem_0
        let (var_627: (int64 ref)) = var_626.mem_0
        let (var_628: EnvStack0) = var_626.mem_1
        let (var_629: (uint64 ref)) = var_628.mem_0
        let (var_630: uint64) = method_5((var_629: (uint64 ref)))
        let (var_631: uint64) = method_5((var_572: (uint64 ref)))
        let (var_632: EnvHeap3) = var_625.mem_0
        let (var_633: (int64 ref)) = var_632.mem_0
        let (var_634: EnvStack0) = var_632.mem_1
        let (var_635: (uint64 ref)) = var_634.mem_0
        let (var_636: uint64) = method_5((var_635: (uint64 ref)))
        // Cuda join point
        // method_30((var_630: uint64), (var_631: uint64), (var_636: uint64))
        let (var_637: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_10, var_7)
        let (var_638: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_637.set_GridDimensions(var_638)
        let (var_639: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_637.set_BlockDimensions(var_639)
        let (var_640: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_642: (System.Object [])) = [|var_630; var_631; var_636|]: (System.Object [])
        var_637.RunAsync(var_640, var_642)
        let (var_643: int64) = 1024L
        let (var_644: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_643: int64))
        let (var_645: EnvStack8) = EnvStack8((var_644: EnvHeap3))
        let (var_646: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_647: EnvHeap3) = var_645.mem_0
        let (var_648: (int64 ref)) = var_647.mem_0
        let (var_649: EnvStack0) = var_647.mem_1
        let (var_650: (uint64 ref)) = var_649.mem_0
        let (var_651: uint64) = method_5((var_650: (uint64 ref)))
        let (var_652: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_651)
        let (var_653: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_652)
        let (var_654: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_653, 0uy, var_654, var_646)
        let (var_656: int64) = 1024L
        let (var_657: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_656: int64))
        let (var_658: EnvStack8) = EnvStack8((var_657: EnvHeap3))
        let (var_659: uint64) = method_5((var_601: (uint64 ref)))
        let (var_660: uint64) = method_5((var_635: (uint64 ref)))
        let (var_661: EnvHeap3) = var_658.mem_0
        let (var_662: (int64 ref)) = var_661.mem_0
        let (var_663: EnvStack0) = var_661.mem_1
        let (var_664: (uint64 ref)) = var_663.mem_0
        let (var_665: uint64) = method_5((var_664: (uint64 ref)))
        // Cuda join point
        // method_55((var_659: uint64), (var_660: uint64), (var_665: uint64))
        let (var_666: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_10, var_7)
        let (var_667: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_666.set_GridDimensions(var_667)
        let (var_668: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_666.set_BlockDimensions(var_668)
        let (var_669: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_671: (System.Object [])) = [|var_659; var_660; var_665|]: (System.Object [])
        var_666.RunAsync(var_669, var_671)
        let (var_672: int64) = 1024L
        let (var_673: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_672: int64))
        let (var_674: EnvStack8) = EnvStack8((var_673: EnvHeap3))
        let (var_675: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_676: EnvHeap3) = var_674.mem_0
        let (var_677: (int64 ref)) = var_676.mem_0
        let (var_678: EnvStack0) = var_676.mem_1
        let (var_679: (uint64 ref)) = var_678.mem_0
        let (var_680: uint64) = method_5((var_679: (uint64 ref)))
        let (var_681: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_680)
        let (var_682: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_681)
        let (var_683: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_682, 0uy, var_683, var_675)
        let (var_688: int64) = 1024L
        let (var_689: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_688: int64))
        let (var_690: EnvStack8) = EnvStack8((var_689: EnvHeap3))
        let (var_691: uint64) = method_5((var_664: (uint64 ref)))
        let (var_692: EnvHeap3) = var_690.mem_0
        let (var_693: (int64 ref)) = var_692.mem_0
        let (var_694: EnvStack0) = var_692.mem_1
        let (var_695: (uint64 ref)) = var_694.mem_0
        let (var_696: uint64) = method_5((var_695: (uint64 ref)))
        // Cuda join point
        // method_29((var_691: uint64), (var_696: uint64))
        let (var_697: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_698: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_697.set_GridDimensions(var_698)
        let (var_699: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_697.set_BlockDimensions(var_699)
        let (var_700: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_702: (System.Object [])) = [|var_691; var_696|]: (System.Object [])
        var_697.RunAsync(var_700, var_702)
        let (var_703: int64) = 1024L
        let (var_704: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_703: int64))
        let (var_705: EnvStack8) = EnvStack8((var_704: EnvHeap3))
        let (var_706: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_707: EnvHeap3) = var_705.mem_0
        let (var_708: (int64 ref)) = var_707.mem_0
        let (var_709: EnvStack0) = var_707.mem_1
        let (var_710: (uint64 ref)) = var_709.mem_0
        let (var_711: uint64) = method_5((var_710: (uint64 ref)))
        let (var_712: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_711)
        let (var_713: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_712)
        let (var_714: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_7.ClearMemoryAsync(var_713, 0uy, var_714, var_706)
        let (var_715: int64) = 128L
        let (var_716: int64) = 1L
        let (var_717: int64) = 0L
        let (var_718: int64) = 2L
        let (var_719: int64) = 0L
        let (var_720: int64) = 128L
        method_31((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_0: EnvStack8), (var_39: int64), (var_715: int64), (var_716: int64), (var_717: int64), (var_718: int64), (var_719: int64), (var_720: int64))
        let (var_721: uint64) = method_5((var_695: (uint64 ref)))
        let (var_722: (int64 ref)) = var_401.mem_0
        let (var_723: EnvStack0) = var_401.mem_1
        let (var_724: (uint64 ref)) = var_723.mem_0
        let (var_725: uint64) = method_5((var_724: (uint64 ref)))
        let (var_726: int64) = (var_39 * 4L)
        let (var_727: uint64) = (uint64 var_726)
        let (var_728: uint64) = (var_725 + var_727)
        let (var_737: int64) = 4L
        let (var_738: EnvHeap3) = method_11((var_40: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_737: int64))
        let (var_739: EnvStack8) = EnvStack8((var_738: EnvHeap3))
        let (var_740: EnvHeap3) = var_739.mem_0
        let (var_741: (int64 ref)) = var_740.mem_0
        let (var_742: EnvStack0) = var_740.mem_1
        let (var_743: (uint64 ref)) = var_742.mem_0
        let (var_744: uint64) = method_5((var_743: (uint64 ref)))
        // Cuda join point
        // method_40((var_721: uint64), (var_728: uint64), (var_744: uint64))
        let (var_745: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_10, var_7)
        let (var_746: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_745.set_GridDimensions(var_746)
        let (var_747: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
        var_745.set_BlockDimensions(var_747)
        let (var_748: ManagedCuda.BasicTypes.CUstream) = method_19((var_411: (bool ref)), (var_412: ManagedCuda.CudaStream))
        let (var_750: (System.Object [])) = [|var_721; var_728; var_744|]: (System.Object [])
        var_745.RunAsync(var_748, var_750)
        let (var_751: (unit -> unit)) = method_68((var_408: EnvStack8), (var_404: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_0: EnvStack8), (var_38: int64), (var_22: EnvStack8), (var_23: EnvStack8), (var_33: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_456: EnvStack8), (var_441: EnvStack8), (var_472: EnvStack8), (var_468: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_519: EnvStack8), (var_504: EnvStack8), (var_535: EnvStack8), (var_531: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_582: EnvStack8), (var_567: EnvStack8), (var_611: EnvStack8), (var_595: EnvStack8), (var_645: EnvStack8), (var_625: EnvStack8), (var_674: EnvStack8), (var_658: EnvStack8), (var_705: EnvStack8), (var_690: EnvStack8), (var_739: EnvStack8), (var_39: int64))
        let (var_752: (unit -> float32)) = method_52((var_739: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_1082: int64) = 1L
        method_70((var_0: EnvStack8), (var_38: int64), (var_39: int64), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: EnvStack8), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_48: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_34: int64), (var_8: ResizeArray<EnvHeap3>), (var_32: ResizeArray<EnvHeap3>), (var_752: (unit -> float32)), (var_751: (unit -> unit)), (var_705: EnvStack8), (var_690: EnvStack8), (var_1082: int64))
    else
        method_62((var_32: ResizeArray<EnvHeap3>))
        let (var_1084: float) = (float var_12)
        (var_13 / var_1084)
and method_34((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_34((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_35((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): int64 =
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
            method_36((var_0: System.Text.StringBuilder), (var_15: int64))
            let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_17: int64) = method_37((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_3: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_19: int64) = (var_6 + 1L)
            method_39((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_17: int64), (var_19: int64))
        else
            let (var_21: int64) = 0L
            method_34((var_0: System.Text.StringBuilder), (var_21: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_58((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
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
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 2, 128, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_59((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
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
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 128, 128, 2, var_22, var_29, 128, var_36, 128, var_37, var_44, 128)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_68 ((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_22: EnvStack8), (var_23: EnvStack8), (var_24: EnvStack8), (var_25: EnvStack8), (var_26: EnvStack8), (var_27: EnvStack8), (var_28: EnvStack8), (var_29: EnvStack8), (var_30: EnvStack8), (var_31: EnvStack8), (var_32: EnvStack8), (var_33: EnvStack8), (var_34: EnvStack8), (var_35: EnvStack8), (var_36: EnvStack8), (var_37: EnvStack8), (var_38: EnvStack8), (var_39: EnvStack8), (var_40: EnvStack8), (var_41: EnvStack8), (var_42: EnvStack8), (var_43: EnvStack8), (var_44: EnvStack8), (var_45: EnvStack8), (var_46: EnvStack8), (var_47: EnvStack8), (var_48: EnvStack8), (var_49: EnvStack8), (var_50: EnvStack8), (var_51: EnvStack8), (var_52: EnvStack8), (var_53: int64)) (): unit =
    let (var_54: EnvHeap3) = var_52.mem_0
    let (var_55: (int64 ref)) = var_54.mem_0
    let (var_56: EnvStack0) = var_54.mem_1
    let (var_57: (uint64 ref)) = var_56.mem_0
    let (var_58: uint64) = method_5((var_57: (uint64 ref)))
    let (var_59: EnvHeap3) = var_51.mem_0
    let (var_60: (int64 ref)) = var_59.mem_0
    let (var_61: EnvStack0) = var_59.mem_1
    let (var_62: (uint64 ref)) = var_61.mem_0
    let (var_63: uint64) = method_5((var_62: (uint64 ref)))
    let (var_64: EnvHeap3) = var_4.mem_0
    let (var_65: (int64 ref)) = var_64.mem_0
    let (var_66: EnvStack0) = var_64.mem_1
    let (var_67: (uint64 ref)) = var_66.mem_0
    let (var_68: uint64) = method_5((var_67: (uint64 ref)))
    let (var_69: int64) = (var_53 * 4L)
    let (var_70: uint64) = (uint64 var_69)
    let (var_71: uint64) = (var_68 + var_70)
    let (var_72: EnvHeap3) = var_50.mem_0
    let (var_73: (int64 ref)) = var_72.mem_0
    let (var_74: EnvStack0) = var_72.mem_1
    let (var_75: (uint64 ref)) = var_74.mem_0
    let (var_76: uint64) = method_5((var_75: (uint64 ref)))
    // Cuda join point
    // method_43((var_58: uint64), (var_63: uint64), (var_71: uint64), (var_76: uint64))
    let (var_77: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_43", var_20, var_17)
    let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_77.set_GridDimensions(var_78)
    let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_77.set_BlockDimensions(var_79)
    let (var_80: (int64 ref)) = var_21.mem_0
    let (var_81: EnvHeap5) = var_21.mem_1
    let (var_82: (bool ref)) = var_81.mem_0
    let (var_83: ManagedCuda.CudaStream) = var_81.mem_1
    let (var_84: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_86: (System.Object [])) = [|var_58; var_63; var_71; var_76|]: (System.Object [])
    var_77.RunAsync(var_84, var_86)
    let (var_87: EnvHeap3) = var_49.mem_0
    let (var_88: (int64 ref)) = var_87.mem_0
    let (var_89: EnvStack0) = var_87.mem_1
    let (var_90: (uint64 ref)) = var_89.mem_0
    let (var_91: uint64) = method_5((var_90: (uint64 ref)))
    let (var_92: uint64) = method_5((var_75: (uint64 ref)))
    let (var_93: uint64) = method_5((var_62: (uint64 ref)))
    let (var_94: EnvHeap3) = var_48.mem_0
    let (var_95: (int64 ref)) = var_94.mem_0
    let (var_96: EnvStack0) = var_94.mem_1
    let (var_97: (uint64 ref)) = var_96.mem_0
    let (var_98: uint64) = method_5((var_97: (uint64 ref)))
    // Cuda join point
    // method_44((var_91: uint64), (var_92: uint64), (var_93: uint64), (var_98: uint64))
    let (var_99: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_20, var_17)
    let (var_100: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_99.set_GridDimensions(var_100)
    let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_99.set_BlockDimensions(var_101)
    let (var_102: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_104: (System.Object [])) = [|var_91; var_92; var_93; var_98|]: (System.Object [])
    var_99.RunAsync(var_102, var_104)
    let (var_105: EnvHeap3) = var_45.mem_0
    let (var_106: (int64 ref)) = var_105.mem_0
    let (var_107: EnvStack0) = var_105.mem_1
    let (var_108: (uint64 ref)) = var_107.mem_0
    let (var_109: uint64) = method_5((var_108: (uint64 ref)))
    let (var_110: EnvHeap3) = var_47.mem_0
    let (var_111: (int64 ref)) = var_110.mem_0
    let (var_112: EnvStack0) = var_110.mem_1
    let (var_113: (uint64 ref)) = var_112.mem_0
    let (var_114: uint64) = method_5((var_113: (uint64 ref)))
    let (var_115: uint64) = method_5((var_97: (uint64 ref)))
    let (var_116: uint64) = method_5((var_90: (uint64 ref)))
    let (var_117: EnvHeap3) = var_44.mem_0
    let (var_118: (int64 ref)) = var_117.mem_0
    let (var_119: EnvStack0) = var_117.mem_1
    let (var_120: (uint64 ref)) = var_119.mem_0
    let (var_121: uint64) = method_5((var_120: (uint64 ref)))
    let (var_122: EnvHeap3) = var_46.mem_0
    let (var_123: (int64 ref)) = var_122.mem_0
    let (var_124: EnvStack0) = var_122.mem_1
    let (var_125: (uint64 ref)) = var_124.mem_0
    let (var_126: uint64) = method_5((var_125: (uint64 ref)))
    // Cuda join point
    // method_57((var_109: uint64), (var_114: uint64), (var_115: uint64), (var_116: uint64), (var_121: uint64), (var_126: uint64))
    let (var_127: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_57", var_20, var_17)
    let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_127.set_GridDimensions(var_128)
    let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_127.set_BlockDimensions(var_129)
    let (var_130: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_132: (System.Object [])) = [|var_109; var_114; var_115; var_116; var_121; var_126|]: (System.Object [])
    var_127.RunAsync(var_130, var_132)
    let (var_133: EnvHeap3) = var_8.mem_0
    let (var_134: (int64 ref)) = var_133.mem_0
    let (var_135: EnvStack0) = var_133.mem_1
    let (var_136: (uint64 ref)) = var_135.mem_0
    let (var_137: uint64) = method_5((var_136: (uint64 ref)))
    let (var_138: EnvHeap3) = var_43.mem_0
    let (var_139: (int64 ref)) = var_138.mem_0
    let (var_140: EnvStack0) = var_138.mem_1
    let (var_141: (uint64 ref)) = var_140.mem_0
    let (var_142: uint64) = method_5((var_141: (uint64 ref)))
    let (var_143: uint64) = method_5((var_125: (uint64 ref)))
    let (var_144: uint64) = method_5((var_113: (uint64 ref)))
    let (var_145: EnvHeap3) = var_42.mem_0
    let (var_146: (int64 ref)) = var_145.mem_0
    let (var_147: EnvStack0) = var_145.mem_1
    let (var_148: (uint64 ref)) = var_147.mem_0
    let (var_149: uint64) = method_5((var_148: (uint64 ref)))
    // Cuda join point
    // method_69((var_137: uint64), (var_142: uint64), (var_143: uint64), (var_144: uint64), (var_149: uint64))
    let (var_150: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_69", var_20, var_17)
    let (var_151: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_150.set_GridDimensions(var_151)
    let (var_152: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_150.set_BlockDimensions(var_152)
    let (var_153: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_155: (System.Object [])) = [|var_137; var_142; var_143; var_144; var_149|]: (System.Object [])
    var_150.RunAsync(var_153, var_155)
    let (var_156: EnvHeap3) = var_23.mem_0
    let (var_157: (int64 ref)) = var_156.mem_0
    let (var_158: EnvStack0) = var_156.mem_1
    let (var_159: (uint64 ref)) = var_158.mem_0
    let (var_160: uint64) = method_5((var_159: (uint64 ref)))
    let (var_161: EnvHeap3) = var_33.mem_0
    let (var_162: (int64 ref)) = var_161.mem_0
    let (var_163: EnvStack0) = var_161.mem_1
    let (var_164: (uint64 ref)) = var_163.mem_0
    let (var_165: uint64) = method_5((var_164: (uint64 ref)))
    let (var_166: uint64) = method_5((var_120: (uint64 ref)))
    let (var_167: uint64) = method_5((var_108: (uint64 ref)))
    let (var_168: EnvHeap3) = var_22.mem_0
    let (var_169: (int64 ref)) = var_168.mem_0
    let (var_170: EnvStack0) = var_168.mem_1
    let (var_171: (uint64 ref)) = var_170.mem_0
    let (var_172: uint64) = method_5((var_171: (uint64 ref)))
    let (var_173: EnvHeap3) = var_32.mem_0
    let (var_174: (int64 ref)) = var_173.mem_0
    let (var_175: EnvStack0) = var_173.mem_1
    let (var_176: (uint64 ref)) = var_175.mem_0
    let (var_177: uint64) = method_5((var_176: (uint64 ref)))
    // Cuda join point
    // method_45((var_160: uint64), (var_165: uint64), (var_166: uint64), (var_167: uint64), (var_172: uint64), (var_177: uint64))
    let (var_178: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_20, var_17)
    let (var_179: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_178.set_GridDimensions(var_179)
    let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_178.set_BlockDimensions(var_180)
    let (var_181: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_183: (System.Object [])) = [|var_160; var_165; var_166; var_167; var_172; var_177|]: (System.Object [])
    var_178.RunAsync(var_181, var_183)
    let (var_184: EnvHeap3) = var_35.mem_0
    let (var_185: (int64 ref)) = var_184.mem_0
    let (var_186: EnvStack0) = var_184.mem_1
    let (var_187: (uint64 ref)) = var_186.mem_0
    let (var_188: uint64) = method_5((var_187: (uint64 ref)))
    let (var_189: uint64) = method_5((var_148: (uint64 ref)))
    let (var_190: uint64) = method_5((var_141: (uint64 ref)))
    let (var_191: EnvHeap3) = var_34.mem_0
    let (var_192: (int64 ref)) = var_191.mem_0
    let (var_193: EnvStack0) = var_191.mem_1
    let (var_194: (uint64 ref)) = var_193.mem_0
    let (var_195: uint64) = method_5((var_194: (uint64 ref)))
    // Cuda join point
    // method_44((var_188: uint64), (var_189: uint64), (var_190: uint64), (var_195: uint64))
    let (var_196: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_20, var_17)
    let (var_197: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_196.set_GridDimensions(var_197)
    let (var_198: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_196.set_BlockDimensions(var_198)
    let (var_199: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_201: (System.Object [])) = [|var_188; var_189; var_190; var_195|]: (System.Object [])
    var_196.RunAsync(var_199, var_201)
    method_46((var_34: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_38: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    method_59((var_34: EnvStack8), (var_8: EnvStack8), (var_40: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    let (var_202: uint64) = method_5((var_194: (uint64 ref)))
    let (var_203: EnvHeap3) = var_36.mem_0
    let (var_204: (int64 ref)) = var_203.mem_0
    let (var_205: EnvStack0) = var_203.mem_1
    let (var_206: (uint64 ref)) = var_205.mem_0
    let (var_207: uint64) = method_5((var_206: (uint64 ref)))
    // Cuda join point
    // method_47((var_202: uint64), (var_207: uint64))
    let (var_208: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_20, var_17)
    let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_208.set_GridDimensions(var_209)
    let (var_210: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_208.set_BlockDimensions(var_210)
    let (var_211: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_213: (System.Object [])) = [|var_202; var_207|]: (System.Object [])
    var_208.RunAsync(var_211, var_213)
    let (var_214: EnvHeap3) = var_25.mem_0
    let (var_215: (int64 ref)) = var_214.mem_0
    let (var_216: EnvStack0) = var_214.mem_1
    let (var_217: (uint64 ref)) = var_216.mem_0
    let (var_218: uint64) = method_5((var_217: (uint64 ref)))
    let (var_219: uint64) = method_5((var_176: (uint64 ref)))
    let (var_220: uint64) = method_5((var_164: (uint64 ref)))
    let (var_221: EnvHeap3) = var_24.mem_0
    let (var_222: (int64 ref)) = var_221.mem_0
    let (var_223: EnvStack0) = var_221.mem_1
    let (var_224: (uint64 ref)) = var_223.mem_0
    let (var_225: uint64) = method_5((var_224: (uint64 ref)))
    // Cuda join point
    // method_44((var_218: uint64), (var_219: uint64), (var_220: uint64), (var_225: uint64))
    let (var_226: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_20, var_17)
    let (var_227: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_226.set_GridDimensions(var_227)
    let (var_228: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_226.set_BlockDimensions(var_228)
    let (var_229: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_231: (System.Object [])) = [|var_218; var_219; var_220; var_225|]: (System.Object [])
    var_226.RunAsync(var_229, var_231)
    method_46((var_24: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_28: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    method_59((var_24: EnvStack8), (var_8: EnvStack8), (var_30: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    let (var_232: uint64) = method_5((var_224: (uint64 ref)))
    let (var_233: EnvHeap3) = var_26.mem_0
    let (var_234: (int64 ref)) = var_233.mem_0
    let (var_235: EnvStack0) = var_233.mem_1
    let (var_236: (uint64 ref)) = var_235.mem_0
    let (var_237: uint64) = method_5((var_236: (uint64 ref)))
    // Cuda join point
    // method_47((var_232: uint64), (var_237: uint64))
    let (var_238: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_20, var_17)
    let (var_239: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_238.set_GridDimensions(var_239)
    let (var_240: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_238.set_BlockDimensions(var_240)
    let (var_241: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_243: (System.Object [])) = [|var_232; var_237|]: (System.Object [])
    var_238.RunAsync(var_241, var_243)
    let (var_244: EnvHeap3) = var_1.mem_0
    let (var_245: (int64 ref)) = var_244.mem_0
    let (var_246: EnvStack0) = var_244.mem_1
    let (var_247: (uint64 ref)) = var_246.mem_0
    let (var_248: uint64) = method_5((var_247: (uint64 ref)))
    let (var_249: uint64) = method_5((var_171: (uint64 ref)))
    let (var_250: uint64) = method_5((var_159: (uint64 ref)))
    let (var_251: EnvHeap3) = var_0.mem_0
    let (var_252: (int64 ref)) = var_251.mem_0
    let (var_253: EnvStack0) = var_251.mem_1
    let (var_254: (uint64 ref)) = var_253.mem_0
    let (var_255: uint64) = method_5((var_254: (uint64 ref)))
    // Cuda join point
    // method_51((var_248: uint64), (var_249: uint64), (var_250: uint64), (var_255: uint64))
    let (var_256: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_20, var_17)
    let (var_257: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_256.set_GridDimensions(var_257)
    let (var_258: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_256.set_BlockDimensions(var_258)
    let (var_259: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_261: (System.Object [])) = [|var_248; var_249; var_250; var_255|]: (System.Object [])
    var_256.RunAsync(var_259, var_261)
    method_46((var_0: EnvStack8), (var_4: EnvStack8), (var_5: int64), (var_6: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    method_59((var_0: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4))
    let (var_262: uint64) = method_5((var_254: (uint64 ref)))
    let (var_263: EnvHeap3) = var_2.mem_0
    let (var_264: (int64 ref)) = var_263.mem_0
    let (var_265: EnvStack0) = var_263.mem_1
    let (var_266: (uint64 ref)) = var_265.mem_0
    let (var_267: uint64) = method_5((var_266: (uint64 ref)))
    // Cuda join point
    // method_47((var_262: uint64), (var_267: uint64))
    let (var_268: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_47", var_20, var_17)
    let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_268.set_GridDimensions(var_269)
    let (var_270: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
    var_268.set_BlockDimensions(var_270)
    let (var_271: ManagedCuda.BasicTypes.CUstream) = method_19((var_82: (bool ref)), (var_83: ManagedCuda.CudaStream))
    let (var_273: (System.Object [])) = [|var_262; var_267|]: (System.Object [])
    var_268.RunAsync(var_271, var_273)
and method_70((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64), (var_33: float), (var_34: int64), (var_35: ResizeArray<EnvHeap3>), (var_36: ResizeArray<EnvHeap3>), (var_37: (unit -> float32)), (var_38: (unit -> unit)), (var_39: EnvStack8), (var_40: EnvStack8), (var_41: int64)): float =
    let (var_42: bool) = (var_41 < 4L)
    if var_42 then
        let (var_43: bool) = (var_41 >= 0L)
        let (var_44: bool) = (var_43 = false)
        if var_44 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_45: int64) = (var_41 * 256L)
        let (var_46: int64) = (var_1 + var_45)
        if var_44 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_47: int64) = (var_2 + var_45)
        let (var_48: EnvHeap3) = var_0.mem_0
        let (var_49: int64) = 1024L
        let (var_50: EnvHeap7) = ({mem_0 = (var_23: EnvStack0); mem_1 = (var_24: uint64); mem_2 = (var_25: ResizeArray<Env1>); mem_3 = (var_26: ResizeArray<Env2>)} : EnvHeap7)
        let (var_51: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_49: int64))
        let (var_52: EnvStack8) = EnvStack8((var_51: EnvHeap3))
        method_24((var_12: EnvStack8), (var_0: EnvStack8), (var_46: int64), (var_52: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_53: EnvHeap3) = var_52.mem_0
        let (var_54: int64) = 1024L
        let (var_55: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_54: int64))
        let (var_56: EnvStack8) = EnvStack8((var_55: EnvHeap3))
        let (var_57: (int64 ref)) = var_31.mem_0
        let (var_58: EnvHeap5) = var_31.mem_1
        let (var_59: (bool ref)) = var_58.mem_0
        let (var_60: ManagedCuda.CudaStream) = var_58.mem_1
        let (var_61: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_62: EnvHeap3) = var_56.mem_0
        let (var_63: (int64 ref)) = var_62.mem_0
        let (var_64: EnvStack0) = var_62.mem_1
        let (var_65: (uint64 ref)) = var_64.mem_0
        let (var_66: uint64) = method_5((var_65: (uint64 ref)))
        let (var_67: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_66)
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_67)
        let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_68, 0uy, var_69, var_61)
        method_54((var_18: EnvStack8), (var_40: EnvStack8), (var_52: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_70: EnvHeap3) = var_6.mem_0
        let (var_71: (int64 ref)) = var_70.mem_0
        let (var_72: EnvStack0) = var_70.mem_1
        let (var_73: (uint64 ref)) = var_72.mem_0
        let (var_74: uint64) = method_5((var_73: (uint64 ref)))
        let (var_75: (int64 ref)) = var_53.mem_0
        let (var_76: EnvStack0) = var_53.mem_1
        let (var_77: (uint64 ref)) = var_76.mem_0
        let (var_78: uint64) = method_5((var_77: (uint64 ref)))
        let (var_79: uint64) = method_5((var_77: (uint64 ref)))
        // Cuda join point
        // method_25((var_74: uint64), (var_78: uint64), (var_79: uint64))
        let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_80.set_GridDimensions(var_81)
        let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_80.set_BlockDimensions(var_82)
        let (var_83: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_85: (System.Object [])) = [|var_74; var_78; var_79|]: (System.Object [])
        var_80.RunAsync(var_83, var_85)
        let (var_87: int64) = 1024L
        let (var_88: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_87: int64))
        let (var_89: EnvStack8) = EnvStack8((var_88: EnvHeap3))
        let (var_90: uint64) = method_5((var_77: (uint64 ref)))
        let (var_91: EnvHeap3) = var_89.mem_0
        let (var_92: (int64 ref)) = var_91.mem_0
        let (var_93: EnvStack0) = var_91.mem_1
        let (var_94: (uint64 ref)) = var_93.mem_0
        let (var_95: uint64) = method_5((var_94: (uint64 ref)))
        // Cuda join point
        // method_27((var_90: uint64), (var_95: uint64))
        let (var_96: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_30, var_27)
        let (var_97: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_96.set_GridDimensions(var_97)
        let (var_98: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_96.set_BlockDimensions(var_98)
        let (var_99: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_101: (System.Object [])) = [|var_90; var_95|]: (System.Object [])
        var_96.RunAsync(var_99, var_101)
        let (var_102: int64) = 1024L
        let (var_103: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_102: int64))
        let (var_104: EnvStack8) = EnvStack8((var_103: EnvHeap3))
        let (var_105: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_106: EnvHeap3) = var_104.mem_0
        let (var_107: (int64 ref)) = var_106.mem_0
        let (var_108: EnvStack0) = var_106.mem_1
        let (var_109: (uint64 ref)) = var_108.mem_0
        let (var_110: uint64) = method_5((var_109: (uint64 ref)))
        let (var_111: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_110)
        let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_111)
        let (var_113: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_112, 0uy, var_113, var_105)
        let (var_114: int64) = 1024L
        let (var_115: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_114: int64))
        let (var_116: EnvStack8) = EnvStack8((var_115: EnvHeap3))
        method_24((var_14: EnvStack8), (var_0: EnvStack8), (var_46: int64), (var_116: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_117: EnvHeap3) = var_116.mem_0
        let (var_118: int64) = 1024L
        let (var_119: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_118: int64))
        let (var_120: EnvStack8) = EnvStack8((var_119: EnvHeap3))
        let (var_121: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_122: EnvHeap3) = var_120.mem_0
        let (var_123: (int64 ref)) = var_122.mem_0
        let (var_124: EnvStack0) = var_122.mem_1
        let (var_125: (uint64 ref)) = var_124.mem_0
        let (var_126: uint64) = method_5((var_125: (uint64 ref)))
        let (var_127: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_126)
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_127)
        let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_128, 0uy, var_129, var_121)
        method_54((var_20: EnvStack8), (var_40: EnvStack8), (var_116: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_130: EnvHeap3) = var_8.mem_0
        let (var_131: (int64 ref)) = var_130.mem_0
        let (var_132: EnvStack0) = var_130.mem_1
        let (var_133: (uint64 ref)) = var_132.mem_0
        let (var_134: uint64) = method_5((var_133: (uint64 ref)))
        let (var_135: (int64 ref)) = var_117.mem_0
        let (var_136: EnvStack0) = var_117.mem_1
        let (var_137: (uint64 ref)) = var_136.mem_0
        let (var_138: uint64) = method_5((var_137: (uint64 ref)))
        let (var_139: uint64) = method_5((var_137: (uint64 ref)))
        // Cuda join point
        // method_25((var_134: uint64), (var_138: uint64), (var_139: uint64))
        let (var_140: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_140.set_GridDimensions(var_141)
        let (var_142: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_140.set_BlockDimensions(var_142)
        let (var_143: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_145: (System.Object [])) = [|var_134; var_138; var_139|]: (System.Object [])
        var_140.RunAsync(var_143, var_145)
        let (var_150: int64) = 1024L
        let (var_151: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_150: int64))
        let (var_152: EnvStack8) = EnvStack8((var_151: EnvHeap3))
        let (var_153: uint64) = method_5((var_137: (uint64 ref)))
        let (var_154: EnvHeap3) = var_152.mem_0
        let (var_155: (int64 ref)) = var_154.mem_0
        let (var_156: EnvStack0) = var_154.mem_1
        let (var_157: (uint64 ref)) = var_156.mem_0
        let (var_158: uint64) = method_5((var_157: (uint64 ref)))
        // Cuda join point
        // method_29((var_153: uint64), (var_158: uint64))
        let (var_159: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_159.set_GridDimensions(var_160)
        let (var_161: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_159.set_BlockDimensions(var_161)
        let (var_162: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_164: (System.Object [])) = [|var_153; var_158|]: (System.Object [])
        var_159.RunAsync(var_162, var_164)
        let (var_165: int64) = 1024L
        let (var_166: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_165: int64))
        let (var_167: EnvStack8) = EnvStack8((var_166: EnvHeap3))
        let (var_168: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_169: EnvHeap3) = var_167.mem_0
        let (var_170: (int64 ref)) = var_169.mem_0
        let (var_171: EnvStack0) = var_169.mem_1
        let (var_172: (uint64 ref)) = var_171.mem_0
        let (var_173: uint64) = method_5((var_172: (uint64 ref)))
        let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_173)
        let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_174)
        let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_175, 0uy, var_176, var_168)
        let (var_177: int64) = 1024L
        let (var_178: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_177: int64))
        let (var_179: EnvStack8) = EnvStack8((var_178: EnvHeap3))
        method_24((var_10: EnvStack8), (var_0: EnvStack8), (var_46: int64), (var_179: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_180: EnvHeap3) = var_179.mem_0
        let (var_181: int64) = 1024L
        let (var_182: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_181: int64))
        let (var_183: EnvStack8) = EnvStack8((var_182: EnvHeap3))
        let (var_184: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_185: EnvHeap3) = var_183.mem_0
        let (var_186: (int64 ref)) = var_185.mem_0
        let (var_187: EnvStack0) = var_185.mem_1
        let (var_188: (uint64 ref)) = var_187.mem_0
        let (var_189: uint64) = method_5((var_188: (uint64 ref)))
        let (var_190: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_189)
        let (var_191: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_190)
        let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_191, 0uy, var_192, var_184)
        method_54((var_16: EnvStack8), (var_40: EnvStack8), (var_179: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4))
        let (var_193: EnvHeap3) = var_4.mem_0
        let (var_194: (int64 ref)) = var_193.mem_0
        let (var_195: EnvStack0) = var_193.mem_1
        let (var_196: (uint64 ref)) = var_195.mem_0
        let (var_197: uint64) = method_5((var_196: (uint64 ref)))
        let (var_198: (int64 ref)) = var_180.mem_0
        let (var_199: EnvStack0) = var_180.mem_1
        let (var_200: (uint64 ref)) = var_199.mem_0
        let (var_201: uint64) = method_5((var_200: (uint64 ref)))
        let (var_202: uint64) = method_5((var_200: (uint64 ref)))
        // Cuda join point
        // method_25((var_197: uint64), (var_201: uint64), (var_202: uint64))
        let (var_203: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_30, var_27)
        let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_203.set_GridDimensions(var_204)
        let (var_205: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 2u, 1u)
        var_203.set_BlockDimensions(var_205)
        let (var_206: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_208: (System.Object [])) = [|var_197; var_201; var_202|]: (System.Object [])
        var_203.RunAsync(var_206, var_208)
        let (var_213: int64) = 1024L
        let (var_214: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_213: int64))
        let (var_215: EnvStack8) = EnvStack8((var_214: EnvHeap3))
        let (var_216: uint64) = method_5((var_200: (uint64 ref)))
        let (var_217: EnvHeap3) = var_215.mem_0
        let (var_218: (int64 ref)) = var_217.mem_0
        let (var_219: EnvStack0) = var_217.mem_1
        let (var_220: (uint64 ref)) = var_219.mem_0
        let (var_221: uint64) = method_5((var_220: (uint64 ref)))
        // Cuda join point
        // method_29((var_216: uint64), (var_221: uint64))
        let (var_222: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_223: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_222.set_GridDimensions(var_223)
        let (var_224: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_222.set_BlockDimensions(var_224)
        let (var_225: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_227: (System.Object [])) = [|var_216; var_221|]: (System.Object [])
        var_222.RunAsync(var_225, var_227)
        let (var_228: int64) = 1024L
        let (var_229: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_228: int64))
        let (var_230: EnvStack8) = EnvStack8((var_229: EnvHeap3))
        let (var_231: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_232: EnvHeap3) = var_230.mem_0
        let (var_233: (int64 ref)) = var_232.mem_0
        let (var_234: EnvStack0) = var_232.mem_1
        let (var_235: (uint64 ref)) = var_234.mem_0
        let (var_236: uint64) = method_5((var_235: (uint64 ref)))
        let (var_237: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_236)
        let (var_238: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_237)
        let (var_239: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_238, 0uy, var_239, var_231)
        let (var_241: int64) = 1024L
        let (var_242: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_241: int64))
        let (var_243: EnvStack8) = EnvStack8((var_242: EnvHeap3))
        let (var_244: uint64) = method_5((var_94: (uint64 ref)))
        let (var_245: uint64) = method_5((var_157: (uint64 ref)))
        let (var_246: EnvHeap3) = var_243.mem_0
        let (var_247: (int64 ref)) = var_246.mem_0
        let (var_248: EnvStack0) = var_246.mem_1
        let (var_249: (uint64 ref)) = var_248.mem_0
        let (var_250: uint64) = method_5((var_249: (uint64 ref)))
        // Cuda join point
        // method_30((var_244: uint64), (var_245: uint64), (var_250: uint64))
        let (var_251: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_30, var_27)
        let (var_252: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_251.set_GridDimensions(var_252)
        let (var_253: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_251.set_BlockDimensions(var_253)
        let (var_254: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_256: (System.Object [])) = [|var_244; var_245; var_250|]: (System.Object [])
        var_251.RunAsync(var_254, var_256)
        let (var_257: int64) = 1024L
        let (var_258: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_257: int64))
        let (var_259: EnvStack8) = EnvStack8((var_258: EnvHeap3))
        let (var_260: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_261: EnvHeap3) = var_259.mem_0
        let (var_262: (int64 ref)) = var_261.mem_0
        let (var_263: EnvStack0) = var_261.mem_1
        let (var_264: (uint64 ref)) = var_263.mem_0
        let (var_265: uint64) = method_5((var_264: (uint64 ref)))
        let (var_266: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_265)
        let (var_267: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_266)
        let (var_268: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_267, 0uy, var_268, var_260)
        let (var_271: int64) = 1024L
        let (var_272: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_271: int64))
        let (var_273: EnvStack8) = EnvStack8((var_272: EnvHeap3))
        let (var_274: EnvHeap3) = var_40.mem_0
        let (var_275: (int64 ref)) = var_274.mem_0
        let (var_276: EnvStack0) = var_274.mem_1
        let (var_277: (uint64 ref)) = var_276.mem_0
        let (var_278: uint64) = method_5((var_277: (uint64 ref)))
        let (var_279: uint64) = method_5((var_220: (uint64 ref)))
        let (var_280: EnvHeap3) = var_273.mem_0
        let (var_281: (int64 ref)) = var_280.mem_0
        let (var_282: EnvStack0) = var_280.mem_1
        let (var_283: (uint64 ref)) = var_282.mem_0
        let (var_284: uint64) = method_5((var_283: (uint64 ref)))
        // Cuda join point
        // method_30((var_278: uint64), (var_279: uint64), (var_284: uint64))
        let (var_285: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_30, var_27)
        let (var_286: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_285.set_GridDimensions(var_286)
        let (var_287: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_285.set_BlockDimensions(var_287)
        let (var_288: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_290: (System.Object [])) = [|var_278; var_279; var_284|]: (System.Object [])
        var_285.RunAsync(var_288, var_290)
        let (var_291: int64) = 1024L
        let (var_292: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_291: int64))
        let (var_293: EnvStack8) = EnvStack8((var_292: EnvHeap3))
        let (var_294: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_295: EnvHeap3) = var_293.mem_0
        let (var_296: (int64 ref)) = var_295.mem_0
        let (var_297: EnvStack0) = var_295.mem_1
        let (var_298: (uint64 ref)) = var_297.mem_0
        let (var_299: uint64) = method_5((var_298: (uint64 ref)))
        let (var_300: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_299)
        let (var_301: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_300)
        let (var_302: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_301, 0uy, var_302, var_294)
        let (var_304: int64) = 1024L
        let (var_305: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_304: int64))
        let (var_306: EnvStack8) = EnvStack8((var_305: EnvHeap3))
        let (var_307: uint64) = method_5((var_249: (uint64 ref)))
        let (var_308: uint64) = method_5((var_283: (uint64 ref)))
        let (var_309: EnvHeap3) = var_306.mem_0
        let (var_310: (int64 ref)) = var_309.mem_0
        let (var_311: EnvStack0) = var_309.mem_1
        let (var_312: (uint64 ref)) = var_311.mem_0
        let (var_313: uint64) = method_5((var_312: (uint64 ref)))
        // Cuda join point
        // method_55((var_307: uint64), (var_308: uint64), (var_313: uint64))
        let (var_314: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_55", var_30, var_27)
        let (var_315: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_314.set_GridDimensions(var_315)
        let (var_316: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_314.set_BlockDimensions(var_316)
        let (var_317: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_319: (System.Object [])) = [|var_307; var_308; var_313|]: (System.Object [])
        var_314.RunAsync(var_317, var_319)
        let (var_320: int64) = 1024L
        let (var_321: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_320: int64))
        let (var_322: EnvStack8) = EnvStack8((var_321: EnvHeap3))
        let (var_323: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_324: EnvHeap3) = var_322.mem_0
        let (var_325: (int64 ref)) = var_324.mem_0
        let (var_326: EnvStack0) = var_324.mem_1
        let (var_327: (uint64 ref)) = var_326.mem_0
        let (var_328: uint64) = method_5((var_327: (uint64 ref)))
        let (var_329: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_328)
        let (var_330: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_329)
        let (var_331: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_330, 0uy, var_331, var_323)
        let (var_336: int64) = 1024L
        let (var_337: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_336: int64))
        let (var_338: EnvStack8) = EnvStack8((var_337: EnvHeap3))
        let (var_339: uint64) = method_5((var_312: (uint64 ref)))
        let (var_340: EnvHeap3) = var_338.mem_0
        let (var_341: (int64 ref)) = var_340.mem_0
        let (var_342: EnvStack0) = var_340.mem_1
        let (var_343: (uint64 ref)) = var_342.mem_0
        let (var_344: uint64) = method_5((var_343: (uint64 ref)))
        // Cuda join point
        // method_29((var_339: uint64), (var_344: uint64))
        let (var_345: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_30, var_27)
        let (var_346: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
        var_345.set_GridDimensions(var_346)
        let (var_347: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_345.set_BlockDimensions(var_347)
        let (var_348: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_350: (System.Object [])) = [|var_339; var_344|]: (System.Object [])
        var_345.RunAsync(var_348, var_350)
        let (var_351: int64) = 1024L
        let (var_352: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_351: int64))
        let (var_353: EnvStack8) = EnvStack8((var_352: EnvHeap3))
        let (var_354: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_355: EnvHeap3) = var_353.mem_0
        let (var_356: (int64 ref)) = var_355.mem_0
        let (var_357: EnvStack0) = var_355.mem_1
        let (var_358: (uint64 ref)) = var_357.mem_0
        let (var_359: uint64) = method_5((var_358: (uint64 ref)))
        let (var_360: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_359)
        let (var_361: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_360)
        let (var_362: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024L)
        var_27.ClearMemoryAsync(var_361, 0uy, var_362, var_354)
        let (var_363: int64) = 128L
        let (var_364: int64) = 1L
        let (var_365: int64) = 0L
        let (var_366: int64) = 2L
        let (var_367: int64) = 0L
        let (var_368: int64) = 128L
        method_31((var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_0: EnvStack8), (var_47: int64), (var_363: int64), (var_364: int64), (var_365: int64), (var_366: int64), (var_367: int64), (var_368: int64))
        let (var_369: uint64) = method_5((var_343: (uint64 ref)))
        let (var_370: (int64 ref)) = var_48.mem_0
        let (var_371: EnvStack0) = var_48.mem_1
        let (var_372: (uint64 ref)) = var_371.mem_0
        let (var_373: uint64) = method_5((var_372: (uint64 ref)))
        let (var_374: int64) = (var_47 * 4L)
        let (var_375: uint64) = (uint64 var_374)
        let (var_376: uint64) = (var_373 + var_375)
        let (var_385: int64) = 4L
        let (var_386: EnvHeap3) = method_11((var_50: EnvHeap7), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_385: int64))
        let (var_387: EnvStack8) = EnvStack8((var_386: EnvHeap3))
        let (var_388: EnvHeap3) = var_387.mem_0
        let (var_389: (int64 ref)) = var_388.mem_0
        let (var_390: EnvStack0) = var_388.mem_1
        let (var_391: (uint64 ref)) = var_390.mem_0
        let (var_392: uint64) = method_5((var_391: (uint64 ref)))
        // Cuda join point
        // method_40((var_369: uint64), (var_376: uint64), (var_392: uint64))
        let (var_393: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_30, var_27)
        let (var_394: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_393.set_GridDimensions(var_394)
        let (var_395: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
        var_393.set_BlockDimensions(var_395)
        let (var_396: ManagedCuda.BasicTypes.CUstream) = method_19((var_59: (bool ref)), (var_60: ManagedCuda.CudaStream))
        let (var_398: (System.Object [])) = [|var_369; var_376; var_392|]: (System.Object [])
        var_393.RunAsync(var_396, var_398)
        let (var_399: (unit -> unit)) = method_56((var_38: (unit -> unit)), (var_56: EnvStack8), (var_52: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_0: EnvStack8), (var_46: int64), (var_11: EnvStack8), (var_12: EnvStack8), (var_39: EnvStack8), (var_40: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_104: EnvStack8), (var_89: EnvStack8), (var_120: EnvStack8), (var_116: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_167: EnvStack8), (var_152: EnvStack8), (var_183: EnvStack8), (var_179: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_230: EnvStack8), (var_215: EnvStack8), (var_259: EnvStack8), (var_243: EnvStack8), (var_293: EnvStack8), (var_273: EnvStack8), (var_322: EnvStack8), (var_306: EnvStack8), (var_353: EnvStack8), (var_338: EnvStack8), (var_387: EnvStack8), (var_47: int64))
        let (var_400: (unit -> float32)) = method_60((var_387: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_37: (unit -> float32)))
        let (var_401: int64) = (var_41 + 1L)
        method_70((var_0: EnvStack8), (var_1: int64), (var_2: int64), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64), (var_33: float), (var_34: int64), (var_35: ResizeArray<EnvHeap3>), (var_36: ResizeArray<EnvHeap3>), (var_400: (unit -> float32)), (var_399: (unit -> unit)), (var_353: EnvStack8), (var_338: EnvStack8), (var_401: int64))
    else
        let (var_403: float32) = var_37()
        let (var_404: float) = (float var_403)
        let (var_405: float) = (var_33 + var_404)
        method_62((var_36: ResizeArray<EnvHeap3>))
        let (var_414: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_415: EnvHeap3) = var_40.mem_0
        method_15((var_415: EnvHeap3), (var_414: ResizeArray<EnvHeap3>))
        let (var_416: int64) = (var_32 + 1L)
        if (System.Double.IsNaN var_405) then
            method_62((var_28: ResizeArray<EnvHeap3>))
            method_62((var_414: ResizeArray<EnvHeap3>))
            let (var_417: float) = (float var_416)
            (var_405 / var_417)
        else
            var_38()
            let (var_419: EnvHeap3) = var_4.mem_0
            let (var_420: (int64 ref)) = var_419.mem_0
            let (var_421: EnvStack0) = var_419.mem_1
            let (var_422: (uint64 ref)) = var_421.mem_0
            let (var_423: uint64) = method_5((var_422: (uint64 ref)))
            let (var_424: EnvHeap3) = var_3.mem_0
            let (var_425: (int64 ref)) = var_424.mem_0
            let (var_426: EnvStack0) = var_424.mem_1
            let (var_427: (uint64 ref)) = var_426.mem_0
            let (var_428: uint64) = method_5((var_427: (uint64 ref)))
            // Cuda join point
            // method_64((var_423: uint64), (var_428: uint64))
            let (var_429: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_430: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_429.set_GridDimensions(var_430)
            let (var_431: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_429.set_BlockDimensions(var_431)
            let (var_432: (int64 ref)) = var_31.mem_0
            let (var_433: EnvHeap5) = var_31.mem_1
            let (var_434: (bool ref)) = var_433.mem_0
            let (var_435: ManagedCuda.CudaStream) = var_433.mem_1
            let (var_436: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_438: (System.Object [])) = [|var_423; var_428|]: (System.Object [])
            var_429.RunAsync(var_436, var_438)
            let (var_439: EnvHeap3) = var_6.mem_0
            let (var_440: (int64 ref)) = var_439.mem_0
            let (var_441: EnvStack0) = var_439.mem_1
            let (var_442: (uint64 ref)) = var_441.mem_0
            let (var_443: uint64) = method_5((var_442: (uint64 ref)))
            let (var_444: EnvHeap3) = var_5.mem_0
            let (var_445: (int64 ref)) = var_444.mem_0
            let (var_446: EnvStack0) = var_444.mem_1
            let (var_447: (uint64 ref)) = var_446.mem_0
            let (var_448: uint64) = method_5((var_447: (uint64 ref)))
            // Cuda join point
            // method_64((var_443: uint64), (var_448: uint64))
            let (var_449: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_450: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_449.set_GridDimensions(var_450)
            let (var_451: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_449.set_BlockDimensions(var_451)
            let (var_452: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_454: (System.Object [])) = [|var_443; var_448|]: (System.Object [])
            var_449.RunAsync(var_452, var_454)
            let (var_455: EnvHeap3) = var_8.mem_0
            let (var_456: (int64 ref)) = var_455.mem_0
            let (var_457: EnvStack0) = var_455.mem_1
            let (var_458: (uint64 ref)) = var_457.mem_0
            let (var_459: uint64) = method_5((var_458: (uint64 ref)))
            let (var_460: EnvHeap3) = var_7.mem_0
            let (var_461: (int64 ref)) = var_460.mem_0
            let (var_462: EnvStack0) = var_460.mem_1
            let (var_463: (uint64 ref)) = var_462.mem_0
            let (var_464: uint64) = method_5((var_463: (uint64 ref)))
            // Cuda join point
            // method_64((var_459: uint64), (var_464: uint64))
            let (var_465: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_30, var_27)
            let (var_466: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_465.set_GridDimensions(var_466)
            let (var_467: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_465.set_BlockDimensions(var_467)
            let (var_468: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_470: (System.Object [])) = [|var_459; var_464|]: (System.Object [])
            var_465.RunAsync(var_468, var_470)
            let (var_471: EnvHeap3) = var_10.mem_0
            let (var_472: (int64 ref)) = var_471.mem_0
            let (var_473: EnvStack0) = var_471.mem_1
            let (var_474: (uint64 ref)) = var_473.mem_0
            let (var_475: uint64) = method_5((var_474: (uint64 ref)))
            let (var_476: EnvHeap3) = var_9.mem_0
            let (var_477: (int64 ref)) = var_476.mem_0
            let (var_478: EnvStack0) = var_476.mem_1
            let (var_479: (uint64 ref)) = var_478.mem_0
            let (var_480: uint64) = method_5((var_479: (uint64 ref)))
            // Cuda join point
            // method_65((var_475: uint64), (var_480: uint64))
            let (var_481: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_482: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_481.set_GridDimensions(var_482)
            let (var_483: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_481.set_BlockDimensions(var_483)
            let (var_484: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_486: (System.Object [])) = [|var_475; var_480|]: (System.Object [])
            var_481.RunAsync(var_484, var_486)
            let (var_487: EnvHeap3) = var_12.mem_0
            let (var_488: (int64 ref)) = var_487.mem_0
            let (var_489: EnvStack0) = var_487.mem_1
            let (var_490: (uint64 ref)) = var_489.mem_0
            let (var_491: uint64) = method_5((var_490: (uint64 ref)))
            let (var_492: EnvHeap3) = var_11.mem_0
            let (var_493: (int64 ref)) = var_492.mem_0
            let (var_494: EnvStack0) = var_492.mem_1
            let (var_495: (uint64 ref)) = var_494.mem_0
            let (var_496: uint64) = method_5((var_495: (uint64 ref)))
            // Cuda join point
            // method_65((var_491: uint64), (var_496: uint64))
            let (var_497: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_498: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_497.set_GridDimensions(var_498)
            let (var_499: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_497.set_BlockDimensions(var_499)
            let (var_500: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_502: (System.Object [])) = [|var_491; var_496|]: (System.Object [])
            var_497.RunAsync(var_500, var_502)
            let (var_503: EnvHeap3) = var_14.mem_0
            let (var_504: (int64 ref)) = var_503.mem_0
            let (var_505: EnvStack0) = var_503.mem_1
            let (var_506: (uint64 ref)) = var_505.mem_0
            let (var_507: uint64) = method_5((var_506: (uint64 ref)))
            let (var_508: EnvHeap3) = var_13.mem_0
            let (var_509: (int64 ref)) = var_508.mem_0
            let (var_510: EnvStack0) = var_508.mem_1
            let (var_511: (uint64 ref)) = var_510.mem_0
            let (var_512: uint64) = method_5((var_511: (uint64 ref)))
            // Cuda join point
            // method_65((var_507: uint64), (var_512: uint64))
            let (var_513: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_514: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_513.set_GridDimensions(var_514)
            let (var_515: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_513.set_BlockDimensions(var_515)
            let (var_516: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_518: (System.Object [])) = [|var_507; var_512|]: (System.Object [])
            var_513.RunAsync(var_516, var_518)
            let (var_519: EnvHeap3) = var_16.mem_0
            let (var_520: (int64 ref)) = var_519.mem_0
            let (var_521: EnvStack0) = var_519.mem_1
            let (var_522: (uint64 ref)) = var_521.mem_0
            let (var_523: uint64) = method_5((var_522: (uint64 ref)))
            let (var_524: EnvHeap3) = var_15.mem_0
            let (var_525: (int64 ref)) = var_524.mem_0
            let (var_526: EnvStack0) = var_524.mem_1
            let (var_527: (uint64 ref)) = var_526.mem_0
            let (var_528: uint64) = method_5((var_527: (uint64 ref)))
            // Cuda join point
            // method_65((var_523: uint64), (var_528: uint64))
            let (var_529: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_530: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_529.set_GridDimensions(var_530)
            let (var_531: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_529.set_BlockDimensions(var_531)
            let (var_532: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_534: (System.Object [])) = [|var_523; var_528|]: (System.Object [])
            var_529.RunAsync(var_532, var_534)
            let (var_535: EnvHeap3) = var_18.mem_0
            let (var_536: (int64 ref)) = var_535.mem_0
            let (var_537: EnvStack0) = var_535.mem_1
            let (var_538: (uint64 ref)) = var_537.mem_0
            let (var_539: uint64) = method_5((var_538: (uint64 ref)))
            let (var_540: EnvHeap3) = var_17.mem_0
            let (var_541: (int64 ref)) = var_540.mem_0
            let (var_542: EnvStack0) = var_540.mem_1
            let (var_543: (uint64 ref)) = var_542.mem_0
            let (var_544: uint64) = method_5((var_543: (uint64 ref)))
            // Cuda join point
            // method_65((var_539: uint64), (var_544: uint64))
            let (var_545: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_546: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_545.set_GridDimensions(var_546)
            let (var_547: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_545.set_BlockDimensions(var_547)
            let (var_548: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_550: (System.Object [])) = [|var_539; var_544|]: (System.Object [])
            var_545.RunAsync(var_548, var_550)
            let (var_551: EnvHeap3) = var_20.mem_0
            let (var_552: (int64 ref)) = var_551.mem_0
            let (var_553: EnvStack0) = var_551.mem_1
            let (var_554: (uint64 ref)) = var_553.mem_0
            let (var_555: uint64) = method_5((var_554: (uint64 ref)))
            let (var_556: EnvHeap3) = var_19.mem_0
            let (var_557: (int64 ref)) = var_556.mem_0
            let (var_558: EnvStack0) = var_556.mem_1
            let (var_559: (uint64 ref)) = var_558.mem_0
            let (var_560: uint64) = method_5((var_559: (uint64 ref)))
            // Cuda join point
            // method_65((var_555: uint64), (var_560: uint64))
            let (var_561: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_65", var_30, var_27)
            let (var_562: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_561.set_GridDimensions(var_562)
            let (var_563: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_561.set_BlockDimensions(var_563)
            let (var_564: ManagedCuda.BasicTypes.CUstream) = method_19((var_434: (bool ref)), (var_435: ManagedCuda.CudaStream))
            let (var_566: (System.Object [])) = [|var_555; var_560|]: (System.Object [])
            var_561.RunAsync(var_564, var_566)
            method_62((var_28: ResizeArray<EnvHeap3>))
            let (var_567: int64) = (var_34 + 1L)
            method_67((var_0: EnvStack8), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_35: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_416: int64), (var_405: float), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: EnvStack8), (var_7: EnvStack8), (var_8: EnvStack8), (var_9: EnvStack8), (var_10: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: EnvStack8), (var_20: EnvStack8), (var_414: ResizeArray<EnvHeap3>), (var_40: EnvStack8), (var_567: int64))
and method_36((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_36((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_37((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
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
            method_38((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_39((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): int64 =
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
            method_36((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_37((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_11 + 1L)
            method_39((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_34((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_38((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
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
            method_38((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
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
let (var_101: int64) = 571081728L
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
let (var_111: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139425u, 1u, 1u)
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
var_44.GenerateNormal32(var_131, var_128, 0.000000f, 0.108253f)
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
let (var_168: int64) = 65536L
let (var_169: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_168: int64))
let (var_170: EnvStack8) = EnvStack8((var_169: EnvHeap3))
let (var_171: EnvHeap3) = var_170.mem_0
let (var_172: (int64 ref)) = var_171.mem_0
let (var_173: EnvStack0) = var_171.mem_1
let (var_174: (uint64 ref)) = var_173.mem_0
let (var_175: uint64) = method_5((var_174: (uint64 ref)))
let (var_176: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_177: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_177)
let (var_178: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_175)
let (var_179: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_178)
var_44.GenerateNormal32(var_179, var_176, 0.000000f, 0.088388f)
let (var_180: int64) = 65536L
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
let (var_191: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_190, 0uy, var_191, var_183)
let (var_192: int64) = 65536L
let (var_193: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_192: int64))
let (var_194: EnvStack8) = EnvStack8((var_193: EnvHeap3))
let (var_195: EnvHeap3) = var_194.mem_0
let (var_196: (int64 ref)) = var_195.mem_0
let (var_197: EnvStack0) = var_195.mem_1
let (var_198: (uint64 ref)) = var_197.mem_0
let (var_199: uint64) = method_5((var_198: (uint64 ref)))
let (var_200: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_201: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_201)
let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_199)
let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_202)
var_44.GenerateNormal32(var_203, var_200, 0.000000f, 0.108253f)
let (var_204: int64) = 65536L
let (var_205: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_204: int64))
let (var_206: EnvStack8) = EnvStack8((var_205: EnvHeap3))
let (var_207: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_208: EnvHeap3) = var_206.mem_0
let (var_209: (int64 ref)) = var_208.mem_0
let (var_210: EnvStack0) = var_208.mem_1
let (var_211: (uint64 ref)) = var_210.mem_0
let (var_212: uint64) = method_5((var_211: (uint64 ref)))
let (var_213: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_212)
let (var_214: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_213)
let (var_215: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_214, 0uy, var_215, var_207)
let (var_216: int64) = 65536L
let (var_217: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_216: int64))
let (var_218: EnvStack8) = EnvStack8((var_217: EnvHeap3))
let (var_219: EnvHeap3) = var_218.mem_0
let (var_220: (int64 ref)) = var_219.mem_0
let (var_221: EnvStack0) = var_219.mem_1
let (var_222: (uint64 ref)) = var_221.mem_0
let (var_223: uint64) = method_5((var_222: (uint64 ref)))
let (var_224: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_225: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_225)
let (var_226: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_223)
let (var_227: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_226)
var_44.GenerateNormal32(var_227, var_224, 0.000000f, 0.088388f)
let (var_228: int64) = 65536L
let (var_229: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_228: int64))
let (var_230: EnvStack8) = EnvStack8((var_229: EnvHeap3))
let (var_231: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_232: EnvHeap3) = var_230.mem_0
let (var_233: (int64 ref)) = var_232.mem_0
let (var_234: EnvStack0) = var_232.mem_1
let (var_235: (uint64 ref)) = var_234.mem_0
let (var_236: uint64) = method_5((var_235: (uint64 ref)))
let (var_237: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_236)
let (var_238: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_237)
let (var_239: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_238, 0uy, var_239, var_231)
let (var_240: int64) = 65536L
let (var_241: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_240: int64))
let (var_242: EnvStack8) = EnvStack8((var_241: EnvHeap3))
let (var_243: EnvHeap3) = var_242.mem_0
let (var_244: (int64 ref)) = var_243.mem_0
let (var_245: EnvStack0) = var_243.mem_1
let (var_246: (uint64 ref)) = var_245.mem_0
let (var_247: uint64) = method_5((var_246: (uint64 ref)))
let (var_248: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_249: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
var_44.SetStream(var_249)
let (var_250: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_247)
let (var_251: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_250)
var_44.GenerateNormal32(var_251, var_248, 0.000000f, 0.088388f)
let (var_252: int64) = 65536L
let (var_253: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_252: int64))
let (var_254: EnvStack8) = EnvStack8((var_253: EnvHeap3))
let (var_255: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_256: EnvHeap3) = var_254.mem_0
let (var_257: (int64 ref)) = var_256.mem_0
let (var_258: EnvStack0) = var_256.mem_1
let (var_259: (uint64 ref)) = var_258.mem_0
let (var_260: uint64) = method_5((var_259: (uint64 ref)))
let (var_261: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_260)
let (var_262: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_261)
let (var_263: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_262, 0uy, var_263, var_255)
let (var_264: int64) = 512L
let (var_265: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_264: int64))
let (var_266: EnvStack8) = EnvStack8((var_265: EnvHeap3))
let (var_267: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_268: EnvHeap3) = var_266.mem_0
let (var_269: (int64 ref)) = var_268.mem_0
let (var_270: EnvStack0) = var_268.mem_1
let (var_271: (uint64 ref)) = var_270.mem_0
let (var_272: uint64) = method_5((var_271: (uint64 ref)))
let (var_273: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_272)
let (var_274: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_273)
let (var_275: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_274, 0uy, var_275, var_267)
let (var_276: int64) = 512L
let (var_277: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_276: int64))
let (var_278: EnvStack8) = EnvStack8((var_277: EnvHeap3))
let (var_279: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_280: EnvHeap3) = var_278.mem_0
let (var_281: (int64 ref)) = var_280.mem_0
let (var_282: EnvStack0) = var_280.mem_1
let (var_283: (uint64 ref)) = var_282.mem_0
let (var_284: uint64) = method_5((var_283: (uint64 ref)))
let (var_285: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_284)
let (var_286: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_285)
let (var_287: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_286, 0uy, var_287, var_279)
let (var_288: int64) = 512L
let (var_289: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_288: int64))
let (var_290: EnvStack8) = EnvStack8((var_289: EnvHeap3))
let (var_291: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_292: EnvHeap3) = var_290.mem_0
let (var_293: (int64 ref)) = var_292.mem_0
let (var_294: EnvStack0) = var_292.mem_1
let (var_295: (uint64 ref)) = var_294.mem_0
let (var_296: uint64) = method_5((var_295: (uint64 ref)))
let (var_297: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_296)
let (var_298: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_297)
let (var_299: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_298, 0uy, var_299, var_291)
let (var_300: int64) = 512L
let (var_301: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_300: int64))
let (var_302: EnvStack8) = EnvStack8((var_301: EnvHeap3))
let (var_303: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_304: EnvHeap3) = var_302.mem_0
let (var_305: (int64 ref)) = var_304.mem_0
let (var_306: EnvStack0) = var_304.mem_1
let (var_307: (uint64 ref)) = var_306.mem_0
let (var_308: uint64) = method_5((var_307: (uint64 ref)))
let (var_309: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_308)
let (var_310: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_309)
let (var_311: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_310, 0uy, var_311, var_303)
let (var_312: int64) = 512L
let (var_313: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_312: int64))
let (var_314: EnvStack8) = EnvStack8((var_313: EnvHeap3))
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_314: EnvStack8))
let (var_315: EnvHeap3) = var_314.mem_0
let (var_316: int64) = 512L
let (var_317: EnvHeap3) = method_11((var_102: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_316: int64))
let (var_318: EnvStack8) = EnvStack8((var_317: EnvHeap3))
let (var_319: ManagedCuda.BasicTypes.CUstream) = method_19((var_115: (bool ref)), (var_116: ManagedCuda.CudaStream))
let (var_320: EnvHeap3) = var_318.mem_0
let (var_321: (int64 ref)) = var_320.mem_0
let (var_322: EnvStack0) = var_320.mem_1
let (var_323: (uint64 ref)) = var_322.mem_0
let (var_324: uint64) = method_5((var_323: (uint64 ref)))
let (var_325: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_324)
let (var_326: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_325)
let (var_327: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_326, 0uy, var_327, var_319)
let (var_328: int64) = 0L
method_22((var_318: EnvStack8), (var_314: EnvStack8), (var_278: EnvStack8), (var_266: EnvStack8), (var_302: EnvStack8), (var_290: EnvStack8), (var_182: EnvStack8), (var_170: EnvStack8), (var_134: EnvStack8), (var_122: EnvStack8), (var_158: EnvStack8), (var_146: EnvStack8), (var_254: EnvStack8), (var_242: EnvStack8), (var_206: EnvStack8), (var_194: EnvStack8), (var_230: EnvStack8), (var_218: EnvStack8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_104: EnvStack8), (var_328: int64))
method_71((var_68: ResizeArray<EnvHeap4>))
method_62((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_329: (uint64 ref)) = var_40.mem_0
let (var_330: uint64) = method_5((var_329: (uint64 ref)))
let (var_331: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_330)
let (var_332: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_331)
var_1.FreeMemory(var_332)
var_329 := 0UL
var_1.Dispose()

