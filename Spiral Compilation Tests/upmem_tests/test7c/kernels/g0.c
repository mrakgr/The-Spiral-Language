
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
__mram_noinit uint8_t buffer[1024*1024*1];
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
    __dma_aligned int32_t v5[8u];
    __dma_aligned int32_t v6[8u];
    __dma_aligned int32_t v7[8u];
    uint32_t v8 = 0u;
    while (method0(v3, v8)){
        uint32_t v10;
        v10 = v8 + 8u;
        bool v11;
        v11 = v3 < v10;
        uint32_t v12;
        if (v11){
            v12 = v3;
        } else {
            v12 = v10;
        }
        uint32_t v13;
        v13 = v12 - v8;
        __mram_ptr int32_t * v14;
        v14 = (__mram_ptr int32_t *) (buffer + v2);
        mram_read(v14 + v8,v6,v13 * sizeof(int32_t));
        __mram_ptr int32_t * v15;
        v15 = (__mram_ptr int32_t *) (buffer + 0u);
        mram_read(v15 + v8,v7,v13 * sizeof(int32_t));
        uint32_t v16 = 0u;
        while (method0(v13, v16)){
            int32_t v18;
            v18 = v6[v16];
            int32_t v19;
            v19 = v7[v16];
            int32_t v20;
            v20 = v18 + v19;
            v5[v16] = v20;
            v16 += 1u;
        }
        __mram_ptr int32_t * v21;
        v21 = (__mram_ptr int32_t *) (buffer + v4);
        mram_write(v5,v21 + v8,v13 * sizeof(int32_t));
        v8 += 8u;
    }
    return 0;
}
