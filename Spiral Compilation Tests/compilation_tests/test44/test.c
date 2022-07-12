#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
typedef struct UH1 UH1;
typedef struct UH2 UH2;
typedef struct UH3 UH3;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            int32_t v0;
            UH0 * v1;
        } case0; // Cons
    };
};
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            String * v0;
            UH1 * v1;
        } case0; // Cons
    };
};
struct UH2 {
    int refc;
    int tag;
    union {
        struct {
            bool v0;
            UH2 * v1;
        } case0; // Cons
    };
};
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            int32_t v0;
            String * v1;
            bool v2;
            UH3 * v3;
        } case0; // Cons
    };
};
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v1, q);
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
UH0 * UH0_0(int32_t v0, UH0 * v1) { // Cons
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
Array0 * ArrayCreate0(uint32_t size, bool init_at_zero){
    size = sizeof(Array0) + sizeof(char) * size;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size, false);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc0(x, q);
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
static inline void UHRefcBody1(UH1 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            StringRefc(x.case0.v0, q); UHRefc1(x.case0.v1, q);
            break;
        }
    }
}
void UHRefc1(UH1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody1(*x, REFC_DECR);
            free(x);
        }
    }
}
UH1 * UH1_0(String * v0, UH1 * v1) { // Cons
    UH1 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody1(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH1)),&x,sizeof(UH1));
}
UH1 * UH1_1() { // Nil
    UH1 x;
    x.tag = 1;
    UHRefcBody1(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH1)),&x,sizeof(UH1));
}
static inline void UHRefcBody2(UH2 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc2(x.case0.v1, q);
            break;
        }
    }
}
void UHRefc2(UH2 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody2(*x, REFC_DECR);
            free(x);
        }
    }
}
UH2 * UH2_0(bool v0, UH2 * v1) { // Cons
    UH2 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody2(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH2)),&x,sizeof(UH2));
}
UH2 * UH2_1() { // Nil
    UH2 x;
    x.tag = 1;
    UHRefcBody2(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH2)),&x,sizeof(UH2));
}
static inline void UHRefcBody3(UH3 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            StringRefc(x.case0.v1, q); UHRefc3(x.case0.v3, q);
            break;
        }
    }
}
void UHRefc3(UH3 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody3(*x, REFC_DECR);
            free(x);
        }
    }
}
UH3 * UH3_0(int32_t v0, String * v1, bool v2, UH3 * v3) { // Cons
    UH3 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2; x.case0.v3 = v3;
    UHRefcBody3(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH3)),&x,sizeof(UH3));
}
UH3 * UH3_1() { // Nil
    UH3 x;
    x.tag = 1;
    UHRefcBody3(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH3)),&x,sizeof(UH3));
}
UH3 * method3(int32_t v0, String * v1, UH2 * v2, UH3 * v3){
    StringRefc(v1, REFC_INCR); UHRefc2(v2, REFC_INCR); UHRefc3(v3, REFC_INCR);
    switch (v2->tag) {
        case 0: { // Cons
            bool v4 = v2->case0.v0; UH2 * v5 = v2->case0.v1;
            UHRefc2(v2, REFC_DECR);
            UH3 * v6;
            v6 = method3(v0, v1, v5, v3);
            UHRefc3(v6, REFC_INCR);
            UHRefc3(v3, REFC_DECR);
            StringRefc(v1, REFC_SUPPR); UHRefc3(v6, REFC_SUPPR);
            return UH3_0(v0, v1, v4, v6);
            break;
        }
        case 1: { // Nil
            StringRefc(v1, REFC_DECR); UHRefc2(v2, REFC_DECR);
            UHRefc3(v3, REFC_SUPPR);
            return v3;
            break;
        }
    }
}
UH3 * method4(UH3 * v0, UH3 * v1){
    UHRefc3(v0, REFC_INCR); UHRefc3(v1, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; String * v3 = v0->case0.v1; bool v4 = v0->case0.v2; UH3 * v5 = v0->case0.v3;
            UHRefc3(v0, REFC_DECR);
            UH3 * v6;
            v6 = method4(v5, v1);
            UHRefc3(v6, REFC_INCR);
            UHRefc3(v1, REFC_DECR);
            StringRefc(v3, REFC_SUPPR); UHRefc3(v6, REFC_SUPPR);
            return UH3_0(v2, v3, v4, v6);
            break;
        }
        case 1: { // Nil
            UHRefc3(v0, REFC_DECR);
            UHRefc3(v1, REFC_SUPPR);
            return v1;
            break;
        }
    }
}
UH3 * method2(UH2 * v0, int32_t v1, UH1 * v2, UH3 * v3){
    UHRefc2(v0, REFC_INCR); UHRefc1(v2, REFC_INCR); UHRefc3(v3, REFC_INCR);
    switch (v2->tag) {
        case 0: { // Cons
            String * v4 = v2->case0.v0; UH1 * v5 = v2->case0.v1;
            UHRefc1(v2, REFC_DECR);
            UH3 * v6;
            v6 = method2(v0, v1, v5, v3);
            UHRefc3(v6, REFC_INCR);
            UHRefc3(v3, REFC_DECR);
            UH3 * v7;
            v7 = UH3_1();
            UHRefc3(v7, REFC_INCR);
            UH3 * v8;
            v8 = method3(v1, v4, v0, v7);
            UHRefc3(v8, REFC_INCR);
            UHRefc2(v0, REFC_DECR); UHRefc3(v7, REFC_DECR);
            UHRefc3(v8, REFC_SUPPR); UHRefc3(v6, REFC_SUPPR);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            UHRefc2(v0, REFC_DECR); UHRefc1(v2, REFC_DECR);
            UHRefc3(v3, REFC_SUPPR);
            return v3;
            break;
        }
    }
}
UH3 * method1(UH1 * v0, UH2 * v1, UH0 * v2, UH3 * v3){
    UHRefc1(v0, REFC_INCR); UHRefc2(v1, REFC_INCR); UHRefc0(v2, REFC_INCR); UHRefc3(v3, REFC_INCR);
    switch (v2->tag) {
        case 0: { // Cons
            int32_t v4 = v2->case0.v0; UH0 * v5 = v2->case0.v1;
            UHRefc0(v2, REFC_DECR);
            UH3 * v6;
            v6 = method1(v0, v1, v5, v3);
            UHRefc3(v6, REFC_INCR);
            UHRefc3(v3, REFC_DECR);
            UH3 * v7;
            v7 = UH3_1();
            UHRefc3(v7, REFC_INCR);
            UH3 * v8;
            v8 = method2(v1, v4, v0, v7);
            UHRefc3(v8, REFC_INCR);
            UHRefc1(v0, REFC_DECR); UHRefc2(v1, REFC_DECR); UHRefc3(v7, REFC_DECR);
            UHRefc3(v8, REFC_SUPPR); UHRefc3(v6, REFC_SUPPR);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            UHRefc1(v0, REFC_DECR); UHRefc2(v1, REFC_DECR); UHRefc0(v2, REFC_DECR);
            UHRefc3(v3, REFC_SUPPR);
            return v3;
            break;
        }
    }
}
UH3 * method0(UH0 * v0, UH1 * v1, UH2 * v2){
    UHRefc0(v0, REFC_INCR); UHRefc1(v1, REFC_INCR); UHRefc2(v2, REFC_INCR);
    UH3 * v3;
    v3 = UH3_1();
    UHRefc3(v3, REFC_INCR);
    UHRefc1(v1, REFC_SUPPR); UHRefc2(v2, REFC_SUPPR); UHRefc0(v0, REFC_SUPPR); UHRefc3(v3, REFC_SUPPR);
    return method1(v1, v2, v0, v3);
}
void method5(UH3 * v0){
    UHRefc3(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v1 = v0->case0.v0; String * v2 = v0->case0.v1; bool v3 = v0->case0.v2; UH3 * v4 = v0->case0.v3;
            UHRefc3(v0, REFC_DECR);
            printf("%i %s %i\n",v1, v2->ptr, (int) v3);
            UHRefc3(v4, REFC_SUPPR);
            return method5(v4);
            break;
        }
        case 1: { // Nil
            UHRefc3(v0, REFC_DECR);
            return ;
            break;
        }
    }
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    int32_t v2;
    v2 = 3l;
    UH0 * v3;
    v3 = UH0_1();
    UHRefc0(v3, REFC_INCR);
    UH0 * v4;
    v4 = UH0_0(v2, v3);
    UHRefc0(v4, REFC_INCR);
    UHRefc0(v3, REFC_DECR);
    UH0 * v5;
    v5 = UH0_0(v1, v4);
    UHRefc0(v5, REFC_INCR);
    UHRefc0(v4, REFC_DECR);
    UH0 * v6;
    v6 = UH0_0(v0, v5);
    UHRefc0(v6, REFC_INCR);
    UHRefc0(v5, REFC_DECR);
    String * v7;
    v7 = StringLit(1, "a");
    StringRefc(v7, REFC_INCR);
    String * v8;
    v8 = StringLit(1, "b");
    StringRefc(v8, REFC_INCR);
    UH1 * v9;
    v9 = UH1_1();
    UHRefc1(v9, REFC_INCR);
    UH1 * v10;
    v10 = UH1_0(v8, v9);
    UHRefc1(v10, REFC_INCR);
    StringRefc(v8, REFC_DECR); UHRefc1(v9, REFC_DECR);
    UH1 * v11;
    v11 = UH1_0(v7, v10);
    UHRefc1(v11, REFC_INCR);
    StringRefc(v7, REFC_DECR); UHRefc1(v10, REFC_DECR);
    bool v12;
    v12 = true;
    UH2 * v13;
    v13 = UH2_1();
    UHRefc2(v13, REFC_INCR);
    UH2 * v14;
    v14 = UH2_0(v12, v13);
    UHRefc2(v14, REFC_INCR);
    UHRefc2(v13, REFC_DECR);
    UH3 * v15;
    v15 = method0(v6, v11, v14);
    UHRefc3(v15, REFC_INCR);
    UHRefc0(v6, REFC_DECR); UHRefc1(v11, REFC_DECR); UHRefc2(v14, REFC_DECR);
    method5(v15);
    UHRefc3(v15, REFC_DECR);
    return 0l;
}
