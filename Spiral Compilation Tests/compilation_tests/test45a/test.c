#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int tag;
    union {
    };
} US0;
typedef struct {
    uint32_t len;
    US0 ptr[];
} Array0;
typedef struct {
    uint64_t v0;
} Mut0;
US0 US0_0() { // Empty
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // Princess
    US0 x;
    x.tag = 1;
    return x;
}
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(US0) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, US0 * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(US0) * size);
    return x;
}
static inline Mut0 * MutCreate0(uint64_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->v0 = v0;
    return x;
}
bool method0(Mut0 * v0){
    uint64_t v1;
    v1 = v0->v0;
    return v1 < 1ull;
}
void main(){
    Array0 * v0;
    v0 = ArrayCreate0(1ull);
    Mut0 * v1;
    v1 = MutCreate0(0ull);
    while (method0(v1)){
        uint64_t v3;
        v3 = v1->v0;
        US0 v4;
        v4 = US0_1();
        v0->ptr[v3] = v4;
        uint64_t v5;
        v5 = v3 + 1ull;
        v1->v0 = v5;
    }
    return ;
}
