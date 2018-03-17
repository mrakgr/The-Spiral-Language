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
    __global__ void method_81(float * var_0, float * var_1);
    __global__ void method_84(float * var_0, float * var_1);
    __global__ void method_44(float * var_0, float * var_1, float * var_2);
    __global__ void method_69(float * var_0, float * var_1, float * var_2);
    __global__ void method_98(long long int * var_0, long long int * var_1);
    __global__ void method_50(float * var_0, float * var_1);
    __global__ void method_92(float * var_0, float * var_1, long long int * var_2);
    __global__ void method_56(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_61(float * var_0, float * var_1);
    __global__ void method_75(float * var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_45(long long int * var_0);
    __device__ char method_85(long long int * var_0);
    __device__ char method_46(long long int * var_0);
    __device__ char method_70(long long int * var_0, float * var_1);
    __device__ char method_99(long long int * var_0, long long int * var_1);
    __device__ char method_51(long long int * var_0);
    __device__ char method_93(long long int * var_0, float * var_1, float * var_2);
    __device__ Tuple0 method_94(Tuple0 var_0, Tuple0 var_1);
    __device__ char method_62(long long int * var_0, float * var_1);
    __device__ char method_63(long long int * var_0, float * var_1);
    __device__ char method_64(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_81(float * var_0, float * var_1) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_84(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_85(var_6)) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 7936);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_44(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_45(var_7)) {
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
            while (method_46(var_18)) {
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
    __global__ void method_69(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_70(var_8, var_9)) {
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
    __global__ void method_98(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_99(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 128);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_10];
            long long int var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 128);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = cub::BlockReduce<long long int,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_22 = threadIdx.x;
        char var_23 = (var_22 == 0);
        if (var_23) {
            long long int var_24 = blockIdx.x;
            char var_25 = (var_24 >= 0);
            char var_27;
            if (var_25) {
                var_27 = (var_24 < 1);
            } else {
                var_27 = 0;
            }
            char var_28 = (var_27 == 0);
            if (var_28) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_24] = var_21;
        } else {
        }
    }
    __global__ void method_50(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_51(var_6)) {
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
    __global__ void method_92(float * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_46(var_6)) {
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
            while (method_93(var_23, var_24, var_25)) {
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
            FunPointer1 var_47 = method_94;
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
                long long int var_56 = var_2[var_8];
                long long int var_57 = ((long long int) (var_50));
                var_2[var_8] = var_57;
            } else {
            }
            long long int var_58 = (var_8 + 64);
            var_6[0] = var_58;
        }
        long long int var_59 = var_6[0];
    }
    __global__ void method_56(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_51(var_8)) {
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
    __global__ void method_61(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_45(var_6)) {
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
            while (method_62(var_21, var_22)) {
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
    __global__ void method_75(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_51(var_8)) {
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
            float var_18 = var_1[var_10];
            float var_19 = var_2[var_10];
            float var_20 = var_3[var_10];
            float var_21 = var_0[0];
            float var_22 = (1 - var_18);
            float var_23 = log(var_22);
            float var_24 = log(var_18);
            float var_25 = (var_23 - var_24);
            float var_26 = (var_25 / 128);
            float var_27 = (var_20 + var_26);
            var_3[var_10] = var_27;
            long long int var_28 = (var_10 + 1280);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __device__ char method_45(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_85(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 7840);
    }
    __device__ char method_46(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_70(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1280);
    }
    __device__ char method_99(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_51(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1280);
    }
    __device__ char method_93(long long int * var_0, float * var_1, float * var_2) {
        long long int var_3 = var_0[0];
        float var_4 = var_1[0];
        float var_5 = var_2[0];
        return (var_3 < 10);
    }
    __device__ Tuple0 method_94(Tuple0 var_0, Tuple0 var_1) {
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
    __device__ char method_62(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
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
    val mem_0: Env10
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
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
and Env8 =
    struct
    val mem_0: Env2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack9 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env10 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack11 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple12 =
    struct
    val mem_0: float
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvHeap13 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: ResizeArray<Env0>
    mem_3: ResizeArray<Env1>
    }
and EnvStack14 =
    struct
    val mem_0: EnvStack15
    val mem_1: (int64 ref)
    val mem_2: Env10
    val mem_3: (unit -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvStack15 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack16 =
    struct
    val mem_0: Env17
    val mem_1: (unit -> unit)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env17 =
    struct
    val mem_0: Env18
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env18 =
    struct
    val mem_0: Env8
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack19 =
    struct
    val mem_0: Env20
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env20 =
    struct
    val mem_0: Env21
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env21 =
    struct
    val mem_0: Env22
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env22 =
    struct
    val mem_0: Env2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env23 =
    struct
    val mem_0: Env17
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack24 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env10
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env25 =
    struct
    val mem_0: Env20
    new(arg_mem_0) = {mem_0 = arg_mem_0}
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
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64), (var_13: (float32 [])), (var_14: int64), (var_15: int64), (var_16: int64)): Env8 =
    let (var_17: int64) = (var_12 * var_15)
    let (var_18: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_19: int64) = var_18.AddrOfPinnedObject().ToInt64()
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: int64) = (var_14 * 4L)
    let (var_22: uint64) = (uint64 var_21)
    let (var_23: uint64) = (var_22 + var_20)
    let (var_24: Env2) = method_18((var_17: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: Env10) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: int64) = (var_17 * 4L)
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_35: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_31, var_33, var_34)
    if var_35 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_35)
    var_18.Free()
    (Env8((Env2(var_25, var_26))))
and method_24((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): EnvStack9 =
    let (var_12: Env2) = method_25((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env10) = var_12.mem_1
    method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_13: (int64 ref)), (var_14: Env10), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    EnvStack9((var_13: (int64 ref)), (var_14: Env10))
and method_28((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack9 =
    let (var_14: Env2) = method_25((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env10) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_29((var_15: (int64 ref)), (var_16: Env10), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack9((var_15: (int64 ref)), (var_16: Env10))
and method_30((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): EnvStack11 =
    let (var_12: Env2) = method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_13: (int64 ref)) = var_12.mem_0
    let (var_14: Env10) = var_12.mem_1
    let (var_15: (bool ref)) = var_11.mem_0
    let (var_16: ManagedCuda.CudaStream) = var_11.mem_1
    let (var_17: ManagedCuda.BasicTypes.CUstream) = method_27((var_15: (bool ref)), (var_16: ManagedCuda.CudaStream))
    method_32((var_13: (int64 ref)), (var_14: Env10), (var_6: ManagedCuda.CudaContext), (var_17: ManagedCuda.BasicTypes.CUstream))
    EnvStack11((var_13: (int64 ref)), (var_14: Env10))
and method_33((var_0: EnvStack11), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): EnvStack11 =
    let (var_13: (int64 ref)) = var_0.mem_0
    let (var_14: Env10) = var_0.mem_1
    let (var_15: Env2) = method_31((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env10) = var_15.mem_1
    let (var_18: (bool ref)) = var_12.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_12.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_27((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
    method_32((var_16: (int64 ref)), (var_17: Env10), (var_7: ManagedCuda.CudaContext), (var_20: ManagedCuda.BasicTypes.CUstream))
    EnvStack11((var_16: (int64 ref)), (var_17: Env10))
and method_34((var_0: EnvStack11), (var_1: EnvStack11), (var_2: EnvStack9), (var_3: (int64 ref)), (var_4: Env10), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4), (var_17: Env2), (var_18: Env2), (var_19: Env2), (var_20: Env2), (var_21: int64)): unit =
    let (var_22: bool) = (var_21 < 10L)
    if var_22 then
        let (var_23: int64) = 0L
        let (var_24: float) = 0.000000
        let (var_25: int64) = 0L
        let (var_26: float) = method_35((var_19: Env2), (var_20: Env2), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4), (var_23: int64), (var_24: float), (var_0: EnvStack11), (var_1: EnvStack11), (var_2: EnvStack9), (var_3: (int64 ref)), (var_4: Env10), (var_25: int64))
        let (var_27: string) = System.String.Format("Training: {0}",var_26)
        let (var_28: string) = System.String.Format("{0}",var_27)
        System.Console.WriteLine(var_28)
        if (System.Double.IsNaN var_26) then
            System.Console.WriteLine("Training diverged. Aborting...")
        else
            let (var_29: int64) = 0L
            let (var_30: float) = 0.000000
            let (var_31: int64) = 0L
            let (var_32: int64) = 0L
            let (var_33: int64) = 0L
            let (var_34: Tuple12) = method_86((var_17: Env2), (var_18: Env2), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4), (var_31: int64), (var_32: int64), (var_29: int64), (var_30: float), (var_0: EnvStack11), (var_1: EnvStack11), (var_2: EnvStack9), (var_3: (int64 ref)), (var_4: Env10), (var_33: int64))
            let (var_35: float) = var_34.mem_0
            let (var_36: int64) = var_34.mem_1
            let (var_37: int64) = var_34.mem_2
            let (var_38: string) = System.String.Format("Testing: {0}({1}/{2})",var_35,var_36,var_37)
            let (var_39: string) = System.String.Format("{0}",var_38)
            System.Console.WriteLine(var_39)
            let (var_40: int64) = (var_21 + 1L)
            method_34((var_0: EnvStack11), (var_1: EnvStack11), (var_2: EnvStack9), (var_3: (int64 ref)), (var_4: Env10), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4), (var_17: Env2), (var_18: Env2), (var_19: Env2), (var_20: Env2), (var_40: int64))
    else
        ()
and method_101((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_102
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_77((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_78
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2 ((var_0: Env1)): bool =
    let (var_1: Env10) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: Env10) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env1) = var_1.[var_4]
        let (var_7: Env10) = var_6.mem_0
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
and method_18((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): Env2 =
    let (var_13: int64) = (var_0 * 4L)
    let (var_14: EnvHeap13) = ({mem_0 = (var_3: (uint64 ref)); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env0>); mem_3 = (var_6: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_14: EnvHeap13), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_13: int64))
and method_25((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 31360L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_26((var_0: ManagedCuda.CudaRand.CudaRandDevice), (var_1: (int64 ref)), (var_2: Env10), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): unit =
    let (var_14: (uint64 ref)) = var_2.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    var_0.SetStream(var_19)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    var_0.GenerateNormal32(var_21, var_16, 0.000000f, 0.050189f)
and method_27((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_29((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 40L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_32((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_35((var_0: Env2), (var_1: Env2), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: float), (var_16: EnvStack11), (var_17: EnvStack11), (var_18: EnvStack9), (var_19: (int64 ref)), (var_20: Env10), (var_21: int64)): float =
    let (var_22: bool) = (var_21 < 468L)
    if var_22 then
        let (var_23: bool) = (var_21 >= 0L)
        let (var_24: bool) = (var_23 = false)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (var_21 * 100352L)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_26: int64) = (var_21 * 1280L)
        let (var_27: EnvHeap13) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap13)
        let (var_28: (uint64 ref)) = var_27.mem_0
        let (var_29: uint64) = var_27.mem_1
        let (var_30: ResizeArray<Env0>) = var_27.mem_2
        let (var_31: ResizeArray<Env1>) = var_27.mem_3
        method_1((var_30: ResizeArray<Env0>), (var_28: (uint64 ref)), (var_29: uint64), (var_31: ResizeArray<Env1>))
        let (var_35: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_36: EnvStack14) = method_36((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_35: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_0: Env2), (var_25: int64), (var_16: EnvStack11), (var_17: EnvStack11), (var_18: EnvStack9), (var_19: (int64 ref)), (var_20: Env10))
        let (var_37: EnvStack15) = var_36.mem_0
        let (var_38: (int64 ref)) = var_36.mem_1
        let (var_39: Env10) = var_36.mem_2
        let (var_40: (unit -> unit)) = var_36.mem_3
        let (var_41: EnvStack16) = method_65((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_35: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_1: Env2), (var_26: int64), (var_37: EnvStack15), (var_38: (int64 ref)), (var_39: Env10))
        let (var_42: Env17) = var_41.mem_0
        let (var_43: (unit -> unit)) = var_41.mem_1
        let (var_44: Env18) = var_42.mem_0
        let (var_45: Env8) = var_44.mem_0
        let (var_46: int64) = var_44.mem_1
        let (var_47: int64) = 1L
        let (var_48: Env2) = var_45.mem_0
        let (var_49: (float32 [])) = method_76((var_47: int64), (var_45: Env8), (var_46: int64))
        let (var_50: float32) = var_49.[int32 0L]
        let (var_51: float) = (float var_50)
        let (var_52: float) = (var_15 + var_51)
        let (var_53: int64) = (var_14 + 1L)
        if (System.Double.IsNaN var_52) then
            method_77((var_35: ResizeArray<Env2>))
            // Done with the net...
            let (var_54: float) = (float var_53)
            (var_52 / var_54)
        else
            var_43()
            var_40()
            let (var_56: (int64 ref)) = var_17.mem_0
            let (var_57: Env10) = var_17.mem_1
            method_79((var_17: EnvStack11), (var_16: EnvStack11), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_35: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4))
            method_82((var_19: (int64 ref)), (var_20: Env10), (var_18: EnvStack9), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_35: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4))
            method_77((var_35: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_58: int64) = (var_21 + 1L)
            method_35((var_0: Env2), (var_1: Env2), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_53: int64), (var_52: float), (var_16: EnvStack11), (var_17: EnvStack11), (var_18: EnvStack9), (var_19: (int64 ref)), (var_20: Env10), (var_58: int64))
    else
        let (var_61: float) = (float var_14)
        (var_15 / var_61)
and method_86((var_0: Env2), (var_1: Env2), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: float), (var_18: EnvStack11), (var_19: EnvStack11), (var_20: EnvStack9), (var_21: (int64 ref)), (var_22: Env10), (var_23: int64)): Tuple12 =
    let (var_24: bool) = (var_23 < 78L)
    if var_24 then
        let (var_25: bool) = (var_23 >= 0L)
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_27: int64) = (var_23 * 100352L)
        if var_26 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_28: int64) = (var_23 * 1280L)
        let (var_29: EnvHeap13) = ({mem_0 = (var_4: (uint64 ref)); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env0>); mem_3 = (var_7: ResizeArray<Env1>)} : EnvHeap13)
        let (var_30: (uint64 ref)) = var_29.mem_0
        let (var_31: uint64) = var_29.mem_1
        let (var_32: ResizeArray<Env0>) = var_29.mem_2
        let (var_33: ResizeArray<Env1>) = var_29.mem_3
        method_1((var_32: ResizeArray<Env0>), (var_30: (uint64 ref)), (var_31: uint64), (var_33: ResizeArray<Env1>))
        let (var_37: ResizeArray<Env2>) = ResizeArray<Env2>()
        // Executing the net...
        let (var_38: EnvStack14) = method_36((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_37: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_0: Env2), (var_27: int64), (var_18: EnvStack11), (var_19: EnvStack11), (var_20: EnvStack9), (var_21: (int64 ref)), (var_22: Env10))
        let (var_39: EnvStack15) = var_38.mem_0
        let (var_40: (int64 ref)) = var_38.mem_1
        let (var_41: Env10) = var_38.mem_2
        let (var_42: (unit -> unit)) = var_38.mem_3
        let (var_43: EnvStack16) = method_65((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_37: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_1: Env2), (var_28: int64), (var_39: EnvStack15), (var_40: (int64 ref)), (var_41: Env10))
        let (var_44: Env17) = var_43.mem_0
        let (var_45: (unit -> unit)) = var_43.mem_1
        let (var_46: EnvStack19) = method_87((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_37: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_1: Env2), (var_28: int64), (var_39: EnvStack15), (var_40: (int64 ref)), (var_41: Env10))
        let (var_47: Env20) = var_46.mem_0
        let (var_48: Env18) = var_44.mem_0
        let (var_49: Env8) = var_48.mem_0
        let (var_50: int64) = var_48.mem_1
        let (var_51: int64) = 1L
        let (var_52: Env2) = var_49.mem_0
        let (var_53: (float32 [])) = method_76((var_51: int64), (var_49: Env8), (var_50: int64))
        let (var_54: float32) = var_53.[int32 0L]
        let (var_55: float) = (float var_54)
        let (var_56: float) = (var_17 + var_55)
        let (var_57: Env21) = var_47.mem_0
        let (var_58: Env22) = var_57.mem_0
        let (var_59: int64) = var_57.mem_1
        let (var_60: int64) = 1L
        let (var_61: Env2) = var_58.mem_0
        let (var_62: (int64 [])) = method_100((var_60: int64), (var_58: Env22), (var_59: int64))
        let (var_63: int64) = var_62.[int32 0L]
        let (var_64: int64) = (var_14 + var_63)
        let (var_65: int64) = (var_15 + 128L)
        let (var_66: int64) = (var_16 + 1L)
        if (System.Double.IsNaN var_56) then
            method_77((var_37: ResizeArray<Env2>))
            // Done with the net...
            let (var_67: float) = (float var_66)
            let (var_68: float) = (var_56 / var_67)
            Tuple12(var_68, var_64, var_65)
        else
            method_77((var_37: ResizeArray<Env2>))
            // Executing the next loop...
            let (var_69: int64) = (var_23 + 1L)
            method_86((var_0: Env2), (var_1: Env2), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4), (var_64: int64), (var_65: int64), (var_66: int64), (var_56: float), (var_18: EnvStack11), (var_19: EnvStack11), (var_20: EnvStack9), (var_21: (int64 ref)), (var_22: Env10), (var_69: int64))
    else
        let (var_72: float) = (float var_16)
        let (var_73: float) = (var_17 / var_72)
        Tuple12(var_73, var_14, var_15)
and method_102 ((var_0: Env3)): unit =
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
and method_78 ((var_0: Env2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env10) = var_0.mem_1
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
    let (var_2: Env10) = var_0.mem_0
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
and method_19((var_0: EnvHeap13), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_13: int64)): Env2 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: ResizeArray<Env0>) = var_0.mem_2
    let (var_17: ResizeArray<Env1>) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env10) = method_20((var_16: ResizeArray<Env0>), (var_14: (uint64 ref)), (var_15: uint64), (var_17: ResizeArray<Env1>), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_23((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: ResizeArray<Env2>))
    (Env2(var_24, (Env10(var_23))))
and method_36((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: Env2), (var_13: int64), (var_14: EnvStack11), (var_15: EnvStack11), (var_16: EnvStack9), (var_17: (int64 ref)), (var_18: Env10)): EnvStack14 =
    let (var_19: EnvStack15) = method_37((var_12: Env2), (var_13: int64), (var_17: (int64 ref)), (var_18: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_20: (int64 ref)) = var_19.mem_0
    let (var_21: Env10) = var_19.mem_1
    let (var_22: EnvStack15) = method_40((var_20: (int64 ref)), (var_21: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    method_42((var_15: EnvStack11), (var_20: (int64 ref)), (var_21: Env10), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_10: (int64 ref)), (var_11: Env4))
    let (var_23: EnvStack15) = method_47((var_20: (int64 ref)), (var_21: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env10) = var_23.mem_1
    let (var_26: EnvStack15) = method_40((var_24: (int64 ref)), (var_25: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_27: (unit -> unit)) = method_52((var_22: EnvStack15), (var_20: (int64 ref)), (var_21: Env10), (var_14: EnvStack11), (var_15: EnvStack11), (var_12: Env2), (var_13: int64), (var_16: EnvStack9), (var_17: (int64 ref)), (var_18: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_26: EnvStack15), (var_24: (int64 ref)), (var_25: Env10))
    EnvStack14((var_26: EnvStack15), (var_24: (int64 ref)), (var_25: Env10), (var_27: (unit -> unit)))
and method_65((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: Env2), (var_13: int64), (var_14: EnvStack15), (var_15: (int64 ref)), (var_16: Env10)): EnvStack16 =
    let (var_17: Env23) = method_66((var_12: Env2), (var_13: int64), (var_15: (int64 ref)), (var_16: Env10), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_10: (int64 ref)), (var_11: Env4))
    let (var_18: Env17) = var_17.mem_0
    let (var_19: (unit -> unit)) = method_71((var_14: EnvStack15), (var_18: Env17), (var_12: Env2), (var_13: int64), (var_15: (int64 ref)), (var_16: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    EnvStack16((var_18: Env17), (var_19: (unit -> unit)))
and method_76((var_0: int64), (var_1: Env8), (var_2: int64)): (float32 []) =
    let (var_3: Env2) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env10) = var_3.mem_1
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
and method_79((var_0: EnvStack11), (var_1: EnvStack11), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: ResizeArray<Env0>), (var_8: ResizeArray<Env1>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<Env2>), (var_11: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env10) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env10) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_80((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
and method_82((var_0: (int64 ref)), (var_1: Env10), (var_2: EnvStack9), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: (int64 ref)), (var_14: Env4)): unit =
    let (var_15: (int64 ref)) = var_2.mem_0
    let (var_16: Env10) = var_2.mem_1
    let (var_17: (uint64 ref)) = var_1.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_16.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_83((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env4))
and method_87((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: Env2), (var_13: int64), (var_14: EnvStack15), (var_15: (int64 ref)), (var_16: Env10)): EnvStack19 =
    let (var_17: EnvStack24) = method_88((var_12: Env2), (var_13: int64), (var_15: (int64 ref)), (var_16: Env10), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env10) = var_17.mem_1
    let (var_20: Env25) = method_95((var_18: (int64 ref)), (var_19: Env10), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_10: (int64 ref)), (var_11: Env4))
    let (var_21: Env20) = var_20.mem_0
    EnvStack19((var_21: Env20))
and method_100((var_0: int64), (var_1: Env22), (var_2: int64)): (int64 []) =
    let (var_3: Env2) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: Env10) = var_3.mem_1
    let (var_6: (uint64 ref)) = var_5.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: int64) = (var_2 * 8L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_0))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_0 * 8L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_20((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): Env10 =
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
            (Env1((Env10(var_14)), var_4))
        else
            let (var_16: (Env0 -> (Env0 -> int32))) = method_21
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
                (Env1((Env10(var_24)), var_4))
            else
                method_1((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_26: (Env0 -> (Env0 -> int32))) = method_21
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
                    (Env1((Env10(var_34)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_39: Env10) = var_38.mem_0
    let (var_40: uint64) = var_38.mem_1
    var_3.Add((Env1(var_39, var_40)))
    var_39
and method_23((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, (Env10(var_1)))))
and method_37((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4)): EnvStack15 =
    let (var_16: Env2) = method_38((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env10) = var_16.mem_1
    method_39((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_17: (int64 ref)), (var_18: Env10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_14: (int64 ref)), (var_15: Env4))
    EnvStack15((var_17: (int64 ref)), (var_18: Env10))
and method_40((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack15 =
    let (var_14: Env2) = method_38((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_15: (int64 ref)) = var_14.mem_0
    let (var_16: Env10) = var_14.mem_1
    let (var_17: (bool ref)) = var_13.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_13.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_27((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
    method_41((var_15: (int64 ref)), (var_16: Env10), (var_8: ManagedCuda.CudaContext), (var_19: ManagedCuda.BasicTypes.CUstream))
    EnvStack15((var_15: (int64 ref)), (var_16: Env10))
and method_42((var_0: EnvStack11), (var_1: (int64 ref)), (var_2: Env10), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: (int64 ref)), (var_14: Env4)): unit =
    let (var_15: (int64 ref)) = var_0.mem_0
    let (var_16: Env10) = var_0.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: uint64) = method_5((var_19: (uint64 ref)))
    method_43((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_21: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env4))
and method_47((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack15 =
    let (var_18: Env2) = method_38((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_19: (int64 ref)) = var_18.mem_0
    let (var_20: Env10) = var_18.mem_1
    method_48((var_0: (int64 ref)), (var_1: Env10), (var_19: (int64 ref)), (var_20: Env10), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4))
    EnvStack15((var_19: (int64 ref)), (var_20: Env10))
and method_52 ((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env10), (var_3: EnvStack11), (var_4: EnvStack11), (var_5: Env2), (var_6: int64), (var_7: EnvStack9), (var_8: (int64 ref)), (var_9: Env10), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: ResizeArray<Env0>), (var_15: ResizeArray<Env1>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<Env2>), (var_18: ResizeArray<Env3>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env4), (var_22: EnvStack15), (var_23: (int64 ref)), (var_24: Env10)) (): unit =
    method_53((var_0: EnvStack15), (var_22: EnvStack15), (var_23: (int64 ref)), (var_24: Env10), (var_1: (int64 ref)), (var_2: Env10), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: ResizeArray<Env0>), (var_15: ResizeArray<Env1>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<Env2>), (var_18: ResizeArray<Env3>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env4))
    method_57((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env10), (var_3: EnvStack11), (var_4: EnvStack11), (var_5: Env2), (var_6: int64), (var_7: EnvStack9), (var_8: (int64 ref)), (var_9: Env10), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: ResizeArray<Env0>), (var_15: ResizeArray<Env1>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<Env2>), (var_18: ResizeArray<Env3>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env4))
and method_66((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: (int64 ref)), (var_15: Env4)): Env23 =
    let (var_16: (int64 ref)) = var_0.mem_0
    let (var_17: Env10) = var_0.mem_1
    let (var_18: (uint64 ref)) = var_17.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: int64) = (var_1 * 4L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_19 + var_21)
    let (var_23: (uint64 ref)) = var_3.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_33: Env2) = method_67((var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
    let (var_34: (int64 ref)) = var_33.mem_0
    let (var_35: Env10) = var_33.mem_1
    let (var_36: (uint64 ref)) = var_35.mem_0
    let (var_37: uint64) = method_5((var_36: (uint64 ref)))
    method_68((var_11: ManagedCuda.CudaContext), (var_22: uint64), (var_24: uint64), (var_37: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
    (Env23((Env17((Env18((Env8((Env2(var_34, var_35)))), 0L))))))
and method_71 ((var_0: EnvStack15), (var_1: Env17), (var_2: Env2), (var_3: int64), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4)) (): unit =
    method_72((var_0: EnvStack15), (var_1: Env17), (var_2: Env2), (var_3: int64), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4))
and method_80((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_81((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_81", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_83((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_84((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_84", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_88((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4)): EnvStack24 =
    let (var_16: Env2) = method_89((var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env10) = var_16.mem_1
    method_90((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_17: (int64 ref)), (var_18: Env10), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_14: (int64 ref)), (var_15: Env4))
    EnvStack24((var_17: (int64 ref)), (var_18: Env10))
and method_95((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: ResizeArray<Env0>), (var_8: ResizeArray<Env1>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<Env2>), (var_11: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4)): Env25 =
    let (var_14: (uint64 ref)) = var_1.mem_0
    let (var_15: uint64) = method_5((var_14: (uint64 ref)))
    let (var_16: Env2) = method_96((var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: ResizeArray<Env0>), (var_8: ResizeArray<Env1>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<Env2>), (var_11: ResizeArray<Env3>), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env10) = var_16.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_97((var_9: ManagedCuda.CudaContext), (var_15: uint64), (var_20: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    (Env25((Env20((Env21((Env22((Env2(var_17, var_18)))), 0L))))))
and method_21 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_22((var_2: uint64))
and method_38((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 5120L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_39((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: (int64 ref)), (var_8: Env4)): unit =
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: (bool ref)) = var_8.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_8.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    var_6.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: (uint64 ref)) = var_3.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (int64 ref)) = var_0.mem_0
    let (var_21: Env10) = var_0.mem_1
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_1 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_26)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: (float32 ref)) = (ref 0.000000f)
    let (var_30: (uint64 ref)) = var_5.mem_0
    let (var_31: uint64) = method_5((var_30: (uint64 ref)))
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_31)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_13, var_14, 10, 128, 784, var_15, var_19, 10, var_28, 784, var_29, var_33, 10)
    if var_34 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_34)
and method_41((var_0: (int64 ref)), (var_1: Env10), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUstream)): unit =
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
    var_2.ClearMemoryAsync(var_7, 0uy, var_8, var_3)
and method_43((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_44((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_44", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_48((var_0: (int64 ref)), (var_1: Env10), (var_2: (int64 ref)), (var_3: Env10), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: (int64 ref)), (var_15: Env4)): unit =
    let (var_16: (uint64 ref)) = var_1.mem_0
    let (var_17: uint64) = method_5((var_16: (uint64 ref)))
    let (var_18: (uint64 ref)) = var_3.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    method_49((var_11: ManagedCuda.CudaContext), (var_17: uint64), (var_19: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
and method_53((var_0: EnvStack15), (var_1: EnvStack15), (var_2: (int64 ref)), (var_3: Env10), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: (int64 ref)) = var_1.mem_0
    let (var_19: Env10) = var_1.mem_1
    method_54((var_4: (int64 ref)), (var_5: Env10), (var_18: (int64 ref)), (var_19: Env10), (var_2: (int64 ref)), (var_3: Env10), (var_0: EnvStack15), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_16: (int64 ref)), (var_17: Env4))
and method_57((var_0: EnvStack15), (var_1: (int64 ref)), (var_2: Env10), (var_3: EnvStack11), (var_4: EnvStack11), (var_5: Env2), (var_6: int64), (var_7: EnvStack9), (var_8: (int64 ref)), (var_9: Env10), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: ResizeArray<Env0>), (var_15: ResizeArray<Env1>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<Env2>), (var_18: ResizeArray<Env3>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: (int64 ref)), (var_21: Env4)): unit =
    method_58((var_5: Env2), (var_6: int64), (var_0: EnvStack15), (var_7: EnvStack9), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_20: (int64 ref)), (var_21: Env4))
    let (var_22: (int64 ref)) = var_3.mem_0
    let (var_23: Env10) = var_3.mem_1
    method_59((var_0: EnvStack15), (var_3: EnvStack11), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: (uint64 ref)), (var_13: uint64), (var_14: ResizeArray<Env0>), (var_15: ResizeArray<Env1>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<Env2>), (var_18: ResizeArray<Env3>), (var_20: (int64 ref)), (var_21: Env4))
and method_67((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 4L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_68((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_69((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_69", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_72((var_0: EnvStack15), (var_1: Env17), (var_2: Env2), (var_3: int64), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: Env18) = var_1.mem_0
    let (var_19: Env8) = var_18.mem_0
    let (var_20: int64) = var_18.mem_1
    let (var_21: Env2) = var_19.mem_0
    let (var_22: (int64 ref)) = var_21.mem_0
    let (var_23: Env10) = var_21.mem_1
    let (var_24: (uint64 ref)) = var_23.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: int64) = (var_20 * 4L)
    let (var_27: uint64) = (uint64 var_26)
    let (var_28: uint64) = (var_25 + var_27)
    method_73((var_28: uint64), (var_2: Env2), (var_3: int64), (var_4: (int64 ref)), (var_5: Env10), (var_0: EnvStack15), (var_15: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_16: (int64 ref)), (var_17: Env4))
and method_89((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 1024L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_90((var_0: Env2), (var_1: int64), (var_2: (int64 ref)), (var_3: Env10), (var_4: (int64 ref)), (var_5: Env10), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: (int64 ref)) = var_0.mem_0
    let (var_19: Env10) = var_0.mem_1
    let (var_20: (uint64 ref)) = var_19.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: int64) = (var_1 * 4L)
    let (var_23: uint64) = (uint64 var_22)
    let (var_24: uint64) = (var_21 + var_23)
    let (var_25: (uint64 ref)) = var_3.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: (uint64 ref)) = var_5.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_91((var_13: ManagedCuda.CudaContext), (var_24: uint64), (var_26: uint64), (var_28: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4))
and method_96((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 8L
    let (var_13: EnvHeap13) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap13)
    method_19((var_13: EnvHeap13), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_97((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_98((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_98", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_22 ((var_1: uint64)) ((var_0: Env0)): int32 =
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
and method_49((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_50((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_50", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_54((var_0: (int64 ref)), (var_1: Env10), (var_2: (int64 ref)), (var_3: Env10), (var_4: (int64 ref)), (var_5: Env10), (var_6: EnvStack15), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: ManagedCuda.CudaBlas.CudaBlas), (var_9: ManagedCuda.CudaRand.CudaRandDevice), (var_10: (uint64 ref)), (var_11: uint64), (var_12: ResizeArray<Env0>), (var_13: ResizeArray<Env1>), (var_14: ManagedCuda.CudaContext), (var_15: ResizeArray<Env2>), (var_16: ResizeArray<Env3>), (var_17: (int64 ref)), (var_18: Env4)): unit =
    let (var_19: (int64 ref)) = var_6.mem_0
    let (var_20: Env10) = var_6.mem_1
    let (var_21: (uint64 ref)) = var_1.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_3.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    let (var_25: (uint64 ref)) = var_5.mem_0
    let (var_26: uint64) = method_5((var_25: (uint64 ref)))
    let (var_27: (uint64 ref)) = var_20.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    method_55((var_14: ManagedCuda.CudaContext), (var_22: uint64), (var_24: uint64), (var_26: uint64), (var_28: uint64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_17: (int64 ref)), (var_18: Env4))
and method_58((var_0: Env2), (var_1: int64), (var_2: EnvStack15), (var_3: EnvStack9), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: (int64 ref)), (var_6: Env4)): unit =
    let (var_7: (int64 ref)) = var_2.mem_0
    let (var_8: Env10) = var_2.mem_1
    let (var_9: (int64 ref)) = var_3.mem_0
    let (var_10: Env10) = var_3.mem_1
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_12: (bool ref)) = var_6.mem_0
    let (var_13: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_14: ManagedCuda.BasicTypes.CUstream) = method_27((var_12: (bool ref)), (var_13: ManagedCuda.CudaStream))
    var_4.set_Stream(var_14)
    let (var_15: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_16: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: (uint64 ref)) = var_8.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (int64 ref)) = var_0.mem_0
    let (var_23: Env10) = var_0.mem_1
    let (var_24: (uint64 ref)) = var_23.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    let (var_26: int64) = (var_1 * 4L)
    let (var_27: uint64) = (uint64 var_26)
    let (var_28: uint64) = (var_25 + var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: (float32 ref)) = (ref 1.000000f)
    let (var_32: (uint64 ref)) = var_10.mem_0
    let (var_33: uint64) = method_5((var_32: (uint64 ref)))
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_33)
    let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_34)
    let (var_36: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_15, var_16, 10, 784, 128, var_17, var_21, 10, var_30, 784, var_31, var_35, 10)
    if var_36 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_36)
and method_59((var_0: EnvStack15), (var_1: EnvStack11), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: (uint64 ref)), (var_6: uint64), (var_7: ResizeArray<Env0>), (var_8: ResizeArray<Env1>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<Env2>), (var_11: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4)): unit =
    let (var_14: (int64 ref)) = var_0.mem_0
    let (var_15: Env10) = var_0.mem_1
    let (var_16: (int64 ref)) = var_1.mem_0
    let (var_17: Env10) = var_1.mem_1
    let (var_18: (uint64 ref)) = var_15.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (uint64 ref)) = var_17.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    method_60((var_9: ManagedCuda.CudaContext), (var_19: uint64), (var_21: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
and method_73((var_0: uint64), (var_1: Env2), (var_2: int64), (var_3: (int64 ref)), (var_4: Env10), (var_5: EnvStack15), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: (uint64 ref)), (var_10: uint64), (var_11: ResizeArray<Env0>), (var_12: ResizeArray<Env1>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<Env2>), (var_15: ResizeArray<Env3>), (var_16: (int64 ref)), (var_17: Env4)): unit =
    let (var_18: (int64 ref)) = var_5.mem_0
    let (var_19: Env10) = var_5.mem_1
    let (var_20: (int64 ref)) = var_1.mem_0
    let (var_21: Env10) = var_1.mem_1
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: int64) = (var_2 * 4L)
    let (var_25: uint64) = (uint64 var_24)
    let (var_26: uint64) = (var_23 + var_25)
    let (var_27: (uint64 ref)) = var_4.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: (uint64 ref)) = var_19.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    method_74((var_13: ManagedCuda.CudaContext), (var_0: uint64), (var_26: uint64), (var_28: uint64), (var_30: uint64), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_16: (int64 ref)), (var_17: Env4))
and method_91((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_92((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_92", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_27((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_55((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env4)): unit =
    // Cuda join point
    // method_56((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_56", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
and method_60((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_61((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_61", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_27((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_74((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (int64 ref)), (var_7: Env4)): unit =
    // Cuda join point
    // method_75((var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: uint64))
    let (var_8: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_75", var_5, var_0)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
    var_8.set_GridDimensions(var_9)
    let (var_10: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_8.set_BlockDimensions(var_10)
    let (var_11: (bool ref)) = var_7.mem_0
    let (var_12: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_13: ManagedCuda.BasicTypes.CUstream) = method_27((var_11: (bool ref)), (var_12: ManagedCuda.CudaStream))
    let (var_15: (System.Object [])) = [|var_1; var_2; var_3; var_4|]: (System.Object [])
    var_8.RunAsync(var_13, var_15)
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
let (var_70: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_71: Tuple5) = method_9((var_70: string))
let (var_72: Tuple6) = var_71.mem_0
let (var_73: (uint8 [])) = var_71.mem_1
let (var_74: int64) = var_72.mem_0
let (var_75: int64) = var_72.mem_1
let (var_76: int64) = var_72.mem_2
let (var_77: bool) = (10000L = var_74)
let (var_81: bool) =
    if var_77 then
        let (var_78: bool) = (28L = var_75)
        if var_78 then
            (28L = var_76)
        else
            false
    else
        false
let (var_82: bool) = (var_81 = false)
if var_82 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_83: int64) = var_73.LongLength
let (var_84: bool) = (var_83 > 0L)
let (var_85: bool) = (var_84 = false)
if var_85 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_86: bool) = (var_83 = 7840000L)
let (var_87: bool) = (var_86 = false)
if var_87 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_91: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_92: int64) = 0L
method_10((var_73: (uint8 [])), (var_91: (float32 [])), (var_92: int64))
let (var_93: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_94: Tuple7) = method_12((var_93: string))
let (var_95: int64) = var_94.mem_0
let (var_96: (uint8 [])) = var_94.mem_1
let (var_97: bool) = (10000L = var_95)
let (var_98: bool) = (var_97 = false)
if var_98 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_102: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_103: int64) = 0L
method_13((var_96: (uint8 [])), (var_102: (float32 [])), (var_103: int64))
let (var_104: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_105: Tuple5) = method_9((var_104: string))
let (var_106: Tuple6) = var_105.mem_0
let (var_107: (uint8 [])) = var_105.mem_1
let (var_108: int64) = var_106.mem_0
let (var_109: int64) = var_106.mem_1
let (var_110: int64) = var_106.mem_2
let (var_111: bool) = (60000L = var_108)
let (var_115: bool) =
    if var_111 then
        let (var_112: bool) = (28L = var_109)
        if var_112 then
            (28L = var_110)
        else
            false
    else
        false
let (var_116: bool) = (var_115 = false)
if var_116 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_117: int64) = var_107.LongLength
let (var_118: bool) = (var_117 > 0L)
let (var_119: bool) = (var_118 = false)
if var_119 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_120: bool) = (var_117 = 47040000L)
let (var_121: bool) = (var_120 = false)
if var_121 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_125: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_126: int64) = 0L
method_15((var_107: (uint8 [])), (var_125: (float32 [])), (var_126: int64))
let (var_127: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_128: Tuple7) = method_12((var_127: string))
let (var_129: int64) = var_128.mem_0
let (var_130: (uint8 [])) = var_128.mem_1
let (var_131: bool) = (60000L = var_129)
let (var_132: bool) = (var_131 = false)
if var_132 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_136: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_137: int64) = 0L
method_16((var_130: (uint8 [])), (var_136: (float32 [])), (var_137: int64))
let (var_138: int64) = 10000L
let (var_139: int64) = 0L
let (var_140: int64) = 784L
let (var_141: int64) = 1L
let (var_142: Env8) = method_17((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_138: int64), (var_91: (float32 [])), (var_139: int64), (var_140: int64), (var_141: int64))
let (var_143: Env2) = var_142.mem_0
let (var_144: int64) = 10000L
let (var_145: int64) = 0L
let (var_146: int64) = 10L
let (var_147: int64) = 1L
let (var_148: Env8) = method_17((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_144: int64), (var_102: (float32 [])), (var_145: int64), (var_146: int64), (var_147: int64))
let (var_149: Env2) = var_148.mem_0
let (var_150: int64) = 60000L
let (var_151: int64) = 0L
let (var_152: int64) = 784L
let (var_153: int64) = 1L
let (var_154: Env8) = method_17((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_150: int64), (var_125: (float32 [])), (var_151: int64), (var_152: int64), (var_153: int64))
let (var_155: Env2) = var_154.mem_0
let (var_156: int64) = 60000L
let (var_157: int64) = 0L
let (var_158: int64) = 10L
let (var_159: int64) = 1L
let (var_160: Env8) = method_17((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_156: int64), (var_136: (float32 [])), (var_157: int64), (var_158: int64), (var_159: int64))
let (var_161: Env2) = var_160.mem_0
let (var_162: EnvStack9) = method_24((var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_163: (int64 ref)) = var_162.mem_0
let (var_164: Env10) = var_162.mem_1
let (var_165: EnvStack9) = method_28((var_163: (int64 ref)), (var_164: Env10), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_166: EnvStack11) = method_30((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_167: EnvStack11) = method_33((var_166: EnvStack11), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_168: int64) = 0L
method_34((var_167: EnvStack11), (var_166: EnvStack11), (var_165: EnvStack9), (var_163: (int64 ref)), (var_164: Env10), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_143: Env2), (var_149: Env2), (var_155: Env2), (var_161: Env2), (var_168: int64))
method_101((var_64: ResizeArray<Env3>))
method_77((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_169: uint64) = method_5((var_39: (uint64 ref)))
let (var_170: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_169)
let (var_171: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_170)
var_1.FreeMemory(var_171)
var_39 := 0UL
var_1.Dispose()

