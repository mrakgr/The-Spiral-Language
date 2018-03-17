module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Tuple0 {
        long long int mem_0;
        long long int mem_1;
    };
    __device__ __forceinline__ Tuple0 make_Tuple0(long long int mem_0, long long int mem_1){
        Tuple0 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __global__ void method_24(long long int * var_0, long long int * var_1);
    __global__ void method_33(long long int * var_0, long long int * var_1, long long int * var_2);
    __global__ void method_49(long long int * var_0, long long int * var_1, long long int * var_2);
    __device__ char method_25(long long int * var_0);
    __device__ char method_26(long long int * var_0, long long int * var_1);
    __device__ char method_27(long long int * var_0, long long int * var_1);
    __device__ char method_28(long long int var_0, long long int * var_1, long long int * var_2);
    __device__ char method_50(long long int * var_0, long long int * var_1, long long int * var_2);
    __device__ char method_51(long long int * var_0, long long int * var_1, long long int * var_2);
    __device__ char method_52(long long int var_0, long long int * var_1, long long int * var_2, long long int * var_3);
    
    __global__ void method_24(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (10 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6[1];
        var_6[0] = var_5;
        while (method_25(var_6)) {
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
            long long int var_20 = 0;
            long long int var_21[1];
            long long int var_22[1];
            var_21[0] = var_19;
            var_22[0] = var_20;
            while (method_26(var_21, var_22)) {
                long long int var_24 = var_21[0];
                long long int var_25 = var_22[0];
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
                long long int var_35 = var_0[var_34];
                long long int var_36 = (var_35 + 1);
                long long int var_37 = (var_25 + var_36);
                long long int var_38 = (var_24 + 32);
                var_21[0] = var_38;
                var_22[0] = var_37;
            }
            long long int var_39 = var_21[0];
            long long int var_40 = var_22[0];
            __shared__ long long int var_41[310];
            long long int var_42[1];
            long long int var_43[1];
            var_42[0] = 32;
            var_43[0] = var_40;
            while (method_27(var_42, var_43)) {
                long long int var_45 = var_42[0];
                long long int var_46 = var_43[0];
                long long int var_47 = (var_45 / 2);
                long long int var_48 = threadIdx.y;
                char var_49 = (var_48 < var_45);
                char var_52;
                if (var_49) {
                    long long int var_50 = threadIdx.y;
                    var_52 = (var_50 >= var_47);
                } else {
                    var_52 = 0;
                }
                if (var_52) {
                    long long int var_53 = threadIdx.y;
                    char var_54 = (var_53 >= 1);
                    char var_56;
                    if (var_54) {
                        var_56 = (var_53 < 32);
                    } else {
                        var_56 = 0;
                    }
                    char var_57 = (var_56 == 0);
                    if (var_57) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_58 = (var_53 - 1);
                    long long int var_59 = (var_58 * 10);
                    long long int var_60 = threadIdx.x;
                    char var_61 = (var_60 >= 0);
                    char var_63;
                    if (var_61) {
                        var_63 = (var_60 < 10);
                    } else {
                        var_63 = 0;
                    }
                    char var_64 = (var_63 == 0);
                    if (var_64) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_65 = (var_59 + var_60);
                    var_41[var_65] = var_46;
                } else {
                }
                __syncthreads();
                long long int var_66 = threadIdx.y;
                char var_67 = (var_66 < var_47);
                long long int var_92;
                if (var_67) {
                    long long int var_68 = threadIdx.y;
                    long long int var_69 = (var_68 + var_47);
                    long long int var_70[1];
                    long long int var_71[1];
                    var_70[0] = var_69;
                    var_71[0] = var_46;
                    while (method_28(var_45, var_70, var_71)) {
                        long long int var_73 = var_70[0];
                        long long int var_74 = var_71[0];
                        char var_75 = (var_73 >= 1);
                        char var_77;
                        if (var_75) {
                            var_77 = (var_73 < 32);
                        } else {
                            var_77 = 0;
                        }
                        char var_78 = (var_77 == 0);
                        if (var_78) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_79 = (var_73 - 1);
                        long long int var_80 = (var_79 * 10);
                        long long int var_81 = threadIdx.x;
                        char var_82 = (var_81 >= 0);
                        char var_84;
                        if (var_82) {
                            var_84 = (var_81 < 10);
                        } else {
                            var_84 = 0;
                        }
                        char var_85 = (var_84 == 0);
                        if (var_85) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_86 = (var_80 + var_81);
                        long long int var_87 = var_41[var_86];
                        long long int var_88 = (var_74 + var_87);
                        long long int var_89 = (var_73 + var_47);
                        var_70[0] = var_89;
                        var_71[0] = var_88;
                    }
                    long long int var_90 = var_70[0];
                    var_92 = var_71[0];
                } else {
                    var_92 = var_46;
                }
                var_42[0] = var_47;
                var_43[0] = var_92;
            }
            long long int var_93 = var_42[0];
            long long int var_94 = var_43[0];
            long long int var_95 = threadIdx.y;
            char var_96 = (var_95 == 0);
            if (var_96) {
                long long int var_97 = var_1[var_8];
                long long int var_98 = (var_94 / 2);
                var_1[var_8] = var_98;
            } else {
            }
            long long int var_99 = (var_8 + 10);
            var_6[0] = var_99;
        }
        long long int var_100 = var_6[0];
    }
    __global__ void method_33(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_25(var_7)) {
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 10);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.y;
            long long int var_18 = blockIdx.y;
            long long int var_19 = (32 * var_18);
            long long int var_20 = (var_17 + var_19);
            long long int var_21 = 0;
            long long int var_22[1];
            long long int var_23[1];
            var_22[0] = var_20;
            var_23[0] = var_21;
            while (method_26(var_22, var_23)) {
                long long int var_25 = var_22[0];
                long long int var_26 = var_23[0];
                char var_27 = (var_25 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_25 < 128);
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
                if (var_10) {
                    var_33 = (var_9 < 10);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_31 + var_9);
                long long int var_36 = var_0[var_35];
                long long int var_37 = var_1[var_9];
                long long int var_38 = (var_36 + var_37);
                long long int var_39 = (var_26 + var_38);
                long long int var_40 = (var_25 + 32);
                var_22[0] = var_40;
                var_23[0] = var_39;
            }
            long long int var_41 = var_22[0];
            long long int var_42 = var_23[0];
            __shared__ long long int var_43[310];
            long long int var_44[1];
            long long int var_45[1];
            var_44[0] = 32;
            var_45[0] = var_42;
            while (method_27(var_44, var_45)) {
                long long int var_47 = var_44[0];
                long long int var_48 = var_45[0];
                long long int var_49 = (var_47 / 2);
                long long int var_50 = threadIdx.y;
                char var_51 = (var_50 < var_47);
                char var_54;
                if (var_51) {
                    long long int var_52 = threadIdx.y;
                    var_54 = (var_52 >= var_49);
                } else {
                    var_54 = 0;
                }
                if (var_54) {
                    long long int var_55 = threadIdx.y;
                    char var_56 = (var_55 >= 1);
                    char var_58;
                    if (var_56) {
                        var_58 = (var_55 < 32);
                    } else {
                        var_58 = 0;
                    }
                    char var_59 = (var_58 == 0);
                    if (var_59) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_60 = (var_55 - 1);
                    long long int var_61 = (var_60 * 10);
                    long long int var_62 = threadIdx.x;
                    char var_63 = (var_62 >= 0);
                    char var_65;
                    if (var_63) {
                        var_65 = (var_62 < 10);
                    } else {
                        var_65 = 0;
                    }
                    char var_66 = (var_65 == 0);
                    if (var_66) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_67 = (var_61 + var_62);
                    var_43[var_67] = var_48;
                } else {
                }
                __syncthreads();
                long long int var_68 = threadIdx.y;
                char var_69 = (var_68 < var_49);
                long long int var_94;
                if (var_69) {
                    long long int var_70 = threadIdx.y;
                    long long int var_71 = (var_70 + var_49);
                    long long int var_72[1];
                    long long int var_73[1];
                    var_72[0] = var_71;
                    var_73[0] = var_48;
                    while (method_28(var_47, var_72, var_73)) {
                        long long int var_75 = var_72[0];
                        long long int var_76 = var_73[0];
                        char var_77 = (var_75 >= 1);
                        char var_79;
                        if (var_77) {
                            var_79 = (var_75 < 32);
                        } else {
                            var_79 = 0;
                        }
                        char var_80 = (var_79 == 0);
                        if (var_80) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_81 = (var_75 - 1);
                        long long int var_82 = (var_81 * 10);
                        long long int var_83 = threadIdx.x;
                        char var_84 = (var_83 >= 0);
                        char var_86;
                        if (var_84) {
                            var_86 = (var_83 < 10);
                        } else {
                            var_86 = 0;
                        }
                        char var_87 = (var_86 == 0);
                        if (var_87) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_88 = (var_82 + var_83);
                        long long int var_89 = var_43[var_88];
                        long long int var_90 = (var_76 + var_89);
                        long long int var_91 = (var_75 + var_49);
                        var_72[0] = var_91;
                        var_73[0] = var_90;
                    }
                    long long int var_92 = var_72[0];
                    var_94 = var_73[0];
                } else {
                    var_94 = var_48;
                }
                var_44[0] = var_49;
                var_45[0] = var_94;
            }
            long long int var_95 = var_44[0];
            long long int var_96 = var_45[0];
            long long int var_97 = threadIdx.y;
            char var_98 = (var_97 == 0);
            if (var_98) {
                long long int var_99 = var_2[var_9];
                long long int var_100 = (var_96 / 2);
                var_2[var_9] = var_100;
            } else {
            }
            long long int var_101 = (var_9 + 10);
            var_7[0] = var_101;
        }
        long long int var_102 = var_7[0];
    }
    __global__ void method_49(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (10 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_25(var_7)) {
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
            char var_15;
            if (var_10) {
                var_15 = (var_9 < 10);
            } else {
                var_15 = 0;
            }
            char var_16 = (var_15 == 0);
            if (var_16) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_17 = threadIdx.y;
            long long int var_18 = blockIdx.y;
            long long int var_19 = (32 * var_18);
            long long int var_20 = (var_17 + var_19);
            long long int var_21 = -555;
            long long int var_22 = -1;
            long long int var_23[1];
            long long int var_24[1];
            long long int var_25[1];
            var_23[0] = var_20;
            var_24[0] = var_21;
            var_25[0] = var_22;
            while (method_50(var_23, var_24, var_25)) {
                long long int var_27 = var_23[0];
                long long int var_28 = var_24[0];
                long long int var_29 = var_25[0];
                char var_30 = (var_27 >= 0);
                char var_32;
                if (var_30) {
                    var_32 = (var_27 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_27 * 10);
                char var_36;
                if (var_10) {
                    var_36 = (var_9 < 10);
                } else {
                    var_36 = 0;
                }
                char var_37 = (var_36 == 0);
                if (var_37) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_38 = (var_34 + var_9);
                long long int var_39 = var_0[var_38];
                char var_40 = (var_28 > var_39);
                Tuple0 var_41;
                if (var_40) {
                    var_41 = make_Tuple0(var_28, var_29);
                } else {
                    var_41 = make_Tuple0(var_39, var_27);
                }
                long long int var_42 = var_41.mem_0;
                long long int var_43 = var_41.mem_1;
                long long int var_44 = (var_27 + 32);
                var_23[0] = var_44;
                var_24[0] = var_42;
                var_25[0] = var_43;
            }
            long long int var_45 = var_23[0];
            long long int var_46 = var_24[0];
            long long int var_47 = var_25[0];
            __shared__ long long int var_48[310];
            __shared__ long long int var_49[310];
            long long int var_50[1];
            long long int var_51[1];
            long long int var_52[1];
            var_50[0] = 32;
            var_51[0] = var_46;
            var_52[0] = var_47;
            while (method_51(var_50, var_51, var_52)) {
                long long int var_54 = var_50[0];
                long long int var_55 = var_51[0];
                long long int var_56 = var_52[0];
                long long int var_57 = (var_54 / 2);
                long long int var_58 = threadIdx.y;
                char var_59 = (var_58 < var_54);
                char var_62;
                if (var_59) {
                    long long int var_60 = threadIdx.y;
                    var_62 = (var_60 >= var_57);
                } else {
                    var_62 = 0;
                }
                if (var_62) {
                    long long int var_63 = threadIdx.y;
                    char var_64 = (var_63 >= 1);
                    char var_66;
                    if (var_64) {
                        var_66 = (var_63 < 32);
                    } else {
                        var_66 = 0;
                    }
                    char var_67 = (var_66 == 0);
                    if (var_67) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_68 = (var_63 - 1);
                    long long int var_69 = (var_68 * 10);
                    long long int var_70 = threadIdx.x;
                    char var_71 = (var_70 >= 0);
                    char var_73;
                    if (var_71) {
                        var_73 = (var_70 < 10);
                    } else {
                        var_73 = 0;
                    }
                    char var_74 = (var_73 == 0);
                    if (var_74) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_75 = (var_69 + var_70);
                    var_48[var_75] = var_55;
                    var_49[var_75] = var_56;
                } else {
                }
                __syncthreads();
                long long int var_76 = threadIdx.y;
                char var_77 = (var_76 < var_57);
                Tuple0 var_109;
                if (var_77) {
                    long long int var_78 = threadIdx.y;
                    long long int var_79 = (var_78 + var_57);
                    long long int var_80[1];
                    long long int var_81[1];
                    long long int var_82[1];
                    var_80[0] = var_79;
                    var_81[0] = var_55;
                    var_82[0] = var_56;
                    while (method_52(var_54, var_80, var_81, var_82)) {
                        long long int var_84 = var_80[0];
                        long long int var_85 = var_81[0];
                        long long int var_86 = var_82[0];
                        char var_87 = (var_84 >= 1);
                        char var_89;
                        if (var_87) {
                            var_89 = (var_84 < 32);
                        } else {
                            var_89 = 0;
                        }
                        char var_90 = (var_89 == 0);
                        if (var_90) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_91 = (var_84 - 1);
                        long long int var_92 = (var_91 * 10);
                        long long int var_93 = threadIdx.x;
                        char var_94 = (var_93 >= 0);
                        char var_96;
                        if (var_94) {
                            var_96 = (var_93 < 10);
                        } else {
                            var_96 = 0;
                        }
                        char var_97 = (var_96 == 0);
                        if (var_97) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_98 = (var_92 + var_93);
                        long long int var_99 = var_48[var_98];
                        long long int var_100 = var_49[var_98];
                        char var_101 = (var_85 > var_99);
                        Tuple0 var_102;
                        if (var_101) {
                            var_102 = make_Tuple0(var_85, var_86);
                        } else {
                            var_102 = make_Tuple0(var_99, var_100);
                        }
                        long long int var_103 = var_102.mem_0;
                        long long int var_104 = var_102.mem_1;
                        long long int var_105 = (var_84 + var_57);
                        var_80[0] = var_105;
                        var_81[0] = var_103;
                        var_82[0] = var_104;
                    }
                    long long int var_106 = var_80[0];
                    long long int var_107 = var_81[0];
                    long long int var_108 = var_82[0];
                    var_109 = make_Tuple0(var_107, var_108);
                } else {
                    var_109 = make_Tuple0(var_55, var_56);
                }
                long long int var_110 = var_109.mem_0;
                long long int var_111 = var_109.mem_1;
                var_50[0] = var_57;
                var_51[0] = var_110;
                var_52[0] = var_111;
            }
            long long int var_112 = var_50[0];
            long long int var_113 = var_51[0];
            long long int var_114 = var_52[0];
            long long int var_115 = threadIdx.y;
            char var_116 = (var_115 == 0);
            if (var_116) {
                long long int var_117 = var_1[var_9];
                long long int var_118 = var_2[var_9];
                var_1[var_9] = var_113;
                var_2[var_9] = var_114;
            } else {
            }
            long long int var_119 = (var_9 + 10);
            var_7[0] = var_119;
        }
        long long int var_120 = var_7[0];
    }
    __device__ char method_25(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 10);
    }
    __device__ char method_26(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 128);
    }
    __device__ char method_27(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 >= 2);
    }
    __device__ char method_28(long long int var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = var_1[0];
        long long int var_4 = var_2[0];
        return (var_3 < var_0);
    }
    __device__ char method_50(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = var_0[0];
        long long int var_4 = var_1[0];
        long long int var_5 = var_2[0];
        return (var_3 < 128);
    }
    __device__ char method_51(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = var_0[0];
        long long int var_4 = var_1[0];
        long long int var_5 = var_2[0];
        return (var_3 >= 2);
    }
    __device__ char method_52(long long int var_0, long long int * var_1, long long int * var_2, long long int * var_3) {
        long long int var_4 = var_1[0];
        long long int var_5 = var_2[0];
        long long int var_6 = var_3[0];
        return (var_4 < var_0);
    }
}
"""

type Env0 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env1 =
    struct
    val mem_0: Env7
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env7
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env4
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env4 =
    struct
    val mem_0: (bool ref)
    val mem_1: ManagedCuda.CudaStream
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env5 =
    struct
    val mem_0: Env2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack6 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env7
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env7 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack8 =
    struct
    val mem_0: (int64 ref)
    val mem_1: Env7
    val mem_2: (int64 ref)
    val mem_3: Env7
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvHeap9 =
    {
    mem_0: (uint64 ref)
    mem_1: uint64
    mem_2: ResizeArray<Env0>
    mem_3: ResizeArray<Env1>
    }
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>)): unit =
    let (var_5: (Env1 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env1 -> (Env1 -> int32))) = method_3
    let (var_9: System.Comparison<Env1>) = System.Comparison<Env1>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: uint64) = method_5((var_1: (uint64 ref)))
    let (var_12: int32) = 0
    let (var_13: uint64) = method_6((var_0: ResizeArray<Env0>), (var_3: ResizeArray<Env1>), (var_10: int32), (var_11: uint64), (var_12: int32))
    let (var_14: uint64) = method_5((var_1: (uint64 ref)))
    let (var_15: uint64) = (var_14 + var_2)
    let (var_16: uint64) = (var_15 - var_13)
    let (var_17: uint64) = (var_13 + 256UL)
    let (var_18: uint64) = (var_17 - 1UL)
    let (var_19: uint64) = (var_18 &&& 18446744073709551360UL)
    let (var_20: uint64) = (var_19 - var_13)
    let (var_21: bool) = (var_16 > var_20)
    if var_21 then
        let (var_22: uint64) = (var_16 - var_20)
        var_0.Add((Env0(var_19, var_22)))
    else
        ()
and method_7((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule)): Env3 =
    let (var_12: (int64 ref)) = (ref 0L)
    method_8((var_12: (int64 ref)), (var_0: (bool ref)), (var_1: ManagedCuda.CudaStream), (var_10: ResizeArray<Env3>))
    (Env3(var_12, (Env4(var_0, var_1))))
and method_9((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 128L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: int64) = (var_1 * 10L)
        let (var_6: int64) = 0L
        method_10((var_0: (int64 [])), (var_5: int64), (var_6: int64))
        let (var_7: int64) = (var_1 + 1L)
        method_9((var_0: (int64 [])), (var_7: int64))
    else
        ()
and method_11((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 10L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        var_0.[int32 var_1] <- 10L
        let (var_5: int64) = (var_1 + 1L)
        method_11((var_0: (int64 [])), (var_5: int64))
    else
        ()
and method_12((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64), (var_13: (int64 [])), (var_14: int64), (var_15: int64), (var_16: int64)): Env5 =
    let (var_17: int64) = (var_12 * var_15)
    let (var_18: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_19: int64) = var_18.AddrOfPinnedObject().ToInt64()
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: int64) = (var_14 * 8L)
    let (var_22: uint64) = (uint64 var_21)
    let (var_23: uint64) = (var_22 + var_20)
    let (var_24: Env2) = method_13((var_17: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_25: (int64 ref)) = var_24.mem_0
    let (var_26: Env7) = var_24.mem_1
    let (var_27: (uint64 ref)) = var_26.mem_0
    let (var_28: uint64) = method_5((var_27: (uint64 ref)))
    let (var_29: int64) = (var_17 * 8L)
    let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
    let (var_32: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_32)
    let (var_34: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
    let (var_35: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_31, var_33, var_34)
    if var_35 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_35)
    var_18.Free()
    (Env5((Env2(var_25, var_26))))
and method_19((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64), (var_13: (int64 [])), (var_14: int64), (var_15: int64)): Env5 =
    let (var_16: int64) = (var_12 * var_15)
    let (var_17: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_18: int64) = var_17.AddrOfPinnedObject().ToInt64()
    let (var_19: uint64) = (uint64 var_18)
    let (var_20: int64) = (var_14 * 8L)
    let (var_21: uint64) = (uint64 var_20)
    let (var_22: uint64) = (var_21 + var_19)
    let (var_23: Env2) = method_13((var_16: int64), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4))
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: Env7) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: int64) = (var_16 * 8L)
    let (var_29: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_30: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_29)
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_28)
    let (var_34: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_30, var_32, var_33)
    if var_34 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_34)
    var_17.Free()
    (Env5((Env2(var_24, var_25))))
and method_20((var_0: Env2), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): EnvStack6 =
    let (var_15: Env2) = method_21((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4))
    let (var_16: (int64 ref)) = var_15.mem_0
    let (var_17: Env7) = var_15.mem_1
    method_22((var_0: Env2), (var_16: (int64 ref)), (var_17: Env7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_11: (int64 ref)), (var_12: Env4))
    EnvStack6((var_16: (int64 ref)), (var_17: Env7))
and method_30((var_0: Env2), (var_1: Env2), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4)): EnvStack6 =
    let (var_16: Env2) = method_21((var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_12: (int64 ref)), (var_13: Env4))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env7) = var_16.mem_1
    method_31((var_0: Env2), (var_1: Env2), (var_17: (int64 ref)), (var_18: Env7), (var_11: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaBlas.CudaBlas), (var_3: ManagedCuda.CudaRand.CudaRandDevice), (var_4: (uint64 ref)), (var_5: uint64), (var_6: ResizeArray<Env0>), (var_7: ResizeArray<Env1>), (var_8: ManagedCuda.CudaContext), (var_9: ResizeArray<Env2>), (var_10: ResizeArray<Env3>), (var_12: (int64 ref)), (var_13: Env4))
    EnvStack6((var_17: (int64 ref)), (var_18: Env7))
and method_34((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: Env2), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64)): unit =
    let (var_20: int64) = (var_17 - var_16)
    let (var_21: int64) = (var_19 - var_18)
    let (var_22: int64) = (var_20 * var_21)
    let (var_23: bool) = (var_22 > 0L)
    let (var_24: bool) = (var_23 = false)
    if var_24 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_25: int64) = (var_21 * var_15)
    let (var_26: bool) = (var_14 = var_25)
    let (var_27: bool) = (var_26 = false)
    if var_27 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_28: int64) = (var_20 * var_14)
    let (var_29: (int64 [])) = method_35((var_20: int64), (var_12: Env2), (var_13: int64), (var_14: int64), (var_15: int64))
    let (var_30: int64) = 0L
    method_36((var_29: (int64 [])), (var_30: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64))
and method_43((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: (int64 ref)), (var_13: Env7), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64)): unit =
    let (var_18: int64) = (var_17 - var_16)
    let (var_19: bool) = (var_18 > 0L)
    let (var_20: bool) = (var_19 = false)
    if var_20 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_21: (int64 [])) = method_44((var_18: int64), (var_12: (int64 ref)), (var_13: Env7), (var_14: int64), (var_15: int64))
    let (var_22: int64) = 0L
    method_45((var_21: (int64 [])), (var_22: int64), (var_15: int64), (var_16: int64), (var_17: int64))
and method_46((var_0: Env2), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): EnvStack8 =
    let (var_13: Env2) = method_21((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4))
    let (var_14: (int64 ref)) = var_13.mem_0
    let (var_15: Env7) = var_13.mem_1
    let (var_16: Env2) = method_21((var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4))
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: Env7) = var_16.mem_1
    method_47((var_0: Env2), (var_14: (int64 ref)), (var_15: Env7), (var_17: (int64 ref)), (var_18: Env7), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_11: (int64 ref)), (var_12: Env4))
    EnvStack8((var_14: (int64 ref)), (var_15: Env7), (var_17: (int64 ref)), (var_18: Env7))
and method_53((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: (int64 ref)), (var_13: Env7), (var_14: int64), (var_15: int64), (var_16: (int64 ref)), (var_17: Env7), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64)): unit =
    let (var_22: int64) = (var_21 - var_20)
    let (var_23: bool) = (var_22 > 0L)
    let (var_24: bool) = (var_23 = false)
    if var_24 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_25: (int64 [])) = method_44((var_22: int64), (var_12: (int64 ref)), (var_13: Env7), (var_14: int64), (var_15: int64))
    let (var_26: (int64 [])) = method_44((var_22: int64), (var_16: (int64 ref)), (var_17: Env7), (var_18: int64), (var_19: int64))
    let (var_27: int64) = 0L
    let (var_28: int64) = 0L
    method_54((var_25: (int64 [])), (var_27: int64), (var_15: int64), (var_26: (int64 [])), (var_28: int64), (var_19: int64), (var_20: int64), (var_21: int64))
and method_57((var_0: ResizeArray<Env3>)): unit =
    let (var_2: (Env3 -> unit)) = method_58
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_59((var_0: ResizeArray<Env2>)): unit =
    let (var_2: (Env2 -> unit)) = method_60
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2 ((var_0: Env1)): bool =
    let (var_1: Env7) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: Env7) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    method_4((var_3: (uint64 ref)))
and method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env1) = var_1.[var_4]
        let (var_7: Env7) = var_6.mem_0
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
            var_0.Add((Env0(var_17, var_20)))
        else
            ()
        let (var_21: uint64) = (var_13 + var_8)
        let (var_22: int32) = (var_4 + 1)
        method_6((var_0: ResizeArray<Env0>), (var_1: ResizeArray<Env1>), (var_2: int32), (var_21: uint64), (var_22: int32))
    else
        var_3
and method_8((var_0: (int64 ref)), (var_1: (bool ref)), (var_2: ManagedCuda.CudaStream), (var_3: ResizeArray<Env3>)): unit =
    let (var_4: int64) = (!var_0)
    let (var_5: int64) = (var_4 + 1L)
    var_0 := var_5
    var_3.Add((Env3(var_0, (Env4(var_1, var_2)))))
and method_10((var_0: (int64 [])), (var_1: int64), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 10L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_1 + var_2)
        var_0.[int32 var_6] <- var_2
        let (var_7: int64) = (var_2 + 1L)
        method_10((var_0: (int64 [])), (var_1: int64), (var_7: int64))
    else
        ()
and method_13((var_0: int64), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4)): Env2 =
    let (var_13: int64) = (var_0 * 8L)
    let (var_14: EnvHeap9) = ({mem_0 = (var_3: (uint64 ref)); mem_1 = (var_4: uint64); mem_2 = (var_5: ResizeArray<Env0>); mem_3 = (var_6: ResizeArray<Env1>)} : EnvHeap9)
    method_14((var_14: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_13: int64))
and method_21((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4)): Env2 =
    let (var_12: int64) = 80L
    let (var_13: EnvHeap9) = ({mem_0 = (var_2: (uint64 ref)); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env0>); mem_3 = (var_5: ResizeArray<Env1>)} : EnvHeap9)
    method_14((var_13: EnvHeap9), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: (uint64 ref)), (var_3: uint64), (var_4: ResizeArray<Env0>), (var_5: ResizeArray<Env1>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<Env2>), (var_8: ResizeArray<Env3>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: (int64 ref)), (var_11: Env4), (var_12: int64))
and method_22((var_0: Env2), (var_1: (int64 ref)), (var_2: Env7), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: ManagedCuda.CudaRand.CudaRandDevice), (var_6: (uint64 ref)), (var_7: uint64), (var_8: ResizeArray<Env0>), (var_9: ResizeArray<Env1>), (var_10: ManagedCuda.CudaContext), (var_11: ResizeArray<Env2>), (var_12: ResizeArray<Env3>), (var_13: (int64 ref)), (var_14: Env4)): unit =
    let (var_15: (int64 ref)) = var_0.mem_0
    let (var_16: Env7) = var_0.mem_1
    let (var_17: (uint64 ref)) = var_16.mem_0
    let (var_18: uint64) = method_5((var_17: (uint64 ref)))
    let (var_19: (uint64 ref)) = var_2.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    method_23((var_10: ManagedCuda.CudaContext), (var_18: uint64), (var_20: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_13: (int64 ref)), (var_14: Env4))
and method_31((var_0: Env2), (var_1: Env2), (var_2: (int64 ref)), (var_3: Env7), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaRand.CudaRandDevice), (var_7: (uint64 ref)), (var_8: uint64), (var_9: ResizeArray<Env0>), (var_10: ResizeArray<Env1>), (var_11: ManagedCuda.CudaContext), (var_12: ResizeArray<Env2>), (var_13: ResizeArray<Env3>), (var_14: (int64 ref)), (var_15: Env4)): unit =
    let (var_16: (int64 ref)) = var_0.mem_0
    let (var_17: Env7) = var_0.mem_1
    let (var_18: (uint64 ref)) = var_17.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: (int64 ref)) = var_1.mem_0
    let (var_21: Env7) = var_1.mem_1
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_5((var_22: (uint64 ref)))
    let (var_24: (uint64 ref)) = var_3.mem_0
    let (var_25: uint64) = method_5((var_24: (uint64 ref)))
    method_32((var_11: ManagedCuda.CudaContext), (var_19: uint64), (var_23: uint64), (var_25: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_14: (int64 ref)), (var_15: Env4))
and method_35((var_0: int64), (var_1: Env2), (var_2: int64), (var_3: int64), (var_4: int64)): (int64 []) =
    let (var_5: int64) = (var_0 * var_3)
    let (var_6: (int64 ref)) = var_1.mem_0
    let (var_7: Env7) = var_1.mem_1
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: int64) = (var_2 * 8L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_5))
    let (var_14: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_15: int64) = var_14.AddrOfPinnedObject().ToInt64()
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: int64) = (var_5 * 8L)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_23: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_19, var_21, var_22)
    if var_23 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_23)
    var_14.Free()
    var_13
and method_36((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_37((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.AppendLine("[|")
    let (var_13: int64) = method_38((var_8: System.Text.StringBuilder), (var_9: string), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_10: int64))
    let (var_14: int64) = 0L
    method_37((var_8: System.Text.StringBuilder), (var_14: int64))
    let (var_15: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_16: string) = var_8.ToString()
    let (var_17: string) = System.String.Format("{0}",var_16)
    System.Console.WriteLine(var_17)
and method_44((var_0: int64), (var_1: (int64 ref)), (var_2: Env7), (var_3: int64), (var_4: int64)): (int64 []) =
    let (var_5: int64) = (var_0 * var_4)
    let (var_6: (uint64 ref)) = var_2.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: int64) = (var_3 * 8L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_5))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_5 * 8L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_45((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64)): unit =
    let (var_5: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_6: string) = ""
    let (var_7: int64) = 0L
    let (var_8: int64) = 0L
    method_37((var_5: System.Text.StringBuilder), (var_8: int64))
    let (var_9: System.Text.StringBuilder) = var_5.Append("[|")
    let (var_10: int64) = method_40((var_5: System.Text.StringBuilder), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_6: string), (var_7: int64))
    let (var_11: System.Text.StringBuilder) = var_5.AppendLine("|]")
    let (var_12: string) = var_5.ToString()
    let (var_13: string) = System.String.Format("{0}",var_12)
    System.Console.WriteLine(var_13)
and method_47((var_0: Env2), (var_1: (int64 ref)), (var_2: Env7), (var_3: (int64 ref)), (var_4: Env7), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: ManagedCuda.CudaRand.CudaRandDevice), (var_8: (uint64 ref)), (var_9: uint64), (var_10: ResizeArray<Env0>), (var_11: ResizeArray<Env1>), (var_12: ManagedCuda.CudaContext), (var_13: ResizeArray<Env2>), (var_14: ResizeArray<Env3>), (var_15: (int64 ref)), (var_16: Env4)): unit =
    let (var_17: (int64 ref)) = var_0.mem_0
    let (var_18: Env7) = var_0.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: (uint64 ref)) = var_2.mem_0
    let (var_22: uint64) = method_5((var_21: (uint64 ref)))
    let (var_23: (uint64 ref)) = var_4.mem_0
    let (var_24: uint64) = method_5((var_23: (uint64 ref)))
    method_48((var_12: ManagedCuda.CudaContext), (var_20: uint64), (var_22: uint64), (var_24: uint64), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_15: (int64 ref)), (var_16: Env4))
and method_54((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: (int64 [])), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_37((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.Append("[|")
    let (var_13: int64) = method_55((var_8: System.Text.StringBuilder), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: (int64 [])), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_9: string), (var_10: int64))
    let (var_14: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_15: string) = var_8.ToString()
    let (var_16: string) = System.String.Format("{0}",var_15)
    System.Console.WriteLine(var_16)
and method_58 ((var_0: Env3)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env4) = var_0.mem_1
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
and method_60 ((var_0: Env2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: Env7) = var_0.mem_1
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
and method_4 ((var_1: (uint64 ref))) ((var_0: Env1)): int32 =
    let (var_2: Env7) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: (uint64 ref)) = var_2.mem_0
    let (var_5: uint64) = method_5((var_1: (uint64 ref)))
    let (var_6: uint64) = method_5((var_4: (uint64 ref)))
    let (var_7: bool) = (var_5 < var_6)
    if var_7 then
        -1
    else
        let (var_8: bool) = (var_5 = var_6)
        if var_8 then
            0
        else
            1
and method_14((var_0: EnvHeap9), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: (uint64 ref)), (var_4: uint64), (var_5: ResizeArray<Env0>), (var_6: ResizeArray<Env1>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<Env2>), (var_9: ResizeArray<Env3>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: (int64 ref)), (var_12: Env4), (var_13: int64)): Env2 =
    let (var_14: (uint64 ref)) = var_0.mem_0
    let (var_15: uint64) = var_0.mem_1
    let (var_16: ResizeArray<Env0>) = var_0.mem_2
    let (var_17: ResizeArray<Env1>) = var_0.mem_3
    let (var_18: uint64) = (uint64 var_13)
    let (var_19: uint64) = (var_18 + 256UL)
    let (var_20: uint64) = (var_19 - 1UL)
    let (var_21: uint64) = (var_20 &&& 18446744073709551360UL)
    let (var_22: Env7) = method_15((var_16: ResizeArray<Env0>), (var_14: (uint64 ref)), (var_15: uint64), (var_17: ResizeArray<Env1>), (var_21: uint64))
    let (var_23: (uint64 ref)) = var_22.mem_0
    let (var_24: (int64 ref)) = (ref 0L)
    method_18((var_24: (int64 ref)), (var_23: (uint64 ref)), (var_8: ResizeArray<Env2>))
    (Env2(var_24, (Env7(var_23))))
and method_23((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: (int64 ref)), (var_5: Env4)): unit =
    // Cuda join point
    // method_24((var_1: uint64), (var_2: uint64))
    let (var_6: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_3, var_0)
    let (var_7: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_6.set_GridDimensions(var_7)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_6.set_BlockDimensions(var_8)
    let (var_9: (bool ref)) = var_5.mem_0
    let (var_10: ManagedCuda.CudaStream) = var_5.mem_1
    let (var_11: ManagedCuda.BasicTypes.CUstream) = method_29((var_9: (bool ref)), (var_10: ManagedCuda.CudaStream))
    let (var_13: (System.Object [])) = [|var_1; var_2|]: (System.Object [])
    var_6.RunAsync(var_11, var_13)
and method_32((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_33((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_33", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_29((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_37((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_37((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_38((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): int64 =
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
            method_39((var_0: System.Text.StringBuilder), (var_15: int64))
            let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_17: int64) = method_40((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_19: int64) = (var_6 + 1L)
            method_42((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_17: int64), (var_19: int64))
        else
            let (var_21: int64) = 0L
            method_37((var_0: System.Text.StringBuilder), (var_21: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_40((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
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
            let (var_13: int64) = var_1.[int32 var_2]
            let (var_14: string) = System.String.Format("{0}",var_13)
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
            let (var_16: string) = "; "
            let (var_17: int64) = (var_7 + 1L)
            let (var_18: int64) = (var_4 + 1L)
            method_41((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_48((var_0: ManagedCuda.CudaContext), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: (int64 ref)), (var_6: Env4)): unit =
    // Cuda join point
    // method_49((var_1: uint64), (var_2: uint64), (var_3: uint64))
    let (var_7: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_49", var_4, var_0)
    let (var_8: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_7.set_GridDimensions(var_8)
    let (var_9: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 32u, 1u)
    var_7.set_BlockDimensions(var_9)
    let (var_10: (bool ref)) = var_6.mem_0
    let (var_11: ManagedCuda.CudaStream) = var_6.mem_1
    let (var_12: ManagedCuda.BasicTypes.CUstream) = method_29((var_10: (bool ref)), (var_11: ManagedCuda.CudaStream))
    let (var_14: (System.Object [])) = [|var_1; var_2; var_3|]: (System.Object [])
    var_7.RunAsync(var_12, var_14)
and method_55((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64)): int64 =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: bool) = (var_10 < 1000L)
        if var_12 then
            let (var_13: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_14: bool) = (var_7 >= var_7)
            let (var_15: bool) = (var_14 = false)
            if var_15 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_16: int64) = var_1.[int32 var_2]
            let (var_17: int64) = var_4.[int32 var_5]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: string) = System.String.Format("{0}",var_16)
            let (var_20: string) = String.concat ", " [|var_19; var_18|]
            let (var_21: string) = System.String.Format("[{0}]",var_20)
            let (var_22: System.Text.StringBuilder) = var_0.Append(var_21)
            let (var_23: string) = "; "
            let (var_24: int64) = (var_10 + 1L)
            let (var_25: int64) = (var_7 + 1L)
            method_56((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_23: string), (var_24: int64), (var_25: int64))
        else
            let (var_27: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
and method_15((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): Env7 =
    let (var_5: int32) = var_0.get_Count()
    let (var_6: bool) = (var_5 > 0)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_8: Env0) = var_0.[0]
    let (var_9: uint64) = var_8.mem_0
    let (var_10: uint64) = var_8.mem_1
    let (var_11: bool) = (var_4 <= var_10)
    let (var_38: Env1) =
        if var_11 then
            let (var_12: uint64) = (var_9 + var_4)
            let (var_13: uint64) = (var_10 - var_4)
            var_0.[0] <- (Env0(var_12, var_13))
            let (var_14: (uint64 ref)) = (ref var_9)
            (Env1((Env7(var_14)), var_4))
        else
            let (var_16: (Env0 -> (Env0 -> int32))) = method_16
            let (var_17: System.Comparison<Env0>) = System.Comparison<Env0>(var_16)
            var_0.Sort(var_17)
            let (var_18: Env0) = var_0.[0]
            let (var_19: uint64) = var_18.mem_0
            let (var_20: uint64) = var_18.mem_1
            let (var_21: bool) = (var_4 <= var_20)
            if var_21 then
                let (var_22: uint64) = (var_19 + var_4)
                let (var_23: uint64) = (var_20 - var_4)
                var_0.[0] <- (Env0(var_22, var_23))
                let (var_24: (uint64 ref)) = (ref var_19)
                (Env1((Env7(var_24)), var_4))
            else
                method_1((var_0: ResizeArray<Env0>), (var_1: (uint64 ref)), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_26: (Env0 -> (Env0 -> int32))) = method_16
                let (var_27: System.Comparison<Env0>) = System.Comparison<Env0>(var_26)
                var_0.Sort(var_27)
                let (var_28: Env0) = var_0.[0]
                let (var_29: uint64) = var_28.mem_0
                let (var_30: uint64) = var_28.mem_1
                let (var_31: bool) = (var_4 <= var_30)
                if var_31 then
                    let (var_32: uint64) = (var_29 + var_4)
                    let (var_33: uint64) = (var_30 - var_4)
                    var_0.[0] <- (Env0(var_32, var_33))
                    let (var_34: (uint64 ref)) = (ref var_29)
                    (Env1((Env7(var_34)), var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_39: Env7) = var_38.mem_0
    let (var_40: uint64) = var_38.mem_1
    var_3.Add((Env1(var_39, var_40)))
    var_39
and method_18((var_0: (int64 ref)), (var_1: (uint64 ref)), (var_2: ResizeArray<Env2>)): unit =
    let (var_3: int64) = (!var_0)
    let (var_4: int64) = (var_3 + 1L)
    var_0 := var_4
    var_2.Add((Env2(var_0, (Env7(var_1)))))
and method_29((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_39((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_39((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_42((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): int64 =
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
            method_39((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_40((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_18: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_11 + 1L)
            method_42((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_37((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_41((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
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
            let (var_17: int64) = var_1.[int32 var_16]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
            let (var_20: string) = "; "
            let (var_21: int64) = (var_7 + 1L)
            let (var_22: int64) = (var_8 + 1L)
            method_41((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
        else
            let (var_24: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_56((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: System.Text.StringBuilder) = var_0.Append(var_9)
            let (var_15: bool) = (var_11 >= var_7)
            let (var_16: bool) = (var_15 = false)
            if var_16 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_17: int64) = (var_11 - var_7)
            let (var_18: int64) = (var_17 * var_3)
            let (var_19: int64) = (var_2 + var_18)
            let (var_20: int64) = (var_17 * var_6)
            let (var_21: int64) = (var_5 + var_20)
            let (var_22: int64) = var_1.[int32 var_19]
            let (var_23: int64) = var_4.[int32 var_21]
            let (var_24: string) = System.String.Format("{0}",var_23)
            let (var_25: string) = System.String.Format("{0}",var_22)
            let (var_26: string) = String.concat ", " [|var_25; var_24|]
            let (var_27: string) = System.String.Format("[{0}]",var_26)
            let (var_28: System.Text.StringBuilder) = var_0.Append(var_27)
            let (var_29: string) = "; "
            let (var_30: int64) = (var_10 + 1L)
            let (var_31: int64) = (var_11 + 1L)
            method_56((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_29: string), (var_30: int64), (var_31: int64))
        else
            let (var_33: System.Text.StringBuilder) = var_0.Append("...")
            var_10
    else
        var_10
and method_16 ((var_0: Env0)): (Env0 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_17((var_2: uint64))
and method_17 ((var_1: uint64)) ((var_0: Env0)): int32 =
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
let (var_40: ResizeArray<Env0>) = ResizeArray<Env0>()
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_40: ResizeArray<Env0>), (var_39: (uint64 ref)), (var_35: uint64), (var_41: ResizeArray<Env1>))
let (var_42: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_43: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_42)
let (var_44: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_45: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_46: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_44, var_45)
let (var_55: ResizeArray<Env2>) = ResizeArray<Env2>()
let (var_64: ResizeArray<Env3>) = ResizeArray<Env3>()
let (var_65: (bool ref)) = (ref true)
let (var_66: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_67: Env3) = method_7((var_65: (bool ref)), (var_66: ManagedCuda.CudaStream), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_68: (int64 ref)) = var_67.mem_0
let (var_69: Env4) = var_67.mem_1
let (var_70: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(1280L))
let (var_71: int64) = 0L
method_9((var_70: (int64 [])), (var_71: int64))
let (var_72: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(10L))
let (var_73: int64) = 0L
method_11((var_72: (int64 [])), (var_73: int64))
let (var_74: int64) = 128L
let (var_75: int64) = 0L
let (var_76: int64) = 10L
let (var_77: int64) = 1L
let (var_78: Env5) = method_12((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_74: int64), (var_70: (int64 [])), (var_75: int64), (var_76: int64), (var_77: int64))
let (var_79: Env2) = var_78.mem_0
let (var_80: int64) = 10L
let (var_81: int64) = 0L
let (var_82: int64) = 1L
let (var_83: Env5) = method_19((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_80: int64), (var_72: (int64 [])), (var_81: int64), (var_82: int64))
let (var_84: Env2) = var_83.mem_0
let (var_85: EnvStack6) = method_20((var_79: Env2), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_86: (int64 ref)) = var_85.mem_0
let (var_87: Env7) = var_85.mem_1
let (var_88: EnvStack6) = method_30((var_79: Env2), (var_84: Env2), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_89: (int64 ref)) = var_88.mem_0
let (var_90: Env7) = var_88.mem_1
let (var_91: int64) = 0L
let (var_92: int64) = 10L
let (var_93: int64) = 1L
let (var_94: int64) = 0L
let (var_95: int64) = 128L
let (var_96: int64) = 0L
let (var_97: int64) = 10L
method_34((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_79: Env2), (var_91: int64), (var_92: int64), (var_93: int64), (var_94: int64), (var_95: int64), (var_96: int64), (var_97: int64))
let (var_98: int64) = 0L
let (var_99: int64) = 1L
let (var_100: int64) = 0L
let (var_101: int64) = 10L
method_43((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_86: (int64 ref)), (var_87: Env7), (var_98: int64), (var_99: int64), (var_100: int64), (var_101: int64))
let (var_102: int64) = 0L
let (var_103: int64) = 1L
let (var_104: int64) = 0L
let (var_105: int64) = 10L
method_43((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_89: (int64 ref)), (var_90: Env7), (var_102: int64), (var_103: int64), (var_104: int64), (var_105: int64))
let (var_106: EnvStack8) = method_46((var_79: Env2), (var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4))
let (var_107: (int64 ref)) = var_106.mem_0
let (var_108: Env7) = var_106.mem_1
let (var_109: (int64 ref)) = var_106.mem_2
let (var_110: Env7) = var_106.mem_3
let (var_111: int64) = 0L
let (var_112: int64) = 1L
let (var_113: int64) = 0L
let (var_114: int64) = 1L
let (var_115: int64) = 0L
let (var_116: int64) = 10L
method_53((var_46: ManagedCuda.CudaBlas.CudaBlas), (var_43: ManagedCuda.CudaRand.CudaRandDevice), (var_39: (uint64 ref)), (var_35: uint64), (var_40: ResizeArray<Env0>), (var_41: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_55: ResizeArray<Env2>), (var_64: ResizeArray<Env3>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_68: (int64 ref)), (var_69: Env4), (var_107: (int64 ref)), (var_108: Env7), (var_111: int64), (var_112: int64), (var_109: (int64 ref)), (var_110: Env7), (var_113: int64), (var_114: int64), (var_115: int64), (var_116: int64))
method_57((var_64: ResizeArray<Env3>))
method_59((var_55: ResizeArray<Env2>))
var_46.Dispose()
var_43.Dispose()
let (var_117: uint64) = method_5((var_39: (uint64 ref)))
let (var_118: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_117)
let (var_119: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_118)
var_1.FreeMemory(var_119)
var_39 := 0UL
var_1.Dispose()

