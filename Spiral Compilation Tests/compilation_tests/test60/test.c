#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc++; x->case0.v1->refc++; x->case0.v2->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            StringDecref(x->case0.v0); StringDecref(x->case0.v1); StringDecref(x->case0.v2);
            break;
        }
    }
}
static inline void USSupprefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc--; x->case0.v1->refc--; x->case0.v2->refc--;
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
void USSuppref0(US0 * x){ USSupprefBody0(x); }
US0 US0_0(String * v0, String * v1, String * v2) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
    v0->refc++; v1->refc++; v2->refc++;
    return x;
}
int32_t main(){
    String * v0;
    v0 = StringLit(4, "qwe");
    String * v1;
    v1 = StringLit(4, "asd");
    String * v2;
    v2 = StringLit(4, "zxc");
    US0 v3;
    v3 = US0_0(v0, v1, v2);
    StringDecref(v0); StringDecref(v1); StringDecref(v2);
    switch (v3.tag) {
        case 0: { // A
            String * v4 = v3.case0.v0;
            v4->refc++;
            USDecref0(&(v3));
            int32_t v7;
            v7 = 5l;
            int32_t v8;
            v8 = v4->len-1;
            StringDecref(v4);
            return v8;
            break;
        }
    }
}
