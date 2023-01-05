#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
    int32_t v1;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(int32_t v0, int32_t v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
int32_t main(){
    Heap0 * v0;
    v0 = HeapCreate0(1l, 2l);
    int32_t v1;
    v1 = v0->v0;
    int32_t v2;
    v2 = v0->v1;
    HeapDecref0(v0);
    int32_t v3;
    v3 = v1 + v2;
    return v3;
}
