
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
__mram_noinit uint8_t t[1024*1024*64];
__mram_noinit uint8_t t1[1024*1024*64];
int32_t main(){
    __dma_aligned uint8_t v0[512];
    mram_read(t, v0, sizeof(v0));
    return 0l;
}
