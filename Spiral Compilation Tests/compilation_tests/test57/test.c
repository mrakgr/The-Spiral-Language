#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int refc;
    uint32_t len;
    bool ptr[];
} Array0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array2;
typedef Array2 String;
typedef struct {
    int refc;
    uint32_t len;
    String * ptr[];
} Array1;
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array3;
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
    uint32_t size = sizeof(Array0) + sizeof(bool) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, bool * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(bool) * len);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
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
static inline void ArrayRefcBody1(Array1 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        String * v = x->ptr[i];
        StringRefc(v, q);
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
    uint32_t size = sizeof(Array1) + sizeof(String *) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, String * * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(String *) * len);
    ArrayRefcBody1(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody3(Array3 * x, REFC_FLAG q){
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
    uint32_t size = sizeof(Array3) + sizeof(int32_t) * len;
    Array3 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array3 * ArrayLit3(uint32_t len, int32_t * ptr){
    Array3 * x = ArrayCreate3(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    ArrayRefcBody3(x, REFC_INCR);
    return x;
}
static inline void AssignArray0(bool * a, bool b){
    *a = b;
}
static inline void AssignArray1(String * * a, String * b){
    StringRefc(b, REFC_INCR);
    StringRefc(*a, REFC_DECR);
    *a = b;
}
static inline void AssignArray2(int32_t * a, int32_t b){
    *a = b;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(10l, false);
    Array1 * v1;
    v1 = ArrayCreate1(10l, true);
    Array3 * v2;
    v2 = ArrayCreate3(10l, false);
    Array0 * v3;
    v3 = ArrayCreate0(10l, false);
    Array0 * v4;
    v4 = ArrayCreate0(10l, false);
    AssignArray0(&(v0->ptr[0l]), true);
    String * v5;
    v5 = StringLit(4, "qwe");
    AssignArray1(&(v1->ptr[0l]), v5);
    StringRefc(v5, REFC_DECR);
    AssignArray2(&(v2->ptr[0l]), 2l);
    AssignArray0(&(v3->ptr[0l]), false);
    AssignArray0(&(v4->ptr[0l]), true);
    AssignArray0(&(v0->ptr[1l]), false);
    String * v6;
    v6 = StringLit(4, "zxc");
    AssignArray1(&(v1->ptr[1l]), v6);
    StringRefc(v6, REFC_DECR);
    AssignArray2(&(v2->ptr[1l]), -2l);
    AssignArray0(&(v4->ptr[1l]), false);
    bool v7;
    v7 = v0->ptr[0l];
    ArrayRefc0(v0, REFC_DECR);
    String * v8;
    v8 = v1->ptr[0l];
    ArrayRefc1(v1, REFC_DECR);
    int32_t v9;
    v9 = v2->ptr[0l];
    ArrayRefc3(v2, REFC_DECR);
    bool v10;
    v10 = v3->ptr[0l];
    ArrayRefc0(v3, REFC_DECR);
    bool v11;
    v11 = v4->ptr[0l];
    ArrayRefc0(v4, REFC_DECR);
    return 0l;
}
