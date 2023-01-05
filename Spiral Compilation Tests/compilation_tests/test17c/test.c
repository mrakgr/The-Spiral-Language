#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH1 UH1;
void UHDecref1(UH1 * x);
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
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
static inline void UHDecrefBody1(UH1 * x){
    switch (x->tag) {
        case 1: {
            UHDecref0(x->case1.v0);
            break;
        }
    }
}
void UHDecref1(UH1 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody1(x); free(x); }
}
UH1 * UH1_0() { // AQ
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH1 * UH1_1(UH0 * v0) { // AW
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 1: {
            UHDecref1(x->case1.v0);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0() { // BQ
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    return x;
}
UH0 * UH0_1(UH1 * v0) { // BW
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    x->case1.v0 = v0;
    return x;
}
int32_t main(){
    UH0 * v0;
    v0 = UH0_0();
    v0->refc++;
    UH1 * v1;
    v1 = UH1_1(v0);
    v1->refc++;
    UHDecref0(v0);
    UH0 * v2;
    v2 = UH0_1(v1);
    v2->refc++;
    UHDecref1(v1);
    UH1 * v3;
    v3 = UH1_1(v2);
    UHDecref0(v2); UHDecref1(v3);
    return 0l;
}
