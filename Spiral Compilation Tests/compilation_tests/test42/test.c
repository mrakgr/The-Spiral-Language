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
UH0 * UH0_0(UH0 * v0, UH0 * v1) { // Add
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH0 * UH0_1(UH0 * v0, UH0 * v1) { // Mult
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->case1.v0 = v0; x->case1.v1 = v1;
    return x;
}
UH0 * UH0_2(float v0) { // V
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 2;
    x->case2.v0 = v0;
    return x;
}
float method0(UH0 * v0){
    switch (v0->tag) {
        case 0: { // Add
            UH0 * v1 = v0->case0.v0; UH0 * v2 = v0->case0.v1;
            float v3;
            v3 = method0(v1);
            float v4;
            v4 = method0(v2);
            return v3 + v4;
            break;
        }
        case 1: { // Mult
            UH0 * v6 = v0->case1.v0; UH0 * v7 = v0->case1.v1;
            float v8;
            v8 = method0(v6);
            float v9;
            v9 = method0(v7);
            return v8 * v9;
            break;
        }
        case 2: { // V
            float v11 = v0->case2.v0;
            return v11;
            break;
        }
    }
}
float main(){
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
    UH0 * v11;
    v11 = UH0_1(v5, v10);
    float v12;
    v12 = method0(v11);
    return v12 * 2.0f;
}
