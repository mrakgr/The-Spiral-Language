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
Array0 * ArrayCreate0(uint32_t size, bool init_at_zero){
    size = sizeof(Array0) + sizeof(char) * size;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 0;
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size, false);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    ArrayRefcBody0(x, REFC_INCR);
    return x;
}
static inline void StringRefc(String * x, REFC_FLAG q){
    return ArrayRefc0(x, q);
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
int32_t main(){
    String * v0;
    v0 = StringLit(1, "0");
    StringRefc(v0, REFC_INCR);
    StringRefc(v0, REFC_DECR);
    int32_t v1;
    v1 = 0l;
    String * v2;
    v2 = StringLit(1, "1");
    StringRefc(v2, REFC_INCR);
    StringRefc(v2, REFC_DECR);
    int32_t v3;
    v3 = 1l;
    String * v4;
    v4 = StringLit(5, "false");
    StringRefc(v4, REFC_INCR);
    StringRefc(v4, REFC_DECR);
    bool v5;
    v5 = false;
    String * v6;
    v6 = StringLit(4, "true");
    StringRefc(v6, REFC_INCR);
    StringRefc(v6, REFC_DECR);
    bool v7;
    v7 = true;
    String * v8;
    v8 = StringLit(3, "asd");
    StringRefc(v8, REFC_INCR);
    StringRefc(v8, REFC_DECR);
    String * v9;
    v9 = StringLit(3, "asd");
    StringRefc(v9, REFC_INCR);
    StringRefc(v9, REFC_DECR);
    String * v10;
    v10 = StringLit(3, "1i8");
    StringRefc(v10, REFC_INCR);
    StringRefc(v10, REFC_DECR);
    int8_t v11;
    v11 = 1;
    String * v12;
    v12 = StringLit(3, "5.5");
    StringRefc(v12, REFC_INCR);
    StringRefc(v12, REFC_DECR);
    double v13;
    v13 = 5.5;
    String * v14;
    v14 = StringLit(7, "unknown");
    StringRefc(v14, REFC_INCR);
    StringRefc(v14, REFC_DECR);
    double v15;
    v15 = 5.0;
    return 0l;
}
