// https://docs.nvidia.com/cuda/cublas/index.html#cublas-lt-t-gt-spmv
// This is the row major version.
let u n j i = i+((2*n-j+1)*j)/2
let l n j i = i+(j*(j+1))/2

l 3 2 2