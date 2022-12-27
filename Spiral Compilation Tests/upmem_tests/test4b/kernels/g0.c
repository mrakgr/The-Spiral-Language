
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
int32_t main(){
    __dma_aligned uint8_t v0[512];
    printf("%u\n",DPU_MRAM_HEAP_POINTER+1);
    mram_read(DPU_MRAM_HEAP_POINTER, v0, sizeof(v0));
    return 0l;
}
