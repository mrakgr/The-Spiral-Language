#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include <iostream>
bool method1(int64_t v0){
    bool v1;
    v1 = v0 < 8ll;
    return v1;
}
void primary0(){
    int64_t v0[8ll];
    int64_t v1;
    v1 = 0ll;
    while (method1(v1)){
        int64_t v3;
        v3 = 1ll + v1;
        v0[v1] = v3;
        v1++;
    }
    int64_t v4[8ll];
    int64_t v5;
    v5 = 0ll;
    while (method1(v5)){
        int64_t v7;
        v7 = v0[v5];
        int64_t v8;
        v8 = v7 + 10ll;
        v4[v5] = v8;
        v5++;
    }
    int64_t v9[8ll];
    int64_t v10;
    v10 = 0ll;
    while (method1(v10)){
        int64_t v12;
        v12 = v4[v10];
        int64_t v13;
        v13 = v12 * 2ll;
        v9[v10] = v13;
        v10++;
    }
    int64_t v14;
    v14 = 0ll;
    while (method1(v14)){
        int64_t v16;
        v16 = v9[v14];
        std::cout << v16 << std::endl;
        v14++;
    }
    return ;
}
void main(){
    return primary0();
}
