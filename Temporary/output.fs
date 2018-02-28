module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(float * var_0, float * var_1, float * var_2);
    __global__ void method_19(float * var_0, float * var_1);
    __global__ void method_21(float * var_0, float * var_1, float * var_2);
    __global__ void method_24(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_26(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_20(long long int * var_0);
    __device__ char method_22(long long int * var_0, float * var_1);
    __device__ char method_27(long long int * var_0, float * var_1);
    __device__ char method_28(long long int * var_0, float * var_1);
    __device__ char method_29(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_16(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (16 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_17(var_7)) {
            long long int var_9 = var_7[0];
            char var_10 = (var_9 >= 0);
            char var_12;
            if (var_10) {
                var_12 = (var_9 < 16);
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
            while (method_18(var_18)) {
                long long int var_20 = var_18[0];
                char var_21 = (var_20 >= 0);
                char var_23;
                if (var_21) {
                    var_23 = (var_20 < 32);
                } else {
                    var_23 = 0;
                }
                char var_24 = (var_23 == 0);
                if (var_24) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_25 = (var_20 * 16);
                char var_27;
                if (var_10) {
                    var_27 = (var_9 < 16);
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
                    var_31 = (var_20 < 32);
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
                    var_34 = (var_9 < 16);
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
            long long int var_42 = (var_9 + 16);
            var_7[0] = var_42;
        }
        long long int var_43 = var_7[0];
    }
    __global__ void method_19(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_20(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 512);
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
                var_14 = (var_8 < 512);
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
            long long int var_22 = (var_8 + 512);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_21(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (512 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_22(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 512);
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
            float var_19 = (var_18 - var_17);
            float var_20 = (var_19 * var_19);
            float var_21 = (var_12 + var_20);
            long long int var_22 = (var_11 + 512);
            var_8[0] = var_22;
            var_9[0] = var_21;
        }
        long long int var_23 = var_8[0];
        float var_24 = var_9[0];
        float var_25 = cub::BlockReduce<float,512,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_24);
        float var_26 = (var_25 / 32);
        long long int var_27 = threadIdx.x;
        char var_28 = (var_27 == 0);
        if (var_28) {
            long long int var_29 = blockIdx.x;
            char var_30 = (var_29 >= 0);
            char var_32;
            if (var_30) {
                var_32 = (var_29 < 1);
            } else {
                var_32 = 0;
            }
            char var_33 = (var_32 == 0);
            if (var_33) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_29] = var_26;
        } else {
        }
    }
    __global__ void method_24(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_20(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 512);
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
                var_16 = (var_10 < 512);
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
            float var_23 = (2 * var_22);
            float var_24 = (var_23 / 32);
            float var_25 = (var_20 + var_24);
            var_3[var_10] = var_25;
            long long int var_26 = (var_10 + 512);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_20(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 512);
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
                var_16 = (var_10 < 512);
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
            long long int var_26 = (var_10 + 512);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_26(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (16 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_17(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 16);
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
                var_17 = (var_11 < 16);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_19 = threadIdx.y;
            long long int var_20 = blockIdx.y;
            long long int var_21 = (32 * var_20);
            long long int var_22 = (var_19 + var_21);
            float var_23 = 0;
            long long int var_24[1];
            float var_25[1];
            var_24[0] = var_22;
            var_25[0] = var_23;
            while (method_27(var_24, var_25)) {
                long long int var_27 = var_24[0];
                float var_28 = var_25[0];
                char var_29 = (var_27 >= 0);
                char var_31;
                if (var_29) {
                    var_31 = (var_27 < 32);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_27 * 16);
                char var_35;
                if (var_12) {
                    var_35 = (var_11 < 16);
                } else {
                    var_35 = 0;
                }
                char var_36 = (var_35 == 0);
                if (var_36) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_37 = (var_33 + var_11);
                float var_38 = var_0[var_37];
                float var_39 = var_1[var_37];
                float var_40 = var_2[var_37];
                float var_41 = var_3[var_11];
                float var_42 = (var_28 + var_39);
                long long int var_43 = (var_27 + 32);
                var_24[0] = var_43;
                var_25[0] = var_42;
            }
            long long int var_44 = var_24[0];
            float var_45 = var_25[0];
            __shared__ float var_46[496];
            long long int var_47[1];
            float var_48[1];
            var_47[0] = 32;
            var_48[0] = var_45;
            while (method_28(var_47, var_48)) {
                long long int var_50 = var_47[0];
                float var_51 = var_48[0];
                long long int var_52 = (var_50 / 2);
                long long int var_53 = threadIdx.y;
                char var_54 = (var_53 < var_50);
                char var_57;
                if (var_54) {
                    long long int var_55 = threadIdx.y;
                    var_57 = (var_55 >= var_52);
                } else {
                    var_57 = 0;
                }
                if (var_57) {
                    long long int var_58 = threadIdx.y;
                    char var_59 = (var_58 >= 1);
                    char var_61;
                    if (var_59) {
                        var_61 = (var_58 < 32);
                    } else {
                        var_61 = 0;
                    }
                    char var_62 = (var_61 == 0);
                    if (var_62) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_63 = (var_58 - 1);
                    long long int var_64 = (var_63 * 16);
                    long long int var_65 = threadIdx.x;
                    char var_66 = (var_65 >= 0);
                    char var_68;
                    if (var_66) {
                        var_68 = (var_65 < 16);
                    } else {
                        var_68 = 0;
                    }
                    char var_69 = (var_68 == 0);
                    if (var_69) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_70 = (var_64 + var_65);
                    var_46[var_70] = var_51;
                } else {
                }
                __syncthreads();
                long long int var_71 = threadIdx.y;
                char var_72 = (var_71 < var_52);
                float var_97;
                if (var_72) {
                    long long int var_73 = threadIdx.y;
                    long long int var_74 = (var_73 + var_52);
                    long long int var_75[1];
                    float var_76[1];
                    var_75[0] = var_74;
                    var_76[0] = var_51;
                    while (method_29(var_50, var_75, var_76)) {
                        long long int var_78 = var_75[0];
                        float var_79 = var_76[0];
                        char var_80 = (var_78 >= 1);
                        char var_82;
                        if (var_80) {
                            var_82 = (var_78 < 32);
                        } else {
                            var_82 = 0;
                        }
                        char var_83 = (var_82 == 0);
                        if (var_83) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_84 = (var_78 - 1);
                        long long int var_85 = (var_84 * 16);
                        long long int var_86 = threadIdx.x;
                        char var_87 = (var_86 >= 0);
                        char var_89;
                        if (var_87) {
                            var_89 = (var_86 < 16);
                        } else {
                            var_89 = 0;
                        }
                        char var_90 = (var_89 == 0);
                        if (var_90) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_91 = (var_85 + var_86);
                        float var_92 = var_46[var_91];
                        float var_93 = (var_79 + var_92);
                        long long int var_94 = (var_78 + var_52);
                        var_75[0] = var_94;
                        var_76[0] = var_93;
                    }
                    long long int var_95 = var_75[0];
                    var_97 = var_76[0];
                } else {
                    var_97 = var_51;
                }
                var_47[0] = var_52;
                var_48[0] = var_97;
            }
            long long int var_98 = var_47[0];
            float var_99 = var_48[0];
            long long int var_100 = threadIdx.y;
            char var_101 = (var_100 == 0);
            if (var_101) {
                float var_102 = var_4[var_11];
                float var_103 = (var_99 + var_102);
                var_4[var_11] = var_103;
            } else {
            }
            long long int var_104 = (var_11 + 16);
            var_9[0] = var_104;
        }
        long long int var_105 = var_9[0];
    }
    __global__ void method_30(float * var_0, float * var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (16 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_17(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 16);
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
            long long int var_20[1];
            var_20[0] = var_19;
            while (method_18(var_20)) {
                long long int var_22 = var_20[0];
                char var_23 = (var_22 >= 0);
                char var_25;
                if (var_23) {
                    var_25 = (var_22 < 32);
                } else {
                    var_25 = 0;
                }
                char var_26 = (var_25 == 0);
                if (var_26) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_27 = (var_22 * 16);
                char var_29;
                if (var_12) {
                    var_29 = (var_11 < 16);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_27 + var_11);
                char var_33;
                if (var_23) {
                    var_33 = (var_22 < 32);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                char var_36;
                if (var_12) {
                    var_36 = (var_11 < 16);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                float var_38 = var_0[var_11];
                float var_39 = var_1[var_31];
                float var_40 = var_2[var_31];
                float var_41 = var_3[var_31];
                float var_42 = var_4[var_31];
                float var_43 = (var_40 + var_42);
                var_4[var_31] = var_43;
                long long int var_44 = (var_22 + 32);
                var_20[0] = var_44;
            }
            long long int var_45 = var_20[0];
            long long int var_46 = (var_11 + 16);
            var_9[0] = var_46;
        }
        long long int var_47 = var_9[0];
    }
    __device__ char method_17(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16);
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 32);
    }
    __device__ char method_20(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 512);
    }
    __device__ char method_22(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 512);
    }
    __device__ char method_27(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 32);
    }
    __device__ char method_28(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_29(long long int var_0, long long int * var_1, float * var_2) {
        long long int var_3 = var_1[0];
        float var_4 = var_2[0];
        return (var_3 < var_0);
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
and EnvHeap6 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
and EnvStack7 =
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
and method_9((var_0: EnvHeap6), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
    let (var_13: EnvStack0) = var_0.mem_0
    let (var_14: uint64) = var_0.mem_1
    let (var_15: ResizeArray<Env1>) = var_0.mem_2
    let (var_16: ResizeArray<Env2>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_10((var_15: ResizeArray<Env1>), (var_13: EnvStack0), (var_14: uint64), (var_16: ResizeArray<Env2>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap3) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap3)
    method_13((var_23: EnvHeap3), (var_8: ResizeArray<EnvHeap3>))
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
and method_14((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_15((var_0: EnvStack7), (var_1: EnvStack7), (var_2: EnvStack7), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_3.get_CublasHandle()
    let (var_15: (int64 ref)) = var_13.mem_0
    let (var_16: EnvHeap5) = var_13.mem_1
    let (var_17: (bool ref)) = var_16.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_14((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
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
    let (var_37: (float32 ref)) = (ref 0.000000f)
    let (var_38: EnvHeap3) = var_2.mem_0
    let (var_39: (int64 ref)) = var_38.mem_0
    let (var_40: EnvStack0) = var_38.mem_1
    let (var_41: (uint64 ref)) = var_40.mem_0
    let (var_42: uint64) = method_5((var_41: (uint64 ref)))
    let (var_43: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_42)
    let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_43)
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 16, 32, 6, var_22, var_29, 16, var_36, 6, var_37, var_44, 16)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_23((var_0: int64), (var_1: EnvStack7), (var_2: int64)): (float32 []) =
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
and method_31((var_0: EnvStack7), (var_1: EnvStack7), (var_2: EnvStack7), (var_3: ManagedCuda.CudaBlas.CudaBlas), (var_4: ManagedCuda.CudaRand.CudaRandDevice), (var_5: EnvStack0), (var_6: uint64), (var_7: ResizeArray<Env1>), (var_8: ResizeArray<Env2>), (var_9: ManagedCuda.CudaContext), (var_10: ResizeArray<EnvHeap3>), (var_11: ResizeArray<EnvHeap4>), (var_12: ManagedCuda.BasicTypes.CUmodule), (var_13: EnvHeap4)): unit =
    let (var_14: ManagedCuda.CudaBlas.CudaBlasHandle) = var_3.get_CublasHandle()
    let (var_15: (int64 ref)) = var_13.mem_0
    let (var_16: EnvHeap5) = var_13.mem_1
    let (var_17: (bool ref)) = var_16.mem_0
    let (var_18: ManagedCuda.CudaStream) = var_16.mem_1
    let (var_19: ManagedCuda.BasicTypes.CUstream) = method_14((var_17: (bool ref)), (var_18: ManagedCuda.CudaStream))
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
    let (var_45: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_14, var_20, var_21, 16, 6, 32, var_22, var_29, 16, var_36, 6, var_37, var_44, 16)
    if var_45 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_45)
and method_32((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_33
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_34((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_35
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
and method_10((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>), (var_4: uint64)): EnvStack0 =
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
            let (var_17: (Env1 -> (Env1 -> int32))) = method_11
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
                let (var_28: (Env1 -> (Env1 -> int32))) = method_11
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
and method_13((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_33 ((var_0: EnvHeap4)): unit =
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
and method_35 ((var_0: EnvHeap3)): unit =
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
and method_11 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_12((var_2: uint64))
and method_12 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
let (var_35: uint64) = 1048576UL
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
let (var_73: int64) = 768L
let (var_74: EnvHeap6) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap6)
let (var_75: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_73: int64))
let (var_76: EnvStack7) = EnvStack7((var_75: EnvHeap3))
let (var_77: EnvHeap3) = var_76.mem_0
let (var_78: (int64 ref)) = var_77.mem_0
let (var_79: EnvStack0) = var_77.mem_1
let (var_80: (uint64 ref)) = var_79.mem_0
let (var_81: uint64) = method_5((var_80: (uint64 ref)))
let (var_82: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(192L)
let (var_83: (int64 ref)) = var_72.mem_0
let (var_84: EnvHeap5) = var_72.mem_1
let (var_85: (bool ref)) = var_84.mem_0
let (var_86: ManagedCuda.CudaStream) = var_84.mem_1
let (var_87: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
var_44.SetStream(var_87)
let (var_88: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_81)
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_88)
var_44.GenerateNormal32(var_89, var_82, 0.000000f, 1.000000f)
let (var_90: int64) = 384L
let (var_91: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_90: int64))
let (var_92: EnvStack7) = EnvStack7((var_91: EnvHeap3))
let (var_93: EnvHeap3) = var_92.mem_0
let (var_94: (int64 ref)) = var_93.mem_0
let (var_95: EnvStack0) = var_93.mem_1
let (var_96: (uint64 ref)) = var_95.mem_0
let (var_97: uint64) = method_5((var_96: (uint64 ref)))
let (var_98: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(96L)
let (var_99: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
var_44.SetStream(var_99)
let (var_100: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_97)
let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_100)
var_44.GenerateNormal32(var_101, var_98, 0.000000f, 1.000000f)
let (var_102: int64) = 384L
let (var_103: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_102: int64))
let (var_104: EnvStack7) = EnvStack7((var_103: EnvHeap3))
let (var_105: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_106: EnvHeap3) = var_104.mem_0
let (var_107: (int64 ref)) = var_106.mem_0
let (var_108: EnvStack0) = var_106.mem_1
let (var_109: (uint64 ref)) = var_108.mem_0
let (var_110: uint64) = method_5((var_109: (uint64 ref)))
let (var_111: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_110)
let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_111)
let (var_113: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(384L)
var_1.ClearMemoryAsync(var_112, 0uy, var_113, var_105)
let (var_114: int64) = 64L
let (var_115: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_114: int64))
let (var_116: EnvStack7) = EnvStack7((var_115: EnvHeap3))
let (var_117: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_118: EnvHeap3) = var_116.mem_0
let (var_119: (int64 ref)) = var_118.mem_0
let (var_120: EnvStack0) = var_118.mem_1
let (var_121: (uint64 ref)) = var_120.mem_0
let (var_122: uint64) = method_5((var_121: (uint64 ref)))
let (var_123: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_122)
let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_123)
let (var_125: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(64L)
var_1.ClearMemoryAsync(var_124, 0uy, var_125, var_117)
let (var_126: int64) = 64L
let (var_127: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_126: int64))
let (var_128: EnvStack7) = EnvStack7((var_127: EnvHeap3))
let (var_129: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_130: EnvHeap3) = var_128.mem_0
let (var_131: (int64 ref)) = var_130.mem_0
let (var_132: EnvStack0) = var_130.mem_1
let (var_133: (uint64 ref)) = var_132.mem_0
let (var_134: uint64) = method_5((var_133: (uint64 ref)))
let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_134)
let (var_136: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_135)
let (var_137: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(64L)
var_1.ClearMemoryAsync(var_136, 0uy, var_137, var_129)
let (var_138: int64) = 2048L
let (var_139: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_138: int64))
let (var_140: EnvStack7) = EnvStack7((var_139: EnvHeap3))
let (var_141: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_142: EnvHeap3) = var_140.mem_0
let (var_143: (int64 ref)) = var_142.mem_0
let (var_144: EnvStack0) = var_142.mem_1
let (var_145: (uint64 ref)) = var_144.mem_0
let (var_146: uint64) = method_5((var_145: (uint64 ref)))
let (var_147: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_146)
let (var_148: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_147)
let (var_149: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_148, 0uy, var_149, var_141)
let (var_150: int64) = 2048L
let (var_151: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_150: int64))
let (var_152: EnvStack7) = EnvStack7((var_151: EnvHeap3))
method_15((var_92: EnvStack7), (var_76: EnvStack7), (var_152: EnvStack7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4))
let (var_153: EnvHeap3) = var_152.mem_0
let (var_154: int64) = 2048L
let (var_155: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_154: int64))
let (var_156: EnvStack7) = EnvStack7((var_155: EnvHeap3))
let (var_157: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_158: EnvHeap3) = var_156.mem_0
let (var_159: (int64 ref)) = var_158.mem_0
let (var_160: EnvStack0) = var_158.mem_1
let (var_161: (uint64 ref)) = var_160.mem_0
let (var_162: uint64) = method_5((var_161: (uint64 ref)))
let (var_163: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_162)
let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_163)
let (var_165: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_164, 0uy, var_165, var_157)
let (var_167: int64) = 2048L
let (var_168: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_167: int64))
let (var_169: EnvStack7) = EnvStack7((var_168: EnvHeap3))
let (var_170: uint64) = method_5((var_121: (uint64 ref)))
let (var_171: (int64 ref)) = var_153.mem_0
let (var_172: EnvStack0) = var_153.mem_1
let (var_173: (uint64 ref)) = var_172.mem_0
let (var_174: uint64) = method_5((var_173: (uint64 ref)))
let (var_175: EnvHeap3) = var_169.mem_0
let (var_176: (int64 ref)) = var_175.mem_0
let (var_177: EnvStack0) = var_175.mem_1
let (var_178: (uint64 ref)) = var_177.mem_0
let (var_179: uint64) = method_5((var_178: (uint64 ref)))
// Cuda join point
// method_16((var_170: uint64), (var_174: uint64), (var_179: uint64))
let (var_180: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_181: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_180.set_GridDimensions(var_181)
let (var_182: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(16u, 32u, 1u)
var_180.set_BlockDimensions(var_182)
let (var_183: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_185: (System.Object [])) = [|var_170; var_174; var_179|]: (System.Object [])
var_180.RunAsync(var_183, var_185)
let (var_186: int64) = 2048L
let (var_187: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_186: int64))
let (var_188: EnvStack7) = EnvStack7((var_187: EnvHeap3))
let (var_189: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_190: EnvHeap3) = var_188.mem_0
let (var_191: (int64 ref)) = var_190.mem_0
let (var_192: EnvStack0) = var_190.mem_1
let (var_193: (uint64 ref)) = var_192.mem_0
let (var_194: uint64) = method_5((var_193: (uint64 ref)))
let (var_195: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_194)
let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_195)
let (var_197: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_196, 0uy, var_197, var_189)
let (var_202: int64) = 2048L
let (var_203: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_202: int64))
let (var_204: EnvStack7) = EnvStack7((var_203: EnvHeap3))
let (var_205: uint64) = method_5((var_178: (uint64 ref)))
let (var_206: EnvHeap3) = var_204.mem_0
let (var_207: (int64 ref)) = var_206.mem_0
let (var_208: EnvStack0) = var_206.mem_1
let (var_209: (uint64 ref)) = var_208.mem_0
let (var_210: uint64) = method_5((var_209: (uint64 ref)))
// Cuda join point
// method_19((var_205: uint64), (var_210: uint64))
let (var_211: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_19", var_32, var_1)
let (var_212: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_211.set_GridDimensions(var_212)
let (var_213: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_211.set_BlockDimensions(var_213)
let (var_214: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_216: (System.Object [])) = [|var_205; var_210|]: (System.Object [])
var_211.RunAsync(var_214, var_216)
let (var_217: int64) = 2048L
let (var_218: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_217: int64))
let (var_219: EnvStack7) = EnvStack7((var_218: EnvHeap3))
let (var_220: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_221: EnvHeap3) = var_219.mem_0
let (var_222: (int64 ref)) = var_221.mem_0
let (var_223: EnvStack0) = var_221.mem_1
let (var_224: (uint64 ref)) = var_223.mem_0
let (var_225: uint64) = method_5((var_224: (uint64 ref)))
let (var_226: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_225)
let (var_227: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_226)
let (var_228: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_227, 0uy, var_228, var_220)
let (var_229: uint64) = method_5((var_209: (uint64 ref)))
let (var_230: uint64) = method_5((var_145: (uint64 ref)))
let (var_234: int64) = 4L
let (var_235: EnvHeap3) = method_9((var_74: EnvHeap6), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_234: int64))
let (var_236: EnvStack7) = EnvStack7((var_235: EnvHeap3))
let (var_237: EnvHeap3) = var_236.mem_0
let (var_238: (int64 ref)) = var_237.mem_0
let (var_239: EnvStack0) = var_237.mem_1
let (var_240: (uint64 ref)) = var_239.mem_0
let (var_241: uint64) = method_5((var_240: (uint64 ref)))
// Cuda join point
// method_21((var_229: uint64), (var_230: uint64), (var_241: uint64))
let (var_242: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_21", var_32, var_1)
let (var_243: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_242.set_GridDimensions(var_243)
let (var_244: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(512u, 1u, 1u)
var_242.set_BlockDimensions(var_244)
let (var_245: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_247: (System.Object [])) = [|var_229; var_230; var_241|]: (System.Object [])
var_242.RunAsync(var_245, var_247)
let (var_248: int64) = 1L
let (var_249: int64) = 0L
let (var_250: (float32 [])) = method_23((var_248: int64), (var_236: EnvStack7), (var_249: int64))
let (var_251: float32) = var_250.[int32 0L]
let (var_252: string) = System.String.Format("Cost is: {0}",var_251)
let (var_253: string) = System.String.Format("{0}",var_252)
System.Console.WriteLine(var_253)
let (var_254: uint64) = method_5((var_240: (uint64 ref)))
let (var_255: uint64) = method_5((var_209: (uint64 ref)))
let (var_256: uint64) = method_5((var_145: (uint64 ref)))
let (var_257: uint64) = method_5((var_224: (uint64 ref)))
// Cuda join point
// method_24((var_254: uint64), (var_255: uint64), (var_256: uint64), (var_257: uint64))
let (var_258: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_32, var_1)
let (var_259: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_258.set_GridDimensions(var_259)
let (var_260: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_258.set_BlockDimensions(var_260)
let (var_261: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_263: (System.Object [])) = [|var_254; var_255; var_256; var_257|]: (System.Object [])
var_258.RunAsync(var_261, var_263)
let (var_264: uint64) = method_5((var_178: (uint64 ref)))
let (var_265: uint64) = method_5((var_224: (uint64 ref)))
let (var_266: uint64) = method_5((var_209: (uint64 ref)))
let (var_267: uint64) = method_5((var_193: (uint64 ref)))
// Cuda join point
// method_25((var_264: uint64), (var_265: uint64), (var_266: uint64), (var_267: uint64))
let (var_268: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_268.set_GridDimensions(var_269)
let (var_270: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_268.set_BlockDimensions(var_270)
let (var_271: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_273: (System.Object [])) = [|var_264; var_265; var_266; var_267|]: (System.Object [])
var_268.RunAsync(var_271, var_273)
let (var_274: uint64) = method_5((var_173: (uint64 ref)))
let (var_275: uint64) = method_5((var_193: (uint64 ref)))
let (var_276: uint64) = method_5((var_178: (uint64 ref)))
let (var_277: uint64) = method_5((var_121: (uint64 ref)))
let (var_278: uint64) = method_5((var_133: (uint64 ref)))
// Cuda join point
// method_26((var_274: uint64), (var_275: uint64), (var_276: uint64), (var_277: uint64), (var_278: uint64))
let (var_279: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_32, var_1)
let (var_280: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_279.set_GridDimensions(var_280)
let (var_281: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(16u, 32u, 1u)
var_279.set_BlockDimensions(var_281)
let (var_282: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_284: (System.Object [])) = [|var_274; var_275; var_276; var_277; var_278|]: (System.Object [])
var_279.RunAsync(var_282, var_284)
let (var_285: uint64) = method_5((var_121: (uint64 ref)))
let (var_286: uint64) = method_5((var_173: (uint64 ref)))
let (var_287: uint64) = method_5((var_193: (uint64 ref)))
let (var_288: uint64) = method_5((var_178: (uint64 ref)))
let (var_289: uint64) = method_5((var_161: (uint64 ref)))
// Cuda join point
// method_30((var_285: uint64), (var_286: uint64), (var_287: uint64), (var_288: uint64), (var_289: uint64))
let (var_290: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_32, var_1)
let (var_291: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_290.set_GridDimensions(var_291)
let (var_292: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(16u, 32u, 1u)
var_290.set_BlockDimensions(var_292)
let (var_293: ManagedCuda.BasicTypes.CUstream) = method_14((var_85: (bool ref)), (var_86: ManagedCuda.CudaStream))
let (var_295: (System.Object [])) = [|var_285; var_286; var_287; var_288; var_289|]: (System.Object [])
var_290.RunAsync(var_293, var_295)
method_31((var_156: EnvStack7), (var_76: EnvStack7), (var_104: EnvStack7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4))
method_32((var_68: ResizeArray<EnvHeap4>))
method_34((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_296: (uint64 ref)) = var_40.mem_0
let (var_297: uint64) = method_5((var_296: (uint64 ref)))
let (var_298: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_297)
let (var_299: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_298)
var_1.FreeMemory(var_299)
var_296 := 0UL
var_1.Dispose()

