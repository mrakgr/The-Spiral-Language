module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(unsigned char * var_0, float * var_1);
    __global__ void method_23(float * var_0, float * var_1, float * var_2);
    __global__ void method_25(float * var_0, float * var_1);
    __global__ void method_26(float * var_0, float * var_1, float * var_2);
    __global__ void method_31(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_34(float * var_0, float * var_1);
    __global__ void method_36(float * var_0, float * var_1);
    __global__ void method_37(float * var_0, float * var_1);
    __device__ char method_17(long long int * var_0);
    __device__ char method_18(long long int * var_0);
    __device__ char method_24(long long int * var_0);
    __device__ char method_27(long long int * var_0, float * var_1);
    __device__ char method_35(long long int * var_0, float * var_1);
    __device__ char method_38(long long int * var_0);
    
    __global__ void method_16(unsigned char * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (var_2 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_17(var_5)) {
            long long int var_7 = var_5[0];
            long long int var_8 = (var_7 % 32);
            long long int var_9 = (var_7 / 32);
            long long int var_10 = (var_9 % 32);
            long long int var_11 = (var_9 / 32);
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 32);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = (var_10 * 128);
            char var_18;
            if (var_12) {
                var_18 = (var_10 < 32);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            unsigned char var_20 = var_0[var_10];
            long long int var_21[1];
            var_21[0] = var_8;
            while (method_18(var_21)) {
                long long int var_23 = var_21[0];
                unsigned char var_24 = ((unsigned char) (var_23));
                char var_25 = (var_20 == var_24);
                float var_26;
                if (var_25) {
                    var_26 = 1;
                } else {
                    var_26 = 0;
                }
                char var_27 = (var_23 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_23 < 128);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_16 + var_23);
                var_1[var_31] = var_26;
                long long int var_32 = (var_23 + 32);
                var_21[0] = var_32;
            }
            long long int var_33 = var_21[0];
            long long int var_34 = (var_7 + 1);
            var_5[0] = var_34;
        }
        long long int var_35 = var_5[0];
    }
    __global__ void method_23(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (32 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_18(var_7)) {
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
            long long int var_16 = (var_14 + var_15);
            long long int var_17[1];
            var_17[0] = var_16;
            while (method_24(var_17)) {
                long long int var_19 = var_17[0];
                char var_20 = (var_19 >= 0);
                char var_22;
                if (var_20) {
                    var_22 = (var_19 < 1);
                } else {
                    var_22 = 0;
                }
                char var_23 = (var_22 == 0);
                if (var_23) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_24 = (var_19 * 128);
                char var_26;
                if (var_10) {
                    var_26 = (var_9 < 128);
                } else {
                    var_26 = 0;
                }
                char var_27 = (var_26 == 0);
                if (var_27) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_28 = (var_24 + var_9);
                char var_30;
                if (var_20) {
                    var_30 = (var_19 < 1);
                } else {
                    var_30 = 0;
                }
                char var_31 = (var_30 == 0);
                if (var_31) {
                    // "Argument out of bounds."
                } else {
                }
                char var_33;
                if (var_10) {
                    var_33 = (var_9 < 128);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                float var_35 = var_0[var_9];
                float var_36 = var_1[var_28];
                float var_37 = var_2[var_28];
                float var_38 = (var_35 + var_36);
                var_2[var_28] = var_38;
                long long int var_39 = (var_19 + 1);
                var_17[0] = var_39;
            }
            long long int var_40 = var_17[0];
            long long int var_41 = (var_9 + 128);
            var_7[0] = var_41;
        }
        long long int var_42 = var_7[0];
    }
    __global__ void method_25(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_18(var_6)) {
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
            float var_18 = (-var_16);
            float var_19 = exp(var_18);
            float var_20 = (1 + var_19);
            float var_21 = (1 / var_20);
            var_1[var_8] = var_21;
            long long int var_22 = (var_8 + 128);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_26(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_27(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 128);
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
            long long int var_28 = (var_11 + 128);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,128,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        long long int var_32 = threadIdx.x;
        char var_33 = (var_32 == 0);
        if (var_33) {
            long long int var_34 = blockIdx.x;
            char var_35 = (var_34 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_34 < 1);
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
    __global__ void method_31(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_18(var_8)) {
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
            char var_16;
            if (var_11) {
                var_16 = (var_10 < 128);
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
            float var_26 = (var_20 + var_25);
            var_3[var_10] = var_26;
            long long int var_27 = (var_10 + 128);
            var_8[0] = var_27;
        }
        long long int var_28 = var_8[0];
    }
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_18(var_8)) {
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
            char var_16;
            if (var_11) {
                var_16 = (var_10 < 128);
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
            long long int var_26 = (var_10 + 128);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_34(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_18(var_6)) {
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
            long long int var_18 = (var_16 + var_17);
            float var_19 = 0;
            long long int var_20[1];
            float var_21[1];
            var_20[0] = var_18;
            var_21[0] = var_19;
            while (method_35(var_20, var_21)) {
                long long int var_23 = var_20[0];
                float var_24 = var_21[0];
                char var_25 = (var_23 >= 0);
                char var_27;
                if (var_25) {
                    var_27 = (var_23 < 1);
                } else {
                    var_27 = 0;
                }
                char var_28 = (var_27 == 0);
                if (var_28) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_29 = (var_23 * 128);
                char var_31;
                if (var_9) {
                    var_31 = (var_8 < 128);
                } else {
                    var_31 = 0;
                }
                char var_32 = (var_31 == 0);
                if (var_32) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_33 = (var_29 + var_8);
                float var_34 = var_0[var_33];
                float var_35 = (var_24 + var_34);
                long long int var_36 = (var_23 + 1);
                var_20[0] = var_36;
                var_21[0] = var_35;
            }
            long long int var_37 = var_20[0];
            float var_38 = var_21[0];
            float var_39 = var_1[var_8];
            float var_40 = (var_38 + var_39);
            var_1[var_8] = var_40;
            long long int var_41 = (var_8 + 128);
            var_6[0] = var_41;
        }
        long long int var_42 = var_6[0];
    }
    __global__ void method_36(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_18(var_6)) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 128);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __global__ void method_37(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_38(var_6)) {
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
            float var_18 = (0.25 * var_17);
            float var_19 = (var_16 - var_18);
            var_0[var_8] = var_19;
            var_1[var_8] = 0;
            long long int var_20 = (var_8 + 8192);
            var_6[0] = var_20;
        }
        long long int var_21 = var_6[0];
    }
    __device__ char method_17(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1024);
    }
    __device__ char method_18(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
    }
    __device__ char method_24(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_27(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_35(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 1);
    }
    __device__ char method_38(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 16384);
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
and EnvStack7 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap8 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
and EnvStack9 =
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
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: int64), (var_12: (uint8 [])), (var_13: int64), (var_14: int64)): EnvStack7 =
    let (var_15: int64) = (var_11 * var_14)
    let (var_16: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_17: int64) = var_16.AddrOfPinnedObject().ToInt64()
    let (var_18: uint64) = (uint64 var_17)
    let (var_19: uint64) = (uint64 var_13)
    let (var_20: uint64) = (var_19 + var_18)
    let (var_21: EnvHeap8) = ({mem_0 = (var_2: EnvStack0); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env1>); mem_3 = (var_5: ResizeArray<Env2>)} : EnvHeap8)
    let (var_22: EnvHeap3) = method_11((var_21: EnvHeap8), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_15: int64))
    let (var_23: EnvStack7) = EnvStack7((var_22: EnvHeap3))
    let (var_24: EnvHeap3) = var_23.mem_0
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: EnvStack0) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_34: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_30, var_32, var_33)
    if var_34 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_34)
    var_16.Free()
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
and method_11((var_0: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
    let (var_13: EnvStack0) = var_0.mem_0
    let (var_14: uint64) = var_0.mem_1
    let (var_15: ResizeArray<Env1>) = var_0.mem_2
    let (var_16: ResizeArray<Env2>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_12((var_15: ResizeArray<Env1>), (var_13: EnvStack0), (var_14: uint64), (var_16: ResizeArray<Env2>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap3) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap3)
    method_15((var_23: EnvHeap3), (var_8: ResizeArray<EnvHeap3>))
    var_23
and method_19((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_20((var_0: EnvStack6), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ResizeArray<Env2>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<EnvHeap3>), (var_15: ResizeArray<EnvHeap4>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: EnvHeap4), (var_18: EnvStack9), (var_19: int64)): unit =
    let (var_20: bool) = (var_19 < 100L)
    if var_20 then
        let (var_21: ManagedCuda.CudaBlas.CudaBlas) = var_0.mem_0
        let (var_22: ManagedCuda.CudaRand.CudaRandDevice) = var_0.mem_1
        let (var_23: EnvStack0) = var_0.mem_2
        let (var_24: uint64) = var_0.mem_3
        let (var_25: ResizeArray<Env1>) = var_0.mem_4
        let (var_26: ResizeArray<Env2>) = var_0.mem_5
        let (var_27: ManagedCuda.CudaContext) = var_0.mem_6
        let (var_28: ResizeArray<EnvHeap3>) = var_0.mem_7
        let (var_29: ResizeArray<EnvHeap4>) = var_0.mem_8
        let (var_30: ManagedCuda.BasicTypes.CUmodule) = var_0.mem_9
        let (var_31: EnvHeap4) = var_0.mem_10
        let (var_32: int64) = 0L
        let (var_33: float) = 0.000000
        let (var_34: int64) = 0L
        let (var_35: float) = method_21((var_18: EnvStack9), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ResizeArray<Env2>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<EnvHeap3>), (var_15: ResizeArray<EnvHeap4>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: EnvHeap4), (var_32: int64), (var_33: float), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_34: int64))
        let (var_36: string) = System.String.Format("Training: {0}",var_35)
        let (var_37: string) = System.String.Format("{0}",var_36)
        System.Console.WriteLine(var_37)
        let (var_38: int64) = (var_19 + 1L)
        method_20((var_0: EnvStack6), (var_1: EnvStack9), (var_2: EnvStack9), (var_3: EnvStack9), (var_4: EnvStack9), (var_5: EnvStack9), (var_6: EnvStack9), (var_7: ManagedCuda.CudaBlas.CudaBlas), (var_8: ManagedCuda.CudaRand.CudaRandDevice), (var_9: EnvStack0), (var_10: uint64), (var_11: ResizeArray<Env1>), (var_12: ResizeArray<Env2>), (var_13: ManagedCuda.CudaContext), (var_14: ResizeArray<EnvHeap3>), (var_15: ResizeArray<EnvHeap4>), (var_16: ManagedCuda.BasicTypes.CUmodule), (var_17: EnvHeap4), (var_18: EnvStack9), (var_38: int64))
    else
        ()
and method_39((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_40
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_29((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_30
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
and method_12((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>), (var_4: uint64)): EnvStack0 =
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
            let (var_17: (Env1 -> (Env1 -> int32))) = method_13
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
                let (var_28: (Env1 -> (Env1 -> int32))) = method_13
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
and method_15((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_21((var_0: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64), (var_13: float), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: EnvStack9), (var_20: int64)): float =
    let (var_21: bool) = (var_20 < 1L)
    if var_21 then
        let (var_22: bool) = (var_20 >= 0L)
        let (var_23: bool) = (var_22 = false)
        if var_23 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_24: int64) = (var_20 * 128L)
        if var_23 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_25: int64) = (128L + var_24)
        let (var_26: EnvHeap8) = ({mem_0 = (var_3: EnvStack0); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env1>); mem_3 = (var_6: ResizeArray<Env2>)} : EnvHeap8)
        let (var_27: EnvStack0) = var_26.mem_0
        let (var_28: uint64) = var_26.mem_1
        let (var_29: ResizeArray<Env1>) = var_26.mem_2
        let (var_30: ResizeArray<Env2>) = var_26.mem_3
        method_1((var_29: ResizeArray<Env1>), (var_27: EnvStack0), (var_28: uint64), (var_30: ResizeArray<Env2>))
        let (var_34: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
        let (var_35: EnvHeap3) = var_0.mem_0
        let (var_36: int64) = 512L
        let (var_37: EnvHeap3) = method_11((var_26: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_36: int64))
        let (var_38: EnvStack9) = EnvStack9((var_37: EnvHeap3))
        method_22((var_17: EnvStack9), (var_0: EnvStack9), (var_24: int64), (var_38: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
        let (var_39: EnvHeap3) = var_38.mem_0
        let (var_40: int64) = 512L
        let (var_41: EnvHeap3) = method_11((var_26: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_40: int64))
        let (var_42: EnvStack9) = EnvStack9((var_41: EnvHeap3))
        let (var_43: (int64 ref)) = var_11.mem_0
        let (var_44: EnvHeap5) = var_11.mem_1
        let (var_45: (bool ref)) = var_44.mem_0
        let (var_46: ManagedCuda.CudaStream) = var_44.mem_1
        let (var_47: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_48: EnvHeap3) = var_42.mem_0
        let (var_49: (int64 ref)) = var_48.mem_0
        let (var_50: EnvStack0) = var_48.mem_1
        let (var_51: (uint64 ref)) = var_50.mem_0
        let (var_52: uint64) = method_5((var_51: (uint64 ref)))
        let (var_53: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_52)
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_53)
        let (var_55: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_54, 0uy, var_55, var_47)
        let (var_56: EnvHeap3) = var_15.mem_0
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
        // method_23((var_60: uint64), (var_64: uint64), (var_65: uint64))
        let (var_66: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_23", var_10, var_7)
        let (var_67: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
        var_66.set_GridDimensions(var_67)
        let (var_68: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_66.set_BlockDimensions(var_68)
        let (var_69: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_71: (System.Object [])) = [|var_60; var_64; var_65|]: (System.Object [])
        var_66.RunAsync(var_69, var_71)
        let (var_76: int64) = 512L
        let (var_77: EnvHeap3) = method_11((var_26: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_76: int64))
        let (var_78: EnvStack9) = EnvStack9((var_77: EnvHeap3))
        let (var_79: uint64) = method_5((var_63: (uint64 ref)))
        let (var_80: EnvHeap3) = var_78.mem_0
        let (var_81: (int64 ref)) = var_80.mem_0
        let (var_82: EnvStack0) = var_80.mem_1
        let (var_83: (uint64 ref)) = var_82.mem_0
        let (var_84: uint64) = method_5((var_83: (uint64 ref)))
        // Cuda join point
        // method_25((var_79: uint64), (var_84: uint64))
        let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_10, var_7)
        let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_85.set_GridDimensions(var_86)
        let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_85.set_BlockDimensions(var_87)
        let (var_88: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_90: (System.Object [])) = [|var_79; var_84|]: (System.Object [])
        var_85.RunAsync(var_88, var_90)
        let (var_91: int64) = 512L
        let (var_92: EnvHeap3) = method_11((var_26: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_91: int64))
        let (var_93: EnvStack9) = EnvStack9((var_92: EnvHeap3))
        let (var_94: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_95: EnvHeap3) = var_93.mem_0
        let (var_96: (int64 ref)) = var_95.mem_0
        let (var_97: EnvStack0) = var_95.mem_1
        let (var_98: (uint64 ref)) = var_97.mem_0
        let (var_99: uint64) = method_5((var_98: (uint64 ref)))
        let (var_100: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_99)
        let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_100)
        let (var_102: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
        var_7.ClearMemoryAsync(var_101, 0uy, var_102, var_94)
        let (var_103: uint64) = method_5((var_83: (uint64 ref)))
        let (var_104: (int64 ref)) = var_35.mem_0
        let (var_105: EnvStack0) = var_35.mem_1
        let (var_106: (uint64 ref)) = var_105.mem_0
        let (var_107: uint64) = method_5((var_106: (uint64 ref)))
        let (var_108: int64) = (var_25 * 4L)
        let (var_109: uint64) = (uint64 var_108)
        let (var_110: uint64) = (var_107 + var_109)
        let (var_118: int64) = 4L
        let (var_119: EnvHeap3) = method_11((var_26: EnvHeap8), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_118: int64))
        let (var_120: EnvStack9) = EnvStack9((var_119: EnvHeap3))
        let (var_121: EnvHeap3) = var_120.mem_0
        let (var_122: (int64 ref)) = var_121.mem_0
        let (var_123: EnvStack0) = var_121.mem_1
        let (var_124: (uint64 ref)) = var_123.mem_0
        let (var_125: uint64) = method_5((var_124: (uint64 ref)))
        // Cuda join point
        // method_26((var_103: uint64), (var_110: uint64), (var_125: uint64))
        let (var_126: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_10, var_7)
        let (var_127: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_126.set_GridDimensions(var_127)
        let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_126.set_BlockDimensions(var_128)
        let (var_129: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
        let (var_131: (System.Object [])) = [|var_103; var_110; var_125|]: (System.Object [])
        var_126.RunAsync(var_129, var_131)
        let (var_132: int64) = 1L
        let (var_133: int64) = 0L
        let (var_134: (float32 [])) = method_28((var_132: int64), (var_120: EnvStack9), (var_133: int64))
        let (var_135: float32) = var_134.[int32 0L]
        let (var_136: float) = (float var_135)
        let (var_137: float) = (var_13 + var_136)
        let (var_138: int64) = (var_12 + 1L)
        if (System.Double.IsNaN var_137) then
            method_29((var_34: ResizeArray<EnvHeap3>))
            let (var_139: float) = (float var_138)
            (var_137 / var_139)
        else
            let (var_141: uint64) = method_5((var_124: (uint64 ref)))
            let (var_142: uint64) = method_5((var_83: (uint64 ref)))
            let (var_143: uint64) = method_5((var_106: (uint64 ref)))
            let (var_144: uint64) = (var_143 + var_109)
            let (var_145: uint64) = method_5((var_98: (uint64 ref)))
            // Cuda join point
            // method_31((var_141: uint64), (var_142: uint64), (var_144: uint64), (var_145: uint64))
            let (var_146: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_31", var_10, var_7)
            let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_146.set_GridDimensions(var_147)
            let (var_148: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_146.set_BlockDimensions(var_148)
            let (var_149: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_151: (System.Object [])) = [|var_141; var_142; var_144; var_145|]: (System.Object [])
            var_146.RunAsync(var_149, var_151)
            let (var_152: uint64) = method_5((var_63: (uint64 ref)))
            let (var_153: uint64) = method_5((var_98: (uint64 ref)))
            let (var_154: uint64) = method_5((var_83: (uint64 ref)))
            let (var_155: uint64) = method_5((var_51: (uint64 ref)))
            // Cuda join point
            // method_32((var_152: uint64), (var_153: uint64), (var_154: uint64), (var_155: uint64))
            let (var_156: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_10, var_7)
            let (var_157: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_156.set_GridDimensions(var_157)
            let (var_158: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_156.set_BlockDimensions(var_158)
            let (var_159: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_161: (System.Object [])) = [|var_152; var_153; var_154; var_155|]: (System.Object [])
            var_156.RunAsync(var_159, var_161)
            method_33((var_42: EnvStack9), (var_0: EnvStack9), (var_24: int64), (var_16: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_34: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4))
            let (var_162: uint64) = method_5((var_51: (uint64 ref)))
            let (var_163: EnvHeap3) = var_14.mem_0
            let (var_164: (int64 ref)) = var_163.mem_0
            let (var_165: EnvStack0) = var_163.mem_1
            let (var_166: (uint64 ref)) = var_165.mem_0
            let (var_167: uint64) = method_5((var_166: (uint64 ref)))
            // Cuda join point
            // method_34((var_162: uint64), (var_167: uint64))
            let (var_168: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_34", var_10, var_7)
            let (var_169: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
            var_168.set_GridDimensions(var_169)
            let (var_170: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
            var_168.set_BlockDimensions(var_170)
            let (var_171: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_173: (System.Object [])) = [|var_162; var_167|]: (System.Object [])
            var_168.RunAsync(var_171, var_173)
            let (var_174: uint64) = method_5((var_59: (uint64 ref)))
            let (var_175: uint64) = method_5((var_166: (uint64 ref)))
            // Cuda join point
            // method_36((var_174: uint64), (var_175: uint64))
            let (var_176: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_36", var_10, var_7)
            let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
            var_176.set_GridDimensions(var_177)
            let (var_178: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_176.set_BlockDimensions(var_178)
            let (var_179: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_181: (System.Object [])) = [|var_174; var_175|]: (System.Object [])
            var_176.RunAsync(var_179, var_181)
            let (var_182: EnvHeap3) = var_17.mem_0
            let (var_183: (int64 ref)) = var_182.mem_0
            let (var_184: EnvStack0) = var_182.mem_1
            let (var_185: (uint64 ref)) = var_184.mem_0
            let (var_186: uint64) = method_5((var_185: (uint64 ref)))
            let (var_187: EnvHeap3) = var_16.mem_0
            let (var_188: (int64 ref)) = var_187.mem_0
            let (var_189: EnvStack0) = var_187.mem_1
            let (var_190: (uint64 ref)) = var_189.mem_0
            let (var_191: uint64) = method_5((var_190: (uint64 ref)))
            // Cuda join point
            // method_37((var_186: uint64), (var_191: uint64))
            let (var_192: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_10, var_7)
            let (var_193: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_192.set_GridDimensions(var_193)
            let (var_194: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_192.set_BlockDimensions(var_194)
            let (var_195: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_197: (System.Object [])) = [|var_186; var_191|]: (System.Object [])
            var_192.RunAsync(var_195, var_197)
            let (var_198: EnvHeap3) = var_19.mem_0
            let (var_199: (int64 ref)) = var_198.mem_0
            let (var_200: EnvStack0) = var_198.mem_1
            let (var_201: (uint64 ref)) = var_200.mem_0
            let (var_202: uint64) = method_5((var_201: (uint64 ref)))
            let (var_203: EnvHeap3) = var_18.mem_0
            let (var_204: (int64 ref)) = var_203.mem_0
            let (var_205: EnvStack0) = var_203.mem_1
            let (var_206: (uint64 ref)) = var_205.mem_0
            let (var_207: uint64) = method_5((var_206: (uint64 ref)))
            // Cuda join point
            // method_37((var_202: uint64), (var_207: uint64))
            let (var_208: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_37", var_10, var_7)
            let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_208.set_GridDimensions(var_209)
            let (var_210: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_208.set_BlockDimensions(var_210)
            let (var_211: ManagedCuda.BasicTypes.CUstream) = method_19((var_45: (bool ref)), (var_46: ManagedCuda.CudaStream))
            let (var_213: (System.Object [])) = [|var_202; var_207|]: (System.Object [])
            var_208.RunAsync(var_211, var_213)
            method_29((var_34: ResizeArray<EnvHeap3>))
            let (var_214: int64) = (var_20 + 1L)
            method_21((var_0: EnvStack9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_138: int64), (var_137: float), (var_14: EnvStack9), (var_15: EnvStack9), (var_16: EnvStack9), (var_17: EnvStack9), (var_18: EnvStack9), (var_19: EnvStack9), (var_214: int64))
    else
        let (var_217: float) = (float var_12)
        (var_13 / var_217)
and method_40 ((var_0: EnvHeap4)): unit =
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
and method_30 ((var_0: EnvHeap3)): unit =
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
and method_13 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_22((var_0: EnvStack9), (var_1: EnvStack9), (var_2: int64), (var_3: EnvStack9), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_19((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 1, 128, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_28((var_0: int64), (var_1: EnvStack9), (var_2: int64)): (float32 []) =
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
and method_33((var_0: EnvStack9), (var_1: EnvStack9), (var_2: int64), (var_3: EnvStack9), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: EnvStack0), (var_7: uint64), (var_8: ResizeArray<Env1>), (var_9: ResizeArray<Env2>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<EnvHeap3>), (var_12: ResizeArray<EnvHeap4>), (var_13: ManagedCuda.BasicTypes.CUmodule), (var_14: EnvHeap4)): unit =
    let (var_15: ManagedCuda.CudaBlas.CudaBlasHandle) = var_4.get_CublasHandle()
    let (var_16: (int64 ref)) = var_14.mem_0
    let (var_17: EnvHeap5) = var_14.mem_1
    let (var_18: (bool ref)) = var_17.mem_0
    let (var_19: ManagedCuda.CudaStream) = var_17.mem_1
    let (var_20: ManagedCuda.BasicTypes.CUstream) = method_19((var_18: (bool ref)), (var_19: ManagedCuda.CudaStream))
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
    let (var_49: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_15, var_21, var_22, 128, 128, 1, var_23, var_30, 128, var_40, 128, var_41, var_48, 128)
    if var_49 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_49)
and method_14 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
let (var_75: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()
let (var_76: int64) = var_75.LongLength
let (var_77: bool) = (var_76 >= 0L)
let (var_78: bool) = (var_77 = false)
if var_78 then
    (failwith "The input to init needs to be greater or equal to 0.")
else
    ()
let (var_83: (uint8 [])) = Array.zeroCreate<uint8> (System.Convert.ToInt32(var_76))
let (var_84: int64) = 0L
method_9((var_83: (uint8 [])), (var_75: (char [])), (var_76: int64), (var_84: int64))
let (var_85: int64) = var_83.LongLength
let (var_86: bool) = (var_85 > 0L)
let (var_87: bool) = (var_86 = false)
if var_87 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_88: bool) = (var_85 = 1115394L)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "The dimensions must match.")
else
    ()
let (var_90: int64) = 1115394L
let (var_91: int64) = 0L
let (var_92: int64) = 1L
let (var_93: EnvStack7) = method_10((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_90: int64), (var_83: (uint8 [])), (var_91: int64), (var_92: int64))
let (var_94: EnvHeap3) = var_93.mem_0
let (var_95: (int64 ref)) = var_94.mem_0
let (var_96: EnvStack0) = var_94.mem_1
let (var_97: (uint64 ref)) = var_96.mem_0
let (var_98: uint64) = method_5((var_97: (uint64 ref)))
let (var_102: int64) = 16384L
let (var_103: EnvHeap8) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap8)
let (var_104: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_102: int64))
let (var_105: EnvStack9) = EnvStack9((var_104: EnvHeap3))
let (var_106: EnvHeap3) = var_105.mem_0
let (var_107: (int64 ref)) = var_106.mem_0
let (var_108: EnvStack0) = var_106.mem_1
let (var_109: (uint64 ref)) = var_108.mem_0
let (var_110: uint64) = method_5((var_109: (uint64 ref)))
// Cuda join point
// method_16((var_98: uint64), (var_110: uint64))
let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_111.set_GridDimensions(var_112)
let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_111.set_BlockDimensions(var_113)
let (var_114: (int64 ref)) = var_72.mem_0
let (var_115: EnvHeap5) = var_72.mem_1
let (var_116: (bool ref)) = var_115.mem_0
let (var_117: ManagedCuda.CudaStream) = var_115.mem_1
let (var_118: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_120: (System.Object [])) = [|var_98; var_110|]: (System.Object [])
var_111.RunAsync(var_118, var_120)
let (var_121: int64) = 65536L
let (var_122: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_121: int64))
let (var_123: EnvStack9) = EnvStack9((var_122: EnvHeap3))
let (var_124: EnvHeap3) = var_123.mem_0
let (var_125: (int64 ref)) = var_124.mem_0
let (var_126: EnvStack0) = var_124.mem_1
let (var_127: (uint64 ref)) = var_126.mem_0
let (var_128: uint64) = method_5((var_127: (uint64 ref)))
let (var_129: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_130: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_130)
let (var_131: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_128)
let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_131)
var_44.GenerateNormal32(var_132, var_129, 0.000000f, 0.088388f)
let (var_133: int64) = 65536L
let (var_134: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_133: int64))
let (var_135: EnvStack9) = EnvStack9((var_134: EnvHeap3))
let (var_136: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_137: EnvHeap3) = var_135.mem_0
let (var_138: (int64 ref)) = var_137.mem_0
let (var_139: EnvStack0) = var_137.mem_1
let (var_140: (uint64 ref)) = var_139.mem_0
let (var_141: uint64) = method_5((var_140: (uint64 ref)))
let (var_142: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_141)
let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_142)
let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_143, 0uy, var_144, var_136)
let (var_145: int64) = 65536L
let (var_146: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_145: int64))
let (var_147: EnvStack9) = EnvStack9((var_146: EnvHeap3))
let (var_148: EnvHeap3) = var_147.mem_0
let (var_149: (int64 ref)) = var_148.mem_0
let (var_150: EnvStack0) = var_148.mem_1
let (var_151: (uint64 ref)) = var_150.mem_0
let (var_152: uint64) = method_5((var_151: (uint64 ref)))
let (var_153: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(16384L)
let (var_154: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
var_44.SetStream(var_154)
let (var_155: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_152)
let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_155)
var_44.GenerateNormal32(var_156, var_153, 0.000000f, 0.088388f)
let (var_157: int64) = 65536L
let (var_158: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_157: int64))
let (var_159: EnvStack9) = EnvStack9((var_158: EnvHeap3))
let (var_160: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_161: EnvHeap3) = var_159.mem_0
let (var_162: (int64 ref)) = var_161.mem_0
let (var_163: EnvStack0) = var_161.mem_1
let (var_164: (uint64 ref)) = var_163.mem_0
let (var_165: uint64) = method_5((var_164: (uint64 ref)))
let (var_166: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_165)
let (var_167: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_166)
let (var_168: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(65536L)
var_1.ClearMemoryAsync(var_167, 0uy, var_168, var_160)
let (var_169: int64) = 512L
let (var_170: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_169: int64))
let (var_171: EnvStack9) = EnvStack9((var_170: EnvHeap3))
let (var_172: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_173: EnvHeap3) = var_171.mem_0
let (var_174: (int64 ref)) = var_173.mem_0
let (var_175: EnvStack0) = var_173.mem_1
let (var_176: (uint64 ref)) = var_175.mem_0
let (var_177: uint64) = method_5((var_176: (uint64 ref)))
let (var_178: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_177)
let (var_179: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_178)
let (var_180: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_179, 0uy, var_180, var_172)
let (var_181: int64) = 512L
let (var_182: EnvHeap3) = method_11((var_103: EnvHeap8), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_181: int64))
let (var_183: EnvStack9) = EnvStack9((var_182: EnvHeap3))
let (var_184: ManagedCuda.BasicTypes.CUstream) = method_19((var_116: (bool ref)), (var_117: ManagedCuda.CudaStream))
let (var_185: EnvHeap3) = var_183.mem_0
let (var_186: (int64 ref)) = var_185.mem_0
let (var_187: EnvStack0) = var_185.mem_1
let (var_188: (uint64 ref)) = var_187.mem_0
let (var_189: uint64) = method_5((var_188: (uint64 ref)))
let (var_190: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_189)
let (var_191: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_190)
let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(512L)
var_1.ClearMemoryAsync(var_191, 0uy, var_192, var_184)
let (var_193: int64) = 0L
method_20((var_73: EnvStack6), (var_183: EnvStack9), (var_171: EnvStack9), (var_135: EnvStack9), (var_123: EnvStack9), (var_159: EnvStack9), (var_147: EnvStack9), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_105: EnvStack9), (var_193: int64))
method_39((var_68: ResizeArray<EnvHeap4>))
method_29((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_194: (uint64 ref)) = var_40.mem_0
let (var_195: uint64) = method_5((var_194: (uint64 ref)))
let (var_196: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_195)
let (var_197: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_196)
var_1.FreeMemory(var_197)
var_194 := 0UL
var_1.Dispose()

