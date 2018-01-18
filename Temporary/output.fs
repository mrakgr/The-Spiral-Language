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
    __global__ void method_7(float * var_0, float * var_1, float * var_2);
    __global__ void method_10(float * var_0, float * var_1);
    __global__ void method_12(float * var_0, float * var_1, float * var_2);
    __global__ void method_16(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_17(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_18(float * var_0, float * var_1);
    __global__ void method_20(float * var_0, float * var_1);
    __global__ void method_22(float * var_0, float * var_1);
    __global__ void method_23(float * var_0, float * var_1, char * var_2);
    __device__ char method_8(Env0 * var_0);
    __device__ char method_9(Env0 * var_0);
    __device__ char method_11(Env0 * var_0);
    __device__ char method_13(Env1 * var_0);
    __device__ float method_14(float var_0, float var_1);
    __device__ char method_19(Env1 * var_0);
    __device__ char method_21(Env0 * var_0);
    __device__ char method_24(Env3 * var_0);
    __device__ Tuple4 method_25(Tuple4 var_0, Tuple4 var_1);
    
    __global__ void method_7(float * var_0, float * var_1, float * var_2) {
        printf("Inside method_7 with args: [%llu, %llu, %llu]\n", var_0, var_1, var_2);
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_3 + var_6);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_8(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 1);
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
            long long int var_19 = (var_4 + var_7);
            Env0 var_20[1];
            var_20[0] = (make_Env0(var_19));
            while (method_9(var_20)) {
                Env0 var_22 = var_20[0];
                long long int var_23 = var_22.mem_0;
                long long int var_24 = (var_23 + 1);
                char var_25 = (var_23 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_23 < 32);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_23 * 10);
                char var_31;
                if (var_15) {
                    var_31 = (var_13 < 10);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_13);
                char var_35;
                if (var_25) {
                    var_35 = (var_23 < 32);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                char var_38;
                if (var_15) {
                    var_38 = (var_13 < 10);
                } else {
                    var_38 = 0;
                }
                char var_39 = (var_38 == 0);
                if (var_39) {
                    // "Argument out of bounds."
                } else {
                }
                float var_40 = var_0[var_13];
                float var_41 = var_1[var_33];
                float var_42 = var_2[var_33];
                float var_43 = (var_40 + var_41);
                var_2[var_33] = var_43;
                var_20[0] = (make_Env0(var_24));
            }
            Env0 var_44 = var_20[0];
            long long int var_45 = var_44.mem_0;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_46 = var_10[0];
        long long int var_47 = var_46.mem_0;
    }
    __global__ void method_10(float * var_0, float * var_1) {
        printf("Inside method_10 with args: [%llu, %llu]\n", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_11(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 320);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_12 < 320);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_12];
            float var_22 = var_1[var_12];
            float var_23 = (-var_21);
            float var_24 = exp(var_23);
            float var_25 = (1 + var_24);
            float var_26 = (1 / var_25);
            var_1[var_12] = var_26;
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_27 = var_9[0];
        long long int var_28 = var_27.mem_0;
    }
    __global__ void method_12(float * var_0, float * var_1, float * var_2) {
        printf("Inside method_12 with args: [%llu, %llu, %llu]\n", var_0, var_1, var_2);
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 + var_3);
        float var_10 = 0;
        Env1 var_11[1];
        var_11[0] = (make_Env1(var_9, var_10));
        while (method_13(var_11)) {
            Env1 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            float var_15 = var_13.mem_1;
            long long int var_16 = (var_14 + 1);
            char var_17 = (var_14 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_14 < 320);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_14];
            float var_22 = var_1[var_14];
            float var_23 = log(var_21);
            float var_24 = (var_22 * var_23);
            float var_25 = (1 - var_22);
            float var_26 = (1 - var_21);
            float var_27 = log(var_26);
            float var_28 = (var_25 * var_27);
            float var_29 = (var_24 + var_28);
            float var_30 = (-var_29);
            float var_31 = (var_15 + var_30);
            var_11[0] = (make_Env1(var_16, var_31));
        }
        Env1 var_32 = var_11[0];
        long long int var_33 = var_32.mem_0;
        float var_34 = var_32.mem_1;
        FunPointer2 var_37 = method_14;
        float var_38 = cub::BlockReduce<float,1>().Reduce(var_34, var_37);
        char var_39 = (var_3 == 0);
        if (var_39) {
            char var_40 = (var_6 >= 0);
            char var_42;
            if (var_40) {
                var_42 = (var_6 < 1);
            } else {
                var_42 = 0;
            }
            char var_43 = (var_42 == 0);
            if (var_43) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_6] = var_38;
        } else {
        }
    }
    __global__ void method_16(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        printf("Inside method_16 with args: [%f, %f, %llu, %llu, %llu]\n", var_0, var_1, var_2, var_3, var_4);
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 + var_5);
        Env0 var_12[1];
        var_12[0] = (make_Env0(var_11));
        while (method_11(var_12)) {
            Env0 var_14 = var_12[0];
            long long int var_15 = var_14.mem_0;
            long long int var_16 = (var_15 + 1);
            char var_17 = (var_15 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_15 < 320);
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
                var_22 = (var_15 < 320);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            float var_24 = var_2[var_15];
            float var_25 = var_3[var_15];
            float var_26 = var_4[var_15];
            float var_27 = (var_24 - var_25);
            float var_28 = (1 - var_24);
            float var_29 = (var_24 * var_28);
            float var_30 = (var_27 / var_29);
            float var_31 = (var_0 * var_30);
            float var_32 = (var_26 + var_31);
            var_4[var_15] = var_32;
            var_12[0] = (make_Env0(var_16));
        }
        Env0 var_33 = var_12[0];
        long long int var_34 = var_33.mem_0;
    }
    __global__ void method_17(float * var_0, float * var_1, float * var_2, float * var_3) {
        printf("Inside method_17 with args: [%llu, %llu, %llu, %llu]\n", var_0, var_1, var_2, var_3);
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 + var_4);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_11(var_11)) {
            Env0 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            long long int var_15 = (var_14 + 1);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < 320);
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
                var_21 = (var_14 < 320);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            float var_23 = var_0[var_14];
            float var_24 = var_1[var_14];
            float var_25 = var_2[var_14];
            float var_26 = var_3[var_14];
            float var_27 = (1 - var_25);
            float var_28 = (var_25 * var_27);
            float var_29 = (var_24 * var_28);
            float var_30 = (var_26 + var_29);
            var_3[var_14] = var_30;
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_31 = var_11[0];
        long long int var_32 = var_31.mem_0;
    }
    __global__ void method_18(float * var_0, float * var_1) {
        printf("Inside method_18 with args: [%llu, %llu]\n", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_2 + var_5);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_8(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 10);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_12 < 10);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_21 = (var_3 + var_6);
            float var_22 = 0;
            Env1 var_23[1];
            var_23[0] = (make_Env1(var_21, var_22));
            while (method_19(var_23)) {
                Env1 var_25 = var_23[0];
                long long int var_26 = var_25.mem_0;
                float var_27 = var_25.mem_1;
                long long int var_28 = (var_26 + 1);
                char var_29 = (var_26 >= 0);
                char var_31;
                if (var_29) {
                    var_31 = (var_26 < 32);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_26 * 10);
                char var_35;
                if (var_14) {
                    var_35 = (var_12 < 10);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_37 = (var_33 + var_12);
                float var_38 = var_0[var_37];
                float var_39 = (var_27 + var_38);
                var_23[0] = (make_Env1(var_28, var_39));
            }
            Env1 var_40 = var_23[0];
            long long int var_41 = var_40.mem_0;
            float var_42 = var_40.mem_1;
            float var_43 = var_1[var_12];
            float var_44 = (var_42 + var_43);
            var_1[var_12] = var_44;
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_45 = var_9[0];
        long long int var_46 = var_45.mem_0;
    }
    __global__ void method_20(float * var_0, float * var_1) {
        printf("Inside method_20 with args: [%llu, %llu]\n", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_21(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 7840);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_12 < 7840);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_12];
            float var_22 = var_1[var_12];
            float var_23 = (0.5 * var_21);
            float var_24 = (var_22 - var_23);
            var_1[var_12] = var_24;
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_25 = var_9[0];
        long long int var_26 = var_25.mem_0;
    }
    __global__ void method_22(float * var_0, float * var_1) {
        printf("Inside method_22 with args: [%llu, %llu]\n", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_8(var_9)) {
            Env0 var_11 = var_9[0];
            long long int var_12 = var_11.mem_0;
            long long int var_13 = (var_12 + 1);
            char var_14 = (var_12 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_12 < 10);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // "Argument out of bounds."
            } else {
            }
            char var_19;
            if (var_14) {
                var_19 = (var_12 < 10);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            float var_21 = var_0[var_12];
            float var_22 = var_1[var_12];
            float var_23 = (0.5 * var_21);
            float var_24 = (var_22 - var_23);
            var_1[var_12] = var_24;
            var_9[0] = (make_Env0(var_13));
        }
        Env0 var_25 = var_9[0];
        long long int var_26 = var_25.mem_0;
    }
    __global__ void method_23(float * var_0, float * var_1, char * var_2) {
        printf("Inside method_23 with args: [%llu, %llu, %llu]\n", var_0, var_1, var_2);
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_9(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 1);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 32);
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
                var_21 = (var_13 < 32);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = (var_3 + var_6);
            float var_24 = __int_as_float(0xff800000);
            float var_25 = 0;
            Env3 var_26[1];
            var_26[0] = (make_Env3(var_23, make_Tuple4(var_24, var_25)));
            while (method_24(var_26)) {
                Env3 var_28 = var_26[0];
                long long int var_29 = var_28.mem_0;
                Tuple4 var_30 = var_28.mem_1;
                float var_31 = var_30.mem_0;
                float var_32 = var_30.mem_1;
                long long int var_33 = (var_29 + 1);
                char var_34 = (var_29 >= 0);
                char var_36;
                if (var_34) {
                    var_36 = (var_29 < 10);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_38 = (var_19 + var_29);
                float var_39 = var_0[var_38];
                float var_40 = var_1[var_38];
                char var_41 = (var_31 > var_39);
                Tuple4 var_42;
                if (var_41) {
                    var_42 = make_Tuple4(var_31, var_32);
                } else {
                    var_42 = make_Tuple4(var_39, var_40);
                }
                float var_43 = var_42.mem_0;
                float var_44 = var_42.mem_1;
                var_26[0] = (make_Env3(var_33, make_Tuple4(var_43, var_44)));
            }
            Env3 var_45 = var_26[0];
            long long int var_46 = var_45.mem_0;
            Tuple4 var_47 = var_45.mem_1;
            float var_48 = var_47.mem_0;
            float var_49 = var_47.mem_1;
            FunPointer5 var_52 = method_25;
            Tuple4 var_53 = cub::BlockReduce<Tuple4,1>().Reduce(make_Tuple4(var_48, var_49), var_52);
            float var_54 = var_53.mem_0;
            float var_55 = var_53.mem_1;
            char var_56 = (var_3 == 0);
            if (var_56) {
                char var_58;
                if (var_15) {
                    var_58 = (var_13 < 32);
                } else {
                    var_58 = 0;
                }
                char var_59 = (var_58 == 0);
                if (var_59) {
                    // "Argument out of bounds."
                } else {
                }
                char var_60 = var_2[var_13];
                char var_61 = (var_55 == 1);
                var_2[var_13] = var_61;
            } else {
            }
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_62 = var_10[0];
        long long int var_63 = var_62.mem_0;
    }
    __device__ char method_8(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_9(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 32);
    }
    __device__ char method_11(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 320);
    }
    __device__ char method_13(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 320);
    }
    __device__ float method_14(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ char method_19(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 32);
    }
    __device__ char method_21(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 7840);
    }
    __device__ char method_24(Env3 * var_0) {
        Env3 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple4 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 10);
    }
    __device__ Tuple4 method_25(Tuple4 var_0, Tuple4 var_1) {
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
and Env4 =
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_5((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 5L)
    if var_14 then
        let (var_15: int64) = 0L
        let (var_16: float) = 0.000000
        let (var_17: int64) = 0L
        let (var_18: Env4) = method_6((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_15: int64), (var_16: float), (var_17: int64))
        let (var_19: int64) = var_18.mem_0
        let (var_20: float) = var_18.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_21: float) = (var_20 / 32.000000)
        let (var_22: string) = System.String.Format("Average of batch costs is {0}.",var_21)
        let (var_23: string) = System.String.Format("{0}",var_22)
        System.Console.WriteLine(var_23)
        let (var_24: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_19,32L)
        let (var_25: string) = System.String.Format("{0}",var_24)
        System.Console.WriteLine(var_25)
        System.Console.WriteLine("-----")
        let (var_26: int64) = (var_13 + 1L)
        method_5((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_26: int64))
    else
        ()
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
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
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
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
and method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: int64), (var_14: float), (var_15: int64)): Env4 =
    let (var_16: bool) = (var_15 < 32L)
    if var_16 then
        let (var_17: int64) = (var_15 + 32L)
        let (var_18: bool) = (var_15 >= 0L)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_20: bool) = (var_17 > 0L)
        let (var_22: bool) =
            if var_20 then
                (var_17 <= 32L)
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
                (var_17 <= 32L)
            else
                false
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_28: int64) = (var_15 * 10L)
        let (var_29: int64) = 1280L
        let (var_30: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_29: int64))
        let (var_31: int64) = 1280L
        let (var_32: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_31: int64))
        let (var_33: (Union0 ref)) = var_32.mem_0
        let (var_34: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        let (var_35: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
        var_0.ClearMemoryAsync(var_34, 0uy, var_36, var_35)
        let (var_37: (Union0 ref)) = var_7.mem_0
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_37: (Union0 ref)))
        let (var_39: (Union0 ref)) = var_30.mem_0
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        // Cuda join point
        // method_7((var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_41: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_42: uint64) = uint64 var_38
        let (var_43: uint64) = uint64 var_40
        let (var_44: uint64) = uint64 var_41
        let (var_45: string) = System.String.Format("{0}",var_44)
        let (var_46: string) = System.String.Format("{0}",var_43)
        let (var_47: string) = System.String.Format("{0}",var_42)
        let (var_48: string) = String.concat ", " [|var_47; var_46; var_45|]
        let (var_49: string) = System.String.Format("[{0}]",var_48)
        let (var_50: string) = System.String.Format("Calling {0} with args: {1}","method_7",var_49)
        let (var_51: string) = System.String.Format("{0}",var_50)
        System.Console.WriteLine(var_51)
        let (var_52: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_1, var_0)
        let (var_53: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_52.set_GridDimensions(var_53)
        let (var_54: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_52.set_BlockDimensions(var_54)
        var_0.Synchronize()
        let (var_59: int64) = 1280L
        let (var_60: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_59: int64))
        let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_62: (Union0 ref)) = var_60.mem_0
        let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
        // Cuda join point
        // method_10((var_61: ManagedCuda.BasicTypes.CUdeviceptr), (var_63: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_64: uint64) = uint64 var_61
        let (var_65: uint64) = uint64 var_63
        let (var_66: string) = System.String.Format("{0}",var_65)
        let (var_67: string) = System.String.Format("{0}",var_64)
        let (var_68: string) = String.concat ", " [|var_67; var_66|]
        let (var_69: string) = System.String.Format("[{0}]",var_68)
        let (var_70: string) = System.String.Format("Calling {0} with args: {1}","method_10",var_69)
        let (var_71: string) = System.String.Format("{0}",var_70)
        System.Console.WriteLine(var_71)
        let (var_72: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_10", var_1, var_0)
        let (var_73: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_72.set_GridDimensions(var_73)
        let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_72.set_BlockDimensions(var_74)
        var_0.Synchronize()
        let (var_75: int64) = 1280L
        let (var_76: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_75: int64))
        let (var_77: (Union0 ref)) = var_76.mem_0
        let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_77: (Union0 ref)))
        let (var_79: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_80: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
        var_0.ClearMemoryAsync(var_78, 0uy, var_80, var_79)
        let (var_81: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
        let (var_82: int64) = (var_28 * 4L)
        let (var_83: (Union0 ref)) = var_12.mem_0
        let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_85: ManagedCuda.BasicTypes.SizeT) = var_84.Pointer
        let (var_86: uint64) = uint64 var_85
        let (var_87: uint64) = (uint64 var_82)
        let (var_88: uint64) = (var_86 + var_87)
        let (var_89: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_88)
        let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_89)
        let (var_98: int64) = 4L
        let (var_99: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_98: int64))
        let (var_100: (Union0 ref)) = var_99.mem_0
        let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_100: (Union0 ref)))
        // Cuda join point
        // method_12((var_81: ManagedCuda.BasicTypes.CUdeviceptr), (var_90: ManagedCuda.BasicTypes.CUdeviceptr), (var_101: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_102: uint64) = uint64 var_81
        let (var_103: uint64) = uint64 var_90
        let (var_104: uint64) = uint64 var_101
        let (var_105: string) = System.String.Format("{0}",var_104)
        let (var_106: string) = System.String.Format("{0}",var_103)
        let (var_107: string) = System.String.Format("{0}",var_102)
        let (var_108: string) = String.concat ", " [|var_107; var_106; var_105|]
        let (var_109: string) = System.String.Format("[{0}]",var_108)
        let (var_110: string) = System.String.Format("Calling {0} with args: {1}","method_12",var_109)
        let (var_111: string) = System.String.Format("{0}",var_110)
        System.Console.WriteLine(var_111)
        let (var_112: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_12", var_1, var_0)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_112.set_GridDimensions(var_113)
        let (var_114: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_112.set_BlockDimensions(var_114)
        var_0.Synchronize()
        let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_100: (Union0 ref)))
        let (var_116: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
        var_0.CopyToHost(var_116, var_115)
        var_0.Synchronize()
        let (var_117: float32) = 0.000000f
        let (var_118: int64) = 0L
        let (var_119: float32) = method_15((var_116: (float32 [])), (var_117: float32), (var_118: int64))
        var_100 := Union0Case1
        let (var_120: (float32 ref)) = (ref 0.000000f)
        let (var_121: float32) = (var_119 / 32.000000f)
        let (var_122: (float32 ref)) = (ref 0.000000f)
        var_122 := 1.000000f
        let (var_123: float32) = (!var_122)
        let (var_124: float32) = (var_123 / 32.000000f)
        let (var_125: float32) = (!var_120)
        let (var_126: float32) = (var_125 + var_124)
        var_120 := var_126
        let (var_127: float32) = (!var_120)
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
        let (var_129: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_130: ManagedCuda.BasicTypes.SizeT) = var_129.Pointer
        let (var_131: uint64) = uint64 var_130
        let (var_132: uint64) = (var_131 + var_87)
        let (var_133: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_132)
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_133)
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_77: (Union0 ref)))
        // Cuda join point
        // method_16((var_127: float32), (var_119: float32), (var_128: ManagedCuda.BasicTypes.CUdeviceptr), (var_134: ManagedCuda.BasicTypes.CUdeviceptr), (var_135: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_136: uint64) = uint64 var_128
        let (var_137: uint64) = uint64 var_134
        let (var_138: uint64) = uint64 var_135
        let (var_139: string) = System.String.Format("{0}",var_138)
        let (var_140: string) = System.String.Format("{0}",var_137)
        let (var_141: string) = System.String.Format("{0}",var_136)
        let (var_142: string) = System.String.Format("{0}",var_119)
        let (var_143: string) = System.String.Format("{0}",var_127)
        let (var_144: string) = String.concat ", " [|var_143; var_142; var_141; var_140; var_139|]
        let (var_145: string) = System.String.Format("[{0}]",var_144)
        let (var_146: string) = System.String.Format("Calling {0} with args: {1}","method_16",var_145)
        let (var_147: string) = System.String.Format("{0}",var_146)
        System.Console.WriteLine(var_147)
        let (var_148: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_1, var_0)
        let (var_149: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_148.set_GridDimensions(var_149)
        let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_148.set_BlockDimensions(var_150)
        var_0.Synchronize()
        let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_152: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_77: (Union0 ref)))
        let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
        let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        // Cuda join point
        // method_17((var_151: ManagedCuda.BasicTypes.CUdeviceptr), (var_152: ManagedCuda.BasicTypes.CUdeviceptr), (var_153: ManagedCuda.BasicTypes.CUdeviceptr), (var_154: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_155: uint64) = uint64 var_151
        let (var_156: uint64) = uint64 var_152
        let (var_157: uint64) = uint64 var_153
        let (var_158: uint64) = uint64 var_154
        let (var_159: string) = System.String.Format("{0}",var_158)
        let (var_160: string) = System.String.Format("{0}",var_157)
        let (var_161: string) = System.String.Format("{0}",var_156)
        let (var_162: string) = System.String.Format("{0}",var_155)
        let (var_163: string) = String.concat ", " [|var_162; var_161; var_160; var_159|]
        let (var_164: string) = System.String.Format("[{0}]",var_163)
        let (var_165: string) = System.String.Format("Calling {0} with args: {1}","method_17",var_164)
        let (var_166: string) = System.String.Format("{0}",var_165)
        System.Console.WriteLine(var_166)
        let (var_167: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_168: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_167.set_GridDimensions(var_168)
        let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_167.set_BlockDimensions(var_169)
        var_0.Synchronize()
        let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        let (var_171: (Union0 ref)) = var_6.mem_0
        let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        // Cuda join point
        // method_18((var_170: ManagedCuda.BasicTypes.CUdeviceptr), (var_172: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_173: uint64) = uint64 var_170
        let (var_174: uint64) = uint64 var_172
        let (var_175: string) = System.String.Format("{0}",var_174)
        let (var_176: string) = System.String.Format("{0}",var_173)
        let (var_177: string) = String.concat ", " [|var_176; var_175|]
        let (var_178: string) = System.String.Format("[{0}]",var_177)
        let (var_179: string) = System.String.Format("Calling {0} with args: {1}","method_18",var_178)
        let (var_180: string) = System.String.Format("{0}",var_179)
        System.Console.WriteLine(var_180)
        let (var_181: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_18", var_1, var_0)
        let (var_182: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_181.set_GridDimensions(var_182)
        let (var_183: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_181.set_BlockDimensions(var_183)
        var_0.Synchronize()
        let (var_184: (Union0 ref)) = var_9.mem_0
        let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_184: (Union0 ref)))
        let (var_186: (Union0 ref)) = var_10.mem_0
        let (var_187: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_186: (Union0 ref)))
        // Cuda join point
        // method_20((var_185: ManagedCuda.BasicTypes.CUdeviceptr), (var_187: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_188: uint64) = uint64 var_185
        let (var_189: uint64) = uint64 var_187
        let (var_190: string) = System.String.Format("{0}",var_189)
        let (var_191: string) = System.String.Format("{0}",var_188)
        let (var_192: string) = String.concat ", " [|var_191; var_190|]
        let (var_193: string) = System.String.Format("[{0}]",var_192)
        let (var_194: string) = System.String.Format("Calling {0} with args: {1}","method_20",var_193)
        let (var_195: string) = System.String.Format("{0}",var_194)
        System.Console.WriteLine(var_195)
        let (var_196: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_197: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_196.set_GridDimensions(var_197)
        let (var_198: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_196.set_BlockDimensions(var_198)
        var_0.Synchronize()
        let (var_199: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_184: (Union0 ref)))
        let (var_200: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_201: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_199, 0uy, var_201, var_200)
        let (var_202: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_37: (Union0 ref)))
        // Cuda join point
        // method_22((var_202: ManagedCuda.BasicTypes.CUdeviceptr), (var_203: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_204: uint64) = uint64 var_202
        let (var_205: uint64) = uint64 var_203
        let (var_206: string) = System.String.Format("{0}",var_205)
        let (var_207: string) = System.String.Format("{0}",var_204)
        let (var_208: string) = String.concat ", " [|var_207; var_206|]
        let (var_209: string) = System.String.Format("[{0}]",var_208)
        let (var_210: string) = System.String.Format("Calling {0} with args: {1}","method_22",var_209)
        let (var_211: string) = System.String.Format("{0}",var_210)
        System.Console.WriteLine(var_211)
        let (var_212: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_213: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_212.set_GridDimensions(var_213)
        let (var_214: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_212.set_BlockDimensions(var_214)
        var_0.Synchronize()
        let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_171: (Union0 ref)))
        let (var_216: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_217: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_215, 0uy, var_217, var_216)
        let (var_218: float) = (float var_121)
        let (var_219: float) = (var_218 * 32.000000)
        let (var_220: float) = (var_14 + var_219)
        let (var_222: int64) = 32L
        let (var_223: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_222: int64))
        let (var_224: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
        let (var_225: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_226: ManagedCuda.BasicTypes.SizeT) = var_225.Pointer
        let (var_227: uint64) = uint64 var_226
        let (var_228: uint64) = (var_227 + var_87)
        let (var_229: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_228)
        let (var_230: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_229)
        let (var_231: (Union0 ref)) = var_223.mem_0
        let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_231: (Union0 ref)))
        // Cuda join point
        // method_23((var_224: ManagedCuda.BasicTypes.CUdeviceptr), (var_230: ManagedCuda.BasicTypes.CUdeviceptr), (var_232: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_233: uint64) = uint64 var_224
        let (var_234: uint64) = uint64 var_230
        let (var_235: uint64) = uint64 var_232
        let (var_236: string) = System.String.Format("{0}",var_235)
        let (var_237: string) = System.String.Format("{0}",var_234)
        let (var_238: string) = System.String.Format("{0}",var_233)
        let (var_239: string) = String.concat ", " [|var_238; var_237; var_236|]
        let (var_240: string) = System.String.Format("[{0}]",var_239)
        let (var_241: string) = System.String.Format("Calling {0} with args: {1}","method_23",var_240)
        let (var_242: string) = System.String.Format("{0}",var_241)
        System.Console.WriteLine(var_242)
        let (var_243: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_1, var_0)
        let (var_244: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_243.set_GridDimensions(var_244)
        let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_243.set_BlockDimensions(var_245)
        var_0.Synchronize()
        let (var_246: int64) = 0L
        let (var_247: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_231: (Union0 ref)))
        let (var_248: (bool [])) = Array.zeroCreate<bool> (System.Convert.ToInt32(32L))
        var_0.CopyToHost(var_248, var_247)
        var_0.Synchronize()
        let (var_249: int64) = var_248.LongLength
        let (var_250: int64) = 0L
        let (var_251: int64) = method_26((var_248: (bool [])), (var_249: int64), (var_246: int64), (var_250: int64))
        var_231 := Union0Case1
        let (var_252: int64) = (var_13 + var_251)
        var_77 := Union0Case1
        var_62 := Union0Case1
        var_33 := Union0Case1
        var_39 := Union0Case1
        method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_252: int64), (var_220: float), (var_17: int64))
    else
        (Env4(var_13, var_14))
and method_15((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 1L)
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
        method_15((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_26((var_0: (bool [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: bool) = var_0.[int32 var_3]
        let (var_7: int64) =
            if var_5 then
                (var_2 + 1L)
            else
                var_2
        let (var_8: int64) = (var_3 + 1L)
        method_26((var_0: (bool [])), (var_1: int64), (var_7: int64), (var_8: int64))
    else
        var_2
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
let (var_39: float) = (0.100000 * var_38)
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
let (var_60: int64) = 100352L
let (var_61: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_60: int64))
let (var_62: (Union0 ref)) = var_61.mem_0
let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(25088L)
var_53.GenerateUniform32(var_63, var_64)
let (var_65: int64) = 1280L
let (var_66: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_65: int64))
let (var_67: (Union0 ref)) = var_66.mem_0
let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(320L)
var_53.GenerateUniform32(var_68, var_69)
let (var_70: int64) = 31360L
let (var_71: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_70: int64))
let (var_72: (Union0 ref)) = var_71.mem_0
let (var_73: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_72: (Union0 ref)))
let (var_74: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_53.GenerateNormal32(var_73, var_74, 0.000000f, 0.050189f)
let (var_75: int64) = 31360L
let (var_76: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_75: int64))
let (var_77: (Union0 ref)) = var_76.mem_0
let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_77: (Union0 ref)))
let (var_79: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_80: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_78, 0uy, var_80, var_79)
let (var_81: int64) = 40L
let (var_82: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_81: int64))
let (var_83: (Union0 ref)) = var_82.mem_0
let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
let (var_85: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_86: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_84, 0uy, var_86, var_85)
let (var_87: int64) = 40L
let (var_88: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_87: int64))
let (var_89: (Union0 ref)) = var_88.mem_0
let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
let (var_91: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_92: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_90, 0uy, var_92, var_91)
let (var_93: int64) = 0L
method_5((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_88: EnvStack2), (var_82: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_76: EnvStack2), (var_71: EnvStack2), (var_61: EnvStack2), (var_66: EnvStack2), (var_93: int64))
var_89 := Union0Case1
var_83 := Union0Case1
var_77 := Union0Case1
var_72 := Union0Case1
var_67 := Union0Case1
var_62 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_94)
var_46 := Union0Case1
var_1.Dispose()

