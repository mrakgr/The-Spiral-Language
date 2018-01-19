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
    __global__ void method_34(float * var_0, long long int var_1, float * var_2);
    __global__ void method_39(long long int var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_17(Env0 * var_0);
    __device__ char method_18(long long int var_0, Env0 * var_1);
    __device__ char method_21(long long int var_0, Env1 * var_1);
    __device__ float method_22(float var_0, float var_1);
    __device__ char method_28(Env1 * var_0);
    __device__ char method_30(Env0 * var_0);
    __device__ char method_40(Env3 * var_0);
    __device__ Tuple4 method_41(Tuple4 var_0, Tuple4 var_1);
    
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
            float var_28 = log(var_26);
            float var_29 = (var_27 * var_28);
            float var_30 = (1 - var_27);
            float var_31 = (1 - var_26);
            float var_32 = log(var_31);
            float var_33 = (var_30 * var_32);
            float var_34 = (var_29 + var_33);
            float var_35 = (-var_34);
            float var_36 = (var_20 + var_35);
            var_16[0] = (make_Env1(var_21, var_36));
        }
        Env1 var_37 = var_16[0];
        long long int var_38 = var_37.mem_0;
        float var_39 = var_37.mem_1;
        FunPointer2 var_42 = method_22;
        float var_43 = cub::BlockReduce<float,128>().Reduce(var_39, var_42);
        char var_44 = (var_5 == 0);
        if (var_44) {
            char var_45 = (var_8 >= 0);
            char var_47;
            if (var_45) {
                var_47 = (var_8 < var_4);
            } else {
                var_47 = 0;
            }
            char var_48 = (var_47 == 0);
            if (var_48) {
                // "Argument out of bounds."
            } else {
            }
            var_3[var_8] = var_43;
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
            float var_32 = (1 - var_28);
            float var_33 = (var_28 * var_32);
            float var_34 = (var_31 / var_33);
            float var_35 = (var_0 * var_34);
            float var_36 = (var_30 + var_35);
            var_5[var_19] = var_36;
            var_16[0] = (make_Env0(var_20));
        }
        Env0 var_37 = var_16[0];
        long long int var_38 = var_37.mem_0;
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
            float var_24 = (0.5 * var_22);
            float var_25 = (var_23 - var_24);
            var_1[var_13] = var_25;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_26 = var_10[0];
        long long int var_27 = var_26.mem_0;
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
            float var_24 = (0.5 * var_22);
            float var_25 = (var_23 - var_24);
            var_1[var_13] = var_25;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_26 = var_10[0];
        long long int var_27 = var_26.mem_0;
    }
    __global__ void method_34(float * var_0, long long int var_1, float * var_2) {
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
            var_2[var_16] = var_25;
            var_13[0] = (make_Env0(var_17));
        }
        Env0 var_27 = var_13[0];
        long long int var_28 = var_27.mem_0;
    }
    __global__ void method_39(long long int var_0, float * var_1, float * var_2, float * var_3) {
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
            while (method_40(var_28)) {
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
            FunPointer5 var_54 = method_41;
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
    __device__ char method_40(Env3 * var_0) {
        Env3 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple4 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 10);
    }
    __device__ Tuple4 method_41(Tuple4 var_0, Tuple4 var_1) {
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
    val mem_0: float
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env8 =
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
    let (var_14: bool) = (var_13 < 20L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: Env7) = method_14((var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_15: float), (var_16: int64))
        let (var_18: float) = var_17.mem_0
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_19: float) = (var_18 / 60000.000000)
        let (var_20: string) = System.String.Format("Average of batch costs is {0}.",var_19)
        let (var_21: string) = System.String.Format("{0}",var_20)
        System.Console.WriteLine(var_21)
        System.Console.WriteLine("-----")
        let (var_22: int64) = (var_13 + 1L)
        method_13((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_22: int64))
    else
        ()
and method_32((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 1L)
    if var_14 then
        let (var_15: int64) = 0L
        let (var_16: float) = 0.000000
        let (var_17: int64) = 0L
        let (var_18: Env8) = method_33((var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_15: int64), (var_16: float), (var_17: int64))
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
        method_32((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_26: int64))
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
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_14((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: float), (var_14: int64)): Env7 =
    let (var_15: bool) = (var_14 < 60000L)
    if var_15 then
        let (var_16: int64) = (var_14 + 128L)
        let (var_17: bool) = (60000L > var_16)
        let (var_18: int64) =
            if var_17 then
                var_16
            else
                60000L
        let (var_19: bool) = (var_14 < var_18)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_21: bool) = (var_14 >= 0L)
        let (var_22: bool) = (var_21 = false)
        if var_22 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_23: bool) = (var_18 > 0L)
        let (var_25: bool) =
            if var_23 then
                (var_18 <= 60000L)
            else
                false
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_27: int64) = (var_18 - var_14)
        let (var_28: int64) = (var_14 * 784L)
        if var_20 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_22 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_30: bool) =
            if var_23 then
                (var_18 <= 60000L)
            else
                false
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_32: int64) = (var_14 * 10L)
        let (var_33: bool) = (var_27 > 0L)
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_35: int64) = (var_27 * 10L)
        let (var_36: int64) = (var_35 * 4L)
        let (var_37: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_36: int64))
        let (var_38: int32) = (int32 var_27)
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_38: int32), (var_11: EnvStack2), (var_28: int64), (var_27: int64), (var_10: EnvStack2), (var_37: EnvStack2))
        let (var_39: bool) = (0L < var_27)
        let (var_40: bool) = (var_39 = false)
        if var_40 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_41: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_36: int64))
        let (var_42: (Union0 ref)) = var_41.mem_0
        let (var_43: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_42: (Union0 ref)))
        if var_40 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_44: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_45: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
        var_3.ClearMemoryAsync(var_43, 0uy, var_45, var_44)
        let (var_46: bool) = (8L > var_27)
        let (var_47: int64) =
            if var_46 then
                var_27
            else
                8L
        let (var_48: (Union0 ref)) = var_7.mem_0
        let (var_49: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_48: (Union0 ref)))
        let (var_50: (Union0 ref)) = var_37.mem_0
        let (var_51: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        // Cuda join point
        // method_16((var_27: int64), (var_49: ManagedCuda.BasicTypes.CUdeviceptr), (var_51: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_53: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_4, var_3)
        let (var_54: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_53.set_GridDimensions(var_54)
        let (var_55: uint32) = (uint32 var_47)
        let (var_56: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_55, 1u)
        var_53.set_BlockDimensions(var_56)
        let (var_57: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_59: (System.Object [])) = [|var_27; var_49; var_51; var_52|]: (System.Object [])
        var_53.RunAsync(var_57, var_59)
        if var_40 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_64: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_36: int64))
        let (var_65: bool) = (var_35 > 0L)
        let (var_66: bool) = (var_65 = false)
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_68: (Union0 ref)) = var_64.mem_0
        let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_68: (Union0 ref)))
        let (var_70: int64) = (var_35 - 1L)
        let (var_71: int64) = (var_70 / 128L)
        let (var_72: int64) = (var_71 + 1L)
        let (var_73: bool) = (64L > var_72)
        let (var_74: int64) =
            if var_73 then
                var_72
            else
                64L
        // Cuda join point
        // method_19((var_67: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_69: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_75: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_4, var_3)
        let (var_76: uint32) = (uint32 var_74)
        let (var_77: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_76, 1u, 1u)
        var_75.set_GridDimensions(var_77)
        let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_75.set_BlockDimensions(var_78)
        let (var_79: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_81: (System.Object [])) = [|var_67; var_35; var_69|]: (System.Object [])
        var_75.RunAsync(var_79, var_81)
        if var_40 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_82: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_36: int64))
        let (var_83: (Union0 ref)) = var_82.mem_0
        let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        if var_40 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_85: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_86: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_36)
        var_3.ClearMemoryAsync(var_84, 0uy, var_86, var_85)
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_68: (Union0 ref)))
        let (var_88: int64) = (var_32 * 4L)
        let (var_89: (Union0 ref)) = var_12.mem_0
        let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_91: ManagedCuda.BasicTypes.SizeT) = var_90.Pointer
        let (var_92: uint64) = uint64 var_91
        let (var_93: uint64) = (uint64 var_88)
        let (var_94: uint64) = (var_92 + var_93)
        let (var_95: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_94)
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_95)
        let (var_97: int64) =
            if var_73 then
                var_72
            else
                64L
        let (var_105: bool) = (var_97 > 0L)
        let (var_106: bool) = (var_105 = false)
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_107: int64) = (var_97 * 4L)
        let (var_108: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_107: int64))
        let (var_109: (Union0 ref)) = var_108.mem_0
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_109: (Union0 ref)))
        // Cuda join point
        // method_20((var_87: ManagedCuda.BasicTypes.CUdeviceptr), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_110: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: int64))
        let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_4, var_3)
        let (var_112: uint32) = (uint32 var_97)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_112, 1u, 1u)
        var_111.set_GridDimensions(var_113)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_111.set_BlockDimensions(var_114)
        let (var_115: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_117: (System.Object [])) = [|var_87; var_96; var_35; var_110; var_97|]: (System.Object [])
        var_111.RunAsync(var_115, var_117)
        let (var_118: bool) = (0L < var_97)
        let (var_119: bool) = (var_118 = false)
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_120: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_97))
        let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_109: (Union0 ref)))
        var_3.CopyToHost(var_120, var_121)
        let (var_122: float32) = 0.000000f
        let (var_123: int64) = 0L
        let (var_124: float32) = method_23((var_120: (float32 [])), (var_97: int64), (var_122: float32), (var_123: int64))
        var_109 := Union0Case1
        let (var_125: (float32 ref)) = (ref 0.000000f)
        let (var_126: float32) = (float32 var_27)
        let (var_127: float32) = (var_124 / var_126)
        let (var_128: (float32 ref)) = (ref 0.000000f)
        var_128 := 1.000000f
        let (var_129: float32) = (!var_128)
        let (var_130: float32) = (var_129 / var_126)
        let (var_131: float32) = (!var_125)
        let (var_132: float32) = (var_131 + var_130)
        var_125 := var_132
        let (var_133: float32) = (!var_125)
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_68: (Union0 ref)))
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_136: ManagedCuda.BasicTypes.SizeT) = var_135.Pointer
        let (var_137: uint64) = uint64 var_136
        let (var_138: uint64) = (var_137 + var_93)
        let (var_139: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_138)
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_139)
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_142: int64) =
            if var_73 then
                var_72
            else
                64L
        // Cuda join point
        // method_24((var_133: float32), (var_124: float32), (var_134: ManagedCuda.BasicTypes.CUdeviceptr), (var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_141: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_143: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_144: uint32) = (uint32 var_142)
        let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_144, 1u, 1u)
        var_143.set_GridDimensions(var_145)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_143.set_BlockDimensions(var_146)
        let (var_147: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_149: (System.Object [])) = [|var_133; var_124; var_134; var_140; var_35; var_141|]: (System.Object [])
        var_143.RunAsync(var_147, var_149)
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_150: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_68: (Union0 ref)))
        if var_66 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_42: (Union0 ref)))
        let (var_154: int64) =
            if var_73 then
                var_72
            else
                64L
        // Cuda join point
        // method_25((var_150: ManagedCuda.BasicTypes.CUdeviceptr), (var_151: ManagedCuda.BasicTypes.CUdeviceptr), (var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_35: int64), (var_153: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_155: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_4, var_3)
        let (var_156: uint32) = (uint32 var_154)
        let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_156, 1u, 1u)
        var_155.set_GridDimensions(var_157)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_155.set_BlockDimensions(var_158)
        let (var_159: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_161: (System.Object [])) = [|var_150; var_151; var_152; var_35; var_153|]: (System.Object [])
        var_155.RunAsync(var_159, var_161)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_38: int32), (var_11: EnvStack2), (var_28: int64), (var_27: int64), (var_41: EnvStack2), (var_9: EnvStack2))
        let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_42: (Union0 ref)))
        let (var_163: (Union0 ref)) = var_6.mem_0
        let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_163: (Union0 ref)))
        // Cuda join point
        // method_27((var_27: int64), (var_162: ManagedCuda.BasicTypes.CUdeviceptr), (var_164: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_165: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_4, var_3)
        let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_165.set_GridDimensions(var_166)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_165.set_BlockDimensions(var_167)
        let (var_168: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_170: (System.Object [])) = [|var_27; var_162; var_164|]: (System.Object [])
        var_165.RunAsync(var_168, var_170)
        let (var_171: (Union0 ref)) = var_9.mem_0
        let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        let (var_173: (Union0 ref)) = var_10.mem_0
        let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_173: (Union0 ref)))
        // Cuda join point
        // method_29((var_172: ManagedCuda.BasicTypes.CUdeviceptr), (var_174: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_175: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_4, var_3)
        let (var_176: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_175.set_GridDimensions(var_176)
        let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_175.set_BlockDimensions(var_177)
        let (var_178: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_180: (System.Object [])) = [|var_172; var_174|]: (System.Object [])
        var_175.RunAsync(var_178, var_180)
        let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        let (var_182: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_183: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_3.ClearMemoryAsync(var_181, 0uy, var_183, var_182)
        let (var_184: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_163: (Union0 ref)))
        let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_48: (Union0 ref)))
        // Cuda join point
        // method_31((var_184: ManagedCuda.BasicTypes.CUdeviceptr), (var_185: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_186: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_4, var_3)
        let (var_187: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_186.set_GridDimensions(var_187)
        let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_186.set_BlockDimensions(var_188)
        let (var_189: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_191: (System.Object [])) = [|var_184; var_185|]: (System.Object [])
        var_186.RunAsync(var_189, var_191)
        let (var_192: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_163: (Union0 ref)))
        let (var_193: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_194: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_3.ClearMemoryAsync(var_192, 0uy, var_194, var_193)
        let (var_195: float) = (float var_127)
        let (var_196: float) = (float var_27)
        let (var_197: float) = (var_195 * var_196)
        let (var_198: float) = (var_13 + var_197)
        var_83 := Union0Case1
        var_68 := Union0Case1
        var_42 := Union0Case1
        var_50 := Union0Case1
        method_14((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_198: float), (var_16: int64))
    else
        (Env7(var_13))
and method_33((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_15: int64)): Env8 =
    let (var_16: bool) = (var_15 < 60000L)
    if var_16 then
        let (var_17: int64) = (var_15 + 128L)
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
        let (var_38: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
        let (var_39: int32) = (int32 var_28)
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: EnvStack2), (var_29: int64), (var_28: int64), (var_10: EnvStack2), (var_38: EnvStack2))
        let (var_40: bool) = (0L < var_28)
        let (var_41: bool) = (var_40 = false)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_42: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
        let (var_43: (Union0 ref)) = var_42.mem_0
        let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_45: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_46: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
        var_3.ClearMemoryAsync(var_44, 0uy, var_46, var_45)
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
        let (var_54: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_4, var_3)
        let (var_55: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_54.set_GridDimensions(var_55)
        let (var_56: uint32) = (uint32 var_48)
        let (var_57: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, var_56, 1u)
        var_54.set_BlockDimensions(var_57)
        let (var_58: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_60: (System.Object [])) = [|var_28; var_50; var_52; var_53|]: (System.Object [])
        var_54.RunAsync(var_58, var_60)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_65: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
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
        let (var_76: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_4, var_3)
        let (var_77: uint32) = (uint32 var_75)
        let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_77, 1u, 1u)
        var_76.set_GridDimensions(var_78)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_76.set_BlockDimensions(var_79)
        let (var_80: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_82: (System.Object [])) = [|var_68; var_36; var_70|]: (System.Object [])
        var_76.RunAsync(var_80, var_82)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_83: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
        let (var_84: (Union0 ref)) = var_83.mem_0
        let (var_85: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_86: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_87: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_37)
        var_3.ClearMemoryAsync(var_85, 0uy, var_87, var_86)
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
        let (var_106: bool) = (var_98 > 0L)
        let (var_107: bool) = (var_106 = false)
        if var_107 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_108: int64) = (var_98 * 4L)
        let (var_109: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_108: int64))
        let (var_110: (Union0 ref)) = var_109.mem_0
        let (var_111: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_110: (Union0 ref)))
        // Cuda join point
        // method_20((var_88: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_111: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: int64))
        let (var_112: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_4, var_3)
        let (var_113: uint32) = (uint32 var_98)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_113, 1u, 1u)
        var_112.set_GridDimensions(var_114)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_112.set_BlockDimensions(var_115)
        let (var_116: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_118: (System.Object [])) = [|var_88; var_97; var_36; var_111; var_98|]: (System.Object [])
        var_112.RunAsync(var_116, var_118)
        let (var_119: bool) = (0L < var_98)
        let (var_120: bool) = (var_119 = false)
        if var_120 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_121: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_98))
        let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_110: (Union0 ref)))
        var_3.CopyToHost(var_121, var_122)
        let (var_123: float32) = 0.000000f
        let (var_124: int64) = 0L
        let (var_125: float32) = method_23((var_121: (float32 [])), (var_98: int64), (var_123: float32), (var_124: int64))
        var_110 := Union0Case1
        let (var_126: (float32 ref)) = (ref 0.000000f)
        let (var_127: float32) = (float32 var_28)
        let (var_128: float32) = (var_125 / var_127)
        let (var_129: (float32 ref)) = (ref 0.000000f)
        var_129 := 1.000000f
        let (var_130: float32) = (!var_129)
        let (var_131: float32) = (var_130 / var_127)
        let (var_132: float32) = (!var_126)
        let (var_133: float32) = (var_132 + var_131)
        var_126 := var_133
        let (var_134: float32) = (!var_126)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_137: ManagedCuda.BasicTypes.SizeT) = var_136.Pointer
        let (var_138: uint64) = uint64 var_137
        let (var_139: uint64) = (var_138 + var_94)
        let (var_140: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_139)
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_140)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        let (var_143: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_24((var_134: float32), (var_125: float32), (var_135: ManagedCuda.BasicTypes.CUdeviceptr), (var_141: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_142: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_144: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_145: uint32) = (uint32 var_143)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_145, 1u, 1u)
        var_144.set_GridDimensions(var_146)
        let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_144.set_BlockDimensions(var_147)
        let (var_148: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_150: (System.Object [])) = [|var_134; var_125; var_135; var_141; var_36; var_142|]: (System.Object [])
        var_144.RunAsync(var_148, var_150)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_84: (Union0 ref)))
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        let (var_155: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_25((var_151: ManagedCuda.BasicTypes.CUdeviceptr), (var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_153: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_154: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_4, var_3)
        let (var_157: uint32) = (uint32 var_155)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_157, 1u, 1u)
        var_156.set_GridDimensions(var_158)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_156.set_BlockDimensions(var_159)
        let (var_160: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_162: (System.Object [])) = [|var_151; var_152; var_153; var_36; var_154|]: (System.Object [])
        var_156.RunAsync(var_160, var_162)
        method_26((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_39: int32), (var_11: EnvStack2), (var_29: int64), (var_28: int64), (var_42: EnvStack2), (var_9: EnvStack2))
        let (var_163: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
        let (var_164: (Union0 ref)) = var_6.mem_0
        let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_164: (Union0 ref)))
        // Cuda join point
        // method_27((var_28: int64), (var_163: ManagedCuda.BasicTypes.CUdeviceptr), (var_165: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_166: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_4, var_3)
        let (var_167: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_166.set_GridDimensions(var_167)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_166.set_BlockDimensions(var_168)
        let (var_169: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_171: (System.Object [])) = [|var_28; var_163; var_165|]: (System.Object [])
        var_166.RunAsync(var_169, var_171)
        let (var_172: (Union0 ref)) = var_9.mem_0
        let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_172: (Union0 ref)))
        let (var_174: (Union0 ref)) = var_10.mem_0
        let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_174: (Union0 ref)))
        // Cuda join point
        // method_29((var_173: ManagedCuda.BasicTypes.CUdeviceptr), (var_175: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_176: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_4, var_3)
        let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_176.set_GridDimensions(var_177)
        let (var_178: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_176.set_BlockDimensions(var_178)
        let (var_179: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_181: (System.Object [])) = [|var_173; var_175|]: (System.Object [])
        var_176.RunAsync(var_179, var_181)
        let (var_182: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_172: (Union0 ref)))
        let (var_183: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_184: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_3.ClearMemoryAsync(var_182, 0uy, var_184, var_183)
        let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_164: (Union0 ref)))
        let (var_186: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
        // Cuda join point
        // method_31((var_185: ManagedCuda.BasicTypes.CUdeviceptr), (var_186: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_187: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_4, var_3)
        let (var_188: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_187.set_GridDimensions(var_188)
        let (var_189: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_187.set_BlockDimensions(var_189)
        let (var_190: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_192: (System.Object [])) = [|var_185; var_186|]: (System.Object [])
        var_187.RunAsync(var_190, var_192)
        let (var_193: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_164: (Union0 ref)))
        let (var_194: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_3.ClearMemoryAsync(var_193, 0uy, var_195, var_194)
        let (var_196: float) = (float var_128)
        let (var_197: float) = (float var_28)
        let (var_198: float) = (var_196 * var_197)
        let (var_199: float) = (var_14 + var_198)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_200: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_201: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_202: (Union0 ref)) = var_200.mem_0
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_202: (Union0 ref)))
        let (var_204: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_34((var_201: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_203: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_205: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_206: uint32) = (uint32 var_204)
        let (var_207: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_206, 1u, 1u)
        var_205.set_GridDimensions(var_207)
        let (var_208: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_205.set_BlockDimensions(var_208)
        let (var_209: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_211: (System.Object [])) = [|var_201; var_36; var_203|]: (System.Object [])
        var_205.RunAsync(var_209, var_211)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_212: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_37: int64))
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_213: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_214: ManagedCuda.BasicTypes.SizeT) = var_213.Pointer
        let (var_215: uint64) = uint64 var_214
        let (var_216: uint64) = (var_215 + var_94)
        let (var_217: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_216)
        let (var_218: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_217)
        if var_67 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_219: (Union0 ref)) = var_212.mem_0
        let (var_220: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_219: (Union0 ref)))
        let (var_221: int64) =
            if var_74 then
                var_73
            else
                64L
        // Cuda join point
        // method_34((var_218: ManagedCuda.BasicTypes.CUdeviceptr), (var_36: int64), (var_220: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_222: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_4, var_3)
        let (var_223: uint32) = (uint32 var_221)
        let (var_224: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_223, 1u, 1u)
        var_222.set_GridDimensions(var_224)
        let (var_225: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_222.set_BlockDimensions(var_225)
        let (var_226: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_228: (System.Object [])) = [|var_218; var_36; var_220|]: (System.Object [])
        var_222.RunAsync(var_226, var_228)
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_229: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_36))
        let (var_230: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_202: (Union0 ref)))
        var_3.CopyToHost(var_229, var_230)
        let (var_231: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_36))
        let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_219: (Union0 ref)))
        var_3.CopyToHost(var_231, var_232)
        let (var_233: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_234: string) = ""
        let (var_235: int64) = 0L
        method_35((var_233: System.Text.StringBuilder), (var_235: int64))
        let (var_236: System.Text.StringBuilder) = var_233.AppendLine("[|")
        let (var_237: int64) = 0L
        method_36((var_233: System.Text.StringBuilder), (var_234: string), (var_229: (float32 [])), (var_231: (float32 [])), (var_28: int64), (var_237: int64))
        let (var_238: int64) = 0L
        method_35((var_233: System.Text.StringBuilder), (var_238: int64))
        let (var_239: System.Text.StringBuilder) = var_233.AppendLine("|]")
        let (var_240: string) = var_233.ToString()
        let (var_241: string) = System.String.Format("{0}",var_240)
        System.Console.WriteLine(var_241)
        var_219 := Union0Case1
        var_202 := Union0Case1
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_242: int64) = (var_28 * 4L)
        let (var_243: EnvStack2) = method_10((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_242: int64))
        let (var_244: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_245: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_246: ManagedCuda.BasicTypes.SizeT) = var_245.Pointer
        let (var_247: uint64) = uint64 var_246
        let (var_248: uint64) = (var_247 + var_94)
        let (var_249: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_248)
        let (var_250: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_249)
        let (var_251: (Union0 ref)) = var_243.mem_0
        let (var_252: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_251: (Union0 ref)))
        // Cuda join point
        // method_39((var_28: int64), (var_244: ManagedCuda.BasicTypes.CUdeviceptr), (var_250: ManagedCuda.BasicTypes.CUdeviceptr), (var_252: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_253: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_4, var_3)
        let (var_254: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
        var_253.set_GridDimensions(var_254)
        let (var_255: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_253.set_BlockDimensions(var_255)
        let (var_256: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_258: (System.Object [])) = [|var_28; var_244; var_250; var_252|]: (System.Object [])
        var_253.RunAsync(var_256, var_258)
        let (var_259: int64) = 0L
        if var_41 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_260: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_28))
        let (var_261: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_251: (Union0 ref)))
        var_3.CopyToHost(var_260, var_261)
        let (var_262: int64) = var_260.LongLength
        let (var_263: int64) = 0L
        let (var_264: int64) = method_42((var_260: (float32 [])), (var_262: int64), (var_259: int64), (var_263: int64))
        var_251 := Union0Case1
        let (var_265: int64) = (var_13 + var_264)
        var_84 := Union0Case1
        var_69 := Union0Case1
        var_43 := Union0Case1
        var_51 := Union0Case1
        method_33((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_265: int64), (var_199: float), (var_17: int64))
    else
        (Env8(var_13, var_14))
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
and method_35((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_35((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_36((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: (float32 [])), (var_4: int64), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < var_4)
    if var_6 then
        let (var_7: bool) = (var_5 >= 0L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: int64) = (var_5 * 10L)
        let (var_10: int64) = 0L
        method_37((var_0: System.Text.StringBuilder), (var_10: int64))
        let (var_11: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_12: int64) = 0L
        let (var_13: string) = method_38((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_9: int64), (var_3: (float32 [])), (var_1: string), (var_12: int64))
        let (var_14: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_15: int64) = (var_5 + 1L)
        method_36((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: (float32 [])), (var_4: int64), (var_15: int64))
    else
        ()
and method_42((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
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
        method_42((var_0: (float32 [])), (var_1: int64), (var_8: int64), (var_9: int64))
    else
        var_2
and method_37((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_37((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_38((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_4: string), (var_5: int64)): string =
    let (var_6: bool) = (var_5 < 10L)
    if var_6 then
        let (var_7: System.Text.StringBuilder) = var_0.Append(var_4)
        let (var_8: bool) = (var_5 >= 0L)
        let (var_9: bool) = (var_8 = false)
        if var_9 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_10: int64) = (var_2 + var_5)
        let (var_11: float32) = var_1.[int32 var_10]
        let (var_12: float32) = var_3.[int32 var_10]
        let (var_13: string) = System.String.Format("{0}",var_12)
        let (var_14: string) = System.String.Format("{0}",var_11)
        let (var_15: string) = String.concat ", " [|var_14; var_13|]
        let (var_16: string) = System.String.Format("[{0}]",var_15)
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_16)
        let (var_18: string) = "; "
        let (var_19: int64) = (var_5 + 1L)
        method_38((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_18: string), (var_19: int64))
    else
        var_4
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
let (var_172: int64) = 0L
method_32((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_166: EnvStack2), (var_160: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_154: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_172: int64))
var_167 := Union0Case1
var_161 := Union0Case1
var_155 := Union0Case1
var_150 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_173)
var_46 := Union0Case1
var_1.Dispose()

