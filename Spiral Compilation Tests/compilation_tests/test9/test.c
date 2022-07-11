#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
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
static inline void ArrayRefcBody0(Array0 * x, int c){
}
void ArrayRefc0(Array0 * x, int c){
    if (x != NULL) {
        if ((x->refc += c) == 0) {
            ArrayRefcBody0(x, -1);
            free(x);
        }
    }
}
Array0 * ArrayCreate0(uint32_t size, bool init_at_zero){
    x->refc = 0;
    Array0 * x = (init_at_zero ? calloc : malloc)(sizeof(Array0) + sizeof(char) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size, false);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    ArrayRefcBody(x,1);
    return x;
}
static inline void StringRefc(String * x, int c){
    return ArrayRefc0(x, c);
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
Tuple0 method4(int32_t v0, double v1, float v2, double v3){
    return TupleCreate0(1l, v0, v1, v2, v3);
}
static inline void ClosureRefcBody2(Closure2 * x, int c){
}
void ClosureRefc2(Closure2 * x, int c){
    if (x != NULL) {
        if ((x->refc += c) == 0) {
            ClosureRefcBody2(x, -1);
            free(x);
        }
    }
}
Tuple0 ClosureMethod2(Closure2 * x, String * v4){
    ClosureEnv2 * env = x->env;
    int32_t v0 = env->v0; double v1 = env->v1; float v2 = env->v2; double v3 = env->v3;
    StringRefc(v4, -1);
    return method4(v0, v1, v2, v3);
}
Fun0 * ClosureCreate2(int32_t v0, double v1, float v2, double v3){
    Closure2 * x = malloc(sizeof(Closure2) + sizeof(ClosureEnv2));
    x->refc = 0;
    x->refc_fptr = ClosurRefc2;
    x->fptr = ClosureMethod2;
    ClosureEnv2 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2; env->v3 = v3;
    ClosureRefcBody2(x,1);
    return (Fun0 *) x;
}
Fun0 * method3(int32_t v0, double v1, float v2, double v3){
    return ClosureCreate2(v0, v1, v2, v3);
}
static inline void ClosureRefcBody1(Closure1 * x, int c){
}
void ClosureRefc1(Closure1 * x, int c){
    if (x != NULL) {
        if ((x->refc += c) == 0) {
            ClosureRefcBody1(x, -1);
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
    x->refc_fptr = ClosurRefc1;
    x->fptr = ClosureMethod1;
    ClosureEnv1 * env = x->env;
    env->v0 = v0;
    ClosureRefcBody1(x,1);
    return (Fun2 *) x;
}
Fun2 * method2(int32_t v0){
    return ClosureCreate1(v0);
}
static inline void ClosureRefcBody0(Closure0 * x, int c){
}
void ClosureRefc0(Closure0 * x, int c){
    if (x != NULL) {
        if ((x->refc += c) == 0) {
            ClosureRefcBody0(x, -1);
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
    x->refc_fptr = ClosurRefc0;
    x->fptr = ClosureMethod0;
    return (Fun1 *) x;
}
Fun1 * method1(){
    return ClosureCreate0();
}
Fun0 * method0(){
    Fun1 * v0;
    v0 = method1();
    v0->refc_fptr(v0, 1);
    Fun2 * v1;
    v1 = v0->fptr(v0, 2l);
    v1->refc_fptr(v1, 1);
    v0->refc_fptr(v0, -1);
    return v1->fptr(v1, 2.2, 3.0f, 4.5);
}
int32_t main(){
    Fun0 * v0;
    v0 = method0();
    v0->refc_fptr(v0, 1);
    int32_t v1; int32_t v2; double v3; float v4; double v5;
    Tuple0 tmp0 = v0->fptr(v0, StringLit(3, "qwe"));
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2; v4 = tmp0.v3; v5 = tmp0.v4;
    v0->refc_fptr(v0, -1);
    return v1 + v2;
}
