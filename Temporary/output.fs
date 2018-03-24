module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple1 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, float mem_1){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer0)(float, float);
    struct Tuple2 {
        float mem_0;
        float mem_1;
        float mem_2;
        float mem_3;
    };
    __device__ __forceinline__ Tuple2 make_Tuple2(float mem_0, float mem_1, float mem_2, float mem_3){
        Tuple2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        tmp.mem_3 = mem_3;
        return tmp;
    }
    __global__ void method_21(unsigned char * var_0, float * var_1);
    __global__ void method_34(float var_0, float * var_1);
    __global__ void method_78(float * var_0, float * var_1, float * var_2);
    __global__ void method_97(float * var_0, float * var_1, float * var_2);
    __global__ void method_52(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_91(float * var_0, float * var_1);
    __global__ void method_135(float * var_0, float * var_1);
    __global__ void method_139(float * var_0, float * var_1);
    __global__ void method_58(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6);
    __global__ void method_64(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    __global__ void method_83(float * var_0, float * var_1);
    __global__ void method_103(float * var_0, float * var_1, float * var_2);
    __global__ void method_112(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6);
    __global__ void method_117(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9, float * var_10, float * var_11);
    __global__ void method_123(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9);
    __device__ char method_22(long long int * var_0);
    __device__ char method_23(long long int * var_0);
    __device__ char method_53(long long int * var_0);
    __device__ char method_98(long long int * var_0, float * var_1);
    __device__ char method_92(long long int * var_0);
    __device__ float method_93(float var_0, float var_1);
    __device__ char method_140(long long int * var_0);
    __device__ char method_59(long long int * var_0, float * var_1, float * var_2);
    __device__ char method_60(long long int * var_0, float * var_1, float * var_2);
    __device__ char method_61(long long int var_0, long long int * var_1, float * var_2, float * var_3);
    __device__ char method_84(long long int * var_0, float * var_1);
    __device__ char method_85(long long int * var_0, float * var_1);
    __device__ char method_86(long long int var_0, long long int * var_1, float * var_2);
    __device__ char method_104(long long int * var_0);
    __device__ char method_118(long long int * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_119(long long int * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_120(long long int var_0, long long int * var_1, float * var_2, float * var_3, float * var_4, float * var_5);
    
    __global__ void method_21(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_22(var_6)) {
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
            while (method_23(var_35)) {
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
    __global__ void method_34(float var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_23(var_6)) {
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
            float var_16 = var_1[var_8];
            var_1[var_8] = var_0;
            long long int var_17 = (var_8 + 128);
            var_6[0] = var_17;
        }
        long long int var_18 = var_6[0];
    }
    __global__ void method_78(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_23(var_7)) {
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
            while (method_53(var_18)) {
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
                float var_30 = var_1[var_29];
                char var_32;
                if (var_21) {
                    var_32 = (var_20 < 64);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                char var_35;
                if (var_10) {
                    var_35 = (var_9 < 128);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                float var_37 = var_0[var_9];
                float var_38 = var_2[var_29];
                float var_39 = (var_37 + var_30);
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
    __global__ void method_97(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_98(var_8, var_9)) {
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
            float var_19 = (-var_18);
            float var_20 = log(var_17);
            float var_21 = (var_19 * var_20);
            float var_22 = (var_12 + var_21);
            long long int var_23 = (var_11 + 1024);
            var_8[0] = var_23;
            var_9[0] = var_22;
        }
        long long int var_24 = var_8[0];
        float var_25 = var_9[0];
        float var_26 = cub::BlockReduce<float,1024,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_25);
        float var_27 = (var_26 / 64);
        long long int var_28 = threadIdx.x;
        char var_29 = (var_28 == 0);
        if (var_29) {
            long long int var_30 = blockIdx.x;
            char var_31 = (var_30 >= 0);
            char var_33;
            if (var_31) {
                var_33 = (var_30 < 1);
            } else {
                var_33 = 0;
            }
            char var_34 = (var_33 == 0);
            if (var_34) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_30] = var_27;
        } else {
        }
    }
    __global__ void method_52(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (32 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_23(var_8)) {
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
            long long int var_15 = threadIdx.y;
            long long int var_16 = blockIdx.y;
            long long int var_17 = (32 * var_16);
            long long int var_18 = (var_15 + var_17);
            long long int var_19[1];
            var_19[0] = var_18;
            while (method_53(var_19)) {
                long long int var_21 = var_19[0];
                char var_22 = (var_21 >= 0);
                char var_24;
                if (var_22) {
                    var_24 = (var_21 < 64);
                } else {
                    var_24 = 0;
                }
                char var_25 = (var_24 == 0);
                if (var_25) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_26 = (var_21 * 128);
                char var_28;
                if (var_11) {
                    var_28 = (var_10 < 128);
                } else {
                    var_28 = 0;
                }
                char var_29 = (var_28 == 0);
                if (var_29) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_30 = (var_26 + var_10);
                float var_31 = var_2[var_30];
                char var_33;
                if (var_22) {
                    var_33 = (var_21 < 64);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                char var_36;
                if (var_11) {
                    var_36 = (var_10 < 128);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                float var_38 = var_0[var_10];
                float var_39 = var_1[var_10];
                float var_40 = var_3[var_30];
                float var_41 = (var_38 * var_31);
                float var_42 = (var_41 + var_39);
                float var_43 = (-var_42);
                float var_44 = exp(var_43);
                float var_45 = (1 + var_44);
                float var_46 = (1 / var_45);
                var_3[var_30] = var_46;
                long long int var_47 = (var_21 + 32);
                var_19[0] = var_47;
            }
            long long int var_48 = var_19[0];
            long long int var_49 = (var_10 + 128);
            var_8[0] = var_49;
        }
        long long int var_50 = var_8[0];
    }
    __global__ void method_91(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.y;
        long long int var_3 = blockIdx.y;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_53(var_5)) {
            long long int var_7 = var_5[0];
            char var_8 = (var_7 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_7 < 64);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_12 = (var_7 * 128);
            char var_14;
            if (var_8) {
                var_14 = (var_7 < 64);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            float var_16[1];
            long long int var_17 = threadIdx.x;
            long long int var_18 = blockIdx.x;
            long long int var_19 = (128 * var_18);
            long long int var_20 = (var_17 + var_19);
            long long int var_21[1];
            var_21[0] = 0;
            while (method_92(var_21)) {
                long long int var_23 = var_21[0];
                long long int var_24 = (128 * var_23);
                long long int var_25 = (var_20 + var_24);
                long long int var_26 = (128 - var_24);
                char var_27 = (var_25 < 128);
                if (var_27) {
                    char var_28 = (var_23 >= 0);
                    char var_30;
                    if (var_28) {
                        var_30 = (var_23 < 1);
                    } else {
                        var_30 = 0;
                    }
                    char var_31 = (var_30 == 0);
                    if (var_31) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_32 = (var_25 >= 0);
                    char var_33 = (var_32 == 0);
                    if (var_33) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_34 = (var_12 + var_25);
                    float var_35 = var_0[var_34];
                    var_16[var_23] = var_35;
                } else {
                }
                long long int var_36 = (var_23 + 1);
                var_21[0] = var_36;
            }
            long long int var_37 = var_21[0];
            FunPointer0 var_40 = method_93;
            float var_41 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_16, var_40);
            __shared__ float var_42[1];
            long long int var_43 = threadIdx.x;
            char var_44 = (var_43 == 0);
            if (var_44) {
                var_42[0] = var_41;
            } else {
            }
            __syncthreads();
            float var_45 = var_42[0];
            float var_48[1];
            long long int var_49[1];
            var_49[0] = 0;
            while (method_92(var_49)) {
                long long int var_51 = var_49[0];
                long long int var_52 = (128 * var_51);
                long long int var_53 = (var_20 + var_52);
                long long int var_54 = (128 - var_52);
                char var_55 = (var_53 < 128);
                if (var_55) {
                    char var_56 = (var_53 >= 0);
                    char var_57 = (var_56 == 0);
                    if (var_57) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_58 = (var_12 + var_53);
                    char var_59 = (var_51 >= 0);
                    char var_61;
                    if (var_59) {
                        var_61 = (var_51 < 1);
                    } else {
                        var_61 = 0;
                    }
                    char var_62 = (var_61 == 0);
                    if (var_62) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_63 = var_16[var_51];
                    float var_64 = (var_63 - var_45);
                    float var_65 = exp(var_64);
                    char var_67;
                    if (var_59) {
                        var_67 = (var_51 < 1);
                    } else {
                        var_67 = 0;
                    }
                    char var_68 = (var_67 == 0);
                    if (var_68) {
                        // "Argument out of bounds."
                    } else {
                    }
                    var_48[var_51] = var_65;
                } else {
                }
                long long int var_69 = (var_51 + 1);
                var_49[0] = var_69;
            }
            long long int var_70 = var_49[0];
            float var_71 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_48);
            __shared__ float var_72[1];
            long long int var_73 = threadIdx.x;
            char var_74 = (var_73 == 0);
            if (var_74) {
                var_72[0] = var_71;
            } else {
            }
            __syncthreads();
            float var_75 = var_72[0];
            long long int var_76[1];
            var_76[0] = 0;
            while (method_92(var_76)) {
                long long int var_78 = var_76[0];
                long long int var_79 = (128 * var_78);
                long long int var_80 = (var_20 + var_79);
                long long int var_81 = (128 - var_79);
                char var_82 = (var_80 < 128);
                if (var_82) {
                    char var_83 = (var_80 >= 0);
                    char var_84 = (var_83 == 0);
                    if (var_84) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_85 = (var_12 + var_80);
                    char var_86 = (var_78 >= 0);
                    char var_88;
                    if (var_86) {
                        var_88 = (var_78 < 1);
                    } else {
                        var_88 = 0;
                    }
                    char var_89 = (var_88 == 0);
                    if (var_89) {
                        // "Argument out of bounds."
                    } else {
                    }
                    float var_90 = var_48[var_78];
                    float var_91 = var_1[var_85];
                    float var_92 = (var_90 / var_75);
                    var_1[var_85] = var_92;
                } else {
                }
                long long int var_93 = (var_78 + 1);
                var_76[0] = var_93;
            }
            long long int var_94 = var_76[0];
            long long int var_95 = (var_7 + 64);
            var_5[0] = var_95;
        }
        long long int var_96 = var_5[0];
    }
    __global__ void method_135(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_23(var_6)) {
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
            char var_18 = (var_17 < -0.5);
            float var_21;
            if (var_18) {
                var_21 = -0.5;
            } else {
                char var_19 = (var_17 > 0.5);
                if (var_19) {
                    var_21 = 0.5;
                } else {
                    var_21 = var_17;
                }
            }
            float var_22 = (0.03 * var_21);
            float var_23 = (var_16 - var_22);
            var_0[var_8] = var_23;
            var_1[var_8] = 0;
            long long int var_24 = (var_8 + 128);
            var_6[0] = var_24;
        }
        long long int var_25 = var_6[0];
    }
    __global__ void method_139(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_140(var_6)) {
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
            char var_18 = (var_17 < -0.5);
            float var_21;
            if (var_18) {
                var_21 = -0.5;
            } else {
                char var_19 = (var_17 > 0.5);
                if (var_19) {
                    var_21 = 0.5;
                } else {
                    var_21 = var_17;
                }
            }
            float var_22 = (0.03 * var_21);
            float var_23 = (var_16 - var_22);
            var_0[var_8] = var_23;
            var_1[var_8] = 0;
            long long int var_24 = (var_8 + 8192);
            var_6[0] = var_24;
        }
        long long int var_25 = var_6[0];
    }
    __global__ void method_58(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6) {
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (32 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11[1];
        var_11[0] = var_10;
        while (method_23(var_11)) {
            long long int var_13 = var_11[0];
            char var_14 = (var_13 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_13 < 128);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            float var_18 = var_3[var_13];
            float var_19 = var_4[var_13];
            char var_21;
            if (var_14) {
                var_21 = (var_13 < 128);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = threadIdx.y;
            long long int var_24 = blockIdx.y;
            long long int var_25 = (32 * var_24);
            long long int var_26 = (var_23 + var_25);
            float var_27 = 0;
            float var_28 = 0;
            long long int var_29[1];
            float var_30[1];
            float var_31[1];
            var_29[0] = var_26;
            var_30[0] = var_27;
            var_31[0] = var_28;
            while (method_59(var_29, var_30, var_31)) {
                long long int var_33 = var_29[0];
                float var_34 = var_30[0];
                float var_35 = var_31[0];
                char var_36 = (var_33 >= 0);
                char var_38;
                if (var_36) {
                    var_38 = (var_33 < 64);
                } else {
                    var_38 = 0;
                }
                char var_39 = (var_38 == 0);
                if (var_39) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_40 = (var_33 * 128);
                char var_42;
                if (var_14) {
                    var_42 = (var_13 < 128);
                } else {
                    var_42 = 0;
                }
                char var_43 = (var_42 == 0);
                if (var_43) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_44 = (var_40 + var_13);
                float var_45 = var_0[var_44];
                float var_46 = var_1[var_44];
                float var_47 = var_2[var_44];
                float var_48 = (1 - var_47);
                float var_49 = (var_47 * var_48);
                float var_50 = (var_49 * var_45);
                float var_51 = (var_46 * var_50);
                float var_52 = (var_46 * var_49);
                float var_53 = (var_34 + var_51);
                float var_54 = (var_35 + var_52);
                long long int var_55 = (var_33 + 32);
                var_29[0] = var_55;
                var_30[0] = var_53;
                var_31[0] = var_54;
            }
            long long int var_56 = var_29[0];
            float var_57 = var_30[0];
            float var_58 = var_31[0];
            __shared__ float var_59[992];
            __shared__ float var_60[992];
            long long int var_61[1];
            float var_62[1];
            float var_63[1];
            var_61[0] = 32;
            var_62[0] = var_57;
            var_63[0] = var_58;
            while (method_60(var_61, var_62, var_63)) {
                long long int var_65 = var_61[0];
                float var_66 = var_62[0];
                float var_67 = var_63[0];
                long long int var_68 = (var_65 / 2);
                long long int var_69 = threadIdx.y;
                char var_70 = (var_69 < var_65);
                char var_73;
                if (var_70) {
                    long long int var_71 = threadIdx.y;
                    var_73 = (var_71 >= var_68);
                } else {
                    var_73 = 0;
                }
                if (var_73) {
                    long long int var_74 = threadIdx.y;
                    char var_75 = (var_74 >= 1);
                    char var_77;
                    if (var_75) {
                        var_77 = (var_74 < 32);
                    } else {
                        var_77 = 0;
                    }
                    char var_78 = (var_77 == 0);
                    if (var_78) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_79 = (var_74 - 1);
                    long long int var_80 = (var_79 * 32);
                    long long int var_81 = threadIdx.x;
                    char var_82 = (var_81 >= 0);
                    char var_84;
                    if (var_82) {
                        var_84 = (var_81 < 32);
                    } else {
                        var_84 = 0;
                    }
                    char var_85 = (var_84 == 0);
                    if (var_85) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_86 = (var_80 + var_81);
                    var_59[var_86] = var_66;
                    var_60[var_86] = var_67;
                } else {
                }
                __syncthreads();
                long long int var_87 = threadIdx.y;
                char var_88 = (var_87 < var_68);
                Tuple1 var_118;
                if (var_88) {
                    long long int var_89 = threadIdx.y;
                    long long int var_90 = (var_89 + var_68);
                    long long int var_91[1];
                    float var_92[1];
                    float var_93[1];
                    var_91[0] = var_90;
                    var_92[0] = var_66;
                    var_93[0] = var_67;
                    while (method_61(var_65, var_91, var_92, var_93)) {
                        long long int var_95 = var_91[0];
                        float var_96 = var_92[0];
                        float var_97 = var_93[0];
                        char var_98 = (var_95 >= 1);
                        char var_100;
                        if (var_98) {
                            var_100 = (var_95 < 32);
                        } else {
                            var_100 = 0;
                        }
                        char var_101 = (var_100 == 0);
                        if (var_101) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_102 = (var_95 - 1);
                        long long int var_103 = (var_102 * 32);
                        long long int var_104 = threadIdx.x;
                        char var_105 = (var_104 >= 0);
                        char var_107;
                        if (var_105) {
                            var_107 = (var_104 < 32);
                        } else {
                            var_107 = 0;
                        }
                        char var_108 = (var_107 == 0);
                        if (var_108) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_109 = (var_103 + var_104);
                        float var_110 = var_59[var_109];
                        float var_111 = var_60[var_109];
                        float var_112 = (var_96 + var_110);
                        float var_113 = (var_97 + var_111);
                        long long int var_114 = (var_95 + var_68);
                        var_91[0] = var_114;
                        var_92[0] = var_112;
                        var_93[0] = var_113;
                    }
                    long long int var_115 = var_91[0];
                    float var_116 = var_92[0];
                    float var_117 = var_93[0];
                    var_118 = make_Tuple1(var_116, var_117);
                } else {
                    var_118 = make_Tuple1(var_66, var_67);
                }
                float var_119 = var_118.mem_0;
                float var_120 = var_118.mem_1;
                var_61[0] = var_68;
                var_62[0] = var_119;
                var_63[0] = var_120;
            }
            long long int var_121 = var_61[0];
            float var_122 = var_62[0];
            float var_123 = var_63[0];
            long long int var_124 = threadIdx.y;
            char var_125 = (var_124 == 0);
            if (var_125) {
                float var_126 = var_5[var_13];
                float var_127 = var_6[var_13];
                float var_128 = (var_122 + var_126);
                float var_129 = (var_123 + var_127);
                var_5[var_13] = var_128;
                var_6[var_13] = var_129;
            } else {
            }
            long long int var_130 = (var_13 + 128);
            var_11[0] = var_130;
        }
        long long int var_131 = var_11[0];
    }
    __global__ void method_64(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = blockIdx.x;
        long long int var_8 = (32 * var_7);
        long long int var_9 = (var_6 + var_8);
        long long int var_10[1];
        var_10[0] = var_9;
        while (method_23(var_10)) {
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
            long long int var_17 = threadIdx.y;
            long long int var_18 = blockIdx.y;
            long long int var_19 = (32 * var_18);
            long long int var_20 = (var_17 + var_19);
            long long int var_21[1];
            var_21[0] = var_20;
            while (method_53(var_21)) {
                long long int var_23 = var_21[0];
                char var_24 = (var_23 >= 0);
                char var_26;
                if (var_24) {
                    var_26 = (var_23 < 64);
                } else {
                    var_26 = 0;
                }
                char var_27 = (var_26 == 0);
                if (var_27) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_28 = (var_23 * 128);
                char var_30;
                if (var_13) {
                    var_30 = (var_12 < 128);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_32 = (var_28 + var_12);
                float var_33 = var_2[var_32];
                float var_34 = var_3[var_32];
                float var_35 = var_4[var_32];
                char var_37;
                if (var_24) {
                    var_37 = (var_23 < 64);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                char var_40;
                if (var_13) {
                    var_40 = (var_12 < 128);
                } else {
                    var_40 = 0;
                }
                char var_41 = (var_40 == 0);
                if (var_41) {
                    // "Argument out of bounds."
                } else {
                }
                float var_42 = var_0[var_12];
                float var_43 = var_1[var_12];
                float var_44 = (1 - var_35);
                float var_45 = (var_35 * var_44);
                float var_46 = (var_42 * var_45);
                float var_47 = var_5[var_32];
                float var_48 = (var_34 * var_46);
                float var_49 = (var_47 + var_48);
                var_5[var_32] = var_49;
                long long int var_50 = (var_23 + 32);
                var_21[0] = var_50;
            }
            long long int var_51 = var_21[0];
            long long int var_52 = (var_12 + 128);
            var_10[0] = var_52;
        }
        long long int var_53 = var_10[0];
    }
    __global__ void method_83(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_23(var_6)) {
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
            while (method_84(var_21, var_22)) {
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
            while (method_85(var_41, var_42)) {
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
                    while (method_86(var_44, var_69, var_70)) {
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
    __global__ void method_103(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_104(var_7)) {
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
            float var_20 = (var_17 - var_18);
            float var_21 = (var_20 / 64);
            float var_22 = (var_19 + var_21);
            var_2[var_9] = var_22;
            long long int var_23 = (var_9 + 8192);
            var_7[0] = var_23;
        }
        long long int var_24 = var_7[0];
    }
    __global__ void method_112(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6) {
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (32 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11[1];
        var_11[0] = var_10;
        while (method_23(var_11)) {
            long long int var_13 = var_11[0];
            char var_14 = (var_13 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_13 < 128);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_18 = threadIdx.y;
            long long int var_19 = blockIdx.y;
            long long int var_20 = (32 * var_19);
            long long int var_21 = (var_18 + var_20);
            long long int var_22[1];
            var_22[0] = var_21;
            while (method_53(var_22)) {
                long long int var_24 = var_22[0];
                char var_25 = (var_24 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_24 < 64);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_24 * 128);
                char var_31;
                if (var_14) {
                    var_31 = (var_13 < 128);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_13);
                float var_34 = var_4[var_33];
                float var_35 = var_5[var_33];
                char var_37;
                if (var_25) {
                    var_37 = (var_24 < 64);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                char var_40;
                if (var_14) {
                    var_40 = (var_13 < 128);
                } else {
                    var_40 = 0;
                }
                char var_41 = (var_40 == 0);
                if (var_41) {
                    // "Argument out of bounds."
                } else {
                }
                float var_42 = var_0[var_13];
                float var_43 = var_1[var_13];
                float var_44 = var_2[var_13];
                float var_45 = var_3[var_13];
                float var_46 = var_6[var_33];
                float var_47 = (var_42 * var_34);
                float var_48 = (var_47 * var_35);
                float var_49 = (var_43 * var_35);
                float var_50 = (var_48 + var_49);
                float var_51 = (var_44 * var_34);
                float var_52 = (var_50 + var_51);
                float var_53 = (var_52 + var_45);
                float var_54 = (-var_53);
                float var_55 = exp(var_54);
                float var_56 = (1 + var_55);
                float var_57 = (1 / var_56);
                var_6[var_33] = var_57;
                long long int var_58 = (var_24 + 32);
                var_22[0] = var_58;
            }
            long long int var_59 = var_22[0];
            long long int var_60 = (var_13 + 128);
            var_11[0] = var_60;
        }
        long long int var_61 = var_11[0];
    }
    __global__ void method_117(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9, float * var_10, float * var_11) {
        long long int var_12 = threadIdx.x;
        long long int var_13 = blockIdx.x;
        long long int var_14 = (32 * var_13);
        long long int var_15 = (var_12 + var_14);
        long long int var_16[1];
        var_16[0] = var_15;
        while (method_23(var_16)) {
            long long int var_18 = var_16[0];
            char var_19 = (var_18 >= 0);
            char var_21;
            if (var_19) {
                var_21 = (var_18 < 128);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            float var_23 = var_4[var_18];
            float var_24 = var_5[var_18];
            float var_25 = var_6[var_18];
            float var_26 = var_7[var_18];
            char var_28;
            if (var_19) {
                var_28 = (var_18 < 128);
            } else {
                var_28 = 0;
            }
            char var_29 = (var_28 == 0);
            if (var_29) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_30 = threadIdx.y;
            long long int var_31 = blockIdx.y;
            long long int var_32 = (32 * var_31);
            long long int var_33 = (var_30 + var_32);
            float var_34 = 0;
            float var_35 = 0;
            float var_36 = 0;
            float var_37 = 0;
            long long int var_38[1];
            float var_39[1];
            float var_40[1];
            float var_41[1];
            float var_42[1];
            var_38[0] = var_33;
            var_39[0] = var_34;
            var_40[0] = var_35;
            var_41[0] = var_36;
            var_42[0] = var_37;
            while (method_118(var_38, var_39, var_40, var_41, var_42)) {
                long long int var_44 = var_38[0];
                float var_45 = var_39[0];
                float var_46 = var_40[0];
                float var_47 = var_41[0];
                float var_48 = var_42[0];
                char var_49 = (var_44 >= 0);
                char var_51;
                if (var_49) {
                    var_51 = (var_44 < 64);
                } else {
                    var_51 = 0;
                }
                char var_52 = (var_51 == 0);
                if (var_52) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_53 = (var_44 * 128);
                char var_55;
                if (var_19) {
                    var_55 = (var_18 < 128);
                } else {
                    var_55 = 0;
                }
                char var_56 = (var_55 == 0);
                if (var_56) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_57 = (var_53 + var_18);
                float var_58 = var_0[var_57];
                float var_59 = var_1[var_57];
                float var_60 = var_2[var_57];
                float var_61 = var_3[var_57];
                float var_62 = (var_58 * var_59);
                float var_63 = (1 - var_61);
                float var_64 = (var_61 * var_63);
                float var_65 = (var_64 * var_62);
                float var_66 = (var_64 * var_59);
                float var_67 = (var_64 * var_58);
                float var_68 = (var_60 * var_65);
                float var_69 = (var_60 * var_66);
                float var_70 = (var_60 * var_67);
                float var_71 = (var_60 * var_64);
                float var_72 = (var_45 + var_68);
                float var_73 = (var_46 + var_69);
                float var_74 = (var_47 + var_70);
                float var_75 = (var_48 + var_71);
                long long int var_76 = (var_44 + 32);
                var_38[0] = var_76;
                var_39[0] = var_72;
                var_40[0] = var_73;
                var_41[0] = var_74;
                var_42[0] = var_75;
            }
            long long int var_77 = var_38[0];
            float var_78 = var_39[0];
            float var_79 = var_40[0];
            float var_80 = var_41[0];
            float var_81 = var_42[0];
            __shared__ float var_82[992];
            __shared__ float var_83[992];
            __shared__ float var_84[992];
            __shared__ float var_85[992];
            long long int var_86[1];
            float var_87[1];
            float var_88[1];
            float var_89[1];
            float var_90[1];
            var_86[0] = 32;
            var_87[0] = var_78;
            var_88[0] = var_79;
            var_89[0] = var_80;
            var_90[0] = var_81;
            while (method_119(var_86, var_87, var_88, var_89, var_90)) {
                long long int var_92 = var_86[0];
                float var_93 = var_87[0];
                float var_94 = var_88[0];
                float var_95 = var_89[0];
                float var_96 = var_90[0];
                long long int var_97 = (var_92 / 2);
                long long int var_98 = threadIdx.y;
                char var_99 = (var_98 < var_92);
                char var_102;
                if (var_99) {
                    long long int var_100 = threadIdx.y;
                    var_102 = (var_100 >= var_97);
                } else {
                    var_102 = 0;
                }
                if (var_102) {
                    long long int var_103 = threadIdx.y;
                    char var_104 = (var_103 >= 1);
                    char var_106;
                    if (var_104) {
                        var_106 = (var_103 < 32);
                    } else {
                        var_106 = 0;
                    }
                    char var_107 = (var_106 == 0);
                    if (var_107) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_108 = (var_103 - 1);
                    long long int var_109 = (var_108 * 32);
                    long long int var_110 = threadIdx.x;
                    char var_111 = (var_110 >= 0);
                    char var_113;
                    if (var_111) {
                        var_113 = (var_110 < 32);
                    } else {
                        var_113 = 0;
                    }
                    char var_114 = (var_113 == 0);
                    if (var_114) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_115 = (var_109 + var_110);
                    var_82[var_115] = var_93;
                    var_83[var_115] = var_94;
                    var_84[var_115] = var_95;
                    var_85[var_115] = var_96;
                } else {
                }
                __syncthreads();
                long long int var_116 = threadIdx.y;
                char var_117 = (var_116 < var_97);
                Tuple2 var_157;
                if (var_117) {
                    long long int var_118 = threadIdx.y;
                    long long int var_119 = (var_118 + var_97);
                    long long int var_120[1];
                    float var_121[1];
                    float var_122[1];
                    float var_123[1];
                    float var_124[1];
                    var_120[0] = var_119;
                    var_121[0] = var_93;
                    var_122[0] = var_94;
                    var_123[0] = var_95;
                    var_124[0] = var_96;
                    while (method_120(var_92, var_120, var_121, var_122, var_123, var_124)) {
                        long long int var_126 = var_120[0];
                        float var_127 = var_121[0];
                        float var_128 = var_122[0];
                        float var_129 = var_123[0];
                        float var_130 = var_124[0];
                        char var_131 = (var_126 >= 1);
                        char var_133;
                        if (var_131) {
                            var_133 = (var_126 < 32);
                        } else {
                            var_133 = 0;
                        }
                        char var_134 = (var_133 == 0);
                        if (var_134) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_135 = (var_126 - 1);
                        long long int var_136 = (var_135 * 32);
                        long long int var_137 = threadIdx.x;
                        char var_138 = (var_137 >= 0);
                        char var_140;
                        if (var_138) {
                            var_140 = (var_137 < 32);
                        } else {
                            var_140 = 0;
                        }
                        char var_141 = (var_140 == 0);
                        if (var_141) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_142 = (var_136 + var_137);
                        float var_143 = var_82[var_142];
                        float var_144 = var_83[var_142];
                        float var_145 = var_84[var_142];
                        float var_146 = var_85[var_142];
                        float var_147 = (var_127 + var_143);
                        float var_148 = (var_128 + var_144);
                        float var_149 = (var_129 + var_145);
                        float var_150 = (var_130 + var_146);
                        long long int var_151 = (var_126 + var_97);
                        var_120[0] = var_151;
                        var_121[0] = var_147;
                        var_122[0] = var_148;
                        var_123[0] = var_149;
                        var_124[0] = var_150;
                    }
                    long long int var_152 = var_120[0];
                    float var_153 = var_121[0];
                    float var_154 = var_122[0];
                    float var_155 = var_123[0];
                    float var_156 = var_124[0];
                    var_157 = make_Tuple2(var_153, var_154, var_155, var_156);
                } else {
                    var_157 = make_Tuple2(var_93, var_94, var_95, var_96);
                }
                float var_158 = var_157.mem_0;
                float var_159 = var_157.mem_1;
                float var_160 = var_157.mem_2;
                float var_161 = var_157.mem_3;
                var_86[0] = var_97;
                var_87[0] = var_158;
                var_88[0] = var_159;
                var_89[0] = var_160;
                var_90[0] = var_161;
            }
            long long int var_162 = var_86[0];
            float var_163 = var_87[0];
            float var_164 = var_88[0];
            float var_165 = var_89[0];
            float var_166 = var_90[0];
            long long int var_167 = threadIdx.y;
            char var_168 = (var_167 == 0);
            if (var_168) {
                float var_169 = var_8[var_18];
                float var_170 = var_9[var_18];
                float var_171 = var_10[var_18];
                float var_172 = var_11[var_18];
                float var_173 = (var_163 + var_169);
                float var_174 = (var_164 + var_170);
                float var_175 = (var_165 + var_171);
                float var_176 = (var_166 + var_172);
                var_8[var_18] = var_173;
                var_9[var_18] = var_174;
                var_10[var_18] = var_175;
                var_11[var_18] = var_176;
            } else {
            }
            long long int var_177 = (var_18 + 128);
            var_16[0] = var_177;
        }
        long long int var_178 = var_16[0];
    }
    __global__ void method_123(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4, float * var_5, float * var_6, float * var_7, float * var_8, float * var_9) {
        long long int var_10 = threadIdx.x;
        long long int var_11 = blockIdx.x;
        long long int var_12 = (32 * var_11);
        long long int var_13 = (var_10 + var_12);
        long long int var_14[1];
        var_14[0] = var_13;
        while (method_23(var_14)) {
            long long int var_16 = var_14[0];
            char var_17 = (var_16 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_16 < 128);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_21 = threadIdx.y;
            long long int var_22 = blockIdx.y;
            long long int var_23 = (32 * var_22);
            long long int var_24 = (var_21 + var_23);
            long long int var_25[1];
            var_25[0] = var_24;
            while (method_53(var_25)) {
                long long int var_27 = var_25[0];
                char var_28 = (var_27 >= 0);
                char var_30;
                if (var_28) {
                    var_30 = (var_27 < 64);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_32 = (var_27 * 128);
                char var_34;
                if (var_17) {
                    var_34 = (var_16 < 128);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_36 = (var_32 + var_16);
                float var_37 = var_4[var_36];
                float var_38 = var_5[var_36];
                float var_39 = var_6[var_36];
                float var_40 = var_7[var_36];
                char var_42;
                if (var_28) {
                    var_42 = (var_27 < 64);
                } else {
                    var_42 = 0;
                }
                char var_43 = (var_42 == 0);
                if (var_43) {
                    // "Argument out of bounds."
                } else {
                }
                char var_45;
                if (var_17) {
                    var_45 = (var_16 < 128);
                } else {
                    var_45 = 0;
                }
                char var_46 = (var_45 == 0);
                if (var_46) {
                    // "Argument out of bounds."
                } else {
                }
                float var_47 = var_0[var_16];
                float var_48 = var_1[var_16];
                float var_49 = var_2[var_16];
                float var_50 = var_3[var_16];
                float var_51 = (var_47 * var_38);
                float var_52 = (var_51 + var_49);
                float var_53 = (var_47 * var_37);
                float var_54 = (var_53 + var_48);
                float var_55 = (1 - var_40);
                float var_56 = (var_40 * var_55);
                float var_57 = (var_56 * var_52);
                float var_58 = (var_56 * var_54);
                float var_59 = var_8[var_36];
                float var_60 = var_9[var_36];
                float var_61 = (var_39 * var_57);
                float var_62 = (var_59 + var_61);
                float var_63 = (var_39 * var_58);
                float var_64 = (var_60 + var_63);
                var_8[var_36] = var_62;
                var_9[var_36] = var_64;
                long long int var_65 = (var_27 + 32);
                var_25[0] = var_65;
            }
            long long int var_66 = var_25[0];
            long long int var_67 = (var_16 + 128);
            var_14[0] = var_67;
        }
        long long int var_68 = var_14[0];
    }
    __device__ char method_22(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 35692544);
    }
    __device__ char method_23(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_53(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_98(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8192);
    }
    __device__ char method_92(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ float method_93(float var_0, float var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_140(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
    }
    __device__ char method_59(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 64);
    }
    __device__ char method_60(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 >= 2);
    }
    __device__ char method_61(long long int var_0, long long int * var_1, float * var_2, float * var_3) {
        long long int var_4 = var_1[0];
        float var_5 = var_2[0];
        float var_6 = var_3[0];
        return (var_4 < var_0);
    }
    __device__ char method_84(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 64);
    }
    __device__ char method_85(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_86(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_104(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8192);
    }
    __device__ char method_118(long long int * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = var_0[0];
        float var_6 = var_1[0];
        float var_7 = var_2[0];
        float var_8 = var_3[0];
        float var_9 = var_4[0];
        return (var_5 < 64);
    }
    __device__ char method_119(long long int * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = var_0[0];
        float var_6 = var_1[0];
        float var_7 = var_2[0];
        float var_8 = var_3[0];
        float var_9 = var_4[0];
        return (var_5 >= 2);
    }
    __device__ char method_120(long long int var_0, long long int * var_1, float * var_2, float * var_3, float * var_4, float * var_5) {
        long long int var_6 = var_1[0];
        float var_7 = var_2[0];
        float var_8 = var_3[0];
        float var_9 = var_4[0];
        float var_10 = var_5[0];
        return (var_6 < var_0);
    }
}
"""

type Env0 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack1 =
    struct
    val mem_0: ResizeArray<Env0>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env2 =
    struct
    val mem_0: Env11
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack3 =
    struct
    val mem_0: ResizeArray<Env2>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env4 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env11
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack5 =
    struct
    val mem_0: ResizeArray<Env4>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env6 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env9
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack7 =
    struct
    val mem_0: ResizeArray<Env6>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap8 =
    {
    mem_0: ManagedCuda.CudaEvent
    mem_1: (bool ref)
    mem_2: ManagedCuda.CudaStream
    }
and Env9 =
    struct
    val mem_0: EnvHeap8
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env10 =
    struct
    val mem_0: Env4
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env11 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack12 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env11
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack13 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env11
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack14 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env11
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap15 =
    {
    mem_0: EnvStack14
    mem_1: (int64 ref)
    mem_2: Env11
    mem_3: EnvStack14
    mem_4: (int64 ref)
    mem_5: Env11
    mem_6: EnvStack14
    mem_7: (int64 ref)
    mem_8: Env11
    mem_9: EnvStack14
    mem_10: EnvStack14
    mem_11: EnvStack13
    mem_12: (int64 ref)
    mem_13: Env11
    mem_14: EnvStack13
    mem_15: (int64 ref)
    mem_16: Env11
    }
and EnvHeap16 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: EnvStack1
    mem_3: EnvStack3
    }
and EnvStack17 =
    struct
    val mem_0: EnvStack18
    val mem_1: (int64 ref)
    val mem_2: Env11
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack18 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env11
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env19 =
    struct
    val mem_0: EnvHeap8
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack20 =
    struct
    val mem_0: EnvStack18
    val mem_1: (int64 ref)
    val mem_2: Env11
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack21 =
    struct
    val mem_0: Env22
    val mem_1: (unit -> unit)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env22 =
    struct
    val mem_0: Env24
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env23 =
    struct
    val mem_0: Env22
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env24 =
    struct
    val mem_0: Env25
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env25 =
    struct
    val mem_0: Env4
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3)): unit =
    let (var_4: ResizeArray<Env2>) = var_3.mem_0
    let (var_6: (Env2 -> bool)) = method_2
    let (var_7: int32) = var_4.RemoveAll <| System.Predicate(var_6)
    let (var_9: (Env2 -> (Env2 -> int32))) = method_3
    let (var_10: System.Comparison<Env2>) = System.Comparison<Env2>(var_9)
    var_4.Sort(var_10)
    let (var_11: ResizeArray<Env0>) = var_0.mem_0
    var_11.Clear()
    let (var_12: int32) = var_4.get_Count()
    let (var_13: uint64) = method_5((var_1: (uint64 ref)))
    let (var_14: int32) = 0
    let (var_15: uint64) = method_6((var_0: EnvStack1), (var_3: EnvStack3), (var_12: int32), (var_13: uint64), (var_14: int32))
    let (var_16: uint64) = method_5((var_1: (uint64 ref)))
    let (var_17: uint64) = (var_16 + var_2)
    let (var_18: uint64) = (var_17 - var_15)
    let (var_19: uint64) = (var_15 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: uint64) = (var_21 - var_15)
    let (var_23: bool) = (var_18 > var_22)
    if var_23 then
        let (var_24: uint64) = (var_18 - var_22)
        var_11.Add((Env0(var_21, var_24)))
    else
        ()
and method_7((var_0: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule)): Env6 =
    let (var_11: (int64 ref)) = (ref 0L)
    method_8((var_11: (int64 ref)), (var_0: EnvHeap8), (var_9: EnvStack7))
    (Env6(var_11, (Env9(var_0))))
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64), (var_13: (uint8 [])), (var_14: int64), (var_15: int64)): Env10 =
    let (var_16: int64) = (var_12 * var_15)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: uint64) = (uint64 var_14)
    let (var_21: uint64) = (var_20 + var_19)
    let (var_22: Env4) = method_11((var_16: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: Env11) = var_22.mem_1
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
    (Env10((Env4(var_23, var_24))))
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_17((var_0: uint64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9)): EnvStack12 =
    let (var_16: Env4) = method_18((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env11) = var_16.mem_1
    method_19((var_0: uint64), (var_17: (int64 ref)), (var_18: Env11), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_11: (int64 ref)), (var_12: Env9))
    EnvStack12((var_17: (int64 ref)), (var_18: Env11))
and method_25((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): EnvStack13 =
    let (var_12: Env4) = method_26((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env11) = var_12.mem_1
    method_27((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (int64 ref)), (var_14: Env11), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    EnvStack13((var_13: (int64 ref)), (var_14: Env11))
and method_28((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): EnvStack13 =
    let (var_14: Env4) = method_26((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env11) = var_14.mem_1
    let (var_17: EnvHeap8) = var_13.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_24((var_17: EnvHeap8))
    method_29((var_15: (int64 ref)), (var_16: Env11), (var_8: ManagedCuda.CudaContext), (var_18: ManagedCuda.BasicTypes.CUstream))
    EnvStack13((var_15: (int64 ref)), (var_16: Env11))
and method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): Env4 =
    let (var_12: int64) = 512L
    let (var_13: EnvHeap16) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64))
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: (int64 ref)), (var_13: Env11)): unit =
    let (var_14: float32) = 1.000000f
    method_32((var_14: float32), (var_12: (int64 ref)), (var_13: Env11), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env9))
and method_35((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): EnvStack14 =
    let (var_14: Env4) = method_30((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env11) = var_14.mem_1
    let (var_17: EnvHeap8) = var_13.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_24((var_17: EnvHeap8))
    method_36((var_15: (int64 ref)), (var_16: Env11), (var_8: ManagedCuda.CudaContext), (var_18: ManagedCuda.BasicTypes.CUstream))
    EnvStack14((var_15: (int64 ref)), (var_16: Env11))
and method_37((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: (int64 ref)), (var_13: Env11)): unit =
    let (var_14: float32) = 0.500000f
    method_32((var_14: float32), (var_12: (int64 ref)), (var_13: Env11), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env9))
and method_38((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): EnvStack14 =
    let (var_12: Env4) = method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env11) = var_12.mem_1
    let (var_15: EnvHeap8) = var_11.mem_0
    let (var_16: ManagedCuda.BasicTypes.CUstream) = method_24((var_15: EnvHeap8))
    method_36((var_13: (int64 ref)), (var_14: Env11), (var_6: ManagedCuda.CudaContext), (var_16: ManagedCuda.BasicTypes.CUstream))
    EnvStack14((var_13: (int64 ref)), (var_14: Env11))
and method_39((var_0: EnvStack14), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9)): EnvStack14 =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env11) = var_0.mem_1
    let (var_15: Env4) = method_30((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env11) = var_15.mem_1
    let (var_18: EnvHeap8) = var_12.mem_0
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_24((var_18: EnvHeap8))
    method_36((var_16: (int64 ref)), (var_17: Env11), (var_7: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack14((var_16: (int64 ref)), (var_17: Env11))
and method_40((var_0: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9)): Env6 =
    let (var_13: (int64 ref)) = (ref 0L)
    method_8((var_13: (int64 ref)), (var_0: EnvHeap8), (var_9: EnvStack7))
    (Env6(var_13, (Env9(var_0))))
and method_41((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env9), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: EnvHeap15), (var_11: EnvHeap15), (var_12: EnvStack14), (var_13: EnvStack14), (var_14: EnvStack13), (var_15: (int64 ref)), (var_16: Env11), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: (uint64 ref)), (var_20: uint64), (var_21: EnvStack1), (var_22: EnvStack3), (var_23: ManagedCuda.CudaContext), (var_24: EnvStack5), (var_25: EnvStack7), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: (int64 ref)), (var_28: Env9), (var_29: int64)): unit =
    let (var_30: bool) = (var_29 < 10L)
    if var_30 then
        let (var_31: string) = System.String.Format("iteration {0}",var_29)
        let (var_32: string) = System.String.Format("Starting timing for: {0}",var_31)
        let (var_33: string) = System.String.Format("{0}",var_32)
        System.Console.WriteLine(var_33)
        let (var_34: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
        let (var_35: int64) = 0L
        let (var_36: float) = 0.000000
        let (var_37: int64) = 0L
        let (var_38: float) = method_42((var_0: (int64 ref)), (var_1: Env11), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: (uint64 ref)), (var_20: uint64), (var_21: EnvStack1), (var_22: EnvStack3), (var_23: ManagedCuda.CudaContext), (var_24: EnvStack5), (var_25: EnvStack7), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: (int64 ref)), (var_28: Env9), (var_35: int64), (var_36: float), (var_2: (int64 ref)), (var_3: Env9), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: EnvHeap15), (var_11: EnvHeap15), (var_12: EnvStack14), (var_13: EnvStack14), (var_14: EnvStack13), (var_15: (int64 ref)), (var_16: Env11), (var_37: int64))
        let (var_39: System.TimeSpan) = var_34.Elapsed
        let (var_40: string) = System.String.Format("The time was {0} for: {1}",var_39,var_31)
        let (var_41: string) = System.String.Format("{0}",var_40)
        System.Console.WriteLine(var_41)
        let (var_42: string) = System.String.Format("Training: {0}",var_38)
        let (var_43: string) = System.String.Format("{0}",var_42)
        System.Console.WriteLine(var_43)
        if (System.Double.IsNaN var_38) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_44: int64) = (var_29 + 1L)
            method_41((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env9), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: EnvHeap15), (var_11: EnvHeap15), (var_12: EnvStack14), (var_13: EnvStack14), (var_14: EnvStack13), (var_15: (int64 ref)), (var_16: Env11), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: (uint64 ref)), (var_20: uint64), (var_21: EnvStack1), (var_22: EnvStack3), (var_23: ManagedCuda.CudaContext), (var_24: EnvStack5), (var_25: EnvStack7), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: (int64 ref)), (var_28: Env9), (var_44: int64))
    else
        ()
and method_148((var_0: EnvStack7)): unit =
    let (var_1: ResizeArray<Env6>) = var_0.mem_0
    let (var_3: (Env6 -> unit)) = method_149
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_130((var_0: EnvStack5)): unit =
    let (var_1: ResizeArray<Env4>) = var_0.mem_0
    let (var_3: (Env4 -> unit)) = method_131
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_2 ((var_0: Env2)): bool =
    let (var_1: Env11) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: Env11) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: EnvStack1), (var_1: EnvStack3), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env2>) = var_1.mem_0
        let (var_7: Env2) = var_6.[var_4]
        let (var_8: Env11) = var_7.mem_0
        let (var_9: uint64) = var_7.mem_1
        let (var_10: (uint64 ref)) = var_8.mem_0
        let (var_11: uint64) = method_5((var_10: (uint64 ref)))
        let (var_12: bool) = (var_11 >= var_3)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_14: uint64) = method_5((var_10: (uint64 ref)))
        let (var_15: uint64) = (var_14 - var_3)
        let (var_16: uint64) = (var_3 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_3)
        let (var_20: bool) = (var_15 > var_19)
        if var_20 then
            let (var_21: ResizeArray<Env0>) = var_0.mem_0
            let (var_22: uint64) = (var_15 - var_19)
            var_21.Add((Env0(var_18, var_22)))
        else
            ()
        let (var_23: uint64) = (var_14 + var_9)
        let (var_24: int32) = (var_4 + 1)
        method_6((var_0: EnvStack1), (var_1: EnvStack3), (var_2: int32), (var_23: uint64), (var_24: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: EnvHeap8), (var_2: EnvStack7)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env6>) = var_2.mem_0
    var_5.Add((Env6(var_0, (Env9(var_1)))))
and method_11((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9)): Env4 =
    let (var_13: EnvHeap16) = ({mem_0 = (var_3: (uint64 ref)); mem_1 = (var_4: uint64); mem_2 = (var_5: EnvStack1); mem_3 = (var_6: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9), (var_0: int64))
and method_18((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): Env4 =
    let (var_12: int64) = 571080704L
    let (var_13: EnvHeap16) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64))
and method_19((var_0: uint64), (var_1: (int64 ref)), (var_2: Env11), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env9)): unit =
    let (var_15: (uint64 ref)) = var_2.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_20((var_10: ManagedCuda.CudaContext), (var_0: uint64), (var_16: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env9))
and method_26((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): Env4 =
    let (var_12: int64) = 65536L
    let (var_13: EnvHeap16) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64))
and method_27((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env11), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): unit =
    let (var_14: (uint64 ref)) = var_2.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
    let (var_17: EnvHeap8) = var_13.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_24((var_17: EnvHeap8))
    var_0.SetStream(var_18)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    var_0.GenerateNormal32(var_20, var_16, 0.000000f, 0.088388f)
and method_24((var_0: EnvHeap8)): ManagedCuda.BasicTypes.CUstream =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_4: ManagedCuda.CudaStream) = var_0.mem_2
    var_4.Stream
and method_29((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_12((var_0: EnvHeap16), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: EnvStack1), (var_6: EnvStack3), (var_7: ManagedCuda.CudaContext), (var_8: EnvStack5), (var_9: EnvStack7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env9), (var_13: int64)): Env4 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: EnvStack1) = var_0.mem_2
    let (var_17: EnvStack3) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env11) = method_13((var_16: EnvStack1), (var_14: (uint64 ref)), (var_15: uint64), (var_17: EnvStack3), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_16((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: EnvStack5))
    (Env4(var_24, (Env11(var_23))))
and method_32((var_0: float32), (var_1: (int64 ref)), (var_2: Env11), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env9)): unit =
    let (var_15: (uint64 ref)) = var_2.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    method_33((var_10: ManagedCuda.CudaContext), (var_0: float32), (var_16: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env9))
and method_36((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_42((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env9), (var_18: (int64 ref)), (var_19: Env9), (var_20: (int64 ref)), (var_21: Env9), (var_22: (int64 ref)), (var_23: Env9), (var_24: EnvHeap15), (var_25: EnvHeap15), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11), (var_31: int64)): float =
    let (var_32: bool) = (var_31 < 272L)
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
        let (var_36: int64) = (8192L + var_35)
        let (var_37: EnvHeap16) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: EnvStack1); mem_3 = (var_7: EnvStack3)} : EnvHeap16)
        let (var_38: (uint64 ref)) = var_37.mem_0
        let (var_39: uint64) = var_37.mem_1
        let (var_40: EnvStack1) = var_37.mem_2
        let (var_41: EnvStack3) = var_37.mem_3
        method_1((var_40: EnvStack1), (var_38: (uint64 ref)), (var_39: uint64), (var_41: EnvStack3))
        let (var_45: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_46: EnvStack5) = EnvStack5((var_45: ResizeArray<Env4>))
        // Executing the net...
        let (var_86: EnvStack17) = method_43((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_46: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_22: (int64 ref)), (var_23: Env9), (var_0: (int64 ref)), (var_1: Env11), (var_35: int64), (var_24: EnvHeap15))
        let (var_87: EnvStack18) = var_86.mem_0
        let (var_88: (int64 ref)) = var_86.mem_1
        let (var_89: Env11) = var_86.mem_2
        let (var_90: (unit -> unit)) = var_86.mem_3
        let (var_91: EnvHeap8) = var_21.mem_0
        let (var_92: Env19) = method_67((var_91: EnvHeap8))
        let (var_93: EnvHeap8) = var_92.mem_0
        let (var_94: ManagedCuda.CudaEvent) = var_93.mem_0
        let (var_95: EnvHeap8) = var_23.mem_0
        let (var_96: ManagedCuda.BasicTypes.CUstream) = method_24((var_95: EnvHeap8))
        var_94.Record(var_96)
        let (var_97: ManagedCuda.CudaStream) = var_93.mem_2
        var_97.WaitEvent var_94.Event
        let (var_98: EnvStack17) = method_68((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_46: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env9), (var_87: EnvStack18), (var_88: (int64 ref)), (var_89: Env11), (var_22: (int64 ref)), (var_23: Env9), (var_25: EnvHeap15))
        let (var_99: EnvStack18) = var_98.mem_0
        let (var_100: (int64 ref)) = var_98.mem_1
        let (var_101: Env11) = var_98.mem_2
        let (var_102: (unit -> unit)) = var_98.mem_3
        let (var_103: EnvHeap8) = var_19.mem_0
        let (var_104: Env19) = method_67((var_103: EnvHeap8))
        let (var_105: EnvHeap8) = var_104.mem_0
        let (var_106: ManagedCuda.CudaEvent) = var_105.mem_0
        let (var_107: ManagedCuda.BasicTypes.CUstream) = method_24((var_91: EnvHeap8))
        var_106.Record(var_107)
        let (var_108: ManagedCuda.CudaStream) = var_105.mem_2
        var_108.WaitEvent var_106.Event
        let (var_109: EnvStack20) = method_75((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_46: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env9), (var_99: EnvStack18), (var_100: (int64 ref)), (var_101: Env11), (var_20: (int64 ref)), (var_21: Env9), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11))
        let (var_110: EnvStack18) = var_109.mem_0
        let (var_111: (int64 ref)) = var_109.mem_1
        let (var_112: Env11) = var_109.mem_2
        let (var_113: (unit -> unit)) = var_109.mem_3
        let (var_114: EnvHeap8) = var_17.mem_0
        let (var_115: Env19) = method_67((var_114: EnvHeap8))
        let (var_116: EnvHeap8) = var_115.mem_0
        let (var_117: ManagedCuda.CudaEvent) = var_116.mem_0
        let (var_118: ManagedCuda.BasicTypes.CUstream) = method_24((var_103: EnvHeap8))
        var_117.Record(var_118)
        let (var_119: ManagedCuda.CudaStream) = var_116.mem_2
        var_119.WaitEvent var_117.Event
        let (var_120: EnvStack21) = method_87((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_46: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9), (var_110: EnvStack18), (var_111: (int64 ref)), (var_112: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_36: int64), (var_18: (int64 ref)), (var_19: Env9))
        let (var_121: Env22) = var_120.mem_0
        let (var_122: (unit -> unit)) = var_120.mem_1
        let (var_123: (unit -> unit)) = method_105((var_90: (unit -> unit)), (var_102: (unit -> unit)), (var_113: (unit -> unit)), (var_122: (unit -> unit)))
        let (var_124: (unit -> float32)) = method_106((var_121: Env22))
        let (var_162: int64) = 1L
        method_128((var_0: (int64 ref)), (var_1: Env11), (var_35: int64), (var_36: int64), (var_16: (int64 ref)), (var_17: Env9), (var_18: (int64 ref)), (var_19: Env9), (var_20: (int64 ref)), (var_21: Env9), (var_22: (int64 ref)), (var_23: Env9), (var_24: EnvHeap15), (var_25: EnvHeap15), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_46: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9), (var_14: int64), (var_15: float), (var_31: int64), (var_9: EnvStack5), (var_124: (unit -> float32)), (var_123: (unit -> unit)), (var_87: EnvStack18), (var_88: (int64 ref)), (var_89: Env11), (var_99: EnvStack18), (var_100: (int64 ref)), (var_101: Env11), (var_162: int64))
    else
        let (var_164: float) = (float var_14)
        (var_15 / var_164)
and method_149 ((var_0: Env6)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env9) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: EnvHeap8) = var_2.mem_0
        let (var_8: ManagedCuda.CudaStream) = var_7.mem_2
        var_8.Dispose()
        let (var_9: ManagedCuda.CudaEvent) = var_7.mem_0
        var_9.Dispose()
        let (var_10: (bool ref)) = var_7.mem_1
        var_10 := false
    else
        ()
and method_131 ((var_0: Env4)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env11) = var_0.mem_1
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
and method_4 ((var_1: (uint64 ref))) ((var_0: Env2)): int32 =
    let (var_2: Env11) = var_0.mem_0
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
and method_20((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_21((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(139424u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_13((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3), (var_4: uint64)): Env11 =
    let (var_5: ResizeArray<Env0>) = var_0.mem_0
    let (var_6: int32) = var_5.get_Count()
    let (var_7: bool) = (var_6 > 0)
    let (var_8: bool) = (var_7 = false)
    if var_8 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_9: Env0) = var_5.[0]
    let (var_10: uint64) = var_9.mem_0
    let (var_11: uint64) = var_9.mem_1
    let (var_12: bool) = (var_4 <= var_11)
    let (var_39: Env2) =
        if var_12 then
            let (var_13: uint64) = (var_10 + var_4)
            let (var_14: uint64) = (var_11 - var_4)
            var_5.[0] <- (Env0(var_13, var_14))
            let (var_15: (uint64 ref)) = (ref var_10)
            (Env2((Env11(var_15)), var_4))
        else
            let (var_17: (Env0 -> (Env0 -> int32))) = method_14
            let (var_18: System.Comparison<Env0>) = System.Comparison<Env0>(var_17)
            var_5.Sort(var_18)
            let (var_19: Env0) = var_5.[0]
            let (var_20: uint64) = var_19.mem_0
            let (var_21: uint64) = var_19.mem_1
            let (var_22: bool) = (var_4 <= var_21)
            if var_22 then
                let (var_23: uint64) = (var_20 + var_4)
                let (var_24: uint64) = (var_21 - var_4)
                var_5.[0] <- (Env0(var_23, var_24))
                let (var_25: (uint64 ref)) = (ref var_20)
                (Env2((Env11(var_25)), var_4))
            else
                method_1((var_0: EnvStack1), (var_1: (uint64 ref)), (var_2: uint64), (var_3: EnvStack3))
                let (var_27: (Env0 -> (Env0 -> int32))) = method_14
                let (var_28: System.Comparison<Env0>) = System.Comparison<Env0>(var_27)
                var_5.Sort(var_28)
                let (var_29: Env0) = var_5.[0]
                let (var_30: uint64) = var_29.mem_0
                let (var_31: uint64) = var_29.mem_1
                let (var_32: bool) = (var_4 <= var_31)
                if var_32 then
                    let (var_33: uint64) = (var_30 + var_4)
                    let (var_34: uint64) = (var_31 - var_4)
                    var_5.[0] <- (Env0(var_33, var_34))
                    let (var_35: (uint64 ref)) = (ref var_30)
                    (Env2((Env11(var_35)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_40: Env11) = var_39.mem_0
    let (var_41: uint64) = var_39.mem_1
    let (var_42: ResizeArray<Env2>) = var_3.mem_0
    var_42.Add((Env2(var_40, var_41)))
    var_40
and method_16((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack5)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env4>) = var_2.mem_0
    var_5.Add((Env4(var_0, (Env11(var_1)))))
and method_33((var_0: ManagedCuda.CudaContext), (var_1: float32), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_34((var_1: float32), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_43((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: (int64 ref)), (var_13: Env11), (var_14: int64), (var_15: EnvHeap15)): EnvStack17 =
    let (var_16: EnvStack14) = var_15.mem_0
    let (var_17: (int64 ref)) = var_15.mem_1
    let (var_18: Env11) = var_15.mem_2
    let (var_19: EnvStack14) = var_15.mem_3
    let (var_20: (int64 ref)) = var_15.mem_4
    let (var_21: Env11) = var_15.mem_5
    let (var_22: EnvStack14) = var_15.mem_6
    let (var_23: (int64 ref)) = var_15.mem_7
    let (var_24: Env11) = var_15.mem_8
    let (var_25: EnvStack14) = var_15.mem_9
    let (var_26: EnvStack14) = var_15.mem_10
    let (var_27: EnvStack13) = var_15.mem_11
    let (var_28: (int64 ref)) = var_15.mem_12
    let (var_29: Env11) = var_15.mem_13
    let (var_30: EnvStack13) = var_15.mem_14
    let (var_31: (int64 ref)) = var_15.mem_15
    let (var_32: Env11) = var_15.mem_16
    let (var_33: EnvStack18) = method_44((var_12: (int64 ref)), (var_13: Env11), (var_14: int64), (var_28: (int64 ref)), (var_29: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_34: (int64 ref)) = var_33.mem_0
    let (var_35: Env11) = var_33.mem_1
    let (var_36: EnvStack18) = method_47((var_34: (int64 ref)), (var_35: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_37: EnvStack18) = method_49((var_23: (int64 ref)), (var_24: Env11), (var_26: EnvStack14), (var_34: (int64 ref)), (var_35: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_38: (int64 ref)) = var_37.mem_0
    let (var_39: Env11) = var_37.mem_1
    let (var_40: EnvStack18) = method_47((var_38: (int64 ref)), (var_39: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_41: (unit -> unit)) = method_54((var_36: EnvStack18), (var_34: (int64 ref)), (var_35: Env11), (var_12: (int64 ref)), (var_13: Env11), (var_14: int64), (var_27: EnvStack13), (var_28: (int64 ref)), (var_29: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_22: EnvStack14), (var_25: EnvStack14), (var_40: EnvStack18), (var_38: (int64 ref)), (var_39: Env11), (var_23: (int64 ref)), (var_24: Env11), (var_26: EnvStack14))
    EnvStack17((var_40: EnvStack18), (var_38: (int64 ref)), (var_39: Env11), (var_41: (unit -> unit)))
and method_67((var_0: EnvHeap8)): Env19 =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    (Env19(var_0))
and method_68((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_15: (int64 ref)), (var_16: Env9), (var_17: EnvHeap15)): EnvStack17 =
    let (var_18: EnvStack14) = var_17.mem_0
    let (var_19: (int64 ref)) = var_17.mem_1
    let (var_20: Env11) = var_17.mem_2
    let (var_21: EnvStack14) = var_17.mem_3
    let (var_22: (int64 ref)) = var_17.mem_4
    let (var_23: Env11) = var_17.mem_5
    let (var_24: EnvStack14) = var_17.mem_6
    let (var_25: (int64 ref)) = var_17.mem_7
    let (var_26: Env11) = var_17.mem_8
    let (var_27: EnvStack14) = var_17.mem_9
    let (var_28: EnvStack14) = var_17.mem_10
    let (var_29: EnvStack13) = var_17.mem_11
    let (var_30: (int64 ref)) = var_17.mem_12
    let (var_31: Env11) = var_17.mem_13
    let (var_32: EnvStack13) = var_17.mem_14
    let (var_33: (int64 ref)) = var_17.mem_15
    let (var_34: Env11) = var_17.mem_16
    let (var_35: EnvStack18) = method_69((var_13: (int64 ref)), (var_14: Env11), (var_30: (int64 ref)), (var_31: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_36: (int64 ref)) = var_35.mem_0
    let (var_37: Env11) = var_35.mem_1
    let (var_38: EnvStack18) = method_47((var_36: (int64 ref)), (var_37: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_39: EnvStack18) = method_49((var_25: (int64 ref)), (var_26: Env11), (var_28: EnvStack14), (var_36: (int64 ref)), (var_37: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_40: (int64 ref)) = var_39.mem_0
    let (var_41: Env11) = var_39.mem_1
    let (var_42: EnvStack18) = method_47((var_40: (int64 ref)), (var_41: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_43: (unit -> unit)) = method_71((var_38: EnvStack18), (var_36: (int64 ref)), (var_37: Env11), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_29: EnvStack13), (var_30: (int64 ref)), (var_31: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_24: EnvStack14), (var_27: EnvStack14), (var_42: EnvStack18), (var_40: (int64 ref)), (var_41: Env11), (var_25: (int64 ref)), (var_26: Env11), (var_28: EnvStack14), (var_15: (int64 ref)), (var_16: Env9))
    EnvStack17((var_42: EnvStack18), (var_40: (int64 ref)), (var_41: Env11), (var_43: (unit -> unit)))
and method_75((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_15: (int64 ref)), (var_16: Env9), (var_17: EnvStack14), (var_18: EnvStack14), (var_19: EnvStack13), (var_20: (int64 ref)), (var_21: Env11)): EnvStack20 =
    let (var_22: EnvStack18) = method_69((var_13: (int64 ref)), (var_14: Env11), (var_20: (int64 ref)), (var_21: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_23: (int64 ref)) = var_22.mem_0
    let (var_24: Env11) = var_22.mem_1
    let (var_25: EnvStack18) = method_47((var_23: (int64 ref)), (var_24: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    method_76((var_18: EnvStack14), (var_23: (int64 ref)), (var_24: Env11), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env9))
    let (var_26: (unit -> unit)) = method_79((var_25: EnvStack18), (var_23: (int64 ref)), (var_24: Env11), (var_17: EnvStack14), (var_18: EnvStack14), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_19: EnvStack13), (var_20: (int64 ref)), (var_21: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_15: (int64 ref)), (var_16: Env9))
    EnvStack20((var_25: EnvStack18), (var_23: (int64 ref)), (var_24: Env11), (var_26: (unit -> unit)))
and method_87((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_18: (int64 ref)), (var_19: Env9)): EnvStack21 =
    let (var_20: EnvStack18) = method_88((var_13: (int64 ref)), (var_14: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_21: (int64 ref)) = var_20.mem_0
    let (var_22: Env11) = var_20.mem_1
    let (var_23: Env23) = method_94((var_21: (int64 ref)), (var_22: Env11), (var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_10: (int64 ref)), (var_11: Env9))
    let (var_24: Env22) = var_23.mem_0
    let (var_25: (unit -> unit)) = method_99((var_12: EnvStack18), (var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_21: (int64 ref)), (var_22: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_18: (int64 ref)), (var_19: Env9))
    EnvStack21((var_24: Env22), (var_25: (unit -> unit)))
and method_105 ((var_0: (unit -> unit)), (var_1: (unit -> unit)), (var_2: (unit -> unit)), (var_3: (unit -> unit))) (): unit =
    var_3()
    var_2()
    var_1()
    var_0()
and method_106 ((var_0: Env22)) (): float32 =
    let (var_1: Env24) = var_0.mem_0
    let (var_2: Env25) = var_1.mem_0
    let (var_3: int64) = var_1.mem_1
    let (var_4: int64) = 1L
    let (var_5: Env4) = var_2.mem_0
    let (var_6: (float32 [])) = method_107((var_4: int64), (var_2: Env25), (var_3: int64))
    var_6.[int32 0L]
and method_128((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_31: int64), (var_32: float), (var_33: int64), (var_34: EnvStack5), (var_35: (unit -> float32)), (var_36: (unit -> unit)), (var_37: EnvStack18), (var_38: (int64 ref)), (var_39: Env11), (var_40: EnvStack18), (var_41: (int64 ref)), (var_42: Env11), (var_43: int64)): float =
    let (var_44: bool) = (var_43 < 64L)
    if var_44 then
        let (var_45: bool) = (var_43 >= 0L)
        let (var_46: bool) = (var_45 = false)
        if var_46 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_47: int64) = (var_43 * 8192L)
        let (var_48: int64) = (var_2 + var_47)
        if var_46 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_49: int64) = (var_3 + var_47)
        let (var_50: EnvStack17) = method_108((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_37: EnvStack18), (var_38: (int64 ref)), (var_39: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_48: int64), (var_12: EnvHeap15))
        let (var_51: EnvStack18) = var_50.mem_0
        let (var_52: (int64 ref)) = var_50.mem_1
        let (var_53: Env11) = var_50.mem_2
        let (var_54: (unit -> unit)) = var_50.mem_3
        let (var_55: EnvHeap8) = var_9.mem_0
        let (var_56: Env19) = method_67((var_55: EnvHeap8))
        let (var_57: EnvHeap8) = var_56.mem_0
        let (var_58: ManagedCuda.CudaEvent) = var_57.mem_0
        let (var_59: EnvHeap8) = var_11.mem_0
        let (var_60: ManagedCuda.BasicTypes.CUstream) = method_24((var_59: EnvHeap8))
        var_58.Record(var_60)
        let (var_61: ManagedCuda.CudaStream) = var_57.mem_2
        var_61.WaitEvent var_58.Event
        let (var_62: EnvStack17) = method_124((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env9), (var_40: EnvStack18), (var_41: (int64 ref)), (var_42: Env11), (var_51: EnvStack18), (var_52: (int64 ref)), (var_53: Env11), (var_10: (int64 ref)), (var_11: Env9), (var_13: EnvHeap15))
        let (var_63: EnvStack18) = var_62.mem_0
        let (var_64: (int64 ref)) = var_62.mem_1
        let (var_65: Env11) = var_62.mem_2
        let (var_66: (unit -> unit)) = var_62.mem_3
        let (var_67: EnvHeap8) = var_7.mem_0
        let (var_68: Env19) = method_67((var_67: EnvHeap8))
        let (var_69: EnvHeap8) = var_68.mem_0
        let (var_70: ManagedCuda.CudaEvent) = var_69.mem_0
        let (var_71: ManagedCuda.BasicTypes.CUstream) = method_24((var_55: EnvHeap8))
        var_70.Record(var_71)
        let (var_72: ManagedCuda.CudaStream) = var_69.mem_2
        var_72.WaitEvent var_70.Event
        let (var_73: EnvStack20) = method_75((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env9), (var_63: EnvStack18), (var_64: (int64 ref)), (var_65: Env11), (var_8: (int64 ref)), (var_9: Env9), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11))
        let (var_74: EnvStack18) = var_73.mem_0
        let (var_75: (int64 ref)) = var_73.mem_1
        let (var_76: Env11) = var_73.mem_2
        let (var_77: (unit -> unit)) = var_73.mem_3
        let (var_78: EnvHeap8) = var_5.mem_0
        let (var_79: Env19) = method_67((var_78: EnvHeap8))
        let (var_80: EnvHeap8) = var_79.mem_0
        let (var_81: ManagedCuda.CudaEvent) = var_80.mem_0
        let (var_82: ManagedCuda.BasicTypes.CUstream) = method_24((var_67: EnvHeap8))
        var_81.Record(var_82)
        let (var_83: ManagedCuda.CudaStream) = var_80.mem_2
        var_83.WaitEvent var_81.Event
        let (var_84: EnvStack21) = method_87((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9), (var_74: EnvStack18), (var_75: (int64 ref)), (var_76: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_49: int64), (var_6: (int64 ref)), (var_7: Env9))
        let (var_85: Env22) = var_84.mem_0
        let (var_86: (unit -> unit)) = var_84.mem_1
        let (var_87: (unit -> unit)) = method_126((var_36: (unit -> unit)), (var_54: (unit -> unit)), (var_66: (unit -> unit)), (var_77: (unit -> unit)), (var_86: (unit -> unit)))
        let (var_88: (unit -> float32)) = method_127((var_85: Env22), (var_35: (unit -> float32)))
        let (var_89: int64) = (var_43 + 1L)
        method_128((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_31: int64), (var_32: float), (var_33: int64), (var_34: EnvStack5), (var_88: (unit -> float32)), (var_87: (unit -> unit)), (var_51: EnvStack18), (var_52: (int64 ref)), (var_53: Env11), (var_63: EnvStack18), (var_64: (int64 ref)), (var_65: Env11), (var_89: int64))
    else
        let (var_91: float32) = var_35()
        let (var_92: float) = (float var_91)
        let (var_93: float) = (var_32 + var_92)
        let (var_94: int64) = (var_31 + 1L)
        let (var_103: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_104: EnvStack5) = EnvStack5((var_103: ResizeArray<Env4>))
        method_129((var_38: (int64 ref)), (var_39: Env11), (var_104: EnvStack5))
        method_129((var_41: (int64 ref)), (var_42: Env11), (var_104: EnvStack5))
        if (System.Double.IsNaN var_93) then
            method_130((var_26: EnvStack5))
            // Done with the net...
            method_130((var_104: EnvStack5))
            let (var_105: float) = (float var_94)
            (var_93 / var_105)
        else
            var_36()
            method_132((var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9))
            method_130((var_26: EnvStack5))
            // Executing the next loop...
            let (var_107: int64) = (var_33 + 1L)
            method_141((var_0: (int64 ref)), (var_1: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_34: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_94: int64), (var_93: float), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_104: EnvStack5), (var_38: (int64 ref)), (var_39: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_107: int64))
and method_14 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_15((var_2: uint64))
and method_44((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: (int64 ref)), (var_4: Env11), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9)): EnvStack18 =
    let (var_17: Env4) = method_45((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env11) = var_17.mem_1
    method_46((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: (int64 ref)), (var_4: Env11), (var_18: (int64 ref)), (var_19: Env11), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_15: (int64 ref)), (var_16: Env9))
    EnvStack18((var_18: (int64 ref)), (var_19: Env11))
and method_47((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): EnvStack18 =
    let (var_14: Env4) = method_45((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env11) = var_14.mem_1
    let (var_17: EnvHeap8) = var_13.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_24((var_17: EnvHeap8))
    method_48((var_15: (int64 ref)), (var_16: Env11), (var_8: ManagedCuda.CudaContext), (var_18: ManagedCuda.BasicTypes.CUstream))
    EnvStack18((var_15: (int64 ref)), (var_16: Env11))
and method_49((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack14), (var_3: (int64 ref)), (var_4: Env11), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9)): EnvStack18 =
    let (var_17: (int64 ref)) = var_2.mem_0
    let (var_18: Env11) = var_2.mem_1
    let (var_25: Env4) = method_45((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9))
    let (var_26: (int64 ref)) = var_25.mem_0
    let (var_27: Env11) = var_25.mem_1
    method_50((var_0: (int64 ref)), (var_1: Env11), (var_17: (int64 ref)), (var_18: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_15: (int64 ref)), (var_16: Env9))
    EnvStack18((var_26: (int64 ref)), (var_27: Env11))
and method_54 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack14), (var_22: EnvStack14), (var_23: EnvStack18), (var_24: (int64 ref)), (var_25: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_28: EnvStack14)) (): unit =
    method_55((var_21: EnvStack14), (var_22: EnvStack14), (var_0: EnvStack18), (var_23: EnvStack18), (var_24: (int64 ref)), (var_25: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_28: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_65((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
and method_69((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env9)): EnvStack18 =
    let (var_16: Env4) = method_45((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env9))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env11) = var_16.mem_1
    method_70((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_17: (int64 ref)), (var_18: Env11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_14: (int64 ref)), (var_15: Env9))
    EnvStack18((var_17: (int64 ref)), (var_18: Env11))
and method_71 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack14), (var_22: EnvStack14), (var_23: EnvStack18), (var_24: (int64 ref)), (var_25: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_28: EnvStack14), (var_29: (int64 ref)), (var_30: Env9)) (): unit =
    method_55((var_21: EnvStack14), (var_22: EnvStack14), (var_0: EnvStack18), (var_23: EnvStack18), (var_24: (int64 ref)), (var_25: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_28: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_72((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    let (var_31: EnvHeap8) = var_30.mem_0
    let (var_32: Env19) = method_67((var_31: EnvHeap8))
    let (var_33: EnvHeap8) = var_32.mem_0
    let (var_34: ManagedCuda.CudaEvent) = var_33.mem_0
    let (var_35: EnvHeap8) = var_20.mem_0
    let (var_36: ManagedCuda.BasicTypes.CUstream) = method_24((var_35: EnvHeap8))
    var_34.Record(var_36)
    let (var_37: ManagedCuda.CudaStream) = var_33.mem_2
    var_37.WaitEvent var_34.Event
and method_76((var_0: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env9)): unit =
    let (var_15: (int64 ref)) = var_0.mem_0
    let (var_16: Env11) = var_0.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: uint64) = method_5((var_19: (uint64 ref)))
    method_77((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_21: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env9))
and method_79 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack14), (var_4: EnvStack14), (var_5: EnvStack18), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack13), (var_9: (int64 ref)), (var_10: Env11), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9), (var_23: (int64 ref)), (var_24: Env9)) (): unit =
    method_80((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack14), (var_4: EnvStack14), (var_5: EnvStack18), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack13), (var_9: (int64 ref)), (var_10: Env11), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9))
    let (var_25: EnvHeap8) = var_24.mem_0
    let (var_26: Env19) = method_67((var_25: EnvHeap8))
    let (var_27: EnvHeap8) = var_26.mem_0
    let (var_28: ManagedCuda.CudaEvent) = var_27.mem_0
    let (var_29: EnvHeap8) = var_22.mem_0
    let (var_30: ManagedCuda.BasicTypes.CUstream) = method_24((var_29: EnvHeap8))
    var_28.Record(var_30)
    let (var_31: ManagedCuda.CudaStream) = var_27.mem_2
    var_31.WaitEvent var_28.Event
and method_88((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): EnvStack18 =
    let (var_17: Env4) = method_45((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env11) = var_17.mem_1
    method_89((var_0: (int64 ref)), (var_1: Env11), (var_18: (int64 ref)), (var_19: Env11), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_12: (int64 ref)), (var_13: Env9))
    EnvStack18((var_18: (int64 ref)), (var_19: Env11))
and method_94((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: int64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_15: (int64 ref)), (var_16: Env9)): Env23 =
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_3.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: int64) = (var_4 * 4L)
    let (var_22: uint64) = (uint64 var_21)
    let (var_23: uint64) = (var_20 + var_22)
    let (var_28: Env4) = method_95((var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9))
    let (var_29: (int64 ref)) = var_28.mem_0
    let (var_30: Env11) = var_28.mem_1
    let (var_31: (uint64 ref)) = var_30.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    method_96((var_12: ManagedCuda.CudaContext), (var_18: uint64), (var_23: uint64), (var_32: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env9))
    (Env23((Env22((Env24((Env25((Env4(var_29, var_30)))), 0L))))))
and method_99 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: int64), (var_4: (int64 ref)), (var_5: Env11), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9), (var_18: (int64 ref)), (var_19: Env9)) (): unit =
    method_100((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: int64), (var_4: (int64 ref)), (var_5: Env11), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9))
    let (var_20: EnvHeap8) = var_19.mem_0
    let (var_21: Env19) = method_67((var_20: EnvHeap8))
    let (var_22: EnvHeap8) = var_21.mem_0
    let (var_23: ManagedCuda.CudaEvent) = var_22.mem_0
    let (var_24: EnvHeap8) = var_17.mem_0
    let (var_25: ManagedCuda.BasicTypes.CUstream) = method_24((var_24: EnvHeap8))
    var_23.Record(var_25)
    let (var_26: ManagedCuda.CudaStream) = var_22.mem_2
    var_26.WaitEvent var_23.Event
and method_107((var_0: int64), (var_1: Env25), (var_2: int64)): (float32 []) =
    let (var_3: Env4) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env11) = var_3.mem_1
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
and method_108((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_18: EnvHeap15)): EnvStack17 =
    let (var_19: EnvStack14) = var_18.mem_0
    let (var_20: (int64 ref)) = var_18.mem_1
    let (var_21: Env11) = var_18.mem_2
    let (var_22: EnvStack14) = var_18.mem_3
    let (var_23: (int64 ref)) = var_18.mem_4
    let (var_24: Env11) = var_18.mem_5
    let (var_25: EnvStack14) = var_18.mem_6
    let (var_26: (int64 ref)) = var_18.mem_7
    let (var_27: Env11) = var_18.mem_8
    let (var_28: EnvStack14) = var_18.mem_9
    let (var_29: EnvStack14) = var_18.mem_10
    let (var_30: EnvStack13) = var_18.mem_11
    let (var_31: (int64 ref)) = var_18.mem_12
    let (var_32: Env11) = var_18.mem_13
    let (var_33: EnvStack13) = var_18.mem_14
    let (var_34: (int64 ref)) = var_18.mem_15
    let (var_35: Env11) = var_18.mem_16
    let (var_36: EnvStack18) = method_44((var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_31: (int64 ref)), (var_32: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_37: (int64 ref)) = var_36.mem_0
    let (var_38: Env11) = var_36.mem_1
    let (var_39: EnvStack18) = method_47((var_37: (int64 ref)), (var_38: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_40: EnvStack18) = method_69((var_13: (int64 ref)), (var_14: Env11), (var_34: (int64 ref)), (var_35: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_41: (int64 ref)) = var_40.mem_0
    let (var_42: Env11) = var_40.mem_1
    let (var_43: EnvStack18) = method_47((var_41: (int64 ref)), (var_42: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_44: EnvStack18) = method_109((var_20: (int64 ref)), (var_21: Env11), (var_23: (int64 ref)), (var_24: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_29: EnvStack14), (var_37: (int64 ref)), (var_38: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_45: (int64 ref)) = var_44.mem_0
    let (var_46: Env11) = var_44.mem_1
    let (var_47: EnvStack18) = method_47((var_45: (int64 ref)), (var_46: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_48: (unit -> unit)) = method_113((var_39: EnvStack18), (var_37: (int64 ref)), (var_38: Env11), (var_15: (int64 ref)), (var_16: Env11), (var_17: int64), (var_30: EnvStack13), (var_31: (int64 ref)), (var_32: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_43: EnvStack18), (var_41: (int64 ref)), (var_42: Env11), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_33: EnvStack13), (var_34: (int64 ref)), (var_35: Env11), (var_19: EnvStack14), (var_22: EnvStack14), (var_25: EnvStack14), (var_28: EnvStack14), (var_47: EnvStack18), (var_45: (int64 ref)), (var_46: Env11), (var_20: (int64 ref)), (var_21: Env11), (var_23: (int64 ref)), (var_24: Env11), (var_26: (int64 ref)), (var_27: Env11), (var_29: EnvStack14))
    EnvStack17((var_47: EnvStack18), (var_45: (int64 ref)), (var_46: Env11), (var_48: (unit -> unit)))
and method_124((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_15: EnvStack18), (var_16: (int64 ref)), (var_17: Env11), (var_18: (int64 ref)), (var_19: Env9), (var_20: EnvHeap15)): EnvStack17 =
    let (var_21: EnvStack14) = var_20.mem_0
    let (var_22: (int64 ref)) = var_20.mem_1
    let (var_23: Env11) = var_20.mem_2
    let (var_24: EnvStack14) = var_20.mem_3
    let (var_25: (int64 ref)) = var_20.mem_4
    let (var_26: Env11) = var_20.mem_5
    let (var_27: EnvStack14) = var_20.mem_6
    let (var_28: (int64 ref)) = var_20.mem_7
    let (var_29: Env11) = var_20.mem_8
    let (var_30: EnvStack14) = var_20.mem_9
    let (var_31: EnvStack14) = var_20.mem_10
    let (var_32: EnvStack13) = var_20.mem_11
    let (var_33: (int64 ref)) = var_20.mem_12
    let (var_34: Env11) = var_20.mem_13
    let (var_35: EnvStack13) = var_20.mem_14
    let (var_36: (int64 ref)) = var_20.mem_15
    let (var_37: Env11) = var_20.mem_16
    let (var_38: EnvStack18) = method_69((var_16: (int64 ref)), (var_17: Env11), (var_33: (int64 ref)), (var_34: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: Env11) = var_38.mem_1
    let (var_41: EnvStack18) = method_47((var_39: (int64 ref)), (var_40: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_42: EnvStack18) = method_69((var_13: (int64 ref)), (var_14: Env11), (var_36: (int64 ref)), (var_37: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_43: (int64 ref)) = var_42.mem_0
    let (var_44: Env11) = var_42.mem_1
    let (var_45: EnvStack18) = method_47((var_43: (int64 ref)), (var_44: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_46: EnvStack18) = method_109((var_22: (int64 ref)), (var_23: Env11), (var_25: (int64 ref)), (var_26: Env11), (var_28: (int64 ref)), (var_29: Env11), (var_31: EnvStack14), (var_39: (int64 ref)), (var_40: Env11), (var_43: (int64 ref)), (var_44: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_47: (int64 ref)) = var_46.mem_0
    let (var_48: Env11) = var_46.mem_1
    let (var_49: EnvStack18) = method_47((var_47: (int64 ref)), (var_48: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_50: (unit -> unit)) = method_125((var_41: EnvStack18), (var_39: (int64 ref)), (var_40: Env11), (var_15: EnvStack18), (var_16: (int64 ref)), (var_17: Env11), (var_32: EnvStack13), (var_33: (int64 ref)), (var_34: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_45: EnvStack18), (var_43: (int64 ref)), (var_44: Env11), (var_12: EnvStack18), (var_13: (int64 ref)), (var_14: Env11), (var_35: EnvStack13), (var_36: (int64 ref)), (var_37: Env11), (var_21: EnvStack14), (var_24: EnvStack14), (var_27: EnvStack14), (var_30: EnvStack14), (var_49: EnvStack18), (var_47: (int64 ref)), (var_48: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_25: (int64 ref)), (var_26: Env11), (var_28: (int64 ref)), (var_29: Env11), (var_31: EnvStack14), (var_18: (int64 ref)), (var_19: Env9))
    EnvStack17((var_49: EnvStack18), (var_47: (int64 ref)), (var_48: Env11), (var_50: (unit -> unit)))
and method_126 ((var_0: (unit -> unit)), (var_1: (unit -> unit)), (var_2: (unit -> unit)), (var_3: (unit -> unit)), (var_4: (unit -> unit))) (): unit =
    var_4()
    var_3()
    var_2()
    var_1()
    var_0()
and method_127 ((var_0: Env22), (var_1: (unit -> float32))) (): float32 =
    let (var_2: float32) = var_1()
    let (var_3: Env24) = var_0.mem_0
    let (var_4: Env25) = var_3.mem_0
    let (var_5: int64) = var_3.mem_1
    let (var_6: int64) = 1L
    let (var_7: Env4) = var_4.mem_0
    let (var_8: (float32 [])) = method_107((var_6: int64), (var_4: Env25), (var_5: int64))
    let (var_9: float32) = var_8.[int32 0L]
    (var_2 + var_9)
and method_129((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack5)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env4>) = var_2.mem_0
    var_5.Add((Env4(var_0, var_1)))
and method_132((var_0: (int64 ref)), (var_1: Env9), (var_2: (int64 ref)), (var_3: Env9), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: EnvHeap15), (var_9: EnvHeap15), (var_10: EnvStack14), (var_11: EnvStack14), (var_12: EnvStack13), (var_13: (int64 ref)), (var_14: Env11), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_25: (int64 ref)), (var_26: Env9)): unit =
    let (var_27: EnvStack14) = var_8.mem_0
    let (var_28: (int64 ref)) = var_8.mem_1
    let (var_29: Env11) = var_8.mem_2
    let (var_30: EnvStack14) = var_8.mem_3
    let (var_31: (int64 ref)) = var_8.mem_4
    let (var_32: Env11) = var_8.mem_5
    let (var_33: EnvStack14) = var_8.mem_6
    let (var_34: (int64 ref)) = var_8.mem_7
    let (var_35: Env11) = var_8.mem_8
    let (var_36: EnvStack14) = var_8.mem_9
    let (var_37: EnvStack14) = var_8.mem_10
    let (var_38: EnvStack13) = var_8.mem_11
    let (var_39: (int64 ref)) = var_8.mem_12
    let (var_40: Env11) = var_8.mem_13
    let (var_41: EnvStack13) = var_8.mem_14
    let (var_42: (int64 ref)) = var_8.mem_15
    let (var_43: Env11) = var_8.mem_16
    method_133((var_28: (int64 ref)), (var_29: Env11), (var_27: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    method_133((var_31: (int64 ref)), (var_32: Env11), (var_30: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    method_133((var_34: (int64 ref)), (var_35: Env11), (var_33: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    let (var_44: (int64 ref)) = var_37.mem_0
    let (var_45: Env11) = var_37.mem_1
    method_136((var_37: EnvStack14), (var_36: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    method_137((var_39: (int64 ref)), (var_40: Env11), (var_38: EnvStack13), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    method_137((var_42: (int64 ref)), (var_43: Env11), (var_41: EnvStack13), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_6: (int64 ref)), (var_7: Env9))
    let (var_46: EnvStack14) = var_9.mem_0
    let (var_47: (int64 ref)) = var_9.mem_1
    let (var_48: Env11) = var_9.mem_2
    let (var_49: EnvStack14) = var_9.mem_3
    let (var_50: (int64 ref)) = var_9.mem_4
    let (var_51: Env11) = var_9.mem_5
    let (var_52: EnvStack14) = var_9.mem_6
    let (var_53: (int64 ref)) = var_9.mem_7
    let (var_54: Env11) = var_9.mem_8
    let (var_55: EnvStack14) = var_9.mem_9
    let (var_56: EnvStack14) = var_9.mem_10
    let (var_57: EnvStack13) = var_9.mem_11
    let (var_58: (int64 ref)) = var_9.mem_12
    let (var_59: Env11) = var_9.mem_13
    let (var_60: EnvStack13) = var_9.mem_14
    let (var_61: (int64 ref)) = var_9.mem_15
    let (var_62: Env11) = var_9.mem_16
    method_133((var_47: (int64 ref)), (var_48: Env11), (var_46: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    method_133((var_50: (int64 ref)), (var_51: Env11), (var_49: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    method_133((var_53: (int64 ref)), (var_54: Env11), (var_52: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    let (var_63: (int64 ref)) = var_56.mem_0
    let (var_64: Env11) = var_56.mem_1
    method_136((var_56: EnvStack14), (var_55: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    method_137((var_58: (int64 ref)), (var_59: Env11), (var_57: EnvStack13), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    method_137((var_61: (int64 ref)), (var_62: Env11), (var_60: EnvStack13), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_4: (int64 ref)), (var_5: Env9))
    let (var_65: (int64 ref)) = var_11.mem_0
    let (var_66: Env11) = var_11.mem_1
    method_136((var_11: EnvStack14), (var_10: EnvStack14), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_2: (int64 ref)), (var_3: Env9))
    method_137((var_13: (int64 ref)), (var_14: Env11), (var_12: EnvStack13), (var_24: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_2: (int64 ref)), (var_3: Env9))
and method_141((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_9: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9), (var_14: int64), (var_15: float), (var_16: (int64 ref)), (var_17: Env9), (var_18: (int64 ref)), (var_19: Env9), (var_20: (int64 ref)), (var_21: Env9), (var_22: (int64 ref)), (var_23: Env9), (var_24: EnvHeap15), (var_25: EnvHeap15), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11), (var_31: EnvStack5), (var_32: (int64 ref)), (var_33: Env11), (var_34: (int64 ref)), (var_35: Env11), (var_36: int64)): float =
    let (var_37: bool) = (var_36 < 272L)
    if var_37 then
        let (var_38: bool) = (var_36 >= 0L)
        let (var_39: bool) = (var_38 = false)
        if var_39 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_40: int64) = (var_36 * 524288L)
        if var_39 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_41: int64) = (8192L + var_40)
        let (var_42: EnvHeap16) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: EnvStack1); mem_3 = (var_7: EnvStack3)} : EnvHeap16)
        let (var_43: (uint64 ref)) = var_42.mem_0
        let (var_44: uint64) = var_42.mem_1
        let (var_45: EnvStack1) = var_42.mem_2
        let (var_46: EnvStack3) = var_42.mem_3
        method_1((var_45: EnvStack1), (var_43: (uint64 ref)), (var_44: uint64), (var_46: EnvStack3))
        let (var_50: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_51: EnvStack5) = EnvStack5((var_50: ResizeArray<Env4>))
        // Executing the net...
        let (var_91: EnvStack17) = method_142((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_51: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_22: (int64 ref)), (var_23: Env9), (var_32: (int64 ref)), (var_33: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_40: int64), (var_24: EnvHeap15))
        let (var_92: EnvStack18) = var_91.mem_0
        let (var_93: (int64 ref)) = var_91.mem_1
        let (var_94: Env11) = var_91.mem_2
        let (var_95: (unit -> unit)) = var_91.mem_3
        let (var_96: EnvHeap8) = var_21.mem_0
        let (var_97: Env19) = method_67((var_96: EnvHeap8))
        let (var_98: EnvHeap8) = var_97.mem_0
        let (var_99: ManagedCuda.CudaEvent) = var_98.mem_0
        let (var_100: EnvHeap8) = var_23.mem_0
        let (var_101: ManagedCuda.BasicTypes.CUstream) = method_24((var_100: EnvHeap8))
        var_99.Record(var_101)
        let (var_102: ManagedCuda.CudaStream) = var_98.mem_2
        var_102.WaitEvent var_99.Event
        let (var_103: EnvStack17) = method_145((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_51: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env9), (var_34: (int64 ref)), (var_35: Env11), (var_92: EnvStack18), (var_93: (int64 ref)), (var_94: Env11), (var_22: (int64 ref)), (var_23: Env9), (var_25: EnvHeap15))
        let (var_104: EnvStack18) = var_103.mem_0
        let (var_105: (int64 ref)) = var_103.mem_1
        let (var_106: Env11) = var_103.mem_2
        let (var_107: (unit -> unit)) = var_103.mem_3
        let (var_108: EnvHeap8) = var_19.mem_0
        let (var_109: Env19) = method_67((var_108: EnvHeap8))
        let (var_110: EnvHeap8) = var_109.mem_0
        let (var_111: ManagedCuda.CudaEvent) = var_110.mem_0
        let (var_112: ManagedCuda.BasicTypes.CUstream) = method_24((var_96: EnvHeap8))
        var_111.Record(var_112)
        let (var_113: ManagedCuda.CudaStream) = var_110.mem_2
        var_113.WaitEvent var_111.Event
        let (var_114: EnvStack20) = method_75((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_51: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env9), (var_104: EnvStack18), (var_105: (int64 ref)), (var_106: Env11), (var_20: (int64 ref)), (var_21: Env9), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11))
        let (var_115: EnvStack18) = var_114.mem_0
        let (var_116: (int64 ref)) = var_114.mem_1
        let (var_117: Env11) = var_114.mem_2
        let (var_118: (unit -> unit)) = var_114.mem_3
        let (var_119: EnvHeap8) = var_17.mem_0
        let (var_120: Env19) = method_67((var_119: EnvHeap8))
        let (var_121: EnvHeap8) = var_120.mem_0
        let (var_122: ManagedCuda.CudaEvent) = var_121.mem_0
        let (var_123: ManagedCuda.BasicTypes.CUstream) = method_24((var_108: EnvHeap8))
        var_122.Record(var_123)
        let (var_124: ManagedCuda.CudaStream) = var_121.mem_2
        var_124.WaitEvent var_122.Event
        let (var_125: EnvStack21) = method_87((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_51: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9), (var_115: EnvStack18), (var_116: (int64 ref)), (var_117: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_41: int64), (var_18: (int64 ref)), (var_19: Env9))
        let (var_126: Env22) = var_125.mem_0
        let (var_127: (unit -> unit)) = var_125.mem_1
        let (var_128: (unit -> unit)) = method_105((var_95: (unit -> unit)), (var_107: (unit -> unit)), (var_118: (unit -> unit)), (var_127: (unit -> unit)))
        let (var_129: (unit -> float32)) = method_106((var_126: Env22))
        let (var_167: int64) = 1L
        method_147((var_0: (int64 ref)), (var_1: Env11), (var_40: int64), (var_41: int64), (var_16: (int64 ref)), (var_17: Env9), (var_18: (int64 ref)), (var_19: Env9), (var_20: (int64 ref)), (var_21: Env9), (var_22: (int64 ref)), (var_23: Env9), (var_24: EnvHeap15), (var_25: EnvHeap15), (var_26: EnvStack14), (var_27: EnvStack14), (var_28: EnvStack13), (var_29: (int64 ref)), (var_30: Env11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: EnvStack1), (var_7: EnvStack3), (var_8: ManagedCuda.CudaContext), (var_51: EnvStack5), (var_10: EnvStack7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9), (var_14: int64), (var_15: float), (var_36: int64), (var_9: EnvStack5), (var_31: EnvStack5), (var_129: (unit -> float32)), (var_128: (unit -> unit)), (var_92: EnvStack18), (var_93: (int64 ref)), (var_94: Env11), (var_104: EnvStack18), (var_105: (int64 ref)), (var_106: Env11), (var_167: int64))
    else
        method_130((var_31: EnvStack5))
        let (var_169: float) = (float var_14)
        (var_15 / var_169)
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
and method_45((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): Env4 =
    let (var_12: int64) = 32768L
    let (var_13: EnvHeap16) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64))
and method_46((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: (int64 ref)), (var_4: Env11), (var_5: (int64 ref)), (var_6: Env11), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: (int64 ref)), (var_9: Env9)): unit =
    let (var_10: ManagedCuda.CudaBlas.CudaBlasHandle) = var_7.get_CublasHandle()
    let (var_11: EnvHeap8) = var_9.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_24((var_11: EnvHeap8))
    var_7.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: (uint64 ref)) = var_4.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (uint64 ref)) = var_1.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: int64) = (var_2 * 4L)
    let (var_23: uint64) = (uint64 var_22)
    let (var_24: uint64) = (var_21 + var_23)
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: (float32 ref)) = (ref 0.000000f)
    let (var_28: (uint64 ref)) = var_6.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_10, var_13, var_14, 128, 64, 128, var_15, var_19, 128, var_26, 128, var_27, var_31, 128)
    if var_32 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_32)
and method_48((var_0: (int64 ref)), (var_1: Env11), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(32768L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_50((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_6: (int64 ref)), (var_7: Env11), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: (int64 ref)), (var_19: Env9)): unit =
    let (var_20: (uint64 ref)) = var_1.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: (uint64 ref)) = var_3.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: (uint64 ref)) = var_5.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: (uint64 ref)) = var_7.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    method_51((var_15: ManagedCuda.CudaContext), (var_21: uint64), (var_23: uint64), (var_25: uint64), (var_27: uint64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env9))
and method_55((var_0: EnvStack14), (var_1: EnvStack14), (var_2: EnvStack18), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack14), (var_9: (int64 ref)), (var_10: Env11), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9)): unit =
    method_56((var_9: (int64 ref)), (var_10: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack14), (var_0: EnvStack14), (var_1: EnvStack14), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_21: (int64 ref)), (var_22: Env9))
    method_62((var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack14), (var_9: (int64 ref)), (var_10: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_2: EnvStack18), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_21: (int64 ref)), (var_22: Env9))
and method_65((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9)): unit =
    method_66((var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_0: EnvStack18), (var_6: EnvStack13), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_19: (int64 ref)), (var_20: Env9))
and method_70((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env9)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: EnvHeap8) = var_8.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_24((var_10: EnvHeap8))
    var_6.set_Stream(var_11)
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: (float32 ref)) = (ref 1.000000f)
    let (var_15: (uint64 ref)) = var_3.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (uint64 ref)) = var_1.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: (float32 ref)) = (ref 0.000000f)
    let (var_24: (uint64 ref)) = var_5.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_25)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_12, var_13, 128, 64, 128, var_14, var_18, 128, var_22, 128, var_23, var_27, 128)
    if var_28 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_28)
and method_72((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9)): unit =
    method_73((var_0: EnvStack18), (var_7: (int64 ref)), (var_8: Env11), (var_3: EnvStack18), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_19: (int64 ref)), (var_20: Env9))
    method_74((var_4: (int64 ref)), (var_5: Env11), (var_0: EnvStack18), (var_6: EnvStack13), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_19: (int64 ref)), (var_20: Env9))
and method_77((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env9)): unit =
    // Cuda join point
    // method_78((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_78", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap8) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_24((var_10: EnvHeap8))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_80((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack14), (var_4: EnvStack14), (var_5: EnvStack18), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack13), (var_9: (int64 ref)), (var_10: Env11), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9)): unit =
    method_73((var_0: EnvStack18), (var_9: (int64 ref)), (var_10: Env11), (var_5: EnvStack18), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_21: (int64 ref)), (var_22: Env9))
    method_74((var_6: (int64 ref)), (var_7: Env11), (var_0: EnvStack18), (var_8: EnvStack13), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_21: (int64 ref)), (var_22: Env9))
    let (var_23: (int64 ref)) = var_3.mem_0
    let (var_24: Env11) = var_3.mem_1
    method_81((var_0: EnvStack18), (var_3: EnvStack14), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_21: (int64 ref)), (var_22: Env9))
and method_89((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: EnvStack1), (var_10: EnvStack3), (var_11: ManagedCuda.CudaContext), (var_12: EnvStack5), (var_13: EnvStack7), (var_14: (int64 ref)), (var_15: Env9)): unit =
    let (var_16: (uint64 ref)) = var_1.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: (uint64 ref)) = var_3.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    method_90((var_11: ManagedCuda.CudaContext), (var_17: uint64), (var_19: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env9))
and method_95((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9)): Env4 =
    let (var_12: int64) = 4L
    let (var_13: EnvHeap16) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: EnvStack1); mem_3 = (var_5: EnvStack3)} : EnvHeap16)
    method_12((var_13: EnvHeap16), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: int64))
and method_96((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env9)): unit =
    // Cuda join point
    // method_97((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_97", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap8) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_24((var_10: EnvHeap8))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_100((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: int64), (var_4: (int64 ref)), (var_5: Env11), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9)): unit =
    method_101((var_4: (int64 ref)), (var_5: Env11), (var_1: (int64 ref)), (var_2: Env11), (var_3: int64), (var_0: EnvStack18), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: EnvStack1), (var_11: EnvStack3), (var_12: ManagedCuda.CudaContext), (var_13: EnvStack5), (var_14: EnvStack7), (var_16: (int64 ref)), (var_17: Env9))
and method_109((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack14), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9)): EnvStack18 =
    let (var_23: (int64 ref)) = var_6.mem_0
    let (var_24: Env11) = var_6.mem_1
    let (var_34: Env4) = method_45((var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: (int64 ref)), (var_22: Env9))
    let (var_35: (int64 ref)) = var_34.mem_0
    let (var_36: Env11) = var_34.mem_1
    method_110((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_23: (int64 ref)), (var_24: Env11), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_35: (int64 ref)), (var_36: Env11), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_21: (int64 ref)), (var_22: Env9))
    EnvStack18((var_35: (int64 ref)), (var_36: Env11))
and method_113 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: EnvStack18), (var_25: (int64 ref)), (var_26: Env11), (var_27: EnvStack13), (var_28: (int64 ref)), (var_29: Env11), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack14), (var_34: EnvStack18), (var_35: (int64 ref)), (var_36: Env11), (var_37: (int64 ref)), (var_38: Env11), (var_39: (int64 ref)), (var_40: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_43: EnvStack14)) (): unit =
    method_114((var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack14), (var_0: EnvStack18), (var_21: EnvStack18), (var_34: EnvStack18), (var_35: (int64 ref)), (var_36: Env11), (var_37: (int64 ref)), (var_38: Env11), (var_39: (int64 ref)), (var_40: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_43: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_72((var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: EnvStack18), (var_25: (int64 ref)), (var_26: Env11), (var_27: EnvStack13), (var_28: (int64 ref)), (var_29: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_65((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
and method_125 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: EnvStack18), (var_25: (int64 ref)), (var_26: Env11), (var_27: EnvStack13), (var_28: (int64 ref)), (var_29: Env11), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack14), (var_34: EnvStack18), (var_35: (int64 ref)), (var_36: Env11), (var_37: (int64 ref)), (var_38: Env11), (var_39: (int64 ref)), (var_40: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_43: EnvStack14), (var_44: (int64 ref)), (var_45: Env9)) (): unit =
    method_114((var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack14), (var_0: EnvStack18), (var_21: EnvStack18), (var_34: EnvStack18), (var_35: (int64 ref)), (var_36: Env11), (var_37: (int64 ref)), (var_38: Env11), (var_39: (int64 ref)), (var_40: Env11), (var_41: (int64 ref)), (var_42: Env11), (var_43: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_72((var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: EnvStack18), (var_25: (int64 ref)), (var_26: Env11), (var_27: EnvStack13), (var_28: (int64 ref)), (var_29: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_72((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    let (var_46: EnvHeap8) = var_45.mem_0
    let (var_47: Env19) = method_67((var_46: EnvHeap8))
    let (var_48: EnvHeap8) = var_47.mem_0
    let (var_49: ManagedCuda.CudaEvent) = var_48.mem_0
    let (var_50: EnvHeap8) = var_20.mem_0
    let (var_51: ManagedCuda.BasicTypes.CUstream) = method_24((var_50: EnvHeap8))
    var_49.Record(var_51)
    let (var_52: ManagedCuda.CudaStream) = var_48.mem_2
    var_52.WaitEvent var_49.Event
and method_133((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack14), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env9)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env11) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_134((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env9))
and method_136((var_0: EnvStack14), (var_1: EnvStack14), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env9)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env11) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env11) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_134((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
and method_137((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack13), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: EnvStack1), (var_9: EnvStack3), (var_10: ManagedCuda.CudaContext), (var_11: EnvStack5), (var_12: EnvStack7), (var_13: (int64 ref)), (var_14: Env9)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env11) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_138((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env9))
and method_142((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: (int64 ref)), (var_13: Env11), (var_14: (int64 ref)), (var_15: Env11), (var_16: int64), (var_17: EnvHeap15)): EnvStack17 =
    let (var_18: EnvStack14) = var_17.mem_0
    let (var_19: (int64 ref)) = var_17.mem_1
    let (var_20: Env11) = var_17.mem_2
    let (var_21: EnvStack14) = var_17.mem_3
    let (var_22: (int64 ref)) = var_17.mem_4
    let (var_23: Env11) = var_17.mem_5
    let (var_24: EnvStack14) = var_17.mem_6
    let (var_25: (int64 ref)) = var_17.mem_7
    let (var_26: Env11) = var_17.mem_8
    let (var_27: EnvStack14) = var_17.mem_9
    let (var_28: EnvStack14) = var_17.mem_10
    let (var_29: EnvStack13) = var_17.mem_11
    let (var_30: (int64 ref)) = var_17.mem_12
    let (var_31: Env11) = var_17.mem_13
    let (var_32: EnvStack13) = var_17.mem_14
    let (var_33: (int64 ref)) = var_17.mem_15
    let (var_34: Env11) = var_17.mem_16
    let (var_35: EnvStack18) = method_44((var_14: (int64 ref)), (var_15: Env11), (var_16: int64), (var_30: (int64 ref)), (var_31: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_36: (int64 ref)) = var_35.mem_0
    let (var_37: Env11) = var_35.mem_1
    let (var_38: EnvStack18) = method_47((var_36: (int64 ref)), (var_37: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_39: EnvStack18) = method_69((var_12: (int64 ref)), (var_13: Env11), (var_33: (int64 ref)), (var_34: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_40: (int64 ref)) = var_39.mem_0
    let (var_41: Env11) = var_39.mem_1
    let (var_42: EnvStack18) = method_47((var_40: (int64 ref)), (var_41: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_43: EnvStack18) = method_109((var_19: (int64 ref)), (var_20: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_25: (int64 ref)), (var_26: Env11), (var_28: EnvStack14), (var_36: (int64 ref)), (var_37: Env11), (var_40: (int64 ref)), (var_41: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_44: (int64 ref)) = var_43.mem_0
    let (var_45: Env11) = var_43.mem_1
    let (var_46: EnvStack18) = method_47((var_44: (int64 ref)), (var_45: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_47: (unit -> unit)) = method_143((var_38: EnvStack18), (var_36: (int64 ref)), (var_37: Env11), (var_14: (int64 ref)), (var_15: Env11), (var_16: int64), (var_29: EnvStack13), (var_30: (int64 ref)), (var_31: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_42: EnvStack18), (var_40: (int64 ref)), (var_41: Env11), (var_12: (int64 ref)), (var_13: Env11), (var_32: EnvStack13), (var_33: (int64 ref)), (var_34: Env11), (var_18: EnvStack14), (var_21: EnvStack14), (var_24: EnvStack14), (var_27: EnvStack14), (var_46: EnvStack18), (var_44: (int64 ref)), (var_45: Env11), (var_19: (int64 ref)), (var_20: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_25: (int64 ref)), (var_26: Env11), (var_28: EnvStack14))
    EnvStack17((var_46: EnvStack18), (var_44: (int64 ref)), (var_45: Env11), (var_47: (unit -> unit)))
and method_145((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_12: (int64 ref)), (var_13: Env11), (var_14: EnvStack18), (var_15: (int64 ref)), (var_16: Env11), (var_17: (int64 ref)), (var_18: Env9), (var_19: EnvHeap15)): EnvStack17 =
    let (var_20: EnvStack14) = var_19.mem_0
    let (var_21: (int64 ref)) = var_19.mem_1
    let (var_22: Env11) = var_19.mem_2
    let (var_23: EnvStack14) = var_19.mem_3
    let (var_24: (int64 ref)) = var_19.mem_4
    let (var_25: Env11) = var_19.mem_5
    let (var_26: EnvStack14) = var_19.mem_6
    let (var_27: (int64 ref)) = var_19.mem_7
    let (var_28: Env11) = var_19.mem_8
    let (var_29: EnvStack14) = var_19.mem_9
    let (var_30: EnvStack14) = var_19.mem_10
    let (var_31: EnvStack13) = var_19.mem_11
    let (var_32: (int64 ref)) = var_19.mem_12
    let (var_33: Env11) = var_19.mem_13
    let (var_34: EnvStack13) = var_19.mem_14
    let (var_35: (int64 ref)) = var_19.mem_15
    let (var_36: Env11) = var_19.mem_16
    let (var_37: EnvStack18) = method_69((var_15: (int64 ref)), (var_16: Env11), (var_32: (int64 ref)), (var_33: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_38: (int64 ref)) = var_37.mem_0
    let (var_39: Env11) = var_37.mem_1
    let (var_40: EnvStack18) = method_47((var_38: (int64 ref)), (var_39: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_41: EnvStack18) = method_69((var_12: (int64 ref)), (var_13: Env11), (var_35: (int64 ref)), (var_36: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_42: (int64 ref)) = var_41.mem_0
    let (var_43: Env11) = var_41.mem_1
    let (var_44: EnvStack18) = method_47((var_42: (int64 ref)), (var_43: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_45: EnvStack18) = method_109((var_21: (int64 ref)), (var_22: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_27: (int64 ref)), (var_28: Env11), (var_30: EnvStack14), (var_38: (int64 ref)), (var_39: Env11), (var_42: (int64 ref)), (var_43: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_46: (int64 ref)) = var_45.mem_0
    let (var_47: Env11) = var_45.mem_1
    let (var_48: EnvStack18) = method_47((var_46: (int64 ref)), (var_47: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9))
    let (var_49: (unit -> unit)) = method_146((var_40: EnvStack18), (var_38: (int64 ref)), (var_39: Env11), (var_14: EnvStack18), (var_15: (int64 ref)), (var_16: Env11), (var_31: EnvStack13), (var_32: (int64 ref)), (var_33: Env11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: EnvStack1), (var_5: EnvStack3), (var_6: ManagedCuda.CudaContext), (var_7: EnvStack5), (var_8: EnvStack7), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_44: EnvStack18), (var_42: (int64 ref)), (var_43: Env11), (var_12: (int64 ref)), (var_13: Env11), (var_34: EnvStack13), (var_35: (int64 ref)), (var_36: Env11), (var_20: EnvStack14), (var_23: EnvStack14), (var_26: EnvStack14), (var_29: EnvStack14), (var_48: EnvStack18), (var_46: (int64 ref)), (var_47: Env11), (var_21: (int64 ref)), (var_22: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_27: (int64 ref)), (var_28: Env11), (var_30: EnvStack14), (var_17: (int64 ref)), (var_18: Env9))
    EnvStack17((var_48: EnvStack18), (var_46: (int64 ref)), (var_47: Env11), (var_49: (unit -> unit)))
and method_147((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_31: int64), (var_32: float), (var_33: int64), (var_34: EnvStack5), (var_35: EnvStack5), (var_36: (unit -> float32)), (var_37: (unit -> unit)), (var_38: EnvStack18), (var_39: (int64 ref)), (var_40: Env11), (var_41: EnvStack18), (var_42: (int64 ref)), (var_43: Env11), (var_44: int64)): float =
    let (var_45: bool) = (var_44 < 64L)
    if var_45 then
        let (var_46: bool) = (var_44 >= 0L)
        let (var_47: bool) = (var_46 = false)
        if var_47 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_48: int64) = (var_44 * 8192L)
        let (var_49: int64) = (var_2 + var_48)
        if var_47 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_50: int64) = (var_3 + var_48)
        let (var_51: EnvStack17) = method_108((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env9), (var_38: EnvStack18), (var_39: (int64 ref)), (var_40: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_49: int64), (var_12: EnvHeap15))
        let (var_52: EnvStack18) = var_51.mem_0
        let (var_53: (int64 ref)) = var_51.mem_1
        let (var_54: Env11) = var_51.mem_2
        let (var_55: (unit -> unit)) = var_51.mem_3
        let (var_56: EnvHeap8) = var_9.mem_0
        let (var_57: Env19) = method_67((var_56: EnvHeap8))
        let (var_58: EnvHeap8) = var_57.mem_0
        let (var_59: ManagedCuda.CudaEvent) = var_58.mem_0
        let (var_60: EnvHeap8) = var_11.mem_0
        let (var_61: ManagedCuda.BasicTypes.CUstream) = method_24((var_60: EnvHeap8))
        var_59.Record(var_61)
        let (var_62: ManagedCuda.CudaStream) = var_58.mem_2
        var_62.WaitEvent var_59.Event
        let (var_63: EnvStack17) = method_124((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env9), (var_41: EnvStack18), (var_42: (int64 ref)), (var_43: Env11), (var_52: EnvStack18), (var_53: (int64 ref)), (var_54: Env11), (var_10: (int64 ref)), (var_11: Env9), (var_13: EnvHeap15))
        let (var_64: EnvStack18) = var_63.mem_0
        let (var_65: (int64 ref)) = var_63.mem_1
        let (var_66: Env11) = var_63.mem_2
        let (var_67: (unit -> unit)) = var_63.mem_3
        let (var_68: EnvHeap8) = var_7.mem_0
        let (var_69: Env19) = method_67((var_68: EnvHeap8))
        let (var_70: EnvHeap8) = var_69.mem_0
        let (var_71: ManagedCuda.CudaEvent) = var_70.mem_0
        let (var_72: ManagedCuda.BasicTypes.CUstream) = method_24((var_56: EnvHeap8))
        var_71.Record(var_72)
        let (var_73: ManagedCuda.CudaStream) = var_70.mem_2
        var_73.WaitEvent var_71.Event
        let (var_74: EnvStack20) = method_75((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env9), (var_64: EnvStack18), (var_65: (int64 ref)), (var_66: Env11), (var_8: (int64 ref)), (var_9: Env9), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11))
        let (var_75: EnvStack18) = var_74.mem_0
        let (var_76: (int64 ref)) = var_74.mem_1
        let (var_77: Env11) = var_74.mem_2
        let (var_78: (unit -> unit)) = var_74.mem_3
        let (var_79: EnvHeap8) = var_5.mem_0
        let (var_80: Env19) = method_67((var_79: EnvHeap8))
        let (var_81: EnvHeap8) = var_80.mem_0
        let (var_82: ManagedCuda.CudaEvent) = var_81.mem_0
        let (var_83: ManagedCuda.BasicTypes.CUstream) = method_24((var_68: EnvHeap8))
        var_82.Record(var_83)
        let (var_84: ManagedCuda.CudaStream) = var_81.mem_2
        var_84.WaitEvent var_82.Event
        let (var_85: EnvStack21) = method_87((var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9), (var_75: EnvStack18), (var_76: (int64 ref)), (var_77: Env11), (var_0: (int64 ref)), (var_1: Env11), (var_50: int64), (var_6: (int64 ref)), (var_7: Env9))
        let (var_86: Env22) = var_85.mem_0
        let (var_87: (unit -> unit)) = var_85.mem_1
        let (var_88: (unit -> unit)) = method_126((var_37: (unit -> unit)), (var_55: (unit -> unit)), (var_67: (unit -> unit)), (var_78: (unit -> unit)), (var_87: (unit -> unit)))
        let (var_89: (unit -> float32)) = method_127((var_86: Env22), (var_36: (unit -> float32)))
        let (var_90: int64) = (var_44 + 1L)
        method_147((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_31: int64), (var_32: float), (var_33: int64), (var_34: EnvStack5), (var_35: EnvStack5), (var_89: (unit -> float32)), (var_88: (unit -> unit)), (var_52: EnvStack18), (var_53: (int64 ref)), (var_54: Env11), (var_64: EnvStack18), (var_65: (int64 ref)), (var_66: Env11), (var_90: int64))
    else
        let (var_92: float32) = var_36()
        let (var_93: float) = (float var_92)
        let (var_94: float) = (var_32 + var_93)
        let (var_95: int64) = (var_31 + 1L)
        let (var_104: ResizeArray<Env4>) = ResizeArray<Env4>()
        let (var_105: EnvStack5) = EnvStack5((var_104: ResizeArray<Env4>))
        method_129((var_39: (int64 ref)), (var_40: Env11), (var_105: EnvStack5))
        method_129((var_42: (int64 ref)), (var_43: Env11), (var_105: EnvStack5))
        if (System.Double.IsNaN var_94) then
            method_130((var_35: EnvStack5))
            method_130((var_26: EnvStack5))
            // Done with the net...
            method_130((var_105: EnvStack5))
            let (var_106: float) = (float var_95)
            (var_94 / var_106)
        else
            var_37()
            method_132((var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9))
            method_130((var_35: EnvStack5))
            method_130((var_26: EnvStack5))
            // Executing the next loop...
            let (var_108: int64) = (var_33 + 1L)
            method_141((var_0: (int64 ref)), (var_1: Env11), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_34: EnvStack5), (var_27: EnvStack7), (var_28: ManagedCuda.BasicTypes.CUmodule), (var_29: (int64 ref)), (var_30: Env9), (var_95: int64), (var_94: float), (var_4: (int64 ref)), (var_5: Env9), (var_6: (int64 ref)), (var_7: Env9), (var_8: (int64 ref)), (var_9: Env9), (var_10: (int64 ref)), (var_11: Env9), (var_12: EnvHeap15), (var_13: EnvHeap15), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack13), (var_17: (int64 ref)), (var_18: Env11), (var_105: EnvStack5), (var_39: (int64 ref)), (var_40: Env11), (var_42: (int64 ref)), (var_43: Env11), (var_108: int64))
and method_51((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env9)): unit =
    // Cuda join point
    // method_52((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_52", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: EnvHeap8) = var_7.mem_0
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_24((var_11: EnvHeap8))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_12, var_14)
and method_56((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack18), (var_3: (int64 ref)), (var_4: Env11), (var_5: (int64 ref)), (var_6: Env11), (var_7: EnvStack14), (var_8: EnvStack14), (var_9: EnvStack14), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (uint64 ref)), (var_14: uint64), (var_15: EnvStack1), (var_16: EnvStack3), (var_17: ManagedCuda.CudaContext), (var_18: EnvStack5), (var_19: EnvStack7), (var_20: (int64 ref)), (var_21: Env9)): unit =
    let (var_22: (int64 ref)) = var_2.mem_0
    let (var_23: Env11) = var_2.mem_1
    let (var_24: (int64 ref)) = var_7.mem_0
    let (var_25: Env11) = var_7.mem_1
    let (var_26: (int64 ref)) = var_8.mem_0
    let (var_27: Env11) = var_8.mem_1
    let (var_28: (int64 ref)) = var_9.mem_0
    let (var_29: Env11) = var_9.mem_1
    let (var_30: (uint64 ref)) = var_1.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: (uint64 ref)) = var_23.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: (uint64 ref)) = var_4.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: (uint64 ref)) = var_6.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: (uint64 ref)) = var_25.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: (uint64 ref)) = var_27.mem_0
    let (var_41: uint64) = method_5((var_40: (uint64 ref)))
    let (var_42: (uint64 ref)) = var_29.mem_0
    let (var_43: uint64) = method_5((var_42: (uint64 ref)))
    method_57((var_17: ManagedCuda.CudaContext), (var_31: uint64), (var_33: uint64), (var_35: uint64), (var_37: uint64), (var_39: uint64), (var_41: uint64), (var_43: uint64), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env9))
and method_62((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack14), (var_3: (int64 ref)), (var_4: Env11), (var_5: EnvStack18), (var_6: (int64 ref)), (var_7: Env11), (var_8: EnvStack18), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: EnvStack1), (var_15: EnvStack3), (var_16: ManagedCuda.CudaContext), (var_17: EnvStack5), (var_18: EnvStack7), (var_19: (int64 ref)), (var_20: Env9)): unit =
    let (var_21: (int64 ref)) = var_2.mem_0
    let (var_22: Env11) = var_2.mem_1
    let (var_23: (int64 ref)) = var_5.mem_0
    let (var_24: Env11) = var_5.mem_1
    let (var_25: (int64 ref)) = var_8.mem_0
    let (var_26: Env11) = var_8.mem_1
    let (var_27: (uint64 ref)) = var_1.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: (uint64 ref)) = var_22.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: (uint64 ref)) = var_4.mem_0
    let (var_32: uint64) = method_5((var_31: (uint64 ref)))
    let (var_33: (uint64 ref)) = var_24.mem_0
    let (var_34: uint64) = method_5((var_33: (uint64 ref)))
    let (var_35: (uint64 ref)) = var_7.mem_0
    let (var_36: uint64) = method_5((var_35: (uint64 ref)))
    let (var_37: (uint64 ref)) = var_26.mem_0
    let (var_38: uint64) = method_5((var_37: (uint64 ref)))
    method_63((var_16: ManagedCuda.CudaContext), (var_28: uint64), (var_30: uint64), (var_32: uint64), (var_34: uint64), (var_36: uint64), (var_38: uint64), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
and method_66((var_0: (int64 ref)), (var_1: Env11), (var_2: int64), (var_3: EnvStack18), (var_4: EnvStack13), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: (int64 ref)), (var_7: Env9)): unit =
    let (var_8: (int64 ref)) = var_3.mem_0
    let (var_9: Env11) = var_3.mem_1
    let (var_10: (int64 ref)) = var_4.mem_0
    let (var_11: Env11) = var_4.mem_1
    let (var_12: ManagedCuda.CudaBlas.CudaBlasHandle) = var_5.get_CublasHandle()
    let (var_13: EnvHeap8) = var_7.mem_0
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_24((var_13: EnvHeap8))
    var_5.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_9.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (uint64 ref)) = var_1.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_2 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (float32 ref)) = (ref 1.000000f)
    let (var_30: (uint64 ref)) = var_11.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_31)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_12, var_15, var_16, 128, 128, 64, var_17, var_21, 128, var_28, 128, var_29, var_33, 128)
    if var_34 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_34)
and method_73((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env9)): unit =
    let (var_7: (int64 ref)) = var_0.mem_0
    let (var_8: Env11) = var_0.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env11) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap8) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_24((var_12: EnvHeap8))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_2.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_8.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 128, 64, 128, var_16, var_20, 128, var_24, 128, var_25, var_29, 128)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_74((var_0: (int64 ref)), (var_1: Env11), (var_2: EnvStack18), (var_3: EnvStack13), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env9)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env11) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env11) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: EnvHeap8) = var_6.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_24((var_12: EnvHeap8))
    var_4.set_Stream(var_13)
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: (uint64 ref)) = var_8.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (uint64 ref)) = var_1.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (uint64 ref)) = var_10.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_14, var_15, 128, 128, 64, var_16, var_20, 128, var_24, 128, var_25, var_29, 128)
    if var_30 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_30)
and method_81((var_0: EnvStack18), (var_1: EnvStack14), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: EnvStack1), (var_8: EnvStack3), (var_9: ManagedCuda.CudaContext), (var_10: EnvStack5), (var_11: EnvStack7), (var_12: (int64 ref)), (var_13: Env9)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env11) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env11) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_82((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9))
and method_90((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_91((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_91", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_101((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: int64), (var_5: EnvStack18), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: EnvStack1), (var_12: EnvStack3), (var_13: ManagedCuda.CudaContext), (var_14: EnvStack5), (var_15: EnvStack7), (var_16: (int64 ref)), (var_17: Env9)): unit =
    let (var_18: (int64 ref)) = var_5.mem_0
    let (var_19: Env11) = var_5.mem_1
    let (var_20: (uint64 ref)) = var_1.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: (uint64 ref)) = var_3.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_4 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: (uint64 ref)) = var_19.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_102((var_13: ManagedCuda.CudaContext), (var_21: uint64), (var_26: uint64), (var_28: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env9))
and method_110((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_6: (int64 ref)), (var_7: Env11), (var_8: (int64 ref)), (var_9: Env11), (var_10: (int64 ref)), (var_11: Env11), (var_12: (int64 ref)), (var_13: Env11), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: ManagedCuda.CudaBlas.CudaBlas), (var_16: ManagedCuda.CudaRand.CudaRandDevice), (var_17: (uint64 ref)), (var_18: uint64), (var_19: EnvStack1), (var_20: EnvStack3), (var_21: ManagedCuda.CudaContext), (var_22: EnvStack5), (var_23: EnvStack7), (var_24: (int64 ref)), (var_25: Env9)): unit =
    let (var_26: (uint64 ref)) = var_1.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: (uint64 ref)) = var_3.mem_0
    let (var_29: uint64) = method_5((var_28: (uint64 ref)))
    let (var_30: (uint64 ref)) = var_5.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: (uint64 ref)) = var_7.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: (uint64 ref)) = var_9.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: (uint64 ref)) = var_11.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: (uint64 ref)) = var_13.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    method_111((var_21: ManagedCuda.CudaContext), (var_27: uint64), (var_29: uint64), (var_31: uint64), (var_33: uint64), (var_35: uint64), (var_37: uint64), (var_39: uint64), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_24: (int64 ref)), (var_25: Env9))
and method_114((var_0: EnvStack14), (var_1: EnvStack14), (var_2: EnvStack14), (var_3: EnvStack14), (var_4: EnvStack18), (var_5: EnvStack18), (var_6: EnvStack18), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_11: (int64 ref)), (var_12: Env11), (var_13: (int64 ref)), (var_14: Env11), (var_15: EnvStack14), (var_16: (int64 ref)), (var_17: Env11), (var_18: (int64 ref)), (var_19: Env11), (var_20: ManagedCuda.CudaBlas.CudaBlas), (var_21: ManagedCuda.CudaRand.CudaRandDevice), (var_22: (uint64 ref)), (var_23: uint64), (var_24: EnvStack1), (var_25: EnvStack3), (var_26: ManagedCuda.CudaContext), (var_27: EnvStack5), (var_28: EnvStack7), (var_29: ManagedCuda.BasicTypes.CUmodule), (var_30: (int64 ref)), (var_31: Env9)): unit =
    method_115((var_16: (int64 ref)), (var_17: Env11), (var_18: (int64 ref)), (var_19: Env11), (var_6: EnvStack18), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_11: (int64 ref)), (var_12: Env11), (var_13: (int64 ref)), (var_14: Env11), (var_15: EnvStack14), (var_0: EnvStack14), (var_1: EnvStack14), (var_2: EnvStack14), (var_3: EnvStack14), (var_29: ManagedCuda.BasicTypes.CUmodule), (var_20: ManagedCuda.CudaBlas.CudaBlas), (var_21: ManagedCuda.CudaRand.CudaRandDevice), (var_22: (uint64 ref)), (var_23: uint64), (var_24: EnvStack1), (var_25: EnvStack3), (var_26: ManagedCuda.CudaContext), (var_27: EnvStack5), (var_28: EnvStack7), (var_30: (int64 ref)), (var_31: Env9))
    method_121((var_9: (int64 ref)), (var_10: Env11), (var_11: (int64 ref)), (var_12: Env11), (var_13: (int64 ref)), (var_14: Env11), (var_15: EnvStack14), (var_16: (int64 ref)), (var_17: Env11), (var_18: (int64 ref)), (var_19: Env11), (var_6: EnvStack18), (var_7: (int64 ref)), (var_8: Env11), (var_4: EnvStack18), (var_5: EnvStack18), (var_29: ManagedCuda.BasicTypes.CUmodule), (var_20: ManagedCuda.CudaBlas.CudaBlas), (var_21: ManagedCuda.CudaRand.CudaRandDevice), (var_22: (uint64 ref)), (var_23: uint64), (var_24: EnvStack1), (var_25: EnvStack3), (var_26: ManagedCuda.CudaContext), (var_27: EnvStack5), (var_28: EnvStack7), (var_30: (int64 ref)), (var_31: Env9))
and method_134((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_135((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_135", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_138((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_139((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_139", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_143 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_26: EnvStack13), (var_27: (int64 ref)), (var_28: Env11), (var_29: EnvStack14), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack18), (var_34: (int64 ref)), (var_35: Env11), (var_36: (int64 ref)), (var_37: Env11), (var_38: (int64 ref)), (var_39: Env11), (var_40: (int64 ref)), (var_41: Env11), (var_42: EnvStack14)) (): unit =
    method_114((var_29: EnvStack14), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_0: EnvStack18), (var_21: EnvStack18), (var_33: EnvStack18), (var_34: (int64 ref)), (var_35: Env11), (var_36: (int64 ref)), (var_37: Env11), (var_38: (int64 ref)), (var_39: Env11), (var_40: (int64 ref)), (var_41: Env11), (var_42: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_144((var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_26: EnvStack13), (var_27: (int64 ref)), (var_28: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_65((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: int64), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
and method_146 ((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9), (var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_26: EnvStack13), (var_27: (int64 ref)), (var_28: Env11), (var_29: EnvStack14), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_33: EnvStack18), (var_34: (int64 ref)), (var_35: Env11), (var_36: (int64 ref)), (var_37: Env11), (var_38: (int64 ref)), (var_39: Env11), (var_40: (int64 ref)), (var_41: Env11), (var_42: EnvStack14), (var_43: (int64 ref)), (var_44: Env9)) (): unit =
    method_114((var_29: EnvStack14), (var_30: EnvStack14), (var_31: EnvStack14), (var_32: EnvStack14), (var_0: EnvStack18), (var_21: EnvStack18), (var_33: EnvStack18), (var_34: (int64 ref)), (var_35: Env11), (var_36: (int64 ref)), (var_37: Env11), (var_38: (int64 ref)), (var_39: Env11), (var_40: (int64 ref)), (var_41: Env11), (var_42: EnvStack14), (var_1: (int64 ref)), (var_2: Env11), (var_22: (int64 ref)), (var_23: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_144((var_21: EnvStack18), (var_22: (int64 ref)), (var_23: Env11), (var_24: (int64 ref)), (var_25: Env11), (var_26: EnvStack13), (var_27: (int64 ref)), (var_28: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    method_72((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: EnvStack18), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack13), (var_7: (int64 ref)), (var_8: Env11), (var_9: ManagedCuda.CudaBlas.CudaBlas), (var_10: ManagedCuda.CudaRand.CudaRandDevice), (var_11: (uint64 ref)), (var_12: uint64), (var_13: EnvStack1), (var_14: EnvStack3), (var_15: ManagedCuda.CudaContext), (var_16: EnvStack5), (var_17: EnvStack7), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: (int64 ref)), (var_20: Env9))
    let (var_45: EnvHeap8) = var_44.mem_0
    let (var_46: Env19) = method_67((var_45: EnvHeap8))
    let (var_47: EnvHeap8) = var_46.mem_0
    let (var_48: ManagedCuda.CudaEvent) = var_47.mem_0
    let (var_49: EnvHeap8) = var_20.mem_0
    let (var_50: ManagedCuda.BasicTypes.CUstream) = method_24((var_49: EnvHeap8))
    var_48.Record(var_50)
    let (var_51: ManagedCuda.CudaStream) = var_47.mem_2
    var_51.WaitEvent var_48.Event
and method_57((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env9)): unit =
    // Cuda join point
    // method_58((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64))
    let (var_11: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_58", var_8, var_0)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_11.set_GridDimensions(var_12)
    let (var_13: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_11.set_BlockDimensions(var_13)
    let (var_14: EnvHeap8) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_24((var_14: EnvHeap8))
    let (var_17: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6; var_7|]: (System.Object [])
    var_11.RunAsync(var_15, var_17)
and method_63((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: (int64 ref)), (var_9: Env9)): unit =
    // Cuda join point
    // method_64((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64))
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_64", var_7, var_0)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: EnvHeap8) = var_9.mem_0
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_24((var_13: EnvHeap8))
    let (var_16: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_14, var_16)
and method_82((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env9)): unit =
    // Cuda join point
    // method_83((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_83", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: EnvHeap8) = var_5.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_24((var_9: EnvHeap8))
    let (var_12: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_10, var_12)
and method_102((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env9)): unit =
    // Cuda join point
    // method_103((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_103", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: EnvHeap8) = var_6.mem_0
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_24((var_10: EnvHeap8))
    let (var_13: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_11, var_13)
and method_111((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_9: (int64 ref)), (var_10: Env9)): unit =
    // Cuda join point
    // method_112((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64))
    let (var_11: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_112", var_8, var_0)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_11.set_GridDimensions(var_12)
    let (var_13: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_11.set_BlockDimensions(var_13)
    let (var_14: EnvHeap8) = var_10.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_24((var_14: EnvHeap8))
    let (var_17: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6; var_7|]: (System.Object [])
    var_11.RunAsync(var_15, var_17)
and method_115((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: EnvStack18), (var_5: (int64 ref)), (var_6: Env11), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_11: (int64 ref)), (var_12: Env11), (var_13: EnvStack14), (var_14: EnvStack14), (var_15: EnvStack14), (var_16: EnvStack14), (var_17: EnvStack14), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_19: ManagedCuda.CudaBlas.CudaBlas), (var_20: ManagedCuda.CudaRand.CudaRandDevice), (var_21: (uint64 ref)), (var_22: uint64), (var_23: EnvStack1), (var_24: EnvStack3), (var_25: ManagedCuda.CudaContext), (var_26: EnvStack5), (var_27: EnvStack7), (var_28: (int64 ref)), (var_29: Env9)): unit =
    let (var_30: (int64 ref)) = var_4.mem_0
    let (var_31: Env11) = var_4.mem_1
    let (var_32: (int64 ref)) = var_13.mem_0
    let (var_33: Env11) = var_13.mem_1
    let (var_34: (int64 ref)) = var_14.mem_0
    let (var_35: Env11) = var_14.mem_1
    let (var_36: (int64 ref)) = var_15.mem_0
    let (var_37: Env11) = var_15.mem_1
    let (var_38: (int64 ref)) = var_16.mem_0
    let (var_39: Env11) = var_16.mem_1
    let (var_40: (int64 ref)) = var_17.mem_0
    let (var_41: Env11) = var_17.mem_1
    let (var_42: (uint64 ref)) = var_1.mem_0
    let (var_43: uint64) = method_5((var_42: (uint64 ref)))
    let (var_44: (uint64 ref)) = var_3.mem_0
    let (var_45: uint64) = method_5((var_44: (uint64 ref)))
    let (var_46: (uint64 ref)) = var_31.mem_0
    let (var_47: uint64) = method_5((var_46: (uint64 ref)))
    let (var_48: (uint64 ref)) = var_6.mem_0
    let (var_49: uint64) = method_5((var_48: (uint64 ref)))
    let (var_50: (uint64 ref)) = var_8.mem_0
    let (var_51: uint64) = method_5((var_50: (uint64 ref)))
    let (var_52: (uint64 ref)) = var_10.mem_0
    let (var_53: uint64) = method_5((var_52: (uint64 ref)))
    let (var_54: (uint64 ref)) = var_12.mem_0
    let (var_55: uint64) = method_5((var_54: (uint64 ref)))
    let (var_56: (uint64 ref)) = var_33.mem_0
    let (var_57: uint64) = method_5((var_56: (uint64 ref)))
    let (var_58: (uint64 ref)) = var_35.mem_0
    let (var_59: uint64) = method_5((var_58: (uint64 ref)))
    let (var_60: (uint64 ref)) = var_37.mem_0
    let (var_61: uint64) = method_5((var_60: (uint64 ref)))
    let (var_62: (uint64 ref)) = var_39.mem_0
    let (var_63: uint64) = method_5((var_62: (uint64 ref)))
    let (var_64: (uint64 ref)) = var_41.mem_0
    let (var_65: uint64) = method_5((var_64: (uint64 ref)))
    method_116((var_25: ManagedCuda.CudaContext), (var_43: uint64), (var_45: uint64), (var_47: uint64), (var_49: uint64), (var_51: uint64), (var_53: uint64), (var_55: uint64), (var_57: uint64), (var_59: uint64), (var_61: uint64), (var_63: uint64), (var_65: uint64), (var_18: ManagedCuda.BasicTypes.CUmodule), (var_28: (int64 ref)), (var_29: Env9))
and method_121((var_0: (int64 ref)), (var_1: Env11), (var_2: (int64 ref)), (var_3: Env11), (var_4: (int64 ref)), (var_5: Env11), (var_6: EnvStack14), (var_7: (int64 ref)), (var_8: Env11), (var_9: (int64 ref)), (var_10: Env11), (var_11: EnvStack18), (var_12: (int64 ref)), (var_13: Env11), (var_14: EnvStack18), (var_15: EnvStack18), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: (uint64 ref)), (var_20: uint64), (var_21: EnvStack1), (var_22: EnvStack3), (var_23: ManagedCuda.CudaContext), (var_24: EnvStack5), (var_25: EnvStack7), (var_26: (int64 ref)), (var_27: Env9)): unit =
    let (var_28: (int64 ref)) = var_6.mem_0
    let (var_29: Env11) = var_6.mem_1
    let (var_30: (int64 ref)) = var_11.mem_0
    let (var_31: Env11) = var_11.mem_1
    let (var_32: (int64 ref)) = var_14.mem_0
    let (var_33: Env11) = var_14.mem_1
    let (var_34: (int64 ref)) = var_15.mem_0
    let (var_35: Env11) = var_15.mem_1
    let (var_36: (uint64 ref)) = var_1.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    let (var_38: (uint64 ref)) = var_3.mem_0
    let (var_39: uint64) = method_5((var_38: (uint64 ref)))
    let (var_40: (uint64 ref)) = var_5.mem_0
    let (var_41: uint64) = method_5((var_40: (uint64 ref)))
    let (var_42: (uint64 ref)) = var_29.mem_0
    let (var_43: uint64) = method_5((var_42: (uint64 ref)))
    let (var_44: (uint64 ref)) = var_8.mem_0
    let (var_45: uint64) = method_5((var_44: (uint64 ref)))
    let (var_46: (uint64 ref)) = var_10.mem_0
    let (var_47: uint64) = method_5((var_46: (uint64 ref)))
    let (var_48: (uint64 ref)) = var_31.mem_0
    let (var_49: uint64) = method_5((var_48: (uint64 ref)))
    let (var_50: (uint64 ref)) = var_13.mem_0
    let (var_51: uint64) = method_5((var_50: (uint64 ref)))
    let (var_52: (uint64 ref)) = var_33.mem_0
    let (var_53: uint64) = method_5((var_52: (uint64 ref)))
    let (var_54: (uint64 ref)) = var_35.mem_0
    let (var_55: uint64) = method_5((var_54: (uint64 ref)))
    method_122((var_23: ManagedCuda.CudaContext), (var_37: uint64), (var_39: uint64), (var_41: uint64), (var_43: uint64), (var_45: uint64), (var_47: uint64), (var_49: uint64), (var_51: uint64), (var_53: uint64), (var_55: uint64), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: Env9))
and method_144((var_0: EnvStack18), (var_1: (int64 ref)), (var_2: Env11), (var_3: (int64 ref)), (var_4: Env11), (var_5: EnvStack13), (var_6: (int64 ref)), (var_7: Env11), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: (uint64 ref)), (var_11: uint64), (var_12: EnvStack1), (var_13: EnvStack3), (var_14: ManagedCuda.CudaContext), (var_15: EnvStack5), (var_16: EnvStack7), (var_17: ManagedCuda.BasicTypes.CUmodule), (var_18: (int64 ref)), (var_19: Env9)): unit =
    method_74((var_3: (int64 ref)), (var_4: Env11), (var_0: EnvStack18), (var_5: EnvStack13), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_18: (int64 ref)), (var_19: Env9))
and method_116((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64), (var_9: uint64), (var_10: uint64), (var_11: uint64), (var_12: uint64), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env9)): unit =
    // Cuda join point
    // method_117((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64), (var_9: uint64), (var_10: uint64), (var_11: uint64), (var_12: uint64))
    let (var_16: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_117", var_13, var_0)
    let (var_17: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_16.set_GridDimensions(var_17)
    let (var_18: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_16.set_BlockDimensions(var_18)
    let (var_19: EnvHeap8) = var_15.mem_0
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_24((var_19: EnvHeap8))
    let (var_22: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6; var_7; var_8; var_9; var_10; var_11; var_12|]: (System.Object [])
    var_16.RunAsync(var_20, var_22)
and method_122((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64), (var_9: uint64), (var_10: uint64), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env9)): unit =
    // Cuda join point
    // method_123((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: uint64), (var_6: uint64), (var_7: uint64), (var_8: uint64), (var_9: uint64), (var_10: uint64))
    let (var_14: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_123", var_11, var_0)
    let (var_15: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
    var_14.set_GridDimensions(var_15)
    let (var_16: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 32u, 1u)
    var_14.set_BlockDimensions(var_16)
    let (var_17: EnvHeap8) = var_13.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUstream) = method_24((var_17: EnvHeap8))
    let (var_20: (System.Object [])) = [|var_1; var_2; var_3; var_4; var_5; var_6; var_7; var_8; var_9; var_10|]: (System.Object [])
    var_14.RunAsync(var_18, var_20)
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
let (var_41: EnvStack1) = EnvStack1((var_40: ResizeArray<Env0>))
let (var_42: ResizeArray<Env2>) = ResizeArray<Env2>()
let (var_43: EnvStack3) = EnvStack3((var_42: ResizeArray<Env2>))
method_1((var_41: EnvStack1), (var_39: (uint64 ref)), (var_35: uint64), (var_43: EnvStack3))
let (var_44: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_45: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_44)
let (var_46: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_47: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_48: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_46, var_47)
let (var_57: ResizeArray<Env4>) = ResizeArray<Env4>()
let (var_58: EnvStack5) = EnvStack5((var_57: ResizeArray<Env4>))
let (var_70: ResizeArray<Env6>) = ResizeArray<Env6>()
let (var_71: EnvStack7) = EnvStack7((var_70: ResizeArray<Env6>))
let (var_72: (bool ref)) = (ref true)
let (var_73: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_74: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_75: EnvHeap8) = ({mem_0 = (var_74: ManagedCuda.CudaEvent); mem_1 = (var_72: (bool ref)); mem_2 = (var_73: ManagedCuda.CudaStream)} : EnvHeap8)
let (var_76: Env6) = method_7((var_75: EnvHeap8), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_77: (int64 ref)) = var_76.mem_0
let (var_78: Env9) = var_76.mem_1
let (var_80: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_81: int64) = var_80.LongLength
let (var_82: bool) = (var_81 >= 0L)
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_88: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_81))
let (var_89: int64) = 0L
method_9((var_88: (uint8 [])), (var_80: (char [])), (var_81: int64), (var_89: int64))
let (var_90: int64) = var_88.LongLength
let (var_91: bool) = (var_90 > 0L)
let (var_92: bool) = (var_91 = false)
if var_92 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_93: bool) = (var_90 = 1115394L)
let (var_94: bool) = (var_93 = false)
if var_94 then
    (failwith "The dimensions must match.")
else
    ()
let (var_95: int64) = 1115394L
let (var_96: int64) = 0L
let (var_97: int64) = 1L
let (var_98: Env10) = method_10((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_95: int64), (var_88: (uint8 [])), (var_96: int64), (var_97: int64))
let (var_99: Env4) = var_98.mem_0
let (var_100: (int64 ref)) = var_99.mem_0
let (var_101: Env11) = var_99.mem_1
let (var_102: (uint64 ref)) = var_101.mem_0
let (var_103: uint64) = method_5((var_102: (uint64 ref)))
let (var_104: EnvStack12) = method_17((var_103: uint64), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_105: (int64 ref)) = var_104.mem_0
let (var_106: Env11) = var_104.mem_1
let (var_107: EnvStack13) = method_25((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_108: (int64 ref)) = var_107.mem_0
let (var_109: Env11) = var_107.mem_1
let (var_110: EnvStack13) = method_28((var_108: (int64 ref)), (var_109: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_111: EnvStack13) = method_25((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_112: (int64 ref)) = var_111.mem_0
let (var_113: Env11) = var_111.mem_1
let (var_114: EnvStack13) = method_28((var_112: (int64 ref)), (var_113: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_115: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_116: (int64 ref)) = var_115.mem_0
let (var_117: Env11) = var_115.mem_1
method_31((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_116: (int64 ref)), (var_117: Env11))
let (var_118: EnvStack14) = method_35((var_116: (int64 ref)), (var_117: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_119: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_120: (int64 ref)) = var_119.mem_0
let (var_121: Env11) = var_119.mem_1
method_37((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_120: (int64 ref)), (var_121: Env11))
let (var_122: EnvStack14) = method_35((var_120: (int64 ref)), (var_121: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_123: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_124: (int64 ref)) = var_123.mem_0
let (var_125: Env11) = var_123.mem_1
method_37((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_124: (int64 ref)), (var_125: Env11))
let (var_126: EnvStack14) = method_35((var_124: (int64 ref)), (var_125: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_127: EnvStack14) = method_38((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_128: EnvStack14) = method_39((var_127: EnvStack14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_129: EnvHeap15) = ({mem_0 = (var_118: EnvStack14); mem_1 = (var_116: (int64 ref)); mem_2 = (var_117: Env11); mem_3 = (var_122: EnvStack14); mem_4 = (var_120: (int64 ref)); mem_5 = (var_121: Env11); mem_6 = (var_126: EnvStack14); mem_7 = (var_124: (int64 ref)); mem_8 = (var_125: Env11); mem_9 = (var_128: EnvStack14); mem_10 = (var_127: EnvStack14); mem_11 = (var_110: EnvStack13); mem_12 = (var_108: (int64 ref)); mem_13 = (var_109: Env11); mem_14 = (var_114: EnvStack13); mem_15 = (var_112: (int64 ref)); mem_16 = (var_113: Env11)} : EnvHeap15)
let (var_130: (bool ref)) = (ref true)
let (var_131: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_132: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_133: EnvHeap8) = ({mem_0 = (var_132: ManagedCuda.CudaEvent); mem_1 = (var_130: (bool ref)); mem_2 = (var_131: ManagedCuda.CudaStream)} : EnvHeap8)
let (var_134: Env6) = method_40((var_133: EnvHeap8), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_135: (int64 ref)) = var_134.mem_0
let (var_136: Env9) = var_134.mem_1
let (var_137: EnvStack13) = method_25((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_138: (int64 ref)) = var_137.mem_0
let (var_139: Env11) = var_137.mem_1
let (var_140: EnvStack13) = method_28((var_138: (int64 ref)), (var_139: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_141: EnvStack13) = method_25((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_142: (int64 ref)) = var_141.mem_0
let (var_143: Env11) = var_141.mem_1
let (var_144: EnvStack13) = method_28((var_142: (int64 ref)), (var_143: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_145: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_146: (int64 ref)) = var_145.mem_0
let (var_147: Env11) = var_145.mem_1
method_31((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_146: (int64 ref)), (var_147: Env11))
let (var_148: EnvStack14) = method_35((var_146: (int64 ref)), (var_147: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_149: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_150: (int64 ref)) = var_149.mem_0
let (var_151: Env11) = var_149.mem_1
method_37((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_150: (int64 ref)), (var_151: Env11))
let (var_152: EnvStack14) = method_35((var_150: (int64 ref)), (var_151: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_153: Env4) = method_30((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_154: (int64 ref)) = var_153.mem_0
let (var_155: Env11) = var_153.mem_1
method_37((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_154: (int64 ref)), (var_155: Env11))
let (var_156: EnvStack14) = method_35((var_154: (int64 ref)), (var_155: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_157: EnvStack14) = method_38((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_158: EnvStack14) = method_39((var_157: EnvStack14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_159: EnvHeap15) = ({mem_0 = (var_148: EnvStack14); mem_1 = (var_146: (int64 ref)); mem_2 = (var_147: Env11); mem_3 = (var_152: EnvStack14); mem_4 = (var_150: (int64 ref)); mem_5 = (var_151: Env11); mem_6 = (var_156: EnvStack14); mem_7 = (var_154: (int64 ref)); mem_8 = (var_155: Env11); mem_9 = (var_158: EnvStack14); mem_10 = (var_157: EnvStack14); mem_11 = (var_140: EnvStack13); mem_12 = (var_138: (int64 ref)); mem_13 = (var_139: Env11); mem_14 = (var_144: EnvStack13); mem_15 = (var_142: (int64 ref)); mem_16 = (var_143: Env11)} : EnvHeap15)
let (var_160: (bool ref)) = (ref true)
let (var_161: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_162: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_163: EnvHeap8) = ({mem_0 = (var_162: ManagedCuda.CudaEvent); mem_1 = (var_160: (bool ref)); mem_2 = (var_161: ManagedCuda.CudaStream)} : EnvHeap8)
let (var_164: Env6) = method_40((var_163: EnvHeap8), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_165: (int64 ref)) = var_164.mem_0
let (var_166: Env9) = var_164.mem_1
let (var_167: EnvStack13) = method_25((var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_168: (int64 ref)) = var_167.mem_0
let (var_169: Env11) = var_167.mem_1
let (var_170: EnvStack13) = method_28((var_168: (int64 ref)), (var_169: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_171: EnvStack14) = method_38((var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_172: EnvStack14) = method_39((var_171: EnvStack14), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_173: (bool ref)) = (ref true)
let (var_174: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_175: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_176: EnvHeap8) = ({mem_0 = (var_175: ManagedCuda.CudaEvent); mem_1 = (var_173: (bool ref)); mem_2 = (var_174: ManagedCuda.CudaStream)} : EnvHeap8)
let (var_177: Env6) = method_40((var_176: EnvHeap8), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_178: (int64 ref)) = var_177.mem_0
let (var_179: Env9) = var_177.mem_1
let (var_180: (bool ref)) = (ref true)
let (var_181: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_182: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_183: EnvHeap8) = ({mem_0 = (var_182: ManagedCuda.CudaEvent); mem_1 = (var_180: (bool ref)); mem_2 = (var_181: ManagedCuda.CudaStream)} : EnvHeap8)
let (var_184: Env6) = method_40((var_183: EnvHeap8), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9))
let (var_185: (int64 ref)) = var_184.mem_0
let (var_186: Env9) = var_184.mem_1
let (var_187: int64) = 0L
method_41((var_105: (int64 ref)), (var_106: Env11), (var_185: (int64 ref)), (var_186: Env9), (var_178: (int64 ref)), (var_179: Env9), (var_165: (int64 ref)), (var_166: Env9), (var_135: (int64 ref)), (var_136: Env9), (var_129: EnvHeap15), (var_159: EnvHeap15), (var_172: EnvStack14), (var_171: EnvStack14), (var_170: EnvStack13), (var_168: (int64 ref)), (var_169: Env11), (var_48: ManagedCuda.CudaBlas.CudaBlas), (var_45: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_41: EnvStack1), (var_43: EnvStack3), (var_1: ManagedCuda.CudaContext), (var_58: EnvStack5), (var_71: EnvStack7), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_77: (int64 ref)), (var_78: Env9), (var_187: int64))
method_148((var_71: EnvStack7))
method_130((var_58: EnvStack5))
var_48.Dispose()
var_45.Dispose()
let (var_188: uint64) = method_5((var_39: (uint64 ref)))
let (var_189: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_188)
let (var_190: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_189)
var_1.FreeMemory(var_190)
var_39 := 0UL
var_1.Dispose()

