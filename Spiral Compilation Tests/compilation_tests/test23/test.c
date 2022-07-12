#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
int32_t main(){
    // let v0 = false;
    bool v0;
    v0 = false;
    // let v1 = true;
    bool v1;
    v1 = true;
    // let v2 = false;
    bool v2;
    v2 = false;
    // v0  = false;
    bool v3;
    v3 = v0 == false;
    return 0l;
}
