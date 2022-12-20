#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
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
static inline void UHDecrefBody0(UH0 * x){
    switch (x->tag) {
        case 0: {
            UHDecref0(x->case0.v2);
            break;
        }
    }
}
void UHDecref0(UH0 * x){
    if (x != NULL && --(x->refc) == 0) { UHDecrefBody0(x); free(x); }
}
UH0 * UH0_0(int32_t v0, int32_t v1, UH0 * v2) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->refc = 1;
    x->case0.v0 = v0; x->case0.v1 = v1; x->case0.v2 = v2;
    v2->refc++;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
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
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
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
    UHDecref0(v6);
    UH0 * v8;
    v8 = UH0_0(v2, v3, v7);
    UHDecref0(v7);
    UH0 * v9;
    v9 = UH0_0(v0, v1, v8);
    UHDecref0(v8);
    String * v36; int32_t v37;
    switch (v9->tag) {
        case 0: { // Cons
            int32_t v10 = v9->case0.v0; int32_t v11 = v9->case0.v1; UH0 * v12 = v9->case0.v2;
            v12->refc++;
            switch (v12->tag) {
                case 0: { // Cons
                    int32_t v13 = v12->case0.v0; int32_t v14 = v12->case0.v1; UH0 * v15 = v12->case0.v2;
                    v15->refc++;
                    UHDecref0(v12);
                    switch (v15->tag) {
                        case 0: { // Cons
                            int32_t v16 = v15->case0.v0; int32_t v17 = v15->case0.v1; UH0 * v18 = v15->case0.v2;
                            UHDecref0(v15);
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
                            UHDecref0(v15);
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
                    UHDecref0(v12);
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
    UHDecref0(v9);
    printf("%s\n%i\n",v36->ptr,v37);
    StringDecref(v36);
    return 0l;
}
