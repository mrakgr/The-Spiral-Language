#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
typedef struct {
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
typedef struct UH0 UH0;
struct UH0 {
    int tag;
    union {
        struct {
            char v0;
            int32_t v1;
            String * v2;
            UH0 * v3;
        } case0; // Cons
    };
};
typedef struct {
    uint32_t len;
    uint8_t ptr[];
} Array1;
typedef struct {
    int32_t v0;
} Mut0;
typedef struct {
    int32_t v0;
} Mut1;
Array0 * ArrayCreate0(uint32_t size){
    Array0 * x = malloc(sizeof(Array0) + sizeof(char) * size);
    x->len = size;
    return x;
}
Array0 * ArrayLit0(uint32_t size, char * ptr){
    Array0 * x = ArrayCreate0(size);
    memcpy(x->ptr, ptr, sizeof(char) * size);
    return x;
}
static inline String * StringLit(uint32_t size, char * ptr){
    return ArrayLit0(size, ptr);
}
UH0 * UH0_0(char v0, int32_t v1, String * v2, UH0 * v3) { // Cons
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 0;
    x->case0.v0 = v0; x->case0.v1 = v1; x->case0.v2 = v2; x->case0.v3 = v3;
    return x;
}
UH0 * UH0_1() { // Nil
    UH0 * x = malloc(sizeof(UH0));
    x->tag = 1;
    return x;
}
int32_t method0(UH0 * v0){
    int32_t v11;
    switch (v0->tag) {
        case 0: { // Cons
            char v1 = v0->case0.v0; int32_t v2 = v0->case0.v1; String * v3 = v0->case0.v2; UH0 * v4 = v0->case0.v3;
            int32_t v5;
            v5 = v3->len;;
            int32_t v6;
            v6 = 2l * v5;
            int32_t v7;
            v7 = 4l + v6;
            int32_t v8;
            v8 = 6l + v7;
            int32_t v9;
            v9 = method0(v4);
            v11 = v8 + v9;
            break;
        }
        case 1: { // Nil
            v11 = 0l;
            break;
        }
    }
    return 4l + v11;
}
Array1 * ArrayCreate1(uint32_t size){
    Array1 * x = malloc(sizeof(Array1) + sizeof(uint8_t) * size);
    x->len = size;
    return x;
}
Array1 * ArrayLit1(uint32_t size, uint8_t * ptr){
    Array1 * x = ArrayCreate1(size);
    memcpy(x->ptr, ptr, sizeof(uint8_t) * size);
    return x;
}
static inline Mut0 * MutCreate0(int32_t v0){
    Mut0 * x = malloc(sizeof(Mut0));
    x->v0 = v0;
    return x;
}
static inline Mut1 * MutCreate1(int32_t v0){
    Mut1 * x = malloc(sizeof(Mut1));
    x->v0 = v0;
    return x;
}
bool method2(int32_t v0, Mut1 * v1){
    int32_t v2;
    v2 = v1->v0;
    return v2 < v0;
}
void method1(Mut0 * v0, Array1 * v1, UH0 * v2){
    switch (v2->tag) {
        case 0: { // Cons
            char v3 = v2->case0.v0; int32_t v4 = v2->case0.v1; String * v5 = v2->case0.v2; UH0 * v6 = v2->case0.v3;
            int32_t v7;
            v7 = v0->v0;
            System.Span<uint8_t> v8;
            v8 = System.Span(v1,v7,4l);
            bool v9;
            v9 = System.BitConverter.TryWriteBytes(v8,0l);
            bool v10;
            v10 = v9 == false;
            if (v10){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
                
            }
            int32_t v11;
            v11 = v7 + 4l;
            v0->v0 = v11;
            int32_t v12;
            v12 = v0->v0;
            System.Span<uint8_t> v13;
            v13 = System.Span(v1,v12,2l);
            bool v14;
            v14 = System.BitConverter.TryWriteBytes(v13,v3);
            bool v15;
            v15 = v14 == false;
            if (v15){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
                
            }
            int32_t v16;
            v16 = v12 + 2l;
            v0->v0 = v16;
            int32_t v17;
            v17 = v0->v0;
            System.Span<uint8_t> v18;
            v18 = System.Span(v1,v17,4l);
            bool v19;
            v19 = System.BitConverter.TryWriteBytes(v18,v4);
            bool v20;
            v20 = v19 == false;
            if (v20){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
                
            }
            int32_t v21;
            v21 = v17 + 4l;
            v0->v0 = v21;
            Array0 * v22;
            v22 = v5.ToCharArray();
            int32_t v23;
            v23 = v22->len;;
            int32_t v24;
            v24 = v0->v0;
            System.Span<uint8_t> v25;
            v25 = System.Span(v1,v24,4l);
            bool v26;
            v26 = System.BitConverter.TryWriteBytes(v25,v23);
            bool v27;
            v27 = v26 == false;
            if (v27){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
                
            }
            int32_t v28;
            v28 = v24 + 4l;
            v0->v0 = v28;
            Mut1 * v29;
            v29 = MutCreate1(0l);
            while (method2(v23, v29)){
                int32_t v31;
                v31 = v29->v0;
                char v32;
                v32 = v22->ptr[v31];
                int32_t v33;
                v33 = v0->v0;
                System.Span<uint8_t> v34;
                v34 = System.Span(v1,v33,2l);
                bool v35;
                v35 = System.BitConverter.TryWriteBytes(v34,v32);
                bool v36;
                v36 = v35 == false;
                if (v36){
                    fprintf(stderr, "%s\n", "Conversion failed.")
                    exit(EXIT_FAILURE);
                } else {
                    
                }
                int32_t v37;
                v37 = v33 + 2l;
                v0->v0 = v37;
                int32_t v38;
                v38 = v31 + 1l;
                v29->v0 = v38;
            }
            return method1(v0, v1, v6);
            break;
        }
        case 1: { // Nil
            int32_t v39;
            v39 = v0->v0;
            System.Span<uint8_t> v40;
            v40 = System.Span(v1,v39,4l);
            bool v41;
            v41 = System.BitConverter.TryWriteBytes(v40,1l);
            bool v42;
            v42 = v41 == false;
            if (v42){
                fprintf(stderr, "%s\n", "Conversion failed.")
                exit(EXIT_FAILURE);
            } else {
                
            }
            int32_t v43;
            v43 = v39 + 4l;
            v0->v0 = v43;
            break;
        }
    }
}
UH0 * method3(Mut0 * v0, Array1 * v1){
    int32_t v2;
    v2 = v0->v0;
    int32_t v3;
    v3 = v2 + 4l;
    v0->v0 = v3;
    int32_t v4;
    v4 = System.BitConverter.ToInt32(v1,v2);
    switch (v4) {
        case 0: {
            int32_t v6;
            v6 = v0->v0;
            int32_t v7;
            v7 = v6 + 2l;
            v0->v0 = v7;
            char v8;
            v8 = System.BitConverter.ToChar(v1,v6);
            int32_t v9;
            v9 = v0->v0;
            int32_t v10;
            v10 = v9 + 4l;
            v0->v0 = v10;
            int32_t v11;
            v11 = System.BitConverter.ToInt32(v1,v9);
            int32_t v12;
            v12 = v0->v0;
            int32_t v13;
            v13 = v12 + 4l;
            v0->v0 = v13;
            int32_t v14;
            v14 = System.BitConverter.ToInt32(v1,v12);
            Array0 * v15;
            v15 = ArrayCreate0(v14);
            Mut1 * v16;
            v16 = MutCreate1(0l);
            while (method2(v14, v16)){
                int32_t v18;
                v18 = v16->v0;
                int32_t v19;
                v19 = v0->v0;
                int32_t v20;
                v20 = v19 + 2l;
                v0->v0 = v20;
                char v21;
                v21 = System.BitConverter.ToChar(v1,v19);
                v15->ptr[v18] = v21;
                int32_t v22;
                v22 = v18 + 1l;
                v16->v0 = v22;
            }
            String * v23;
            v23 = System.String(v15);
            UH0 * v24;
            v24 = method3(v0, v1);
            return UH0_0(v8, v11, v23, v24);
            break;
        }
        case 1: {
            return UH0_1();
            break;
        }
        default: {
            fprintf(stderr, "%s\n", "Invalid tag.")
            exit(EXIT_FAILURE);
        }
    }
}
bool method4(UH0 * v0, UH0 * v1){
    switch (v1->tag == v0->tag ? v1->tag : -1) {
        case 0: { // Cons
            char v2 = v1->case0.v0; int32_t v3 = v1->case0.v1; String * v4 = v1->case0.v2; UH0 * v5 = v1->case0.v3;
            char v6 = v0->case0.v0; int32_t v7 = v0->case0.v1; String * v8 = v0->case0.v2; UH0 * v9 = v0->case0.v3;
            bool v10;
            v10 = v2 == v6;
            bool v14;
            if (v10){
                bool v11;
                v11 = v3 == v7;
                if (v11){
                    v14 = v4 == v8;
                } else {
                    v14 = false;
                }
            } else {
                v14 = false;
            }
            if (v14){
                return method4(v9, v5);
            } else {
                return false;
            }
            break;
        }
        case 1: { // Nil
            return true;
            break;
        }
        default: {
            return false;
        }
    }
}
void main(){
    int32_t v0;
    v0 = 1l;
    int32_t v1;
    v1 = 2l;
    char v2;
    v2 = 'z';
    int32_t v3;
    v3 = 1l;
    String * v4;
    v4 = StringLit(1, "a");
    char v5;
    v5 = 'x';
    int32_t v6;
    v6 = 2l;
    String * v7;
    v7 = StringLit(1, "s");
    UH0 * v8;
    v8 = UH0_1();
    UH0 * v9;
    v9 = UH0_0(v5, v6, v7, v8);
    UH0 * v10;
    v10 = UH0_0(v2, v3, v4, v9);
    int32_t v11;
    v11 = method0(v10);
    int32_t v12;
    v12 = 4l + v11;
    int32_t v13;
    v13 = 4l + v12;
    Array1 * v14;
    v14 = ArrayCreate1(v13);
    Mut0 * v15;
    v15 = MutCreate0(0l);
    int32_t v16;
    v16 = v15->v0;
    System.Span<uint8_t> v17;
    v17 = System.Span(v14,v16,4l);
    bool v18;
    v18 = System.BitConverter.TryWriteBytes(v17,v0);
    bool v19;
    v19 = v18 == false;
    if (v19){
        fprintf(stderr, "%s\n", "Conversion failed.")
        exit(EXIT_FAILURE);
    } else {
        
    }
    int32_t v20;
    v20 = v16 + 4l;
    v15->v0 = v20;
    int32_t v21;
    v21 = v15->v0;
    System.Span<uint8_t> v22;
    v22 = System.Span(v14,v21,4l);
    bool v23;
    v23 = System.BitConverter.TryWriteBytes(v22,v1);
    bool v24;
    v24 = v23 == false;
    if (v24){
        fprintf(stderr, "%s\n", "Conversion failed.")
        exit(EXIT_FAILURE);
    } else {
        
    }
    int32_t v25;
    v25 = v21 + 4l;
    v15->v0 = v25;
    method1(v15, v14, v10);
    int32_t v26;
    v26 = v15->v0;
    bool v27;
    v27 = v26 == v13;
    bool v28;
    v28 = v27 == false;
    if (v28){
        fprintf(stderr, "%s\n", "The size of the array does not correspond to the amount being pickled.")
        exit(EXIT_FAILURE);
    } else {
        
    }
    Mut0 * v29;
    v29 = MutCreate0(0l);
    int32_t v30;
    v30 = v29->v0;
    int32_t v31;
    v31 = v30 + 4l;
    v29->v0 = v31;
    int32_t v32;
    v32 = System.BitConverter.ToInt32(v14,v30);
    int32_t v33;
    v33 = v29->v0;
    int32_t v34;
    v34 = v33 + 4l;
    v29->v0 = v34;
    int32_t v35;
    v35 = System.BitConverter.ToInt32(v14,v33);
    UH0 * v36;
    v36 = method3(v29, v14);
    int32_t v37;
    v37 = v29->v0;
    int32_t v38;
    v38 = v14->len;;
    bool v39;
    v39 = v37 == v38;
    bool v40;
    v40 = v39 == false;
    if (v40){
        fprintf(stderr, "%s\n", "The size of the array does not correspond to the amount being unpickled.")
        exit(EXIT_FAILURE);
    } else {
        
    }
    bool v41;
    v41 = v0 == v32;
    bool v45;
    if (v41){
        bool v42;
        v42 = v1 == v35;
        if (v42){
            v45 = method4(v36, v10);
        } else {
            v45 = false;
        }
    } else {
        v45 = false;
    }
    bool v46;
    v46 = v45 == false;
    if (v46){
        fprintf(stderr, "%s\n", "Serialization and deserialization should have the same result as the original.")
        exit(EXIT_FAILURE);
    } else {
        return ;
    }
}
