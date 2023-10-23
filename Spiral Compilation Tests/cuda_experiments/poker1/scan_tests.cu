#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177
#include <cstdint>
#include <array>
#include <iostream>
struct Tuple0;
struct Tuple0 {
    int32_t v0;
    int32_t v1;
};
inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 10l;
    return v1;
}
inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
inline bool while_method_1(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
inline bool while_method_2(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
inline bool while_method_3(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
inline bool while_method_4(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
inline bool while_method_5(std::array<int32_t,10l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 10l;
    return v2;
}
inline bool while_method_6(int32_t v0, int32_t v1){
    bool v2;
    v2 = v1 > v0;
    return v2;
}
int32_t main() {
    std::array<int32_t,10l> v0;
    int32_t v1;
    v1 = 0l;
    while (while_method_0(v1)){
        v0[v1] = v1;
        v1++;
    }
    std::array<int32_t,10l> v3;
    int32_t v4; int32_t v5;
    Tuple0 tmp0 = TupleCreate0(0l, 0l);
    v4 = tmp0.v0; v5 = tmp0.v1;
    while (while_method_0(v4)){
        int32_t v7;
        v7 = v0[v4];
        int32_t v8;
        v8 = v5 + v7;
        v3[v4] = v5;
        v5 = v8;
        v4++;
    }
    std::array<int32_t,5l> v9;
    int32_t v10;
    v10 = 0l;
    while (while_method_1(v10)){
        int32_t v12;
        v12 = v10 * 2l;
        int32_t v13;
        v13 = v12 + 1l;
        bool v14;
        v14 = v13 < 10l;
        int32_t v19;
        if (v14){
            int32_t v15;
            v15 = v0[v12];
            int32_t v16;
            v16 = v0[v13];
            int32_t v17;
            v17 = v15 + v16;
            v19 = v17;
        } else {
            int32_t v18;
            v18 = v0[v12];
            v19 = v18;
        }
        v9[v10] = v19;
        v10++;
    }
    std::array<int32_t,3l> v20;
    int32_t v21;
    v21 = 0l;
    while (while_method_2(v21)){
        int32_t v23;
        v23 = v21 * 2l;
        int32_t v24;
        v24 = v23 + 1l;
        bool v25;
        v25 = v24 < 5l;
        int32_t v30;
        if (v25){
            int32_t v26;
            v26 = v9[v23];
            int32_t v27;
            v27 = v9[v24];
            int32_t v28;
            v28 = v26 + v27;
            v30 = v28;
        } else {
            int32_t v29;
            v29 = v9[v23];
            v30 = v29;
        }
        v20[v21] = v30;
        v21++;
    }
    std::array<int32_t,2l> v31;
    int32_t v32;
    v32 = 0l;
    while (while_method_3(v32)){
        int32_t v34;
        v34 = v32 * 2l;
        int32_t v35;
        v35 = v34 + 1l;
        bool v36;
        v36 = v35 < 3l;
        int32_t v41;
        if (v36){
            int32_t v37;
            v37 = v20[v34];
            int32_t v38;
            v38 = v20[v35];
            int32_t v39;
            v39 = v37 + v38;
            v41 = v39;
        } else {
            int32_t v40;
            v40 = v20[v34];
            v41 = v40;
        }
        v31[v32] = v41;
        v32++;
    }
    std::array<int32_t,1l> v42;
    int32_t v43;
    v43 = 0l;
    while (while_method_4(v43)){
        int32_t v45;
        v45 = v43 * 2l;
        int32_t v46;
        v46 = v45 + 1l;
        bool v47;
        v47 = v46 < 2l;
        int32_t v52;
        if (v47){
            int32_t v48;
            v48 = v31[v45];
            int32_t v49;
            v49 = v31[v46];
            int32_t v50;
            v50 = v48 + v49;
            v52 = v50;
        } else {
            int32_t v51;
            v51 = v31[v45];
            v52 = v51;
        }
        v42[v43] = v52;
        v43++;
    }
    int32_t v53;
    v53 = v42[0l];
    std::cout << v5 << " " << v53 << std::endl;
    std::cout << "---" << std::endl;
    std::array<int32_t,10l> v54;
    int32_t v55;
    v55 = 0l;
    while (while_method_0(v55)){
        int32_t v57;
        v57 = v0[v55];
        v54[v55] = v57;
        v55++;
    }
    std::array<int32_t,5l> v58;
    int32_t v59;
    v59 = 0l;
    while (while_method_1(v59)){
        int32_t v61;
        v61 = v59 * 2l;
        int32_t v62;
        v62 = v61 + 1l;
        bool v63;
        v63 = v62 < 10l;
        int32_t v68;
        if (v63){
            int32_t v64;
            v64 = v54[v61];
            int32_t v65;
            v65 = v54[v62];
            int32_t v66;
            v66 = v64 + v65;
            v68 = v66;
        } else {
            int32_t v67;
            v67 = v54[v61];
            v68 = v67;
        }
        v58[v59] = v68;
        v59++;
    }
    std::array<int32_t,3l> v69;
    int32_t v70;
    v70 = 0l;
    while (while_method_2(v70)){
        int32_t v72;
        v72 = v70 * 2l;
        int32_t v73;
        v73 = v72 + 1l;
        bool v74;
        v74 = v73 < 5l;
        int32_t v79;
        if (v74){
            int32_t v75;
            v75 = v58[v72];
            int32_t v76;
            v76 = v58[v73];
            int32_t v77;
            v77 = v75 + v76;
            v79 = v77;
        } else {
            int32_t v78;
            v78 = v58[v72];
            v79 = v78;
        }
        v69[v70] = v79;
        v70++;
    }
    std::array<int32_t,2l> v80;
    int32_t v81;
    v81 = 0l;
    while (while_method_3(v81)){
        int32_t v83;
        v83 = v81 * 2l;
        int32_t v84;
        v84 = v83 + 1l;
        bool v85;
        v85 = v84 < 3l;
        int32_t v90;
        if (v85){
            int32_t v86;
            v86 = v69[v83];
            int32_t v87;
            v87 = v69[v84];
            int32_t v88;
            v88 = v86 + v87;
            v90 = v88;
        } else {
            int32_t v89;
            v89 = v69[v83];
            v90 = v89;
        }
        v80[v81] = v90;
        v81++;
    }
    std::array<int32_t,1l> v91;
    int32_t v92;
    v92 = 0l;
    while (while_method_4(v92)){
        int32_t v94;
        v94 = v92 * 2l;
        int32_t v95;
        v95 = v94 + 1l;
        bool v96;
        v96 = v95 < 2l;
        int32_t v101;
        if (v96){
            int32_t v97;
            v97 = v80[v94];
            int32_t v98;
            v98 = v80[v95];
            int32_t v99;
            v99 = v97 + v98;
            v101 = v99;
        } else {
            int32_t v100;
            v100 = v80[v94];
            v101 = v100;
        }
        v91[v92] = v101;
        v92++;
    }
    v91[0l] = 0l;
    int32_t v102;
    v102 = 0l;
    while (while_method_4(v102)){
        int32_t v104;
        v104 = v91[v102];
        int32_t v105;
        v105 = v102 * 2l;
        int32_t v106;
        v106 = v105 + 1l;
        bool v107;
        v107 = v106 < 2l;
        if (v107){
            int32_t v108;
            v108 = v80[v105];
            int32_t v109;
            v109 = v108 + v104;
            v80[v106] = v109;
        } else {
        }
        v80[v105] = v104;
        v102++;
    }
    int32_t v110;
    v110 = 0l;
    while (while_method_3(v110)){
        int32_t v112;
        v112 = v80[v110];
        int32_t v113;
        v113 = v110 * 2l;
        int32_t v114;
        v114 = v113 + 1l;
        bool v115;
        v115 = v114 < 3l;
        if (v115){
            int32_t v116;
            v116 = v69[v113];
            int32_t v117;
            v117 = v116 + v112;
            v69[v114] = v117;
        } else {
        }
        v69[v113] = v112;
        v110++;
    }
    int32_t v118;
    v118 = 0l;
    while (while_method_2(v118)){
        int32_t v120;
        v120 = v69[v118];
        int32_t v121;
        v121 = v118 * 2l;
        int32_t v122;
        v122 = v121 + 1l;
        bool v123;
        v123 = v122 < 5l;
        if (v123){
            int32_t v124;
            v124 = v58[v121];
            int32_t v125;
            v125 = v124 + v120;
            v58[v122] = v125;
        } else {
        }
        v58[v121] = v120;
        v118++;
    }
    int32_t v126;
    v126 = 0l;
    while (while_method_1(v126)){
        int32_t v128;
        v128 = v58[v126];
        int32_t v129;
        v129 = v126 * 2l;
        int32_t v130;
        v130 = v129 + 1l;
        bool v131;
        v131 = v130 < 10l;
        if (v131){
            int32_t v132;
            v132 = v54[v129];
            int32_t v133;
            v133 = v132 + v128;
            v54[v130] = v133;
        } else {
        }
        v54[v129] = v128;
        v126++;
    }
    std::array<int32_t,10l> v134;
    int32_t v135;
    v135 = 0l;
    while (while_method_0(v135)){
        int32_t v137;
        v137 = v0[v135];
        v134[v135] = v137;
        v135++;
    }
    int32_t v138;
    v138 = 1l;
    while (while_method_5(v134, v138)){
        int32_t v140;
        v140 = 10l;
        while (while_method_6(v138, v140)){
            v140--;
            int32_t v142;
            v142 = v140 - v138;
            int32_t v143;
            v143 = v134[v142];
            int32_t v144;
            v144 = v134[v140];
            int32_t v145;
            v145 = v143 + v144;
            v134[v140] = v145;
        }
        int32_t v146;
        v146 = v138 * 2l;
        v138 = v146;
    }
    int32_t v147;
    v147 = 0l;
    while (while_method_0(v147)){
        int32_t v149;
        v149 = v3[v147];
        int32_t v150;
        v150 = v54[v147];
        int32_t v151;
        v151 = v134[v147];
        std::cout << v149 << " " << v150 << " " << v151 << std::endl;
        v147++;
    }
    return 0l;
}
