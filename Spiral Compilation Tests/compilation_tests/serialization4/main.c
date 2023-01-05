#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            uint32_t v0;
        } case2; // Raise
    };
} US0;
typedef struct {
    int refc;
    uint32_t len;
    float ptr[];
} Array0;
typedef struct {
    uint32_t v0;
    uint32_t v1;
} Tuple0;
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
US0 US0_0() { // Call
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // NoAction
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_2(uint32_t v0) { // Raise
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
static inline void ArrayDecrefBody0(Array0 * x){
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(float) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, float * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(float) * len);
    return x;
}
static inline void AssignArray0(float * a, float b){
    *a = b;
}
static inline Tuple0 TupleCreate0(uint32_t v0, uint32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method2(uint32_t v0, Array0 * v1, uint32_t v2, uint32_t v3, uint32_t v4){
    bool v5;
    v5 = v2 < v0;
    if (v5){
        uint32_t v6;
        v6 = v2 + 1ul;
        float v7;
        v7 = v1->ptr[v2];
        bool v8;
        v8 = v7 == 0.0f;
        uint32_t v15; uint32_t v16;
        if (v8){
            v15 = v3; v16 = v4;
        } else {
            bool v9;
            v9 = v7 == 1.0f;
            if (v9){
                uint32_t v10;
                v10 = v4 + 1ul;
                v15 = v2; v16 = v10;
            } else {
                fprintf(stderr, "%s\n", "Unpickling failure. The int type must either be active or inactive.");
                exit(EXIT_FAILURE);
            }
        }
        return method2(v0, v1, v6, v15, v16);
    } else {
        ArrayDecref0(v1);
        return TupleCreate0(v3, v4);
    }
}
Tuple0 method1(Array0 * v0, uint32_t v1, uint32_t v2){
    uint32_t v3;
    v3 = 0ul;
    uint32_t v4;
    v4 = 0ul;
    v0->refc++;
    uint32_t v5; uint32_t v6;
    Tuple0 tmp0 = method2(v1, v0, v2, v3, v4);
    v5 = tmp0.v0; v6 = tmp0.v1;
    ArrayDecref0(v0);
    bool v7;
    v7 = 1ul < v6;
    if (v7){
        fprintf(stderr, "%s\n", "Unpickling failure. Too many active indices in the one-hot vector.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v8;
    v8 = v5 - v2;
    return TupleCreate0(v8, v6);
}
int32_t method0(){
    uint32_t v0;
    v0 = 0ul;
    uint32_t v1;
    v1 = 1ul;
    uint32_t v2;
    v2 = 12ul;
    uint32_t v3;
    v3 = 3ul;
    uint32_t v4;
    v4 = 10ul;
    US0 v5;
    v5 = US0_1();
    uint32_t v6;
    v6 = 5ul;
    uint32_t v7;
    v7 = 5ul;
    Array0 * v8;
    v8 = ArrayCreate0(73ul, true); // I set this manually.
    bool v9;
    v9 = 0ul <= v7;
    bool v11;
    if (v9){
        bool v10;
        v10 = v7 < 11ul;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11){
        AssignArray0(&(v8->ptr[v7]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v12;
    v12 = 0ul <= v6;
    bool v14;
    if (v12){
        bool v13;
        v13 = v6 < 11ul;
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14){
        uint32_t v15;
        v15 = 11ul + v6;
        AssignArray0(&(v8->ptr[v15]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v16;
    v16 = 0ul <= v4;
    bool v18;
    if (v16){
        bool v17;
        v17 = v4 < 11ul;
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18){
        uint32_t v19;
        v19 = 22ul + v4;
        AssignArray0(&(v8->ptr[v19]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v20;
    v20 = 0ul <= v0;
    bool v22;
    if (v20){
        bool v21;
        v21 = v0 < 13ul;
        v22 = v21;
    } else {
        v22 = false;
    }
    if (v22){
        uint32_t v23;
        v23 = 33ul + v0;
        AssignArray0(&(v8->ptr[v23]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v24;
    v24 = 0ul <= v1;
    bool v26;
    if (v24){
        bool v25;
        v25 = v1 < 4ul;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26){
        uint32_t v27;
        v27 = 46ul + v1;
        AssignArray0(&(v8->ptr[v27]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v28;
    v28 = 0ul <= v2;
    bool v30;
    if (v28){
        bool v29;
        v29 = v2 < 13ul;
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30){
        uint32_t v31;
        v31 = 50ul + v2;
        AssignArray0(&(v8->ptr[v31]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    bool v32;
    v32 = 0ul <= v3;
    bool v34;
    if (v32){
        bool v33;
        v33 = v3 < 4ul;
        v34 = v33;
    } else {
        v34 = false;
    }
    if (v34){
        uint32_t v35;
        v35 = 63ul + v3;
        AssignArray0(&(v8->ptr[v35]), 1.0f);
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.");
        exit(EXIT_FAILURE);
    }
    switch (v5.tag) {
        case 0: { // Call
            AssignArray0(&(v8->ptr[67ul]), 1.0f);
            break;
        }
        case 1: { // NoAction
            AssignArray0(&(v8->ptr[68ul]), 1.0f);
            break;
        }
        case 2: { // Raise
            uint32_t v36 = v5.case2.v0;
            bool v37;
            v37 = 0ul <= v36;
            bool v39;
            if (v37){
                bool v38;
                v38 = v36 < 4ul;
                v39 = v38;
            } else {
                v39 = false;
            }
            if (v39){
                uint32_t v40;
                v40 = 69ul + v36;
                AssignArray0(&(v8->ptr[v40]), 1.0f);
            } else {
                fprintf(stderr, "%s\n", "Value out of bounds.");
                exit(EXIT_FAILURE);
            }
            break;
        }
    }
    uint32_t v41;
    v41 = 0ul;
    uint32_t v42;
    v42 = 11ul;
    v8->refc++;
    uint32_t v43; uint32_t v44;
    Tuple0 tmp1 = method1(v8, v42, v41);
    v43 = tmp1.v0; v44 = tmp1.v1;
    uint32_t v45;
    v45 = 11ul;
    uint32_t v46;
    v46 = 22ul;
    v8->refc++;
    uint32_t v47; uint32_t v48;
    Tuple0 tmp2 = method1(v8, v46, v45);
    v47 = tmp2.v0; v48 = tmp2.v1;
    uint32_t v49;
    v49 = 22ul;
    uint32_t v50;
    v50 = 33ul;
    v8->refc++;
    uint32_t v51; uint32_t v52;
    Tuple0 tmp3 = method1(v8, v50, v49);
    v51 = tmp3.v0; v52 = tmp3.v1;
    uint32_t v53;
    v53 = 33ul;
    uint32_t v54;
    v54 = 46ul;
    v8->refc++;
    uint32_t v55; uint32_t v56;
    Tuple0 tmp4 = method1(v8, v54, v53);
    v55 = tmp4.v0; v56 = tmp4.v1;
    uint32_t v57;
    v57 = 46ul;
    uint32_t v58;
    v58 = 50ul;
    v8->refc++;
    uint32_t v59; uint32_t v60;
    Tuple0 tmp5 = method1(v8, v58, v57);
    v59 = tmp5.v0; v60 = tmp5.v1;
    uint32_t v61;
    v61 = v56 + v60;
    bool v62;
    v62 = v61 == 1ul;
    if (v62){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v63;
    v63 = v61 / 2ul;
    uint32_t v64;
    v64 = 50ul;
    uint32_t v65;
    v65 = 63ul;
    v8->refc++;
    uint32_t v66; uint32_t v67;
    Tuple0 tmp6 = method1(v8, v65, v64);
    v66 = tmp6.v0; v67 = tmp6.v1;
    uint32_t v68;
    v68 = 63ul;
    uint32_t v69;
    v69 = 67ul;
    v8->refc++;
    uint32_t v70; uint32_t v71;
    Tuple0 tmp7 = method1(v8, v69, v68);
    v70 = tmp7.v0; v71 = tmp7.v1;
    uint32_t v72;
    v72 = v67 + v71;
    bool v73;
    v73 = v72 == 1ul;
    if (v73){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v74;
    v74 = v72 / 2ul;
    uint32_t v75;
    v75 = v63 + v74;
    bool v76;
    v76 = v75 == 1ul;
    if (v76){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v77;
    v77 = v75 / 2ul;
    float v78;
    v78 = v8->ptr[67ul];
    bool v79;
    v79 = v78 == 1.0f;
    uint32_t v83;
    if (v79){
        v83 = 1ul;
    } else {
        bool v80;
        v80 = v78 == 0.0f;
        if (v80){
            v83 = 0ul;
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. The unit type should always be either be active or inactive.");
            exit(EXIT_FAILURE);
        }
    }
    float v84;
    v84 = v8->ptr[68ul];
    bool v85;
    v85 = v84 == 1.0f;
    uint32_t v89;
    if (v85){
        v89 = 1ul;
    } else {
        bool v86;
        v86 = v84 == 0.0f;
        if (v86){
            v89 = 0ul;
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. The unit type should always be either be active or inactive.");
            exit(EXIT_FAILURE);
        }
    }
    uint32_t v90;
    v90 = 69ul;
    uint32_t v91;
    v91 = 73ul;
    v8->refc++;
    uint32_t v92; uint32_t v93;
    Tuple0 tmp8 = method1(v8, v91, v90);
    v92 = tmp8.v0; v93 = tmp8.v1;
    ArrayDecref0(v8);
    bool v94;
    v94 = v89 == 1ul;
    US0 v97;
    if (v94){
        v97 = US0_1();
    } else {
        v97 = US0_0();
    }
    uint32_t v98;
    v98 = v83 + v89;
    bool v99;
    v99 = v93 == 1ul;
    US0 v101;
    if (v99){
        v101 = US0_2(v92);
    } else {
        USIncref0(&(v97));
        v101 = v97;
    }
    USDecref0(&(v97));
    uint32_t v102;
    v102 = v98 + v93;
    bool v103;
    v103 = 1ul < v102;
    if (v103){
        fprintf(stderr, "%s\n", "Unpickling failure. Only a single case of an union type should be active at most.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v104;
    v104 = v77 + v102;
    bool v105;
    v105 = v104 == 1ul;
    if (v105){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v106;
    v106 = v104 / 2ul;
    uint32_t v107;
    v107 = v52 + v106;
    bool v108;
    v108 = v107 == 1ul;
    if (v108){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v109;
    v109 = v107 / 2ul;
    uint32_t v110;
    v110 = v48 + v109;
    bool v111;
    v111 = v110 == 1ul;
    if (v111){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v112;
    v112 = v110 / 2ul;
    uint32_t v113;
    v113 = v44 + v112;
    bool v114;
    v114 = v113 == 1ul;
    if (v114){
        fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.");
        exit(EXIT_FAILURE);
    } else {
    }
    uint32_t v115;
    v115 = v113 / 2ul;
    bool v116;
    v116 = v115 == 1ul;
    bool v117;
    v117 = v116 != true;
    if (v117){
        fprintf(stderr, "%s\n", "Invalid format.");
        exit(EXIT_FAILURE);
    } else {
    }
    bool v118;
    v118 = v0 == v55;
    bool v120;
    if (v118){
        bool v119;
        v119 = v1 == v59;
        v120 = v119;
    } else {
        v120 = false;
    }
    bool v124;
    if (v120){
        bool v121;
        v121 = v2 == v66;
        if (v121){
            bool v122;
            v122 = v3 == v70;
            v124 = v122;
        } else {
            v124 = false;
        }
    } else {
        v124 = false;
    }
    bool v135;
    if (v124){
        bool v125;
        v125 = v4 == v51;
        if (v125){
            bool v129;
            switch (v5.tag == v101.tag ? v5.tag : -1) {
                case 0: { // Call
                    v129 = true;
                    break;
                }
                case 1: { // NoAction
                    v129 = true;
                    break;
                }
                case 2: { // Raise
                    uint32_t v126 = v5.case2.v0;
                    uint32_t v127 = v101.case2.v0;
                    bool v128;
                    v128 = v126 == v127;
                    v129 = v128;
                    break;
                }
                default: {
                    v129 = false;
                }
            }
            if (v129){
                bool v130;
                v130 = v6 == v47;
                if (v130){
                    bool v131;
                    v131 = v7 == v43;
                    v135 = v131;
                } else {
                    v135 = false;
                }
            } else {
                v135 = false;
            }
        } else {
            v135 = false;
        }
    } else {
        v135 = false;
    }
    USDecref0(&(v5)); USDecref0(&(v101));
    bool v136;
    v136 = v135 == false;
    if (v136){
        fprintf(stderr, "%s\n", "Serialization and deserialization should result in the same result.");
        exit(EXIT_FAILURE);
    } else {
    }
    return 0l;
}
int32_t main(){
    return method0();
}
