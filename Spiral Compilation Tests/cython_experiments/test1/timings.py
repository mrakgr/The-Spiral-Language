import timeit

cy = timeit.timeit("test_cy.test(5000)", setup="import test_cy", number=1000)
py = timeit.timeit("test_py.test(5000)", setup="import test_py", number=1000)

print(py, cy)
print("Cython is {} times faster than Python.".format(py/cy))