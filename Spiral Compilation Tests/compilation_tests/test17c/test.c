#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct UH1 UH1;
typedef struct UH0 UH0;
struct UH1 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v0;
        } case1; // AW
    };
};
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH1 * v0;
        } case1; // BW
    };
};
static inline void UHRefcBody1(UH1 x, REFC_FLAG q){
    switch (x.tag) {
        case 1: {
            UHRefc0(x.case1.v0, q);
            break;
        }
    }
}
void UHRefc1(UH1 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            UHRefcBody1(*x, REFC_DECR);
            free(x);
        }
    }
}
UH1 * UH1_0() { // AQ
    UH1 x;
    x.tag = 0;
    x.refc = 1;
    UHRefcBody1(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH1)),&x,sizeof(UH1));
}
UH1 * UH1_1(UH0 * v0) { // AW
    UH1 x;
    x.tag = 1;
    x.refc = 1;
    x.case1.v0 = v0;
    UHRefcBody1(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH1)),&x,sizeof(UH1));
}
static inline void UHRefcBody0(UH0 x, REFC_FLAG q){
    switch (x.tag) {
        case 1: {
            UHRefc1(x.case1.v0, q);
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
UH0 * UH0_0() { // BQ
    UH0 x;
    x.tag = 0;
    x.refc = 1;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
UH0 * UH0_1(UH1 * v0) { // BW
    UH0 x;
    x.tag = 1;
    x.refc = 1;
    x.case1.v0 = v0;
    UHRefcBody0(x, REFC_INCR);
    return memcpy(malloc(sizeof(UH0)),&x,sizeof(UH0));
}
int32_t main(){
    UH0 * v0;
    v0 = UH0_0();
    UH1 * v1;
    v1 = UH1_1(v0);
    UHRefc0(v0, REFC_DECR);
    UH0 * v2;
    v2 = UH0_1(v1);
    UHRefc1(v1, REFC_DECR);
    UH1 * v3;
    v3 = UH1_1(v2);
    UHRefc0(v2, REFC_DECR); UHRefc1(v3, REFC_DECR);
    return 0l;
}
