#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int64_t v0;
    int64_t v1;
} Tuple0;
typedef struct {
    int refc;
    uint32_t len;
    Tuple0 ptr[];
} Array0;
static inline Tuple0 TupleCreate0(int64_t v0, int64_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(Tuple0) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, Tuple0 * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(Tuple0) * len);
    return x;
}
static inline void AssignArray0(Tuple0 * a, Tuple0 b){
    *a = b;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayCreate0(1l, false);
    AssignArray0(&(v0->ptr[0l]), TupleCreate0(1ll, 2ll));
    int64_t v1; int64_t v2;
    Tuple0 tmp0 = v0->ptr[0l];
    v1 = tmp0.v0; v2 = tmp0.v1;
    ArrayDecref0(v0);
    return 0l;
}
