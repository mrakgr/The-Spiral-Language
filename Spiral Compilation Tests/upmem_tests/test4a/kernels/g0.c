
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
int32_t main(){
    printf("Size of a pointer is %i.\n", sizeof(int *));
    printf("Size of a mram pointer is %i.\n", sizeof(__mram int *));
    return 0l;
}
