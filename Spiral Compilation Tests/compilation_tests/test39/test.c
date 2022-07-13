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
    };
} US0;
static inline void USRefcBody0(US0 x, REFC_FLAG q){
    switch (x.tag) {
    }
}
void USRefc0(US0 * x, REFC_FLAG q){
    USRefcBody0(*x, q);
}
US0 US0_0() { // A
    US0 x;
    x.tag = 0;
    USRefcBody0(x, REFC_INCR);
    return x;
}
US0 US0_1() { // B
    US0 x;
    x.tag = 1;
    USRefcBody0(x, REFC_INCR);
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
            USRefc0(&(v0), REFC_DECR); USRefc0(&(v1), REFC_DECR); USRefc0(&(v2), REFC_DECR);
            return 1l;
            break;
        }
        case 1: { // B
            USRefc0(&(v0), REFC_DECR);
            switch (v1.tag) {
                case 0: { // A
                    USRefc0(&(v1), REFC_DECR); USRefc0(&(v2), REFC_DECR);
                    return 2l;
                    break;
                }
                case 1: { // B
                    USRefc0(&(v1), REFC_DECR);
                    switch (v2.tag) {
                        case 0: { // A
                            USRefc0(&(v2), REFC_DECR);
                            return 3l;
                            break;
                        }
                        case 1: { // B
                            USRefc0(&(v2), REFC_DECR);
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
