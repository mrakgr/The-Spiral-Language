
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
__mram_noinit uint8_t buffer[1024*1024*64];
bool method0(uint32_t v0){
    bool v1;
    v1 = v0 < 64ul;
    return v1;
}
bool method1(uint32_t v0, uint32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
int32_t main(){
    __dma_aligned int32_t v0[8ul];
    __dma_aligned int32_t v1[8ul];
    __dma_aligned int32_t v2[8ul];
    uint32_t v3 = 0ul;
    while (method0(v3)){
        uint32_t v5;
        v5 = v3 + 8ul;
        bool v6;
        v6 = 64ul < v5;
        uint32_t v7;
        if (v6){
            v7 = 64ul;
        } else {
            v7 = v5;
        }
        uint32_t v8;
        v8 = v7 - v3;
        __mram_ptr int32_t * v9;
        v9 = (__mram_ptr int32_t *) (buffer + 256ul);
        mram_read(v9 + v3,v1,v8 * sizeof(int32_t));
        __mram_ptr int32_t * v10;
        v10 = (__mram_ptr int32_t *) (buffer + 0ul);
        mram_read(v10 + v3,v2,v8 * sizeof(int32_t));
        uint32_t v11 = 0ul;
        while (method1(v8, v11)){
            int32_t v13;
            v13 = v1[v11];
            int32_t v14;
            v14 = v2[v11];
            int32_t v15;
            v15 = v13 + v14;
            v0[v11] = v15;
            v11 += 1ul;
        }
        __mram_ptr int32_t * v16;
        v16 = (__mram_ptr int32_t *) (buffer + 512ul);
        mram_write(v0,v16 + v3,v8 * sizeof(int32_t));
        v3 += 8ul;
    }
    return 0l;
}
