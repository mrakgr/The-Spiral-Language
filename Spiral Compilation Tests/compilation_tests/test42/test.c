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
            UH0 * v0;
            UH0 * v1;
        } case0; // Add
        struct {
            UH0 * v0;
            UH0 * v1;
        } case1; // Mult
        struct {
            float v0;
        } case2; // V
    };
};
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 0: {
            UHRefc0(x.case0.v0, q); UHRefc0(x.case0.v1, q);
            break;
        }
        case 1: {
            UHRefc0(x.case1.v0, q); UHRefc0(x.case1.v1, q);
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
UH0 * UH0_0(UH0 * v0, UH0 * v1) { // Add
    UH0 x;
    x.tag = 0;
    x.refc = 1;
    x.case0.v0 = v0; x.case0.v1 = v1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1(UH0 * v0, UH0 * v1) { // Mult
    UH0 x;
    x.tag = 1;
    x.refc = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_2(float v0) { // V
    UH0 x;
    x.tag = 2;
    x.refc = 1;
    x.case2.v0 = v0;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
float method0(UH0 * v0){
    UHRefc0(v0, REFC_INCR);
    switch (v0->tag) {
        case 0: { // Add
            UH0 * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            UHRefc0(v1, REFC_INCR); UHRefc0(v2, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            float v3;
            v3 = method0(v1);
            UHRefc0(v1, REFC_DECR);
            float v4;
            v4 = method0(v2);
            UHRefc0(v2, REFC_DECR);
            float v5;
            v5 = v3 + v4;
            return v5;
            break;
        }
        case 1: { // Mult
            UH0 * v6 = v0->case1.v0; UH0 * v7 = v0->case1.v1;
            UHRefc0(v6, REFC_INCR); UHRefc0(v7, REFC_INCR);
            UHRefc0(v0, REFC_DECR);
            float v8;
            v8 = method0(v6);
            UHRefc0(v6, REFC_DECR);
            float v9;
            v9 = method0(v7);
            UHRefc0(v7, REFC_DECR);
            float v10;
            v10 = v8 * v9;
            return v10;
            break;
        }
        case 2: { // V
            float v11 = v0->case2.v0;
            UHRefc0(v0, REFC_DECR);
            return v11;
            break;
        }
    }
}
int32_t main(){
    float v0;
    v0 = 21.0f;
    float v1;
    v1 = 1.0f;
    UH0 * v2;
    v2 = UH0_2(v1);
    float v3;
    v3 = 2.0f;
    UH0 * v4;
    v4 = UH0_2(v3);
    UH0 * v5;
    v5 = UH0_0(v2, v4);
    UHRefc0(v2, REFC_DECR); UHRefc0(v4, REFC_DECR);
    float v6;
    v6 = 3.0f;
    UH0 * v7;
    v7 = UH0_2(v6);
    float v8;
    v8 = 4.0f;
    UH0 * v9;
    v9 = UH0_2(v8);
    UH0 * v10;
    v10 = UH0_0(v7, v9);
    UHRefc0(v7, REFC_DECR); UHRefc0(v9, REFC_DECR);
    UH0 * v11;
    v11 = UH0_1(v5, v10);
    UHRefc0(v5, REFC_DECR); UHRefc0(v10, REFC_DECR);
    float v12;
    v12 = method0(v11);
    UHRefc0(v11, REFC_DECR);
    float v13;
    v13 = v12 * 2.0f;
    return 0l;
}
