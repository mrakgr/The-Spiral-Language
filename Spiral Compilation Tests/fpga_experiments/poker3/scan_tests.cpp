#include <cstdint>
#include <array>
#include "ap_int.h"
#include <iostream>
struct Tuple0;
bool method0(int32_t v0);
struct Tuple1;
bool method1(int32_t v0);
bool method2(int32_t v0);
bool method3(int32_t v0);
bool method4(int32_t v0);
struct Tuple2;
bool method5(std::array<int32_t,10l> v0, int32_t v1);
struct Tuple0 {
    ap_uint<128l> v1;
    int32_t v0;
};
struct Tuple1 {
    int32_t v0;
    int32_t v1;
};
struct Tuple2 {
    std::array<int32_t,10l> v0;
    int32_t v1;
};
static inline Tuple0 TupleCreate0(int32_t v0, ap_uint<128l> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method0(int32_t v0){
    bool v1;
    v1 = v0 < 10l;
    return v1;
}
static inline Tuple1 TupleCreate1(int32_t v0, int32_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
bool method2(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool method3(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
bool method4(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
static inline Tuple2 TupleCreate2(std::array<int32_t,10l> v0, int32_t v1){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method5(std::array<int32_t,10l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 10l;
    return v2;
}
int32_t entry() {
    std::array<int32_t,10l> v0;
    ap_uint<64l> v1;
    v1 = 0b1101011010100110111111000010111101111111100001011011100001111110;
    ap_uint<64l> v2;
    v2 = 0b1000001110011100000101101011010000000100101010110010110000110000;
    ap_uint<128l> v3;
    v3 = v1.concat(v2);
    int32_t v4; ap_uint<128l> v5;
    Tuple0 tmp0 = TupleCreate0(0l, v3);
    v4 = tmp0.v0; v5 = tmp0.v1;
    while (method0(v4)){
        v0[v4] = v4;
        v5 = v5;
        v4++;
    }
    std::array<int32_t,10l> v7;
    int32_t v8; int32_t v9;
    Tuple1 tmp1 = TupleCreate1(0l, 0l);
    v8 = tmp1.v0; v9 = tmp1.v1;
    while (method0(v8)){
        int32_t v11;
        v11 = v0[v8];
        int32_t v12;
        v12 = v9 + v11;
        v7[v8] = v9;
        v9 = v12;
        v8++;
    }
    std::array<int32_t,5l> v13;
    int32_t v14;
    v14 = 0l;
    while (method1(v14)){
        int32_t v16;
        v16 = v14 * 2l;
        int32_t v17;
        v17 = v16 + 1l;
        bool v18;
        v18 = v17 < 10l;
        int32_t v23;
        if (v18){
            int32_t v19;
            v19 = v0[v16];
            int32_t v20;
            v20 = v0[v17];
            int32_t v21;
            v21 = v19 + v20;
            v23 = v21;
        } else {
            int32_t v22;
            v22 = v0[v16];
            v23 = v22;
        }
        v13[v14] = v23;
        v14++;
    }
    std::array<int32_t,3l> v24;
    int32_t v25;
    v25 = 0l;
    while (method2(v25)){
        int32_t v27;
        v27 = v25 * 2l;
        int32_t v28;
        v28 = v27 + 1l;
        bool v29;
        v29 = v28 < 5l;
        int32_t v34;
        if (v29){
            int32_t v30;
            v30 = v13[v27];
            int32_t v31;
            v31 = v13[v28];
            int32_t v32;
            v32 = v30 + v31;
            v34 = v32;
        } else {
            int32_t v33;
            v33 = v13[v27];
            v34 = v33;
        }
        v24[v25] = v34;
        v25++;
    }
    std::array<int32_t,2l> v35;
    int32_t v36;
    v36 = 0l;
    while (method3(v36)){
        int32_t v38;
        v38 = v36 * 2l;
        int32_t v39;
        v39 = v38 + 1l;
        bool v40;
        v40 = v39 < 3l;
        int32_t v45;
        if (v40){
            int32_t v41;
            v41 = v24[v38];
            int32_t v42;
            v42 = v24[v39];
            int32_t v43;
            v43 = v41 + v42;
            v45 = v43;
        } else {
            int32_t v44;
            v44 = v24[v38];
            v45 = v44;
        }
        v35[v36] = v45;
        v36++;
    }
    std::array<int32_t,1l> v46;
    int32_t v47;
    v47 = 0l;
    while (method4(v47)){
        int32_t v49;
        v49 = v47 * 2l;
        int32_t v50;
        v50 = v49 + 1l;
        bool v51;
        v51 = v50 < 2l;
        int32_t v56;
        if (v51){
            int32_t v52;
            v52 = v35[v49];
            int32_t v53;
            v53 = v35[v50];
            int32_t v54;
            v54 = v52 + v53;
            v56 = v54;
        } else {
            int32_t v55;
            v55 = v35[v49];
            v56 = v55;
        }
        v46[v47] = v56;
        v47++;
    }
    int32_t v57;
    v57 = v46[0l];
    std::cout << v9 << " " << v57 << std::endl;
    std::cout << "---" << std::endl;
    std::array<int32_t,10l> v58;
    int32_t v59;
    v59 = 0l;
    while (method0(v59)){
        int32_t v61;
        v61 = v0[v59];
        v58[v59] = v61;
        v59++;
    }
    std::array<int32_t,5l> v62;
    int32_t v63;
    v63 = 0l;
    while (method1(v63)){
        int32_t v65;
        v65 = v63 * 2l;
        int32_t v66;
        v66 = v65 + 1l;
        bool v67;
        v67 = v66 < 10l;
        int32_t v72;
        if (v67){
            int32_t v68;
            v68 = v58[v65];
            int32_t v69;
            v69 = v58[v66];
            int32_t v70;
            v70 = v68 + v69;
            v72 = v70;
        } else {
            int32_t v71;
            v71 = v58[v65];
            v72 = v71;
        }
        v62[v63] = v72;
        v63++;
    }
    std::array<int32_t,3l> v73;
    int32_t v74;
    v74 = 0l;
    while (method2(v74)){
        int32_t v76;
        v76 = v74 * 2l;
        int32_t v77;
        v77 = v76 + 1l;
        bool v78;
        v78 = v77 < 5l;
        int32_t v83;
        if (v78){
            int32_t v79;
            v79 = v62[v76];
            int32_t v80;
            v80 = v62[v77];
            int32_t v81;
            v81 = v79 + v80;
            v83 = v81;
        } else {
            int32_t v82;
            v82 = v62[v76];
            v83 = v82;
        }
        v73[v74] = v83;
        v74++;
    }
    std::array<int32_t,2l> v84;
    int32_t v85;
    v85 = 0l;
    while (method3(v85)){
        int32_t v87;
        v87 = v85 * 2l;
        int32_t v88;
        v88 = v87 + 1l;
        bool v89;
        v89 = v88 < 3l;
        int32_t v94;
        if (v89){
            int32_t v90;
            v90 = v73[v87];
            int32_t v91;
            v91 = v73[v88];
            int32_t v92;
            v92 = v90 + v91;
            v94 = v92;
        } else {
            int32_t v93;
            v93 = v73[v87];
            v94 = v93;
        }
        v84[v85] = v94;
        v85++;
    }
    std::array<int32_t,1l> v95;
    int32_t v96;
    v96 = 0l;
    while (method4(v96)){
        int32_t v98;
        v98 = v96 * 2l;
        int32_t v99;
        v99 = v98 + 1l;
        bool v100;
        v100 = v99 < 2l;
        int32_t v105;
        if (v100){
            int32_t v101;
            v101 = v84[v98];
            int32_t v102;
            v102 = v84[v99];
            int32_t v103;
            v103 = v101 + v102;
            v105 = v103;
        } else {
            int32_t v104;
            v104 = v84[v98];
            v105 = v104;
        }
        v95[v96] = v105;
        v96++;
    }
    v95[0l] = 0l;
    int32_t v106;
    v106 = 0l;
    while (method4(v106)){
        int32_t v108;
        v108 = v95[v106];
        int32_t v109;
        v109 = v106 * 2l;
        int32_t v110;
        v110 = v109 + 1l;
        bool v111;
        v111 = v110 < 2l;
        if (v111){
            int32_t v112;
            v112 = v84[v109];
            int32_t v113;
            v113 = v112 + v108;
            v84[v110] = v113;
        } else {
        }
        v84[v109] = v108;
        v106++;
    }
    int32_t v114;
    v114 = 0l;
    while (method3(v114)){
        int32_t v116;
        v116 = v84[v114];
        int32_t v117;
        v117 = v114 * 2l;
        int32_t v118;
        v118 = v117 + 1l;
        bool v119;
        v119 = v118 < 3l;
        if (v119){
            int32_t v120;
            v120 = v73[v117];
            int32_t v121;
            v121 = v120 + v116;
            v73[v118] = v121;
        } else {
        }
        v73[v117] = v116;
        v114++;
    }
    int32_t v122;
    v122 = 0l;
    while (method2(v122)){
        int32_t v124;
        v124 = v73[v122];
        int32_t v125;
        v125 = v122 * 2l;
        int32_t v126;
        v126 = v125 + 1l;
        bool v127;
        v127 = v126 < 5l;
        if (v127){
            int32_t v128;
            v128 = v62[v125];
            int32_t v129;
            v129 = v128 + v124;
            v62[v126] = v129;
        } else {
        }
        v62[v125] = v124;
        v122++;
    }
    int32_t v130;
    v130 = 0l;
    while (method1(v130)){
        int32_t v132;
        v132 = v62[v130];
        int32_t v133;
        v133 = v130 * 2l;
        int32_t v134;
        v134 = v133 + 1l;
        bool v135;
        v135 = v134 < 10l;
        if (v135){
            int32_t v136;
            v136 = v58[v133];
            int32_t v137;
            v137 = v136 + v132;
            v58[v134] = v137;
        } else {
        }
        v58[v133] = v132;
        v130++;
    }
    std::array<int32_t,10l> v138; int32_t v139;
    Tuple2 tmp2 = TupleCreate2(v0, 1l);
    v138 = tmp2.v0; v139 = tmp2.v1;
    while (method5(v138, v139)){
        #pragma HLS UNROLL
        std::array<int32_t,10l> v141;
        int32_t v142;
        v142 = 0l;
        while (method0(v142)){
            int32_t v144;
            v144 = v142 - v139;
            bool v145;
            v145 = 0l <= v144;
            int32_t v150;
            if (v145){
                int32_t v146;
                v146 = v138[v144];
                int32_t v147;
                v147 = v138[v142];
                int32_t v148;
                v148 = v146 + v147;
                v150 = v148;
            } else {
                int32_t v149;
                v149 = v138[v142];
                v150 = v149;
            }
            v141[v142] = v150;
            v142++;
        }
        int32_t v151;
        v151 = v139 * 2l;
        v138 = v141;
        v139 = v151;
    }
    int32_t v152;
    v152 = 0l;
    while (method0(v152)){
        int32_t v154;
        v154 = v7[v152];
        int32_t v155;
        v155 = v58[v152];
        int32_t v156;
        v156 = v138[v152];
        std::cout << v154 << " " << v155 << " " << v156 << std::endl;
        v152++;
    }
    return 0l;
}
