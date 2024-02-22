m,n,k = 16, 16, 8
frag_registers = (m*k+n*k+m*n*2)/4/32
global_array_ptrs_registers = 3*2 # Because they are 64 bit pointers.
print(frag_registers)