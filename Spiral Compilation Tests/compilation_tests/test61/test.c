#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    int32_t ptr[];
} Array0;
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(int32_t) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, int32_t * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(int32_t) * len);
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayLit0(3, (int32_t []){1l,2l,3l});
    uint64_t v1;
    v1 = v0->len;
    bool v2;
    v2 = v1 == 3ull;
    if (v2){
        int32_t v3;
        v3 = v0->ptr[0l];
        int32_t v4;
        v4 = v0->ptr[1l];
        int32_t v5;
        v5 = v0->ptr[2l];
        ArrayDecref0(v0);
        int32_t v6;
        v6 = v3 + v4;
        int32_t v7;
        v7 = v6 + v5;
        return v7;
    } else {
        bool v8;
        v8 = v1 == 2ull;
        if (v8){
            int32_t v9;
            v9 = v0->ptr[0l];
            int32_t v10;
            v10 = v0->ptr[1l];
            ArrayDecref0(v0);
            int32_t v11;
            v11 = v9 + v10;
            return v11;
        } else {
            bool v12;
            v12 = v1 == 1ull;
            if (v12){
                int32_t v13;
                v13 = v0->ptr[0l];
                ArrayDecref0(v0);
                return v13;
            } else {
                ArrayDecref0(v0);
                return 0l;
            }
        }
    }
}
