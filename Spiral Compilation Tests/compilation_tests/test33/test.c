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
    int32_t v5;
    int32_t v6;
    int32_t v7;
    int32_t v8;
    int32_t v9;
    int32_t v10;
    int32_t v11;
} Tuple0;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6, int32_t v7, int32_t v8, int32_t v9, int32_t v10, int32_t v11){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5; x.v6 = v6; x.v7 = v7; x.v8 = v8; x.v9 = v9; x.v10 = v10; x.v11 = v11;
    return x;
}
Tuple0 method0(){
    return TupleCreate0(3l, 1l, 2l, 3l, 1l, 2l, 3l, 1l, 2l, 3l, 1l, 2l);
}
Tuple0 method1(int32_t v0, int32_t v1, int32_t v2, int32_t v3, int32_t v4, int32_t v5, int32_t v6, int32_t v7, int32_t v8, int32_t v9, int32_t v10, int32_t v11){
    return TupleCreate0(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11);
}
Tuple0 main(){
    int32_t v0; int32_t v1; int32_t v2; int32_t v3; int32_t v4; int32_t v5; int32_t v6; int32_t v7; int32_t v8; int32_t v9; int32_t v10; int32_t v11;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2; v3 = tmp0.v3; v4 = tmp0.v4; v5 = tmp0.v5; v6 = tmp0.v6; v7 = tmp0.v7; v8 = tmp0.v8; v9 = tmp0.v9; v10 = tmp0.v10; v11 = tmp0.v11;
    return method1(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11);
}
