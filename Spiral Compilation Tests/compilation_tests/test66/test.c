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
String * main(){
    uint8_t v0;
    v0 = 0u;
    bool v1;
    v1 = 0u == v0;
    if (v1){
        return StringLit(3, "qwe");
    } else {
        bool v2;
        v2 = 1u == v0;
        if (v2){
            return StringLit(3, "asd");
        } else {
            bool v3;
            v3 = 2u == v0;
            if (v3){
                return StringLit(3, "asd");
            } else {
                return StringLit(3, "zxc");
            }
        }
    }
}
