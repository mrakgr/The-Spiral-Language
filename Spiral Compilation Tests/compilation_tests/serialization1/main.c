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
            char v0;
            int32_t v1;
            String * v2;
            UH0 * v3;
        } case0; // Cons
    };
};
typedef struct {
    int refc;
    uint32_t len;
    uint8_t ptr[];
} Array1;
typedef struct {
    int refc;
    int32_t v0;
} Mut0;
typedef struct {
    int refc;
    int32_t v0;
} Mut1;
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
            StringRefc(x.case0.v2, q); UHRefc0(x.case0.v3, q);
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
UH0 * UH0_0(char v0, int32_t v1, String * v2, UH0 * v3) { // Cons
    UH0 x;
    x.tag = 0;
    x.refc = 1;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2; x.case0.v3 = v3;
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
int32_t method1(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            char v1 = v0->case0.v0; int32_t v2 = v0->case0.v1; String * v3 = v0->case0.v2; UH0 * v4 = v0->case0.v3;
            StringRefc(v3, REFC_INCR); UHRefc0(v4, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            int32_t v5;
            v5 = v3->len;
            StringRefc(v3, REFC_DECR);
            int32_t v6;
            v6 = 2l * v5;
            int32_t v7;
            v7 = 4l + v6;
            int32_t v8;
            v8 = v7 + 2l;
            int32_t v9;
            v9 = 4l + v8;
            int32_t v10;
            v10 = method1(v4);
            UHRefc0(v4, REFC_DECR);
            int32_t v11;
            v11 = v9 + v10;
            int32_t v12;
            v12 = 4l + v11;
            return v12;
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            return 4l;
            break;
        }
    }
}
static inline void ArrayRefcBody1(Array1 * x, REFC_FLAG q){
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
    uint32_t size = sizeof(Array1) + sizeof(uint8_t) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, uint8_t * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(uint8_t) * len);
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
Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    MutRefcBody0(x, REFC_INCR);
    return x;
}
static inline void AssignMut0(int32_t * a0, int32_t b0){
    *a0 = b0;
}
static inline void MutRefcBody1(Mut1 * x, REFC_FLAG q){
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
Mut1 * MutCreate1(int32_t v0){
    Mut1 * x = malloc(sizeof(Mut1));
    x->refc = 1;
    x->v0 = v0;
    MutRefcBody1(x, REFC_INCR);
    return x;
}
bool method3(int32_t v0, Mut1 * v1){
    MutRefc1(v1, REFC_INCR);
    int32_t v2;
    v2 = v1->v0;
    MutRefc1(v1, REFC_DECR);
    bool v3;
    v3 = v2 < v0;
    return v3;
}
void method2(UH0 * v0, Mut0 * v1, Array1 * v2){
    UHRefc0(v0, REFC_INCR); MutRefc0(v1, REFC_INCR); ArrayRefc1(v2, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            char v3 = v0->case0.v0; int32_t v4 = v0->case0.v1; String * v5 = v0->case0.v2; UH0 * v6 = v0->case0.v3;
            StringRefc(v5, REFC_INCR); UHRefc0(v6, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            int32_t v7;
            v7 = v1->v0;
            System.Span<uint8_t> v8;
            v8 = System.Span(v2,v7,4l);
            bool v9;
            v9 = System.BitConverter.TryWriteBytes(v8,0l);
            bool v10;
            v10 = v9 == false;
            if (v10){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
            }
            int32_t v11;
            v11 = v7 + 4l;
            AssignMut0(&(v1->v0), v11);
            int32_t v12;
            v12 = v1->v0;
            System.Span<uint8_t> v13;
            v13 = System.Span(v2,v12,4l);
            bool v14;
            v14 = System.BitConverter.TryWriteBytes(v13,v4);
            bool v15;
            v15 = v14 == false;
            if (v15){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
            }
            int32_t v16;
            v16 = v12 + 4l;
            AssignMut0(&(v1->v0), v16);
            Array0 * v17;
            v17 = v5.ToCharArray();
            StringRefc(v5, REFC_DECR);
            int32_t v18;
            v18 = v17->len;
            int32_t v19;
            v19 = v1->v0;
            System.Span<uint8_t> v20;
            v20 = System.Span(v2,v19,4l);
            bool v21;
            v21 = System.BitConverter.TryWriteBytes(v20,v18);
            bool v22;
            v22 = v21 == false;
            if (v22){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
            }
            int32_t v23;
            v23 = v19 + 4l;
            AssignMut0(&(v1->v0), v23);
            Mut1 * v24;
            v24 = MutCreate1(0l);
            while (method3(v18, v24)){
                int32_t v26;
                v26 = v24->v0;
                char v27;
                v27 = v17->ptr[v26];
                int32_t v28;
                v28 = v1->v0;
                System.Span<uint8_t> v29;
                v29 = System.Span(v2,v28,2l);
                bool v30;
                v30 = System.BitConverter.TryWriteBytes(v29,v27);
                bool v31;
                v31 = v30 == false;
                if (v31){
                    fprintf(stderr, "%s\n", "Conversion failed.")
                    exit(EXIT_FAILURE);
                } else {
                }
                int32_t v32;
                v32 = v28 + 2l;
                AssignMut0(&(v1->v0), v32);
                int32_t v33;
                v33 = v26 + 1l;
                AssignMut0(&(v24->v0), v33);
            }
            ArrayRefc0(v17, REFC_DECR);
            MutRefc1(v24, REFC_DECR);
            int32_t v34;
            v34 = v1->v0;
            System.Span<uint8_t> v35;
            v35 = System.Span(v2,v34,2l);
            bool v36;
            v36 = System.BitConverter.TryWriteBytes(v35,v3);
            bool v37;
            v37 = v36 == false;
            if (v37){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
            }
            int32_t v38;
            v38 = v34 + 2l;
            AssignMut0(&(v1->v0), v38);
            MutRefc0(v1, REFC_SUPPR); ArrayRefc1(v2, REFC_SUPPR); UHRefc0(v6, REFC_SUPPR);
            return method2(v6, v1, v2);
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            int32_t v39;
            v39 = v1->v0;
            System.Span<uint8_t> v40;
            v40 = System.Span(v2,v39,4l);
            ArrayRefc1(v2, REFC_DECR);
            bool v41;
            v41 = System.BitConverter.TryWriteBytes(v40,1l);
            bool v42;
            v42 = v41 == false;
            if (v42){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
            }
            int32_t v43;
            v43 = v39 + 4l;
            AssignMut0(&(v1->v0), v43);
            MutRefc0(v1, REFC_DECR);
            return ;
            break;
        }
    }
}
static inline void AssignArray0(char * a, char b){
    *a = b;
}
UH0 * method4(Mut0 * v0, Array1 * v1){
    MutRefc0(v0, REFC_INCR); ArrayRefc1(v1, REFC_INCR);
    int32_t v2;
    v2 = v0->v0;
    int32_t v3;
    v3 = v2 + 4l;
    AssignMut0(&(v0->v0), v3);
    int32_t v4;
    v4 = System.BitConverter.ToInt32(v1,v2);
    bool v5;
    v5 = 0l == v4;
    if (v5){
        int32_t v6;
        v6 = v0->v0;
        int32_t v7;
        v7 = v6 + 4l;
        AssignMut0(&(v0->v0), v7);
        int32_t v8;
        v8 = System.BitConverter.ToInt32(v1,v6);
        int32_t v9;
        v9 = v0->v0;
        int32_t v10;
        v10 = v9 + 4l;
        AssignMut0(&(v0->v0), v10);
        int32_t v11;
        v11 = System.BitConverter.ToInt32(v1,v9);
        Array0 * v12;
        v12 = ArrayCreate0(v11, false);
        Mut1 * v13;
        v13 = MutCreate1(0l);
        while (method3(v11, v13)){
            int32_t v15;
            v15 = v13->v0;
            int32_t v16;
            v16 = v0->v0;
            int32_t v17;
            v17 = v16 + 2l;
            AssignMut0(&(v0->v0), v17);
            char v18;
            v18 = System.BitConverter.ToChar(v1,v16);
            AssignArray0(&(v12->ptr[v15]), v18);
            int32_t v19;
            v19 = v15 + 1l;
            AssignMut0(&(v13->v0), v19);
        }
        MutRefc1(v13, REFC_DECR);
        String * v20;
        v20 = System.String(v12);
        ArrayRefc0(v12, REFC_DECR);
        int32_t v21;
        v21 = v0->v0;
        int32_t v22;
        v22 = v21 + 2l;
        AssignMut0(&(v0->v0), v22);
        char v23;
        v23 = System.BitConverter.ToChar(v1,v21);
        UH0 * v24;
        v24 = method4(v0, v1);
        MutRefc0(v0, REFC_DECR); ArrayRefc1(v1, REFC_DECR);
        StringRefc(v20, REFC_SUPPR); UHRefc0(v24, REFC_SUPPR);
        return UH0_0(v23, v8, v20, v24);
    } else {
        MutRefc0(v0, REFC_DECR); ArrayRefc1(v1, REFC_DECR);
        bool v26;
        v26 = 1l == v4;
        if (v26){
            return UH0_1();
        } else {
            fprintf(stderr, "%s\n", "Invalid tag.")
            exit(EXIT_FAILURE);
        }
    }
}
bool method5(UH0 * v0, UH0 * v1){
    UHRefc0(v0, REFC_INCR); UHRefc0(v1, REFC_INCR);
    switch (v1->tag == v0->tag ? v1->tag : -1) {
        case 0: { // Cons
            char v2 = v1->case0.v0; int32_t v3 = v1->case0.v1; String * v4 = v1->case0.v2; UH0 * v5 = v1->case0.v3;
            StringRefc(v4, REFC_INCR); UHRefc0(v5, REFC_INCR);
            char v6 = v0->case0.v0; int32_t v7 = v0->case0.v1; String * v8 = v0->case0.v2; UH0 * v9 = v0->case0.v3;
            StringRefc(v8, REFC_INCR); UHRefc0(v9, REFC_INCR);
            UHRefc0(v0, REFC_DECR); UHRefc0(v1, REFC_DECR);
            bool v10;
            v10 = v2 == v6;
            bool v14;
            if (v10){
                bool v11;
                v11 = v3 == v7;
                if (v11){
                    bool v12;
                    v12 = strcmp(v4->ptr->ptr, v8->ptr->ptr) == 0;
                    v14 = v12;
                } else {
                    v14 = false;
                }
            } else {
                v14 = false;
            }
            StringRefc(v4, REFC_DECR); StringRefc(v8, REFC_DECR);
            if (v14){
                UHRefc0(v5, REFC_SUPPR); UHRefc0(v9, REFC_SUPPR);
                return method5(v9, v5);
            } else {
                UHRefc0(v5, REFC_DECR); UHRefc0(v9, REFC_DECR);
                return false;
            }
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR); UHRefc0(v1, REFC_DECR);
            return true;
            break;
        }
        default: {
            UHRefc0(v0, REFC_DECR); UHRefc0(v1, REFC_DECR);
            return false;
        }
    }
}
int32_t method0(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    char v2;
    v2 = 'z';
    int32_t v3;
    v3 = 1l;
    String * v4;
    v4 = StringLit(2, "a");
    char v5;
    v5 = 'x';
    int32_t v6;
    v6 = 2l;
    String * v7;
    v7 = StringLit(2, "s");
    UH0 * v8;
    v8 = UH0_1();
    UH0 * v9;
    v9 = UH0_0(v5, v6, v7, v8);
    StringRefc(v7, REFC_DECR); UHRefc0(v8, REFC_DECR);
    UH0 * v10;
    v10 = UH0_0(v2, v3, v4, v9);
    StringRefc(v4, REFC_DECR); UHRefc0(v9, REFC_DECR);
    int32_t v11;
    v11 = method1(v10);
    int32_t v12;
    v12 = 4l + v11;
    int32_t v13;
    v13 = 4l + v12;
    Array1 * v14;
    v14 = ArrayCreate1(v13, false);
    Mut0 * v15;
    v15 = MutCreate0(0l);
    int32_t v16;
    v16 = v15->v0;
    System.Span<uint8_t> v17;
    v17 = System.Span(v14,v16,4l);
    bool v18;
    v18 = System.BitConverter.TryWriteBytes(v17,v0);
    bool v19;
    v19 = v18 == false;
    if (v19){
        fprintf(stderr, "%s\n", "Conversion failed.")
        exit(EXIT_FAILURE);
    } else {
    }
    int32_t v20;
    v20 = v16 + 4l;
    AssignMut0(&(v15->v0), v20);
    int32_t v21;
    v21 = v15->v0;
    System.Span<uint8_t> v22;
    v22 = System.Span(v14,v21,4l);
    bool v23;
    v23 = System.BitConverter.TryWriteBytes(v22,v1);
    bool v24;
    v24 = v23 == false;
    if (v24){
        fprintf(stderr, "%s\n", "Conversion failed.")
        exit(EXIT_FAILURE);
    } else {
    }
    int32_t v25;
    v25 = v21 + 4l;
    AssignMut0(&(v15->v0), v25);
    method2(v10, v15, v14);
    int32_t v26;
    v26 = v15->v0;
    MutRefc0(v15, REFC_DECR);
    bool v27;
    v27 = v26 == v13;
    bool v28;
    v28 = v27 == false;
    if (v28){
        fprintf(stderr, "%s\n", "The size of the array does not correspond to the amount being pickled. One of the combinators is faulty.")
        exit(EXIT_FAILURE);
    } else {
    }
    Mut0 * v29;
    v29 = MutCreate0(0l);
    int32_t v30;
    v30 = v29->v0;
    int32_t v31;
    v31 = v30 + 4l;
    AssignMut0(&(v29->v0), v31);
    int32_t v32;
    v32 = System.BitConverter.ToInt32(v14,v30);
    int32_t v33;
    v33 = v29->v0;
    int32_t v34;
    v34 = v33 + 4l;
    AssignMut0(&(v29->v0), v34);
    int32_t v35;
    v35 = System.BitConverter.ToInt32(v14,v33);
    UH0 * v36;
    v36 = method4(v29, v14);
    int32_t v37;
    v37 = v29->v0;
    MutRefc0(v29, REFC_DECR);
    int32_t v38;
    v38 = v14->len;
    ArrayRefc1(v14, REFC_DECR);
    bool v39;
    v39 = v37 == v38;
    bool v40;
    v40 = v39 == false;
    if (v40){
        fprintf(stderr, "%s\n", "The size of the array does not correspond to the amount being unpickled. One of the combinators is faulty or the data is malformed.")
        exit(EXIT_FAILURE);
    } else {
    }
    bool v41;
    v41 = v0 == v32;
    bool v45;
    if (v41){
        bool v42;
        v42 = v1 == v35;
        if (v42){
            v45 = method5(v36, v10);
        } else {
            v45 = false;
        }
    } else {
        v45 = false;
    }
    UHRefc0(v10, REFC_DECR); UHRefc0(v36, REFC_DECR);
    bool v46;
    v46 = v45 == false;
    if (v46){
        fprintf(stderr, "%s\n", "Serialization and deserialization should result in the same result.")
        exit(EXIT_FAILURE);
    } else {
    }
    return 0l;
}
int32_t main(){
    return method0();
}
