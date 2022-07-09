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
        } case2; // Raise
    };
} US0;
typedef struct {
    uint32_t len;
    float ptr[];
} Array0;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Some
    };
} US1;
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
        } case1; // Some
    };
} US2;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
        } case1; // Some
    };
} US3;
typedef struct {
    int tag;
    union {
    };
} US4;
typedef struct {
    int tag;
    union {
        struct {
            US0 v0;
        } case1; // Some
    };
} US5;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
            US0 v4;
        } case1; // Some
    };
} US6;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
            int32_t v4;
            US0 v5;
        } case1; // Some
    };
} US7;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
            int32_t v4;
            int32_t v5;
            US0 v6;
        } case1; // Some
    };
} US8;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
            int32_t v4;
            int32_t v5;
            int32_t v6;
            US0 v7;
        } case1; // Some
    };
} US9;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
            int32_t v1;
            int32_t v2;
            int32_t v3;
            int32_t v4;
            US0 v5;
            int32_t v6;
            int32_t v7;
        } case1; // Some
    };
} US10;
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
US0 US0_2(int32_t v0) { // Raise
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(float) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, float * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(float) * size);
    return x;
}
US1 US1_0() { // None
    US1 x;
    x.tag = 0;
    return x;
}
US1 US1_1(int32_t v0) { // Some
    US1 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method2(int32_t v0, Array0 * v1, int32_t v2, int32_t v3, int32_t v4){
    bool v5;
    v5 = v2 < v0;
    if (v5){
        int32_t v6;
        v6 = v2 + 1l;
        float v7;
        v7 = v1->ptr[v2];
        bool v8;
        v8 = v7 == 0.0f;
        int32_t v15; int32_t v16;
        if (v8){
            v15 = v3; v16 = v4;
        } else {
            bool v9;
            v9 = v7 == 1.0f;
            if (v9){
                int32_t v10;
                v10 = v4 + 1l;
                v15 = v2; v16 = v10;
            } else {
                fprintf(stderr, "%s\n", "Unpickling failure. The int type must either be active or inactive.")
                exit(EXIT_FAILURE);
            }
        }
        return method2(v0, v1, v6, v15, v16);
    } else {
        return TupleCreate0(v3, v4);
    }
}
US1 method1(Array0 * v0, int32_t v1, int32_t v2){
    int32_t v3;
    v3 = -1l;
    int32_t v4;
    v4 = 0l;
    int32_t v5; int32_t v6;
    Tuple0 tmp0 = method2(v1, v0, v2, v3, v4);
    v5 = tmp0.v0; v6 = tmp0.v1;
    bool v7;
    v7 = v6 == 0l;
    if (v7){
        return US1_0();
    } else {
        bool v9;
        v9 = v6 == 1l;
        if (v9){
            int32_t v10;
            v10 = v5 - v2;
            return US1_1(v10);
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. Too many active indices in the one-hot vector.")
            exit(EXIT_FAILURE);
        }
    }
}
US2 US2_0() { // None
    US2 x;
    x.tag = 0;
    return x;
}
US2 US2_1(int32_t v0, int32_t v1) { // Some
    US2 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1;
    return x;
}
US3 US3_0() { // None
    US3 x;
    x.tag = 0;
    return x;
}
US3 US3_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3) { // Some
    US3 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3;
    return x;
}
US4 US4_0() { // None
    US4 x;
    x.tag = 0;
    return x;
}
US4 US4_1() { // Some
    US4 x;
    x.tag = 1;
    return x;
}
US5 US5_0() { // None
    US5 x;
    x.tag = 0;
    return x;
}
US5 US5_1(US0 v0) { // Some
    US5 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US6 US6_0() { // None
    US6 x;
    x.tag = 0;
    return x;
}
US6 US6_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, US0 v4) { // Some
    US6 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3; x.case1.v4 = v4;
    return x;
}
US7 US7_0() { // None
    US7 x;
    x.tag = 0;
    return x;
}
US7 US7_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, US0 v5) { // Some
    US7 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3; x.case1.v4 = v4; x.case1.v5 = v5;
    return x;
}
US8 US8_0() { // None
    US8 x;
    x.tag = 0;
    return x;
}
US8 US8_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, US0 v6) { // Some
    US8 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3; x.case1.v4 = v4; x.case1.v5 = v5; x.case1.v6 = v6;
    return x;
}
US9 US9_0() { // None
    US9 x;
    x.tag = 0;
    return x;
}
US9 US9_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6, US0 v7) { // Some
    US9 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3; x.case1.v4 = v4; x.case1.v5 = v5; x.case1.v6 = v6; x.case1.v7 = v7;
    return x;
}
US10 US10_0() { // None
    US10 x;
    x.tag = 0;
    return x;
}
US10 US10_1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, US0 v5, int32_t v6, int32_t v7) { // Some
    US10 x;
    x.tag = 1;
    x.case1.v0 = v0; x.case1.v1 = v1; x.case1.v2 = v2; x.case1.v3 = v3; x.case1.v4 = v4; x.case1.v5 = v5; x.case1.v6 = v6; x.case1.v7 = v7;
    return x;
}
void method0(){
    int32_t v0;
    v0 = 0l;
    int32_t v1;
    v1 = 1l;
    int32_t v2;
    v2 = 12l;
    int32_t v3;
    v3 = 3l;
    int32_t v4;
    v4 = 10l;
    US0 v5;
    v5 = US0_1();
    int32_t v6;
    v6 = 5l;
    int32_t v7;
    v7 = 5l;
    Array0 * v8;
    v8 = ArrayCreate0(73l);
    bool v9;
    v9 = 0l <= v7;
    bool v11;
    if (v9){
        v11 = v7 < 11l;
    } else {
        v11 = false;
    }
    if (v11){
        v8->ptr[v7] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v12;
    v12 = 0l <= v6;
    bool v14;
    if (v12){
        v14 = v6 < 11l;
    } else {
        v14 = false;
    }
    if (v14){
        int32_t v15;
        v15 = 11l + v6;
        v8->ptr[v15] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v16;
    v16 = 0l <= v4;
    bool v18;
    if (v16){
        v18 = v4 < 11l;
    } else {
        v18 = false;
    }
    if (v18){
        int32_t v19;
        v19 = 22l + v4;
        v8->ptr[v19] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v20;
    v20 = 0l <= v0;
    bool v22;
    if (v20){
        v22 = v0 < 13l;
    } else {
        v22 = false;
    }
    if (v22){
        int32_t v23;
        v23 = 33l + v0;
        v8->ptr[v23] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v24;
    v24 = 0l <= v1;
    bool v26;
    if (v24){
        v26 = v1 < 4l;
    } else {
        v26 = false;
    }
    if (v26){
        int32_t v27;
        v27 = 46l + v1;
        v8->ptr[v27] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v28;
    v28 = 0l <= v2;
    bool v30;
    if (v28){
        v30 = v2 < 13l;
    } else {
        v30 = false;
    }
    if (v30){
        int32_t v31;
        v31 = 50l + v2;
        v8->ptr[v31] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    bool v32;
    v32 = 0l <= v3;
    bool v34;
    if (v32){
        v34 = v3 < 4l;
    } else {
        v34 = false;
    }
    if (v34){
        int32_t v35;
        v35 = 63l + v3;
        v8->ptr[v35] = 1.0f;
    } else {
        fprintf(stderr, "%s\n", "Value out of bounds.")
        exit(EXIT_FAILURE);
    }
    switch (v5.tag) {
        case 0: { // Call
            v8->ptr[67l] = 1.0f;
            break;
        }
        case 1: { // NoAction
            v8->ptr[68l] = 1.0f;
            break;
        }
        case 2: { // Raise
            int32_t v36 = v5.case2.v0;
            bool v37;
            v37 = 0l <= v36;
            bool v39;
            if (v37){
                v39 = v36 < 4l;
            } else {
                v39 = false;
            }
            if (v39){
                int32_t v40;
                v40 = 69l + v36;
                v8->ptr[v40] = 1.0f;
            } else {
                fprintf(stderr, "%s\n", "Value out of bounds.")
                exit(EXIT_FAILURE);
            }
            break;
        }
    }
    printfn "%A" v8;
    int32_t v41;
    v41 = 0l;
    int32_t v42;
    v42 = 11l;
    US1 v43;
    v43 = method1(v8, v42, v41);
    int32_t v44;
    v44 = 11l;
    int32_t v45;
    v45 = 22l;
    US1 v46;
    v46 = method1(v8, v45, v44);
    int32_t v47;
    v47 = 22l;
    int32_t v48;
    v48 = 33l;
    US1 v49;
    v49 = method1(v8, v48, v47);
    int32_t v50;
    v50 = 33l;
    int32_t v51;
    v51 = 46l;
    US1 v52;
    v52 = method1(v8, v51, v50);
    int32_t v53;
    v53 = 46l;
    int32_t v54;
    v54 = 50l;
    US1 v55;
    v55 = method1(v8, v54, v53);
    US2 v65;
    switch (v52.tag) {
        case 0: { // None
            switch (v55.tag) {
                case 0: { // None
                    v65 = US2_0();
                    break;
                }
                case 1: { // Some
                    int32_t v57 = v55.case1.v0;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v60 = v52.case1.v0;
            switch (v55.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v62 = v55.case1.v0;
                    v65 = US2_1(v60, v62);
                    break;
                }
            }
            break;
        }
    }
    int32_t v66;
    v66 = 50l;
    int32_t v67;
    v67 = 63l;
    US1 v68;
    v68 = method1(v8, v67, v66);
    int32_t v69;
    v69 = 63l;
    int32_t v70;
    v70 = 67l;
    US1 v71;
    v71 = method1(v8, v70, v69);
    US2 v81;
    switch (v68.tag) {
        case 0: { // None
            switch (v71.tag) {
                case 0: { // None
                    v81 = US2_0();
                    break;
                }
                case 1: { // Some
                    int32_t v73 = v71.case1.v0;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v76 = v68.case1.v0;
            switch (v71.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v78 = v71.case1.v0;
                    v81 = US2_1(v76, v78);
                    break;
                }
            }
            break;
        }
    }
    US3 v94;
    switch (v65.tag) {
        case 0: { // None
            switch (v81.tag) {
                case 0: { // None
                    v94 = US3_0();
                    break;
                }
                case 1: { // Some
                    int32_t v83 = v81.case1.v0; int32_t v84 = v81.case1.v1;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v87 = v65.case1.v0; int32_t v88 = v65.case1.v1;
            switch (v81.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v90 = v81.case1.v0; int32_t v91 = v81.case1.v1;
                    v94 = US3_1(v87, v88, v90, v91);
                    break;
                }
            }
            break;
        }
    }
    float v95;
    v95 = v8->ptr[67l];
    bool v96;
    v96 = v95 == 1.0f;
    US4 v102;
    if (v96){
        v102 = US4_1();
    } else {
        bool v98;
        v98 = v95 == 0.0f;
        if (v98){
            v102 = US4_0();
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. The unit type should always be either be active or inactive.")
            exit(EXIT_FAILURE);
        }
    }
    US5 v106;
    switch (v102.tag) {
        case 0: { // None
            v106 = US5_0();
            break;
        }
        case 1: { // Some
            US0 v104;
            v104 = US0_0();
            v106 = US5_1(v104);
            break;
        }
    }
    float v107;
    v107 = v8->ptr[68l];
    bool v108;
    v108 = v107 == 1.0f;
    US4 v114;
    if (v108){
        v114 = US4_1();
    } else {
        bool v110;
        v110 = v107 == 0.0f;
        if (v110){
            v114 = US4_0();
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. The unit type should always be either be active or inactive.")
            exit(EXIT_FAILURE);
        }
    }
    US5 v118;
    switch (v114.tag) {
        case 0: { // None
            v118 = US5_0();
            break;
        }
        case 1: { // Some
            US0 v116;
            v116 = US0_1();
            v118 = US5_1(v116);
            break;
        }
    }
    int32_t v119;
    v119 = 69l;
    int32_t v120;
    v120 = 73l;
    US1 v121;
    v121 = method1(v8, v120, v119);
    US5 v126;
    switch (v121.tag) {
        case 0: { // None
            v126 = US5_0();
            break;
        }
        case 1: { // Some
            int32_t v123 = v121.case1.v0;
            US0 v124;
            v124 = US0_2(v123);
            v126 = US5_1(v124);
            break;
        }
    }
    US5 v129; int32_t v130;
    switch (v106.tag) {
        case 0: { // None
            US5 v127;
            v127 = US5_0();
            v129 = v127; v130 = 0l;
            break;
        }
        case 1: { // Some
            US0 v128 = v106.case1.v0;
            v129 = v106; v130 = 1l;
            break;
        }
    }
    US5 v133; int32_t v134;
    switch (v118.tag) {
        case 0: { // None
            v133 = v129; v134 = v130;
            break;
        }
        case 1: { // Some
            US0 v131 = v118.case1.v0;
            int32_t v132;
            v132 = v130 + 1l;
            v133 = v118; v134 = v132;
            break;
        }
    }
    US5 v137; int32_t v138;
    switch (v126.tag) {
        case 0: { // None
            v137 = v133; v138 = v134;
            break;
        }
        case 1: { // Some
            US0 v135 = v126.case1.v0;
            int32_t v136;
            v136 = v134 + 1l;
            v137 = v126; v138 = v136;
            break;
        }
    }
    bool v139;
    v139 = v138 == 0l;
    US5 v144;
    if (v139){
        v144 = US5_0();
    } else {
        bool v141;
        v141 = v138 == 1l;
        if (v141){
            v144 = v137;
        } else {
            fprintf(stderr, "%s\n", "Unpickling failure. Only a single case of an union type should be active at most.")
            exit(EXIT_FAILURE);
        }
    }
    US6 v157;
    switch (v94.tag) {
        case 0: { // None
            switch (v144.tag) {
                case 0: { // None
                    v157 = US6_0();
                    break;
                }
                case 1: { // Some
                    US0 v146 = v144.case1.v0;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v149 = v94.case1.v0; int32_t v150 = v94.case1.v1; int32_t v151 = v94.case1.v2; int32_t v152 = v94.case1.v3;
            switch (v144.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    US0 v154 = v144.case1.v0;
                    v157 = US6_1(v149, v150, v151, v152, v154);
                    break;
                }
            }
            break;
        }
    }
    US7 v175;
    switch (v49.tag) {
        case 0: { // None
            switch (v157.tag) {
                case 0: { // None
                    v175 = US7_0();
                    break;
                }
                case 1: { // Some
                    int32_t v159 = v157.case1.v0; int32_t v160 = v157.case1.v1; int32_t v161 = v157.case1.v2; int32_t v162 = v157.case1.v3; US0 v163 = v157.case1.v4;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v166 = v49.case1.v0;
            switch (v157.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v168 = v157.case1.v0; int32_t v169 = v157.case1.v1; int32_t v170 = v157.case1.v2; int32_t v171 = v157.case1.v3; US0 v172 = v157.case1.v4;
                    v175 = US7_1(v166, v168, v169, v170, v171, v172);
                    break;
                }
            }
            break;
        }
    }
    US8 v195;
    switch (v46.tag) {
        case 0: { // None
            switch (v175.tag) {
                case 0: { // None
                    v195 = US8_0();
                    break;
                }
                case 1: { // Some
                    int32_t v177 = v175.case1.v0; int32_t v178 = v175.case1.v1; int32_t v179 = v175.case1.v2; int32_t v180 = v175.case1.v3; int32_t v181 = v175.case1.v4; US0 v182 = v175.case1.v5;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v185 = v46.case1.v0;
            switch (v175.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v187 = v175.case1.v0; int32_t v188 = v175.case1.v1; int32_t v189 = v175.case1.v2; int32_t v190 = v175.case1.v3; int32_t v191 = v175.case1.v4; US0 v192 = v175.case1.v5;
                    v195 = US8_1(v185, v187, v188, v189, v190, v191, v192);
                    break;
                }
            }
            break;
        }
    }
    US9 v217;
    switch (v43.tag) {
        case 0: { // None
            switch (v195.tag) {
                case 0: { // None
                    v217 = US9_0();
                    break;
                }
                case 1: { // Some
                    int32_t v197 = v195.case1.v0; int32_t v198 = v195.case1.v1; int32_t v199 = v195.case1.v2; int32_t v200 = v195.case1.v3; int32_t v201 = v195.case1.v4; int32_t v202 = v195.case1.v5; US0 v203 = v195.case1.v6;
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
            }
            break;
        }
        case 1: { // Some
            int32_t v206 = v43.case1.v0;
            switch (v195.tag) {
                case 0: { // None
                    fprintf(stderr, "%s\n", "Unpickling failure. Two sides of a pair should either all be active or inactive.")
                    exit(EXIT_FAILURE);
                    break;
                }
                case 1: { // Some
                    int32_t v208 = v195.case1.v0; int32_t v209 = v195.case1.v1; int32_t v210 = v195.case1.v2; int32_t v211 = v195.case1.v3; int32_t v212 = v195.case1.v4; int32_t v213 = v195.case1.v5; US0 v214 = v195.case1.v6;
                    v217 = US9_1(v206, v208, v209, v210, v211, v212, v213, v214);
                    break;
                }
            }
            break;
        }
    }
    US10 v228;
    switch (v217.tag) {
        case 0: { // None
            v228 = US10_0();
            break;
        }
        case 1: { // Some
            int32_t v219 = v217.case1.v0; int32_t v220 = v217.case1.v1; int32_t v221 = v217.case1.v2; int32_t v222 = v217.case1.v3; int32_t v223 = v217.case1.v4; int32_t v224 = v217.case1.v5; int32_t v225 = v217.case1.v6; US0 v226 = v217.case1.v7;
            v228 = US10_1(v222, v223, v224, v225, v221, v226, v220, v219);
            break;
        }
    }
    int32_t v245; int32_t v246; int32_t v247; int32_t v248; int32_t v249; US0 v250; int32_t v251; int32_t v252;
    switch (v228.tag) {
        case 0: { // None
            fprintf(stderr, "%s\n", "Invalid format.")
            exit(EXIT_FAILURE);
            break;
        }
        case 1: { // Some
            int32_t v237 = v228.case1.v0; int32_t v238 = v228.case1.v1; int32_t v239 = v228.case1.v2; int32_t v240 = v228.case1.v3; int32_t v241 = v228.case1.v4; US0 v242 = v228.case1.v5; int32_t v243 = v228.case1.v6; int32_t v244 = v228.case1.v7;
            v245 = v237; v246 = v238; v247 = v239; v248 = v240; v249 = v241; v250 = v242; v251 = v243; v252 = v244;
            break;
        }
    }
    bool v253;
    v253 = v0 == v245;
    bool v255;
    if (v253){
        v255 = v1 == v246;
    } else {
        v255 = false;
    }
    bool v259;
    if (v255){
        bool v256;
        v256 = v2 == v247;
        if (v256){
            v259 = v3 == v248;
        } else {
            v259 = false;
        }
    } else {
        v259 = false;
    }
    bool v270;
    if (v259){
        bool v260;
        v260 = v4 == v249;
        if (v260){
            bool v264;
            switch (v5.tag == v250.tag ? v5.tag : -1) {
                case 0: { // Call
                    v264 = true;
                    break;
                }
                case 1: { // NoAction
                    v264 = true;
                    break;
                }
                case 2: { // Raise
                    int32_t v261 = v5.case2.v0;
                    int32_t v262 = v250.case2.v0;
                    v264 = v261 == v262;
                    break;
                }
                default: {
                    v264 = false;
                }
            }
            if (v264){
                bool v265;
                v265 = v6 == v251;
                if (v265){
                    v270 = v7 == v252;
                } else {
                    v270 = false;
                }
            } else {
                v270 = false;
            }
        } else {
            v270 = false;
        }
    } else {
        v270 = false;
    }
    bool v271;
    v271 = v270 == false;
    if (v271){
        fprintf(stderr, "%s\n", "Serialization and deserialization should result in the same result.")
        exit(EXIT_FAILURE);
    } else {
        return ;
    }
}
void main(){
    return method0();
}
