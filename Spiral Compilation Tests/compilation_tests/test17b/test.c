#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method1(int32_t v0, uint64_t v1){
    bool v2;
    v2 = v1 == 0ull;
    if (v2){
        return v0;
    } else {
        uint64_t v3;
        v3 = v1 - 1ull;
        return method0(v0, v3);
    }
}
int32_t method0(int32_t v0, uint64_t v1){
    bool v2;
    v2 = v1 == 0ull;
    if (v2){
        return v0;
    } else {
        uint64_t v3;
        v3 = v1 - 1ull;
        return method1(v0, v3);
    }
}
int32_t main(){
    int32_t v0;
    v0 = 123l;
    uint64_t v1;
    v1 = 10ull;
    return method0(v0, v1);
}
