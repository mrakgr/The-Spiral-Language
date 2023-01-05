#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case1; // Some
    };
} US0;
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
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
int32_t main(){
    int32_t v0;
    v0 = 3l;
    US0 v1;
    v1 = US0_1(v0);
    switch (v1.tag) {
        case 0: { // None
            USDecref0(&(v1));
            return 0l;
            break;
        }
        case 1: { // Some
            int32_t v2 = v1.case1.v0;
            USDecref0(&(v1));
            return v2;
            break;
        }
    }
}
