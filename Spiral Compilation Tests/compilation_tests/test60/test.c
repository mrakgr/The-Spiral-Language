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
typedef struct {
    int tag;
    union {
        struct {
            String * v0;
            String * v1;
            String * v2;
        } case0; // A
    };
} US0;
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
static inline void USRefcBody0(US0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            StringRefc(x.case0.v0, q); StringRefc(x.case0.v1, q); StringRefc(x.case0.v2, q);
            break;
        }
    }
}
void USRefc0(US0 * x, REFC_FLAG q){
    USRefcBody0(*x, q);
}
US0 US0_0(String * v0, String * v1, String * v2) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
    USRefcBody0(x, REFC_INCR);
    return x;
}
int32_t main(){
    String * v0;
    v0 = StringLit(3, "qwe");
    StringRefc(v0, REFC_INCR);
    String * v1;
    v1 = StringLit(3, "asd");
    StringRefc(v1, REFC_INCR);
    String * v2;
    v2 = StringLit(3, "zxc");
    StringRefc(v2, REFC_INCR);
    US0 v3;
    v3 = US0_0(v0, v1, v2);
    USRefc0(&(v3), REFC_INCR);
    StringRefc(v0, REFC_DECR); StringRefc(v1, REFC_DECR); StringRefc(v2, REFC_DECR);
    switch (v3.tag) {
        case 0: { // A
            String * v4 = v3.case0.v0;
            StringRefc(v4, REFC_INCR);
            USRefc0(&(v3), REFC_DECR);
            int32_t v7;
            v7 = 5l;
            int32_t v8;
            v8 = v4->len;
            StringRefc(v4, REFC_DECR);
            return v8;
            break;
        }
    }
}
