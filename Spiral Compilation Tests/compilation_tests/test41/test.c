#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            UH0 * v2;
        } case0; // Cons
    };
};
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v2, q);
            break;
        }
    }
}
void UHRefc0(UH0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody0(*x, REFC_DECR);
            free(x);
        }
    }
}
UH0 * UH0_0(int32_t v0, int32_t v1, UH0 * v2) { // Cons
    UH0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1() { // Nil
    UH0 x;
    x.tag = 1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
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
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    int32_t v2;
    v2 = 4l;
    int32_t v3;
    v3 = 5l;
    int32_t v4;
    v4 = 5l;
    int32_t v5;
    v5 = 6l;
    UH0 * v6;
    v6 = UH0_1();
    UHRefc0(v6, REFC_INCR);
    UH0 * v7;
    v7 = UH0_0(v4, v5, v6);
    UHRefc0(v7, REFC_INCR);
    UHRefc0(v6, REFC_DECR);
    UH0 * v8;
    v8 = UH0_0(v2, v3, v7);
    UHRefc0(v8, REFC_INCR);
    UHRefc0(v7, REFC_DECR);
    UH0 * v9;
    v9 = UH0_0(v0, v1, v8);
    UHRefc0(v9, REFC_INCR);
    UHRefc0(v8, REFC_DECR);
    String * v32; int32_t v33;
    switch (v9->tag) {
        case 0: { // Cons
            int32_t v10 = v9->case0.v0; int32_t v11 = v9->case0.v1; UH0 * v12 = v9->case0.v2;
            switch (v12->tag) {
                case 0: { // Cons
                    int32_t v13 = v12->case0.v0; int32_t v14 = v12->case0.v1; UH0 * v15 = v12->case0.v2;
                    switch (v15->tag) {
                        case 0: { // Cons
                            int32_t v16 = v15->case0.v0; int32_t v17 = v15->case0.v1; UH0 * v18 = v15->case0.v2;
                            int32_t v19;
                            v19 = v10 + v11;
                            int32_t v20;
                            v20 = v19 + v13;
                            int32_t v21;
                            v21 = v20 + v14;
                            int32_t v22;
                            v22 = v21 + v16;
                            int32_t v23;
                            v23 = v22 + v17;
                            v32 = StringLit(24, "At least three elements."); v33 = v23;
                            break;
                        }
                        case 1: { // Nil
                            int32_t v24;
                            v24 = v10 + v11;
                            int32_t v25;
                            v25 = v24 + v13;
                            int32_t v26;
                            v26 = v25 + v14;
                            v32 = StringLit(13, "Two elements."); v33 = v26;
                            break;
                        }
                    }
                    break;
                }
                case 1: { // Nil
                    int32_t v29;
                    v29 = v10 + v11;
                    v32 = StringLit(12, "One element."); v33 = v29;
                    break;
                }
            }
            break;
        }
        case 1: { // Nil
            v32 = StringLit(11, "No elements"); v33 = 0l;
            break;
        }
    }
    StringRefc(v32, REFC_INCR);
    UHRefc0(v9, REFC_DECR);
    printf("%s\n%i\n",v32->ptr,v33);
    StringRefc(v32, REFC_DECR);
    return 0l;
}
