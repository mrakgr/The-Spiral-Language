#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int64_t method0(int64_t v0, int64_t v1){
    bool v2;
    v2 = true;
    if (v2){
        return method0(v1, v0);
    } else {
        return v0 + v1;
    }
}
int64_t main(){
    int64_t v0;
    v0 = 1ll;
    int64_t v1;
    v1 = 2ll;
    return method0(v0, v1);
}
