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
    int32_t v3;
    int32_t v4;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4;
    return x;
}
void main(){
    return TupleCreate0(1l, 2l, 3l, 4l, 5l);
}
