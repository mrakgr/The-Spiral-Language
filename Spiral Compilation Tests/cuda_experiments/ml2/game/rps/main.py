kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
#include <curand_kernel.h>
struct US1;
struct US2;
struct US0;
struct US3;
struct US4;
struct US5;
struct Tuple0;
struct Tuple1;
__device__ long loop_4(array<float,3l> v0, float v1, long v2);
__device__ long sample_discrete__3(array<float,3l> v0, curandStatePhilox4_32_10_t * v1);
__device__ US1 sample_discrete_2(array<Tuple1,3l> v0, curandStatePhilox4_32_10_t * v1);
__device__ Tuple0 method_1(curandStatePhilox4_32_10_t * v0, US3 v1, array<US3,2l> v2, US4 v3, US5 v4, US2 v5, US2 v6);
__device__ Tuple0 method_0(curandStatePhilox4_32_10_t * v0, array<US3,2l> v1, US4 v2, US5 v3, US2 v4, US2 v5, US0 v6);
struct US1 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US2 {
    union {
    } v;
    unsigned long tag : 2;
};
struct US0 {
    union {
        struct {
            US1 v0;
        } case0; // ActionSelected
        struct {
            US2 v0;
            US2 v1;
        } case1; // PlayerChanged
    } v;
    unsigned long tag : 2;
};
struct US3 {
    union {
        struct {
            US1 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US4 {
    union {
        struct {
            US1 v0;
            US1 v1;
        } case1; // GameOver
        struct {
            long v0;
        } case2; // WaitingForActionFromPlayerId
    } v;
    unsigned long tag : 2;
};
struct US5 {
    union {
        struct {
            US1 v0;
            US1 v1;
        } case1; // ShowdownResult
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    array<US3,2l> v0;
    US4 v1;
    US5 v2;
    US2 v3;
    US2 v4;
    __device__ Tuple0(array<US3,2l> t0, US4 t1, US5 t2, US2 t3, US2 t4) : v0(t0), v1(t1), v2(t2), v3(t3), v4(t4) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    US1 v0;
    float v1;
    __device__ Tuple1(US1 t0, float t1) : v0(t0), v1(t1) {}
    __device__ Tuple1() = default;
};
__device__ US1 US1_0() { // Paper
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1() { // Rock
    US1 x;
    x.tag = 1;
    return x;
}
__device__ US1 US1_2() { // Scissors
    US1 x;
    x.tag = 2;
    return x;
}
__device__ US2 US2_0() { // Computer
    US2 x;
    x.tag = 0;
    return x;
}
__device__ US2 US2_1() { // Human
    US2 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_0(US1 v0) { // ActionSelected
    US0 x;
    x.tag = 0;
    x.v.case0.v0 = v0;
    return x;
}
__device__ US0 US0_1(US2 v0, US2 v1) { // PlayerChanged
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US0 US0_2() { // StartGame
    US0 x;
    x.tag = 2;
    return x;
}
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(US1 v0) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ inline bool while_method_0(long v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
__device__ US4 US4_0() { // GameNotStarted
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(US1 v0, US1 v1) { // GameOver
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US4 US4_2(long v0) { // WaitingForActionFromPlayerId
    US4 x;
    x.tag = 2;
    x.v.case2.v0 = v0;
    return x;
}
__device__ US5 US5_0() { // GameStarted
    US5 x;
    x.tag = 0;
    return x;
}
__device__ US5 US5_1(US1 v0, US1 v1) { // ShowdownResult
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US5 US5_2() { // WaitingToStart
    US5 x;
    x.tag = 2;
    return x;
}
__device__ inline bool while_method_1(long v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
__device__ inline bool while_method_2(array<float,3l> v0, long v1){
    bool v2;
    v2 = v1 < 3l;
    return v2;
}
__device__ inline bool while_method_3(long v0, long v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
__device__ long loop_4(array<float,3l> v0, float v1, long v2){
    bool v3;
    v3 = v2 < 3l;
    if (v3){
        bool v4;
        v4 = 0l <= v2;
        bool v5;
        v5 = v4 && v3;
        bool v6;
        v6 = v5 == false;
        if (v6){
            assert("The read index needs to be in range." && v5);
        } else {
        }
        float v7;
        v7 = v0.v[v2];
        bool v8;
        v8 = v1 <= v7;
        if (v8){
            return v2;
        } else {
            long v9;
            v9 = v2 + 1l;
            return loop_4(v0, v1, v9);
        }
    } else {
        return 2l;
    }
}
__device__ long sample_discrete__3(array<float,3l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,3l> v2;
    long v3;
    v3 = 0l;
    while (while_method_1(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 3l;
            v7 = v6;
        } else {
            v7 = false;
        }
        bool v8;
        v8 = v7 == false;
        if (v8){
            assert("The read index needs to be in range." && v7);
        } else {
        }
        float v9;
        v9 = v0.v[v3];
        bool v11;
        if (v5){
            bool v10;
            v10 = v3 < 3l;
            v11 = v10;
        } else {
            v11 = false;
        }
        bool v12;
        v12 = v11 == false;
        if (v12){
            assert("The read index needs to be in range." && v11);
        } else {
        }
        v2.v[v3] = v9;
        v3 += 1l ;
    }
    long v13;
    v13 = 1l;
    while (while_method_2(v2, v13)){
        long v15;
        v15 = 3l;
        while (while_method_3(v13, v15)){
            v15 -= 1l ;
            long v17;
            v17 = v15 - v13;
            bool v18;
            v18 = 0l <= v17;
            bool v20;
            if (v18){
                bool v19;
                v19 = v17 < 3l;
                v20 = v19;
            } else {
                v20 = false;
            }
            bool v21;
            v21 = v20 == false;
            if (v21){
                assert("The read index needs to be in range." && v20);
            } else {
            }
            float v22;
            v22 = v2.v[v17];
            bool v23;
            v23 = 0l <= v15;
            bool v25;
            if (v23){
                bool v24;
                v24 = v15 < 3l;
                v25 = v24;
            } else {
                v25 = false;
            }
            bool v26;
            v26 = v25 == false;
            if (v26){
                assert("The read index needs to be in range." && v25);
            } else {
            }
            float v27;
            v27 = v2.v[v15];
            float v28;
            v28 = v22 + v27;
            bool v30;
            if (v23){
                bool v29;
                v29 = v15 < 3l;
                v30 = v29;
            } else {
                v30 = false;
            }
            bool v31;
            v31 = v30 == false;
            if (v31){
                assert("The read index needs to be in range." && v30);
            } else {
            }
            v2.v[v15] = v28;
        }
        long v32;
        v32 = v13 * 2l;
        v13 = v32;
    }
    float v33;
    v33 = v2.v[2l];
    float v34;
    v34 = curand_uniform(v1);
    float v35;
    v35 = v34 * v33;
    long v36;
    v36 = 0l;
    return loop_4(v2, v35, v36);
}
__device__ US1 sample_discrete_2(array<Tuple1,3l> v0, curandStatePhilox4_32_10_t * v1){
    array<float,3l> v2;
    long v3;
    v3 = 0l;
    while (while_method_1(v3)){
        bool v5;
        v5 = 0l <= v3;
        bool v7;
        if (v5){
            bool v6;
            v6 = v3 < 3l;
            v7 = v6;
        } else {
            v7 = false;
        }
        bool v8;
        v8 = v7 == false;
        if (v8){
            assert("The read index needs to be in range." && v7);
        } else {
        }
        US1 v9; float v10;
        Tuple1 tmp0 = v0.v[v3];
        v9 = tmp0.v0; v10 = tmp0.v1;
        bool v12;
        if (v5){
            bool v11;
            v11 = v3 < 3l;
            v12 = v11;
        } else {
            v12 = false;
        }
        bool v13;
        v13 = v12 == false;
        if (v13){
            assert("The read index needs to be in range." && v12);
        } else {
        }
        v2.v[v3] = v10;
        v3 += 1l ;
    }
    long v14;
    v14 = sample_discrete__3(v2, v1);
    bool v15;
    v15 = 0l <= v14;
    bool v17;
    if (v15){
        bool v16;
        v16 = v14 < 3l;
        v17 = v16;
    } else {
        v17 = false;
    }
    bool v18;
    v18 = v17 == false;
    if (v18){
        assert("The read index needs to be in range." && v17);
    } else {
    }
    US1 v19; float v20;
    Tuple1 tmp1 = v0.v[v14];
    v19 = tmp1.v0; v20 = tmp1.v1;
    return v19;
}
__device__ Tuple0 method_1(curandStatePhilox4_32_10_t * v0, US3 v1, array<US3,2l> v2, US4 v3, US5 v4, US2 v5, US2 v6){
    switch (v3.tag) {
        case 0: { // GameNotStarted
            return Tuple0(v2, v3, v4, v5, v6);
            break;
        }
        case 1: { // GameOver
            US1 v7 = v3.v.case1.v0; US1 v8 = v3.v.case1.v1;
            return Tuple0(v2, v3, v4, v5, v6);
            break;
        }
        default: { // WaitingForActionFromPlayerId
            long v9 = v3.v.case2.v0;
            bool v10;
            v10 = v9 < 2l;
            if (v10){
                bool v11;
                v11 = v9 == 0l;
                US2 v12;
                if (v11){
                    v12 = v5;
                } else {
                    v12 = v6;
                }
                switch (v12.tag) {
                    case 0: { // Computer
                        bool v14;
                        switch (v1.tag) {
                            case 0: { // None
                                v14 = true;
                                break;
                            }
                            default: {
                                v14 = false;
                            }
                        }
                        bool v15;
                        v15 = v14 == false;
                        if (v15){
                            assert("The computer player should never be receiving an action." && v14);
                        } else {
                        }
                        array<Tuple1,3l> v16;
                        US1 v17;
                        v17 = US1_1();
                        v16.v[0l] = Tuple1(v17, 1.0f);
                        US1 v18;
                        v18 = US1_0();
                        v16.v[1l] = Tuple1(v18, 1.0f);
                        US1 v19;
                        v19 = US1_2();
                        v16.v[2l] = Tuple1(v19, 1.0f);
                        US1 v20;
                        v20 = sample_discrete_2(v16, v0);
                        long v21;
                        v21 = v9 + 1l;
                        array<US3,2l> v22;
                        long v23;
                        v23 = 0l;
                        while (while_method_0(v23)){
                            bool v25;
                            v25 = 0l <= v23;
                            bool v27;
                            if (v25){
                                bool v26;
                                v26 = v23 < 2l;
                                v27 = v26;
                            } else {
                                v27 = false;
                            }
                            bool v28;
                            v28 = v27 == false;
                            if (v28){
                                assert("The read index needs to be in range." && v27);
                            } else {
                            }
                            US3 v29;
                            v29 = v2.v[v23];
                            bool v30;
                            v30 = v9 == v23;
                            US3 v32;
                            if (v30){
                                v32 = US3_1(v20);
                            } else {
                                v32 = v29;
                            }
                            bool v34;
                            if (v25){
                                bool v33;
                                v33 = v23 < 2l;
                                v34 = v33;
                            } else {
                                v34 = false;
                            }
                            bool v35;
                            v35 = v34 == false;
                            if (v35){
                                assert("The read index needs to be in range." && v34);
                            } else {
                            }
                            v22.v[v23] = v32;
                            v23 += 1l ;
                        }
                        US3 v36;
                        v36 = US3_0();
                        US4 v37;
                        v37 = US4_2(v21);
                        return method_1(v0, v36, v22, v37, v4, v5, v6);
                        break;
                    }
                    default: { // Human
                        switch (v1.tag) {
                            case 0: { // None
                                return Tuple0(v2, v3, v4, v5, v6);
                                break;
                            }
                            default: { // Some
                                US1 v43 = v1.v.case1.v0;
                                long v44;
                                v44 = v9 + 1l;
                                array<US3,2l> v45;
                                long v46;
                                v46 = 0l;
                                while (while_method_0(v46)){
                                    bool v48;
                                    v48 = 0l <= v46;
                                    bool v50;
                                    if (v48){
                                        bool v49;
                                        v49 = v46 < 2l;
                                        v50 = v49;
                                    } else {
                                        v50 = false;
                                    }
                                    bool v51;
                                    v51 = v50 == false;
                                    if (v51){
                                        assert("The read index needs to be in range." && v50);
                                    } else {
                                    }
                                    US3 v52;
                                    v52 = v2.v[v46];
                                    bool v53;
                                    v53 = v9 == v46;
                                    US3 v55;
                                    if (v53){
                                        v55 = US3_1(v43);
                                    } else {
                                        v55 = v52;
                                    }
                                    bool v57;
                                    if (v48){
                                        bool v56;
                                        v56 = v46 < 2l;
                                        v57 = v56;
                                    } else {
                                        v57 = false;
                                    }
                                    bool v58;
                                    v58 = v57 == false;
                                    if (v58){
                                        assert("The read index needs to be in range." && v57);
                                    } else {
                                    }
                                    v45.v[v46] = v55;
                                    v46 += 1l ;
                                }
                                US3 v59;
                                v59 = US3_0();
                                US4 v60;
                                v60 = US4_2(v44);
                                return method_1(v0, v59, v45, v60, v4, v5, v6);
                            }
                        }
                    }
                }
            } else {
                US3 v86;
                v86 = v2.v[0l];
                US3 v87;
                v87 = v2.v[1l];
                switch (v86.tag) {
                    case 1: { // Some
                        US1 v88 = v86.v.case1.v0;
                        switch (v87.tag) {
                            case 1: { // Some
                                US1 v89 = v87.v.case1.v0;
                                array<US3,2l> v90;
                                long v91;
                                v91 = 0l;
                                while (while_method_0(v91)){
                                    bool v93;
                                    v93 = 0l <= v91;
                                    bool v95;
                                    if (v93){
                                        bool v94;
                                        v94 = v91 < 2l;
                                        v95 = v94;
                                    } else {
                                        v95 = false;
                                    }
                                    bool v96;
                                    v96 = v95 == false;
                                    if (v96){
                                        assert("The read index needs to be in range." && v95);
                                    } else {
                                    }
                                    US3 v97;
                                    v97 = US3_0();
                                    v90.v[v91] = v97;
                                    v91 += 1l ;
                                }
                                US4 v98;
                                v98 = US4_1(v88, v89);
                                US5 v99;
                                v99 = US5_1(v88, v89);
                                return Tuple0(v90, v98, v99, v5, v6);
                                break;
                            }
                            default: {
                                printf("%s\n", "At showdown all the actions have to be selected.");
                                asm("exit;");
                            }
                        }
                        break;
                    }
                    default: {
                        printf("%s\n", "At showdown all the actions have to be selected.");
                        asm("exit;");
                    }
                }
            }
        }
    }
}
__device__ Tuple0 method_0(curandStatePhilox4_32_10_t * v0, array<US3,2l> v1, US4 v2, US5 v3, US2 v4, US2 v5, US0 v6){
    array<US3,2l> v49; US4 v50; US5 v51; US2 v52; US2 v53;
    switch (v6.tag) {
        case 0: { // ActionSelected
            US1 v32 = v6.v.case0.v0;
            US3 v33;
            v33 = US3_1(v32);
            Tuple0 tmp2 = method_1(v0, v33, v1, v2, v3, v4, v5);
            v49 = tmp2.v0; v50 = tmp2.v1; v51 = tmp2.v2; v52 = tmp2.v3; v53 = tmp2.v4;
            break;
        }
        case 1: { // PlayerChanged
            US2 v24 = v6.v.case1.v0; US2 v25 = v6.v.case1.v1;
            US3 v26;
            v26 = US3_0();
            Tuple0 tmp3 = method_1(v0, v26, v1, v2, v3, v24, v25);
            v49 = tmp3.v0; v50 = tmp3.v1; v51 = tmp3.v2; v52 = tmp3.v3; v53 = tmp3.v4;
            break;
        }
        default: { // StartGame
            array<US3,2l> v7;
            long v8;
            v8 = 0l;
            while (while_method_0(v8)){
                bool v10;
                v10 = 0l <= v8;
                bool v12;
                if (v10){
                    bool v11;
                    v11 = v8 < 2l;
                    v12 = v11;
                } else {
                    v12 = false;
                }
                bool v13;
                v13 = v12 == false;
                if (v13){
                    assert("The read index needs to be in range." && v12);
                } else {
                }
                US3 v14;
                v14 = US3_0();
                v7.v[v8] = v14;
                v8 += 1l ;
            }
            US3 v15;
            v15 = US3_0();
            long v16;
            v16 = 0l;
            US4 v17;
            v17 = US4_2(v16);
            US5 v18;
            v18 = US5_0();
            Tuple0 tmp4 = method_1(v0, v15, v7, v17, v18, v4, v5);
            v49 = tmp4.v0; v50 = tmp4.v1; v51 = tmp4.v2; v52 = tmp4.v3; v53 = tmp4.v4;
        }
    }
    return Tuple0(v49, v50, v51, v52, v53);
}
extern "C" __global__ void entry0(unsigned char * v0, unsigned char * v1) {
    long v2;
    v2 = threadIdx.x;
    long v3;
    v3 = blockIdx.x;
    long v4;
    v4 = v3 * 512l;
    long v5;
    v5 = v2 + v4;
    bool v6;
    v6 = v5 == 0l;
    if (v6){
        unsigned long long v7;
        v7 = clock64();
        unsigned long long v8;
        v8 = (unsigned long long)v5;
        curandStatePhilox4_32_10_t v9;
        curandStatePhilox4_32_10_t * v10 = &v9;
        curand_init(v7,v8,0ull,v10);
        long * v11;
        v11 = (long *)(v1+0ull);
        long v12;
        v12 = v11[0l];
        US0 v36;
        switch (v12) {
            case 0: {
                long * v14;
                v14 = (long *)(v1+4ull);
                long v15;
                v15 = v14[0l];
                US1 v20;
                switch (v15) {
                    case 0: {
                        v20 = US1_0();
                        break;
                    }
                    case 1: {
                        v20 = US1_1();
                        break;
                    }
                    case 2: {
                        v20 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v36 = US0_0(v20);
                break;
            }
            case 1: {
                long * v22;
                v22 = (long *)(v1+4ull);
                long v23;
                v23 = v22[0l];
                US2 v27;
                switch (v23) {
                    case 0: {
                        v27 = US2_0();
                        break;
                    }
                    case 1: {
                        v27 = US2_1();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                long * v28;
                v28 = (long *)(v1+8ull);
                long v29;
                v29 = v28[0l];
                US2 v33;
                switch (v29) {
                    case 0: {
                        v33 = US2_0();
                        break;
                    }
                    case 1: {
                        v33 = US2_1();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v36 = US0_1(v27, v33);
                break;
            }
            case 2: {
                v36 = US0_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        array<US3,2l> v37;
        long v38;
        v38 = 0l;
        while (while_method_0(v38)){
            unsigned long long v40;
            v40 = (unsigned long long)v38;
            unsigned long long v41;
            v41 = v40 * 8ull;
            unsigned char * v42;
            v42 = (unsigned char *)(v0+v41);
            long * v43;
            v43 = (long *)(v42+0ull);
            long v44;
            v44 = v43[0l];
            US3 v55;
            switch (v44) {
                case 0: {
                    v55 = US3_0();
                    break;
                }
                case 1: {
                    long * v47;
                    v47 = (long *)(v42+4ull);
                    long v48;
                    v48 = v47[0l];
                    US1 v53;
                    switch (v48) {
                        case 0: {
                            v53 = US1_0();
                            break;
                        }
                        case 1: {
                            v53 = US1_1();
                            break;
                        }
                        case 2: {
                            v53 = US1_2();
                            break;
                        }
                        default: {
                            printf("%s\n", "Invalid tag.");
                            asm("exit;");
                        }
                    }
                    v55 = US3_1(v53);
                    break;
                }
                default: {
                    printf("%s\n", "Invalid tag.");
                    asm("exit;");
                }
            }
            bool v56;
            v56 = 0l <= v38;
            bool v58;
            if (v56){
                bool v57;
                v57 = v38 < 2l;
                v58 = v57;
            } else {
                v58 = false;
            }
            bool v59;
            v59 = v58 == false;
            if (v59){
                assert("The read index needs to be in range." && v58);
            } else {
            }
            v37.v[v38] = v55;
            v38 += 1l ;
        }
        long * v60;
        v60 = (long *)(v0+16ull);
        long v61;
        v61 = v60[0l];
        US4 v82;
        switch (v61) {
            case 0: {
                v82 = US4_0();
                break;
            }
            case 1: {
                long * v64;
                v64 = (long *)(v0+20ull);
                long v65;
                v65 = v64[0l];
                US1 v70;
                switch (v65) {
                    case 0: {
                        v70 = US1_0();
                        break;
                    }
                    case 1: {
                        v70 = US1_1();
                        break;
                    }
                    case 2: {
                        v70 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                long * v71;
                v71 = (long *)(v0+24ull);
                long v72;
                v72 = v71[0l];
                US1 v77;
                switch (v72) {
                    case 0: {
                        v77 = US1_0();
                        break;
                    }
                    case 1: {
                        v77 = US1_1();
                        break;
                    }
                    case 2: {
                        v77 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v82 = US4_1(v70, v77);
                break;
            }
            case 2: {
                long * v79;
                v79 = (long *)(v0+20ull);
                long v80;
                v80 = v79[0l];
                v82 = US4_2(v80);
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        long * v83;
        v83 = (long *)(v0+28ull);
        long v84;
        v84 = v83[0l];
        US5 v103;
        switch (v84) {
            case 0: {
                v103 = US5_0();
                break;
            }
            case 1: {
                long * v87;
                v87 = (long *)(v0+32ull);
                long v88;
                v88 = v87[0l];
                US1 v93;
                switch (v88) {
                    case 0: {
                        v93 = US1_0();
                        break;
                    }
                    case 1: {
                        v93 = US1_1();
                        break;
                    }
                    case 2: {
                        v93 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                long * v94;
                v94 = (long *)(v0+36ull);
                long v95;
                v95 = v94[0l];
                US1 v100;
                switch (v95) {
                    case 0: {
                        v100 = US1_0();
                        break;
                    }
                    case 1: {
                        v100 = US1_1();
                        break;
                    }
                    case 2: {
                        v100 = US1_2();
                        break;
                    }
                    default: {
                        printf("%s\n", "Invalid tag.");
                        asm("exit;");
                    }
                }
                v103 = US5_1(v93, v100);
                break;
            }
            case 2: {
                v103 = US5_2();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        long * v104;
        v104 = (long *)(v0+40ull);
        long v105;
        v105 = v104[0l];
        US2 v109;
        switch (v105) {
            case 0: {
                v109 = US2_0();
                break;
            }
            case 1: {
                v109 = US2_1();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        long * v110;
        v110 = (long *)(v0+44ull);
        long v111;
        v111 = v110[0l];
        US2 v115;
        switch (v111) {
            case 0: {
                v115 = US2_0();
                break;
            }
            case 1: {
                v115 = US2_1();
                break;
            }
            default: {
                printf("%s\n", "Invalid tag.");
                asm("exit;");
            }
        }
        array<US3,2l> v116; US4 v117; US5 v118; US2 v119; US2 v120;
        Tuple0 tmp5 = method_0(v10, v37, v82, v103, v109, v115, v36);
        v116 = tmp5.v0; v117 = tmp5.v1; v118 = tmp5.v2; v119 = tmp5.v3; v120 = tmp5.v4;
        long v121;
        v121 = 0l;
        while (while_method_0(v121)){
            unsigned long long v123;
            v123 = (unsigned long long)v121;
            unsigned long long v124;
            v124 = v123 * 8ull;
            unsigned char * v125;
            v125 = (unsigned char *)(v0+v124);
            bool v126;
            v126 = 0l <= v121;
            bool v128;
            if (v126){
                bool v127;
                v127 = v121 < 2l;
                v128 = v127;
            } else {
                v128 = false;
            }
            bool v129;
            v129 = v128 == false;
            if (v129){
                assert("The read index needs to be in range." && v128);
            } else {
            }
            US3 v130;
            v130 = v116.v[v121];
            long v131;
            v131 = v130.tag;
            long * v132;
            v132 = (long *)(v125+0ull);
            v132[0l] = v131;
            switch (v130.tag) {
                case 0: { // None
                    break;
                }
                default: { // Some
                    US1 v133 = v130.v.case1.v0;
                    long v134;
                    v134 = v133.tag;
                    long * v135;
                    v135 = (long *)(v125+4ull);
                    v135[0l] = v134;
                    switch (v133.tag) {
                        case 0: { // Paper
                            break;
                        }
                        case 1: { // Rock
                            break;
                        }
                        default: { // Scissors
                        }
                    }
                }
            }
            v121 += 1l ;
        }
        long v136;
        v136 = v117.tag;
        long * v137;
        v137 = (long *)(v0+16ull);
        v137[0l] = v136;
        switch (v117.tag) {
            case 0: { // GameNotStarted
                break;
            }
            case 1: { // GameOver
                US1 v138 = v117.v.case1.v0; US1 v139 = v117.v.case1.v1;
                long v140;
                v140 = v138.tag;
                long * v141;
                v141 = (long *)(v0+20ull);
                v141[0l] = v140;
                switch (v138.tag) {
                    case 0: { // Paper
                        break;
                    }
                    case 1: { // Rock
                        break;
                    }
                    default: { // Scissors
                    }
                }
                long v142;
                v142 = v139.tag;
                long * v143;
                v143 = (long *)(v0+24ull);
                v143[0l] = v142;
                switch (v139.tag) {
                    case 0: { // Paper
                        break;
                    }
                    case 1: { // Rock
                        break;
                    }
                    default: { // Scissors
                    }
                }
                break;
            }
            default: { // WaitingForActionFromPlayerId
                long v144 = v117.v.case2.v0;
                long * v145;
                v145 = (long *)(v0+20ull);
                v145[0l] = v144;
            }
        }
        long v146;
        v146 = v118.tag;
        long * v147;
        v147 = (long *)(v0+28ull);
        v147[0l] = v146;
        switch (v118.tag) {
            case 0: { // GameStarted
                break;
            }
            case 1: { // ShowdownResult
                US1 v148 = v118.v.case1.v0; US1 v149 = v118.v.case1.v1;
                long v150;
                v150 = v148.tag;
                long * v151;
                v151 = (long *)(v0+32ull);
                v151[0l] = v150;
                switch (v148.tag) {
                    case 0: { // Paper
                        break;
                    }
                    case 1: { // Rock
                        break;
                    }
                    default: { // Scissors
                    }
                }
                long v152;
                v152 = v149.tag;
                long * v153;
                v153 = (long *)(v0+36ull);
                v153[0l] = v152;
                switch (v149.tag) {
                    case 0: { // Paper
                        break;
                    }
                    case 1: { // Rock
                        break;
                    }
                    default: { // Scissors
                    }
                }
                break;
            }
            default: { // WaitingToStart
            }
        }
        long v154;
        v154 = v119.tag;
        long * v155;
        v155 = (long *)(v0+40ull);
        v155[0l] = v154;
        switch (v119.tag) {
            case 0: { // Computer
                break;
            }
            default: { // Human
            }
        }
        long v156;
        v156 = v120.tag;
        long * v157;
        v157 = (long *)(v0+44ull);
        v157[0l] = v156;
        switch (v120.tag) {
            case 0: { // Computer
                return ;
                break;
            }
            default: { // Human
                return ;
            }
        }
    } else {
        return ;
    }
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
import collections
class US1_0(NamedTuple): # Paper
    tag = 0
class US1_1(NamedTuple): # Rock
    tag = 1
class US1_2(NamedTuple): # Scissors
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US0_0(NamedTuple): # ActionSelected
    v0 : US1
    tag = 0
class US0_1(NamedTuple): # PlayerChanged
    v0 : US2
    v1 : US2
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : US1
    tag = 1
US3 = Union[US3_0, US3_1]
class US4_0(NamedTuple): # GameNotStarted
    tag = 0
class US4_1(NamedTuple): # GameOver
    v0 : US1
    v1 : US1
    tag = 1
class US4_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    tag = 2
US4 = Union[US4_0, US4_1, US4_2]
class US5_0(NamedTuple): # GameStarted
    tag = 0
class US5_1(NamedTuple): # ShowdownResult
    v0 : US1
    v1 : US1
    tag = 1
class US5_2(NamedTuple): # WaitingToStart
    tag = 2
US5 = Union[US5_0, US5_1, US5_2]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6, v7 = method4(v1)
        v8, v9, v10, v11, v12 = method9(v3, v4, v5, v6, v7, v2)
        del v2, v3, v4, v5, v6, v7
        return method12(v8, v9, v10, v11, v12)
    return inner
def Closure1():
    def inner(v0 : object, v1 : object) -> object:
        v2 = cp.empty(16,dtype=cp.uint8)
        v3 = cp.empty(48,dtype=cp.uint8)
        v4 = method0(v0)
        v5, v6, v7, v8, v9 = method4(v1)
        v10 = v4.tag
        v11 = v2[0:].view(cp.int32)
        v11[0] = v10
        del v10, v11
        match v4:
            case US0_0(v12): # ActionSelected
                v13 = v12.tag
                v14 = v2[4:].view(cp.int32)
                v14[0] = v13
                del v13, v14
                match v12:
                    case US1_0(): # Paper
                        del v12
                    case US1_1(): # Rock
                        del v12
                    case US1_2(): # Scissors
                        del v12
            case US0_1(v15, v16): # PlayerChanged
                v17 = v15.tag
                v18 = v2[4:].view(cp.int32)
                v18[0] = v17
                del v17, v18
                match v15:
                    case US2_0(): # Computer
                        pass
                    case US2_1(): # Human
                        pass
                del v15
                v19 = v16.tag
                v20 = v2[8:].view(cp.int32)
                v20[0] = v19
                del v19, v20
                match v16:
                    case US2_0(): # Computer
                        del v16
                    case US2_1(): # Human
                        del v16
            case US0_2(): # StartGame
                pass
        del v4
        v21 = 0
        while method11(v21):
            v23 = u64(v21)
            v24 = v23 * 8
            del v23
            v25 = v3[v24:].view(cp.uint8)
            del v24
            v26 = 0 <= v21
            if v26:
                v27 = v21 < 2
                v28 = v27
            else:
                v28 = False
            del v26
            v29 = v28 == False
            if v29:
                v30 = "The read index needs to be in range."
                assert v28, v30
                del v30
            else:
                pass
            del v28, v29
            v31 = v5[v21]
            v32 = v31.tag
            v33 = v25[0:].view(cp.int32)
            v33[0] = v32
            del v32, v33
            match v31:
                case US3_0(): # None
                    pass
                case US3_1(v34): # Some
                    v35 = v34.tag
                    v36 = v25[4:].view(cp.int32)
                    v36[0] = v35
                    del v35, v36
                    match v34:
                        case US1_0(): # Paper
                            del v34
                        case US1_1(): # Rock
                            del v34
                        case US1_2(): # Scissors
                            del v34
            del v25, v31
            v21 += 1 
        del v5, v21
        v37 = v6.tag
        v38 = v3[16:].view(cp.int32)
        v38[0] = v37
        del v37, v38
        match v6:
            case US4_0(): # GameNotStarted
                pass
            case US4_1(v39, v40): # GameOver
                v41 = v39.tag
                v42 = v3[20:].view(cp.int32)
                v42[0] = v41
                del v41, v42
                match v39:
                    case US1_0(): # Paper
                        pass
                    case US1_1(): # Rock
                        pass
                    case US1_2(): # Scissors
                        pass
                del v39
                v43 = v40.tag
                v44 = v3[24:].view(cp.int32)
                v44[0] = v43
                del v43, v44
                match v40:
                    case US1_0(): # Paper
                        del v40
                    case US1_1(): # Rock
                        del v40
                    case US1_2(): # Scissors
                        del v40
            case US4_2(v45): # WaitingForActionFromPlayerId
                v46 = v3[20:].view(cp.int32)
                v46[0] = v45
                del v45, v46
        del v6
        v47 = v7.tag
        v48 = v3[28:].view(cp.int32)
        v48[0] = v47
        del v47, v48
        match v7:
            case US5_0(): # GameStarted
                pass
            case US5_1(v49, v50): # ShowdownResult
                v51 = v49.tag
                v52 = v3[32:].view(cp.int32)
                v52[0] = v51
                del v51, v52
                match v49:
                    case US1_0(): # Paper
                        pass
                    case US1_1(): # Rock
                        pass
                    case US1_2(): # Scissors
                        pass
                del v49
                v53 = v50.tag
                v54 = v3[36:].view(cp.int32)
                v54[0] = v53
                del v53, v54
                match v50:
                    case US1_0(): # Paper
                        del v50
                    case US1_1(): # Rock
                        del v50
                    case US1_2(): # Scissors
                        del v50
            case US5_2(): # WaitingToStart
                pass
        del v7
        v55 = v8.tag
        v56 = v3[40:].view(cp.int32)
        v56[0] = v55
        del v55, v56
        match v8:
            case US2_0(): # Computer
                pass
            case US2_1(): # Human
                pass
        del v8
        v57 = v9.tag
        v58 = v3[44:].view(cp.int32)
        v58[0] = v57
        del v57, v58
        match v9:
            case US2_0(): # Computer
                pass
            case US2_1(): # Human
                pass
        del v9
        v59 = 0
        v60 = raw_module.get_function(f"entry{v59}")
        del v59
        v60.max_dynamic_shared_size_bytes = 0 
        v60((1,),(512,),(v3, v2),shared_mem=0)
        del v2, v60
        v61 = [None] * 2
        v62 = 0
        while method11(v62):
            v64 = u64(v62)
            v65 = v64 * 8
            del v64
            v66 = v3[v65:].view(cp.uint8)
            del v65
            v67 = v66[0:].view(cp.int32)
            v68 = v67[0].item()
            del v67
            if v68 == 0:
                v79 = US3_0()
            elif v68 == 1:
                v71 = v66[4:].view(cp.int32)
                v72 = v71[0].item()
                del v71
                if v72 == 0:
                    v77 = US1_0()
                elif v72 == 1:
                    v77 = US1_1()
                elif v72 == 2:
                    v77 = US1_2()
                else:
                    raise Exception("Invalid tag.")
                del v72
                v79 = US3_1(v77)
            else:
                raise Exception("Invalid tag.")
            del v66, v68
            v80 = 0 <= v62
            if v80:
                v81 = v62 < 2
                v82 = v81
            else:
                v82 = False
            del v80
            v83 = v82 == False
            if v83:
                v84 = "The read index needs to be in range."
                assert v82, v84
                del v84
            else:
                pass
            del v82, v83
            v61[v62] = v79
            del v79
            v62 += 1 
        del v62
        v85 = v3[16:].view(cp.int32)
        v86 = v85[0].item()
        del v85
        if v86 == 0:
            v107 = US4_0()
        elif v86 == 1:
            v89 = v3[20:].view(cp.int32)
            v90 = v89[0].item()
            del v89
            if v90 == 0:
                v95 = US1_0()
            elif v90 == 1:
                v95 = US1_1()
            elif v90 == 2:
                v95 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v90
            v96 = v3[24:].view(cp.int32)
            v97 = v96[0].item()
            del v96
            if v97 == 0:
                v102 = US1_0()
            elif v97 == 1:
                v102 = US1_1()
            elif v97 == 2:
                v102 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v97
            v107 = US4_1(v95, v102)
        elif v86 == 2:
            v104 = v3[20:].view(cp.int32)
            v105 = v104[0].item()
            del v104
            v107 = US4_2(v105)
        else:
            raise Exception("Invalid tag.")
        del v86
        v108 = v3[28:].view(cp.int32)
        v109 = v108[0].item()
        del v108
        if v109 == 0:
            v128 = US5_0()
        elif v109 == 1:
            v112 = v3[32:].view(cp.int32)
            v113 = v112[0].item()
            del v112
            if v113 == 0:
                v118 = US1_0()
            elif v113 == 1:
                v118 = US1_1()
            elif v113 == 2:
                v118 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v113
            v119 = v3[36:].view(cp.int32)
            v120 = v119[0].item()
            del v119
            if v120 == 0:
                v125 = US1_0()
            elif v120 == 1:
                v125 = US1_1()
            elif v120 == 2:
                v125 = US1_2()
            else:
                raise Exception("Invalid tag.")
            del v120
            v128 = US5_1(v118, v125)
        elif v109 == 2:
            v128 = US5_2()
        else:
            raise Exception("Invalid tag.")
        del v109
        v129 = v3[40:].view(cp.int32)
        v130 = v129[0].item()
        del v129
        if v130 == 0:
            v134 = US2_0()
        elif v130 == 1:
            v134 = US2_1()
        else:
            raise Exception("Invalid tag.")
        del v130
        v135 = v3[44:].view(cp.int32)
        del v3
        v136 = v135[0].item()
        del v135
        if v136 == 0:
            v140 = US2_0()
        elif v136 == 1:
            v140 = US2_1()
        else:
            raise Exception("Invalid tag.")
        del v136
        return method12(v61, v107, v128, v134, v140)
    return inner
def Closure2():
    def inner() -> object:
        v0 = [None] * 2
        v1 = 0
        while method11(v1):
            v3 = 0 <= v1
            if v3:
                v4 = v1 < 2
                v5 = v4
            else:
                v5 = False
            del v3
            v6 = v5 == False
            if v6:
                v7 = "The read index needs to be in range."
                assert v5, v7
                del v7
            else:
                pass
            del v5, v6
            v8 = US3_0()
            v0[v1] = v8
            del v8
            v1 += 1 
        del v1
        v9 = US4_0()
        v10 = US5_2()
        v11 = US2_0()
        v12 = US2_1()
        return method18(v0, v9, v10, v11, v12)
    return inner
def method2(v0 : object) -> US1:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Paper" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US1_0()
    else:
        del v4
        v7 = "Rock" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US1_1()
        else:
            del v7
            v10 = "Scissors" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US1_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method3(v0 : object) -> US2:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method1(v0 : object) -> US0:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "ActionSelected" == v1
    if v4:
        del v1, v4
        v5 = method2(v2)
        del v2
        return US0_0(v5)
    else:
        del v4
        v8 = "PlayerChanged" == v1
        if v8:
            del v1, v8
            v9 = v2[0]
            v10 = method3(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method3(v11)
            del v11
            return US0_1(v10, v12)
        else:
            del v8
            v15 = "StartGame" == v1
            if v15:
                del v1, v15
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US0_2()
            else:
                del v2, v15
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method0(v0 : object) -> US0:
    return method1(v0)
def method5(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method6(v0 : object) -> US3:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method2(v2)
            del v2
            return US3_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method7(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = v2[0]
            v9 = method2(v8)
            del v8
            v10 = v2[1]
            del v2
            v11 = method2(v10)
            del v10
            return US4_1(v9, v11)
        else:
            del v7
            v14 = "WaitingForActionFromPlayerId" == v1
            if v14:
                del v1, v14
                assert isinstance(v2,i32), f'The object needs to be the right primitive type. Got: {v2}'
                v15 = v2
                del v2
                return US4_2(v15)
            else:
                del v2, v14
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method8(v0 : object) -> US5:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US5_0()
    else:
        del v4
        v7 = "ShowdownResult" == v1
        if v7:
            del v1, v7
            v8 = v2[0]
            v9 = method2(v8)
            del v8
            v10 = v2[1]
            del v2
            v11 = method2(v10)
            del v10
            return US5_1(v9, v11)
        else:
            del v7
            v14 = "WaitingToStart" == v1
            if v14:
                del v1, v14
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US5_2()
            else:
                del v2, v14
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method4(v0 : object) -> Tuple[list[US3], US4, US5, US2, US2]:
    v1 = "game_state"
    v2 = v0[v1]
    v3 = "past_actions"
    v4 = v2[v3]
    del v2, v3
    assert isinstance(v4,list), f'The object needs to be a Python list. Got: {v4}'
    v5 = len(v4)
    v6 = 2 == v5
    v7 = v6 == False
    if v7:
        v8 = "The type level dimension has to equal the value passed at runtime into create."
        assert v6, v8
        del v8
    else:
        pass
    del v6, v7
    v9 = [None] * 2
    v10 = 0
    while method5(v5, v10):
        v12 = v4[v10]
        v13 = method6(v12)
        del v12
        v14 = 0 <= v10
        if v14:
            v15 = v10 < 2
            v16 = v15
        else:
            v16 = False
        del v14
        v17 = v16 == False
        if v17:
            v18 = "The read index needs to be in range."
            assert v16, v18
            del v18
        else:
            pass
        del v16, v17
        v9[v10] = v13
        del v13
        v10 += 1 
    del v4, v5, v10
    v19 = "ui_state"
    v20 = v0[v19]
    del v0, v19
    v21 = v20[v1]
    del v1
    v22 = method7(v21)
    del v21
    v23 = "messages"
    v24 = v20[v23]
    del v23
    v25 = method8(v24)
    del v24
    v26 = "pl_type"
    v27 = v20[v26]
    del v20, v26
    v28 = v27[0]
    v29 = method3(v28)
    del v28
    v30 = v27[1]
    del v27
    v31 = method3(v30)
    del v30
    return v9, v22, v25, v29, v31
def method11(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method10(v0 : US3, v1 : list[US3], v2 : US4, v3 : US5, v4 : US2, v5 : US2) -> Tuple[list[US3], US4, US5, US2, US2]:
    match v2:
        case US4_0(): # GameNotStarted
            del v0
            return v1, v2, v3, v4, v5
        case US4_1(_, _): # GameOver
            del v0
            return v1, v2, v3, v4, v5
        case US4_2(v8): # WaitingForActionFromPlayerId
            v9 = v8 < 2
            if v9:
                del v9
                v10 = v8 == 0
                if v10:
                    v11 = v4
                else:
                    v11 = v5
                del v10
                match v11:
                    case US2_0(): # Computer
                        del v2, v11
                        match v0:
                            case US3_0(): # None
                                v13 = True
                            case _:
                                v13 = False
                        del v0
                        v14 = v13 == False
                        if v14:
                            v15 = "The computer player should never be receiving an action."
                            assert v13, v15
                            del v15
                        else:
                            pass
                        del v13, v14
                        v16 = US1_1()
                        v17 = US1_0()
                        v18 = US1_2()
                        v19 = random.choice([v16, v17, v18])
                        del v16, v17, v18
                        v20 = v8 + 1
                        v21 = [None] * 2
                        v22 = 0
                        while method11(v22):
                            v24 = 0 <= v22
                            if v24:
                                v25 = v22 < 2
                                v26 = v25
                            else:
                                v26 = False
                            v27 = v26 == False
                            if v27:
                                v28 = "The read index needs to be in range."
                                assert v26, v28
                                del v28
                            else:
                                pass
                            del v26, v27
                            v29 = v1[v22]
                            v30 = v8 == v22
                            if v30:
                                v32 = US3_1(v19)
                            else:
                                v32 = v29
                            del v29, v30
                            if v24:
                                v33 = v22 < 2
                                v34 = v33
                            else:
                                v34 = False
                            del v24
                            v35 = v34 == False
                            if v35:
                                v36 = "The read index needs to be in range."
                                assert v34, v36
                                del v36
                            else:
                                pass
                            del v34, v35
                            v21[v22] = v32
                            del v32
                            v22 += 1 
                        del v1, v8, v19, v22
                        v37 = US3_0()
                        v38 = US4_2(v20)
                        del v20
                        return method10(v37, v21, v38, v3, v4, v5)
                    case US2_1(): # Human
                        del v11
                        match v0:
                            case US3_0(): # None
                                del v0, v8
                                return v1, v2, v3, v4, v5
                            case US3_1(v44): # Some
                                del v0, v2
                                v45 = v8 + 1
                                v46 = [None] * 2
                                v47 = 0
                                while method11(v47):
                                    v49 = 0 <= v47
                                    if v49:
                                        v50 = v47 < 2
                                        v51 = v50
                                    else:
                                        v51 = False
                                    v52 = v51 == False
                                    if v52:
                                        v53 = "The read index needs to be in range."
                                        assert v51, v53
                                        del v53
                                    else:
                                        pass
                                    del v51, v52
                                    v54 = v1[v47]
                                    v55 = v8 == v47
                                    if v55:
                                        v57 = US3_1(v44)
                                    else:
                                        v57 = v54
                                    del v54, v55
                                    if v49:
                                        v58 = v47 < 2
                                        v59 = v58
                                    else:
                                        v59 = False
                                    del v49
                                    v60 = v59 == False
                                    if v60:
                                        v61 = "The read index needs to be in range."
                                        assert v59, v61
                                        del v61
                                    else:
                                        pass
                                    del v59, v60
                                    v46[v47] = v57
                                    del v57
                                    v47 += 1 
                                del v1, v8, v44, v47
                                v62 = US3_0()
                                v63 = US4_2(v45)
                                del v45
                                return method10(v62, v46, v63, v3, v4, v5)
            else:
                del v0, v2, v3, v8, v9
                v89 = v1[0]
                v90 = v1[1]
                del v1
                match v89:
                    case US3_1(v91): # Some
                        del v89
                        match v90:
                            case US3_1(v92): # Some
                                del v90
                                v93 = [None] * 2
                                v94 = 0
                                while method11(v94):
                                    v96 = 0 <= v94
                                    if v96:
                                        v97 = v94 < 2
                                        v98 = v97
                                    else:
                                        v98 = False
                                    del v96
                                    v99 = v98 == False
                                    if v99:
                                        v100 = "The read index needs to be in range."
                                        assert v98, v100
                                        del v100
                                    else:
                                        pass
                                    del v98, v99
                                    v101 = US3_0()
                                    v93[v94] = v101
                                    del v101
                                    v94 += 1 
                                del v94
                                v102 = US4_1(v91, v92)
                                v103 = US5_1(v91, v92)
                                del v91, v92
                                return v93, v102, v103, v4, v5
                            case _:
                                del v4, v5, v90, v91
                                raise Exception("At showdown all the actions have to be selected.")
                    case _:
                        del v4, v5, v89, v90
                        raise Exception("At showdown all the actions have to be selected.")
def method9(v0 : list[US3], v1 : US4, v2 : US5, v3 : US2, v4 : US2, v5 : US0) -> Tuple[list[US3], US4, US5, US2, US2]:
    match v5:
        case US0_0(v32): # ActionSelected
            v33 = US3_1(v32)
            del v32
            v49, v50, v51, v52, v53 = method10(v33, v0, v1, v2, v3, v4)
        case US0_1(v24, v25): # PlayerChanged
            v26 = US3_0()
            v49, v50, v51, v52, v53 = method10(v26, v0, v1, v2, v24, v25)
        case US0_2(): # StartGame
            v6 = [None] * 2
            v7 = 0
            while method11(v7):
                v9 = 0 <= v7
                if v9:
                    v10 = v7 < 2
                    v11 = v10
                else:
                    v11 = False
                del v9
                v12 = v11 == False
                if v12:
                    v13 = "The read index needs to be in range."
                    assert v11, v13
                    del v13
                else:
                    pass
                del v11, v12
                v14 = US3_0()
                v6[v7] = v14
                del v14
                v7 += 1 
            del v7
            v15 = US3_0()
            v16 = 0
            v17 = US4_2(v16)
            del v16
            v18 = US5_0()
            v49, v50, v51, v52, v53 = method10(v15, v6, v17, v18, v3, v4)
    del v0, v1, v2, v3, v4, v5
    return v49, v50, v51, v52, v53
def method14(v0 : US1) -> object:
    match v0:
        case US1_0(): # Paper
            del v0
            v1 = []
            v2 = "Paper"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # Rock
            del v0
            v4 = []
            v5 = "Rock"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(): # Scissors
            del v0
            v7 = []
            v8 = "Scissors"
            v9 = [v8,v7]
            del v7, v8
            return v9
def method13(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method14(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
def method15(v0 : US4) -> object:
    match v0:
        case US4_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(v4, v5): # GameOver
            del v0
            v6 = []
            v7 = method14(v4)
            del v4
            v6.append(v7)
            del v7
            v8 = method14(v5)
            del v5
            v6.append(v8)
            del v8
            v9 = v6
            del v6
            v10 = "GameOver"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US4_2(v12): # WaitingForActionFromPlayerId
            del v0
            v13 = v12
            del v12
            v14 = "WaitingForActionFromPlayerId"
            v15 = [v14,v13]
            del v13, v14
            return v15
def method16(v0 : US5) -> object:
    match v0:
        case US5_0(): # GameStarted
            del v0
            v1 = []
            v2 = "GameStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US5_1(v4, v5): # ShowdownResult
            del v0
            v6 = []
            v7 = method14(v4)
            del v4
            v6.append(v7)
            del v7
            v8 = method14(v5)
            del v5
            v6.append(v8)
            del v8
            v9 = v6
            del v6
            v10 = "ShowdownResult"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_2(): # WaitingToStart
            del v0
            v12 = []
            v13 = "WaitingToStart"
            v14 = [v13,v12]
            del v12, v13
            return v14
def method17(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = []
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = []
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
def method12(v0 : list[US3], v1 : US4, v2 : US5, v3 : US2, v4 : US2) -> object:
    v5 = []
    v6 = 0
    while method11(v6):
        v8 = 0 <= v6
        if v8:
            v9 = v6 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v0[v6]
        v14 = method13(v13)
        del v13
        v5.append(v14)
        del v14
        v6 += 1 
    del v0, v6
    v15 = {'past_actions': v5}
    del v5
    v16 = method15(v1)
    del v1
    v17 = method16(v2)
    del v2
    v18 = []
    v19 = method17(v3)
    del v3
    v18.append(v19)
    del v19
    v20 = method17(v4)
    del v4
    v18.append(v20)
    del v20
    v21 = v18
    del v18
    v22 = {'game_state': v16, 'messages': v17, 'pl_type': v21}
    del v16, v17, v21
    v23 = {'game_state': v15, 'ui_state': v22}
    del v15, v22
    return v23
def method18(v0 : list[US3], v1 : US4, v2 : US5, v3 : US2, v4 : US2) -> object:
    v5 = []
    v6 = 0
    while method11(v6):
        v8 = 0 <= v6
        if v8:
            v9 = v6 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v0[v6]
        v14 = method13(v13)
        del v13
        v5.append(v14)
        del v14
        v6 += 1 
    del v0, v6
    v15 = {'past_actions': v5}
    del v5
    v16 = method15(v1)
    del v1
    v17 = method16(v2)
    del v2
    v18 = []
    v19 = method17(v3)
    del v3
    v18.append(v19)
    del v19
    v20 = method17(v4)
    del v4
    v18.append(v20)
    del v20
    v21 = v18
    del v18
    v22 = {'game_state': v16, 'messages': v17, 'pl_type': v21}
    del v16, v17, v21
    v23 = {'game_state': v15, 'ui_state': v22}
    del v15, v22
    return v23
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = Closure2()
    v3 = collections.namedtuple("RPS_Game",['event_loop_cpu', 'event_loop_gpu', 'init'])(v0, v1, v2)
    del v0, v1, v2
    return v3

if __name__ == '__main__': print(main())
