module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

let (var_1: (char [])) = System.IO.File.ReadAllText("C:\\ML Datasets\\TinyShakespeare\\tiny_shakespeare.txt").ToCharArray()

