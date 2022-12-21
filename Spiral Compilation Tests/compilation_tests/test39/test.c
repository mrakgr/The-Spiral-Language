#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int refc;
    double v0;
} Heap0;
typedef struct {
    int refc;
    int32_t v0;
} Heap1;
typedef struct {
    int refc;
    uint64_t v0;
} Heap2;
typedef struct {
    int refc;
    Heap2 * v0;
} Mut0;
typedef struct {
    int tag;
    union {
        struct {
            Heap1 * v0;
            Mut0 * v1;
        } case0; // A
        struct {
            Heap0 * v0;
        } case1; // B
    };
} US0;
typedef struct {
    US0 v0;
    US0 v1;
    US0 v2;
} Tuple0;
static inline void HeapDecrefBody0(Heap0 * x){
}
void HeapDecref0(Heap0 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody0(x); free(x); }
}
Heap0 * HeapCreate0(double v0){
    Heap0 * x = malloc(sizeof(Heap0));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void HeapDecrefBody1(Heap1 * x){
}
void HeapDecref1(Heap1 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody1(x); free(x); }
}
Heap1 * HeapCreate1(int32_t v0){
    Heap1 * x = malloc(sizeof(Heap1));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void HeapDecrefBody2(Heap2 * x){
}
void HeapDecref2(Heap2 * x){
    if (x != NULL && --(x->refc) == 0) { HeapDecrefBody2(x); free(x); }
}
Heap2 * HeapCreate2(uint64_t v0){
    Heap2 * x = malloc(sizeof(Heap2));
    x->refc = 1;
    x->v0 = v0;
    return x;
}
static inline void MutDecrefBody0(Mut0 * x){
    HeapDecref2(x->v0);
}
void MutDecref0(Mut0 * x){
    if (x != NULL && --(x->refc) == 0) { MutDecrefBody0(x); free(x); }
}
Mut0 * MutCreate0(Heap2 * v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->refc = 1;
    x->v0 = v0;
    v0->refc++;
    return x;
}
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc++; x->case0.v1->refc++;
            break;
        }
        case 1: {
            x->case1.v0->refc++;
            break;
        }
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            HeapDecref1(x->case0.v0); MutDecref0(x->case0.v1);
            break;
        }
        case 1: {
            HeapDecref0(x->case1.v0);
            break;
        }
    }
}
static inline void USSupprefBody0(US0 * x){
    switch (x->tag) {
        case 0: {
            x->case0.v0->refc--; x->case0.v1->refc--;
            break;
        }
        case 1: {
            x->case1.v0->refc--;
            break;
        }
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
void USSuppref0(US0 * x){ USSupprefBody0(x); }
US0 US0_0(Heap1 * v0, Mut0 * v1) { // A
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0; x.case0.v1 = v1;
    v0->refc++; v1->refc++;
    return x;
}
US0 US0_1(Heap0 * v0) { // B
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    v0->refc++;
    return x;
}
static inline Tuple0 TupleCreate0(US0 v0, US0 v1, US0 v2){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2;
    return x;
}
Tuple0 method0(US0 v0, US0 v1, US0 v2){
    USIncref0(&(v0)); USIncref0(&(v1)); USIncref0(&(v2));
    return TupleCreate0(v2, v1, v0);
}
int32_t main(){
    Heap0 * v0;
    v0 = HeapCreate0(5.0);
    Heap0 * v1;
    v1 = HeapCreate0(2.0);
    Heap0 * v2;
    v2 = HeapCreate0(1.0);
    US0 v3;
    v3 = US0_1(v0);
    HeapDecref0(v0);
    US0 v4;
    v4 = US0_1(v1);
    HeapDecref0(v1);
    US0 v5;
    v5 = US0_1(v2);
    HeapDecref0(v2);
    US0 v6; US0 v7; US0 v8;
    Tuple0 tmp0 = method0(v5, v4, v3);
    v6 = tmp0.v0; v7 = tmp0.v1; v8 = tmp0.v2;
    USDecref0(&(v3)); USDecref0(&(v4)); USDecref0(&(v5));
    switch (v6.tag) {
        case 0: { // A
            USDecref0(&(v6)); USDecref0(&(v7)); USDecref0(&(v8));
            return 1l;
            break;
        }
        case 1: { // B
            USDecref0(&(v6));
            switch (v7.tag) {
                case 0: { // A
                    USDecref0(&(v7)); USDecref0(&(v8));
                    return 2l;
                    break;
                }
                case 1: { // B
                    USDecref0(&(v7));
                    switch (v8.tag) {
                        case 0: { // A
                            USDecref0(&(v8));
                            return 3l;
                            break;
                        }
                        case 1: { // B
                            USDecref0(&(v8));
                            return 4l;
                            break;
                        }
                    }
                    break;
                }
            }
            break;
        }
    }
}
