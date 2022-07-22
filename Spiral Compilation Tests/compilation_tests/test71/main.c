#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int refc;
    uint32_t len;
} Array0;
typedef struct {
    int refc;
    Array0 * v0;
} Heap0;
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
static inline void HeapRefcBody0(Heap0 * x, REFC_FLAG q){
    Array0 * z0 = x->v0;
    ArrayRefc0(z0, q);
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
Heap0 * HeapCreate0(Array0 * v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    HeapRefcBody0(x, REFC_INCR);
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1l, true);
    Heap0 * v1;
    v1 = HeapCreate0(v0);
    ArrayRefc0(v0, REFC_DECR); HeapRefc0(v1, REFC_DECR);
    return 0l;
}
