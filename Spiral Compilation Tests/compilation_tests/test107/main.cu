#include "main.auto.cu"
#include <thrust/device_vector.h>
namespace Device {
}
struct HeapRefs0;
struct StackRefs0;
struct Mut0;
struct StackMut0;
struct HeapRefs0 {
    int refc{0};
    int v0;
    HeapRefs0() = default;
    HeapRefs0(int t0) : v0(t0) {}
};
struct StackRefs0 {
    int v0;
    StackRefs0() = default;
    StackRefs0(int t0) : v0(t0) {}
};
struct Mut0 {
    int refc{0};
    int v0;
    Mut0() = default;
    Mut0(int t0) : v0(t0) {}
};
struct StackMut0 {
    int v0;
    StackMut0() = default;
    StackMut0(int t0) : v0(t0) {}
};
int main() {
    sptr<HeapRefs0> v0;
    v0 = sptr<HeapRefs0>{new HeapRefs0{0}};
    StackRefs0 v1{1};
    v0.base->v0 = 5;
    v1.v0 = 10;
    int & v2 = v0.base->v0;
    int & v3 = v1.v0;
    return 0;
}
