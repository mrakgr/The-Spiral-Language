#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef void (* Fun0)();
void method0(){
    char * v0;
    v0 = "qwe";
    return ;
}
void ClosureMethod0(){
    return method0();
}
void main(){
    Fun0 v0;
    v0 = ClosureMethod0;
    int32_t v1[128ll];
    return ;
}
