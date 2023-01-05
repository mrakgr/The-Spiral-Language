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
    uint8_t v0;
    v0 = 0u;
    bool v1;
    v1 = 0u == v0;
    String * v10;
    if (v1){
        String * v2;
        v2 = StringLit(4, "qwe");
        v10 = v2;
    } else {
        bool v3;
        v3 = 1u == v0;
        if (v3){
            String * v4;
            v4 = StringLit(4, "asd");
            v10 = v4;
        } else {
            bool v5;
            v5 = 2u == v0;
            if (v5){
                String * v6;
                v6 = StringLit(4, "asd");
                v10 = v6;
            } else {
                String * v7;
                v7 = StringLit(4, "zxc");
                v10 = v7;
            }
        }
    }
    StringDecref(v10);
    return 0l;
}
