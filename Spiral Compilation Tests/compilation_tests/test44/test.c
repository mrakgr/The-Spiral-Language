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
typedef struct {
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct UH1 UH1;
struct UH1 {
    int tag;
    union {
        struct {
            String * v0;
            UH1 * v1;
        } case0; // Cons
    };
};
typedef struct UH2 UH2;
struct UH2 {
    int tag;
    union {
        struct {
            bool v0;
            UH2 * v1;
        } case0; // Cons
    };
};
typedef struct UH3 UH3;
struct UH3 {
    int tag;
    union {
        struct {
            int32_t v0;
            String * v1;
            bool v2;
            UH3 * v3;
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
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(char) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    return x;
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
UH1 * UH1_0(String * v0, UH1 * v1) { // Cons
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH1 * UH1_1() { // Nil
    UH1 * x = malloc(sizeof(UH1));
    x->tag = 1;
    return x;
}
UH2 * UH2_0(bool v0, UH2 * v1) { // Cons
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1;
    return x;
}
UH2 * UH2_1() { // Nil
    UH2 * x = malloc(sizeof(UH2));
    x->tag = 1;
    return x;
}
UH3 * UH3_0(int32_t v0, String * v1, bool v2, UH3 * v3) { // Cons
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1; x->case0.v2 = v2; x->case0.v3 = v3;
    return x;
}
UH3 * UH3_1() { // Nil
    UH3 * x = malloc(sizeof(UH3));
    x->tag = 1;
    return x;
}
UH3 * method3(int32_t v0, String * v1, UH2 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            bool v4 = v2->case0.v0; UH2 * v5 = v2->case0.v1;
            UH3 * v6;
            v6 = method3(v0, v1, v5, v3);
            return UH3_0(v0, v1, v4, v6);
            break;
        }
        case 1: { // Nil
            return v3;
            break;
        }
    }
}
UH3 * method4(UH3 * v0, UH3 * v1){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v2 = v0->case0.v0; String * v3 = v0->case0.v1; bool v4 = v0->case0.v2; UH3 * v5 = v0->case0.v3;
            UH3 * v6;
            v6 = method4(v5, v1);
            return UH3_0(v2, v3, v4, v6);
            break;
        }
        case 1: { // Nil
            return v1;
            break;
        }
    }
}
UH3 * method2(UH2 * v0, int32_t v1, UH1 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            String * v4 = v2->case0.v0; UH1 * v5 = v2->case0.v1;
            UH3 * v6;
            v6 = method2(v0, v1, v5, v3);
            UH3 * v7;
            v7 = UH3_1();
            UH3 * v8;
            v8 = method3(v1, v4, v0, v7);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            return v3;
            break;
        }
    }
}
UH3 * method1(UH1 * v0, UH2 * v1, UH0 * v2, UH3 * v3){
    switch (v2->tag) {
        case 0: { // Cons
            int32_t v4 = v2->case0.v0; UH0 * v5 = v2->case0.v1;
            UH3 * v6;
            v6 = method1(v0, v1, v5, v3);
            UH3 * v7;
            v7 = UH3_1();
            UH3 * v8;
            v8 = method2(v1, v4, v0, v7);
            return method4(v8, v6);
            break;
        }
        case 1: { // Nil
            return v3;
            break;
        }
    }
}
UH3 * method0(UH0 * v0, UH1 * v1, UH2 * v2){
    UH3 * v3;
    v3 = UH3_1();
    return method1(v1, v2, v0, v3);
}
void method5(UH3 * v0){
    switch (v0->tag) {
        case 0: { // Cons
            int32_t v1 = v0->case0.v0; String * v2 = v0->case0.v1; bool v3 = v0->case0.v2; UH3 * v4 = v0->case0.v3;
            printf("%i %s %i\n",v1, v2->ptr, (int) v3);
            return method5(v4);
            break;
        }
        case 1: { // Nil
            return ;
            break;
        }
    }
}
void main(){
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
    String * v7;
    v7 = StringLit(1, "a");
    String * v8;
    v8 = StringLit(1, "b");
    UH1 * v9;
    v9 = UH1_1();
    UH1 * v10;
    v10 = UH1_0(v8, v9);
    UH1 * v11;
    v11 = UH1_0(v7, v10);
    bool v12;
    v12 = true;
    UH2 * v13;
    v13 = UH2_1();
    UH2 * v14;
    v14 = UH2_0(v12, v13);
    UH3 * v15;
    v15 = method0(v6, v11, v14);
    return method5(v15);
}
