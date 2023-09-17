#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include "ap_int.h"
#include <iostream>
#include <algorithm>
typedef struct {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
} Tuple0;
typedef struct {
    array<5l,Tuple0> v0;
    ap_uint<4l> v1;
} Tuple1;
typedef bool (* Fun0)(ap_uint<4l>, ap_uint<2l>, ap_uint<4l>, ap_uint<2l>);
typedef struct {
    ap_uint<4l> v2;
    int32_t v1;
    int32_t v0;
} Tuple2;
typedef struct {
    ap_uint<4l> v1;
    int32_t v0;
} Tuple3;
struct US0 {
    unsigned int tag : 1;
    union U {
        struct {
            array<2l,Tuple0> v0;
            array<6l,Tuple0> v1;
        } case1; // Some
        U() {}
    } v;
    US0() {}
    US0(const US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US0(const US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US0 & operator=(US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US0 & operator=(US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US1 {
    unsigned int tag : 1;
    union U {
        struct {
            array<5l,Tuple0> v0;
        } case1; // Some
        U() {}
    } v;
    US1() {}
    US1(const US1 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US1(const US1 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US1 & operator=(US1 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US1 & operator=(US1 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US2 {
    unsigned int tag : 1;
    union U {
        struct {
            array<2l,Tuple0> v0;
            array<4l,Tuple0> v1;
        } case1; // Some
        U() {}
    } v;
    US2() {}
    US2(const US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US2(const US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US2 & operator=(US2 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US2 & operator=(US2 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US3 {
    unsigned int tag : 1;
    union U {
        struct {
            array<3l,Tuple0> v0;
            array<5l,Tuple0> v1;
        } case1; // Some
        U() {}
    } v;
    US3() {}
    US3(const US3 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US3(const US3 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US3 & operator=(US3 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US3 & operator=(US3 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple4;
struct US4 {
    unsigned int tag : 2;
    union U {
        U() {}
    } v;
    US4() {}
    US4(const US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US4(const US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US4 & operator=(US4 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
    US4 & operator=(US4 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
};
typedef struct {
    US4 v1;
    int32_t v0;
} Tuple5;
struct US5 {
    unsigned int tag : 1;
    union U {
        struct {
            array<2l,Tuple0> v0;
            array<3l,Tuple0> v1;
        } case1; // Some
        U() {}
    } v;
    US5() {}
    US5(const US5 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US5(const US5 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US5 & operator=(US5 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US5 & operator=(US5 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US6 {
    unsigned int tag : 1;
    union U {
        struct {
            array<4l,Tuple0> v0;
            array<4l,Tuple0> v1;
        } case1; // Some
        U() {}
    } v;
    US6() {}
    US6(const US6 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US6(const US6 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US6 & operator=(US6 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US6 & operator=(US6 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
struct US7 {
    unsigned int tag : 1;
    union U {
        struct {
            array<5l,Tuple0> v0;
            ap_uint<4l> v1;
        } case1; // Some
        U() {}
    } v;
    US7() {}
    US7(const US7 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US7(const US7 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US7 & operator=(US7 & x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
    US7 & operator=(US7 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
bool method1(int32_t v0);
bool method2(int32_t v0);
bool method3(int32_t v0, int32_t v1);
bool method4(int32_t v0);
bool method5(int32_t v0);
bool method6(int32_t v0);
bool method7(int32_t v0);
bool method8(int32_t v0);
Tuple1 score0(array<8l,Tuple0> v0);
static inline Tuple0 TupleCreate0(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline Tuple1 TupleCreate1(array<5l,Tuple0> v0, ap_uint<4l> v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 8l;
    return v1;
}
bool ClosureMethod0(ap_uint<4l> v0, ap_uint<2l> v1, ap_uint<4l> v2, ap_uint<2l> v3){
    bool v4;
    v4 = v0 > v2;
    if (v4){
        return true;
    } else {
        bool v5;
        v5 = v0 == v2;
        if (v5){
            bool v6;
            v6 = v1 < v3;
            return v6;
        } else {
            return false;
        }
    }
}
bool method2(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
static inline Tuple2 TupleCreate2(int32_t v0, int32_t v1, ap_uint<4l> v2){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline Tuple3 TupleCreate3(int32_t v0, ap_uint<4l> v1){
    Tuple3 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(array<2l,Tuple0> v0, array<6l,Tuple0> v1) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method3(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
bool method4(int32_t v0){
    bool v1;
    v1 = v0 < 6l;
    return v1;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(array<5l,Tuple0> v0) { // Some
    US1 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
bool method5(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool method6(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(array<2l,Tuple0> v0, array<4l,Tuple0> v1) { // Some
    US2 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
bool method7(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
bool method8(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(array<3l,Tuple0> v0, array<5l,Tuple0> v1) { // Some
    US3 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
static inline Tuple4 TupleCreate4(int32_t v0, int32_t v1){
    Tuple4 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US4 US4_0() { // Eq
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1() { // Gt
    US4 x;
    x.tag = 1;
    return x;
}
US4 US4_2() { // Lt
    US4 x;
    x.tag = 2;
    return x;
}
static inline Tuple5 TupleCreate5(int32_t v0, US4 v1){
    Tuple5 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(array<2l,Tuple0> v0, array<3l,Tuple0> v1) { // Some
    US5 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(array<4l,Tuple0> v0, array<4l,Tuple0> v1) { // Some
    US6 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(array<5l,Tuple0> v0, ap_uint<4l> v1) { // Some
    US7 x;
    x.tag = 1;
    x.v.case1.v0 = v0; x.v.case1.v1 = v1;
    return x;
}
Tuple1 score0(array<8l,Tuple0> v0){
    array<8l,Tuple0> v1;
    int32_t v2;
    v2 = 0l;
    while (method1(v2)){
        ap_uint<4l> v4; ap_uint<2l> v5;
        Tuple0 tmp0 = v0.v[v2];
        v4 = tmp0.v0; v5 = tmp0.v1;
        v1.v[v2] = TupleCreate0(v4, v5);
        v2++;
    }
    Fun0 v6;
    v6 = ClosureMethod0;
    std::sort(v1.v,v1.v+8l,v6);
    array<5l,Tuple0> v7;
    int32_t v8;
    v8 = 0l;
    while (method2(v8)){
        ap_uint<4l> v10; ap_uint<2l> v11;
        Tuple0 tmp1 = v1.v[v8];
        v10 = tmp1.v0; v11 = tmp1.v1;
        v7.v[v8] = TupleCreate0(v10, v11);
        v8++;
    }
    array<2l,Tuple0> v12;
    array<6l,Tuple0> v13;
    ap_uint<4l> v14;
    v14 = 12ul;
    int32_t v15; int32_t v16; ap_uint<4l> v17;
    Tuple2 tmp2 = TupleCreate2(0l, 0l, v14);
    v15 = tmp2.v0; v16 = tmp2.v1; v17 = tmp2.v2;
    while (method1(v15)){
        ap_uint<4l> v19; ap_uint<2l> v20;
        Tuple0 tmp3 = v1.v[v15];
        v19 = tmp3.v0; v20 = tmp3.v1;
        bool v21;
        v21 = v16 < 2l;
        int32_t v25; ap_uint<4l> v26;
        if (v21){
            bool v22;
            v22 = v17 == v19;
            int32_t v23;
            if (v22){
                v23 = v16;
            } else {
                v23 = 0l;
            }
            v12.v[v23] = TupleCreate0(v19, v20);
            int32_t v24;
            v24 = v23 + 1l;
            v25 = v24; v26 = v19;
        } else {
            v25 = v16; v26 = v17;
        }
        TupleCreate3(v16, v17) = TupleCreate3(v25, v26);
        v15++;
    }
    bool v27;
    v27 = v16 == 2l;
    US0 v40;
    if (v27){
        int32_t v28;
        v28 = v16 - 2l;
        int32_t v29;
        v29 = 0l;
        while (method3(v28, v29)){
            ap_uint<4l> v31; ap_uint<2l> v32;
            Tuple0 tmp4 = v1.v[v29];
            v31 = tmp4.v0; v32 = tmp4.v1;
            v13.v[v29] = TupleCreate0(v31, v32);
            v29++;
        }
        int32_t v33;
        v33 = v28;
        while (method4(v33)){
            int32_t v35;
            v35 = 2l + v33;
            ap_uint<4l> v36; ap_uint<2l> v37;
            Tuple0 tmp5 = v1.v[v35];
            v36 = tmp5.v0; v37 = tmp5.v1;
            v13.v[v33] = TupleCreate0(v36, v37);
            v33++;
        }
        v40 = US0_1(v12, v13);
    } else {
        v40 = US0_0();
    }
    US1 v62;
    switch (v40.tag) {
        case 0: { // None
            v62 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple0> v41 = v40.v.case1.v0; array<6l,Tuple0> v42 = v40.v.case1.v1;
            array<3l,Tuple0> v43;
            int32_t v44;
            v44 = 0l;
            while (method5(v44)){
                ap_uint<4l> v46; ap_uint<2l> v47;
                Tuple0 tmp6 = v42.v[v44];
                v46 = tmp6.v0; v47 = tmp6.v1;
                v43.v[v44] = TupleCreate0(v46, v47);
                v44++;
            }
            array<0l,Tuple0> v48;
            array<5l,Tuple0> v49;
            int32_t v50;
            v50 = 0l;
            while (method6(v50)){
                ap_uint<4l> v52; ap_uint<2l> v53;
                Tuple0 tmp7 = v41.v[v50];
                v52 = tmp7.v0; v53 = tmp7.v1;
                v49.v[v50] = TupleCreate0(v52, v53);
                v50++;
            }
            int32_t v54;
            v54 = 0l;
            while (method5(v54)){
                ap_uint<4l> v56; ap_uint<2l> v57;
                Tuple0 tmp8 = v43.v[v54];
                v56 = tmp8.v0; v57 = tmp8.v1;
                int32_t v58;
                v58 = 2l + v54;
                v49.v[v58] = TupleCreate0(v56, v57);
                v54++;
            }
            v62 = US1_1(v49);
            break;
        }
    }
    array<2l,Tuple0> v63;
    array<6l,Tuple0> v64;
    ap_uint<4l> v65;
    v65 = 12ul;
    int32_t v66; int32_t v67; ap_uint<4l> v68;
    Tuple2 tmp9 = TupleCreate2(0l, 0l, v65);
    v66 = tmp9.v0; v67 = tmp9.v1; v68 = tmp9.v2;
    while (method1(v66)){
        ap_uint<4l> v70; ap_uint<2l> v71;
        Tuple0 tmp10 = v1.v[v66];
        v70 = tmp10.v0; v71 = tmp10.v1;
        bool v72;
        v72 = v67 < 2l;
        int32_t v76; ap_uint<4l> v77;
        if (v72){
            bool v73;
            v73 = v68 == v70;
            int32_t v74;
            if (v73){
                v74 = v67;
            } else {
                v74 = 0l;
            }
            v63.v[v74] = TupleCreate0(v70, v71);
            int32_t v75;
            v75 = v74 + 1l;
            v76 = v75; v77 = v70;
        } else {
            v76 = v67; v77 = v68;
        }
        TupleCreate3(v67, v68) = TupleCreate3(v76, v77);
        v66++;
    }
    bool v78;
    v78 = v67 == 2l;
    US0 v91;
    if (v78){
        int32_t v79;
        v79 = v67 - 2l;
        int32_t v80;
        v80 = 0l;
        while (method3(v79, v80)){
            ap_uint<4l> v82; ap_uint<2l> v83;
            Tuple0 tmp11 = v1.v[v80];
            v82 = tmp11.v0; v83 = tmp11.v1;
            v64.v[v80] = TupleCreate0(v82, v83);
            v80++;
        }
        int32_t v84;
        v84 = v79;
        while (method4(v84)){
            int32_t v86;
            v86 = 2l + v84;
            ap_uint<4l> v87; ap_uint<2l> v88;
            Tuple0 tmp12 = v1.v[v86];
            v87 = tmp12.v0; v88 = tmp12.v1;
            v64.v[v84] = TupleCreate0(v87, v88);
            v84++;
        }
        v91 = US0_1(v63, v64);
    } else {
        v91 = US0_0();
    }
    US1 v151;
    switch (v91.tag) {
        case 0: { // None
            v151 = US1_0();
            break;
        }
        case 1: { // Some
            array<2l,Tuple0> v92 = v91.v.case1.v0; array<6l,Tuple0> v93 = v91.v.case1.v1;
            array<2l,Tuple0> v94;
            array<4l,Tuple0> v95;
            ap_uint<4l> v96;
            v96 = 12ul;
            int32_t v97; int32_t v98; ap_uint<4l> v99;
            Tuple2 tmp13 = TupleCreate2(0l, 0l, v96);
            v97 = tmp13.v0; v98 = tmp13.v1; v99 = tmp13.v2;
            while (method4(v97)){
                ap_uint<4l> v101; ap_uint<2l> v102;
                Tuple0 tmp14 = v93.v[v97];
                v101 = tmp14.v0; v102 = tmp14.v1;
                bool v103;
                v103 = v98 < 2l;
                int32_t v107; ap_uint<4l> v108;
                if (v103){
                    bool v104;
                    v104 = v99 == v101;
                    int32_t v105;
                    if (v104){
                        v105 = v98;
                    } else {
                        v105 = 0l;
                    }
                    v94.v[v105] = TupleCreate0(v101, v102);
                    int32_t v106;
                    v106 = v105 + 1l;
                    v107 = v106; v108 = v101;
                } else {
                    v107 = v98; v108 = v99;
                }
                TupleCreate3(v98, v99) = TupleCreate3(v107, v108);
                v97++;
            }
            bool v109;
            v109 = v98 == 2l;
            US2 v122;
            if (v109){
                int32_t v110;
                v110 = v98 - 2l;
                int32_t v111;
                v111 = 0l;
                while (method3(v110, v111)){
                    ap_uint<4l> v113; ap_uint<2l> v114;
                    Tuple0 tmp15 = v93.v[v111];
                    v113 = tmp15.v0; v114 = tmp15.v1;
                    v95.v[v111] = TupleCreate0(v113, v114);
                    v111++;
                }
                int32_t v115;
                v115 = v110;
                while (method7(v115)){
                    int32_t v117;
                    v117 = 2l + v115;
                    ap_uint<4l> v118; ap_uint<2l> v119;
                    Tuple0 tmp16 = v93.v[v117];
                    v118 = tmp16.v0; v119 = tmp16.v1;
                    v95.v[v115] = TupleCreate0(v118, v119);
                    v115++;
                }
                v122 = US2_1(v94, v95);
            } else {
                v122 = US2_0();
            }
            switch (v122.tag) {
                case 0: { // None
                    v151 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple0> v123 = v122.v.case1.v0; array<4l,Tuple0> v124 = v122.v.case1.v1;
                    array<1l,Tuple0> v125;
                    int32_t v126;
                    v126 = 0l;
                    while (method8(v126)){
                        ap_uint<4l> v128; ap_uint<2l> v129;
                        Tuple0 tmp17 = v124.v[v126];
                        v128 = tmp17.v0; v129 = tmp17.v1;
                        v125.v[v126] = TupleCreate0(v128, v129);
                        v126++;
                    }
                    array<5l,Tuple0> v130;
                    int32_t v131;
                    v131 = 0l;
                    while (method6(v131)){
                        ap_uint<4l> v133; ap_uint<2l> v134;
                        Tuple0 tmp18 = v92.v[v131];
                        v133 = tmp18.v0; v134 = tmp18.v1;
                        v130.v[v131] = TupleCreate0(v133, v134);
                        v131++;
                    }
                    int32_t v135;
                    v135 = 0l;
                    while (method6(v135)){
                        ap_uint<4l> v137; ap_uint<2l> v138;
                        Tuple0 tmp19 = v123.v[v135];
                        v137 = tmp19.v0; v138 = tmp19.v1;
                        int32_t v139;
                        v139 = 2l + v135;
                        v130.v[v139] = TupleCreate0(v137, v138);
                        v135++;
                    }
                    int32_t v140;
                    v140 = 0l;
                    while (method8(v140)){
                        ap_uint<4l> v142; ap_uint<2l> v143;
                        Tuple0 tmp20 = v125.v[v140];
                        v142 = tmp20.v0; v143 = tmp20.v1;
                        int32_t v144;
                        v144 = 4l + v140;
                        v130.v[v144] = TupleCreate0(v142, v143);
                        v140++;
                    }
                    v151 = US1_1(v130);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple0> v152;
    array<5l,Tuple0> v153;
    ap_uint<4l> v154;
    v154 = 12ul;
    int32_t v155; int32_t v156; ap_uint<4l> v157;
    Tuple2 tmp21 = TupleCreate2(0l, 0l, v154);
    v155 = tmp21.v0; v156 = tmp21.v1; v157 = tmp21.v2;
    while (method1(v155)){
        ap_uint<4l> v159; ap_uint<2l> v160;
        Tuple0 tmp22 = v1.v[v155];
        v159 = tmp22.v0; v160 = tmp22.v1;
        bool v161;
        v161 = v156 < 3l;
        int32_t v165; ap_uint<4l> v166;
        if (v161){
            bool v162;
            v162 = v157 == v159;
            int32_t v163;
            if (v162){
                v163 = v156;
            } else {
                v163 = 0l;
            }
            v152.v[v163] = TupleCreate0(v159, v160);
            int32_t v164;
            v164 = v163 + 1l;
            v165 = v164; v166 = v159;
        } else {
            v165 = v156; v166 = v157;
        }
        TupleCreate3(v156, v157) = TupleCreate3(v165, v166);
        v155++;
    }
    bool v167;
    v167 = v156 == 3l;
    US3 v180;
    if (v167){
        int32_t v168;
        v168 = v156 - 3l;
        int32_t v169;
        v169 = 0l;
        while (method3(v168, v169)){
            ap_uint<4l> v171; ap_uint<2l> v172;
            Tuple0 tmp23 = v1.v[v169];
            v171 = tmp23.v0; v172 = tmp23.v1;
            v153.v[v169] = TupleCreate0(v171, v172);
            v169++;
        }
        int32_t v173;
        v173 = v168;
        while (method2(v173)){
            int32_t v175;
            v175 = 3l + v173;
            ap_uint<4l> v176; ap_uint<2l> v177;
            Tuple0 tmp24 = v1.v[v175];
            v176 = tmp24.v0; v177 = tmp24.v1;
            v153.v[v173] = TupleCreate0(v176, v177);
            v173++;
        }
        v180 = US3_1(v152, v153);
    } else {
        v180 = US3_0();
    }
    US1 v202;
    switch (v180.tag) {
        case 0: { // None
            v202 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple0> v181 = v180.v.case1.v0; array<5l,Tuple0> v182 = v180.v.case1.v1;
            array<2l,Tuple0> v183;
            int32_t v184;
            v184 = 0l;
            while (method6(v184)){
                ap_uint<4l> v186; ap_uint<2l> v187;
                Tuple0 tmp25 = v182.v[v184];
                v186 = tmp25.v0; v187 = tmp25.v1;
                v183.v[v184] = TupleCreate0(v186, v187);
                v184++;
            }
            array<0l,Tuple0> v188;
            array<5l,Tuple0> v189;
            int32_t v190;
            v190 = 0l;
            while (method5(v190)){
                ap_uint<4l> v192; ap_uint<2l> v193;
                Tuple0 tmp26 = v181.v[v190];
                v192 = tmp26.v0; v193 = tmp26.v1;
                v189.v[v190] = TupleCreate0(v192, v193);
                v190++;
            }
            int32_t v194;
            v194 = 0l;
            while (method6(v194)){
                ap_uint<4l> v196; ap_uint<2l> v197;
                Tuple0 tmp27 = v183.v[v194];
                v196 = tmp27.v0; v197 = tmp27.v1;
                int32_t v198;
                v198 = 3l + v194;
                v189.v[v198] = TupleCreate0(v196, v197);
                v194++;
            }
            v202 = US1_1(v189);
            break;
        }
    }
    array<5l,Tuple0> v203;
    ap_uint<4l> v204;
    v204 = 12ul;
    int32_t v205; int32_t v206; ap_uint<4l> v207;
    Tuple2 tmp28 = TupleCreate2(0l, 0l, v204);
    v205 = tmp28.v0; v206 = tmp28.v1; v207 = tmp28.v2;
    while (method1(v205)){
        ap_uint<4l> v209; ap_uint<2l> v210;
        Tuple0 tmp29 = v1.v[v205];
        v209 = tmp29.v0; v210 = tmp29.v1;
        bool v211;
        v211 = v206 < 5l;
        bool v216;
        if (v211){
            ap_uint<4l> v212;
            v212 = 1ul;
            ap_uint<4l> v213;
            v213 = v209 - v212;
            bool v214;
            v214 = v207 == v213;
            bool v215;
            v215 = v214 != true;
            v216 = v215;
        } else {
            v216 = false;
        }
        int32_t v222; ap_uint<4l> v223;
        if (v216){
            bool v217;
            v217 = v207 == v209;
            int32_t v218;
            if (v217){
                v218 = v206;
            } else {
                v218 = 0l;
            }
            v203.v[v218] = TupleCreate0(v209, v210);
            int32_t v219;
            v219 = v218 + 1l;
            ap_uint<4l> v220;
            v220 = 1ul;
            ap_uint<4l> v221;
            v221 = v209 - v220;
            v222 = v219; v223 = v221;
        } else {
            v222 = v206; v223 = v207;
        }
        TupleCreate3(v206, v207) = TupleCreate3(v222, v223);
        v205++;
    }
    bool v224;
    v224 = v206 == 4l;
    bool v235;
    if (v224){
        ap_uint<4l> v225;
        v225 = 0ul;
        ap_uint<4l> v226;
        v226 = 1ul;
        ap_uint<4l> v227;
        v227 = v225 - v226;
        bool v228;
        v228 = v207 == v227;
        if (v228){
            ap_uint<4l> v229; ap_uint<2l> v230;
            Tuple0 tmp30 = v1.v[0l];
            v229 = tmp30.v0; v230 = tmp30.v1;
            ap_uint<4l> v231;
            v231 = 12ul;
            bool v232;
            v232 = v229 == v231;
            if (v232){
                v203.v[4l] = TupleCreate0(v229, v230);
                v235 = true;
            } else {
                v235 = false;
            }
        } else {
            v235 = false;
        }
    } else {
        v235 = false;
    }
    US1 v241;
    if (v235){
        v241 = US1_1(v203);
    } else {
        bool v237;
        v237 = v206 == 5l;
        if (v237){
            v241 = US1_1(v203);
        } else {
            v241 = US1_0();
        }
    }
    array<5l,Tuple0> v242;
    int32_t v243; int32_t v244;
    Tuple4 tmp31 = TupleCreate4(0l, 0l);
    v243 = tmp31.v0; v244 = tmp31.v1;
    while (method1(v243)){
        ap_uint<4l> v246; ap_uint<2l> v247;
        Tuple0 tmp32 = v1.v[v243];
        v246 = tmp32.v0; v247 = tmp32.v1;
        ap_uint<2l> v248;
        v248 = 3ul;
        bool v249;
        v249 = v247 == v248;
        bool v251;
        if (v249){
            bool v250;
            v250 = v244 < 5l;
            v251 = v250;
        } else {
            v251 = false;
        }
        int32_t v253;
        if (v251){
            v242.v[v244] = TupleCreate0(v246, v247);
            int32_t v252;
            v252 = v244 + 1l;
            v253 = v252;
        } else {
            v253 = v244;
        }
        v244 = v253;
        v243++;
    }
    bool v254;
    v254 = v244 == 5l;
    US1 v257;
    if (v254){
        v257 = US1_1(v242);
    } else {
        v257 = US1_0();
    }
    array<5l,Tuple0> v258;
    int32_t v259; int32_t v260;
    Tuple4 tmp33 = TupleCreate4(0l, 0l);
    v259 = tmp33.v0; v260 = tmp33.v1;
    while (method1(v259)){
        ap_uint<4l> v262; ap_uint<2l> v263;
        Tuple0 tmp34 = v1.v[v259];
        v262 = tmp34.v0; v263 = tmp34.v1;
        ap_uint<2l> v264;
        v264 = 2ul;
        bool v265;
        v265 = v263 == v264;
        bool v267;
        if (v265){
            bool v266;
            v266 = v260 < 5l;
            v267 = v266;
        } else {
            v267 = false;
        }
        int32_t v269;
        if (v267){
            v258.v[v260] = TupleCreate0(v262, v263);
            int32_t v268;
            v268 = v260 + 1l;
            v269 = v268;
        } else {
            v269 = v260;
        }
        v260 = v269;
        v259++;
    }
    bool v270;
    v270 = v260 == 5l;
    US1 v273;
    if (v270){
        v273 = US1_1(v258);
    } else {
        v273 = US1_0();
    }
    array<5l,Tuple0> v274;
    int32_t v275; int32_t v276;
    Tuple4 tmp35 = TupleCreate4(0l, 0l);
    v275 = tmp35.v0; v276 = tmp35.v1;
    while (method1(v275)){
        ap_uint<4l> v278; ap_uint<2l> v279;
        Tuple0 tmp36 = v1.v[v275];
        v278 = tmp36.v0; v279 = tmp36.v1;
        ap_uint<2l> v280;
        v280 = 1ul;
        bool v281;
        v281 = v279 == v280;
        bool v283;
        if (v281){
            bool v282;
            v282 = v276 < 5l;
            v283 = v282;
        } else {
            v283 = false;
        }
        int32_t v285;
        if (v283){
            v274.v[v276] = TupleCreate0(v278, v279);
            int32_t v284;
            v284 = v276 + 1l;
            v285 = v284;
        } else {
            v285 = v276;
        }
        v276 = v285;
        v275++;
    }
    bool v286;
    v286 = v276 == 5l;
    US1 v289;
    if (v286){
        v289 = US1_1(v274);
    } else {
        v289 = US1_0();
    }
    array<5l,Tuple0> v290;
    int32_t v291; int32_t v292;
    Tuple4 tmp37 = TupleCreate4(0l, 0l);
    v291 = tmp37.v0; v292 = tmp37.v1;
    while (method1(v291)){
        ap_uint<4l> v294; ap_uint<2l> v295;
        Tuple0 tmp38 = v1.v[v291];
        v294 = tmp38.v0; v295 = tmp38.v1;
        ap_uint<2l> v296;
        v296 = 0ul;
        bool v297;
        v297 = v295 == v296;
        bool v299;
        if (v297){
            bool v298;
            v298 = v292 < 5l;
            v299 = v298;
        } else {
            v299 = false;
        }
        int32_t v301;
        if (v299){
            v290.v[v292] = TupleCreate0(v294, v295);
            int32_t v300;
            v300 = v292 + 1l;
            v301 = v300;
        } else {
            v301 = v292;
        }
        v292 = v301;
        v291++;
    }
    bool v302;
    v302 = v292 == 5l;
    US1 v305;
    if (v302){
        v305 = US1_1(v290);
    } else {
        v305 = US1_0();
    }
    US1 v330;
    switch (v305.tag) {
        case 0: { // None
            v330 = v289;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v306 = v305.v.case1.v0;
            switch (v289.tag) {
                case 0: { // None
                    v330 = v305;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v307 = v289.v.case1.v0;
                    US4 v308;
                    v308 = US4_0();
                    int32_t v309; US4 v310;
                    Tuple5 tmp39 = TupleCreate5(0l, v308);
                    v309 = tmp39.v0; v310 = tmp39.v1;
                    while (method2(v309)){
                        ap_uint<4l> v312; ap_uint<2l> v313;
                        Tuple0 tmp40 = v306.v[v309];
                        v312 = tmp40.v0; v313 = tmp40.v1;
                        ap_uint<4l> v314; ap_uint<2l> v315;
                        Tuple0 tmp41 = v307.v[v309];
                        v314 = tmp41.v0; v315 = tmp41.v1;
                        US4 v323;
                        switch (v310.tag) {
                            case 0: { // Eq
                                bool v316;
                                v316 = v312 > v314;
                                if (v316){
                                    v323 = US4_1();
                                } else {
                                    bool v318;
                                    v318 = v312 < v314;
                                    if (v318){
                                        v323 = US4_2();
                                    } else {
                                        v323 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v310 = v323;
                        v309++;
                    }
                    bool v324;
                    switch (v310.tag) {
                        case 1: { // Gt
                            v324 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v325;
                    if (v324){
                        v325 = v306;
                    } else {
                        v325 = v307;
                    }
                    v330 = US1_1(v325);
                    break;
                }
            }
            break;
        }
    }
    US1 v355;
    switch (v330.tag) {
        case 0: { // None
            v355 = v273;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v331 = v330.v.case1.v0;
            switch (v273.tag) {
                case 0: { // None
                    v355 = v330;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v332 = v273.v.case1.v0;
                    US4 v333;
                    v333 = US4_0();
                    int32_t v334; US4 v335;
                    Tuple5 tmp42 = TupleCreate5(0l, v333);
                    v334 = tmp42.v0; v335 = tmp42.v1;
                    while (method2(v334)){
                        ap_uint<4l> v337; ap_uint<2l> v338;
                        Tuple0 tmp43 = v331.v[v334];
                        v337 = tmp43.v0; v338 = tmp43.v1;
                        ap_uint<4l> v339; ap_uint<2l> v340;
                        Tuple0 tmp44 = v332.v[v334];
                        v339 = tmp44.v0; v340 = tmp44.v1;
                        US4 v348;
                        switch (v335.tag) {
                            case 0: { // Eq
                                bool v341;
                                v341 = v337 > v339;
                                if (v341){
                                    v348 = US4_1();
                                } else {
                                    bool v343;
                                    v343 = v337 < v339;
                                    if (v343){
                                        v348 = US4_2();
                                    } else {
                                        v348 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v335 = v348;
                        v334++;
                    }
                    bool v349;
                    switch (v335.tag) {
                        case 1: { // Gt
                            v349 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v350;
                    if (v349){
                        v350 = v331;
                    } else {
                        v350 = v332;
                    }
                    v355 = US1_1(v350);
                    break;
                }
            }
            break;
        }
    }
    US1 v380;
    switch (v355.tag) {
        case 0: { // None
            v380 = v257;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v356 = v355.v.case1.v0;
            switch (v257.tag) {
                case 0: { // None
                    v380 = v355;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v357 = v257.v.case1.v0;
                    US4 v358;
                    v358 = US4_0();
                    int32_t v359; US4 v360;
                    Tuple5 tmp45 = TupleCreate5(0l, v358);
                    v359 = tmp45.v0; v360 = tmp45.v1;
                    while (method2(v359)){
                        ap_uint<4l> v362; ap_uint<2l> v363;
                        Tuple0 tmp46 = v356.v[v359];
                        v362 = tmp46.v0; v363 = tmp46.v1;
                        ap_uint<4l> v364; ap_uint<2l> v365;
                        Tuple0 tmp47 = v357.v[v359];
                        v364 = tmp47.v0; v365 = tmp47.v1;
                        US4 v373;
                        switch (v360.tag) {
                            case 0: { // Eq
                                bool v366;
                                v366 = v362 > v364;
                                if (v366){
                                    v373 = US4_1();
                                } else {
                                    bool v368;
                                    v368 = v362 < v364;
                                    if (v368){
                                        v373 = US4_2();
                                    } else {
                                        v373 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v360 = v373;
                        v359++;
                    }
                    bool v374;
                    switch (v360.tag) {
                        case 1: { // Gt
                            v374 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v375;
                    if (v374){
                        v375 = v356;
                    } else {
                        v375 = v357;
                    }
                    v380 = US1_1(v375);
                    break;
                }
            }
            break;
        }
    }
    array<3l,Tuple0> v381;
    array<5l,Tuple0> v382;
    ap_uint<4l> v383;
    v383 = 12ul;
    int32_t v384; int32_t v385; ap_uint<4l> v386;
    Tuple2 tmp48 = TupleCreate2(0l, 0l, v383);
    v384 = tmp48.v0; v385 = tmp48.v1; v386 = tmp48.v2;
    while (method1(v384)){
        ap_uint<4l> v388; ap_uint<2l> v389;
        Tuple0 tmp49 = v1.v[v384];
        v388 = tmp49.v0; v389 = tmp49.v1;
        bool v390;
        v390 = v385 < 3l;
        int32_t v394; ap_uint<4l> v395;
        if (v390){
            bool v391;
            v391 = v386 == v388;
            int32_t v392;
            if (v391){
                v392 = v385;
            } else {
                v392 = 0l;
            }
            v381.v[v392] = TupleCreate0(v388, v389);
            int32_t v393;
            v393 = v392 + 1l;
            v394 = v393; v395 = v388;
        } else {
            v394 = v385; v395 = v386;
        }
        TupleCreate3(v385, v386) = TupleCreate3(v394, v395);
        v384++;
    }
    bool v396;
    v396 = v385 == 3l;
    US3 v409;
    if (v396){
        int32_t v397;
        v397 = v385 - 3l;
        int32_t v398;
        v398 = 0l;
        while (method3(v397, v398)){
            ap_uint<4l> v400; ap_uint<2l> v401;
            Tuple0 tmp50 = v1.v[v398];
            v400 = tmp50.v0; v401 = tmp50.v1;
            v382.v[v398] = TupleCreate0(v400, v401);
            v398++;
        }
        int32_t v402;
        v402 = v397;
        while (method2(v402)){
            int32_t v404;
            v404 = 3l + v402;
            ap_uint<4l> v405; ap_uint<2l> v406;
            Tuple0 tmp51 = v1.v[v404];
            v405 = tmp51.v0; v406 = tmp51.v1;
            v382.v[v402] = TupleCreate0(v405, v406);
            v402++;
        }
        v409 = US3_1(v381, v382);
    } else {
        v409 = US3_0();
    }
    US1 v460;
    switch (v409.tag) {
        case 0: { // None
            v460 = US1_0();
            break;
        }
        case 1: { // Some
            array<3l,Tuple0> v410 = v409.v.case1.v0; array<5l,Tuple0> v411 = v409.v.case1.v1;
            array<2l,Tuple0> v412;
            array<3l,Tuple0> v413;
            ap_uint<4l> v414;
            v414 = 12ul;
            int32_t v415; int32_t v416; ap_uint<4l> v417;
            Tuple2 tmp52 = TupleCreate2(0l, 0l, v414);
            v415 = tmp52.v0; v416 = tmp52.v1; v417 = tmp52.v2;
            while (method2(v415)){
                ap_uint<4l> v419; ap_uint<2l> v420;
                Tuple0 tmp53 = v411.v[v415];
                v419 = tmp53.v0; v420 = tmp53.v1;
                bool v421;
                v421 = v416 < 2l;
                int32_t v425; ap_uint<4l> v426;
                if (v421){
                    bool v422;
                    v422 = v417 == v419;
                    int32_t v423;
                    if (v422){
                        v423 = v416;
                    } else {
                        v423 = 0l;
                    }
                    v412.v[v423] = TupleCreate0(v419, v420);
                    int32_t v424;
                    v424 = v423 + 1l;
                    v425 = v424; v426 = v419;
                } else {
                    v425 = v416; v426 = v417;
                }
                TupleCreate3(v416, v417) = TupleCreate3(v425, v426);
                v415++;
            }
            bool v427;
            v427 = v416 == 2l;
            US5 v440;
            if (v427){
                int32_t v428;
                v428 = v416 - 2l;
                int32_t v429;
                v429 = 0l;
                while (method3(v428, v429)){
                    ap_uint<4l> v431; ap_uint<2l> v432;
                    Tuple0 tmp54 = v411.v[v429];
                    v431 = tmp54.v0; v432 = tmp54.v1;
                    v413.v[v429] = TupleCreate0(v431, v432);
                    v429++;
                }
                int32_t v433;
                v433 = v428;
                while (method5(v433)){
                    int32_t v435;
                    v435 = 2l + v433;
                    ap_uint<4l> v436; ap_uint<2l> v437;
                    Tuple0 tmp55 = v411.v[v435];
                    v436 = tmp55.v0; v437 = tmp55.v1;
                    v413.v[v433] = TupleCreate0(v436, v437);
                    v433++;
                }
                v440 = US5_1(v412, v413);
            } else {
                v440 = US5_0();
            }
            switch (v440.tag) {
                case 0: { // None
                    v460 = US1_0();
                    break;
                }
                case 1: { // Some
                    array<2l,Tuple0> v441 = v440.v.case1.v0; array<3l,Tuple0> v442 = v440.v.case1.v1;
                    array<0l,Tuple0> v443;
                    array<5l,Tuple0> v444;
                    int32_t v445;
                    v445 = 0l;
                    while (method5(v445)){
                        ap_uint<4l> v447; ap_uint<2l> v448;
                        Tuple0 tmp56 = v410.v[v445];
                        v447 = tmp56.v0; v448 = tmp56.v1;
                        v444.v[v445] = TupleCreate0(v447, v448);
                        v445++;
                    }
                    int32_t v449;
                    v449 = 0l;
                    while (method6(v449)){
                        ap_uint<4l> v451; ap_uint<2l> v452;
                        Tuple0 tmp57 = v441.v[v449];
                        v451 = tmp57.v0; v452 = tmp57.v1;
                        int32_t v453;
                        v453 = 3l + v449;
                        v444.v[v453] = TupleCreate0(v451, v452);
                        v449++;
                    }
                    v460 = US1_1(v444);
                    break;
                }
            }
            break;
        }
    }
    array<4l,Tuple0> v461;
    array<4l,Tuple0> v462;
    ap_uint<4l> v463;
    v463 = 12ul;
    int32_t v464; int32_t v465; ap_uint<4l> v466;
    Tuple2 tmp58 = TupleCreate2(0l, 0l, v463);
    v464 = tmp58.v0; v465 = tmp58.v1; v466 = tmp58.v2;
    while (method1(v464)){
        ap_uint<4l> v468; ap_uint<2l> v469;
        Tuple0 tmp59 = v1.v[v464];
        v468 = tmp59.v0; v469 = tmp59.v1;
        bool v470;
        v470 = v465 < 4l;
        int32_t v474; ap_uint<4l> v475;
        if (v470){
            bool v471;
            v471 = v466 == v468;
            int32_t v472;
            if (v471){
                v472 = v465;
            } else {
                v472 = 0l;
            }
            v461.v[v472] = TupleCreate0(v468, v469);
            int32_t v473;
            v473 = v472 + 1l;
            v474 = v473; v475 = v468;
        } else {
            v474 = v465; v475 = v466;
        }
        TupleCreate3(v465, v466) = TupleCreate3(v474, v475);
        v464++;
    }
    bool v476;
    v476 = v465 == 4l;
    US6 v489;
    if (v476){
        int32_t v477;
        v477 = v465 - 4l;
        int32_t v478;
        v478 = 0l;
        while (method3(v477, v478)){
            ap_uint<4l> v480; ap_uint<2l> v481;
            Tuple0 tmp60 = v1.v[v478];
            v480 = tmp60.v0; v481 = tmp60.v1;
            v462.v[v478] = TupleCreate0(v480, v481);
            v478++;
        }
        int32_t v482;
        v482 = v477;
        while (method7(v482)){
            int32_t v484;
            v484 = 4l + v482;
            ap_uint<4l> v485; ap_uint<2l> v486;
            Tuple0 tmp61 = v1.v[v484];
            v485 = tmp61.v0; v486 = tmp61.v1;
            v462.v[v482] = TupleCreate0(v485, v486);
            v482++;
        }
        v489 = US6_1(v461, v462);
    } else {
        v489 = US6_0();
    }
    US1 v511;
    switch (v489.tag) {
        case 0: { // None
            v511 = US1_0();
            break;
        }
        case 1: { // Some
            array<4l,Tuple0> v490 = v489.v.case1.v0; array<4l,Tuple0> v491 = v489.v.case1.v1;
            array<1l,Tuple0> v492;
            int32_t v493;
            v493 = 0l;
            while (method8(v493)){
                ap_uint<4l> v495; ap_uint<2l> v496;
                Tuple0 tmp62 = v491.v[v493];
                v495 = tmp62.v0; v496 = tmp62.v1;
                v492.v[v493] = TupleCreate0(v495, v496);
                v493++;
            }
            array<0l,Tuple0> v497;
            array<5l,Tuple0> v498;
            int32_t v499;
            v499 = 0l;
            while (method7(v499)){
                ap_uint<4l> v501; ap_uint<2l> v502;
                Tuple0 tmp63 = v490.v[v499];
                v501 = tmp63.v0; v502 = tmp63.v1;
                v498.v[v499] = TupleCreate0(v501, v502);
                v499++;
            }
            int32_t v503;
            v503 = 0l;
            while (method8(v503)){
                ap_uint<4l> v505; ap_uint<2l> v506;
                Tuple0 tmp64 = v492.v[v503];
                v505 = tmp64.v0; v506 = tmp64.v1;
                int32_t v507;
                v507 = 4l + v503;
                v498.v[v507] = TupleCreate0(v505, v506);
                v503++;
            }
            v511 = US1_1(v498);
            break;
        }
    }
    ap_uint<2l> v512;
    v512 = 3ul;
    array<5l,Tuple0> v513;
    ap_uint<4l> v514;
    v514 = 12ul;
    int32_t v515; int32_t v516; ap_uint<4l> v517;
    Tuple2 tmp65 = TupleCreate2(0l, 0l, v514);
    v515 = tmp65.v0; v516 = tmp65.v1; v517 = tmp65.v2;
    while (method1(v515)){
        ap_uint<4l> v519; ap_uint<2l> v520;
        Tuple0 tmp66 = v1.v[v515];
        v519 = tmp66.v0; v520 = tmp66.v1;
        bool v521;
        v521 = v516 < 5l;
        bool v523;
        if (v521){
            bool v522;
            v522 = v512 == v520;
            v523 = v522;
        } else {
            v523 = false;
        }
        int32_t v529; ap_uint<4l> v530;
        if (v523){
            bool v524;
            v524 = v517 == v519;
            int32_t v525;
            if (v524){
                v525 = v516;
            } else {
                v525 = 0l;
            }
            v513.v[v525] = TupleCreate0(v519, v520);
            int32_t v526;
            v526 = v525 + 1l;
            ap_uint<4l> v527;
            v527 = 1ul;
            ap_uint<4l> v528;
            v528 = v519 - v527;
            v529 = v526; v530 = v528;
        } else {
            v529 = v516; v530 = v517;
        }
        TupleCreate3(v516, v517) = TupleCreate3(v529, v530);
        v515++;
    }
    bool v531;
    v531 = v516 == 4l;
    bool v568;
    if (v531){
        ap_uint<4l> v532;
        v532 = 0ul;
        ap_uint<4l> v533;
        v533 = 1ul;
        ap_uint<4l> v534;
        v534 = v532 - v533;
        bool v535;
        v535 = v517 == v534;
        if (v535){
            ap_uint<4l> v536; ap_uint<2l> v537;
            Tuple0 tmp67 = v1.v[0l];
            v536 = tmp67.v0; v537 = tmp67.v1;
            bool v538;
            v538 = v512 == v537;
            bool v542;
            if (v538){
                ap_uint<4l> v539;
                v539 = 12ul;
                bool v540;
                v540 = v536 == v539;
                if (v540){
                    v513.v[4l] = TupleCreate0(v536, v537);
                    v542 = true;
                } else {
                    v542 = false;
                }
            } else {
                v542 = false;
            }
            if (v542){
                v568 = true;
            } else {
                ap_uint<4l> v543; ap_uint<2l> v544;
                Tuple0 tmp68 = v1.v[1l];
                v543 = tmp68.v0; v544 = tmp68.v1;
                bool v545;
                v545 = v512 == v544;
                bool v549;
                if (v545){
                    ap_uint<4l> v546;
                    v546 = 12ul;
                    bool v547;
                    v547 = v543 == v546;
                    if (v547){
                        v513.v[4l] = TupleCreate0(v543, v544);
                        v549 = true;
                    } else {
                        v549 = false;
                    }
                } else {
                    v549 = false;
                }
                if (v549){
                    v568 = true;
                } else {
                    ap_uint<4l> v550; ap_uint<2l> v551;
                    Tuple0 tmp69 = v1.v[2l];
                    v550 = tmp69.v0; v551 = tmp69.v1;
                    bool v552;
                    v552 = v512 == v551;
                    bool v556;
                    if (v552){
                        ap_uint<4l> v553;
                        v553 = 12ul;
                        bool v554;
                        v554 = v550 == v553;
                        if (v554){
                            v513.v[4l] = TupleCreate0(v550, v551);
                            v556 = true;
                        } else {
                            v556 = false;
                        }
                    } else {
                        v556 = false;
                    }
                    if (v556){
                        v568 = true;
                    } else {
                        ap_uint<4l> v557; ap_uint<2l> v558;
                        Tuple0 tmp70 = v1.v[3l];
                        v557 = tmp70.v0; v558 = tmp70.v1;
                        bool v559;
                        v559 = v512 == v558;
                        if (v559){
                            ap_uint<4l> v560;
                            v560 = 12ul;
                            bool v561;
                            v561 = v557 == v560;
                            if (v561){
                                v513.v[4l] = TupleCreate0(v557, v558);
                                v568 = true;
                            } else {
                                v568 = false;
                            }
                        } else {
                            v568 = false;
                        }
                    }
                }
            }
        } else {
            v568 = false;
        }
    } else {
        v568 = false;
    }
    US1 v574;
    if (v568){
        v574 = US1_1(v513);
    } else {
        bool v570;
        v570 = v516 == 5l;
        if (v570){
            v574 = US1_1(v513);
        } else {
            v574 = US1_0();
        }
    }
    ap_uint<2l> v575;
    v575 = 2ul;
    array<5l,Tuple0> v576;
    ap_uint<4l> v577;
    v577 = 12ul;
    int32_t v578; int32_t v579; ap_uint<4l> v580;
    Tuple2 tmp71 = TupleCreate2(0l, 0l, v577);
    v578 = tmp71.v0; v579 = tmp71.v1; v580 = tmp71.v2;
    while (method1(v578)){
        ap_uint<4l> v582; ap_uint<2l> v583;
        Tuple0 tmp72 = v1.v[v578];
        v582 = tmp72.v0; v583 = tmp72.v1;
        bool v584;
        v584 = v579 < 5l;
        bool v586;
        if (v584){
            bool v585;
            v585 = v575 == v583;
            v586 = v585;
        } else {
            v586 = false;
        }
        int32_t v592; ap_uint<4l> v593;
        if (v586){
            bool v587;
            v587 = v580 == v582;
            int32_t v588;
            if (v587){
                v588 = v579;
            } else {
                v588 = 0l;
            }
            v576.v[v588] = TupleCreate0(v582, v583);
            int32_t v589;
            v589 = v588 + 1l;
            ap_uint<4l> v590;
            v590 = 1ul;
            ap_uint<4l> v591;
            v591 = v582 - v590;
            v592 = v589; v593 = v591;
        } else {
            v592 = v579; v593 = v580;
        }
        TupleCreate3(v579, v580) = TupleCreate3(v592, v593);
        v578++;
    }
    bool v594;
    v594 = v579 == 4l;
    bool v631;
    if (v594){
        ap_uint<4l> v595;
        v595 = 0ul;
        ap_uint<4l> v596;
        v596 = 1ul;
        ap_uint<4l> v597;
        v597 = v595 - v596;
        bool v598;
        v598 = v580 == v597;
        if (v598){
            ap_uint<4l> v599; ap_uint<2l> v600;
            Tuple0 tmp73 = v1.v[0l];
            v599 = tmp73.v0; v600 = tmp73.v1;
            bool v601;
            v601 = v575 == v600;
            bool v605;
            if (v601){
                ap_uint<4l> v602;
                v602 = 12ul;
                bool v603;
                v603 = v599 == v602;
                if (v603){
                    v576.v[4l] = TupleCreate0(v599, v600);
                    v605 = true;
                } else {
                    v605 = false;
                }
            } else {
                v605 = false;
            }
            if (v605){
                v631 = true;
            } else {
                ap_uint<4l> v606; ap_uint<2l> v607;
                Tuple0 tmp74 = v1.v[1l];
                v606 = tmp74.v0; v607 = tmp74.v1;
                bool v608;
                v608 = v575 == v607;
                bool v612;
                if (v608){
                    ap_uint<4l> v609;
                    v609 = 12ul;
                    bool v610;
                    v610 = v606 == v609;
                    if (v610){
                        v576.v[4l] = TupleCreate0(v606, v607);
                        v612 = true;
                    } else {
                        v612 = false;
                    }
                } else {
                    v612 = false;
                }
                if (v612){
                    v631 = true;
                } else {
                    ap_uint<4l> v613; ap_uint<2l> v614;
                    Tuple0 tmp75 = v1.v[2l];
                    v613 = tmp75.v0; v614 = tmp75.v1;
                    bool v615;
                    v615 = v575 == v614;
                    bool v619;
                    if (v615){
                        ap_uint<4l> v616;
                        v616 = 12ul;
                        bool v617;
                        v617 = v613 == v616;
                        if (v617){
                            v576.v[4l] = TupleCreate0(v613, v614);
                            v619 = true;
                        } else {
                            v619 = false;
                        }
                    } else {
                        v619 = false;
                    }
                    if (v619){
                        v631 = true;
                    } else {
                        ap_uint<4l> v620; ap_uint<2l> v621;
                        Tuple0 tmp76 = v1.v[3l];
                        v620 = tmp76.v0; v621 = tmp76.v1;
                        bool v622;
                        v622 = v575 == v621;
                        if (v622){
                            ap_uint<4l> v623;
                            v623 = 12ul;
                            bool v624;
                            v624 = v620 == v623;
                            if (v624){
                                v576.v[4l] = TupleCreate0(v620, v621);
                                v631 = true;
                            } else {
                                v631 = false;
                            }
                        } else {
                            v631 = false;
                        }
                    }
                }
            }
        } else {
            v631 = false;
        }
    } else {
        v631 = false;
    }
    US1 v637;
    if (v631){
        v637 = US1_1(v576);
    } else {
        bool v633;
        v633 = v579 == 5l;
        if (v633){
            v637 = US1_1(v576);
        } else {
            v637 = US1_0();
        }
    }
    ap_uint<2l> v638;
    v638 = 1ul;
    array<5l,Tuple0> v639;
    ap_uint<4l> v640;
    v640 = 12ul;
    int32_t v641; int32_t v642; ap_uint<4l> v643;
    Tuple2 tmp77 = TupleCreate2(0l, 0l, v640);
    v641 = tmp77.v0; v642 = tmp77.v1; v643 = tmp77.v2;
    while (method1(v641)){
        ap_uint<4l> v645; ap_uint<2l> v646;
        Tuple0 tmp78 = v1.v[v641];
        v645 = tmp78.v0; v646 = tmp78.v1;
        bool v647;
        v647 = v642 < 5l;
        bool v649;
        if (v647){
            bool v648;
            v648 = v638 == v646;
            v649 = v648;
        } else {
            v649 = false;
        }
        int32_t v655; ap_uint<4l> v656;
        if (v649){
            bool v650;
            v650 = v643 == v645;
            int32_t v651;
            if (v650){
                v651 = v642;
            } else {
                v651 = 0l;
            }
            v639.v[v651] = TupleCreate0(v645, v646);
            int32_t v652;
            v652 = v651 + 1l;
            ap_uint<4l> v653;
            v653 = 1ul;
            ap_uint<4l> v654;
            v654 = v645 - v653;
            v655 = v652; v656 = v654;
        } else {
            v655 = v642; v656 = v643;
        }
        TupleCreate3(v642, v643) = TupleCreate3(v655, v656);
        v641++;
    }
    bool v657;
    v657 = v642 == 4l;
    bool v694;
    if (v657){
        ap_uint<4l> v658;
        v658 = 0ul;
        ap_uint<4l> v659;
        v659 = 1ul;
        ap_uint<4l> v660;
        v660 = v658 - v659;
        bool v661;
        v661 = v643 == v660;
        if (v661){
            ap_uint<4l> v662; ap_uint<2l> v663;
            Tuple0 tmp79 = v1.v[0l];
            v662 = tmp79.v0; v663 = tmp79.v1;
            bool v664;
            v664 = v638 == v663;
            bool v668;
            if (v664){
                ap_uint<4l> v665;
                v665 = 12ul;
                bool v666;
                v666 = v662 == v665;
                if (v666){
                    v639.v[4l] = TupleCreate0(v662, v663);
                    v668 = true;
                } else {
                    v668 = false;
                }
            } else {
                v668 = false;
            }
            if (v668){
                v694 = true;
            } else {
                ap_uint<4l> v669; ap_uint<2l> v670;
                Tuple0 tmp80 = v1.v[1l];
                v669 = tmp80.v0; v670 = tmp80.v1;
                bool v671;
                v671 = v638 == v670;
                bool v675;
                if (v671){
                    ap_uint<4l> v672;
                    v672 = 12ul;
                    bool v673;
                    v673 = v669 == v672;
                    if (v673){
                        v639.v[4l] = TupleCreate0(v669, v670);
                        v675 = true;
                    } else {
                        v675 = false;
                    }
                } else {
                    v675 = false;
                }
                if (v675){
                    v694 = true;
                } else {
                    ap_uint<4l> v676; ap_uint<2l> v677;
                    Tuple0 tmp81 = v1.v[2l];
                    v676 = tmp81.v0; v677 = tmp81.v1;
                    bool v678;
                    v678 = v638 == v677;
                    bool v682;
                    if (v678){
                        ap_uint<4l> v679;
                        v679 = 12ul;
                        bool v680;
                        v680 = v676 == v679;
                        if (v680){
                            v639.v[4l] = TupleCreate0(v676, v677);
                            v682 = true;
                        } else {
                            v682 = false;
                        }
                    } else {
                        v682 = false;
                    }
                    if (v682){
                        v694 = true;
                    } else {
                        ap_uint<4l> v683; ap_uint<2l> v684;
                        Tuple0 tmp82 = v1.v[3l];
                        v683 = tmp82.v0; v684 = tmp82.v1;
                        bool v685;
                        v685 = v638 == v684;
                        if (v685){
                            ap_uint<4l> v686;
                            v686 = 12ul;
                            bool v687;
                            v687 = v683 == v686;
                            if (v687){
                                v639.v[4l] = TupleCreate0(v683, v684);
                                v694 = true;
                            } else {
                                v694 = false;
                            }
                        } else {
                            v694 = false;
                        }
                    }
                }
            }
        } else {
            v694 = false;
        }
    } else {
        v694 = false;
    }
    US1 v700;
    if (v694){
        v700 = US1_1(v639);
    } else {
        bool v696;
        v696 = v642 == 5l;
        if (v696){
            v700 = US1_1(v639);
        } else {
            v700 = US1_0();
        }
    }
    ap_uint<2l> v701;
    v701 = 0ul;
    array<5l,Tuple0> v702;
    ap_uint<4l> v703;
    v703 = 12ul;
    int32_t v704; int32_t v705; ap_uint<4l> v706;
    Tuple2 tmp83 = TupleCreate2(0l, 0l, v703);
    v704 = tmp83.v0; v705 = tmp83.v1; v706 = tmp83.v2;
    while (method1(v704)){
        ap_uint<4l> v708; ap_uint<2l> v709;
        Tuple0 tmp84 = v1.v[v704];
        v708 = tmp84.v0; v709 = tmp84.v1;
        bool v710;
        v710 = v705 < 5l;
        bool v712;
        if (v710){
            bool v711;
            v711 = v701 == v709;
            v712 = v711;
        } else {
            v712 = false;
        }
        int32_t v718; ap_uint<4l> v719;
        if (v712){
            bool v713;
            v713 = v706 == v708;
            int32_t v714;
            if (v713){
                v714 = v705;
            } else {
                v714 = 0l;
            }
            v702.v[v714] = TupleCreate0(v708, v709);
            int32_t v715;
            v715 = v714 + 1l;
            ap_uint<4l> v716;
            v716 = 1ul;
            ap_uint<4l> v717;
            v717 = v708 - v716;
            v718 = v715; v719 = v717;
        } else {
            v718 = v705; v719 = v706;
        }
        TupleCreate3(v705, v706) = TupleCreate3(v718, v719);
        v704++;
    }
    bool v720;
    v720 = v705 == 4l;
    bool v757;
    if (v720){
        ap_uint<4l> v721;
        v721 = 0ul;
        ap_uint<4l> v722;
        v722 = 1ul;
        ap_uint<4l> v723;
        v723 = v721 - v722;
        bool v724;
        v724 = v706 == v723;
        if (v724){
            ap_uint<4l> v725; ap_uint<2l> v726;
            Tuple0 tmp85 = v1.v[0l];
            v725 = tmp85.v0; v726 = tmp85.v1;
            bool v727;
            v727 = v701 == v726;
            bool v731;
            if (v727){
                ap_uint<4l> v728;
                v728 = 12ul;
                bool v729;
                v729 = v725 == v728;
                if (v729){
                    v702.v[4l] = TupleCreate0(v725, v726);
                    v731 = true;
                } else {
                    v731 = false;
                }
            } else {
                v731 = false;
            }
            if (v731){
                v757 = true;
            } else {
                ap_uint<4l> v732; ap_uint<2l> v733;
                Tuple0 tmp86 = v1.v[1l];
                v732 = tmp86.v0; v733 = tmp86.v1;
                bool v734;
                v734 = v701 == v733;
                bool v738;
                if (v734){
                    ap_uint<4l> v735;
                    v735 = 12ul;
                    bool v736;
                    v736 = v732 == v735;
                    if (v736){
                        v702.v[4l] = TupleCreate0(v732, v733);
                        v738 = true;
                    } else {
                        v738 = false;
                    }
                } else {
                    v738 = false;
                }
                if (v738){
                    v757 = true;
                } else {
                    ap_uint<4l> v739; ap_uint<2l> v740;
                    Tuple0 tmp87 = v1.v[2l];
                    v739 = tmp87.v0; v740 = tmp87.v1;
                    bool v741;
                    v741 = v701 == v740;
                    bool v745;
                    if (v741){
                        ap_uint<4l> v742;
                        v742 = 12ul;
                        bool v743;
                        v743 = v739 == v742;
                        if (v743){
                            v702.v[4l] = TupleCreate0(v739, v740);
                            v745 = true;
                        } else {
                            v745 = false;
                        }
                    } else {
                        v745 = false;
                    }
                    if (v745){
                        v757 = true;
                    } else {
                        ap_uint<4l> v746; ap_uint<2l> v747;
                        Tuple0 tmp88 = v1.v[3l];
                        v746 = tmp88.v0; v747 = tmp88.v1;
                        bool v748;
                        v748 = v701 == v747;
                        if (v748){
                            ap_uint<4l> v749;
                            v749 = 12ul;
                            bool v750;
                            v750 = v746 == v749;
                            if (v750){
                                v702.v[4l] = TupleCreate0(v746, v747);
                                v757 = true;
                            } else {
                                v757 = false;
                            }
                        } else {
                            v757 = false;
                        }
                    }
                }
            }
        } else {
            v757 = false;
        }
    } else {
        v757 = false;
    }
    US1 v763;
    if (v757){
        v763 = US1_1(v702);
    } else {
        bool v759;
        v759 = v705 == 5l;
        if (v759){
            v763 = US1_1(v702);
        } else {
            v763 = US1_0();
        }
    }
    US1 v788;
    switch (v763.tag) {
        case 0: { // None
            v788 = v700;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v764 = v763.v.case1.v0;
            switch (v700.tag) {
                case 0: { // None
                    v788 = v763;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v765 = v700.v.case1.v0;
                    US4 v766;
                    v766 = US4_0();
                    int32_t v767; US4 v768;
                    Tuple5 tmp89 = TupleCreate5(0l, v766);
                    v767 = tmp89.v0; v768 = tmp89.v1;
                    while (method2(v767)){
                        ap_uint<4l> v770; ap_uint<2l> v771;
                        Tuple0 tmp90 = v764.v[v767];
                        v770 = tmp90.v0; v771 = tmp90.v1;
                        ap_uint<4l> v772; ap_uint<2l> v773;
                        Tuple0 tmp91 = v765.v[v767];
                        v772 = tmp91.v0; v773 = tmp91.v1;
                        US4 v781;
                        switch (v768.tag) {
                            case 0: { // Eq
                                bool v774;
                                v774 = v770 > v772;
                                if (v774){
                                    v781 = US4_1();
                                } else {
                                    bool v776;
                                    v776 = v770 < v772;
                                    if (v776){
                                        v781 = US4_2();
                                    } else {
                                        v781 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v768 = v781;
                        v767++;
                    }
                    bool v782;
                    switch (v768.tag) {
                        case 1: { // Gt
                            v782 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v783;
                    if (v782){
                        v783 = v764;
                    } else {
                        v783 = v765;
                    }
                    v788 = US1_1(v783);
                    break;
                }
            }
            break;
        }
    }
    US1 v813;
    switch (v788.tag) {
        case 0: { // None
            v813 = v637;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v789 = v788.v.case1.v0;
            switch (v637.tag) {
                case 0: { // None
                    v813 = v788;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v790 = v637.v.case1.v0;
                    US4 v791;
                    v791 = US4_0();
                    int32_t v792; US4 v793;
                    Tuple5 tmp92 = TupleCreate5(0l, v791);
                    v792 = tmp92.v0; v793 = tmp92.v1;
                    while (method2(v792)){
                        ap_uint<4l> v795; ap_uint<2l> v796;
                        Tuple0 tmp93 = v789.v[v792];
                        v795 = tmp93.v0; v796 = tmp93.v1;
                        ap_uint<4l> v797; ap_uint<2l> v798;
                        Tuple0 tmp94 = v790.v[v792];
                        v797 = tmp94.v0; v798 = tmp94.v1;
                        US4 v806;
                        switch (v793.tag) {
                            case 0: { // Eq
                                bool v799;
                                v799 = v795 > v797;
                                if (v799){
                                    v806 = US4_1();
                                } else {
                                    bool v801;
                                    v801 = v795 < v797;
                                    if (v801){
                                        v806 = US4_2();
                                    } else {
                                        v806 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v793 = v806;
                        v792++;
                    }
                    bool v807;
                    switch (v793.tag) {
                        case 1: { // Gt
                            v807 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v808;
                    if (v807){
                        v808 = v789;
                    } else {
                        v808 = v790;
                    }
                    v813 = US1_1(v808);
                    break;
                }
            }
            break;
        }
    }
    US1 v838;
    switch (v813.tag) {
        case 0: { // None
            v838 = v574;
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v814 = v813.v.case1.v0;
            switch (v574.tag) {
                case 0: { // None
                    v838 = v813;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v815 = v574.v.case1.v0;
                    US4 v816;
                    v816 = US4_0();
                    int32_t v817; US4 v818;
                    Tuple5 tmp95 = TupleCreate5(0l, v816);
                    v817 = tmp95.v0; v818 = tmp95.v1;
                    while (method2(v817)){
                        ap_uint<4l> v820; ap_uint<2l> v821;
                        Tuple0 tmp96 = v814.v[v817];
                        v820 = tmp96.v0; v821 = tmp96.v1;
                        ap_uint<4l> v822; ap_uint<2l> v823;
                        Tuple0 tmp97 = v815.v[v817];
                        v822 = tmp97.v0; v823 = tmp97.v1;
                        US4 v831;
                        switch (v818.tag) {
                            case 0: { // Eq
                                bool v824;
                                v824 = v820 > v822;
                                if (v824){
                                    v831 = US4_1();
                                } else {
                                    bool v826;
                                    v826 = v820 < v822;
                                    if (v826){
                                        v831 = US4_2();
                                    } else {
                                        v831 = US4_0();
                                    }
                                }
                                break;
                            }
                        }
                        v818 = v831;
                        v817++;
                    }
                    bool v832;
                    switch (v818.tag) {
                        case 1: { // Gt
                            v832 = true;
                            break;
                        }
                    }
                    array<5l,Tuple0> v833;
                    if (v832){
                        v833 = v814;
                    } else {
                        v833 = v815;
                    }
                    v838 = US1_1(v833);
                    break;
                }
            }
            break;
        }
    }
    ap_uint<4l> v839;
    v839 = 1ul;
    US7 v844;
    switch (v62.tag) {
        case 0: { // None
            v844 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v840 = v62.v.case1.v0;
            v844 = US7_1(v840, v839);
            break;
        }
    }
    ap_uint<4l> v845;
    v845 = 2ul;
    US7 v850;
    switch (v151.tag) {
        case 0: { // None
            v850 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v846 = v151.v.case1.v0;
            v850 = US7_1(v846, v845);
            break;
        }
    }
    ap_uint<4l> v851;
    v851 = 3ul;
    US7 v856;
    switch (v202.tag) {
        case 0: { // None
            v856 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v852 = v202.v.case1.v0;
            v856 = US7_1(v852, v851);
            break;
        }
    }
    ap_uint<4l> v857;
    v857 = 4ul;
    US7 v862;
    switch (v241.tag) {
        case 0: { // None
            v862 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v858 = v241.v.case1.v0;
            v862 = US7_1(v858, v857);
            break;
        }
    }
    ap_uint<4l> v863;
    v863 = 5ul;
    US7 v868;
    switch (v380.tag) {
        case 0: { // None
            v868 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v864 = v380.v.case1.v0;
            v868 = US7_1(v864, v863);
            break;
        }
    }
    ap_uint<4l> v869;
    v869 = 6ul;
    US7 v874;
    switch (v460.tag) {
        case 0: { // None
            v874 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v870 = v460.v.case1.v0;
            v874 = US7_1(v870, v869);
            break;
        }
    }
    ap_uint<4l> v875;
    v875 = 7ul;
    US7 v880;
    switch (v511.tag) {
        case 0: { // None
            v880 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v876 = v511.v.case1.v0;
            v880 = US7_1(v876, v875);
            break;
        }
    }
    ap_uint<4l> v881;
    v881 = 8ul;
    US7 v886;
    switch (v838.tag) {
        case 0: { // None
            v886 = US7_0();
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v882 = v838.v.case1.v0;
            v886 = US7_1(v882, v881);
            break;
        }
    }
    US7 v888;
    switch (v886.tag) {
        case 0: { // None
            v888 = US7_0();
            break;
        }
    }
    US7 v898;
    switch (v888.tag) {
        case 1: { // Some
            array<5l,Tuple0> v889 = v888.v.case1.v0; ap_uint<4l> v890 = v888.v.case1.v1;
            switch (v880.tag) {
                case 0: { // None
                    v898 = v888;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v891 = v880.v.case1.v0; ap_uint<4l> v892 = v880.v.case1.v1;
                    v898 = US7_1(v889, v890);
                    break;
                }
            }
            break;
        }
    }
    US7 v908;
    switch (v898.tag) {
        case 1: { // Some
            array<5l,Tuple0> v899 = v898.v.case1.v0; ap_uint<4l> v900 = v898.v.case1.v1;
            switch (v874.tag) {
                case 0: { // None
                    v908 = v898;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v901 = v874.v.case1.v0; ap_uint<4l> v902 = v874.v.case1.v1;
                    v908 = US7_1(v899, v900);
                    break;
                }
            }
            break;
        }
    }
    US7 v918;
    switch (v908.tag) {
        case 1: { // Some
            array<5l,Tuple0> v909 = v908.v.case1.v0; ap_uint<4l> v910 = v908.v.case1.v1;
            switch (v868.tag) {
                case 0: { // None
                    v918 = v908;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v911 = v868.v.case1.v0; ap_uint<4l> v912 = v868.v.case1.v1;
                    v918 = US7_1(v909, v910);
                    break;
                }
            }
            break;
        }
    }
    US7 v928;
    switch (v918.tag) {
        case 1: { // Some
            array<5l,Tuple0> v919 = v918.v.case1.v0; ap_uint<4l> v920 = v918.v.case1.v1;
            switch (v862.tag) {
                case 0: { // None
                    v928 = v918;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v921 = v862.v.case1.v0; ap_uint<4l> v922 = v862.v.case1.v1;
                    v928 = US7_1(v919, v920);
                    break;
                }
            }
            break;
        }
    }
    US7 v938;
    switch (v928.tag) {
        case 1: { // Some
            array<5l,Tuple0> v929 = v928.v.case1.v0; ap_uint<4l> v930 = v928.v.case1.v1;
            switch (v856.tag) {
                case 0: { // None
                    v938 = v928;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v931 = v856.v.case1.v0; ap_uint<4l> v932 = v856.v.case1.v1;
                    v938 = US7_1(v929, v930);
                    break;
                }
            }
            break;
        }
    }
    US7 v948;
    switch (v938.tag) {
        case 1: { // Some
            array<5l,Tuple0> v939 = v938.v.case1.v0; ap_uint<4l> v940 = v938.v.case1.v1;
            switch (v850.tag) {
                case 0: { // None
                    v948 = v938;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v941 = v850.v.case1.v0; ap_uint<4l> v942 = v850.v.case1.v1;
                    v948 = US7_1(v939, v940);
                    break;
                }
            }
            break;
        }
    }
    US7 v958;
    switch (v948.tag) {
        case 1: { // Some
            array<5l,Tuple0> v949 = v948.v.case1.v0; ap_uint<4l> v950 = v948.v.case1.v1;
            switch (v844.tag) {
                case 0: { // None
                    v958 = v948;
                    break;
                }
                case 1: { // Some
                    array<5l,Tuple0> v951 = v844.v.case1.v0; ap_uint<4l> v952 = v844.v.case1.v1;
                    v958 = US7_1(v949, v950);
                    break;
                }
            }
            break;
        }
    }
    switch (v958.tag) {
        case 0: { // None
            ap_uint<4l> v961;
            v961 = 0ul;
            return TupleCreate1(v7, v961);
            break;
        }
        case 1: { // Some
            array<5l,Tuple0> v959 = v958.v.case1.v0; ap_uint<4l> v960 = v958.v.case1.v1;
            return TupleCreate1(v959, v960);
            break;
        }
    }
}
int32_t entry(){
    array<8l,Tuple0> v0;
    uint32_t v1;
    v1 = (uint32_t)0;
    ap_uint<4l> v2;
    v2 = v1;
    uint32_t v3;
    v3 = (uint32_t)0;
    ap_uint<2l> v4;
    v4 = v3;
    v0.v[0l] = TupleCreate0(v2, v4);
    uint32_t v5;
    v5 = (uint32_t)1;
    ap_uint<4l> v6;
    v6 = v5;
    uint32_t v7;
    v7 = (uint32_t)0;
    ap_uint<2l> v8;
    v8 = v7;
    v0.v[1l] = TupleCreate0(v6, v8);
    uint32_t v9;
    v9 = (uint32_t)2;
    ap_uint<4l> v10;
    v10 = v9;
    uint32_t v11;
    v11 = (uint32_t)1;
    ap_uint<2l> v12;
    v12 = v11;
    v0.v[2l] = TupleCreate0(v10, v12);
    uint32_t v13;
    v13 = (uint32_t)3;
    ap_uint<4l> v14;
    v14 = v13;
    uint32_t v15;
    v15 = (uint32_t)1;
    ap_uint<2l> v16;
    v16 = v15;
    v0.v[3l] = TupleCreate0(v14, v16);
    uint32_t v17;
    v17 = (uint32_t)4;
    ap_uint<4l> v18;
    v18 = v17;
    uint32_t v19;
    v19 = (uint32_t)1;
    ap_uint<2l> v20;
    v20 = v19;
    v0.v[4l] = TupleCreate0(v18, v20);
    uint32_t v21;
    v21 = (uint32_t)5;
    ap_uint<4l> v22;
    v22 = v21;
    uint32_t v23;
    v23 = (uint32_t)1;
    ap_uint<2l> v24;
    v24 = v23;
    v0.v[5l] = TupleCreate0(v22, v24);
    uint32_t v25;
    v25 = (uint32_t)6;
    ap_uint<4l> v26;
    v26 = v25;
    uint32_t v27;
    v27 = (uint32_t)1;
    ap_uint<2l> v28;
    v28 = v27;
    v0.v[6l] = TupleCreate0(v26, v28);
    uint32_t v29;
    v29 = (uint32_t)7;
    ap_uint<4l> v30;
    v30 = v29;
    uint32_t v31;
    v31 = (uint32_t)1;
    ap_uint<2l> v32;
    v32 = v31;
    v0.v[7l] = TupleCreate0(v30, v32);
    array<5l,Tuple0> v33; ap_uint<4l> v34;
    Tuple1 tmp98 = score0(v0);
    v33 = tmp98.v0; v34 = tmp98.v1;
    ap_uint<4l> v35; ap_uint<2l> v36;
    Tuple0 tmp99 = v33.v[0l];
    v35 = tmp99.v0; v36 = tmp99.v1;
    int8_t v37;
    v37 = v36;
    int8_t v38;
    v38 = v35;
    ap_uint<4l> v39; ap_uint<2l> v40;
    Tuple0 tmp100 = v33.v[1l];
    v39 = tmp100.v0; v40 = tmp100.v1;
    int8_t v41;
    v41 = v40;
    int8_t v42;
    v42 = v39;
    ap_uint<4l> v43; ap_uint<2l> v44;
    Tuple0 tmp101 = v33.v[2l];
    v43 = tmp101.v0; v44 = tmp101.v1;
    int8_t v45;
    v45 = v44;
    int8_t v46;
    v46 = v43;
    ap_uint<4l> v47; ap_uint<2l> v48;
    Tuple0 tmp102 = v33.v[3l];
    v47 = tmp102.v0; v48 = tmp102.v1;
    int8_t v49;
    v49 = v48;
    int8_t v50;
    v50 = v47;
    ap_uint<4l> v51; ap_uint<2l> v52;
    Tuple0 tmp103 = v33.v[4l];
    v51 = tmp103.v0; v52 = tmp103.v1;
    int8_t v53;
    v53 = v52;
    int8_t v54;
    v54 = v51;
    int8_t v55;
    v55 = v34;
    return 0l;
}
#endif
