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
            int64_t v0;
        } case1; // Some
    };
} US0;
US0 US0_0() { // None
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1(int64_t v0) { // Some
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
int64_t main(){
    int64_t v0;
    v0 = 3ll;
    US0 v1;
    v1 = US0_1(v0);
    switch (v1.tag) {
        case 0: {
            return 0ll;
            break;
        }
        case 1: {
            int64_t v2 = v1.case1.v0;
            return v2;
            break;
        }
    }
}
