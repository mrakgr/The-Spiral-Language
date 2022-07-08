#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Mut0;
static inline Mut0 * MutCreate0(int32_t v0, int32_t v1){
    Mut0 * x = malloc(sizeof(Mut0));
    x->v0 = v0; x->v1 = v1;
    return x;
}
void main(){
    Mut0 * v0;
    v0 = MutCreate0(1l, 2l);
    v0->v0 = 3l;
    v0->v1 = 4l;
}
