#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
struct UH0 {
    int refc;
    int tag;
    union {
        struct {
            UH0 * v1;
            int32_t v0;
        } case0; // Cons
    };
};
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v1);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(int32_t v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
int32_t method0(UH0 * v0, int32_t v1){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; UH0 * v3 = v0->case0.v1;
            v3->refc++;
            UHDecref0(v0);
            int32_t v4;
            v4 = v1 + v2;
            return method0(v3, v4);
            break;
        }
        case 1: { // Nil
            UHDecref0(v0);
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
    v3->refc++;
    UH0 * v4;
    v4 = UH0_0(v2, v3);
    v4->refc++;
    UHDecref0(v3);
    UH0 * v5;
    v5 = UH0_0(v1, v4);
    v5->refc++;
    UHDecref0(v4);
    UH0 * v6;
    v6 = UH0_0(v0, v5);
    UHDecref0(v5);
    int32_t v7;
    v7 = 6l;
    return method0(v6, v7);
}
