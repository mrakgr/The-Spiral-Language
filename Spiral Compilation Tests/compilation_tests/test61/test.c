#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    uint32_t len;
    int32_t ptr[];
} Array0;
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(int32_t) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, int32_t * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(int32_t) * size);
    return x;
}
int32_t main(){
    Array0 * v0;
    v0 = ArrayLit0(10,(int32_t []){1l,2l,3l});
    uint64_t v1;
    v1 = v0->len;;
    bool v2;
    v2 = v1 == 3ull;
    if (v2){
        int32_t v3;
        v3 = v0->ptr[0l];
        int32_t v4;
        v4 = v0->ptr[1l];
        int32_t v5;
        v5 = v0->ptr[2l];
        int32_t v6;
        v6 = v3 + v4;
        return v6 + v5;
    } else {
        bool v8;
        v8 = v1 == 2ull;
        if (v8){
            int32_t v9;
            v9 = v0->ptr[0l];
            int32_t v10;
            v10 = v0->ptr[1l];
            return v9 + v10;
        } else {
            bool v12;
            v12 = v1 == 1ull;
            if (v12){
                return v0->ptr[0l];
            } else {
                return 0l;
            }
        }
    }
}
