#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    bool v0;
} Heap0;
typedef struct {
    Heap0 * v0;
    Heap0 * v1;
} Tuple0;
static inline void HeapDecrefBody0(Heap0 * x){
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(bool v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(Heap0 * v0, Heap0 * v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method2(Heap0 * v0){
    v0->refc++;
    return TupleCreate0(v0, v0);
}
Tuple0 method1(Heap0 * v0){
    return method2(v0);
}
Tuple0 method0(Heap0 * v0){
    return method1(v0);
}
int32_t main(){
    bool v0;
    v0 = true;
    Heap0 * v1;
    v1 = HeapCreate0(true);
    Heap0 * v4; Heap0 * v5;
    if (v0){
        v1->refc++;
        Tuple0 tmp0 = method0(v1);
        v4 = tmp0.v0; v5 = tmp0.v1;
    } else {
        v1->refc += 2;
        v4 = v1; v5 = v1;
    }
    HeapDecref0(v1); HeapDecref0(v4); HeapDecref0(v5);
    return 0l;
}
