#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
#include "ap_int.h"
template <int dim, typename el> struct array { el v[dim]; };
#include <algorithm>
typedef struct {
    ap_uint<4l> v0;
    ap_uint<2l> v1;
} Tuple0;
typedef bool (* Fun0)(Tuple0, Tuple0);
static inline Tuple0 TupleCreate0(ap_uint<4l> v0, ap_uint<2l> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
bool ClosureMethod0(Tuple0 tup0, Tuple0 tup1){
    ap_uint<4l> v0 = tup0.v0; ap_uint<2l> v1 = tup0.v1; ap_uint<4l> v2 = tup1.v0; ap_uint<2l> v3 = tup1.v1;
    bool v4;
    v4 = v0 > v2;
    if (v4){
        return true;
    } else {
        bool v5;
        v5 = v0 == v2;
        if (v5){
            bool v6;
            v6 = v1 < v3;
            return v6;
        } else {
            return false;
        }
    }
}
int32_t entry(){
    array<8l,Tuple0> v0;
    Fun0 v1;
    v1 = ClosureMethod0;
    std::sort(v0.v,v0.v+8l,v1);
    return 0l;
}
#endif
