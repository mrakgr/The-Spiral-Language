#include "main.auto.cu"
#include <thrust/device_vector.h>
namespace Device {
}
struct HeapRefs0;
struct StackRefs0;
struct HeapRefs0 {
    int refc{0};
    int v0;
    HeapRefs0() = default;
    HeapRefs0(int t0) : v0(t0) {}
};
struct StackRefs0 {
    int & v0;
    float & v2;
    bool & v1;
    StackRefs0() = default;
    StackRefs0(int & t0, bool & t1, float & t2) : v0(t0), v1(t1), v2(t2) {}
};
int main() {
    sptr<HeapRefs0> v0;
    v0 = sptr<HeapRefs0>{new HeapRefs0{0}};
    int v1;
    v1 = 1;
    bool v2;
    v2 = true;
    float v3;
    v3 = 5.0f;
    StackRefs0 v4{v1, v2, v3};
    v0.base->v0 = 5;
    v4.v0 = 10;
    int & v5 = v0.base->v0;
    int & v6 = v4.v0; bool & v7 = v4.v1; float & v8 = v4.v2;
    return 0;
}
