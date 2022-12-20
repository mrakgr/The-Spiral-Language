#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int refc;
    uint32_t len;
} Array0;
typedef struct {
    int refc;
    uint64_t v0;
} Mut0;
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
static inline void MutDecrefBody0(Mut0 * x){
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(uint64_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
bool method0(Mut0 * v0){
    v0->refc++;
    uint64_t v1;
    v1 = v0->v0;
    MutDecref0(v0);
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
    Mut0 * v1;
    v1 = MutCreate0(0ull);
    while (method0(v1)){
        uint64_t v3;
        v3 = v1->v0;
        /* void array set */;
        uint64_t v4;
        v4 = v3 + 1ull;
        AssignMut0(&(v1->v0), v4);
    }
    ArrayDecref0(v0);
    MutDecref0(v1);
    return 0l;
}
