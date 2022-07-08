#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int32_t v0;
    int32_t v1;
} Tuple0;
typedef struct {
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct {
    int32_t v0;
    int32_t v1;
    String * v2;
} Tuple1;
static inline Tuple0 TupleCreate0(int32_t v0, int32_t v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
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
static inline Tuple1 TupleCreate1(int32_t v0, int32_t v1, String * v2){
    Tuple1 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 main(){
    int32_t v0;
    v0 = 123l;
    int32_t v1;
    v1 = 456l;
    return TupleCreate1(v0, v1, StringLit(3, "qwe"));
}
