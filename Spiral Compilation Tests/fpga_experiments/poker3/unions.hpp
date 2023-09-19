#ifndef _ENTRY
#define _ENTRY
#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include "ap_int.h"
struct US0 {
    unsigned int tag : 1;
    union U {
        struct {
            ap_uint<2l> v0;
        } case1; // Some
        U() {}
    } v;
    US0() {}
    US0(const US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
    }
    US0 & operator=(US0 && x) {
        this->tag = x.tag;
        switch (x.tag) {
            case 1: { this->v.case1 = x.v.case1; break; }
        }
        return *this;
    }
};
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(ap_uint<2l> v0) { // Some
    US0 x;
    x.tag = 1;
    x.v.case1.v0 = v0;
    return x;
}
int32_t entry(){
    ap_uint<2l> v0;
    v0 = 0;
    US0 v1;
    v1 = US0_1(v0);
    US0 v2;
    v2 = US0_0();
    bool v6;
    if (v2.tag == v1.tag) {
        switch (v2.tag) {
            case 0: { // None
                v6 = true;
                break;
            }
            case 1: { // Some
                ap_uint<2l> v3 = v2.v.case1.v0;
                ap_uint<2l> v4 = v1.v.case1.v0;
                bool v5;
                v5 = v3 == v4;
                v6 = v5;
                break;
            }
        }
    } else {
        v6 = false;
    }
    return 0l;
}
#endif
