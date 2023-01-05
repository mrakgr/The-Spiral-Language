#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
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
int32_t main(){
    int32_t v0;
    v0 = 1l;
    String * v1;
    v1 = StringLit(4, "qwe");
    StringDecref(v1);
    int32_t v2;
    v2 = 2l;
    String * v3;
    v3 = StringLit(4, "asd");
    StringDecref(v3);
    bool v4;
    v4 = v0 == v2;
    int32_t v5;
    v5 = 1l;
    double v6;
    v6 = 2.0;
    bool v7;
    v7 = v5 == 3l;
    bool v9;
    if (v7){
        bool v8;
        v8 = v6 == 4.0;
        v9 = v8;
    } else {
        v9 = false;
    }
    return 0l;
}
