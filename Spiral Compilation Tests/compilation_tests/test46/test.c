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
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*refc_fptr)(Fun0 *, REFC_FLAG);
    Fun1 * (*fptr)(Fun0 *, String *);
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
    ClosureEnv1 env[];
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
    ClosureEnv0 env[];
};
typedef struct {
} ClosureEnv3;
typedef struct Closure3 Closure3;
struct Closure3 {
    int refc;
    void (*refc_fptr)(Closure3 *, REFC_FLAG);
    Tuple1 (*fptr)(Closure3 *, uint32_t);
    ClosureEnv3 env[];
};
typedef struct {
} ClosureEnv2;
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*refc_fptr)(Closure2 *, REFC_FLAG);
    Fun1 * (*fptr)(Closure2 *, String *);
    ClosureEnv2 env[];
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
    x->refc = 1;
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
    US0 v53; uint32_t v54;
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
                v53 = v17; v54 = v12;
            } else {
                String * v18;
                v18 = StringLit(6, "digit");
                UH0 * v19;
                v19 = UH0_1();
                UH0 * v20;
                v20 = UH0_0(v18, v19);
                StringRefc(v18, REFC_DECR); UHRefc0(v19, REFC_DECR);
                US0 v21;
                v21 = US0_0(v20);
                UHRefc0(v20, REFC_DECR);
                v53 = v21; v54 = v12;
            }
        } else {
            String * v24;
            v24 = StringLit(15, "Out of bounds.");
            UH0 * v25;
            v25 = UH0_1();
            UH0 * v26;
            v26 = UH0_0(v24, v25);
            StringRefc(v24, REFC_DECR); UHRefc0(v25, REFC_DECR);
            US0 v27;
            v27 = US0_0(v26);
            UHRefc0(v26, REFC_DECR);
            v53 = v27; v54 = v1;
        }
    } else {
        char v30;
        v30 = System.Char.MaxValue;
        char v31;
        v31 = System.Char.MaxValue;
        bool v32;
        v32 = v30 == v31;
        bool v33;
        v33 = v32 != true;
        if (v33){
            char v34;
            v34 = v0->ptr[v1];
            uint32_t v35;
            v35 = v1 + 1ul;
            uint32_t v36;
            v36 = uint32 v34 - uint32 '0';
            bool v37;
            v37 = 0ul <= v36;
            bool v39;
            if (v37){
                bool v38;
                v38 = v36 <= 9ul;
                v39 = v38;
            } else {
                v39 = false;
            }
            if (v39){
                US0 v40;
                v40 = US0_1(v36);
                v53 = v40; v54 = v35;
            } else {
                String * v41;
                v41 = StringLit(6, "digit");
                UH0 * v42;
                v42 = UH0_1();
                UH0 * v43;
                v43 = UH0_0(v41, v42);
                StringRefc(v41, REFC_DECR); UHRefc0(v42, REFC_DECR);
                US0 v44;
                v44 = US0_0(v43);
                UHRefc0(v43, REFC_DECR);
                v53 = v44; v54 = v35;
            }
        } else {
            String * v47;
            v47 = StringLit(15, "Out of bounds.");
            UH0 * v48;
            v48 = UH0_1();
            UH0 * v49;
            v49 = UH0_0(v47, v48);
            StringRefc(v47, REFC_DECR); UHRefc0(v48, REFC_DECR);
            US0 v50;
            v50 = US0_0(v49);
            UHRefc0(v49, REFC_DECR);
            v53 = v50; v54 = v1;
        }
    }
    switch (v53.tag) {
        case 0: { // Error
            UH0 * v55 = v53.case0.v0;
            USRefc0(&(v53), REFC_DECR);
            StringRefc(v0, REFC_SUPPR);
            if (v2){
                US0 v56;
                v56 = US0_1(v3);
                return TupleCreate0(v56, v54);
            } else {
                String * v57;
                v57 = StringLit(4, "i32");
                UH0 * v58;
                v58 = UH0_1();
                UH0 * v59;
                v59 = UH0_0(v57, v58);
                StringRefc(v57, REFC_DECR); UHRefc0(v58, REFC_DECR);
                US0 v60;
                v60 = US0_0(v59);
                UHRefc0(v59, REFC_DECR);
                return TupleCreate0(v60, v54);
            }
            break;
        }
        case 1: { // Ok
            uint32_t v63 = v53.case1.v0;
            USRefc0(&(v53), REFC_DECR);
            uint32_t v64;
            v64 = v3 * 10ul;
            uint32_t v65;
            v65 = v64 + v63;
            bool v66;
            v66 = v3 <= 214748364ul;
            bool v68;
            if (v66){
                bool v67;
                v67 = 0ul <= v65;
                v68 = v67;
            } else {
                v68 = false;
            }
            if (v68){
                bool v69;
                v69 = true;
                StringRefc(v0, REFC_SUPPR);
                return method0(v0, v54, v69, v65);
            } else {
                StringRefc(v0, REFC_SUPPR);
                String * v72;
                v72 = StringLit(52, "The number is too large to be parsed as 32 bit int.");
                UH0 * v73;
                v73 = UH0_1();
                UH0 * v74;
                v74 = UH0_0(v72, v73);
                StringRefc(v72, REFC_DECR); UHRefc0(v73, REFC_DECR);
                US0 v75;
                v75 = US0_0(v74);
                UHRefc0(v74, REFC_DECR);
                return TupleCreate0(v75, v54);
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
        StringRefc(v0, REFC_SUPPR);
        US1 v14;
        v14 = US1_1();
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
    x->refc = 1;
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
    x->refc = 1;
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
                    USRefc3(&(v1), REFC_DECR); USRefc3(&(v2), REFC_DECR);
                    US2 v23;
                    v23 = US2_1(v22);
                    AssignArray0(&(v0->ptr[v3]), v23);
                    ArrayRefc1(v0, REFC_DECR); USRefc2(&(v23), REFC_DECR);
                    return v22;
                    break;
                }
                case 1: { // Some
                    US3 v24 = v4.case1.v0;
                    USRefc3(&(v24), REFC_INCR);
                    ArrayRefc1(v0, REFC_DECR); USRefc3(&(v1), REFC_DECR); USRefc3(&(v2), REFC_DECR); USRefc2(&(v4), REFC_DECR);
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
                        USRefc3(&(v2), REFC_DECR);
                        return v1;
                    } else {
                        USRefc3(&(v1), REFC_DECR);
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
    US0 v18; uint32_t v19;
    switch (v6.tag) {
        case 0: { // Error
            UH0 * v8 = v6.case0.v0;
            UHRefc0(v8, REFC_INCR);
            US0 v9;
            v9 = US0_0(v8);
            UHRefc0(v8, REFC_DECR);
            v18 = v9; v19 = v7;
            break;
        }
        case 1: { // Ok
            uint32_t v10 = v6.case1.v0;
            US1 v11; uint32_t v12;
            Tuple1 tmp3 = method1(v2, v7);
            v11 = tmp3.v0; v12 = tmp3.v1;
            switch (v11.tag) {
                case 0: { // Error
                    UH0 * v13 = v11.case0.v0;
                    UHRefc0(v13, REFC_INCR);
                    USRefc1(&(v11), REFC_DECR);
                    US0 v14;
                    v14 = US0_0(v13);
                    UHRefc0(v13, REFC_DECR);
                    v18 = v14; v19 = v12;
                    break;
                }
                case 1: { // Ok
                    USRefc1(&(v11), REFC_DECR);
                    US0 v15;
                    v15 = US0_1(v10);
                    v18 = v15; v19 = v12;
                    break;
                }
            }
            break;
        }
    }
    USRefc0(&(v6), REFC_DECR);
    switch (v18.tag) {
        case 0: { // Error
            UH0 * v20 = v18.case0.v0;
            UHRefc0(v20, REFC_INCR);
            USRefc0(&(v18), REFC_DECR);
            US1 v21;
            v21 = US1_0(v20);
            UHRefc0(v20, REFC_DECR);
            return TupleCreate1(v21, v19);
            break;
        }
        case 1: { // Ok
            uint32_t v22 = v18.case1.v0;
            USRefc0(&(v18), REFC_DECR);
            bool v23;
            v23 = 100ul < v22;
            if (v23){
                fprintf(stderr, "%s\n", "The max input has been exceeded.")
                exit(EXIT_FAILURE);
            } else {
            }
            Array1 * v24;
            v24 = ArrayCreate1(101ul, true);
            Mut0 * v25;
            v25 = MutCreate0(0ul);
            while (method3(v25)){
                uint32_t v27;
                v27 = v25->v0;
                US2 v28;
                v28 = US2_0();
                AssignArray0(&(v24->ptr[v27]), v28);
                USRefc2(&(v28), REFC_DECR);
                uint32_t v29;
                v29 = v27 + 1ul;
                AssignMut0(&(v25->v0), v29);
            }
            MutRefc0(v25, REFC_DECR);
            US3 v30;
            v30 = US3_0();
            US3 v31;
            v31 = US3_1();
            US3 v32;
            v32 = method4(v24, v30, v31, v22);
            ArrayRefc1(v24, REFC_DECR); USRefc3(&(v30), REFC_DECR); USRefc3(&(v31), REFC_DECR);
            String * v35;
            switch (v32.tag) {
                case 0: { // First
                    String * v33;
                    v33 = StringLit(6, "First");
                    v35 = v33;
                    break;
                }
                case 1: { // Second
                    String * v34;
                    v34 = StringLit(7, "Second");
                    v35 = v34;
                    break;
                }
            }
            USRefc3(&(v32), REFC_DECR);
            System.Console.WriteLine(v35);
            StringRefc(v35, REFC_DECR);
            uint32_t v36;
            v36 = v1 + 1ul;
            Fun0 * v37;
            v37 = method2(v0, v36);
            Fun1 * v38;
            v38 = v37->fptr(v37, v2);
            v37->refc_fptr(v37, REFC_DECR);
            US1 v39; uint32_t v40;
            Tuple1 tmp4 = v38->fptr(v38, v19);
            v39 = tmp4.v0; v40 = tmp4.v1;
            v38->refc_fptr(v38, REFC_DECR);
            return TupleCreate1(v39, v40);
            break;
        }
    }
}
Fun1 * ClosureCreate1(uint32_t v0, uint32_t v1, String * v2){
    Closure1 * x = malloc(sizeof(Closure1) + sizeof(ClosureEnv1));
    x->refc = 1;
    x->refc_fptr = ClosureRefc1;
    x->fptr = ClosureMethod1;
    ClosureEnv1 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2;
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
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    x->refc = 1;
    x->refc_fptr = ClosureRefc0;
    x->fptr = ClosureMethod0;
    ClosureEnv0 * env = x->env;
    env->v0 = v0; env->v1 = v1;
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
    return TupleCreate1(v1, v0);
}
Fun1 * ClosureCreate3(){
    Closure3 * x = malloc(sizeof(Closure3) + sizeof(ClosureEnv3));
    x->refc = 1;
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
    Closure2 * x = malloc(sizeof(Closure2) + sizeof(ClosureEnv2));
    x->refc = 1;
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
        return v3;
    } else {
        Fun0 * v4;
        v4 = ClosureCreate2();
        return v4;
    }
}
void method5(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            StringRefc(v1, REFC_INCR); UHRefc0(v2, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            printfn "%s" v1;
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
    String * v0;
    v0 = StringLit(19, "8 1 2 3 4 5 6 7 10");
    uint32_t v1;
    v1 = 0ul;
    bool v2;
    v2 = false;
    uint32_t v3;
    v3 = 0ul;
    US0 v4; uint32_t v5;
    Tuple0 tmp0 = method0(v0, v1, v2, v3);
    v4 = tmp0.v0; v5 = tmp0.v1;
    US0 v16; uint32_t v17;
    switch (v4.tag) {
        case 0: { // Error
            UH0 * v6 = v4.case0.v0;
            UHRefc0(v6, REFC_INCR);
            US0 v7;
            v7 = US0_0(v6);
            UHRefc0(v6, REFC_DECR);
            v16 = v7; v17 = v5;
            break;
        }
        case 1: { // Ok
            uint32_t v8 = v4.case1.v0;
            US1 v9; uint32_t v10;
            Tuple1 tmp1 = method1(v0, v5);
            v9 = tmp1.v0; v10 = tmp1.v1;
            switch (v9.tag) {
                case 0: { // Error
                    UH0 * v11 = v9.case0.v0;
                    UHRefc0(v11, REFC_INCR);
                    USRefc1(&(v9), REFC_DECR);
                    US0 v12;
                    v12 = US0_0(v11);
                    UHRefc0(v11, REFC_DECR);
                    v16 = v12; v17 = v10;
                    break;
                }
                case 1: { // Ok
                    USRefc1(&(v9), REFC_DECR);
                    US0 v13;
                    v13 = US0_1(v8);
                    v16 = v13; v17 = v10;
                    break;
                }
            }
            break;
        }
    }
    USRefc0(&(v4), REFC_DECR);
    US1 v26; uint32_t v27;
    switch (v16.tag) {
        case 0: { // Error
            UH0 * v18 = v16.case0.v0;
            UHRefc0(v18, REFC_INCR);
            US1 v19;
            v19 = US1_0(v18);
            UHRefc0(v18, REFC_DECR);
            v26 = v19; v27 = v17;
            break;
        }
        case 1: { // Ok
            uint32_t v20 = v16.case1.v0;
            uint32_t v21;
            v21 = 0ul;
            Fun0 * v22;
            v22 = method2(v20, v21);
            Fun1 * v23;
            v23 = v22->fptr(v22, v0);
            v22->refc_fptr(v22, REFC_DECR);
            US1 v24; uint32_t v25;
            Tuple1 tmp5 = v23->fptr(v23, v17);
            v24 = tmp5.v0; v25 = tmp5.v1;
            v23->refc_fptr(v23, REFC_DECR);
            v26 = v24; v27 = v25;
            break;
        }
    }
    StringRefc(v0, REFC_DECR); USRefc0(&(v16), REFC_DECR);
    switch (v26.tag) {
        case 0: { // Error
            UH0 * v28 = v26.case0.v0;
            UHRefc0(v28, REFC_INCR);
            printfn "Parsing failed at position %i" v27;
            printfn "Errors:";
            UHRefc0(v28, REFC_SUPPR);
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
