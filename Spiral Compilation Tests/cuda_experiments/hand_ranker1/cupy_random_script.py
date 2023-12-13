import cupy as cp
# cp.random.BitGenerator = cp.random.Philox4x3210
gen = cp.random.Generator(cp.random.Philox4x3210(size=2 ** 18))

print(gen.random([10,10]))
print(2 ** 18)