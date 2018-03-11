module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_26(float * var_0, float * var_1, float * var_2);
    __global__ void method_29(float * var_0, float * var_1);
    __global__ void method_31(float * var_0, float * var_1, float * var_2);
    __global__ void method_34(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_35(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_37(float * var_0, float * var_1);
    __device__ char method_27(long long int * var_0);
    __device__ char method_28(long long int * var_0);
    __device__ char method_30(long long int * var_0);
    __device__ char method_32(long long int * var_0, float * var_1);
    __device__ char method_38(long long int * var_0, float * var_1);
    __device__ char method_39(long long int * var_0, float * var_1);
    __device__ char method_40(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_26(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_27(var_7)) {
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
            while (method_28(var_18)) {
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
    __global__ void method_29(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_30(var_6)) {
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
    __global__ void method_31(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (1024 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_32(var_8, var_9)) {
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
    __global__ void method_34(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_30(var_8)) {
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
            float var_22 = (var_18 - var_19);
            float var_23 = (1 - var_18);
            float var_24 = (var_18 * var_23);
            float var_25 = (var_22 / var_24);
            float var_26 = (var_25 / 128);
            float var_27 = (var_20 + var_26);
            var_3[var_10] = var_27;
            long long int var_28 = (var_10 + 1280);
            var_8[0] = var_28;
        }
        long long int var_29 = var_8[0];
    }
    __global__ void method_35(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_30(var_8)) {
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
    __global__ void method_37(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_27(var_6)) {
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
            while (method_38(var_21, var_22)) {
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
            while (method_39(var_41, var_42)) {
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
                    while (method_40(var_44, var_69, var_70)) {
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
    __device__ char method_27(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_28(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_30(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1280);
    }
    __device__ char method_32(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1280);
    }
    __device__ char method_38(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_39(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_40(long long int var_0, long long int * var_1, float * var_2) {
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
and Tuple7 =
    struct
    val mem_0: Tuple8
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple8 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple9 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack10 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap11 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
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
and method_9((var_0: string)): Tuple7 =
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
    Tuple7(Tuple8(var_16, var_17, var_18), var_22)
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
and method_12((var_0: string)): Tuple9 =
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
    Tuple9(var_12, var_14)
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
and method_17((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: int64), (var_12: (float32 [])), (var_13: int64), (var_14: int64), (var_15: int64)): EnvStack10 =
    let (var_16: int64) = (var_11 * var_14)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: int64) = (var_13 * 4L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_21 + var_19)
    let (var_23: int64) = (var_16 * 4L)
    let (var_24: EnvHeap11) = ({mem_0 = (var_2: EnvStack0); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env1>); mem_3 = (var_5: ResizeArray<Env2>)} : EnvHeap11)
    let (var_25: EnvHeap3) = method_18((var_24: EnvHeap11), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_23: int64))
    let (var_26: EnvStack10) = EnvStack10((var_25: EnvHeap3))
    let (var_27: EnvHeap3) = var_26.mem_0
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
and method_18((var_0: EnvHeap11), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
    let (var_13: EnvStack0) = var_0.mem_0
    let (var_14: uint64) = var_0.mem_1
    let (var_15: ResizeArray<Env1>) = var_0.mem_2
    let (var_16: ResizeArray<Env2>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_19((var_15: ResizeArray<Env1>), (var_13: EnvStack0), (var_14: uint64), (var_16: ResizeArray<Env2>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap3) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap3)
    method_22((var_23: EnvHeap3), (var_8: ResizeArray<EnvHeap3>))
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
and method_23((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_24((var_0: EnvStack10), (var_1: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_13: EnvStack10), (var_14: EnvStack10), (var_15: EnvStack10), (var_16: EnvStack10), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvStack0), (var_20: uint64), (var_21: ResizeArray<Env1>), (var_22: ResizeArray<Env2>), (var_23: ManagedCuda.CudaContext), (var_24: ResizeArray<EnvHeap3>), (var_25: ResizeArray<EnvHeap4>), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: EnvHeap4), (var_28: int64)): float =
    let (var_29: bool) = (var_28 < 1L)
    if var_29 then
        let (var_30: bool) = (var_28 >= 0L)
        let (var_31: bool) = (var_30 = false)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_32: int64) = (var_28 * 100352L)
        if var_31 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_33: int64) = (var_28 * 1280L)
        let (var_42: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_43: int64) = 0L
        let (var_44: float) = 0.000000
        let (var_45: EnvHeap3) = var_0.mem_0
        let (var_46: int64) = 5120L
        let (var_47: EnvHeap11) = ({mem_0 = (var_4: EnvStack0); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env1>); mem_3 = (var_7: ResizeArray<Env2>)} : EnvHeap11)
        let (var_48: EnvHeap3) = method_18((var_47: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_46: int64))
        let (var_49: EnvStack10) = EnvStack10((var_48: EnvHeap3))
        method_25((var_16: EnvStack10), (var_0: EnvStack10), (var_32: int64), (var_49: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4))
        let (var_50: EnvHeap3) = var_49.mem_0
        let (var_51: int64) = 5120L
        let (var_52: EnvHeap3) = method_18((var_47: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_51: int64))
        let (var_53: EnvStack10) = EnvStack10((var_52: EnvHeap3))
        let (var_54: (int64 ref)) = var_12.mem_0
        let (var_55: EnvHeap5) = var_12.mem_1
        let (var_56: (bool ref)) = var_55.mem_0
        let (var_57: ManagedCuda.CudaStream) = var_55.mem_1
        let (var_58: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
        let (var_59: EnvHeap3) = var_53.mem_0
        let (var_60: (int64 ref)) = var_59.mem_0
        let (var_61: EnvStack0) = var_59.mem_1
        let (var_62: (uint64 ref)) = var_61.mem_0
        let (var_63: uint64) = method_5((var_62: (uint64 ref)))
        let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_63)
        let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_64)
        let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_8.ClearMemoryAsync(var_65, 0uy, var_66, var_58)
        let (var_67: EnvHeap3) = var_14.mem_0
        let (var_68: (int64 ref)) = var_67.mem_0
        let (var_69: EnvStack0) = var_67.mem_1
        let (var_70: (uint64 ref)) = var_69.mem_0
        let (var_71: uint64) = method_5((var_70: (uint64 ref)))
        let (var_72: (int64 ref)) = var_50.mem_0
        let (var_73: EnvStack0) = var_50.mem_1
        let (var_74: (uint64 ref)) = var_73.mem_0
        let (var_75: uint64) = method_5((var_74: (uint64 ref)))
        let (var_76: uint64) = method_5((var_74: (uint64 ref)))
        // Cuda join point
        // method_26((var_71: uint64), (var_75: uint64), (var_76: uint64))
        let (var_77: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_11, var_8)
        let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_77.set_GridDimensions(var_78)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
        var_77.set_BlockDimensions(var_79)
        let (var_80: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
        let (var_82: (System.Object [])) = [|var_71; var_75; var_76|]: (System.Object [])
        var_77.RunAsync(var_80, var_82)
        let (var_87: int64) = 5120L
        let (var_88: EnvHeap3) = method_18((var_47: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_87: int64))
        let (var_89: EnvStack10) = EnvStack10((var_88: EnvHeap3))
        let (var_90: uint64) = method_5((var_74: (uint64 ref)))
        let (var_91: EnvHeap3) = var_89.mem_0
        let (var_92: (int64 ref)) = var_91.mem_0
        let (var_93: EnvStack0) = var_91.mem_1
        let (var_94: (uint64 ref)) = var_93.mem_0
        let (var_95: uint64) = method_5((var_94: (uint64 ref)))
        // Cuda join point
        // method_29((var_90: uint64), (var_95: uint64))
        let (var_96: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_11, var_8)
        let (var_97: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_96.set_GridDimensions(var_97)
        let (var_98: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_96.set_BlockDimensions(var_98)
        let (var_99: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
        let (var_101: (System.Object [])) = [|var_90; var_95|]: (System.Object [])
        var_96.RunAsync(var_99, var_101)
        let (var_102: int64) = 5120L
        let (var_103: EnvHeap3) = method_18((var_47: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_102: int64))
        let (var_104: EnvStack10) = EnvStack10((var_103: EnvHeap3))
        let (var_105: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
        let (var_106: EnvHeap3) = var_104.mem_0
        let (var_107: (int64 ref)) = var_106.mem_0
        let (var_108: EnvStack0) = var_106.mem_1
        let (var_109: (uint64 ref)) = var_108.mem_0
        let (var_110: uint64) = method_5((var_109: (uint64 ref)))
        let (var_111: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_110)
        let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_111)
        let (var_113: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_8.ClearMemoryAsync(var_112, 0uy, var_113, var_105)
        let (var_114: uint64) = method_5((var_94: (uint64 ref)))
        let (var_115: EnvHeap3) = var_1.mem_0
        let (var_116: (int64 ref)) = var_115.mem_0
        let (var_117: EnvStack0) = var_115.mem_1
        let (var_118: (uint64 ref)) = var_117.mem_0
        let (var_119: uint64) = method_5((var_118: (uint64 ref)))
        let (var_120: int64) = (var_33 * 4L)
        let (var_121: uint64) = (uint64 var_120)
        let (var_122: uint64) = (var_119 + var_121)
        let (var_131: int64) = 4L
        let (var_132: EnvHeap3) = method_18((var_47: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_131: int64))
        let (var_133: EnvStack10) = EnvStack10((var_132: EnvHeap3))
        let (var_134: EnvHeap3) = var_133.mem_0
        let (var_135: (int64 ref)) = var_134.mem_0
        let (var_136: EnvStack0) = var_134.mem_1
        let (var_137: (uint64 ref)) = var_136.mem_0
        let (var_138: uint64) = method_5((var_137: (uint64 ref)))
        // Cuda join point
        // method_31((var_114: uint64), (var_122: uint64), (var_138: uint64))
        let (var_139: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_11, var_8)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_139.set_GridDimensions(var_140)
        let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_139.set_BlockDimensions(var_141)
        let (var_142: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
        let (var_144: (System.Object [])) = [|var_114; var_122; var_138|]: (System.Object [])
        var_139.RunAsync(var_142, var_144)
        let (var_145: int64) = 1L
        let (var_146: int64) = 0L
        let (var_147: (float32 [])) = method_33((var_145: int64), (var_133: EnvStack10), (var_146: int64))
        let (var_148: float32) = var_147.[int32 0L]
        let (var_149: float) = (float var_148)
        let (var_150: float) = (var_44 + var_149)
        let (var_151: int64) = (var_43 + 1L)
        if (System.Double.IsNaN var_150) then
            let (var_152: float) = (float var_151)
            (var_150 / var_152)
        else
            let (var_154: uint64) = method_5((var_137: (uint64 ref)))
            let (var_155: uint64) = method_5((var_94: (uint64 ref)))
            let (var_156: uint64) = method_5((var_118: (uint64 ref)))
            let (var_157: uint64) = (var_156 + var_121)
            let (var_158: uint64) = method_5((var_109: (uint64 ref)))
            // Cuda join point
            // method_34((var_154: uint64), (var_155: uint64), (var_157: uint64), (var_158: uint64))
            let (var_159: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_11, var_8)
            let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_159.set_GridDimensions(var_160)
            let (var_161: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_159.set_BlockDimensions(var_161)
            let (var_162: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
            let (var_164: (System.Object [])) = [|var_154; var_155; var_157; var_158|]: (System.Object [])
            var_159.RunAsync(var_162, var_164)
            let (var_165: uint64) = method_5((var_74: (uint64 ref)))
            let (var_166: uint64) = method_5((var_109: (uint64 ref)))
            let (var_167: uint64) = method_5((var_94: (uint64 ref)))
            let (var_168: uint64) = method_5((var_62: (uint64 ref)))
            // Cuda join point
            // method_35((var_165: uint64), (var_166: uint64), (var_167: uint64), (var_168: uint64))
            let (var_169: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_11, var_8)
            let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_169.set_GridDimensions(var_170)
            let (var_171: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_169.set_BlockDimensions(var_171)
            let (var_172: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
            let (var_174: (System.Object [])) = [|var_165; var_166; var_167; var_168|]: (System.Object [])
            var_169.RunAsync(var_172, var_174)
            method_36((var_53: EnvStack10), (var_0: EnvStack10), (var_32: int64), (var_15: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4))
            let (var_175: uint64) = method_5((var_62: (uint64 ref)))
            let (var_176: EnvHeap3) = var_13.mem_0
            let (var_177: (int64 ref)) = var_176.mem_0
            let (var_178: EnvStack0) = var_176.mem_1
            let (var_179: (uint64 ref)) = var_178.mem_0
            let (var_180: uint64) = method_5((var_179: (uint64 ref)))
            // Cuda join point
            // method_37((var_175: uint64), (var_180: uint64))
            let (var_181: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_11, var_8)
            let (var_182: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_181.set_GridDimensions(var_182)
            let (var_183: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_181.set_BlockDimensions(var_183)
            let (var_184: ManagedCuda.BasicTypes.CUstream) = method_23((var_56: (bool ref)), (var_57: ManagedCuda.CudaStream))
            let (var_186: (System.Object [])) = [|var_175; var_180|]: (System.Object [])
            var_181.RunAsync(var_184, var_186)
            let (var_187: int64) = 0L
            let (var_188: float) = 0.000000
            let (var_189: int64) = 0L
            method_41((var_13: EnvStack10), (var_187: int64), (var_188: float), (var_14: EnvStack10), (var_15: EnvStack10), (var_16: EnvStack10), (var_0: EnvStack10), (var_32: int64), (var_1: EnvStack10), (var_33: int64), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvStack0), (var_20: uint64), (var_21: ResizeArray<Env1>), (var_22: ResizeArray<Env2>), (var_23: ManagedCuda.CudaContext), (var_24: ResizeArray<EnvHeap3>), (var_25: ResizeArray<EnvHeap4>), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: EnvHeap4), (var_189: int64))
            let (var_190: int64) = 0L
            method_44((var_15: EnvStack10), (var_187: int64), (var_188: float), (var_13: EnvStack10), (var_14: EnvStack10), (var_16: EnvStack10), (var_0: EnvStack10), (var_32: int64), (var_1: EnvStack10), (var_33: int64), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_42: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_17: ManagedCuda.CudaBlas.CudaBlas), (var_18: ManagedCuda.CudaRand.CudaRandDevice), (var_19: EnvStack0), (var_20: uint64), (var_21: ResizeArray<Env1>), (var_22: ResizeArray<Env2>), (var_23: ManagedCuda.CudaContext), (var_24: ResizeArray<EnvHeap3>), (var_25: ResizeArray<EnvHeap4>), (var_26: ManagedCuda.BasicTypes.CUmodule), (var_27: EnvHeap4), (var_190: int64))
            let (var_191: int64) = (var_28 + 1L)
            method_46((var_0: EnvStack10), (var_1: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_151: int64), (var_150: float), (var_13: EnvStack10), (var_14: EnvStack10), (var_15: EnvStack10), (var_16: EnvStack10), (var_191: int64))
    else
        0.000000
and method_47((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_48
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_49((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_50
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
and method_19((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>), (var_4: uint64)): EnvStack0 =
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
            let (var_17: (Env1 -> (Env1 -> int32))) = method_20
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
                let (var_28: (Env1 -> (Env1 -> int32))) = method_20
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
and method_22((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_25((var_0: EnvStack10), (var_1: EnvStack10), (var_2: int64), (var_3: EnvStack10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_23((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 10, 128, 784, var_23, var_30, 10, var_40, 784, var_41, var_48, 10)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_33((var_0: int64), (var_1: EnvStack10), (var_2: int64)): (float32 []) =
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
and method_36((var_0: EnvStack10), (var_1: EnvStack10), (var_2: int64), (var_3: EnvStack10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_23((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 10, 784, 128, var_23, var_30, 10, var_40, 784, var_41, var_48, 10)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_41((var_0: EnvStack10), (var_1: int64), (var_2: float), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64)): unit =
    let (var_33: bool) = (var_32 < 10L)
    if var_33 then
        let (var_34: bool) = (var_32 >= 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = 1L
        let (var_37: (float32 [])) = method_33((var_36: int64), (var_3: EnvStack10), (var_32: int64))
        let (var_38: float32) = var_37.[int32 0L]
        let (var_39: float32) = (var_38 + 0.001000f)
        method_42((var_3: EnvStack10), (var_32: int64), (var_39: float32))
        let (var_40: int64) = 0L
        let (var_41: float) = method_43((var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_1: int64), (var_2: float), (var_0: EnvStack10), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_40: int64))
        let (var_42: float32) = (float32 var_41)
        let (var_43: float32) = (var_38 - 0.001000f)
        method_42((var_3: EnvStack10), (var_32: int64), (var_43: float32))
        let (var_44: int64) = 0L
        let (var_45: float) = method_43((var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_1: int64), (var_2: float), (var_0: EnvStack10), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_44: int64))
        let (var_46: float32) = (float32 var_45)
        method_42((var_3: EnvStack10), (var_32: int64), (var_38: float32))
        let (var_47: float32) = (var_42 - var_46)
        let (var_48: float32) = (var_47 / 0.002000f)
        let (var_49: int64) = 1L
        let (var_50: (float32 [])) = method_33((var_49: int64), (var_0: EnvStack10), (var_32: int64))
        let (var_51: float32) = var_50.[int32 0L]
        let (var_52: float32) = (var_51 - var_48)
        let (var_53: float32) = (-var_52)
        let (var_54: bool) = (var_53 < var_52)
        let (var_55: float32) =
            if var_54 then
                var_52
            else
                var_53
        let (var_56: bool) = (var_55 >= 0.001000f)
        if var_56 then
            let (var_57: string) = System.String.Format("{0}",var_51)
            let (var_58: string) = System.String.Format("{0} = {1}","true_gradient",var_57)
            let (var_59: string) = System.String.Format("{0}",var_55)
            let (var_60: string) = System.String.Format("{0} = {1}","diff",var_59)
            let (var_61: string) = System.String.Format("{0}",var_48)
            let (var_62: string) = System.String.Format("{0} = {1}","approx_gradient",var_61)
            let (var_63: string) = String.concat "; " [|var_62; var_60; var_58|]
            let (var_64: string) = System.String.Format("{0}{1}{2}","{",var_63,"}")
            System.Console.WriteLine(var_64)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_65: int64) = (var_32 + 1L)
        method_41((var_0: EnvStack10), (var_1: int64), (var_2: float), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_65: int64))
    else
        ()
and method_44((var_0: EnvStack10), (var_1: int64), (var_2: float), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_32: int64)): unit =
    let (var_33: bool) = (var_32 < 784L)
    if var_33 then
        let (var_34: bool) = (var_32 >= 0L)
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_36: int64) = (var_32 * 10L)
        if var_35 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_37: int64) = 0L
        method_45((var_0: EnvStack10), (var_36: int64), (var_1: int64), (var_2: float), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_37: int64))
        let (var_38: int64) = (var_32 + 1L)
        method_44((var_0: EnvStack10), (var_1: int64), (var_2: float), (var_3: EnvStack10), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: int64), (var_8: EnvStack10), (var_9: int64), (var_10: ManagedCuda.CudaBlas.CudaBlas), (var_11: ManagedCuda.CudaRand.CudaRandDevice), (var_12: EnvStack0), (var_13: uint64), (var_14: ResizeArray<Env1>), (var_15: ResizeArray<Env2>), (var_16: ManagedCuda.CudaContext), (var_17: ResizeArray<EnvHeap3>), (var_18: ResizeArray<EnvHeap4>), (var_19: ManagedCuda.BasicTypes.CUmodule), (var_20: EnvHeap4), (var_21: ManagedCuda.CudaBlas.CudaBlas), (var_22: ManagedCuda.CudaRand.CudaRandDevice), (var_23: EnvStack0), (var_24: uint64), (var_25: ResizeArray<Env1>), (var_26: ResizeArray<Env2>), (var_27: ManagedCuda.CudaContext), (var_28: ResizeArray<EnvHeap3>), (var_29: ResizeArray<EnvHeap4>), (var_30: ManagedCuda.BasicTypes.CUmodule), (var_31: EnvHeap4), (var_38: int64))
    else
        ()
and method_46((var_0: EnvStack10), (var_1: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_13: int64), (var_14: float), (var_15: EnvStack10), (var_16: EnvStack10), (var_17: EnvStack10), (var_18: EnvStack10), (var_19: int64)): float =
    let (var_20: bool) = (var_19 < 1L)
    if var_20 then
        let (var_21: bool) = (var_19 >= 0L)
        let (var_22: bool) = (var_21 = false)
        if var_22 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_23: int64) = (var_19 * 100352L)
        if var_22 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_24: int64) = (var_19 * 1280L)
        let (var_33: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_34: EnvHeap3) = var_0.mem_0
        let (var_35: int64) = 5120L
        let (var_36: EnvHeap11) = ({mem_0 = (var_4: EnvStack0); mem_1 = (var_5: uint64); mem_2 = (var_6: ResizeArray<Env1>); mem_3 = (var_7: ResizeArray<Env2>)} : EnvHeap11)
        let (var_37: EnvHeap3) = method_18((var_36: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_35: int64))
        let (var_38: EnvStack10) = EnvStack10((var_37: EnvHeap3))
        method_25((var_18: EnvStack10), (var_0: EnvStack10), (var_23: int64), (var_38: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4))
        let (var_39: EnvHeap3) = var_38.mem_0
        let (var_40: int64) = 5120L
        let (var_41: EnvHeap3) = method_18((var_36: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_40: int64))
        let (var_42: EnvStack10) = EnvStack10((var_41: EnvHeap3))
        let (var_43: (int64 ref)) = var_12.mem_0
        let (var_44: EnvHeap5) = var_12.mem_1
        let (var_45: (bool ref)) = var_44.mem_0
        let (var_46: ManagedCuda.CudaStream) = var_44.mem_1
        let (var_47: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_48: EnvHeap3) = var_42.mem_0
        let (var_49: (int64 ref)) = var_48.mem_0
        let (var_50: EnvStack0) = var_48.mem_1
        let (var_51: (uint64 ref)) = var_50.mem_0
        let (var_52: uint64) = method_5((var_51: (uint64 ref)))
        let (var_53: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_52)
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_53)
        let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_8.ClearMemoryAsync(var_54, 0uy, var_55, var_47)
        let (var_56: EnvHeap3) = var_16.mem_0
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
        // method_26((var_60: uint64), (var_64: uint64), (var_65: uint64))
        let (var_66: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_11, var_8)
        let (var_67: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_66.set_GridDimensions(var_67)
        let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
        var_66.set_BlockDimensions(var_68)
        let (var_69: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_71: (System.Object [])) = [|var_60; var_64; var_65|]: (System.Object [])
        var_66.RunAsync(var_69, var_71)
        let (var_76: int64) = 5120L
        let (var_77: EnvHeap3) = method_18((var_36: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_76: int64))
        let (var_78: EnvStack10) = EnvStack10((var_77: EnvHeap3))
        let (var_79: uint64) = method_5((var_63: (uint64 ref)))
        let (var_80: EnvHeap3) = var_78.mem_0
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: EnvStack0) = var_80.mem_1
        let (var_83: (uint64 ref)) = var_82.mem_0
        let (var_84: uint64) = method_5((var_83: (uint64 ref)))
        // Cuda join point
        // method_29((var_79: uint64), (var_84: uint64))
        let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_11, var_8)
        let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_85.set_GridDimensions(var_86)
        let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_85.set_BlockDimensions(var_87)
        let (var_88: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_90: (System.Object [])) = [|var_79; var_84|]: (System.Object [])
        var_85.RunAsync(var_88, var_90)
        let (var_91: int64) = 5120L
        let (var_92: EnvHeap3) = method_18((var_36: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_91: int64))
        let (var_93: EnvStack10) = EnvStack10((var_92: EnvHeap3))
        let (var_94: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_95: EnvHeap3) = var_93.mem_0
        let (var_96: (int64 ref)) = var_95.mem_0
        let (var_97: EnvStack0) = var_95.mem_1
        let (var_98: (uint64 ref)) = var_97.mem_0
        let (var_99: uint64) = method_5((var_98: (uint64 ref)))
        let (var_100: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_99)
        let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_100)
        let (var_102: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_8.ClearMemoryAsync(var_101, 0uy, var_102, var_94)
        let (var_103: uint64) = method_5((var_83: (uint64 ref)))
        let (var_104: EnvHeap3) = var_1.mem_0
        let (var_105: (int64 ref)) = var_104.mem_0
        let (var_106: EnvStack0) = var_104.mem_1
        let (var_107: (uint64 ref)) = var_106.mem_0
        let (var_108: uint64) = method_5((var_107: (uint64 ref)))
        let (var_109: int64) = (var_24 * 4L)
        let (var_110: uint64) = (uint64 var_109)
        let (var_111: uint64) = (var_108 + var_110)
        let (var_120: int64) = 4L
        let (var_121: EnvHeap3) = method_18((var_36: EnvHeap11), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_120: int64))
        let (var_122: EnvStack10) = EnvStack10((var_121: EnvHeap3))
        let (var_123: EnvHeap3) = var_122.mem_0
        let (var_124: (int64 ref)) = var_123.mem_0
        let (var_125: EnvStack0) = var_123.mem_1
        let (var_126: (uint64 ref)) = var_125.mem_0
        let (var_127: uint64) = method_5((var_126: (uint64 ref)))
        // Cuda join point
        // method_31((var_103: uint64), (var_111: uint64), (var_127: uint64))
        let (var_128: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_11, var_8)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_128.set_GridDimensions(var_129)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_128.set_BlockDimensions(var_130)
        let (var_131: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_133: (System.Object [])) = [|var_103; var_111; var_127|]: (System.Object [])
        var_128.RunAsync(var_131, var_133)
        let (var_134: int64) = 1L
        let (var_135: int64) = 0L
        let (var_136: (float32 [])) = method_33((var_134: int64), (var_122: EnvStack10), (var_135: int64))
        let (var_137: float32) = var_136.[int32 0L]
        let (var_138: float) = (float var_137)
        let (var_139: float) = (var_14 + var_138)
        let (var_140: int64) = (var_13 + 1L)
        if (System.Double.IsNaN var_139) then
            let (var_141: float) = (float var_140)
            (var_139 / var_141)
        else
            let (var_143: uint64) = method_5((var_126: (uint64 ref)))
            let (var_144: uint64) = method_5((var_83: (uint64 ref)))
            let (var_145: uint64) = method_5((var_107: (uint64 ref)))
            let (var_146: uint64) = (var_145 + var_110)
            let (var_147: uint64) = method_5((var_98: (uint64 ref)))
            // Cuda join point
            // method_34((var_143: uint64), (var_144: uint64), (var_146: uint64), (var_147: uint64))
            let (var_148: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_11, var_8)
            let (var_149: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_148.set_GridDimensions(var_149)
            let (var_150: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_148.set_BlockDimensions(var_150)
            let (var_151: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_153: (System.Object [])) = [|var_143; var_144; var_146; var_147|]: (System.Object [])
            var_148.RunAsync(var_151, var_153)
            let (var_154: uint64) = method_5((var_63: (uint64 ref)))
            let (var_155: uint64) = method_5((var_98: (uint64 ref)))
            let (var_156: uint64) = method_5((var_83: (uint64 ref)))
            let (var_157: uint64) = method_5((var_51: (uint64 ref)))
            // Cuda join point
            // method_35((var_154: uint64), (var_155: uint64), (var_156: uint64), (var_157: uint64))
            let (var_158: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_11, var_8)
            let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
            var_158.set_GridDimensions(var_159)
            let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_158.set_BlockDimensions(var_160)
            let (var_161: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_163: (System.Object [])) = [|var_154; var_155; var_156; var_157|]: (System.Object [])
            var_158.RunAsync(var_161, var_163)
            method_36((var_42: EnvStack10), (var_0: EnvStack10), (var_23: int64), (var_17: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_33: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4))
            let (var_164: uint64) = method_5((var_51: (uint64 ref)))
            let (var_165: EnvHeap3) = var_15.mem_0
            let (var_166: (int64 ref)) = var_165.mem_0
            let (var_167: EnvStack0) = var_165.mem_1
            let (var_168: (uint64 ref)) = var_167.mem_0
            let (var_169: uint64) = method_5((var_168: (uint64 ref)))
            // Cuda join point
            // method_37((var_164: uint64), (var_169: uint64))
            let (var_170: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_11, var_8)
            let (var_171: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_170.set_GridDimensions(var_171)
            let (var_172: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
            var_170.set_BlockDimensions(var_172)
            let (var_173: ManagedCuda.BasicTypes.CUstream) = method_23((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_175: (System.Object [])) = [|var_164; var_169|]: (System.Object [])
            var_170.RunAsync(var_173, var_175)
            let (var_176: int64) = (var_19 + 1L)
            method_46((var_0: EnvStack10), (var_1: EnvStack10), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: EnvStack0), (var_5: uint64), (var_6: ResizeArray<Env1>), (var_7: ResizeArray<Env2>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<EnvHeap3>), (var_10: ResizeArray<EnvHeap4>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: EnvHeap4), (var_140: int64), (var_139: float), (var_15: EnvStack10), (var_16: EnvStack10), (var_17: EnvStack10), (var_18: EnvStack10), (var_176: int64))
    else
        let (var_179: float) = (float var_13)
        (var_14 / var_179)
and method_48 ((var_0: EnvHeap4)): unit =
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
and method_50 ((var_0: EnvHeap3)): unit =
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
and method_20 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_21((var_2: uint64))
and method_42((var_0: EnvStack10), (var_1: int64), (var_2: float32)): unit =
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_3.[int32 0L] <- var_2
    let (var_4: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_3,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_5: int64) = var_4.AddrOfPinnedObject().ToInt64()
    let (var_6: uint64) = (uint64 var_5)
    let (var_7: EnvHeap3) = var_0.mem_0
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
and method_43((var_0: EnvStack10), (var_1: int64), (var_2: EnvStack10), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_15: int64), (var_16: float), (var_17: EnvStack10), (var_18: EnvStack10), (var_19: EnvStack10), (var_20: EnvStack10), (var_21: int64)): float =
    let (var_22: bool) = (var_21 < 1L)
    if var_22 then
        let (var_23: bool) = (var_21 >= 0L)
        let (var_24: bool) = (var_23 = false)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (var_21 * 100352L)
        let (var_26: int64) = (var_1 + var_25)
        if var_24 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_27: int64) = (var_21 * 1280L)
        let (var_28: int64) = (var_3 + var_27)
        let (var_37: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_38: EnvHeap3) = var_0.mem_0
        let (var_39: int64) = 5120L
        let (var_40: EnvHeap11) = ({mem_0 = (var_6: EnvStack0); mem_1 = (var_7: uint64); mem_2 = (var_8: ResizeArray<Env1>); mem_3 = (var_9: ResizeArray<Env2>)} : EnvHeap11)
        let (var_41: EnvHeap3) = method_18((var_40: EnvHeap11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_39: int64))
        let (var_42: EnvStack10) = EnvStack10((var_41: EnvHeap3))
        method_25((var_20: EnvStack10), (var_0: EnvStack10), (var_26: int64), (var_42: EnvStack10), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4))
        let (var_43: EnvHeap3) = var_42.mem_0
        let (var_44: int64) = 5120L
        let (var_45: EnvHeap3) = method_18((var_40: EnvHeap11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_44: int64))
        let (var_46: EnvStack10) = EnvStack10((var_45: EnvHeap3))
        let (var_47: (int64 ref)) = var_14.mem_0
        let (var_48: EnvHeap5) = var_14.mem_1
        let (var_49: (bool ref)) = var_48.mem_0
        let (var_50: ManagedCuda.CudaStream) = var_48.mem_1
        let (var_51: ManagedCuda.BasicTypes.CUstream) = method_23((var_49: (bool ref)), (var_50: ManagedCuda.CudaStream))
        let (var_52: EnvHeap3) = var_46.mem_0
        let (var_53: (int64 ref)) = var_52.mem_0
        let (var_54: EnvStack0) = var_52.mem_1
        let (var_55: (uint64 ref)) = var_54.mem_0
        let (var_56: uint64) = method_5((var_55: (uint64 ref)))
        let (var_57: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_56)
        let (var_58: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_57)
        let (var_59: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_10.ClearMemoryAsync(var_58, 0uy, var_59, var_51)
        let (var_60: EnvHeap3) = var_18.mem_0
        let (var_61: (int64 ref)) = var_60.mem_0
        let (var_62: EnvStack0) = var_60.mem_1
        let (var_63: (uint64 ref)) = var_62.mem_0
        let (var_64: uint64) = method_5((var_63: (uint64 ref)))
        let (var_65: (int64 ref)) = var_43.mem_0
        let (var_66: EnvStack0) = var_43.mem_1
        let (var_67: (uint64 ref)) = var_66.mem_0
        let (var_68: uint64) = method_5((var_67: (uint64 ref)))
        let (var_69: uint64) = method_5((var_67: (uint64 ref)))
        // Cuda join point
        // method_26((var_64: uint64), (var_68: uint64), (var_69: uint64))
        let (var_70: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_13, var_10)
        let (var_71: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_70.set_GridDimensions(var_71)
        let (var_72: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
        var_70.set_BlockDimensions(var_72)
        let (var_73: ManagedCuda.BasicTypes.CUstream) = method_23((var_49: (bool ref)), (var_50: ManagedCuda.CudaStream))
        let (var_75: (System.Object [])) = [|var_64; var_68; var_69|]: (System.Object [])
        var_70.RunAsync(var_73, var_75)
        let (var_80: int64) = 5120L
        let (var_81: EnvHeap3) = method_18((var_40: EnvHeap11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_80: int64))
        let (var_82: EnvStack10) = EnvStack10((var_81: EnvHeap3))
        let (var_83: uint64) = method_5((var_67: (uint64 ref)))
        let (var_84: EnvHeap3) = var_82.mem_0
        let (var_85: (int64 ref)) = var_84.mem_0
        let (var_86: EnvStack0) = var_84.mem_1
        let (var_87: (uint64 ref)) = var_86.mem_0
        let (var_88: uint64) = method_5((var_87: (uint64 ref)))
        // Cuda join point
        // method_29((var_83: uint64), (var_88: uint64))
        let (var_89: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_29", var_13, var_10)
        let (var_90: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_89.set_GridDimensions(var_90)
        let (var_91: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_89.set_BlockDimensions(var_91)
        let (var_92: ManagedCuda.BasicTypes.CUstream) = method_23((var_49: (bool ref)), (var_50: ManagedCuda.CudaStream))
        let (var_94: (System.Object [])) = [|var_83; var_88|]: (System.Object [])
        var_89.RunAsync(var_92, var_94)
        let (var_95: int64) = 5120L
        let (var_96: EnvHeap3) = method_18((var_40: EnvHeap11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_95: int64))
        let (var_97: EnvStack10) = EnvStack10((var_96: EnvHeap3))
        let (var_98: ManagedCuda.BasicTypes.CUstream) = method_23((var_49: (bool ref)), (var_50: ManagedCuda.CudaStream))
        let (var_99: EnvHeap3) = var_97.mem_0
        let (var_100: (int64 ref)) = var_99.mem_0
        let (var_101: EnvStack0) = var_99.mem_1
        let (var_102: (uint64 ref)) = var_101.mem_0
        let (var_103: uint64) = method_5((var_102: (uint64 ref)))
        let (var_104: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_103)
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_104)
        let (var_106: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(5120L)
        var_10.ClearMemoryAsync(var_105, 0uy, var_106, var_98)
        let (var_107: uint64) = method_5((var_87: (uint64 ref)))
        let (var_108: EnvHeap3) = var_2.mem_0
        let (var_109: (int64 ref)) = var_108.mem_0
        let (var_110: EnvStack0) = var_108.mem_1
        let (var_111: (uint64 ref)) = var_110.mem_0
        let (var_112: uint64) = method_5((var_111: (uint64 ref)))
        let (var_113: int64) = (var_28 * 4L)
        let (var_114: uint64) = (uint64 var_113)
        let (var_115: uint64) = (var_112 + var_114)
        let (var_124: int64) = 4L
        let (var_125: EnvHeap3) = method_18((var_40: EnvHeap11), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_37: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_124: int64))
        let (var_126: EnvStack10) = EnvStack10((var_125: EnvHeap3))
        let (var_127: EnvHeap3) = var_126.mem_0
        let (var_128: (int64 ref)) = var_127.mem_0
        let (var_129: EnvStack0) = var_127.mem_1
        let (var_130: (uint64 ref)) = var_129.mem_0
        let (var_131: uint64) = method_5((var_130: (uint64 ref)))
        // Cuda join point
        // method_31((var_107: uint64), (var_115: uint64), (var_131: uint64))
        let (var_132: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_13, var_10)
        let (var_133: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_132.set_GridDimensions(var_133)
        let (var_134: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1024u, 1u, 1u)
        var_132.set_BlockDimensions(var_134)
        let (var_135: ManagedCuda.BasicTypes.CUstream) = method_23((var_49: (bool ref)), (var_50: ManagedCuda.CudaStream))
        let (var_137: (System.Object [])) = [|var_107; var_115; var_131|]: (System.Object [])
        var_132.RunAsync(var_135, var_137)
        let (var_138: int64) = 1L
        let (var_139: int64) = 0L
        let (var_140: (float32 [])) = method_33((var_138: int64), (var_126: EnvStack10), (var_139: int64))
        let (var_141: float32) = var_140.[int32 0L]
        let (var_142: float) = (float var_141)
        let (var_143: float) = (var_16 + var_142)
        let (var_144: int64) = (var_15 + 1L)
        if (System.Double.IsNaN var_143) then
            let (var_145: float) = (float var_144)
            (var_143 / var_145)
        else
            let (var_147: int64) = (var_21 + 1L)
            method_43((var_0: EnvStack10), (var_1: int64), (var_2: EnvStack10), (var_3: int64), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4), (var_144: int64), (var_143: float), (var_17: EnvStack10), (var_18: EnvStack10), (var_19: EnvStack10), (var_20: EnvStack10), (var_147: int64))
    else
        let (var_150: float) = (float var_15)
        (var_16 / var_150)
and method_45((var_0: EnvStack10), (var_1: int64), (var_2: int64), (var_3: float), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: EnvStack10), (var_8: int64), (var_9: EnvStack10), (var_10: int64), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_22: ManagedCuda.CudaBlas.CudaBlas), (var_23: ManagedCuda.CudaRand.CudaRandDevice), (var_24: EnvStack0), (var_25: uint64), (var_26: ResizeArray<Env1>), (var_27: ResizeArray<Env2>), (var_28: ManagedCuda.CudaContext), (var_29: ResizeArray<EnvHeap3>), (var_30: ResizeArray<EnvHeap4>), (var_31: ManagedCuda.BasicTypes.CUmodule), (var_32: EnvHeap4), (var_33: int64)): unit =
    let (var_34: bool) = (var_33 < 10L)
    if var_34 then
        let (var_35: bool) = (var_33 >= 0L)
        let (var_36: bool) = (var_35 = false)
        if var_36 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_37: int64) = (var_1 + var_33)
        if var_36 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_38: int64) = 1L
        let (var_39: (float32 [])) = method_33((var_38: int64), (var_6: EnvStack10), (var_37: int64))
        let (var_40: float32) = var_39.[int32 0L]
        let (var_41: float32) = (var_40 + 0.001000f)
        method_42((var_6: EnvStack10), (var_37: int64), (var_41: float32))
        let (var_42: int64) = 0L
        let (var_43: float) = method_43((var_7: EnvStack10), (var_8: int64), (var_9: EnvStack10), (var_10: int64), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_2: int64), (var_3: float), (var_4: EnvStack10), (var_5: EnvStack10), (var_0: EnvStack10), (var_6: EnvStack10), (var_42: int64))
        let (var_44: float32) = (float32 var_43)
        let (var_45: float32) = (var_40 - 0.001000f)
        method_42((var_6: EnvStack10), (var_37: int64), (var_45: float32))
        let (var_46: int64) = 0L
        let (var_47: float) = method_43((var_7: EnvStack10), (var_8: int64), (var_9: EnvStack10), (var_10: int64), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_2: int64), (var_3: float), (var_4: EnvStack10), (var_5: EnvStack10), (var_0: EnvStack10), (var_6: EnvStack10), (var_46: int64))
        let (var_48: float32) = (float32 var_47)
        method_42((var_6: EnvStack10), (var_37: int64), (var_40: float32))
        let (var_49: float32) = (var_44 - var_48)
        let (var_50: float32) = (var_49 / 0.002000f)
        let (var_51: int64) = 1L
        let (var_52: (float32 [])) = method_33((var_51: int64), (var_0: EnvStack10), (var_37: int64))
        let (var_53: float32) = var_52.[int32 0L]
        let (var_54: float32) = (var_53 - var_50)
        let (var_55: float32) = (-var_54)
        let (var_56: bool) = (var_55 < var_54)
        let (var_57: float32) =
            if var_56 then
                var_54
            else
                var_55
        let (var_58: bool) = (var_57 >= 0.001000f)
        if var_58 then
            let (var_59: string) = System.String.Format("{0}",var_53)
            let (var_60: string) = System.String.Format("{0} = {1}","true_gradient",var_59)
            let (var_61: string) = System.String.Format("{0}",var_57)
            let (var_62: string) = System.String.Format("{0} = {1}","diff",var_61)
            let (var_63: string) = System.String.Format("{0}",var_50)
            let (var_64: string) = System.String.Format("{0} = {1}","approx_gradient",var_63)
            let (var_65: string) = String.concat "; " [|var_64; var_62; var_60|]
            let (var_66: string) = System.String.Format("{0}{1}{2}","{",var_65,"}")
            System.Console.WriteLine(var_66)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_67: int64) = (var_33 + 1L)
        method_45((var_0: EnvStack10), (var_1: int64), (var_2: int64), (var_3: float), (var_4: EnvStack10), (var_5: EnvStack10), (var_6: EnvStack10), (var_7: EnvStack10), (var_8: int64), (var_9: EnvStack10), (var_10: int64), (var_11: ManagedCuda.CudaBlas.CudaBlas), (var_12: ManagedCuda.CudaRand.CudaRandDevice), (var_13: EnvStack0), (var_14: uint64), (var_15: ResizeArray<Env1>), (var_16: ResizeArray<Env2>), (var_17: ManagedCuda.CudaContext), (var_18: ResizeArray<EnvHeap3>), (var_19: ResizeArray<EnvHeap4>), (var_20: ManagedCuda.BasicTypes.CUmodule), (var_21: EnvHeap4), (var_22: ManagedCuda.CudaBlas.CudaBlas), (var_23: ManagedCuda.CudaRand.CudaRandDevice), (var_24: EnvStack0), (var_25: uint64), (var_26: ResizeArray<Env1>), (var_27: ResizeArray<Env2>), (var_28: ManagedCuda.CudaContext), (var_29: ResizeArray<EnvHeap3>), (var_30: ResizeArray<EnvHeap4>), (var_31: ManagedCuda.BasicTypes.CUmodule), (var_32: EnvHeap4), (var_67: int64))
    else
        ()
and method_21 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
let (var_74: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_75: Tuple7) = method_9((var_74: string))
let (var_76: Tuple8) = var_75.mem_0
let (var_77: (uint8 [])) = var_75.mem_1
let (var_78: int64) = var_76.mem_0
let (var_79: int64) = var_76.mem_1
let (var_80: int64) = var_76.mem_2
let (var_81: bool) = (10000L = var_78)
let (var_85: bool) =
    if var_81 then
        let (var_82: bool) = (28L = var_79)
        if var_82 then
            (28L = var_80)
        else
            false
    else
        false
let (var_86: bool) = (var_85 = false)
if var_86 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_87: int64) = var_77.LongLength
let (var_88: bool) = (var_87 > 0L)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_90: bool) = (var_87 = 7840000L)
let (var_91: bool) = (var_90 = false)
if var_91 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_95: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_96: int64) = 0L
method_10((var_77: (uint8 [])), (var_95: (float32 [])), (var_96: int64))
let (var_97: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_98: Tuple9) = method_12((var_97: string))
let (var_99: int64) = var_98.mem_0
let (var_100: (uint8 [])) = var_98.mem_1
let (var_101: bool) = (10000L = var_99)
let (var_102: bool) = (var_101 = false)
if var_102 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_106: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_107: int64) = 0L
method_13((var_100: (uint8 [])), (var_106: (float32 [])), (var_107: int64))
let (var_108: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_109: Tuple7) = method_9((var_108: string))
let (var_110: Tuple8) = var_109.mem_0
let (var_111: (uint8 [])) = var_109.mem_1
let (var_112: int64) = var_110.mem_0
let (var_113: int64) = var_110.mem_1
let (var_114: int64) = var_110.mem_2
let (var_115: bool) = (60000L = var_112)
let (var_119: bool) =
    if var_115 then
        let (var_116: bool) = (28L = var_113)
        if var_116 then
            (28L = var_114)
        else
            false
    else
        false
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_121: int64) = var_111.LongLength
let (var_122: bool) = (var_121 > 0L)
let (var_123: bool) = (var_122 = false)
if var_123 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_124: bool) = (var_121 = 47040000L)
let (var_125: bool) = (var_124 = false)
if var_125 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_129: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_130: int64) = 0L
method_15((var_111: (uint8 [])), (var_129: (float32 [])), (var_130: int64))
let (var_131: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_132: Tuple9) = method_12((var_131: string))
let (var_133: int64) = var_132.mem_0
let (var_134: (uint8 [])) = var_132.mem_1
let (var_135: bool) = (60000L = var_133)
let (var_136: bool) = (var_135 = false)
if var_136 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_140: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_141: int64) = 0L
method_16((var_134: (uint8 [])), (var_140: (float32 [])), (var_141: int64))
let (var_142: int64) = 10000L
let (var_143: int64) = 0L
let (var_144: int64) = 784L
let (var_145: int64) = 1L
let (var_146: EnvStack10) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_142: int64), (var_95: (float32 [])), (var_143: int64), (var_144: int64), (var_145: int64))
let (var_147: int64) = 10000L
let (var_148: int64) = 0L
let (var_149: int64) = 10L
let (var_150: int64) = 1L
let (var_151: EnvStack10) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_147: int64), (var_106: (float32 [])), (var_148: int64), (var_149: int64), (var_150: int64))
let (var_152: int64) = 60000L
let (var_153: int64) = 0L
let (var_154: int64) = 784L
let (var_155: int64) = 1L
let (var_156: EnvStack10) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_152: int64), (var_129: (float32 [])), (var_153: int64), (var_154: int64), (var_155: int64))
let (var_157: int64) = 60000L
let (var_158: int64) = 0L
let (var_159: int64) = 10L
let (var_160: int64) = 1L
let (var_161: EnvStack10) = method_17((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_157: int64), (var_140: (float32 [])), (var_158: int64), (var_159: int64), (var_160: int64))
let (var_162: int64) = 31360L
let (var_163: EnvHeap11) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap11)
let (var_164: EnvHeap3) = method_18((var_163: EnvHeap11), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_162: int64))
let (var_165: EnvStack10) = EnvStack10((var_164: EnvHeap3))
let (var_166: EnvHeap3) = var_165.mem_0
let (var_167: (int64 ref)) = var_166.mem_0
let (var_168: EnvStack0) = var_166.mem_1
let (var_169: (uint64 ref)) = var_168.mem_0
let (var_170: uint64) = method_5((var_169: (uint64 ref)))
let (var_171: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
let (var_172: (int64 ref)) = var_72.mem_0
let (var_173: EnvHeap5) = var_72.mem_1
let (var_174: (bool ref)) = var_173.mem_0
let (var_175: ManagedCuda.CudaStream) = var_173.mem_1
let (var_176: ManagedCuda.BasicTypes.CUstream) = method_23((var_174: (bool ref)), (var_175: ManagedCuda.CudaStream))
var_44.SetStream(var_176)
let (var_177: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_170)
let (var_178: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_177)
var_44.GenerateNormal32(var_178, var_171, 0.000000f, 0.050189f)
let (var_179: int64) = 31360L
let (var_180: EnvHeap3) = method_18((var_163: EnvHeap11), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_179: int64))
let (var_181: EnvStack10) = EnvStack10((var_180: EnvHeap3))
let (var_182: ManagedCuda.BasicTypes.CUstream) = method_23((var_174: (bool ref)), (var_175: ManagedCuda.CudaStream))
let (var_183: EnvHeap3) = var_181.mem_0
let (var_184: (int64 ref)) = var_183.mem_0
let (var_185: EnvStack0) = var_183.mem_1
let (var_186: (uint64 ref)) = var_185.mem_0
let (var_187: uint64) = method_5((var_186: (uint64 ref)))
let (var_188: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_187)
let (var_189: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_188)
let (var_190: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_189, 0uy, var_190, var_182)
let (var_191: int64) = 40L
let (var_192: EnvHeap3) = method_18((var_163: EnvHeap11), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_191: int64))
let (var_193: EnvStack10) = EnvStack10((var_192: EnvHeap3))
let (var_194: ManagedCuda.BasicTypes.CUstream) = method_23((var_174: (bool ref)), (var_175: ManagedCuda.CudaStream))
let (var_195: EnvHeap3) = var_193.mem_0
let (var_196: (int64 ref)) = var_195.mem_0
let (var_197: EnvStack0) = var_195.mem_1
let (var_198: (uint64 ref)) = var_197.mem_0
let (var_199: uint64) = method_5((var_198: (uint64 ref)))
let (var_200: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_199)
let (var_201: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_200)
let (var_202: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_201, 0uy, var_202, var_194)
let (var_203: int64) = 40L
let (var_204: EnvHeap3) = method_18((var_163: EnvHeap11), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_203: int64))
let (var_205: EnvStack10) = EnvStack10((var_204: EnvHeap3))
let (var_206: ManagedCuda.BasicTypes.CUstream) = method_23((var_174: (bool ref)), (var_175: ManagedCuda.CudaStream))
let (var_207: EnvHeap3) = var_205.mem_0
let (var_208: (int64 ref)) = var_207.mem_0
let (var_209: EnvStack0) = var_207.mem_1
let (var_210: (uint64 ref)) = var_209.mem_0
let (var_211: uint64) = method_5((var_210: (uint64 ref)))
let (var_212: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_211)
let (var_213: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_212)
let (var_214: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_213, 0uy, var_214, var_206)
let (var_215: ManagedCuda.CudaBlas.CudaBlas) = var_73.mem_0
let (var_216: ManagedCuda.CudaRand.CudaRandDevice) = var_73.mem_1
let (var_217: EnvStack0) = var_73.mem_2
let (var_218: uint64) = var_73.mem_3
let (var_219: ResizeArray<Env1>) = var_73.mem_4
let (var_220: ResizeArray<Env2>) = var_73.mem_5
let (var_221: ManagedCuda.CudaContext) = var_73.mem_6
let (var_222: ResizeArray<EnvHeap3>) = var_73.mem_7
let (var_223: ResizeArray<EnvHeap4>) = var_73.mem_8
let (var_224: ManagedCuda.BasicTypes.CUmodule) = var_73.mem_9
let (var_225: EnvHeap4) = var_73.mem_10
let (var_226: int64) = 0L
let (var_227: float) = method_24((var_156: EnvStack10), (var_161: EnvStack10), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_205: EnvStack10), (var_193: EnvStack10), (var_181: EnvStack10), (var_165: EnvStack10), (var_215: ManagedCuda.CudaBlas.CudaBlas), (var_216: ManagedCuda.CudaRand.CudaRandDevice), (var_217: EnvStack0), (var_218: uint64), (var_219: ResizeArray<Env1>), (var_220: ResizeArray<Env2>), (var_221: ManagedCuda.CudaContext), (var_222: ResizeArray<EnvHeap3>), (var_223: ResizeArray<EnvHeap4>), (var_224: ManagedCuda.BasicTypes.CUmodule), (var_225: EnvHeap4), (var_226: int64))
let (var_228: string) = System.String.Format("Training: {0}",var_227)
let (var_229: string) = System.String.Format("{0}",var_228)
System.Console.WriteLine(var_229)
method_47((var_68: ResizeArray<EnvHeap4>))
method_49((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_230: (uint64 ref)) = var_40.mem_0
let (var_231: uint64) = method_5((var_230: (uint64 ref)))
let (var_232: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_231)
let (var_233: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_232)
var_1.FreeMemory(var_233)
var_230 := 0UL
var_1.Dispose()

