#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
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
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
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
    return x;
}
static inline void ArrayDecrefBody2(Array2 * x){
}
void ArrayDecref2(Array2 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody2(x); free(x); }
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
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref2(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit2(len, ptr);
}
static inline void ArrayDecrefBody1(Array1 * x){
    uint32_t len = x->len;
    String * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        String * v = ptr[i];
        StringDecref(v);
    }
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
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
        for (uint32_t i=0; i < len; i++){
            String * v = ptr[i];
            v->refc++;
        }
    return x;
}
static inline void ArrayDecrefBody3(Array3 * x){
}
void ArrayDecref3(Array3 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody3(x); free(x); }
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
    return x;
}
static inline void AssignArray0(bool * a, bool b){
    *a = b;
}
static inline void AssignArray1(String * * a, String * b){
    b->refc++;
    StringDecref(*a);
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
    StringDecref(v5);
    AssignArray2(&(v2->ptr[0l]), 2l);
    AssignArray0(&(v3->ptr[0l]), false);
    AssignArray0(&(v4->ptr[0l]), true);
    AssignArray0(&(v0->ptr[1l]), false);
    String * v6;
    v6 = StringLit(4, "zxc");
    AssignArray1(&(v1->ptr[1l]), v6);
    StringDecref(v6);
    AssignArray2(&(v2->ptr[1l]), -2l);
    AssignArray0(&(v4->ptr[1l]), false);
    bool v7;
    v7 = v0->ptr[0l];
    ArrayDecref0(v0);
    String * v8;
    v8 = v1->ptr[0l];
    ArrayDecref1(v1);
    int32_t v9;
    v9 = v2->ptr[0l];
    ArrayDecref3(v2);
    bool v10;
    v10 = v3->ptr[0l];
    ArrayDecref0(v3);
    bool v11;
    v11 = v4->ptr[0l];
    ArrayDecref0(v4);
    return 0l;
}
