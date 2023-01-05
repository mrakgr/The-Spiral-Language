#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
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
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    x->refc = 1;
    return x;
}
int32_t method0(UH0 * v0, UH0 * v1){
    switch (v1->tag == v0->tag ? v1->tag : -1) {
        case 0: { // Cons
            int32_t v2 = v1->case0.v0; UH0 * v3 = v1->case0.v1;
            int32_t v4 = v0->case0.v0; UH0 * v5 = v0->case0.v1;
            v3->refc++; v5->refc++;
            UHDecref0(v0); UHDecref0(v1);
            bool v6;
            v6 = v2 < v4;
            int32_t v9;
            if (v6){
                v9 = -1l;
            } else {
                bool v7;
                v7 = v2 > v4;
                if (v7){
                    v9 = 1l;
                } else {
                    v9 = 0l;
                }
            }
            bool v10;
            v10 = v9 == 0l;
            if (v10){
                return method0(v5, v3);
            } else {
                UHDecref0(v3); UHDecref0(v5);
                return v9;
            }
            break;
        }
        case 1: { // Nil
            UHDecref0(v0); UHDecref0(v1);
            return 0l;
            break;
        }
        default: {
            int32_t v13;
            v13 = v1->tag;
            UHDecref0(v1);
            int32_t v14;
            v14 = v0->tag;
            UHDecref0(v0);
            bool v15;
            v15 = v13 < v14;
            if (v15){
                return -1l;
            } else {
                bool v16;
                v16 = v13 > v14;
                if (v16){
                    return 1l;
                } else {
                    return 0l;
                }
            }
        }
    }
}
int32_t main(){
    # // Union test;
    # // Static, Static;
    int32_t v3;
    v3 = -1l;
    # // Dyn, Static;
    int32_t v4;
    v4 = 1l;
    US0 v5;
    v5 = US0_0(v4);
    int32_t v17;
    switch (v5.tag) {
        case 1: { // B
            double v7 = v5.case1.v0;
            bool v8;
            v8 = v7 < 3.0;
            if (v8){
                v17 = -1l;
            } else {
                bool v9;
                v9 = v7 > 3.0;
                if (v9){
                    v17 = 1l;
                } else {
                    v17 = 0l;
                }
            }
            break;
        }
        default: {
            int32_t v12;
            v12 = v5.tag;
            bool v13;
            v13 = v12 < 1l;
            if (v13){
                v17 = -1l;
            } else {
                bool v14;
                v14 = v12 > 1l;
                if (v14){
                    v17 = 1l;
                } else {
                    v17 = 0l;
                }
            }
        }
    }
    USDecref0(&(v5));
    # // Static, Dyn;
    double v18;
    v18 = 3.0;
    US0 v19;
    v19 = US0_1(v18);
    int32_t v32;
    switch (v19.tag) {
        case 0: { // A
            int32_t v22 = v19.case0.v0;
            bool v23;
            v23 = 1l < v22;
            if (v23){
                v32 = -1l;
            } else {
                bool v24;
                v24 = 1l > v22;
                if (v24){
                    v32 = 1l;
                } else {
                    v32 = 0l;
                }
            }
            break;
        }
        default: {
            int32_t v27;
            v27 = v19.tag;
            bool v28;
            v28 = 0l < v27;
            if (v28){
                v32 = -1l;
            } else {
                bool v29;
                v29 = 0l > v27;
                if (v29){
                    v32 = 1l;
                } else {
                    v32 = 0l;
                }
            }
        }
    }
    USDecref0(&(v19));
    # // Dyn, Dyn;
    int32_t v33;
    v33 = 1l;
    US0 v34;
    v34 = US0_0(v33);
    double v35;
    v35 = 3.0;
    US0 v36;
    v36 = US0_1(v35);
    int32_t v55;
    switch (v34.tag == v36.tag ? v34.tag : -1) {
        case 0: { // A
            int32_t v37 = v34.case0.v0;
            int32_t v38 = v36.case0.v0;
            bool v39;
            v39 = v37 < v38;
            if (v39){
                v55 = -1l;
            } else {
                bool v40;
                v40 = v37 > v38;
                if (v40){
                    v55 = 1l;
                } else {
                    v55 = 0l;
                }
            }
            break;
        }
        case 1: { // B
            double v43 = v34.case1.v0;
            double v44 = v36.case1.v0;
            bool v45;
            v45 = v43 < v44;
            if (v45){
                v55 = -1l;
            } else {
                bool v46;
                v46 = v43 > v44;
                if (v46){
                    v55 = 1l;
                } else {
                    v55 = 0l;
                }
            }
            break;
        }
        default: {
            int32_t v49;
            v49 = v34.tag;
            int32_t v50;
            v50 = v36.tag;
            bool v51;
            v51 = v49 < v50;
            if (v51){
                v55 = -1l;
            } else {
                bool v52;
                v52 = v49 > v50;
                if (v52){
                    v55 = 1l;
                } else {
                    v55 = 0l;
                }
            }
        }
    }
    USDecref0(&(v34)); USDecref0(&(v36));
    # // Union rec test;
    int32_t v56;
    v56 = 3l;
    UH0 * v57;
    v57 = UH0_1();
    v57->refc++;
    UH0 * v58;
    v58 = UH0_0(v56, v57);
    UHDecref0(v57);
    int32_t v59;
    v59 = 2l;
    int32_t v60;
    v60 = 3l;
    UH0 * v61;
    v61 = UH0_1();
    v61->refc++;
    UH0 * v62;
    v62 = UH0_0(v60, v61);
    v62->refc++;
    UHDecref0(v61);
    UH0 * v63;
    v63 = UH0_0(v59, v62);
    UHDecref0(v62);
    int32_t v84;
    switch (v63->tag) {
        case 0: { // Cons
            int32_t v70 = v63->case0.v0; UH0 * v71 = v63->case0.v1;
            v71->refc++;
            bool v72;
            v72 = 2l < v70;
            int32_t v75;
            if (v72){
                v75 = -1l;
            } else {
                bool v73;
                v73 = 2l > v70;
                if (v73){
                    v75 = 1l;
                } else {
                    v75 = 0l;
                }
            }
            bool v76;
            v76 = v75 == 0l;
            if (v76){
                v58->refc++;
                v84 = method0(v71, v58);
            } else {
                UHDecref0(v71);
                v84 = v75;
            }
            break;
        }
        default: {
            int32_t v79;
            v79 = v63->tag;
            bool v80;
            v80 = 0l < v79;
            if (v80){
                v84 = -1l;
            } else {
                bool v81;
                v81 = 0l > v79;
                if (v81){
                    v84 = 1l;
                } else {
                    v84 = 0l;
                }
            }
        }
    }
    UHDecref0(v58); UHDecref0(v63);
    return 0l;
}
