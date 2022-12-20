#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
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
    void (*decref_fptr)(Fun1 *);
    Tuple1 (*fptr)(Fun1 *, uint32_t);
};
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
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
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    Tuple1 (*fptr)(Closure1 *, uint32_t);
    String * v2;
    uint32_t v1;
    uint32_t v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun1 * (*fptr)(Closure0 *, String *);
    uint32_t v0;
    uint32_t v1;
};
typedef struct Closure3 Closure3;
struct Closure3 {
    int refc;
    void (*decref_fptr)(Closure3 *);
    Tuple1 (*fptr)(Closure3 *, uint32_t);
};
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*decref_fptr)(Closure2 *);
    Fun1 * (*fptr)(Closure2 *, String *);
};
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
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
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            StringDecref(x->case0.v0); UHDecref0(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(String * v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    v0->refc++; v1->refc++;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v0);
            break;
        }
    }
}
static inline void USSupprefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc--;
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
void USSuppref0(US0 * x){ USSupprefBody0(x); }
US0 US0_0(UH0 * v0) { // Error
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    v0->refc++;
    return x;
}
US0 US0_1(uint32_t v0) { // Ok
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(US0 v0, uint32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(String * v0, uint32_t v1, bool v2, uint32_t v3){
    v0->refc++;
    bool v4;
    v4 = 0ul <= v1;
    bool v7;
    if (v4){
        uint32_t v5;
        v5 = v0->len-1;
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
                StringDecref(v18); UHDecref0(v19);
                US0 v21;
                v21 = US0_0(v20);
                UHDecref0(v20);
                v53 = v21; v54 = v12;
            }
        } else {
            String * v24;
            v24 = StringLit(15, "Out of bounds.");
            UH0 * v25;
            v25 = UH0_1();
            UH0 * v26;
            v26 = UH0_0(v24, v25);
            StringDecref(v24); UHDecref0(v25);
            US0 v27;
            v27 = US0_0(v26);
            UHDecref0(v26);
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
                StringDecref(v41); UHDecref0(v42);
                US0 v44;
                v44 = US0_0(v43);
                UHDecref0(v43);
                v53 = v44; v54 = v35;
            }
        } else {
            String * v47;
            v47 = StringLit(15, "Out of bounds.");
            UH0 * v48;
            v48 = UH0_1();
            UH0 * v49;
            v49 = UH0_0(v47, v48);
            StringDecref(v47); UHDecref0(v48);
            US0 v50;
            v50 = US0_0(v49);
            UHDecref0(v49);
            v53 = v50; v54 = v1;
        }
    }
    switch (v53.tag) {
        case 0: { // Error
            UH0 * v55 = v53.case0.v0;
            StringDecref(v0); USDecref0(&(v53));
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
                StringDecref(v57); UHDecref0(v58);
                US0 v60;
                v60 = US0_0(v59);
                UHDecref0(v59);
                return TupleCreate0(v60, v54);
            }
            break;
        }
        case 1: { // Ok
            uint32_t v63 = v53.case1.v0;
            USDecref0(&(v53));
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
                v0->refc--;
                return method0(v0, v54, v69, v65);
            } else {
                StringDecref(v0);
                String * v72;
                v72 = StringLit(52, "The number is too large to be parsed as 32 bit int.");
                UH0 * v73;
                v73 = UH0_1();
                UH0 * v74;
                v74 = UH0_0(v72, v73);
                StringDecref(v72); UHDecref0(v73);
                US0 v75;
                v75 = US0_0(v74);
                UHDecref0(v74);
                return TupleCreate0(v75, v54);
            }
            break;
        }
    }
}
static inline void USIncrefBody1(US1 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody1(US1 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v0);
            break;
        }
    }
}
static inline void USSupprefBody1(US1 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc--;
            break;
        }
    }
}
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
void USSuppref1(US1 * x){ USSupprefBody1(x); }
US1 US1_0(UH0 * v0) { // Error
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0;
    v0->refc++;
    return x;
}
US1 US1_1() { // Ok
    US1 x;
    x.tag = 1;
    return x;
}
static inline Tuple1 TupleCreate1(US1 v0, uint32_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple1 method1(String * v0, uint32_t v1){
    v0->refc++;
    bool v2;
    v2 = 0ul <= v1;
    bool v10;
    if (v2){
        uint32_t v3;
        v3 = v0->len-1;
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
        v0->refc--;
        return method1(v0, v11);
    } else {
        StringDecref(v0);
        US1 v14;
        v14 = US1_1();
        return TupleCreate1(v14, v1);
    }
}
static inline void USIncrefBody3(US3 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody3(US3 * x){
    switch (x->tag) {
    }
}
static inline void USSupprefBody3(US3 * x){
    switch (x->tag) {
    }
}
void USIncref3(US3 * x){ USIncrefBody3(x); }
void USDecref3(US3 * x){ USDecrefBody3(x); }
void USSuppref3(US3 * x){ USSupprefBody3(x); }
US3 US3_0() { // First
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1() { // Second
    US3 x;
    x.tag = 1;
    return x;
}
static inline void USIncrefBody2(US2 * x){
    switch (x->tag) {
        case 1: {
            USIncref3(&(x->case1.v0));
            break;
        }
    }
}
static inline void USDecrefBody2(US2 * x){
    switch (x->tag) {
        case 1: {
            USDecref3(&(x->case1.v0));
            break;
        }
    }
}
static inline void USSupprefBody2(US2 * x){
    switch (x->tag) {
        case 1: {
            USSuppref3(&(x->case1.v0));
            break;
        }
    }
}
void USIncref2(US2 * x){ USIncrefBody2(x); }
void USDecref2(US2 * x){ USDecrefBody2(x); }
void USSuppref2(US2 * x){ USSupprefBody2(x); }
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(US3 v0) { // Some
    US2 x;
    x.tag = 1;
    x.case1.v0 = v0;
    USIncref3(&(v0));
    return x;
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    US2 * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        US2 v = ptr[i];
        USDecref2(&(v));
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
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
        for (uint32_t i=0; i < len; i++){
            US2 v = ptr[i];
            USIncref2(&(v));
        }
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(uint32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
bool method3(Mut0 * v0){
    v0->refc++;
    uint32_t v1;
    v1 = v0->v0;
    MutDecref0(v0);
    bool v2;
    v2 = v1 < 101ul;
    return v2;
}
static inline void AssignArray0(US2 * a, US2 b){
    USIncref2(&(b));
    USDecref2(&(*a));
    *a = b;
}
static inline void AssignMut0(uint32_t * a0, uint32_t b0){
    *a0 = b0;
}
US3 method4(Array1 * v0, US3 v1, US3 v2, uint32_t v3){
    v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
    switch (v1.tag) {
        case 0: { // First
            US2 v4;
            v4 = v0->ptr[v3];
            USIncref2(&(v4));
            switch (v4.tag) {
                case 0: { // None
                    USDecref2(&(v4));
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
                                USDecref3(&(v7));
                                v9 = true;
                                break;
                            }
                            case 1: { // Second
                                USDecref3(&(v7));
                                v9 = false;
                                break;
                            }
                        }
                    } else {
                        v9 = false;
                    }
                    US3 v22;
                    if (v9){
                        USIncref3(&(v1));
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
                                    USDecref3(&(v12));
                                    v14 = true;
                                    break;
                                }
                                case 1: { // Second
                                    USDecref3(&(v12));
                                    v14 = false;
                                    break;
                                }
                            }
                        } else {
                            v14 = false;
                        }
                        if (v14){
                            USIncref3(&(v1));
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
                                        USDecref3(&(v17));
                                        v19 = true;
                                        break;
                                    }
                                    case 1: { // Second
                                        USDecref3(&(v17));
                                        v19 = false;
                                        break;
                                    }
                                }
                            } else {
                                v19 = false;
                            }
                            if (v19){
                                USIncref3(&(v1));
                                v22 = v1;
                            } else {
                                USIncref3(&(v2));
                                v22 = v2;
                            }
                        }
                    }
                    USDecref3(&(v1)); USDecref3(&(v2));
                    US2 v23;
                    v23 = US2_1(v22);
                    AssignArray0(&(v0->ptr[v3]), v23);
                    ArrayDecref1(v0); USDecref2(&(v23));
                    return v22;
                    break;
                }
                case 1: { // Some
                    US3 v24 = v4.case1.v0;
                    USIncref3(&(v24));
                    ArrayDecref1(v0); USDecref3(&(v1)); USDecref3(&(v2)); USDecref2(&(v4));
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
                        USDecref3(&(v28));
                        v30 = false;
                        break;
                    }
                    case 1: { // Second
                        USDecref3(&(v28));
                        v30 = true;
                        break;
                    }
                }
            } else {
                v30 = false;
            }
            if (v30){
                ArrayDecref1(v0); USDecref3(&(v2));
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
                            USDecref3(&(v33));
                            v35 = false;
                            break;
                        }
                        case 1: { // Second
                            USDecref3(&(v33));
                            v35 = true;
                            break;
                        }
                    }
                } else {
                    v35 = false;
                }
                if (v35){
                    ArrayDecref1(v0); USDecref3(&(v2));
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
                                USDecref3(&(v38));
                                v40 = false;
                                break;
                            }
                            case 1: { // Second
                                USDecref3(&(v38));
                                v40 = true;
                                break;
                            }
                        }
                    } else {
                        v40 = false;
                    }
                    ArrayDecref1(v0);
                    if (v40){
                        USDecref3(&(v2));
                        return v1;
                    } else {
                        USDecref3(&(v1));
                        return v2;
                    }
                }
            }
            break;
        }
    }
}
static inline void ClosureDecrefBody1(Closure1 * x){
    StringDecref(x->v2);
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
Tuple1 ClosureMethod1(Closure1 * x, uint32_t v3){
    uint32_t v0 = x->v0; uint32_t v1 = x->v1; String * v2 = x->v2;
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
            v8->refc++;
            US0 v9;
            v9 = US0_0(v8);
            UHDecref0(v8);
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
                    v13->refc++;
                    USDecref1(&(v11));
                    US0 v14;
                    v14 = US0_0(v13);
                    UHDecref0(v13);
                    v18 = v14; v19 = v12;
                    break;
                }
                case 1: { // Ok
                    USDecref1(&(v11));
                    US0 v15;
                    v15 = US0_1(v10);
                    v18 = v15; v19 = v12;
                    break;
                }
            }
            break;
        }
    }
    USDecref0(&(v6));
    switch (v18.tag) {
        case 0: { // Error
            UH0 * v20 = v18.case0.v0;
            v20->refc++;
            USDecref0(&(v18));
            US1 v21;
            v21 = US1_0(v20);
            UHDecref0(v20);
            return TupleCreate1(v21, v19);
            break;
        }
        case 1: { // Ok
            uint32_t v22 = v18.case1.v0;
            USDecref0(&(v18));
            bool v23;
            v23 = 100ul < v22;
            if (v23){
                fprintf(stderr, "%s\n", "The max input has been exceeded.")
                exit(EXIT_FAILURE);
            } else {
            }
            Array1 * v24;
            v24 = ArrayCreate1(101ul, false);
            Mut0 * v25;
            v25 = MutCreate0(0ul);
            while (method3(v25)){
                uint32_t v27;
                v27 = v25->v0;
                US2 v28;
                v28 = US2_0();
                AssignArray0(&(v24->ptr[v27]), v28);
                USDecref2(&(v28));
                uint32_t v29;
                v29 = v27 + 1ul;
                AssignMut0(&(v25->v0), v29);
            }
            MutDecref0(v25);
            US3 v30;
            v30 = US3_0();
            US3 v31;
            v31 = US3_1();
            US3 v32;
            v32 = method4(v24, v30, v31, v22);
            ArrayDecref1(v24); USDecref3(&(v30)); USDecref3(&(v31));
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
            USDecref3(&(v32));
            System.Console.WriteLine(v35);
            StringDecref(v35);
            uint32_t v36;
            v36 = v1 + 1ul;
            Fun0 * v37;
            v37 = method2(v0, v36);
            Fun1 * v38;
            v38 = v37->fptr(v37, v2);
            v37->decref_fptr(v37);
            US1 v39; uint32_t v40;
            Tuple1 tmp4 = v38->fptr(v38, v19);
            v39 = tmp4.v0; v40 = tmp4.v1;
            v38->decref_fptr(v38);
            return TupleCreate1(v39, v40);
            break;
        }
    }
}
Fun1 * ClosureCreate1(uint32_t v0, uint32_t v1, String * v2){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    v2->refc++;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * ClosureMethod0(Closure0 * x, String * v2){
    uint32_t v0 = x->v0; uint32_t v1 = x->v1;
    return ClosureCreate1(v0, v1, v2);
}
Fun0 * ClosureCreate0(uint32_t v0, uint32_t v1){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0; x->v1 = v1;
    return (Fun0 *) x;
}
static inline void ClosureDecrefBody3(Closure3 * x){
}
void ClosureDecref3(Closure3 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody3(x); free(x); }
}
Tuple1 ClosureMethod3(Closure3 * x, uint32_t v0){
    US1 v1;
    v1 = US1_1();
    return TupleCreate1(v1, v0);
}
Fun1 * ClosureCreate3(){
    Closure3 * x = malloc(sizeof(Closure3));
    x->refc = 1;
    x->decref_fptr = ClosureDecref3;
    x->fptr = ClosureMethod3;
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody2(Closure2 * x){
}
void ClosureDecref2(Closure2 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
Fun1 * ClosureMethod2(Closure2 * x, String * v0){
    v0->refc++;
    StringDecref(v0);
    return ClosureCreate3();
}
Fun0 * ClosureCreate2(){
    Closure2 * x = malloc(sizeof(Closure2));
    x->refc = 1;
    x->decref_fptr = ClosureDecref2;
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
    v0->refc++;
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            v1->refc++; v2->refc++;
            UHDecref0(v0);
            printfn "%s" v1;
            StringDecref(v1);
            v2->refc--;
            return method5(v2);
            break;
        }
        case 1: { // Nil
            UHDecref0(v0);
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
            v6->refc++;
            US0 v7;
            v7 = US0_0(v6);
            UHDecref0(v6);
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
                    v11->refc++;
                    USDecref1(&(v9));
                    US0 v12;
                    v12 = US0_0(v11);
                    UHDecref0(v11);
                    v16 = v12; v17 = v10;
                    break;
                }
                case 1: { // Ok
                    USDecref1(&(v9));
                    US0 v13;
                    v13 = US0_1(v8);
                    v16 = v13; v17 = v10;
                    break;
                }
            }
            break;
        }
    }
    USDecref0(&(v4));
    US1 v26; uint32_t v27;
    switch (v16.tag) {
        case 0: { // Error
            UH0 * v18 = v16.case0.v0;
            v18->refc++;
            US1 v19;
            v19 = US1_0(v18);
            UHDecref0(v18);
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
            v22->decref_fptr(v22);
            US1 v24; uint32_t v25;
            Tuple1 tmp5 = v23->fptr(v23, v17);
            v24 = tmp5.v0; v25 = tmp5.v1;
            v23->decref_fptr(v23);
            v26 = v24; v27 = v25;
            break;
        }
    }
    StringDecref(v0); USDecref0(&(v16));
    switch (v26.tag) {
        case 0: { // Error
            UH0 * v28 = v26.case0.v0;
            v28->refc++;
            printfn "Parsing failed at position %i" v27;
            printfn "Errors:";
            v28->refc--;
            method5(v28);
            break;
        }
        case 1: { // Ok
            break;
        }
    }
    USDecref1(&(v26));
    return 0l;
}
