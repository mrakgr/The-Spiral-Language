#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int refc;
    int32_t v0;
    int32_t v1;
} Heap0;
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
Heap0 * HeapCreate0(int32_t v0, int32_t v1){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 0;
        x->v0 = v0; x->v1 = v1;
    HeapRefcBody0(x, REFC_INCR);
    return x;
}
int32_t main(){
    Heap0 * v0;
    v0 = HeapCreate0(1l, 2l);
    HeapRefc0(v0, REFC_INCR);
    int32_t v1;
    v1 = v0->v0;
    int32_t v2;
    v2 = v0->v1;
    HeapRefc0(v0, REFC_DECR);
    int32_t v3;
    v3 = v1 + v2;
    return v3;
}
