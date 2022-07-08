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
typedef struct {
    US0 v0;
    US0 v1;
    US0 v2;
    US0 v3;
} Tuple0;
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
static inline Tuple0 TupleCreate0(US0 v0, US0 v1, US0 v2, US0 v3){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1; x.v2 = v2; x.v3 = v3;
    return x;
}
Tuple0 method0(){
    US0 v0;
    v0 = US0_0();
    US0 v1;
    v1 = US0_0();
    US0 v2;
    v2 = US0_0();
    US0 v3;
    v3 = US0_0();
    return TupleCreate0(v0, v1, v2, v3);
}
int32_t method1(){
    return 1l;
}
int32_t method2(){
    return 2l;
}
int32_t method3(){
    return 3l;
}
int32_t method4(){
    return 4l;
}
int32_t main(){
    US0 v0; US0 v1; US0 v2; US0 v3;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2; v3 = tmp0.v3;
    switch (v0.tag) {
        case 0: { // A
            switch (v1.tag) {
                case 0: { // A
                    return method1();
                    break;
                }
                case 1: { // B
                    switch (v2.tag) {
                        case 0: { // A
                            switch (v3.tag) {
                                case 0: { // A
                                    return method2();
                                    break;
                                }
                                case 1: { // B
                                    return method3();
                                    break;
                                }
                            }
                            break;
                        }
                        case 1: { // B
                            return method4();
                            break;
                        }
                    }
                    break;
                }
            }
            break;
        }
        case 1: { // B
            switch (v2.tag) {
                case 0: { // A
                    switch (v3.tag) {
                        case 0: { // A
                            return method2();
                            break;
                        }
                        case 1: { // B
                            return method4();
                            break;
                        }
                    }
                    break;
                }
                case 1: { // B
                    return method4();
                    break;
                }
            }
            break;
        }
    }
}
