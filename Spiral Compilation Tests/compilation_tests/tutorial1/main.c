#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    float ptr[];
} Array0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(float) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, float * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(float) * len);
    return x;
}
static inline void AssignArray0(float * a, float b){
    *a = b;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1ull, false);
    float v1;
    v1 = v0->ptr[0ull];
    AssignArray0(&(v0->ptr[0ull]), v1);
    ArrayDecref0(v0);
    return 0l;
}
