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
    __global__ void method_16(float * var_0, float * var_1, float * var_2);
    __global__ void method_19(float * var_0, float * var_1);
    __global__ void method_21(float * var_0, float * var_1, float * var_2);
    __global__ void method_25(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_26(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_28(float * var_0, float * var_1);
    __global__ void method_31(float * var_0, float * var_1);
    __global__ void method_33(float * var_0, float * var_1);
    __global__ void method_34(float * var_0, float * var_1, float * var_2);
    __device__ char method_17(Env0 * var_0);
    __device__ char method_18(Env0 * var_0);
    __device__ char method_20(Env0 * var_0);
    __device__ char method_22(Env1 * var_0);
    __device__ float method_23(float var_0, float var_1);
    __device__ char method_29(Env1 * var_0);
    __device__ char method_30(Env1 * var_0);
    __device__ char method_32(Env0 * var_0);
    __device__ char method_35(Env3 * var_0);
    __device__ Tuple4 method_36(Tuple4 var_0, Tuple4 var_1);
    
    __global__ void method_16(float * var_0, float * var_1, float * var_2) {
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
            long long int var_20 = (8 * var_7);
            long long int var_21 = (var_4 + var_20);
            Env0 var_22[1];
            var_22[0] = (make_Env0(var_21));
            while (method_18(var_22)) {
                Env0 var_24 = var_22[0];
                long long int var_25 = var_24.mem_0;
                long long int var_26 = (var_25 + 8);
                char var_27 = (var_25 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_25 < 10240);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_25 * 10);
                char var_33;
                if (var_16) {
                    var_33 = (var_14 < 10);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_31 + var_14);
                char var_37;
                if (var_27) {
                    var_37 = (var_25 < 10240);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                char var_40;
                if (var_16) {
                    var_40 = (var_14 < 10);
                } else {
                    var_40 = 0;
                }
                char var_41 = (var_40 == 0);
                if (var_41) {
                    // "Argument out of bounds."
                } else {
                }
                float var_42 = var_0[var_14];
                float var_43 = var_1[var_35];
                float var_44 = var_2[var_35];
                float var_45 = (var_42 + var_43);
                var_2[var_35] = var_45;
                var_22[0] = (make_Env0(var_26));
            }
            Env0 var_46 = var_22[0];
            long long int var_47 = var_46.mem_0;
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_48 = var_11[0];
        long long int var_49 = var_48.mem_0;
    }
    __global__ void method_19(float * var_0, float * var_1) {
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
        while (method_20(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 8192);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 102400);
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
                var_20 = (var_13 < 102400);
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
            float var_24 = (-var_22);
            float var_25 = exp(var_24);
            float var_26 = (1 + var_25);
            float var_27 = (1 / var_26);
            var_1[var_13] = var_27;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_28 = var_10[0];
        long long int var_29 = var_28.mem_0;
    }
    __global__ void method_21(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        Env1 var_12[1];
        var_12[0] = (make_Env1(var_10, var_11));
        while (method_22(var_12)) {
            Env1 var_14 = var_12[0];
            long long int var_15 = var_14.mem_0;
            float var_16 = var_14.mem_1;
            long long int var_17 = (var_15 + 8192);
            char var_18 = (var_15 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_15 < 102400);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_15];
            float var_23 = var_1[var_15];
            float var_24 = (var_23 - var_22);
            float var_25 = (var_24 * var_24);
            float var_26 = (var_16 + var_25);
            var_12[0] = (make_Env1(var_17, var_26));
        }
        Env1 var_27 = var_12[0];
        long long int var_28 = var_27.mem_0;
        float var_29 = var_27.mem_1;
        FunPointer2 var_32 = method_23;
        float var_33 = cub::BlockReduce<float,128>().Reduce(var_29, var_32);
        char var_34 = (var_3 == 0);
        if (var_34) {
            char var_35 = (var_6 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_6 < 64);
            } else {
                var_37 = 0;
            }
            char var_38 = (var_37 == 0);
            if (var_38) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_6] = var_33;
        } else {
        }
    }
    __global__ void method_25(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        Env0 var_13[1];
        var_13[0] = (make_Env0(var_12));
        while (method_20(var_13)) {
            Env0 var_15 = var_13[0];
            long long int var_16 = var_15.mem_0;
            long long int var_17 = (var_16 + 8192);
            char var_18 = (var_16 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_16 < 102400);
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
                var_23 = (var_16 < 102400);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            float var_25 = var_2[var_16];
            float var_26 = var_3[var_16];
            float var_27 = var_4[var_16];
            float var_28 = (var_25 - var_26);
            float var_29 = (2 * var_28);
            float var_30 = (var_0 * var_29);
            float var_31 = (var_27 + var_30);
            var_4[var_16] = var_31;
            var_13[0] = (make_Env0(var_17));
        }
        Env0 var_32 = var_13[0];
        long long int var_33 = var_32.mem_0;
    }
    __global__ void method_26(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 * 128);
        long long int var_11 = (var_10 + var_4);
        Env0 var_12[1];
        var_12[0] = (make_Env0(var_11));
        while (method_20(var_12)) {
            Env0 var_14 = var_12[0];
            long long int var_15 = var_14.mem_0;
            long long int var_16 = (var_15 + 8192);
            char var_17 = (var_15 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_15 < 102400);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            char var_22;
            if (var_17) {
                var_22 = (var_15 < 102400);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            float var_24 = var_0[var_15];
            float var_25 = var_1[var_15];
            float var_26 = var_2[var_15];
            float var_27 = var_3[var_15];
            float var_28 = (1 - var_26);
            float var_29 = (var_26 * var_28);
            float var_30 = (var_25 * var_29);
            float var_31 = (var_27 + var_30);
            var_3[var_15] = var_31;
            var_12[0] = (make_Env0(var_16));
        }
        Env0 var_32 = var_12[0];
        long long int var_33 = var_32.mem_0;
    }
    __global__ void method_28(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (10 * var_5);
        long long int var_9 = (var_2 + var_8);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_17(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 10);
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
            long long int var_22 = (8 * var_6);
            long long int var_23 = (var_3 + var_22);
            float var_24 = 0;
            Env1 var_25[1];
            var_25[0] = (make_Env1(var_23, var_24));
            while (method_29(var_25)) {
                Env1 var_27 = var_25[0];
                long long int var_28 = var_27.mem_0;
                float var_29 = var_27.mem_1;
                long long int var_30 = (var_28 + 8);
                char var_31 = (var_28 >= 0);
                char var_33;
                if (var_31) {
                    var_33 = (var_28 < 10240);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_28 * 10);
                char var_37;
                if (var_15) {
                    var_37 = (var_13 < 10);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_39 = (var_35 + var_13);
                float var_40 = var_0[var_39];
                float var_41 = (var_29 + var_40);
                var_25[0] = (make_Env1(var_30, var_41));
            }
            Env1 var_42 = var_25[0];
            long long int var_43 = var_42.mem_0;
            float var_44 = var_42.mem_1;
            __shared__ float var_45[70];
            char var_46 = (var_2 >= 0);
            char var_48;
            if (var_46) {
                var_48 = (var_2 < 10);
            } else {
                var_48 = 0;
            }
            char var_49 = (var_48 == 0);
            if (var_49) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_50 = (var_2 * 7);
            char var_51 = (var_3 != 0);
            if (var_51) {
                char var_52 = (var_3 >= 1);
                char var_54;
                if (var_52) {
                    var_54 = (var_3 < 8);
                } else {
                    var_54 = 0;
                }
                char var_55 = (var_54 == 0);
                if (var_55) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_56 = (var_3 - 1);
                long long int var_57 = (var_50 + var_56);
                var_45[var_57] = var_44;
            } else {
            }
            __syncthreads();
            char var_58 = (var_3 == 0);
            if (var_58) {
                Env1 var_59[1];
                var_59[0] = (make_Env1(1, var_44));
                while (method_30(var_59)) {
                    Env1 var_61 = var_59[0];
                    long long int var_62 = var_61.mem_0;
                    float var_63 = var_61.mem_1;
                    long long int var_64 = (var_62 + 1);
                    char var_65 = (var_62 >= 1);
                    char var_67;
                    if (var_65) {
                        var_67 = (var_62 < 8);
                    } else {
                        var_67 = 0;
                    }
                    char var_68 = (var_67 == 0);
                    if (var_68) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_69 = (var_62 - 1);
                    long long int var_70 = (var_50 + var_69);
                    float var_71 = var_45[var_70];
                    float var_72 = (var_63 + var_71);
                    var_59[0] = (make_Env1(var_64, var_72));
                }
                Env1 var_73 = var_59[0];
                long long int var_74 = var_73.mem_0;
                float var_75 = var_73.mem_1;
                float var_76 = var_1[var_13];
                float var_77 = (var_75 + var_76);
                var_1[var_13] = var_77;
            } else {
            }
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_78 = var_10[0];
        long long int var_79 = var_78.mem_0;
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
        while (method_32(var_10)) {
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
            float var_24 = (0.01 * var_22);
            float var_25 = (var_23 - var_24);
            var_1[var_13] = var_25;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_26 = var_10[0];
        long long int var_27 = var_26.mem_0;
    }
    __global__ void method_33(float * var_0, float * var_1) {
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
            float var_24 = (0.01 * var_22);
            float var_25 = (var_23 - var_24);
            var_1[var_13] = var_25;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_26 = var_10[0];
        long long int var_27 = var_26.mem_0;
    }
    __global__ void method_34(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_18(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 64);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 10240);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = (var_13 * 10);
            char var_21;
            if (var_15) {
                var_21 = (var_13 < 10240);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = (10 * var_6);
            long long int var_24 = (var_3 + var_23);
            float var_25 = __int_as_float(0xff800000);
            float var_26 = 0;
            Env3 var_27[1];
            var_27[0] = (make_Env3(var_24, make_Tuple4(var_25, var_26)));
            while (method_35(var_27)) {
                Env3 var_29 = var_27[0];
                long long int var_30 = var_29.mem_0;
                Tuple4 var_31 = var_29.mem_1;
                float var_32 = var_31.mem_0;
                float var_33 = var_31.mem_1;
                long long int var_34 = (var_30 + 10);
                char var_35 = (var_30 >= 0);
                char var_37;
                if (var_35) {
                    var_37 = (var_30 < 10);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_39 = (var_19 + var_30);
                float var_40 = var_0[var_39];
                float var_41 = var_1[var_39];
                char var_42 = (var_32 > var_40);
                Tuple4 var_43;
                if (var_42) {
                    var_43 = make_Tuple4(var_32, var_33);
                } else {
                    var_43 = make_Tuple4(var_40, var_41);
                }
                float var_44 = var_43.mem_0;
                float var_45 = var_43.mem_1;
                var_27[0] = (make_Env3(var_34, make_Tuple4(var_44, var_45)));
            }
            Env3 var_46 = var_27[0];
            long long int var_47 = var_46.mem_0;
            Tuple4 var_48 = var_46.mem_1;
            float var_49 = var_48.mem_0;
            float var_50 = var_48.mem_1;
            FunPointer5 var_53 = method_36;
            Tuple4 var_54 = cub::BlockReduce<Tuple4,10>().Reduce(make_Tuple4(var_49, var_50), var_53);
            float var_55 = var_54.mem_0;
            float var_56 = var_54.mem_1;
            char var_57 = (var_3 == 0);
            if (var_57) {
                char var_59;
                if (var_15) {
                    var_59 = (var_13 < 10240);
                } else {
                    var_59 = 0;
                }
                char var_60 = (var_59 == 0);
                if (var_60) {
                    // "Argument out of bounds."
                } else {
                }
                float var_61 = var_2[var_13];
                var_2[var_13] = var_56;
            } else {
            }
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_62 = var_10[0];
        long long int var_63 = var_62.mem_0;
    }
    __device__ char method_17(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_18(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10240);
    }
    __device__ char method_20(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 102400);
    }
    __device__ char method_22(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 102400);
    }
    __device__ float method_23(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ char method_29(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 10240);
    }
    __device__ char method_30(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 8);
    }
    __device__ char method_32(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 7840);
    }
    __device__ char method_35(Env3 * var_0) {
        Env3 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple4 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 10);
    }
    __device__ Tuple4 method_36(Tuple4 var_0, Tuple4 var_1) {
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
    let (var_14: bool) = (var_13 < 1L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: int64) = 0L
        let (var_18: Env7) = method_14((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_16: int64), (var_15: float), (var_17: int64))
        let (var_19: int64) = var_18.mem_0
        let (var_20: float) = var_18.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: float) = (var_20 / 10240.000000)
        let (var_22: string) = System.String.Format("Average of batch costs is {0}.",var_21)
        let (var_23: string) = System.String.Format("{0}",var_22)
        System.Console.WriteLine(var_23)
        let (var_24: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_19,10240L)
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
    let (var_16: bool) = (var_15 < 10240L)
    if var_16 then
        let (var_17: int64) = (var_15 + 10240L)
        let (var_18: bool) = (var_15 >= 0L)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_20: bool) = (var_17 > 0L)
        let (var_22: bool) =
            if var_20 then
                (var_17 <= 10240L)
            else
                false
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_24: int64) = (var_15 * 784L)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_26: bool) =
            if var_20 then
                (var_17 <= 10240L)
            else
                false
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_28: int64) = (var_15 * 10L)
        let (var_29: int64) = 409600L
        let (var_30: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_29: int64))
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_24: int64), (var_10: EnvStack2), (var_30: EnvStack2))
        let (var_31: int64) = 409600L
        let (var_32: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_31: int64))
        let (var_33: (Union0 ref)) = var_32.mem_0
        let (var_34: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        let (var_35: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
        var_0.ClearMemoryAsync(var_34, 0uy, var_36, var_35)
        let (var_37: (Union0 ref)) = var_7.mem_0
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_37: (Union0 ref)))
        let (var_39: (Union0 ref)) = var_30.mem_0
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        // Cuda join point
        // method_16((var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_41: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_43: (System.Object [])) = [|var_38; var_40; var_41|]: (System.Object [])
        let (var_44: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_1, var_0)
        let (var_45: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_44.set_GridDimensions(var_45)
        let (var_46: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_44.set_BlockDimensions(var_46)
        let (var_47: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_44.RunAsync(var_47, var_43)
        let (var_52: int64) = 409600L
        let (var_53: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_52: int64))
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_55: (Union0 ref)) = var_53.mem_0
        let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_55: (Union0 ref)))
        // Cuda join point
        // method_19((var_54: ManagedCuda.BasicTypes.CUdeviceptr), (var_56: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_58: (System.Object [])) = [|var_54; var_56|]: (System.Object [])
        let (var_59: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_1, var_0)
        let (var_60: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_59.set_GridDimensions(var_60)
        let (var_61: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_59.set_BlockDimensions(var_61)
        let (var_62: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_59.RunAsync(var_62, var_58)
        let (var_63: int64) = 409600L
        let (var_64: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_63: int64))
        let (var_65: (Union0 ref)) = var_64.mem_0
        let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_67: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_68: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
        var_0.ClearMemoryAsync(var_66, 0uy, var_68, var_67)
        let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_55: (Union0 ref)))
        let (var_70: int64) = (var_28 * 4L)
        let (var_71: (Union0 ref)) = var_12.mem_0
        let (var_72: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_73: ManagedCuda.BasicTypes.SizeT) = var_72.Pointer
        let (var_74: uint64) = uint64 var_73
        let (var_75: uint64) = (uint64 var_70)
        let (var_76: uint64) = (var_74 + var_75)
        let (var_77: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_76)
        let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_77)
        let (var_81: int64) = 256L
        let (var_82: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_81: int64))
        let (var_83: (Union0 ref)) = var_82.mem_0
        let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        // Cuda join point
        // method_21((var_69: ManagedCuda.BasicTypes.CUdeviceptr), (var_78: ManagedCuda.BasicTypes.CUdeviceptr), (var_84: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_86: (System.Object [])) = [|var_69; var_78; var_84|]: (System.Object [])
        let (var_87: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_1, var_0)
        let (var_88: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_87.set_GridDimensions(var_88)
        let (var_89: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_87.set_BlockDimensions(var_89)
        let (var_90: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_87.RunAsync(var_90, var_86)
        let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_92: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(64L))
        var_0.CopyToHost(var_92, var_91)
        var_0.Synchronize()
        let (var_93: float32) = 0.000000f
        let (var_94: int64) = 0L
        let (var_95: float32) = method_24((var_92: (float32 [])), (var_93: float32), (var_94: int64))
        var_83 := Union0Case1
        let (var_96: (float32 ref)) = (ref 0.000000f)
        let (var_97: float32) = (var_95 / 10240.000000f)
        let (var_98: (float32 ref)) = (ref 0.000000f)
        var_98 := 1.000000f
        let (var_99: float32) = (!var_98)
        let (var_100: float32) = (var_99 / 10240.000000f)
        System.Console.WriteLine("I am in host_map back.")
        let (var_101: float32) = (!var_96)
        let (var_102: float32) = (var_101 + var_100)
        var_96 := var_102
        let (var_103: float32) = (!var_96)
        System.Console.WriteLine("I am in map_redo back.")
        let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_55: (Union0 ref)))
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_106: ManagedCuda.BasicTypes.SizeT) = var_105.Pointer
        let (var_107: uint64) = uint64 var_106
        let (var_108: uint64) = (var_107 + var_75)
        let (var_109: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_108)
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_109)
        let (var_111: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        // Cuda join point
        // method_25((var_103: float32), (var_95: float32), (var_104: ManagedCuda.BasicTypes.CUdeviceptr), (var_110: ManagedCuda.BasicTypes.CUdeviceptr), (var_111: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_113: (System.Object [])) = [|var_103; var_95; var_104; var_110; var_111|]: (System.Object [])
        let (var_114: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_1, var_0)
        let (var_115: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_114.set_GridDimensions(var_115)
        let (var_116: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_114.set_BlockDimensions(var_116)
        let (var_117: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_114.RunAsync(var_117, var_113)
        System.Console.WriteLine("I am in map back.")
        let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_119: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_120: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_55: (Union0 ref)))
        let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        // Cuda join point
        // method_26((var_118: ManagedCuda.BasicTypes.CUdeviceptr), (var_119: ManagedCuda.BasicTypes.CUdeviceptr), (var_120: ManagedCuda.BasicTypes.CUdeviceptr), (var_121: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_123: (System.Object [])) = [|var_118; var_119; var_120; var_121|]: (System.Object [])
        let (var_124: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_1, var_0)
        let (var_125: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_124.set_GridDimensions(var_125)
        let (var_126: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_124.set_BlockDimensions(var_126)
        let (var_127: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_124.RunAsync(var_127, var_123)
        System.Console.WriteLine("I am in matmultb back.")
        method_27((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_24: int64), (var_32: EnvStack2), (var_9: EnvStack2))
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        let (var_129: (Union0 ref)) = var_6.mem_0
        let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_129: (Union0 ref)))
        // Cuda join point
        // method_28((var_128: ManagedCuda.BasicTypes.CUdeviceptr), (var_130: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_132: (System.Object [])) = [|var_128; var_130|]: (System.Object [])
        let (var_133: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_1, var_0)
        let (var_134: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_133.set_GridDimensions(var_134)
        let (var_135: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_133.set_BlockDimensions(var_135)
        let (var_136: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_133.RunAsync(var_136, var_132)
        let (var_137: (Union0 ref)) = var_9.mem_0
        let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_137: (Union0 ref)))
        let (var_139: (Union0 ref)) = var_10.mem_0
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_139: (Union0 ref)))
        // Cuda join point
        // method_31((var_138: ManagedCuda.BasicTypes.CUdeviceptr), (var_140: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_142: (System.Object [])) = [|var_138; var_140|]: (System.Object [])
        let (var_143: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_1, var_0)
        let (var_144: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_143.set_GridDimensions(var_144)
        let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_143.set_BlockDimensions(var_145)
        let (var_146: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_143.RunAsync(var_146, var_142)
        let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_137: (Union0 ref)))
        let (var_148: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_149: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_147, 0uy, var_149, var_148)
        let (var_150: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_129: (Union0 ref)))
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_37: (Union0 ref)))
        // Cuda join point
        // method_33((var_150: ManagedCuda.BasicTypes.CUdeviceptr), (var_151: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_153: (System.Object [])) = [|var_150; var_151|]: (System.Object [])
        let (var_154: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_1, var_0)
        let (var_155: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_154.set_GridDimensions(var_155)
        let (var_156: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_154.set_BlockDimensions(var_156)
        let (var_157: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_154.RunAsync(var_157, var_153)
        let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_129: (Union0 ref)))
        let (var_159: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_160: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_158, 0uy, var_160, var_159)
        let (var_161: float) = (float var_97)
        let (var_162: float) = (var_161 * 10240.000000)
        let (var_163: float) = (var_14 + var_162)
        let (var_164: int64) = 40960L
        let (var_165: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_164: int64))
        let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_55: (Union0 ref)))
        let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_168: ManagedCuda.BasicTypes.SizeT) = var_167.Pointer
        let (var_169: uint64) = uint64 var_168
        let (var_170: uint64) = (var_169 + var_75)
        let (var_171: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_170)
        let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_171)
        let (var_173: (Union0 ref)) = var_165.mem_0
        let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_173: (Union0 ref)))
        // Cuda join point
        // method_34((var_166: ManagedCuda.BasicTypes.CUdeviceptr), (var_172: ManagedCuda.BasicTypes.CUdeviceptr), (var_174: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_176: (System.Object [])) = [|var_166; var_172; var_174|]: (System.Object [])
        let (var_177: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_1, var_0)
        let (var_178: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
        var_177.set_GridDimensions(var_178)
        let (var_179: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_177.set_BlockDimensions(var_179)
        let (var_180: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_177.RunAsync(var_180, var_176)
        let (var_181: int64) = 0L
        let (var_182: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_173: (Union0 ref)))
        let (var_183: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10240L))
        var_0.CopyToHost(var_183, var_182)
        var_0.Synchronize()
        let (var_184: int64) = var_183.LongLength
        let (var_185: int64) = 0L
        let (var_186: int64) = method_37((var_183: (float32 [])), (var_184: int64), (var_181: int64), (var_185: int64))
        var_173 := Union0Case1
        let (var_187: int64) = (var_13 + var_186)
        var_65 := Union0Case1
        var_55 := Union0Case1
        var_33 := Union0Case1
        var_39 := Union0Case1
        method_38((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_187: int64), (var_163: float), (var_17: int64))
    else
        (Env7(var_13, var_14))
and method_15((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: int64), (var_3: EnvStack2), (var_4: EnvStack2)): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: (Union0 ref)) = var_1.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: ManagedCuda.BasicTypes.SizeT) = var_10.Pointer
    let (var_12: uint64) = uint64 var_11
    let (var_13: uint64) = (uint64 var_8)
    let (var_14: uint64) = (var_12 + var_13)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: (Union0 ref)) = var_3.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_17: (Union0 ref)))
    let (var_19: (float32 ref)) = (ref 0.000000f)
    let (var_20: (Union0 ref)) = var_4.mem_0
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_20: (Union0 ref)))
    let (var_22: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 10240, 10, 784, var_7, var_16, 10240, var_18, 784, var_19, var_21, 10240)
    if var_22 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_22)
and method_24((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 64L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = var_0.[int32 var_2]
        let (var_7: float32) = (var_1 + var_6)
        let (var_8: int64) = (var_2 + 1L)
        method_24((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_27((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: int64), (var_3: EnvStack2), (var_4: EnvStack2)): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: (Union0 ref)) = var_1.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: ManagedCuda.BasicTypes.SizeT) = var_10.Pointer
    let (var_12: uint64) = uint64 var_11
    let (var_13: uint64) = (uint64 var_8)
    let (var_14: uint64) = (var_12 + var_13)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: (Union0 ref)) = var_3.mem_0
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_17: (Union0 ref)))
    let (var_19: (float32 ref)) = (ref 1.000000f)
    let (var_20: (Union0 ref)) = var_4.mem_0
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_20: (Union0 ref)))
    let (var_22: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 784, 10, 10240, var_7, var_16, 10240, var_18, 10240, var_19, var_21, 784)
    if var_22 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_22)
and method_37((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
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
        method_37((var_0: (float32 [])), (var_1: int64), (var_8: int64), (var_9: int64))
    else
        var_2
and method_38((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_15: int64), (var_16: float), (var_17: int64)): Env7 =
    let (var_18: bool) = (var_17 < 10240L)
    if var_18 then
        let (var_19: int64) = (var_17 + 10240L)
        let (var_20: bool) = (var_17 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_22: bool) = (var_19 > 0L)
        let (var_24: bool) =
            if var_22 then
                (var_19 <= 10240L)
            else
                false
        let (var_25: bool) = (var_24 = false)
        if var_25 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_26: int64) = (var_17 * 784L)
        if var_21 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_28: bool) =
            if var_22 then
                (var_19 <= 10240L)
            else
                false
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_30: int64) = (var_17 * 10L)
        let (var_31: int64) = 409600L
        let (var_32: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_31: int64))
        method_15((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_26: int64), (var_10: EnvStack2), (var_32: EnvStack2))
        let (var_33: int64) = 409600L
        let (var_34: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_33: int64))
        let (var_35: (Union0 ref)) = var_34.mem_0
        let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_35: (Union0 ref)))
        let (var_37: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
        var_0.ClearMemoryAsync(var_36, 0uy, var_38, var_37)
        let (var_39: (Union0 ref)) = var_7.mem_0
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_41: (Union0 ref)) = var_32.mem_0
        let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        let (var_43: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        // Cuda join point
        // method_16((var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_42: ManagedCuda.BasicTypes.CUdeviceptr), (var_43: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_45: (System.Object [])) = [|var_40; var_42; var_43|]: (System.Object [])
        let (var_46: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_1, var_0)
        let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_46.set_GridDimensions(var_47)
        let (var_48: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_46.set_BlockDimensions(var_48)
        let (var_49: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_46.RunAsync(var_49, var_45)
        let (var_54: int64) = 409600L
        let (var_55: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_54: int64))
        let (var_56: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        let (var_57: (Union0 ref)) = var_55.mem_0
        let (var_58: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
        // Cuda join point
        // method_19((var_56: ManagedCuda.BasicTypes.CUdeviceptr), (var_58: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_60: (System.Object [])) = [|var_56; var_58|]: (System.Object [])
        let (var_61: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_1, var_0)
        let (var_62: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_61.set_GridDimensions(var_62)
        let (var_63: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_61.set_BlockDimensions(var_63)
        let (var_64: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_61.RunAsync(var_64, var_60)
        let (var_65: int64) = 409600L
        let (var_66: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_65: int64))
        let (var_67: (Union0 ref)) = var_66.mem_0
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
        let (var_69: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_70: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
        var_0.ClearMemoryAsync(var_68, 0uy, var_70, var_69)
        let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
        let (var_72: int64) = (var_30 * 4L)
        let (var_73: (Union0 ref)) = var_12.mem_0
        let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_73: (Union0 ref)))
        let (var_75: ManagedCuda.BasicTypes.SizeT) = var_74.Pointer
        let (var_76: uint64) = uint64 var_75
        let (var_77: uint64) = (uint64 var_72)
        let (var_78: uint64) = (var_76 + var_77)
        let (var_79: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_78)
        let (var_80: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_79)
        let (var_83: int64) = 256L
        let (var_84: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_83: int64))
        let (var_85: (Union0 ref)) = var_84.mem_0
        let (var_86: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_85: (Union0 ref)))
        // Cuda join point
        // method_21((var_71: ManagedCuda.BasicTypes.CUdeviceptr), (var_80: ManagedCuda.BasicTypes.CUdeviceptr), (var_86: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_88: (System.Object [])) = [|var_71; var_80; var_86|]: (System.Object [])
        let (var_89: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_1, var_0)
        let (var_90: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_89.set_GridDimensions(var_90)
        let (var_91: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_89.set_BlockDimensions(var_91)
        let (var_92: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_89.RunAsync(var_92, var_88)
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_85: (Union0 ref)))
        let (var_94: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(64L))
        var_0.CopyToHost(var_94, var_93)
        var_0.Synchronize()
        let (var_95: float32) = 0.000000f
        let (var_96: int64) = 0L
        let (var_97: float32) = method_24((var_94: (float32 [])), (var_95: float32), (var_96: int64))
        var_85 := Union0Case1
        let (var_98: (float32 ref)) = (ref 0.000000f)
        let (var_99: float32) = (var_97 / 10240.000000f)
        let (var_100: (float32 ref)) = (ref 0.000000f)
        var_100 := 1.000000f
        let (var_101: float32) = (!var_100)
        let (var_102: float32) = (var_101 / 10240.000000f)
        System.Console.WriteLine("I am in host_map back.")
        let (var_103: float32) = (!var_98)
        let (var_104: float32) = (var_103 + var_102)
        var_98 := var_104
        let (var_105: float32) = (!var_98)
        System.Console.WriteLine("I am in map_redo back.")
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_73: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.SizeT) = var_107.Pointer
        let (var_109: uint64) = uint64 var_108
        let (var_110: uint64) = (var_109 + var_77)
        let (var_111: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_110)
        let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_111)
        let (var_113: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
        // Cuda join point
        // method_25((var_105: float32), (var_97: float32), (var_106: ManagedCuda.BasicTypes.CUdeviceptr), (var_112: ManagedCuda.BasicTypes.CUdeviceptr), (var_113: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_115: (System.Object [])) = [|var_105; var_97; var_106; var_112; var_113|]: (System.Object [])
        let (var_116: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_1, var_0)
        let (var_117: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_116.set_GridDimensions(var_117)
        let (var_118: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_116.set_BlockDimensions(var_118)
        let (var_119: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_116.RunAsync(var_119, var_115)
        System.Console.WriteLine("I am in map back.")
        let (var_120: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
        let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_35: (Union0 ref)))
        // Cuda join point
        // method_26((var_120: ManagedCuda.BasicTypes.CUdeviceptr), (var_121: ManagedCuda.BasicTypes.CUdeviceptr), (var_122: ManagedCuda.BasicTypes.CUdeviceptr), (var_123: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_125: (System.Object [])) = [|var_120; var_121; var_122; var_123|]: (System.Object [])
        let (var_126: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_1, var_0)
        let (var_127: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_126.set_GridDimensions(var_127)
        let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_126.set_BlockDimensions(var_128)
        let (var_129: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_126.RunAsync(var_129, var_125)
        System.Console.WriteLine("I am in matmultb back.")
        method_27((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_26: int64), (var_34: EnvStack2), (var_9: EnvStack2))
        let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_35: (Union0 ref)))
        let (var_131: (Union0 ref)) = var_6.mem_0
        let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        // Cuda join point
        // method_28((var_130: ManagedCuda.BasicTypes.CUdeviceptr), (var_132: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_134: (System.Object [])) = [|var_130; var_132|]: (System.Object [])
        let (var_135: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_1, var_0)
        let (var_136: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_135.set_GridDimensions(var_136)
        let (var_137: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_135.set_BlockDimensions(var_137)
        let (var_138: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_135.RunAsync(var_138, var_134)
        let (var_139: (Union0 ref)) = var_9.mem_0
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_139: (Union0 ref)))
        let (var_141: (Union0 ref)) = var_10.mem_0
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
        // Cuda join point
        // method_31((var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_142: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_144: (System.Object [])) = [|var_140; var_142|]: (System.Object [])
        let (var_145: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_1, var_0)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_145.set_GridDimensions(var_146)
        let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_145.set_BlockDimensions(var_147)
        let (var_148: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_145.RunAsync(var_148, var_144)
        let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_139: (Union0 ref)))
        let (var_150: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_151: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_149, 0uy, var_151, var_150)
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        // Cuda join point
        // method_33((var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_153: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_155: (System.Object [])) = [|var_152; var_153|]: (System.Object [])
        let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_1, var_0)
        let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_156.set_GridDimensions(var_157)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_156.set_BlockDimensions(var_158)
        let (var_159: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_156.RunAsync(var_159, var_155)
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        let (var_161: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_162: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_160, 0uy, var_162, var_161)
        let (var_163: float) = (float var_99)
        let (var_164: float) = (var_163 * 10240.000000)
        let (var_165: float) = (var_16 + var_164)
        let (var_166: int64) = 40960L
        let (var_167: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_166: int64))
        let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_57: (Union0 ref)))
        let (var_169: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_73: (Union0 ref)))
        let (var_170: ManagedCuda.BasicTypes.SizeT) = var_169.Pointer
        let (var_171: uint64) = uint64 var_170
        let (var_172: uint64) = (var_171 + var_77)
        let (var_173: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_172)
        let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_173)
        let (var_175: (Union0 ref)) = var_167.mem_0
        let (var_176: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_175: (Union0 ref)))
        // Cuda join point
        // method_34((var_168: ManagedCuda.BasicTypes.CUdeviceptr), (var_174: ManagedCuda.BasicTypes.CUdeviceptr), (var_176: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_178: (System.Object [])) = [|var_168; var_174; var_176|]: (System.Object [])
        let (var_179: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_1, var_0)
        let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
        var_179.set_GridDimensions(var_180)
        let (var_181: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_179.set_BlockDimensions(var_181)
        let (var_182: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_179.RunAsync(var_182, var_178)
        let (var_183: int64) = 0L
        let (var_184: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_175: (Union0 ref)))
        let (var_185: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10240L))
        var_0.CopyToHost(var_185, var_184)
        var_0.Synchronize()
        let (var_186: int64) = var_185.LongLength
        let (var_187: int64) = 0L
        let (var_188: int64) = method_37((var_185: (float32 [])), (var_186: int64), (var_183: int64), (var_187: int64))
        var_175 := Union0Case1
        let (var_189: int64) = (var_15 + var_188)
        var_67 := Union0Case1
        var_57 := Union0Case1
        var_35 := Union0Case1
        var_41 := Union0Case1
        method_38((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_189: int64), (var_165: float), (var_19: int64))
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

