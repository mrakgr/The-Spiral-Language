#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include <iostream>
bool method0(int32_t v0){
    bool v1;
    v1 = v0 < 5l;
    return v1;
}
bool method1(int32_t v0){
    bool v1;
    v1 = v0 < 3l;
    return v1;
}
bool method2(int32_t v0){
    bool v1;
    v1 = v0 < 2l;
    return v1;
}
bool method3(int32_t v0){
    bool v1;
    v1 = v0 < 1l;
    return v1;
}
int32_t main(){
    array<5l,int32_t> v0;
    int32_t v1;
    v1 = 0l;
    while (method0(v1)){
        int32_t v3;
        v3 = v1 + 1l;
        v0.v[v1] = v3;
        v1++;
    }
    // start reduce;
    array<3l,int32_t> v4;
    int32_t v5;
    v5 = 0l;
    while (method1(v5)){
        int32_t v7;
        v7 = v5 * 2l;
        int32_t v8;
        v8 = v7 + 1l;
        bool v9;
        v9 = v8 < 5l;
        int32_t v14;
        if (v9){
            int32_t v10;
            v10 = v0.v[v7];
            int32_t v11;
            v11 = v0.v[v8];
            int32_t v12;
            v12 = v10 + v11;
            v14 = v12;
        } else {
            int32_t v13;
            v13 = v0.v[v7];
            v14 = v13;
        }
        v4.v[v5] = v14;
        v5++;
    }
    array<2l,int32_t> v15;
    int32_t v16;
    v16 = 0l;
    while (method2(v16)){
        int32_t v18;
        v18 = v16 * 2l;
        int32_t v19;
        v19 = v18 + 1l;
        bool v20;
        v20 = v19 < 3l;
        int32_t v25;
        if (v20){
            int32_t v21;
            v21 = v4.v[v18];
            int32_t v22;
            v22 = v4.v[v19];
            int32_t v23;
            v23 = v21 + v22;
            v25 = v23;
        } else {
            int32_t v24;
            v24 = v4.v[v18];
            v25 = v24;
        }
        v15.v[v16] = v25;
        v16++;
    }
    array<1l,int32_t> v26;
    int32_t v27;
    v27 = 0l;
    while (method3(v27)){
        int32_t v29;
        v29 = v27 * 2l;
        int32_t v30;
        v30 = v29 + 1l;
        bool v31;
        v31 = v30 < 2l;
        int32_t v36;
        if (v31){
            int32_t v32;
            v32 = v15.v[v29];
            int32_t v33;
            v33 = v15.v[v30];
            int32_t v34;
            v34 = v32 + v33;
            v36 = v34;
        } else {
            int32_t v35;
            v35 = v15.v[v29];
            v36 = v35;
        }
        v26.v[v27] = v36;
        v27++;
    }
    int32_t v37;
    v37 = v26.v[0l];
    std::cout << v37 << std::endl;
    return 0l;
}
