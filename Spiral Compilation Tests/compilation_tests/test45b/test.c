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
    int32_t ptr[];
} Array1;
typedef struct {
    int refc;
    uint32_t len;
    Array1 * ptr[];
} Array0;
static inline void ArrayRefcBody1(Array1 * x, REFC_FLAG q){
}
void ArrayRefc1(Array1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody1(x, REFC_DECR);
            free(x);
        }
    }
}
Array1 * ArrayCreate1(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array1) + sizeof(int32_t) * len;
    Array1 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array1 * ArrayLit1(uint32_t len, int32_t * ptr){
    Array1 * x = ArrayCreate1(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    ArrayRefcBody1(x, REFC_INCR);
    return x;
}
static inline void ArrayRefcBody0(Array0 * x, REFC_FLAG q){
    for (uint32_t i=0; i < x->len; i++){
        Array1 * v = x->ptr[i];
        ArrayRefc1(v, q);
    }
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
    uint32_t size = sizeof(Array0) + sizeof(Array1 *) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, Array1 * * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Array1 *) * len);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(4ull, true);
    ArrayRefc0(v0, REFC_DECR);
    return 0l;
}
