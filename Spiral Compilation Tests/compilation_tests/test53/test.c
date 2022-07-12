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
} Mut0;
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
Mut0 * MutCreate0(int32_t v0, int32_t v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 0;
        x->v0 = v0; x->v1 = v1;
    MutRefcBody0(x, REFC_INCR);
    return x;
}
static inline void AssignMut0(int32_t * a0, int32_t b0, int32_t * a1, int32_t b1){
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    Mut0 * v0;
    v0 = MutCreate0(1l, 2l);
    MutRefc0(v0, REFC_INCR);
    AssignMut0(&(v0->v0), 3l, &(v0->v1), 4l);
    MutRefc0(v0, REFC_DECR);
    return 0l;
}
