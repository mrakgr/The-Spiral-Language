
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__mram_noinit uint8_t buffer[1024*1024*64];
__host uint32_t v0;
__host uint32_t v1;
__host uint32_t v2;
__host uint32_t v3;
__host uint32_t v4;
int32_t main(){
    int32_t v5;
    v5 = ((__mram_ptr int32_t *) (buffer + v2))[3u];
    int32_t v6;
    v6 = ((__mram_ptr int32_t *) (buffer + 0u))[3u];
    int32_t v7;
    v7 = v5 + v6;
    ((__mram_ptr int32_t *) (buffer + v4))[3u] = v7;
    return 0;
}
