
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
    __dma_aligned int32_t v3[8ul];
    uint32_t v4 = 0ul;
    while (method0(v4)){
        uint32_t v6;
        v6 = v4 + 8ul;
        bool v7;
        v7 = 64ul < v6;
        uint32_t v8;
        if (v7){
            v8 = 64ul;
        } else {
            v8 = v6;
        }
        uint32_t v9;
        v9 = v8 - v4;
        __mram_ptr int32_t * v10;
        v10 = (__mram_ptr int32_t *) (buffer + 0ul);
        mram_read(v10 + v4,v0,v9 * sizeof(int32_t));
        __mram_ptr int32_t * v11;
        v11 = (__mram_ptr int32_t *) (buffer + 256ul);
        mram_read(v11 + v4,v1,v9 * sizeof(int32_t));
        __mram_ptr int32_t * v12;
        v12 = (__mram_ptr int32_t *) (buffer + 512ul);
        mram_read(v12 + v4,v2,v9 * sizeof(int32_t));
        uint32_t v13 = 0ul;
        while (method1(v9, v13)){
            int32_t v15;
            v15 = v0[v13];
            int32_t v16;
            v16 = v1[v13];
            int32_t v17;
            v17 = v2[v13];
            int32_t v18;
            v18 = v15 + v16;
            int32_t v19;
            v19 = v18 + v17;
            int32_t v20;
            v20 = v19 + 10l;
            v3[v13] = v20;
            v13 += 1ul;
        }
        __mram_ptr int32_t * v21;
        v21 = (__mram_ptr int32_t *) (buffer + 768ul);
        mram_write(v3,v21 + v4,v9 * sizeof(int32_t));
        v4 += 8ul;
    }
    return 0l;
}
