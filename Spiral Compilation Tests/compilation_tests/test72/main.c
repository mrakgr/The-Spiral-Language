#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    bool v0;
} Heap0;
static inline void HeapDecrefBody0(Heap0 * x){
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(bool v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
Heap0 * method2(Heap0 * v0){
    return v0;
}
Heap0 * method1(Heap0 * v0){
    return method2(v0);
}
Heap0 * method0(Heap0 * v0){
    return method1(v0);
}
int32_t main(){
    bool v0;
    v0 = true;
    Heap0 * v1;
    v1 = HeapCreate0(true);
    Heap0 * v3;
    if (v0){
        v1->refc++;
        v3 = method0(v1);
    } else {
        v1->refc++;
        v3 = v1;
    }
    HeapDecref0(v1); HeapDecref0(v3);
    return 0l;
}
