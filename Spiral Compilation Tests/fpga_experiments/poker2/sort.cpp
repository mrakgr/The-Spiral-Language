#include <cstdint>
#include <array>
#include "ap_int.h"
#include <random>
#include <iostream>
#include <algorithm>
struct Tuple0;
bool method1(int32_t v0);
bool method2(int32_t v0);
typedef bool (* Fun0)(int32_t, int32_t);
struct Tuple1;
bool method3(std::array<int32_t,2l> v0, bool v1, int32_t v2);
bool method4(std::array<int32_t,2l> v0, int32_t v1);
struct Tuple2;
bool method5(int32_t v0, int32_t v1, int32_t v2, int32_t v3);
struct US0;
bool method6(std::array<int32_t,2l> v0, bool v1, int32_t v2);
bool try_size0();
struct Tuple0 {
    int32_t v0;
    bool v1;
};
struct Tuple1 {
    int32_t v1;
    bool v0;
};
struct Tuple2 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
};
struct US0 {
    ap_uint<2> tag;
    union U {
        U() {}
    } v;
    US0() {}
    US0(const US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US0(const US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
    }
    US0 & operator=(US0 & x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
    US0 & operator=(US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
        }
        return *this;
    }
};
static inline Tuple0 TupleCreate0(int32_t v0, bool v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 1000l;
    return v1;
}
bool method2(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
bool ClosureMethod0(int32_t tup0, int32_t tup1){
    int32_t v0 = tup0; int32_t v1 = tup1;
    bool v2;
    v2 = v0 <= v1;
    return v2;
}
static inline Tuple1 TupleCreate1(bool v0, int32_t v1){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool method3(std::array<int32_t,2l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 2l;
    return v3;
}
bool method4(std::array<int32_t,2l> v0, int32_t v1){
    bool v2;
    v2 = v1 <= 2l;
    return v2;
}
static inline Tuple2 TupleCreate2(int32_t v0, int32_t v1, int32_t v2){
    Tuple2 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
bool method5(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
US0 US0_0() { // Eq
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // Gt
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_2() { // Lt
    US0 x;
    x.tag = 2;
    return x;
}
bool method6(std::array<int32_t,2l> v0, bool v1, int32_t v2){
    if (v1){
        bool v3;
        v3 = v2 < 2l;
        return v3;
    } else {
        return false;
    }
}
bool try_size0(){
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0l,51l);
    int32_t v3; bool v4;
    Tuple0 tmp0 = TupleCreate0(0l, true);
    v3 = tmp0.v0; v4 = tmp0.v1;
    while (method1(v3)){
        std::array<int32_t,2l> v6;
        int32_t v7;
        v7 = 0l;
        while (method2(v7)){
            int32_t v9;
            v9 = v2(v1);
            v6[v7] = v9;
            v7++;
        }
        std::array<int32_t,2l> v10;
        int32_t v11;
        v11 = 0l;
        while (method2(v11)){
            int32_t v13;
            v13 = v6[v11];
            v10[v11] = v13;
            v11++;
        }
        Fun0 v14;
        v14 = ClosureMethod0;
        std::stable_sort(v10.begin(),v10.end(),v14);
        std::array<int32_t,2l> v15;
        int32_t v16;
        v16 = 0l;
        while (method2(v16)){
            int32_t v18;
            v18 = v6[v16];
            v15[v16] = v18;
            v16++;
        }
        std::array<int32_t,2l> v19;
        int32_t v20;
        v20 = 0l;
        while (method2(v20)){
            int32_t v22;
            v22 = v15[v20];
            v19[v20] = v22;
            v20++;
        }
        bool v23; int32_t v24;
        Tuple1 tmp1 = TupleCreate1(true, 1l);
        v23 = tmp1.v0; v24 = tmp1.v1;
        while (method3(v15, v23, v24)){
            #pragma HLS INLINE;
            int32_t v26;
            v26 = 0l;
            while (method4(v15, v26)){
                #pragma HLS INLINE;
                int32_t v28;
                v28 = v26 + v24;
                bool v29;
                v29 = v28 < 2l;
                int32_t v30;
                if (v29){
                    v30 = v28;
                } else {
                    v30 = 2l;
                }
                int32_t v31;
                v31 = v24 * 2l;
                int32_t v32;
                v32 = v26 + v31;
                bool v33;
                v33 = v32 < 2l;
                int32_t v34;
                if (v33){
                    v34 = v32;
                } else {
                    v34 = 2l;
                }
                int32_t v35; int32_t v36; int32_t v37;
                Tuple2 tmp2 = TupleCreate2(v26, v30, v26);
                v35 = tmp2.v0; v36 = tmp2.v1; v37 = tmp2.v2;
                while (method5(v34, v35, v36, v37)){
                    #pragma HLS INLINE;
                    bool v39;
                    v39 = v35 < v30;
                    bool v41;
                    if (v39){
                        bool v40;
                        v40 = v36 < v34;
                        v41 = v40;
                    } else {
                        v41 = false;
                    }
                    int32_t v71; int32_t v72; int32_t v73;
                    if (v41){
                        int32_t v44;
                        if (v23){
                            int32_t v42;
                            v42 = v15[v35];
                            v44 = v42;
                        } else {
                            int32_t v43;
                            v43 = v19[v35];
                            v44 = v43;
                        }
                        int32_t v47;
                        if (v23){
                            int32_t v45;
                            v45 = v15[v36];
                            v47 = v45;
                        } else {
                            int32_t v46;
                            v46 = v19[v36];
                            v47 = v46;
                        }
                        bool v48;
                        v48 = v44 < v47;
                        US0 v54;
                        if (v48){
                            v54 = US0_2();
                        } else {
                            bool v50;
                            v50 = v44 > v47;
                            if (v50){
                                v54 = US0_1();
                            } else {
                                v54 = US0_0();
                            }
                        }
                        switch (v54.tag) {
                            case 1: { // Gt
                                int32_t v55;
                                v55 = v36 + 1l;
                                v71 = v47; v72 = v35; v73 = v55;
                                break;
                            }
                            default: {
                                int32_t v56;
                                v56 = v35 + 1l;
                                v71 = v44; v72 = v56; v73 = v36;
                            }
                        }
                    } else {
                        if (v39){
                            int32_t v62;
                            if (v23){
                                int32_t v60;
                                v60 = v15[v35];
                                v62 = v60;
                            } else {
                                int32_t v61;
                                v61 = v19[v35];
                                v62 = v61;
                            }
                            int32_t v63;
                            v63 = v35 + 1l;
                            v71 = v62; v72 = v63; v73 = v36;
                        } else {
                            int32_t v66;
                            if (v23){
                                int32_t v64;
                                v64 = v15[v36];
                                v66 = v64;
                            } else {
                                int32_t v65;
                                v65 = v19[v36];
                                v66 = v65;
                            }
                            int32_t v67;
                            v67 = v36 + 1l;
                            v71 = v66; v72 = v35; v73 = v67;
                        }
                    }
                    if (v23){
                        v19[v37] = v71;
                    } else {
                        v15[v37] = v71;
                    }
                    int32_t v74;
                    v74 = v37 + 1l;
                    v35 = v72;
                    v36 = v73;
                    v37 = v74;
                }
                v26 = v32;
            }
            std::cout << "***\n" ;
            bool v75;
            v75 = v23 == false;
            int32_t v76;
            v76 = v24 * 2l;
            v23 = v75;
            v24 = v76;
        }
        bool v77;
        v77 = v23 == false;
        std::array<int32_t,2l> v78;
        if (v77){
            v78 = v19;
        } else {
            v78 = v15;
        }
        bool v79; int32_t v80;
        Tuple1 tmp3 = TupleCreate1(true, 0l);
        v79 = tmp3.v0; v80 = tmp3.v1;
        while (method6(v10, v79, v80)){
            int32_t v82;
            v82 = v10[v80];
            int32_t v83;
            v83 = v78[v80];
            bool v84;
            v84 = v82 == v83;
            int32_t v85;
            v85 = v80 + 1l;
            v79 = v84;
            v80 = v85;
        }
        bool v95;
        if (v79){
            v95 = true;
        } else {
            std::cout << "Error:\n";
            int32_t v86;
            v86 = 0l;
            while (method2(v86)){
                int32_t v88;
                v88 = v6[v86];
                std::cout << v88 << std::endl;
                v86++;
            }
            std::cout << "---\n";
            int32_t v89;
            v89 = 0l;
            while (method2(v89)){
                int32_t v91;
                v91 = v10[v89];
                std::cout << v91 << std::endl;
                v89++;
            }
            std::cout << "---\n";
            int32_t v92;
            v92 = 0l;
            while (method2(v92)){
                int32_t v94;
                v94 = v78[v92];
                std::cout << v94 << std::endl;
                v92++;
            }
            v95 = false;
        }
        bool v96;
        v96 = v95 && v4;
        v4 = v96;
        v3++;
    }
    std::cout << "///\n";
    return v4;
}
int32_t entry() {
    bool v0;
    v0 = try_size0();
    if (v0){
        return 0l;
    } else {
        return 1l;
    }
}
