import numpy as np
import pyximport
pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
from performance_test import main
import timeit
print(timeit.timeit(main,number=10))