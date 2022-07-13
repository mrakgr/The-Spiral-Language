#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef enum {REFC_DECR, REFC_INCR, REFC_SUPPR} REFC_FLAG;
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Some
    };
} US0;
typedef struct Fun0 Fun0;
struct Fun0{
    int refc;
    void (*refc_fptr)(Fun0 *, REFC_FLAG);
    int32_t (*fptr)(Fun0 *, US0);
};
typedef struct {
    int32_t v0;
} ClosureEnv0;
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*refc_fptr)(Closure0 *, REFC_FLAG);
    int32_t (*fptr)(Closure0 *, US0);
    ClosureEnv0 env[];
};
static inline void USRefcBody0(US0 x, REFC_FLAG q){
    switch (x.tag) {
    }
}
void USRefc0(US0 * x, REFC_FLAG q){
    USRefcBody0(*x, q);
}
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
US0 US0_1(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
static inline void ClosureRefcBody0(Closure0 * x, REFC_FLAG q){
}
void ClosureRefc0(Closure0 * x, REFC_FLAG q){
    if (x != NULL) {
        int refc = (x->refc += q & REFC_INCR ? 1 : -1);
        if (!(q & REFC_SUPPR) && refc == 0) {
            ClosureRefcBody0(x, REFC_DECR);
            free(x);
        }
    }
}
int32_t ClosureMethod0(Closure0 * x, US0 v1){
    ClosureEnv0 * env = x->env;
    int32_t v0 = env->v0;
    USRefc0(&(v1), REFC_INCR);
    switch (v1.tag) {
        case 0: { // None
            USRefc0(&(v1), REFC_DECR);
            return v0;
            break;
        }
        case 1: { // Some
            int32_t v2 = v1.case1.v0;
            USRefc0(&(v1), REFC_DECR);
            return v2;
            break;
        }
    }
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    x->refc = 1;
    x->refc_fptr = ClosureRefc0;
    x->fptr = ClosureMethod0;
    ClosureEnv0 * env = x->env;
    env->v0 = v0;
    ClosureRefcBody0(x, REFC_INCR);
    return (Fun0 *) x;
}
int32_t main(){
    int32_t v0;
    v0 = 0l;
    Fun0 * v1;
    v1 = ClosureCreate0(v0);
    v1->refc_fptr(v1, REFC_DECR);
    return 0l;
}
