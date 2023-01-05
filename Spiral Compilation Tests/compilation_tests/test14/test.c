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
    String * v0;
    v0 = StringLit(2, "0");
    StringDecref(v0);
    int32_t v1;
    v1 = 0l;
    String * v2;
    v2 = StringLit(2, "1");
    StringDecref(v2);
    int32_t v3;
    v3 = 1l;
    String * v4;
    v4 = StringLit(6, "false");
    StringDecref(v4);
    bool v5;
    v5 = false;
    String * v6;
    v6 = StringLit(5, "true");
    StringDecref(v6);
    bool v7;
    v7 = true;
    String * v8;
    v8 = StringLit(4, "asd");
    StringDecref(v8);
    String * v9;
    v9 = StringLit(4, "1i8");
    StringDecref(v9);
    int8_t v10;
    v10 = 1;
    String * v11;
    v11 = StringLit(4, "5.5");
    StringDecref(v11);
    double v12;
    v12 = 5.5;
    String * v13;
    v13 = StringLit(8, "unknown");
    StringDecref(v13);
    double v14;
    v14 = 5.0;
    return 0l;
}
