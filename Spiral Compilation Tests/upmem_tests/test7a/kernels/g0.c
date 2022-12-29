
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
    bool v5;
    v5 = 3u < v1;
    if (v5){
        ((__mram_ptr char *) NULL)[0] = -123;;
    } else {
    }
    int32_t v6;
    v6 = ((__mram_ptr int32_t *) (buffer + v2))[3u];
    bool v7;
    v7 = 3u < v0;
    if (v7){
        ((__mram_ptr char *) NULL)[0] = -123;;
    } else {
    }
    int32_t v8;
    v8 = ((__mram_ptr int32_t *) (buffer + 0u))[3u];
    int32_t v9;
    v9 = v6 + v8;
    bool v10;
    v10 = 3u < v3;
    if (v10){
        ((__mram_ptr char *) NULL)[0] = -123;;
    } else {
    }
    ((__mram_ptr int32_t *) (buffer + v4))[3u] = v9;
    return 0;
}
