#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
bool main(){
    bool v0;
    v0 = true;
    bool v1;
    v1 = false;
    bool v2;
    v2 = true;
    bool v3;
    v3 = false;
    bool v4;
    v4 = true;
    bool v5;
    v5 = v0 && v1;
    if (v5){
        return true;
    } else {
        bool v6;
        v6 = v2 && v3;
        return v6 || v4;
    }
}
