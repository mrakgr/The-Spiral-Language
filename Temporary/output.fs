module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple3 {
        int mem_0;
        int mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(int mem_0, int mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef int(*FunPointer0)(int, int);
    struct Env1 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Env1 make_Env1(float mem_0, float mem_1){
        Env1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Env2 {
        float mem_0;
        float mem_1;
        float mem_2;
        float mem_3;
    };
    __device__ __forceinline__ Env2 make_Env2(float mem_0, float mem_1, float mem_2, float mem_3){
        Env2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        tmp.mem_2 = mem_2;
        tmp.mem_3 = mem_3;
        return tmp;
    }
    __global__ void method_46(int * var_0, int * var_1);
    __global__ void method_41(unsigned long long int * var_0, unsigned long long int * var_1, float * var_2, float * var_3);
    __global__ void method_54(float * var_0);
    __global__ void method_79(float * var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6);
    __global__ void method_73(float * var_0, long long int var_1, float * var_2);
    __device__ char method_47(long long int * var_0, int * var_1);
    __device__ int method_48(int var_0, int var_1);
    __device__ char method_42(long long int * var_0);
    __device__ char method_55(long long int * var_0);
    __device__ char method_80(long long int * var_0);
    __device__ char method_74(long long int var_0, long long int * var_1);
    __device__ char method_75(long long int * var_0, float * var_1);
    
    __global__ void method_46(int * var_0, int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (var_2 + var_3);
        int var_5 = 0;
        long long int var_6[1];
        int var_7[1];
        var_6[0] = var_4;
        var_7[0] = var_5;
        while (method_47(var_6, var_7)) {
            long long int var_9 = var_6[0];
            int var_10 = var_7[0];
            char var_11 = (var_9 >= 0);
            char var_13;
            if (var_11) {
                var_13 = (var_9 < 1);
            } else {
                var_13 = 0;
            }
            char var_14 = (var_13 == 0);
            if (var_14) {
                // "Argument out of bounds."
            } else {
            }
            int var_15 = var_0[var_9];
            char var_16 = (var_10 > var_15);
            int var_17;
            if (var_16) {
                var_17 = var_10;
            } else {
                var_17 = var_15;
            }
            long long int var_18 = (var_9 + 1);
            var_6[0] = var_18;
            var_7[0] = var_17;
        }
        long long int var_19 = var_6[0];
        int var_20 = var_7[0];
        FunPointer0 var_23 = method_48;
        int var_24 = cub::BlockReduce<int,1,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Reduce(var_20, var_23);
        long long int var_25 = threadIdx.x;
        char var_26 = (var_25 == 0);
        if (var_26) {
            long long int var_27 = blockIdx.x;
            char var_28 = (var_27 >= 0);
            char var_30;
            if (var_28) {
                var_30 = (var_27 < 1);
            } else {
                var_30 = 0;
            }
            char var_31 = (var_30 == 0);
            if (var_31) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_27] = var_24;
        } else {
        }
    }
    __global__ void method_41(unsigned long long int * var_0, unsigned long long int * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = blockIdx.x;
        long long int var_6 = (var_4 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_42(var_7)) {
            long long int var_9 = var_7[0];
            unsigned long long int var_10 = (unsigned long long) (var_2 + 0);
            var_0[0] = var_10;
            unsigned long long int var_11 = (unsigned long long) (var_3 + 0);
            var_1[0] = var_11;
            long long int var_12 = (var_9 + 1);
            var_7[0] = var_12;
        }
        long long int var_13 = var_7[0];
    }
    __global__ void method_54(float * var_0) {
        long long int var_1 = threadIdx.x;
        long long int var_2 = blockIdx.x;
        long long int var_3 = (64 * var_2);
        long long int var_4 = (var_1 + var_3);
        long long int var_5[1];
        var_5[0] = var_4;
        while (method_55(var_5)) {
            long long int var_7 = var_5[0];
            long long int var_8 = (var_7 % 8);
            long long int var_9 = (var_7 / 8);
            long long int var_10 = (var_9 % 8);
            long long int var_11 = (var_9 / 8);
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 8);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = (var_10 * 8);
            char var_17 = (var_10 == var_8);
            float var_18;
            if (var_17) {
                var_18 = 1;
            } else {
                var_18 = 0;
            }
            char var_19 = (var_8 >= 0);
            char var_21;
            if (var_19) {
                var_21 = (var_8 < 8);
            } else {
                var_21 = 0;
            }
            char var_22 = (var_21 == 0);
            if (var_22) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_23 = (var_16 + var_8);
            float var_24 = var_0[var_23];
            var_0[var_23] = var_18;
            long long int var_25 = (var_7 + 64);
            var_5[0] = var_25;
        }
        long long int var_26 = var_5[0];
    }
    __global__ void method_79(float * var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6) {
        long long int var_7 = threadIdx.x;
        long long int var_8 = blockIdx.x;
        long long int var_9 = (8 * var_8);
        long long int var_10 = (var_7 + var_9);
        long long int var_11 = threadIdx.y;
        long long int var_12 = blockIdx.y;
        long long int var_13 = (var_11 + var_12);
        long long int var_14[1];
        var_14[0] = var_13;
        while (method_80(var_14)) {
            long long int var_16 = var_14[0];
            Env1 var_30[1];
            long long int var_31[1];
            var_31[0] = 0;
            while (method_42(var_31)) {
                long long int var_33 = var_31[0];
                long long int var_34 = (8 * var_33);
                long long int var_35 = (var_10 + var_34);
                long long int var_36 = (8 - var_34);
                char var_37 = (var_35 < 8);
                if (var_37) {
                    char var_38 = (var_33 >= 0);
                    char var_40;
                    if (var_38) {
                        var_40 = (var_33 < 1);
                    } else {
                        var_40 = 0;
                    }
                    char var_41 = (var_40 == 0);
                    if (var_41) {
                        // "Argument out of bounds."
                    } else {
                    }
                    char var_42 = (var_16 >= 0);
                    char var_44;
                    if (var_42) {
                        var_44 = (var_16 < 8);
                    } else {
                        var_44 = 0;
                    }
                    char var_45 = (var_44 == 0);
                    if (var_45) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_46 = (var_16 * 8);
                    char var_47 = (var_35 >= 0);
                    char var_48 = (var_47 == 0);
                    if (var_48) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_49 = (var_46 + var_35);
                    float var_50 = var_0[var_49];
                    var_30[var_33] = (make_Env1(var_50, 0));
                } else {
                }
                long long int var_51 = (var_33 + 1);
                var_31[0] = var_51;
            }
            long long int var_52 = var_31[0];
            long long int var_53[1];
            var_53[0] = 0;
            while (method_74(var_6, var_53)) {
                long long int var_55 = var_53[0];
                Env2 var_80[1];
                long long int var_81[1];
                var_81[0] = 0;
                while (method_42(var_81)) {
                    long long int var_83 = var_81[0];
                    long long int var_84 = (8 * var_83);
                    long long int var_85 = (var_10 + var_84);
                    long long int var_86 = (8 - var_84);
                    char var_87 = (var_85 < 8);
                    if (var_87) {
                        char var_88 = (var_83 >= 0);
                        char var_90;
                        if (var_88) {
                            var_90 = (var_83 < 1);
                        } else {
                            var_90 = 0;
                        }
                        char var_91 = (var_90 == 0);
                        if (var_91) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_93;
                        if (var_88) {
                            var_93 = (var_83 < 1);
                        } else {
                            var_93 = 0;
                        }
                        char var_94 = (var_93 == 0);
                        if (var_94) {
                            // "Argument out of bounds."
                        } else {
                        }
                        Env1 var_95 = var_30[var_83];
                        float var_96 = var_95.mem_0;
                        float var_97 = var_95.mem_1;
                        char var_98 = (var_55 >= 0);
                        char var_100;
                        if (var_98) {
                            var_100 = (var_55 < var_6);
                        } else {
                            var_100 = 0;
                        }
                        char var_101 = (var_100 == 0);
                        if (var_101) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_102 = (var_55 * 8);
                        char var_103 = (var_85 >= 0);
                        char var_104 = (var_103 == 0);
                        if (var_104) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_105 = (var_102 + var_85);
                        float var_106 = var_5[var_105];
                        char var_108;
                        if (var_98) {
                            var_108 = (var_55 < var_4);
                        } else {
                            var_108 = 0;
                        }
                        char var_109 = (var_108 == 0);
                        if (var_109) {
                            // "Argument out of bounds."
                        } else {
                        }
                        float var_110 = var_3[var_55];
                        var_80[var_83] = (make_Env2(var_96, var_110, var_97, var_106));
                    } else {
                    }
                    long long int var_111 = (var_83 + 1);
                    var_81[0] = var_111;
                }
                long long int var_112 = var_81[0];
                float var_125[1];
                long long int var_126[1];
                var_126[0] = 0;
                while (method_42(var_126)) {
                    long long int var_128 = var_126[0];
                    long long int var_129 = (8 * var_128);
                    long long int var_130 = (var_10 + var_129);
                    long long int var_131 = (8 - var_129);
                    char var_132 = (var_130 < 8);
                    if (var_132) {
                        char var_133 = (var_128 >= 0);
                        char var_135;
                        if (var_133) {
                            var_135 = (var_128 < 1);
                        } else {
                            var_135 = 0;
                        }
                        char var_136 = (var_135 == 0);
                        if (var_136) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_138;
                        if (var_133) {
                            var_138 = (var_128 < 1);
                        } else {
                            var_138 = 0;
                        }
                        char var_139 = (var_138 == 0);
                        if (var_139) {
                            // "Argument out of bounds."
                        } else {
                        }
                        Env2 var_140 = var_80[var_128];
                        float var_141 = var_140.mem_0;
                        float var_142 = var_140.mem_1;
                        float var_143 = var_140.mem_2;
                        float var_144 = var_140.mem_3;
                        float var_145 = (var_141 * var_144);
                        var_125[var_128] = var_145;
                    } else {
                    }
                    long long int var_146 = (var_128 + 1);
                    var_126[0] = var_146;
                }
                long long int var_147 = var_126[0];
                float var_148 = cub::BlockReduce<float,8,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_125);
                __shared__ float var_149[1];
                long long int var_150 = threadIdx.x;
                char var_151 = (var_150 == 0);
                if (var_151) {
                    var_149[0] = var_148;
                } else {
                }
                __syncthreads();
                float var_152 = var_149[0];
                Env1 var_178[1];
                long long int var_179[1];
                var_179[0] = 0;
                while (method_42(var_179)) {
                    long long int var_181 = var_179[0];
                    long long int var_182 = (8 * var_181);
                    long long int var_183 = (var_10 + var_182);
                    long long int var_184 = (8 - var_182);
                    char var_185 = (var_183 < 8);
                    if (var_185) {
                        char var_186 = (var_181 >= 0);
                        char var_188;
                        if (var_186) {
                            var_188 = (var_181 < 1);
                        } else {
                            var_188 = 0;
                        }
                        char var_189 = (var_188 == 0);
                        if (var_189) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_191;
                        if (var_186) {
                            var_191 = (var_181 < 1);
                        } else {
                            var_191 = 0;
                        }
                        char var_192 = (var_191 == 0);
                        if (var_192) {
                            // "Argument out of bounds."
                        } else {
                        }
                        Env2 var_193 = var_80[var_181];
                        float var_194 = var_193.mem_0;
                        float var_195 = var_193.mem_1;
                        float var_196 = var_193.mem_2;
                        float var_197 = var_193.mem_3;
                        char var_198 = (var_16 >= 0);
                        char var_200;
                        if (var_198) {
                            var_200 = (var_16 < 8);
                        } else {
                            var_200 = 0;
                        }
                        char var_201 = (var_200 == 0);
                        if (var_201) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_202 = (var_16 * 8);
                        char var_203 = (var_183 >= 0);
                        char var_204 = (var_203 == 0);
                        if (var_204) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_205 = (var_202 + var_183);
                        float var_206 = var_2[var_205];
                        float var_207 = (var_195 * var_152);
                        float var_208 = (var_207 * var_197);
                        float var_209 = (var_196 + var_208);
                        var_178[var_181] = (make_Env1(var_194, var_209));
                    } else {
                    }
                    long long int var_210 = (var_181 + 1);
                    var_179[0] = var_210;
                }
                long long int var_211 = var_179[0];
                long long int var_212[1];
                var_212[0] = 0;
                while (method_42(var_212)) {
                    long long int var_214 = var_212[0];
                    long long int var_215 = (8 * var_214);
                    long long int var_216 = (var_10 + var_215);
                    long long int var_217 = (8 - var_215);
                    char var_218 = (var_216 < 8);
                    if (var_218) {
                        char var_219 = (var_214 >= 0);
                        char var_221;
                        if (var_219) {
                            var_221 = (var_214 < 1);
                        } else {
                            var_221 = 0;
                        }
                        char var_222 = (var_221 == 0);
                        if (var_222) {
                            // "Argument out of bounds."
                        } else {
                        }
                        char var_224;
                        if (var_219) {
                            var_224 = (var_214 < 1);
                        } else {
                            var_224 = 0;
                        }
                        char var_225 = (var_224 == 0);
                        if (var_225) {
                            // "Argument out of bounds."
                        } else {
                        }
                        Env1 var_226 = var_178[var_214];
                        float var_227 = var_226.mem_0;
                        float var_228 = var_226.mem_1;
                        var_30[var_214] = (make_Env1(var_227, var_228));
                    } else {
                    }
                    long long int var_229 = (var_214 + 1);
                    var_212[0] = var_229;
                }
                long long int var_230 = var_212[0];
                long long int var_231 = (var_55 + 1);
                var_53[0] = var_231;
            }
            long long int var_232 = var_53[0];
            long long int var_233[1];
            var_233[0] = 0;
            while (method_42(var_233)) {
                long long int var_235 = var_233[0];
                long long int var_236 = (8 * var_235);
                long long int var_237 = (var_10 + var_236);
                long long int var_238 = (8 - var_236);
                char var_239 = (var_237 < 8);
                if (var_239) {
                    char var_240 = (var_235 >= 0);
                    char var_242;
                    if (var_240) {
                        var_242 = (var_235 < 1);
                    } else {
                        var_242 = 0;
                    }
                    char var_243 = (var_242 == 0);
                    if (var_243) {
                        // "Argument out of bounds."
                    } else {
                    }
                    Env1 var_244 = var_30[var_235];
                    float var_245 = var_244.mem_0;
                    float var_246 = var_244.mem_1;
                    char var_247 = (var_16 >= 0);
                    char var_249;
                    if (var_247) {
                        var_249 = (var_16 < 8);
                    } else {
                        var_249 = 0;
                    }
                    char var_250 = (var_249 == 0);
                    if (var_250) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_251 = (var_16 * 8);
                    char var_252 = (var_237 >= 0);
                    char var_253 = (var_252 == 0);
                    if (var_253) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_254 = (var_251 + var_237);
                    float var_255 = (1.0005 * var_245);
                    float var_256 = (var_246 / var_1);
                    float var_257 = (var_255 + var_256);
                    var_2[var_254] = var_257;
                } else {
                }
                long long int var_258 = (var_235 + 1);
                var_233[0] = var_258;
            }
            long long int var_259 = var_233[0];
            long long int var_260 = (var_16 + 8);
            var_14[0] = var_260;
        }
        long long int var_261 = var_14[0];
    }
    __global__ void method_73(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.y;
        long long int var_4 = blockIdx.y;
        long long int var_5 = (var_3 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_74(var_1, var_6)) {
            long long int var_8 = var_6[0];
            char var_9 = (var_8 >= 0);
            char var_11;
            if (var_9) {
                var_11 = (var_8 < var_1);
            } else {
                var_11 = 0;
            }
            char var_12 = (var_11 == 0);
            if (var_12) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_13 = (var_8 * 8);
            char var_15;
            if (var_9) {
                var_15 = (var_8 < var_1);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.x;
            long long int var_18 = blockIdx.x;
            long long int var_19 = (8 * var_18);
            long long int var_20 = (var_17 + var_19);
            float var_21 = 0;
            long long int var_22[1];
            float var_23[1];
            var_22[0] = var_20;
            var_23[0] = var_21;
            while (method_75(var_22, var_23)) {
                long long int var_25 = var_22[0];
                float var_26 = var_23[0];
                char var_27 = (var_25 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_25 < 8);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_13 + var_25);
                float var_32 = var_0[var_31];
                float var_33 = (var_32 * var_32);
                float var_34 = (var_26 + var_33);
                long long int var_35 = (var_25 + 8);
                var_22[0] = var_35;
                var_23[0] = var_34;
            }
            long long int var_36 = var_22[0];
            float var_37 = var_23[0];
            float var_38 = cub::BlockReduce<float,8,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_37);
            long long int var_39 = threadIdx.x;
            char var_40 = (var_39 == 0);
            if (var_40) {
                char var_42;
                if (var_9) {
                    var_42 = (var_8 < var_1);
                } else {
                    var_42 = 0;
                }
                char var_43 = (var_42 == 0);
                if (var_43) {
                    // "Argument out of bounds."
                } else {
                }
                float var_44 = var_2[var_8];
                float var_45 = (-1.0005 / var_38);
                float var_46 = (0.001001001 * var_38);
                float var_47 = (1 + var_46);
                float var_48 = sqrt(var_47);
                float var_49 = (1 / var_48);
                float var_50 = (1 - var_49);
                float var_51 = (var_45 * var_50);
                float var_52;
                if (isnan(var_51)) {
                    var_52 = 0;
                } else {
                    var_52 = var_51;
                }
                var_2[var_8] = var_52;
            } else {
            }
            long long int var_53 = (var_8 + 64);
            var_6[0] = var_53;
        }
        long long int var_54 = var_6[0];
    }
    __device__ char method_47(long long int * var_0, int * var_1) {
        long long int var_2 = var_0[0];
        int var_3 = var_1[0];
        return (var_2 < 1);
    }
    __device__ int method_48(int var_0, int var_1) {
        char var_2 = (var_0 > var_1);
        if (var_2) {
            return var_0;
        } else {
            return var_1;
        }
    }
    __device__ char method_42(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 1);
    }
    __device__ char method_55(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 64);
    }
    __device__ char method_80(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 8);
    }
    __device__ char method_74(long long int var_0, long long int * var_1) {
        long long int var_2 = var_1[0];
        return (var_2 < var_0);
    }
    __device__ char method_75(long long int * var_0, float * var_1) {
        long long int var_2 = var_0[0];
        float var_3 = var_1[0];
        return (var_2 < 8);
    }
}
"""

type EnvHeap0 =
    {
    mem_0: ManagedCuda.CudaContext
    }
and Env1 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: ResizeArray<Env1>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: Env22
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack4 =
    struct
    val mem_0: ResizeArray<Env3>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap5 =
    {
    mem_0: EnvStack2
    mem_1: (uint64 ref)
    mem_2: uint64
    mem_3: EnvStack4
    }
and EnvHeap6 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: EnvHeap5
    }
and EnvHeap7 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaRand.CudaRandDevice
    mem_2: EnvHeap5
    }
and EnvHeap8 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvHeap5
    }
and Env9 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env22
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack10 =
    struct
    val mem_0: ResizeArray<Env9>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap11 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvHeap5
    }
and Env12 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env16
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack13 =
    struct
    val mem_0: ResizeArray<Env12>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap14 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvStack13
    mem_5: EnvHeap5
    }
and EnvHeap15 =
    {
    mem_0: ManagedCuda.CudaEvent
    mem_1: (bool ref)
    mem_2: ManagedCuda.CudaStream
    }
and Env16 =
    struct
    val mem_0: EnvHeap15
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap17 =
    {
    mem_0: ManagedCuda.CudaContext
    mem_1: ManagedCuda.CudaBlas.CudaBlas
    mem_2: ManagedCuda.CudaRand.CudaRandDevice
    mem_3: EnvStack10
    mem_4: EnvStack13
    mem_5: EnvHeap5
    mem_6: (int64 ref)
    mem_7: EnvHeap15
    }
and Tuple18 =
    struct
    val mem_0: Tuple19
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple19 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple20 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env21 =
    struct
    val mem_0: Env9
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env22 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack23 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack24 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack25 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack26 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple27 =
    struct
    val mem_0: Env28
    val mem_1: Env28
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env28 =
    struct
    val mem_0: Env29
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env29 =
    struct
    val mem_0: Env30
    val mem_1: Tuple33
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env30 =
    struct
    val mem_0: Env31
    val mem_1: int64
    val mem_2: Tuple32
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Env31 =
    struct
    val mem_0: Env9
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple32 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple33 =
    struct
    val mem_0: Env34
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env34 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack35 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack36 =
    struct
    val mem_0: (int64 ref)
    val mem_1: (uint64 ref)
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    System.Console.WriteLine(var_1)
and method_1((var_0: EnvHeap6), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap5) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack2) = var_2.mem_0
    let (var_6: EnvStack4) = var_2.mem_3
    let (var_7: ResizeArray<Env3>) = var_6.mem_0
    let (var_9: (Env3 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env3 -> (Env3 -> int32))) = method_3
    let (var_13: System.Comparison<Env3>) = System.Comparison<Env3>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env1>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack2), (var_6: EnvStack4), (var_15: int32), (var_16: uint64), (var_17: int32))
    let (var_19: uint64) = method_5((var_3: (uint64 ref)))
    let (var_20: uint64) = (var_19 + var_4)
    let (var_21: uint64) = (var_20 - var_18)
    let (var_22: uint64) = (var_18 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_18)
    let (var_26: bool) = (var_21 > var_25)
    if var_26 then
        let (var_27: uint64) = (var_21 - var_25)
        var_14.Add((Env1(var_24, var_27)))
    else
        ()
and method_7((var_0: EnvHeap15), (var_1: EnvHeap14), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env12 =
    let (var_3: (int64 ref)) = (ref 0L)
    let (var_4: EnvStack13) = var_1.mem_4
    method_8((var_3: (int64 ref)), (var_0: EnvHeap15), (var_4: EnvStack13))
    (Env12(var_3, (Env16(var_0))))
and method_9((var_0: string)): Tuple18 =
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
    Tuple18(Tuple19(var_16, var_17, var_18), var_22)
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
and method_12((var_0: string)): Tuple20 =
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
    Tuple20(var_12, var_14)
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
and method_17((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (float32 [])), (var_4: int64), (var_5: int64), (var_6: int64)): Env21 =
    let (var_7: (int64 ref)) = var_0.mem_6
    let (var_8: EnvHeap15) = var_0.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    let (var_10: int64) = (var_2 * var_5)
    let (var_11: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_3,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_12: int64) = var_11.AddrOfPinnedObject().ToInt64()
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: int64) = (var_4 * 4L)
    let (var_15: uint64) = (uint64 var_14)
    let (var_16: uint64) = (var_15 + var_13)
    let (var_17: Env9) = method_19((var_10: int64), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env22) = var_17.mem_1
    let (var_20: (uint64 ref)) = var_19.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: int64) = (var_10 * 4L)
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_25)
    let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_28: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.AsynchronousMemcpy_v2.cuMemcpyAsync(var_24, var_26, var_27, var_9)
    if var_28 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_28)
    var_11.Free()
    (Env21((Env9(var_18, (Env22(var_20))))))
and method_26((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack23 =
    let (var_2: Env9) = method_27((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_3: (int64 ref)) = var_2.mem_0
    let (var_4: Env22) = var_2.mem_1
    let (var_5: (uint64 ref)) = var_4.mem_0
    method_28((var_3: (int64 ref)), (var_5: (uint64 ref)), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack23((var_3: (int64 ref)), (var_5: (uint64 ref)))
and method_29((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack24 =
    let (var_6: Env9) = method_30((var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env22) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_31((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack24((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_32((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_4: Env9) = method_33((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env22) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    method_34((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_5: (int64 ref)), (var_7: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack25((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_35((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack26 =
    let (var_4: Env9) = method_33((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env22) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    let (var_8: Env9) = method_36((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_9: (int64 ref)) = var_8.mem_0
    let (var_10: Env22) = var_8.mem_1
    let (var_11: (uint64 ref)) = var_10.mem_0
    let (var_12: Tuple27) = method_37((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_5: (int64 ref)), (var_7: (uint64 ref)))
    let (var_13: Env28) = var_12.mem_0
    let (var_14: Env29) = var_13.mem_0
    let (var_15: Env30) = var_14.mem_0
    let (var_16: Env31) = var_15.mem_0
    let (var_17: Env9) = var_16.mem_0
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env22) = var_17.mem_1
    let (var_20: (uint64 ref)) = var_19.mem_0
    let (var_21: int64) = var_15.mem_1
    let (var_22: Tuple32) = var_15.mem_2
    let (var_23: int64) = var_22.mem_0
    let (var_24: Tuple33) = var_14.mem_1
    let (var_25: Env34) = var_24.mem_0
    let (var_26: int64) = var_25.mem_0
    let (var_27: int64) = var_25.mem_1
    let (var_28: Env28) = var_12.mem_1
    let (var_29: Env29) = var_28.mem_0
    let (var_30: Env30) = var_29.mem_0
    let (var_31: Env31) = var_30.mem_0
    let (var_32: Env9) = var_31.mem_0
    let (var_33: (int64 ref)) = var_32.mem_0
    let (var_34: Env22) = var_32.mem_1
    let (var_35: (uint64 ref)) = var_34.mem_0
    let (var_36: int64) = var_30.mem_1
    let (var_37: Tuple32) = var_30.mem_2
    let (var_38: int64) = var_37.mem_0
    let (var_39: Tuple33) = var_29.mem_1
    let (var_40: Env34) = var_39.mem_0
    let (var_41: int64) = var_40.mem_0
    let (var_42: int64) = var_40.mem_1
    method_43((var_18: (int64 ref)), (var_20: (uint64 ref)), (var_21: int64), (var_23: int64), (var_26: int64), (var_27: int64), (var_33: (int64 ref)), (var_35: (uint64 ref)), (var_36: int64), (var_38: int64), (var_41: int64), (var_42: int64), (var_9: (int64 ref)), (var_11: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_43: EnvStack35) = method_44((var_9: (int64 ref)), (var_11: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_44: (int64 ref)) = var_43.mem_0
    let (var_45: (uint64 ref)) = var_43.mem_1
    let (var_46: int64) = 1L
    let (var_47: int64) = 0L
    let (var_48: (int32 [])) = method_49((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_46: int64), (var_44: (int64 ref)), (var_45: (uint64 ref)), (var_47: int64))
    let (var_49: int32) = var_48.[int32 0L]
    let (var_50: bool) = (var_49 = 0)
    let (var_51: bool) = (var_50 = false)
    if var_51 then
        (failwith "The matrix inversion failed.")
    else
        ()
    EnvStack26((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_50((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_6: Env9) = method_33((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env22) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_51((var_7: (int64 ref)), (var_9: (uint64 ref)), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    EnvStack25((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_56((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
    let (var_11: int64) = (var_8 - var_7)
    let (var_12: int64) = (var_10 - var_9)
    let (var_13: int64) = (var_11 * var_12)
    let (var_14: bool) = (var_13 > 0L)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_16: int64) = (var_12 * var_6)
    let (var_17: bool) = (var_5 = var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_19: int64) = (var_11 * var_5)
    let (var_20: (float32 [])) = method_57((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_11: int64), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: int64), (var_5: int64), (var_6: int64))
    let (var_21: int64) = 0L
    method_58((var_20: (float32 [])), (var_21: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64))
and method_65((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: int64)): unit =
    let (var_7: bool) = (var_6 < 1000L)
    if var_7 then
        method_24((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
        let (var_14: ResizeArray<Env9>) = ResizeArray<Env9>()
        let (var_15: EnvStack10) = EnvStack10((var_14: ResizeArray<Env9>))
        let (var_16: ManagedCuda.CudaContext) = var_2.mem_0
        let (var_17: ManagedCuda.CudaBlas.CudaBlas) = var_2.mem_1
        let (var_18: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
        let (var_19: EnvStack10) = var_2.mem_3
        let (var_20: EnvStack13) = var_2.mem_4
        let (var_21: EnvHeap5) = var_2.mem_5
        let (var_22: (int64 ref)) = var_2.mem_6
        let (var_23: EnvHeap15) = var_2.mem_7
        let (var_24: EnvHeap17) = ({mem_0 = (var_16: ManagedCuda.CudaContext); mem_1 = (var_17: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_18: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_15: EnvStack10); mem_4 = (var_20: EnvStack13); mem_5 = (var_21: EnvHeap5); mem_6 = (var_22: (int64 ref)); mem_7 = (var_23: EnvHeap15)} : EnvHeap17)
        let (var_25: EnvStack24) = method_66((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_24: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
        let (var_26: (int64 ref)) = var_25.mem_0
        let (var_27: (uint64 ref)) = var_25.mem_1
        let (var_28: int64) = 0L
        method_68((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_24: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_26: (int64 ref)), (var_27: (uint64 ref)), (var_28: int64))
        let (var_29: EnvStack10) = var_24.mem_3
        method_81((var_29: EnvStack10))
        let (var_30: int64) = (var_6 + 1L)
        method_65((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_30: int64))
    else
        ()
and method_83((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_4: Env9) = method_33((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env22) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    method_84((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_5: (int64 ref)), (var_7: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack25((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_85((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack25 =
    let (var_4: Env9) = method_33((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_5: (int64 ref)) = var_4.mem_0
    let (var_6: Env22) = var_4.mem_1
    let (var_7: (uint64 ref)) = var_6.mem_0
    method_86((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_5: (int64 ref)), (var_7: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    EnvStack25((var_5: (int64 ref)), (var_7: (uint64 ref)))
and method_87((var_0: EnvStack13)): unit =
    let (var_1: ResizeArray<Env12>) = var_0.mem_0
    let (var_3: (Env12 -> unit)) = method_88
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_81((var_0: EnvStack10)): unit =
    let (var_1: ResizeArray<Env9>) = var_0.mem_0
    let (var_3: (Env9 -> unit)) = method_82
    var_1.ForEach <| System.Action<_>(var_3)
    var_1.Clear()
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2 ((var_0: Env3)): bool =
    let (var_1: Env22) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: uint64) = (!var_2)
    (var_4 = 0UL)
and method_3 ((var_0: Env3)): (Env3 -> int32) =
    let (var_1: Env22) = var_0.mem_0
    let (var_2: (uint64 ref)) = var_1.mem_0
    let (var_3: uint64) = var_0.mem_1
    method_4((var_2: (uint64 ref)))
and method_6((var_0: EnvStack2), (var_1: EnvStack4), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: ResizeArray<Env3>) = var_1.mem_0
        let (var_7: Env3) = var_6.[var_4]
        let (var_8: Env22) = var_7.mem_0
        let (var_9: (uint64 ref)) = var_8.mem_0
        let (var_10: uint64) = var_7.mem_1
        let (var_11: uint64) = method_5((var_9: (uint64 ref)))
        let (var_12: bool) = (var_11 >= var_3)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_14: uint64) = method_5((var_9: (uint64 ref)))
        let (var_15: uint64) = (var_14 - var_3)
        let (var_16: uint64) = (var_3 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_3)
        let (var_20: bool) = (var_15 > var_19)
        if var_20 then
            let (var_21: ResizeArray<Env1>) = var_0.mem_0
            let (var_22: uint64) = (var_15 - var_19)
            var_21.Add((Env1(var_18, var_22)))
        else
            ()
        let (var_23: uint64) = (var_14 + var_10)
        let (var_24: int32) = (var_4 + 1)
        method_6((var_0: EnvStack2), (var_1: EnvStack4), (var_2: int32), (var_23: uint64), (var_24: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: EnvHeap15), (var_2: EnvStack13)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env12>) = var_2.mem_0
    var_5.Add((Env12(var_0, (Env16(var_1)))))
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
and method_18((var_0: EnvHeap15)): ManagedCuda.BasicTypes.CUstream =
    let (var_1: (bool ref)) = var_0.mem_1
    let (var_2: bool) = (!var_1)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_4: ManagedCuda.CudaStream) = var_0.mem_2
    var_4.Stream
and method_19((var_0: int64), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_3: int64) = (var_0 * 4L)
    method_20((var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: int64))
and method_27((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 25088L
    method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_28((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(6272L)
    let (var_6: ManagedCuda.CudaRand.CudaRandDevice) = var_2.mem_2
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap15) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    var_6.SetStream(var_9)
    let (var_10: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_4)
    let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_10)
    var_6.GenerateNormal32(var_11, var_5, 0.000000f, 0.100000f)
and method_30((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 3072L
    method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_31((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap15) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap15))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 0.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 8, 96, 784, var_15, var_18, 8, var_21, 784, var_22, var_25, 8)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_33((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 256L
    method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_34((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: ManagedCuda.CudaBlas.CudaBlas) = var_4.mem_1
    let (var_7: (int64 ref)) = var_4.mem_6
    let (var_8: EnvHeap15) = var_4.mem_7
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    var_6.set_Stream(var_10)
    let (var_11: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_13: (float32 ref)) = (ref 0.010417f)
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: uint64) = method_5((var_1: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (float32 ref)) = (ref 0.000000f)
    let (var_21: uint64) = method_5((var_3: (uint64 ref)))
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_11, var_12, 8, 8, 96, var_13, var_16, 8, var_19, 8, var_20, var_23, 8)
    if var_24 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_24)
and method_36((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 4L
    method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_37((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref))): Tuple27 =
    let (var_6: Env9) = method_38((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env22) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    let (var_10: Env9) = method_38((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    let (var_11: (int64 ref)) = var_10.mem_0
    let (var_12: Env22) = var_10.mem_1
    let (var_13: (uint64 ref)) = var_12.mem_0
    let (var_14: uint64) = method_5((var_9: (uint64 ref)))
    let (var_15: uint64) = method_5((var_13: (uint64 ref)))
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: uint64) = method_5((var_5: (uint64 ref)))
    method_39((var_14: uint64), (var_15: uint64), (var_16: uint64), (var_17: uint64), (var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
    Tuple27((Env28((Env29((Env30((Env31((Env9(var_7, (Env22(var_9)))))), 0L, Tuple32(1L))), Tuple33((Env34(0L, 1L))))))), (Env28((Env29((Env30((Env31((Env9(var_11, (Env22(var_13)))))), 0L, Tuple32(1L))), Tuple33((Env34(0L, 1L))))))))
and method_43((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 ref)), (var_7: (uint64 ref)), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 ref)), (var_13: (uint64 ref)), (var_14: EnvHeap17), (var_15: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_16: int64) = (var_5 - var_4)
    let (var_17: int64) = (var_11 - var_10)
    let (var_18: bool) = (var_16 = var_17)
    let (var_19: bool) = (var_18 = false)
    if var_19 then
        (failwith "Ainv must be equal to batch size.")
    else
        ()
    let (var_20: bool) = (var_16 = 1L)
    let (var_21: bool) = (var_20 = false)
    if var_21 then
        (failwith "info must be equal to batch size.")
    else
        ()
    let (var_22: int32) = (int32 var_16)
    let (var_23: ManagedCuda.CudaBlas.CudaBlas) = var_14.mem_1
    let (var_24: (int64 ref)) = var_14.mem_6
    let (var_25: EnvHeap15) = var_14.mem_7
    let (var_26: ManagedCuda.CudaBlas.CudaBlasHandle) = var_23.get_CublasHandle()
    let (var_27: ManagedCuda.BasicTypes.CUstream) = method_18((var_25: EnvHeap15))
    var_23.set_Stream(var_27)
    let (var_28: bool) = (var_3 = 1L)
    let (var_29: bool) = (var_28 = false)
    if var_29 then
        (failwith "The stride of the innermost dimension should always be 1.")
    else
        ()
    let (var_30: bool) = (var_16 > 0L)
    let (var_31: bool) = (var_30 = false)
    if var_31 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_32: uint64) = method_5((var_1: (uint64 ref)))
    let (var_33: int64) = (var_2 * 8L)
    let (var_34: uint64) = (uint64 var_33)
    let (var_35: uint64) = (var_32 + var_34)
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: bool) = (var_9 = 1L)
    let (var_39: bool) = (var_38 = false)
    if var_39 then
        (failwith "The stride of the innermost dimension should always be 1.")
    else
        ()
    let (var_40: bool) = (var_17 > 0L)
    let (var_41: bool) = (var_40 = false)
    if var_41 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_42: uint64) = method_5((var_7: (uint64 ref)))
    let (var_43: int64) = (var_8 * 8L)
    let (var_44: uint64) = (uint64 var_43)
    let (var_45: uint64) = (var_42 + var_44)
    let (var_46: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_45)
    let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_46)
    let (var_48: uint64) = method_5((var_13: (uint64 ref)))
    let (var_49: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_48)
    let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_49)
    let (var_51: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSmatinvBatched(var_26, 8, var_37, 8, var_47, 8, var_50, var_22)
    if var_51 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_51)
and method_44((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): EnvStack35 =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    let (var_5: Env9) = method_36((var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
    let (var_6: (int64 ref)) = var_5.mem_0
    let (var_7: Env22) = var_5.mem_1
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    method_45((var_4: uint64), (var_9: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap17))
    EnvStack35((var_6: (int64 ref)), (var_8: (uint64 ref)))
and method_49((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (int64 ref)), (var_4: (uint64 ref)), (var_5: int64)): (int32 []) =
    let (var_6: (int64 ref)) = var_0.mem_6
    let (var_7: EnvHeap15) = var_0.mem_7
    let (var_8: ManagedCuda.BasicTypes.CUstream) = method_18((var_7: EnvHeap15))
    let (var_9: uint64) = method_5((var_4: (uint64 ref)))
    let (var_10: int64) = (var_5 * 4L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: (int32 [])) = Array.zeroCreate<int32> (System.Convert.ToInt32(var_2))
    let (var_14: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_15: int64) = var_14.AddrOfPinnedObject().ToInt64()
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: int64) = (var_2 * 4L)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_23: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.AsynchronousMemcpy_v2.cuMemcpyAsync(var_19, var_21, var_22, var_8)
    if var_23 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_23)
    var_14.Free()
    var_13
and method_51((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_4: uint64) = method_5((var_1: (uint64 ref)))
    method_52((var_4: uint64), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
and method_57((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64), (var_3: (int64 ref)), (var_4: (uint64 ref)), (var_5: int64), (var_6: int64), (var_7: int64)): (float32 []) =
    let (var_8: (int64 ref)) = var_0.mem_6
    let (var_9: EnvHeap15) = var_0.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap15))
    let (var_11: int64) = (var_2 * var_6)
    let (var_12: uint64) = method_5((var_4: (uint64 ref)))
    let (var_13: int64) = (var_5 * 4L)
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: uint64) = (var_12 + var_14)
    let (var_16: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_11))
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_16,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: int64) = (var_11 * 4L)
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_23)
    let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_26: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.AsynchronousMemcpy_v2.cuMemcpyAsync(var_22, var_24, var_25, var_10)
    if var_26 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_26)
    var_17.Free()
    var_16
and method_58((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_59((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.AppendLine("[|")
    let (var_13: int64) = method_60((var_8: System.Text.StringBuilder), (var_9: string), (var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_10: int64))
    let (var_14: int64) = 0L
    method_59((var_8: System.Text.StringBuilder), (var_14: int64))
    let (var_15: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_16: string) = var_8.ToString()
    System.Console.WriteLine(var_16)
and method_24((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_2: EnvHeap5) = var_0.mem_5
    let (var_3: (uint64 ref)) = var_2.mem_1
    let (var_4: uint64) = var_2.mem_2
    let (var_5: EnvStack2) = var_2.mem_0
    let (var_6: EnvStack4) = var_2.mem_3
    let (var_7: ResizeArray<Env3>) = var_6.mem_0
    let (var_9: (Env3 -> bool)) = method_2
    let (var_10: int32) = var_7.RemoveAll <| System.Predicate(var_9)
    let (var_12: (Env3 -> (Env3 -> int32))) = method_3
    let (var_13: System.Comparison<Env3>) = System.Comparison<Env3>(var_12)
    var_7.Sort(var_13)
    let (var_14: ResizeArray<Env1>) = var_5.mem_0
    var_14.Clear()
    let (var_15: int32) = var_7.get_Count()
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: int32) = 0
    let (var_18: uint64) = method_6((var_5: EnvStack2), (var_6: EnvStack4), (var_15: int32), (var_16: uint64), (var_17: int32))
    let (var_19: uint64) = method_5((var_3: (uint64 ref)))
    let (var_20: uint64) = (var_19 + var_4)
    let (var_21: uint64) = (var_20 - var_18)
    let (var_22: uint64) = (var_18 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_18)
    let (var_26: bool) = (var_21 > var_25)
    if var_26 then
        let (var_27: uint64) = (var_21 - var_25)
        var_14.Add((Env1(var_24, var_27)))
    else
        ()
and method_66((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack24 =
    let (var_6: Env9) = method_30((var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_7: (int64 ref)) = var_6.mem_0
    let (var_8: Env22) = var_6.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    method_67((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_7: (int64 ref)), (var_9: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack24((var_7: (int64 ref)), (var_9: (uint64 ref)))
and method_68((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: int64)): unit =
    let (var_7: bool) = (var_6 < 96L)
    if var_7 then
        let (var_8: int64) = (var_6 + 2L)
        let (var_9: bool) = (var_8 <= 96L)
        if var_9 then
            let (var_10: bool) = (var_6 >= 0L)
            let (var_11: bool) = (var_10 = false)
            if var_11 then
                (failwith "Lower boundary out of bounds.")
            else
                ()
            let (var_12: bool) = (var_8 > 0L)
            let (var_13: bool) = (var_12 = false)
            if var_13 then
                (failwith "Higher boundary out of bounds.")
            else
                ()
            let (var_14: int64) = (var_8 - var_6)
            let (var_15: int64) = (8L * var_6)
            let (var_16: EnvStack36) = method_69((var_4: (int64 ref)), (var_5: (uint64 ref)), (var_15: int64), (var_14: int64), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
            let (var_17: (int64 ref)) = var_16.mem_0
            let (var_18: (uint64 ref)) = var_16.mem_1
            let (var_19: int64) = var_16.mem_2
            let (var_20: uint64) = method_5((var_18: (uint64 ref)))
            let (var_21: uint64) = method_5((var_5: (uint64 ref)))
            let (var_22: int64) = (var_15 * 4L)
            let (var_23: uint64) = (uint64 var_22)
            let (var_24: uint64) = (var_21 + var_23)
            let (var_25: bool) = (var_14 = var_19)
            let (var_26: bool) = (var_25 = false)
            if var_26 then
                (failwith "The dimension of c and the outer dimension z needs to match.")
            else
                ()
            let (var_27: float32) = (float32 var_14)
            method_76((var_27: float32), (var_20: uint64), (var_19: int64), (var_24: uint64), (var_14: int64), (var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule))
        else
            ()
        method_68((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvHeap17), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_8: int64))
    else
        ()
and method_84((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: ManagedCuda.CudaBlas.CudaBlas) = var_4.mem_1
    let (var_7: (int64 ref)) = var_4.mem_6
    let (var_8: EnvHeap15) = var_4.mem_7
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    var_6.set_Stream(var_10)
    let (var_11: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_13: (float32 ref)) = (ref 1.000000f)
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: uint64) = method_5((var_1: (uint64 ref)))
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: (float32 ref)) = (ref 0.000000f)
    let (var_21: uint64) = method_5((var_3: (uint64 ref)))
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_9, var_11, var_12, 8, 8, 8, var_13, var_16, 8, var_19, 8, var_20, var_23, 8)
    if var_24 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_24)
and method_86((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_6: ManagedCuda.CudaBlas.CudaBlas) = var_4.mem_1
    let (var_7: (int64 ref)) = var_4.mem_6
    let (var_8: EnvHeap15) = var_4.mem_7
    let (var_9: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    var_6.set_Stream(var_10)
    let (var_11: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_12: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_13: (float32 ref)) = (ref 1.000000f)
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_16: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_15)
    let (var_17: (float32 ref)) = (ref -1.000000f)
    let (var_18: uint64) = method_5((var_1: (uint64 ref)))
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: uint64) = method_5((var_3: (uint64 ref)))
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgeam(var_9, var_11, var_12, 8, 8, var_13, var_16, 8, var_17, var_20, 8, var_23, 8)
    if var_24 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_24)
and method_88 ((var_0: Env12)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env16) = var_0.mem_1
    let (var_3: EnvHeap15) = var_2.mem_0
    let (var_4: int64) = (!var_1)
    let (var_5: int64) = (var_4 - 1L)
    var_1 := var_5
    let (var_6: int64) = (!var_1)
    let (var_7: bool) = (var_6 = 0L)
    if var_7 then
        let (var_8: ManagedCuda.CudaStream) = var_3.mem_2
        var_8.Dispose()
        let (var_9: ManagedCuda.CudaEvent) = var_3.mem_0
        var_9.Dispose()
        let (var_10: (bool ref)) = var_3.mem_1
        var_10 := false
    else
        ()
and method_82 ((var_0: Env9)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env22) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_2.mem_0
    let (var_4: int64) = (!var_1)
    let (var_5: int64) = (var_4 - 1L)
    var_1 := var_5
    let (var_6: int64) = (!var_1)
    let (var_7: bool) = (var_6 = 0L)
    if var_7 then
        var_3 := 0UL
    else
        ()
and method_4 ((var_1: (uint64 ref))) ((var_0: Env3)): int32 =
    let (var_2: Env22) = var_0.mem_0
    let (var_3: (uint64 ref)) = var_2.mem_0
    let (var_4: uint64) = var_0.mem_1
    let (var_5: uint64) = method_5((var_1: (uint64 ref)))
    let (var_6: uint64) = method_5((var_3: (uint64 ref)))
    let (var_7: bool) = (var_5 < var_6)
    if var_7 then
        -1
    else
        let (var_8: bool) = (var_5 = var_6)
        if var_8 then
            0
        else
            1
and method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64)): Env9 =
    let (var_3: uint64) = (uint64 var_2)
    let (var_4: uint64) = (var_3 + 256UL)
    let (var_5: uint64) = (var_4 - 1UL)
    let (var_6: uint64) = (var_5 &&& 18446744073709551360UL)
    let (var_7: Env22) = method_21((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_6: uint64))
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: (int64 ref)) = (ref 0L)
    let (var_10: EnvStack10) = var_0.mem_3
    method_25((var_9: (int64 ref)), (var_8: (uint64 ref)), (var_10: EnvStack10))
    (Env9(var_9, (Env22(var_8))))
and method_38((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule)): Env9 =
    let (var_2: int64) = 8L
    method_20((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: int64))
and method_39((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_40((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17))
and method_45((var_0: uint64), (var_1: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17)): unit =
    // Cuda join point
    // method_46((var_0: uint64), (var_1: uint64))
    let (var_4: ManagedCuda.CudaContext) = var_3.mem_0
    let (var_5: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_46", var_2, var_4)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_GridDimensions(var_6)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_5.set_BlockDimensions(var_7)
    let (var_8: (int64 ref)) = var_3.mem_6
    let (var_9: EnvHeap15) = var_3.mem_7
    let (var_10: ManagedCuda.BasicTypes.CUstream) = method_18((var_9: EnvHeap15))
    let (var_12: (System.Object [])) = [|var_0; var_1|]: (System.Object [])
    var_5.RunAsync(var_10, var_12)
and method_52((var_0: uint64), (var_1: EnvHeap17), (var_2: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_53((var_0: uint64), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_1: EnvHeap17))
and method_59((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_59((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_60((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): int64 =
    let (var_11: bool) = (var_6 < var_7)
    if var_11 then
        let (var_12: bool) = (var_10 < 1000L)
        if var_12 then
            let (var_13: bool) = (var_6 >= var_6)
            let (var_14: bool) = (var_13 = false)
            if var_14 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_15: int64) = 0L
            method_61((var_0: System.Text.StringBuilder), (var_15: int64))
            let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_17: int64) = method_62((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_3: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_19: int64) = (var_6 + 1L)
            method_64((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_17: int64), (var_19: int64))
        else
            let (var_21: int64) = 0L
            method_59((var_0: System.Text.StringBuilder), (var_21: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_67((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: (int64 ref)), (var_3: (uint64 ref)), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: ManagedCuda.CudaBlas.CudaBlas) = var_6.mem_1
    let (var_9: (int64 ref)) = var_6.mem_6
    let (var_10: EnvHeap15) = var_6.mem_7
    let (var_11: ManagedCuda.CudaBlas.CudaBlasHandle) = var_8.get_CublasHandle()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap15))
    var_8.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: uint64) = method_5((var_3: (uint64 ref)))
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: uint64) = method_5((var_1: (uint64 ref)))
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: (float32 ref)) = (ref 0.000000f)
    let (var_23: uint64) = method_5((var_5: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_11, var_13, var_14, 8, 96, 8, var_15, var_18, 8, var_21, 8, var_22, var_25, 8)
    if var_26 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_26)
and method_69((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: int64), (var_3: int64), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule)): EnvStack36 =
    let (var_6: bool) = (0L < var_3)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    if var_7 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_17: Env9) = method_19((var_3: int64), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    let (var_18: (int64 ref)) = var_17.mem_0
    let (var_19: Env22) = var_17.mem_1
    let (var_20: (uint64 ref)) = var_19.mem_0
    method_70((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: int64), (var_3: int64), (var_18: (int64 ref)), (var_20: (uint64 ref)), (var_4: EnvHeap17), (var_5: ManagedCuda.BasicTypes.CUmodule))
    EnvStack36((var_18: (int64 ref)), (var_20: (uint64 ref)), (var_3: int64))
and method_76((var_0: float32), (var_1: uint64), (var_2: int64), (var_3: uint64), (var_4: int64), (var_5: (int64 ref)), (var_6: (uint64 ref)), (var_7: EnvHeap17), (var_8: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_9: uint64) = method_5((var_6: (uint64 ref)))
    let (var_10: uint64) = method_5((var_6: (uint64 ref)))
    method_77((var_9: uint64), (var_0: float32), (var_10: uint64), (var_1: uint64), (var_2: int64), (var_3: uint64), (var_4: int64), (var_7: EnvHeap17), (var_8: ManagedCuda.BasicTypes.CUmodule))
and method_21((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: uint64)): Env22 =
    let (var_3: EnvHeap5) = var_0.mem_5
    let (var_4: (uint64 ref)) = var_3.mem_1
    let (var_5: uint64) = var_3.mem_2
    let (var_6: EnvStack4) = var_3.mem_3
    let (var_7: EnvStack2) = var_3.mem_0
    let (var_8: ResizeArray<Env1>) = var_7.mem_0
    let (var_9: int32) = var_8.get_Count()
    let (var_10: bool) = (var_9 > 0)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_12: Env1) = var_8.[0]
    let (var_13: uint64) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: bool) = (var_2 <= var_14)
    let (var_42: Env3) =
        if var_15 then
            let (var_16: uint64) = (var_13 + var_2)
            let (var_17: uint64) = (var_14 - var_2)
            var_8.[0] <- (Env1(var_16, var_17))
            let (var_18: (uint64 ref)) = (ref var_13)
            (Env3((Env22(var_18)), var_2))
        else
            let (var_20: (Env1 -> (Env1 -> int32))) = method_22
            let (var_21: System.Comparison<Env1>) = System.Comparison<Env1>(var_20)
            var_8.Sort(var_21)
            let (var_22: Env1) = var_8.[0]
            let (var_23: uint64) = var_22.mem_0
            let (var_24: uint64) = var_22.mem_1
            let (var_25: bool) = (var_2 <= var_24)
            if var_25 then
                let (var_26: uint64) = (var_23 + var_2)
                let (var_27: uint64) = (var_24 - var_2)
                var_8.[0] <- (Env1(var_26, var_27))
                let (var_28: (uint64 ref)) = (ref var_23)
                (Env3((Env22(var_28)), var_2))
            else
                method_24((var_0: EnvHeap17), (var_1: ManagedCuda.BasicTypes.CUmodule))
                let (var_30: (Env1 -> (Env1 -> int32))) = method_22
                let (var_31: System.Comparison<Env1>) = System.Comparison<Env1>(var_30)
                var_8.Sort(var_31)
                let (var_32: Env1) = var_8.[0]
                let (var_33: uint64) = var_32.mem_0
                let (var_34: uint64) = var_32.mem_1
                let (var_35: bool) = (var_2 <= var_34)
                if var_35 then
                    let (var_36: uint64) = (var_33 + var_2)
                    let (var_37: uint64) = (var_34 - var_2)
                    var_8.[0] <- (Env1(var_36, var_37))
                    let (var_38: (uint64 ref)) = (ref var_33)
                    (Env3((Env22(var_38)), var_2))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_43: Env22) = var_42.mem_0
    let (var_44: (uint64 ref)) = var_43.mem_0
    let (var_45: uint64) = var_42.mem_1
    let (var_46: ResizeArray<Env3>) = var_6.mem_0
    var_46.Add((Env3((Env22(var_44)), var_45)))
    (Env22(var_44))
and method_25((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: EnvStack10)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    let (var_5: ResizeArray<Env9>) = var_2.mem_0
    var_5.Add((Env9(var_0, (Env22(var_1)))))
and method_40((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: EnvHeap17)): unit =
    // Cuda join point
    // method_41((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_6: ManagedCuda.CudaContext) = var_5.mem_0
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_41", var_4, var_6)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (int64 ref)) = var_5.mem_6
    let (var_11: EnvHeap15) = var_5.mem_7
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_18((var_11: EnvHeap15))
    let (var_14: (System.Object [])) = [|var_0; var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_53((var_0: uint64), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: EnvHeap17)): unit =
    // Cuda join point
    // method_54((var_0: uint64))
    let (var_3: ManagedCuda.CudaContext) = var_2.mem_0
    let (var_4: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_54", var_1, var_3)
    let (var_5: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_4.set_GridDimensions(var_5)
    let (var_6: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_4.set_BlockDimensions(var_6)
    let (var_7: (int64 ref)) = var_2.mem_6
    let (var_8: EnvHeap15) = var_2.mem_7
    let (var_9: ManagedCuda.BasicTypes.CUstream) = method_18((var_8: EnvHeap15))
    let (var_11: (System.Object [])) = [|var_0|]: (System.Object [])
    var_4.RunAsync(var_9, var_11)
and method_61((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_61((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_62((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
    let (var_8: bool) = (var_4 < var_5)
    if var_8 then
        let (var_9: bool) = (var_7 < 1000L)
        if var_9 then
            let (var_10: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_11: bool) = (var_4 >= var_4)
            let (var_12: bool) = (var_11 = false)
            if var_12 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_13: float32) = var_1.[int32 var_2]
            let (var_14: string) = System.String.Format("{0}",var_13)
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
            let (var_16: string) = "; "
            let (var_17: int64) = (var_7 + 1L)
            let (var_18: int64) = (var_4 + 1L)
            method_63((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_64((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_7)
    if var_12 then
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: bool) = (var_11 >= var_6)
            let (var_15: bool) = (var_14 = false)
            if var_15 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_16: int64) = (var_11 - var_6)
            let (var_17: int64) = (var_16 * var_4)
            let (var_18: int64) = (var_3 + var_17)
            let (var_19: int64) = 0L
            method_61((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_62((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_11 + 1L)
            method_64((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_59((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_70((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: int64), (var_3: int64), (var_4: (int64 ref)), (var_5: (uint64 ref)), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule)): unit =
    let (var_8: uint64) = method_5((var_1: (uint64 ref)))
    let (var_9: int64) = (var_2 * 4L)
    let (var_10: uint64) = (uint64 var_9)
    let (var_11: uint64) = (var_8 + var_10)
    let (var_12: uint64) = method_5((var_5: (uint64 ref)))
    method_71((var_11: uint64), (var_3: int64), (var_12: uint64), (var_6: EnvHeap17), (var_7: ManagedCuda.BasicTypes.CUmodule))
and method_77((var_0: uint64), (var_1: float32), (var_2: uint64), (var_3: uint64), (var_4: int64), (var_5: uint64), (var_6: int64), (var_7: EnvHeap17), (var_8: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_78((var_0: uint64), (var_1: float32), (var_2: uint64), (var_3: uint64), (var_4: int64), (var_5: uint64), (var_6: int64), (var_8: ManagedCuda.BasicTypes.CUmodule), (var_7: EnvHeap17))
and method_22 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_23((var_2: uint64))
and method_63((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
    let (var_9: bool) = (var_8 < var_5)
    if var_9 then
        let (var_10: bool) = (var_7 < 1000L)
        if var_10 then
            let (var_11: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_12: bool) = (var_8 >= var_4)
            let (var_13: bool) = (var_12 = false)
            if var_13 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_14: int64) = (var_8 - var_4)
            let (var_15: int64) = (var_14 * var_3)
            let (var_16: int64) = (var_2 + var_15)
            let (var_17: float32) = var_1.[int32 var_16]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
            let (var_20: string) = "; "
            let (var_21: int64) = (var_7 + 1L)
            let (var_22: int64) = (var_8 + 1L)
            method_63((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
        else
            let (var_24: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_71((var_0: uint64), (var_1: int64), (var_2: uint64), (var_3: EnvHeap17), (var_4: ManagedCuda.BasicTypes.CUmodule)): unit =
    method_72((var_0: uint64), (var_1: int64), (var_2: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_3: EnvHeap17))
and method_78((var_0: uint64), (var_1: float32), (var_2: uint64), (var_3: uint64), (var_4: int64), (var_5: uint64), (var_6: int64), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvHeap17)): unit =
    // Cuda join point
    // method_79((var_0: uint64), (var_1: float32), (var_2: uint64), (var_3: uint64), (var_4: int64), (var_5: uint64), (var_6: int64))
    let (var_9: ManagedCuda.CudaContext) = var_8.mem_0
    let (var_10: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_79", var_7, var_9)
    let (var_11: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 8u, 1u)
    var_10.set_GridDimensions(var_11)
    let (var_12: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_10.set_BlockDimensions(var_12)
    let (var_13: (int64 ref)) = var_8.mem_6
    let (var_14: EnvHeap15) = var_8.mem_7
    let (var_15: ManagedCuda.BasicTypes.CUstream) = method_18((var_14: EnvHeap15))
    let (var_17: (System.Object [])) = [|var_0; var_1; var_2; var_3; var_4; var_5; var_6|]: (System.Object [])
    var_10.RunAsync(var_15, var_17)
and method_23 ((var_1: uint64)) ((var_0: Env1)): int32 =
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
and method_72((var_0: uint64), (var_1: int64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: EnvHeap17)): unit =
    // Cuda join point
    // method_73((var_0: uint64), (var_1: int64), (var_2: uint64))
    let (var_5: ManagedCuda.CudaContext) = var_4.mem_0
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_73", var_3, var_5)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 64u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 1u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (int64 ref)) = var_4.mem_6
    let (var_10: EnvHeap15) = var_4.mem_7
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_18((var_10: EnvHeap15))
    let (var_13: (System.Object [])) = [|var_0; var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
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
let (var_10: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
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
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_11; "\" -I\"C:/cub-1.7.4\" -I\""; var_10; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
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
System.Console.WriteLine(var_33)
let (var_34: EnvHeap0) = ({mem_0 = (var_1: ManagedCuda.CudaContext)} : EnvHeap0)
let (var_35: uint64) = 1073741824UL
let (var_36: ManagedCuda.CudaContext) = var_34.mem_0
let (var_37: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = var_36.AllocateMemory(var_37)
let (var_39: uint64) = uint64 var_38
let (var_40: (uint64 ref)) = (ref var_39)
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: EnvStack2) = EnvStack2((var_41: ResizeArray<Env1>))
let (var_43: ResizeArray<Env3>) = ResizeArray<Env3>()
let (var_44: EnvStack4) = EnvStack4((var_43: ResizeArray<Env3>))
let (var_45: EnvHeap5) = ({mem_0 = (var_42: EnvStack2); mem_1 = (var_40: (uint64 ref)); mem_2 = (var_35: uint64); mem_3 = (var_44: EnvStack4)} : EnvHeap5)
let (var_46: EnvHeap6) = ({mem_0 = (var_36: ManagedCuda.CudaContext); mem_1 = (var_45: EnvHeap5)} : EnvHeap6)
method_1((var_46: EnvHeap6), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_47: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_48: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_47)
let (var_49: ManagedCuda.CudaContext) = var_46.mem_0
let (var_50: EnvHeap5) = var_46.mem_1
let (var_51: EnvHeap7) = ({mem_0 = (var_49: ManagedCuda.CudaContext); mem_1 = (var_48: ManagedCuda.CudaRand.CudaRandDevice); mem_2 = (var_50: EnvHeap5)} : EnvHeap7)
let (var_52: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_53: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_54: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_52, var_53)
let (var_55: ManagedCuda.CudaContext) = var_51.mem_0
let (var_56: ManagedCuda.CudaRand.CudaRandDevice) = var_51.mem_1
let (var_57: EnvHeap5) = var_51.mem_2
let (var_58: EnvHeap8) = ({mem_0 = (var_55: ManagedCuda.CudaContext); mem_1 = (var_54: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_56: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_57: EnvHeap5)} : EnvHeap8)
let (var_65: ResizeArray<Env9>) = ResizeArray<Env9>()
let (var_66: EnvStack10) = EnvStack10((var_65: ResizeArray<Env9>))
let (var_67: ManagedCuda.CudaContext) = var_58.mem_0
let (var_68: ManagedCuda.CudaBlas.CudaBlas) = var_58.mem_1
let (var_69: ManagedCuda.CudaRand.CudaRandDevice) = var_58.mem_2
let (var_70: EnvHeap5) = var_58.mem_3
let (var_71: EnvHeap11) = ({mem_0 = (var_67: ManagedCuda.CudaContext); mem_1 = (var_68: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_69: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_66: EnvStack10); mem_4 = (var_70: EnvHeap5)} : EnvHeap11)
let (var_83: ResizeArray<Env12>) = ResizeArray<Env12>()
let (var_84: EnvStack13) = EnvStack13((var_83: ResizeArray<Env12>))
let (var_85: ManagedCuda.CudaContext) = var_71.mem_0
let (var_86: ManagedCuda.CudaBlas.CudaBlas) = var_71.mem_1
let (var_87: ManagedCuda.CudaRand.CudaRandDevice) = var_71.mem_2
let (var_88: EnvStack10) = var_71.mem_3
let (var_89: EnvHeap5) = var_71.mem_4
let (var_90: EnvHeap14) = ({mem_0 = (var_85: ManagedCuda.CudaContext); mem_1 = (var_86: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_87: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_88: EnvStack10); mem_4 = (var_84: EnvStack13); mem_5 = (var_89: EnvHeap5)} : EnvHeap14)
let (var_91: (bool ref)) = (ref true)
let (var_92: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_93: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_94: EnvHeap15) = ({mem_0 = (var_93: ManagedCuda.CudaEvent); mem_1 = (var_91: (bool ref)); mem_2 = (var_92: ManagedCuda.CudaStream)} : EnvHeap15)
let (var_95: Env12) = method_7((var_94: EnvHeap15), (var_90: EnvHeap14), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_96: (int64 ref)) = var_95.mem_0
let (var_97: Env16) = var_95.mem_1
let (var_98: EnvHeap15) = var_97.mem_0
let (var_99: ManagedCuda.CudaContext) = var_90.mem_0
let (var_100: ManagedCuda.CudaBlas.CudaBlas) = var_90.mem_1
let (var_101: ManagedCuda.CudaRand.CudaRandDevice) = var_90.mem_2
let (var_102: EnvStack10) = var_90.mem_3
let (var_103: EnvStack13) = var_90.mem_4
let (var_104: EnvHeap5) = var_90.mem_5
let (var_105: EnvHeap17) = ({mem_0 = (var_99: ManagedCuda.CudaContext); mem_1 = (var_100: ManagedCuda.CudaBlas.CudaBlas); mem_2 = (var_101: ManagedCuda.CudaRand.CudaRandDevice); mem_3 = (var_102: EnvStack10); mem_4 = (var_103: EnvStack13); mem_5 = (var_104: EnvHeap5); mem_6 = (var_96: (int64 ref)); mem_7 = (var_98: EnvHeap15)} : EnvHeap17)
let (var_106: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_107: Tuple18) = method_9((var_106: string))
let (var_108: Tuple19) = var_107.mem_0
let (var_109: int64) = var_108.mem_0
let (var_110: int64) = var_108.mem_1
let (var_111: int64) = var_108.mem_2
let (var_112: (uint8 [])) = var_107.mem_1
let (var_113: bool) = (10000L = var_109)
let (var_117: bool) =
    if var_113 then
        let (var_114: bool) = (28L = var_110)
        if var_114 then
            (28L = var_111)
        else
            false
    else
        false
let (var_118: bool) = (var_117 = false)
if var_118 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_119: int64) = var_112.LongLength
let (var_120: bool) = (var_119 > 0L)
let (var_121: bool) = (var_120 = false)
if var_121 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_122: bool) = (var_119 = 7840000L)
let (var_123: bool) = (var_122 = false)
if var_123 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_127: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_128: int64) = 0L
method_10((var_112: (uint8 [])), (var_127: (float32 [])), (var_128: int64))
let (var_129: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_130: Tuple20) = method_12((var_129: string))
let (var_131: int64) = var_130.mem_0
let (var_132: (uint8 [])) = var_130.mem_1
let (var_133: bool) = (10000L = var_131)
let (var_134: bool) = (var_133 = false)
if var_134 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_138: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_139: int64) = 0L
method_13((var_132: (uint8 [])), (var_138: (float32 [])), (var_139: int64))
let (var_140: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_141: Tuple18) = method_9((var_140: string))
let (var_142: Tuple19) = var_141.mem_0
let (var_143: int64) = var_142.mem_0
let (var_144: int64) = var_142.mem_1
let (var_145: int64) = var_142.mem_2
let (var_146: (uint8 [])) = var_141.mem_1
let (var_147: bool) = (60000L = var_143)
let (var_151: bool) =
    if var_147 then
        let (var_148: bool) = (28L = var_144)
        if var_148 then
            (28L = var_145)
        else
            false
    else
        false
let (var_152: bool) = (var_151 = false)
if var_152 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_153: int64) = var_146.LongLength
let (var_154: bool) = (var_153 > 0L)
let (var_155: bool) = (var_154 = false)
if var_155 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_156: bool) = (var_153 = 47040000L)
let (var_157: bool) = (var_156 = false)
if var_157 then
    (failwith "The product of the split dimension must equal to that of the previous one.")
else
    ()
let (var_161: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_162: int64) = 0L
method_15((var_146: (uint8 [])), (var_161: (float32 [])), (var_162: int64))
let (var_163: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_164: Tuple20) = method_12((var_163: string))
let (var_165: int64) = var_164.mem_0
let (var_166: (uint8 [])) = var_164.mem_1
let (var_167: bool) = (60000L = var_165)
let (var_168: bool) = (var_167 = false)
if var_168 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_172: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_173: int64) = 0L
method_16((var_166: (uint8 [])), (var_172: (float32 [])), (var_173: int64))
let (var_174: int64) = 10000L
let (var_175: int64) = 0L
let (var_176: int64) = 784L
let (var_177: int64) = 1L
let (var_178: Env21) = method_17((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_174: int64), (var_127: (float32 [])), (var_175: int64), (var_176: int64), (var_177: int64))
let (var_179: Env9) = var_178.mem_0
let (var_180: (int64 ref)) = var_179.mem_0
let (var_181: Env22) = var_179.mem_1
let (var_182: (uint64 ref)) = var_181.mem_0
let (var_183: int64) = 10000L
let (var_184: int64) = 0L
let (var_185: int64) = 10L
let (var_186: int64) = 1L
let (var_187: Env21) = method_17((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_183: int64), (var_138: (float32 [])), (var_184: int64), (var_185: int64), (var_186: int64))
let (var_188: Env9) = var_187.mem_0
let (var_189: (int64 ref)) = var_188.mem_0
let (var_190: Env22) = var_188.mem_1
let (var_191: (uint64 ref)) = var_190.mem_0
let (var_192: int64) = 60000L
let (var_193: int64) = 0L
let (var_194: int64) = 784L
let (var_195: int64) = 1L
let (var_196: Env21) = method_17((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_192: int64), (var_161: (float32 [])), (var_193: int64), (var_194: int64), (var_195: int64))
let (var_197: Env9) = var_196.mem_0
let (var_198: (int64 ref)) = var_197.mem_0
let (var_199: Env22) = var_197.mem_1
let (var_200: (uint64 ref)) = var_199.mem_0
let (var_201: int64) = 60000L
let (var_202: int64) = 0L
let (var_203: int64) = 10L
let (var_204: int64) = 1L
let (var_205: Env21) = method_17((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_201: int64), (var_172: (float32 [])), (var_202: int64), (var_203: int64), (var_204: int64))
let (var_206: Env9) = var_205.mem_0
let (var_207: (int64 ref)) = var_206.mem_0
let (var_208: Env22) = var_206.mem_1
let (var_209: (uint64 ref)) = var_208.mem_0
let (var_210: EnvStack23) = method_26((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_211: (int64 ref)) = var_210.mem_0
let (var_212: (uint64 ref)) = var_210.mem_1
let (var_213: EnvStack24) = method_29((var_198: (int64 ref)), (var_200: (uint64 ref)), (var_211: (int64 ref)), (var_212: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_214: (int64 ref)) = var_213.mem_0
let (var_215: (uint64 ref)) = var_213.mem_1
let (var_216: EnvStack25) = method_32((var_214: (int64 ref)), (var_215: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_217: (int64 ref)) = var_216.mem_0
let (var_218: (uint64 ref)) = var_216.mem_1
let (var_219: EnvStack26) = method_35((var_217: (int64 ref)), (var_218: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_220: (int64 ref)) = var_219.mem_0
let (var_221: (uint64 ref)) = var_219.mem_1
let (var_222: EnvStack25) = method_50((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_223: (int64 ref)) = var_222.mem_0
let (var_224: (uint64 ref)) = var_222.mem_1
let (var_225: int64) = 0L
let (var_226: int64) = 8L
let (var_227: int64) = 1L
let (var_228: int64) = 0L
let (var_229: int64) = 96L
let (var_230: int64) = 0L
let (var_231: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_214: (int64 ref)), (var_215: (uint64 ref)), (var_225: int64), (var_226: int64), (var_227: int64), (var_228: int64), (var_229: int64), (var_230: int64), (var_231: int64))
let (var_232: int64) = 0L
let (var_233: int64) = 8L
let (var_234: int64) = 1L
let (var_235: int64) = 0L
let (var_236: int64) = 8L
let (var_237: int64) = 0L
let (var_238: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_217: (int64 ref)), (var_218: (uint64 ref)), (var_232: int64), (var_233: int64), (var_234: int64), (var_235: int64), (var_236: int64), (var_237: int64), (var_238: int64))
System.Console.WriteLine("---")
let (var_239: int64) = 0L
method_65((var_223: (int64 ref)), (var_224: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_214: (int64 ref)), (var_215: (uint64 ref)), (var_239: int64))
let (var_240: int64) = 0L
let (var_241: int64) = 8L
let (var_242: int64) = 1L
let (var_243: int64) = 0L
let (var_244: int64) = 8L
let (var_245: int64) = 0L
let (var_246: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_220: (int64 ref)), (var_221: (uint64 ref)), (var_240: int64), (var_241: int64), (var_242: int64), (var_243: int64), (var_244: int64), (var_245: int64), (var_246: int64))
System.Console.WriteLine("///")
let (var_247: EnvStack25) = method_83((var_223: (int64 ref)), (var_224: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_248: (int64 ref)) = var_247.mem_0
let (var_249: (uint64 ref)) = var_247.mem_1
let (var_250: int64) = 0L
let (var_251: int64) = 8L
let (var_252: int64) = 1L
let (var_253: int64) = 0L
let (var_254: int64) = 8L
let (var_255: int64) = 0L
let (var_256: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_248: (int64 ref)), (var_249: (uint64 ref)), (var_250: int64), (var_251: int64), (var_252: int64), (var_253: int64), (var_254: int64), (var_255: int64), (var_256: int64))
System.Console.WriteLine("***")
let (var_257: int64) = 0L
let (var_258: int64) = 8L
let (var_259: int64) = 1L
let (var_260: int64) = 0L
let (var_261: int64) = 8L
let (var_262: int64) = 0L
let (var_263: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_223: (int64 ref)), (var_224: (uint64 ref)), (var_257: int64), (var_258: int64), (var_259: int64), (var_260: int64), (var_261: int64), (var_262: int64), (var_263: int64))
let (var_264: EnvStack25) = method_85((var_223: (int64 ref)), (var_224: (uint64 ref)), (var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_265: (int64 ref)) = var_264.mem_0
let (var_266: (uint64 ref)) = var_264.mem_1
let (var_267: int64) = 0L
let (var_268: int64) = 8L
let (var_269: int64) = 1L
let (var_270: int64) = 0L
let (var_271: int64) = 8L
let (var_272: int64) = 0L
let (var_273: int64) = 8L
method_56((var_105: EnvHeap17), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_265: (int64 ref)), (var_266: (uint64 ref)), (var_267: int64), (var_268: int64), (var_269: int64), (var_270: int64), (var_271: int64), (var_272: int64), (var_273: int64))
method_87((var_103: EnvStack13))
method_81((var_88: EnvStack10))
var_54.Dispose()
var_48.Dispose()
let (var_274: uint64) = method_5((var_40: (uint64 ref)))
let (var_275: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_274)
let (var_276: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_275)
var_49.FreeMemory(var_276)
var_40 := 0UL
var_1.Dispose()

