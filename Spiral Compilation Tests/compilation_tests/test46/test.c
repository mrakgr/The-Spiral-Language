#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct UH0 UH0;
struct UH0 {
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
typedef struct {
    Tuple1 (*fptr)(char *, uint32_t);
    char env[];
} Fun1;
typedef struct {
    Fun1 * (*fptr)(char *, String *);
    char env[];
} Fun0;
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
    uint32_t len;
    US2 ptr[];
} Array1;
typedef struct {
    uint32_t v0;
} Mut0;
typedef struct {
    uint32_t v0;
    uint32_t v1;
    String * v2;
} ClosureEnv1;
typedef struct {
    Tuple1 (*fptr)(ClosureEnv1 *, uint32_t);
    ClosureEnv1 env[];
} Closure1;
typedef struct {
    uint32_t v0;
    uint32_t v1;
} ClosureEnv0;
typedef struct {
    Fun1 * (*fptr)(ClosureEnv0 *, String *);
    ClosureEnv0 env[];
} Closure0;
typedef struct {
} ClosureEnv3;
typedef struct {
    Tuple1 (*fptr)(ClosureEnv3 *, uint32_t);
    ClosureEnv3 env[];
} Closure3;
typedef struct {
} ClosureEnv2;
typedef struct {
    Fun1 * (*fptr)(ClosureEnv2 *, String *);
    ClosureEnv2 env[];
} Closure2;
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(char) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    return x;
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
UH0 * UH0_0(String * v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    return x;
}
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
        v5 = v0->len;;
        v7 = v1 < v5;
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
                v16 = v13 <= 9ul;
            } else {
                v16 = false;
            }
            if (v16){
                US0 v17;
                v17 = US0_1(v13);
                v49 = v17; v50 = v12;
            } else {
                UH0 * v18;
                v18 = UH0_1();
                UH0 * v19;
                v19 = UH0_0(StringLit(5, "digit"), v18);
                US0 v20;
                v20 = US0_0(v19);
                v49 = v20; v50 = v12;
            }
        } else {
            UH0 * v23;
            v23 = UH0_1();
            UH0 * v24;
            v24 = UH0_0(StringLit(14, "Out of bounds."), v23);
            US0 v25;
            v25 = US0_0(v24);
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
                v37 = v34 <= 9ul;
            } else {
                v37 = false;
            }
            if (v37){
                US0 v38;
                v38 = US0_1(v34);
                v49 = v38; v50 = v33;
            } else {
                UH0 * v39;
                v39 = UH0_1();
                UH0 * v40;
                v40 = UH0_0(StringLit(5, "digit"), v39);
                US0 v41;
                v41 = US0_0(v40);
                v49 = v41; v50 = v33;
            }
        } else {
            UH0 * v44;
            v44 = UH0_1();
            UH0 * v45;
            v45 = UH0_0(StringLit(14, "Out of bounds."), v44);
            US0 v46;
            v46 = US0_0(v45);
            v49 = v46; v50 = v1;
        }
    }
    switch (v49.tag) {
        case 0: { // Error
            UH0 * v51 = v49.case0.v0;
            if (v2){
                US0 v52;
                v52 = US0_1(v3);
                return TupleCreate0(v52, v50);
            } else {
                UH0 * v53;
                v53 = UH0_1();
                UH0 * v54;
                v54 = UH0_0(StringLit(3, "i32"), v53);
                US0 v55;
                v55 = US0_0(v54);
                return TupleCreate0(v55, v50);
            }
            break;
        }
        case 1: { // Ok
            uint32_t v58 = v49.case1.v0;
            uint32_t v59;
            v59 = v3 * 10ul;
            uint32_t v60;
            v60 = v59 + v58;
            bool v61;
            v61 = v3 <= 214748364ul;
            bool v63;
            if (v61){
                v63 = 0ul <= v60;
            } else {
                v63 = false;
            }
            if (v63){
                bool v64;
                v64 = true;
                return method0(v0, v50, v64, v60);
            } else {
                UH0 * v67;
                v67 = UH0_1();
                UH0 * v68;
                v68 = UH0_0(StringLit(51, "The number is too large to be parsed as 32 bit int."), v67);
                US0 v69;
                v69 = US0_0(v68);
                return TupleCreate0(v69, v50);
            }
            break;
        }
    }
}
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
        v3 = v0->len;;
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
                v10 = v5 == '\n';
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
        US1 v14;
        v14 = US1_1();
        return TupleCreate1(v14, v1);
    }
}
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
Array1 * ArrayCreate1(uint32_t size){
    Array1 * x = malloc(sizeof(Array1) + sizeof(US2) * size);
    x->len = size;
    return x;
}
Array1 * ArrayLit1(uint32_t size, US2 * ptr){
    Array1 * x = ArrayCreate1(size);
    memcpy(x->ptr, ptr, sizeof(US2) * size);
    return x;
}
static inline Mut0 * MutCreate0(uint32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->v0 = v0;
    return x;
}
bool method3(Mut0 * v0){
    uint32_t v1;
    v1 = v0->v0;
    return v1 < 101ul;
}
US3 method4(Array1 * v0, US3 v1, US3 v2, uint32_t v3){
    switch (v1.tag) {
        case 0: { // First
            US2 v4;
            v4 = v0->ptr[v3];
            switch (v4.tag) {
                case 0: { // None
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
                                v9 = true;
                                break;
                            }
                            case 1: { // Second
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
                                    v14 = true;
                                    break;
                                }
                                case 1: { // Second
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
                                        v19 = true;
                                        break;
                                    }
                                    case 1: { // Second
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
                    US2 v23;
                    v23 = US2_1(v22);
                    v0->ptr[v3] = v23;
                    return v22;
                    break;
                }
                case 1: { // Some
                    US3 v24 = v4.case1.v0;
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
                        v30 = false;
                        break;
                    }
                    case 1: { // Second
                        v30 = true;
                        break;
                    }
                }
            } else {
                v30 = false;
            }
            if (v30){
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
                            v35 = false;
                            break;
                        }
                        case 1: { // Second
                            v35 = true;
                            break;
                        }
                    }
                } else {
                    v35 = false;
                }
                if (v35){
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
                                v40 = false;
                                break;
                            }
                            case 1: { // Second
                                v40 = true;
                                break;
                            }
                        }
                    } else {
                        v40 = false;
                    }
                    if (v40){
                        return v1;
                    } else {
                        return v2;
                    }
                }
            }
            break;
        }
    }
}
Tuple1 ClosureMethod1(ClosureEnv1 * env, uint32_t v3){
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
            US0 v9;
            v9 = US0_0(v8);
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
                    US0 v14;
                    v14 = US0_0(v13);
                    v18 = v14; v19 = v12;
                    break;
                }
                case 1: { // Ok
                    US0 v15;
                    v15 = US0_1(v10);
                    v18 = v15; v19 = v12;
                    break;
                }
            }
            break;
        }
    }
    switch (v18.tag) {
        case 0: { // Error
            UH0 * v20 = v18.case0.v0;
            US1 v21;
            v21 = US1_0(v20);
            return TupleCreate1(v21, v19);
            break;
        }
        case 1: { // Ok
            uint32_t v22 = v18.case1.v0;
            bool v23;
            v23 = 100ul < v22;
            if (v23){
                fprintf(stderr, "%s\
", StringLit(32, "The max input has been exceeded."))
                exit(EXIT_FAILURE);
            } else {
                
            }
            Array1 * v24;
            v24 = ArrayCreate1(101ul);
            Mut0 * v25;
            v25 = MutCreate0(0ul);
            while (method3(v25)){
                uint32_t v27;
                v27 = v25->v0;
                US2 v28;
                v28 = US2_0();
                v24->ptr[v27] = v28;
                uint32_t v29;
                v29 = v27 + 1ul;
                v25->v0 = v29;
            }
            US3 v30;
            v30 = US3_0();
            US3 v31;
            v31 = US3_1();
            US3 v32;
            v32 = method4(v24, v30, v31, v22);
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
            System.Console.WriteLine(v33);
            uint32_t v34;
            v34 = v1 + 1ul;
            Fun0 * v35;
            v35 = method2(v0, v34);
            Fun1 * v36;
            v36 = v35->fptr(v35->env, v2);
            return v36->fptr(v36->env, v19);
            break;
        }
    }
}
Fun1 * ClosureCreate1(uint32_t v0, uint32_t v1, String * v2){
    Closure1 * x = malloc(sizeof(Closure1) + sizeof(ClosureEnv1));
    ClosureEnv1 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2;
    x->fptr = ClosureMethod1;
    return (Fun1 *) x;
}
Fun1 * ClosureMethod0(ClosureEnv0 * env, String * v2){
    uint32_t v0 = env->v0; uint32_t v1 = env->v1;
    return ClosureCreate1(v0, v1, v2);
}
Fun0 * ClosureCreate0(uint32_t v0, uint32_t v1){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    ClosureEnv0 * env = x->env;
    env->v0 = v0; env->v1 = v1;
    x->fptr = ClosureMethod0;
    return (Fun0 *) x;
}
Tuple1 ClosureMethod3(ClosureEnv3 * env, uint32_t v0){
    US1 v1;
    v1 = US1_1();
    return TupleCreate1(v1, v0);
}
Fun1 * ClosureCreate3(){
    Closure3 * x = malloc(sizeof(Closure3) + sizeof(ClosureEnv3));
    x->fptr = ClosureMethod3;
    return (Fun1 *) x;
}
Fun1 * ClosureMethod2(ClosureEnv2 * env, String * v0){
    return ClosureCreate3();
}
Fun0 * ClosureCreate2(){
    Closure2 * x = malloc(sizeof(Closure2) + sizeof(ClosureEnv2));
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
    switch (v0->tag) {
        case 0: { // Cons
            String * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            printfn "%s" v1;
            return method5(v2);
            break;
        }
        case 1: { // Nil
            return ;
            break;
        }
    }
}
void main(){
    String * v0;
    v0 = StringLit(18, "8 1 2 3 4 5 6 7 10");
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
            US0 v7;
            v7 = US0_0(v6);
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
                    US0 v12;
                    v12 = US0_0(v11);
                    v16 = v12; v17 = v10;
                    break;
                }
                case 1: { // Ok
                    US0 v13;
                    v13 = US0_1(v8);
                    v16 = v13; v17 = v10;
                    break;
                }
            }
            break;
        }
    }
    US1 v26; uint32_t v27;
    switch (v16.tag) {
        case 0: { // Error
            UH0 * v18 = v16.case0.v0;
            US1 v19;
            v19 = US1_0(v18);
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
            v23 = v22->fptr(v22->env, v0);
            Tuple1 tmp4 = v23->fptr(v23->env, v17);
            v26 = tmp4.v0; v27 = tmp4.v1;
            break;
        }
    }
    switch (v26.tag) {
        case 0: { // Error
            UH0 * v28 = v26.case0.v0;
            printfn "Parsing failed at position %i" v27;
            printfn "Errors:";
            return method5(v28);
            break;
        }
        case 1: { // Ok
            return ;
            break;
        }
    }
}
