#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t method0(){
    return 3l;
}
int32_t method1(){
    return -1l;
}
int32_t method2(){
    return 2l;
}
int32_t main(){
    int32_t v0;
    v0 = method0();
    int32_t v1;
    v1 = method1();
    int32_t v2;
    v2 = method2();
    int32_t v3;
    v3 = v0 + v1;
    return v3 + v2;
}
