#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayRefcBody0(Array0 * x, REFC_FLAG q){
}
void ArrayRefc0(Array0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ArrayRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc0(x, q);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    String * v1;
    v1 = StringLit(3, "qwe");
    StringRefc(v1, REFC_INCR);
    StringRefc(v1, REFC_DECR);
    int32_t v2;
    v2 = 2l;
    String * v3;
    v3 = StringLit(3, "asd");
    StringRefc(v3, REFC_INCR);
    StringRefc(v3, REFC_DECR);
    int32_t v4;
    v4 = hash v0;
    int32_t v5;
    v5 = hash v2;
    int32_t v6;
    v6 = 1l;
    double v7;
    v7 = 2.0;
    int32_t v8;
    v8 = hash v6;
    int32_t v9;
    v9 = v8 * 31l;
    int32_t v10;
    v10 = hash v7;
    int32_t v11;
    v11 = v9 + v10;
    int32_t v12;
    v12 = hash 3l;
    int32_t v13;
    v13 = v12 * 31l;
    int32_t v14;
    v14 = hash 4.0;
    int32_t v15;
    v15 = v13 + v14;
    return 0l;
}
