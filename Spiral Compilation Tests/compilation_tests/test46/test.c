#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_0(UH0 * v0) { // Error
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
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
                v18->refc++; v19->refc++;
                UH0 * v20;
                v20 = UH0_0(v18, v19);
                v20->refc++;
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
            v24->refc++; v25->refc++;
            UH0 * v26;
            v26 = UH0_0(v24, v25);
            v26->refc++;
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
                v41->refc++; v42->refc++;
                UH0 * v43;
                v43 = UH0_0(v41, v42);
                v43->refc++;
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
            v47->refc++; v48->refc++;
            UH0 * v49;
            v49 = UH0_0(v47, v48);
            v49->refc++;
            StringDecref(v47); UHDecref0(v48);
            US0 v50;
            v50 = US0_0(v49);
            UHDecref0(v49);
            v53 = v50; v54 = v1;
        }
    }
    switch (v53.tag) {
        case 0: { // Error
            StringDecref(v0); USDecref0(&(v53));
            if (v2){
                US0 v71;
                v71 = US0_1(v3);
                return TupleCreate0(v71, v54);
            } else {
                String * v72;
                v72 = StringLit(4, "i32");
                UH0 * v73;
                v73 = UH0_1();
                v72->refc++; v73->refc++;
                UH0 * v74;
                v74 = UH0_0(v72, v73);
                v74->refc++;
                StringDecref(v72); UHDecref0(v73);
                US0 v75;
                v75 = US0_0(v74);
                UHDecref0(v74);
                return TupleCreate0(v75, v54);
            }
            break;
        }
        case 1: { // Ok
            uint32_t v55 = v53.case1.v0;
            USDecref0(&(v53));
            uint32_t v56;
            v56 = v3 * 10ul;
            uint32_t v57;
            v57 = v56 + v55;
            bool v58;
            v58 = v3 <= 214748364ul;
            bool v60;
            if (v58){
                bool v59;
                v59 = 0ul <= v57;
                v60 = v59;
            } else {
                v60 = false;
            }
            if (v60){
                bool v61;
                v61 = true;
                return method0(v0, v54, v61, v57);
            } else {
                StringDecref(v0);
                String * v64;
                v64 = StringLit(52, "The number is too large to be parsed as 32 bit int.");
                UH0 * v65;
                v65 = UH0_1();
                v64->refc++; v65->refc++;
                UH0 * v66;
                v66 = UH0_0(v64, v65);
                v66->refc++;
                StringDecref(v64); UHDecref0(v65);
                US0 v67;
                v67 = US0_0(v66);
                UHDecref0(v66);
                return TupleCreate0(v67, v54);
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
void USIncref1(US1 * x){ USIncrefBody1(x); }
void USDecref1(US1 * x){ USDecrefBody1(x); }
US1 US1_0(UH0 * v0) { // Error
    US1 x;
    x.tag = 0;
    x.case0.v0 = v0;
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
void USIncref3(US3 * x){ USIncrefBody3(x); }
void USDecref3(US3 * x){ USDecrefBody3(x); }
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
void USIncref2(US2 * x){ USIncrefBody2(x); }
void USDecref2(US2 * x){ USDecrefBody2(x); }
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(US3 v0) { // Some
    US2 x;
    x.tag = 1;
    x.case1.v0 = v0;
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
bool method_while0(Mut0 * v0){
    uint32_t v1;
    v1 = v0->v0;
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
US3 method3(Array1 * v0, US3 v1, US3 v2, uint32_t v3){
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
                    bool v10;
                    if (v5){
                        uint32_t v6;
                        v6 = v3 - 2ul;
                        v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                        US3 v7;
                        v7 = method3(v0, v2, v1, v6);
                        switch (v7.tag) {
                            case 0: { // First
                                USDecref3(&(v7));
                                v10 = true;
                                break;
                            }
                            case 1: { // Second
                                USDecref3(&(v7));
                                v10 = false;
                                break;
                            }
                        }
                    } else {
                        v10 = false;
                    }
                    US3 v25;
                    if (v10){
                        USIncref3(&(v1));
                        v25 = v1;
                    } else {
                        bool v11;
                        v11 = v3 >= 3ul;
                        bool v16;
                        if (v11){
                            uint32_t v12;
                            v12 = v3 - 3ul;
                            v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                            US3 v13;
                            v13 = method3(v0, v2, v1, v12);
                            switch (v13.tag) {
                                case 0: { // First
                                    USDecref3(&(v13));
                                    v16 = true;
                                    break;
                                }
                                case 1: { // Second
                                    USDecref3(&(v13));
                                    v16 = false;
                                    break;
                                }
                            }
                        } else {
                            v16 = false;
                        }
                        if (v16){
                            USIncref3(&(v1));
                            v25 = v1;
                        } else {
                            bool v17;
                            v17 = v3 >= 5ul;
                            bool v22;
                            if (v17){
                                uint32_t v18;
                                v18 = v3 - 5ul;
                                v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                                US3 v19;
                                v19 = method3(v0, v2, v1, v18);
                                switch (v19.tag) {
                                    case 0: { // First
                                        USDecref3(&(v19));
                                        v22 = true;
                                        break;
                                    }
                                    case 1: { // Second
                                        USDecref3(&(v19));
                                        v22 = false;
                                        break;
                                    }
                                }
                            } else {
                                v22 = false;
                            }
                            if (v22){
                                USIncref3(&(v1));
                                v25 = v1;
                            } else {
                                USIncref3(&(v2));
                                v25 = v2;
                            }
                        }
                    }
                    USIncref3(&(v25));
                    USDecref3(&(v1)); USDecref3(&(v2));
                    US2 v26;
                    v26 = US2_1(v25);
                    AssignArray0(&(v0->ptr[v3]), v26);
                    ArrayDecref1(v0); USDecref2(&(v26));
                    return v25;
                    break;
                }
                case 1: { // Some
                    US3 v27 = v4.case1.v0;
                    USIncref3(&(v27));
                    ArrayDecref1(v0); USDecref3(&(v1)); USDecref3(&(v2)); USDecref2(&(v4));
                    return v27;
                    break;
                }
            }
            break;
        }
        case 1: { // Second
            bool v30;
            v30 = v3 >= 2ul;
            bool v35;
            if (v30){
                uint32_t v31;
                v31 = v3 - 2ul;
                v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                US3 v32;
                v32 = method3(v0, v2, v1, v31);
                switch (v32.tag) {
                    case 0: { // First
                        USDecref3(&(v32));
                        v35 = false;
                        break;
                    }
                    case 1: { // Second
                        USDecref3(&(v32));
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
                v36 = v3 >= 3ul;
                bool v41;
                if (v36){
                    uint32_t v37;
                    v37 = v3 - 3ul;
                    v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                    US3 v38;
                    v38 = method3(v0, v2, v1, v37);
                    switch (v38.tag) {
                        case 0: { // First
                            USDecref3(&(v38));
                            v41 = false;
                            break;
                        }
                        case 1: { // Second
                            USDecref3(&(v38));
                            v41 = true;
                            break;
                        }
                    }
                } else {
                    v41 = false;
                }
                if (v41){
                    ArrayDecref1(v0); USDecref3(&(v2));
                    return v1;
                } else {
                    bool v42;
                    v42 = v3 >= 5ul;
                    bool v47;
                    if (v42){
                        uint32_t v43;
                        v43 = v3 - 5ul;
                        v0->refc++; USIncref3(&(v1)); USIncref3(&(v2));
                        US3 v44;
                        v44 = method3(v0, v2, v1, v43);
                        switch (v44.tag) {
                            case 0: { // First
                                USDecref3(&(v44));
                                v47 = false;
                                break;
                            }
                            case 1: { // Second
                                USDecref3(&(v44));
                                v47 = true;
                                break;
                            }
                        }
                    } else {
                        v47 = false;
                    }
                    ArrayDecref1(v0);
                    if (v47){
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
    ClosureDecref1(x);
    bool v4;
    v4 = false;
    uint32_t v5;
    v5 = 0ul;
    v2->refc++;
    US0 v6; uint32_t v7;
    Tuple0 tmp2 = method0(v2, v3, v4, v5);
    v6 = tmp2.v0; v7 = tmp2.v1;
    US0 v22; uint32_t v23;
    switch (v6.tag) {
        case 0: { // Error
            UH0 * v18 = v6.case0.v0;
            v18->refc += 2;
            US0 v19;
            v19 = US0_0(v18);
            UHDecref0(v18);
            v22 = v19; v23 = v7;
            break;
        }
        case 1: { // Ok
            uint32_t v8 = v6.case1.v0;
            v2->refc++;
            US1 v9; uint32_t v10;
            Tuple1 tmp3 = method1(v2, v7);
            v9 = tmp3.v0; v10 = tmp3.v1;
            switch (v9.tag) {
                case 0: { // Error
                    UH0 * v12 = v9.case0.v0;
                    v12->refc += 2;
                    USDecref1(&(v9));
                    US0 v13;
                    v13 = US0_0(v12);
                    UHDecref0(v12);
                    v22 = v13; v23 = v10;
                    break;
                }
                case 1: { // Ok
                    USDecref1(&(v9));
                    US0 v11;
                    v11 = US0_1(v8);
                    v22 = v11; v23 = v10;
                    break;
                }
            }
            break;
        }
    }
    USDecref0(&(v6));
    switch (v22.tag) {
        case 0: { // Error
            UH0 * v44 = v22.case0.v0;
            v44->refc += 2;
            USDecref0(&(v22));
            US1 v45;
            v45 = US1_0(v44);
            UHDecref0(v44);
            return TupleCreate1(v45, v23);
            break;
        }
        case 1: { // Ok
            uint32_t v24 = v22.case1.v0;
            USDecref0(&(v22));
            bool v25;
            v25 = 100ul < v24;
            if (v25){
                fprintf(stderr, "%s\n", "The max input has been exceeded.")
                exit(EXIT_FAILURE);
            } else {
            }
            Array1 * v26;
            v26 = ArrayCreate1(101ul, false);
            Mut0 * v27;
            v27 = MutCreate0(0ul);
            while (method_while0(v27)){
                uint32_t v29;
                v29 = v27->v0;
                US2 v30;
                v30 = US2_0();
                AssignArray0(&(v26->ptr[v29]), v30);
                USDecref2(&(v30));
                uint32_t v31;
                v31 = v29 + 1ul;
                AssignMut0(&(v27->v0), v31);
            }
            MutDecref0(v27);
            US3 v32;
            v32 = US3_0();
            US3 v33;
            v33 = US3_1();
            v26->refc++; USIncref3(&(v32)); USIncref3(&(v33));
            US3 v34;
            v34 = method3(v26, v32, v33, v24);
            ArrayDecref1(v26); USDecref3(&(v32)); USDecref3(&(v33));
            String * v38;
            switch (v34.tag) {
                case 0: { // First
                    String * v35;
                    v35 = StringLit(6, "First");
                    v38 = v35;
                    break;
                }
                case 1: { // Second
                    String * v36;
                    v36 = StringLit(7, "Second");
                    v38 = v36;
                    break;
                }
            }
            USDecref3(&(v34));
            System.Console.WriteLine(v38);
            StringDecref(v38);
            uint32_t v39;
            v39 = v1 + 1ul;
            Fun0 * v40;
            v40 = method2(v0, v39);
            v2->refc++; v40->refc++;
            Fun1 * v41;
            v41 = v40->fptr(v40, v2);
            v40->decref_fptr(v40);
            return v41->fptr(v41, v23);
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
    return (Fun1 *) x;
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun1 * ClosureMethod0(Closure0 * x, String * v2){
    uint32_t v0 = x->v0; uint32_t v1 = x->v1;
    ClosureDecref0(x);
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
    ClosureDecref3(x);
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
    ClosureDecref2(x);
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
void method4(UH0 * v0){
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            v1->refc++; v2->refc++;
            UHDecref0(v0);
            printfn "%s" v1;
            StringDecref(v1);
            return method4(v2);
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
    v0->refc++;
    US0 v4; uint32_t v5;
    Tuple0 tmp0 = method0(v0, v1, v2, v3);
    v4 = tmp0.v0; v5 = tmp0.v1;
    US0 v20; uint32_t v21;
    switch (v4.tag) {
        case 0: { // Error
            UH0 * v16 = v4.case0.v0;
            v16->refc += 2;
            US0 v17;
            v17 = US0_0(v16);
            UHDecref0(v16);
            v20 = v17; v21 = v5;
            break;
        }
        case 1: { // Ok
            uint32_t v6 = v4.case1.v0;
            v0->refc++;
            US1 v7; uint32_t v8;
            Tuple1 tmp1 = method1(v0, v5);
            v7 = tmp1.v0; v8 = tmp1.v1;
            switch (v7.tag) {
                case 0: { // Error
                    UH0 * v10 = v7.case0.v0;
                    v10->refc += 2;
                    USDecref1(&(v7));
                    US0 v11;
                    v11 = US0_0(v10);
                    UHDecref0(v10);
                    v20 = v11; v21 = v8;
                    break;
                }
                case 1: { // Ok
                    USDecref1(&(v7));
                    US0 v9;
                    v9 = US0_1(v6);
                    v20 = v9; v21 = v8;
                    break;
                }
            }
            break;
        }
    }
    USDecref0(&(v4));
    US1 v32; uint32_t v33;
    switch (v20.tag) {
        case 0: { // Error
            UH0 * v28 = v20.case0.v0;
            v28->refc += 2;
            US1 v29;
            v29 = US1_0(v28);
            UHDecref0(v28);
            v32 = v29; v33 = v21;
            break;
        }
        case 1: { // Ok
            uint32_t v22 = v20.case1.v0;
            uint32_t v23;
            v23 = 0ul;
            Fun0 * v24;
            v24 = method2(v22, v23);
            v0->refc++; v24->refc++;
            Fun1 * v25;
            v25 = v24->fptr(v24, v0);
            v24->decref_fptr(v24);
            Tuple1 tmp4 = v25->fptr(v25, v21);
            v32 = tmp4.v0; v33 = tmp4.v1;
            break;
        }
    }
    StringDecref(v0); USDecref0(&(v20));
    switch (v32.tag) {
        case 0: { // Error
            UH0 * v34 = v32.case0.v0;
            v34->refc++;
            printfn "Parsing failed at position %i" v33;
            printfn "Errors:";
            method4(v34);
            break;
        }
        default: {
        }
    }
    USDecref1(&(v32));
    return 0l;
}
