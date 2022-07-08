#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
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
bool method0(UH0 * v0, UH0 * v1){
    switch (v1->tag == v0->tag ? v1->tag : -1) {
        case 0: { // Cons
            int32_t v2 = v1->case0.v0; UH0 * v3 = v1->case0.v1;
            int32_t v4 = v0->case0.v0; UH0 * v5 = v0->case0.v1;
            bool v6;
            v6 = v2 == v4;
            if (v6){
                return method0(v5, v3);
            } else {
                return false;
            }
            break;
        }
        case 1: { // Nil
            return true;
            break;
        }
        default: {
            return false;
        }
    }
}
void main(){
    // Union test;
    # // Static, Static;
    bool v3;
    v3 = false;
    # // Dyn, Static;
    int32_t v4;
    v4 = 1l;
    US0 v5;
    v5 = US0_0(v4);
    bool v9;
    switch (v5.tag) {
        case 1: { // B
            double v7 = v5.case1.v0;
            v9 = v7 == 3.0;
            break;
        }
        default: {
            v9 = false;
        }
    }
    # // Static, Dyn;
    double v10;
    v10 = 3.0;
    US0 v11;
    v11 = US0_1(v10);
    bool v16;
    switch (v11.tag) {
        case 0: { // A
            int32_t v14 = v11.case0.v0;
            v16 = 1l == v14;
            break;
        }
        default: {
            v16 = false;
        }
    }
    # // Dyn, Dyn;
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
            v27 = v21 == v22;
            break;
        }
        case 1: { // B
            double v24 = v18.case1.v0;
            double v25 = v20.case1.v0;
            v27 = v24 == v25;
            break;
        }
        default: {
            v27 = false;
        }
    }
    // Union rec test;
    int32_t v28;
    v28 = 3l;
    UH0 * v29;
    v29 = UH0_1();
    UH0 * v30;
    v30 = UH0_0(v28, v29);
    int32_t v31;
    v31 = 2l;
    int32_t v32;
    v32 = 3l;
    UH0 * v33;
    v33 = UH0_1();
    UH0 * v34;
    v34 = UH0_0(v32, v33);
    UH0 * v35;
    v35 = UH0_0(v31, v34);
    bool v47;
    switch (v35->tag) {
        case 0: { // Cons
            int32_t v42 = v35->case0.v0; UH0 * v43 = v35->case0.v1;
            bool v44;
            v44 = 2l == v42;
            if (v44){
                v47 = method0(v43, v30);
            } else {
                v47 = false;
            }
            break;
        }
        default: {
            v47 = false;
        }
    }
    return ;
}
