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
    __global__ void method_8(float * var_0, float * var_1, float * var_2);
    __global__ void method_11(float * var_0, float * var_1);
    __global__ void method_13(float * var_0, float * var_1, float * var_2);
    __global__ void method_17(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_18(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_20(float * var_0, float * var_1);
    __global__ void method_22(float * var_0, float * var_1);
    __global__ void method_24(float * var_0, float * var_1);
    __global__ void method_25(float * var_0, float * var_1, char * var_2);
    __device__ char method_9(Env0 * var_0);
    __device__ char method_10(Env0 * var_0);
    __device__ char method_12(Env0 * var_0);
    __device__ char method_14(Env1 * var_0);
    __device__ float method_15(float var_0, float var_1);
    __device__ char method_21(Env1 * var_0);
    __device__ char method_23(Env0 * var_0);
    __device__ char method_26(Env3 * var_0);
    __device__ Tuple4 method_27(Tuple4 var_0, Tuple4 var_1);
    
    __global__ void method_8(float * var_0, float * var_1, float * var_2) {
        printf("Inside method_8 with args: [%p, %p, %p]", var_0, var_1, var_2);
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_3 + var_6);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_9(var_10)) {
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
            while (method_10(var_20)) {
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
    __global__ void method_11(float * var_0, float * var_1) {
        printf("Inside method_11 with args: [%p, %p]", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_12(var_9)) {
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
    __global__ void method_13(float * var_0, float * var_1, float * var_2) {
        printf("Inside method_13 with args: [%p, %p, %p]", var_0, var_1, var_2);
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
        while (method_14(var_11)) {
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
        FunPointer2 var_37 = method_15;
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
    __global__ void method_17(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        printf("Inside method_17 with args: [%f, %f, %p, %p, %p]", var_0, var_1, var_2, var_3, var_4);
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 + var_5);
        Env0 var_12[1];
        var_12[0] = (make_Env0(var_11));
        while (method_12(var_12)) {
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
    __global__ void method_18(float * var_0, float * var_1, float * var_2, float * var_3) {
        printf("Inside method_18 with args: [%p, %p, %p, %p]", var_0, var_1, var_2, var_3);
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 + var_4);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_12(var_11)) {
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
    __global__ void method_20(float * var_0, float * var_1) {
        printf("Inside method_20 with args: [%p, %p]", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_2 + var_5);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_9(var_9)) {
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
            while (method_21(var_23)) {
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
    __global__ void method_22(float * var_0, float * var_1) {
        printf("Inside method_22 with args: [%p, %p]", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_23(var_9)) {
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
    __global__ void method_24(float * var_0, float * var_1) {
        printf("Inside method_24 with args: [%p, %p]", var_0, var_1);
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 + var_2);
        Env0 var_9[1];
        var_9[0] = (make_Env0(var_8));
        while (method_9(var_9)) {
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
    __global__ void method_25(float * var_0, float * var_1, char * var_2) {
        printf("Inside method_25 with args: [%p, %p, %p]", var_0, var_1, var_2);
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_10(var_10)) {
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
            while (method_26(var_26)) {
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
            FunPointer5 var_52 = method_27;
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
    __device__ char method_9(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_10(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 32);
    }
    __device__ char method_12(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 320);
    }
    __device__ char method_14(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 320);
    }
    __device__ float method_15(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ char method_21(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 32);
    }
    __device__ char method_23(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 7840);
    }
    __device__ char method_26(Env3 * var_0) {
        Env3 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple4 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 10);
    }
    __device__ Tuple4 method_27(Tuple4 var_0, Tuple4 var_1) {
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
        method_7((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_24: int64), (var_10: EnvStack2), (var_30: EnvStack2))
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
        // method_8((var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_41: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_42: uint64) = uint64 var_38
        let (var_43: uint64) = uint64 var_40
        let (var_44: uint64) = uint64 var_41
        let (var_45: string) = System.String.Format("{0}",var_44)
        let (var_46: string) = System.String.Format("{0}",var_43)
        let (var_47: string) = System.String.Format("{0}",var_42)
        let (var_48: string) = String.concat ", " [|var_47; var_46; var_45|]
        let (var_49: string) = System.String.Format("[{0}]",var_48)
        let (var_50: string) = System.String.Format("Calling {0} with args: {1}","method_8",var_49)
        let (var_51: string) = System.String.Format("{0}",var_50)
        System.Console.WriteLine(var_51)
        let (var_52: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_1, var_0)
        let (var_53: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_52.set_GridDimensions(var_53)
        let (var_54: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_52.set_BlockDimensions(var_54)
        let (var_55: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_57: (System.Object [])) = [|var_38; var_40; var_41|]: (System.Object [])
        var_52.RunAsync(var_55, var_57)
        var_0.Synchronize()
        let (var_62: int64) = 1280L
        let (var_63: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_62: int64))
        let (var_64: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_65: (Union0 ref)) = var_63.mem_0
        let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        // Cuda join point
        // method_11((var_64: ManagedCuda.BasicTypes.CUdeviceptr), (var_66: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_67: uint64) = uint64 var_64
        let (var_68: uint64) = uint64 var_66
        let (var_69: string) = System.String.Format("{0}",var_68)
        let (var_70: string) = System.String.Format("{0}",var_67)
        let (var_71: string) = String.concat ", " [|var_70; var_69|]
        let (var_72: string) = System.String.Format("[{0}]",var_71)
        let (var_73: string) = System.String.Format("Calling {0} with args: {1}","method_11",var_72)
        let (var_74: string) = System.String.Format("{0}",var_73)
        System.Console.WriteLine(var_74)
        let (var_75: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_11", var_1, var_0)
        let (var_76: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_75.set_GridDimensions(var_76)
        let (var_77: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_75.set_BlockDimensions(var_77)
        let (var_78: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_80: (System.Object [])) = [|var_64; var_66|]: (System.Object [])
        var_75.RunAsync(var_78, var_80)
        var_0.Synchronize()
        let (var_81: int64) = 1280L
        let (var_82: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_81: int64))
        let (var_83: (Union0 ref)) = var_82.mem_0
        let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_85: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_86: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
        var_0.ClearMemoryAsync(var_84, 0uy, var_86, var_85)
        let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_88: int64) = (var_28 * 4L)
        let (var_89: (Union0 ref)) = var_12.mem_0
        let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_91: ManagedCuda.BasicTypes.SizeT) = var_90.Pointer
        let (var_92: uint64) = uint64 var_91
        let (var_93: uint64) = (uint64 var_88)
        let (var_94: uint64) = (var_92 + var_93)
        let (var_95: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_94)
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_95)
        let (var_104: int64) = 4L
        let (var_105: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_104: int64))
        let (var_106: (Union0 ref)) = var_105.mem_0
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
        // Cuda join point
        // method_13((var_87: ManagedCuda.BasicTypes.CUdeviceptr), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_107: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_108: uint64) = uint64 var_87
        let (var_109: uint64) = uint64 var_96
        let (var_110: uint64) = uint64 var_107
        let (var_111: string) = System.String.Format("{0}",var_110)
        let (var_112: string) = System.String.Format("{0}",var_109)
        let (var_113: string) = System.String.Format("{0}",var_108)
        let (var_114: string) = String.concat ", " [|var_113; var_112; var_111|]
        let (var_115: string) = System.String.Format("[{0}]",var_114)
        let (var_116: string) = System.String.Format("Calling {0} with args: {1}","method_13",var_115)
        let (var_117: string) = System.String.Format("{0}",var_116)
        System.Console.WriteLine(var_117)
        let (var_118: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_1, var_0)
        let (var_119: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_118.set_GridDimensions(var_119)
        let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_118.set_BlockDimensions(var_120)
        let (var_121: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_123: (System.Object [])) = [|var_87; var_96; var_107|]: (System.Object [])
        var_118.RunAsync(var_121, var_123)
        var_0.Synchronize()
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
        let (var_125: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
        var_0.CopyToHost(var_125, var_124)
        var_0.Synchronize()
        let (var_126: float32) = 0.000000f
        let (var_127: int64) = 0L
        let (var_128: float32) = method_16((var_125: (float32 [])), (var_126: float32), (var_127: int64))
        var_106 := Union0Case1
        let (var_129: (float32 ref)) = (ref 0.000000f)
        let (var_130: float32) = (var_128 / 32.000000f)
        let (var_131: (float32 ref)) = (ref 0.000000f)
        var_131 := 1.000000f
        let (var_132: float32) = (!var_131)
        let (var_133: float32) = (var_132 / 32.000000f)
        let (var_134: float32) = (!var_129)
        let (var_135: float32) = (var_134 + var_133)
        var_129 := var_135
        let (var_136: float32) = (!var_129)
        let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_139: ManagedCuda.BasicTypes.SizeT) = var_138.Pointer
        let (var_140: uint64) = uint64 var_139
        let (var_141: uint64) = (var_140 + var_93)
        let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_141)
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_142)
        let (var_144: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        // Cuda join point
        // method_17((var_136: float32), (var_128: float32), (var_137: ManagedCuda.BasicTypes.CUdeviceptr), (var_143: ManagedCuda.BasicTypes.CUdeviceptr), (var_144: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_145: uint64) = uint64 var_137
        let (var_146: uint64) = uint64 var_143
        let (var_147: uint64) = uint64 var_144
        let (var_148: string) = System.String.Format("{0}",var_147)
        let (var_149: string) = System.String.Format("{0}",var_146)
        let (var_150: string) = System.String.Format("{0}",var_145)
        let (var_151: string) = System.String.Format("{0}",var_128)
        let (var_152: string) = System.String.Format("{0}",var_136)
        let (var_153: string) = String.concat ", " [|var_152; var_151; var_150; var_149; var_148|]
        let (var_154: string) = System.String.Format("[{0}]",var_153)
        let (var_155: string) = System.String.Format("Calling {0} with args: {1}","method_17",var_154)
        let (var_156: string) = System.String.Format("{0}",var_155)
        System.Console.WriteLine(var_156)
        let (var_157: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_157.set_GridDimensions(var_158)
        let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_157.set_BlockDimensions(var_159)
        let (var_160: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_162: (System.Object [])) = [|var_136; var_128; var_137; var_143; var_144|]: (System.Object [])
        var_157.RunAsync(var_160, var_162)
        var_0.Synchronize()
        let (var_163: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_39: (Union0 ref)))
        let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
        let (var_165: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        // Cuda join point
        // method_18((var_163: ManagedCuda.BasicTypes.CUdeviceptr), (var_164: ManagedCuda.BasicTypes.CUdeviceptr), (var_165: ManagedCuda.BasicTypes.CUdeviceptr), (var_166: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_167: uint64) = uint64 var_163
        let (var_168: uint64) = uint64 var_164
        let (var_169: uint64) = uint64 var_165
        let (var_170: uint64) = uint64 var_166
        let (var_171: string) = System.String.Format("{0}",var_170)
        let (var_172: string) = System.String.Format("{0}",var_169)
        let (var_173: string) = System.String.Format("{0}",var_168)
        let (var_174: string) = System.String.Format("{0}",var_167)
        let (var_175: string) = String.concat ", " [|var_174; var_173; var_172; var_171|]
        let (var_176: string) = System.String.Format("[{0}]",var_175)
        let (var_177: string) = System.String.Format("Calling {0} with args: {1}","method_18",var_176)
        let (var_178: string) = System.String.Format("{0}",var_177)
        System.Console.WriteLine(var_178)
        let (var_179: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_18", var_1, var_0)
        let (var_180: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_179.set_GridDimensions(var_180)
        let (var_181: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_179.set_BlockDimensions(var_181)
        let (var_182: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_184: (System.Object [])) = [|var_163; var_164; var_165; var_166|]: (System.Object [])
        var_179.RunAsync(var_182, var_184)
        var_0.Synchronize()
        method_19((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_24: int64), (var_32: EnvStack2), (var_9: EnvStack2))
        let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_33: (Union0 ref)))
        let (var_186: (Union0 ref)) = var_6.mem_0
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
        let (var_199: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_201: (System.Object [])) = [|var_185; var_187|]: (System.Object [])
        var_196.RunAsync(var_199, var_201)
        var_0.Synchronize()
        let (var_202: (Union0 ref)) = var_9.mem_0
        let (var_203: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_202: (Union0 ref)))
        let (var_204: (Union0 ref)) = var_10.mem_0
        let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_204: (Union0 ref)))
        // Cuda join point
        // method_22((var_203: ManagedCuda.BasicTypes.CUdeviceptr), (var_205: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_206: uint64) = uint64 var_203
        let (var_207: uint64) = uint64 var_205
        let (var_208: string) = System.String.Format("{0}",var_207)
        let (var_209: string) = System.String.Format("{0}",var_206)
        let (var_210: string) = String.concat ", " [|var_209; var_208|]
        let (var_211: string) = System.String.Format("[{0}]",var_210)
        let (var_212: string) = System.String.Format("Calling {0} with args: {1}","method_22",var_211)
        let (var_213: string) = System.String.Format("{0}",var_212)
        System.Console.WriteLine(var_213)
        let (var_214: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_215: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_214.set_GridDimensions(var_215)
        let (var_216: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_214.set_BlockDimensions(var_216)
        let (var_217: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_219: (System.Object [])) = [|var_203; var_205|]: (System.Object [])
        var_214.RunAsync(var_217, var_219)
        var_0.Synchronize()
        let (var_220: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_202: (Union0 ref)))
        let (var_221: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_222: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_220, 0uy, var_222, var_221)
        let (var_223: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_186: (Union0 ref)))
        let (var_224: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_37: (Union0 ref)))
        // Cuda join point
        // method_24((var_223: ManagedCuda.BasicTypes.CUdeviceptr), (var_224: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_225: uint64) = uint64 var_223
        let (var_226: uint64) = uint64 var_224
        let (var_227: string) = System.String.Format("{0}",var_226)
        let (var_228: string) = System.String.Format("{0}",var_225)
        let (var_229: string) = String.concat ", " [|var_228; var_227|]
        let (var_230: string) = System.String.Format("[{0}]",var_229)
        let (var_231: string) = System.String.Format("Calling {0} with args: {1}","method_24",var_230)
        let (var_232: string) = System.String.Format("{0}",var_231)
        System.Console.WriteLine(var_232)
        let (var_233: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_1, var_0)
        let (var_234: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_233.set_GridDimensions(var_234)
        let (var_235: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_233.set_BlockDimensions(var_235)
        let (var_236: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_238: (System.Object [])) = [|var_223; var_224|]: (System.Object [])
        var_233.RunAsync(var_236, var_238)
        var_0.Synchronize()
        let (var_239: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_186: (Union0 ref)))
        let (var_240: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_241: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_239, 0uy, var_241, var_240)
        let (var_242: float) = (float var_130)
        let (var_243: float) = (var_242 * 32.000000)
        let (var_244: float) = (var_14 + var_243)
        let (var_246: int64) = 32L
        let (var_247: EnvStack2) = method_2((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_246: int64))
        let (var_248: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
        let (var_249: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_250: ManagedCuda.BasicTypes.SizeT) = var_249.Pointer
        let (var_251: uint64) = uint64 var_250
        let (var_252: uint64) = (var_251 + var_93)
        let (var_253: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_252)
        let (var_254: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_253)
        let (var_255: (Union0 ref)) = var_247.mem_0
        let (var_256: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_255: (Union0 ref)))
        // Cuda join point
        // method_25((var_248: ManagedCuda.BasicTypes.CUdeviceptr), (var_254: ManagedCuda.BasicTypes.CUdeviceptr), (var_256: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_257: uint64) = uint64 var_248
        let (var_258: uint64) = uint64 var_254
        let (var_259: uint64) = uint64 var_256
        let (var_260: string) = System.String.Format("{0}",var_259)
        let (var_261: string) = System.String.Format("{0}",var_258)
        let (var_262: string) = System.String.Format("{0}",var_257)
        let (var_263: string) = String.concat ", " [|var_262; var_261; var_260|]
        let (var_264: string) = System.String.Format("[{0}]",var_263)
        let (var_265: string) = System.String.Format("Calling {0} with args: {1}","method_25",var_264)
        let (var_266: string) = System.String.Format("{0}",var_265)
        System.Console.WriteLine(var_266)
        let (var_267: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_1, var_0)
        let (var_268: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_267.set_GridDimensions(var_268)
        let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_267.set_BlockDimensions(var_269)
        let (var_270: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_272: (System.Object [])) = [|var_248; var_254; var_256|]: (System.Object [])
        var_267.RunAsync(var_270, var_272)
        var_0.Synchronize()
        let (var_273: int64) = 0L
        let (var_274: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_255: (Union0 ref)))
        let (var_275: (bool [])) = Array.zeroCreate<bool> (System.Convert.ToInt32(32L))
        var_0.CopyToHost(var_275, var_274)
        var_0.Synchronize()
        let (var_276: int64) = var_275.LongLength
        let (var_277: int64) = 0L
        let (var_278: int64) = method_28((var_275: (bool [])), (var_276: int64), (var_273: int64), (var_277: int64))
        var_255 := Union0Case1
        let (var_279: int64) = (var_13 + var_278)
        var_83 := Union0Case1
        var_65 := Union0Case1
        var_33 := Union0Case1
        var_39 := Union0Case1
        method_6((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_279: int64), (var_244: float), (var_17: int64))
    else
        (Env4(var_13, var_14))
and method_7((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: int64), (var_3: EnvStack2), (var_4: EnvStack2)): unit =
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
    let (var_22: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 32, 10, 784, var_7, var_16, 32, var_18, 784, var_19, var_21, 32)
    if var_22 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_22)
and method_16((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
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
        method_16((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_19((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: int64), (var_3: EnvStack2), (var_4: EnvStack2)): unit =
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
    let (var_22: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 784, 10, 32, var_7, var_16, 32, var_18, 32, var_19, var_21, 784)
    if var_22 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_22)
and method_28((var_0: (bool [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: bool) = var_0.[int32 var_3]
        let (var_7: int64) =
            if var_5 then
                (var_2 + 1L)
            else
                var_2
        let (var_8: int64) = (var_3 + 1L)
        method_28((var_0: (bool [])), (var_1: int64), (var_7: int64), (var_8: int64))
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

