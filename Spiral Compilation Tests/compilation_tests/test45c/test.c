#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
void UHRefc0(UH0 * x, REFC_FLAG q);
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
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(US0) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, US0 * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(US0) * len);
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
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Array1 *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, Array1 * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Array1 *) * len);
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
    x->refc = 1;
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
Array2 * ArrayCreate2(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array2) + sizeof(char) * len;
    Array2 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array2 * ArrayLit2(uint32_t len, char * ptr){
    Array2 * x = ArrayCreate2(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    ArrayRefcBody2(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc2(x, q);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit2(len, ptr);
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
    x.refc = 1;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1() { // Nil
    UH0 x;
    x.tag = 1;
    x.refc = 1;
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
Array4 * ArrayCreate4(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array4) + sizeof(bool) * len;
    Array4 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array4 * ArrayLit4(uint32_t len, bool * ptr){
    Array4 * x = ArrayCreate4(len, false);
    memcpy(x->ptr, ptr, sizeof(bool) * len);
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
Array3 * ArrayCreate3(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array3) + sizeof(Array4 *) * len;
    Array3 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array3 * ArrayLit3(uint32_t len, Array4 * * ptr){
    Array3 * x = ArrayCreate3(len, false);
    memcpy(x->ptr, ptr, sizeof(Array4 *) * len);
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
    x->refc = 1;
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
Array5 * ArrayCreate5(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array5) + sizeof(Tuple0) * len;
    Array5 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array5 * ArrayLit5(uint32_t len, Tuple0 * ptr){
    Array5 * x = ArrayCreate5(len, false);
    memcpy(x->ptr, ptr, sizeof(Tuple0) * len);
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
Array6 * ArrayCreate6(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array6) + sizeof(Array5 *) * len;
    Array6 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array6 * ArrayLit6(uint32_t len, Array5 * * ptr){
    Array6 * x = ArrayCreate6(len, false);
    memcpy(x->ptr, ptr, sizeof(Array5 *) * len);
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
    x->refc = 1;
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
            StringRefc(v2, REFC_INCR); UHRefc0(v3, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            UH0 * v4;
            v4 = UH0_0(v2, v1);
            UHRefc0(v1, REFC_DECR); StringRefc(v2, REFC_DECR);
            UHRefc0(v3, REFC_SUPPR); UHRefc0(v4, REFC_SUPPR);
            return method4(v3, v4);
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            return v1;
            break;
        }
    }
}
UH0 * method2(Array3 * v0, Array0 * v1, Mut1 * v2, Array5 * v3){
    ArrayRefc3(v0, REFC_INCR); ArrayRefc0(v1, REFC_INCR); MutRefc1(v2, REFC_INCR); ArrayRefc5(v3, REFC_INCR);
    uint64_t v4;
    v4 = v3->len;
    Array6 * v5;
    v5 = ArrayCreate6(v4, true);
    Mut0 * v6;
    v6 = MutCreate0(0ull);
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
            v14 = v1->len;
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
                    v18 = v16->len;
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
        bool v34;
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
                String * v30;
                v30 = StringLit(3, "UP");
                UH0 * v31;
                v31 = UH0_0(v30, v11);
                StringRefc(v30, REFC_DECR);
                US1 v32;
                v32 = US1_1(v31);
                UHRefc0(v31, REFC_DECR);
                AssignMut1(&(v2->v0), v32);
                USRefc1(&(v32), REFC_DECR);
            } else {
            }
            Array4 * v33;
            v33 = v0->ptr[v12];
            ArrayRefc4(v33, REFC_INCR);
            AssignArray2(&(v33->ptr[v10]), true);
            ArrayRefc4(v33, REFC_DECR);
            v34 = true;
        } else {
            v34 = false;
        }
        uint64_t v35;
        v35 = v9 + 1ull;
        bool v36;
        v36 = 0ull <= v35;
        bool v45;
        if (v36){
            uint64_t v37;
            v37 = v1->len;
            bool v38;
            v38 = v35 < v37;
            if (v38){
                Array1 * v39;
                v39 = v1->ptr[v35];
                ArrayRefc1(v39, REFC_INCR);
                bool v40;
                v40 = 0ull <= v10;
                if (v40){
                    uint64_t v41;
                    v41 = v39->len;
                    ArrayRefc1(v39, REFC_DECR);
                    bool v42;
                    v42 = v10 < v41;
                    v45 = v42;
                } else {
                    ArrayRefc1(v39, REFC_DECR);
                    v45 = false;
                }
            } else {
                v45 = false;
            }
        } else {
            v45 = false;
        }
        bool v49;
        if (v45){
            Array4 * v46;
            v46 = v0->ptr[v35];
            ArrayRefc4(v46, REFC_INCR);
            bool v47;
            v47 = v46->ptr[v10];
            ArrayRefc4(v46, REFC_DECR);
            bool v48;
            v48 = v47 == false;
            v49 = v48;
        } else {
            v49 = false;
        }
        bool v57;
        if (v49){
            Array1 * v50;
            v50 = v1->ptr[v35];
            ArrayRefc1(v50, REFC_INCR);
            US0 v51;
            v51 = v50->ptr[v10];
            USRefc0(&(v51), REFC_INCR);
            ArrayRefc1(v50, REFC_DECR);
            bool v52;
            switch (v51.tag) {
                case 0: { // Empty
                    v52 = false;
                    break;
                }
                case 1: { // Princess
                    v52 = true;
                    break;
                }
            }
            USRefc0(&(v51), REFC_DECR);
            if (v52){
                String * v53;
                v53 = StringLit(5, "DOWN");
                UH0 * v54;
                v54 = UH0_0(v53, v11);
                StringRefc(v53, REFC_DECR);
                US1 v55;
                v55 = US1_1(v54);
                UHRefc0(v54, REFC_DECR);
                AssignMut1(&(v2->v0), v55);
                USRefc1(&(v55), REFC_DECR);
            } else {
            }
            Array4 * v56;
            v56 = v0->ptr[v35];
            ArrayRefc4(v56, REFC_INCR);
            AssignArray2(&(v56->ptr[v10]), true);
            ArrayRefc4(v56, REFC_DECR);
            v57 = true;
        } else {
            v57 = false;
        }
        uint64_t v58;
        v58 = v10 - 1ull;
        bool v59;
        v59 = 0ull <= v9;
        bool v68;
        if (v59){
            uint64_t v60;
            v60 = v1->len;
            bool v61;
            v61 = v9 < v60;
            if (v61){
                Array1 * v62;
                v62 = v1->ptr[v9];
                ArrayRefc1(v62, REFC_INCR);
                bool v63;
                v63 = 0ull <= v58;
                if (v63){
                    uint64_t v64;
                    v64 = v62->len;
                    ArrayRefc1(v62, REFC_DECR);
                    bool v65;
                    v65 = v58 < v64;
                    v68 = v65;
                } else {
                    ArrayRefc1(v62, REFC_DECR);
                    v68 = false;
                }
            } else {
                v68 = false;
            }
        } else {
            v68 = false;
        }
        bool v72;
        if (v68){
            Array4 * v69;
            v69 = v0->ptr[v9];
            ArrayRefc4(v69, REFC_INCR);
            bool v70;
            v70 = v69->ptr[v58];
            ArrayRefc4(v69, REFC_DECR);
            bool v71;
            v71 = v70 == false;
            v72 = v71;
        } else {
            v72 = false;
        }
        bool v80;
        if (v72){
            Array1 * v73;
            v73 = v1->ptr[v9];
            ArrayRefc1(v73, REFC_INCR);
            US0 v74;
            v74 = v73->ptr[v58];
            USRefc0(&(v74), REFC_INCR);
            ArrayRefc1(v73, REFC_DECR);
            bool v75;
            switch (v74.tag) {
                case 0: { // Empty
                    v75 = false;
                    break;
                }
                case 1: { // Princess
                    v75 = true;
                    break;
                }
            }
            USRefc0(&(v74), REFC_DECR);
            if (v75){
                String * v76;
                v76 = StringLit(5, "LEFT");
                UH0 * v77;
                v77 = UH0_0(v76, v11);
                StringRefc(v76, REFC_DECR);
                US1 v78;
                v78 = US1_1(v77);
                UHRefc0(v77, REFC_DECR);
                AssignMut1(&(v2->v0), v78);
                USRefc1(&(v78), REFC_DECR);
            } else {
            }
            Array4 * v79;
            v79 = v0->ptr[v9];
            ArrayRefc4(v79, REFC_INCR);
            AssignArray2(&(v79->ptr[v58]), true);
            ArrayRefc4(v79, REFC_DECR);
            v80 = true;
        } else {
            v80 = false;
        }
        uint64_t v81;
        v81 = v10 + 1ull;
        bool v90;
        if (v59){
            uint64_t v82;
            v82 = v1->len;
            bool v83;
            v83 = v9 < v82;
            if (v83){
                Array1 * v84;
                v84 = v1->ptr[v9];
                ArrayRefc1(v84, REFC_INCR);
                bool v85;
                v85 = 0ull <= v81;
                if (v85){
                    uint64_t v86;
                    v86 = v84->len;
                    ArrayRefc1(v84, REFC_DECR);
                    bool v87;
                    v87 = v81 < v86;
                    v90 = v87;
                } else {
                    ArrayRefc1(v84, REFC_DECR);
                    v90 = false;
                }
            } else {
                v90 = false;
            }
        } else {
            v90 = false;
        }
        bool v94;
        if (v90){
            Array4 * v91;
            v91 = v0->ptr[v9];
            ArrayRefc4(v91, REFC_INCR);
            bool v92;
            v92 = v91->ptr[v81];
            ArrayRefc4(v91, REFC_DECR);
            bool v93;
            v93 = v92 == false;
            v94 = v93;
        } else {
            v94 = false;
        }
        bool v102;
        if (v94){
            Array1 * v95;
            v95 = v1->ptr[v9];
            ArrayRefc1(v95, REFC_INCR);
            US0 v96;
            v96 = v95->ptr[v81];
            USRefc0(&(v96), REFC_INCR);
            ArrayRefc1(v95, REFC_DECR);
            bool v97;
            switch (v96.tag) {
                case 0: { // Empty
                    v97 = false;
                    break;
                }
                case 1: { // Princess
                    v97 = true;
                    break;
                }
            }
            USRefc0(&(v96), REFC_DECR);
            if (v97){
                String * v98;
                v98 = StringLit(6, "RIGHT");
                UH0 * v99;
                v99 = UH0_0(v98, v11);
                StringRefc(v98, REFC_DECR);
                US1 v100;
                v100 = US1_1(v99);
                UHRefc0(v99, REFC_DECR);
                AssignMut1(&(v2->v0), v100);
                USRefc1(&(v100), REFC_DECR);
            } else {
            }
            Array4 * v101;
            v101 = v0->ptr[v9];
            ArrayRefc4(v101, REFC_INCR);
            AssignArray2(&(v101->ptr[v81]), true);
            ArrayRefc4(v101, REFC_DECR);
            v102 = true;
        } else {
            v102 = false;
        }
        uint64_t v103;
        if (v34){
            v103 = 1ull;
        } else {
            v103 = 0ull;
        }
        uint64_t v104;
        if (v57){
            v104 = 1ull;
        } else {
            v104 = 0ull;
        }
        uint64_t v105;
        v105 = v103 + v104;
        uint64_t v106;
        if (v80){
            v106 = 1ull;
        } else {
            v106 = 0ull;
        }
        uint64_t v107;
        v107 = v105 + v106;
        uint64_t v108;
        if (v102){
            v108 = 1ull;
        } else {
            v108 = 0ull;
        }
        uint64_t v109;
        v109 = v107 + v108;
        Array5 * v110;
        v110 = ArrayCreate5(v109, true);
        uint64_t v113;
        if (v34){
            String * v111;
            v111 = StringLit(3, "UP");
            UH0 * v112;
            v112 = UH0_0(v111, v11);
            StringRefc(v111, REFC_DECR);
            AssignArray4(&(v110->ptr[0ull]), TupleCreate0(v12, v10, v112));
            UHRefc0(v112, REFC_DECR);
            v113 = 1ull;
        } else {
            v113 = 0ull;
        }
        uint64_t v117;
        if (v57){
            String * v114;
            v114 = StringLit(5, "DOWN");
            UH0 * v115;
            v115 = UH0_0(v114, v11);
            StringRefc(v114, REFC_DECR);
            AssignArray4(&(v110->ptr[v113]), TupleCreate0(v35, v10, v115));
            UHRefc0(v115, REFC_DECR);
            uint64_t v116;
            v116 = v113 + 1ull;
            v117 = v116;
        } else {
            v117 = v113;
        }
        uint64_t v121;
        if (v80){
            String * v118;
            v118 = StringLit(5, "LEFT");
            UH0 * v119;
            v119 = UH0_0(v118, v11);
            StringRefc(v118, REFC_DECR);
            AssignArray4(&(v110->ptr[v117]), TupleCreate0(v9, v58, v119));
            UHRefc0(v119, REFC_DECR);
            uint64_t v120;
            v120 = v117 + 1ull;
            v121 = v120;
        } else {
            v121 = v117;
        }
        uint64_t v125;
        if (v102){
            String * v122;
            v122 = StringLit(6, "RIGHT");
            UH0 * v123;
            v123 = UH0_0(v122, v11);
            StringRefc(v122, REFC_DECR);
            AssignArray4(&(v110->ptr[v121]), TupleCreate0(v9, v81, v123));
            UHRefc0(v123, REFC_DECR);
            uint64_t v124;
            v124 = v121 + 1ull;
            v125 = v124;
        } else {
            v125 = v121;
        }
        UHRefc0(v11, REFC_DECR);
        AssignArray5(&(v5->ptr[v8]), v110);
        ArrayRefc5(v110, REFC_DECR);
        uint64_t v126;
        v126 = v8 + 1ull;
        AssignMut0(&(v6->v0), v126);
    }
    ArrayRefc5(v3, REFC_DECR);
    MutRefc0(v6, REFC_DECR);
    uint64_t v127;
    v127 = v5->len;
    Mut2 * v128;
    v128 = MutCreate2(0ull, 0ull);
    while (method3(v127, v128)){
        uint64_t v130;
        v130 = v128->v0;
        uint64_t v131;
        v131 = v128->v1;
        Array5 * v132;
        v132 = v5->ptr[v130];
        ArrayRefc5(v132, REFC_INCR);
        uint64_t v133;
        v133 = v132->len;
        ArrayRefc5(v132, REFC_DECR);
        uint64_t v134;
        v134 = v131 + v133;
        uint64_t v135;
        v135 = v130 + 1ull;
        AssignMut2(&(v128->v0), v135, &(v128->v1), v134);
    }
    uint64_t v136;
    v136 = v128->v1;
    MutRefc2(v128, REFC_DECR);
    Array5 * v137;
    v137 = ArrayCreate5(v136, true);
    Mut2 * v138;
    v138 = MutCreate2(0ull, 0ull);
    while (method3(v127, v138)){
        uint64_t v140;
        v140 = v138->v0;
        uint64_t v141;
        v141 = v138->v1;
        Array5 * v142;
        v142 = v5->ptr[v140];
        ArrayRefc5(v142, REFC_INCR);
        uint64_t v143;
        v143 = v142->len;
        Mut2 * v144;
        v144 = MutCreate2(0ull, v141);
        while (method3(v143, v144)){
            uint64_t v146;
            v146 = v144->v0;
            uint64_t v147;
            v147 = v144->v1;
            uint64_t v148; uint64_t v149; UH0 * v150;
            Tuple0 tmp1 = v142->ptr[v146];
            v148 = tmp1.v0; v149 = tmp1.v1; v150 = tmp1.v2;
            UHRefc0(v150, REFC_INCR);
            AssignArray4(&(v137->ptr[v147]), TupleCreate0(v148, v149, v150));
            UHRefc0(v150, REFC_DECR);
            uint64_t v151;
            v151 = v147 + 1ull;
            uint64_t v152;
            v152 = v146 + 1ull;
            AssignMut2(&(v144->v0), v152, &(v144->v1), v151);
        }
        ArrayRefc5(v142, REFC_DECR);
        uint64_t v153;
        v153 = v144->v1;
        MutRefc2(v144, REFC_DECR);
        uint64_t v154;
        v154 = v140 + 1ull;
        AssignMut2(&(v138->v0), v154, &(v138->v1), v153);
    }
    ArrayRefc6(v5, REFC_DECR);
    uint64_t v155;
    v155 = v138->v1;
    MutRefc2(v138, REFC_DECR);
    US1 v156;
    v156 = v2->v0;
    USRefc1(&(v156), REFC_INCR);
    switch (v156.tag) {
        case 0: { // None
            USRefc1(&(v156), REFC_DECR);
            ArrayRefc3(v0, REFC_SUPPR); ArrayRefc0(v1, REFC_SUPPR); MutRefc1(v2, REFC_SUPPR); ArrayRefc5(v137, REFC_SUPPR);
            return method2(v0, v1, v2, v137);
            break;
        }
        case 1: { // Some
            UH0 * v158 = v156.case1.v0;
            UHRefc0(v158, REFC_INCR);
            ArrayRefc3(v0, REFC_DECR); ArrayRefc0(v1, REFC_DECR); MutRefc1(v2, REFC_DECR); ArrayRefc5(v137, REFC_DECR); USRefc1(&(v156), REFC_DECR);
            UH0 * v159;
            v159 = UH0_1();
            UHRefc0(v158, REFC_SUPPR); UHRefc0(v159, REFC_SUPPR);
            return method4(v158, v159);
            break;
        }
    }
}
UH0 * method1(Array0 * v0, uint64_t v1, uint64_t v2){
    ArrayRefc0(v0, REFC_INCR);
    uint64_t v3;
    v3 = v0->len;
    Array3 * v4;
    v4 = ArrayCreate3(v3, true);
    Mut0 * v5;
    v5 = MutCreate0(0ull);
    while (method0(v3, v5)){
        uint64_t v7;
        v7 = v5->v0;
        Array1 * v8;
        v8 = v0->ptr[v7];
        ArrayRefc1(v8, REFC_INCR);
        uint64_t v9;
        v9 = v8->len;
        ArrayRefc1(v8, REFC_DECR);
        Array4 * v10;
        v10 = ArrayCreate4(v9, false);
        Mut0 * v11;
        v11 = MutCreate0(0ull);
        while (method0(v9, v11)){
            uint64_t v13;
            v13 = v11->v0;
            AssignArray2(&(v10->ptr[v13]), false);
            uint64_t v14;
            v14 = v13 + 1ull;
            AssignMut0(&(v11->v0), v14);
        }
        MutRefc0(v11, REFC_DECR);
        AssignArray3(&(v4->ptr[v7]), v10);
        ArrayRefc4(v10, REFC_DECR);
        uint64_t v15;
        v15 = v7 + 1ull;
        AssignMut0(&(v5->v0), v15);
    }
    MutRefc0(v5, REFC_DECR);
    US1 v16;
    v16 = US1_0();
    Mut1 * v17;
    v17 = MutCreate1(v16);
    USRefc1(&(v16), REFC_DECR);
    Array5 * v18;
    v18 = ArrayCreate5(1ull, true);
    UH0 * v19;
    v19 = UH0_1();
    AssignArray4(&(v18->ptr[0ull]), TupleCreate0(v1, v2, v19));
    UHRefc0(v19, REFC_DECR);
    ArrayRefc0(v0, REFC_SUPPR); ArrayRefc3(v4, REFC_SUPPR); MutRefc1(v17, REFC_SUPPR); ArrayRefc5(v18, REFC_SUPPR);
    return method2(v4, v0, v17, v18);
}
void method5(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            StringRefc(v1, REFC_INCR); UHRefc0(v2, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            printf("%s\n",v1->ptr);
            StringRefc(v1, REFC_DECR);
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
    Mut0 * v4;
    v4 = MutCreate0(0ull);
    while (method0(v0, v4)){
        uint64_t v6;
        v6 = v4->v0;
        Array1 * v7;
        v7 = ArrayCreate1(v0, true);
        Mut0 * v8;
        v8 = MutCreate0(0ull);
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
            AssignArray0(&(v7->ptr[v10]), v16);
            USRefc0(&(v16), REFC_DECR);
            uint64_t v17;
            v17 = v10 + 1ull;
            AssignMut0(&(v8->v0), v17);
        }
        MutRefc0(v8, REFC_DECR);
        AssignArray1(&(v3->ptr[v6]), v7);
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
    ArrayRefc0(v3, REFC_DECR);
    printf("%s\n","Printing");
    method5(v21);
    UHRefc0(v21, REFC_DECR);
    return 0l;
}
