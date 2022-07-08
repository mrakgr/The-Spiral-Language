#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
bool main(){
    int32_t v0;
    v0 = 2l;
    int32_t v1;
    v1 = 3l;
    bool v2;
    v2 = v0 == 2l;
    if (v2){
        return v1 == 3l;
    } else {
        return false;
    }
}
