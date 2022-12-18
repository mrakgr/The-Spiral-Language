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
            UH0 * v2;
            int32_t v1;
            int32_t v0;
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
    x.refc = 1;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
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
    x->refc = 1;
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
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
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
    UH0 * v7;
    v7 = UH0_0(v4, v5, v6);
    UHRefc0(v6, REFC_DECR);
    UH0 * v8;
    v8 = UH0_0(v2, v3, v7);
    UHRefc0(v7, REFC_DECR);
    UH0 * v9;
    v9 = UH0_0(v0, v1, v8);
    UHRefc0(v8, REFC_DECR);
    String * v36; int32_t v37;
    switch (v9->tag) {
        case 0: { // Cons
            int32_t v10 = v9->case0.v0; int32_t v11 = v9->case0.v1; UH0 * v12 = v9->case0.v2;
            UHRefc0(v12, REFC_INCR);
            switch (v12->tag) {
                case 0: { // Cons
                    int32_t v13 = v12->case0.v0; int32_t v14 = v12->case0.v1; UH0 * v15 = v12->case0.v2;
                    UHRefc0(v15, REFC_INCR);
                    UHRefc0(v12, REFC_DECR);
                    switch (v15->tag) {
                        case 0: { // Cons
                            int32_t v16 = v15->case0.v0; int32_t v17 = v15->case0.v1; UH0 * v18 = v15->case0.v2;
                            UHRefc0(v18, REFC_INCR);
                            UHRefc0(v15, REFC_DECR); UHRefc0(v18, REFC_DECR);
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
                            String * v24;
                            v24 = StringLit(25, "At least three elements.");
                            v36 = v24; v37 = v23;
                            break;
                        }
                        case 1: { // Nil
                            UHRefc0(v15, REFC_DECR);
                            int32_t v25;
                            v25 = v10 + v11;
                            int32_t v26;
                            v26 = v25 + v13;
                            int32_t v27;
                            v27 = v26 + v14;
                            String * v28;
                            v28 = StringLit(14, "Two elements.");
                            v36 = v28; v37 = v27;
                            break;
                        }
                    }
                    break;
                }
                case 1: { // Nil
                    UHRefc0(v12, REFC_DECR);
                    int32_t v31;
                    v31 = v10 + v11;
                    String * v32;
                    v32 = StringLit(13, "One element.");
                    v36 = v32; v37 = v31;
                    break;
                }
            }
            break;
        }
        case 1: { // Nil
            String * v35;
            v35 = StringLit(12, "No elements");
            v36 = v35; v37 = 0l;
            break;
        }
    }
    UHRefc0(v9, REFC_DECR);
    printf("%s\n%i\n",v36->ptr,v37);
    StringRefc(v36, REFC_DECR);
    return 0l;
}
