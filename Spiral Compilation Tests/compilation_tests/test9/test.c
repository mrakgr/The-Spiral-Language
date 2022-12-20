#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    double v2;
    double v4;
    int32_t v0;
    int32_t v1;
    float v3;
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
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *, String *);
};
typedef struct Fun2 Fun2;
struct Fun2{
    int refc;
    void (*decref_fptr)(Fun2 *);
    Fun0 * (*fptr)(Fun2 *, double, float, double);
};
typedef struct Fun1 Fun1;
struct Fun1{
    int refc;
    void (*decref_fptr)(Fun1 *);
    Fun2 * (*fptr)(Fun1 *, int32_t);
};
typedef struct Closure2 Closure2;
struct Closure2 {
    int refc;
    void (*decref_fptr)(Closure2 *);
    Tuple0 (*fptr)(Closure2 *, String *);
    double v1;
    double v3;
    int32_t v0;
    float v2;
};
typedef struct Closure1 Closure1;
struct Closure1 {
    int refc;
    void (*decref_fptr)(Closure1 *);
    Fun0 * (*fptr)(Closure1 *, double, float, double);
    int32_t v0;
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Fun2 * (*fptr)(Closure0 *, int32_t);
};
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, double v2, float v3, double v4){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4;
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
Tuple0 method4(int32_t v0, double v1, float v2, double v3){
    return TupleCreate0(1l, v0, v1, v2, v3);
}
static inline void ClosureDecrefBody2(Closure2 * x){
}
void ClosureDecref2(Closure2 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody2(x); free(x); }
}
Tuple0 ClosureMethod2(Closure2 * x, String * v4){
    int32_t v0 = x->v0; double v1 = x->v1; float v2 = x->v2; double v3 = x->v3;
    v4->refc++;
    StringDecref(v4);
    return method4(v0, v1, v2, v3);
}
Fun0 * ClosureCreate2(int32_t v0, double v1, float v2, double v3){
    Closure2 * x = malloc(sizeof(Closure2));
    x->refc = 1;
    x->decref_fptr = ClosureDecref2;
    x->fptr = ClosureMethod2;
    x->v0 = v0; x->v1 = v1; x->v2 = v2; x->v3 = v3;
    return (Fun0 *) x;
}
Fun0 * method3(int32_t v0, double v1, float v2, double v3){
    return ClosureCreate2(v0, v1, v2, v3);
}
static inline void ClosureDecrefBody1(Closure1 * x){
}
void ClosureDecref1(Closure1 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody1(x); free(x); }
}
Fun0 * ClosureMethod1(Closure1 * x, double v1, float v2, double v3){
    int32_t v0 = x->v0;
    return method3(v0, v1, v2, v3);
}
Fun2 * ClosureCreate1(int32_t v0){
    Closure1 * x = malloc(sizeof(Closure1));
    x->refc = 1;
    x->decref_fptr = ClosureDecref1;
    x->fptr = ClosureMethod1;
    x->v0 = v0;
    return (Fun2 *) x;
}
Fun2 * method2(int32_t v0){
    return ClosureCreate1(v0);
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Fun2 * ClosureMethod0(Closure0 * x, int32_t v0){
    return method2(v0);
}
Fun1 * ClosureCreate0(){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
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
    v1 = v0->fptr(v0, 2l);
    v0->decref_fptr(v0);
    Fun0 * v2;
    v2 = v1->fptr(v1, 2.2, 3.0f, 4.5);
    v1->decref_fptr(v1);
    return v2;
}
int32_t main(){
    Fun0 * v0;
    v0 = method0();
    String * v1;
    v1 = StringLit(4, "qwe");
    int32_t v2; int32_t v3; double v4; float v5; double v6;
    Tuple0 tmp0 = v0->fptr(v0, v1);
    v2 = tmp0.v0; v3 = tmp0.v1; v4 = tmp0.v2; v5 = tmp0.v3; v6 = tmp0.v4;
    v0->decref_fptr(v0); StringDecref(v1);
    int32_t v7;
    v7 = v2 + v3;
    return v7;
}
