#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int64_t v2;
    float v1;
    char v0;
} Tuple0;
static inline Tuple0 TupleCreate0(char v0, float v1, int64_t v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method0(){
    return TupleCreate0('a', 2.0f, 3ll);
}
int32_t main(){
    char v0; float v1; int64_t v2;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2;
    return 0l;
}
