#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Some
    };
} US0;
typedef struct {
    int32_t (*fptr)(char *, US0);
    char env[];
} Fun0;
typedef struct {
    int32_t v0;
} ClosureEnv0;
typedef struct {
    int32_t (*fptr)(ClosureEnv0 *, US0);
    ClosureEnv0 env[];
} Closure0;
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(int32_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int32_t ClosureMethod0(ClosureEnv0 * env, US0 v1){
    int32_t v0 = env->v0;
    switch (v1.tag) {
        case 0: {
            return v0;
            break;
        }
        case 1: {
            int32_t v2 = v1.case1.v0;
            return v2;
            break;
        }
    }
}
Fun0 * ClosureCreate0(int32_t v0){
    Closure0 * x = malloc(sizeof(Closure0) + sizeof(ClosureEnv0));
    ClosureEnv0 * env = x->env;
    env->v0 = v0;
    x->fptr = ClosureMethod0;
    return (Fun0 *) x;
}
Fun0 * main(){
    int32_t v0;
    v0 = 0l;
    return ClosureCreate0(v0);
}
