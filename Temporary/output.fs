module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Env0 {
        long long int mem_0;
    };
    __device__ __forceinline__ Env0 make_Env0(long long int mem_0){
        Env0 tmp;
        tmp.mem_0 = mem_0;
        return tmp;
    }
    struct Env1 {
        long long int mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Env1 make_Env1(long long int mem_0, float mem_1){
        Env1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple4 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple4 make_Tuple4(float mem_0, float mem_1){
        Tuple4 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer2)(float, float);
    struct Env3 {
        long long int mem_0;
        Tuple4 mem_1;
    };
    __device__ __forceinline__ Env3 make_Env3(long long int mem_0, Tuple4 mem_1){
        Env3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple6 {
        Tuple4 mem_0;
        Tuple4 mem_1;
    };
    __device__ __forceinline__ Tuple6 make_Tuple6(Tuple4 mem_0, Tuple4 mem_1){
        Tuple6 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple4(*FunPointer5)(Tuple4, Tuple4);
    __global__ void method_16(long long int var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_19(float * var_0, long long int var_1, float * var_2);
    __global__ void method_20(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5);
    __global__ void method_25(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4);
    __global__ void method_27(long long int var_0, float * var_1, float * var_2);
    __global__ void method_29(float * var_0, float * var_1);
    __global__ void method_31(float * var_0, float * var_1);
    __global__ void method_32(long long int var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_17(Env0 * var_0);
    __device__ char method_18(long long int var_0, Env0 * var_1);
    __device__ char method_21(long long int var_0, Env1 * var_1);
    __device__ float method_22(float var_0, float var_1);
    __device__ char method_28(Env1 * var_0);
    __device__ char method_30(Env0 * var_0);
    __device__ char method_33(Env3 * var_0);
    __device__ Tuple4 method_34(Tuple4 var_0, Tuple4 var_1);
    
    __global__ void method_16(long long int var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = blockDim.y;
        long long int var_11 = (10 * var_7);
        long long int var_12 = (var_4 + var_11);
        Env0 var_13[1];
        var_13[0] = (make_Env0(var_12));
        while (method_17(var_13)) {
            Env0 var_15 = var_13[0];
            long long int var_16 = var_15.mem_0;
            long long int var_17 = (var_16 + 10);
            char var_18 = (var_16 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_16 < 10);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_22 = (var_10 * var_8);
            long long int var_23 = (var_5 + var_22);
            Env0 var_24[1];
            var_24[0] = (make_Env0(var_23));
            while (method_18(var_0, var_24)) {
                Env0 var_26 = var_24[0];
                long long int var_27 = var_26.mem_0;
                long long int var_28 = (var_27 + var_10);
                char var_29 = (var_27 >= 0);
                char var_31;
                if (var_29) {
                    var_31 = (var_27 < var_0);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_27 * 10);
                char var_35;
                if (var_18) {
                    var_35 = (var_16 < 10);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_37 = (var_33 + var_16);
                char var_39;
                if (var_29) {
                    var_39 = (var_27 < var_0);
                } else {
                    var_39 = 0;
                }
                char var_40 = (var_39 == 0);
                if (var_40) {
                    // "Argument out of bounds."
                } else {
                }
                char var_42;
                if (var_18) {
                    var_42 = (var_16 < 10);
                } else {
                    var_42 = 0;
                }
                char var_43 = (var_42 == 0);
                if (var_43) {
                    // "Argument out of bounds."
                } else {
                }
                float var_44 = var_1[var_16];
                float var_45 = var_2[var_37];
                float var_46 = var_3[var_37];
                float var_47 = (var_44 + var_45);
                var_3[var_37] = var_47;
                var_24[0] = (make_Env0(var_28));
            }
            Env0 var_48 = var_24[0];
            long long int var_49 = var_48.mem_0;
            var_13[0] = (make_Env0(var_17));
        }
        Env0 var_50 = var_13[0];
        long long int var_51 = var_50.mem_0;
    }
    __global__ void method_19(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = gridDim.x;
        long long int var_10 = (var_6 * 128);
        long long int var_11 = (var_10 + var_3);
        long long int var_12 = (var_9 * 128);
        Env0 var_13[1];
        var_13[0] = (make_Env0(var_11));
        while (method_18(var_1, var_13)) {
            Env0 var_15 = var_13[0];
            long long int var_16 = var_15.mem_0;
            long long int var_17 = (var_16 + var_12);
            char var_18 = (var_16 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_16 < var_1);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            char var_23;
            if (var_18) {
                var_23 = (var_16 < var_1);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            float var_25 = var_0[var_16];
            float var_26 = var_2[var_16];
            float var_27 = (-var_25);
            float var_28 = exp(var_27);
            float var_29 = (1 + var_28);
            float var_30 = (1 / var_29);
            var_2[var_16] = var_30;
            var_13[0] = (make_Env0(var_17));
        }
        Env0 var_31 = var_13[0];
        long long int var_32 = var_31.mem_0;
    }
    __global__ void method_20(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = gridDim.x;
        long long int var_12 = (var_8 * 128);
        long long int var_13 = (var_12 + var_5);
        long long int var_14 = (var_11 * 128);
        float var_15 = 0;
        Env1 var_16[1];
        var_16[0] = (make_Env1(var_13, var_15));
        while (method_21(var_2, var_16)) {
            Env1 var_18 = var_16[0];
            long long int var_19 = var_18.mem_0;
            float var_20 = var_18.mem_1;
            long long int var_21 = (var_19 + var_14);
            char var_22 = (var_19 >= 0);
            char var_24;
            if (var_22) {
                var_24 = (var_19 < var_2);
            } else {
                var_24 = 0;
            }
            char var_25 = (var_24 == 0);
            if (var_25) {
                // "Argument out of bounds."
            } else {
            }
            float var_26 = var_0[var_19];
            float var_27 = var_1[var_19];
            float var_28 = (var_27 - var_26);
            float var_29 = (var_28 * var_28);
            float var_30 = (var_20 + var_29);
            var_16[0] = (make_Env1(var_21, var_30));
        }
        Env1 var_31 = var_16[0];
        long long int var_32 = var_31.mem_0;
        float var_33 = var_31.mem_1;
        FunPointer2 var_36 = method_22;
        float var_37 = cub::BlockReduce<float,128>().Reduce(var_33, var_36);
        char var_38 = (var_5 == 0);
        if (var_38) {
            char var_39 = (var_8 >= 0);
            char var_41;
            if (var_39) {
                var_41 = (var_8 < var_4);
            } else {
                var_41 = 0;
            }
            char var_42 = (var_41 == 0);
            if (var_42) {
                // "Argument out of bounds."
            } else {
            }
            var_3[var_8] = var_37;
        } else {
        }
    }
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = gridDim.x;
        long long int var_13 = (var_9 * 128);
        long long int var_14 = (var_13 + var_6);
        long long int var_15 = (var_12 * 128);
        Env0 var_16[1];
        var_16[0] = (make_Env0(var_14));
        while (method_18(var_4, var_16)) {
            Env0 var_18 = var_16[0];
            long long int var_19 = var_18.mem_0;
            long long int var_20 = (var_19 + var_15);
            char var_21 = (var_19 >= 0);
            char var_23;
            if (var_21) {
                var_23 = (var_19 < var_4);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            char var_26;
            if (var_21) {
                var_26 = (var_19 < var_4);
            } else {
                var_26 = 0;
            }
            char var_27 = (var_26 == 0);
            if (var_27) {
                // "Argument out of bounds."
            } else {
            }
            float var_28 = var_2[var_19];
            float var_29 = var_3[var_19];
            float var_30 = var_5[var_19];
            float var_31 = (var_28 - var_29);
            float var_32 = (2 * var_31);
            float var_33 = (var_0 * var_32);
            float var_34 = (var_30 + var_33);
            var_5[var_19] = var_34;
            var_16[0] = (make_Env0(var_20));
        }
        Env0 var_35 = var_16[0];
        long long int var_36 = var_35.mem_0;
    }
    __global__ void method_25(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = gridDim.x;
        long long int var_12 = (var_8 * 128);
        long long int var_13 = (var_12 + var_5);
        long long int var_14 = (var_11 * 128);
        Env0 var_15[1];
        var_15[0] = (make_Env0(var_13));
        while (method_18(var_3, var_15)) {
            Env0 var_17 = var_15[0];
            long long int var_18 = var_17.mem_0;
            long long int var_19 = (var_18 + var_14);
            char var_20 = (var_18 >= 0);
            char var_22;
            if (var_20) {
                var_22 = (var_18 < var_3);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            char var_25;
            if (var_20) {
                var_25 = (var_18 < var_3);
            } else {
                var_25 = 0;
            }
            char var_26 = (var_25 == 0);
            if (var_26) {
                // "Argument out of bounds."
            } else {
            }
            float var_27 = var_0[var_18];
            float var_28 = var_1[var_18];
            float var_29 = var_2[var_18];
            float var_30 = var_4[var_18];
            float var_31 = (1 - var_29);
            float var_32 = (var_29 * var_31);
            float var_33 = (var_28 * var_32);
            float var_34 = (var_30 + var_33);
            var_4[var_18] = var_34;
            var_15[0] = (make_Env0(var_19));
        }
        Env0 var_35 = var_15[0];
        long long int var_36 = var_35.mem_0;
    }
    __global__ void method_27(long long int var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (10 * var_6);
        long long int var_10 = (var_3 + var_9);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_17(var_11)) {
            Env0 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            long long int var_15 = (var_14 + 10);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < 10);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            char var_21;
            if (var_16) {
                var_21 = (var_14 < 10);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = (8 * var_7);
            long long int var_24 = (var_4 + var_23);
            float var_25 = 0;
            Env1 var_26[1];
            var_26[0] = (make_Env1(var_24, var_25));
            while (method_21(var_0, var_26)) {
                Env1 var_28 = var_26[0];
                long long int var_29 = var_28.mem_0;
                float var_30 = var_28.mem_1;
                long long int var_31 = (var_29 + 8);
                char var_32 = (var_29 >= 0);
                char var_34;
                if (var_32) {
                    var_34 = (var_29 < var_0);
                } else {
                    var_34 = 0;
                }
                char var_35 = (var_34 == 0);
                if (var_35) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_36 = (var_29 * 10);
                char var_38;
                if (var_16) {
                    var_38 = (var_14 < 10);
                } else {
                    var_38 = 0;
                }
                char var_39 = (var_38 == 0);
                if (var_39) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_40 = (var_36 + var_14);
                float var_41 = var_1[var_40];
                float var_42 = (var_30 + var_41);
                var_26[0] = (make_Env1(var_31, var_42));
            }
            Env1 var_43 = var_26[0];
            long long int var_44 = var_43.mem_0;
            float var_45 = var_43.mem_1;
            __shared__ float var_46[70];
            char var_47 = (var_3 >= 0);
            char var_49;
            if (var_47) {
                var_49 = (var_3 < 10);
            } else {
                var_49 = 0;
            }
            char var_50 = (var_49 == 0);
            if (var_50) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_51 = (var_3 * 7);
            char var_52 = (var_4 != 0);
            if (var_52) {
                char var_53 = (var_4 >= 1);
                char var_55;
                if (var_53) {
                    var_55 = (var_4 < 8);
                } else {
                    var_55 = 0;
                }
                char var_56 = (var_55 == 0);
                if (var_56) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_57 = (var_4 - 1);
                long long int var_58 = (var_51 + var_57);
                var_46[var_58] = var_45;
            } else {
            }
            __syncthreads();
            char var_59 = (var_4 == 0);
            if (var_59) {
                Env1 var_60[1];
                var_60[0] = (make_Env1(1, var_45));
                while (method_28(var_60)) {
                    Env1 var_62 = var_60[0];
                    long long int var_63 = var_62.mem_0;
                    float var_64 = var_62.mem_1;
                    long long int var_65 = (var_63 + 1);
                    char var_66 = (var_63 >= 1);
                    char var_68;
                    if (var_66) {
                        var_68 = (var_63 < 8);
                    } else {
                        var_68 = 0;
                    }
                    char var_69 = (var_68 == 0);
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_70 = (var_63 - 1);
                    long long int var_71 = (var_51 + var_70);
                    float var_72 = var_46[var_71];
                    float var_73 = (var_64 + var_72);
                    var_60[0] = (make_Env1(var_65, var_73));
                }
                Env1 var_74 = var_60[0];
                long long int var_75 = var_74.mem_0;
                float var_76 = var_74.mem_1;
                float var_77 = var_2[var_14];
                float var_78 = (var_76 + var_77);
                var_2[var_14] = var_78;
            } else {
            }
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_79 = var_11[0];
        long long int var_80 = var_79.mem_0;
    }
    __global__ void method_29(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_30(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 7936);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 7840);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            char var_20;
            if (var_15) {
                var_20 = (var_13 < 7840);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_13];
            float var_23 = var_1[var_13];
            float var_24 = (var_23 - var_22);
            var_1[var_13] = var_24;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_25 = var_10[0];
        long long int var_26 = var_25.mem_0;
    }
    __global__ void method_31(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_17(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 128);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 10);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            char var_20;
            if (var_15) {
                var_20 = (var_13 < 10);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_13];
            float var_23 = var_1[var_13];
            float var_24 = (var_23 - var_22);
            var_1[var_13] = var_24;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_25 = var_10[0];
        long long int var_26 = var_25.mem_0;
    }
    __global__ void method_32(long long int var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_5 + var_8);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_18(var_0, var_11)) {
            Env0 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            long long int var_15 = (var_14 + 64);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < var_0);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_20 = (var_14 * 10);
            char var_22;
            if (var_16) {
                var_22 = (var_14 < var_0);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_24 = (10 * var_7);
            long long int var_25 = (var_4 + var_24);
            float var_26 = __int_as_float(0xff800000);
            float var_27 = 0;
            Env3 var_28[1];
            var_28[0] = (make_Env3(var_25, make_Tuple4(var_26, var_27)));
            while (method_33(var_28)) {
                Env3 var_30 = var_28[0];
                long long int var_31 = var_30.mem_0;
                Tuple4 var_32 = var_30.mem_1;
                float var_33 = var_32.mem_0;
                float var_34 = var_32.mem_1;
                long long int var_35 = (var_31 + 10);
                char var_36 = (var_31 >= 0);
                char var_38;
                if (var_36) {
                    var_38 = (var_31 < 10);
                } else {
                    var_38 = 0;
                }
                char var_39 = (var_38 == 0);
                if (var_39) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_40 = (var_20 + var_31);
                float var_41 = var_1[var_40];
                float var_42 = var_2[var_40];
                char var_43 = (var_33 > var_41);
                Tuple4 var_44;
                if (var_43) {
                    var_44 = make_Tuple4(var_33, var_34);
                } else {
                    var_44 = make_Tuple4(var_41, var_42);
                }
                float var_45 = var_44.mem_0;
                float var_46 = var_44.mem_1;
                var_28[0] = (make_Env3(var_35, make_Tuple4(var_45, var_46)));
            }
            Env3 var_47 = var_28[0];
            long long int var_48 = var_47.mem_0;
            Tuple4 var_49 = var_47.mem_1;
            float var_50 = var_49.mem_0;
            float var_51 = var_49.mem_1;
            FunPointer5 var_54 = method_34;
            Tuple4 var_55 = cub::BlockReduce<Tuple4,10>().Reduce(make_Tuple4(var_50, var_51), var_54);
            float var_56 = var_55.mem_0;
            float var_57 = var_55.mem_1;
            char var_58 = (var_4 == 0);
            if (var_58) {
                char var_60;
                if (var_16) {
                    var_60 = (var_14 < var_0);
                } else {
                    var_60 = 0;
                }
                char var_61 = (var_60 == 0);
                if (var_61) {
                    // "Argument out of bounds."
                } else {
                }
                float var_62 = var_3[var_14];
                var_3[var_14] = var_57;
            } else {
            }
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_63 = var_11[0];
        long long int var_64 = var_63.mem_0;
    }
    __device__ char method_17(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_18(long long int var_0, Env0 * var_1) {
        Env0 var_2 = var_1[0];
        long long int var_3 = var_2.mem_0;
        return (var_3 < var_0);
    }
    __device__ char method_21(long long int var_0, Env1 * var_1) {
        Env1 var_2 = var_1[0];
        long long int var_3 = var_2.mem_0;
        float var_4 = var_2.mem_1;
        return (var_3 < var_0);
    }
    __device__ float method_22(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ char method_28(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 8);
    }
    __device__ char method_30(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 7840);
    }
    __device__ char method_33(Env3 * var_0) {
        Env3 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple4 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 10);
    }
    __device__ Tuple4 method_34(Tuple4 var_0, Tuple4 var_1) {
        float var_2 = var_0.mem_0;
        float var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        float var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple4 var_7;
        if (var_6) {
            var_7 = make_Tuple4(var_2, var_3);
        } else {
            var_7 = make_Tuple4(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        float var_9 = var_7.mem_1;
        return make_Tuple4(var_8, var_9);
    }
}
"""

type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack2 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: EnvStack2
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple4 =
    struct
    val mem_0: Tuple5
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple5 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple6 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env7 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: string)): Tuple4 =
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
    Tuple4(Tuple5(var_16, var_17, var_18), var_22)
and method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_4((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_5((var_0: string)): Tuple6 =
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
    Tuple6(var_12, var_14)
and method_6((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_7((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_6((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_8((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_4((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_8((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_9((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
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
        method_7((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_9((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env3) = var_1.Peek()
        let (var_7: EnvStack2) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_11((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_12((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_13((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 100L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: int64) = 0L
        let (var_18: Env7) = method_14((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_16: int64), (var_15: float), (var_17: int64))
        let (var_19: int64) = var_18.mem_0
        let (var_20: float) = var_18.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: float) = (var_20 / 60000.000000)
        let (var_22: string) = System.String.Format("Average of batch costs is {0}.",var_21)
        let (var_23: string) = System.String.Format("{0}",var_22)
        System.Console.WriteLine(var_23)
        let (var_24: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_19,60000L)
        let (var_25: string) = System.String.Format("{0}",var_24)
        System.Console.WriteLine(var_25)
        System.Console.WriteLine("-----")
        let (var_26: int64) = (var_13 + 1L)
        method_13((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_26: int64))
    else
        ()
and method_4((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64)): unit =
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
        method_4((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_11: int64))
    else
        ()
and method_7((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_7((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_11((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64 var_3
    let (var_13: uint64) = (var_12 + var_11)
    let (var_14: bool) = (var_13 <= var_2)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_16: uint64) = (var_8 + var_9)
    let (var_17: uint64) = (var_16 % 128UL)
    let (var_18: uint64) = (var_16 + var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_3)))
    var_22
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: uint64) = (var_0 % 128UL)
    let (var_8: uint64) = (var_0 + var_7)
    let (var_9: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_8)
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_9)
    let (var_11: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_10))))
    let (var_12: EnvStack2) = EnvStack2((var_11: (Union0 ref)))
    var_3.Push((Env3(var_12, var_2)))
    var_12
and method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_15: int64)): Env7 =
    let (var_16: bool) = (var_15 < 60000L)
    if var_16 then
        let (var_17: int64) = (var_15 + 64L)
        let (var_18: bool) = (60000L > var_17)
        let (var_19: int64) =
            if var_18 then
                var_17
            else
                60000L
        let (var_20: bool) = (var_15 < var_19)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_22: bool) = (var_15 >= 0L)
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_24: bool) = (var_19 > 0L)
        let (var_26: bool) =
            if var_24 then
                (var_19 <= 60000L)
            else
                false
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_28: int64) = (var_19 - var_15)
        let (var_29: int64) = (var_15 * 784L)
        if var_21 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_23 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_31: bool) =
            if var_24 then
                (var_19 <= 60000L)
            else
                false
        let (var_32: bool) = (var_31 = false)
        if var_32 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_33: int64) = (var_15 * 10L)
        let (var_34: bool) = (var_28 > 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_36: int64) = (var_28 * 10L)
        let (var_37: int64) = (var_36 * 4L)
        let (var_38: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_37: int64))
        let (var_39: int32) = (int32 var_28)
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: EnvStack2), (var_29: int64), (var_28: int64), (var_10: EnvStack2), (var_38: EnvStack2))
        let (var_40: bool) = (0L < var_28)
        let (var_41: bool) = (var_40 = false)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_42: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_37: int64))
        let (var_43: (Union0 ref)) = var_42.mem_0
        let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_45: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_46: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
        var_0.ClearMemoryAsync(var_44, 0uy, var_46, var_45)
        let (var_47: bool) = (8L > var_28)
        let (var_48: int64) =
            if var_47 then
                var_28
            else
                8L
        let (var_49: (Union0 ref)) = var_7.mem_0
        let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
        let (var_51: (Union0 ref)) = var_38.mem_0
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        // Cuda join point
        // method_16((var_28: int64), (var_50: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: ManagedCuda.BasicTypes.CUdeviceptr), (var_53: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_55: (System.Object [])) = [|var_28; var_50; var_52; var_53|]: (System.Object [])
        let (var_56: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_1, var_0)
        let (var_57: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_56.set_GridDimensions(var_57)
        let (var_58: uint32) = (uint32 var_48)
        let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_58, 1u)
        var_56.set_BlockDimensions(var_59)
        let (var_60: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_56.RunAsync(var_60, var_55)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_65: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_37: int64))
        let (var_66: bool) = (var_36 > 0L)
        let (var_67: bool) = (var_66 = false)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_69: (Union0 ref)) = var_65.mem_0
        let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_71: int64) = (var_36 - 1L)
        let (var_72: int64) = (var_71 / 128L)
        let (var_73: int64) = (var_72 + 1L)
        let (var_74: bool) = (64L > var_73)
        let (var_75: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_19((var_68: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_70: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_77: (System.Object [])) = [|var_68; var_36; var_70|]: (System.Object [])
        let (var_78: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_1, var_0)
        let (var_79: uint32) = (uint32 var_75)
        let (var_80: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_79, 1u, 1u)
        var_78.set_GridDimensions(var_80)
        let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_78.set_BlockDimensions(var_81)
        let (var_82: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_78.RunAsync(var_82, var_77)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_83: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_37: int64))
        let (var_84: (Union0 ref)) = var_83.mem_0
        let (var_85: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_86: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_87: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
        var_0.ClearMemoryAsync(var_85, 0uy, var_87, var_86)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_88: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_89: int64) = (var_33 * 4L)
        let (var_90: (Union0 ref)) = var_12.mem_0
        let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_92: ManagedCuda.BasicTypes.SizeT) = var_91.Pointer
        let (var_93: uint64) = uint64 var_92
        let (var_94: uint64) = (uint64 var_89)
        let (var_95: uint64) = (var_93 + var_94)
        let (var_96: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_95)
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_96)
        let (var_98: int64) =
            if var_74 then
                var_73
            else
                64L
        let (var_101: bool) = (var_98 > 0L)
        let (var_102: bool) = (var_101 = false)
        if var_102 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_103: int64) = (var_98 * 4L)
        let (var_104: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_103: int64))
        let (var_105: (Union0 ref)) = var_104.mem_0
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_105: (Union0 ref)))
        // Cuda join point
        // method_20((var_88: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_106: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: int64))
        let (var_108: (System.Object [])) = [|var_88; var_97; var_36; var_106; var_98|]: (System.Object [])
        let (var_109: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_110: uint32) = (uint32 var_98)
        let (var_111: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_110, 1u, 1u)
        var_109.set_GridDimensions(var_111)
        let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_109.set_BlockDimensions(var_112)
        let (var_113: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_109.RunAsync(var_113, var_108)
        let (var_114: bool) = (0L < var_98)
        let (var_115: bool) = (var_114 = false)
        if var_115 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_105: (Union0 ref)))
        let (var_117: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_98))
        var_0.CopyToHost(var_117, var_116)
        var_0.Synchronize()
        let (var_118: float32) = 0.000000f
        let (var_119: int64) = 0L
        let (var_120: float32) = method_23((var_117: (float32 [])), (var_98: int64), (var_118: float32), (var_119: int64))
        var_105 := Union0Case1
        let (var_121: (float32 ref)) = (ref 0.000000f)
        let (var_122: float32) = (float32 var_28)
        let (var_123: float32) = (var_120 / var_122)
        let (var_124: (float32 ref)) = (ref 0.000000f)
        var_124 := 1.000000f
        let (var_125: float32) = (!var_124)
        let (var_126: float32) = (var_125 / var_122)
        let (var_127: float32) = (!var_121)
        let (var_128: float32) = (var_127 + var_126)
        var_121 := var_128
        let (var_129: float32) = (!var_121)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_131: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_132: ManagedCuda.BasicTypes.SizeT) = var_131.Pointer
        let (var_133: uint64) = uint64 var_132
        let (var_134: uint64) = (var_133 + var_94)
        let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_134)
        let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_135)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        let (var_138: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_24((var_129: float32), (var_120: float32), (var_130: ManagedCuda.BasicTypes.CUdeviceptr), (var_136: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_137: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_140: (System.Object [])) = [|var_129; var_120; var_130; var_136; var_36; var_137|]: (System.Object [])
        let (var_141: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_1, var_0)
        let (var_142: uint32) = (uint32 var_138)
        let (var_143: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_142, 1u, 1u)
        var_141.set_GridDimensions(var_143)
        let (var_144: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_141.set_BlockDimensions(var_144)
        let (var_145: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_141.RunAsync(var_145, var_140)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_146: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        let (var_148: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        let (var_150: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_25((var_146: ManagedCuda.BasicTypes.CUdeviceptr), (var_147: ManagedCuda.BasicTypes.CUdeviceptr), (var_148: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_149: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_152: (System.Object [])) = [|var_146; var_147; var_148; var_36; var_149|]: (System.Object [])
        let (var_153: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_1, var_0)
        let (var_154: uint32) = (uint32 var_150)
        let (var_155: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_154, 1u, 1u)
        var_153.set_GridDimensions(var_155)
        let (var_156: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_153.set_BlockDimensions(var_156)
        let (var_157: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_153.RunAsync(var_157, var_152)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: EnvStack2), (var_29: int64), (var_28: int64), (var_42: EnvStack2), (var_9: EnvStack2))
        let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        let (var_159: (Union0 ref)) = var_6.mem_0
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_159: (Union0 ref)))
        // Cuda join point
        // method_27((var_28: int64), (var_158: ManagedCuda.BasicTypes.CUdeviceptr), (var_160: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_162: (System.Object [])) = [|var_28; var_158; var_160|]: (System.Object [])
        let (var_163: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_1, var_0)
        let (var_164: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_163.set_GridDimensions(var_164)
        let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_163.set_BlockDimensions(var_165)
        let (var_166: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_163.RunAsync(var_166, var_162)
        let (var_167: (Union0 ref)) = var_9.mem_0
        let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_167: (Union0 ref)))
        let (var_169: (Union0 ref)) = var_10.mem_0
        let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_169: (Union0 ref)))
        // Cuda join point
        // method_29((var_168: ManagedCuda.BasicTypes.CUdeviceptr), (var_170: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_172: (System.Object [])) = [|var_168; var_170|]: (System.Object [])
        let (var_173: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_1, var_0)
        let (var_174: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_173.set_GridDimensions(var_174)
        let (var_175: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_173.set_BlockDimensions(var_175)
        let (var_176: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_173.RunAsync(var_176, var_172)
        let (var_177: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_167: (Union0 ref)))
        let (var_178: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_177, 0uy, var_179, var_178)
        let (var_180: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_159: (Union0 ref)))
        let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
        // Cuda join point
        // method_31((var_180: ManagedCuda.BasicTypes.CUdeviceptr), (var_181: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_183: (System.Object [])) = [|var_180; var_181|]: (System.Object [])
        let (var_184: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_1, var_0)
        let (var_185: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_184.set_GridDimensions(var_185)
        let (var_186: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_184.set_BlockDimensions(var_186)
        let (var_187: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_184.RunAsync(var_187, var_183)
        let (var_188: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_159: (Union0 ref)))
        let (var_189: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_190: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_188, 0uy, var_190, var_189)
        let (var_191: float) = (float var_123)
        let (var_192: float) = (float var_28)
        let (var_193: float) = (var_191 * var_192)
        let (var_194: float) = (var_14 + var_193)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_195: int64) = (var_28 * 4L)
        let (var_196: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_195: int64))
        let (var_197: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_198: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_199: ManagedCuda.BasicTypes.SizeT) = var_198.Pointer
        let (var_200: uint64) = uint64 var_199
        let (var_201: uint64) = (var_200 + var_94)
        let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_201)
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_202)
        let (var_204: (Union0 ref)) = var_196.mem_0
        let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_204: (Union0 ref)))
        // Cuda join point
        // method_32((var_28: int64), (var_197: ManagedCuda.BasicTypes.CUdeviceptr), (var_203: ManagedCuda.BasicTypes.CUdeviceptr), (var_205: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_207: (System.Object [])) = [|var_28; var_197; var_203; var_205|]: (System.Object [])
        let (var_208: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
        var_208.set_GridDimensions(var_209)
        let (var_210: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_208.set_BlockDimensions(var_210)
        let (var_211: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_208.RunAsync(var_211, var_207)
        let (var_212: int64) = 0L
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_213: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_204: (Union0 ref)))
        let (var_214: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_28))
        var_0.CopyToHost(var_214, var_213)
        var_0.Synchronize()
        let (var_215: int64) = var_214.LongLength
        let (var_216: int64) = 0L
        let (var_217: int64) = method_35((var_214: (float32 [])), (var_215: int64), (var_212: int64), (var_216: int64))
        var_204 := Union0Case1
        let (var_218: int64) = (var_13 + var_217)
        var_84 := Union0Case1
        var_69 := Union0Case1
        var_43 := Union0Case1
        var_51 := Union0Case1
        method_36((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_218: int64), (var_194: float), (var_17: int64))
    else
        (Env7(var_13, var_14))
and method_15((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: EnvStack2), (var_3: int64), (var_4: int64), (var_5: EnvStack2), (var_6: EnvStack2)): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: bool) = (0L < var_4)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_12: int64) = (var_4 * 784L)
    let (var_13: int64) = (var_3 * 4L)
    let (var_14: (Union0 ref)) = var_2.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_14: (Union0 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = var_15.Pointer
    let (var_17: uint64) = uint64 var_16
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_17 + var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (Union0 ref)) = var_5.mem_0
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_22: (Union0 ref)))
    let (var_24: (float32 ref)) = (ref 0.000000f)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_25: int64) = (var_4 * 10L)
    let (var_26: (Union0 ref)) = var_6.mem_0
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_26: (Union0 ref)))
    let (var_28: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, var_1, 10, 784, var_9, var_21, var_1, var_23, 784, var_24, var_27, var_1)
    if var_28 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_28)
and method_23((var_0: (float32 [])), (var_1: int64), (var_2: float32), (var_3: int64)): float32 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: float32) = var_0.[int32 var_3]
        let (var_8: float32) = (var_2 + var_7)
        let (var_9: int64) = (var_3 + 1L)
        method_23((var_0: (float32 [])), (var_1: int64), (var_8: float32), (var_9: int64))
    else
        var_2
and method_26((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: int32), (var_2: EnvStack2), (var_3: int64), (var_4: int64), (var_5: EnvStack2), (var_6: EnvStack2)): unit =
    let (var_7: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_8: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_9: (float32 ref)) = (ref 1.000000f)
    let (var_10: bool) = (0L < var_4)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_12: int64) = (var_4 * 784L)
    let (var_13: int64) = (var_3 * 4L)
    let (var_14: (Union0 ref)) = var_2.mem_0
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_14: (Union0 ref)))
    let (var_16: ManagedCuda.BasicTypes.SizeT) = var_15.Pointer
    let (var_17: uint64) = uint64 var_16
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_17 + var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    if var_11 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_22: int64) = (var_4 * 10L)
    let (var_23: (Union0 ref)) = var_5.mem_0
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_23: (Union0 ref)))
    let (var_25: (float32 ref)) = (ref 1.000000f)
    let (var_26: (Union0 ref)) = var_6.mem_0
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_26: (Union0 ref)))
    let (var_28: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_7, var_8, 784, 10, var_1, var_9, var_21, var_1, var_24, var_1, var_25, var_27, 784)
    if var_28 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_28)
and method_35((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
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
        method_35((var_0: (float32 [])), (var_1: int64), (var_8: int64), (var_9: int64))
    else
        var_2
and method_36((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_15: int64), (var_16: float), (var_17: int64)): Env7 =
    let (var_18: bool) = (var_17 < 60000L)
    if var_18 then
        let (var_19: int64) = (var_17 + 64L)
        let (var_20: bool) = (60000L > var_19)
        let (var_21: int64) =
            if var_20 then
                var_19
            else
                60000L
        let (var_22: bool) = (var_17 < var_21)
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_24: bool) = (var_17 >= 0L)
        let (var_25: bool) = (var_24 = false)
        if var_25 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_26: bool) = (var_21 > 0L)
        let (var_28: bool) =
            if var_26 then
                (var_21 <= 60000L)
            else
                false
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_30: int64) = (var_21 - var_17)
        let (var_31: int64) = (var_17 * 784L)
        if var_23 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_25 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_33: bool) =
            if var_26 then
                (var_21 <= 60000L)
            else
                false
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_35: int64) = (var_17 * 10L)
        let (var_36: bool) = (var_30 > 0L)
        let (var_37: bool) = (var_36 = false)
        if var_37 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_38: int64) = (var_30 * 10L)
        let (var_39: int64) = (var_38 * 4L)
        let (var_40: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_39: int64))
        let (var_41: int32) = (int32 var_30)
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_41: int32), (var_11: EnvStack2), (var_31: int64), (var_30: int64), (var_10: EnvStack2), (var_40: EnvStack2))
        let (var_42: bool) = (0L < var_30)
        let (var_43: bool) = (var_42 = false)
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_44: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_39: int64))
        let (var_45: (Union0 ref)) = var_44.mem_0
        let (var_46: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_45: (Union0 ref)))
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_47: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_48: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
        var_0.ClearMemoryAsync(var_46, 0uy, var_48, var_47)
        let (var_49: bool) = (8L > var_30)
        let (var_50: int64) =
            if var_49 then
                var_30
            else
                8L
        let (var_51: (Union0 ref)) = var_7.mem_0
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        let (var_53: (Union0 ref)) = var_40.mem_0
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_53: (Union0 ref)))
        let (var_55: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_53: (Union0 ref)))
        // Cuda join point
        // method_16((var_30: int64), (var_52: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: ManagedCuda.BasicTypes.CUdeviceptr), (var_55: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_57: (System.Object [])) = [|var_30; var_52; var_54; var_55|]: (System.Object [])
        let (var_58: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_1, var_0)
        let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_58.set_GridDimensions(var_59)
        let (var_60: uint32) = (uint32 var_50)
        let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_60, 1u)
        var_58.set_BlockDimensions(var_61)
        let (var_62: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_58.RunAsync(var_62, var_57)
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_67: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_39: int64))
        let (var_68: bool) = (var_38 > 0L)
        let (var_69: bool) = (var_68 = false)
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_53: (Union0 ref)))
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_71: (Union0 ref)) = var_67.mem_0
        let (var_72: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_73: int64) = (var_38 - 1L)
        let (var_74: int64) = (var_73 / 128L)
        let (var_75: int64) = (var_74 + 1L)
        let (var_76: bool) = (64L > var_75)
        let (var_77: int64) =
            if var_76 then
                var_75
            else
                64L
        // Cuda join point
        // method_19((var_70: ManagedCuda.BasicTypes.CUdeviceptr), (var_38: int64), (var_72: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_79: (System.Object [])) = [|var_70; var_38; var_72|]: (System.Object [])
        let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_1, var_0)
        let (var_81: uint32) = (uint32 var_77)
        let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_81, 1u, 1u)
        var_80.set_GridDimensions(var_82)
        let (var_83: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_80.set_BlockDimensions(var_83)
        let (var_84: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_80.RunAsync(var_84, var_79)
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_85: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_39: int64))
        let (var_86: (Union0 ref)) = var_85.mem_0
        let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_86: (Union0 ref)))
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_88: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_89: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
        var_0.ClearMemoryAsync(var_87, 0uy, var_89, var_88)
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_91: int64) = (var_35 * 4L)
        let (var_92: (Union0 ref)) = var_12.mem_0
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_92: (Union0 ref)))
        let (var_94: ManagedCuda.BasicTypes.SizeT) = var_93.Pointer
        let (var_95: uint64) = uint64 var_94
        let (var_96: uint64) = (uint64 var_91)
        let (var_97: uint64) = (var_95 + var_96)
        let (var_98: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_97)
        let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_98)
        let (var_100: int64) =
            if var_76 then
                var_75
            else
                64L
        let (var_103: bool) = (var_100 > 0L)
        let (var_104: bool) = (var_103 = false)
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_105: int64) = (var_100 * 4L)
        let (var_106: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_105: int64))
        let (var_107: (Union0 ref)) = var_106.mem_0
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_107: (Union0 ref)))
        // Cuda join point
        // method_20((var_90: ManagedCuda.BasicTypes.CUdeviceptr), (var_99: ManagedCuda.BasicTypes.CUdeviceptr), (var_38: int64), (var_108: ManagedCuda.BasicTypes.CUdeviceptr), (var_100: int64))
        let (var_110: (System.Object [])) = [|var_90; var_99; var_38; var_108; var_100|]: (System.Object [])
        let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_112: uint32) = (uint32 var_100)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_112, 1u, 1u)
        var_111.set_GridDimensions(var_113)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_111.set_BlockDimensions(var_114)
        let (var_115: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_111.RunAsync(var_115, var_110)
        let (var_116: bool) = (0L < var_100)
        let (var_117: bool) = (var_116 = false)
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_107: (Union0 ref)))
        let (var_119: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_100))
        var_0.CopyToHost(var_119, var_118)
        var_0.Synchronize()
        let (var_120: float32) = 0.000000f
        let (var_121: int64) = 0L
        let (var_122: float32) = method_23((var_119: (float32 [])), (var_100: int64), (var_120: float32), (var_121: int64))
        var_107 := Union0Case1
        let (var_123: (float32 ref)) = (ref 0.000000f)
        let (var_124: float32) = (float32 var_30)
        let (var_125: float32) = (var_122 / var_124)
        let (var_126: (float32 ref)) = (ref 0.000000f)
        var_126 := 1.000000f
        let (var_127: float32) = (!var_126)
        let (var_128: float32) = (var_127 / var_124)
        let (var_129: float32) = (!var_123)
        let (var_130: float32) = (var_129 + var_128)
        var_123 := var_130
        let (var_131: float32) = (!var_123)
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_133: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_92: (Union0 ref)))
        let (var_134: ManagedCuda.BasicTypes.SizeT) = var_133.Pointer
        let (var_135: uint64) = uint64 var_134
        let (var_136: uint64) = (var_135 + var_96)
        let (var_137: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_136)
        let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_137)
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_139: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_86: (Union0 ref)))
        let (var_140: int64) =
            if var_76 then
                var_75
            else
                64L
        // Cuda join point
        // method_24((var_131: float32), (var_122: float32), (var_132: ManagedCuda.BasicTypes.CUdeviceptr), (var_138: ManagedCuda.BasicTypes.CUdeviceptr), (var_38: int64), (var_139: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_142: (System.Object [])) = [|var_131; var_122; var_132; var_138; var_38; var_139|]: (System.Object [])
        let (var_143: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_1, var_0)
        let (var_144: uint32) = (uint32 var_140)
        let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_144, 1u, 1u)
        var_143.set_GridDimensions(var_145)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_143.set_BlockDimensions(var_146)
        let (var_147: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_143.RunAsync(var_147, var_142)
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_148: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_53: (Union0 ref)))
        let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_86: (Union0 ref)))
        let (var_150: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        if var_69 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_45: (Union0 ref)))
        let (var_152: int64) =
            if var_76 then
                var_75
            else
                64L
        // Cuda join point
        // method_25((var_148: ManagedCuda.BasicTypes.CUdeviceptr), (var_149: ManagedCuda.BasicTypes.CUdeviceptr), (var_150: ManagedCuda.BasicTypes.CUdeviceptr), (var_38: int64), (var_151: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_154: (System.Object [])) = [|var_148; var_149; var_150; var_38; var_151|]: (System.Object [])
        let (var_155: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_1, var_0)
        let (var_156: uint32) = (uint32 var_152)
        let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_156, 1u, 1u)
        var_155.set_GridDimensions(var_157)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_155.set_BlockDimensions(var_158)
        let (var_159: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_155.RunAsync(var_159, var_154)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_41: int32), (var_11: EnvStack2), (var_31: int64), (var_30: int64), (var_44: EnvStack2), (var_9: EnvStack2))
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_45: (Union0 ref)))
        let (var_161: (Union0 ref)) = var_6.mem_0
        let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
        // Cuda join point
        // method_27((var_30: int64), (var_160: ManagedCuda.BasicTypes.CUdeviceptr), (var_162: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_164: (System.Object [])) = [|var_30; var_160; var_162|]: (System.Object [])
        let (var_165: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_1, var_0)
        let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_165.set_GridDimensions(var_166)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_165.set_BlockDimensions(var_167)
        let (var_168: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_165.RunAsync(var_168, var_164)
        let (var_169: (Union0 ref)) = var_9.mem_0
        let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_169: (Union0 ref)))
        let (var_171: (Union0 ref)) = var_10.mem_0
        let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        // Cuda join point
        // method_29((var_170: ManagedCuda.BasicTypes.CUdeviceptr), (var_172: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_174: (System.Object [])) = [|var_170; var_172|]: (System.Object [])
        let (var_175: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_1, var_0)
        let (var_176: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_175.set_GridDimensions(var_176)
        let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_175.set_BlockDimensions(var_177)
        let (var_178: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_175.RunAsync(var_178, var_174)
        let (var_179: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_169: (Union0 ref)))
        let (var_180: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_181: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_179, 0uy, var_181, var_180)
        let (var_182: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
        let (var_183: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        // Cuda join point
        // method_31((var_182: ManagedCuda.BasicTypes.CUdeviceptr), (var_183: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_185: (System.Object [])) = [|var_182; var_183|]: (System.Object [])
        let (var_186: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_1, var_0)
        let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_186.set_GridDimensions(var_187)
        let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_186.set_BlockDimensions(var_188)
        let (var_189: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_186.RunAsync(var_189, var_185)
        let (var_190: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
        let (var_191: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_190, 0uy, var_192, var_191)
        let (var_193: float) = (float var_125)
        let (var_194: float) = (float var_30)
        let (var_195: float) = (var_193 * var_194)
        let (var_196: float) = (var_16 + var_195)
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_197: int64) = (var_30 * 4L)
        let (var_198: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_197: int64))
        let (var_199: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_200: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_92: (Union0 ref)))
        let (var_201: ManagedCuda.BasicTypes.SizeT) = var_200.Pointer
        let (var_202: uint64) = uint64 var_201
        let (var_203: uint64) = (var_202 + var_96)
        let (var_204: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_203)
        let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_204)
        let (var_206: (Union0 ref)) = var_198.mem_0
        let (var_207: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_206: (Union0 ref)))
        // Cuda join point
        // method_32((var_30: int64), (var_199: ManagedCuda.BasicTypes.CUdeviceptr), (var_205: ManagedCuda.BasicTypes.CUdeviceptr), (var_207: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_209: (System.Object [])) = [|var_30; var_199; var_205; var_207|]: (System.Object [])
        let (var_210: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_211: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
        var_210.set_GridDimensions(var_211)
        let (var_212: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_210.set_BlockDimensions(var_212)
        let (var_213: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_210.RunAsync(var_213, var_209)
        let (var_214: int64) = 0L
        if var_43 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_206: (Union0 ref)))
        let (var_216: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_30))
        var_0.CopyToHost(var_216, var_215)
        var_0.Synchronize()
        let (var_217: int64) = var_216.LongLength
        let (var_218: int64) = 0L
        let (var_219: int64) = method_35((var_216: (float32 [])), (var_217: int64), (var_214: int64), (var_218: int64))
        var_206 := Union0Case1
        let (var_220: int64) = (var_15 + var_219)
        var_86 := Union0Case1
        var_71 := Union0Case1
        var_45 := Union0Case1
        var_53 := Union0Case1
        method_36((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_220: int64), (var_196: float), (var_19: int64))
    else
        (Env7(var_15, var_16))
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
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.700000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_53: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_52)
let (var_54: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_53.SetStream(var_54)
let (var_55: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_56: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_57: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_55, var_56)
let (var_58: ManagedCuda.CudaBlas.CudaBlasHandle) = var_57.get_CublasHandle()
let (var_59: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_57.set_Stream(var_59)
let (var_60: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_61: Tuple4) = method_2((var_60: string))
let (var_62: Tuple5) = var_61.mem_0
let (var_63: (uint8 [])) = var_61.mem_1
let (var_64: int64) = var_62.mem_0
let (var_65: int64) = var_62.mem_1
let (var_66: int64) = var_62.mem_2
let (var_67: bool) = (10000L = var_64)
let (var_71: bool) =
    if var_67 then
        let (var_68: bool) = (28L = var_65)
        if var_68 then
            (28L = var_66)
        else
            false
    else
        false
let (var_72: bool) = (var_71 = false)
if var_72 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_73: int64) = var_63.LongLength
let (var_74: bool) = (var_73 > 0L)
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_76: bool) = (7840000L = var_73)
let (var_77: bool) = (var_76 = false)
if var_77 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_81: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_82: int64) = 0L
method_3((var_63: (uint8 [])), (var_81: (float32 [])), (var_82: int64))
let (var_83: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_84: Tuple6) = method_5((var_83: string))
let (var_85: int64) = var_84.mem_0
let (var_86: (uint8 [])) = var_84.mem_1
let (var_87: bool) = (10000L = var_85)
let (var_88: bool) = (var_87 = false)
if var_88 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_92: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_93: int64) = 0L
method_6((var_86: (uint8 [])), (var_92: (float32 [])), (var_93: int64))
let (var_94: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_95: Tuple4) = method_2((var_94: string))
let (var_96: Tuple5) = var_95.mem_0
let (var_97: (uint8 [])) = var_95.mem_1
let (var_98: int64) = var_96.mem_0
let (var_99: int64) = var_96.mem_1
let (var_100: int64) = var_96.mem_2
let (var_101: bool) = (60000L = var_98)
let (var_105: bool) =
    if var_101 then
        let (var_102: bool) = (28L = var_99)
        if var_102 then
            (28L = var_100)
        else
            false
    else
        false
let (var_106: bool) = (var_105 = false)
if var_106 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_107: int64) = var_97.LongLength
let (var_108: bool) = (var_107 > 0L)
let (var_109: bool) = (var_108 = false)
if var_109 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_110: bool) = (47040000L = var_107)
let (var_111: bool) = (var_110 = false)
if var_111 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_115: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_116: int64) = 0L
method_8((var_97: (uint8 [])), (var_115: (float32 [])), (var_116: int64))
let (var_117: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_118: Tuple6) = method_5((var_117: string))
let (var_119: int64) = var_118.mem_0
let (var_120: (uint8 [])) = var_118.mem_1
let (var_121: bool) = (60000L = var_119)
let (var_122: bool) = (var_121 = false)
if var_122 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_126: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_127: int64) = 0L
method_9((var_120: (uint8 [])), (var_126: (float32 [])), (var_127: int64))
let (var_128: int64) = var_81.LongLength
let (var_129: int64) = (var_128 * 4L)
let (var_130: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_129: int64))
let (var_131: (Union0 ref)) = var_130.mem_0
let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
var_1.CopyToDevice(var_132, var_81)
let (var_133: int64) = var_92.LongLength
let (var_134: int64) = (var_133 * 4L)
let (var_135: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_134: int64))
let (var_136: (Union0 ref)) = var_135.mem_0
let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_136: (Union0 ref)))
var_1.CopyToDevice(var_137, var_92)
let (var_138: int64) = var_115.LongLength
let (var_139: int64) = (var_138 * 4L)
let (var_140: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_139: int64))
let (var_141: (Union0 ref)) = var_140.mem_0
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
var_1.CopyToDevice(var_142, var_115)
let (var_143: int64) = var_126.LongLength
let (var_144: int64) = (var_143 * 4L)
let (var_145: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_144: int64))
let (var_146: (Union0 ref)) = var_145.mem_0
let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
var_1.CopyToDevice(var_147, var_126)
let (var_148: int64) = 31360L
let (var_149: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_148: int64))
let (var_150: (Union0 ref)) = var_149.mem_0
let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_150: (Union0 ref)))
let (var_152: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_53.GenerateNormal32(var_151, var_152, 0.000000f, 0.050189f)
let (var_153: int64) = 31360L
let (var_154: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_153: int64))
let (var_155: (Union0 ref)) = var_154.mem_0
let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_155: (Union0 ref)))
let (var_157: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_158: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_156, 0uy, var_158, var_157)
let (var_159: int64) = 40L
let (var_160: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_159: int64))
let (var_161: (Union0 ref)) = var_160.mem_0
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
let (var_163: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_164: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_162, 0uy, var_164, var_163)
let (var_165: int64) = 40L
let (var_166: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_165: int64))
let (var_167: (Union0 ref)) = var_166.mem_0
let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_167: (Union0 ref)))
let (var_169: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_170: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_168, 0uy, var_170, var_169)
let (var_171: int64) = 0L
method_13((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_166: EnvStack2), (var_160: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_154: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_171: int64))
var_167 := Union0Case1
var_161 := Union0Case1
var_155 := Union0Case1
var_150 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_172)
var_46 := Union0Case1
var_1.Dispose()

