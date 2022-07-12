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
    uint64_t v0;
} Mut0;
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
Array0 * ArrayCreate0(uint32_t size, bool init_at_zero){
    size = sizeof(Array0);
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, void * ptr){
    Array0 * x = ArrayCreate0(size, false);
    return x;
}
static inline void MutRefcBody0(Mut0 * x, REFC_FLAG q){
}
void MutRefc0(Mut0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            MutRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Mut0 * MutCreate0(uint64_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 0;
        x->v0 = v0;
    MutRefcBody0(x, REFC_INCR);
    return x;
}
bool method0(Mut0 * v0){
    MutRefc0(v0, REFC_INCR);
    uint64_t v1;
    v1 = v0->v0;
    MutRefc0(v0, REFC_DECR);
    bool v2;
    v2 = v1 < 1ull;
    return v2;
}
static inline void AssignMut0(uint64_t * a0, uint64_t b0){
    *a0 = b0;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1ull, false);
    ArrayRefc0(v0, REFC_INCR);
    Mut0 * v1;
    v1 = MutCreate0(0ull);
    MutRefc0(v1, REFC_INCR);
    while (method0(v1)){
        uint64_t v3;
        v3 = v1->v0;
        /* void array set */;
        uint64_t v4;
        v4 = v3 + 1ull;
        AssignMut0(&v1->v0, v4);
    }
    ArrayRefc0(v0, REFC_DECR);
    MutRefc0(v1, REFC_DECR);
    return 0l;
}
