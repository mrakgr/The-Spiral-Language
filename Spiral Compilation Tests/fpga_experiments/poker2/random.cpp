#include <cstdint>
#include <array>
#include "ap_int.h"
#include <random>
#include <iostream>
int32_t test_random0();
int32_t test_random0(){
    std::random_device v0;
    std::mt19937 v1(v0());
    std::uniform_int_distribution<std::mt19937::result_type> v2(0l,100l);
    int32_t v3;
    v3 = v2(v1);
    return v3;
}
int32_t entry() {
    int32_t v0;
    v0 = test_random0();
    std::cout << v0 << std::endl;
    return 0l;
}
