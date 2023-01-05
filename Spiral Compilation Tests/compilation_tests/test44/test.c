#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct UH2 UH2;
void UHDecref2(UH2 * x);
typedef struct UH3 UH3;
void UHDecref3(UH3 * x);
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
            UH2 * v1;
            bool v0;
        } case0; // Cons
    };
};
struct UH3 {
    int refc;
    int tag;
    union {
        struct {
            String * v1;
            UH3 * v3;
            int32_t v0;
            bool v2;
        } case0; // Cons
    };
};
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
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
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
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 0: {
            StringDecref(x->case0.v0); UHDecref1(x->case0.v1);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_0(String * v0, UH1 * v1) { // Cons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH1 * UH1_1() { // Nil
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void UHDecrefBody2(UH2 * x){
    switch (x->tag) {
        case 0: {
            UHDecref2(x->case0.v1);
            break;
        }
    }
}
void UHDecref2(UH2 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody2(x); free(x); }
}
UH2 * UH2_0(bool v0, UH2 * v1) { // Cons
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH2 * UH2_1() { // Nil
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void UHDecrefBody3(UH3 * x){
    switch (x->tag) {
        case 0: {
            StringDecref(x->case0.v1); UHDecref3(x->case0.v3);
            break;
        }
    }
}
void UHDecref3(UH3 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody3(x); free(x); }
}
UH3 * UH3_0(int32_t v0, String * v1, bool v2, UH3 * v3) { // Cons
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1; x->case0.v2 = v2; x->case0.v3 = v3;
    return x;
}
UH3 * UH3_1() { // Nil
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    x->refc = 1;
    return x;
}
UH3 * method3(int32_t v0, String * v1, UH2 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            bool v4 = v2->case0.v0; UH2 * v5 = v2->case0.v1;
            v1->refc++; v3->refc++; v5->refc += 2;
            UHDecref2(v2);
            UH3 * v6;
            v6 = method3(v0, v1, v5, v3);
            UHDecref3(v3); UHDecref2(v5);
            return UH3_0(v0, v1, v4, v6);
            break;
        }
        case 1: { // Nil
            StringDecref(v1); UHDecref2(v2);
            return v3;
            break;
        }
    }
}
UH3 * method4(UH3 * v0, UH3 * v1){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; String * v3 = v0->case0.v1; bool v4 = v0->case0.v2; UH3 * v5 = v0->case0.v3;
            v1->refc++; v3->refc++; v5->refc += 2;
            UHDecref3(v0);
            UH3 * v6;
            v6 = method4(v5, v1);
            UHDecref3(v1); UHDecref3(v5);
            return UH3_0(v2, v3, v4, v6);
            break;
        }
        case 1: { // Nil
            UHDecref3(v0);
            return v1;
            break;
        }
    }
}
UH3 * method2(UH2 * v0, int32_t v1, UH1 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            String * v4 = v2->case0.v0; UH1 * v5 = v2->case0.v1;
            v0->refc++; v3->refc++; v4->refc++; v5->refc += 2;
            UHDecref1(v2);
            UH3 * v6;
            v6 = method2(v0, v1, v5, v3);
            UHDecref3(v3); UHDecref1(v5);
            UH3 * v7;
            v7 = UH3_1();
            v0->refc++; v4->refc++; v7->refc++;
            UH3 * v8;
            v8 = method3(v1, v4, v0, v7);
            UHDecref2(v0); StringDecref(v4); UHDecref3(v7);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            UHDecref2(v0); UHDecref1(v2);
            return v3;
            break;
        }
    }
}
UH3 * method1(UH1 * v0, UH2 * v1, UH0 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            int32_t v4 = v2->case0.v0; UH0 * v5 = v2->case0.v1;
            v0->refc++; v1->refc++; v3->refc++; v5->refc += 2;
            UHDecref0(v2);
            UH3 * v6;
            v6 = method1(v0, v1, v5, v3);
            UHDecref3(v3); UHDecref0(v5);
            UH3 * v7;
            v7 = UH3_1();
            v0->refc++; v1->refc++; v7->refc++;
            UH3 * v8;
            v8 = method2(v1, v4, v0, v7);
            UHDecref1(v0); UHDecref2(v1); UHDecref3(v7);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            UHDecref1(v0); UHDecref2(v1); UHDecref0(v2);
            return v3;
            break;
        }
    }
}
UH3 * method0(UH0 * v0, UH1 * v1, UH2 * v2){
    UH3 * v3;
    v3 = UH3_1();
    return method1(v1, v2, v0, v3);
}
void method5(UH3 * v0){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v1 = v0->case0.v0; String * v2 = v0->case0.v1; bool v3 = v0->case0.v2; UH3 * v4 = v0->case0.v3;
            v2->refc++; v4->refc++;
            UHDecref3(v0);
            printf("%i %s %i\n",v1, v2->ptr, (int) v3);
            StringDecref(v2);
            return method5(v4);
            break;
        }
        case 1: { // Nil
            UHDecref3(v0);
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
    v3->refc++;
    UH0 * v4;
    v4 = UH0_0(v2, v3);
    v4->refc++;
    UHDecref0(v3);
    UH0 * v5;
    v5 = UH0_0(v1, v4);
    v5->refc++;
    UHDecref0(v4);
    UH0 * v6;
    v6 = UH0_0(v0, v5);
    UHDecref0(v5);
    String * v7;
    v7 = StringLit(2, "a");
    String * v8;
    v8 = StringLit(2, "b");
    UH1 * v9;
    v9 = UH1_1();
    v8->refc++; v9->refc++;
    UH1 * v10;
    v10 = UH1_0(v8, v9);
    v7->refc++; v10->refc++;
    StringDecref(v8); UHDecref1(v9);
    UH1 * v11;
    v11 = UH1_0(v7, v10);
    StringDecref(v7); UHDecref1(v10);
    bool v12;
    v12 = true;
    UH2 * v13;
    v13 = UH2_1();
    v13->refc++;
    UH2 * v14;
    v14 = UH2_0(v12, v13);
    v6->refc++; v11->refc++; v14->refc++;
    UHDecref2(v13);
    UH3 * v15;
    v15 = method0(v6, v11, v14);
    v15->refc++;
    UHDecref0(v6); UHDecref1(v11); UHDecref2(v14);
    method5(v15);
    UHDecref3(v15);
    return 0l;
}
