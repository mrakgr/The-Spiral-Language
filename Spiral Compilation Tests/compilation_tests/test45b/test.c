#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
typedef struct {
    int tag;
    union {
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    US0 ptr[];
} Array1;
typedef struct {
    int refc;
    uint32_t len;
    Array1 * ptr[];
} Array0;
typedef struct {
    int refc;
    uint64_t v0;
} Mut0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array2;
typedef Array2 String;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            String * v0;
            UH0 * v1;
        } case0; // Cons
    };
};
typedef struct {
    int refc;
    uint32_t len;
    bool ptr[];
} Array4;
typedef struct {
    int refc;
    uint32_t len;
    Array4 * ptr[];
} Array3;
typedef struct {
    int tag;
    union {
        struct {
            UH0 * v0;
        } case1; // Some
    };
} US1;
typedef struct {
    int refc;
    US1 v0;
} Mut1;
typedef struct {
    uint64_t v0;
    uint64_t v1;
    UH0 * v2;
} Tuple0;
typedef struct {
    int refc;
    uint32_t len;
    Tuple0 ptr[];
} Array5;
typedef struct {
    int refc;
    uint32_t len;
    Array5 * ptr[];
} Array6;
typedef struct {
    int refc;
    uint64_t v0;
    uint64_t v1;
} Mut2;
static inline void USRefcBody0(US0 x, REFC_FLAG q){
    switch (x.tag) {
    }
}
void USRefc0(US0 * x, REFC_FLAG q){
    USRefcBody0(*x, q);
}
US0 US0_0() { // Empty
    US0 x;
    x.tag = 0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
US0 US0_1() { // Princess
    US0 x;
    x.tag = 1;
    USRefcBody0(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody1(Array1 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        US0 v = x->ptr[i];
        USRefc0(&(v), q);
    }
}
void ArrayRefc1(Array1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody1(x, REFC_DECR);
            free(x);
        }
    }
}
Array1 * ArrayCreate1(uint32_t size, bool init_at_zero){
    size = sizeof(Array1) + sizeof(US0) * size;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array1 * ArrayLit1(uint32_t size, US0 * ptr){
    Array1 * x = ArrayCreate1(size, false);
    memcpy(x->ptr, ptr, sizeof(US0) * size);
    ArrayRefcBody1(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody0(Array0 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        Array1 * v = x->ptr[i];
        ArrayRefc1(v, q);
    }
}
void ArrayRefc0(Array0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Array0 * ArrayCreate0(uint32_t size, bool init_at_zero){
    size = sizeof(Array0) + sizeof(Array1 *) * size;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, Array1 * * ptr){
    Array0 * x = ArrayCreate0(size, false);
    memcpy(x->ptr, ptr, sizeof(Array1 *) * size);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
static inline void MutRefcBody0(Mut0 * x, REFC_FLAG q){
}
void MutRefc0(Mut0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            MutRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Mut0 * MutCreate0(uint64_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 0;
        x->v0 = v0;
    MutRefcBody0(x, REFC_INCR);
    return x;
}
bool method0(uint64_t v0, Mut0 * v1){
    MutRefc0(v1, REFC_INCR);
    uint64_t v2;
    v2 = v1->v0;
    MutRefc0(v1, REFC_DECR);
    bool v3;
    v3 = v2 < v0;
    return v3;
}
static inline void AssignArray0(US0 * a, US0 b){
    USRefc0(&(b), REFC_INCR);
    USRefc0(&(*a), REFC_DECR);
    *a = b;
}
static inline void AssignMut0(uint64_t * a0, uint64_t b0){
    *a0 = b0;
}
static inline void AssignArray1(Array1 * * a, Array1 * b){
    ArrayRefc1(b, REFC_INCR);
    ArrayRefc1(*a, REFC_DECR);
    *a = b;
}
static inline void ArrayRefcBody2(Array2 * x, REFC_FLAG q){
}
void ArrayRefc2(Array2 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody2(x, REFC_DECR);
            free(x);
        }
    }
}
Array2 * ArrayCreate2(uint32_t size, bool init_at_zero){
    size = sizeof(Array2) + sizeof(char) * size;
    Array2 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array2 * ArrayLit2(uint32_t size, char * ptr){
    Array2 * x = ArrayCreate2(size, false);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    ArrayRefcBody2(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc2(x, q);
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit2(size, ptr);
}
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            StringRefc(x.case0.v0, q); UHRefc0(x.case0.v1, q);
            break;
        }
    }
}
void UHRefc0(UH0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody0(*x, REFC_DECR);
            free(x);
        }
    }
}
UH0 * UH0_0(String * v0, UH0 * v1) { // Cons
    UH0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1() { // Nil
    UH0 x;
    x.tag = 1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
static inline void ArrayRefcBody4(Array4 * x, REFC_FLAG q){
}
void ArrayRefc4(Array4 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody4(x, REFC_DECR);
            free(x);
        }
    }
}
Array4 * ArrayCreate4(uint32_t size, bool init_at_zero){
    size = sizeof(Array4) + sizeof(bool) * size;
    Array4 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array4 * ArrayLit4(uint32_t size, bool * ptr){
    Array4 * x = ArrayCreate4(size, false);
    memcpy(x->ptr, ptr, sizeof(bool) * size);
    ArrayRefcBody4(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody3(Array3 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        Array4 * v = x->ptr[i];
        ArrayRefc4(v, q);
    }
}
void ArrayRefc3(Array3 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody3(x, REFC_DECR);
            free(x);
        }
    }
}
Array3 * ArrayCreate3(uint32_t size, bool init_at_zero){
    size = sizeof(Array3) + sizeof(Array4 *) * size;
    Array3 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array3 * ArrayLit3(uint32_t size, Array4 * * ptr){
    Array3 * x = ArrayCreate3(size, false);
    memcpy(x->ptr, ptr, sizeof(Array4 *) * size);
    ArrayRefcBody3(x, REFC_INCR);
    return x;
}
static inline void AssignArray2(bool * a, bool b){
    *a = b;
}
static inline void AssignArray3(Array4 * * a, Array4 * b){
    ArrayRefc4(b, REFC_INCR);
    ArrayRefc4(*a, REFC_DECR);
    *a = b;
}
static inline void USRefcBody1(US1 x, REFC_FLAG q){
    switch (x.tag) {
        case 1: {
            UHRefc0(x.case1.v0, q);
            break;
        }
    }
}
void USRefc1(US1 * x, REFC_FLAG q){
    USRefcBody1(*x, q);
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    USRefcBody1(x, REFC_INCR);
    return x;
}
US1 US1_1(UH0 * v0) { // Some
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    USRefcBody1(x, REFC_INCR);
    return x;
}
static inline void MutRefcBody1(Mut1 * x, REFC_FLAG q){
    US1 z0 = x->v0;
    USRefc1(&(z0), q);
}
void MutRefc1(Mut1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            MutRefcBody1(x, REFC_DECR);
            free(x);
        }
    }
}
Mut1 * MutCreate1(US1 v0){
    Mut1 * x = malloc(sizeof(Mut1));
    x->refc = 0;
        x->v0 = v0;
    MutRefcBody1(x, REFC_INCR);
    return x;
}
static inline Tuple0 TupleCreate0(uint64_t v0, uint64_t v1, UH0 * v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
static inline void ArrayRefcBody5(Array5 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        Tuple0 v = x->ptr[i];
        UHRefc0(v.v2, q);
    }
}
void ArrayRefc5(Array5 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody5(x, REFC_DECR);
            free(x);
        }
    }
}
Array5 * ArrayCreate5(uint32_t size, bool init_at_zero){
    size = sizeof(Array5) + sizeof(Tuple0) * size;
    Array5 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array5 * ArrayLit5(uint32_t size, Tuple0 * ptr){
    Array5 * x = ArrayCreate5(size, false);
    memcpy(x->ptr, ptr, sizeof(Tuple0) * size);
    ArrayRefcBody5(x, REFC_INCR);
    return x;
}
static inline void AssignArray4(Tuple0 * a, Tuple0 b){
    UHRefc0(b.v2, REFC_INCR);
    UHRefc0(a->v2, REFC_DECR);
    *a = b;
}
static inline void ArrayRefcBody6(Array6 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        Array5 * v = x->ptr[i];
        ArrayRefc5(v, q);
    }
}
void ArrayRefc6(Array6 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody6(x, REFC_DECR);
            free(x);
        }
    }
}
Array6 * ArrayCreate6(uint32_t size, bool init_at_zero){
    size = sizeof(Array6) + sizeof(Array5 *) * size;
    Array6 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array6 * ArrayLit6(uint32_t size, Array5 * * ptr){
    Array6 * x = ArrayCreate6(size, false);
    memcpy(x->ptr, ptr, sizeof(Array5 *) * size);
    ArrayRefcBody6(x, REFC_INCR);
    return x;
}
static inline void AssignMut1(US1 * a0, US1 b0){
    USRefc1(&(b0), REFC_INCR);
    USRefc1(&(*a0), REFC_DECR);
    *a0 = b0;
}
static inline void AssignArray5(Array5 * * a, Array5 * b){
    ArrayRefc5(b, REFC_INCR);
    ArrayRefc5(*a, REFC_DECR);
    *a = b;
}
static inline void MutRefcBody2(Mut2 * x, REFC_FLAG q){
}
void MutRefc2(Mut2 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            MutRefcBody2(x, REFC_DECR);
            free(x);
        }
    }
}
Mut2 * MutCreate2(uint64_t v0, uint64_t v1){
    Mut2 * x = malloc(sizeof(Mut2));
    x->refc = 0;
        x->v0 = v0; x->v1 = v1;
    MutRefcBody2(x, REFC_INCR);
    return x;
}
bool method3(uint64_t v0, Mut2 * v1){
    MutRefc2(v1, REFC_INCR);
    uint64_t v2;
    v2 = v1->v0;
    MutRefc2(v1, REFC_DECR);
    bool v3;
    v3 = v2 < v0;
    return v3;
}
static inline void AssignMut2(uint64_t * a0, uint64_t b0, uint64_t * a1, uint64_t b1){
    *a0 = b0; *a1 = b1;
}
UH0 * method4(UH0 * v0, UH0 * v1){
    UHRefc0(v0, REFC_INCR); UHRefc0(v1, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            String * v2 = v0->case0.v0; UH0 * v3 = v0->case0.v1;
            UHRefc0(v0, REFC_DECR);
            UH0 * v4;
            v4 = UH0_0(v2, v1);
            UHRefc0(v4, REFC_INCR);
            UHRefc0(v1, REFC_DECR);
            UHRefc0(v3, REFC_SUPPR); UHRefc0(v4, REFC_SUPPR);
            return method4(v3, v4);
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            UHRefc0(v1, REFC_SUPPR);
            return v1;
            break;
        }
    }
}
UH0 * method2(Array3 * v0, Array0 * v1, Mut1 * v2, Array5 * v3){
    ArrayRefc3(v0, REFC_INCR); ArrayRefc0(v1, REFC_INCR); MutRefc1(v2, REFC_INCR); ArrayRefc5(v3, REFC_INCR);
    uint64_t v4;
    v4 = v3->len;;
    Array6 * v5;
    v5 = ArrayCreate6(v4, true);
    ArrayRefc6(v5, REFC_INCR);
    Mut0 * v6;
    v6 = MutCreate0(0ull);
    MutRefc0(v6, REFC_INCR);
    while (method0(v4, v6)){
        uint64_t v8;
        v8 = v6->v0;
        uint64_t v9; uint64_t v10; UH0 * v11;
        Tuple0 tmp0 = v3->ptr[v8];
        v9 = tmp0.v0; v10 = tmp0.v1; v11 = tmp0.v2;
        UHRefc0(v11, REFC_INCR);
        uint64_t v12;
        v12 = v9 - 1ull;
        bool v13;
        v13 = 0ull <= v12;
        bool v22;
        if (v13){
            uint64_t v14;
            v14 = v1->len;;
            bool v15;
            v15 = v12 < v14;
            if (v15){
                Array1 * v16;
                v16 = v1->ptr[v12];
                ArrayRefc1(v16, REFC_INCR);
                bool v17;
                v17 = 0ull <= v10;
                if (v17){
                    uint64_t v18;
                    v18 = v16->len;;
                    ArrayRefc1(v16, REFC_DECR);
                    bool v19;
                    v19 = v10 < v18;
                    v22 = v19;
                } else {
                    ArrayRefc1(v16, REFC_DECR);
                    v22 = false;
                }
            } else {
                v22 = false;
            }
        } else {
            v22 = false;
        }
        bool v26;
        if (v22){
            Array4 * v23;
            v23 = v0->ptr[v12];
            ArrayRefc4(v23, REFC_INCR);
            bool v24;
            v24 = v23->ptr[v10];
            ArrayRefc4(v23, REFC_DECR);
            bool v25;
            v25 = v24 == false;
            v26 = v25;
        } else {
            v26 = false;
        }
        bool v33;
        if (v26){
            Array1 * v27;
            v27 = v1->ptr[v12];
            ArrayRefc1(v27, REFC_INCR);
            US0 v28;
            v28 = v27->ptr[v10];
            USRefc0(&(v28), REFC_INCR);
            ArrayRefc1(v27, REFC_DECR);
            bool v29;
            switch (v28.tag) {
                case 0: { // Empty
                    v29 = false;
                    break;
                }
                case 1: { // Princess
                    v29 = true;
                    break;
                }
            }
            USRefc0(&(v28), REFC_DECR);
            if (v29){
                UH0 * v30;
                v30 = UH0_0(StringLit(2, "UP"), v11);
                UHRefc0(v30, REFC_INCR);
                US1 v31;
                v31 = US1_1(v30);
                USRefc1(&(v31), REFC_INCR);
                UHRefc0(v30, REFC_DECR);
                AssignMut1(&(v2->v0), v31);
                USRefc1(&(v31), REFC_DECR);
            } else {
            }
            Array4 * v32;
            v32 = v0->ptr[v12];
            ArrayRefc4(v32, REFC_INCR);
            AssignArray2(v32->ptr+v10, true);
            ArrayRefc4(v32, REFC_DECR);
            v33 = true;
        } else {
            v33 = false;
        }
        uint64_t v34;
        v34 = v9 + 1ull;
        bool v35;
        v35 = 0ull <= v34;
        bool v44;
        if (v35){
            uint64_t v36;
            v36 = v1->len;;
            bool v37;
            v37 = v34 < v36;
            if (v37){
                Array1 * v38;
                v38 = v1->ptr[v34];
                ArrayRefc1(v38, REFC_INCR);
                bool v39;
                v39 = 0ull <= v10;
                if (v39){
                    uint64_t v40;
                    v40 = v38->len;;
                    ArrayRefc1(v38, REFC_DECR);
                    bool v41;
                    v41 = v10 < v40;
                    v44 = v41;
                } else {
                    ArrayRefc1(v38, REFC_DECR);
                    v44 = false;
                }
            } else {
                v44 = false;
            }
        } else {
            v44 = false;
        }
        bool v48;
        if (v44){
            Array4 * v45;
            v45 = v0->ptr[v34];
            ArrayRefc4(v45, REFC_INCR);
            bool v46;
            v46 = v45->ptr[v10];
            ArrayRefc4(v45, REFC_DECR);
            bool v47;
            v47 = v46 == false;
            v48 = v47;
        } else {
            v48 = false;
        }
        bool v55;
        if (v48){
            Array1 * v49;
            v49 = v1->ptr[v34];
            ArrayRefc1(v49, REFC_INCR);
            US0 v50;
            v50 = v49->ptr[v10];
            USRefc0(&(v50), REFC_INCR);
            ArrayRefc1(v49, REFC_DECR);
            bool v51;
            switch (v50.tag) {
                case 0: { // Empty
                    v51 = false;
                    break;
                }
                case 1: { // Princess
                    v51 = true;
                    break;
                }
            }
            USRefc0(&(v50), REFC_DECR);
            if (v51){
                UH0 * v52;
                v52 = UH0_0(StringLit(4, "DOWN"), v11);
                UHRefc0(v52, REFC_INCR);
                US1 v53;
                v53 = US1_1(v52);
                USRefc1(&(v53), REFC_INCR);
                UHRefc0(v52, REFC_DECR);
                AssignMut1(&(v2->v0), v53);
                USRefc1(&(v53), REFC_DECR);
            } else {
            }
            Array4 * v54;
            v54 = v0->ptr[v34];
            ArrayRefc4(v54, REFC_INCR);
            AssignArray2(v54->ptr+v10, true);
            ArrayRefc4(v54, REFC_DECR);
            v55 = true;
        } else {
            v55 = false;
        }
        uint64_t v56;
        v56 = v10 - 1ull;
        bool v57;
        v57 = 0ull <= v9;
        bool v66;
        if (v57){
            uint64_t v58;
            v58 = v1->len;;
            bool v59;
            v59 = v9 < v58;
            if (v59){
                Array1 * v60;
                v60 = v1->ptr[v9];
                ArrayRefc1(v60, REFC_INCR);
                bool v61;
                v61 = 0ull <= v56;
                if (v61){
                    uint64_t v62;
                    v62 = v60->len;;
                    ArrayRefc1(v60, REFC_DECR);
                    bool v63;
                    v63 = v56 < v62;
                    v66 = v63;
                } else {
                    ArrayRefc1(v60, REFC_DECR);
                    v66 = false;
                }
            } else {
                v66 = false;
            }
        } else {
            v66 = false;
        }
        bool v70;
        if (v66){
            Array4 * v67;
            v67 = v0->ptr[v9];
            ArrayRefc4(v67, REFC_INCR);
            bool v68;
            v68 = v67->ptr[v56];
            ArrayRefc4(v67, REFC_DECR);
            bool v69;
            v69 = v68 == false;
            v70 = v69;
        } else {
            v70 = false;
        }
        bool v77;
        if (v70){
            Array1 * v71;
            v71 = v1->ptr[v9];
            ArrayRefc1(v71, REFC_INCR);
            US0 v72;
            v72 = v71->ptr[v56];
            USRefc0(&(v72), REFC_INCR);
            ArrayRefc1(v71, REFC_DECR);
            bool v73;
            switch (v72.tag) {
                case 0: { // Empty
                    v73 = false;
                    break;
                }
                case 1: { // Princess
                    v73 = true;
                    break;
                }
            }
            USRefc0(&(v72), REFC_DECR);
            if (v73){
                UH0 * v74;
                v74 = UH0_0(StringLit(4, "LEFT"), v11);
                UHRefc0(v74, REFC_INCR);
                US1 v75;
                v75 = US1_1(v74);
                USRefc1(&(v75), REFC_INCR);
                UHRefc0(v74, REFC_DECR);
                AssignMut1(&(v2->v0), v75);
                USRefc1(&(v75), REFC_DECR);
            } else {
            }
            Array4 * v76;
            v76 = v0->ptr[v9];
            ArrayRefc4(v76, REFC_INCR);
            AssignArray2(v76->ptr+v56, true);
            ArrayRefc4(v76, REFC_DECR);
            v77 = true;
        } else {
            v77 = false;
        }
        uint64_t v78;
        v78 = v10 + 1ull;
        bool v87;
        if (v57){
            uint64_t v79;
            v79 = v1->len;;
            bool v80;
            v80 = v9 < v79;
            if (v80){
                Array1 * v81;
                v81 = v1->ptr[v9];
                ArrayRefc1(v81, REFC_INCR);
                bool v82;
                v82 = 0ull <= v78;
                if (v82){
                    uint64_t v83;
                    v83 = v81->len;;
                    ArrayRefc1(v81, REFC_DECR);
                    bool v84;
                    v84 = v78 < v83;
                    v87 = v84;
                } else {
                    ArrayRefc1(v81, REFC_DECR);
                    v87 = false;
                }
            } else {
                v87 = false;
            }
        } else {
            v87 = false;
        }
        bool v91;
        if (v87){
            Array4 * v88;
            v88 = v0->ptr[v9];
            ArrayRefc4(v88, REFC_INCR);
            bool v89;
            v89 = v88->ptr[v78];
            ArrayRefc4(v88, REFC_DECR);
            bool v90;
            v90 = v89 == false;
            v91 = v90;
        } else {
            v91 = false;
        }
        bool v98;
        if (v91){
            Array1 * v92;
            v92 = v1->ptr[v9];
            ArrayRefc1(v92, REFC_INCR);
            US0 v93;
            v93 = v92->ptr[v78];
            USRefc0(&(v93), REFC_INCR);
            ArrayRefc1(v92, REFC_DECR);
            bool v94;
            switch (v93.tag) {
                case 0: { // Empty
                    v94 = false;
                    break;
                }
                case 1: { // Princess
                    v94 = true;
                    break;
                }
            }
            USRefc0(&(v93), REFC_DECR);
            if (v94){
                UH0 * v95;
                v95 = UH0_0(StringLit(5, "RIGHT"), v11);
                UHRefc0(v95, REFC_INCR);
                US1 v96;
                v96 = US1_1(v95);
                USRefc1(&(v96), REFC_INCR);
                UHRefc0(v95, REFC_DECR);
                AssignMut1(&(v2->v0), v96);
                USRefc1(&(v96), REFC_DECR);
            } else {
            }
            Array4 * v97;
            v97 = v0->ptr[v9];
            ArrayRefc4(v97, REFC_INCR);
            AssignArray2(v97->ptr+v78, true);
            ArrayRefc4(v97, REFC_DECR);
            v98 = true;
        } else {
            v98 = false;
        }
        uint64_t v99;
        if (v33){
            v99 = 1ull;
        } else {
            v99 = 0ull;
        }
        uint64_t v100;
        if (v55){
            v100 = 1ull;
        } else {
            v100 = 0ull;
        }
        uint64_t v101;
        v101 = v99 + v100;
        uint64_t v102;
        if (v77){
            v102 = 1ull;
        } else {
            v102 = 0ull;
        }
        uint64_t v103;
        v103 = v101 + v102;
        uint64_t v104;
        if (v98){
            v104 = 1ull;
        } else {
            v104 = 0ull;
        }
        uint64_t v105;
        v105 = v103 + v104;
        Array5 * v106;
        v106 = ArrayCreate5(v105, true);
        ArrayRefc5(v106, REFC_INCR);
        uint64_t v108;
        if (v33){
            UH0 * v107;
            v107 = UH0_0(StringLit(2, "UP"), v11);
            UHRefc0(v107, REFC_INCR);
            AssignArray4(v106->ptr+0ull, TupleCreate0(v12, v10, v107));
            UHRefc0(v107, REFC_DECR);
            v108 = 1ull;
        } else {
            v108 = 0ull;
        }
        uint64_t v111;
        if (v55){
            UH0 * v109;
            v109 = UH0_0(StringLit(4, "DOWN"), v11);
            UHRefc0(v109, REFC_INCR);
            AssignArray4(v106->ptr+v108, TupleCreate0(v34, v10, v109));
            UHRefc0(v109, REFC_DECR);
            uint64_t v110;
            v110 = v108 + 1ull;
            v111 = v110;
        } else {
            v111 = v108;
        }
        uint64_t v114;
        if (v77){
            UH0 * v112;
            v112 = UH0_0(StringLit(4, "LEFT"), v11);
            UHRefc0(v112, REFC_INCR);
            AssignArray4(v106->ptr+v111, TupleCreate0(v9, v56, v112));
            UHRefc0(v112, REFC_DECR);
            uint64_t v113;
            v113 = v111 + 1ull;
            v114 = v113;
        } else {
            v114 = v111;
        }
        uint64_t v117;
        if (v98){
            UH0 * v115;
            v115 = UH0_0(StringLit(5, "RIGHT"), v11);
            UHRefc0(v115, REFC_INCR);
            AssignArray4(v106->ptr+v114, TupleCreate0(v9, v78, v115));
            UHRefc0(v115, REFC_DECR);
            uint64_t v116;
            v116 = v114 + 1ull;
            v117 = v116;
        } else {
            v117 = v114;
        }
        UHRefc0(v11, REFC_DECR);
        AssignArray5(v5->ptr+v8, v106);
        ArrayRefc5(v106, REFC_DECR);
        uint64_t v118;
        v118 = v8 + 1ull;
        AssignMut0(&(v6->v0), v118);
    }
    ArrayRefc5(v3, REFC_DECR);
    MutRefc0(v6, REFC_DECR);
    uint64_t v119;
    v119 = v5->len;;
    Mut2 * v120;
    v120 = MutCreate2(0ull, 0ull);
    MutRefc2(v120, REFC_INCR);
    while (method3(v119, v120)){
        uint64_t v122;
        v122 = v120->v0;
        uint64_t v123;
        v123 = v120->v1;
        Array5 * v124;
        v124 = v5->ptr[v122];
        ArrayRefc5(v124, REFC_INCR);
        uint64_t v125;
        v125 = v124->len;;
        ArrayRefc5(v124, REFC_DECR);
        uint64_t v126;
        v126 = v123 + v125;
        uint64_t v127;
        v127 = v122 + 1ull;
        AssignMut2(&(v120->v0), v127, &(v120->v1), v126);
    }
    uint64_t v128;
    v128 = v120->v1;
    MutRefc2(v120, REFC_DECR);
    Array5 * v129;
    v129 = ArrayCreate5(v128, true);
    ArrayRefc5(v129, REFC_INCR);
    Mut2 * v130;
    v130 = MutCreate2(0ull, 0ull);
    MutRefc2(v130, REFC_INCR);
    while (method3(v119, v130)){
        uint64_t v132;
        v132 = v130->v0;
        uint64_t v133;
        v133 = v130->v1;
        Array5 * v134;
        v134 = v5->ptr[v132];
        ArrayRefc5(v134, REFC_INCR);
        uint64_t v135;
        v135 = v134->len;;
        Mut2 * v136;
        v136 = MutCreate2(0ull, v133);
        MutRefc2(v136, REFC_INCR);
        while (method3(v135, v136)){
            uint64_t v138;
            v138 = v136->v0;
            uint64_t v139;
            v139 = v136->v1;
            uint64_t v140; uint64_t v141; UH0 * v142;
            Tuple0 tmp1 = v134->ptr[v138];
            v140 = tmp1.v0; v141 = tmp1.v1; v142 = tmp1.v2;
            UHRefc0(v142, REFC_INCR);
            AssignArray4(v129->ptr+v139, TupleCreate0(v140, v141, v142));
            UHRefc0(v142, REFC_DECR);
            uint64_t v143;
            v143 = v139 + 1ull;
            uint64_t v144;
            v144 = v138 + 1ull;
            AssignMut2(&(v136->v0), v144, &(v136->v1), v143);
        }
        ArrayRefc5(v134, REFC_DECR);
        uint64_t v145;
        v145 = v136->v1;
        MutRefc2(v136, REFC_DECR);
        uint64_t v146;
        v146 = v132 + 1ull;
        AssignMut2(&(v130->v0), v146, &(v130->v1), v145);
    }
    ArrayRefc6(v5, REFC_DECR);
    uint64_t v147;
    v147 = v130->v1;
    MutRefc2(v130, REFC_DECR);
    US1 v148;
    v148 = v2->v0;
    USRefc1(&(v148), REFC_INCR);
    switch (v148.tag) {
        case 0: { // None
            USRefc1(&(v148), REFC_DECR);
            ArrayRefc3(v0, REFC_SUPPR); ArrayRefc0(v1, REFC_SUPPR); MutRefc1(v2, REFC_SUPPR); ArrayRefc5(v129, REFC_SUPPR);
            return method2(v0, v1, v2, v129);
            break;
        }
        case 1: { // Some
            UH0 * v150 = v148.case1.v0;
            ArrayRefc3(v0, REFC_DECR); ArrayRefc0(v1, REFC_DECR); MutRefc1(v2, REFC_DECR); ArrayRefc5(v129, REFC_DECR); USRefc1(&(v148), REFC_DECR);
            UH0 * v151;
            v151 = UH0_1();
            UHRefc0(v151, REFC_INCR);
            UHRefc0(v150, REFC_SUPPR); UHRefc0(v151, REFC_SUPPR);
            return method4(v150, v151);
            break;
        }
    }
}
UH0 * method1(Array0 * v0, uint64_t v1, uint64_t v2){
    ArrayRefc0(v0, REFC_INCR);
    printf("%s\n","qwe");
    uint64_t v3;
    v3 = v0->len;;
    Array3 * v4;
    v4 = ArrayCreate3(v3, true);
    ArrayRefc3(v4, REFC_INCR);
    Mut0 * v5;
    v5 = MutCreate0(0ull);
    MutRefc0(v5, REFC_INCR);
    while (method0(v3, v5)){
        uint64_t v7;
        v7 = v5->v0;
        Array1 * v8;
        v8 = v0->ptr[v7];
        ArrayRefc1(v8, REFC_INCR);
        uint64_t v9;
        v9 = v8->len;;
        ArrayRefc1(v8, REFC_DECR);
        Array4 * v10;
        v10 = ArrayCreate4(v9, false);
        ArrayRefc4(v10, REFC_INCR);
        Mut0 * v11;
        v11 = MutCreate0(0ull);
        MutRefc0(v11, REFC_INCR);
        while (method0(v9, v11)){
            uint64_t v13;
            v13 = v11->v0;
            AssignArray2(v10->ptr+v13, false);
            uint64_t v14;
            v14 = v13 + 1ull;
            AssignMut0(&(v11->v0), v14);
        }
        MutRefc0(v11, REFC_DECR);
        AssignArray3(v4->ptr+v7, v10);
        ArrayRefc4(v10, REFC_DECR);
        uint64_t v15;
        v15 = v7 + 1ull;
        AssignMut0(&(v5->v0), v15);
    }
    MutRefc0(v5, REFC_DECR);
    printf("%s\n","asd");
    US1 v16;
    v16 = US1_0();
    USRefc1(&(v16), REFC_INCR);
    Mut1 * v17;
    v17 = MutCreate1(v16);
    MutRefc1(v17, REFC_INCR);
    USRefc1(&(v16), REFC_DECR);
    Array5 * v18;
    v18 = ArrayCreate5(1ull, true);
    ArrayRefc5(v18, REFC_INCR);
    UH0 * v19;
    v19 = UH0_1();
    UHRefc0(v19, REFC_INCR);
    AssignArray4(v18->ptr+0ull, TupleCreate0(v1, v2, v19));
    UHRefc0(v19, REFC_DECR);
    ArrayRefc3(v4, REFC_SUPPR); ArrayRefc0(v0, REFC_SUPPR); MutRefc1(v17, REFC_SUPPR); ArrayRefc5(v18, REFC_SUPPR);
    return method2(v4, v0, v17, v18);
}
void method5(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            UHRefc0(v0, REFC_DECR);
            printf("%s\n",v1->ptr);
            UHRefc0(v2, REFC_SUPPR);
            return method5(v2);
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            return ;
            break;
        }
    }
}
int32_t main(){
    uint64_t v0;
    v0 = 4ull;
    uint64_t v1;
    v1 = 2ull;
    uint64_t v2;
    v2 = 3ull;
    printf("%s\n","Initing");
    Array0 * v3;
    v3 = ArrayCreate0(v0, true);
    ArrayRefc0(v3, REFC_INCR);
    Mut0 * v4;
    v4 = MutCreate0(0ull);
    MutRefc0(v4, REFC_INCR);
    while (method0(v0, v4)){
        uint64_t v6;
        v6 = v4->v0;
        Array1 * v7;
        v7 = ArrayCreate1(v0, false);
        ArrayRefc1(v7, REFC_INCR);
        Mut0 * v8;
        v8 = MutCreate0(0ull);
        MutRefc0(v8, REFC_INCR);
        while (method0(v0, v8)){
            uint64_t v10;
            v10 = v8->v0;
            bool v11;
            v11 = v6 == v1;
            bool v13;
            if (v11){
                bool v12;
                v12 = v10 == v2;
                v13 = v12;
            } else {
                v13 = false;
            }
            US0 v16;
            if (v13){
                v16 = US0_1();
            } else {
                v16 = US0_0();
            }
            USRefc0(&(v16), REFC_INCR);
            AssignArray0(v7->ptr+v10, v16);
            USRefc0(&(v16), REFC_DECR);
            uint64_t v17;
            v17 = v10 + 1ull;
            AssignMut0(&(v8->v0), v17);
        }
        MutRefc0(v8, REFC_DECR);
        AssignArray1(v3->ptr+v6, v7);
        ArrayRefc1(v7, REFC_DECR);
        uint64_t v18;
        v18 = v6 + 1ull;
        AssignMut0(&(v4->v0), v18);
    }
    MutRefc0(v4, REFC_DECR);
    printf("%s\n","Starting");
    uint64_t v19;
    v19 = 0ull;
    uint64_t v20;
    v20 = 0ull;
    UH0 * v21;
    v21 = method1(v3, v19, v20);
    UHRefc0(v21, REFC_INCR);
    ArrayRefc0(v3, REFC_DECR);
    printf("%s\n","Printing");
    method5(v21);
    UHRefc0(v21, REFC_DECR);
    return 0l;
}
