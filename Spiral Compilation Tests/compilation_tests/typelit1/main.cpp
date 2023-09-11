#include <cstdint>
template <int dim, typename el> struct array { el v[dim]; };
typedef struct {
    float v0;
    int32_t v1;
} Tuple0;
static inline Tuple0 TupleCreate0(float v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
void main(){
    array<16l,Tuple0> v0;
    return ;
}
