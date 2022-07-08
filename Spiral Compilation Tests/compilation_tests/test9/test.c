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
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    Tuple0 (*fptr)(char *, String *);
    char env[];
} Fun0;
typedef struct {
    Fun0 * (*fptr)(char *, double, float, double);
    char env[];
} Fun2;
typedef struct {
    Fun2 * (*fptr)(char *, int32_t);
    char env[];
} Fun1;
typedef struct {
    int32_t v0;
    double v1;
    float v2;
    double v3;
} ClosureEnv2;
typedef struct {
    Tuple0 (*fptr)(ClosureEnv2 *, String *);
    ClosureEnv2 env[];
} Closure2;
typedef struct {
    int32_t v0;
} ClosureEnv1;
typedef struct {
    Fun0 * (*fptr)(ClosureEnv1 *, double, float, double);
    ClosureEnv1 env[];
} Closure1;
typedef struct {
} ClosureEnv0;
typedef struct {
    Fun2 * (*fptr)(ClosureEnv0 *, int32_t);
    ClosureEnv0 env[];
} Closure0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, double v2, float v3, double v4){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4;
    return x;
}
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
Tuple0 method4(int32_t v0, double v1, float v2, double v3){
    return TupleCreate0(1l, v0, v1, v2, v3);
}
Tuple0 ClosureMethod2(ClosureEnv2 * env, String * v4){
    int32_t v0 = env->v0; double v1 = env->v1; float v2 = env->v2; double v3 = env->v3;
    return method4(v0, v1, v2, v3);
}
Fun0 * ClosureCreate2(int32_t v0, double v1, float v2, double v3){
    Closure2 * x = malloc(sizeof(Closure2) + sizeof(ClosureEnv2));
    ClosureEnv2 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2; env->v3 = v3;
    x->fptr = ClosureMethod2;
    return (Fun0 *) x;
}
Fun0 * method3(int32_t v0, double v1, float v2, double v3){
    return ClosureCreate2(v0, v1, v2, v3);
}
Fun0 * ClosureMethod1(ClosureEnv1 * env, double v1, float v2, double v3){
    int32_t v0 = env->v0;
    return method3(v0, v1, v2, v3);
}
Fun2 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1) + sizeof(ClosureEnv1));
    ClosureEnv1 * env = x->env;
    env->v0 = v0;
    x->fptr = ClosureMethod1;
    return (Fun2 *) x;
}
Fun2 * method2(int32_t v0){
    return ClosureCreate1(v0);
}
Fun2 * ClosureMethod0(ClosureEnv0 * env, int32_t v0){
    return method2(v0);
}
Fun1 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    x->fptr = ClosureMethod0;
    return (Fun1 *) x;
}
Fun1 * method1(){
    return ClosureCreate0();
}
Fun0 * method0(){
    Fun1 * v0;
    v0 = method1();
    Fun2 * v1;
    v1 = v0->fptr(v0->env, 2l);
    return v1->fptr(v1->env, 2.2, 3.0f, 4.5);
}
int32_t main(){
    Fun0 * v0;
    v0 = method0();
    int32_t v1; int32_t v2; double v3; float v4; double v5;
    Tuple0 tmp0 = v0->fptr(v0->env, StringLit(3, "qwe"));
    v1 = tmp0.v0; v2 = tmp0.v1; v3 = tmp0.v2; v4 = tmp0.v3; v5 = tmp0.v4;
    return v1 + v2;
}
