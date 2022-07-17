#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int64_t v2;
    float v1;
    char v0;
} Tuple0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*refc_fptr)(Fun0 *, REFC_FLAG);
    Tuple0 (*fptr)(Fun0 *);
};
typedef struct {
    int64_t v2;
    float v1;
    char v0;
} ClosureEnv0;
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*refc_fptr)(Closure0 *, REFC_FLAG);
    Tuple0 (*fptr)(Closure0 *);
    ClosureEnv0 env[];
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
Tuple0 ClosureMethod0(Closure0 * x){
    ClosureEnv0 * env = x->env;
    char v0 = env->v0; float v1 = env->v1; int64_t v2 = env->v2;
    return TupleCreate0(v0, v1, v2);
}
Fun0 * ClosureCreate0(char v0, float v1, int64_t v2){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    x->refc = 1;
    x->refc_fptr = ClosureRefc0;
    x->fptr = ClosureMethod0;
    ClosureEnv0 * env = x->env;
    env->v0 = v0; env->v1 = v1; env->v2 = v2;
    ClosureRefcBody0(x, REFC_INCR);
    return (Fun0 *) x;
}
static inline void HeapRefcBody0(Heap0 * x, REFC_FLAG q){
}
void HeapRefc0(Heap0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            HeapRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Heap0 * HeapCreate0(char v0, float v1, int64_t v2){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1; x->v2 = v2;
    HeapRefcBody0(x, REFC_INCR);
    return x;
}
int32_t main(){
    char v0; float v1; int64_t v2;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2;
    Fun0 * v3;
    v3 = ClosureCreate0(v0, v1, v2);
    v3->refc_fptr(v3, REFC_DECR);
    Heap0 * v4;
    v4 = HeapCreate0(v0, v1, v2);
    HeapRefc0(v4, REFC_DECR);
    return 0l;
}
