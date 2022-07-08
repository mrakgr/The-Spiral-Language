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
    int64_t v0;
    double v1;
    String * v2;
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
static inline Tuple0 TupleCreate0(int64_t v0, double v1, String * v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 main(){
    int64_t v0;
    v0 = 2ll;
    double v1;
    v1 = 3.4;
    String * v2;
    v2 = StringLit(3, "123");
    return TupleCreate0(v0, v1, v2);
}
