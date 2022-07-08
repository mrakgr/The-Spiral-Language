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
void main(){
    int32_t v0;
    v0 = 1l;
    String * v1;
    v1 = StringLit(3, "qwe");
    int32_t v2;
    v2 = 2l;
    String * v3;
    v3 = StringLit(3, "asd");
    bool v4;
    v4 = v0 == v2;
    int32_t v5;
    v5 = 1l;
    double v6;
    v6 = 2.0;
    bool v7;
    v7 = v5 == 3l;
    bool v9;
    if (v7){
        v9 = v6 == 4.0;
    } else {
        v9 = false;
    }
    return ;
}
