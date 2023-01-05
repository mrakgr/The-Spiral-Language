#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method0(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    int32_t v4;
    v4 = v3 + v2;
    int32_t v5;
    v5 = v4 * v1;
    int32_t v6;
    v6 = v5 / v0;
    return v6;
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    int32_t v2;
    v2 = 3l;
    int32_t v3;
    v3 = 4l;
    return method0(v3, v2, v1, v0);
}
