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
    int tag;
    union {
        struct {
            String * v0;
            String * v1;
            String * v2;
        } case0; // A
    };
} US0;
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
US0 US0_0(String * v0, String * v1, String * v2) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1; x.case0.v2 = v2;
    return x;
}
String * main(){
    String * v0;
    v0 = StringLit(3, "qwe");
    String * v1;
    v1 = StringLit(3, "asd");
    String * v2;
    v2 = StringLit(3, "zxc");
    US0 v3;
    v3 = US0_0(v0, v1, v2);
    switch (v3.tag) {
        case 0: { // A
            String * v4 = v3.case0.v0; String * v5 = v3.case0.v1; String * v6 = v3.case0.v2;
            return v4;
            break;
        }
    }
}
