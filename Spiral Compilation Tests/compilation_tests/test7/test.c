#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int32_t v0;
    int32_t v1;
    int32_t v2;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, int32_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
int32_t method0(){
    return 3l;
}
int32_t method1(){
    return -1l;
}
int32_t method2(){
    return 2l;
}
Tuple0 main(){
    int32_t v0;
    v0 = method0();
    int32_t v1;
    v1 = method1();
    int32_t v2;
    v2 = method2();
    return TupleCreate0(v0, v1, v2);
}
