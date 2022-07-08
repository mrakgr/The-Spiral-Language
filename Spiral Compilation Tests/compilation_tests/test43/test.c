#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct UH0 UH0;
struct UH0 {
    int tag;
    union {
        struct {
            int32_t v0;
            UH0 * v1;
        } case0; // Cons
    };
};
UH0 * UH0_0(int32_t v0, UH0 * v1) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    return x;
}
int32_t method0(UH0 * v0, int32_t v1){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; UH0 * v3 = v0->case0.v1;
            int32_t v4;
            v4 = v1 + v2;
            return method0(v3, v4);
            break;
        }
        case 1: { // Nil
            return v1;
            break;
        }
    }
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    int32_t v2;
    v2 = 3l;
    UH0 * v3;
    v3 = UH0_1();
    UH0 * v4;
    v4 = UH0_0(v2, v3);
    UH0 * v5;
    v5 = UH0_0(v1, v4);
    UH0 * v6;
    v6 = UH0_0(v0, v5);
    int32_t v7;
    v7 = 0l;
    return method0(v6, v7);
}
