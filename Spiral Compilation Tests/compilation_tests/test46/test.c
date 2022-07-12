#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
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
    int tag;
    union {
        struct {
            UH0 * v0;
        } case0; // Error
        struct {
            uint32_t v0;
        } case1; // Ok
    };
} US0;
typedef struct {
    US0 v0;
    uint32_t v1;
} Tuple0;
typedef struct {
    int tag;
    union {
        struct {
            UH0 * v0;
        } case0; // Error
    };
} US1;
typedef struct {
    US1 v0;
    uint32_t v1;
} Tuple1;
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*refc_fptr)(Fun1 *, REFC_FLAG);
    Tuple1 (*fptr)(Fun1 *, uint32_t);
    void * env;
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*refc_fptr)(Fun0 *, REFC_FLAG);
    Fun1 * (*fptr)(Fun0 *, String *);
    void * env;
};
typedef struct {
    int tag;
    union {
    };
} US3;
typedef struct {
    int tag;
    union {
        struct {
            US3 v0;
        } case1; // Some
    };
} US2;
typedef struct {
    int refc;
    uint32_t len;
    US2 ptr[];
} Array1;
typedef struct {
    int refc;
    uint32_t v0;
} Mut0;
typedef struct {
    uint32_t v0;
    uint32_t v1;
    String * v2;
} ClosureEnv1;
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*refc_fptr)(Closure1 *, REFC_FLAG);
    Tuple1 (*fptr)(Closure1 *, uint32_t);
    ClosureEnv1 * env;
};
typedef struct {
    uint32_t v0;
    uint32_t v1;
} ClosureEnv0;
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*refc_fptr)(Closure0 *, REFC_FLAG);
    Fun1 * (*fptr)(Closure0 *, String *);
    ClosureEnv0 * env;
};
typedef struct {
} ClosureEnv3;
typedef struct Closure3 Closure3;
struct Closure3 {
    int refc;
    void (*refc_fptr)(Closure3 *, REFC_FLAG);
    Tuple1 (*fptr)(Closure3 *, uint32_t);
    ClosureEnv3 * env;
};
typedef struct {
} ClosureEnv2;
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*refc_fptr)(Closure2 *, REFC_FLAG);
    Fun1 * (*fptr)(Closure2 *, String *);
    ClosureEnv2 * env;
};
static inline void ArrayRefcBody0(Array0 * x, REFC_FLAG q){
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
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc0(x, q);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
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
static inline void USRefcBody0(US0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v0, q);
            break;
        }
    }
}
void USRefc0(US0 * x, REFC_FLAG q){
    USRefcBody0(*x, q);
}
US0 US0_0(UH0 * v0) { // Error
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
US0 US0_1(uint32_t v0) { // Ok
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
static inline Tuple0 TupleCreate0(US0 v0, uint32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(String * v0, uint32_t v1, bool v2, uint32_t v3){
    StringRefc(v0, REFC_INCR);
    bool v4;
    v4 = 0ul <= v1;
    bool v7;
    if (v4){
        uint32_t v5;
        v5 = v0->len;
        bool v6;
        v6 = v1 < v5;
        v7 = v6;
    } else {
        v7 = false;
    }
    US0 v49; uint32_t v50;
    if (v7){
        char v8;
        v8 = v0->ptr[v1];
        char v9;
        v9 = System.Char.MaxValue;
        bool v10;
        v10 = v8 == v9;
        bool v11;
        v11 = v10 != true;
        if (v11){
            uint32_t v12;
            v12 = v1 + 1ul;
            uint32_t v13;
            v13 = uint32 v8 - uint32 '0';
            bool v14;
            v14 = 0ul <= v13;
            bool v16;
            if (v14){
                bool v15;
                v15 = v13 <= 9ul;
                v16 = v15;
            } else {
                v16 = false;
            }
            if (v16){
                US0 v17;
                v17 = US0_1(v13);
                USRefc0(&(v17), REFC_INCR);
                v49 = v17; v50 = v12;
            } else {
                UH0 * v18;
                v18 = UH0_1();
                UHRefc0(v18, REFC_INCR);
                UH0 * v19;
                v19 = UH0_0(StringLit(5, "digit"), v18);
                UHRefc0(v19, REFC_INCR);
                UHRefc0(v18, REFC_DECR);
                US0 v20;
                v20 = US0_0(v19);
                USRefc0(&(v20), REFC_INCR);
                UHRefc0(v19, REFC_DECR);
                v49 = v20; v50 = v12;
            }
        } else {
            UH0 * v23;
            v23 = UH0_1();
            UHRefc0(v23, REFC_INCR);
            UH0 * v24;
            v24 = UH0_0(StringLit(14, "Out of bounds."), v23);
            UHRefc0(v24, REFC_INCR);
            UHRefc0(v23, REFC_DECR);
            US0 v25;
            v25 = US0_0(v24);
            USRefc0(&(v25), REFC_INCR);
            UHRefc0(v24, REFC_DECR);
            v49 = v25; v50 = v1;
        }
    } else {
        char v28;
        v28 = System.Char.MaxValue;
        char v29;
        v29 = System.Char.MaxValue;
        bool v30;
        v30 = v28 == v29;
        bool v31;
        v31 = v30 != true;
        if (v31){
            char v32;
            v32 = v0->ptr[v1];
            uint32_t v33;
            v33 = v1 + 1ul;
            uint32_t v34;
            v34 = uint32 v32 - uint32 '0';
            bool v35;
            v35 = 0ul <= v34;
            bool v37;
            if (v35){
                bool v36;
                v36 = v34 <= 9ul;
                v37 = v36;
            } else {
                v37 = false;
            }
            if (v37){
                US0 v38;
                v38 = US0_1(v34);
                USRefc0(&(v38), REFC_INCR);
                v49 = v38; v50 = v33;
            } else {
                UH0 * v39;
                v39 = UH0_1();
                UHRefc0(v39, REFC_INCR);
                UH0 * v40;
                v40 = UH0_0(StringLit(5, "digit"), v39);
                UHRefc0(v40, REFC_INCR);
                UHRefc0(v39, REFC_DECR);
                US0 v41;
                v41 = US0_0(v40);
                USRefc0(&(v41), REFC_INCR);
                UHRefc0(v40, REFC_DECR);
                v49 = v41; v50 = v33;
            }
        } else {
            UH0 * v44;
            v44 = UH0_1();
            UHRefc0(v44, REFC_INCR);
            UH0 * v45;
            v45 = UH0_0(StringLit(14, "Out of bounds."), v44);
            UHRefc0(v45, REFC_INCR);
            UHRefc0(v44, REFC_DECR);
            US0 v46;
            v46 = US0_0(v45);
            USRefc0(&(v46), REFC_INCR);
            UHRefc0(v45, REFC_DECR);
            v49 = v46; v50 = v1;
        }
    }
    USRefc0(&(v49), REFC_INCR);
    switch (v49.tag) {
        case 0: { // Error
            UH0 * v51 = v49.case0.v0;
            StringRefc(v0, REFC_DECR); USRefc0(&(v49), REFC_DECR);
            if (v2){
                StringRefc(v0, REFC_DECR); USRefc0(&(v49), REFC_DECR);
                US0 v52;
                v52 = US0_1(v3);
                USRefc0(&(v52), REFC_INCR);
                USRefc0(&(v52), REFC_SUPPR);
                return TupleCreate0(v52, v50);
            } else {
                StringRefc(v0, REFC_DECR); USRefc0(&(v49), REFC_DECR);
                UH0 * v53;
                v53 = UH0_1();
                UHRefc0(v53, REFC_INCR);
                UH0 * v54;
                v54 = UH0_0(StringLit(3, "i32"), v53);
                UHRefc0(v54, REFC_INCR);
                UHRefc0(v53, REFC_DECR);
                US0 v55;
                v55 = US0_0(v54);
                USRefc0(&(v55), REFC_INCR);
                UHRefc0(v54, REFC_DECR);
                USRefc0(&(v55), REFC_SUPPR);
                return TupleCreate0(v55, v50);
            }
            break;
        }
        case 1: { // Ok
            uint32_t v58 = v49.case1.v0;
            USRefc0(&(v49), REFC_DECR);
            uint32_t v59;
            v59 = v3 * 10ul;
            uint32_t v60;
            v60 = v59 + v58;
            bool v61;
            v61 = v3 <= 214748364ul;
            bool v63;
            if (v61){
                bool v62;
                v62 = 0ul <= v60;
                v63 = v62;
            } else {
                v63 = false;
            }
            if (v63){
                bool v64;
                v64 = true;
                StringRefc(v0, REFC_SUPPR);
                return method0(v0, v50, v64, v60);
            } else {
                StringRefc(v0, REFC_DECR);
                UH0 * v67;
                v67 = UH0_1();
                UHRefc0(v67, REFC_INCR);
                UH0 * v68;
                v68 = UH0_0(StringLit(51, "The number is too large to be parsed as 32 bit int."), v67);
                UHRefc0(v68, REFC_INCR);
                UHRefc0(v67, REFC_DECR);
                US0 v69;
                v69 = US0_0(v68);
                USRefc0(&(v69), REFC_INCR);
                UHRefc0(v68, REFC_DECR);
                USRefc0(&(v69), REFC_SUPPR);
                return TupleCreate0(v69, v50);
            }
            break;
        }
    }
}
static inline void USRefcBody1(US1 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v0, q);
            break;
        }
    }
}
void USRefc1(US1 * x, REFC_FLAG q){
    USRefcBody1(*x, q);
}
US1 US1_0(UH0 * v0) { // Error
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0;
    USRefcBody1(x, REFC_INCR);
    return x;
}
US1 US1_1() { // Ok
    US1 x;
    x.tag = 1;
    USRefcBody1(x, REFC_INCR);
    return x;
}
static inline Tuple1 TupleCreate1(US1 v0, uint32_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple1 method1(String * v0, uint32_t v1){
    StringRefc(v0, REFC_INCR);
    bool v2;
    v2 = 0ul <= v1;
    bool v10;
    if (v2){
        uint32_t v3;
        v3 = v0->len;
        bool v4;
        v4 = v1 < v3;
        if (v4){
            char v5;
            v5 = v0->ptr[v1];
            bool v6;
            v6 = v5 == ' ';
            if (v6){
                v10 = true;
            } else {
                bool v7;
                v7 = v5 == '\n';
                v10 = v7;
            }
        } else {
            v10 = false;
        }
    } else {
        v10 = false;
    }
    if (v10){
        uint32_t v11;
        v11 = v1 + 1ul;
        StringRefc(v0, REFC_SUPPR);
        return method1(v0, v11);
    } else {
        StringRefc(v0, REFC_DECR);
        US1 v14;
        v14 = US1_1();
        USRefc1(&(v14), REFC_INCR);
        USRefc1(&(v14), REFC_SUPPR);
        return TupleCreate1(v14, v1);
    }
}
static inline void USRefcBody3(US3 x, REFC_FLAG q){
    switch (x.tag) {
    }
}
void USRefc3(US3 * x, REFC_FLAG q){
    USRefcBody3(*x, q);
}
US3 US3_0() { // First
    US3 x;
    x.tag = 0;
    USRefcBody3(x, REFC_INCR);
    return x;
}
US3 US3_1() { // Second
    US3 x;
    x.tag = 1;
    USRefcBody3(x, REFC_INCR);
    return x;
}
static inline void USRefcBody2(US2 x, REFC_FLAG q){
    switch (x.tag) {
        case 1: {
            USRefc3(&(x.case1.v0), q);
            break;
        }
    }
}
void USRefc2(US2 * x, REFC_FLAG q){
    USRefcBody2(*x, q);
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    USRefcBody2(x, REFC_INCR);
    return x;
}
US2 US2_1(US3 v0) { // Some
    US2 x;
    x.tag = 1;
    x.case1.v0 = v0;
    USRefcBody2(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody1(Array1 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        US2 v = x->ptr[i];
        USRefc2(&(v), q);
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
    uint32_t size = sizeof(Array1) + sizeof(US2) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, US2 * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(US2) * len);
    ArrayRefcBody1(x, REFC_INCR);
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
Mut0 * MutCreate0(uint32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 0;
        x->v0 = v0;
    MutRefcBody0(x, REFC_INCR);
    return x;
}
bool method3(Mut0 * v0){
    MutRefc0(v0, REFC_INCR);
    uint32_t v1;
    v1 = v0->v0;
    MutRefc0(v0, REFC_DECR);
    bool v2;
    v2 = v1 < 101ul;
    return v2;
}
static inline void AssignArray0(US2 * a, US2 b){
    USRefc2(&(b), REFC_INCR);
    USRefc2(&(*a), REFC_DECR);
    *a = b;
}
static inline void AssignMut0(uint32_t * a0, uint32_t b0){
    *a0 = b0;
}
US3 method4(Array1 * v0, US3 v1, US3 v2, uint32_t v3){
    ArrayRefc1(v0, REFC_INCR); USRefc3(&(v1), REFC_INCR); USRefc3(&(v2), REFC_INCR);
    switch (v1.tag) {
        case 0: { // First
            US2 v4;
            v4 = v0->ptr[v3];
            USRefc2(&(v4), REFC_INCR);
            switch (v4.tag) {
                case 0: { // None
                    USRefc2(&(v4), REFC_DECR);
                    bool v5;
                    v5 = v3 >= 2ul;
                    bool v9;
                    if (v5){
                        uint32_t v6;
                        v6 = v3 - 2ul;
                        US3 v7;
                        v7 = method4(v0, v2, v1, v6);
                        USRefc3(&(v7), REFC_INCR);
                        switch (v7.tag) {
                            case 0: { // First
                                USRefc3(&(v7), REFC_DECR);
                                v9 = true;
                                break;
                            }
                            case 1: { // Second
                                USRefc3(&(v7), REFC_DECR);
                                v9 = false;
                                break;
                            }
                        }
                    } else {
                        v9 = false;
                    }
                    US3 v22;
                    if (v9){
                        v22 = v1;
                    } else {
                        bool v10;
                        v10 = v3 >= 3ul;
                        bool v14;
                        if (v10){
                            uint32_t v11;
                            v11 = v3 - 3ul;
                            US3 v12;
                            v12 = method4(v0, v2, v1, v11);
                            USRefc3(&(v12), REFC_INCR);
                            switch (v12.tag) {
                                case 0: { // First
                                    USRefc3(&(v12), REFC_DECR);
                                    v14 = true;
                                    break;
                                }
                                case 1: { // Second
                                    USRefc3(&(v12), REFC_DECR);
                                    v14 = false;
                                    break;
                                }
                            }
                        } else {
                            v14 = false;
                        }
                        if (v14){
                            v22 = v1;
                        } else {
                            bool v15;
                            v15 = v3 >= 5ul;
                            bool v19;
                            if (v15){
                                uint32_t v16;
                                v16 = v3 - 5ul;
                                US3 v17;
                                v17 = method4(v0, v2, v1, v16);
                                USRefc3(&(v17), REFC_INCR);
                                switch (v17.tag) {
                                    case 0: { // First
                                        USRefc3(&(v17), REFC_DECR);
                                        v19 = true;
                                        break;
                                    }
                                    case 1: { // Second
                                        USRefc3(&(v17), REFC_DECR);
                                        v19 = false;
                                        break;
                                    }
                                }
                            } else {
                                v19 = false;
                            }
                            if (v19){
                                v22 = v1;
                            } else {
                                v22 = v2;
                            }
                        }
                    }
                    USRefc3(&(v22), REFC_INCR);
                    USRefc3(&(v1), REFC_DECR); USRefc3(&(v2), REFC_DECR);
                    US2 v23;
                    v23 = US2_1(v22);
                    USRefc2(&(v23), REFC_INCR);
                    AssignArray0(&(v0->ptr[v3]), v23);
                    ArrayRefc1(v0, REFC_DECR); USRefc2(&(v23), REFC_DECR);
                    USRefc3(&(v22), REFC_SUPPR);
                    return v22;
                    break;
                }
                case 1: { // Some
                    US3 v24 = v4.case1.v0;
                    ArrayRefc1(v0, REFC_DECR); USRefc3(&(v1), REFC_DECR); USRefc3(&(v2), REFC_DECR); USRefc2(&(v4), REFC_DECR);
                    USRefc3(&(v24), REFC_SUPPR);
                    return v24;
                    break;
                }
            }
            break;
        }
        case 1: { // Second
            bool v26;
            v26 = v3 >= 2ul;
            bool v30;
            if (v26){
                uint32_t v27;
                v27 = v3 - 2ul;
                US3 v28;
                v28 = method4(v0, v2, v1, v27);
                USRefc3(&(v28), REFC_INCR);
                switch (v28.tag) {
                    case 0: { // First
                        USRefc3(&(v28), REFC_DECR);
                        v30 = false;
                        break;
                    }
                    case 1: { // Second
                        USRefc3(&(v28), REFC_DECR);
                        v30 = true;
                        break;
                    }
                }
            } else {
                v30 = false;
            }
            if (v30){
                ArrayRefc1(v0, REFC_DECR); USRefc3(&(v2), REFC_DECR);
                USRefc3(&(v1), REFC_SUPPR);
                return v1;
            } else {
                bool v31;
                v31 = v3 >= 3ul;
                bool v35;
                if (v31){
                    uint32_t v32;
                    v32 = v3 - 3ul;
                    US3 v33;
                    v33 = method4(v0, v2, v1, v32);
                    USRefc3(&(v33), REFC_INCR);
                    switch (v33.tag) {
                        case 0: { // First
                            USRefc3(&(v33), REFC_DECR);
                            v35 = false;
                            break;
                        }
                        case 1: { // Second
                            USRefc3(&(v33), REFC_DECR);
                            v35 = true;
                            break;
                        }
                    }
                } else {
                    v35 = false;
                }
                if (v35){
                    ArrayRefc1(v0, REFC_DECR); USRefc3(&(v2), REFC_DECR);
                    USRefc3(&(v1), REFC_SUPPR);
                    return v1;
                } else {
                    bool v36;
                    v36 = v3 >= 5ul;
                    bool v40;
                    if (v36){
                        uint32_t v37;
                        v37 = v3 - 5ul;
                        US3 v38;
                        v38 = method4(v0, v2, v1, v37);
                        USRefc3(&(v38), REFC_INCR);
                        switch (v38.tag) {
                            case 0: { // First
                                USRefc3(&(v38), REFC_DECR);
                                v40 = false;
                                break;
                            }
                            case 1: { // Second
                                USRefc3(&(v38), REFC_DECR);
                                v40 = true;
                                break;
                            }
                        }
                    } else {
                        v40 = false;
                    }
                    ArrayRefc1(v0, REFC_DECR);
                    if (v40){
                        ArrayRefc1(v0, REFC_DECR); USRefc3(&(v2), REFC_DECR);
                        USRefc3(&(v1), REFC_SUPPR);
                        return v1;
                    } else {
                        ArrayRefc1(v0, REFC_DECR); USRefc3(&(v1), REFC_DECR);
                        USRefc3(&(v2), REFC_SUPPR);
                        return v2;
                    }
                }
            }
            break;
        }
    }
}
static inline void ClosureRefcBody1(Closure1 * x, REFC_FLAG q){
    ClosureEnv1 env = x->env[0];
    StringRefc(env.v2, q);
}
void ClosureRefc1(Closure1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ClosureRefcBody1(x, REFC_DECR);
            free(x);
        }
    }
}
Tuple1 ClosureMethod1(Closure1 * x, uint32_t v3){
    ClosureEnv1 * env = x->env;
    uint32_t v0 = env->v0; uint32_t v1 = env->v1; String * v2 = env->v2;
    bool v4;
    v4 = false;
    uint32_t v5;
    v5 = 0ul;
    US0 v6; uint32_t v7;
    Tuple0 tmp2 = method0(v2, v3, v4, v5);
    v6 = tmp2.v0; v7 = tmp2.v1;
    USRefc0(&(v6), REFC_INCR);
    US0 v18; uint32_t v19;
    switch (v6.tag) {
        case 0: { // Error
            UH0 * v8 = v6.case0.v0;
            US0 v9;
            v9 = US0_0(v8);
            USRefc0(&(v9), REFC_INCR);
            v18 = v9; v19 = v7;
            break;
        }
        case 1: { // Ok
            uint32_t v10 = v6.case1.v0;
            US1 v11; uint32_t v12;
            Tuple1 tmp3 = method1(v2, v7);
            v11 = tmp3.v0; v12 = tmp3.v1;
            USRefc1(&(v11), REFC_INCR);
            switch (v11.tag) {
                case 0: { // Error
                    UH0 * v13 = v11.case0.v0;
                    USRefc1(&(v11), REFC_DECR);
                    US0 v14;
                    v14 = US0_0(v13);
                    USRefc0(&(v14), REFC_INCR);
                    v18 = v14; v19 = v12;
                    break;
                }
                case 1: { // Ok
                    USRefc1(&(v11), REFC_DECR);
                    US0 v15;
                    v15 = US0_1(v10);
                    USRefc0(&(v15), REFC_INCR);
                    v18 = v15; v19 = v12;
                    break;
                }
            }
            break;
        }
    }
    USRefc0(&(v18), REFC_INCR);
    USRefc0(&(v6), REFC_DECR);
    switch (v18.tag) {
        case 0: { // Error
            UH0 * v20 = v18.case0.v0;
            USRefc0(&(v6), REFC_DECR); USRefc0(&(v18), REFC_DECR);
            US1 v21;
            v21 = US1_0(v20);
            USRefc1(&(v21), REFC_INCR);
            USRefc1(&(v21), REFC_SUPPR);
            return TupleCreate1(v21, v19);
            break;
        }
        case 1: { // Ok
            uint32_t v22 = v18.case1.v0;
            USRefc0(&(v6), REFC_DECR); USRefc0(&(v18), REFC_DECR);
            bool v23;
            v23 = 100ul < v22;
            if (v23){
                fprintf(stderr, "%s\n", "The max input has been exceeded.")
                exit(EXIT_FAILURE);
            } else {
            }
            Array1 * v24;
            v24 = ArrayCreate1(101ul, false);
            ArrayRefc1(v24, REFC_INCR);
            Mut0 * v25;
            v25 = MutCreate0(0ul);
            MutRefc0(v25, REFC_INCR);
            while (method3(v25)){
                uint32_t v27;
                v27 = v25->v0;
                US2 v28;
                v28 = US2_0();
                USRefc2(&(v28), REFC_INCR);
                AssignArray0(&(v24->ptr[v27]), v28);
                USRefc2(&(v28), REFC_DECR);
                uint32_t v29;
                v29 = v27 + 1ul;
                AssignMut0(&(v25->v0), v29);
            }
            MutRefc0(v25, REFC_DECR);
            US3 v30;
            v30 = US3_0();
            USRefc3(&(v30), REFC_INCR);
            US3 v31;
            v31 = US3_1();
            USRefc3(&(v31), REFC_INCR);
            US3 v32;
            v32 = method4(v24, v30, v31, v22);
            USRefc3(&(v32), REFC_INCR);
            ArrayRefc1(v24, REFC_DECR); USRefc3(&(v30), REFC_DECR); USRefc3(&(v31), REFC_DECR);
            String * v33;
            switch (v32.tag) {
                case 0: { // First
                    v33 = StringLit(5, "First");
                    break;
                }
                case 1: { // Second
                    v33 = StringLit(6, "Second");
                    break;
                }
            }
            StringRefc(v33, REFC_INCR);
            USRefc3(&(v32), REFC_DECR);
            System.Console.WriteLine(v33);
            StringRefc(v33, REFC_DECR);
            uint32_t v34;
            v34 = v1 + 1ul;
            Fun0 * v35;
            v35 = method2(v0, v34);
            v35->refc_fptr(v35, REFC_INCR);
            Fun1 * v36;
            v36 = v35->fptr(v35, v2);
            v36->refc_fptr(v36, REFC_INCR);
            v35->refc_fptr(v35, REFC_DECR);
            US1 v37; uint32_t v38;
            Tuple1 tmp4 = v36->fptr(v36, v19);
            v37 = tmp4.v0; v38 = tmp4.v1;
            USRefc1(&(v37), REFC_INCR);
            v36->refc_fptr(v36, REFC_DECR);
            USRefc1(&(v37), REFC_SUPPR);
            return TupleCreate1(v37, v38);
            break;
        }
    }
}
Fun1 * ClosureCreate1(uint32_t v0, uint32_t v1, String * v2){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 0;
    x->refc_fptr = ClosureRefc1;
    x->fptr = ClosureMethod1;
    ClosureEnv1 * env = malloc(sizeof(ClosureEnv1));
    env->v0 = v0; env->v1 = v1; env->v2 = v2;
    x->env = env;
    ClosureRefcBody1(x, REFC_INCR);
    return (Fun1 *) x;
}
static inline void ClosureRefcBody0(Closure0 * x, REFC_FLAG q){
}
void ClosureRefc0(Closure0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ClosureRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Fun1 * ClosureMethod0(Closure0 * x, String * v2){
    ClosureEnv0 * env = x->env;
    uint32_t v0 = env->v0; uint32_t v1 = env->v1;
    StringRefc(v2, REFC_INCR);
    StringRefc(v2, REFC_SUPPR);
    return ClosureCreate1(v0, v1, v2);
}
Fun0 * ClosureCreate0(uint32_t v0, uint32_t v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 0;
    x->refc_fptr = ClosureRefc0;
    x->fptr = ClosureMethod0;
    ClosureEnv0 * env = malloc(sizeof(ClosureEnv0));
    env->v0 = v0; env->v1 = v1;
    x->env = env;
    ClosureRefcBody0(x, REFC_INCR);
    return (Fun0 *) x;
}
static inline void ClosureRefcBody3(Closure3 * x, REFC_FLAG q){
}
void ClosureRefc3(Closure3 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ClosureRefcBody3(x, REFC_DECR);
            free(x);
        }
    }
}
Tuple1 ClosureMethod3(Closure3 * x, uint32_t v0){
    US1 v1;
    v1 = US1_1();
    USRefc1(&(v1), REFC_INCR);
    USRefc1(&(v1), REFC_SUPPR);
    return TupleCreate1(v1, v0);
}
Fun1 * ClosureCreate3(){
    Closure3 * x = malloc(sizeof(Closure3));
    x->refc = 0;
    x->refc_fptr = ClosureRefc3;
    x->fptr = ClosureMethod3;
    return (Fun1 *) x;
}
static inline void ClosureRefcBody2(Closure2 * x, REFC_FLAG q){
}
void ClosureRefc2(Closure2 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ClosureRefcBody2(x, REFC_DECR);
            free(x);
        }
    }
}
Fun1 * ClosureMethod2(Closure2 * x, String * v0){
    StringRefc(v0, REFC_INCR);
    StringRefc(v0, REFC_DECR);
    return ClosureCreate3();
}
Fun0 * ClosureCreate2(){
    Closure2 * x = malloc(sizeof(Closure2));
    x->refc = 0;
    x->refc_fptr = ClosureRefc2;
    x->fptr = ClosureMethod2;
    return (Fun0 *) x;
}
Fun0 * method2(uint32_t v0, uint32_t v1){
    bool v2;
    v2 = v1 < v0;
    if (v2){
        Fun0 * v3;
        v3 = ClosureCreate0(v0, v1);
        v3->refc_fptr(v3, REFC_INCR);
        v3->refc_fptr(v3, REFC_SUPPR);
        return v3;
    } else {
        Fun0 * v4;
        v4 = ClosureCreate2();
        v4->refc_fptr(v4, REFC_INCR);
        v4->refc_fptr(v4, REFC_SUPPR);
        return v4;
    }
}
void method5(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            UHRefc0(v0, REFC_DECR);
            printfn "%s" v1;
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
    String * v0;
    v0 = StringLit(18, "8 1 2 3 4 5 6 7 10");
    StringRefc(v0, REFC_INCR);
    uint32_t v1;
    v1 = 0ul;
    bool v2;
    v2 = false;
    uint32_t v3;
    v3 = 0ul;
    US0 v4; uint32_t v5;
    Tuple0 tmp0 = method0(v0, v1, v2, v3);
    v4 = tmp0.v0; v5 = tmp0.v1;
    USRefc0(&(v4), REFC_INCR);
    US0 v16; uint32_t v17;
    switch (v4.tag) {
        case 0: { // Error
            UH0 * v6 = v4.case0.v0;
            US0 v7;
            v7 = US0_0(v6);
            USRefc0(&(v7), REFC_INCR);
            v16 = v7; v17 = v5;
            break;
        }
        case 1: { // Ok
            uint32_t v8 = v4.case1.v0;
            US1 v9; uint32_t v10;
            Tuple1 tmp1 = method1(v0, v5);
            v9 = tmp1.v0; v10 = tmp1.v1;
            USRefc1(&(v9), REFC_INCR);
            switch (v9.tag) {
                case 0: { // Error
                    UH0 * v11 = v9.case0.v0;
                    USRefc1(&(v9), REFC_DECR);
                    US0 v12;
                    v12 = US0_0(v11);
                    USRefc0(&(v12), REFC_INCR);
                    v16 = v12; v17 = v10;
                    break;
                }
                case 1: { // Ok
                    USRefc1(&(v9), REFC_DECR);
                    US0 v13;
                    v13 = US0_1(v8);
                    USRefc0(&(v13), REFC_INCR);
                    v16 = v13; v17 = v10;
                    break;
                }
            }
            break;
        }
    }
    USRefc0(&(v16), REFC_INCR);
    USRefc0(&(v4), REFC_DECR);
    US1 v26; uint32_t v27;
    switch (v16.tag) {
        case 0: { // Error
            UH0 * v18 = v16.case0.v0;
            US1 v19;
            v19 = US1_0(v18);
            USRefc1(&(v19), REFC_INCR);
            v26 = v19; v27 = v17;
            break;
        }
        case 1: { // Ok
            uint32_t v20 = v16.case1.v0;
            uint32_t v21;
            v21 = 0ul;
            Fun0 * v22;
            v22 = method2(v20, v21);
            v22->refc_fptr(v22, REFC_INCR);
            Fun1 * v23;
            v23 = v22->fptr(v22, v0);
            v23->refc_fptr(v23, REFC_INCR);
            v22->refc_fptr(v22, REFC_DECR);
            US1 v24; uint32_t v25;
            Tuple1 tmp5 = v23->fptr(v23, v17);
            v24 = tmp5.v0; v25 = tmp5.v1;
            USRefc1(&(v24), REFC_INCR);
            v23->refc_fptr(v23, REFC_DECR);
            v26 = v24; v27 = v25;
            break;
        }
    }
    USRefc1(&(v26), REFC_INCR);
    StringRefc(v0, REFC_DECR); USRefc0(&(v16), REFC_DECR);
    switch (v26.tag) {
        case 0: { // Error
            UH0 * v28 = v26.case0.v0;
            printfn "Parsing failed at position %i" v27;
            printfn "Errors:";
            method5(v28);
            break;
        }
        case 1: { // Ok
            break;
        }
    }
    USRefc1(&(v26), REFC_DECR);
    return 0l;
}
