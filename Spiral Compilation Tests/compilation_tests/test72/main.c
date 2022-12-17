#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int refc;
    bool v0;
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
Heap0 * HeapCreate0(bool v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    HeapRefcBody0(x, REFC_INCR);
    return x;
}
Heap0 * method2(Heap0 * v0){
    HeapRefc0(v0, REFC_INCR);
    return v0;
}
Heap0 * method1(Heap0 * v0){
    return method2(v0);
}
Heap0 * method0(Heap0 * v0){
    return method1(v0);
}
int32_t main(){
    bool v0;
    v0 = true;
    Heap0 * v1;
    v1 = HeapCreate0(true);
    Heap0 * v3;
    if (v0){
        v3 = method0(v1);
    } else {
        HeapRefc0(v1, REFC_INCR);
        v3 = v1;
    }
    return 0l;
}
