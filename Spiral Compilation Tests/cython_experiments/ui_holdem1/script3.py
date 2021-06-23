import time

a = time.perf_counter()
time.sleep(2)
b = time.perf_counter()
print(f'{b-a:0.4f}')