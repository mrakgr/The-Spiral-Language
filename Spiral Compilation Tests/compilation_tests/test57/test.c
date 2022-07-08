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
    bool v0;
    String * v1;
    int32_t v2;
    bool v3;
    bool v4;
} Tuple0;
typedef struct {
    uint32_t len;
    bool ptr[];
} Array1;
typedef struct {
    uint32_t len;
    String * ptr[];
} Array2;
typedef struct {
    uint32_t len;
    int32_t ptr[];
} Array3;
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
static inline Tuple0 TupleCreate0(bool v0, String * v1, int32_t v2, bool v3, bool v4){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3; x.v4 = v4;
    return x;
}
Array1 * ArrayCreate1(uint32_t size){
    Array1 * x = malloc(sizeof(Array1) + sizeof(bool) * size);
    x->len = size;
    return x;
}
Array1 * ArrayLit1(uint32_t size, bool * ptr){
    Array1 * x = ArrayCreate1(size);
    memcpy(x->ptr, ptr, sizeof(bool) * size);
    return x;
}
Array2 * ArrayCreate2(uint32_t size){
    Array2 * x = malloc(sizeof(Array2) + sizeof(String *) * size);
    x->len = size;
    return x;
}
Array2 * ArrayLit2(uint32_t size, String * * ptr){
    Array2 * x = ArrayCreate2(size);
    memcpy(x->ptr, ptr, sizeof(String *) * size);
    return x;
}
Array3 * ArrayCreate3(uint32_t size){
    Array3 * x = malloc(sizeof(Array3) + sizeof(int32_t) * size);
    x->len = size;
    return x;
}
Array3 * ArrayLit3(uint32_t size, int32_t * ptr){
    Array3 * x = ArrayCreate3(size);
    memcpy(x->ptr, ptr, sizeof(int32_t) * size);
    return x;
}
Tuple0 main(){
    Array1 * v0;
    v0 = ArrayCreate1(10l);
    Array2 * v1;
    v1 = ArrayCreate2(10l);
    Array3 * v2;
    v2 = ArrayCreate3(10l);
    Array1 * v3;
    v3 = ArrayCreate1(10l);
    Array1 * v4;
    v4 = ArrayCreate1(10l);
    v0->ptr[0l] = true;
    v1->ptr[0l] = StringLit(3, "qwe");
    v2->ptr[0l] = 2l;
    v3->ptr[0l] = false;
    v4->ptr[0l] = true;
    v0->ptr[1l] = false;
    v1->ptr[1l] = StringLit(3, "zxc");
    v2->ptr[1l] = -2l;
    v4->ptr[1l] = false;
    bool v5;
    v5 = v0->ptr[0l];
    String * v6;
    v6 = v1->ptr[0l];
    int32_t v7;
    v7 = v2->ptr[0l];
    bool v8;
    v8 = v3->ptr[0l];
    bool v9;
    v9 = v4->ptr[0l];
    return TupleCreate0(v5, v6, v7, v8, v9);
}
