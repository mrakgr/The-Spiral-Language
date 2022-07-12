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
int32_t main(){
    int32_t v0;
    v0 = 3l;
    US0 v1;
    v1 = US0_1(v0);
    USRefc0(&(v1), REFC_INCR);
    switch (v1.tag) {
        case 0: { // None
            USRefc0(&(v1), REFC_DECR);
            return 0l;
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
