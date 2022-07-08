#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    String * v0;
    int32_t v1;
    String * v2;
    int32_t v3;
    String * v4;
    bool v5;
    String * v6;
    bool v7;
    String * v8;
    String * v9;
    String * v10;
    int8_t v11;
    String * v12;
    double v13;
    String * v14;
    double v15;
} Tuple0;
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(char) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    return x;
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
static inline Tuple0 TupleCreate0(String * v0, int32_t v1, String * v2, int32_t v3, String * v4, bool v5, String * v6, bool v7, String * v8, String * v9, String * v10, int8_t v11, String * v12, double v13, String * v14, double v15){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4; x.v5 = v5; x.v6 = v6; x.v7 = v7; x.v8 = v8; x.v9 = v9; x.v10 = v10; x.v11 = v11; x.v12 = v12; x.v13 = v13; x.v14 = v14; x.v15 = v15;
    return x;
}
Tuple0 main(){
    String * v0;
    v0 = StringLit(1, "0");
    int32_t v1;
    v1 = 0l;
    String * v2;
    v2 = StringLit(1, "1");
    int32_t v3;
    v3 = 1l;
    String * v4;
    v4 = StringLit(5, "false");
    bool v5;
    v5 = false;
    String * v6;
    v6 = StringLit(4, "true");
    bool v7;
    v7 = true;
    String * v8;
    v8 = StringLit(3, "asd");
    String * v9;
    v9 = StringLit(3, "asd");
    String * v10;
    v10 = StringLit(3, "1i8");
    int8_t v11;
    v11 = 1;
    String * v12;
    v12 = StringLit(3, "5.5");
    double v13;
    v13 = 5.5;
    String * v14;
    v14 = StringLit(7, "unknown");
    double v15;
    v15 = 5.0;
    return TupleCreate0(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15);
}
