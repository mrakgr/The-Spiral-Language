#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    int32_t v2;
    v2 = 3l;
    int32_t v3;
    v3 = 4l;
    int32_t v4;
    v4 = v0 + v2;
    int32_t v5;
    v5 = v1 + v3;
    int32_t v6;
    v6 = v4 + v5;
    return v6;
}
