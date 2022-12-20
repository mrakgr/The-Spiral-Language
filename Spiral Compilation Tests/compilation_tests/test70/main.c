#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int64_t v2;
    float v1;
    char v0;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*decref_fptr)(Fun0 *);
    Tuple0 (*fptr)(Fun0 *);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    Tuple0 (*fptr)(Closure0 *);
    int64_t v2;
    float v1;
    char v0;
};
typedef struct {
    int refc;
    int64_t v2;
    float v1;
    char v0;
} Heap0;
static inline Tuple0 TupleCreate0(char v0, float v1, int64_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method0(){
    return TupleCreate0('a', 2.0f, 3ll);
}
static inline void ClosureDecrefBody0(Closure0 * x){
}
void ClosureDecref0(Closure0 * x){
    if (x != NULL && --(x->refc) == 0) { ClosureDecrefBody0(x); free(x); }
}
Tuple0 ClosureMethod0(Closure0 * x){
    char v0 = x->v0; float v1 = x->v1; int64_t v2 = x->v2;
    return TupleCreate0(v0, v1, v2);
}
Fun0 * ClosureCreate0(char v0, float v1, int64_t v2){
    Closure0 * x = malloc(sizeof(Closure0));
    x->refc = 1;
    x->decref_fptr = ClosureDecref0;
    x->fptr = ClosureMethod0;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return (Fun0 *) x;
}
static inline void HeapDecrefBody0(Heap0 * x){
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(char v0, float v1, int64_t v2){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    return x;
}
int32_t main(){
    char v0; float v1; int64_t v2;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2;
    Fun0 * v3;
    v3 = ClosureCreate0(v0, v1, v2);
    v3->decref_fptr(v3);
    Heap0 * v4;
    v4 = HeapCreate0(v0, v1, v2);
    HeapDecref0(v4);
    return 0l;
}
