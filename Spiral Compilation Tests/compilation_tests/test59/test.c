#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t method2(int32_t v0, int32_t v1){
    bool v2;
    v2 = 0l < v1;
    if (v2){
        int32_t v3;
        v3 = v1 / 10l;
        int32_t v4;
        v4 = v0 * 10l;
        int32_t v5;
        v5 = v1 % 10l;
        int32_t v6;
        v6 = v4 + v5;
        return method2(v6, v3);
    } else {
        return v0;
    }
}
int32_t method3(int32_t v0, int32_t v1, int32_t v2){
    bool v3;
    v3 = v1 < 1000l;
    if (v3){
        int32_t v4;
        v4 = v1 + 1l;
        int32_t v5;
        v5 = v0 * v1;
        int32_t v6;
        v6 = 0l;
        int32_t v7;
        v7 = method2(v6, v5);
        bool v8;
        v8 = v5 == v7;
        bool v10;
        if (v8){
            bool v9;
            v9 = v2 < v5;
            v10 = v9;
        } else {
            v10 = false;
        }
        int32_t v11;
        if (v10){
            v11 = v5;
        } else {
            v11 = v2;
        }
        return method3(v0, v4, v11);
    } else {
        return v2;
    }
}
int32_t method1(int32_t v0, int32_t v1){
    bool v2;
    v2 = v0 < 1000l;
    if (v2){
        int32_t v3;
        v3 = v0 + 1l;
        int32_t v4;
        v4 = v0 * v0;
        int32_t v5;
        v5 = 0l;
        int32_t v6;
        v6 = method2(v5, v4);
        bool v7;
        v7 = v4 == v6;
        bool v9;
        if (v7){
            bool v8;
            v8 = v1 < v4;
            v9 = v8;
        } else {
            v9 = false;
        }
        int32_t v10;
        if (v9){
            v10 = v4;
        } else {
            v10 = v1;
        }
        return method3(v0, v3, v10);
    } else {
        return v1;
    }
}
int32_t method0(int32_t v0, int32_t v1){
    bool v2;
    v2 = v0 < 1000l;
    if (v2){
        int32_t v3;
        v3 = v0 + 1l;
        int32_t v4;
        v4 = method1(v0, v1);
        return method0(v3, v4);
    } else {
        return v1;
    }
}
int32_t main(){
    int32_t v0;
    v0 = 100l;
    int32_t v1;
    v1 = 0l;
    return method0(v0, v1);
}
