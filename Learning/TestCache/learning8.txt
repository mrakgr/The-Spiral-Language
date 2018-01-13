module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_17(float * var_0, float * var_1, float * var_2);
    __global__ void method_20(float * var_0, float * var_1);
    __global__ void method_22(float * var_0, float * var_1, float * var_2);
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_35(float * var_0, float * var_1);
    __global__ void method_39(float * var_0, float * var_1);
    __global__ void method_41(float * var_0, float * var_1);
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    __device__ void method_21(float * var_0, float * var_1, long long int var_2);
    __device__ float method_23(float * var_0, float * var_1, float var_2, long long int var_3);
    __device__ float method_24(float var_0, float var_1);
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5);
    __device__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4);
    __device__ void method_36(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8);
    __device__ void method_40(float * var_0, float * var_1, long long int var_2);
    __device__ void method_42(float * var_0, float * var_1, long long int var_2);
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4);
    __device__ float method_37(long long int var_0, float * var_1, float var_2, long long int var_3);
    __device__ void method_38(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5);
    
    __global__ void method_17(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (10 * var_6);
        long long int var_10 = (var_3 + var_9);
        method_18(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_10);
    }
    __global__ void method_20(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_21(var_0, var_1, var_9);
    }
    __global__ void method_22(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        float var_12 = method_23(var_0, var_1, var_11, var_10);
        FunPointer0 var_15 = method_24;
        float var_16 = cub::BlockReduce<float,128>().Reduce(var_12, var_15);
        char var_17 = (var_3 == 0);
        if (var_17) {
            char var_18 = (var_6 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_6 < 3);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // unprinted assert;
            } else {
            }
            var_2[var_6] = var_16;
        } else {
        }
    }
    __global__ void method_30(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_31(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __global__ void method_32(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 * 128);
        long long int var_11 = (var_10 + var_4);
        method_33(var_0, var_1, var_2, var_3, var_11);
    }
    __global__ void method_35(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (10 * var_5);
        long long int var_9 = (var_2 + var_8);
        method_36(var_5, var_6, var_7, var_0, var_1, var_2, var_3, var_4, var_9);
    }
    __global__ void method_39(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_40(var_0, var_1, var_9);
    }
    __global__ void method_41(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_42(var_0, var_1, var_9);
    }
    __device__ void method_18(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, float * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 10);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            long long int var_13 = (8 * var_1);
            long long int var_14 = (var_7 + var_13);
            method_19(var_3, var_9, var_4, var_5, var_14);
            long long int var_15 = (var_9 + 10);
            method_18(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_15);
        } else {
        }
    }
    __device__ void method_21(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 320);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (-var_6);
            float var_9 = exp(var_8);
            float var_10 = (1 + var_9);
            float var_11 = (1 / var_10);
            var_1[var_2] = var_11;
            long long int var_12 = (var_2 + 384);
            method_21(var_0, var_1, var_12);
        } else {
        }
    }
    __device__ float method_23(float * var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 320);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float var_7 = var_0[var_3];
            float var_8 = var_1[var_3];
            float var_9 = (var_8 - var_7);
            float var_10 = (var_9 * var_9);
            float var_11 = (var_2 + var_10);
            long long int var_12 = (var_3 + 384);
            return method_23(var_0, var_1, var_11, var_12);
        } else {
            return var_2;
        }
    }
    __device__ float method_24(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_31(float var_0, float var_1, float * var_2, float * var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < 320);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float var_9 = var_2[var_5];
            float var_10 = var_3[var_5];
            float var_11 = var_4[var_5];
            float var_12 = (var_9 - var_10);
            float var_13 = (2 * var_12);
            float var_14 = (var_0 * var_13);
            float var_15 = (var_11 + var_14);
            var_4[var_5] = var_15;
            long long int var_16 = (var_5 + 384);
            method_31(var_0, var_1, var_2, var_3, var_4, var_16);
        } else {
        }
    }
    __device__ void method_33(float * var_0, float * var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 320);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                // unprinted assert;
            } else {
            }
            if (var_7) {
                // unprinted assert;
            } else {
            }
            float var_8 = var_0[var_4];
            float var_9 = var_1[var_4];
            float var_10 = var_2[var_4];
            float var_11 = var_3[var_4];
            float var_12 = (1 - var_10);
            float var_13 = (var_10 * var_12);
            float var_14 = (var_9 * var_13);
            float var_15 = (var_11 + var_14);
            var_3[var_4] = var_15;
            long long int var_16 = (var_4 + 384);
            method_33(var_0, var_1, var_2, var_3, var_16);
        } else {
        }
    }
    __device__ void method_36(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int var_5, long long int var_6, long long int var_7, long long int var_8) {
        char var_9 = (var_8 < 10);
        if (var_9) {
            char var_10 = (var_8 >= 0);
            char var_11 = (var_10 == 0);
            if (var_11) {
                // unprinted assert;
            } else {
            }
            if (var_11) {
                // unprinted assert;
            } else {
            }
            long long int var_12 = (8 * var_1);
            long long int var_13 = (var_6 + var_12);
            float var_14 = 0;
            float var_15 = method_37(var_8, var_3, var_14, var_13);
            __shared__ float var_16[70];
            char var_17 = (var_5 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_5 < 10);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // unprinted assert;
            } else {
            }
            long long int var_21 = (var_5 * 7);
            char var_22 = (var_6 != 0);
            if (var_22) {
                char var_23 = (var_6 >= 1);
                char var_25;
                if (var_23) {
                    var_25 = (var_6 < 8);
                } else {
                    var_25 = 0;
                }
                char var_26 = (var_25 == 0);
                if (var_26) {
                    // unprinted assert;
                } else {
                }
                long long int var_27 = (var_6 - 1);
                long long int var_28 = (var_21 + var_27);
                var_16[var_28] = var_15;
            } else {
            }
            __syncthreads();
            char var_29 = (var_6 == 0);
            if (var_29) {
                long long int var_30 = 1;
                method_38(var_16, var_21, var_4, var_8, var_15, var_30);
            } else {
            }
            long long int var_31 = (var_8 + 10);
            method_36(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_31);
        } else {
        }
    }
    __device__ void method_40(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 7840);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 7936);
            method_40(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_42(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 10);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float var_6 = var_0[var_2];
            float var_7 = var_1[var_2];
            float var_8 = (0.01 * var_6);
            float var_9 = (var_7 - var_8);
            var_1[var_2] = var_9;
            long long int var_10 = (var_2 + 128);
            method_42(var_0, var_1, var_10);
        } else {
        }
    }
    __device__ void method_19(float * var_0, long long int var_1, float * var_2, float * var_3, long long int var_4) {
        char var_5 = (var_4 < 32);
        if (var_5) {
            char var_6 = (var_4 >= 0);
            char var_7 = (var_6 == 0);
            if (var_7) {
                // unprinted assert;
            } else {
            }
            long long int var_8 = (var_4 * 10);
            char var_9 = (var_1 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_1 < 10);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            long long int var_13 = (var_8 + var_1);
            if (var_7) {
                // unprinted assert;
            } else {
            }
            char var_15;
            if (var_9) {
                var_15 = (var_1 < 10);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // unprinted assert;
            } else {
            }
            float var_17 = var_0[var_1];
            float var_18 = var_2[var_13];
            float var_19 = var_3[var_13];
            float var_20 = (var_17 + var_18);
            var_3[var_13] = var_20;
            long long int var_21 = (var_4 + 8);
            method_19(var_0, var_1, var_2, var_3, var_21);
        } else {
        }
    }
    __device__ float method_37(long long int var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 32);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            long long int var_7 = (var_3 * 10);
            char var_8 = (var_0 >= 0);
            char var_10;
            if (var_8) {
                var_10 = (var_0 < 10);
            } else {
                var_10 = 0;
            }
            char var_11 = (var_10 == 0);
            if (var_11) {
                // unprinted assert;
            } else {
            }
            long long int var_12 = (var_7 + var_0);
            float var_13 = var_1[var_12];
            float var_14 = (var_2 + var_13);
            long long int var_15 = (var_3 + 8);
            return method_37(var_0, var_1, var_14, var_15);
        } else {
            return var_2;
        }
    }
    __device__ void method_38(float * var_0, long long int var_1, float * var_2, long long int var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 8);
        if (var_6) {
            char var_7 = (var_5 >= 1);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            long long int var_9 = (var_5 - 1);
            long long int var_10 = (var_1 + var_9);
            float var_11 = var_0[var_10];
            float var_12 = (var_4 + var_11);
            long long int var_13 = (var_5 + 1);
            method_38(var_0, var_1, var_2, var_3, var_12, var_13);
        } else {
            float var_14 = var_2[var_3];
            float var_15 = (var_4 + var_14);
            var_2[var_3] = var_15;
        }
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
and Env2 =
    struct
    val mem_0: Env6
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: Tuple4
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple4 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple5 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env6 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union7 =
    | Union7Case0 of Tuple8
    | Union7Case1
and Tuple8 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
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
and method_2((var_0: string)): Tuple3 =
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
    Tuple3(Tuple4(var_16, var_17, var_18), var_22)
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
and method_5((var_0: string)): Tuple5 =
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
    Tuple5(var_12, var_14)
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
and method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env6 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env6) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_11((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env6), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env6) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_12((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_13((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: int64)): unit =
    let (var_14: bool) = (var_13 < 10L)
    if var_14 then
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: float) = method_15((var_0: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_15: float), (var_16: int64))
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_18: float) = (var_17 / 60000.000000)
        let (var_19: string) = System.String.Format("Average of batch costs is {0}.",var_18)
        let (var_20: string) = System.String.Format("{0}",var_19)
        System.Console.WriteLine(var_20)
        System.Console.WriteLine("-----")
        let (var_21: int64) = (var_13 + 1L)
        method_14((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_21: int64))
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
and method_11((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env6), (var_6: int64)): Env6 =
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
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_18))))
    var_4.Push((Env2((Env6(var_19)), var_3)))
    (Env6(var_19))
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env6 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    var_3.Push((Env2((Env6(var_9)), var_2)))
    (Env6(var_9))
and method_15((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_13: float), (var_14: int64)): float =
    let (var_15: bool) = (var_14 < 60000L)
    if var_15 then
        let (var_16: int64) = (var_14 + 32L)
        let (var_17: bool) = (var_14 >= 0L)
        let (var_18: bool) = (var_17 = false)
        if var_18 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_19: bool) = (var_16 > 0L)
        let (var_21: bool) =
            if var_19 then
                (var_16 <= 60000L)
            else
                false
        let (var_22: bool) = (var_21 = false)
        if var_22 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_23: int64) = (var_14 * 784L)
        if var_18 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_25: bool) =
            if var_19 then
                (var_16 <= 60000L)
            else
                false
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_27: int64) = (var_14 * 10L)
        let (var_28: int64) = 1280L
        let (var_29: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_28: int64))
        let (var_30: (Union0 ref)) = var_29.mem_0
        method_16((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_23: int64), (var_10: (Union0 ref)), (var_30: (Union0 ref)))
        let (var_31: int64) = 1280L
        let (var_32: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_31: int64))
        let (var_33: (Union0 ref)) = var_32.mem_0
        let (var_34: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        let (var_35: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
        var_0.ClearMemoryAsync(var_34, 0uy, var_36, var_35)
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_30: (Union0 ref)))
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_30: (Union0 ref)))
        // Cuda join point
        // method_17((var_37: ManagedCuda.BasicTypes.CUdeviceptr), (var_38: ManagedCuda.BasicTypes.CUdeviceptr), (var_39: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_41: (System.Object [])) = [|var_37; var_38; var_39|]: (System.Object [])
        let (var_42: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
        let (var_43: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_42.set_GridDimensions(var_43)
        let (var_44: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_42.set_BlockDimensions(var_44)
        let (var_45: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_42.RunAsync(var_45, var_41)
        let (var_50: int64) = 1280L
        let (var_51: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_50: int64))
        let (var_52: (Union0 ref)) = var_51.mem_0
        let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_30: (Union0 ref)))
        let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_52: (Union0 ref)))
        // Cuda join point
        // method_20((var_53: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_56: (System.Object [])) = [|var_53; var_54|]: (System.Object [])
        let (var_57: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
        let (var_58: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
        var_57.set_GridDimensions(var_58)
        let (var_59: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_57.set_BlockDimensions(var_59)
        let (var_60: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_57.RunAsync(var_60, var_56)
        let (var_61: int64) = 1280L
        let (var_62: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_61: int64))
        let (var_63: (Union0 ref)) = var_62.mem_0
        let (var_64: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        let (var_65: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_66: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
        var_0.ClearMemoryAsync(var_64, 0uy, var_66, var_65)
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_52: (Union0 ref)))
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_71: int64) = 12L
        let (var_72: Env6) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_4: uint64), (var_71: int64))
        let (var_73: (Union0 ref)) = var_72.mem_0
        let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_73: (Union0 ref)))
        // Cuda join point
        // method_22((var_67: ManagedCuda.BasicTypes.CUdeviceptr), (var_68: ManagedCuda.BasicTypes.CUdeviceptr), (var_74: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_76: (System.Object [])) = [|var_67; var_68; var_74|]: (System.Object [])
        let (var_77: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_22", var_1, var_0)
        let (var_78: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
        var_77.set_GridDimensions(var_78)
        let (var_79: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_77.set_BlockDimensions(var_79)
        let (var_80: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_77.RunAsync(var_80, var_76)
        let (var_82: (Union7 ref)) = (ref Union7Case1)
        let (var_83: (float32 ref)) = (ref 0.000000f)
        let (var_85: (Union7 ref)) = (ref Union7Case1)
        let (var_86: (float32 ref)) = (ref 0.000000f)
        let (var_87: float32) = method_29((var_73: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_82: (Union7 ref)), (var_85: (Union7 ref)))
        var_86 := 1.000000f
        let (var_88: float32) = method_29((var_73: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_82: (Union7 ref)), (var_85: (Union7 ref)))
        let (var_89: float32) = (!var_86)
        let (var_90: float32) = method_28((var_73: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_82: (Union7 ref)))
        let (var_91: float32) = (var_89 / 32.000000f)
        let (var_92: float32) = (!var_83)
        let (var_93: float32) = (var_92 + var_91)
        var_83 := var_93
        let (var_94: float32) = method_28((var_73: (Union0 ref)), (var_0: ManagedCuda.CudaContext), (var_82: (Union7 ref)))
        let (var_95: float32) = (!var_83)
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_52: (Union0 ref)))
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_12: (Union0 ref)))
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        // Cuda join point
        // method_30((var_95: float32), (var_94: float32), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_98: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_100: (System.Object [])) = [|var_95; var_94; var_96; var_97; var_98|]: (System.Object [])
        let (var_101: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_1, var_0)
        let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
        var_101.set_GridDimensions(var_102)
        let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_101.set_BlockDimensions(var_103)
        let (var_104: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_101.RunAsync(var_104, var_100)
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_30: (Union0 ref)))
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_63: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_52: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        // Cuda join point
        // method_32((var_105: ManagedCuda.BasicTypes.CUdeviceptr), (var_106: ManagedCuda.BasicTypes.CUdeviceptr), (var_107: ManagedCuda.BasicTypes.CUdeviceptr), (var_108: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_110: (System.Object [])) = [|var_105; var_106; var_107; var_108|]: (System.Object [])
        let (var_111: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_32", var_1, var_0)
        let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(3u, 1u, 1u)
        var_111.set_GridDimensions(var_112)
        let (var_113: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_111.set_BlockDimensions(var_113)
        let (var_114: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_111.RunAsync(var_114, var_110)
        method_34((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: (Union0 ref)), (var_23: int64), (var_33: (Union0 ref)), (var_9: (Union0 ref)))
        let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_33: (Union0 ref)))
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        // Cuda join point
        // method_35((var_115: ManagedCuda.BasicTypes.CUdeviceptr), (var_116: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_118: (System.Object [])) = [|var_115; var_116|]: (System.Object [])
        let (var_119: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_35", var_1, var_0)
        let (var_120: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_119.set_GridDimensions(var_120)
        let (var_121: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
        var_119.set_BlockDimensions(var_121)
        let (var_122: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_119.RunAsync(var_122, var_118)
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_10: (Union0 ref)))
        // Cuda join point
        // method_39((var_123: ManagedCuda.BasicTypes.CUdeviceptr), (var_124: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_126: (System.Object [])) = [|var_123; var_124|]: (System.Object [])
        let (var_127: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_39", var_1, var_0)
        let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(62u, 1u, 1u)
        var_127.set_GridDimensions(var_128)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_127.set_BlockDimensions(var_129)
        let (var_130: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_127.RunAsync(var_130, var_126)
        let (var_131: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: (Union0 ref)))
        let (var_132: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_133: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
        var_0.ClearMemoryAsync(var_131, 0uy, var_133, var_132)
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_7: (Union0 ref)))
        // Cuda join point
        // method_41((var_134: ManagedCuda.BasicTypes.CUdeviceptr), (var_135: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_137: (System.Object [])) = [|var_134; var_135|]: (System.Object [])
        let (var_138: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_1, var_0)
        let (var_139: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_138.set_GridDimensions(var_139)
        let (var_140: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_138.set_BlockDimensions(var_140)
        let (var_141: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        var_138.RunAsync(var_141, var_137)
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_6: (Union0 ref)))
        let (var_143: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
        let (var_144: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
        var_0.ClearMemoryAsync(var_142, 0uy, var_144, var_143)
        let (var_145: float) = (float var_87)
        let (var_146: float) = (var_145 * 32.000000)
        let (var_147: float) = (var_13 + var_146)
        var_73 := Union0Case1
        var_63 := Union0Case1
        var_52 := Union0Case1
        var_33 := Union0Case1
        var_30 := Union0Case1
        method_15((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env2>), (var_6: (Union0 ref)), (var_7: (Union0 ref)), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: (Union0 ref)), (var_10: (Union0 ref)), (var_11: (Union0 ref)), (var_12: (Union0 ref)), (var_147: float), (var_16: int64))
    else
        var_13
and method_16((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_1: (Union0 ref)))
    let (var_9: ManagedCuda.BasicTypes.SizeT) = var_8.Pointer
    let (var_10: uint64) = uint64 var_9
    let (var_11: uint64) = (uint64 var_2)
    let (var_12: uint64) = (var_10 + var_11)
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_14: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_3: (Union0 ref)))
    let (var_16: (float32 ref)) = (ref 0.000000f)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_4: (Union0 ref)))
    let (var_18: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 32, 10, 784, var_7, var_14, 32, var_15, 784, var_16, var_17, 32)
    if var_18 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_18)
and method_29((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union7 ref)), (var_3: (Union7 ref))): float32 =
    let (var_4: Union7) = (!var_3)
    match var_4 with
    | Union7Case0(var_5) ->
        var_5.mem_0
    | Union7Case1 ->
        let (var_7: float32) = method_27((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union7 ref)))
        var_3 := (Union7Case0(Tuple8(var_7)))
        var_7
and method_28((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union7 ref))): float32 =
    let (var_3: Union7) = (!var_2)
    match var_3 with
    | Union7Case0(var_4) ->
        var_4.mem_0
    | Union7Case1 ->
        let (var_6: float32) = method_25((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext))
        var_2 := (Union7Case0(Tuple8(var_6)))
        var_6
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: (Union0 ref)), (var_2: int64), (var_3: (Union0 ref)), (var_4: (Union0 ref))): unit =
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_7: (float32 ref)) = (ref 1.000000f)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_1: (Union0 ref)))
    let (var_9: ManagedCuda.BasicTypes.SizeT) = var_8.Pointer
    let (var_10: uint64) = uint64 var_9
    let (var_11: uint64) = (uint64 var_2)
    let (var_12: uint64) = (var_10 + var_11)
    let (var_13: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_14: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_13)
    let (var_15: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_3: (Union0 ref)))
    let (var_16: (float32 ref)) = (ref 1.000000f)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_4: (Union0 ref)))
    let (var_18: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_5, var_6, 784, 10, 32, var_7, var_14, 32, var_15, 32, var_16, var_17, 784)
    if var_18 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_18)
and method_27((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union7 ref))): float32 =
    let (var_3: float32) = method_28((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext), (var_2: (Union7 ref)))
    (var_3 / 32.000000f)
and method_25((var_0: (Union0 ref)), (var_1: ManagedCuda.CudaContext)): float32 =
    let (var_2: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_0: (Union0 ref)))
    let (var_3: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(3L))
    var_1.CopyToHost(var_3, var_2)
    var_1.Synchronize()
    let (var_4: float32) = 0.000000f
    let (var_5: int64) = 0L
    method_26((var_3: (float32 [])), (var_4: float32), (var_5: int64))
and method_26((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 3L)
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
        method_26((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
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
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64")
let (var_10: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\include")
let (var_12: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "bin\\nvcc.exe")
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
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:\\cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
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
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_51: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_50)
let (var_52: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_51.SetStream(var_52)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaBlas.CudaBlasHandle) = var_55.get_CublasHandle()
let (var_57: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_55.set_Stream(var_57)
let (var_58: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_59: Tuple3) = method_2((var_58: string))
let (var_60: Tuple4) = var_59.mem_0
let (var_61: (uint8 [])) = var_59.mem_1
let (var_62: int64) = var_60.mem_0
let (var_63: int64) = var_60.mem_1
let (var_64: int64) = var_60.mem_2
let (var_65: bool) = (10000L = var_62)
let (var_69: bool) =
    if var_65 then
        let (var_66: bool) = (28L = var_63)
        if var_66 then
            (28L = var_64)
        else
            false
    else
        false
let (var_70: bool) = (var_69 = false)
if var_70 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_71: int64) = var_61.LongLength
let (var_72: bool) = (var_71 > 0L)
let (var_73: bool) = (var_72 = false)
if var_73 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_74: bool) = (7840000L = var_71)
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_79: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_80: int64) = 0L
method_3((var_61: (uint8 [])), (var_79: (float32 [])), (var_80: int64))
let (var_81: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_82: Tuple5) = method_5((var_81: string))
let (var_83: int64) = var_82.mem_0
let (var_84: (uint8 [])) = var_82.mem_1
let (var_85: bool) = (10000L = var_83)
let (var_86: bool) = (var_85 = false)
if var_86 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_90: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_91: int64) = 0L
method_6((var_84: (uint8 [])), (var_90: (float32 [])), (var_91: int64))
let (var_92: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_93: Tuple3) = method_2((var_92: string))
let (var_94: Tuple4) = var_93.mem_0
let (var_95: (uint8 [])) = var_93.mem_1
let (var_96: int64) = var_94.mem_0
let (var_97: int64) = var_94.mem_1
let (var_98: int64) = var_94.mem_2
let (var_99: bool) = (60000L = var_96)
let (var_103: bool) =
    if var_99 then
        let (var_100: bool) = (28L = var_97)
        if var_100 then
            (28L = var_98)
        else
            false
    else
        false
let (var_104: bool) = (var_103 = false)
if var_104 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_105: int64) = var_95.LongLength
let (var_106: bool) = (var_105 > 0L)
let (var_107: bool) = (var_106 = false)
if var_107 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_108: bool) = (47040000L = var_105)
let (var_109: bool) = (var_108 = false)
if var_109 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_113: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_114: int64) = 0L
method_8((var_95: (uint8 [])), (var_113: (float32 [])), (var_114: int64))
let (var_115: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_116: Tuple5) = method_5((var_115: string))
let (var_117: int64) = var_116.mem_0
let (var_118: (uint8 [])) = var_116.mem_1
let (var_119: bool) = (60000L = var_117)
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_124: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_125: int64) = 0L
method_9((var_118: (uint8 [])), (var_124: (float32 [])), (var_125: int64))
let (var_126: int64) = var_79.LongLength
let (var_127: int64) = (var_126 * 4L)
let (var_128: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_127: int64))
let (var_129: (Union0 ref)) = var_128.mem_0
let (var_130: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_129: (Union0 ref)))
var_1.CopyToDevice(var_130, var_79)
let (var_131: int64) = var_90.LongLength
let (var_132: int64) = (var_131 * 4L)
let (var_133: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_132: int64))
let (var_134: (Union0 ref)) = var_133.mem_0
let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_134: (Union0 ref)))
var_1.CopyToDevice(var_135, var_90)
let (var_136: int64) = var_113.LongLength
let (var_137: int64) = (var_136 * 4L)
let (var_138: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_137: int64))
let (var_139: (Union0 ref)) = var_138.mem_0
let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_139: (Union0 ref)))
var_1.CopyToDevice(var_140, var_113)
let (var_141: int64) = var_124.LongLength
let (var_142: int64) = (var_141 * 4L)
let (var_143: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_142: int64))
let (var_144: (Union0 ref)) = var_143.mem_0
let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_144: (Union0 ref)))
var_1.CopyToDevice(var_145, var_124)
let (var_146: int64) = 31360L
let (var_147: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_146: int64))
let (var_148: (Union0 ref)) = var_147.mem_0
let (var_149: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_148: (Union0 ref)))
let (var_150: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_51.GenerateNormal32(var_149, var_150, 0.000000f, 0.050189f)
let (var_151: int64) = 31360L
let (var_152: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_151: int64))
let (var_153: (Union0 ref)) = var_152.mem_0
let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_153: (Union0 ref)))
let (var_155: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_156: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_154, 0uy, var_156, var_155)
let (var_157: int64) = 40L
let (var_158: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_157: int64))
let (var_159: (Union0 ref)) = var_158.mem_0
let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_159: (Union0 ref)))
let (var_161: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_162: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_160, 0uy, var_162, var_161)
let (var_163: int64) = 40L
let (var_164: Env6) = method_10((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_163: int64))
let (var_165: (Union0 ref)) = var_164.mem_0
let (var_166: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_165: (Union0 ref)))
let (var_167: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_168: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_166, 0uy, var_168, var_167)
let (var_169: int64) = 0L
method_14((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_165: (Union0 ref)), (var_159: (Union0 ref)), (var_56: ManagedCuda.CudaBlas.CudaBlasHandle), (var_153: (Union0 ref)), (var_148: (Union0 ref)), (var_139: (Union0 ref)), (var_144: (Union0 ref)), (var_169: int64))
var_165 := Union0Case1
var_159 := Union0Case1
var_153 := Union0Case1
var_148 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_170: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_170)
var_43 := Union0Case1
var_1.Dispose()

