#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include <iostream>
bool method0(int32_t v0){
    bool v1;
    v1 = v0 < 10l;
    return v1;
}
int32_t main(){
    array<10l,int32_t> v0;
    int32_t v1;
    v1 = 0l;
    while (method0(v1)){
        v0.v[v1] = v1;
        v1++;
    }
    array<10l,int32_t> v3;
    int32_t v4;
    v4 = 0l;
    while (method0(v4)){
        int32_t v6;
        v6 = v0.v[v4];
        int32_t v7;
        v7 = v6 + 10l;
        v3.v[v4] = v7;
        v4++;
    }
    array<10l,int32_t> v8;
    int32_t v9;
    v9 = 0l;
    while (method0(v9)){
        int32_t v11;
        v11 = v3.v[v9];
        int32_t v12;
        v12 = v11 * 2l;
        v8.v[v9] = v12;
        v9++;
    }
    int32_t v13;
    v13 = 0l;
    while (method0(v13)){
        int32_t v15;
        v15 = v8.v[v13];
        std::cout << v15 << std::endl;
        v13++;
    }
    return 0l;
}
