module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_15(float * var_0, float * var_1, float * var_2);
    __global__ void method_18(float * var_0, float * var_1);
    __global__ void method_20(float * var_0, float * var_1, float * var_2);
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_27(float * var_0, float * var_1);
    __device__ char method_16(long long int * var_0);
    __device__ char method_17(long long int * var_0);
    __device__ char method_19(long long int * var_0);
    __device__ char method_21(long long int * var_0, float * var_1);
    __device__ char method_28(long long int * var_0, float * var_1);
    __device__ char method_29(long long int * var_0, float * var_1);
    __device__ char method_30(long long int var_0, long long int * var_1, float * var_2);
    
    __global__ void method_15(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_16(var_7)) {
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
            while (method_17(var_18)) {
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
    __global__ void method_18(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (128 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_19(var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < 320);
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
                var_14 = (var_8 < 320);
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
            long long int var_22 = (var_8 + 384);
            var_6[0] = var_22;
        }
        long long int var_23 = var_6[0];
    }
    __global__ void method_20(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (256 * var_4);
        long long int var_6 = (var_3 + var_5);
        float var_7 = 0;
        long long int var_8[1];
        float var_9[1];
        var_8[0] = var_6;
        var_9[0] = var_7;
        while (method_21(var_8, var_9)) {
            long long int var_11 = var_8[0];
            float var_12 = var_9[0];
            char var_13 = (var_11 >= 0);
            char var_15;
            if (var_13) {
                var_15 = (var_11 < 320);
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
            long long int var_28 = (var_11 + 512);
            var_8[0] = var_28;
            var_9[0] = var_27;
        }
        long long int var_29 = var_8[0];
        float var_30 = var_9[0];
        float var_31 = cub::BlockReduce<float,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_30);
        long long int var_32 = threadIdx.x;
        char var_33 = (var_32 == 0);
        if (var_33) {
            long long int var_34 = blockIdx.x;
            char var_35 = (var_34 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_34 < 2);
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
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = blockIdx.x;
        long long int var_7 = (128 * var_6);
        long long int var_8 = (var_5 + var_7);
        long long int var_9[1];
        var_9[0] = var_8;
        while (method_19(var_9)) {
            long long int var_11 = var_9[0];
            char var_12 = (var_11 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_11 < 320);
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
                var_17 = (var_11 < 320);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            float var_19 = var_2[var_11];
            float var_20 = var_3[var_11];
            float var_21 = var_4[var_11];
            float var_22 = (var_19 - var_20);
            float var_23 = (1 - var_19);
            float var_24 = (var_19 * var_23);
            float var_25 = (var_22 / var_24);
            float var_26 = (var_0 * var_25);
            float var_27 = (var_21 + var_26);
            var_4[var_11] = var_27;
            long long int var_28 = (var_11 + 384);
            var_9[0] = var_28;
        }
        long long int var_29 = var_9[0];
    }
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (128 * var_5);
        long long int var_7 = (var_4 + var_6);
        long long int var_8[1];
        var_8[0] = var_7;
        while (method_19(var_8)) {
            long long int var_10 = var_8[0];
            char var_11 = (var_10 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_10 < 320);
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
                var_16 = (var_10 < 320);
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
            long long int var_26 = (var_10 + 384);
            var_8[0] = var_26;
        }
        long long int var_27 = var_8[0];
    }
    __global__ void method_27(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_16(var_6)) {
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
            while (method_28(var_21, var_22)) {
                long long int var_24 = var_21[0];
                float var_25 = var_22[0];
                char var_26 = (var_24 >= 0);
                char var_28;
                if (var_26) {
                    var_28 = (var_24 < 32);
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
            while (method_29(var_41, var_42)) {
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
                    while (method_30(var_44, var_69, var_70)) {
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
    __device__ char method_16(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_17(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 32);
    }
    __device__ char method_19(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 320);
    }
    __device__ char method_21(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 320);
    }
    __device__ char method_28(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 32);
    }
    __device__ char method_29(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_30(long long int var_0, long long int * var_1, float * var_2) {
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
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple2 =
    struct
    val mem_0: Tuple3
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple4 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack5 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2((var_0: string)): Tuple2 =
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
    Tuple2(Tuple3(var_16, var_17, var_18), var_22)
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
and method_5((var_0: string)): Tuple4 =
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
    Tuple4(var_12, var_14)
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
and method_10((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64)): EnvStack5 =
    let (var_8: int64) = (var_3 * var_6)
    let (var_9: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_4,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_10: int64) = var_9.AddrOfPinnedObject().ToInt64()
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: int64) = (var_5 * 4L)
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: uint64) = (var_13 + var_11)
    let (var_15: int64) = (var_8 * 4L)
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: uint64) = (var_16 % 256UL)
    let (var_18: uint64) = (var_16 - var_17)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: EnvStack0) = method_11((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_1: uint64), (var_19: uint64))
    let (var_21: EnvStack5) = EnvStack5((var_20: EnvStack0))
    let (var_22: EnvStack0) = var_21.mem_0
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: uint64) = method_1((var_23: (uint64 ref)))
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_27)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_30: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_26, var_28, var_29)
    if var_30 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_30)
    var_9.Free()
    var_21
and method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64)): EnvStack0 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env1) = var_1.Peek()
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = (!var_9)
        let (var_11: bool) = (var_10 = 0UL)
        if var_11 then
            let (var_12: Env1) = var_1.Pop()
            let (var_13: EnvStack0) = var_12.mem_0
            let (var_14: uint64) = var_12.mem_1
            method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64))
        else
            method_12((var_10: uint64), (var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_8: uint64))
    else
        method_13((var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>))
and method_14((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack5), (var_2: EnvStack5), (var_3: EnvStack5)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: EnvStack0) = var_1.mem_0
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_1((var_8: (uint64 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_9)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    let (var_12: EnvStack0) = var_2.mem_0
    let (var_13: (uint64 ref)) = var_12.mem_0
    let (var_14: uint64) = method_1((var_13: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: (float32 ref)) = (ref 0.000000f)
    let (var_18: EnvStack0) = var_3.mem_0
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_1((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10, 32, 784, var_6, var_11, 10, var_16, 784, var_17, var_22, 10)
    if var_23 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_23)
and method_22((var_0: int64), (var_1: EnvStack5), (var_2: int64), (var_3: int64)): (float32 []) =
    let (var_4: EnvStack0) = var_1.mem_0
    let (var_5: int64) = (var_0 * var_3)
    let (var_6: (uint64 ref)) = var_4.mem_0
    let (var_7: uint64) = method_1((var_6: (uint64 ref)))
    let (var_8: int64) = (var_2 * 4L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_5))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_5 * 4L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_23((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 2L)
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
        method_23((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_26((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack5), (var_2: EnvStack5), (var_3: EnvStack5)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: EnvStack0) = var_1.mem_0
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_1((var_8: (uint64 ref)))
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_9)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    let (var_12: EnvStack0) = var_2.mem_0
    let (var_13: (uint64 ref)) = var_12.mem_0
    let (var_14: uint64) = method_1((var_13: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: (float32 ref)) = (ref 1.000000f)
    let (var_18: EnvStack0) = var_3.mem_0
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_1((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10, 784, 32, var_6, var_11, 10, var_16, 784, var_17, var_22, 10)
    if var_23 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_23)
and method_31((var_0: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvStack5), (var_8: EnvStack5), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 784L)
    if var_14 then
        let (var_15: bool) = (var_13 >= 0L)
        let (var_16: bool) = (var_15 = false)
        if var_16 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_17: int64) = (var_13 * 10L)
        if var_16 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_18: int64) = 0L
        method_32((var_0: EnvStack5), (var_17: int64), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvStack5), (var_8: EnvStack5), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_18: int64))
        let (var_19: int64) = (var_13 + 1L)
        method_31((var_0: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvStack5), (var_8: EnvStack5), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_19: int64))
    else
        ()
and method_36((var_0: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvStack5), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack5), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 10L)
    if var_14 then
        let (var_15: bool) = (var_13 >= 0L)
        let (var_16: bool) = (var_15 = false)
        if var_16 then
            (failwith "Argument out of bounds.")
        else
            ()
        if var_16 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_17: int64) = 1L
        let (var_18: (float32 [])) = method_33((var_17: int64), (var_7: EnvStack5), (var_13: int64))
        let (var_19: float32) = var_18.[int32 0L]
        let (var_20: float32) = (var_19 + 0.001000f)
        method_34((var_7: EnvStack5), (var_13: int64), (var_20: float32))
        let (var_21: float32) = method_35((var_1: ManagedCuda.CudaContext), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_0: EnvStack5), (var_7: EnvStack5), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack5), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5))
        let (var_22: float32) = (var_19 - 0.001000f)
        method_34((var_7: EnvStack5), (var_13: int64), (var_22: float32))
        let (var_23: float32) = method_35((var_1: ManagedCuda.CudaContext), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_0: EnvStack5), (var_7: EnvStack5), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack5), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5))
        method_34((var_7: EnvStack5), (var_13: int64), (var_19: float32))
        let (var_24: float32) = (var_21 - var_23)
        let (var_25: float32) = (var_24 / 0.002000f)
        let (var_26: int64) = 1L
        let (var_27: (float32 [])) = method_33((var_26: int64), (var_0: EnvStack5), (var_13: int64))
        let (var_28: float32) = var_27.[int32 0L]
        let (var_29: float32) = (var_28 - var_25)
        let (var_30: float32) = (-var_29)
        let (var_31: bool) = (var_30 < var_29)
        let (var_32: float32) =
            if var_31 then
                var_29
            else
                var_30
        let (var_33: bool) = (var_32 >= 0.001000f)
        if var_33 then
            let (var_34: string) = System.String.Format("{0}",var_28)
            let (var_35: string) = System.String.Format("{0} = {1}","true_gradient",var_34)
            let (var_36: string) = System.String.Format("{0}",var_32)
            let (var_37: string) = System.String.Format("{0} = {1}","diff",var_36)
            let (var_38: string) = System.String.Format("{0}",var_25)
            let (var_39: string) = System.String.Format("{0} = {1}","approx_gradient",var_38)
            let (var_40: string) = String.concat "; " [|var_39; var_37; var_35|]
            let (var_41: string) = System.String.Format("{0}{1}{2}","{",var_40,"}")
            System.Console.WriteLine(var_41)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_42: int64) = (var_13 + 1L)
        method_36((var_0: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvStack5), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack5), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_42: int64))
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
and method_12((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_5: uint64)): EnvStack0 =
    let (var_6: uint64) = (var_0 + var_5)
    let (var_7: uint64) = (var_1 + var_2)
    let (var_8: uint64) = (var_7 - var_6)
    let (var_9: bool) = (var_3 <= var_8)
    let (var_10: bool) = (var_9 = false)
    if var_10 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_11: (uint64 ref)) = (ref var_6)
    let (var_12: EnvStack0) = EnvStack0((var_11: (uint64 ref)))
    var_4.Push((Env1(var_12, var_3)))
    var_12
and method_13((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env1>)): EnvStack0 =
    let (var_4: uint64) = (var_0 + var_1)
    let (var_5: uint64) = (var_4 - var_0)
    let (var_6: bool) = (var_2 <= var_5)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_8: (uint64 ref)) = (ref var_0)
    let (var_9: EnvStack0) = EnvStack0((var_8: (uint64 ref)))
    var_3.Push((Env1(var_9, var_2)))
    var_9
and method_32((var_0: EnvStack5), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env1>), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvStack5), (var_9: EnvStack5), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5), (var_14: int64)): unit =
    let (var_15: bool) = (var_14 < 10L)
    if var_15 then
        let (var_16: bool) = (var_14 >= 0L)
        let (var_17: bool) = (var_16 = false)
        if var_17 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_18: int64) = (var_1 + var_14)
        if var_17 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_19: int64) = 1L
        let (var_20: (float32 [])) = method_33((var_19: int64), (var_11: EnvStack5), (var_18: int64))
        let (var_21: float32) = var_20.[int32 0L]
        let (var_22: float32) = (var_21 + 0.001000f)
        method_34((var_11: EnvStack5), (var_18: int64), (var_22: float32))
        let (var_23: float32) = method_35((var_2: ManagedCuda.CudaContext), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack5), (var_9: EnvStack5), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_0: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5))
        let (var_24: float32) = (var_21 - 0.001000f)
        method_34((var_11: EnvStack5), (var_18: int64), (var_24: float32))
        let (var_25: float32) = method_35((var_2: ManagedCuda.CudaContext), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env1>), (var_8: EnvStack5), (var_9: EnvStack5), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_0: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5))
        method_34((var_11: EnvStack5), (var_18: int64), (var_21: float32))
        let (var_26: float32) = (var_23 - var_25)
        let (var_27: float32) = (var_26 / 0.002000f)
        let (var_28: int64) = 1L
        let (var_29: (float32 [])) = method_33((var_28: int64), (var_0: EnvStack5), (var_18: int64))
        let (var_30: float32) = var_29.[int32 0L]
        let (var_31: float32) = (var_30 - var_27)
        let (var_32: float32) = (-var_31)
        let (var_33: bool) = (var_32 < var_31)
        let (var_34: float32) =
            if var_33 then
                var_31
            else
                var_32
        let (var_35: bool) = (var_34 >= 0.001000f)
        if var_35 then
            let (var_36: string) = System.String.Format("{0}",var_30)
            let (var_37: string) = System.String.Format("{0} = {1}","true_gradient",var_36)
            let (var_38: string) = System.String.Format("{0}",var_34)
            let (var_39: string) = System.String.Format("{0} = {1}","diff",var_38)
            let (var_40: string) = System.String.Format("{0}",var_27)
            let (var_41: string) = System.String.Format("{0} = {1}","approx_gradient",var_40)
            let (var_42: string) = String.concat "; " [|var_41; var_39; var_37|]
            let (var_43: string) = System.String.Format("{0}{1}{2}","{",var_42,"}")
            System.Console.WriteLine(var_43)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_44: int64) = (var_14 + 1L)
        method_32((var_0: EnvStack5), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env1>), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvStack5), (var_9: EnvStack5), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack5), (var_12: EnvStack5), (var_13: EnvStack5), (var_44: int64))
    else
        ()
and method_33((var_0: int64), (var_1: EnvStack5), (var_2: int64)): (float32 []) =
    let (var_3: EnvStack0) = var_1.mem_0
    let (var_4: (uint64 ref)) = var_3.mem_0
    let (var_5: uint64) = method_1((var_4: (uint64 ref)))
    let (var_6: int64) = (var_2 * 4L)
    let (var_7: uint64) = (uint64 var_6)
    let (var_8: uint64) = (var_5 + var_7)
    let (var_9: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_0))
    let (var_10: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_9,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_11: int64) = var_10.AddrOfPinnedObject().ToInt64()
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: int64) = (var_0 * 4L)
    let (var_14: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_14)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_8)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_19: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_15, var_17, var_18)
    if var_19 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_19)
    var_10.Free()
    var_9
and method_34((var_0: EnvStack5), (var_1: int64), (var_2: float32)): unit =
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
    var_3.[int32 0L] <- var_2
    let (var_4: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_3,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_5: int64) = var_4.AddrOfPinnedObject().ToInt64()
    let (var_6: uint64) = (uint64 var_5)
    let (var_7: EnvStack0) = var_0.mem_0
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_1((var_8: (uint64 ref)))
    let (var_10: int64) = (var_1 * 4L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_14: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_13)
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_6)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
    let (var_18: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_14, var_16, var_17)
    if var_18 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_18)
    var_4.Free()
and method_35((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_6: EnvStack5), (var_7: EnvStack5), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack5), (var_10: EnvStack5), (var_11: EnvStack5), (var_12: EnvStack5)): float32 =
    let (var_13: EnvStack0) = var_11.mem_0
    let (var_14: uint64) = 1536UL
    let (var_15: EnvStack0) = method_11((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_4: uint64), (var_14: uint64))
    let (var_16: EnvStack5) = EnvStack5((var_15: EnvStack0))
    method_14((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack5), (var_11: EnvStack5), (var_16: EnvStack5))
    let (var_17: EnvStack0) = var_16.mem_0
    let (var_18: uint64) = 1536UL
    let (var_19: EnvStack0) = method_11((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_4: uint64), (var_18: uint64))
    let (var_20: EnvStack5) = EnvStack5((var_19: EnvStack0))
    let (var_21: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_22: EnvStack0) = var_20.mem_0
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: uint64) = method_1((var_23: (uint64 ref)))
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_24)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
    var_0.ClearMemoryAsync(var_26, 0uy, var_27, var_21)
    let (var_28: EnvStack0) = var_7.mem_0
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_1((var_29: (uint64 ref)))
    let (var_31: (uint64 ref)) = var_17.mem_0
    let (var_32: uint64) = method_1((var_31: (uint64 ref)))
    let (var_33: uint64) = method_1((var_31: (uint64 ref)))
    // Cuda join point
    // method_15((var_30: uint64), (var_32: uint64), (var_33: uint64))
    let (var_34: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_15", var_1, var_0)
    let (var_35: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_34.set_GridDimensions(var_35)
    let (var_36: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_34.set_BlockDimensions(var_36)
    let (var_37: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_39: (System.Object [])) = [|var_30; var_32; var_33|]: (System.Object [])
    var_34.RunAsync(var_37, var_39)
    let (var_44: uint64) = 1536UL
    let (var_45: EnvStack0) = method_11((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_4: uint64), (var_44: uint64))
    let (var_46: EnvStack5) = EnvStack5((var_45: EnvStack0))
    let (var_47: uint64) = method_1((var_31: (uint64 ref)))
    let (var_48: EnvStack0) = var_46.mem_0
    let (var_49: (uint64 ref)) = var_48.mem_0
    let (var_50: uint64) = method_1((var_49: (uint64 ref)))
    // Cuda join point
    // method_18((var_47: uint64), (var_50: uint64))
    let (var_51: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_18", var_1, var_0)
    let (var_52: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
    var_51.set_GridDimensions(var_52)
    let (var_53: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_51.set_BlockDimensions(var_53)
    let (var_54: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_56: (System.Object [])) = [|var_47; var_50|]: (System.Object [])
    var_51.RunAsync(var_54, var_56)
    let (var_57: uint64) = 1536UL
    let (var_58: EnvStack0) = method_11((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_4: uint64), (var_57: uint64))
    let (var_59: EnvStack5) = EnvStack5((var_58: EnvStack0))
    let (var_60: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_61: EnvStack0) = var_59.mem_0
    let (var_62: (uint64 ref)) = var_61.mem_0
    let (var_63: uint64) = method_1((var_62: (uint64 ref)))
    let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_63)
    let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_64)
    let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
    var_0.ClearMemoryAsync(var_65, 0uy, var_66, var_60)
    let (var_67: uint64) = method_1((var_49: (uint64 ref)))
    let (var_68: EnvStack0) = var_12.mem_0
    let (var_69: (uint64 ref)) = var_68.mem_0
    let (var_70: uint64) = method_1((var_69: (uint64 ref)))
    let (var_78: uint64) = 256UL
    let (var_79: EnvStack0) = method_11((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env1>), (var_4: uint64), (var_78: uint64))
    let (var_80: EnvStack5) = EnvStack5((var_79: EnvStack0))
    let (var_81: EnvStack0) = var_80.mem_0
    let (var_82: (uint64 ref)) = var_81.mem_0
    let (var_83: uint64) = method_1((var_82: (uint64 ref)))
    // Cuda join point
    // method_20((var_67: uint64), (var_70: uint64), (var_83: uint64))
    let (var_84: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
    let (var_85: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
    var_84.set_GridDimensions(var_85)
    let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
    var_84.set_BlockDimensions(var_86)
    let (var_87: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_89: (System.Object [])) = [|var_67; var_70; var_83|]: (System.Object [])
    var_84.RunAsync(var_87, var_89)
    let (var_90: int64) = 2L
    let (var_91: int64) = 0L
    let (var_92: int64) = 1L
    let (var_93: (float32 [])) = method_22((var_90: int64), (var_80: EnvStack5), (var_91: int64), (var_92: int64))
    let (var_94: float32) = var_93.[int32 0L]
    let (var_95: int64) = 1L
    let (var_96: float32) = method_23((var_93: (float32 [])), (var_94: float32), (var_95: int64))
    var_82 := 0UL
    let (var_97: (float32 ref)) = (ref 0.000000f)
    let (var_98: float32) = (var_96 / 32.000000f)
    let (var_99: (float32 ref)) = (ref 0.000000f)
    var_62 := 0UL
    var_49 := 0UL
    var_23 := 0UL
    var_31 := 0UL
    var_98
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
let (var_35: ManagedCuda.BasicTypes.SizeT) = var_1.GetFreeDeviceMemorySize()
let (var_36: int64) = int64 var_35
let (var_37: float) = float var_36
let (var_38: float) = (0.700000 * var_37)
let (var_39: uint64) = uint64 var_38
let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_40)
let (var_42: uint64) = uint64 var_41
let (var_43: (uint64 ref)) = (ref var_42)
let (var_44: EnvStack0) = EnvStack0((var_43: (uint64 ref)))
let (var_45: System.Collections.Generic.Stack<Env1>) = System.Collections.Generic.Stack<Env1>()
let (var_46: (uint64 ref)) = var_44.mem_0
let (var_47: uint64) = method_1((var_46: (uint64 ref)))
let (var_48: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_49: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_50: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_49)
let (var_51: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
var_50.SetStream(var_51)
let (var_52: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_53: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_54: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_52, var_53)
let (var_55: ManagedCuda.CudaBlas.CudaBlasHandle) = var_54.get_CublasHandle()
let (var_56: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
var_54.set_Stream(var_56)
let (var_57: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_58: Tuple2) = method_2((var_57: string))
let (var_59: Tuple3) = var_58.mem_0
let (var_60: (uint8 [])) = var_58.mem_1
let (var_61: int64) = var_59.mem_0
let (var_62: int64) = var_59.mem_1
let (var_63: int64) = var_59.mem_2
let (var_64: bool) = (10000L = var_61)
let (var_68: bool) =
    if var_64 then
        let (var_65: bool) = (28L = var_62)
        if var_65 then
            (28L = var_63)
        else
            false
    else
        false
let (var_69: bool) = (var_68 = false)
if var_69 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_70: int64) = var_60.LongLength
let (var_71: bool) = (var_70 > 0L)
let (var_72: bool) = (var_71 = false)
if var_72 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_76: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_77: int64) = 0L
method_3((var_60: (uint8 [])), (var_76: (float32 [])), (var_77: int64))
let (var_78: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_79: Tuple4) = method_5((var_78: string))
let (var_80: int64) = var_79.mem_0
let (var_81: (uint8 [])) = var_79.mem_1
let (var_82: bool) = (10000L = var_80)
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_87: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_88: int64) = 0L
method_6((var_81: (uint8 [])), (var_87: (float32 [])), (var_88: int64))
let (var_89: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_90: Tuple2) = method_2((var_89: string))
let (var_91: Tuple3) = var_90.mem_0
let (var_92: (uint8 [])) = var_90.mem_1
let (var_93: int64) = var_91.mem_0
let (var_94: int64) = var_91.mem_1
let (var_95: int64) = var_91.mem_2
let (var_96: bool) = (60000L = var_93)
let (var_100: bool) =
    if var_96 then
        let (var_97: bool) = (28L = var_94)
        if var_97 then
            (28L = var_95)
        else
            false
    else
        false
let (var_101: bool) = (var_100 = false)
if var_101 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_102: int64) = var_92.LongLength
let (var_103: bool) = (var_102 > 0L)
let (var_104: bool) = (var_103 = false)
if var_104 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_108: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_109: int64) = 0L
method_8((var_92: (uint8 [])), (var_108: (float32 [])), (var_109: int64))
let (var_110: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_111: Tuple4) = method_5((var_110: string))
let (var_112: int64) = var_111.mem_0
let (var_113: (uint8 [])) = var_111.mem_1
let (var_114: bool) = (60000L = var_112)
let (var_115: bool) = (var_114 = false)
if var_115 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_119: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_120: int64) = 0L
method_9((var_113: (uint8 [])), (var_119: (float32 [])), (var_120: int64))
let (var_121: int64) = 10000L
let (var_122: int64) = 0L
let (var_123: int64) = 784L
let (var_124: int64) = 1L
let (var_125: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_121: int64), (var_76: (float32 [])), (var_122: int64), (var_123: int64), (var_124: int64))
let (var_126: int64) = 10000L
let (var_127: int64) = 0L
let (var_128: int64) = 10L
let (var_129: int64) = 1L
let (var_130: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_126: int64), (var_87: (float32 [])), (var_127: int64), (var_128: int64), (var_129: int64))
let (var_131: int64) = 60000L
let (var_132: int64) = 0L
let (var_133: int64) = 784L
let (var_134: int64) = 1L
let (var_135: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_131: int64), (var_108: (float32 [])), (var_132: int64), (var_133: int64), (var_134: int64))
let (var_136: int64) = 60000L
let (var_137: int64) = 0L
let (var_138: int64) = 10L
let (var_139: int64) = 1L
let (var_140: EnvStack5) = method_10((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_136: int64), (var_119: (float32 [])), (var_137: int64), (var_138: int64), (var_139: int64))
let (var_141: uint64) = 31488UL
let (var_142: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_141: uint64))
let (var_143: EnvStack5) = EnvStack5((var_142: EnvStack0))
let (var_144: EnvStack0) = var_143.mem_0
let (var_145: (uint64 ref)) = var_144.mem_0
let (var_146: uint64) = method_1((var_145: (uint64 ref)))
let (var_147: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
let (var_148: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_146)
let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_148)
var_50.GenerateNormal32(var_149, var_147, 0.000000f, 0.050189f)
let (var_150: uint64) = 31488UL
let (var_151: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_150: uint64))
let (var_152: EnvStack5) = EnvStack5((var_151: EnvStack0))
let (var_153: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_154: EnvStack0) = var_152.mem_0
let (var_155: (uint64 ref)) = var_154.mem_0
let (var_156: uint64) = method_1((var_155: (uint64 ref)))
let (var_157: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_156)
let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_157)
let (var_159: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_158, 0uy, var_159, var_153)
let (var_160: uint64) = 256UL
let (var_161: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_160: uint64))
let (var_162: EnvStack5) = EnvStack5((var_161: EnvStack0))
let (var_163: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_164: EnvStack0) = var_162.mem_0
let (var_165: (uint64 ref)) = var_164.mem_0
let (var_166: uint64) = method_1((var_165: (uint64 ref)))
let (var_167: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_166)
let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_167)
let (var_169: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_168, 0uy, var_169, var_163)
let (var_170: uint64) = 256UL
let (var_171: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_170: uint64))
let (var_172: EnvStack5) = EnvStack5((var_171: EnvStack0))
let (var_173: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_174: EnvStack0) = var_172.mem_0
let (var_175: (uint64 ref)) = var_174.mem_0
let (var_176: uint64) = method_1((var_175: (uint64 ref)))
let (var_177: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_176)
let (var_178: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_177)
let (var_179: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_178, 0uy, var_179, var_173)
let (var_180: EnvStack0) = var_135.mem_0
let (var_181: uint64) = 1536UL
let (var_182: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_181: uint64))
let (var_183: EnvStack5) = EnvStack5((var_182: EnvStack0))
method_14((var_55: ManagedCuda.CudaBlas.CudaBlasHandle), (var_143: EnvStack5), (var_135: EnvStack5), (var_183: EnvStack5))
let (var_184: EnvStack0) = var_183.mem_0
let (var_185: uint64) = 1536UL
let (var_186: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_185: uint64))
let (var_187: EnvStack5) = EnvStack5((var_186: EnvStack0))
let (var_188: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_189: EnvStack0) = var_187.mem_0
let (var_190: (uint64 ref)) = var_189.mem_0
let (var_191: uint64) = method_1((var_190: (uint64 ref)))
let (var_192: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_191)
let (var_193: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_192)
let (var_194: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
var_1.ClearMemoryAsync(var_193, 0uy, var_194, var_188)
let (var_195: uint64) = method_1((var_165: (uint64 ref)))
let (var_196: (uint64 ref)) = var_184.mem_0
let (var_197: uint64) = method_1((var_196: (uint64 ref)))
let (var_198: uint64) = method_1((var_196: (uint64 ref)))
// Cuda join point
// method_15((var_195: uint64), (var_197: uint64), (var_198: uint64))
let (var_199: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_15", var_32, var_1)
let (var_200: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_199.set_GridDimensions(var_200)
let (var_201: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
var_199.set_BlockDimensions(var_201)
let (var_202: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_204: (System.Object [])) = [|var_195; var_197; var_198|]: (System.Object [])
var_199.RunAsync(var_202, var_204)
let (var_209: uint64) = 1536UL
let (var_210: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_209: uint64))
let (var_211: EnvStack5) = EnvStack5((var_210: EnvStack0))
let (var_212: uint64) = method_1((var_196: (uint64 ref)))
let (var_213: EnvStack0) = var_211.mem_0
let (var_214: (uint64 ref)) = var_213.mem_0
let (var_215: uint64) = method_1((var_214: (uint64 ref)))
// Cuda join point
// method_18((var_212: uint64), (var_215: uint64))
let (var_216: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_18", var_32, var_1)
let (var_217: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
var_216.set_GridDimensions(var_217)
let (var_218: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_216.set_BlockDimensions(var_218)
let (var_219: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_221: (System.Object [])) = [|var_212; var_215|]: (System.Object [])
var_216.RunAsync(var_219, var_221)
let (var_222: uint64) = 1536UL
let (var_223: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_222: uint64))
let (var_224: EnvStack5) = EnvStack5((var_223: EnvStack0))
let (var_225: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_226: EnvStack0) = var_224.mem_0
let (var_227: (uint64 ref)) = var_226.mem_0
let (var_228: uint64) = method_1((var_227: (uint64 ref)))
let (var_229: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_228)
let (var_230: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_229)
let (var_231: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
var_1.ClearMemoryAsync(var_230, 0uy, var_231, var_225)
let (var_232: uint64) = method_1((var_214: (uint64 ref)))
let (var_233: EnvStack0) = var_140.mem_0
let (var_234: (uint64 ref)) = var_233.mem_0
let (var_235: uint64) = method_1((var_234: (uint64 ref)))
let (var_243: uint64) = 256UL
let (var_244: EnvStack0) = method_11((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_243: uint64))
let (var_245: EnvStack5) = EnvStack5((var_244: EnvStack0))
let (var_246: EnvStack0) = var_245.mem_0
let (var_247: (uint64 ref)) = var_246.mem_0
let (var_248: uint64) = method_1((var_247: (uint64 ref)))
// Cuda join point
// method_20((var_232: uint64), (var_235: uint64), (var_248: uint64))
let (var_249: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_32, var_1)
let (var_250: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_249.set_GridDimensions(var_250)
let (var_251: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_249.set_BlockDimensions(var_251)
let (var_252: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_254: (System.Object [])) = [|var_232; var_235; var_248|]: (System.Object [])
var_249.RunAsync(var_252, var_254)
let (var_255: int64) = 2L
let (var_256: int64) = 0L
let (var_257: int64) = 1L
let (var_258: (float32 [])) = method_22((var_255: int64), (var_245: EnvStack5), (var_256: int64), (var_257: int64))
let (var_259: float32) = var_258.[int32 0L]
let (var_260: int64) = 1L
let (var_261: float32) = method_23((var_258: (float32 [])), (var_259: float32), (var_260: int64))
var_247 := 0UL
let (var_262: (float32 ref)) = (ref 0.000000f)
let (var_263: float32) = (var_261 / 32.000000f)
let (var_264: (float32 ref)) = (ref 0.000000f)
var_264 := 1.000000f
let (var_265: float32) = (!var_264)
let (var_266: float32) = (var_265 / 32.000000f)
let (var_267: float32) = (!var_262)
let (var_268: float32) = (var_267 + var_266)
var_262 := var_268
let (var_269: float32) = (!var_262)
let (var_270: uint64) = method_1((var_214: (uint64 ref)))
let (var_271: uint64) = method_1((var_234: (uint64 ref)))
let (var_272: uint64) = method_1((var_227: (uint64 ref)))
// Cuda join point
// method_24((var_269: float32), (var_261: float32), (var_270: uint64), (var_271: uint64), (var_272: uint64))
let (var_273: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_32, var_1)
let (var_274: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
var_273.set_GridDimensions(var_274)
let (var_275: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_273.set_BlockDimensions(var_275)
let (var_276: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_278: (System.Object [])) = [|var_269; var_261; var_270; var_271; var_272|]: (System.Object [])
var_273.RunAsync(var_276, var_278)
let (var_279: uint64) = method_1((var_196: (uint64 ref)))
let (var_280: uint64) = method_1((var_227: (uint64 ref)))
let (var_281: uint64) = method_1((var_214: (uint64 ref)))
let (var_282: uint64) = method_1((var_190: (uint64 ref)))
// Cuda join point
// method_25((var_279: uint64), (var_280: uint64), (var_281: uint64), (var_282: uint64))
let (var_283: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_284: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
var_283.set_GridDimensions(var_284)
let (var_285: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_283.set_BlockDimensions(var_285)
let (var_286: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_288: (System.Object [])) = [|var_279; var_280; var_281; var_282|]: (System.Object [])
var_283.RunAsync(var_286, var_288)
method_26((var_55: ManagedCuda.CudaBlas.CudaBlasHandle), (var_187: EnvStack5), (var_135: EnvStack5), (var_152: EnvStack5))
let (var_289: uint64) = method_1((var_190: (uint64 ref)))
let (var_290: uint64) = method_1((var_175: (uint64 ref)))
// Cuda join point
// method_27((var_289: uint64), (var_290: uint64))
let (var_291: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_27", var_32, var_1)
let (var_292: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_291.set_GridDimensions(var_292)
let (var_293: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
var_291.set_BlockDimensions(var_293)
let (var_294: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_296: (System.Object [])) = [|var_289; var_290|]: (System.Object [])
var_291.RunAsync(var_294, var_296)
var_227 := 0UL
var_214 := 0UL
var_190 := 0UL
var_196 := 0UL
let (var_297: int64) = 0L
method_31((var_152: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_48: ManagedCuda.CudaStream), (var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_172: EnvStack5), (var_162: EnvStack5), (var_55: ManagedCuda.CudaBlas.CudaBlasHandle), (var_143: EnvStack5), (var_135: EnvStack5), (var_140: EnvStack5), (var_297: int64))
let (var_298: int64) = 0L
method_36((var_172: EnvStack5), (var_1: ManagedCuda.CudaContext), (var_48: ManagedCuda.CudaStream), (var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_162: EnvStack5), (var_55: ManagedCuda.CudaBlas.CudaBlasHandle), (var_152: EnvStack5), (var_143: EnvStack5), (var_135: EnvStack5), (var_140: EnvStack5), (var_298: int64))
var_175 := 0UL
var_165 := 0UL
var_155 := 0UL
var_145 := 0UL
var_54.Dispose()
var_50.Dispose()
var_48.Dispose()
let (var_299: uint64) = method_1((var_46: (uint64 ref)))
let (var_300: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_299)
let (var_301: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_300)
var_1.FreeMemory(var_301)
var_46 := 0UL
var_1.Dispose()

