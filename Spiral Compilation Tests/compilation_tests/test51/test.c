#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // A
        struct {
            double v0;
        } case1; // B
    };
} US0;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            int32_t v0;
        } case0; // Cons
    };
};
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            double v0;
            UH1 * v1;
        } case0; // Cons
    };
};
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USSupprefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
void USSuppref0(US0 * x){ USSupprefBody0(x); }
US0 US0_0(int32_t v0) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1(double v0) { // B
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(int32_t v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    v1->refc++;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 0: {
            UHDecref1(x->case0.v1);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_0(double v0, UH1 * v1) { // Cons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    v1->refc++;
    return x;
}
UH1 * UH1_1() { // Nil
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    return x;
}
uint64_t method0(UH0 * v0){
    v0->refc++;
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            v2->refc++;
            UHDecref0(v0);
            uint64_t v3;
            v3 = hash(v1);
            uint64_t v4;
            v4 = v3 * 9973ull;
            uint64_t v5;
            v5 = method0(v2);
            UHDecref0(v2);
            uint64_t v6;
            v6 = v4 + v5;
            uint64_t v7;
            v7 = 9223372036854775807ull + v6;
            uint64_t v8;
            v8 = v7 * 9973ull;
            uint64_t v9;
            v9 = 0l;
            uint64_t v10;
            v10 = 1ull + v9;
            uint64_t v11;
            v11 = v8 * v10;
            return v11;
            break;
        }
        case 1: { // Nil
            UHDecref0(v0);
            uint64_t v12;
            v12 = 1l;
            uint64_t v13;
            v13 = 1ull + v12;
            uint64_t v14;
            v14 = 9223372036854765835ull * v13;
            return v14;
            break;
        }
    }
}
uint64_t method1(UH1 * v0){
    v0->refc++;
    switch (v0->tag) {
        case 0: { // Cons
            double v1 = v0->case0.v0; UH1 * v2 = v0->case0.v1;
            v2->refc++;
            UHDecref1(v0);
            uint64_t v3;
            v3 = hash(v1);
            uint64_t v4;
            v4 = v3 * 9973ull;
            uint64_t v5;
            v5 = method1(v2);
            UHDecref1(v2);
            uint64_t v6;
            v6 = v4 + v5;
            uint64_t v7;
            v7 = 9223372036854775807ull + v6;
            uint64_t v8;
            v8 = v7 * 9973ull;
            uint64_t v9;
            v9 = 0l;
            uint64_t v10;
            v10 = 1ull + v9;
            uint64_t v11;
            v11 = v8 * v10;
            return v11;
            break;
        }
        case 1: { // Nil
            UHDecref1(v0);
            uint64_t v12;
            v12 = 1l;
            uint64_t v13;
            v13 = 1ull + v12;
            uint64_t v14;
            v14 = 9223372036854765835ull * v13;
            return v14;
            break;
        }
    }
}
int32_t main(){
    uint64_t v1;
    v1 = hash(1l);
    uint64_t v2;
    v2 = 9223372036854775807ull + v1;
    uint64_t v3;
    v3 = v2 * 9973ull;
    uint64_t v4;
    v4 = 0l;
    uint64_t v5;
    v5 = 1ull + v4;
    uint64_t v6;
    v6 = v3 * v5;
    uint64_t v8;
    v8 = hash(3.0);
    uint64_t v9;
    v9 = 9223372036854775807ull + v8;
    uint64_t v10;
    v10 = v9 * 9973ull;
    uint64_t v11;
    v11 = 1l;
    uint64_t v12;
    v12 = 1ull + v11;
    uint64_t v13;
    v13 = v10 * v12;
    int32_t v14;
    v14 = 1l;
    US0 v15;
    v15 = US0_0(v14);
    uint64_t v30;
    switch (v15.tag) {
        case 0: { // A
            int32_t v16 = v15.case0.v0;
            uint64_t v17;
            v17 = hash(v16);
            uint64_t v18;
            v18 = 9223372036854775807ull + v17;
            uint64_t v19;
            v19 = v18 * 9973ull;
            uint64_t v20;
            v20 = 0l;
            uint64_t v21;
            v21 = 1ull + v20;
            uint64_t v22;
            v22 = v19 * v21;
            v30 = v22;
            break;
        }
        case 1: { // B
            double v23 = v15.case1.v0;
            uint64_t v24;
            v24 = hash(v23);
            uint64_t v25;
            v25 = 9223372036854775807ull + v24;
            uint64_t v26;
            v26 = v25 * 9973ull;
            uint64_t v27;
            v27 = 1l;
            uint64_t v28;
            v28 = 1ull + v27;
            uint64_t v29;
            v29 = v26 * v28;
            v30 = v29;
            break;
        }
    }
    USDecref0(&(v15));
    double v31;
    v31 = 3.0;
    US0 v32;
    v32 = US0_1(v31);
    uint64_t v47;
    switch (v32.tag) {
        case 0: { // A
            int32_t v33 = v32.case0.v0;
            uint64_t v34;
            v34 = hash(v33);
            uint64_t v35;
            v35 = 9223372036854775807ull + v34;
            uint64_t v36;
            v36 = v35 * 9973ull;
            uint64_t v37;
            v37 = 0l;
            uint64_t v38;
            v38 = 1ull + v37;
            uint64_t v39;
            v39 = v36 * v38;
            v47 = v39;
            break;
        }
        case 1: { // B
            double v40 = v32.case1.v0;
            uint64_t v41;
            v41 = hash(v40);
            uint64_t v42;
            v42 = 9223372036854775807ull + v41;
            uint64_t v43;
            v43 = v42 * 9973ull;
            uint64_t v44;
            v44 = 1l;
            uint64_t v45;
            v45 = 1ull + v44;
            uint64_t v46;
            v46 = v43 * v45;
            v47 = v46;
            break;
        }
    }
    USDecref0(&(v32));
    int32_t v48;
    v48 = 3l;
    UH0 * v49;
    v49 = UH0_1();
    UH0 * v50;
    v50 = UH0_0(v48, v49);
    UHDecref0(v49);
    double v51;
    v51 = 2.0;
    double v52;
    v52 = 3.0;
    UH1 * v53;
    v53 = UH1_1();
    UH1 * v54;
    v54 = UH1_0(v52, v53);
    UHDecref1(v53);
    UH1 * v55;
    v55 = UH1_0(v51, v54);
    UHDecref1(v54);
    uint64_t v58;
    v58 = hash(1l);
    uint64_t v59;
    v59 = v58 * 9973ull;
    uint64_t v61;
    v61 = hash(2l);
    uint64_t v62;
    v62 = v61 * 9973ull;
    uint64_t v63;
    v63 = method0(v50);
    UHDecref0(v50);
    uint64_t v64;
    v64 = v62 + v63;
    uint64_t v65;
    v65 = 9223372036854775807ull + v64;
    uint64_t v66;
    v66 = v65 * 9973ull;
    uint64_t v67;
    v67 = 0l;
    uint64_t v68;
    v68 = 1ull + v67;
    uint64_t v69;
    v69 = v66 * v68;
    uint64_t v70;
    v70 = v59 + v69;
    uint64_t v71;
    v71 = 9223372036854775807ull + v70;
    uint64_t v72;
    v72 = v71 * 9973ull;
    uint64_t v73;
    v73 = 0l;
    uint64_t v74;
    v74 = 1ull + v73;
    uint64_t v75;
    v75 = v72 * v74;
    uint64_t v77;
    v77 = hash(1.0);
    uint64_t v78;
    v78 = v77 * 9973ull;
    uint64_t v79;
    v79 = method1(v55);
    UHDecref1(v55);
    uint64_t v80;
    v80 = v78 + v79;
    uint64_t v81;
    v81 = 9223372036854775807ull + v80;
    uint64_t v82;
    v82 = v81 * 9973ull;
    uint64_t v83;
    v83 = 0l;
    uint64_t v84;
    v84 = 1ull + v83;
    uint64_t v85;
    v85 = v82 * v84;
    return 0l;
}
