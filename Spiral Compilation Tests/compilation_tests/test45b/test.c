#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
static inline void ArrayDecrefBody1(Array1 * x){
}
void ArrayDecref1(Array1 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody1(x); free(x); }
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
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
    uint32_t len = x->len;
    Array1 * * ptr = x->ptr;
    for (uint32_t i=0; i < len; i++){
        Array1 * v = ptr[i];
        ArrayDecref1(v);
    }
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
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
        for (uint32_t i=0; i < len; i++){
            Array1 * v = ptr[i];
            v->refc++;
        }
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(4ull, true);
    ArrayDecref0(v0);
    return 0l;
}
