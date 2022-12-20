#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    int32_t v0;
    v0 = 2l;
    int32_t v1;
    v1 = 3l;
    bool v2;
    v2 = v0 == 2l;
    bool v4;
    if (v2){
        bool v3;
        v3 = v1 == 3l;
        v4 = v3;
    } else {
        v4 = false;
    }
    return 0l;
}
