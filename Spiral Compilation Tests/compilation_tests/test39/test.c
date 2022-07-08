#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    int tag;
    union {
    };
} US0;
US0 US0_0() { // A
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_1() { // B
    US0 x;
    x.tag = 1;
    return x;
}
int32_t main(){
    US0 v0;
    v0 = US0_1();
    US0 v1;
    v1 = US0_1();
    US0 v2;
    v2 = US0_1();
    switch (v0.tag) {
        case 0: { // A
            return 1l;
            break;
        }
        case 1: { // B
            switch (v1.tag) {
                case 0: { // A
                    return 2l;
                    break;
                }
                case 1: { // B
                    switch (v2.tag) {
                        case 0: { // A
                            return 3l;
                            break;
                        }
                        case 1: { // B
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
