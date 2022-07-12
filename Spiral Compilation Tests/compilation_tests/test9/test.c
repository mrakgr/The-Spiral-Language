#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int32_t v0;
    int32_t v1;
    double v2;
    float v3;
    double v4;
} Tuple0;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*refc_fptr)(Fun0 *, int);
    Tuple0 (*fptr)(Fun0 *, String *);
};
typedef struct Fun2 Fun2;
struct Fun2{
    int refc;
    void (*refc_fptr)(Fun2 *, int);
    Fun0 * (*fptr)(Fun2 *, double, float, double);
};
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*refc_fptr)(Fun1 *, int);
    Fun2 * (*fptr)(Fun1 *, int32_t);
};
typedef struct {
    int32_t v0;
    double v1;
    float v2;
    double v3;
} ClosureEnv2;
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*refc_fptr)(Closure2 *, int);
    Tuple0 (*fptr)(Closure2 *, String *);
    ClosureEnv2 env[];
};
typedef struct {
    int32_t v0;
} ClosureEnv1;
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*refc_fptr)(Closure1 *, int);
    Fun0 * (*fptr)(Closure1 *, double, float, double);
    ClosureEnv1 env[];
};
typedef struct {
} ClosureEnv0;
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*refc_fptr)(Closure0 *, int);
    Fun2 * (*fptr)(Closure0 *, int32_t);
    ClosureEnv0 env[];
};
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, double v2, float v3, double v4){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4;
    return x;
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
Tuple0 method4(int32_t v0, double v1, float v2, double v3){
    return TupleCreate0(1l, v0, v1, v2, v3);
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
Tuple0 ClosureMethod2(Closure2 * x, String * v4){
    ClosureEnv2 * env = x->env;
    int32_t v0 = env->v0; double v1 = env->v1; float v2 = env->v2; double v3 = env->v3;
    StringRefc(v4, REFC_INCR);
    StringRefc(v4, REFC_DECR);
    return method4(v0, v1, v2, v3);
}
Fun0 * ClosureCreate2(int32_t v0, double v1, float v2, double v3){
    Closure2 * x = malloc(sizeof(Closure2) + sizeof(ClosureEnv2));
    x->refc = 0;
    x->refc_fptr = ClosureRefc2;
    x->fptr = ClosureMethod2;
    ClosureEnv2 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2; env->v3 = v3;
    ClosureRefcBody2(x, REFC_INCR);
    return (Fun0 *) x;
}
Fun0 * method3(int32_t v0, double v1, float v2, double v3){
    return ClosureCreate2(v0, v1, v2, v3);
}
static inline void ClosureRefcBody1(Closure1 * x, REFC_FLAG q){
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
Fun0 * ClosureMethod1(Closure1 * x, double v1, float v2, double v3){
    ClosureEnv1 * env = x->env;
    int32_t v0 = env->v0;
    return method3(v0, v1, v2, v3);
}
Fun2 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1) + sizeof(ClosureEnv1));
    x->refc = 0;
    x->refc_fptr = ClosureRefc1;
    x->fptr = ClosureMethod1;
    ClosureEnv1 * env = x->env;
    env->v0 = v0;
    ClosureRefcBody1(x, REFC_INCR);
    return (Fun2 *) x;
}
Fun2 * method2(int32_t v0){
    return ClosureCreate1(v0);
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
Fun2 * ClosureMethod0(Closure0 * x, int32_t v0){
    return method2(v0);
}
Fun1 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    x->refc = 0;
    x->refc_fptr = ClosureRefc0;
    x->fptr = ClosureMethod0;
    return (Fun1 *) x;
}
Fun1 * method1(){
    return ClosureCreate0();
}
Fun0 * method0(){
    Fun1 * v0;
    v0 = method1();
    v0->refc_fptr(v0, REFC_INCR);
    Fun2 * v1;
    v1 = v0->fptr(v0, 2l);
    v1->refc_fptr(v1, REFC_INCR);
    v0->refc_fptr(v0, REFC_DECR);
    Fun0 * v2;
    v2 = v1->fptr(v1, 2.2, 3.0f, 4.5);
    v2->refc_fptr(v2, REFC_INCR);
    v1->refc_fptr(v1, REFC_DECR);
    v2->refc_fptr(v2, REFC_SUPPR);
    return v2;
}
int32_t main(){
    Fun0 * v0;
    v0 = method0();
    v0->refc_fptr(v0, REFC_INCR);
    int32_t v1; int32_t v2; double v3; float v4; double v5;
    Tuple0 tmp0 = v0->fptr(v0, StringLit(3, "qwe"));
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2; v4 = tmp0.v3; v5 = tmp0.v4;
    v0->refc_fptr(v0, REFC_DECR);
    int32_t v6;
    v6 = v1 + v2;
    return v6;
}
