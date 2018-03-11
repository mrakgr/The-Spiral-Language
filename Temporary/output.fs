module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_21(float * var_0);
    __global__ void method_25(float * var_0, float * var_1, float * var_2);
    __global__ void method_27(float * var_0, float * var_1);
    __global__ void method_28(float * var_0, float * var_1);
    __global__ void method_29(float * var_0, float * var_1, float * var_2);
    __global__ void method_39(float * var_0, float * var_1, float * var_2);
    __global__ void method_44(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_45(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_46(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_48(float * var_0, float * var_1);
    __global__ void method_50(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_51(float * var_0, float * var_1);
    __global__ void method_52(float * var_0, float * var_1);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_26(long long int * var_0);
    __device__ char method_40(long long int * var_0, float * var_1);
    __device__ char method_49(long long int * var_0, float * var_1);
    __device__ char method_53(long long int * var_0);
    
    __global__ void method_16(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_17(var_5)) {
            long long int var_7 = var_5[0];
            long long int var_8 = (var_7 % 32);
            long long int var_9 = (var_7 / 32);
            long long int var_10 = (var_9 % 32);
            long long int var_11 = (var_9 / 32);
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 32);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = (var_10 * 128);
            char var_18;
            if (var_12) {
                var_18 = (var_10 < 32);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            unsigned char var_20 = var_0[var_10];
            long long int var_21[1];
            var_21[0] = var_8;
            while (method_18(var_21)) {
                long long int var_23 = var_21[0];
                unsigned char var_24 = ((unsigned char) (var_23));
                char var_25 = (var_20 == var_24);
                float var_26;
                if (var_25) {
                    var_26 = 1;
                } else {
                    var_26 = 0;
                }
                char var_27 = (var_23 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_23 < 128);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_16 + var_23);
                var_1[var_31] = var_26;
                long long int var_32 = (var_23 + 32);
                var_21[0] = var_32;
            }
            long long int var_33 = var_21[0];
            long long int var_34 = (var_7 + 1);
            var_5[0] = var_34;
        }
        long long int var_35 = var_5[0];
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
            long long int var_16 = (var_14 + var_15);
            long long int var_17[1];
            var_17[0] = var_16;
            while (method_26(var_17)) {
                long long int var_19 = var_17[0];
                char var_20 = (var_19 >= 0);
                char var_22;
                if (var_20) {
                    var_22 = (var_19 < 1);
                } else {
                    var_22 = 0;
                }
                char var_23 = (var_22 == 0);
                if (var_23) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_24 = (var_19 * 128);
                char var_26;
                if (var_10) {
                    var_26 = (var_9 < 128);
                } else {
                    var_26 = 0;
                }
                char var_27 = (var_26 == 0);
                if (var_27) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_28 = (var_24 + var_9);
                char var_30;
                if (var_20) {
                    var_30 = (var_19 < 1);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                char var_33;
                if (var_10) {
                    var_33 = (var_9 < 128);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                float var_35 = var_0[var_9];
                float var_36 = var_1[var_28];
                float var_37 = var_2[var_28];
                float var_38 = (var_35 + var_36);
                var_2[var_28] = var_38;
                long long int var_39 = (var_19 + 1);
                var_17[0] = var_39;
            }
            long long int var_40 = var_17[0];
            long long int var_41 = (var_9 + 128);
            var_7[0] = var_41;
        }
        long long int var_42 = var_7[0];
    }
    __global__ void method_27(float * var_0, float * var_1) {
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
            float var_18 = tanh(var_16);
            var_1[var_8] = var_18;
            long long int var_19 = (var_8 + 128);
            var_6[0] = var_19;
        }
        long long int var_20 = var_6[0];
    }
    __global__ void method_28(float * var_0, float * var_1) {
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
            float var_18 = (-var_16);
            float var_19 = exp(var_18);
            float var_20 = (1 + var_19);
            float var_21 = (1 / var_20);
            var_1[var_8] = var_21;
            long long int var_22 = (var_8 + 128);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_29(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 128);
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
            long long int var_21 = (var_9 + 128);
            var_7[0] = var_21;
        }
        long long int var_22 = var_7[0];
    }
    __global__ void method_39(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
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
                var_15 = (var_11 < 128);
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
            long long int var_28 = (var_11 + 128);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        long long int var_32 = threadIdx.x;
        char var_33 = (var_32 == 0);
        if (var_33) {
            long long int var_34 = blockIdx.x;
            char var_35 = (var_34 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_34 < 1);
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
    __global__ void method_44(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_18(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 128);
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
                var_16 = (var_10 < 128);
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
            float var_26 = (var_20 + var_25);
            var_3[var_10] = var_26;
            long long int var_27 = (var_10 + 128);
            var_8[0] = var_27;
        }
        long long int var_28 = var_8[0];
    }
    __global__ void method_45(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_18(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 128);
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
                var_16 = (var_10 < 128);
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
            long long int var_26 = (var_10 + 128);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_46(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (128 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_18(var_10)) {
            long long int var_12 = var_10[0];
            char var_13 = (var_12 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_12 < 128);
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
                var_18 = (var_12 < 128);
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
            long long int var_30 = (var_12 + 128);
            var_10[0] = var_30;
        }
        long long int var_31 = var_10[0];
    }
    __global__ void method_48(float * var_0, float * var_1) {
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
            long long int var_18 = (var_16 + var_17);
            float var_19 = 0;
            long long int var_20[1];
            float var_21[1];
            var_20[0] = var_18;
            var_21[0] = var_19;
            while (method_49(var_20, var_21)) {
                long long int var_23 = var_20[0];
                float var_24 = var_21[0];
                char var_25 = (var_23 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_23 < 1);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_23 * 128);
                char var_31;
                if (var_9) {
                    var_31 = (var_8 < 128);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_8);
                float var_34 = var_0[var_33];
                float var_35 = (var_24 + var_34);
                long long int var_36 = (var_23 + 1);
                var_20[0] = var_36;
                var_21[0] = var_35;
            }
            long long int var_37 = var_20[0];
            float var_38 = var_21[0];
            float var_39 = var_1[var_8];
            float var_40 = (var_38 + var_39);
            var_1[var_8] = var_40;
            long long int var_41 = (var_8 + 128);
            var_6[0] = var_41;
        }
        long long int var_42 = var_6[0];
    }
    __global__ void method_50(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_18(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 128);
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
                var_16 = (var_10 < 128);
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
            long long int var_26 = (var_10 + 128);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_51(float * var_0, float * var_1) {
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
    __global__ void method_52(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_53(var_6)) {
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
        return (var_1 < 1024);
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_26(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_40(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_49(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1);
    }
    __device__ char method_53(long long int * var_0) {
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
    val mem_0: ManagedCuda.CudaBlas.CudaBlas
    val mem_1: ManagedCuda.CudaRand.CudaRandDevice
    val mem_2: EnvStack0
    val mem_3: uint64
    val mem_4: ResizeArray<Env1>
    val mem_5: ResizeArray<Env2>
    val mem_6: ManagedCuda.CudaContext
    val mem_7: ResizeArray<EnvHeap3>
    val mem_8: ResizeArray<EnvHeap4>
    val mem_9: ManagedCuda.BasicTypes.CUmodule
    val mem_10: EnvHeap4
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4, arg_mem_5, arg_mem_6, arg_mem_7, arg_mem_8, arg_mem_9, arg_mem_10) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4; mem_5 = arg_mem_5; mem_6 = arg_mem_6; mem_7 = arg_mem_7; mem_8 = arg_mem_8; mem_9 = arg_mem_9; mem_10 = arg_mem_10}
    end
and EnvStack7 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap8 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
and EnvStack9 =
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: int64), (var_12: (uint8 [])), (var_13: int64), (var_14: int64)): EnvStack7 =
    let (var_15: int64) = (var_11 * var_14)
    let (var_16: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_17: int64) = var_16.AddrOfPinnedObject().ToInt64()
    let (var_18: uint64) = (uint64 var_17)
    let (var_19: uint64) = (uint64 var_13)
    let (var_20: uint64) = (var_19 + var_18)
    let (var_21: EnvHeap8) = ({mem_0 = (var_2: EnvStack0); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env1>); mem_3 = (var_5: ResizeArray<Env2>)} : EnvHeap8)
    let (var_22: EnvHeap3) = method_11((var_21: EnvHeap8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_15: int64))
    let (var_23: EnvStack7) = EnvStack7((var_22: EnvHeap3))
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
and method_11((var_0: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
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
and method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack9)): unit =
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
and method_22((var_0: EnvStack6), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_7: EnvStack9), (var_8: EnvStack9), (var_9: EnvStack9), (var_10: EnvStack9), (var_11: EnvStack9), (var_12: EnvStack9), (var_13: EnvStack9), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: EnvStack0), (var_22: uint64), (var_23: ResizeArray<Env1>), (var_24: ResizeArray<Env2>), (var_25: ManagedCuda.CudaContext), (var_26: ResizeArray<EnvHeap3>), (var_27: ResizeArray<EnvHeap4>), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: EnvHeap4), (var_30: EnvStack9), (var_31: int64)): unit =
    let (var_32: bool) = (var_31 < 100L)
    if var_32 then
        let (var_33: ManagedCuda.CudaBlas.CudaBlas) = var_0.mem_0
        let (var_34: ManagedCuda.CudaRand.CudaRandDevice) = var_0.mem_1
        let (var_35: EnvStack0) = var_0.mem_2
        let (var_36: uint64) = var_0.mem_3
        let (var_37: ResizeArray<Env1>) = var_0.mem_4
        let (var_38: ResizeArray<Env2>) = var_0.mem_5
        let (var_39: ManagedCuda.CudaContext) = var_0.mem_6
        let (var_40: ResizeArray<EnvHeap3>) = var_0.mem_7
        let (var_41: ResizeArray<EnvHeap4>) = var_0.mem_8
        let (var_42: ManagedCuda.BasicTypes.CUmodule) = var_0.mem_9
        let (var_43: EnvHeap4) = var_0.mem_10
        let (var_44: int64) = 0L
        let (var_45: float) = 0.000000
        let (var_46: int64) = 0L
        let (var_47: float) = method_23((var_30: EnvStack9), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: EnvStack0), (var_22: uint64), (var_23: ResizeArray<Env1>), (var_24: ResizeArray<Env2>), (var_25: ManagedCuda.CudaContext), (var_26: ResizeArray<EnvHeap3>), (var_27: ResizeArray<EnvHeap4>), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: EnvHeap4), (var_44: int64), (var_45: float), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_7: EnvStack9), (var_8: EnvStack9), (var_9: EnvStack9), (var_10: EnvStack9), (var_11: EnvStack9), (var_12: EnvStack9), (var_13: EnvStack9), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_46: int64))
        let (var_48: string) = System.String.Format("Training: {0}",var_47)
        let (var_49: string) = System.String.Format("{0}",var_48)
        System.Console.WriteLine(var_49)
        let (var_50: int64) = (var_31 + 1L)
        method_22((var_0: EnvStack6), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_7: EnvStack9), (var_8: EnvStack9), (var_9: EnvStack9), (var_10: EnvStack9), (var_11: EnvStack9), (var_12: EnvStack9), (var_13: EnvStack9), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: EnvStack0), (var_22: uint64), (var_23: ResizeArray<Env1>), (var_24: ResizeArray<Env2>), (var_25: ManagedCuda.CudaContext), (var_26: ResizeArray<EnvHeap3>), (var_27: ResizeArray<EnvHeap4>), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: EnvHeap4), (var_30: EnvStack9), (var_50: int64))
    else
        ()
and method_54((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_55
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_42((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_43
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
and method_23((var_0: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: EnvStack9), (var_20: EnvStack9), (var_21: EnvStack9), (var_22: EnvStack9), (var_23: EnvStack9), (var_24: EnvStack9), (var_25: EnvStack9), (var_26: EnvStack9), (var_27: EnvStack9), (var_28: EnvStack9), (var_29: EnvStack9), (var_30: EnvStack9), (var_31: EnvStack9), (var_32: int64)): float =
    let (var_33: bool) = (var_32 < 1L)
    if var_33 then
        let (var_34: bool) = (var_32 >= 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = (var_32 * 128L)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_37: int64) = (128L + var_36)
        let (var_38: EnvHeap8) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap8)
        let (var_39: EnvStack0) = var_38.mem_0
        let (var_40: uint64) = var_38.mem_1
        let (var_41: ResizeArray<Env1>) = var_38.mem_2
        let (var_42: ResizeArray<Env2>) = var_38.mem_3
        method_1((var_41: ResizeArray<Env1>), (var_39: EnvStack0), (var_40: uint64), (var_42: ResizeArray<Env2>))
        let (var_46: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_47: EnvHeap3) = var_0.mem_0
        let (var_48: int64) = 512L
        let (var_49: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_48: int64))
        let (var_50: EnvStack9) = EnvStack9((var_49: EnvHeap3))
        method_24((var_23: EnvStack9), (var_0: EnvStack9), (var_36: int64), (var_50: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_51: EnvHeap3) = var_50.mem_0
        let (var_52: int64) = 512L
        let (var_53: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_52: int64))
        let (var_54: EnvStack9) = EnvStack9((var_53: EnvHeap3))
        let (var_55: (int64 ref)) = var_11.mem_0
        let (var_56: EnvHeap5) = var_11.mem_1
        let (var_57: (bool ref)) = var_56.mem_0
        let (var_58: ManagedCuda.CudaStream) = var_56.mem_1
        let (var_59: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_60: EnvHeap3) = var_54.mem_0
        let (var_61: (int64 ref)) = var_60.mem_0
        let (var_62: EnvStack0) = var_60.mem_1
        let (var_63: (uint64 ref)) = var_62.mem_0
        let (var_64: uint64) = method_5((var_63: (uint64 ref)))
        let (var_65: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_64)
        let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_65)
        let (var_67: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_66, 0uy, var_67, var_59)
        let (var_68: EnvHeap3) = var_17.mem_0
        let (var_69: (int64 ref)) = var_68.mem_0
        let (var_70: EnvStack0) = var_68.mem_1
        let (var_71: (uint64 ref)) = var_70.mem_0
        let (var_72: uint64) = method_5((var_71: (uint64 ref)))
        let (var_73: (int64 ref)) = var_51.mem_0
        let (var_74: EnvStack0) = var_51.mem_1
        let (var_75: (uint64 ref)) = var_74.mem_0
        let (var_76: uint64) = method_5((var_75: (uint64 ref)))
        let (var_77: uint64) = method_5((var_75: (uint64 ref)))
        // Cuda join point
        // method_25((var_72: uint64), (var_76: uint64), (var_77: uint64))
        let (var_78: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_78.set_GridDimensions(var_79)
        let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_78.set_BlockDimensions(var_80)
        let (var_81: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_83: (System.Object [])) = [|var_72; var_76; var_77|]: (System.Object [])
        var_78.RunAsync(var_81, var_83)
        let (var_85: int64) = 512L
        let (var_86: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_85: int64))
        let (var_87: EnvStack9) = EnvStack9((var_86: EnvHeap3))
        let (var_88: uint64) = method_5((var_75: (uint64 ref)))
        let (var_89: EnvHeap3) = var_87.mem_0
        let (var_90: (int64 ref)) = var_89.mem_0
        let (var_91: EnvStack0) = var_89.mem_1
        let (var_92: (uint64 ref)) = var_91.mem_0
        let (var_93: uint64) = method_5((var_92: (uint64 ref)))
        // Cuda join point
        // method_27((var_88: uint64), (var_93: uint64))
        let (var_94: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_10, var_7)
        let (var_95: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_94.set_GridDimensions(var_95)
        let (var_96: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_94.set_BlockDimensions(var_96)
        let (var_97: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_99: (System.Object [])) = [|var_88; var_93|]: (System.Object [])
        var_94.RunAsync(var_97, var_99)
        let (var_100: int64) = 512L
        let (var_101: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_100: int64))
        let (var_102: EnvStack9) = EnvStack9((var_101: EnvHeap3))
        let (var_103: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_104: EnvHeap3) = var_102.mem_0
        let (var_105: (int64 ref)) = var_104.mem_0
        let (var_106: EnvStack0) = var_104.mem_1
        let (var_107: (uint64 ref)) = var_106.mem_0
        let (var_108: uint64) = method_5((var_107: (uint64 ref)))
        let (var_109: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_108)
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_109)
        let (var_111: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_110, 0uy, var_111, var_103)
        let (var_112: int64) = 512L
        let (var_113: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_112: int64))
        let (var_114: EnvStack9) = EnvStack9((var_113: EnvHeap3))
        method_24((var_25: EnvStack9), (var_0: EnvStack9), (var_36: int64), (var_114: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_115: EnvHeap3) = var_114.mem_0
        let (var_116: int64) = 512L
        let (var_117: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_116: int64))
        let (var_118: EnvStack9) = EnvStack9((var_117: EnvHeap3))
        let (var_119: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_120: EnvHeap3) = var_118.mem_0
        let (var_121: (int64 ref)) = var_120.mem_0
        let (var_122: EnvStack0) = var_120.mem_1
        let (var_123: (uint64 ref)) = var_122.mem_0
        let (var_124: uint64) = method_5((var_123: (uint64 ref)))
        let (var_125: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_124)
        let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_125)
        let (var_127: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_126, 0uy, var_127, var_119)
        let (var_128: EnvHeap3) = var_19.mem_0
        let (var_129: (int64 ref)) = var_128.mem_0
        let (var_130: EnvStack0) = var_128.mem_1
        let (var_131: (uint64 ref)) = var_130.mem_0
        let (var_132: uint64) = method_5((var_131: (uint64 ref)))
        let (var_133: (int64 ref)) = var_115.mem_0
        let (var_134: EnvStack0) = var_115.mem_1
        let (var_135: (uint64 ref)) = var_134.mem_0
        let (var_136: uint64) = method_5((var_135: (uint64 ref)))
        let (var_137: uint64) = method_5((var_135: (uint64 ref)))
        // Cuda join point
        // method_25((var_132: uint64), (var_136: uint64), (var_137: uint64))
        let (var_138: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_139: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_138.set_GridDimensions(var_139)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_138.set_BlockDimensions(var_140)
        let (var_141: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_143: (System.Object [])) = [|var_132; var_136; var_137|]: (System.Object [])
        var_138.RunAsync(var_141, var_143)
        let (var_148: int64) = 512L
        let (var_149: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_148: int64))
        let (var_150: EnvStack9) = EnvStack9((var_149: EnvHeap3))
        let (var_151: uint64) = method_5((var_135: (uint64 ref)))
        let (var_152: EnvHeap3) = var_150.mem_0
        let (var_153: (int64 ref)) = var_152.mem_0
        let (var_154: EnvStack0) = var_152.mem_1
        let (var_155: (uint64 ref)) = var_154.mem_0
        let (var_156: uint64) = method_5((var_155: (uint64 ref)))
        // Cuda join point
        // method_28((var_151: uint64), (var_156: uint64))
        let (var_157: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_10, var_7)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_157.set_GridDimensions(var_158)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_157.set_BlockDimensions(var_159)
        let (var_160: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_162: (System.Object [])) = [|var_151; var_156|]: (System.Object [])
        var_157.RunAsync(var_160, var_162)
        let (var_163: int64) = 512L
        let (var_164: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_163: int64))
        let (var_165: EnvStack9) = EnvStack9((var_164: EnvHeap3))
        let (var_166: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_167: EnvHeap3) = var_165.mem_0
        let (var_168: (int64 ref)) = var_167.mem_0
        let (var_169: EnvStack0) = var_167.mem_1
        let (var_170: (uint64 ref)) = var_169.mem_0
        let (var_171: uint64) = method_5((var_170: (uint64 ref)))
        let (var_172: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_171)
        let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_172)
        let (var_174: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_173, 0uy, var_174, var_166)
        let (var_176: int64) = 512L
        let (var_177: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_176: int64))
        let (var_178: EnvStack9) = EnvStack9((var_177: EnvHeap3))
        let (var_179: uint64) = method_5((var_92: (uint64 ref)))
        let (var_180: uint64) = method_5((var_155: (uint64 ref)))
        let (var_181: EnvHeap3) = var_178.mem_0
        let (var_182: (int64 ref)) = var_181.mem_0
        let (var_183: EnvStack0) = var_181.mem_1
        let (var_184: (uint64 ref)) = var_183.mem_0
        let (var_185: uint64) = method_5((var_184: (uint64 ref)))
        // Cuda join point
        // method_29((var_179: uint64), (var_180: uint64), (var_185: uint64))
        let (var_186: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_10, var_7)
        let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_186.set_GridDimensions(var_187)
        let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_186.set_BlockDimensions(var_188)
        let (var_189: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_191: (System.Object [])) = [|var_179; var_180; var_185|]: (System.Object [])
        var_186.RunAsync(var_189, var_191)
        let (var_192: int64) = 512L
        let (var_193: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_192: int64))
        let (var_194: EnvStack9) = EnvStack9((var_193: EnvHeap3))
        let (var_195: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_196: EnvHeap3) = var_194.mem_0
        let (var_197: (int64 ref)) = var_196.mem_0
        let (var_198: EnvStack0) = var_196.mem_1
        let (var_199: (uint64 ref)) = var_198.mem_0
        let (var_200: uint64) = method_5((var_199: (uint64 ref)))
        let (var_201: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_200)
        let (var_202: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_201)
        let (var_203: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_202, 0uy, var_203, var_195)
        let (var_208: int64) = 512L
        let (var_209: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_208: int64))
        let (var_210: EnvStack9) = EnvStack9((var_209: EnvHeap3))
        let (var_211: uint64) = method_5((var_184: (uint64 ref)))
        let (var_212: EnvHeap3) = var_210.mem_0
        let (var_213: (int64 ref)) = var_212.mem_0
        let (var_214: EnvStack0) = var_212.mem_1
        let (var_215: (uint64 ref)) = var_214.mem_0
        let (var_216: uint64) = method_5((var_215: (uint64 ref)))
        // Cuda join point
        // method_28((var_211: uint64), (var_216: uint64))
        let (var_217: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_10, var_7)
        let (var_218: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_217.set_GridDimensions(var_218)
        let (var_219: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_217.set_BlockDimensions(var_219)
        let (var_220: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_222: (System.Object [])) = [|var_211; var_216|]: (System.Object [])
        var_217.RunAsync(var_220, var_222)
        let (var_223: int64) = 512L
        let (var_224: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_223: int64))
        let (var_225: EnvStack9) = EnvStack9((var_224: EnvHeap3))
        let (var_226: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_227: EnvHeap3) = var_225.mem_0
        let (var_228: (int64 ref)) = var_227.mem_0
        let (var_229: EnvStack0) = var_227.mem_1
        let (var_230: (uint64 ref)) = var_229.mem_0
        let (var_231: uint64) = method_5((var_230: (uint64 ref)))
        let (var_232: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_231)
        let (var_233: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_232)
        let (var_234: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_233, 0uy, var_234, var_226)
        let (var_235: int64) = 0L
        let (var_236: int64) = 128L
        let (var_237: int64) = 1L
        let (var_238: int64) = 128L
        let (var_239: int64) = 1L
        let (var_240: int64) = 0L
        let (var_241: int64) = 1L
        let (var_242: int64) = 0L
        let (var_243: int64) = 128L
        method_30((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_210: EnvStack9), (var_235: int64), (var_236: int64), (var_237: int64), (var_0: EnvStack9), (var_37: int64), (var_238: int64), (var_239: int64), (var_240: int64), (var_241: int64), (var_242: int64), (var_243: int64))
        let (var_244: uint64) = method_5((var_215: (uint64 ref)))
        let (var_245: (int64 ref)) = var_47.mem_0
        let (var_246: EnvStack0) = var_47.mem_1
        let (var_247: (uint64 ref)) = var_246.mem_0
        let (var_248: uint64) = method_5((var_247: (uint64 ref)))
        let (var_249: int64) = (var_37 * 4L)
        let (var_250: uint64) = (uint64 var_249)
        let (var_251: uint64) = (var_248 + var_250)
        let (var_259: int64) = 4L
        let (var_260: EnvHeap3) = method_11((var_38: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_259: int64))
        let (var_261: EnvStack9) = EnvStack9((var_260: EnvHeap3))
        let (var_262: EnvHeap3) = var_261.mem_0
        let (var_263: (int64 ref)) = var_262.mem_0
        let (var_264: EnvStack0) = var_262.mem_1
        let (var_265: (uint64 ref)) = var_264.mem_0
        let (var_266: uint64) = method_5((var_265: (uint64 ref)))
        // Cuda join point
        // method_39((var_244: uint64), (var_251: uint64), (var_266: uint64))
        let (var_267: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_10, var_7)
        let (var_268: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_267.set_GridDimensions(var_268)
        let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_267.set_BlockDimensions(var_269)
        let (var_270: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
        let (var_272: (System.Object [])) = [|var_244; var_251; var_266|]: (System.Object [])
        var_267.RunAsync(var_270, var_272)
        let (var_273: int64) = 1L
        let (var_274: int64) = 0L
        let (var_275: (float32 [])) = method_41((var_273: int64), (var_261: EnvStack9), (var_274: int64))
        let (var_276: float32) = var_275.[int32 0L]
        let (var_277: float) = (float var_276)
        let (var_278: float) = (var_13 + var_277)
        let (var_279: int64) = (var_12 + 1L)
        if (System.Double.IsNaN var_278) then
            method_42((var_46: ResizeArray<EnvHeap3>))
            let (var_280: float) = (float var_279)
            (var_278 / var_280)
        else
            let (var_282: uint64) = method_5((var_265: (uint64 ref)))
            let (var_283: uint64) = method_5((var_215: (uint64 ref)))
            let (var_284: uint64) = method_5((var_247: (uint64 ref)))
            let (var_285: uint64) = (var_284 + var_250)
            let (var_286: uint64) = method_5((var_230: (uint64 ref)))
            // Cuda join point
            // method_44((var_282: uint64), (var_283: uint64), (var_285: uint64), (var_286: uint64))
            let (var_287: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_10, var_7)
            let (var_288: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_287.set_GridDimensions(var_288)
            let (var_289: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_287.set_BlockDimensions(var_289)
            let (var_290: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_292: (System.Object [])) = [|var_282; var_283; var_285; var_286|]: (System.Object [])
            var_287.RunAsync(var_290, var_292)
            let (var_293: uint64) = method_5((var_184: (uint64 ref)))
            let (var_294: uint64) = method_5((var_230: (uint64 ref)))
            let (var_295: uint64) = method_5((var_215: (uint64 ref)))
            let (var_296: uint64) = method_5((var_199: (uint64 ref)))
            // Cuda join point
            // method_45((var_293: uint64), (var_294: uint64), (var_295: uint64), (var_296: uint64))
            let (var_297: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_10, var_7)
            let (var_298: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_297.set_GridDimensions(var_298)
            let (var_299: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_297.set_BlockDimensions(var_299)
            let (var_300: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_302: (System.Object [])) = [|var_293; var_294; var_295; var_296|]: (System.Object [])
            var_297.RunAsync(var_300, var_302)
            let (var_303: uint64) = method_5((var_92: (uint64 ref)))
            let (var_304: uint64) = method_5((var_155: (uint64 ref)))
            let (var_305: uint64) = method_5((var_199: (uint64 ref)))
            let (var_306: uint64) = method_5((var_184: (uint64 ref)))
            let (var_307: uint64) = method_5((var_107: (uint64 ref)))
            let (var_308: uint64) = method_5((var_170: (uint64 ref)))
            // Cuda join point
            // method_46((var_303: uint64), (var_304: uint64), (var_305: uint64), (var_306: uint64), (var_307: uint64), (var_308: uint64))
            let (var_309: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_46", var_10, var_7)
            let (var_310: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_309.set_GridDimensions(var_310)
            let (var_311: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_309.set_BlockDimensions(var_311)
            let (var_312: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_314: (System.Object [])) = [|var_303; var_304; var_305; var_306; var_307; var_308|]: (System.Object [])
            var_309.RunAsync(var_312, var_314)
            let (var_315: uint64) = method_5((var_135: (uint64 ref)))
            let (var_316: uint64) = method_5((var_170: (uint64 ref)))
            let (var_317: uint64) = method_5((var_155: (uint64 ref)))
            let (var_318: uint64) = method_5((var_123: (uint64 ref)))
            // Cuda join point
            // method_45((var_315: uint64), (var_316: uint64), (var_317: uint64), (var_318: uint64))
            let (var_319: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_45", var_10, var_7)
            let (var_320: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_319.set_GridDimensions(var_320)
            let (var_321: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_319.set_BlockDimensions(var_321)
            let (var_322: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_324: (System.Object [])) = [|var_315; var_316; var_317; var_318|]: (System.Object [])
            var_319.RunAsync(var_322, var_324)
            method_47((var_118: EnvStack9), (var_0: EnvStack9), (var_36: int64), (var_24: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
            let (var_325: uint64) = method_5((var_123: (uint64 ref)))
            let (var_326: EnvHeap3) = var_18.mem_0
            let (var_327: (int64 ref)) = var_326.mem_0
            let (var_328: EnvStack0) = var_326.mem_1
            let (var_329: (uint64 ref)) = var_328.mem_0
            let (var_330: uint64) = method_5((var_329: (uint64 ref)))
            // Cuda join point
            // method_48((var_325: uint64), (var_330: uint64))
            let (var_331: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_48", var_10, var_7)
            let (var_332: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
            var_331.set_GridDimensions(var_332)
            let (var_333: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
            var_331.set_BlockDimensions(var_333)
            let (var_334: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_336: (System.Object [])) = [|var_325; var_330|]: (System.Object [])
            var_331.RunAsync(var_334, var_336)
            let (var_337: uint64) = method_5((var_75: (uint64 ref)))
            let (var_338: uint64) = method_5((var_107: (uint64 ref)))
            let (var_339: uint64) = method_5((var_92: (uint64 ref)))
            let (var_340: uint64) = method_5((var_63: (uint64 ref)))
            // Cuda join point
            // method_50((var_337: uint64), (var_338: uint64), (var_339: uint64), (var_340: uint64))
            let (var_341: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_50", var_10, var_7)
            let (var_342: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_341.set_GridDimensions(var_342)
            let (var_343: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_341.set_BlockDimensions(var_343)
            let (var_344: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_346: (System.Object [])) = [|var_337; var_338; var_339; var_340|]: (System.Object [])
            var_341.RunAsync(var_344, var_346)
            method_47((var_54: EnvStack9), (var_0: EnvStack9), (var_36: int64), (var_22: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_46: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
            let (var_347: uint64) = method_5((var_63: (uint64 ref)))
            let (var_348: EnvHeap3) = var_16.mem_0
            let (var_349: (int64 ref)) = var_348.mem_0
            let (var_350: EnvStack0) = var_348.mem_1
            let (var_351: (uint64 ref)) = var_350.mem_0
            let (var_352: uint64) = method_5((var_351: (uint64 ref)))
            // Cuda join point
            // method_48((var_347: uint64), (var_352: uint64))
            let (var_353: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_48", var_10, var_7)
            let (var_354: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
            var_353.set_GridDimensions(var_354)
            let (var_355: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
            var_353.set_BlockDimensions(var_355)
            let (var_356: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_358: (System.Object [])) = [|var_347; var_352|]: (System.Object [])
            var_353.RunAsync(var_356, var_358)
            let (var_359: EnvHeap3) = var_15.mem_0
            let (var_360: (int64 ref)) = var_359.mem_0
            let (var_361: EnvStack0) = var_359.mem_1
            let (var_362: (uint64 ref)) = var_361.mem_0
            let (var_363: uint64) = method_5((var_362: (uint64 ref)))
            let (var_364: EnvHeap3) = var_14.mem_0
            let (var_365: (int64 ref)) = var_364.mem_0
            let (var_366: EnvStack0) = var_364.mem_1
            let (var_367: (uint64 ref)) = var_366.mem_0
            let (var_368: uint64) = method_5((var_367: (uint64 ref)))
            // Cuda join point
            // method_51((var_363: uint64), (var_368: uint64))
            let (var_369: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_10, var_7)
            let (var_370: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_369.set_GridDimensions(var_370)
            let (var_371: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_369.set_BlockDimensions(var_371)
            let (var_372: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_374: (System.Object [])) = [|var_363; var_368|]: (System.Object [])
            var_369.RunAsync(var_372, var_374)
            let (var_375: uint64) = method_5((var_71: (uint64 ref)))
            let (var_376: uint64) = method_5((var_351: (uint64 ref)))
            // Cuda join point
            // method_51((var_375: uint64), (var_376: uint64))
            let (var_377: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_10, var_7)
            let (var_378: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_377.set_GridDimensions(var_378)
            let (var_379: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_377.set_BlockDimensions(var_379)
            let (var_380: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_382: (System.Object [])) = [|var_375; var_376|]: (System.Object [])
            var_377.RunAsync(var_380, var_382)
            let (var_383: uint64) = method_5((var_131: (uint64 ref)))
            let (var_384: uint64) = method_5((var_329: (uint64 ref)))
            // Cuda join point
            // method_51((var_383: uint64), (var_384: uint64))
            let (var_385: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_10, var_7)
            let (var_386: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_385.set_GridDimensions(var_386)
            let (var_387: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_385.set_BlockDimensions(var_387)
            let (var_388: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_390: (System.Object [])) = [|var_383; var_384|]: (System.Object [])
            var_385.RunAsync(var_388, var_390)
            let (var_391: EnvHeap3) = var_21.mem_0
            let (var_392: (int64 ref)) = var_391.mem_0
            let (var_393: EnvStack0) = var_391.mem_1
            let (var_394: (uint64 ref)) = var_393.mem_0
            let (var_395: uint64) = method_5((var_394: (uint64 ref)))
            let (var_396: EnvHeap3) = var_20.mem_0
            let (var_397: (int64 ref)) = var_396.mem_0
            let (var_398: EnvStack0) = var_396.mem_1
            let (var_399: (uint64 ref)) = var_398.mem_0
            let (var_400: uint64) = method_5((var_399: (uint64 ref)))
            // Cuda join point
            // method_52((var_395: uint64), (var_400: uint64))
            let (var_401: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_402: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_401.set_GridDimensions(var_402)
            let (var_403: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_401.set_BlockDimensions(var_403)
            let (var_404: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_406: (System.Object [])) = [|var_395; var_400|]: (System.Object [])
            var_401.RunAsync(var_404, var_406)
            let (var_407: EnvHeap3) = var_23.mem_0
            let (var_408: (int64 ref)) = var_407.mem_0
            let (var_409: EnvStack0) = var_407.mem_1
            let (var_410: (uint64 ref)) = var_409.mem_0
            let (var_411: uint64) = method_5((var_410: (uint64 ref)))
            let (var_412: EnvHeap3) = var_22.mem_0
            let (var_413: (int64 ref)) = var_412.mem_0
            let (var_414: EnvStack0) = var_412.mem_1
            let (var_415: (uint64 ref)) = var_414.mem_0
            let (var_416: uint64) = method_5((var_415: (uint64 ref)))
            // Cuda join point
            // method_52((var_411: uint64), (var_416: uint64))
            let (var_417: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_418: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_417.set_GridDimensions(var_418)
            let (var_419: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_417.set_BlockDimensions(var_419)
            let (var_420: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_422: (System.Object [])) = [|var_411; var_416|]: (System.Object [])
            var_417.RunAsync(var_420, var_422)
            let (var_423: EnvHeap3) = var_25.mem_0
            let (var_424: (int64 ref)) = var_423.mem_0
            let (var_425: EnvStack0) = var_423.mem_1
            let (var_426: (uint64 ref)) = var_425.mem_0
            let (var_427: uint64) = method_5((var_426: (uint64 ref)))
            let (var_428: EnvHeap3) = var_24.mem_0
            let (var_429: (int64 ref)) = var_428.mem_0
            let (var_430: EnvStack0) = var_428.mem_1
            let (var_431: (uint64 ref)) = var_430.mem_0
            let (var_432: uint64) = method_5((var_431: (uint64 ref)))
            // Cuda join point
            // method_52((var_427: uint64), (var_432: uint64))
            let (var_433: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_434: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_433.set_GridDimensions(var_434)
            let (var_435: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_433.set_BlockDimensions(var_435)
            let (var_436: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_438: (System.Object [])) = [|var_427; var_432|]: (System.Object [])
            var_433.RunAsync(var_436, var_438)
            let (var_439: EnvHeap3) = var_27.mem_0
            let (var_440: (int64 ref)) = var_439.mem_0
            let (var_441: EnvStack0) = var_439.mem_1
            let (var_442: (uint64 ref)) = var_441.mem_0
            let (var_443: uint64) = method_5((var_442: (uint64 ref)))
            let (var_444: EnvHeap3) = var_26.mem_0
            let (var_445: (int64 ref)) = var_444.mem_0
            let (var_446: EnvStack0) = var_444.mem_1
            let (var_447: (uint64 ref)) = var_446.mem_0
            let (var_448: uint64) = method_5((var_447: (uint64 ref)))
            // Cuda join point
            // method_52((var_443: uint64), (var_448: uint64))
            let (var_449: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_450: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_449.set_GridDimensions(var_450)
            let (var_451: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_449.set_BlockDimensions(var_451)
            let (var_452: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_454: (System.Object [])) = [|var_443; var_448|]: (System.Object [])
            var_449.RunAsync(var_452, var_454)
            let (var_455: EnvHeap3) = var_29.mem_0
            let (var_456: (int64 ref)) = var_455.mem_0
            let (var_457: EnvStack0) = var_455.mem_1
            let (var_458: (uint64 ref)) = var_457.mem_0
            let (var_459: uint64) = method_5((var_458: (uint64 ref)))
            let (var_460: EnvHeap3) = var_28.mem_0
            let (var_461: (int64 ref)) = var_460.mem_0
            let (var_462: EnvStack0) = var_460.mem_1
            let (var_463: (uint64 ref)) = var_462.mem_0
            let (var_464: uint64) = method_5((var_463: (uint64 ref)))
            // Cuda join point
            // method_52((var_459: uint64), (var_464: uint64))
            let (var_465: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_466: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_465.set_GridDimensions(var_466)
            let (var_467: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_465.set_BlockDimensions(var_467)
            let (var_468: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_470: (System.Object [])) = [|var_459; var_464|]: (System.Object [])
            var_465.RunAsync(var_468, var_470)
            let (var_471: EnvHeap3) = var_31.mem_0
            let (var_472: (int64 ref)) = var_471.mem_0
            let (var_473: EnvStack0) = var_471.mem_1
            let (var_474: (uint64 ref)) = var_473.mem_0
            let (var_475: uint64) = method_5((var_474: (uint64 ref)))
            let (var_476: EnvHeap3) = var_30.mem_0
            let (var_477: (int64 ref)) = var_476.mem_0
            let (var_478: EnvStack0) = var_476.mem_1
            let (var_479: (uint64 ref)) = var_478.mem_0
            let (var_480: uint64) = method_5((var_479: (uint64 ref)))
            // Cuda join point
            // method_52((var_475: uint64), (var_480: uint64))
            let (var_481: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_10, var_7)
            let (var_482: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_481.set_GridDimensions(var_482)
            let (var_483: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_481.set_BlockDimensions(var_483)
            let (var_484: ManagedCuda.BasicTypes.CUstream) = method_19((var_57: (bool ref)), (var_58: ManagedCuda.CudaStream))
            let (var_486: (System.Object [])) = [|var_475; var_480|]: (System.Object [])
            var_481.RunAsync(var_484, var_486)
            method_42((var_46: ResizeArray<EnvHeap3>))
            let (var_487: int64) = (var_32 + 1L)
            method_23((var_0: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_279: int64), (var_278: float), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: EnvStack9), (var_20: EnvStack9), (var_21: EnvStack9), (var_22: EnvStack9), (var_23: EnvStack9), (var_24: EnvStack9), (var_25: EnvStack9), (var_26: EnvStack9), (var_27: EnvStack9), (var_28: EnvStack9), (var_29: EnvStack9), (var_30: EnvStack9), (var_31: EnvStack9), (var_487: int64))
    else
        let (var_490: float) = (float var_12)
        (var_13 / var_490)
and method_55 ((var_0: EnvHeap4)): unit =
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
and method_43 ((var_0: EnvHeap3)): unit =
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
and method_24((var_0: EnvStack9), (var_1: EnvStack9), (var_2: int64), (var_3: EnvStack9), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 1, 128, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack9), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack9), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64)): unit =
    let (var_23: int64) = (var_20 - var_19)
    let (var_24: int64) = (var_22 - var_21)
    let (var_25: int64) = (var_23 * var_24)
    let (var_26: bool) = (var_25 > 0L)
    let (var_27: bool) = (var_26 = false)
    if var_27 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_28: int64) = (var_24 * var_14)
    let (var_29: bool) = (var_13 = var_28)
    let (var_30: bool) = (var_29 = false)
    if var_30 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_31: int64) = (var_23 * var_13)
    let (var_32: int64) = (var_24 * var_18)
    let (var_33: bool) = (var_17 = var_32)
    let (var_34: bool) = (var_33 = false)
    if var_34 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_35: int64) = (var_23 * var_17)
    let (var_36: (float32 [])) = method_31((var_23: int64), (var_11: EnvStack9), (var_12: int64), (var_13: int64), (var_14: int64))
    let (var_37: (float32 [])) = method_31((var_23: int64), (var_15: EnvStack9), (var_16: int64), (var_17: int64), (var_18: int64))
    let (var_38: int64) = 0L
    let (var_39: int64) = 0L
    method_32((var_36: (float32 [])), (var_38: int64), (var_13: int64), (var_14: int64), (var_37: (float32 [])), (var_39: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64))
and method_41((var_0: int64), (var_1: EnvStack9), (var_2: int64)): (float32 []) =
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
and method_47((var_0: EnvStack9), (var_1: EnvStack9), (var_2: int64), (var_3: EnvStack9), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 128, 1, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
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
and method_31((var_0: int64), (var_1: EnvStack9), (var_2: int64), (var_3: int64), (var_4: int64)): (float32 []) =
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
and method_32((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
    let (var_12: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_13: string) = ""
    let (var_14: int64) = 0L
    let (var_15: int64) = 0L
    method_33((var_12: System.Text.StringBuilder), (var_15: int64))
    let (var_16: System.Text.StringBuilder) = var_12.AppendLine("[|")
    let (var_17: int64) = method_34((var_12: System.Text.StringBuilder), (var_13: string), (var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_14: int64))
    let (var_18: int64) = 0L
    method_33((var_12: System.Text.StringBuilder), (var_18: int64))
    let (var_19: System.Text.StringBuilder) = var_12.AppendLine("|]")
    let (var_20: string) = var_12.ToString()
    let (var_21: string) = System.String.Format("{0}",var_20)
    System.Console.WriteLine(var_21)
and method_33((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_33((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_34((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (float32 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64)): int64 =
    let (var_15: bool) = (var_10 < var_11)
    if var_15 then
        let (var_16: bool) = (var_14 < 1000L)
        if var_16 then
            let (var_17: bool) = (var_10 >= var_10)
            let (var_18: bool) = (var_17 = false)
            if var_18 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_19: int64) = 0L
            method_35((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_36((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_3: int64), (var_5: int64), (var_6: (float32 [])), (var_7: int64), (var_9: int64), (var_12: int64), (var_13: int64), (var_1: string), (var_14: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_10 + 1L)
            method_38((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (float32 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_33((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_14
    else
        var_14
and method_35((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_35((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_36((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64)): int64 =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: bool) = (var_10 < 1000L)
        if var_12 then
            let (var_13: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_14: bool) = (var_7 >= var_7)
            let (var_15: bool) = (var_14 = false)
            if var_15 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_16: float32) = var_1.[int32 var_2]
            let (var_17: float32) = var_4.[int32 var_5]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: string) = System.String.Format("{0}",var_16)
            let (var_20: string) = String.concat ", " [|var_19; var_18|]
            let (var_21: string) = System.String.Format("[{0}]",var_20)
            let (var_22: System.Text.StringBuilder) = var_0.Append(var_21)
            let (var_23: string) = "; "
            let (var_24: int64) = (var_10 + 1L)
            let (var_25: int64) = (var_7 + 1L)
            method_37((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_23: string), (var_24: int64), (var_25: int64))
        else
            let (var_27: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
and method_38((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (float32 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64)): int64 =
    let (var_16: bool) = (var_15 < var_11)
    if var_16 then
        let (var_17: bool) = (var_14 < 1000L)
        if var_17 then
            let (var_18: bool) = (var_15 >= var_10)
            let (var_19: bool) = (var_18 = false)
            if var_19 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_20: int64) = (var_15 - var_10)
            let (var_21: int64) = (var_20 * var_4)
            let (var_22: int64) = (var_3 + var_21)
            let (var_23: int64) = (var_20 * var_8)
            let (var_24: int64) = (var_7 + var_23)
            let (var_25: int64) = 0L
            method_35((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_27: int64) = method_36((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_22: int64), (var_5: int64), (var_6: (float32 [])), (var_24: int64), (var_9: int64), (var_12: int64), (var_13: int64), (var_1: string), (var_14: int64))
            let (var_28: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_29: int64) = (var_15 + 1L)
            method_38((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (float32 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_27: int64), (var_29: int64))
        else
            let (var_31: int64) = 0L
            method_33((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_14
    else
        var_14
and method_37((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_15: bool) = (var_11 >= var_7)
            let (var_16: bool) = (var_15 = false)
            if var_16 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_17: int64) = (var_11 - var_7)
            let (var_18: int64) = (var_17 * var_3)
            let (var_19: int64) = (var_2 + var_18)
            let (var_20: int64) = (var_17 * var_6)
            let (var_21: int64) = (var_5 + var_20)
            let (var_22: float32) = var_1.[int32 var_19]
            let (var_23: float32) = var_4.[int32 var_21]
            let (var_24: string) = System.String.Format("{0}",var_23)
            let (var_25: string) = System.String.Format("{0}",var_22)
            let (var_26: string) = String.concat ", " [|var_25; var_24|]
            let (var_27: string) = System.String.Format("[{0}]",var_26)
            let (var_28: System.Text.StringBuilder) = var_0.Append(var_27)
            let (var_29: string) = "; "
            let (var_30: int64) = (var_10 + 1L)
            let (var_31: int64) = (var_11 + 1L)
            method_37((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_29: string), (var_30: int64), (var_31: int64))
        else
            let (var_33: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
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
let (var_73: EnvStack6) = EnvStack6((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4))
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
let (var_93: EnvStack7) = method_10((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_90: int64), (var_83: (uint8 [])), (var_91: int64), (var_92: int64))
let (var_94: EnvHeap3) = var_93.mem_0
let (var_95: (int64 ref)) = var_94.mem_0
let (var_96: EnvStack0) = var_94.mem_1
let (var_97: (uint64 ref)) = var_96.mem_0
let (var_98: uint64) = method_5((var_97: (uint64 ref)))
let (var_102: int64) = 16384L
let (var_103: EnvHeap8) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap8)
let (var_104: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_102: int64))
let (var_105: EnvStack9) = EnvStack9((var_104: EnvHeap3))
let (var_106: EnvHeap3) = var_105.mem_0
let (var_107: (int64 ref)) = var_106.mem_0
let (var_108: EnvStack0) = var_106.mem_1
let (var_109: (uint64 ref)) = var_108.mem_0
let (var_110: uint64) = method_5((var_109: (uint64 ref)))
// Cuda join point
// method_16((var_98: uint64), (var_110: uint64))
let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_111.set_GridDimensions(var_112)
let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_111.set_BlockDimensions(var_113)
let (var_114: (int64 ref)) = var_72.mem_0
let (var_115: EnvHeap5) = var_72.mem_1
let (var_116: (bool ref)) = var_115.mem_0
let (var_117: ManagedCuda.CudaStream) = var_115.mem_1
let (var_118: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_120: (System.Object [])) = [|var_98; var_110|]: (System.Object [])
var_111.RunAsync(var_118, var_120)
let (var_121: int64) = 65536L
let (var_122: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_121: int64))
let (var_123: EnvStack9) = EnvStack9((var_122: EnvHeap3))
let (var_124: EnvHeap3) = var_123.mem_0
let (var_125: (int64 ref)) = var_124.mem_0
let (var_126: EnvStack0) = var_124.mem_1
let (var_127: (uint64 ref)) = var_126.mem_0
let (var_128: uint64) = method_5((var_127: (uint64 ref)))
let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_130: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_130)
let (var_131: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_128)
let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_131)
var_44.GenerateNormal32(var_132, var_129, 0.000000f, 0.108253f)
let (var_133: int64) = 65536L
let (var_134: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_133: int64))
let (var_135: EnvStack9) = EnvStack9((var_134: EnvHeap3))
let (var_136: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_137: EnvHeap3) = var_135.mem_0
let (var_138: (int64 ref)) = var_137.mem_0
let (var_139: EnvStack0) = var_137.mem_1
let (var_140: (uint64 ref)) = var_139.mem_0
let (var_141: uint64) = method_5((var_140: (uint64 ref)))
let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_141)
let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_142)
let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_143, 0uy, var_144, var_136)
let (var_145: int64) = 65536L
let (var_146: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_145: int64))
let (var_147: EnvStack9) = EnvStack9((var_146: EnvHeap3))
let (var_148: EnvHeap3) = var_147.mem_0
let (var_149: (int64 ref)) = var_148.mem_0
let (var_150: EnvStack0) = var_148.mem_1
let (var_151: (uint64 ref)) = var_150.mem_0
let (var_152: uint64) = method_5((var_151: (uint64 ref)))
let (var_153: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_154: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_154)
let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_152)
let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_155)
var_44.GenerateNormal32(var_156, var_153, 0.000000f, 0.088388f)
let (var_157: int64) = 65536L
let (var_158: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_157: int64))
let (var_159: EnvStack9) = EnvStack9((var_158: EnvHeap3))
let (var_160: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_161: EnvHeap3) = var_159.mem_0
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: EnvStack0) = var_161.mem_1
let (var_164: (uint64 ref)) = var_163.mem_0
let (var_165: uint64) = method_5((var_164: (uint64 ref)))
let (var_166: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_165)
let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_166)
let (var_168: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_167, 0uy, var_168, var_160)
let (var_169: int64) = 65536L
let (var_170: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_169: int64))
let (var_171: EnvStack9) = EnvStack9((var_170: EnvHeap3))
let (var_172: EnvHeap3) = var_171.mem_0
let (var_173: (int64 ref)) = var_172.mem_0
let (var_174: EnvStack0) = var_172.mem_1
let (var_175: (uint64 ref)) = var_174.mem_0
let (var_176: uint64) = method_5((var_175: (uint64 ref)))
let (var_177: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_178: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_178)
let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_176)
let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_179)
var_44.GenerateNormal32(var_180, var_177, 0.000000f, 0.088388f)
let (var_181: int64) = 65536L
let (var_182: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_181: int64))
let (var_183: EnvStack9) = EnvStack9((var_182: EnvHeap3))
let (var_184: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_185: EnvHeap3) = var_183.mem_0
let (var_186: (int64 ref)) = var_185.mem_0
let (var_187: EnvStack0) = var_185.mem_1
let (var_188: (uint64 ref)) = var_187.mem_0
let (var_189: uint64) = method_5((var_188: (uint64 ref)))
let (var_190: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_189)
let (var_191: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_190)
let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_191, 0uy, var_192, var_184)
let (var_193: int64) = 65536L
let (var_194: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_193: int64))
let (var_195: EnvStack9) = EnvStack9((var_194: EnvHeap3))
let (var_196: EnvHeap3) = var_195.mem_0
let (var_197: (int64 ref)) = var_196.mem_0
let (var_198: EnvStack0) = var_196.mem_1
let (var_199: (uint64 ref)) = var_198.mem_0
let (var_200: uint64) = method_5((var_199: (uint64 ref)))
let (var_201: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_202: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_202)
let (var_203: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_200)
let (var_204: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_203)
var_44.GenerateNormal32(var_204, var_201, 0.000000f, 0.108253f)
let (var_205: int64) = 65536L
let (var_206: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_205: int64))
let (var_207: EnvStack9) = EnvStack9((var_206: EnvHeap3))
let (var_208: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_209: EnvHeap3) = var_207.mem_0
let (var_210: (int64 ref)) = var_209.mem_0
let (var_211: EnvStack0) = var_209.mem_1
let (var_212: (uint64 ref)) = var_211.mem_0
let (var_213: uint64) = method_5((var_212: (uint64 ref)))
let (var_214: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_213)
let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_214)
let (var_216: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_215, 0uy, var_216, var_208)
let (var_217: int64) = 65536L
let (var_218: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_217: int64))
let (var_219: EnvStack9) = EnvStack9((var_218: EnvHeap3))
let (var_220: EnvHeap3) = var_219.mem_0
let (var_221: (int64 ref)) = var_220.mem_0
let (var_222: EnvStack0) = var_220.mem_1
let (var_223: (uint64 ref)) = var_222.mem_0
let (var_224: uint64) = method_5((var_223: (uint64 ref)))
let (var_225: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_226: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_226)
let (var_227: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_224)
let (var_228: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_227)
var_44.GenerateNormal32(var_228, var_225, 0.000000f, 0.088388f)
let (var_229: int64) = 65536L
let (var_230: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_229: int64))
let (var_231: EnvStack9) = EnvStack9((var_230: EnvHeap3))
let (var_232: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_233: EnvHeap3) = var_231.mem_0
let (var_234: (int64 ref)) = var_233.mem_0
let (var_235: EnvStack0) = var_233.mem_1
let (var_236: (uint64 ref)) = var_235.mem_0
let (var_237: uint64) = method_5((var_236: (uint64 ref)))
let (var_238: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_237)
let (var_239: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_238)
let (var_240: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_239, 0uy, var_240, var_232)
let (var_241: int64) = 65536L
let (var_242: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_241: int64))
let (var_243: EnvStack9) = EnvStack9((var_242: EnvHeap3))
let (var_244: EnvHeap3) = var_243.mem_0
let (var_245: (int64 ref)) = var_244.mem_0
let (var_246: EnvStack0) = var_244.mem_1
let (var_247: (uint64 ref)) = var_246.mem_0
let (var_248: uint64) = method_5((var_247: (uint64 ref)))
let (var_249: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_250: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_250)
let (var_251: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_248)
let (var_252: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_251)
var_44.GenerateNormal32(var_252, var_249, 0.000000f, 0.088388f)
let (var_253: int64) = 65536L
let (var_254: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_253: int64))
let (var_255: EnvStack9) = EnvStack9((var_254: EnvHeap3))
let (var_256: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_257: EnvHeap3) = var_255.mem_0
let (var_258: (int64 ref)) = var_257.mem_0
let (var_259: EnvStack0) = var_257.mem_1
let (var_260: (uint64 ref)) = var_259.mem_0
let (var_261: uint64) = method_5((var_260: (uint64 ref)))
let (var_262: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_261)
let (var_263: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_262)
let (var_264: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_263, 0uy, var_264, var_256)
let (var_265: int64) = 512L
let (var_266: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_265: int64))
let (var_267: EnvStack9) = EnvStack9((var_266: EnvHeap3))
let (var_268: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_269: EnvHeap3) = var_267.mem_0
let (var_270: (int64 ref)) = var_269.mem_0
let (var_271: EnvStack0) = var_269.mem_1
let (var_272: (uint64 ref)) = var_271.mem_0
let (var_273: uint64) = method_5((var_272: (uint64 ref)))
let (var_274: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_273)
let (var_275: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_274)
let (var_276: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_275, 0uy, var_276, var_268)
let (var_277: int64) = 512L
let (var_278: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_277: int64))
let (var_279: EnvStack9) = EnvStack9((var_278: EnvHeap3))
let (var_280: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_281: EnvHeap3) = var_279.mem_0
let (var_282: (int64 ref)) = var_281.mem_0
let (var_283: EnvStack0) = var_281.mem_1
let (var_284: (uint64 ref)) = var_283.mem_0
let (var_285: uint64) = method_5((var_284: (uint64 ref)))
let (var_286: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_285)
let (var_287: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_286)
let (var_288: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_287, 0uy, var_288, var_280)
let (var_289: int64) = 512L
let (var_290: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_289: int64))
let (var_291: EnvStack9) = EnvStack9((var_290: EnvHeap3))
let (var_292: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_293: EnvHeap3) = var_291.mem_0
let (var_294: (int64 ref)) = var_293.mem_0
let (var_295: EnvStack0) = var_293.mem_1
let (var_296: (uint64 ref)) = var_295.mem_0
let (var_297: uint64) = method_5((var_296: (uint64 ref)))
let (var_298: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_297)
let (var_299: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_298)
let (var_300: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_299, 0uy, var_300, var_292)
let (var_301: int64) = 512L
let (var_302: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_301: int64))
let (var_303: EnvStack9) = EnvStack9((var_302: EnvHeap3))
let (var_304: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_305: EnvHeap3) = var_303.mem_0
let (var_306: (int64 ref)) = var_305.mem_0
let (var_307: EnvStack0) = var_305.mem_1
let (var_308: (uint64 ref)) = var_307.mem_0
let (var_309: uint64) = method_5((var_308: (uint64 ref)))
let (var_310: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_309)
let (var_311: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_310)
let (var_312: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_311, 0uy, var_312, var_304)
let (var_313: int64) = 512L
let (var_314: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_313: int64))
let (var_315: EnvStack9) = EnvStack9((var_314: EnvHeap3))
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_315: EnvStack9))
let (var_316: EnvHeap3) = var_315.mem_0
let (var_317: int64) = 512L
let (var_318: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_317: int64))
let (var_319: EnvStack9) = EnvStack9((var_318: EnvHeap3))
let (var_320: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_321: EnvHeap3) = var_319.mem_0
let (var_322: (int64 ref)) = var_321.mem_0
let (var_323: EnvStack0) = var_321.mem_1
let (var_324: (uint64 ref)) = var_323.mem_0
let (var_325: uint64) = method_5((var_324: (uint64 ref)))
let (var_326: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_325)
let (var_327: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_326)
let (var_328: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_327, 0uy, var_328, var_320)
let (var_329: int64) = 0L
method_22((var_73: EnvStack6), (var_319: EnvStack9), (var_315: EnvStack9), (var_279: EnvStack9), (var_267: EnvStack9), (var_303: EnvStack9), (var_291: EnvStack9), (var_183: EnvStack9), (var_171: EnvStack9), (var_135: EnvStack9), (var_123: EnvStack9), (var_159: EnvStack9), (var_147: EnvStack9), (var_255: EnvStack9), (var_243: EnvStack9), (var_207: EnvStack9), (var_195: EnvStack9), (var_231: EnvStack9), (var_219: EnvStack9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_105: EnvStack9), (var_329: int64))
method_54((var_68: ResizeArray<EnvHeap4>))
method_42((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_330: (uint64 ref)) = var_40.mem_0
let (var_331: uint64) = method_5((var_330: (uint64 ref)))
let (var_332: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_331)
let (var_333: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_332)
var_1.FreeMemory(var_333)
var_330 := 0UL
var_1.Dispose()

