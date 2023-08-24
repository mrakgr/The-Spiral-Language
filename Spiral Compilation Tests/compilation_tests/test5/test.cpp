#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
void f0(){
    return ;
}
void g1(){
    return ;
}
void h2(){
    return ;
}
void i3(){
    return ;
}
int32_t method4(){
    return 1l;
}
int32_t method5(){
    return 2l;
}
void main(){
    f0();
    g1();
    h2();
    i3();
    int32_t v0;
    v0 = method4();
    int32_t v1;
    v1 = method5();
    int32_t v2;
    v2 = v0 + v1;
    return ;
}
