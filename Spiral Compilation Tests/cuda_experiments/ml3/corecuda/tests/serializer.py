kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
struct US0;
struct US3;
struct US4;
struct US2;
struct US1;
struct Tuple0;
__device__ void f_1(unsigned char * v0, long v1);
__device__ void f_4(unsigned char * v0, long v1);
__device__ void f_6(unsigned char * v0);
__device__ void f_7(unsigned char * v0, unsigned long long v1);
__device__ void method_5(US0 v0, unsigned char * v1);
__device__ void f_10(unsigned char * v0, long v1);
__device__ void f_14(unsigned char * v0, float v1);
__device__ void method_13(US3 v0, unsigned char * v1);
__device__ void f_12(unsigned char * v0, char v1, unsigned char v2, US3 v3);
__device__ void f_17(unsigned char * v0, double v1);
__device__ void method_16(US4 v0, unsigned char * v1);
__device__ void f_15(unsigned char * v0, unsigned short v1, US4 v2);
__device__ void method_11(US2 v0, unsigned char * v1);
__device__ void f_9(unsigned char * v0, US2 v1);
__device__ void method_8(US1 v0, unsigned char * v1);
__device__ void f_3(unsigned char * v0, long v1, US0 v2, US1 v3);
__device__ void method_2(unsigned char * v0, static_array_list<Tuple0,14l,long> v1, unsigned long long v2);
__device__ void f_0(unsigned char * v0, short v1, unsigned long long v2, static_array_list<Tuple0,14l,long> v3, unsigned short v4);
struct Tuple1;
__device__ short method_19(unsigned char * v0);
__device__ unsigned long long method_20(unsigned char * v0);
__device__ long method_22(unsigned char * v0);
__device__ long f_21(unsigned char * v0);
__device__ long method_25(unsigned char * v0);
__device__ long method_27(unsigned char * v0);
__device__ long f_26(unsigned char * v0);
__device__ void f_29(unsigned char * v0);
__device__ unsigned long long method_31(unsigned char * v0);
__device__ unsigned long long f_30(unsigned char * v0);
__device__ US0 method_28(long v0, unsigned char * v1);
__device__ long f_34(unsigned char * v0);
struct Tuple2;
__device__ char method_37(unsigned char * v0);
__device__ unsigned char method_38(unsigned char * v0);
__device__ float method_41(unsigned char * v0);
__device__ float f_40(unsigned char * v0);
__device__ US3 method_39(long v0, unsigned char * v1);
__device__ Tuple2 f_36(unsigned char * v0);
struct Tuple3;
__device__ unsigned short method_43(unsigned char * v0);
__device__ double method_46(unsigned char * v0);
__device__ double f_45(unsigned char * v0);
__device__ US4 method_44(long v0, unsigned char * v1);
__device__ Tuple3 f_42(unsigned char * v0);
__device__ US2 method_35(long v0, unsigned char * v1);
__device__ US2 f_33(unsigned char * v0);
__device__ US1 method_32(long v0, unsigned char * v1);
__device__ Tuple0 f_24(unsigned char * v0);
__device__ void method_23(unsigned char * v0, static_array_list<Tuple0,14l,long> v1, unsigned long long v2);
__device__ unsigned short method_47(unsigned char * v0);
__device__ Tuple1 f_18(unsigned char * v0);
struct US0 {
    union {
        struct {
            unsigned long long v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US3 {
    union {
        struct {
            float v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US4 {
    union {
        struct {
            double v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct US2 {
    union {
        struct {
            US3 v2;
            unsigned char v1;
            char v0;
        } case0; // Q
        struct {
            US4 v1;
            unsigned short v0;
        } case1; // W
    } v;
    unsigned long tag : 2;
};
struct US1 {
    union {
        struct {
            US2 v0;
        } case1; // Some
    } v;
    unsigned long tag : 2;
};
struct Tuple0 {
    US0 v1;
    US1 v2;
    long v0;
    __device__ Tuple0(long t0, US0 t1, US1 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    unsigned long long v1;
    static_array_list<Tuple0,14l,long> v2;
    short v0;
    unsigned short v3;
    __device__ Tuple1(short t0, unsigned long long t1, static_array_list<Tuple0,14l,long> t2, unsigned short t3) : v0(t0), v1(t1), v2(t2), v3(t3) {}
    __device__ Tuple1() = default;
};
struct Tuple2 {
    US3 v2;
    unsigned char v1;
    char v0;
    __device__ Tuple2(char t0, unsigned char t1, US3 t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple2() = default;
};
struct Tuple3 {
    US4 v1;
    unsigned short v0;
    __device__ Tuple3(unsigned short t0, US4 t1) : v0(t0), v1(t1) {}
    __device__ Tuple3() = default;
};
__device__ US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1(unsigned long long v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
__device__ US3 US3_1(float v0) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
__device__ US4 US4_1(double v0) { // Some
    US4 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ US2 US2_0(char v0, unsigned char v1, US3 v2) { // Q
    US2 x;
    x.tag = 0;
    x.v.case0.v0 = v0; x.v.case0.v1 = v1; x.v.case0.v2 = v2;
    return x;
}
__device__ US2 US2_1(unsigned short v0, US4 v1) { // W
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
__device__ US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
__device__ US1 US1_1(US2 v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
__device__ void f_1(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+16ull);
    v2[0l] = v1;
    return ;
}
__device__ inline bool while_method_0(long v0, long v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__device__ void f_4(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+4ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_6(unsigned char * v0){
    return ;
}
__device__ void f_7(unsigned char * v0, unsigned long long v1){
    unsigned long long * v2;
    v2 = (unsigned long long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void method_5(US0 v0, unsigned char * v1){
    switch (v0.tag) {
        case 0: { // None
            return f_6(v1);
            break;
        }
        case 1: { // Some
            unsigned long long v2 = v0.v.case1.v0;
            return f_7(v1, v2);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_10(unsigned char * v0, long v1){
    long * v2;
    v2 = (long *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void f_14(unsigned char * v0, float v1){
    float * v2;
    v2 = (float *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void method_13(US3 v0, unsigned char * v1){
    switch (v0.tag) {
        case 0: { // None
            return f_6(v1);
            break;
        }
        case 1: { // Some
            float v2 = v0.v.case1.v0;
            return f_14(v1, v2);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_12(unsigned char * v0, char v1, unsigned char v2, US3 v3){
    char * v4;
    v4 = (char *)(v0+0ull);
    v4[0l] = v1;
    unsigned char * v5;
    v5 = (unsigned char *)(v0+1ull);
    v5[0l] = v2;
    long v6;
    v6 = v3.tag;
    f_4(v0, v6);
    unsigned char * v7;
    v7 = (unsigned char *)(v0+8ull);
    return method_13(v3, v7);
}
__device__ void f_17(unsigned char * v0, double v1){
    double * v2;
    v2 = (double *)(v0+0ull);
    v2[0l] = v1;
    return ;
}
__device__ void method_16(US4 v0, unsigned char * v1){
    switch (v0.tag) {
        case 0: { // None
            return f_6(v1);
            break;
        }
        case 1: { // Some
            double v2 = v0.v.case1.v0;
            return f_17(v1, v2);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_15(unsigned char * v0, unsigned short v1, US4 v2){
    unsigned short * v3;
    v3 = (unsigned short *)(v0+0ull);
    v3[0l] = v1;
    long v4;
    v4 = v2.tag;
    f_4(v0, v4);
    unsigned char * v5;
    v5 = (unsigned char *)(v0+8ull);
    return method_16(v2, v5);
}
__device__ void method_11(US2 v0, unsigned char * v1){
    switch (v0.tag) {
        case 0: { // Q
            char v2 = v0.v.case0.v0; unsigned char v3 = v0.v.case0.v1; US3 v4 = v0.v.case0.v2;
            return f_12(v1, v2, v3, v4);
            break;
        }
        case 1: { // W
            unsigned short v5 = v0.v.case1.v0; US4 v6 = v0.v.case1.v1;
            return f_15(v1, v5, v6);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_9(unsigned char * v0, US2 v1){
    long v2;
    v2 = v1.tag;
    f_10(v0, v2);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+16ull);
    return method_11(v1, v3);
}
__device__ void method_8(US1 v0, unsigned char * v1){
    switch (v0.tag) {
        case 0: { // None
            return f_6(v1);
            break;
        }
        case 1: { // Some
            US2 v2 = v0.v.case1.v0;
            return f_9(v1, v2);
            break;
        }
        default: {
            assert("Invalid tag." && false);
        }
    }
}
__device__ void f_3(unsigned char * v0, long v1, US0 v2, US1 v3){
    long * v4;
    v4 = (long *)(v0+0ull);
    v4[0l] = v1;
    long v5;
    v5 = v2.tag;
    f_4(v0, v5);
    unsigned char * v6;
    v6 = (unsigned char *)(v0+8ull);
    method_5(v2, v6);
    long v7;
    v7 = v3.tag;
    f_1(v0, v7);
    unsigned char * v8;
    v8 = (unsigned char *)(v0+32ull);
    return method_8(v3, v8);
}
__device__ void method_2(unsigned char * v0, static_array_list<Tuple0,14l,long> v1, unsigned long long v2){
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 64ull;
        unsigned long long v8;
        v8 = v2 + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        bool v10;
        v10 = 0l <= v4;
        bool v13;
        if (v10){
            long v11;
            v11 = v1.length;
            bool v12;
            v12 = v4 < v11;
            v13 = v12;
        } else {
            v13 = false;
        }
        bool v14;
        v14 = v13 == false;
        if (v14){
            assert("The read index needs to be in range for the static array list." && v13);
        } else {
        }
        long v15; US0 v16; US1 v17;
        Tuple0 tmp0 = v1.v[v4];
        v15 = tmp0.v0; v16 = tmp0.v1; v17 = tmp0.v2;
        f_3(v9, v15, v16, v17);
        v4 += 1l ;
    }
    return ;
}
__device__ void f_0(unsigned char * v0, short v1, unsigned long long v2, static_array_list<Tuple0,14l,long> v3, unsigned short v4){
    short * v5;
    v5 = (short *)(v0+0ull);
    v5[0l] = v1;
    unsigned long long * v6;
    v6 = (unsigned long long *)(v0+8ull);
    v6[0l] = v2;
    long v7;
    v7 = v3.length;
    f_1(v0, v7);
    unsigned long long v8;
    v8 = 32ull;
    method_2(v0, v3, v8);
    unsigned short * v9;
    v9 = (unsigned short *)(v0+928ull);
    v9[0l] = v4;
    return ;
}
__device__ short method_19(unsigned char * v0){
    short * v1;
    v1 = (short *)(v0+0ull);
    short v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned long long method_20(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+8ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long method_22(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+16ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_21(unsigned char * v0){
    return method_22(v0);
}
__device__ long method_25(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+0ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long method_27(unsigned char * v0){
    long * v1;
    v1 = (long *)(v0+4ull);
    long v2;
    v2 = v1[0l];
    return v2;
}
__device__ long f_26(unsigned char * v0){
    return method_27(v0);
}
__device__ void f_29(unsigned char * v0){
    return ;
}
__device__ unsigned long long method_31(unsigned char * v0){
    unsigned long long * v1;
    v1 = (unsigned long long *)(v0+0ull);
    unsigned long long v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned long long f_30(unsigned char * v0){
    return method_31(v0);
}
__device__ US0 method_28(long v0, unsigned char * v1){
    switch (v0) {
        case 0: {
            f_29(v1);
            return US0_0();
            break;
        }
        case 1: {
            unsigned long long v4;
            v4 = f_30(v1);
            return US0_1(v4);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ long f_34(unsigned char * v0){
    return method_25(v0);
}
__device__ char method_37(unsigned char * v0){
    char * v1;
    v1 = (char *)(v0+0ull);
    char v2;
    v2 = v1[0l];
    return v2;
}
__device__ unsigned char method_38(unsigned char * v0){
    unsigned char * v1;
    v1 = (unsigned char *)(v0+1ull);
    unsigned char v2;
    v2 = v1[0l];
    return v2;
}
__device__ float method_41(unsigned char * v0){
    float * v1;
    v1 = (float *)(v0+0ull);
    float v2;
    v2 = v1[0l];
    return v2;
}
__device__ float f_40(unsigned char * v0){
    return method_41(v0);
}
__device__ US3 method_39(long v0, unsigned char * v1){
    switch (v0) {
        case 0: {
            f_29(v1);
            return US3_0();
            break;
        }
        case 1: {
            float v4;
            v4 = f_40(v1);
            return US3_1(v4);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ Tuple2 f_36(unsigned char * v0){
    char v1;
    v1 = method_37(v0);
    unsigned char v2;
    v2 = method_38(v0);
    long v3;
    v3 = f_26(v0);
    unsigned char * v4;
    v4 = (unsigned char *)(v0+8ull);
    US3 v5;
    v5 = method_39(v3, v4);
    return Tuple2(v1, v2, v5);
}
__device__ unsigned short method_43(unsigned char * v0){
    unsigned short * v1;
    v1 = (unsigned short *)(v0+0ull);
    unsigned short v2;
    v2 = v1[0l];
    return v2;
}
__device__ double method_46(unsigned char * v0){
    double * v1;
    v1 = (double *)(v0+0ull);
    double v2;
    v2 = v1[0l];
    return v2;
}
__device__ double f_45(unsigned char * v0){
    return method_46(v0);
}
__device__ US4 method_44(long v0, unsigned char * v1){
    switch (v0) {
        case 0: {
            f_29(v1);
            return US4_0();
            break;
        }
        case 1: {
            double v4;
            v4 = f_45(v1);
            return US4_1(v4);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ Tuple3 f_42(unsigned char * v0){
    unsigned short v1;
    v1 = method_43(v0);
    long v2;
    v2 = f_26(v0);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+8ull);
    US4 v4;
    v4 = method_44(v2, v3);
    return Tuple3(v1, v4);
}
__device__ US2 method_35(long v0, unsigned char * v1){
    switch (v0) {
        case 0: {
            char v3; unsigned char v4; US3 v5;
            Tuple2 tmp1 = f_36(v1);
            v3 = tmp1.v0; v4 = tmp1.v1; v5 = tmp1.v2;
            return US2_0(v3, v4, v5);
            break;
        }
        case 1: {
            unsigned short v7; US4 v8;
            Tuple3 tmp2 = f_42(v1);
            v7 = tmp2.v0; v8 = tmp2.v1;
            return US2_1(v7, v8);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ US2 f_33(unsigned char * v0){
    long v1;
    v1 = f_34(v0);
    unsigned char * v2;
    v2 = (unsigned char *)(v0+16ull);
    return method_35(v1, v2);
}
__device__ US1 method_32(long v0, unsigned char * v1){
    switch (v0) {
        case 0: {
            f_29(v1);
            return US1_0();
            break;
        }
        case 1: {
            US2 v4;
            v4 = f_33(v1);
            return US1_1(v4);
            break;
        }
        default: {
            printf("%s\n", "Invalid tag.");
            asm("exit;");
        }
    }
}
__device__ Tuple0 f_24(unsigned char * v0){
    long v1;
    v1 = method_25(v0);
    long v2;
    v2 = f_26(v0);
    unsigned char * v3;
    v3 = (unsigned char *)(v0+8ull);
    US0 v4;
    v4 = method_28(v2, v3);
    long v5;
    v5 = f_21(v0);
    unsigned char * v6;
    v6 = (unsigned char *)(v0+32ull);
    US1 v7;
    v7 = method_32(v5, v6);
    return Tuple0(v1, v4, v7);
}
__device__ void method_23(unsigned char * v0, static_array_list<Tuple0,14l,long> v1, unsigned long long v2){
    long v3;
    v3 = v1.length;
    long v4;
    v4 = 0l;
    while (while_method_0(v3, v4)){
        unsigned long long v6;
        v6 = (unsigned long long)v4;
        unsigned long long v7;
        v7 = v6 * 64ull;
        unsigned long long v8;
        v8 = v2 + v7;
        unsigned char * v9;
        v9 = (unsigned char *)(v0+v8);
        long v10; US0 v11; US1 v12;
        Tuple0 tmp3 = f_24(v9);
        v10 = tmp3.v0; v11 = tmp3.v1; v12 = tmp3.v2;
        bool v13;
        v13 = 0l <= v4;
        bool v16;
        if (v13){
            long v14;
            v14 = v1.length;
            bool v15;
            v15 = v4 < v14;
            v16 = v15;
        } else {
            v16 = false;
        }
        bool v17;
        v17 = v16 == false;
        if (v17){
            assert("The set index needs to be in range for the static array list." && v16);
        } else {
        }
        v1.v[v4] = Tuple0(v10, v11, v12);
        v4 += 1l ;
    }
    return ;
}
__device__ unsigned short method_47(unsigned char * v0){
    unsigned short * v1;
    v1 = (unsigned short *)(v0+928ull);
    unsigned short v2;
    v2 = v1[0l];
    return v2;
}
__device__ Tuple1 f_18(unsigned char * v0){
    short v1;
    v1 = method_19(v0);
    unsigned long long v2;
    v2 = method_20(v0);
    static_array_list<Tuple0,14l,long> v3;
    v3.length = 0;
    long v4;
    v4 = f_21(v0);
    v3.length = v4;
    unsigned long long v5;
    v5 = 32ull;
    method_23(v0, v3, v5);
    unsigned short v6;
    v6 = method_47(v0);
    return Tuple1(v1, v2, v3, v6);
}
extern "C" __global__ void entry0(unsigned char * v0) {
    long v1;
    v1 = threadIdx.x;
    long v2;
    v2 = blockIdx.x;
    long v3;
    v3 = v2 * 512l;
    long v4;
    v4 = v1 + v3;
    bool v5;
    v5 = v4 == 0l;
    if (v5){
        static_array_list<Tuple0,14l,long> v6;
        v6.length = 0;
        v6.length = 3l;
        long v7;
        v7 = v6.length;
        bool v8;
        v8 = 0l < v7;
        bool v9;
        v9 = v8 == false;
        if (v9){
            assert("The set index needs to be in range for the static array list." && v8);
        } else {
        }
        US0 v10;
        v10 = US0_1(23ull);
        US3 v11;
        v11 = US3_1(555.0f);
        US2 v12;
        v12 = US2_0(5, 55u, v11);
        US1 v13;
        v13 = US1_1(v12);
        v6.v[0l] = Tuple0(1l, v10, v13);
        long v14;
        v14 = v6.length;
        bool v15;
        v15 = 1l < v14;
        bool v16;
        v16 = v15 == false;
        if (v16){
            assert("The set index needs to be in range for the static array list." && v15);
        } else {
        }
        US0 v17;
        v17 = US0_1(34ull);
        US4 v18;
        v18 = US4_1(222.222);
        US2 v19;
        v19 = US2_1(2u, v18);
        US1 v20;
        v20 = US1_1(v19);
        v6.v[1l] = Tuple0(2l, v17, v20);
        long v21;
        v21 = v6.length;
        bool v22;
        v22 = 2l < v21;
        bool v23;
        v23 = v22 == false;
        if (v23){
            assert("The set index needs to be in range for the static array list." && v22);
        } else {
        }
        US0 v24;
        v24 = US0_0();
        US3 v25;
        v25 = US3_1(890.876f);
        US2 v26;
        v26 = US2_0(88, 80u, v25);
        US1 v27;
        v27 = US1_1(v26);
        v6.v[2l] = Tuple0(3l, v24, v27);
        short v28;
        v28 = -2;
        unsigned long long v29;
        v29 = 555555555ull;
        unsigned short v30;
        v30 = 3412u;
        f_0(v0, v28, v29, v6, v30);
        short v31; unsigned long long v32; static_array_list<Tuple0,14l,long> v33; unsigned short v34;
        Tuple1 tmp4 = f_18(v0);
        v31 = tmp4.v0; v32 = tmp4.v1; v33 = tmp4.v2; v34 = tmp4.v3;
        const char * v35;
        v35 = "%d";
        printf(v35,v31);
        const char * v36;
        v36 = "%s";
        const char * v37;
        v37 = ", ";
        printf(v36,v37);
        const char * v38;
        v38 = "%u";
        printf(v38,v32);
        printf(v36,v37);
        const char * v39;
        v39 = "[";
        printf(v36,v39);
        long v40;
        v40 = v33.length;
        bool v41;
        v41 = 100l < v40;
        long v42;
        if (v41){
            v42 = 100l;
        } else {
            v42 = v40;
        }
        long v43;
        v43 = 0l;
        while (while_method_0(v42, v43)){
            bool v45;
            v45 = 0l <= v43;
            bool v48;
            if (v45){
                long v46;
                v46 = v33.length;
                bool v47;
                v47 = v43 < v46;
                v48 = v47;
            } else {
                v48 = false;
            }
            bool v49;
            v49 = v48 == false;
            if (v49){
                assert("The read index needs to be in range for the static array list." && v48);
            } else {
            }
            long v50; US0 v51; US1 v52;
            Tuple0 tmp5 = v33.v[v43];
            v50 = tmp5.v0; v51 = tmp5.v1; v52 = tmp5.v2;
            printf(v35,v50);
            printf(v36,v37);
            switch (v51.tag) {
                case 0: { // None
                    const char * v53;
                    v53 = "None";
                    printf(v36,v53);
                    break;
                }
                case 1: { // Some
                    unsigned long long v54 = v51.v.case1.v0;
                    const char * v55;
                    v55 = "Some";
                    printf(v36,v55);
                    const char * v56;
                    v56 = "(";
                    printf(v36,v56);
                    printf(v38,v54);
                    const char * v57;
                    v57 = ")";
                    printf(v36,v57);
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            printf(v36,v37);
            switch (v52.tag) {
                case 0: { // None
                    const char * v58;
                    v58 = "None";
                    printf(v36,v58);
                    break;
                }
                case 1: { // Some
                    US2 v59 = v52.v.case1.v0;
                    const char * v60;
                    v60 = "Some";
                    printf(v36,v60);
                    const char * v61;
                    v61 = "(";
                    printf(v36,v61);
                    switch (v59.tag) {
                        case 0: { // Q
                            char v62 = v59.v.case0.v0; unsigned char v63 = v59.v.case0.v1; US3 v64 = v59.v.case0.v2;
                            const char * v65;
                            v65 = "Q";
                            printf(v36,v65);
                            printf(v36,v61);
                            printf(v35,v62);
                            printf(v36,v37);
                            printf(v38,v63);
                            printf(v36,v37);
                            switch (v64.tag) {
                                case 0: { // None
                                    const char * v66;
                                    v66 = "None";
                                    printf(v36,v66);
                                    break;
                                }
                                case 1: { // Some
                                    float v67 = v64.v.case1.v0;
                                    printf(v36,v60);
                                    printf(v36,v61);
                                    const char * v68;
                                    v68 = "%f";
                                    printf(v68,v67);
                                    const char * v69;
                                    v69 = ")";
                                    printf(v36,v69);
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            const char * v70;
                            v70 = ")";
                            printf(v36,v70);
                            break;
                        }
                        case 1: { // W
                            unsigned short v71 = v59.v.case1.v0; US4 v72 = v59.v.case1.v1;
                            const char * v73;
                            v73 = "W";
                            printf(v36,v73);
                            printf(v36,v61);
                            printf(v38,v71);
                            printf(v36,v37);
                            switch (v72.tag) {
                                case 0: { // None
                                    const char * v74;
                                    v74 = "None";
                                    printf(v36,v74);
                                    break;
                                }
                                case 1: { // Some
                                    double v75 = v72.v.case1.v0;
                                    printf(v36,v60);
                                    printf(v36,v61);
                                    const char * v76;
                                    v76 = "%f";
                                    printf(v76,v75);
                                    const char * v77;
                                    v77 = ")";
                                    printf(v36,v77);
                                    break;
                                }
                                default: {
                                    assert("Invalid tag." && false);
                                }
                            }
                            const char * v78;
                            v78 = ")";
                            printf(v36,v78);
                            break;
                        }
                        default: {
                            assert("Invalid tag." && false);
                        }
                    }
                    const char * v79;
                    v79 = ")";
                    printf(v36,v79);
                    break;
                }
                default: {
                    assert("Invalid tag." && false);
                }
            }
            long v80;
            v80 = v43 + 1l;
            long v81;
            v81 = v33.length;
            bool v82;
            v82 = v80 < v81;
            if (v82){
                const char * v83;
                v83 = "; ";
                printf(v36,v83);
            } else {
            }
            v43 += 1l ;
        }
        long v84;
        v84 = v33.length;
        bool v85;
        v85 = v84 > 100l;
        if (v85){
            const char * v86;
            v86 = "; ...";
            printf(v36,v86);
        } else {
        }
        const char * v87;
        v87 = "]";
        printf(v36,v87);
        printf(v36,v37);
        printf(v38,v34);
        printf("\n");
        return ;
    } else {
        return ;
    }
}
"""
class static_array(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = 0
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
class US0_0(NamedTuple): # None
    tag = 0
class US0_1(NamedTuple): # Some
    v0 : u64
    tag = 1
US0 = Union[US0_0, US0_1]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : f32
    tag = 1
US3 = Union[US3_0, US3_1]
class US4_0(NamedTuple): # None
    tag = 0
class US4_1(NamedTuple): # Some
    v0 : f64
    tag = 1
US4 = Union[US4_0, US4_1]
class US2_0(NamedTuple): # Q
    v0 : i8
    v1 : u8
    v2 : US3
    tag = 0
class US2_1(NamedTuple): # W
    v0 : u16
    v1 : US4
    tag = 1
US2 = Union[US2_0, US2_1]
class US1_0(NamedTuple): # None
    tag = 0
class US1_1(NamedTuple): # Some
    v0 : US2
    tag = 1
US1 = Union[US1_0, US1_1]
def method1(v0 : cp.ndarray) -> i16:
    v1 = v0[0:].view(cp.int16)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method2(v0 : cp.ndarray) -> u64:
    v1 = v0[8:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method4(v0 : cp.ndarray) -> i32:
    v1 = v0[16:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method3(v0 : cp.ndarray) -> i32:
    return method4(v0)
def method6(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method8(v0 : cp.ndarray) -> i32:
    v1 = v0[0:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method10(v0 : cp.ndarray) -> i32:
    v1 = v0[4:].view(cp.int32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method9(v0 : cp.ndarray) -> i32:
    return method10(v0)
def method12(v0 : cp.ndarray) -> None:
    del v0
    return 
def method14(v0 : cp.ndarray) -> u64:
    v1 = v0[0:].view(cp.uint64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method13(v0 : cp.ndarray) -> u64:
    return method14(v0)
def method11(v0 : i32, v1 : cp.ndarray) -> US0:
    if v0 == 0:
        del v0
        method12(v1)
        del v1
        return US0_0()
    elif v0 == 1:
        del v0
        v4 = method13(v1)
        del v1
        return US0_1(v4)
    else:
        del v0, v1
        raise Exception("Invalid tag.")
def method17(v0 : cp.ndarray) -> i32:
    return method8(v0)
def method20(v0 : cp.ndarray) -> i8:
    v1 = v0[0:].view(cp.int8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method21(v0 : cp.ndarray) -> u8:
    v1 = v0[1:].view(cp.uint8)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method24(v0 : cp.ndarray) -> f32:
    v1 = v0[0:].view(cp.float32)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method23(v0 : cp.ndarray) -> f32:
    return method24(v0)
def method22(v0 : i32, v1 : cp.ndarray) -> US3:
    if v0 == 0:
        del v0
        method12(v1)
        del v1
        return US3_0()
    elif v0 == 1:
        del v0
        v4 = method23(v1)
        del v1
        return US3_1(v4)
    else:
        del v0, v1
        raise Exception("Invalid tag.")
def method19(v0 : cp.ndarray) -> Tuple[i8, u8, US3]:
    v1 = method20(v0)
    v2 = method21(v0)
    v3 = method9(v0)
    v4 = v0[8:].view(cp.uint8)
    del v0
    v5 = method22(v3, v4)
    del v3, v4
    return v1, v2, v5
def method26(v0 : cp.ndarray) -> u16:
    v1 = v0[0:].view(cp.uint16)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method29(v0 : cp.ndarray) -> f64:
    v1 = v0[0:].view(cp.float64)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method28(v0 : cp.ndarray) -> f64:
    return method29(v0)
def method27(v0 : i32, v1 : cp.ndarray) -> US4:
    if v0 == 0:
        del v0
        method12(v1)
        del v1
        return US4_0()
    elif v0 == 1:
        del v0
        v4 = method28(v1)
        del v1
        return US4_1(v4)
    else:
        del v0, v1
        raise Exception("Invalid tag.")
def method25(v0 : cp.ndarray) -> Tuple[u16, US4]:
    v1 = method26(v0)
    v2 = method9(v0)
    v3 = v0[8:].view(cp.uint8)
    del v0
    v4 = method27(v2, v3)
    del v2, v3
    return v1, v4
def method18(v0 : i32, v1 : cp.ndarray) -> US2:
    if v0 == 0:
        del v0
        v3, v4, v5 = method19(v1)
        del v1
        return US2_0(v3, v4, v5)
    elif v0 == 1:
        del v0
        v7, v8 = method25(v1)
        del v1
        return US2_1(v7, v8)
    else:
        del v0, v1
        raise Exception("Invalid tag.")
def method16(v0 : cp.ndarray) -> US2:
    v1 = method17(v0)
    v2 = v0[16:].view(cp.uint8)
    del v0
    return method18(v1, v2)
def method15(v0 : i32, v1 : cp.ndarray) -> US1:
    if v0 == 0:
        del v0
        method12(v1)
        del v1
        return US1_0()
    elif v0 == 1:
        del v0
        v4 = method16(v1)
        del v1
        return US1_1(v4)
    else:
        del v0, v1
        raise Exception("Invalid tag.")
def method7(v0 : cp.ndarray) -> Tuple[i32, US0, US1]:
    v1 = method8(v0)
    v2 = method9(v0)
    v3 = v0[8:].view(cp.uint8)
    v4 = method11(v2, v3)
    del v2, v3
    v5 = method3(v0)
    v6 = v0[32:].view(cp.uint8)
    del v0
    v7 = method15(v5, v6)
    del v5, v6
    return v1, v4, v7
def method5(v0 : cp.ndarray, v1 : static_array_list, v2 : u64) -> None:
    v3 = v1.length
    v4 = 0
    while method6(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 64
        del v6
        v8 = v2 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10, v11, v12 = method7(v9)
        del v9
        v13 = 0 <= v4
        if v13:
            v14 = v1.length
            v15 = v4 < v14
            del v14
            v16 = v15
        else:
            v16 = False
        del v13
        v17 = v16 == False
        if v17:
            v18 = "The set index needs to be in range for the static array list."
            assert v16, v18
            del v18
        else:
            pass
        del v16, v17
        v1[v4] = (v10, v11, v12)
        del v10, v11, v12
        v4 += 1 
    del v0, v1, v2, v3, v4
    return 
def method30(v0 : cp.ndarray) -> u16:
    v1 = v0[928:].view(cp.uint16)
    del v0
    v2 = v1[0].item()
    del v1
    return v2
def method0(v0 : cp.ndarray) -> Tuple[i16, u64, static_array_list, u16]:
    v1 = method1(v0)
    v2 = method2(v0)
    v3 = static_array_list(14)
    v4 = method3(v0)
    v3.length = v4
    del v4
    v5 = 32
    method5(v0, v3, v5)
    del v5
    v6 = method30(v0)
    del v0
    return v1, v2, v3, v6
def main():
    v0 = cp.empty(944,dtype=cp.uint8)
    v1 = 0
    v2 = raw_module.get_function(f"entry{v1}")
    del v1
    v2.max_dynamic_shared_size_bytes = 0 
    v2((1,),(512,),v0,shared_mem=0)
    del v2
    v3, v4, v5, v6 = method0(v0)
    del v0
    print(v3, end="")
    del v3
    v7 = ", "
    print(v7, end="")
    print(v4, end="")
    del v4
    print(v7, end="")
    v8 = "["
    print(v8, end="")
    del v8
    v9 = v5.length
    v10 = 100 < v9
    if v10:
        v11 = 100
    else:
        v11 = v9
    del v9, v10
    v12 = 0
    while method6(v11, v12):
        v14 = 0 <= v12
        if v14:
            v15 = v5.length
            v16 = v12 < v15
            del v15
            v17 = v16
        else:
            v17 = False
        del v14
        v18 = v17 == False
        if v18:
            v19 = "The read index needs to be in range for the static array list."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        v20, v21, v22 = v5[v12]
        print(v20, end="")
        del v20
        print(v7, end="")
        match v21:
            case US0_0(): # None
                v23 = "None"
                print(v23, end="")
                del v23
            case US0_1(v24): # Some
                v25 = "Some"
                print(v25, end="")
                del v25
                v26 = "("
                print(v26, end="")
                del v26
                print(v24, end="")
                del v24
                v27 = ")"
                print(v27, end="")
                del v27
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v21
        print(v7, end="")
        match v22:
            case US1_0(): # None
                v28 = "None"
                print(v28, end="")
                del v28
            case US1_1(v29): # Some
                v30 = "Some"
                print(v30, end="")
                v31 = "("
                print(v31, end="")
                match v29:
                    case US2_0(v32, v33, v34): # Q
                        v35 = "Q"
                        print(v35, end="")
                        del v35
                        print(v31, end="")
                        print(v32, end="")
                        del v32
                        print(v7, end="")
                        print(v33, end="")
                        del v33
                        print(v7, end="")
                        match v34:
                            case US3_0(): # None
                                v36 = "None"
                                print(v36, end="")
                                del v36
                            case US3_1(v37): # Some
                                print(v30, end="")
                                print(v31, end="")
                                print("{:.6f}".format(v37), end="")
                                del v37
                                v38 = ")"
                                print(v38, end="")
                                del v38
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v34
                        v39 = ")"
                        print(v39, end="")
                        del v39
                    case US2_1(v40, v41): # W
                        v42 = "W"
                        print(v42, end="")
                        del v42
                        print(v31, end="")
                        print(v40, end="")
                        del v40
                        print(v7, end="")
                        match v41:
                            case US4_0(): # None
                                v43 = "None"
                                print(v43, end="")
                                del v43
                            case US4_1(v44): # Some
                                print(v30, end="")
                                print(v31, end="")
                                print("{:.6f}".format(v44), end="")
                                del v44
                                v45 = ")"
                                print(v45, end="")
                                del v45
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                        del v41
                        v46 = ")"
                        print(v46, end="")
                        del v46
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v29, v30, v31
                v47 = ")"
                print(v47, end="")
                del v47
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v22
        v48 = v12 + 1
        v49 = v5.length
        v50 = v48 < v49
        del v48, v49
        if v50:
            v51 = "; "
            print(v51, end="")
            del v51
        else:
            pass
        del v50
        v12 += 1 
    del v11, v12
    v52 = v5.length
    del v5
    v53 = v52 > 100
    del v52
    if v53:
        v54 = "; ..."
        print(v54, end="")
        del v54
    else:
        pass
    del v53
    v55 = "]"
    print(v55, end="")
    del v55
    print(v7, end="")
    del v7
    print(v6, end="")
    del v6
    print()
    return 

if __name__ == '__main__': print(main())
