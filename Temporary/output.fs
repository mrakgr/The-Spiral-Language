module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

System.Console.WriteLine("I am in a.")
System.Console.WriteLine("[state=, 0]")
System.Console.WriteLine("[x=, 100]")
System.Console.WriteLine("I am in a.")
System.Console.WriteLine("[state=, 200]")
System.Console.WriteLine("[x=, 200]")
System.Console.WriteLine("I am in b.")
System.Console.WriteLine("[state=, 0]")
System.Console.WriteLine("[x=, 100]")
System.Console.WriteLine("I am in a.")
System.Console.WriteLine("[state=, 500]")
System.Console.WriteLine("[x=, 300]")
System.Console.WriteLine("I am in b.")
System.Console.WriteLine("[state=, 200]")
System.Console.WriteLine("[x=, 200]")
System.Console.WriteLine("I am in c.")
System.Console.WriteLine("[state=, 0]")
System.Console.WriteLine("[x=, 100]")
System.Console.WriteLine("I am in b.")
System.Console.WriteLine("[state=, 500]")
System.Console.WriteLine("[x=, 300]")
System.Console.WriteLine("I am in c.")
System.Console.WriteLine("[state=, 200]")
System.Console.WriteLine("[x=, 200]")
System.Console.WriteLine("I am in c.")
System.Console.WriteLine("[state=, 500]")
System.Console.WriteLine("[x=, 300]")

