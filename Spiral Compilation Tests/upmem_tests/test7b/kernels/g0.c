
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__mram_noinit uint8_t buffer[1024*1024*64];
bool method0(uint32_t v0, uint32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__host uint32_t v0;
__host uint32_t v1;
__host uint32_t v2;
__host uint32_t v3;
__host uint32_t v4;
int32_t main(){
    uint32_t v5 = 0u;
    while (method0(v3, v5)){
        int32_t v7;
        v7 = ((__mram_ptr int32_t *) (buffer + v2))[v5];
        int32_t v8;
        v8 = ((__mram_ptr int32_t *) (buffer + 0u))[v5];
        int32_t v9;
        v9 = v7 + v8;
        ((__mram_ptr int32_t *) (buffer + v4))[v5] = v9;
        v5 += 1u;
    }
    return 0;
}
