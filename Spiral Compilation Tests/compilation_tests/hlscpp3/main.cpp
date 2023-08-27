#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include <iostream>
int32_t main(){
    array<5,int64_t> q = {1,2,3,4,5};
    return 0l;
}
