
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__host int32_t v0;
__host int32_t v1;
__host int32_t v2;
int32_t main(){
    int32_t v3;
    v3 = v0 - v1;
    int32_t v4;
    v4 = v3 - v2;
    v0 = v4;
    return 0l;
}
