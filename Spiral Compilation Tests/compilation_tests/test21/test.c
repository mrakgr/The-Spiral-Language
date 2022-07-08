#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    float v0;
    float v1;
} Tuple0;
static inline Tuple0 TupleCreate0(float v0, float v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 main(){
    float v0;
    v0 = 6.0f;
    float v1;
    v1 = 4.0f;
    return TupleCreate0(v0, v1);
}
