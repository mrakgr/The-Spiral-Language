#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH0 UH0;
void UHRefc0(UH0 * x, REFC_FLAG q);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            int32_t v0;
            UH0 * v1;
        } case0; // Cons
    };
};
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v1, q);
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
UH0 * UH0_0(int32_t v0, UH0 * v1) { // Cons
    UH0 x;
    x.tag = 0;
    x.refc = 1;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1() { // Nil
    UH0 x;
    x.tag = 1;
    x.refc = 1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
int32_t method0(UH0 * v0, int32_t v1){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; UH0 * v3 = v0->case0.v1;
            UHRefc0(v3, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            int32_t v4;
            v4 = v1 + v2;
            UHRefc0(v3, REFC_SUPPR);
            return method0(v3, v4);
            break;
        }
        case 1: { // Nil
            UHRefc0(v0, REFC_DECR);
            return v1;
            break;
        }
    }
}
int32_t main(){
    int32_t v0;
    v0 = 4l;
    int32_t v1;
    v1 = 5l;
    int32_t v2;
    v2 = 6l;
    UH0 * v3;
    v3 = UH0_1();
    UH0 * v4;
    v4 = UH0_0(v2, v3);
    UHRefc0(v3, REFC_DECR);
    UH0 * v5;
    v5 = UH0_0(v1, v4);
    UHRefc0(v4, REFC_DECR);
    UH0 * v6;
    v6 = UH0_0(v0, v5);
    UHRefc0(v5, REFC_DECR);
    int32_t v7;
    v7 = 6l;
    UHRefc0(v6, REFC_SUPPR);
    return method0(v6, v7);
}
