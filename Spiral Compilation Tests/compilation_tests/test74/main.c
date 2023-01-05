#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
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
US0 US0_2() { // C
    US0 x;
    x.tag = 2;
    return x;
}
US0 US0_3() { // D
    US0 x;
    x.tag = 3;
    return x;
}
US0 US0_4() { // E
    US0 x;
    x.tag = 4;
    return x;
}
int32_t main(){
    US0 v0;
    v0 = US0_1();
    US0 v1;
    v1 = US0_2();
    switch (v0.tag) {
        case 0: { // A
            USDecref0(&(v0));
            switch (v1.tag) {
                case 0: { // A
                    USDecref0(&(v1));
                    return 0l;
                    break;
                }
                case 1: { // B
                    USDecref0(&(v1));
                    return 1l;
                    break;
                }
                case 2: { // C
                    USDecref0(&(v1));
                    return 3l;
                    break;
                }
                default: {
                    USDecref0(&(v1));
                    return -1l;
                }
            }
            break;
        }
        case 1: { // B
            USDecref0(&(v0));
            switch (v1.tag) {
                case 0: { // A
                    USDecref0(&(v1));
                    return 2l;
                    break;
                }
                case 2: { // C
                    USDecref0(&(v1));
                    return 4l;
                    break;
                }
                default: {
                    USDecref0(&(v1));
                    return -1l;
                }
            }
            break;
        }
        default: {
            USDecref0(&(v0)); USDecref0(&(v1));
            return -1l;
        }
    }
}
