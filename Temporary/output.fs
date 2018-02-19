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
    __global__ void method_28(float * var_0, float * var_1, float * var_2);
    __global__ void method_31(float * var_0, float * var_1);
    __global__ void method_33(float * var_0, float * var_1, float * var_2);
    __global__ void method_35(float * var_0, float * var_1);
    __global__ void method_37(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_38(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_40(float * var_0, float * var_1);
    __global__ void method_44(float * var_0, float * var_1);
    __global__ void method_46(float * var_0, float * var_1);
    __global__ void method_51(float * var_0, float * var_1, float * var_2);
    __device__ char method_29(long long int * var_0);
    __device__ char method_30(long long int * var_0);
    __device__ char method_32(long long int * var_0);
    __device__ char method_34(long long int * var_0, float * var_1);
    __device__ char method_41(long long int * var_0, float * var_1);
    __device__ char method_42(long long int * var_0, float * var_1);
    __device__ char method_43(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_45(long long int * var_0);
    __device__ char method_52(long long int * var_0, float * var_1, float * var_2);
    __device__ Tuple0 method_53(Tuple0 var_0, Tuple0 var_1);
    
    __global__ void method_28(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_29(var_7)) {
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
            while (method_30(var_18)) {
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
    __global__ void method_31(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_32(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 1280);
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
                var_14 = (var_8 < 1280);
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
            long long int var_22 = (var_8 + 1280);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_33(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_34(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 1280);
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
            long long int var_28 = (var_11 + 1280);
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
                var_37 = (var_34 < 5);
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
    __global__ void method_35(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (5 * var_3);
        long long int var_5 = (var_2 + var_4);
        float var_6 = 0;
        long long int var_7[1];
        float var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_34(var_7, var_8)) {
            long long int var_10 = var_7[0];
            float var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 5);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16 = var_0[var_10];
            float var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 5);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        float var_20 = var_8[0];
        float var_21 = cub::BlockReduce<float,5,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        float var_22 = (var_21 / 128);
        long long int var_23 = threadIdx.x;
        char var_24 = (var_23 == 0);
        if (var_24) {
            long long int var_25 = blockIdx.x;
            char var_26 = (var_25 >= 0);
            char var_28;
            if (var_26) {
                var_28 = (var_25 < 1);
            } else {
                var_28 = 0;
            }
            char var_29 = (var_28 == 0);
            if (var_29) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_25] = var_22;
        } else {
        }
    }
    __global__ void method_37(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (128 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_32(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 1280);
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
                var_17 = (var_11 < 1280);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            float var_19 = var_2[var_11];
            float var_20 = var_3[var_11];
            float var_21 = var_4[var_11];
            float var_22 = var_0[0];
            float var_23 = var_1[0];
            float var_24 = (var_19 - var_20);
            float var_25 = (1 - var_19);
            float var_26 = (var_19 * var_25);
            float var_27 = (var_24 / var_26);
            float var_28 = (var_22 * var_27);
            float var_29 = (var_28 / 128);
            float var_30 = (var_21 + var_29);
            var_4[var_11] = var_30;
            long long int var_31 = (var_11 + 1280);
            var_9[0] = var_31;
        }
        long long int var_32 = var_9[0];
    }
    __global__ void method_38(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_32(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 1280);
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
                var_16 = (var_10 < 1280);
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
            long long int var_26 = (var_10 + 1280);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_40(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_29(var_6)) {
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
            long long int var_16 = threadIdx.y;
            long long int var_17 = blockIdx.y;
            long long int var_18 = (32 * var_17);
            long long int var_19 = (var_16 + var_18);
            float var_20 = 0;
            long long int var_21[1];
            float var_22[1];
            var_21[0] = var_19;
            var_22[0] = var_20;
            while (method_41(var_21, var_22)) {
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
                long long int var_30 = (var_24 * 10);
                char var_32;
                if (var_9) {
                    var_32 = (var_8 < 10);
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
            __shared__ float var_40[310];
            long long int var_41[1];
            float var_42[1];
            var_41[0] = 32;
            var_42[0] = var_39;
            while (method_42(var_41, var_42)) {
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
                    long long int var_58 = (var_57 * 10);
                    long long int var_59 = threadIdx.x;
                    char var_60 = (var_59 >= 0);
                    char var_62;
                    if (var_60) {
                        var_62 = (var_59 < 10);
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
                    while (method_43(var_44, var_69, var_70)) {
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
                        long long int var_79 = (var_78 * 10);
                        long long int var_80 = threadIdx.x;
                        char var_81 = (var_80 >= 0);
                        char var_83;
                        if (var_81) {
                            var_83 = (var_80 < 10);
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
            long long int var_98 = (var_8 + 10);
            var_6[0] = var_98;
        }
        long long int var_99 = var_6[0];
    }
    __global__ void method_44(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_45(var_6)) {
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
            float var_18 = (0.05 * var_16);
            float var_19 = (var_17 - var_18);
            var_1[var_8] = var_19;
            long long int var_20 = (var_8 + 7936);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_46(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_29(var_6)) {
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
            float var_18 = (0.05 * var_16);
            float var_19 = (var_17 - var_18);
            var_1[var_8] = var_19;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_51(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_30(var_6)) {
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
            long long int var_13 = (var_8 * 10);
            char var_15;
            if (var_9) {
                var_15 = (var_8 < 128);
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
            while (method_52(var_23, var_24, var_25)) {
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
            FunPointer1 var_47 = method_53;
            Tuple0 var_48 = cub::BlockReduce<Tuple0,10,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(make_Tuple0(var_43, var_44), var_47);
            float var_49 = var_48.mem_0;
            float var_50 = var_48.mem_1;
            long long int var_51 = threadIdx.x;
            char var_52 = (var_51 == 0);
            if (var_52) {
                char var_54;
                if (var_9) {
                    var_54 = (var_8 < 128);
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
    __device__ char method_29(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_30(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_32(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1280);
    }
    __device__ char method_34(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1280);
    }
    __device__ char method_41(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_42(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_43(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_45(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 7840);
    }
    __device__ char method_52(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 10);
    }
    __device__ Tuple0 method_53(Tuple0 var_0, Tuple0 var_1) {
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
and Env11 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
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
    let (var_11: int32) = 0
    let (var_12: Env1) = method_6((var_0: ResizeArray<Env1>), (var_10: int32), (var_1: EnvStack0), (var_11: int32))
    let (var_13: EnvStack0) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_1.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: uint64) = (var_16 + var_2)
    let (var_18: (uint64 ref)) = var_13.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: uint64) = (var_17 - var_19)
    let (var_21: uint64) = method_5((var_18: (uint64 ref)))
    let (var_22: uint64) = (var_21 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_21)
    let (var_26: bool) = (var_20 >= var_25)
    if var_26 then
        let (var_27: (uint64 ref)) = (ref var_24)
        let (var_28: EnvStack0) = EnvStack0((var_27: (uint64 ref)))
        let (var_29: uint64) = (var_20 - var_25)
        var_0.Add((Env1(var_28, var_29)))
    else
        ()
and method_8((var_0: EnvHeap4), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ResizeArray<Env1>), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap2>), (var_9: ResizeArray<EnvHeap3>), (var_10: ManagedCuda.BasicTypes.CUmodule)): EnvHeap3 =
    let (var_11: (int64 ref)) = (ref 0L)
    let (var_12: EnvHeap3) = ({mem_0 = (var_11: (int64 ref)); mem_1 = (var_0: EnvHeap4)} : EnvHeap3)
    method_9((var_12: EnvHeap3), (var_9: ResizeArray<EnvHeap3>))
    var_12
and method_10((var_0: string)): Tuple5 =
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
and method_11((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_12((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_11((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_13((var_0: string)): Tuple7 =
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
and method_14((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_15((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_14((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
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
        let (var_6: int64) = (var_2 * 784L)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = 0L
        method_12((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_16((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_17((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_15((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_17((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_18((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_11: int64), (var_12: (float32 [])), (var_13: int64), (var_14: int64), (var_15: int64)): EnvStack8 =
    let (var_16: int64) = (var_11 * var_14)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: int64) = (var_13 * 4L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_21 + var_19)
    let (var_23: int64) = (var_16 * 4L)
    let (var_24: EnvHeap9) = ({mem_0 = (var_2: ResizeArray<Env1>); mem_1 = (var_3: EnvStack0); mem_2 = (var_4: uint64); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    let (var_25: EnvHeap2) = method_19((var_24: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_23: int64))
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
and method_19((var_0: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: ResizeArray<Env1>), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap2>), (var_9: ResizeArray<EnvHeap3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap3), (var_12: int64)): EnvHeap2 =
    let (var_13: ResizeArray<Env1>) = var_0.mem_0
    let (var_14: EnvStack0) = var_0.mem_1
    let (var_15: uint64) = var_0.mem_2
    let (var_16: ResizeArray<Env1>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_20((var_13: ResizeArray<Env1>), (var_14: EnvStack0), (var_15: uint64), (var_16: ResizeArray<Env1>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap2) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap2)
    method_23((var_23: EnvHeap2), (var_8: ResizeArray<EnvHeap2>))
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
and method_24((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_25((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_19: int64)): unit =
    let (var_20: bool) = (var_19 < 10L)
    if var_20 then
        System.Console.WriteLine("Training:")
        let (var_21: float) = 0.000000
        let (var_22: int64) = 0L
        let (var_23: Env10) = method_26((var_17: EnvStack8), (var_18: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_21: float), (var_22: int64))
        let (var_24: float) = var_23.mem_0
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_25: string) = System.String.Format("Average of batch costs is {0}.",var_24)
        let (var_26: string) = System.String.Format("{0}",var_25)
        System.Console.WriteLine(var_26)
        System.Console.WriteLine("-----")
        let (var_27: bool) = System.Double.IsNaN(var_24)
        if var_27 then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            System.Console.WriteLine("Test:")
            let (var_28: int64) = 0L
            let (var_29: float) = 0.000000
            let (var_30: int64) = 0L
            let (var_31: Env11) = method_50((var_15: EnvStack8), (var_16: EnvStack8), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_28: int64), (var_29: float), (var_30: int64))
            let (var_32: int64) = var_31.mem_0
            let (var_33: float) = var_31.mem_1
            System.Console.WriteLine("-----")
            System.Console.WriteLine("Batch done.")
            let (var_34: string) = System.String.Format("Average of batch costs is {0}.",var_33)
            let (var_35: string) = System.String.Format("{0}",var_34)
            System.Console.WriteLine(var_35)
            let (var_36: float) = (float var_32)
            let (var_37: float) = (var_36 / 10000.000000)
            let (var_38: float) = (var_37 * 100.000000)
            let (var_39: string) = System.String.Format("The accuracy of the batch is {0}/{1}({2}%). ",var_32,10000L,var_38)
            let (var_40: string) = System.String.Format("{0}",var_39)
            System.Console.WriteLine(var_40)
            System.Console.WriteLine("-----")
            let (var_41: int64) = (var_19 + 1L)
            method_25((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: ResizeArray<Env1>), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap2>), (var_8: ResizeArray<EnvHeap3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap3), (var_11: EnvStack8), (var_12: EnvStack8), (var_13: EnvStack8), (var_14: EnvStack8), (var_15: EnvStack8), (var_16: EnvStack8), (var_17: EnvStack8), (var_18: EnvStack8), (var_41: int64))
    else
        ()
and method_56((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_57
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_48((var_0: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (EnvHeap2 -> unit)) = method_49
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
and method_6((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: int32)): Env1 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: Env1) = var_0.[var_3]
        let (var_6: EnvStack0) = var_5.mem_0
        let (var_7: uint64) = var_5.mem_1
        let (var_8: (uint64 ref)) = var_6.mem_0
        let (var_9: uint64) = method_5((var_8: (uint64 ref)))
        let (var_10: (uint64 ref)) = var_2.mem_0
        let (var_11: uint64) = method_5((var_10: (uint64 ref)))
        let (var_12: uint64) = (var_9 - var_11)
        let (var_13: uint64) = method_5((var_10: (uint64 ref)))
        let (var_14: uint64) = (var_13 + 256UL)
        let (var_15: uint64) = (var_14 - 1UL)
        let (var_16: uint64) = (var_15 &&& 18446744073709551360UL)
        let (var_17: uint64) = (var_16 - var_13)
        let (var_18: bool) = (var_12 >= var_17)
        if var_18 then
            let (var_19: (uint64 ref)) = (ref var_16)
            let (var_20: EnvStack0) = EnvStack0((var_19: (uint64 ref)))
            let (var_21: uint64) = (var_12 - var_17)
            var_0.Add((Env1(var_20, var_21)))
        else
            ()
        let (var_22: int32) = (var_3 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_6: EnvStack0), (var_7: uint64), (var_22: int32))
    else
        (Env1(var_2, 0UL))
and method_9((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvHeap4) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_12((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64)): unit =
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
        method_12((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_11: int64))
    else
        ()
and method_15((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_15((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_20((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): EnvStack0 =
    let (var_5: Env1) = var_0.[0]
    let (var_6: EnvStack0) = var_5.mem_0
    let (var_7: uint64) = var_5.mem_1
    let (var_8: bool) = (var_4 <= var_7)
    let (var_44: Env1) =
        if var_8 then
            let (var_9: (uint64 ref)) = var_6.mem_0
            let (var_10: uint64) = (!var_9)
            let (var_11: uint64) = (var_10 + var_4)
            let (var_12: (uint64 ref)) = (ref var_11)
            let (var_13: EnvStack0) = EnvStack0((var_12: (uint64 ref)))
            let (var_14: uint64) = (var_7 - var_4)
            var_0.[0] <- (Env1(var_13, var_14))
            (Env1(var_6, var_4))
        else
            let (var_16: (Env1 -> (Env1 -> int32))) = method_21
            let (var_17: System.Comparison<Env1>) = System.Comparison<Env1>(var_16)
            var_0.Sort(var_17)
            let (var_18: Env1) = var_0.[0]
            let (var_19: EnvStack0) = var_18.mem_0
            let (var_20: uint64) = var_18.mem_1
            let (var_21: bool) = (var_4 <= var_20)
            if var_21 then
                let (var_22: (uint64 ref)) = var_19.mem_0
                let (var_23: uint64) = (!var_22)
                let (var_24: uint64) = (var_23 + var_4)
                let (var_25: (uint64 ref)) = (ref var_24)
                let (var_26: EnvStack0) = EnvStack0((var_25: (uint64 ref)))
                let (var_27: uint64) = (var_20 - var_4)
                var_0.[0] <- (Env1(var_26, var_27))
                (Env1(var_19, var_4))
            else
                method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_29: (Env1 -> (Env1 -> int32))) = method_21
                let (var_30: System.Comparison<Env1>) = System.Comparison<Env1>(var_29)
                var_0.Sort(var_30)
                let (var_31: Env1) = var_0.[0]
                let (var_32: EnvStack0) = var_31.mem_0
                let (var_33: uint64) = var_31.mem_1
                let (var_34: bool) = (var_4 <= var_33)
                if var_34 then
                    let (var_35: (uint64 ref)) = var_32.mem_0
                    let (var_36: uint64) = (!var_35)
                    let (var_37: uint64) = (var_36 + var_4)
                    let (var_38: (uint64 ref)) = (ref var_37)
                    let (var_39: EnvStack0) = EnvStack0((var_38: (uint64 ref)))
                    let (var_40: uint64) = (var_33 - var_4)
                    var_0.[0] <- (Env1(var_39, var_40))
                    (Env1(var_32, var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_45: EnvStack0) = var_44.mem_0
    let (var_46: uint64) = var_44.mem_1
    var_45
and method_23((var_0: EnvHeap2), (var_1: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_26((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_17: float), (var_18: int64)): Env10 =
    let (var_19: bool) = (var_18 < 468L)
    if var_19 then
        let (var_20: bool) = System.Double.IsNaN(var_17)
        if var_20 then
            (Env10(var_17))
        else
            let (var_21: bool) = (var_18 >= 0L)
            let (var_22: bool) = (var_21 = false)
            if var_22 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_23: int64) = (var_18 * 100352L)
            if var_22 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_24: int64) = (var_18 * 1280L)
            let (var_25: EnvHeap9) = ({mem_0 = (var_8: ResizeArray<Env1>); mem_1 = (var_9: EnvStack0); mem_2 = (var_10: uint64); mem_3 = (var_11: ResizeArray<Env1>)} : EnvHeap9)
            let (var_26: ResizeArray<Env1>) = var_25.mem_0
            let (var_27: EnvStack0) = var_25.mem_1
            let (var_28: uint64) = var_25.mem_2
            let (var_29: ResizeArray<Env1>) = var_25.mem_3
            method_1((var_26: ResizeArray<Env1>), (var_27: EnvStack0), (var_28: uint64), (var_29: ResizeArray<Env1>))
            let (var_33: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
            let (var_34: EnvHeap2) = var_0.mem_0
            let (var_35: int64) = 5120L
            let (var_36: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_35: int64))
            let (var_37: EnvStack8) = EnvStack8((var_36: EnvHeap2))
            method_27((var_5: EnvStack8), (var_0: EnvStack8), (var_23: int64), (var_37: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3))
            let (var_38: EnvHeap2) = var_37.mem_0
            let (var_39: int64) = 5120L
            let (var_40: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_39: int64))
            let (var_41: EnvStack8) = EnvStack8((var_40: EnvHeap2))
            let (var_42: (int64 ref)) = var_16.mem_0
            let (var_43: EnvHeap4) = var_16.mem_1
            let (var_44: (bool ref)) = var_43.mem_0
            let (var_45: ManagedCuda.CudaStream) = var_43.mem_1
            let (var_46: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_47: EnvHeap2) = var_41.mem_0
            let (var_48: (int64 ref)) = var_47.mem_0
            let (var_49: EnvStack0) = var_47.mem_1
            let (var_50: (uint64 ref)) = var_49.mem_0
            let (var_51: uint64) = method_5((var_50: (uint64 ref)))
            let (var_52: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_51)
            let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_52)
            let (var_54: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
            var_12.ClearMemoryAsync(var_53, 0uy, var_54, var_46)
            let (var_55: EnvHeap2) = var_3.mem_0
            let (var_56: (int64 ref)) = var_55.mem_0
            let (var_57: EnvStack0) = var_55.mem_1
            let (var_58: (uint64 ref)) = var_57.mem_0
            let (var_59: uint64) = method_5((var_58: (uint64 ref)))
            let (var_60: (int64 ref)) = var_38.mem_0
            let (var_61: EnvStack0) = var_38.mem_1
            let (var_62: (uint64 ref)) = var_61.mem_0
            let (var_63: uint64) = method_5((var_62: (uint64 ref)))
            let (var_64: uint64) = method_5((var_62: (uint64 ref)))
            // Cuda join point
            // method_28((var_59: uint64), (var_63: uint64), (var_64: uint64))
            let (var_65: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_15, var_12)
            let (var_66: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_65.set_GridDimensions(var_66)
            let (var_67: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_65.set_BlockDimensions(var_67)
            let (var_68: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_70: (System.Object [])) = [|var_59; var_63; var_64|]: (System.Object [])
            var_65.RunAsync(var_68, var_70)
            let (var_75: int64) = 5120L
            let (var_76: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_75: int64))
            let (var_77: EnvStack8) = EnvStack8((var_76: EnvHeap2))
            let (var_78: uint64) = method_5((var_62: (uint64 ref)))
            let (var_79: EnvHeap2) = var_77.mem_0
            let (var_80: (int64 ref)) = var_79.mem_0
            let (var_81: EnvStack0) = var_79.mem_1
            let (var_82: (uint64 ref)) = var_81.mem_0
            let (var_83: uint64) = method_5((var_82: (uint64 ref)))
            // Cuda join point
            // method_31((var_78: uint64), (var_83: uint64))
            let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_15, var_12)
            let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_84.set_GridDimensions(var_85)
            let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_84.set_BlockDimensions(var_86)
            let (var_87: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_89: (System.Object [])) = [|var_78; var_83|]: (System.Object [])
            var_84.RunAsync(var_87, var_89)
            let (var_90: int64) = 5120L
            let (var_91: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_90: int64))
            let (var_92: EnvStack8) = EnvStack8((var_91: EnvHeap2))
            let (var_93: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_94: EnvHeap2) = var_92.mem_0
            let (var_95: (int64 ref)) = var_94.mem_0
            let (var_96: EnvStack0) = var_94.mem_1
            let (var_97: (uint64 ref)) = var_96.mem_0
            let (var_98: uint64) = method_5((var_97: (uint64 ref)))
            let (var_99: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_98)
            let (var_100: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_99)
            let (var_101: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
            var_12.ClearMemoryAsync(var_100, 0uy, var_101, var_93)
            let (var_110: uint64) = method_5((var_82: (uint64 ref)))
            let (var_111: EnvHeap2) = var_1.mem_0
            let (var_112: (int64 ref)) = var_111.mem_0
            let (var_113: EnvStack0) = var_111.mem_1
            let (var_114: (uint64 ref)) = var_113.mem_0
            let (var_115: uint64) = method_5((var_114: (uint64 ref)))
            let (var_116: int64) = (var_24 * 4L)
            let (var_117: uint64) = (uint64 var_116)
            let (var_118: uint64) = (var_115 + var_117)
            let (var_126: int64) = 20L
            let (var_127: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_126: int64))
            let (var_128: EnvStack8) = EnvStack8((var_127: EnvHeap2))
            let (var_129: EnvHeap2) = var_128.mem_0
            let (var_130: (int64 ref)) = var_129.mem_0
            let (var_131: EnvStack0) = var_129.mem_1
            let (var_132: (uint64 ref)) = var_131.mem_0
            let (var_133: uint64) = method_5((var_132: (uint64 ref)))
            // Cuda join point
            // method_33((var_110: uint64), (var_118: uint64), (var_133: uint64))
            let (var_134: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_15, var_12)
            let (var_135: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
            var_134.set_GridDimensions(var_135)
            let (var_136: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
            var_134.set_BlockDimensions(var_136)
            let (var_137: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_139: (System.Object [])) = [|var_110; var_118; var_133|]: (System.Object [])
            var_134.RunAsync(var_137, var_139)
            let (var_140: uint64) = method_5((var_132: (uint64 ref)))
            let (var_142: int64) = 4L
            let (var_143: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_142: int64))
            let (var_144: EnvStack8) = EnvStack8((var_143: EnvHeap2))
            let (var_145: EnvHeap2) = var_144.mem_0
            let (var_146: (int64 ref)) = var_145.mem_0
            let (var_147: EnvStack0) = var_145.mem_1
            let (var_148: (uint64 ref)) = var_147.mem_0
            let (var_149: uint64) = method_5((var_148: (uint64 ref)))
            // Cuda join point
            // method_35((var_140: uint64), (var_149: uint64))
            let (var_150: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_15, var_12)
            let (var_151: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_150.set_GridDimensions(var_151)
            let (var_152: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
            var_150.set_BlockDimensions(var_152)
            let (var_153: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_155: (System.Object [])) = [|var_140; var_149|]: (System.Object [])
            var_150.RunAsync(var_153, var_155)
            let (var_156: int64) = 4L
            let (var_157: EnvHeap2) = method_19((var_25: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_156: int64))
            let (var_158: EnvStack8) = EnvStack8((var_157: EnvHeap2))
            let (var_159: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_160: EnvHeap2) = var_158.mem_0
            let (var_161: (int64 ref)) = var_160.mem_0
            let (var_162: EnvStack0) = var_160.mem_1
            let (var_163: (uint64 ref)) = var_162.mem_0
            let (var_164: uint64) = method_5((var_163: (uint64 ref)))
            let (var_165: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_164)
            let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_165)
            let (var_167: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
            var_12.ClearMemoryAsync(var_166, 0uy, var_167, var_159)
            let (var_168: int64) = 0L
            let (var_169: float32) = 1.000000f
            method_36((var_158: EnvStack8), (var_168: int64), (var_169: float32))
            let (var_170: uint64) = method_5((var_163: (uint64 ref)))
            let (var_171: uint64) = method_5((var_148: (uint64 ref)))
            let (var_172: uint64) = method_5((var_82: (uint64 ref)))
            let (var_173: uint64) = method_5((var_114: (uint64 ref)))
            let (var_174: uint64) = (var_173 + var_117)
            let (var_175: uint64) = method_5((var_97: (uint64 ref)))
            // Cuda join point
            // method_37((var_170: uint64), (var_171: uint64), (var_172: uint64), (var_174: uint64), (var_175: uint64))
            let (var_176: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_15, var_12)
            let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_176.set_GridDimensions(var_177)
            let (var_178: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_176.set_BlockDimensions(var_178)
            let (var_179: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_181: (System.Object [])) = [|var_170; var_171; var_172; var_174; var_175|]: (System.Object [])
            var_176.RunAsync(var_179, var_181)
            let (var_182: uint64) = method_5((var_62: (uint64 ref)))
            let (var_183: uint64) = method_5((var_97: (uint64 ref)))
            let (var_184: uint64) = method_5((var_82: (uint64 ref)))
            let (var_185: uint64) = method_5((var_50: (uint64 ref)))
            // Cuda join point
            // method_38((var_182: uint64), (var_183: uint64), (var_184: uint64), (var_185: uint64))
            let (var_186: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_38", var_15, var_12)
            let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_186.set_GridDimensions(var_187)
            let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_186.set_BlockDimensions(var_188)
            let (var_189: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_191: (System.Object [])) = [|var_182; var_183; var_184; var_185|]: (System.Object [])
            var_186.RunAsync(var_189, var_191)
            method_39((var_41: EnvStack8), (var_0: EnvStack8), (var_23: int64), (var_4: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3))
            let (var_192: uint64) = method_5((var_50: (uint64 ref)))
            let (var_193: EnvHeap2) = var_2.mem_0
            let (var_194: (int64 ref)) = var_193.mem_0
            let (var_195: EnvStack0) = var_193.mem_1
            let (var_196: (uint64 ref)) = var_195.mem_0
            let (var_197: uint64) = method_5((var_196: (uint64 ref)))
            // Cuda join point
            // method_40((var_192: uint64), (var_197: uint64))
            let (var_198: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_40", var_15, var_12)
            let (var_199: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_198.set_GridDimensions(var_199)
            let (var_200: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_198.set_BlockDimensions(var_200)
            let (var_201: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_203: (System.Object [])) = [|var_192; var_197|]: (System.Object [])
            var_198.RunAsync(var_201, var_203)
            let (var_204: EnvHeap2) = var_4.mem_0
            let (var_205: (int64 ref)) = var_204.mem_0
            let (var_206: EnvStack0) = var_204.mem_1
            let (var_207: (uint64 ref)) = var_206.mem_0
            let (var_208: uint64) = method_5((var_207: (uint64 ref)))
            let (var_209: EnvHeap2) = var_5.mem_0
            let (var_210: (int64 ref)) = var_209.mem_0
            let (var_211: EnvStack0) = var_209.mem_1
            let (var_212: (uint64 ref)) = var_211.mem_0
            let (var_213: uint64) = method_5((var_212: (uint64 ref)))
            // Cuda join point
            // method_44((var_208: uint64), (var_213: uint64))
            let (var_214: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_15, var_12)
            let (var_215: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
            var_214.set_GridDimensions(var_215)
            let (var_216: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_214.set_BlockDimensions(var_216)
            let (var_217: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_219: (System.Object [])) = [|var_208; var_213|]: (System.Object [])
            var_214.RunAsync(var_217, var_219)
            let (var_220: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_221: uint64) = method_5((var_207: (uint64 ref)))
            let (var_222: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_221)
            let (var_223: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_222)
            let (var_224: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
            var_12.ClearMemoryAsync(var_223, 0uy, var_224, var_220)
            let (var_225: uint64) = method_5((var_196: (uint64 ref)))
            let (var_226: uint64) = method_5((var_58: (uint64 ref)))
            // Cuda join point
            // method_46((var_225: uint64), (var_226: uint64))
            let (var_227: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_46", var_15, var_12)
            let (var_228: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_227.set_GridDimensions(var_228)
            let (var_229: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_227.set_BlockDimensions(var_229)
            let (var_230: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_232: (System.Object [])) = [|var_225; var_226|]: (System.Object [])
            var_227.RunAsync(var_230, var_232)
            let (var_233: ManagedCuda.BasicTypes.CUstream) = method_24((var_44: (bool ref)), (var_45: ManagedCuda.CudaStream))
            let (var_234: uint64) = method_5((var_196: (uint64 ref)))
            let (var_235: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_234)
            let (var_236: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_235)
            let (var_237: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
            var_12.ClearMemoryAsync(var_236, 0uy, var_237, var_233)
            let (var_238: int64) = 1L
            let (var_239: int64) = 0L
            let (var_240: (float32 [])) = method_47((var_238: int64), (var_144: EnvStack8), (var_239: int64))
            let (var_241: float32) = var_240.[int32 0L]
            let (var_242: float) = (float var_241)
            let (var_243: float) = (var_17 + var_242)
            let (var_244: int64) = 1L
            let (var_245: int64) = 0L
            let (var_246: (float32 [])) = method_47((var_244: int64), (var_144: EnvStack8), (var_245: int64))
            let (var_247: float32) = var_246.[int32 0L]
            let (var_248: float) = (float var_247)
            let (var_249: float) = (var_17 + var_248)
            method_48((var_33: ResizeArray<EnvHeap2>))
            let (var_250: int64) = (var_18 + 128L)
            method_26((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_249: float), (var_250: int64))
    else
        (Env10(var_17))
and method_50((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_17: int64), (var_18: float), (var_19: int64)): Env11 =
    let (var_20: bool) = (var_19 < 78L)
    if var_20 then
        let (var_21: bool) = System.Double.IsNaN(var_18)
        if var_21 then
            (Env11(var_17, var_18))
        else
            let (var_22: bool) = (var_19 >= 0L)
            let (var_23: bool) = (var_22 = false)
            if var_23 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_24: int64) = (var_19 * 100352L)
            if var_23 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_25: int64) = (var_19 * 1280L)
            let (var_26: EnvHeap9) = ({mem_0 = (var_8: ResizeArray<Env1>); mem_1 = (var_9: EnvStack0); mem_2 = (var_10: uint64); mem_3 = (var_11: ResizeArray<Env1>)} : EnvHeap9)
            let (var_27: ResizeArray<Env1>) = var_26.mem_0
            let (var_28: EnvStack0) = var_26.mem_1
            let (var_29: uint64) = var_26.mem_2
            let (var_30: ResizeArray<Env1>) = var_26.mem_3
            method_1((var_27: ResizeArray<Env1>), (var_28: EnvStack0), (var_29: uint64), (var_30: ResizeArray<Env1>))
            let (var_34: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
            let (var_35: EnvHeap2) = var_0.mem_0
            let (var_36: int64) = 5120L
            let (var_37: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_36: int64))
            let (var_38: EnvStack8) = EnvStack8((var_37: EnvHeap2))
            method_27((var_5: EnvStack8), (var_0: EnvStack8), (var_24: int64), (var_38: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3))
            let (var_39: EnvHeap2) = var_38.mem_0
            let (var_40: int64) = 5120L
            let (var_41: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_40: int64))
            let (var_42: EnvStack8) = EnvStack8((var_41: EnvHeap2))
            let (var_43: (int64 ref)) = var_16.mem_0
            let (var_44: EnvHeap4) = var_16.mem_1
            let (var_45: (bool ref)) = var_44.mem_0
            let (var_46: ManagedCuda.CudaStream) = var_44.mem_1
            let (var_47: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_48: EnvHeap2) = var_42.mem_0
            let (var_49: (int64 ref)) = var_48.mem_0
            let (var_50: EnvStack0) = var_48.mem_1
            let (var_51: (uint64 ref)) = var_50.mem_0
            let (var_52: uint64) = method_5((var_51: (uint64 ref)))
            let (var_53: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_52)
            let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_53)
            let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
            var_12.ClearMemoryAsync(var_54, 0uy, var_55, var_47)
            let (var_56: EnvHeap2) = var_3.mem_0
            let (var_57: (int64 ref)) = var_56.mem_0
            let (var_58: EnvStack0) = var_56.mem_1
            let (var_59: (uint64 ref)) = var_58.mem_0
            let (var_60: uint64) = method_5((var_59: (uint64 ref)))
            let (var_61: (int64 ref)) = var_39.mem_0
            let (var_62: EnvStack0) = var_39.mem_1
            let (var_63: (uint64 ref)) = var_62.mem_0
            let (var_64: uint64) = method_5((var_63: (uint64 ref)))
            let (var_65: uint64) = method_5((var_63: (uint64 ref)))
            // Cuda join point
            // method_28((var_60: uint64), (var_64: uint64), (var_65: uint64))
            let (var_66: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_15, var_12)
            let (var_67: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_66.set_GridDimensions(var_67)
            let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_66.set_BlockDimensions(var_68)
            let (var_69: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_71: (System.Object [])) = [|var_60; var_64; var_65|]: (System.Object [])
            var_66.RunAsync(var_69, var_71)
            let (var_76: int64) = 5120L
            let (var_77: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_76: int64))
            let (var_78: EnvStack8) = EnvStack8((var_77: EnvHeap2))
            let (var_79: uint64) = method_5((var_63: (uint64 ref)))
            let (var_80: EnvHeap2) = var_78.mem_0
            let (var_81: (int64 ref)) = var_80.mem_0
            let (var_82: EnvStack0) = var_80.mem_1
            let (var_83: (uint64 ref)) = var_82.mem_0
            let (var_84: uint64) = method_5((var_83: (uint64 ref)))
            // Cuda join point
            // method_31((var_79: uint64), (var_84: uint64))
            let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_15, var_12)
            let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_85.set_GridDimensions(var_86)
            let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_85.set_BlockDimensions(var_87)
            let (var_88: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_90: (System.Object [])) = [|var_79; var_84|]: (System.Object [])
            var_85.RunAsync(var_88, var_90)
            let (var_91: int64) = 5120L
            let (var_92: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_91: int64))
            let (var_93: EnvStack8) = EnvStack8((var_92: EnvHeap2))
            let (var_94: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_95: EnvHeap2) = var_93.mem_0
            let (var_96: (int64 ref)) = var_95.mem_0
            let (var_97: EnvStack0) = var_95.mem_1
            let (var_98: (uint64 ref)) = var_97.mem_0
            let (var_99: uint64) = method_5((var_98: (uint64 ref)))
            let (var_100: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_99)
            let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_100)
            let (var_102: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
            var_12.ClearMemoryAsync(var_101, 0uy, var_102, var_94)
            let (var_111: uint64) = method_5((var_83: (uint64 ref)))
            let (var_112: EnvHeap2) = var_1.mem_0
            let (var_113: (int64 ref)) = var_112.mem_0
            let (var_114: EnvStack0) = var_112.mem_1
            let (var_115: (uint64 ref)) = var_114.mem_0
            let (var_116: uint64) = method_5((var_115: (uint64 ref)))
            let (var_117: int64) = (var_25 * 4L)
            let (var_118: uint64) = (uint64 var_117)
            let (var_119: uint64) = (var_116 + var_118)
            let (var_127: int64) = 20L
            let (var_128: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_127: int64))
            let (var_129: EnvStack8) = EnvStack8((var_128: EnvHeap2))
            let (var_130: EnvHeap2) = var_129.mem_0
            let (var_131: (int64 ref)) = var_130.mem_0
            let (var_132: EnvStack0) = var_130.mem_1
            let (var_133: (uint64 ref)) = var_132.mem_0
            let (var_134: uint64) = method_5((var_133: (uint64 ref)))
            // Cuda join point
            // method_33((var_111: uint64), (var_119: uint64), (var_134: uint64))
            let (var_135: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_15, var_12)
            let (var_136: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
            var_135.set_GridDimensions(var_136)
            let (var_137: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
            var_135.set_BlockDimensions(var_137)
            let (var_138: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_140: (System.Object [])) = [|var_111; var_119; var_134|]: (System.Object [])
            var_135.RunAsync(var_138, var_140)
            let (var_141: uint64) = method_5((var_133: (uint64 ref)))
            let (var_143: int64) = 4L
            let (var_144: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_143: int64))
            let (var_145: EnvStack8) = EnvStack8((var_144: EnvHeap2))
            let (var_146: EnvHeap2) = var_145.mem_0
            let (var_147: (int64 ref)) = var_146.mem_0
            let (var_148: EnvStack0) = var_146.mem_1
            let (var_149: (uint64 ref)) = var_148.mem_0
            let (var_150: uint64) = method_5((var_149: (uint64 ref)))
            // Cuda join point
            // method_35((var_141: uint64), (var_150: uint64))
            let (var_151: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_15, var_12)
            let (var_152: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_151.set_GridDimensions(var_152)
            let (var_153: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
            var_151.set_BlockDimensions(var_153)
            let (var_154: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_156: (System.Object [])) = [|var_141; var_150|]: (System.Object [])
            var_151.RunAsync(var_154, var_156)
            let (var_157: int64) = 4L
            let (var_158: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_157: int64))
            let (var_159: EnvStack8) = EnvStack8((var_158: EnvHeap2))
            let (var_160: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_161: EnvHeap2) = var_159.mem_0
            let (var_162: (int64 ref)) = var_161.mem_0
            let (var_163: EnvStack0) = var_161.mem_1
            let (var_164: (uint64 ref)) = var_163.mem_0
            let (var_165: uint64) = method_5((var_164: (uint64 ref)))
            let (var_166: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_165)
            let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_166)
            let (var_168: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
            var_12.ClearMemoryAsync(var_167, 0uy, var_168, var_160)
            let (var_169: int64) = 1L
            let (var_170: int64) = 0L
            let (var_171: (float32 [])) = method_47((var_169: int64), (var_145: EnvStack8), (var_170: int64))
            let (var_172: float32) = var_171.[int32 0L]
            let (var_173: float) = (float var_172)
            let (var_174: float) = (var_18 + var_173)
            let (var_175: int64) = 512L
            let (var_176: EnvHeap2) = method_19((var_26: EnvHeap9), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_175: int64))
            let (var_177: EnvStack8) = EnvStack8((var_176: EnvHeap2))
            let (var_178: uint64) = method_5((var_83: (uint64 ref)))
            let (var_179: uint64) = method_5((var_115: (uint64 ref)))
            let (var_180: uint64) = (var_179 + var_118)
            let (var_181: EnvHeap2) = var_177.mem_0
            let (var_182: (int64 ref)) = var_181.mem_0
            let (var_183: EnvStack0) = var_181.mem_1
            let (var_184: (uint64 ref)) = var_183.mem_0
            let (var_185: uint64) = method_5((var_184: (uint64 ref)))
            // Cuda join point
            // method_51((var_178: uint64), (var_180: uint64), (var_185: uint64))
            let (var_186: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_51", var_15, var_12)
            let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
            var_186.set_GridDimensions(var_187)
            let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_186.set_BlockDimensions(var_188)
            let (var_189: ManagedCuda.BasicTypes.CUstream) = method_24((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_191: (System.Object [])) = [|var_178; var_180; var_185|]: (System.Object [])
            var_186.RunAsync(var_189, var_191)
            let (var_192: int64) = 0L
            let (var_193: int64) = 128L
            let (var_194: int64) = 0L
            let (var_195: int64) = 1L
            let (var_196: (float32 [])) = method_54((var_193: int64), (var_177: EnvStack8), (var_194: int64), (var_195: int64))
            let (var_197: int64) = var_196.LongLength
            let (var_198: int64) = 0L
            let (var_199: int64) = method_55((var_196: (float32 [])), (var_197: int64), (var_192: int64), (var_198: int64))
            let (var_200: int64) = (var_17 + var_199)
            method_48((var_34: ResizeArray<EnvHeap2>))
            let (var_201: int64) = (var_19 + 128L)
            method_50((var_0: EnvStack8), (var_1: EnvStack8), (var_2: EnvStack8), (var_3: EnvStack8), (var_4: EnvStack8), (var_5: EnvStack8), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: ResizeArray<Env1>), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<EnvHeap2>), (var_14: ResizeArray<EnvHeap3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: EnvHeap3), (var_200: int64), (var_174: float), (var_201: int64))
    else
        (Env11(var_17, var_18))
and method_57 ((var_0: EnvHeap3)): unit =
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
and method_49 ((var_0: EnvHeap2)): unit =
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
and method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: uint64), (var_4: int32)): Env1 =
    let (var_5: bool) = (var_4 < var_1)
    if var_5 then
        let (var_6: Env1) = var_0.[var_4]
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: (uint64 ref)) = var_2.mem_0
        let (var_12: uint64) = method_5((var_11: (uint64 ref)))
        let (var_13: uint64) = (var_12 + var_3)
        let (var_14: uint64) = (var_10 - var_13)
        let (var_15: uint64) = method_5((var_11: (uint64 ref)))
        let (var_16: uint64) = (var_15 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_15)
        let (var_20: bool) = (var_14 >= var_19)
        if var_20 then
            let (var_21: (uint64 ref)) = (ref var_18)
            let (var_22: EnvStack0) = EnvStack0((var_21: (uint64 ref)))
            let (var_23: uint64) = (var_14 - var_19)
            var_0.Add((Env1(var_22, var_23)))
        else
            ()
        let (var_24: int32) = (var_4 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_7: EnvStack0), (var_8: uint64), (var_24: int32))
    else
        (Env1(var_2, var_3))
and method_21 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_22((var_2: uint64))
and method_27((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: ResizeArray<Env1>), (var_7: EnvStack0), (var_8: uint64), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap2>), (var_12: ResizeArray<EnvHeap3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap3)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap4) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_24((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    var_4.set_Stream(var_20)
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_23: (float32 ref)) = (ref 1.000000f)
    let (var_24: EnvHeap2) = var_0.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: EnvHeap2) = var_1.mem_0
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
    let (var_42: EnvHeap2) = var_3.mem_0
    let (var_43: (int64 ref)) = var_42.mem_0
    let (var_44: EnvStack0) = var_42.mem_1
    let (var_45: (uint64 ref)) = var_44.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
    let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 10, 128, 784, var_23, var_30, 10, var_40, 784, var_41, var_48, 10)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_36((var_0: EnvStack8), (var_1: int64), (var_2: float32)): unit =
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
and method_39((var_0: EnvStack8), (var_1: EnvStack8), (var_2: int64), (var_3: EnvStack8), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: ResizeArray<Env1>), (var_7: EnvStack0), (var_8: uint64), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap2>), (var_12: ResizeArray<EnvHeap3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap3)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap4) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_24((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    var_4.set_Stream(var_20)
    let (var_21: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_22: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_23: (float32 ref)) = (ref 1.000000f)
    let (var_24: EnvHeap2) = var_0.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: EnvHeap2) = var_1.mem_0
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
    let (var_42: EnvHeap2) = var_3.mem_0
    let (var_43: (int64 ref)) = var_42.mem_0
    let (var_44: EnvStack0) = var_42.mem_1
    let (var_45: (uint64 ref)) = var_44.mem_0
    let (var_46: uint64) = method_5((var_45: (uint64 ref)))
    let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
    let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 10, 784, 128, var_23, var_30, 10, var_40, 784, var_41, var_48, 10)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_47((var_0: int64), (var_1: EnvStack8), (var_2: int64)): (float32 []) =
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
and method_54((var_0: int64), (var_1: EnvStack8), (var_2: int64), (var_3: int64)): (float32 []) =
    let (var_4: EnvHeap2) = var_1.mem_0
    let (var_5: int64) = (var_0 * var_3)
    let (var_6: (int64 ref)) = var_4.mem_0
    let (var_7: EnvStack0) = var_4.mem_1
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: int64) = (var_2 * 4L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_5))
    let (var_14: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_15: int64) = var_14.AddrOfPinnedObject().ToInt64()
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: int64) = (var_5 * 4L)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_23: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_19, var_21, var_22)
    if var_23 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_23)
    var_14.Free()
    var_13
and method_55((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
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
        method_55((var_0: (float32 [])), (var_1: int64), (var_8: int64), (var_9: int64))
    else
        var_2
and method_22 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
let (var_72: EnvHeap3) = method_8((var_71: EnvHeap4), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_73: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_74: Tuple5) = method_10((var_73: string))
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
method_11((var_76: (uint8 [])), (var_92: (float32 [])), (var_93: int64))
let (var_94: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_95: Tuple7) = method_13((var_94: string))
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
method_14((var_97: (uint8 [])), (var_103: (float32 [])), (var_104: int64))
let (var_105: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_106: Tuple5) = method_10((var_105: string))
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
method_16((var_108: (uint8 [])), (var_124: (float32 [])), (var_125: int64))
let (var_126: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_127: Tuple7) = method_13((var_126: string))
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
method_17((var_129: (uint8 [])), (var_135: (float32 [])), (var_136: int64))
let (var_137: int64) = 10000L
let (var_138: int64) = 0L
let (var_139: int64) = 784L
let (var_140: int64) = 1L
let (var_141: EnvStack8) = method_18((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_137: int64), (var_92: (float32 [])), (var_138: int64), (var_139: int64), (var_140: int64))
let (var_142: int64) = 10000L
let (var_143: int64) = 0L
let (var_144: int64) = 10L
let (var_145: int64) = 1L
let (var_146: EnvStack8) = method_18((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_142: int64), (var_103: (float32 [])), (var_143: int64), (var_144: int64), (var_145: int64))
let (var_147: int64) = 60000L
let (var_148: int64) = 0L
let (var_149: int64) = 784L
let (var_150: int64) = 1L
let (var_151: EnvStack8) = method_18((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_147: int64), (var_124: (float32 [])), (var_148: int64), (var_149: int64), (var_150: int64))
let (var_152: int64) = 60000L
let (var_153: int64) = 0L
let (var_154: int64) = 10L
let (var_155: int64) = 1L
let (var_156: EnvStack8) = method_18((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_152: int64), (var_135: (float32 [])), (var_153: int64), (var_154: int64), (var_155: int64))
let (var_157: int64) = 31360L
let (var_158: EnvHeap9) = ({mem_0 = (var_41: ResizeArray<Env1>); mem_1 = (var_40: EnvStack0); mem_2 = (var_35: uint64); mem_3 = (var_42: ResizeArray<Env1>)} : EnvHeap9)
let (var_159: EnvHeap2) = method_19((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_157: int64))
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
let (var_171: ManagedCuda.BasicTypes.CUstream) = method_24((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
var_44.SetStream(var_171)
let (var_172: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_165)
let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_172)
var_44.GenerateNormal32(var_173, var_166, 0.000000f, 0.050189f)
let (var_174: int64) = 31360L
let (var_175: EnvHeap2) = method_19((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_174: int64))
let (var_176: EnvStack8) = EnvStack8((var_175: EnvHeap2))
let (var_177: ManagedCuda.BasicTypes.CUstream) = method_24((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
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
let (var_187: EnvHeap2) = method_19((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_186: int64))
let (var_188: EnvStack8) = EnvStack8((var_187: EnvHeap2))
let (var_189: ManagedCuda.BasicTypes.CUstream) = method_24((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
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
let (var_199: EnvHeap2) = method_19((var_158: EnvHeap9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_198: int64))
let (var_200: EnvStack8) = EnvStack8((var_199: EnvHeap2))
let (var_201: ManagedCuda.BasicTypes.CUstream) = method_24((var_169: (bool ref)), (var_170: ManagedCuda.CudaStream))
let (var_202: EnvHeap2) = var_200.mem_0
let (var_203: (int64 ref)) = var_202.mem_0
let (var_204: EnvStack0) = var_202.mem_1
let (var_205: (uint64 ref)) = var_204.mem_0
let (var_206: uint64) = method_5((var_205: (uint64 ref)))
let (var_207: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_206)
let (var_208: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_207)
let (var_209: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_208, 0uy, var_209, var_201)
let (var_210: int64) = 0L
method_25((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap2>), (var_68: ResizeArray<EnvHeap3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap3), (var_200: EnvStack8), (var_188: EnvStack8), (var_176: EnvStack8), (var_160: EnvStack8), (var_141: EnvStack8), (var_146: EnvStack8), (var_151: EnvStack8), (var_156: EnvStack8), (var_210: int64))
method_56((var_68: ResizeArray<EnvHeap3>))
method_48((var_56: ResizeArray<EnvHeap2>))
var_47.Dispose()
var_44.Dispose()
let (var_211: (uint64 ref)) = var_40.mem_0
let (var_212: uint64) = method_5((var_211: (uint64 ref)))
let (var_213: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_212)
let (var_214: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_213)
var_1.FreeMemory(var_214)
var_211 := 0UL
var_1.Dispose()

