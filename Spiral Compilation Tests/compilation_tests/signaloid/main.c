#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    double v0;
    double v1;
} Tuple0;
static inline Tuple0 TupleCreate0(double v0, double v1){
    Tuple0 x;
    x.v0 = v0; x.v1 = v1;
    return x;
}
Tuple0 method0(){
    FILE * v0;
    v0 = fopen("sd0/Signaloid/example-loadDistFromFile/example.csd", "r");
    bool v1;
    v1 = v0 == NULL;
    if (v1){
        fprintf(stderr, "Could not open sd0/Signaloid/example-loadDistFromFile/example.csd.\n");
        exit(EXIT_FAILURE);
    } else {
    }
    double v2;
    v2 = 0.0;
    double v3;
    v3 = 0.0;
    fscanf(v0, "%lf, %lf\n", &v2, &v3);
    return TupleCreate0(v2, v3);
}
int32_t main(){
    double v0; double v1;
    Tuple0 tmp0 = method0();
    v0 = tmp0.v0; v1 = tmp0.v1;
    printf("a = %lf\n", v0);
    printf("b = %lf\n", v1);
    double v2;
    v2 = v0 + v1;
    double v3;
    v3 = v0 - v1;
    double v4;
    v4 = v2 / v3;
    printf("c = %lf\n", v4);
    return 0l;
}
