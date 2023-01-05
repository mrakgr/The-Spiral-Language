#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
} Array0;
typedef struct {
    int refc;
    Array0 * v0;
} Heap0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0);
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, void * ptr){
    Array0 * x = ArrayCreate0(len, false);
    return x;
}
static inline void HeapDecrefBody0(Heap0 * x){
    ArrayDecref0(x->v0);
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(Array0 * v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1l, false);
    v0->refc++;
    Heap0 * v1;
    v1 = HeapCreate0(v0);
    ArrayDecref0(v0); HeapDecref0(v1);
    return 0l;
}
