#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct UH0 UH0;
void UHDecref0(UH0 * x);
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // A
        struct {
            double v0;
        } case1; // B
    };
} US0;
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
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USSupprefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
void USSuppref0(US0 * x){ USSupprefBody0(x); }
US0 US0_0(int32_t v0) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_1(double v0) { // B
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
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
    v1->refc++;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
bool method0(UH0 * v0, UH0 * v1){
    v0->refc++; v1->refc++;
    switch (v1->tag == v0->tag ? v1->tag : -1) {
        case 0: { // Cons
            int32_t v2 = v1->case0.v0; UH0 * v3 = v1->case0.v1;
            int32_t v4 = v0->case0.v0; UH0 * v5 = v0->case0.v1;
            v3->refc++; v5->refc++;
            UHDecref0(v0); UHDecref0(v1);
            bool v6;
            v6 = v2 == v4;
            if (v6){
                v3->refc--; v5->refc--;
                return method0(v5, v3);
            } else {
                UHDecref0(v3); UHDecref0(v5);
                return false;
            }
            break;
        }
        case 1: { // Nil
            UHDecref0(v0); UHDecref0(v1);
            return true;
            break;
        }
        default: {
            UHDecref0(v0); UHDecref0(v1);
            return false;
        }
    }
}
int32_t main(){
    bool v3;
    v3 = false;
    int32_t v4;
    v4 = 1l;
    US0 v5;
    v5 = US0_0(v4);
    bool v9;
    switch (v5.tag) {
        case 1: { // B
            double v7 = v5.case1.v0;
            bool v8;
            v8 = v7 == 3.0;
            v9 = v8;
            break;
        }
        default: {
            v9 = false;
        }
    }
    USDecref0(&(v5));
    double v10;
    v10 = 3.0;
    US0 v11;
    v11 = US0_1(v10);
    bool v16;
    switch (v11.tag) {
        case 0: { // A
            int32_t v14 = v11.case0.v0;
            bool v15;
            v15 = 1l == v14;
            v16 = v15;
            break;
        }
        default: {
            v16 = false;
        }
    }
    USDecref0(&(v11));
    int32_t v17;
    v17 = 1l;
    US0 v18;
    v18 = US0_0(v17);
    double v19;
    v19 = 3.0;
    US0 v20;
    v20 = US0_1(v19);
    bool v27;
    switch (v18.tag == v20.tag ? v18.tag : -1) {
        case 0: { // A
            int32_t v21 = v18.case0.v0;
            int32_t v22 = v20.case0.v0;
            bool v23;
            v23 = v21 == v22;
            v27 = v23;
            break;
        }
        case 1: { // B
            double v24 = v18.case1.v0;
            double v25 = v20.case1.v0;
            bool v26;
            v26 = v24 == v25;
            v27 = v26;
            break;
        }
        default: {
            v27 = false;
        }
    }
    USDecref0(&(v18)); USDecref0(&(v20));
    int32_t v28;
    v28 = 3l;
    UH0 * v29;
    v29 = UH0_1();
    UH0 * v30;
    v30 = UH0_0(v28, v29);
    UHDecref0(v29);
    int32_t v31;
    v31 = 2l;
    int32_t v32;
    v32 = 3l;
    UH0 * v33;
    v33 = UH0_1();
    UH0 * v34;
    v34 = UH0_0(v32, v33);
    UHDecref0(v33);
    UH0 * v35;
    v35 = UH0_0(v31, v34);
    UHDecref0(v34);
    bool v47;
    switch (v35->tag) {
        case 0: { // Cons
            int32_t v42 = v35->case0.v0; UH0 * v43 = v35->case0.v1;
            v43->refc++;
            bool v44;
            v44 = 2l == v42;
            if (v44){
                v43->refc--;
                v47 = method0(v43, v30);
            } else {
                UHDecref0(v43);
                v47 = false;
            }
            break;
        }
        default: {
            v47 = false;
        }
    }
    UHDecref0(v30); UHDecref0(v35);
    return 0l;
}
