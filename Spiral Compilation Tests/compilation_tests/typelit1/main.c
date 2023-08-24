#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
template <int dim, typename el> struct array { el ar[dim]; };
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    float v0;
    int32_t v1;
} Tuple0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
static inline Tuple0 TupleCreate0(float v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
void method0(array<StringLit(4, "qwe"),Tuple0> v0){
    return ;
}
int32_t main(){
    array<StringLit(4, "qwe"),Tuple0> v0;
    method0(v0);
    return 0l;
}
