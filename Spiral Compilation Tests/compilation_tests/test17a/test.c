#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t method0(int32_t v0, int32_t v1){
    bool v2;
    v2 = true;
    if (v2){
        return method0(v1, v0);
    } else {
        int32_t v4;
        v4 = v0 + v1;
        return v4;
    }
}
int32_t main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    return method0(v0, v1);
}
