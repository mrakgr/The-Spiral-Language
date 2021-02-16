import numpy
import pyximport
pyximport.install(language_level=3,setup_args={"include_dirs":numpy.get_include()})
import nets_test
print(nets_test.main())