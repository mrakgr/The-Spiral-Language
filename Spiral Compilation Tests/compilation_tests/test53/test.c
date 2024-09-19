#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    int32_t v0;
    int32_t v1;
} Mut0;
static inline void MutDecrefBody0(Mut0 * x){
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(int32_t v0, int32_t v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0; x->v1 = v1;
    return x;
}
static inline void AssignMut0(int32_t * a0, int32_t b0, int32_t * a1, int32_t b1){
    *a0 = b0; *a1 = b1;
}
int32_t main(){
    Mut0 * v0;
    v0 = MutCreate0(1l, 2l);
    AssignMut0(&(v0->v0), 3l, &(v0->v1), 4l);
    int32_t v1;
    v1 = v0->v0;
    MutDecref0(v0);
    return v1;
}
