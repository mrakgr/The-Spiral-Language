#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
#include "ap_int.h"
typedef struct {
    ap_uint<4> v0;
    ap_uint<2> v1;
} Tuple0;
static inline Tuple0 TupleCreate0(ap_uint<4> v0, ap_uint<2> v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
void main(){
    array<5l,Tuple0> v0;
    return ;
}
